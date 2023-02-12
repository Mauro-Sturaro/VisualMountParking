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
			var il = new WebUtils();
			var img = il.LoadImage(Config.SourceType, Config.Source);
			picPreview.Image = img;
			if (img != null)
			{
				btSetAsReference.Enabled = true;
				btExportPreview.Enabled = true;
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

			numRaRrate.Value = Config.MoveRaRate;
			numDecRate.Value = Config.MoveDecRate;

			numRaTime.Value = Config.MoveRaTime;
			numDecTime.Value = Config.MoveDecTime;

			numFastSpeed.Value = Config.FastRateMultiplier;
			numFastTime.Value = Config.FastTimeMultiplier;

			// Image
			cmbSourceType.SelectedIndex = (int)Config.SourceType;
			txtSource.Text = Config.Source;

			// AutoPark
			txtRegionsCount.Text = Config.Templates.Count.ToString();
			chkUseAruco.Checked = Config.UseArucoMarkers;
			numMarkerIdAr.Value = Config.AutoParkAR.ZoneId;
			numMarkerIdDec.Value = Config.AutoParkDec.ZoneId;
			cmbMarkerArDirection.SelectedIndex = Config.AutoParkAR.Direction == ShiftDirection.X? 0 : 1;
			cmbMarkerDecDirection.SelectedIndex = Config.AutoParkDec.Direction == ShiftDirection.X ? 0 : 1;


		}
		private void CopyFormToConfig()
		{
			Config.MoveRaRate = numRaRrate.Value;
			Config.MoveDecRate = numDecRate.Value;
			Config.MoveRaTime = numRaTime.Value;
			Config.MoveDecTime = numDecTime.Value;
			Config.FastRateMultiplier = numFastSpeed.Value;
			Config.FastTimeMultiplier = numFastTime.Value;

			// AutoPark			
			Config.UseArucoMarkers = chkUseAruco.Checked;
			Config.AutoParkAR.ZoneId =(int)numMarkerIdAr.Value;
			Config.AutoParkDec.ZoneId = (int)numMarkerIdDec.Value;
			Config.AutoParkAR.Direction = cmbMarkerArDirection.SelectedIndex == 0 ? ShiftDirection.X: ShiftDirection.Y;
			Config.AutoParkDec.Direction = cmbMarkerDecDirection.SelectedIndex == 0 ? ShiftDirection.X : ShiftDirection.Y;
		}

		private void txtSource_Validated(object sender, EventArgs e)
		{
			Config.Source = txtSource.Text;
		}

		private void cmbSourceType_SelectedIndexChanged(object sender, EventArgs e)
		{

			Config.SourceType = (ImageSourceType)cmbSourceType.SelectedIndex;
			switch (Config.SourceType)
			{
				case ImageSourceType.File:
					lblSource.Text = "Path:";
					break;
				case ImageSourceType.URL:
					lblSource.Text = "URL:";
					break;
			}
		}

		private void btRegionsClear_Click(object sender, EventArgs e)
		{
			Config.Templates.Clear();
			txtRegionsCount.Text = "0";
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
