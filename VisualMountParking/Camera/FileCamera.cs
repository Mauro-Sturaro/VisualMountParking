using System;
using System.Drawing;
using System.Threading.Tasks;
using VisualMountParking.Properties;

namespace VisualMountParking.Camera
{
    internal class FileCamera : ICamera
    {
        string _FilePath;

        public void Initialize(string settings)
        {
            _FilePath = settings;  
        }

        public Task<Bitmap> LoadImageAsync()
        {
            try
            {
                var image = Image.FromFile(_FilePath);
                if (! (image is  Bitmap))
                    image = new Bitmap(image);
                return Task.FromResult((Bitmap)image);

            }
            catch (Exception)
            {
                return Task.FromResult(Resources.error);
            }

        }
        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }

}
