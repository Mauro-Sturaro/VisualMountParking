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

		public void SearchMatch()
		{
			bool useAccord = false;
			List<Zone> finds;
			if (useArucoMarkers)
				finds = SearchWithAruco(NewImage);
			//else if (useAccord)
			//	finds = SearchMatchWithAccord(NewImage);
			else
				finds = SearchMatchWithOpenCV(NewImage);

			var matchList = new List<ZoneMatch>();
			foreach (var src in referenceTemplates)
			{
				var target = finds.Find((z)=>z.Id== src.Id);
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

				var bmresult = result.ToBitmap();
				bmresult.Save(@"c:\temp\result.png");

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
		private void SearchWithAruco()
		{
			if (_ArucoDetector == null)
			{
				_ArucoDetector = new ArucoDetector();
				_ArucoDetector.Initialize();
			}
			var m = _ArucoDetector.FindMarkers(NewImage);

			var newZone = new List<ZoneMatch>();
			foreach (var marker in m)
			{
				var z = new Zone { Id = marker.Id, X = (int)marker.Position.X, Y = (int)marker.Position.Y, Width = 10, Height = 10 };
				var zm = new ZoneMatch { ZoneId = z.Id, Source = z, Target = z };
				newZone.Add(zm);
			}
			ZoneMatchList = newZone;
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
				var z = new Zone { Id = marker.Id, X = (int)marker.Position.X, Y = (int)marker.Position.Y, Width = 10, Height = 10 };
				result.Add(z);
			}
			return result;
		}




		private Zone EstraiDintorni(int width, int height, Zone template)
		{
			var newWidth = Math.Min(template.Width * 3, width);
			var newHeight = Math.Min(template.Height * 3, height);
			var cX = template.X + template.Width / 2;
			var cY = template.Y + template.Height / 2;
			var newX = cX - newWidth / 2;
			var newY = cY - newHeight / 2;
			if (newX < 0) newX = 0;
			if (newX + newWidth > width) newX = width - newWidth;
			if (newY < 0) newY = 0;
			if (newY + newHeight > height) newY = height - newHeight;

			return new Zone { X = newX, Y = newY, Width = newWidth, Height = newHeight };
		}

		private Bitmap ExtractBitmap(Bitmap image, Zone zone)
		{
			// Clone a portion of the Bitmap object.
			Rectangle cloneRect = new Rectangle(zone.X, zone.Y, zone.Width, zone.Height);
			Bitmap cloneBitmap = image.Clone(cloneRect, image.PixelFormat);

			return cloneBitmap;
		}

		/*-----------------------------------------------------------------------
			Questo richiede:
			- Accord.Video.DirectShow v3.8.0
			- Accord.Extensions.Vision v3.0.1
			- Accord.Controls.Vision v3.8.0
		//---------------------------------------------------------------------- * /
		public List<Zone> SearchMatchWithAccord(Bitmap image)
		{
			var matchFound = new List<Zone>();
			foreach (var zone in referenceTemplates)
			{
				var reducedZone = EstraiDintorni(referenceImage.Width, referenceImage.Height, zone);
				Bitmap template = ExtractBitmap(referenceImage, zone);
				Bitmap reducedImage = ExtractBitmap(image, reducedZone);
				var target = FindTemplate(reducedImage, template);
				if (!target.IsEmpty())
				{
					target.X += reducedZone.X;
					target.Y += reducedZone.Y;
					matchFound.Add(target);
				}
			}
			return matchFound;
		}

		private Bitmap TransformImage(System.Drawing.Image image, double scale)
		{
			Bitmap bimg;
			if (image is Bitmap)
				bimg = (Bitmap)image;
			else
				bimg = new Bitmap(image);

			var gg = Grayscale.CommonAlgorithms.RMY;
			Bitmap gray = gg.Apply(bimg);

			// rescale image
			var filter = new ResizeBilinear((int)(gray.Width * scale), (int)(gray.Height * scale));

			Bitmap newImage = filter.Apply(gray);
			return newImage;
		}

		private Zone FindTemplate(Bitmap fullimage, Bitmap template)
		{
			var scale = 1;

			Bitmap grayTemplate = TransformImage(template, scale);
			Bitmap graySource = TransformImage(fullimage, scale);

			Debug.WriteLine($"Searching {grayTemplate.Width}x{grayTemplate.Height} template in {graySource.Width}x{graySource.Height} image.");

			// create template matching algorithm's instance
			ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0);
			// find all matchings with specified above similarity

			TemplateMatch[] matchings = tm.ProcessImage(graySource, grayTemplate);

			if (matchings.Length == 0 || matchings[0].Similarity <= 0.8f)
				return new Zone();
			var r = matchings[0].Rectangle;

			var z = new Zone { X = (int)(r.X / scale), Y = (int)(r.Y / scale), Width = (int)(r.Width / scale), Height = (int)(r.Height / scale) };
			return z;

		}
		/*-------------------*/

	}
}
