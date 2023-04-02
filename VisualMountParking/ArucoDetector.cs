using Emgu.CV.Aruco;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System;
using System.Drawing;
using System.Collections.Generic;

namespace VisualMountParking
{
	public class ArucoDetector
	{
		DetectorParameters ArucoParameters;

		private static Dictionary ArucoDict = new Dictionary(Dictionary.PredefinedDictionaryName.Dict4X4_50);
		// bits x bits (per marker) _ <number of markers in dictionary>

		//Mat cameraMatrix;
		//Mat distortionMatrix;

		public void Initialize()
		{
			#region Initialize Aruco parameters for markers detection
			//ArucoParameters = new DetectorParameters();
			ArucoParameters = DetectorParameters.GetDefault();

			// Regoliamo quali rettangoli vede
			ArucoParameters.MinMarkerPerimeterRate = 0.06;
			ArucoParameters.MaxMarkerPerimeterRate = 0.1;
			ArucoParameters.MinCornerDistanceRate = 0.15;

			// ora la quantizzazione
			ArucoParameters.PerspectiveRemovePixelPerCell = 4;
			ArucoParameters.PerspectiveRemoveIgnoredMarginPerCell = 0.4;

			// ed infine la robustezza agli errori
			ArucoParameters.MaxErroneousBitsInBorderRate = 0.8;
			ArucoParameters.ErrorCorrectionRate = 1;


			#endregion

			//#region Initialize Camera calibration matrix with distortion coefficients 
			//// Calibration done with https://docs.opencv.org/3.4.3/d7/d21/tutorial_interactive_calibration.html
			//string cameraConfigurationFile = "c:\\temp\\cameraParameters.xml";
			//FileStorage fs = new FileStorage(cameraConfigurationFile, FileStorage.Mode.Read);
			//if (!fs.IsOpened)
			//{
			//	Console.WriteLine("Could not open configuration file " + cameraConfigurationFile);
			//	return;
			//}
			//cameraMatrix = new Mat(new Size(3, 3), DepthType.Cv32F, 1);
			//distortionMatrix = new Mat(1, 8, DepthType.Cv32F, 1);
			//fs["cameraMatrix"].ReadMat(cameraMatrix);
			//fs["dist_coeffs"].ReadMat(distortionMatrix);
			//#endregion

		}


		public Bitmap ShowMarkers(Bitmap image, bool showDetected = false)
		{
			image = ConvertTo24bpp(image);
			var frame = image.ToMat();
			AnalyzeFrame(frame, showDetected);
			var res = frame.ToBitmap();
			return res;
		}
		private void AnalyzeFrame(Mat frame, bool showDetected = false)
		{
			if (!frame.IsEmpty)
			{
				#region Detect markers on last retrieved frame
				VectorOfInt ids = new VectorOfInt(); // name/id of the detected markers
				using (VectorOfVectorOfPointF corners = new VectorOfVectorOfPointF()) // corners of the detected marker)
				using (VectorOfVectorOfPointF rejected = new VectorOfVectorOfPointF()) // rejected contours
				{

					ArucoInvoke.DetectMarkers(frame, ArucoDict, corners, ids, ArucoParameters, rejected);
					#endregion					

					if (showDetected)
					{
						VectorOfInt rejectedId = new VectorOfInt(0);
						ArucoInvoke.DrawDetectedMarkers(frame, rejected, rejectedId, new MCvScalar(0, 0, 255));
					}

					// If we detected at least one marker
					if (ids.Size > 0)
					{
						ArucoInvoke.DrawDetectedMarkers(frame, corners, ids, new MCvScalar(255, 0, 255));
					}
				}
			}
		}

		public static Bitmap ConvertTo24bpp(Image img)
		{
			var bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			using (var gr = Graphics.FromImage(bmp))
				gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
			return bmp;
		}


		public IList<ArucoFind> FindMarkers(Bitmap image)
		{
			var result = new List<ArucoFind>();
			image = ConvertTo24bpp(image);
			var frame = image.ToMat();

			// Detect markers  
			VectorOfInt ids = new VectorOfInt(); // name/id of the detected markers
			using (VectorOfVectorOfPointF corners = new VectorOfVectorOfPointF()) // corners of the detected marker
			using (VectorOfVectorOfPointF rejected = new VectorOfVectorOfPointF()) // rejected contours
			{
				ArucoInvoke.DetectMarkers(frame, ArucoDict, corners, ids, ArucoParameters, rejected);

				for (int i = 0; i < ids.Size; i++)
				{
					result.Add(new ArucoFind { Id = ids[i], Position = corners[i][0] });
				}
			}

			return result;
		}
	}

	public class ArucoFind
	{
		public int Id { get; set; }
		public PointF Position { get; set; }
	}


}
