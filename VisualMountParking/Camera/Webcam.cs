using Emgu.CV;
using System;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VisualMountParking.Properties;

namespace VisualMountParking.Camera
{
    internal class Webcam : ICamera
    {
        string param;
        VideoCapture _capture;
        Mat _frame = new Mat();

        void ICamera.Initialize(string settings)
        {
            param = settings;
        }

        async Task<Bitmap> ICamera.LoadImageAsync()
        {
            Bitmap b;

            if (_capture == null)
            {
                if (!int.TryParse(param, out var n))
                    n = 0;
                _capture = new VideoCapture(n, VideoCapture.API.DShow);
                _capture.ImageGrabbed += Capture_ImageGrabbed;
                _capture.Start();            
                await Task.Delay(200);
            }
            var frame = _capture.QueryFrame();
            if (frame is null)
                return Resources.error;
            else
            {
                b = frame.ToBitmap();
                return b;
            }
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                _capture.Retrieve(_frame, 0);
            }
        }

        public void Dispose()
        {
            _capture?.Stop();
            _capture?.Dispose();
            _capture = null;
            System.GC.SuppressFinalize(this);
        }
    }
}