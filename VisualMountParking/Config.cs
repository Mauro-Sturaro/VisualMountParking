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
        #region AutoPark settings
        public AutoParkSetting AutoParkAR { get; set; }
        public AutoParkSetting AutoParkDec { get; set; }

        #endregion


        #region Image settings

        [JsonIgnore] // We save the image as a distinct file
        public Bitmap ReferenceImage1 { get; set; }
        [JsonIgnore] // We save the image as a distinct file
        public Bitmap ReferenceImage2 { get; set; }
        public string CameraSettings { get; set; }
        public string CameraName { get; set; }

        #endregion

        #region Action settings

        public CommandUri LightOnCommand { get; set; }
        public CommandUri LightOffCommand { get; set; }

        #endregion

        #region Telescope setting
        public string TelescopeDriver { get; set; }

        public double MoveRaRate { get; set; }
        public double MoveDecRate { get; set; }

        public double MoveRaTime { get; set; }
        public double MoveDecTime { get; set; }

        public double FastTimeMultiplier { get; set; }
        public double FastRateMultiplier { get; set; }
        public decimal PositionTolerance { get; set; }
        #endregion

        #region Private Methods
        private static string GetConfigPath()
        {
            string appName = "VisualMountParking";
            var appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), appName);
            if (!Directory.Exists(appdata))
                Directory.CreateDirectory(appdata);
            return appdata;
        }
        private static string GetConfigFilename()
        {
            var appdata = GetConfigPath();
            var configFilename = Path.Combine(appdata, "Config.json");
            return configFilename;
        }
        private static string GetImageFilename(int n)
        {
            var appdata = GetConfigPath();
            var configFilename = Path.Combine(appdata, $"ReferenceImage{n}.png");
            return configFilename;
        }
        #endregion

        #region Public Methods
        public void Save()
        {
            var filename = GetConfigFilename();
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(filename, jsonString);
            if (ReferenceImage1 != null)
                ReferenceImage1.Save(GetImageFilename(1));
            if (ReferenceImage2 != null)
                ReferenceImage2.Save(GetImageFilename(2));
        }

        private static Bitmap LoadImage(int n)
        {
            var imageFileName = GetImageFilename(n);
            if (File.Exists(imageFileName))
            {
                using (var img = Image.FromFile(imageFileName))
                {
                    return new Bitmap(img);
                }
            }
            else
                return null;
        }

        public static Config Load()
        {
            var filename = GetConfigFilename();
            Config cfg;
            if (File.Exists(filename))
            {
                string jsonString = File.ReadAllText(filename);
                cfg = JsonSerializer.Deserialize<Config>(jsonString);
                cfg.ReferenceImage1 = LoadImage(1);
                cfg.ReferenceImage2 = LoadImage(2);
            }
            else
            {
                cfg = new Config();
                cfg.PositionTolerance = 3;
            }

            //
            // adjust some value
            //
            if (cfg.MoveRaRate == 0)
                cfg.MoveRaRate = 1;
            if (cfg.MoveDecRate == 0)
                cfg.MoveDecRate = 1;
            if (cfg.MoveRaTime <= 0)
                cfg.MoveRaTime = 1;
            if (cfg.MoveDecTime <= 0)
                cfg.MoveDecTime = 1;
            if (cfg.FastRateMultiplier < 1)
                cfg.FastRateMultiplier = 2;
            if (cfg.FastTimeMultiplier < 1)
                cfg.FastTimeMultiplier = 3;
            if (cfg.AutoParkAR is null)
                cfg.AutoParkAR = new AutoParkSetting();
            if (cfg.AutoParkDec is null)
                cfg.AutoParkDec = new AutoParkSetting();
            return cfg;
        }

        public Config Clone()
        {
            string jsonString = JsonSerializer.Serialize(this);
            var newcfg = JsonSerializer.Deserialize<Config>(jsonString);
            if (ReferenceImage1 != null)
                newcfg.ReferenceImage1 = new Bitmap(ReferenceImage1);
            if (ReferenceImage2 != null)
                newcfg.ReferenceImage2 = new Bitmap(ReferenceImage2);
            return newcfg;
        }
        #endregion
    }

}
