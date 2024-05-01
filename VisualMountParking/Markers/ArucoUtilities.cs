using Emgu.CV.Aruco;
using Emgu.CV;
using System.Drawing;

namespace VisualMountParking.Markers
{
    internal class ArucoUtilities
    {

        internal static readonly Dictionary ArucoDict = new Dictionary(Dictionary.PredefinedDictionaryName.Dict4X4_50);
        // bits x bits (per marker) _ <number of markers in dictionary>

        public static void PrintCharucoBoard(string filename)
        {
            // ChArUco_Board

            const int SquaresX = 8;
            const int SquaresY = 6;
            const int SquareLength = 20;
            const int MarkerLength = 15;
            var charucoBoard = new CharucoBoard(SquaresX, SquaresY, SquareLength, MarkerLength, ArucoDict);

            const int Width = 1000;
            const int Height = Width / SquaresX * SquaresY;

            Size imageSize = new Size(Width, Height);
            Mat img = new Mat();
            charucoBoard.GenerateImage(imageSize, img, 40, 1);
            img.Save(filename);


        }

        public static void PrintArucoBoard(string filename)
        {
            int markersX = 7;
            int markersY = 5;
            int markersLength = 80;
            int markersSeparation = 30;

            GridBoard ArucoBoard = new GridBoard(markersX, markersY, markersLength, markersSeparation, ArucoDict);

            // Draw the board on a cv::Mat
            Size imageSize = new Size();
            Mat boardImage = new Mat();
            imageSize.Width = markersX * (markersLength + markersSeparation) - markersSeparation + 2 * markersSeparation;
            imageSize.Height = markersY * (markersLength + markersSeparation) - markersSeparation + 2 * markersSeparation;
            ArucoInvoke.DrawPlanarBoard(ArucoBoard, imageSize, boardImage, 30);

            // Save the image
            boardImage.Save(filename);
        }
    }
}
