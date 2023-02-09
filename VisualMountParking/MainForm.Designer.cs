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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.buttonLoadImage = new System.Windows.Forms.Button();
			this.btSetRefImage = new System.Windows.Forms.Button();
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
			this.chkUpdateImage = new System.Windows.Forms.CheckBox();
			this.timerImage = new System.Windows.Forms.Timer(this.components);
			this.btPark = new System.Windows.Forms.Button();
			this.timerMountStat = new System.Windows.Forms.Timer(this.components);
			this.btAutoPark = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(10, 60);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(595, 415);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox2.Location = new System.Drawing.Point(516, 389);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(98, 120);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 7;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
			this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
			this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
			// 
			// buttonLoadImage
			// 
			this.buttonLoadImage.Location = new System.Drawing.Point(55, 4);
			this.buttonLoadImage.Name = "buttonLoadImage";
			this.buttonLoadImage.Size = new System.Drawing.Size(79, 23);
			this.buttonLoadImage.TabIndex = 16;
			this.buttonLoadImage.Text = "Load Image";
			this.buttonLoadImage.UseVisualStyleBackColor = true;
			this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
			// 
			// btSetRefImage
			// 
			this.btSetRefImage.Location = new System.Drawing.Point(55, 31);
			this.btSetRefImage.Name = "btSetRefImage";
			this.btSetRefImage.Size = new System.Drawing.Size(79, 23);
			this.btSetRefImage.TabIndex = 21;
			this.btSetRefImage.Text = "Set ref Image";
			this.btSetRefImage.UseVisualStyleBackColor = true;
			this.btSetRefImage.Click += new System.EventHandler(this.btSetRefImage_Click);
			// 
			// chkImageSize
			// 
			this.chkImageSize.AutoSize = true;
			this.chkImageSize.Checked = true;
			this.chkImageSize.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkImageSize.Location = new System.Drawing.Point(148, 5);
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
			this.btSettings.Location = new System.Drawing.Point(10, 5);
			this.btSettings.Name = "btSettings";
			this.btSettings.Size = new System.Drawing.Size(27, 34);
			this.btSettings.TabIndex = 26;
			this.btSettings.UseVisualStyleBackColor = true;
			this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
			// 
			// btLightON
			// 
			this.btLightON.Location = new System.Drawing.Point(252, 4);
			this.btLightON.Name = "btLightON";
			this.btLightON.Size = new System.Drawing.Size(62, 23);
			this.btLightON.TabIndex = 27;
			this.btLightON.Text = "Light ON";
			this.btLightON.UseVisualStyleBackColor = true;
			this.btLightON.Click += new System.EventHandler(this.btLightON_ClickAsync);
			// 
			// btLightOFF
			// 
			this.btLightOFF.Location = new System.Drawing.Point(252, 30);
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
			this.chkShowRef.Location = new System.Drawing.Point(148, 22);
			this.chkShowRef.Name = "chkShowRef";
			this.chkShowRef.Size = new System.Drawing.Size(102, 17);
			this.chkShowRef.TabIndex = 29;
			this.chkShowRef.Text = "Show ref. image";
			this.chkShowRef.UseVisualStyleBackColor = true;
			this.chkShowRef.CheckedChanged += new System.EventHandler(this.chkShowRef_CheckedChanged);
			// 
			// btRaLow2
			// 
			this.btRaLow2.Location = new System.Drawing.Point(443, 4);
			this.btRaLow2.Name = "btRaLow2";
			this.btRaLow2.Size = new System.Drawing.Size(29, 23);
			this.btRaLow2.TabIndex = 30;
			this.btRaLow2.Text = "<<";
			this.btRaLow2.UseVisualStyleBackColor = true;
			this.btRaLow2.Click += new System.EventHandler(this.btRaLow2_Click);
			// 
			// btDecLow2
			// 
			this.btDecLow2.Location = new System.Drawing.Point(443, 30);
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
			this.label1.Location = new System.Drawing.Point(403, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 32;
			this.label1.Text = "R.A. :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(401, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 33;
			this.label2.Text = "Dec. :";
			// 
			// btDecLow
			// 
			this.btDecLow.Location = new System.Drawing.Point(478, 30);
			this.btDecLow.Name = "btDecLow";
			this.btDecLow.Size = new System.Drawing.Size(29, 23);
			this.btDecLow.TabIndex = 35;
			this.btDecLow.Text = "<";
			this.btDecLow.UseVisualStyleBackColor = true;
			this.btDecLow.Click += new System.EventHandler(this.btDecLow_Click);
			// 
			// btRaLow
			// 
			this.btRaLow.Location = new System.Drawing.Point(478, 4);
			this.btRaLow.Name = "btRaLow";
			this.btRaLow.Size = new System.Drawing.Size(29, 23);
			this.btRaLow.TabIndex = 34;
			this.btRaLow.Text = "<";
			this.btRaLow.UseVisualStyleBackColor = true;
			this.btRaLow.Click += new System.EventHandler(this.btRaLow_Click);
			// 
			// btDecHigh
			// 
			this.btDecHigh.Location = new System.Drawing.Point(506, 30);
			this.btDecHigh.Name = "btDecHigh";
			this.btDecHigh.Size = new System.Drawing.Size(29, 23);
			this.btDecHigh.TabIndex = 37;
			this.btDecHigh.Text = ">";
			this.btDecHigh.UseVisualStyleBackColor = true;
			this.btDecHigh.Click += new System.EventHandler(this.btDecHigh_Click);
			// 
			// btRaHigh
			// 
			this.btRaHigh.Location = new System.Drawing.Point(506, 4);
			this.btRaHigh.Name = "btRaHigh";
			this.btRaHigh.Size = new System.Drawing.Size(29, 23);
			this.btRaHigh.TabIndex = 36;
			this.btRaHigh.Text = ">";
			this.btRaHigh.UseVisualStyleBackColor = true;
			this.btRaHigh.Click += new System.EventHandler(this.btRaHigh_Click);
			// 
			// btDecHigh2
			// 
			this.btDecHigh2.Location = new System.Drawing.Point(541, 30);
			this.btDecHigh2.Name = "btDecHigh2";
			this.btDecHigh2.Size = new System.Drawing.Size(29, 23);
			this.btDecHigh2.TabIndex = 39;
			this.btDecHigh2.Text = ">>";
			this.btDecHigh2.UseVisualStyleBackColor = true;
			this.btDecHigh2.Click += new System.EventHandler(this.btDecHigh2_Click);
			// 
			// btRaHigh2
			// 
			this.btRaHigh2.Location = new System.Drawing.Point(541, 4);
			this.btRaHigh2.Name = "btRaHigh2";
			this.btRaHigh2.Size = new System.Drawing.Size(29, 23);
			this.btRaHigh2.TabIndex = 38;
			this.btRaHigh2.Text = ">>";
			this.btRaHigh2.UseVisualStyleBackColor = true;
			this.btRaHigh2.Click += new System.EventHandler(this.btRaHigh2_Click);
			// 
			// btConnect
			// 
			this.btConnect.Location = new System.Drawing.Point(326, 4);
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
			this.btCancel.Location = new System.Drawing.Point(443, 4);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(171, 49);
			this.btCancel.TabIndex = 41;
			this.btCancel.Text = "CANCEL";
			this.btCancel.UseVisualStyleBackColor = false;
			this.btCancel.Visible = false;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// chkUpdateImage
			// 
			this.chkUpdateImage.AutoSize = true;
			this.chkUpdateImage.Location = new System.Drawing.Point(148, 40);
			this.chkUpdateImage.Name = "chkUpdateImage";
			this.chkUpdateImage.Size = new System.Drawing.Size(92, 17);
			this.chkUpdateImage.TabIndex = 42;
			this.chkUpdateImage.Text = "Update image";
			this.chkUpdateImage.UseVisualStyleBackColor = true;
			this.chkUpdateImage.CheckedChanged += new System.EventHandler(this.chkUpdateImage_CheckedChanged);
			// 
			// timerImage
			// 
			this.timerImage.Interval = 250;
			this.timerImage.Tick += new System.EventHandler(this.timerImage_Tick);
			// 
			// btPark
			// 
			this.btPark.Location = new System.Drawing.Point(326, 31);
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
			this.btAutoPark.Location = new System.Drawing.Point(576, 4);
			this.btAutoPark.Name = "btAutoPark";
			this.btAutoPark.Size = new System.Drawing.Size(38, 49);
			this.btAutoPark.TabIndex = 44;
			this.btAutoPark.Text = "Auto Park";
			this.btAutoPark.UseVisualStyleBackColor = true;
			this.btAutoPark.Click += new System.EventHandler(this.btAutoPark_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(622, 521);
			this.Controls.Add(this.btAutoPark);
			this.Controls.Add(this.btPark);
			this.Controls.Add(this.chkUpdateImage);
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
			this.Controls.Add(this.btSetRefImage);
			this.Controls.Add(this.buttonLoadImage);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btCancel);
			this.Name = "MainForm";
			this.Text = "ChekMountPosition";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Button buttonLoadImage;
		private System.Windows.Forms.Button btSetRefImage;
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
		private System.Windows.Forms.CheckBox chkUpdateImage;
		private System.Windows.Forms.Timer timerImage;
		private System.Windows.Forms.Button btPark;
		private System.Windows.Forms.Timer timerMountStat;
		private System.Windows.Forms.Button btAutoPark;
	}
}