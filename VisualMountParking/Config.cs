using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System;

namespace ChekMountPosition
{

	public class Config
	{
		public List<Zone> Templates { get; set; } = new List<Zone>();

		[JsonConverter(typeof(BitmapJsonConverter))]
		public Bitmap ReferenceImage { get; set; }

		public string Source { get; set; }
		public ImageSourceType SourceType { get; set; }

		public CommandUri LightOnCommand { get; set; }
		public CommandUri LightOffCommand { get; set; }

		public enum ImageSourceType { File, URL }


		//--------------------
		private static string GetDefaultFilename()
		{
			string appName = "ChekMountPosition";
			var appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), appName);
			Directory.CreateDirectory(appdata);
			var configFilename = Path.Combine(appdata, "Config.json");
			return configFilename;
		}

		public void Save()
		{
			var filename =  GetDefaultFilename();		
			string jsonString = JsonSerializer.Serialize(this);
			File.WriteAllText(filename, jsonString);
		}

		public static Config Load()
		{
			var filename = GetDefaultFilename();	
			Config cfg;
			if (File.Exists(filename))
			{
				string jsonString = File.ReadAllText(filename);
				cfg = JsonSerializer.Deserialize<Config>(jsonString);
				return cfg;
			}
			else
			{
				cfg = new Config();
			}
			return cfg;
		}

		public Config Clone()
		{
			string jsonString = JsonSerializer.Serialize(this);
			var newcfg = JsonSerializer.Deserialize<Config>(jsonString);
			return newcfg;
		}
	}
}
