using System.Collections.Generic;
using System.Drawing;
//using Accord.Imaging.Filters;
//using Accord.Imaging;
using System.Diagnostics;
using System;
using System.Data.SqlTypes;
using Emgu.CV;
using Emgu.CV.Reg;
using System.Linq;

namespace VisualMountParking
{
	public class PatternVerifier
	{

		public Bitmap NewImage { get; set; }

		public List<ZoneMatch> ZoneMatchList = new List<ZoneMatch>();

		private ArucoDetector _ArucoDetector;
		private bool useArucoMarkers;
		private List<Zone> referenceTemplates;
		private Bitmap referenceImage;

		public IList<Zone> ReferenceTemplates => referenceTemplates;

		/// <summary>
		/// Call when same basic settin changes, like: reference image, aruco usage, zone definitions 
		/// </summary>
		public void Initialize(Config config)
		{
			useArucoMarkers = config.UseArucoMarkers;
			referenceImage = config.ReferenceImage;
			if (useArucoMarkers)
			{
				referenceTemplates = SearchWithAruco(referenceImage);
			}
			else
			{
				referenceTemplates = config.Templates;
			}
		}

		public Bitmap GetDetectionImage()
		{
			var decImage = _ArucoDetector.ShowMarkers(NewImage, true);
			return decImage;
		}

		public void SearchMatch()
		{
			List<Zone> finds;
			if (useArucoMarkers)
				finds = SearchWithAruco(NewImage);
			else
				finds = SearchMatchWithOpenCV(NewImage);

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

		private List<Zone> SearchMatchWithOpenCV(Bitmap image)
		{
			var matchFound = new List<Zone>();
			var arImage = ArucoDetector.ConvertTo24bpp(image).ToMat();
			foreach (var source in referenceTemplates)
			{
				Bitmap template = ExtractBitmap(referenceImage, source);
				var arTemplate = ArucoDetector.ConvertTo24bpp(template).ToMat();

				var method = Emgu.CV.CvEnum.TemplateMatchingType.SqdiffNormed;
				Mat result = new Mat();
				Emgu.CV.CvInvoke.MatchTemplate(arImage, arTemplate, result, method);

				double min = 0, max = 0;
				Point minLoc = Point.Empty, maxLoc = Point.Empty;
				CvInvoke.MinMaxLoc(result, ref min, ref max, ref minLoc, ref maxLoc);

				if (min < 0.005)
				{
					var target = new Zone { Id = source.Id, X = minLoc.X, Y = minLoc.Y, Width = source.Width, Height = source.Height };
					matchFound.Add(target);
				}
			}
			return matchFound;
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
				var z = new Zone { Id = marker.Id, X = (int)marker.Position.X, Y = (int)marker.Position.Y, Width = 8, Height = 8 };
				result.Add(z);
			}
			return result;
		}

		private Bitmap ExtractBitmap(Bitmap image, Zone zone)
		{
			// Clone a portion of the Bitmap object.
			Rectangle cloneRect = new Rectangle(zone.X, zone.Y, zone.Width, zone.Height);
			Bitmap cloneBitmap = image.Clone(cloneRect, image.PixelFormat);

			return cloneBitmap;
		}

	}
}
