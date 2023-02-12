using ASCOM.DeviceInterface;
using ASCOM.DriverAccess;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualMountParking.Properties;

namespace VisualMountParking
{

	// Camera WebAPI documentation https://drive.google.com/file/d/15AFMQSMlMdpjL2USPsvYd-J9xWecrEf9/view
	public partial class MainForm : Form
	{
		bool _MouseDragging = false;
		Point _SelectionFirstPoint;
		Point _SelectionLastPoint;
		WebUtils _WebUtils = new WebUtils();
		VisualParkDriver _vpDriver = new VisualParkDriver();

		public MainForm()
		{
			InitializeComponent();
			this.Icon = Resources._2bs_logo;
		}

		private Config config; //{ get { return _vpDriver.Config; } set { _vpDriver.Config = value; } }

		public bool ShowRefImage
		{
			get => chkShowRef.Checked;
			set
			{
				chkShowRef.Checked = value;
				MainForm_Resize(this, EventArgs.Empty);
			}
		}

		private async void MainForm_Load(object sender, EventArgs e)
		{
			ShowRefImage = false;
			MainForm_Resize(sender, e);
			config = Config.Load();
			_vpDriver.Initialize(config);

			UpdateMovementButtons();
			btCancel.BringToFront();

			picReference.Image = config.ReferenceImage;
			_vpDriver.ImageUpdated += _vpDriver_ImageUpdated;
			//await _vpDriver.LoadNewImage();
			await _vpDriver.UpdateImageAndPosition();
		}

		private void _vpDriver_ImageUpdated(object sender, EventArgs e)
		{
			if (!ShowingOriginal)
				picCurrent.Image = _vpDriver.CurrentImage;
		}

		private async void buttonLoadImage_Click(object sender, EventArgs e)
		{
			//picCurrent.Image = await _vpDriver.LoadNewImage();
			//await _vpDriver.CheckPosition();
			await _vpDriver.UpdateImageAndPosition();
			picCurrent.Invalidate();
		}

		private void btSetRefImage_Click(object sender, EventArgs e)
		{
			config.ReferenceImage = _vpDriver.CurrentImage;
			_vpDriver.Initialize(config);
			picReference.Image = _vpDriver.CurrentImage;
		}
		private void picReference_MouseDown(object sender, MouseEventArgs e)
		{
			if (_MouseDragging == false && !config.UseArucoMarkers)
			{
				_SelectionFirstPoint = e.Location;
				_MouseDragging = true;
				picReference.Cursor = Cursors.Cross;
			}
		}

		private void picReference_MouseMove(object sender, MouseEventArgs e)
		{
			_SelectionLastPoint = e.Location;
			picReference.Invalidate();
		}

