using Emgu.CV.Aruco;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System;
using System.Drawing;
using System.Collections.Generic;
using Emgu.CV.CvEnum;
using System.Diagnostics;

namespace VisualMountParking.Markers
{
    public class ArucoDetector
    {

        DetectorParameters ArucoParameters;

        private static readonly Dictionary ArucoDict = ArucoUtilities.ArucoDict; 

        //Mat cameraMatrix;
        //Mat distortionMatrix;

        public void Initialize()
        {
            #region Initialize Aruco parameters for markers detection
            //ArucoParameters = new DetectorParameters();
            ArucoParameters = DetectorParameters.GetDefault();

            if (ArucoParameters.MarkerBorderBits != 1)
                throw new Exception("Check EmguCV version, 4.9.1 seems buggy");

            //// Regoliamo quali rettangoli vede
            //ArucoParameters.MinMarkerPerimeterRate = 0.06;
            //ArucoParameters.MaxMarkerPerimeterRate = 0.1;
            //ArucoParameters.MinCornerDistanceRate = 0.15;

            //// ora la quantizzazione
            //ArucoParameters.PerspectiveRemovePixelPerCell = 4;
            //ArucoParameters.PerspectiveRemoveIgnoredMarginPerCell = 0.4;

            //// ed infine la robustezza agli errori
            //ArucoParameters.MaxErroneousBitsInBorderRate = 0.8;
            //ArucoParameters.ErrorCorrectionRate = 1;


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

        public Bitmap ShowMarkers(Bitmap image, bool showRejected = false)
        {
            var image24 = ConvertTo24bpp(image);
            image.Dispose();
            var frame = image24.ToMat();
            AnalyzeFrame(frame, showRejected);
            var res = frame.ToBitmap();
            return res;
        }
        private void AnalyzeFrame(Mat frame, bool showRejected = false)
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

                    if (showRejected)
                    {
                        VectorOfInt rejectedId = new VectorOfInt(0);
                        ArucoInvoke.DrawDetectedMarkers(frame, rejected, rejectedId, new MCvScalar(0, 0, 255));
                    }

                    // If we detected at least one marker
                    if (ids.Size > 0)
                    {
                        //ArucoInvoke.DrawDetectedMarkers(frame, corners, ids, new MCvScalar(255, 0, 255));

                        #region Initialize Camera calibration matrix with distortion coefficients 
                        // Calibration done with https://docs.opencv.org/3.4.3/d7/d21/tutorial_interactive_calibration.html
                        string cameraConfigurationFile = @"c:\temp\cameraParameters.xml";
                        FileStorage fs = new FileStorage(cameraConfigurationFile, FileStorage.Mode.Read);
                        if (!fs.IsOpened)
                        {
                            Console.WriteLine("Could not open configuration file " + cameraConfigurationFile);
                            return;
                        }
                        Mat cameraMatrix = new Mat(new Size(3, 3), DepthType.Cv32F, 1);
                        Mat distortionMatrix = new Mat(1, 8, DepthType.Cv32F, 1);
                        fs["cameraMatrix"].ReadMat(cameraMatrix);
                        fs["dist_coeffs"].ReadMat(distortionMatrix);
                        #endregion

                        #region Estimate pose for each marker using camera calibration matrix and distortion coefficents
                        int markersLength = 80;

                        Mat rvecs = new Mat(); // rotation vector
                        Mat tvecs = new Mat(); // translation vector
                        ArucoInvoke.EstimatePoseSingleMarkers(corners, markersLength, cameraMatrix, distortionMatrix, rvecs, tvecs);

                        #endregion

                        //#region test draw


                        //var criteria = new MCvTermCriteria(30, 0.001);
                        //var corners2 = corners[0];

                        //var objp = CV np.zeros((6 * 7, 3), np.float32)

                        //CvInvoke.CornerSubPix(frame, corners2, new Size(11, 11), new Size(-1, -1), criteria);
                        //CvInvoke.SolvePnP()

                        //#endregion

                        //return;

                        #region Draw 3D orthogonal axis on markers using estimated pose
                        for (int i = 0; i < ids.Size; i++)
                        {
                            var c1 = corners[i];
                            var c1p1 = Point.Round(c1[0]);
                            var c1p2 = Point.Round(c1[1]);

                            CvInvoke.Line(frame, c1p1, c1p2, new MCvScalar(0, 255, 0));

                            using (Mat rvecMat = rvecs.Row(i))
                            using (Mat tvecMat = tvecs.Row(i))
                            using (VectorOfDouble rvec = new VectorOfDouble())
                            using (VectorOfDouble tvec = new VectorOfDouble())
                            {
                                var id = ids[i];
                                double[] values = new double[3];
                                rvecMat.CopyTo(values);
                                rvec.Push(values);
                                tvecMat.CopyTo(values);
                                tvec.Push(values);

                                // ArucoInvoke.DrawAxis(frame, cameraMatrix, distortionMatrix, rvec, tvec, markersLength * 0.5f);
                                Debug.WriteLine($"{i}) id={id} ({rvec[0]},{rvec[1]},{rvec[2]}) ({tvec[0]},{tvec[1]},{tvec[2]})");
                            }
                        }
                        #endregion


                    }
                }
            }
        }

        private static Bitmap ConvertTo24bpp(Image img)
        {
            var bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (var gr = Graphics.FromImage(bmp))
                gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            return bmp;
        }

        public IList<ArucoFind> FindMarkers(Bitmap image)
        {
            var result = new List<ArucoFind>();
            var image24 = ConvertTo24bpp(image);
            var frame = image24.ToMat();
            image24.Dispose();

            // Detect markers  
            VectorOfInt ids = new VectorOfInt(); // name/id of the detected markers
            using (VectorOfVectorOfPointF corners = new VectorOfVectorOfPointF()) // corners of the detected marker
            {
                ArucoInvoke.DetectMarkers(frame, ArucoDict, corners, ids, ArucoParameters);
                for (int i = 0; i < ids.Size; i++)
                {
                    result.Add(new ArucoFind { Id = ids[i], Position = corners[i][0] });
                }
            }
            return result;
        }


    }
}
