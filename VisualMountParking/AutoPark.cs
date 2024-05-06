using ASCOM.DeviceInterface;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using VisualMountParking.Camera;
using VisualMountParking.Markers;
using System.Linq;

namespace VisualMountParking
{
    internal class AutoPark
    {
        private MyTelescope _MyTelescope;
        private MarkerMatchEngine _MarkerMatch = new MarkerMatchEngine(null);
        private Config _Config;
        private ICamera _Camera;

        public Bitmap CurrentImage { get; private set; }
        public void Initialize(Config config, MarkerMatchEngine markerMatch, MyTelescope myTelescope)
        {
            _Config = config;
            _MarkerMatch = markerMatch;
            _MyTelescope = myTelescope;
            ConnectCamera(config);
        }

        public void ChangeVerifier(MarkerMatchEngine marlerMatch)
        {
            _MarkerMatch = marlerMatch;
        }

        private void ConnectCamera(Config config)
        {
            _Camera?.Dispose();
            try
            {
                _Camera = CameraFactory.Instance.GetCamera(config.CameraName);
                _Camera.Initialize(config.CameraSettings);
            }
            catch
            {
                _Camera = CameraFactory.Instance.GetCamera("None");
            }
        }

        public Action<string> Logger { get; set; }

        private void LogWriteLine(string message)
        {
            if (Logger == null)
                return;
            Logger(message);
            Logger("\r\n");
        }

        /// <summary>
        /// Get Marker position relative to target
        /// </summary>
        private async Task<(double, double)> GetMarkerRelativePositionAsync(int markerId)
        {
            await UpdateImageAndPosition();
            var zone = _MarkerMatch.MatchList.Find((z) => z.ZoneId == markerId);
            if (zone == null || zone.Target == null)
                throw new Exception($"Marker {markerId} not found.");

            var x = zone.Target.X - zone.Source.X;
            var y = zone.Target.Y - zone.Source.Y;
            (double, double) res = (x, y);
            return res;
            //var distance = Math.Sqrt(Math.Pow(zone.Target.X - zone.Source.X, 2) + Math.Pow(zone.Target.Y - zone.Source.Y, 2));
            //return distance;
        }

        public async Task UpdateImageAndPosition()
        {
            await LoadNewImage();
            await CheckPosition(CurrentImage);
        }

        private EventHandler<ImageChangedEventArgs> _ImageChanged;
        public event EventHandler<ImageChangedEventArgs> ImageChanged { add { _ImageChanged += value; } remove { _ImageChanged -= value; } }

        public async Task<bool> LoadNewImage()
        {
            var image = await _Camera.LoadImageAsync();

            var previousImage = CurrentImage;
            var eh = _ImageChanged;
            if (eh != null)
                eh(this, new ImageChangedEventArgs { NewImage = image });
            previousImage?.Dispose();
            CurrentImage = image;

            ////-- per debug
            //CurrentImage = _PatternVerifier.GetDetectionImage();
            ////

            return true;
        }

        /// <summary>
        /// Position of RA/DEC Markers is in tolerance range?
        /// null if Markers are not detected.
        /// </summary>
        public bool? InRange { get; set; }

        public async Task CheckPosition(Bitmap image)
        {
            await Task.Run(() =>
            {
                _MarkerMatch.SearchMatch(image);
                var ar = _MarkerMatch.MatchList.FirstOrDefault((m) => m.ZoneId == _Config.AutoParkAR.MarkerId);
                var dec = _MarkerMatch.MatchList.FirstOrDefault((m) => m.ZoneId == _Config.AutoParkDec.MarkerId);
                if (ar == null || dec == null)
                {
                    InRange = null;
                }
                else
                {
                    var maxdelta = 2;
                    InRange = ar.GetDistance() <= maxdelta && dec.GetDistance() < maxdelta;
                }
            });
        }

        internal IList<MarkerPoint> GetReferenceZone()
        {
            return _MarkerMatch.ReferenceMarkers;
        }

        internal IList<ZoneMatch> GetZoneMatch(bool all = true)
        {
            var matchList = _MarkerMatch.MatchList;
            if (all)
                foreach (var zone in GetReferenceZone())
                {
                    if (!matchList.Exists((m) => m.ZoneId == zone.Id))
                    {
                        var z = new ZoneMatch { ZoneId = zone.Id, Source = zone };
                        matchList.Add(z);
                    }
                }
            return matchList;
        }

