using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using VisualMountParking.Properties;

namespace VisualMountParking.Camera
{
    internal class UrlCamera : ICamera
    {
        // REOLINK Camera WebAPI documentation https://drive.google.com/file/d/15AFMQSMlMdpjL2USPsvYd-J9xWecrEf9/view

        string _URL;

        public void Initialize(string settings)
        {
           _URL = settings;
        }

        public async Task<Bitmap> LoadImageAsync()
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(_URL);
                var stream = await response.Content.ReadAsStreamAsync();
                var image = Image.FromStream(stream);

                stream.Flush();
                stream.Close();
                client.Dispose();

                if (image is Bitmap)
                    return (Bitmap)image;
                return new Bitmap(image);
            }
            catch (Exception)
            {
                return Resources.error;
            }
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }

}
