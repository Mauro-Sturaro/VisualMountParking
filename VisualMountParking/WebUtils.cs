using VisualMountParking.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace VisualMountParking
{
	internal class WebUtils
	{
		// Un solo HttpClient condiviso per tutta la vita dell'applicazione: crearne uno nuovo
		// ad ogni chiamata esaurisce le porte TCP disponibili nel lungo periodo (l'app fa polling
		// periodico), vedi https://docs.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient-guidelines
		// La telecamera Reolink in rete locale usa un certificato self-signed: il bypass della
		// validazione è scoped a questo HttpClient (unico usato per parlare con la camera),
		// non a livello di processo come con ServicePointManager.
		private static readonly HttpClient _httpClient = new HttpClient(new HttpClientHandler
		{
			ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
		});

		private Bitmap LoadFromFile(string source)
		{
			var image = Image.FromFile(source);
			if (image is Bitmap)
				return (Bitmap)image;
			return new Bitmap(image);
		}

		public async Task<HttpResponseMessage> RunCommandURIAsync(CommandUri command)
		{
			var content = new StringContent(command.Body,
												Encoding.UTF8,
												"application/json"); //CONTENT-TYPE header

			HttpResponseMessage response;

			if (command.CommandVerb == CommandVerb.Get)
				response = await _httpClient.GetAsync(command.Uri);
			else
				response = await _httpClient.PostAsync(command.Uri, content);


			return response;
		}
	}
}
