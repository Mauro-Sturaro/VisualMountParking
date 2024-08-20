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
            this.btSave = new System.Windows.Forms.Button();
            this.btLightOff = new System.Windows.Forms.Button();
            this.btLightOn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTelescopeDriver = new System.Windows.Forms.TextBox();
            this.btTelescopeChoose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numFastSpeed = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numFastTime = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numDecTime = new System.Windows.Forms.NumericUpDown();
            this.numRaTime = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numDecRate = new System.Windows.Forms.NumericUpDown();
            this.numRaRrate = new System.Windows.Forms.NumericUpDown();
            this.tabDome = new System.Windows.Forms.TabControl();
            this.tabPageImage = new System.Windows.Forms.TabPage();
            this.lbl_ImgSize = new System.Windows.Forms.Label();
            this.btSetAsReference2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btSetAsReference1 = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSourceType = new System.Windows.Forms.ComboBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btPreview = new System.Windows.Forms.Button();
            this.tabPageZone = new System.Windows.Forms.TabPage();
            this.btSaveMarkers = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numPositionTolerance = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chkReverseDec = new System.Windows.Forms.CheckBox();
            this.numMarkerIdAr = new System.Windows.Forms.NumericUpDown();
            this.chkReverseAR = new System.Windows.Forms.CheckBox();
            this.numMarkerIdDec = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPageTelescope = new System.Windows.Forms.TabPage();
            this.txtAllowedRates = new System.Windows.Forms.TextBox();
            this.btShowSpeed = new System.Windows.Forms.Button();
            this.tabPageCommands = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btApply = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFastSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFastTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDecTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRaTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDecRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRaRrate)).BeginInit();
            this.tabDome.SuspendLayout();
            this.tabPageImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.tabPageZone.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPositionTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarkerIdAr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarkerIdDec)).BeginInit();
            this.tabPageTelescope.SuspendLayout();
            this.tabPageCommands.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSave.Location = new System.Drawing.Point(343, 15);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(99, 28);
            this.btSave.TabIndex = 22;
            this.btSave.Text = "Save and Apply";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btLightOff
            // 
            this.btLightOff.Location = new System.Drawing.Point(8, 45);
            this.btLightOff.Name = "btLightOff";
            this.btLightOff.Size = new System.Drawing.Size(85, 28);
            this.btLightOff.TabIndex = 28;
            this.btLightOff.Text = "Light OFF cmd";
            this.btLightOff.UseVisualStyleBackColor = true;
            this.btLightOff.Click += new System.EventHandler(this.btLightOff_Click);
            // 
            // btLightOn
            // 
            this.btLightOn.Location = new System.Drawing.Point(8, 16);
            this.btLightOn.Name = "btLightOn";
            this.btLightOn.Size = new System.Drawing.Size(85, 28);
            this.btLightOn.TabIndex = 29;
            this.btLightOn.Text = "Light ON cmd";
            this.btLightOn.UseVisualStyleBackColor = true;
            this.btLightOn.Click += new System.EventHandler(this.btLightOn_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 18);
            this.label4.TabIndex = 32;
            this.label4.Text = "Telescope mount Driver:";
            // 
            // txtTelescopeDriver
            // 
            this.txtTelescopeDriver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelescopeDriver.Location = new System.Drawing.Point(8, 35);
            this.txtTelescopeDriver.Name = "txtTelescopeDriver";
            this.txtTelescopeDriver.ReadOnly = true;
            this.txtTelescopeDriver.Size = new System.Drawing.Size(376, 20);
            this.txtTelescopeDriver.TabIndex = 31;
            // 
            // btTelescopeChoose
            // 
            this.btTelescopeChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTelescopeChoose.Location = new System.Drawing.Point(390, 35);
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
            this.label5.Location = new System.Drawing.Point(19, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "R.A. step:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Dec. step:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numFastSpeed);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numFastTime);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numDecTime);
            this.groupBox1.Controls.Add(this.numRaTime);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numDecRate);
            this.groupBox1.Controls.Add(this.numRaRrate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(11, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 116);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Move buttons";
            // 
            // numFastSpeed
            // 
            this.numFastSpeed.Location = new System.Drawing.Point(78, 85);
            this.numFastSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFastSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFastSpeed.Name = "numFastSpeed";
            this.numFastSpeed.Size = new System.Drawing.Size(57, 20);
            this.numFastSpeed.TabIndex = 46;
            this.numFastSpeed.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = ">> multiplier";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numFastTime
            // 
            this.numFastTime.Location = new System.Drawing.Point(141, 85);
            this.numFastTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFastTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFastTime.Name = "numFastTime";
            this.numFastTime.Size = new System.Drawing.Size(57, 20);
            this.numFastTime.TabIndex = 44;
            this.numFastTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(147, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "time (sec)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numDecTime
            // 
            this.numDecTime.DecimalPlaces = 2;
            this.numDecTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numDecTime.Location = new System.Drawing.Point(142, 55);
            this.numDecTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDecTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numDecTime.Name = "numDecTime";
            this.numDecTime.Size = new System.Drawing.Size(57, 20);
            this.numDecTime.TabIndex = 42;
            this.numDecTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numRaTime
            // 
            this.numRaTime.DecimalPlaces = 2;
            this.numRaTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numRaTime.Location = new System.Drawing.Point(142, 33);
            this.numRaTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRaTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numRaTime.Name = "numRaTime";
            this.numRaTime.Size = new System.Drawing.Size(57, 20);
            this.numRaTime.TabIndex = 41;
            this.numRaTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "speed";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numDecRate
            // 
            this.numDecRate.DecimalPlaces = 2;
            this.numDecRate.Location = new System.Drawing.Point(79, 55);
            this.numDecRate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDecRate.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numDecRate.Name = "numDecRate";
            this.numDecRate.Size = new System.Drawing.Size(57, 20);
            this.numDecRate.TabIndex = 39;
            this.numDecRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numRaRrate
            // 
            this.numRaRrate.DecimalPlaces = 2;
            this.numRaRrate.Location = new System.Drawing.Point(79, 33);
            this.numRaRrate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRaRrate.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numRaRrate.Name = "numRaRrate";
            this.numRaRrate.Size = new System.Drawing.Size(57, 20);
            this.numRaRrate.TabIndex = 38;
            this.numRaRrate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabDome
            // 
            this.tabDome.Controls.Add(this.tabPageImage);
            this.tabDome.Controls.Add(this.tabPageZone);
            this.tabDome.Controls.Add(this.tabPageTelescope);
            this.tabDome.Controls.Add(this.tabPageCommands);
            this.tabDome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDome.Location = new System.Drawing.Point(0, 0);
            this.tabDome.Name = "tabDome";
            this.tabDome.SelectedIndex = 0;
            this.tabDome.Size = new System.Drawing.Size(454, 396);
            this.tabDome.TabIndex = 39;
            // 
            // tabPageImage
            // 
            this.tabPageImage.Controls.Add(this.lbl_ImgSize);
            this.tabPageImage.Controls.Add(this.btSetAsReference2);
            this.tabPageImage.Controls.Add(this.label10);
            this.tabPageImage.Controls.Add(this.btSetAsReference1);
            this.tabPageImage.Controls.Add(this.lblSource);
            this.tabPageImage.Controls.Add(this.txtSource);
            this.tabPageImage.Controls.Add(this.label1);
            this.tabPageImage.Controls.Add(this.cmbSourceType);
            this.tabPageImage.Controls.Add(this.picPreview);
            this.tabPageImage.Controls.Add(this.btPreview);
            this.tabPageImage.Location = new System.Drawing.Point(4, 22);
            this.tabPageImage.Name = "tabPageImage";
            this.tabPageImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImage.Size = new System.Drawing.Size(446, 370);
            this.tabPageImage.TabIndex = 0;
            this.tabPageImage.Text = "Image";
            // 
            // lbl_ImgSize
            // 
            this.lbl_ImgSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ImgSize.Location = new System.Drawing.Point(341, 309);
            this.lbl_ImgSize.Name = "lbl_ImgSize";
            this.lbl_ImgSize.Size = new System.Drawing.Size(97, 43);
            this.lbl_ImgSize.TabIndex = 34;
            // 
            // btSetAsReference2
            // 
            this.btSetAsReference2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSetAsReference2.Enabled = false;
            this.btSetAsReference2.Location = new System.Drawing.Point(341, 248);
            this.btSetAsReference2.Name = "btSetAsReference2";
            this.btSetAsReference2.Size = new System.Drawing.Size(97, 49);
            this.btSetAsReference2.TabIndex = 33;
            this.btSetAsReference2.Text = "Set as Reference2";
            this.btSetAsReference2.UseVisualStyleBackColor = true;
            this.btSetAsReference2.Click += new System.EventHandler(this.btSetAsReference2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Camera type:";
            // 
            // btSetAsReference1
            // 
            this.btSetAsReference1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSetAsReference1.Enabled = false;
            this.btSetAsReference1.Location = new System.Drawing.Point(341, 193);
            this.btSetAsReference1.Name = "btSetAsReference1";
            this.btSetAsReference1.Size = new System.Drawing.Size(97, 49);
            this.btSetAsReference1.TabIndex = 31;
            this.btSetAsReference1.Text = "Set as Reference1";
            this.btSetAsReference1.UseVisualStyleBackColor = true;
            this.btSetAsReference1.Click += new System.EventHandler(this.btSetAsReference_Click);
            // 
            // lblSource
            // 
            this.lblSource.Location = new System.Drawing.Point(9, 37);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(67, 18);
            this.lblSource.TabIndex = 20;
            this.lblSource.Text = "Settings:";
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSource.Location = new System.Drawing.Point(82, 34);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(326, 20);
            this.txtSource.TabIndex = 18;
            this.txtSource.Validated += new System.EventHandler(this.txtSource_Validated);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 19;
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbSourceType
            // 
            this.cmbSourceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSourceType.FormattingEnabled = true;
            this.cmbSourceType.Items.AddRange(new object[] {
            "File",
            "URL"});
            this.cmbSourceType.Location = new System.Drawing.Point(82, 6);
            this.cmbSourceType.Name = "cmbSourceType";
            this.cmbSourceType.Size = new System.Drawing.Size(121, 21);
            this.cmbSourceType.TabIndex = 21;
            this.cmbSourceType.SelectedIndexChanged += new System.EventHandler(this.cmbSourceType_SelectedIndexChanged);
            // 
            // picPreview
            // 
            this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(6, 69);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(329, 295);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 26;
            this.picPreview.TabStop = false;
            // 
            // btPreview
            // 
            this.btPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPreview.Location = new System.Drawing.Point(341, 69);
            this.btPreview.Name = "btPreview";
            this.btPreview.Size = new System.Drawing.Size(97, 52);
            this.btPreview.TabIndex = 27;
            this.btPreview.Text = "Load Preview";
            this.btPreview.UseVisualStyleBackColor = true;
            this.btPreview.Click += new System.EventHandler(this.btPreview_Click);
            // 
            // tabPageZone
            // 
            this.tabPageZone.Controls.Add(this.btSaveMarkers);
            this.tabPageZone.Controls.Add(this.groupBox2);
            this.tabPageZone.Location = new System.Drawing.Point(4, 22);
            this.tabPageZone.Name = "tabPageZone";
            this.tabPageZone.Size = new System.Drawing.Size(446, 370);
            this.tabPageZone.TabIndex = 3;
            this.tabPageZone.Text = "Markers";
            // 
            // btSaveMarkers
            // 
            this.btSaveMarkers.Location = new System.Drawing.Point(8, 222);
            this.btSaveMarkers.Name = "btSaveMarkers";
            this.btSaveMarkers.Size = new System.Drawing.Size(124, 33);
            this.btSaveMarkers.TabIndex = 33;
            this.btSaveMarkers.Text = "Save Markers Sheet";
            this.btSaveMarkers.UseVisualStyleBackColor = true;
            this.btSaveMarkers.Click += new System.EventHandler(this.btSaveMarkers_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numPositionTolerance);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chkReverseDec);
            this.groupBox2.Controls.Add(this.numMarkerIdAr);
            this.groupBox2.Controls.Add(this.chkReverseAR);
            this.groupBox2.Controls.Add(this.numMarkerIdDec);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(8, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 189);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 140);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Green Light tolerance (pixel)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Marker ID";
            // 
            // numPositionTolerance
            // 
            this.numPositionTolerance.Location = new System.Drawing.Point(177, 138);
            this.numPositionTolerance.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numPositionTolerance.Name = "numPositionTolerance";
            this.numPositionTolerance.Size = new System.Drawing.Size(59, 20);
            this.numPositionTolerance.TabIndex = 38;
            this.numPositionTolerance.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "A.R. Axis:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkReverseDec
            // 
            this.chkReverseDec.AutoSize = true;
            this.chkReverseDec.Location = new System.Drawing.Point(184, 80);
            this.chkReverseDec.Name = "chkReverseDec";
            this.chkReverseDec.Size = new System.Drawing.Size(15, 14);
            this.chkReverseDec.TabIndex = 37;
            this.chkReverseDec.UseVisualStyleBackColor = true;
            // 
            // numMarkerIdAr
            // 
            this.numMarkerIdAr.Location = new System.Drawing.Point(86, 46);
            this.numMarkerIdAr.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numMarkerIdAr.Name = "numMarkerIdAr";
            this.numMarkerIdAr.Size = new System.Drawing.Size(59, 20);
            this.numMarkerIdAr.TabIndex = 28;
            // 
            // chkReverseAR
            // 
            this.chkReverseAR.AutoSize = true;
            this.chkReverseAR.Location = new System.Drawing.Point(184, 48);
            this.chkReverseAR.Name = "chkReverseAR";
            this.chkReverseAR.Size = new System.Drawing.Size(15, 14);
            this.chkReverseAR.TabIndex = 35;
            this.chkReverseAR.UseVisualStyleBackColor = true;
            // 
            // numMarkerIdDec
            // 
            this.numMarkerIdDec.Location = new System.Drawing.Point(86, 78);
            this.numMarkerIdDec.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numMarkerIdDec.Name = "numMarkerIdDec";
            this.numMarkerIdDec.Size = new System.Drawing.Size(59, 20);
            this.numMarkerIdDec.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(165, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 38);
            this.label12.TabIndex = 36;
            this.label12.Text = "Reverse first movement";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Dec. Axis";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabPageTelescope
            // 
            this.tabPageTelescope.Controls.Add(this.txtAllowedRates);
            this.tabPageTelescope.Controls.Add(this.btShowSpeed);
            this.tabPageTelescope.Controls.Add(this.txtTelescopeDriver);
            this.tabPageTelescope.Controls.Add(this.groupBox1);
            this.tabPageTelescope.Controls.Add(this.btTelescopeChoose);
            this.tabPageTelescope.Controls.Add(this.label4);
            this.tabPageTelescope.Location = new System.Drawing.Point(4, 22);
            this.tabPageTelescope.Name = "tabPageTelescope";
            this.tabPageTelescope.Size = new System.Drawing.Size(446, 370);
            this.tabPageTelescope.TabIndex = 2;
            this.tabPageTelescope.Text = "Telescope";
            // 
            // txtAllowedRates
            // 
            this.txtAllowedRates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAllowedRates.Location = new System.Drawing.Point(256, 112);
            this.txtAllowedRates.Multiline = true;
            this.txtAllowedRates.Name = "txtAllowedRates";
            this.txtAllowedRates.ReadOnly = true;
            this.txtAllowedRates.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAllowedRates.Size = new System.Drawing.Size(182, 250);
            this.txtAllowedRates.TabIndex = 40;
            // 
            // btShowSpeed
            // 
            this.btShowSpeed.Location = new System.Drawing.Point(256, 83);
            this.btShowSpeed.Name = "btShowSpeed";
            this.btShowSpeed.Size = new System.Drawing.Size(128, 23);
            this.btShowSpeed.TabIndex = 39;
            this.btShowSpeed.Text = "Show allowed speed";
            this.btShowSpeed.UseVisualStyleBackColor = true;
            this.btShowSpeed.Click += new System.EventHandler(this.btShowSpeed_Click);
            // 
            // tabPageCommands
            // 
            this.tabPageCommands.Controls.Add(this.btLightOn);
            this.tabPageCommands.Controls.Add(this.btLightOff);
            this.tabPageCommands.Location = new System.Drawing.Point(4, 22);
            this.tabPageCommands.Name = "tabPageCommands";
            this.tabPageCommands.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommands.Size = new System.Drawing.Size(446, 370);
            this.tabPageCommands.TabIndex = 1;
            this.tabPageCommands.Text = "Commands";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btApply);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 396);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 55);
            this.panel1.TabIndex = 40;
            // 
            // btApply
            // 
            this.btApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btApply.Location = new System.Drawing.Point(236, 15);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(99, 28);
            this.btApply.TabIndex = 24;
            this.btApply.Text = "Apply";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(129, 15);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(99, 28);
            this.btCancel.TabIndex = 23;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 451);
            this.Controls.Add(this.tabDome);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 200);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFastSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFastTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDecTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRaTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDecRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRaRrate)).EndInit();
            this.tabDome.ResumeLayout(false);
            this.tabPageImage.ResumeLayout(false);
            this.tabPageImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.tabPageZone.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPositionTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarkerIdAr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarkerIdDec)).EndInit();
            this.tabPageTelescope.ResumeLayout(false);
            this.tabPageTelescope.PerformLayout();
            this.tabPageCommands.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.Button btLightOff;
		private System.Windows.Forms.Button btLightOn;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtTelescopeDriver;
		private System.Windows.Forms.Button btTelescopeChoose;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numFastSpeed;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown numFastTime;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown numDecTime;
		private System.Windows.Forms.NumericUpDown numRaTime;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown numDecRate;
		private System.Windows.Forms.NumericUpDown numRaRrate;
		private System.Windows.Forms.TabControl tabDome;
		private System.Windows.Forms.TabPage tabPageCommands;
		private System.Windows.Forms.TabPage tabPageTelescope;
		private System.Windows.Forms.TabPage tabPageZone;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabPage tabPageImage;
		private System.Windows.Forms.Label lblSource;
		private System.Windows.Forms.TextBox txtSource;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbSourceType;
		private System.Windows.Forms.PictureBox picPreview;
		private System.Windows.Forms.Button btPreview;
		private System.Windows.Forms.Button btSetAsReference1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btApply;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown numMarkerIdDec;
		private System.Windows.Forms.NumericUpDown numMarkerIdAr;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSetAsReference2;
        private System.Windows.Forms.Button btSaveMarkers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkReverseDec;
        private System.Windows.Forms.CheckBox chkReverseAR;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numPositionTolerance;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAllowedRates;
        private System.Windows.Forms.Button btShowSpeed;
        private System.Windows.Forms.Label lbl_ImgSize;
    }
}