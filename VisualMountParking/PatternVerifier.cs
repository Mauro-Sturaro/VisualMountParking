using System.Collections.Generic;
using System.Drawing;
using VisualMountParking.Markers;


namespace VisualMountParking
{
    public class PatternVerifier
	{

		public Bitmap NewImage { get; set; }

		public List<ZoneMatch> ZoneMatchList = new List<ZoneMatch>();

		private ArucoDetector _ArucoDetector;
		private List<Zone> referenceTemplates;
	 

		public IList<Zone> ReferenceTemplates => referenceTemplates;

		/// <summary>
		/// Call when same basic settin changes, like: reference image, aruco usage, zone definitions 
		/// </summary>
		public void Initialize(Config config)
		{

			referenceTemplates = SearchWithAruco(config.ReferenceImage);
		}

		public void SearchMatch()
		{
			List<Zone> finds = SearchWithAruco(NewImage);

			var matchList = new List<ZoneMatch>();
			foreach (var src in referenceTemplates)
			{
				var target = finds.Find((z) => z.Id == src.Id);
				if (target != null)
				{
					var zm = new ZoneMatch { ZoneId = src.Id, Source = src, Target = target };
					matchList.Add(zm);
				}
			}
			ZoneMatchList = matchList;
		}

		private List<Zone> SearchWithAruco(Bitmap image)
		{

			if (_ArucoDetector == null)
			{
				_ArucoDetector = new ArucoDetector();
				_ArucoDetector.Initialize();
			}
			var m = _ArucoDetector.FindMarkers(image);

			var result = new List<Zone>();
			foreach (var marker in m)
			{
				var z = new Zone { Id = marker.Id, X = (int)marker.Position.X, Y = (int)marker.Position.Y };
				result.Add(z);
			}
			return result;
		}

	}
}
