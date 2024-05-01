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
	
		private Bitmap LoadFromFile(string source)
		{
			var image = Image.FromFile(source);
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
