namespace VisualMountParking
{
	partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.picReference = new System.Windows.Forms.PictureBox();
            this.picCurrent = new System.Windows.Forms.PictureBox();
            this.chkImageSize = new System.Windows.Forms.CheckBox();
            this.btSettings = new System.Windows.Forms.Button();
            this.btLightON = new System.Windows.Forms.Button();
            this.btLightOFF = new System.Windows.Forms.Button();
            this.chkShowRef = new System.Windows.Forms.CheckBox();
            this.btRaLow2 = new System.Windows.Forms.Button();
            this.btDecLow2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btDecLow = new System.Windows.Forms.Button();
            this.btRaLow = new System.Windows.Forms.Button();
            this.btDecHigh = new System.Windows.Forms.Button();
            this.btRaHigh = new System.Windows.Forms.Button();
            this.btDecHigh2 = new System.Windows.Forms.Button();
            this.btRaHigh2 = new System.Windows.Forms.Button();
            this.btConnect = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.chkFreezeImage = new System.Windows.Forms.CheckBox();
            this.timerImage = new System.Windows.Forms.Timer(this.components);
            this.btPark = new System.Windows.Forms.Button();
            this.timerMountStat = new System.Windows.Forms.Timer(this.components);
            this.btAutoPark = new System.Windows.Forms.Button();
            this.tbLum = new System.Windows.Forms.TrackBar();
            this.tbContrast = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.btPrintCalibration = new System.Windows.Forms.Button();
            this.btCalibration = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picReference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            this.SuspendLayout();
            // 
            // picReference
            // 
            this.picReference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picReference.Location = new System.Drawing.Point(294, 60);
            this.picReference.Name = "picReference";
            this.picReference.Size = new System.Drawing.Size(311, 415);
            this.picReference.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picReference.TabIndex = 6;
            this.picReference.TabStop = false;
            this.picReference.Paint += new System.Windows.Forms.PaintEventHandler(this.picReference_Paint);
            // 
            // picCurrent
            // 
            this.picCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCurrent.Location = new System.Drawing.Point(10, 60);
            this.picCurrent.Name = "picCurrent";
            this.picCurrent.Size = new System.Drawing.Size(278, 415);
            this.picCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCurrent.TabIndex = 7;
            this.picCurrent.TabStop = false;
            this.picCurrent.Paint += new System.Windows.Forms.PaintEventHandler(this.picCurrent_Paint);
            this.picCurrent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCurrent_MouseDown);
            this.picCurrent.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCurrent_MouseUp);
            // 
            // chkImageSize
            // 
            this.chkImageSize.AutoSize = true;
            this.chkImageSize.Checked = true;
            this.chkImageSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImageSize.Location = new System.Drawing.Point(146, 5);
            this.chkImageSize.Name = "chkImageSize";
            this.chkImageSize.Size = new System.Drawing.Size(88, 17);
            this.chkImageSize.TabIndex = 25;
            this.chkImageSize.Text = "Zoom/Shrink";
            this.chkImageSize.UseVisualStyleBackColor = true;
            this.chkImageSize.CheckedChanged += new System.EventHandler(this.chkImageSize_CheckedChanged);
            // 
            // btSettings
            // 
            this.btSettings.Image = ((System.Drawing.Image)(resources.GetObject("btSettings.Image")));
            this.btSettings.Location = new System.Drawing.Point(12, 14);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(39, 34);
            this.btSettings.TabIndex = 26;
            this.btSettings.UseVisualStyleBackColor = true;
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
            // 
            // btLightON
            // 
            this.btLightON.Location = new System.Drawing.Point(250, 4);
            this.btLightON.Name = "btLightON";
            this.btLightON.Size = new System.Drawing.Size(62, 23);
            this.btLightON.TabIndex = 27;
            this.btLightON.Text = "Light ON";
            this.btLightON.UseVisualStyleBackColor = true;
            this.btLightON.Click += new System.EventHandler(this.btLightON_ClickAsync);
            // 
            // btLightOFF
            // 
            this.btLightOFF.Location = new System.Drawing.Point(250, 30);
            this.btLightOFF.Name = "btLightOFF";
            this.btLightOFF.Size = new System.Drawing.Size(62, 23);
            this.btLightOFF.TabIndex = 28;
            this.btLightOFF.Text = "Light OFF";
            this.btLightOFF.UseVisualStyleBackColor = true;
            this.btLightOFF.Click += new System.EventHandler(this.btLightOFF_Click);
            // 
            // chkShowRef
            // 
            this.chkShowRef.AutoSize = true;
            this.chkShowRef.Location = new System.Drawing.Point(146, 22);
            this.chkShowRef.Name = "chkShowRef";
            this.chkShowRef.Size = new System.Drawing.Size(102, 17);
            this.chkShowRef.TabIndex = 29;
            this.chkShowRef.Text = "Show ref. image";
            this.chkShowRef.UseVisualStyleBackColor = true;
            this.chkShowRef.CheckedChanged += new System.EventHandler(this.chkShowRef_CheckedChanged);
            // 
            // btRaLow2
            // 
            this.btRaLow2.Location = new System.Drawing.Point(441, 4);
            this.btRaLow2.Name = "btRaLow2";
            this.btRaLow2.Size = new System.Drawing.Size(29, 23);
            this.btRaLow2.TabIndex = 30;
            this.btRaLow2.Text = "<<";
            this.btRaLow2.UseVisualStyleBackColor = true;
            this.btRaLow2.Click += new System.EventHandler(this.btRaLow2_Click);
            // 
            // btDecLow2
            // 
            this.btDecLow2.Location = new System.Drawing.Point(441, 30);
            this.btDecLow2.Name = "btDecLow2";
            this.btDecLow2.Size = new System.Drawing.Size(29, 23);
            this.btDecLow2.TabIndex = 31;
            this.btDecLow2.Text = "<<";
            this.btDecLow2.UseVisualStyleBackColor = true;
            this.btDecLow2.Click += new System.EventHandler(this.btDecLow2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(401, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "R.A. :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Dec. :";
            // 
            // btDecLow
            // 
            this.btDecLow.Location = new System.Drawing.Point(476, 30);
            this.btDecLow.Name = "btDecLow";
            this.btDecLow.Size = new System.Drawing.Size(29, 23);
            this.btDecLow.TabIndex = 35;
            this.btDecLow.Text = "<";
            this.btDecLow.UseVisualStyleBackColor = true;
            this.btDecLow.Click += new System.EventHandler(this.btDecLow_Click);
            // 
            // btRaLow
            // 
            this.btRaLow.Location = new System.Drawing.Point(476, 4);
            this.btRaLow.Name = "btRaLow";
            this.btRaLow.Size = new System.Drawing.Size(29, 23);
            this.btRaLow.TabIndex = 34;
            this.btRaLow.Text = "<";
            this.btRaLow.UseVisualStyleBackColor = true;
            this.btRaLow.Click += new System.EventHandler(this.btRaLow_Click);
            // 
            // btDecHigh
            // 
            this.btDecHigh.Location = new System.Drawing.Point(504, 30);
            this.btDecHigh.Name = "btDecHigh";
            this.btDecHigh.Size = new System.Drawing.Size(29, 23);
            this.btDecHigh.TabIndex = 37;
            this.btDecHigh.Text = ">";
            this.btDecHigh.UseVisualStyleBackColor = true;
            this.btDecHigh.Click += new System.EventHandler(this.btDecHigh_Click);
            // 
            // btRaHigh
            // 
            this.btRaHigh.Location = new System.Drawing.Point(504, 4);
            this.btRaHigh.Name = "btRaHigh";
            this.btRaHigh.Size = new System.Drawing.Size(29, 23);
            this.btRaHigh.TabIndex = 36;
            this.btRaHigh.Text = ">";
            this.btRaHigh.UseVisualStyleBackColor = true;
            this.btRaHigh.Click += new System.EventHandler(this.btRaHigh_Click);
            // 
            // btDecHigh2
            // 
            this.btDecHigh2.Location = new System.Drawing.Point(539, 30);
            this.btDecHigh2.Name = "btDecHigh2";
            this.btDecHigh2.Size = new System.Drawing.Size(29, 23);
            this.btDecHigh2.TabIndex = 39;
            this.btDecHigh2.Text = ">>";
            this.btDecHigh2.UseVisualStyleBackColor = true;
            this.btDecHigh2.Click += new System.EventHandler(this.btDecHigh2_Click);
            // 
            // btRaHigh2
            // 
            this.btRaHigh2.Location = new System.Drawing.Point(539, 4);
            this.btRaHigh2.Name = "btRaHigh2";
            this.btRaHigh2.Size = new System.Drawing.Size(29, 23);
            this.btRaHigh2.TabIndex = 38;
            this.btRaHigh2.Text = ">>";
            this.btRaHigh2.UseVisualStyleBackColor = true;
            this.btRaHigh2.Click += new System.EventHandler(this.btRaHigh2_Click);
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(324, 4);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(71, 23);
            this.btConnect.TabIndex = 40;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.Tomato;
            this.btCancel.Location = new System.Drawing.Point(441, 4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(171, 49);
            this.btCancel.TabIndex = 41;
            this.btCancel.Text = "CANCEL";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Visible = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // chkFreezeImage
            // 
            this.chkFreezeImage.AutoSize = true;
            this.chkFreezeImage.Location = new System.Drawing.Point(146, 40);
            this.chkFreezeImage.Name = "chkFreezeImage";
            this.chkFreezeImage.Size = new System.Drawing.Size(89, 17);
            this.chkFreezeImage.TabIndex = 42;
            this.chkFreezeImage.Text = "Freeze image";
            this.chkFreezeImage.UseVisualStyleBackColor = true;
            this.chkFreezeImage.CheckedChanged += new System.EventHandler(this.chkFreezeImage_CheckedChanged);
            // 
            // timerImage
            // 
            this.timerImage.Interval = 250;
            this.timerImage.Tick += new System.EventHandler(this.timerImage_Tick);
            // 
            // btPark
            // 
            this.btPark.Location = new System.Drawing.Point(324, 31);
            this.btPark.Name = "btPark";
            this.btPark.Size = new System.Drawing.Size(71, 23);
            this.btPark.TabIndex = 43;
            this.btPark.Text = "Park";
            this.btPark.UseVisualStyleBackColor = true;
            this.btPark.Click += new System.EventHandler(this.btPark_Click);
            // 
            // timerMountStat
            // 
            this.timerMountStat.Enabled = true;
            this.timerMountStat.Interval = 500;
            this.timerMountStat.Tick += new System.EventHandler(this.timerMountStat_Tick);
            // 
            // btAutoPark
            // 
            this.btAutoPark.Location = new System.Drawing.Point(574, 4);
            this.btAutoPark.Name = "btAutoPark";
            this.btAutoPark.Size = new System.Drawing.Size(38, 49);
            this.btAutoPark.TabIndex = 44;
            this.btAutoPark.Text = "Auto Park";
            this.btAutoPark.UseVisualStyleBackColor = true;
            this.btAutoPark.Click += new System.EventHandler(this.btAutoPark_Click);
            // 
            // tbLum
            // 
            this.tbLum.LargeChange = 10;
            this.tbLum.Location = new System.Drawing.Point(62, 4);
            this.tbLum.Maximum = 100;
            this.tbLum.Name = "tbLum";
            this.tbLum.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbLum.Size = new System.Drawing.Size(45, 53);
            this.tbLum.TabIndex = 45;
            this.tbLum.TickFrequency = 25;
            this.tbLum.Value = 50;
            this.tbLum.ValueChanged += new System.EventHandler(this.tbLum_ValueChanged);
            // 
            // tbContrast
            // 
            this.tbContrast.LargeChange = 10;
            this.tbContrast.Location = new System.Drawing.Point(105, 4);
            this.tbContrast.Maximum = 100;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbContrast.Size = new System.Drawing.Size(45, 53);
            this.tbContrast.TabIndex = 46;
            this.tbContrast.TickFrequency = 25;
            this.tbContrast.Value = 50;
            this.tbContrast.ValueChanged += new System.EventHandler(this.tbContrast_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btPrintCalibration
            // 
            this.btPrintCalibration.Location = new System.Drawing.Point(12, 92);
            this.btPrintCalibration.Name = "btPrintCalibration";
            this.btPrintCalibration.Size = new System.Drawing.Size(95, 23);
            this.btPrintCalibration.TabIndex = 48;
            this.btPrintCalibration.Text = "Print Calibration";
            this.btPrintCalibration.UseVisualStyleBackColor = true;
            this.btPrintCalibration.Click += new System.EventHandler(this.btPrintCalibration_Click);
            // 
            // btCalibration
            // 
            this.btCalibration.Location = new System.Drawing.Point(12, 121);
            this.btCalibration.Name = "btCalibration";
            this.btCalibration.Size = new System.Drawing.Size(95, 23);
            this.btCalibration.TabIndex = 49;
            this.btCalibration.Text = "Calibration";
            this.btCalibration.UseVisualStyleBackColor = true;
            this.btCalibration.Click += new System.EventHandler(this.btCalibration_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 521);
            this.Controls.Add(this.btCalibration);
            this.Controls.Add(this.btPrintCalibration);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btAutoPark);
            this.Controls.Add(this.btPark);
            this.Controls.Add(this.chkFreezeImage);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.btDecHigh2);
            this.Controls.Add(this.btRaHigh2);
            this.Controls.Add(this.btDecHigh);
            this.Controls.Add(this.btRaHigh);
            this.Controls.Add(this.btDecLow);
            this.Controls.Add(this.btRaLow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btDecLow2);
            this.Controls.Add(this.btRaLow2);
            this.Controls.Add(this.chkShowRef);
            this.Controls.Add(this.btLightOFF);
            this.Controls.Add(this.btLightON);
            this.Controls.Add(this.btSettings);
            this.Controls.Add(this.chkImageSize);
            this.Controls.Add(this.picCurrent);
            this.Controls.Add(this.picReference);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.tbLum);
            this.Controls.Add(this.tbContrast);
            this.Name = "MainForm";
            this.Text = "Telescope Visual Parking";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picReference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picReference;
		private System.Windows.Forms.PictureBox picCurrent;
		private System.Windows.Forms.CheckBox chkImageSize;
		private System.Windows.Forms.Button btSettings;
		private System.Windows.Forms.Button btLightON;
		private System.Windows.Forms.Button btLightOFF;
		private System.Windows.Forms.CheckBox chkShowRef;
		private System.Windows.Forms.Button btRaLow2;
		private System.Windows.Forms.Button btDecLow2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btDecLow;
		private System.Windows.Forms.Button btRaLow;
		private System.Windows.Forms.Button btDecHigh;
		private System.Windows.Forms.Button btRaHigh;
		private System.Windows.Forms.Button btDecHigh2;
		private System.Windows.Forms.Button btRaHigh2;
		private System.Windows.Forms.Button btConnect;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.CheckBox chkFreezeImage;
		private System.Windows.Forms.Timer timerImage;
		private System.Windows.Forms.Button btPark;
		private System.Windows.Forms.Timer timerMountStat;
		private System.Windows.Forms.Button btAutoPark;
		private System.Windows.Forms.TrackBar tbLum;
		private System.Windows.Forms.TrackBar tbContrast;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btPrintCalibration;
        private System.Windows.Forms.Button btCalibration;
    }
}