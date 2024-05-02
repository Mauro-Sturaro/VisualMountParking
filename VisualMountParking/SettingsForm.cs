//using Accord.Controls;
using ASCOM.DriverAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualMountParking.Camera;

namespace VisualMountParking
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public Config Config { get; internal set; }

        private void btPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (var camera = CameraFactory.Instance.GetCamera(Config.CameraName))
                {
                    camera.Initialize(Config.CameraSettings);

                    var img = AsyncUtil.RunSync(camera.LoadImageAsync);
                    if (img != null)
                    {
                        picPreview.Image = img;
                        btSetAsReference.Enabled = true;
                        btExportPreview.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            CopyFormToConfig();

            //DialogResult = DialogResult.OK;
            Config.Save();
            //this.Close();
        }


        private void SettingsForm_Load(object sender, EventArgs e)
        {
            CopyConfigToForm();
        }

        private void CopyConfigToForm()
        {
            // Telescope
            txtTelescopeDriver.Text = Config.TelescopeDriver;

            numRaRrate.Value = (decimal) Config.MoveRaRate;
            numDecRate.Value = (decimal)Config.MoveDecRate;

            numRaTime.Value = (decimal)Config.MoveRaTime;
            numDecTime.Value = (decimal)Config.MoveDecTime;

            numFastSpeed.Value = (decimal)Config.FastRateMultiplier;
            numFastTime.Value = (decimal)Config.FastTimeMultiplier;

            // Image
            // dropdown items 
            cmbSourceType.Items.Clear();
            foreach (var item in CameraFactory.Instance.Names)
                cmbSourceType.Items.Add(item);
            // set current selection
            int i = CameraFactory.Instance.Names.IndexOf(Config.CameraName);
            cmbSourceType.SelectedIndex = Math.Max(i, 0);

            txtSource.Text = Config.CameraSettings;

            // AutoPark
            numMarkerIdAr.Value = Config.AutoParkAR.ZoneId;
            numMarkerIdDec.Value = Config.AutoParkDec.ZoneId;
            cmbMarkerArDirection.SelectedIndex = Config.AutoParkAR.Direction == ShiftDirection.X ? 0 : 1;
            cmbMarkerDecDirection.SelectedIndex = Config.AutoParkDec.Direction == ShiftDirection.X ? 0 : 1;


        }
        private void CopyFormToConfig()
        {
            Config.MoveRaRate = (double)numRaRrate.Value;
            Config.MoveDecRate = (double)numDecRate.Value;
            Config.MoveRaTime = (double)numRaTime.Value;
            Config.MoveDecTime = (double)numDecTime.Value;
            Config.FastRateMultiplier =  (double)numFastSpeed.Value;
            Config.FastTimeMultiplier = (double)numFastTime.Value;

            // AutoPark			
            Config.AutoParkAR.ZoneId = (int)numMarkerIdAr.Value;
            Config.AutoParkDec.ZoneId = (int)numMarkerIdDec.Value;
            Config.AutoParkAR.Direction = cmbMarkerArDirection.SelectedIndex == 0 ? ShiftDirection.X : ShiftDirection.Y;
            Config.AutoParkDec.Direction = cmbMarkerDecDirection.SelectedIndex == 0 ? ShiftDirection.X : ShiftDirection.Y;
        }

        private void txtSource_Validated(object sender, EventArgs e)
        {
            Config.CameraSettings = txtSource.Text;
        }

        private void cmbSourceType_SelectedIndexChanged(object sender, EventArgs e)
        {

            Config.CameraName = (string)cmbSourceType.SelectedItem;
            //switch (Config.SourceType)
            //{
            //    case ImageSourceType.File:
            //        lblSource.Text = "Path:";
            //        txtSource.AutoCompleteSource = AutoCompleteSource.FileSystem;
            //        break;
            //    case ImageSourceType.URL:
            //        lblSource.Text = "URL:";
            //        txtSource.AutoCompleteSource = AutoCompleteSource.HistoryList;
            //        break;
            //}
        }

        private void btLightOn_Click(object sender, EventArgs e)
        {
            using (var form = new EditCommand())
            {

                form.Command = Config.LightOnCommand;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Config.LightOnCommand = form.Command;
                }
            }
        }

        private void btLightOff_Click(object sender, EventArgs e)
        {
            using (var form = new EditCommand())
            {

                form.Command = Config.LightOffCommand;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Config.LightOffCommand = form.Command;
                }
            }
        }

        private void btExportPreview_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "png file (*.png)|*.png";
                dlg.FileName = "PreviewImage.png";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    picPreview.Image.Save(dlg.FileName);
                }
            }
        }

        private void btTelescopeChoose_Click(object sender, EventArgs e)
        {
            var progId = Telescope.Choose(Config.TelescopeDriver);
            if (string.IsNullOrEmpty(progId))
                return;
            txtTelescopeDriver.Text = progId;
            Config.TelescopeDriver = progId;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //StoreMoveSettings();
        }

        private void btSetAsReference_Click(object sender, EventArgs e)
        {
            Config.ReferenceImage = new Bitmap(picPreview.Image);
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            CopyFormToConfig();
        }
    }
}
