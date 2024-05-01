using System.Drawing;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace VisualMountParking.Camera
{
    internal class DummyCamera : ICamera
    {
        public void Initialize(string jsonSettings)
        {

        }

        public Task<Bitmap> LoadImageAsync()
        {
            var b = new Bitmap(300, 300);
            using (var g = Graphics.FromImage(b))
            {
                g.FillRectangle(Brushes.Black, new Rectangle(0, 0, 299, 299));
                using (var pen = new Pen(Brushes.White))
                {
                    g.DrawRectangle(pen, new Rectangle(100, 100, 100, 100));
                }
            }
            return Task.FromResult(b);
        }
    }
}