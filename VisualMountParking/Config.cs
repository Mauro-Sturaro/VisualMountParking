using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System;
using System.Drawing.Imaging;

namespace VisualMountParking
{

	public class Config
	{
		public List<Zone> Templates { get; set; } = new List<Zone>();

		//[JsonConverter(typeof(BitmapJsonConverter))]
		[JsonIgnore]
		public Bitmap ReferenceImage { get; set; }

		public string Source { get; set; }


		public ImageSourceType SourceType { get; set; }

		public CommandUri LightOnCommand { get; set; }
		public CommandUri LightOffCommand { get; set; }

		public int MoveRaStep { get; set; }
		public int MoveDecStep { get; set; }
		public bool RevertRa { get; set; }
		public bool RevertDec { get; set; }

		public string TelescopeDriver { get; set; }

		private static string GetConfigPath()
		{
			string appName = "VisualMountParking";
			var appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), appName);
			if (!Directory.Exists(appdata))
				Directory.CreateDirectory(appdata);
			return appdata;
		}
		//--------------------
		private static string GetConfigFilename()
		{
			var appdata = GetConfigPath();
			var configFilename = Path.Combine(appdata, "Config.json");
			return configFilename;
		}
		private static string GetImageFilename()
		{
			var appdata = GetConfigPath();
			var configFilename = Path.Combine(appdata, "ReferenceImage.png");
			return configFilename;
		}

		public void Save()
		{
			var filename = GetConfigFilename();
			string jsonString = JsonSerializer.Serialize(this);
			File.WriteAllText(filename, jsonString);
			var imageFilename = GetImageFilename();
			ReferenceImage.Save(imageFilename);
		}

		public static Config Load()
		{
			var filename = GetConfigFilename();
			Config cfg;
			if (File.Exists(filename))
			{
				string jsonString = File.ReadAllText(filename);
				cfg = JsonSerializer.Deserialize<Config>(jsonString);
				var imageFileName = GetImageFilename();
				if (File.Exists(imageFileName))
				{
					using (var img = Image.FromFile(imageFileName))
					{
						cfg.ReferenceImage =  new Bitmap(img);
					}
				}
			}
			else
			{
				cfg = new Config();
			}
			// adjust some value
			if (cfg.MoveRaStep <= 0)
				cfg.MoveRaStep = 600;
			if (cfg.MoveDecStep <= 0)
				cfg.MoveDecStep = 600;


			return cfg;
		}

		public Config Clone()
		{
			string jsonString = JsonSerializer.Serialize(this);
			var newcfg = JsonSerializer.Deserialize<Config>(jsonString);
			//newcfg.ReferenceImage = (Bitmap)ReferenceImage.Clone();//   CopyBitmap(ReferenceImage);
			newcfg.ReferenceImage = new Bitmap(ReferenceImage);
			return newcfg;
		}


		private Bitmap CopyBitmap(Bitmap bitmap)
		{
			var ms = new MemoryStream();
			bitmap.Save(ms, ImageFormat.Png);
			ms.Position = 0;
			return (Bitmap)Image.FromStream(ms);
		}
	}

	public enum ImageSourceType { File, URL }

}
