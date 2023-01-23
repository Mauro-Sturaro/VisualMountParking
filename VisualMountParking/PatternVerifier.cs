using System.Collections.Generic;
using System.Drawing;
using Accord.Imaging.Filters;
using Accord.Imaging;
using System.Diagnostics;
using System;

namespace VisualMountParking
{
	public class PatternVerifier
	{
		public Config Config { get; set; }
		public Bitmap NewImage { get; set; }

		public List<ZoneMatch> ZoneMatchList = new List<ZoneMatch>();

		internal void SearchMatch()
		{
			ZoneMatchList.Clear();
			foreach (var zone in Config.Templates)
			{
				var zm = new ZoneMatch { Source = zone };
				var reducedZone = EstraiDintorni(Config.ReferenceImage.Width, Config.ReferenceImage.Height, zone);
				Bitmap template = ExtractBitmap(Config.ReferenceImage, zone);
				Bitmap reducedImage = ExtractBitmap(NewImage, reducedZone);
				var target = FindTemplate(reducedImage, template);
				if (!target.IsEmpty())
				{
					target.X += reducedZone.X;
					target.Y += reducedZone.Y;
					zm.Target = target;
					ZoneMatchList.Add(zm);
				}
			}
		}

		private Zone EstraiDintorni(int width, int height, Zone template)
		{
			var newWidth = Math.Min( template.Width*3, width );
			var newHeight = Math.Min(template.Height*3, height );
			var cX = template.X + template.Width / 2;
			var cY = template.Y + template.Height / 2;
			var newX = cX-newWidth/2;
			var newY = cY-newHeight/2;
			if(newX<0) newX=0;
			if(newX+newWidth > width) newX=width-newWidth;
			if(newY<0) newY=0;
			if(newY+newHeight> height) newY=height-newHeight;

			return new Zone {X= newX, Y = newY,Width=newWidth,Height=newHeight};
		}

		private Bitmap ExtractBitmap(Bitmap image, Zone zone)
		{
			// Clone a portion of the Bitmap object.
			Rectangle cloneRect = new Rectangle(zone.X, zone.Y, zone.Width, zone.Height);
			Bitmap cloneBitmap = image.Clone(cloneRect, image.PixelFormat);

			return cloneBitmap;
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

	}
}
