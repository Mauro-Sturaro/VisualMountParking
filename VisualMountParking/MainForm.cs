using ASCOM.DeviceInterface;
using ASCOM.DriverAccess;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualMountParking.Markers;
using VisualMountParking.Properties;

namespace VisualMountParking
{


    public partial class MainForm : Form
    {
        bool _MouseDragging = false;
        Point _SelectionFirstPoint;
        Point _SelectionLastPoint;
        readonly WebUtils _WebUtils = new WebUtils();
        readonly VisualParkDriver _vpDriver = new VisualParkDriver();

        public MainForm()
        {
            InitializeComponent();
            this.Icon = Resources._2bs_logo;
        }

        private Config config;

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
            _vpDriver.ImageUpdated += vpDriver_ImageUpdated;

            await _vpDriver.UpdateImageAndPosition();
            timerImage.Enabled = !chkFreezeImage.Checked;
        }

        private void vpDriver_ImageUpdated(object sender, EventArgs e)
        {
            if (!ShowingOriginal)
            {
                picCurrent.Image?.Dispose();
                picCurrent.Image = _vpDriver.CurrentImage;
            }
        }

        private async Task RefreshImage()
        {
            await _vpDriver.UpdateImageAndPosition();
            picCurrent.Invalidate();
        }

        private void btSetRefImage_Click(object sender, EventArgs e)
        {
            config.ReferenceImage = _vpDriver.CurrentImage;
            _vpDriver.Initialize(config);
            picReference.Image = _vpDriver.CurrentImage;
        }

