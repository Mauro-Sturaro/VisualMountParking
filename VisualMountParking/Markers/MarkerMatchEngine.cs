using System.Collections.Generic;
using System.Drawing;


namespace VisualMountParking.Markers
{
    public class MarkerMatchEngine
    {

        public List<ZoneMatch> MatchList = new List<ZoneMatch>();

        private ArucoDetector _ArucoDetector;

        public IList<MarkerPoint> ReferenceMarkers { get; private set; }

        public MarkerMatchEngine(Bitmap refImage)
        {
            Initialize(refImage);
        }

        /// <summary>
        /// Call when same basic settin changes, like: reference image, aruco usage, zone definitions 
        /// </summary>
        public void Initialize(Bitmap refImage)
        {
            if (refImage != null)
                ReferenceMarkers = SearchWithAruco(refImage);
            else
                ReferenceMarkers = new List<MarkerPoint>();

        }

        public void SearchMatch(Bitmap image)
        {
            List<MarkerPoint> finds = SearchWithAruco(image);

            var matchList = new List<ZoneMatch>();
            foreach (var src in ReferenceMarkers)
            {
                var target = finds.Find((z) => z.Id == src.Id);
                if (target != null)
                {
                    var zm = new ZoneMatch { ZoneId = src.Id, Source = src, Target = target };
                    matchList.Add(zm);
                }
            }
            MatchList = matchList;
        }

        private List<MarkerPoint> SearchWithAruco(Bitmap image)
        {

            if (_ArucoDetector == null)
            {
                _ArucoDetector = new ArucoDetector();
                _ArucoDetector.Initialize();
            }
            var m = _ArucoDetector.FindMarkers(image);

            var result = new List<MarkerPoint>();
            foreach (var marker in m)
            {
                var z = new MarkerPoint { Id = marker.Id, X = (int)marker.Position.X, Y = (int)marker.Position.Y };
                result.Add(z);
            }
            return result;
        }

        public Image ShowAllMarkers(Bitmap image)
        {
            if (image == null)
                return null;
            var dimg = _ArucoDetector.DrawMarkers(image, true);
            return dimg;
        }
    }
}
