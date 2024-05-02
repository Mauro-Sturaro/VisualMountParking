using FlashCap;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace VisualMountParking.Camera
{
    public class FlashCapCamera : ICamera
    {
        string param;
        byte[] image;

        public void Initialize(string settings)
        {
            param = settings;

        }

        public async Task<Bitmap> LoadImageAsync()
        {
            if (!int.TryParse(param, out var n))
                n = 0;

            // Capture device enumeration:
            var devices = new CaptureDevices();

            // Open a device with a video characteristics:
            var descriptor0 = devices.EnumerateDescriptors().ElementAt(n);


            var device = await descriptor0.OpenAsync(
                descriptor0.Characteristics[6],
                async bufferScope =>
                {
                    // Captured into a pixel buffer from an argument.

                    // Get image data (Maybe DIB/JPEG/PNG):
                    image = bufferScope.Buffer.CopyImage();

                });
            await device.StartAsync();

            byte[] imageData;
            if (image == null)
            {
                imageData = image;
            }
            else
            {
                imageData = await descriptor0.TakeOneShotAsync(descriptor0.Characteristics[0]);
            }
            var ms = new System.IO.MemoryStream(imageData);
            var bitmap1 = Bitmap.FromStream(ms);
            return (Bitmap)bitmap1;
        }
        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }

}
