﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace VisualMountParking.Camera
{
    internal interface ICamera : IDisposable
    {
        void Initialize(string settings);
        Task<Bitmap> LoadImageAsync();
    }

}
