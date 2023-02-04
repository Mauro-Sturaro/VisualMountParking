using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

using VisualMountParking.Properties;
using System.Runtime.Versioning;
using ASCOM.DeviceInterface;
using ASCOM.DriverAccess;
using System.Threading.Tasks;

namespace VisualMountParking
{

	// per le WebAPI vedi https://drive.google.com/file/d/15AFMQSMlMdpjL2USPsvYd-J9xWecrEf9/view
	public partial class MainForm : Form
	{
		bool _MouseDragging = false;
		Point _SelectionFirstPoint;
		Point _SelectionLastPoint;
		Telescope _Telescope;
		WebUtils _WebUtils = new WebUtils();	

		public MainForm()
		{
			InitializeComponent();
			this.Icon = Resources._2bs_logo;
			this.Width = pictureBox1.Width + 2 * pictureBox1.Left + (this.Width - ClientSize.Width);
		}

		PatternVerifier patternVerifier = new PatternVerifier();
		private Config config { get { return patternVerifier.Config; } set { patternVerifier.Config = value; } }

		public bool ShowRefImage
		{
			get => chkShowRef.Checked;
			set
			{
				chkShowRef.Checked = value;
				MainForm_Resize(this, EventArgs.Empty);
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			ShowRefImage = false;
			//MainForm_Resize(sender, e);
			config = Config.Load();

			UpdateMovementButtons();
			btCancel.BringToFront();

			pictureBox1.Image = config.ReferenceImage;
			if (!string.IsNullOrWhiteSpace(config.Source))
			{
				buttonLoadImage_Click(null, null);
			}
		}

		private void ConnectTelescope()
		{
			DisconnectTelescope();
			if (!string.IsNullOrWhiteSpace(config.TelescopeDriver))
			{
				_Telescope = new Telescope(config.TelescopeDriver);
				_Telescope.Connected = true;
			}
		}

		private void DisconnectTelescope()
		{
			if (_Telescope != null)
			{
				_Telescope.Connected = false;
				_Telescope.Dispose();
				_Telescope = null;
			}
		}

		private async void buttonLoadImage_Click(object sender, EventArgs e)
		{
			patternVerifier.ZoneMatchList.Clear();
			pictureBox2.Image = null;

			var image = await _WebUtils.LoadImageAsync(config.SourceType, config.Source);
			patternVerifier.NewImage = new Bitmap(image);
			pictureBox2.Image = patternVerifier.NewImage;
			Application.DoEvents();
			patternVerifier.SearchMatch();
			pictureBox2.Invalidate();
		}

		private void btSetRefImage_Click(object sender, EventArgs e)
		{
			pictureBox1.Image = patternVerifier.NewImage;
			config.ReferenceImage = patternVerifier.NewImage;
		}
		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (_MouseDragging == false)
			{
				_SelectionFirstPoint = e.Location;
				_MouseDragging = true;
				pictureBox1.Cursor = Cursors.Cross;
			}
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			_SelectionLastPoint = e.Location;
			pictureBox1.Invalidate();
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			if (_MouseDragging)
			{

				//
				GetStretch(pictureBox1, out var stretchX, out var stretchY, out var shiftX, out var shiftY);

				// Raddrizza le coordinate se necessario
				SortPoint(_SelectionFirstPoint, e.Location, out var startPoint, out var endPoint);


				// Calcola il rettangolo rispetto all'immagine reale
				Zone item = new Zone
				{
					X = (int)((startPoint.X - shiftX) / stretchX),
					Y = (int)((startPoint.Y - shiftY) / stretchY),
					Width = (int)((endPoint.X - startPoint.X) / stretchX),
					Height = (int)((endPoint.Y - startPoint.Y) / stretchY)
				};

				// Se è troppo piccolo lo scarta, altrimenti lo aggiunge ai template
				if (item.Width >= 10 && item.Height >= 10)
					config.Templates.Add(item);

				//				
				Cursor.Current = Cursors.Default;
				_MouseDragging = false;
			}
		}

