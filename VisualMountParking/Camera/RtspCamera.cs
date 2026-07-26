using Emgu.CV;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using VisualMountParking.Properties;

namespace VisualMountParking.Camera
{
    // Settings = URL RTSP completo, es. rtsp://user:pwd@192.168.1.100:554/h264Preview_01_sub
    // Per una Reolink conviene il sub-stream: framerate/risoluzione più bassi si avvicinano
    // al ritmo con cui LoadImageAsync viene chiamato, riducendo l'accumulo di frame in coda.
    internal class RtspCamera : ICamera
    {
        string _url;
        readonly object _lock = new object();
        VideoCapture _capture;
        Mat _frame = new Mat();
        Task _connectTask;
        bool _disposed;
        string _lastError;

        public void Initialize(string settings)
        {
            _url = settings;
        }

        // Usata da SettingsForm per far attendere la Preview finché non arriva un frame vero,
        // invece che mostrare subito un tentativo a vuoto mentre la connessione è in corso.
        public bool IsReady
        {
            get { lock (_lock) return _capture != null && !_frame.IsEmpty; }
        }

        public Task<Bitmap> LoadImageAsync()
        {
            lock (_lock)
            {
                if (_disposed)
                    return Task.FromResult((Bitmap)Resources.error);

                if (_capture != null && !_capture.IsOpened)
                {
                    // Stream caduto: lo stacchiamo subito, lo smontaggio (potenzialmente lento)
                    // avviene in background; al prossimo giro si tenta una nuova connessione.
                    var stale = _capture;
                    _capture = null;
                    Task.Run(() => TearDown(stale));
                }

                if (_capture == null)
                {
                    if (_connectTask == null || _connectTask.IsCompleted)
                    {
                        if (_connectTask?.IsFaulted == true)
                        {
                            var ex = _connectTask.Exception?.GetBaseException();
                            _lastError = ex?.Message;
                            Debug.WriteLine($"RtspCamera connect failed for '{_url}': {ex}");
                        }
                        _connectTask = Task.Run(Connect);
                    }
                    return Task.FromResult(GetPlaceholder(_lastError));
                }

                if (_frame.IsEmpty)
                    return Task.FromResult(GetPlaceholder(_lastError));

                return Task.FromResult(_frame.ToBitmap());
            }
        }

        private void Connect()
        {
            Environment.SetEnvironmentVariable("OPENCV_FFMPEG_CAPTURE_OPTIONS", "rtsp_transport;tcp");

            var capture = new VideoCapture(_url, VideoCapture.API.Ffmpeg);
            try
            {
                capture.ImageGrabbed += Capture_ImageGrabbed;
                capture.Start();
            }
            catch
            {
                capture.Dispose();
                throw;
            }

            lock (_lock)
            {
                if (_disposed)
                {
                    // Dispose() è arrivato mentre ci stavamo connettendo: chiudiamo subito
                    // quanto appena aperto invece di pubblicarlo.
                    TearDown(capture);
                    return;
                }
                _capture = capture;
            }
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            lock (_lock)
            {
                if (_capture != null && _capture.Ptr != IntPtr.Zero)
                    _capture.Retrieve(_frame, 0);
            }
        }

        private static void TearDown(VideoCapture capture)
        {
            capture.Stop();
            // Il thread di grab di Emgu.CV controlla lo stop tra un frame e l'altro, non durante
            // una Grab() già in corso: questa pausa dà il tempo a una lettura in volo di
            // concludersi (nel caso comune di rete sana, in genere pochi ms) prima di liberare
            // l'oggetto nativo.
            Thread.Sleep(300);
            capture.Dispose();
        }

        private static Bitmap GetPlaceholder(string lastError)
        {
            var text = "Connessione RTSP in corso...";
            if (!string.IsNullOrEmpty(lastError))
                text += "\n\nUltimo errore:\n" + lastError;

            var bmp = new Bitmap(640, 480);
            using (var g = Graphics.FromImage(bmp))
            using (var font = new Font("Segoe UI", 12, FontStyle.Bold))
            using (var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.Clear(Color.FromArgb(45, 45, 48));
                var rect = new RectangleF(20, 20, bmp.Width - 40, bmp.Height - 40);
                g.DrawString(text, font, Brushes.Gainsboro, rect, format);
            }
            return bmp;
        }

        public void Dispose()
        {
            VideoCapture toDispose;
            lock (_lock)
            {
                _disposed = true;
                toDispose = _capture;
                _capture = null;
            }
            if (toDispose != null)
                TearDown(toDispose);
            GC.SuppressFinalize(this);
        }
    }
}
