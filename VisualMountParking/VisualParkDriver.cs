﻿using ASCOM.DeviceInterface;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using VisualMountParking.Camera;
using Emgu.CV;
using System.Windows.Forms;
using FlashCap.Utilities;

namespace VisualMountParking
{
    public class VisualParkDriver
    {
        private MyTelescope _MyTelescope;
        private readonly PatternVerifier _PatternVerifier = new PatternVerifier();
        private Config _Config;
        private ICamera _Camera;

        public Bitmap CurrentImage { get; private set; }

        public Func<Bitmap, Bitmap> AdjustImage { get; set; }

        public void Initialize(Config config)
        {
            _Config = config;
            _PatternVerifier.Initialize(config);
            ConnectCamera(config);
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

        #region Telescope actions
        public void ConnectTelescope()
        {
            _MyTelescope?.Disconnect();
            _MyTelescope = new MyTelescope();
            _MyTelescope.Initialize(_Config.TelescopeDriver);
        }

        public void DisconnectTelescope()
        {
            _MyTelescope?.Disconnect();
        }

        public void StopTelescope()
        {
            if (!IsTelescopeConnected)
                return;
            _MyTelescope.StopAnyMovement();
        }

        public async Task ParkTelescope()
        {
            if (!IsTelescopeConnected)
                return;
            await _MyTelescope.ParkTelescope();

        }
        public void UnParkTelescope()
        {
            if (!IsTelescopeConnected)
                return;

            _MyTelescope.UnParkTelescope();
        }

        public bool IsTelescopeConnected => _MyTelescope != null && _MyTelescope.IsTelescopeConnected;

        public Task RotateAxisAsync(TelescopeAxes axis, double rate, double time, CancellationToken cancellationToken) => _MyTelescope.RotateAxisAsync(axis, rate, time, cancellationToken);


        public TelescopeState TelescopeState => _MyTelescope.TelescopeState;

        #endregion telescope

        public Action<string> Logger { get; set; }

        private void LogWriteLine(string message)
        {
            if (Logger == null)
                return;
            Logger(message);
            Logger("\r\n");
        }

        private async Task<int?> GetZoneDeltaAsync(int zoneId, ShiftDirection direction)
        {
            await UpdateImageAndPosition();
            var zone = _PatternVerifier.ZoneMatchList.Find((z) => z.ZoneId == zoneId);
            if (zone == null) return null;

            var delta = direction == ShiftDirection.X ? zone.Target.X - zone.Source.X : zone.Target.Y - zone.Source.Y;
            return delta;
        }

        /// <summary>
        /// Get Marker position relative to target
        /// </summary>
        private async Task<(double, double)> GetMarkerRelativePositionAsync(int markerId)
        {
            await UpdateImageAndPosition();
            var zone = _PatternVerifier.ZoneMatchList.Find((z) => z.ZoneId == markerId);
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
            await CheckPosition();
        }

        private EventHandler _ImageUpdated;
        public event EventHandler ImageUpdated { add { _ImageUpdated += value; } remove { _ImageUpdated -= value; } }

        public async Task<bool> LoadNewImage()
        {
            var image = await _Camera.LoadImageAsync();

            if (AdjustImage != null)
                image = AdjustImage(image);

            _PatternVerifier.NewImage?.Dispose();
            _PatternVerifier.NewImage = new Bitmap(image);
            //            CurrentImage?.Dispose();
            CurrentImage = new Bitmap(image);
            ////-- per debug
            //CurrentImage = _PatternVerifier.GetDetectionImage();
            ////
            _ImageUpdated?.Invoke(this, EventArgs.Empty);
            image.Dispose();
            return true;
        }

        public async Task CheckPosition()
        {
            await Task.Run(_PatternVerifier.SearchMatch);
        }

        internal IList<Zone> GetReferenceZone()
        {
            return _PatternVerifier.ReferenceTemplates;
        }

        internal IList<ZoneMatch> GetZoneMatch(bool all = true)
        {
            var matchList = _PatternVerifier.ZoneMatchList;
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


        //------------------
        public async Task<bool> DoVisualPark(CancellationToken cancellationToken)
        {
            // Questi devono stare nei settings
            var apRA = _Config.AutoParkAR;
            var apDec = _Config.AutoParkDec;

            var raRate = _Config.MoveRaRate;
            var raTime = _Config.MoveRaTime * _Config.FastTimeMultiplier;
            var decRate = _Config.MoveDecRate;
            var decTime = _Config.MoveDecTime * _Config.FastTimeMultiplier;

            double raFraction = 1;
            double decFraction = 1;


            bool fast = true;

            if (apRA.ZoneId > 0)
            {
                // Calc initial sense of the vector movement
                var raMarker = await GetMarkerRelativePositionAsync(apRA.ZoneId);
                var reverse = (raMarker.Item1 < 0);
                if (apRA.Direction == ShiftDirection.X)
                    reverse = !reverse;
                if (reverse)
                    raRate *= -1;

                while (raTime > 0.2)
                {
                    Debug.WriteLine($"RA fraction is {raFraction}");
                    // do the movement
                    raFraction = await MinimizeDistance(apRA.ZoneId, TelescopeAxes.axisPrimary, raRate, raTime, cancellationToken);
                    if (!IsValidNonZero(raFraction))
                        break;

                    raRate = raRate * Math.Sign(raFraction);
                    raTime = raTime * Math.Abs(raFraction);

                    //if (fast && raTime < 100)
                    //{
                    //    raRate /= 2;
                    //    raTime *= 2;
                    //    fast = false;
                    //    Debug.WriteLine("--> slow down!");
                    //}

                }
            }
            if (apDec.ZoneId > 0)
            {
                // Calc initial sense of the vector movement
                var decMarker = await GetMarkerRelativePositionAsync(apDec.ZoneId);
                var reverse = (decMarker.Item1 < 0);
                if (apDec.Direction == ShiftDirection.X)
                    reverse = !reverse;
                if (reverse)
                    decRate *= -1;
                while (decTime > 0.2)
                {
                    Debug.WriteLine($"DEC fraction is {decFraction}");
                    decFraction = await MinimizeDistance(apDec.ZoneId, TelescopeAxes.axisSecondary, decRate, decTime, cancellationToken);
                    if (!IsValidNonZero(decFraction))
                        break;

                    decRate = decRate * Math.Sign(decFraction);
                    decTime = decTime * Math.Abs(decFraction);
                }
            }

            Debug.WriteLine($"Fractions are {raFraction},{decFraction} => completed");
            return true;

        }

        private bool IsValidNonZero(double n)
        {
            if (n == 0 || double.IsNaN(n) || double.IsInfinity(n))
                return false;
            return true;
        }

        private async Task<double> MinimizeDistance(int markerId, TelescopeAxes axis, double moveRate, double moveTime, CancellationToken cancellationToken)
        {
            var A = await GetMarkerRelativePositionAsync(markerId);
            var Ax = A.Item1;
            var Ay = A.Item2;
            var curDistance = Math.Sqrt(Math.Pow(Ax, 2) + Math.Pow(Ay, 2));
            if (curDistance < 1)
                return 0;

            await _MyTelescope.RotateAxisAsync(axis, moveRate, moveTime, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            var B = await GetMarkerRelativePositionAsync(markerId);
            var Bx = B.Item1;
            var By = B.Item2;

            /*  ho due punti in un sistema cartesiano centrato sulla destinazione
                stanno su una retta y = m*x+q
                il punto di quella retta più vicino all'origine è l'intersezione con la retta perpendicolare di equazione y=-m*x
                Questo è il punto che voglio raggiungere continuando a muovermi nella direzione attuale (il varso viene calcolato).
            */

            if (Ax == Bx)
            {
                Debug.WriteLine($"Spostamento nullo sull'asse x -> nessun aggiustamento");
            }

            var m = (Ay - By) / (Ax - Bx);
            var q = Ay - m * Ax;

            var Cx = -q / (2 * m);

            var nextMove = (Bx - Cx) / (Ax - Bx); // frazione del movimento precedente, se positivo va nello stesso verso, se negativo in verso opposto

            curDistance = Math.Sqrt(Math.Pow(Bx, 2) + Math.Pow(By, 2));

            Debug.WriteLine($"Spostamento ottenuto {Ax - Bx},{Ay - By}. Distanza rimasta = {curDistance} next={nextMove}");

            if (curDistance < 0.5)
            {
                Debug.WriteLine("Distanza minore di 1");
                return 0;
            }
            if (curDistance < 8)
                return nextMove;
            if (curDistance < 20)
                return nextMove * 0.8;
            return nextMove * 0.5;
        }

    }


}