		private static void SortPoint(Point point1, Point point2, out Point topLeft, out Point bottomRight)
		{
			topLeft = new Point(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
			bottomRight = new Point(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			GetStretch((PictureBox)sender, out var stretchX, out var stretchY, out var shiftX, out var shiftY);
			var g = e.Graphics;
			foreach (var tp in config.Templates)
			{
				g.DrawRectangle(new Pen(Color.Blue, 1), (int)(tp.X * stretchX) + shiftX, (int)(tp.Y * stretchY) + shiftY, (int)(tp.Width * stretchX), (int)(tp.Height * stretchY));

			}
			if (_MouseDragging)
			{
				SortPoint(_SelectionFirstPoint, _SelectionLastPoint, out var startPoint, out var endPoint);
				g.DrawRectangle(new Pen(Color.Coral, 1), startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
			}
		}

		private void GetStretch(PictureBox pb, out double stretchX, out double stretchY, out int shiftX, out int shiftY)
		{

			if (pb.Image == null || pb.SizeMode == PictureBoxSizeMode.Normal)
			{
				stretchX = 1;
				stretchY = 1;
				shiftX = 0;
				shiftY = 0;
			}
			else
			{
				PropertyInfo irProperty = typeof(PictureBox).GetProperty("ImageRectangle", BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Instance);
				Rectangle rr = (Rectangle)irProperty.GetValue(pb, null);

				stretchX = (double)rr.Width / pb.Image.Width;
				stretchY = (double)rr.Height / pb.Image.Height;
				shiftX = rr.X;
				shiftY = rr.Y;
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			GetStretch(pictureBox1, out var stretchX, out var stretchY, out var shiftX, out var shiftY);
			var X = (me.X - shiftX) / stretchX;
			var Y = (me.Y - shiftY) / stretchY;
			for (int i = config.Templates.Count - 1; i >= 0; i--)
			{
				Zone tp = config.Templates[i];
				if (tp.X <= X && X <= tp.X + tp.Width && tp.Y <= Y && Y <= tp.Y + tp.Height)
				{
					config.Templates.RemoveAt(i);
				}
			}

		}

		static Pen greenPen = new Pen(Color.Green, 1);
		static Pen bluePen = new Pen(Color.Blue, 1);
		static Pen redPen = new Pen(Color.DarkRed, 1);
		static Font drawFont = new Font("Arial", 10);
		static SolidBrush drawBrush = new SolidBrush(Color.DarkRed);

		private void pictureBox2_Paint(object sender, PaintEventArgs e)
		{
			GetStretch((PictureBox)sender, out var stretchX, out var stretchY, out var shiftX, out var shiftY);
			var g = e.Graphics;
			foreach (var zoneMatch in patternVerifier.ZoneMatchList)
			{
				var sp = zoneMatch.Source;
				var tp = zoneMatch.Target;

				var x = (int)(sp.X * stretchX) + shiftX;
				var y = (int)(sp.Y * stretchY) + shiftY;

				if (sp.X == tp.X && sp.Y == tp.Y && sp.Width == tp.Width && sp.Height == tp.Height)
				{
					g.DrawRectangle(greenPen, x, y, (int)(tp.Width * stretchX), (int)(tp.Height * stretchY));
				}
				else
				{

					g.DrawRectangle(bluePen, x, y, (int)(sp.Width * stretchX), (int)(sp.Height * stretchY));
					var x1 = (int)(tp.X * stretchX) + shiftX;
					var y1 = (int)(tp.Y * stretchY) + shiftY;
					g.DrawRectangle(redPen, x1, y1, (int)(tp.Width * stretchX), (int)(tp.Height * stretchY));
					//---
					var msg = $"{tp.X - sp.X},{tp.Y - sp.Y}";

					g.DrawString(msg, drawFont, drawBrush, x1 + 2, y1 + 2);
				}
			}
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			var dX = pictureBox1.Left;
			var top = pictureBox1.Top;
			var height = ClientSize.Height - top - dX;

			int width;
			if (ShowRefImage)
				width = (ClientSize.Width - dX * 3) / 2;
			else
				width = ClientSize.Width - dX * 2;

			pictureBox1.Top = pictureBox2.Top = top;
			pictureBox1.Width = pictureBox2.Width = width;
			pictureBox1.Height = pictureBox2.Height = height;
			if (ShowRefImage)
			{
				pictureBox1.Visible = true;
				pictureBox2.Left = width + dX * 2;
			}
			else
			{
				pictureBox1.Visible = false;
				pictureBox2.Left = dX;
			}
		}

		private void chkImageSize_CheckedChanged(object sender, EventArgs e)
		{
			if (chkImageSize.Checked)
			{
				pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
				pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
			}
			else
			{
				pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
				pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
			}
			pictureBox1.Invalidate();
			pictureBox2.Invalidate();

		}

		private void btSettings_Click(object sender, EventArgs e)
		{
			using (var f = new SettingsForm())
			{

				f.Config = config.Clone();
				if (f.ShowDialog(this) == DialogResult.OK)
				{
					config = f.Config;
				}
			}
		}

		bool ShowingOriginal = false;
		private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
		{
			ShowingOriginal = true;
			pictureBox2.Image = patternVerifier.Config.ReferenceImage;
		}

		private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
		{
			pictureBox2.Image = patternVerifier.NewImage;
			ShowingOriginal = false;
		}

		private async void btLightON_ClickAsync(object sender, EventArgs e)
		{
			if (config.LightOnCommand == null || string.IsNullOrWhiteSpace(config.LightOnCommand.Uri))
				return;
			btLightON.Enabled = false;
			try
			{

				var result = await _WebUtils.RunCommandURIAsync(config.LightOnCommand);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			btLightON.Enabled = true;
		}

		private async void btLightOFF_Click(object sender, EventArgs e)
		{
			if (config.LightOffCommand == null || string.IsNullOrWhiteSpace(config.LightOffCommand.Uri))
				return;
			btLightON.Enabled = false;
			try
			{

				var result = await _WebUtils.RunCommandURIAsync(config.LightOffCommand);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			btLightON.Enabled = true;
		}

		private void chkShowRef_CheckedChanged(object sender, EventArgs e)
		{
			var deltaSize = pictureBox1.Width + pictureBox1.Left;
			if (chkShowRef.Checked)
			{
				this.Width += deltaSize;
			}
			else
			{
				this.Width -= deltaSize;
			}

		}



		private void btRaLow2_Click(object sender, EventArgs e)
		{
			RotateAxis(TelescopeAxes.axisPrimary, -config.MoveRaRate * config.FastRateMultiplier, config.MoveRaTime * config.FastTimeMultiplier);
		}

		private void btRaLow_Click(object sender, EventArgs e)
		{
			RotateAxis(TelescopeAxes.axisPrimary, -config.MoveRaRate, config.MoveRaTime);
		}

		private void btRaHigh_Click(object sender, EventArgs e)
		{
			RotateAxis(TelescopeAxes.axisPrimary, config.MoveRaRate, config.MoveRaTime);
		}

		private void btRaHigh2_Click(object sender, EventArgs e)
		{
			RotateAxis(TelescopeAxes.axisPrimary, config.MoveRaRate * config.FastRateMultiplier, config.MoveRaTime * config.FastTimeMultiplier);
		}

		private void btDecLow2_Click(object sender, EventArgs e)
		{
			RotateAxis(TelescopeAxes.axisSecondary, -config.MoveDecRate * config.FastRateMultiplier, config.MoveDecTime * config.FastTimeMultiplier);
		}

		private void btDecLow_Click(object sender, EventArgs e)
		{
			RotateAxis(TelescopeAxes.axisSecondary, -config.MoveDecRate, config.MoveRaTime);
		}

		private void btDecHigh_Click(object sender, EventArgs e)
		{
			RotateAxis(TelescopeAxes.axisSecondary, config.MoveDecRate, config.MoveRaTime);
		}

		private void btDecHigh2_Click(object sender, EventArgs e)
		{
			RotateAxis(TelescopeAxes.axisSecondary, config.MoveDecRate * config.FastRateMultiplier, config.MoveDecTime * config.FastTimeMultiplier);
		}

		private async void RotateAxis(TelescopeAxes axis, decimal rate, decimal time)
		{


			if (_Telescope is null || _Telescope.Connected == false)
				return;

			if (_Telescope.AtPark)
			{
				MessageBox.Show("Mount is At Park", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			_Telescope.MoveAxis(axis, (double)rate);

			var delay = (int)(time * 100);

			await Task.Delay(delay);
			_Telescope.AbortSlew();
			buttonLoadImage_Click(null, null);

		}

		private void btConnect_Click(object sender, EventArgs e)
		{
			if (_Telescope != null && _Telescope.Connected)
				DisconnectTelescope();
			else
				ConnectTelescope();
			UpdateMovementButtons();
		}

		private void UpdateMovementButtons()
		{
			bool canMove = false;

			if (_Telescope != null && _Telescope.Connected)
			{
				btConnect.Text = "Disconnect";
				btPark.Enabled = true;
				if (_Telescope.AtPark)
				{
					btPark.Text = "Unpark";
					canMove = false;
				}
				else
				{
					btPark.Text = "Park";
					canMove = true;
				}
				if (_Telescope.Slewing)
				{
					btCancel.Visible = true;
				}
				else
				{
					btCancel.Visible = false;				
				}
			}
			else
			{
				btConnect.Text = "Connect";
				btCancel.Visible = false;
				btPark.Enabled = false;
				canMove = false;
			}

			btRaHigh2.Enabled = btRaHigh.Enabled = btRaLow.Enabled = btRaLow2.Enabled = canMove;
			btDecHigh2.Enabled = btDecHigh.Enabled = btDecLow.Enabled = btDecLow2.Enabled = canMove;
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			_Telescope.AbortSlew();
		}

		bool loading = false;
		private async void timerImage_Tick(object sender, EventArgs e)
		{
			if (loading || ShowingOriginal)
				return;
			loading = true;
			var image = await _WebUtils.LoadImageAsync(config.SourceType, config.Source);
			if (!ShowingOriginal)
				pictureBox2.Image = image;
			loading = false;
		}

		private void chkUpdateImage_CheckedChanged(object sender, EventArgs e)
		{
			timerImage.Enabled = chkUpdateImage.Checked;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			DisconnectTelescope();
		}

		private async void btPark_Click(object sender, EventArgs e)
		{
			try
			{
				if (_Telescope == null || !_Telescope.Connected)
					return;
				if (_Telescope.AtPark)
				{
					_Telescope.Unpark();
					_Telescope.Tracking = false;
				}
				else
					await Task.Run(() => _Telescope.Park());
				UpdateMovementButtons();
			} catch(Exception ex)
			{
				MessageBox.Show(ex.Message,ex.GetType().Name,MessageBoxButtons.OK,MessageBoxIcon.Error);

			}
		}

		private void timerMountStat_Tick(object sender, EventArgs e)
		{
			UpdateMovementButtons();
		}
	}
	public enum SelectionMode { off, WaitingEnd }
}
