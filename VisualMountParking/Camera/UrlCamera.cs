using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using VisualMountParking.Properties;

namespace VisualMountParking.Camera
{
    internal class UrlCamera : ICamera
    {
        // REOLINK Camera WebAPI documentation https://drive.google.com/file/d/15AFMQSMlMdpjL2USPsvYd-J9xWecrEf9/view

        // Un solo HttpClient condiviso: l'immagine viene ricaricata periodicamente (polling),
        // un'istanza per chiamata esaurirebbe le porte TCP disponibili nel lungo periodo.
        // La telecamera Reolink in rete locale usa un certificato self-signed: il bypass della
        // validazione è scoped a questo HttpClient (unico usato per parlare con la camera),
        // non a livello di processo come con ServicePointManager.
        private static readonly HttpClient _httpClient = new HttpClient(new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
        });

        string _URL;

        public void Initialize(string settings)
        {
           _URL = settings;
        }

        public async Task<Bitmap> LoadImageAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_URL);
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var image = Image.FromStream(stream))
                {
                    if (image is Bitmap bmp)
                        return (Bitmap)bmp.Clone();
                    return new Bitmap(image);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"UrlCamera.LoadImageAsync failed for '{_URL}': {ex}");
                return Resources.error;
            }
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }

}
