using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VisualMountParking.Camera
{
    internal class CameraFactory
    {
        public static CameraFactory Instance { get; } = new CameraFactory();
        public ReadOnlyCollection<string> Names { get; }
        private CameraFactory()
        {
            var names = new List<string>() { "None", "URL", "File","Webcam", "FlashCap" };
            Names = names.AsReadOnly();

        }

        public ICamera GetCamera(string name)
        {
            switch(name)
            {
                case "None":
                    return new DummyCamera();
                case "URL":
                    return new UrlCamera();
                case "File":
                    return new FileCamera();
                case "Webcam":
                    return new Webcam();
                case "FlashCap":
                    return new FlashCapCamera();
                default:
                    throw new ArgumentOutOfRangeException(nameof(name));
            }
        }
    }

}
