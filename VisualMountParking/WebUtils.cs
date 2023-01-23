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
		public async Task<Bitmap> LoadImageAsync(ImageSourceType sourceType, string source)
		{
			try
			{
				if (sourceType == ImageSourceType.URL)
				{
					var img = await LoadFromUrlAsync(source);
					return img;
				}
				else
					return LoadFromFile(source);

			}
			catch (Exception)
			{
				return Resources.error;
			}
		}
		public Bitmap LoadImage(ImageSourceType sourceType, string source)
		{
			try
			{
				if (sourceType == ImageSourceType.URL)
				{
					var img = LoadFromUrl(source);
					return img;
				}
				else
					return LoadFromFile(source);

			}
			catch (Exception)
			{
				return Resources.error;
			}
		}


		private Bitmap LoadFromFile(string source)
		{
			var image = Image.FromFile(source);
			if (image is Bitmap)
				return (Bitmap)image;
			return new Bitmap(image);
		}

		private async Task<Bitmap> LoadFromUrlAsync(string imageUrl)
		{
			var client = new HttpClient();
			var uri = new Uri(imageUrl);
			var response = await client.GetAsync(imageUrl);
			var stream = await response.Content.ReadAsStreamAsync();
			var image = Image.FromStream(stream);

			stream.Flush();
			stream.Close();
			client.Dispose();

			if (image is Bitmap)
				return (Bitmap)image;
			return new Bitmap(image);
		}

		private Bitmap LoadFromUrl (string imageUrl)
		{
			var client = new WebClient();
			var stream =  client.OpenRead(imageUrl);		 
			var image = Image.FromStream(stream);

			stream.Flush();
			stream.Close();
			client.Dispose();

			if (image is Bitmap)
				return (Bitmap)image;
			return new Bitmap(image);
		}

		public async Task<HttpResponseMessage> RunCommandURIAsync(CommandUri command)
		{
			var client = new HttpClient();

			var content = new StringContent(command.Body,
												Encoding.UTF8,
												"application/json"); //CONTENT-TYPE header

			HttpResponseMessage response;

			if (command.CommandVerb == CommandVerb.Get)
				response = await client.GetAsync(command.Uri);
			else
				response = await client.PostAsync(command.Uri, content);


			return response;
		}
	}
}
