using Accord.Video;
using Accord.Video.DirectShow;
	

namespace ImageShiftTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			pictureBox1.Load(@"c:\temp\pic1.jpg");
			pictureBox2.Load(@"c:\temp\pic2.jpg");
		}

		private void comboBox1_DropDown(object sender, EventArgs e)
		{
			comboBox1.Items.Clear();
			var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
			foreach (var device in videoDevices)
			{
				comboBox1.Items.Add(device.MonikerString);
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void btGetImage1_Click(object sender, EventArgs e)
		{
 
			var videoSource = new VideoCaptureDevice(comboBox1.Text);

			// Then, we just have to define what we would like to do once the device send 
			// us a new frame. This can be done using standard .NET events (the actual 
			// contents of the video_NewFrame method is shown at the bottom of this page)
			videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);

			// Start the video source. This is not a blocking operation, meaning that 
			// the frame capturing routine will actually be running in a different thread 
			// and execution will be returned to the caller while the capture happens in 
			// the background:
			videoSource.Start();

			// ...

			// Let's say our application continues running, and after a while we decide
			// to stop capturing frames from the device. To stop the device, we can use

			//videoSource.SignalToStop();
		}

		private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			//var bitmap = eventArgs.Frame;
			//System.Drawing.Image img = bitmap;
			//pictureBox1.Image = img;
		}

		private void bt_ChooseDevice_Click(object sender, EventArgs e)
		{

		}
	}
}