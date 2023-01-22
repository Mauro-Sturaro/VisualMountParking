namespace ChekMountPosition
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
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(10, 54);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(472, 346);
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
			this.pictureBox2.Location = new System.Drawing.Point(488, 54);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(514, 346);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 7;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
			this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
			this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
			// 
			// buttonLoadImage
			// 
			this.buttonLoadImage.Location = new System.Drawing.Point(55, 12);
			this.buttonLoadImage.Name = "buttonLoadImage";
			this.buttonLoadImage.Size = new System.Drawing.Size(75, 23);
			this.buttonLoadImage.TabIndex = 16;
			this.buttonLoadImage.Text = "Load Image";
			this.buttonLoadImage.UseVisualStyleBackColor = true;
			this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
			// 
			// btSetRefImage
			// 
			this.btSetRefImage.Location = new System.Drawing.Point(136, 12);
			this.btSetRefImage.Name = "btSetRefImage";
			this.btSetRefImage.Size = new System.Drawing.Size(86, 23);
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
			this.chkImageSize.Location = new System.Drawing.Point(228, 12);
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
			this.btSettings.Location = new System.Drawing.Point(12, 12);
			this.btSettings.Name = "btSettings";
			this.btSettings.Size = new System.Drawing.Size(28, 23);
			this.btSettings.TabIndex = 26;
			this.btSettings.UseVisualStyleBackColor = true;
			this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
			// 
			// btLightON
			// 
			this.btLightON.Location = new System.Drawing.Point(333, 12);
			this.btLightON.Name = "btLightON";
			this.btLightON.Size = new System.Drawing.Size(75, 23);
			this.btLightON.TabIndex = 27;
			this.btLightON.Text = "Light ON";
			this.btLightON.UseVisualStyleBackColor = true;
			this.btLightON.Click += new System.EventHandler(this.btLightON_ClickAsync);
			// 
			// btLightOFF
			// 
			this.btLightOFF.Location = new System.Drawing.Point(414, 12);
			this.btLightOFF.Name = "btLightOFF";
			this.btLightOFF.Size = new System.Drawing.Size(75, 23);
			this.btLightOFF.TabIndex = 28;
			this.btLightOFF.Text = "Light OFF";
			this.btLightOFF.UseVisualStyleBackColor = true;
			this.btLightOFF.Click += new System.EventHandler(this.btLightOFF_Click);
			// 
			// chkShowRef
			// 
			this.chkShowRef.AutoSize = true;
			this.chkShowRef.Checked = true;
			this.chkShowRef.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkShowRef.Location = new System.Drawing.Point(228, 31);
			this.chkShowRef.Name = "chkShowRef";
			this.chkShowRef.Size = new System.Drawing.Size(102, 17);
			this.chkShowRef.TabIndex = 29;
			this.chkShowRef.Text = "Show ref. image";
			this.chkShowRef.UseVisualStyleBackColor = true;
			this.chkShowRef.CheckedChanged += new System.EventHandler(this.chkShowRef_CheckedChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1014, 410);
			this.Controls.Add(this.chkShowRef);
			this.Controls.Add(this.btLightOFF);
			this.Controls.Add(this.btLightON);
			this.Controls.Add(this.btSettings);
			this.Controls.Add(this.chkImageSize);
			this.Controls.Add(this.btSetRefImage);
			this.Controls.Add(this.buttonLoadImage);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Name = "MainForm";
			this.Text = "ChekMountPosition";
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
	}
}