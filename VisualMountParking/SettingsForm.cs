using Accord.Controls;
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
		}

		private void btSave_Click(object sender, EventArgs e)
		{			
		 	DialogResult= DialogResult.OK;			
			Config.Save();
			this.Close();
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			txtRaStep.Text = Config.MoveRaStep.ToString();
			txtDecStep.Text = Config.MoveDecStep.ToString();

			cmbSourceType.SelectedIndex = (int)Config.SourceType;
			txtRegionsCount.Text = Config.Templates.Count.ToString();
			txtSource.Text = Config.Source;
			txtTelescopeDriver.Text = Config.TelescopeDriver;
		}

		private void txtSource_Validated(object sender, EventArgs e)
		{
			Config.Source = txtSource.Text;
		}

		private void cmbSourceType_SelectedIndexChanged(object sender, EventArgs e)
		{

			Config.SourceType = (ImageSourceType)cmbSourceType.SelectedIndex ;
		}

		private void btRegionsClear_Click(object sender, EventArgs e)
		{
			Config.Templates.Clear();
			txtRegionsCount.Text = "0";
		}

		private void btLightOn_Click(object sender, EventArgs e)
		{
			using(var form = new EditCommand())
			{

				form.Command = Config.LightOnCommand;
				if( form.ShowDialog() == DialogResult.OK)
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
			using(var dlg = new SaveFileDialog())
			{
				dlg.Filter =  "png file (*.png)|*.png";
				dlg.FileName = "PreviewImage.png";
				if(dlg.ShowDialog() == DialogResult.OK)
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

		private void txtRaStep_TextChanged(object sender, EventArgs e)
		{
			Config.MoveRaStep = int.Parse(txtRaStep.Text);
		}

		private void txtDecStep_TextChanged(object sender, EventArgs e)
		{
			Config.MoveDecStep = int.Parse(txtDecStep.Text);
		}
	}
}
