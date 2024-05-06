using System;
using System.Drawing;

namespace VisualMountParking
{
    public class ImageChangedEventArgs : EventArgs
    {      
        public Image NewImage { get; set; }
    }
}
