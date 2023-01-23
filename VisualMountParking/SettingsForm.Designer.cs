namespace VisualMountParking
{
	partial class SettingsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtSource = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbSourceType = new System.Windows.Forms.ComboBox();
			this.btSave = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtRegionsCount = new System.Windows.Forms.TextBox();
			this.btRegionsClear = new System.Windows.Forms.Button();
			this.picPreview = new Accord.Controls.PictureBox();
			this.btPreview = new System.Windows.Forms.Button();
			this.btLightOff = new System.Windows.Forms.Button();
			this.btLightOn = new System.Windows.Forms.Button();
			this.btExportPreview = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTelescopeDriver = new System.Windows.Forms.TextBox();
			this.btTelescopeChoose = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.txtRaStep = new System.Windows.Forms.TextBox();
			this.txtDecStep = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
			this.SuspendLayout();
			// 
			// txtSource
			// 
			this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSource.Location = new System.Drawing.Point(90, 33);
			this.txtSource.Name = "txtSource";
			this.txtSource.Size = new System.Drawing.Size(357, 20);
			this.txtSource.TabIndex = 18;
			this.txtSource.Validated += new System.EventHandler(this.txtSource_Validated);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 18);
			this.label1.TabIndex = 19;
			this.label1.Text = "Source:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 18);
			this.label2.TabIndex = 20;
			this.label2.Text = "Source Type:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// cmbSourceType
			// 
			this.cmbSourceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSourceType.FormattingEnabled = true;
			this.cmbSourceType.Items.AddRange(new object[] {
            "File",
            "URL"});
			this.cmbSourceType.Location = new System.Drawing.Point(91, 6);
			this.cmbSourceType.Name = "cmbSourceType";
			this.cmbSourceType.Size = new System.Drawing.Size(121, 21);
			this.cmbSourceType.TabIndex = 21;
			this.cmbSourceType.SelectedIndexChanged += new System.EventHandler(this.cmbSourceType_SelectedIndexChanged);
			// 
			// btSave
			// 
			this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btSave.Location = new System.Drawing.Point(362, 420);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(85, 28);
			this.btSave.TabIndex = 22;
			this.btSave.Text = "Save";
			this.btSave.UseVisualStyleBackColor = true;
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(257, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 23;
			this.label3.Text = "Regions:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtRegionsCount
			// 
			this.txtRegionsCount.Location = new System.Drawing.Point(312, 5);
			this.txtRegionsCount.Name = "txtRegionsCount";
			this.txtRegionsCount.ReadOnly = true;
			this.txtRegionsCount.Size = new System.Drawing.Size(59, 20);
			this.txtRegionsCount.TabIndex = 24;
			// 
			// btRegionsClear
			// 
			this.btRegionsClear.Location = new System.Drawing.Point(377, 4);
			this.btRegionsClear.Name = "btRegionsClear";
			this.btRegionsClear.Size = new System.Drawing.Size(44, 21);
			this.btRegionsClear.TabIndex = 25;
			this.btRegionsClear.Text = "Clear";
			this.btRegionsClear.UseVisualStyleBackColor = true;
			this.btRegionsClear.Click += new System.EventHandler(this.btRegionsClear_Click);
			// 
			// picPreview
			// 
			this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picPreview.Image = null;
			this.picPreview.Location = new System.Drawing.Point(12, 158);
			this.picPreview.Name = "picPreview";
			this.picPreview.Size = new System.Drawing.Size(344, 290);
			this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picPreview.TabIndex = 26;
			this.picPreview.TabStop = false;
			// 
			// btPreview
			// 
			this.btPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btPreview.Location = new System.Drawing.Point(362, 247);
			this.btPreview.Name = "btPreview";
			this.btPreview.Size = new System.Drawing.Size(85, 56);
			this.btPreview.TabIndex = 27;
			this.btPreview.Text = "Load Preview";
			this.btPreview.UseVisualStyleBackColor = true;
			this.btPreview.Click += new System.EventHandler(this.btPreview_Click);
			// 
			// btLightOff
			// 
			this.btLightOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btLightOff.Location = new System.Drawing.Point(271, 116);
			this.btLightOff.Name = "btLightOff";
			this.btLightOff.Size = new System.Drawing.Size(85, 28);
			this.btLightOff.TabIndex = 28;
			this.btLightOff.Text = "Light OFF cmd";
			this.btLightOff.UseVisualStyleBackColor = true;
			this.btLightOff.Click += new System.EventHandler(this.btLightOff_Click);
			// 
			// btLightOn
			// 
			this.btLightOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btLightOn.Location = new System.Drawing.Point(271, 87);
			this.btLightOn.Name = "btLightOn";
			this.btLightOn.Size = new System.Drawing.Size(85, 28);
			this.btLightOn.TabIndex = 29;
			this.btLightOn.Text = "Light ON cmd";
			this.btLightOn.UseVisualStyleBackColor = true;
			this.btLightOn.Click += new System.EventHandler(this.btLightOn_Click);
			// 
			// btExportPreview
			// 
			this.btExportPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btExportPreview.Location = new System.Drawing.Point(362, 305);
			this.btExportPreview.Name = "btExportPreview";
			this.btExportPreview.Size = new System.Drawing.Size(85, 28);
			this.btExportPreview.TabIndex = 30;
			this.btExportPreview.Text = "Export preview";
			this.btExportPreview.UseVisualStyleBackColor = true;
			this.btExportPreview.Click += new System.EventHandler(this.btExportPreview_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(7, 60);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 18);
			this.label4.TabIndex = 32;
			this.label4.Text = "Telescope:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtTelescopeDriver
			// 
			this.txtTelescopeDriver.Location = new System.Drawing.Point(90, 60);
			this.txtTelescopeDriver.Name = "txtTelescopeDriver";
			this.txtTelescopeDriver.ReadOnly = true;
			this.txtTelescopeDriver.Size = new System.Drawing.Size(266, 20);
			this.txtTelescopeDriver.TabIndex = 31;
			// 
			// btTelescopeChoose
			// 
			this.btTelescopeChoose.Location = new System.Drawing.Point(362, 60);
			this.btTelescopeChoose.Name = "btTelescopeChoose";
			this.btTelescopeChoose.Size = new System.Drawing.Size(48, 21);
			this.btTelescopeChoose.TabIndex = 33;
			this.btTelescopeChoose.Text = "Select";
			this.btTelescopeChoose.UseVisualStyleBackColor = true;
			this.btTelescopeChoose.Click += new System.EventHandler(this.btTelescopeChoose_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(88, 95);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(54, 13);
			this.label5.TabIndex = 34;
			this.label5.Text = "R.A. step:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtRaStep
			// 
			this.txtRaStep.Location = new System.Drawing.Point(148, 92);
			this.txtRaStep.Name = "txtRaStep";
			this.txtRaStep.Size = new System.Drawing.Size(59, 20);
			this.txtRaStep.TabIndex = 35;
			this.txtRaStep.TextChanged += new System.EventHandler(this.txtRaStep_TextChanged);
			// 
			// txtDecStep
			// 
			this.txtDecStep.Location = new System.Drawing.Point(148, 121);
			this.txtDecStep.Name = "txtDecStep";
			this.txtDecStep.Size = new System.Drawing.Size(59, 20);
			this.txtDecStep.TabIndex = 37;
			this.txtDecStep.TextChanged += new System.EventHandler(this.txtDecStep_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(88, 124);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 13);
			this.label6.TabIndex = 36;
			this.label6.Text = "Dec. step:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 460);
			this.Controls.Add(this.txtDecStep);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtRaStep);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btTelescopeChoose);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtTelescopeDriver);
			this.Controls.Add(this.btExportPreview);
			this.Controls.Add(this.btLightOn);
			this.Controls.Add(this.btLightOff);
			this.Controls.Add(this.btPreview);
			this.Controls.Add(this.picPreview);
			this.Controls.Add(this.btRegionsClear);
			this.Controls.Add(this.txtRegionsCount);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btSave);
			this.Controls.Add(this.cmbSourceType);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtSource);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(450, 200);
			this.Name = "SettingsForm";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSource;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbSourceType;
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtRegionsCount;
		private System.Windows.Forms.Button btRegionsClear;
		private Accord.Controls.PictureBox picPreview;
		private System.Windows.Forms.Button btPreview;
		private System.Windows.Forms.Button btLightOff;
		private System.Windows.Forms.Button btLightOn;
		private System.Windows.Forms.Button btExportPreview;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtTelescopeDriver;
		private System.Windows.Forms.Button btTelescopeChoose;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtRaStep;
		private System.Windows.Forms.TextBox txtDecStep;
		private System.Windows.Forms.Label label6;
	}
}