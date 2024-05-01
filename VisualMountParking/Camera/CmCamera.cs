using System.Drawing;
using System.Threading.Tasks;

namespace VisualMountParking.Camera
{
    public class CmCamera : ICamera
    {
        public void Initialize(string settings)
        {
            throw new System.NotImplementedException();
        }

        public Task<Bitmap> LoadImageAsync()
        {
            throw new System.NotImplementedException();
        }
        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }

}