		private void picReference_MouseUp(object sender, MouseEventArgs e)
		{
			if (_MouseDragging)
			{

				//
				GetStretch(picReference, out var stretchX, out var stretchY, out var shiftX, out var shiftY);

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
				{
					int i = 1;
					for (; i <= config.Templates.Count; i++)
					{
						if (!config.Templates.Exists((z) => z.Id == i))
							break;
					}
					item.Id = i;
					config.Templates.Add(item);
				}

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

		private void picReference_Paint(object sender, PaintEventArgs e)
		{
			if (picReference.Image == null)
				return;
			GetStretch((PictureBox)sender, out var stretchX, out var stretchY, out var shiftX, out var shiftY);
			var g = e.Graphics;
			foreach (var tp in _vpDriver.GetReferenceZone())
			{
				int x = (int)(tp.X * stretchX) + shiftX;
				int y = (int)(tp.Y * stretchY) + shiftY;
				g.DrawRectangle(new Pen(Color.Blue, 1), x, y, (int)(tp.Width * stretchX), (int)(tp.Height * stretchY));
				var msg = $"id={tp.Id}";
				g.DrawString(msg, drawFont, drawBrush, x + 2, y + 2);
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

		private void picReference_Click(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			GetStretch(picReference, out var stretchX, out var stretchY, out var shiftX, out var shiftY);
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
		static SolidBrush drawBrush = new SolidBrush(Color.Gold);

		private void picCurrent_Paint(object sender, PaintEventArgs e)
		{
			if (picCurrent.Image == null)
				return;
			GetStretch((PictureBox)sender, out var stretchX, out var stretchY, out var shiftX, out var shiftY);
			var g = e.Graphics;
			foreach (var zoneMatch in _vpDriver.GetZoneMatch())
			{
				var sp = zoneMatch.Source;
				var tp = zoneMatch.Target;

				var x = (int)(sp?.X * stretchX) + shiftX;
				var y = (int)(sp?.Y * stretchY) + shiftY;

				if (sp != null && tp != null && sp.X == tp.X && sp.Y == tp.Y && sp.Width == tp.Width && sp.Height == tp.Height)
				{
					g.DrawRectangle(greenPen, x, y, (int)(tp.Width * stretchX), (int)(tp.Height * stretchY));
				}
				else
				{
					if (sp != null)
					{
						g.DrawRectangle(bluePen, x, y, (int)(sp.Width * stretchX), (int)(sp.Height * stretchY));
					}
					if (tp != null)
					{
						var x1 = (int)(tp.X * stretchX) + shiftX;
						var y1 = (int)(tp.Y * stretchY) + shiftY;
						g.DrawRectangle(redPen, x1, y1, (int)(tp.Width * stretchX), (int)(tp.Height * stretchY));
						if (sp != null)
						{
							var msg = $"{tp.X - sp.X},{tp.Y - sp.Y}";
							g.DrawString(msg, drawFont, drawBrush, x1 + 2, y1 + 2);
						}
					}
				}
			}
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			var dX = picCurrent.Left;
			var top = picCurrent.Top;
			var height = ClientSize.Height - top - dX;

			int width;
			if (ShowRefImage)
				width = (ClientSize.Width - dX * 3) / 2;
			else
				width = ClientSize.Width - dX * 2;

			picReference.Top = picCurrent.Top = top;
			picReference.Width = picCurrent.Width = width;
			picReference.Height = picCurrent.Height = height;
			picReference.Left = width + dX * 2;
			if (ShowRefImage)
			{
				picReference.Visible = true;
			}
			else
			{
				picReference.Visible = false;
			}
		}

		private void chkImageSize_CheckedChanged(object sender, EventArgs e)
		{
			if (chkImageSize.Checked)
			{
				picReference.SizeMode = PictureBoxSizeMode.Zoom;
				picCurrent.SizeMode = PictureBoxSizeMode.Zoom;
			}
			else
			{
				picReference.SizeMode = PictureBoxSizeMode.Normal;
				picCurrent.SizeMode = PictureBoxSizeMode.Normal;
			}
			picReference.Invalidate();
			picCurrent.Invalidate();

		}

		private void btSettings_Click(object sender, EventArgs e)
		{
			using (var f = new SettingsForm())
			{

				f.Config = config.Clone();
				if (f.ShowDialog(this) == DialogResult.OK)
				{
					config = f.Config;
					_vpDriver.Initialize(config);
					picReference.Image = config.ReferenceImage;
				}
			}
		}

		bool ShowingOriginal = false;
		private void picCurrent_MouseDown(object sender, MouseEventArgs e)
		{
			ShowingOriginal = true;
			picCurrent.Image = config.ReferenceImage;
		}

		private void picCurrent_MouseUp(object sender, MouseEventArgs e)
		{
			picCurrent.Image = _vpDriver.CurrentImage;
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
			var deltaSize = picCurrent.Width + picCurrent.Left;
			if (chkShowRef.Checked)
			{
				this.Width += deltaSize;
			}
			else
			{
				this.Width -= deltaSize;
			}

		}

		CancellationTokenSource _CancellationTokenSource = new CancellationTokenSource();

		private async void btRaLow2_Click(object sender, EventArgs e)
		{
			await RotateAxis(TelescopeAxes.axisPrimary, -config.MoveRaRate * config.FastRateMultiplier, config.MoveRaTime * config.FastTimeMultiplier);
		}

		private async void btRaLow_Click(object sender, EventArgs e)
		{
			await RotateAxis(TelescopeAxes.axisPrimary, -config.MoveRaRate, config.MoveRaTime);
		}

		private async void btRaHigh_Click(object sender, EventArgs e)
		{
			await RotateAxis(TelescopeAxes.axisPrimary, config.MoveRaRate, config.MoveRaTime);
		}

		private async void btRaHigh2_Click(object sender, EventArgs e)
		{
			await RotateAxis(TelescopeAxes.axisPrimary, config.MoveRaRate * config.FastRateMultiplier, config.MoveRaTime * config.FastTimeMultiplier);
		}

		private async void btDecLow2_Click(object sender, EventArgs e)
		{
			await RotateAxis(TelescopeAxes.axisSecondary, -config.MoveDecRate * config.FastRateMultiplier, config.MoveDecTime * config.FastTimeMultiplier);
		}

		private async void btDecLow_Click(object sender, EventArgs e)
		{
			await RotateAxis(TelescopeAxes.axisSecondary, -config.MoveDecRate, config.MoveRaTime);
		}

		private async void btDecHigh_Click(object sender, EventArgs e)
		{
			await RotateAxis(TelescopeAxes.axisSecondary, config.MoveDecRate, config.MoveRaTime);
		}

		private async void btDecHigh2_Click(object sender, EventArgs e)
		{
			await RotateAxis(TelescopeAxes.axisSecondary, config.MoveDecRate * config.FastRateMultiplier, config.MoveDecTime * config.FastTimeMultiplier);
		}

		private async Task RotateAxis(TelescopeAxes axis, decimal rate, decimal time)
		{
			_CancellationTokenSource = new CancellationTokenSource();
			try
			{
				await _vpDriver.RotateAxis(axis, rate, time, _CancellationTokenSource.Token);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			buttonLoadImage_Click(null, null);
		}

		private void btConnect_Click(object sender, EventArgs e)
		{
			if (_vpDriver.IsTelescopeConnected)
				_vpDriver.DisconnectTelescope();
			else
				_vpDriver.ConnectTelescope();
			UpdateMovementButtons();
		}

		private void UpdateMovementButtons()
		{
			bool canMove;

			if (_vpDriver.IsTelescopeConnected)
			{
				btConnect.Text = "Disconnect";
				btPark.Enabled = true;
				if (_vpDriver.TelescopeState == TelescopeState.AtPark)
				{
					btPark.Text = "Unpark";
					canMove = false;
				}
				else
				{
					btPark.Text = "Park";
					canMove = true;
				}
				if (_vpDriver.TelescopeState == TelescopeState.Moving)
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
			btAutoPark.Enabled = canMove;
			btRaHigh2.Enabled = btRaHigh.Enabled = btRaLow.Enabled = btRaLow2.Enabled = canMove;
			btDecHigh2.Enabled = btDecHigh.Enabled = btDecLow.Enabled = btDecLow2.Enabled = canMove;
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			_vpDriver.StopTelescope(); // per sicurezza
			_CancellationTokenSource.Cancel();
			_vpDriver.StopTelescope(); // per sicurezza
		}

		bool loading = false;
		private async void timerImage_Tick(object sender, EventArgs e)
		{
			if (loading || ShowingOriginal)
				return;
			loading = true;
			await _vpDriver.UpdateImageAndPosition();
			picCurrent.Invalidate();
			loading = false;
		}

		private void chkUpdateImage_CheckedChanged(object sender, EventArgs e)
		{
			timerImage.Enabled = chkUpdateImage.Checked;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			_vpDriver.DisconnectTelescope();
		}

		private async void btPark_Click(object sender, EventArgs e)
		{
			try
			{
				if (_vpDriver.TelescopeState != TelescopeState.AtPark)
					await _vpDriver.ParkTelescope();
				else
					_vpDriver.UnParkTelescope();
				UpdateMovementButtons();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void timerMountStat_Tick(object sender, EventArgs e)
		{
			UpdateMovementButtons();
		}

		private async void btAutoPark_Click(object sender, EventArgs e)
		{
			// ensure log window is open
			if (log != null && !log.Visible)
			{
				log.Dispose();
				log = null;
			}
			if (log == null)
			{
				log = new LogForm();
				log.Show();
				log.Left = this.Right;
				log.Top = this.Top;
			}

			btAutoPark.Enabled = false;
			_CancellationTokenSource = new CancellationTokenSource();
			try
			{
				_vpDriver.Logger = LogWriter;
				var success = await _vpDriver.DoVisualPark(_CancellationTokenSource.Token);
			}
			catch { }
			finally
			{
				btAutoPark.Enabled = true;
			}
		}

		private void LogWriter(string msg)
		{
			log.Write(msg);
		}

		LogForm log;

	}


}
