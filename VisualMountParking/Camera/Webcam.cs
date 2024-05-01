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
        VideoCapture capture;

        void ICamera.Initialize(string settings)
        {
            param = settings;
        }

        Task<Bitmap> ICamera.LoadImageAsync()
        {
            Bitmap b;

            if (capture == null)
            {
                if (!int.TryParse(param, out var n))
                    n = 0;
                capture = new VideoCapture(n,VideoCapture.API.DShow);
            }
            int repeat = 10;
            Mat frame =null;
            while (frame is null && repeat-- > 0)
            {
                frame = capture.QueryFrame();
            }
            if (frame is null)
                return Task.FromResult(Resources.error);
            else
            {
                b = frame.ToBitmap();
                return Task.FromResult(b);
            }
        }
    }
}