        public async Task<bool> SlaveToReference(CancellationToken cancellationToken)
        {
            // Questi devono stare nei settings
            var apRA = _Config.AutoParkAR;
            var apDec = _Config.AutoParkDec;

            var raRate = _Config.MoveRaRate;
            var raTime = _Config.MoveRaTime * _Config.FastTimeMultiplier;
            var decRate = _Config.MoveDecRate;
            var decTime = _Config.MoveDecTime * _Config.FastTimeMultiplier;

            Debug.WriteLine($"-- Slave RA Axis --");
            await SlewOneAxis(TelescopeAxes.axisPrimary, raRate, raTime, apRA.ReverseDirection, apRA.MarkerId, cancellationToken);
            Debug.WriteLine($"-- Slave DEC Axis --");
            await SlewOneAxis(TelescopeAxes.axisSecondary, decRate, decTime, apDec.ReverseDirection, apDec.MarkerId, cancellationToken);

            Debug.WriteLine($"Slave completed");
            return true;

        }

        private async Task<double> SlewOneAxis(TelescopeAxes axis, double rate, double time, bool reverseDirection, int markerId, CancellationToken cancellationToken)
        {
            //bool fast = true;
            double fraction = 1;
            if (markerId > 0)
            {
                // Calc initial sense of the vector movement
                var marker = await GetMarkerRelativePositionAsync(markerId);
                var reverse = (marker.Item1 < 0);
                if (reverseDirection)
                    reverse = !reverse;
                if (reverse)
                    rate *= -1;

                // Verify distance
                var Ax = marker.Item1;
                var Ay = marker.Item2;
                var initialDistance = Math.Sqrt(Math.Pow(Ax, 2) + Math.Pow(Ay, 2));
                if (initialDistance < 1)
                    return 0;

                // If tpp is know recalc inital time
                if (savedTravelTime.TryGetValue(axis, out double tpp))
                {                    
                    time = tpp * initialDistance;
                }

                while (time > 0.2)
                {
                    // do the movement
                    fraction = await MinimizeDistance(markerId, axis, rate, time, cancellationToken);
                    if (!IsValidNonZero(fraction))
                        break;

                    rate = rate * Math.Sign(fraction);
                    time = time * Math.Abs(fraction);

                    //if (fast && raTime < 100)
                    //{
                    //    raRate /= 2;
                    //    raTime *= 2;
                    //    fast = false;
                    //    Debug.WriteLine("--> slow down!");
                    //}

                }
            }

            return fraction;
        }

        private bool IsValidNonZero(double n)
        {
            if (n == 0 || double.IsNaN(n) || double.IsInfinity(n))
                return false;
            return true;
        }


        private Dictionary<TelescopeAxes, double> savedTravelTime = new Dictionary<TelescopeAxes, double>();

        private async Task<double> MinimizeDistance(int markerId, TelescopeAxes axis, double moveRate, double moveTime, CancellationToken cancellationToken)
        {
            var A = await GetMarkerRelativePositionAsync(markerId);
            var Ax = A.Item1;
            var Ay = A.Item2;
            var initialDistance = Math.Sqrt(Math.Pow(Ax, 2) + Math.Pow(Ay, 2));
            if (initialDistance < 0.5)
                return 0;           

            await _MyTelescope.RotateAxisAsync(axis, moveRate, moveTime, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            var B = await GetMarkerRelativePositionAsync(markerId);
            var Bx = B.Item1;
            var By = B.Item2;

            /*  ho due punti in un sistema cartesiano centrato sulla destinazione
                stanno su una retta y = m*x+q
                il punto di quella retta più vicino all'origine è l'intersezione con la retta perpendicolare di equazione y=-m*x
                Questo è il punto che voglio raggiungere continuando a muovermi nella direzione attuale (il verso viene calcolato).
            */

            if (Ax == Bx)
            {
                Debug.WriteLine($"Spostamento nullo sull'asse x -> nessun aggiustamento");
            }

            var m = (Ay - By) / (Ax - Bx);
            var q = Ay - m * Ax;

            var Cx = -q / (2 * m);

            var nextMove = (Bx - Cx) / (Ax - Bx); // frazione del movimento precedente, se positivo va nello stesso verso, se negativo in verso opposto

            var curDistance = Math.Sqrt(Math.Pow(Bx, 2) + Math.Pow(By, 2));

            if (Math.Sign(initialDistance) == Math.Sign(curDistance))
            {
                var deltaDistance = Math.Abs( initialDistance - curDistance);
                if (deltaDistance > 8)
                {
                    var timePerPixel = moveTime / deltaDistance;
                    savedTravelTime[axis] = timePerPixel;
                }
            }

            Debug.WriteLine($"Distanza iniziale={initialDistance}, Distanza rimasta = {curDistance}, tempo={moveTime}, Spostamento ottenuto {Ax - Bx},{Ay - By}, next fraction={nextMove}");

            if (curDistance < 0.5)
            {
                Debug.WriteLine("Distanza minore di 0.5 -> fine");
                return 0;
            }
            if (curDistance < 8)
                return nextMove;
            return nextMove * 0.85;
        }

    }
}
