using ASCOM.DeviceInterface;
using Emgu.CV.Ocl;
using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Imaging;
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
        readonly WebUtils _WebUtils = new WebUtils();
        private AutoPark _vpDriver;
        private MarkerMatchEngine _markersFinder;
        private MyTelescope _MyTelescope;

        public MainForm()
        {
            InitializeComponent();
            this.Icon = Resources._2bs_logo;
        }

        private Config config;

        private async void MainForm_Load(object sender, EventArgs e)
        {

            cmbImageToShow.SelectedIndex = 0;
            cmbReferenceImage.SelectedIndex = 0;

            config = Config.Load();

            _markersFinder = new MarkerMatchEngine(config.ReferenceImage1);

            _MyTelescope?.Disconnect();
            _MyTelescope = new MyTelescope();
            _MyTelescope.Initialize(config.TelescopeDriver);

            _vpDriver = new AutoPark();
            _vpDriver.Initialize(config, _markersFinder, _MyTelescope);

            UpdateMovementButtons();

            _vpDriver.ImageChanged += _vpDriver_ImageChanged;

            await _vpDriver.UpdateImageAndPosition();
            timerImage.Enabled = !chkFreezeImage.Checked;
        }

        private void _vpDriver_ImageChanged(object sender, ImageChangedEventArgs e)
        {
            if (_ImageToShow == ImageToShow.LiveTracking)
            {
                picCurrent.Image = (Image)e.NewImage.Clone(); //ToDo evitare la copia
            }
            else if (_ImageToShow == ImageToShow.LiveAllMarkers)
            {
                var newImage = (Bitmap)e.NewImage.Clone();
                picCurrent.Image = (Image)_markersFinder.ShowAllMarkers(newImage).Clone();
            }
        }

        private async Task RefreshImage()
        {
            await _vpDriver.UpdateImageAndPosition();
            picCurrent.Invalidate();
            if(_vpDriver.InRange.HasValue)
             pnlImageBorder.BackColor = _vpDriver.InRange.Value ? Color.DarkSeaGreen:Color.DarkSalmon;
            else
                pnlImageBorder.BackColor = System.Drawing.SystemColors.Control;
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

            if (_ImageToShow == ImageToShow.LiveAllMarkers)
                return;

            DrawOverlay((PictureBox)sender, e.Graphics);
        }

        private void DrawOverlay(PictureBox sender, Graphics g)
        {
            GetStretch(sender, out var stretchX, out var stretchY, out var shiftX, out var shiftY);

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

        private void chkImageSize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkImageSize.Checked)
            {
                picCurrent.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                picCurrent.SizeMode = PictureBoxSizeMode.Normal;
            }
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
                    if (cmbReferenceImage.SelectedIndex == 0)
                        _markersFinder = new MarkerMatchEngine(config.ReferenceImage1);
                    else
                        _markersFinder = new MarkerMatchEngine(config.ReferenceImage1);

                    _MyTelescope?.Disconnect();
                    _MyTelescope = new MyTelescope();
                    _MyTelescope.Initialize(config.TelescopeDriver);

                    _vpDriver.Initialize(config, _markersFinder, _MyTelescope);
                }
            }
        }

        bool ShowingOriginal = false;
        private void picCurrent_MouseDown(object sender, MouseEventArgs e)
        {
            if (cmbReferenceImage.SelectedIndex == 0)
            {
                _ImageToShow = ImageToShow.Reference1;
                picCurrent.Image = config.ReferenceImage1;
            }
            else
            {
                _ImageToShow = ImageToShow.Reference2;
                picCurrent.Image = config.ReferenceImage2;
            }
        }

        private void picCurrent_MouseUp(object sender, MouseEventArgs e)
        {
            cmbImageToShow_SelectedIndexChanged(null, null);
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
            btLightOFF.Enabled = false;
            try
            {

                var result = await _WebUtils.RunCommandURIAsync(config.LightOffCommand);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            btLightOFF.Enabled = true;
        }

        CancellationTokenSource _CancellationTokenSource = new CancellationTokenSource();

        private async void btRaLow2_Click(object sender, EventArgs e)
        {
            MoveButtonsActive = true;
            await RotateAxis(TelescopeAxes.axisPrimary, -config.MoveRaRate * config.FastRateMultiplier, config.MoveRaTime * config.FastTimeMultiplier);
            MoveButtonsActive = false;
        }

        private async void btRaLow_Click(object sender, EventArgs e)
        {
            MoveButtonsActive = true;
            await RotateAxis(TelescopeAxes.axisPrimary, -config.MoveRaRate, config.MoveRaTime);
            MoveButtonsActive = false;
        }

        private async void btRaHigh_Click(object sender, EventArgs e)
        {
            MoveButtonsActive = true;
            await RotateAxis(TelescopeAxes.axisPrimary, config.MoveRaRate, config.MoveRaTime);
            MoveButtonsActive = false;
        }

        private async void btRaHigh2_Click(object sender, EventArgs e)
        {
            MoveButtonsActive = true;
            await RotateAxis(TelescopeAxes.axisPrimary, config.MoveRaRate * config.FastRateMultiplier, config.MoveRaTime * config.FastTimeMultiplier);
            MoveButtonsActive = false;
        }

        private async void btDecLow2_Click(object sender, EventArgs e)
        {
            MoveButtonsActive = true;
            await RotateAxis(TelescopeAxes.axisSecondary, -config.MoveDecRate * config.FastRateMultiplier, config.MoveDecTime * config.FastTimeMultiplier);
            MoveButtonsActive = false;
        }

        private async void btDecLow_Click(object sender, EventArgs e)
        {
            MoveButtonsActive = true;
            await RotateAxis(TelescopeAxes.axisSecondary, -config.MoveDecRate, config.MoveRaTime);
            MoveButtonsActive = false;
        }

        private async void btDecHigh_Click(object sender, EventArgs e)
        {
            MoveButtonsActive = true;
            await RotateAxis(TelescopeAxes.axisSecondary, config.MoveDecRate, config.MoveRaTime);
            MoveButtonsActive = false;
        }

        private async void btDecHigh2_Click(object sender, EventArgs e)
        {
            MoveButtonsActive = true;
            await RotateAxis(TelescopeAxes.axisSecondary, config.MoveDecRate * config.FastRateMultiplier, config.MoveDecTime * config.FastTimeMultiplier);
            MoveButtonsActive = false;
        }

        private async Task RotateAxis(TelescopeAxes axis, double rate, double time)
        {
            _CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await _MyTelescope.RotateAxisAsync(axis, rate, time, _CancellationTokenSource.Token);
            }
            catch (TaskCanceledException) { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            await RefreshImage();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (_MyTelescope.IsTelescopeConnected)
                _MyTelescope.Disconnect();
            else
                _MyTelescope.Connect();
            UpdateMovementButtons();
        }

        private void UpdateMovementButtons()
        {
            bool canMove;

            if (_MyTelescope.IsTelescopeConnected)
            {
                btConnect.Text = "Disconnect";
                btPark.Enabled = true;
                if (_MyTelescope.TelescopeState == TelescopeState.AtPark)
                {
                    btPark.Text = "Unpark";
                    canMove = false;
                }
                else
                {
                    btPark.Text = "Park";
                    canMove = true;
                }
                SetMoving(_MyTelescope.TelescopeState == TelescopeState.Moving);
            }
            else
            {
                btConnect.Text = "Connect";
                btPark.Enabled = false;
                canMove = false;
            }

            btSTOP.Enabled = canMove;
            MoveButtonsEnabled( canMove && !MoveButtonsActive);          
        }

        private void MoveButtonsEnabled(bool enabled)
        {
            btAutoPark.Enabled = enabled;
            btRaHigh2.Enabled = btRaHigh.Enabled = btRaLow.Enabled = btRaLow2.Enabled = enabled;
            btDecHigh2.Enabled = btDecHigh.Enabled = btDecLow.Enabled = btDecLow2.Enabled = enabled;
        }

        private bool MoveButtonsActive;

        private void SetMoving(bool moving)
        {
            if (moving)
            {
                btSTOP.UseVisualStyleBackColor = false;
                btSTOP.BackColor = Color.Tomato;
            }
            else
            {
                btSTOP.BackColor = System.Drawing.SystemColors.Control;
                btSTOP.UseVisualStyleBackColor = true;
            }

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            _MyTelescope.StopAnyMovement(); // per sicurezza
            _CancellationTokenSource.Cancel();
            _MyTelescope.StopAnyMovement(); // per sicurezza
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
            timerImage.Stop();
            timerMountStat.Stop();
            _MyTelescope.Disconnect();
        }

        private async void btPark_Click(object sender, EventArgs e)
        {
            try
            {
                if (_MyTelescope.TelescopeState != TelescopeState.AtPark)
                    await _MyTelescope.ParkTelescope();
                else
                    _MyTelescope.UnParkTelescope();
                UpdateMovementButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerMountStat_Tick(object sender, EventArgs e)
        {
            // aggiorna in polling i bottoni in funzione dello stato della montatura
            UpdateMovementButtons();
        }

        private async void btAutoPark_Click(object sender, EventArgs e)
        {
            
            MoveButtonsActive=true;

            _CancellationTokenSource?.Cancel();
            _CancellationTokenSource = new CancellationTokenSource();
            try
            {
                _vpDriver.Logger = LogWriter;
                var success = await _vpDriver.SlaveToReference(_CancellationTokenSource.Token);
            }
            catch (Exception ex)  { 
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                MoveButtonsActive = false;
            }
        }

        private void LogWriter(string msg)
        {
            log?.Write(msg);
        }

        LogForm log;

        private async void tbLum_ValueChanged(object sender, EventArgs e)
        {

            await _vpDriver.UpdateImageAndPosition();
        }

        private async void tbContrast_ValueChanged(object sender, EventArgs e)
        {

            await _vpDriver.UpdateImageAndPosition();
        }

        private void cmbImageToShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbImageToShow.SelectedIndex)
            {
                case 0:
                    _ImageToShow = ImageToShow.LiveTracking;
                    break;
                case 1:
                    _ImageToShow = ImageToShow.LiveAllMarkers;
                    break;
                case 2:
                    _ImageToShow = ImageToShow.Reference1;
                    picCurrent.Image = config.ReferenceImage1;
                    break;
                case 3:
                    _ImageToShow = ImageToShow.Reference2;
                    picCurrent.Image = config.ReferenceImage2;
                    break;
            }
        }

        ImageToShow _ImageToShow;

        private enum ImageToShow
        {
            LiveTracking,
            LiveAllMarkers,
            Reference1,
            Reference2,
        }

        private void cmbReferenceImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (config == null)
                return;

            if (cmbReferenceImage.SelectedIndex == 0)
            {
                _markersFinder = new MarkerMatchEngine(config.ReferenceImage1);
            }
            else
            {
                _markersFinder = new MarkerMatchEngine(config.ReferenceImage2);
            }
            _vpDriver.ChangeVerifier(_markersFinder);
        }
    }

}
