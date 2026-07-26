using Emgu.CV;
using System;
using System.Drawing;
using System.Threading.Tasks;
using VisualMountParking.Properties;

namespace VisualMountParking.Camera
{
    internal class Webcam : ICamera
    {
        string param;
        VideoCapture _capture;
        readonly object _lock = new object();
        Mat _frame = new Mat();

        void ICamera.Initialize(string settings)
        {
            param = settings;
        }

        async Task<Bitmap> ICamera.LoadImageAsync()
        {
            if (_capture == null)
            {
                if (!int.TryParse(param, out var n))
                    n = 0;
                _capture = new VideoCapture(n, VideoCapture.API.DShow);
                _capture.ImageGrabbed += Capture_ImageGrabbed;
                _capture.Start();
                await Task.Delay(200);
            }

            // Il frame più recente arriva dal thread di grab continuo avviato con Start():
            // non richiamare QueryFrame() qui, altrimenti competerebbe con quel thread
            // sulla stessa VideoCapture nativa (non thread-safe).
            lock (_lock)
            {
                if (_frame.IsEmpty)
                    return Resources.error;
                return _frame.ToBitmap();
            }
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            lock (_lock)
            {
                if (_capture != null && _capture.Ptr != IntPtr.Zero)
                {
                    _capture.Retrieve(_frame, 0);
                }
            }
        }

        public void Dispose()
        {
            // Lo scambio del riferimento avviene sotto lock, cosi' Capture_ImageGrabbed
            // (che gira su un thread nativo separato) non puo' mai vedere ne' usare un
            // oggetto a meta' smontato: o lo trova ancora valido, o lo trova gia' a null.
            VideoCapture toDispose;
            lock (_lock)
            {
                toDispose = _capture;
                _capture = null;
            }
            toDispose?.Stop();
            toDispose?.Dispose();
            System.GC.SuppressFinalize(this);
        }
    }
}