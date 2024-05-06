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
            this.picCurrent = new System.Windows.Forms.PictureBox();
            this.chkImageSize = new System.Windows.Forms.CheckBox();
            this.btSettings = new System.Windows.Forms.Button();
            this.btLightON = new System.Windows.Forms.Button();
            this.btLightOFF = new System.Windows.Forms.Button();
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
            this.btSTOP = new System.Windows.Forms.Button();
            this.chkFreezeImage = new System.Windows.Forms.CheckBox();
            this.timerImage = new System.Windows.Forms.Timer(this.components);
            this.btPark = new System.Windows.Forms.Button();
            this.timerMountStat = new System.Windows.Forms.Timer(this.components);
            this.btAutoPark = new System.Windows.Forms.Button();
            this.tbLum = new System.Windows.Forms.TrackBar();
            this.tbContrast = new System.Windows.Forms.TrackBar();
            this.cmbImageToShow = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbReferenceImage = new System.Windows.Forms.ComboBox();
            this.pnlImageBorder = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlImageBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCurrent
            // 
            this.picCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCurrent.Location = new System.Drawing.Point(10, 10);
            this.picCurrent.Name = "picCurrent";
            this.picCurrent.Size = new System.Drawing.Size(530, 370);
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
            this.chkImageSize.Location = new System.Drawing.Point(6, 19);
            this.chkImageSize.Name = "chkImageSize";
            this.chkImageSize.Size = new System.Drawing.Size(66, 17);
            this.chkImageSize.TabIndex = 0;
            this.chkImageSize.Text = "Autosize";
            this.chkImageSize.UseVisualStyleBackColor = true;
            this.chkImageSize.CheckedChanged += new System.EventHandler(this.chkImageSize_CheckedChanged);
            // 
            // btSettings
            // 
            this.btSettings.Image = ((System.Drawing.Image)(resources.GetObject("btSettings.Image")));
            this.btSettings.Location = new System.Drawing.Point(10, 275);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(83, 27);
            this.btSettings.TabIndex = 4;
            this.btSettings.Text = "Settings";
            this.btSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSettings.UseVisualStyleBackColor = true;
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
            // 
            // btLightON
            // 
            this.btLightON.Location = new System.Drawing.Point(12, 129);
            this.btLightON.Name = "btLightON";
            this.btLightON.Size = new System.Drawing.Size(62, 23);
            this.btLightON.TabIndex = 2;
            this.btLightON.Text = "Light ON";
            this.btLightON.UseVisualStyleBackColor = true;
            this.btLightON.Click += new System.EventHandler(this.btLightON_ClickAsync);
            // 
            // btLightOFF
            // 
            this.btLightOFF.Location = new System.Drawing.Point(12, 158);
            this.btLightOFF.Name = "btLightOFF";
            this.btLightOFF.Size = new System.Drawing.Size(62, 23);
            this.btLightOFF.TabIndex = 3;
            this.btLightOFF.Text = "Light OFF";
            this.btLightOFF.UseVisualStyleBackColor = true;
            this.btLightOFF.Click += new System.EventHandler(this.btLightOFF_Click);
            // 
            // btRaLow2
            // 
            this.btRaLow2.Location = new System.Drawing.Point(357, 8);
            this.btRaLow2.Name = "btRaLow2";
            this.btRaLow2.Size = new System.Drawing.Size(29, 23);
            this.btRaLow2.TabIndex = 7;
            this.btRaLow2.Text = "<<";
            this.btRaLow2.UseVisualStyleBackColor = true;
            this.btRaLow2.Click += new System.EventHandler(this.btRaLow2_Click);
            // 
            // btDecLow2
            // 
            this.btDecLow2.Location = new System.Drawing.Point(357, 34);
            this.btDecLow2.Name = "btDecLow2";
            this.btDecLow2.Size = new System.Drawing.Size(29, 23);
            this.btDecLow2.TabIndex = 11;
            this.btDecLow2.Text = "<<";
            this.btDecLow2.UseVisualStyleBackColor = true;
            this.btDecLow2.Click += new System.EventHandler(this.btDecLow2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "R.A. :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Dec. :";
            // 
            // btDecLow
            // 
            this.btDecLow.Location = new System.Drawing.Point(392, 34);
            this.btDecLow.Name = "btDecLow";
            this.btDecLow.Size = new System.Drawing.Size(29, 23);
            this.btDecLow.TabIndex = 12;
            this.btDecLow.Text = "<";
            this.btDecLow.UseVisualStyleBackColor = true;
            this.btDecLow.Click += new System.EventHandler(this.btDecLow_Click);
            // 
            // btRaLow
            // 
            this.btRaLow.Location = new System.Drawing.Point(392, 8);
            this.btRaLow.Name = "btRaLow";
            this.btRaLow.Size = new System.Drawing.Size(29, 23);
            this.btRaLow.TabIndex = 8;
            this.btRaLow.Text = "<";
            this.btRaLow.UseVisualStyleBackColor = true;
            this.btRaLow.Click += new System.EventHandler(this.btRaLow_Click);
            // 
            // btDecHigh
            // 
            this.btDecHigh.Location = new System.Drawing.Point(420, 34);
            this.btDecHigh.Name = "btDecHigh";
            this.btDecHigh.Size = new System.Drawing.Size(29, 23);
            this.btDecHigh.TabIndex = 13;
            this.btDecHigh.Text = ">";
            this.btDecHigh.UseVisualStyleBackColor = true;
            this.btDecHigh.Click += new System.EventHandler(this.btDecHigh_Click);
            // 
            // btRaHigh
            // 
            this.btRaHigh.Location = new System.Drawing.Point(420, 8);
            this.btRaHigh.Name = "btRaHigh";
            this.btRaHigh.Size = new System.Drawing.Size(29, 23);
            this.btRaHigh.TabIndex = 9;
            this.btRaHigh.Text = ">";
            this.btRaHigh.UseVisualStyleBackColor = true;
            this.btRaHigh.Click += new System.EventHandler(this.btRaHigh_Click);
            // 
            // btDecHigh2
            // 
            this.btDecHigh2.Location = new System.Drawing.Point(455, 34);
            this.btDecHigh2.Name = "btDecHigh2";
            this.btDecHigh2.Size = new System.Drawing.Size(29, 23);
            this.btDecHigh2.TabIndex = 14;
            this.btDecHigh2.Text = ">>";
            this.btDecHigh2.UseVisualStyleBackColor = true;
            this.btDecHigh2.Click += new System.EventHandler(this.btDecHigh2_Click);
            // 
            // btRaHigh2
            // 
            this.btRaHigh2.Location = new System.Drawing.Point(455, 8);
            this.btRaHigh2.Name = "btRaHigh2";
            this.btRaHigh2.Size = new System.Drawing.Size(29, 23);
            this.btRaHigh2.TabIndex = 10;
            this.btRaHigh2.Text = ">>";
            this.btRaHigh2.UseVisualStyleBackColor = true;
            this.btRaHigh2.Click += new System.EventHandler(this.btRaHigh2_Click);
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(13, 63);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(71, 23);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // btSTOP
            // 
            this.btSTOP.Location = new System.Drawing.Point(568, 8);
            this.btSTOP.Name = "btSTOP";
            this.btSTOP.Size = new System.Drawing.Size(73, 50);
            this.btSTOP.TabIndex = 16;
            this.btSTOP.Text = "STOP";
            this.btSTOP.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // chkFreezeImage
            // 
            this.chkFreezeImage.AutoSize = true;
            this.chkFreezeImage.Location = new System.Drawing.Point(6, 45);
            this.chkFreezeImage.Name = "chkFreezeImage";
            this.chkFreezeImage.Size = new System.Drawing.Size(58, 17);
            this.chkFreezeImage.TabIndex = 1;
            this.chkFreezeImage.Text = "Freeze";
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
            this.btPark.Location = new System.Drawing.Point(13, 92);
            this.btPark.Name = "btPark";
            this.btPark.Size = new System.Drawing.Size(71, 23);
            this.btPark.TabIndex = 1;
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
            this.btAutoPark.Location = new System.Drawing.Point(490, 8);
            this.btAutoPark.Name = "btAutoPark";
            this.btAutoPark.Size = new System.Drawing.Size(72, 49);
            this.btAutoPark.TabIndex = 15;
            this.btAutoPark.Text = "Slave to Reference";
            this.btAutoPark.UseVisualStyleBackColor = true;
            this.btAutoPark.Click += new System.EventHandler(this.btAutoPark_Click);
            // 
            // tbLum
            // 
            this.tbLum.LargeChange = 10;
            this.tbLum.Location = new System.Drawing.Point(15, 8);
            this.tbLum.Maximum = 100;
            this.tbLum.Name = "tbLum";
            this.tbLum.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbLum.Size = new System.Drawing.Size(45, 53);
            this.tbLum.TabIndex = 17;
            this.tbLum.TickFrequency = 25;
            this.tbLum.Value = 50;
            this.tbLum.ValueChanged += new System.EventHandler(this.tbLum_ValueChanged);
            // 
            // tbContrast
            // 
            this.tbContrast.LargeChange = 10;
            this.tbContrast.Location = new System.Drawing.Point(58, 8);
            this.tbContrast.Maximum = 100;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbContrast.Size = new System.Drawing.Size(45, 53);
            this.tbContrast.TabIndex = 18;
            this.tbContrast.TickFrequency = 25;
            this.tbContrast.Value = 50;
            this.tbContrast.ValueChanged += new System.EventHandler(this.tbContrast_ValueChanged);
            // 
            // cmbImageToShow
            // 
            this.cmbImageToShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageToShow.FormattingEnabled = true;
            this.cmbImageToShow.Items.AddRange(new object[] {
            "Live tracking",
            "Live all markers",
            "Reference1",
            "Reference2"});
            this.cmbImageToShow.Location = new System.Drawing.Point(167, 12);
            this.cmbImageToShow.Name = "cmbImageToShow";
            this.cmbImageToShow.Size = new System.Drawing.Size(133, 21);
            this.cmbImageToShow.TabIndex = 5;
            this.cmbImageToShow.SelectedIndexChanged += new System.EventHandler(this.cmbImageToShow_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkImageSize);
            this.groupBox1.Controls.Add(this.chkFreezeImage);
            this.groupBox1.Location = new System.Drawing.Point(12, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(81, 71);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Show:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Reference:";
            // 
            // cmbReferenceImage
            // 
            this.cmbReferenceImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReferenceImage.FormattingEnabled = true;
            this.cmbReferenceImage.Items.AddRange(new object[] {
            "Reference1",
            "Reference2"});
            this.cmbReferenceImage.Location = new System.Drawing.Point(167, 40);
            this.cmbReferenceImage.Name = "cmbReferenceImage";
            this.cmbReferenceImage.Size = new System.Drawing.Size(133, 21);
            this.cmbReferenceImage.TabIndex = 6;
            this.cmbReferenceImage.SelectedIndexChanged += new System.EventHandler(this.cmbReferenceImage_SelectedIndexChanged);
            // 
            // pnlImageBorder
            // 
            this.pnlImageBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlImageBorder.Controls.Add(this.picCurrent);
            this.pnlImageBorder.Location = new System.Drawing.Point(99, 67);
            this.pnlImageBorder.Name = "pnlImageBorder";
            this.pnlImageBorder.Size = new System.Drawing.Size(550, 390);
            this.pnlImageBorder.TabIndex = 55;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 459);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbReferenceImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbImageToShow);
            this.Controls.Add(this.btAutoPark);
            this.Controls.Add(this.btPark);
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
            this.Controls.Add(this.btLightOFF);
            this.Controls.Add(this.btLightON);
            this.Controls.Add(this.btSettings);
            this.Controls.Add(this.btSTOP);
            this.Controls.Add(this.tbLum);
            this.Controls.Add(this.tbContrast);
            this.Controls.Add(this.pnlImageBorder);
            this.Name = "MainForm";
            this.Text = "Telescope Visual Parking";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlImageBorder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.PictureBox picCurrent;
		private System.Windows.Forms.CheckBox chkImageSize;
		private System.Windows.Forms.Button btSettings;
		private System.Windows.Forms.Button btLightON;
		private System.Windows.Forms.Button btLightOFF;
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
		private System.Windows.Forms.Button btSTOP;
		private System.Windows.Forms.CheckBox chkFreezeImage;
		private System.Windows.Forms.Timer timerImage;
		private System.Windows.Forms.Button btPark;
		private System.Windows.Forms.Timer timerMountStat;
		private System.Windows.Forms.Button btAutoPark;
		private System.Windows.Forms.TrackBar tbLum;
		private System.Windows.Forms.TrackBar tbContrast;
        private System.Windows.Forms.ComboBox cmbImageToShow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbReferenceImage;
        private System.Windows.Forms.Panel pnlImageBorder;
    }
}