        private static void SortPoint(Point point1, Point point2, out Point topLeft, out Point bottomRight)
        {
            topLeft = new Point(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            bottomRight = new Point(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
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

        static readonly Pen penOk1 = new Pen(Color.DarkGreen, 3);
        static readonly Pen penOk2 = new Pen(Color.LightGreen, 1);
        static readonly Pen penRef1 = new Pen(Color.DarkBlue, 3);
        static readonly Pen penRef2 = new Pen(Color.LightBlue, 1);
        static readonly Pen penBad1 = new Pen(Color.DarkRed, 3);
        static readonly Pen penBad2 = new Pen(Color.LightPink, 1);

        static readonly Font drawFont = new Font("Arial", 10);
        static readonly SolidBrush drawBrush = new SolidBrush(Color.Gold);
        static readonly Brush txtBackground = new SolidBrush(Color.FromArgb(100, 0, 0, 0));


        private void picCurrent_Paint(object sender, PaintEventArgs e)
        {
            if (chkFreezeImage.Checked)
                return;
            if (picCurrent.Image == null)
                return;
            GetStretch((PictureBox)sender, out var stretchX, out var stretchY, out var shiftX, out var shiftY);
            var g = e.Graphics;
            foreach (var zoneMatch in _vpDriver.GetZoneMatch())
            {
                var sp = zoneMatch.Source;
                var tp = zoneMatch.Target;

                var x = (int)((sp == null ? tp.X : sp.X) * stretchX) + shiftX;
                var y = (int)((sp == null ? tp.Y : sp.Y) * stretchY) + shiftY;

                if (sp != null && tp != null && sp.X == tp.X && sp.Y == tp.Y)
                {
                    // Green cross
                    DrawMarker(g, penOk1, x, y);
                    DrawMarker(g, penOk2, x, y);
                    if (ShowingOriginal)
                    {
                        var msg = $"id={tp.Id}";
                        DrawStringWithBackground(g, x, y, msg);
                    }
                }
                else
                {
                    if (sp != null)
                    {
                        if (ShowingOriginal || tp != null)
                        {
                            // Blue cross
                            DrawMarker(g, penRef1, x, y);
                            DrawMarker(g, penRef2, x, y);

                            if (ShowingOriginal)
                            {
                                var msg = $"id={sp.Id}";
                                DrawStringWithBackground(g, x, y, msg);
                            }
                        }
                    }
                    if (tp != null)
                    {
                        // Red Cross
                        var x1 = (int)(tp.X * stretchX) + shiftX;
                        var y1 = (int)(tp.Y * stretchY) + shiftY;

                        DrawMarker2(g, penBad1, x1, y1);
                        DrawMarker2(g, penBad2, x1, y1);
                        if (sp != null)
                        {
                            if (!ShowingOriginal)
                            {
                                var msg = $"{tp.X - sp.X},{tp.Y - sp.Y}";
                                DrawStringWithBackground(g, x1, y1, msg);
                            }
                        }
                        g.DrawLine(penBad2, x1, y1, x, y);
                    }
                }
            }
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
                //g.DrawRectangle(bluePen, x, y, (int)(tp.Width * stretchX), (int)(tp.Height * stretchY));
                DrawMarker(g, penRef1, x, y);
                DrawMarker(g, penRef2, x, y);

                var msg = $"id={tp.Id}";
                DrawStringWithBackground(g, x + 2, y + 2, msg);
            }
            if (_MouseDragging)
            {
                SortPoint(_SelectionFirstPoint, _SelectionLastPoint, out var startPoint, out var endPoint);
                g.DrawRectangle(new Pen(Color.Coral, 1), startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);

            }
        }

        private static void DrawMarker(Graphics g, Pen pen, int x, int y)
        {
            var delta = 5;
            g.DrawLine(pen, x - delta, y, x + delta, y);
            g.DrawLine(pen, x, y - delta, x, y + delta);
        }
        private static void DrawMarker2(Graphics g, Pen pen, int x, int y)
        {
            var delta = 4;
            g.DrawLine(pen, x - delta, y - delta, x + delta, y + delta);
            g.DrawLine(pen, x + delta, y - delta, x - delta, y + delta);
        }


        private static void DrawStringWithBackground(Graphics g, int x, int y, string msg)
        {
            var txtSize = g.MeasureString(msg, drawFont);
            var txtX = x + 6;
            var txtY = y + 6;
            g.FillRectangle(txtBackground, txtX, txtY, txtSize.Width, txtSize.Height);
            g.DrawString(msg, drawFont, drawBrush, txtX, txtY);
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

        private void ReplaceImage(Image newImage)
        {
            picReference.Image?.Dispose();
            picReference.Image = newImage;
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
            await RefreshImage();
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
            await RefreshImage();
            loading = false;
        }

        private void chkFreezeImage_CheckedChanged(object sender, EventArgs e)
        {
            timerImage.Enabled = !chkFreezeImage.Checked;
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
            if (log != null)
            {
                log.Dispose();
                log = null;
            }

            log = new LogForm();
            log.Show();
            log.Left = this.Right;
            log.Top = this.Top;

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

        private async void tbLum_ValueChanged(object sender, EventArgs e)
        {
            _vpDriver.Brighness = tbLum.Value;
            await _vpDriver.UpdateImageAndPosition();
        }

        private async void tbContrast_ValueChanged(object sender, EventArgs e)
        {
            _vpDriver.Contrast = tbContrast.Value;
            await _vpDriver.UpdateImageAndPosition();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chkFreezeImage.Checked = true;
            chkFreezeImage_CheckedChanged(null, null);

            //-----
            var det = new ArucoDetector();
            det.Initialize();
            var image = picCurrent.Image as Bitmap;
            if (image == null) return;
            var dimg = det.ShowMarkers(image, true);
            picCurrent.Image = dimg;
        }

        private void btPrintCalibration_Click(object sender, EventArgs e)
        {
            ArucoUtilities.PrintCharucoBoard(@"C:\temp\ChArUco_Board.png");
            ArucoUtilities.PrintArucoBoard(@"C:\temp\ArUco_Board.png");
        }

        private void btCalibration_Click(object sender, EventArgs e)
        {
            var aruco = new ArucoDetector();
            
        }

    }


}
