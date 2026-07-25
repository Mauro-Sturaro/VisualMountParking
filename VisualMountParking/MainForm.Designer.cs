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
            this.pnlImageBorder = new System.Windows.Forms.Panel();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btThemeToggle = new System.Windows.Forms.Button();
            this.chkImageSize = new System.Windows.Forms.CheckBox();
            this.cmbReferenceImage = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbImageToShow = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCardConnection = new System.Windows.Forms.Panel();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.btConnect = new VisualMountParking.ThemedButton();
            this.lblCardConnection = new System.Windows.Forms.Label();
            this.pnlCardMount = new System.Windows.Forms.Panel();
            this.btDecHigh2 = new VisualMountParking.ThemedButton();
            this.btDecHigh = new VisualMountParking.ThemedButton();
            this.btDecLow = new VisualMountParking.ThemedButton();
            this.btDecLow2 = new VisualMountParking.ThemedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btRaHigh2 = new VisualMountParking.ThemedButton();
            this.btRaHigh = new VisualMountParking.ThemedButton();
            this.btRaLow = new VisualMountParking.ThemedButton();
            this.btRaLow2 = new VisualMountParking.ThemedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCardMount = new System.Windows.Forms.Label();
            this.pnlCardActions = new System.Windows.Forms.Panel();
            this.btSTOP = new VisualMountParking.ThemedButton();
            this.btAutoPark = new VisualMountParking.ThemedButton();
            this.btPark = new VisualMountParking.ThemedButton();
            this.lblCardActions = new System.Windows.Forms.Label();
            this.pnlCardAccessories = new System.Windows.Forms.Panel();
            this.btLightOFF = new VisualMountParking.ThemedButton();
            this.btLightON = new VisualMountParking.ThemedButton();
            this.lblCardAccessories = new System.Windows.Forms.Label();
            this.btSettings = new VisualMountParking.ThemedButton();
            this.timerImage = new System.Windows.Forms.Timer(this.components);
            this.timerMountStat = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCurrent)).BeginInit();
            this.pnlImageBorder.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlCardConnection.SuspendLayout();
            this.pnlCardMount.SuspendLayout();
            this.pnlCardActions.SuspendLayout();
            this.pnlCardAccessories.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCurrent
            // 
            this.picCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCurrent.Location = new System.Drawing.Point(10, 10);
            this.picCurrent.Name = "picCurrent";
            this.picCurrent.Size = new System.Drawing.Size(616, 508);
            this.picCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCurrent.TabIndex = 7;
            this.picCurrent.TabStop = false;
            this.picCurrent.Paint += new System.Windows.Forms.PaintEventHandler(this.picCurrent_Paint);
            this.picCurrent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCurrent_MouseDown);
            this.picCurrent.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCurrent_MouseUp);
            // 
            // pnlImageBorder
            // 
            this.pnlImageBorder.Controls.Add(this.picCurrent);
            this.pnlImageBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImageBorder.Location = new System.Drawing.Point(0, 44);
            this.pnlImageBorder.Name = "pnlImageBorder";
            this.pnlImageBorder.Padding = new System.Windows.Forms.Padding(10);
            this.pnlImageBorder.Size = new System.Drawing.Size(636, 528);
            this.pnlImageBorder.TabIndex = 55;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Controls.Add(this.btThemeToggle);
            this.pnlToolbar.Controls.Add(this.chkImageSize);
            this.pnlToolbar.Controls.Add(this.cmbReferenceImage);
            this.pnlToolbar.Controls.Add(this.label4);
            this.pnlToolbar.Controls.Add(this.cmbImageToShow);
            this.pnlToolbar.Controls.Add(this.label3);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(876, 44);
            this.pnlToolbar.TabIndex = 60;
            this.pnlToolbar.Tag = "toolbar";
            // 
            // btThemeToggle
            // 
            this.btThemeToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btThemeToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btThemeToggle.Location = new System.Drawing.Point(834, 6);
            this.btThemeToggle.Name = "btThemeToggle";
            this.btThemeToggle.Size = new System.Drawing.Size(32, 32);
            this.btThemeToggle.TabIndex = 20;
            this.btThemeToggle.Tag = "icon";
            this.btThemeToggle.UseVisualStyleBackColor = true;
            this.btThemeToggle.Click += new System.EventHandler(this.btThemeToggle_Click);
            // 
            // chkImageSize
            // 
            this.chkImageSize.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkImageSize.Checked = true;
            this.chkImageSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImageSize.Location = new System.Drawing.Point(444, 6);
            this.chkImageSize.Name = "chkImageSize";
            this.chkImageSize.Size = new System.Drawing.Size(32, 32);
            this.chkImageSize.TabIndex = 6;
            this.chkImageSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkImageSize.UseVisualStyleBackColor = true;
            this.chkImageSize.CheckedChanged += new System.EventHandler(this.chkImageSize_CheckedChanged);
            // 
            // cmbReferenceImage
            // 
            this.cmbReferenceImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReferenceImage.FormattingEnabled = true;
            this.cmbReferenceImage.Items.AddRange(new object[] {
            "Reference1",
            "Reference2"});
            this.cmbReferenceImage.Location = new System.Drawing.Point(280, 11);
            this.cmbReferenceImage.Name = "cmbReferenceImage";
            this.cmbReferenceImage.Size = new System.Drawing.Size(150, 21);
            this.cmbReferenceImage.TabIndex = 5;
            this.cmbReferenceImage.SelectedIndexChanged += new System.EventHandler(this.cmbReferenceImage_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Reference:";
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
            this.cmbImageToShow.Location = new System.Drawing.Point(60, 11);
            this.cmbImageToShow.Name = "cmbImageToShow";
            this.cmbImageToShow.Size = new System.Drawing.Size(150, 21);
            this.cmbImageToShow.TabIndex = 4;
            this.cmbImageToShow.SelectedIndexChanged += new System.EventHandler(this.cmbImageToShow_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Show:";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.AutoScroll = true;
            this.pnlSidebar.Controls.Add(this.pnlCardConnection);
            this.pnlSidebar.Controls.Add(this.pnlCardMount);
            this.pnlSidebar.Controls.Add(this.pnlCardActions);
            this.pnlSidebar.Controls.Add(this.pnlCardAccessories);
            this.pnlSidebar.Controls.Add(this.btSettings);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlSidebar.Location = new System.Drawing.Point(636, 44);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSidebar.Size = new System.Drawing.Size(240, 528);
            this.pnlSidebar.TabIndex = 56;
            this.pnlSidebar.Tag = "sidebar";
            this.pnlSidebar.WrapContents = false;
            // 
            // pnlCardConnection
            // 
            this.pnlCardConnection.Controls.Add(this.lblConnectionStatus);
            this.pnlCardConnection.Controls.Add(this.btConnect);
            this.pnlCardConnection.Controls.Add(this.lblCardConnection);
            this.pnlCardConnection.Location = new System.Drawing.Point(10, 10);
            this.pnlCardConnection.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlCardConnection.Name = "pnlCardConnection";
            this.pnlCardConnection.Size = new System.Drawing.Size(210, 86);
            this.pnlCardConnection.TabIndex = 0;
            this.pnlCardConnection.Tag = "card";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(10, 62);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(73, 13);
            this.lblConnectionStatus.TabIndex = 2;
            this.lblConnectionStatus.Text = "Disconnected";
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(10, 30);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(190, 28);
            this.btConnect.TabIndex = 1;
            this.btConnect.Tag = "accent";
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // lblCardConnection
            // 
            this.lblCardConnection.AutoSize = true;
            this.lblCardConnection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardConnection.Location = new System.Drawing.Point(10, 8);
            this.lblCardConnection.Name = "lblCardConnection";
            this.lblCardConnection.Size = new System.Drawing.Size(70, 15);
            this.lblCardConnection.TabIndex = 0;
            this.lblCardConnection.Text = "Connection";
            // 
            // pnlCardMount
            // 
            this.pnlCardMount.Controls.Add(this.btDecHigh2);
            this.pnlCardMount.Controls.Add(this.btDecHigh);
            this.pnlCardMount.Controls.Add(this.btDecLow);
            this.pnlCardMount.Controls.Add(this.btDecLow2);
            this.pnlCardMount.Controls.Add(this.label2);
            this.pnlCardMount.Controls.Add(this.btRaHigh2);
            this.pnlCardMount.Controls.Add(this.btRaHigh);
            this.pnlCardMount.Controls.Add(this.btRaLow);
            this.pnlCardMount.Controls.Add(this.btRaLow2);
            this.pnlCardMount.Controls.Add(this.label1);
            this.pnlCardMount.Controls.Add(this.lblCardMount);
            this.pnlCardMount.Location = new System.Drawing.Point(10, 106);
            this.pnlCardMount.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlCardMount.Name = "pnlCardMount";
            this.pnlCardMount.Size = new System.Drawing.Size(210, 112);
            this.pnlCardMount.TabIndex = 1;
            this.pnlCardMount.Tag = "card";
            // 
            // btDecHigh2
            // 
            this.btDecHigh2.Location = new System.Drawing.Point(158, 66);
            this.btDecHigh2.Name = "btDecHigh2";
            this.btDecHigh2.Size = new System.Drawing.Size(34, 26);
            this.btDecHigh2.TabIndex = 14;
            this.btDecHigh2.Text = ">>";
            this.btDecHigh2.UseVisualStyleBackColor = true;
            this.btDecHigh2.Click += new System.EventHandler(this.btDecHigh2_Click);
            // 
            // btDecHigh
            // 
            this.btDecHigh.Location = new System.Drawing.Point(122, 66);
            this.btDecHigh.Name = "btDecHigh";
            this.btDecHigh.Size = new System.Drawing.Size(34, 26);
            this.btDecHigh.TabIndex = 13;
            this.btDecHigh.Text = ">";
            this.btDecHigh.UseVisualStyleBackColor = true;
            this.btDecHigh.Click += new System.EventHandler(this.btDecHigh_Click);
            // 
            // btDecLow
            // 
            this.btDecLow.Location = new System.Drawing.Point(86, 66);
            this.btDecLow.Name = "btDecLow";
            this.btDecLow.Size = new System.Drawing.Size(34, 26);
            this.btDecLow.TabIndex = 12;
            this.btDecLow.Text = "<";
            this.btDecLow.UseVisualStyleBackColor = true;
            this.btDecLow.Click += new System.EventHandler(this.btDecLow_Click);
            // 
            // btDecLow2
            // 
            this.btDecLow2.Location = new System.Drawing.Point(50, 66);
            this.btDecLow2.Name = "btDecLow2";
            this.btDecLow2.Size = new System.Drawing.Size(34, 26);
            this.btDecLow2.TabIndex = 11;
            this.btDecLow2.Text = "<<";
            this.btDecLow2.UseVisualStyleBackColor = true;
            this.btDecLow2.Click += new System.EventHandler(this.btDecLow2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Dec. :";
            // 
            // btRaHigh2
            // 
            this.btRaHigh2.Location = new System.Drawing.Point(158, 32);
            this.btRaHigh2.Name = "btRaHigh2";
            this.btRaHigh2.Size = new System.Drawing.Size(34, 26);
            this.btRaHigh2.TabIndex = 10;
            this.btRaHigh2.Text = ">>";
            this.btRaHigh2.UseVisualStyleBackColor = true;
            this.btRaHigh2.Click += new System.EventHandler(this.btRaHigh2_Click);
            // 
            // btRaHigh
            // 
            this.btRaHigh.Location = new System.Drawing.Point(122, 32);
            this.btRaHigh.Name = "btRaHigh";
            this.btRaHigh.Size = new System.Drawing.Size(34, 26);
            this.btRaHigh.TabIndex = 9;
            this.btRaHigh.Text = ">";
            this.btRaHigh.UseVisualStyleBackColor = true;
            this.btRaHigh.Click += new System.EventHandler(this.btRaHigh_Click);
            // 
            // btRaLow
            // 
            this.btRaLow.Location = new System.Drawing.Point(86, 32);
            this.btRaLow.Name = "btRaLow";
            this.btRaLow.Size = new System.Drawing.Size(34, 26);
            this.btRaLow.TabIndex = 8;
            this.btRaLow.Text = "<";
            this.btRaLow.UseVisualStyleBackColor = true;
            this.btRaLow.Click += new System.EventHandler(this.btRaLow_Click);
            // 
            // btRaLow2
            // 
            this.btRaLow2.Location = new System.Drawing.Point(50, 32);
            this.btRaLow2.Name = "btRaLow2";
            this.btRaLow2.Size = new System.Drawing.Size(34, 26);
            this.btRaLow2.TabIndex = 7;
            this.btRaLow2.Text = "<<";
            this.btRaLow2.UseVisualStyleBackColor = true;
            this.btRaLow2.Click += new System.EventHandler(this.btRaLow2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "R.A. :";
            // 
            // lblCardMount
            // 
            this.lblCardMount.AutoSize = true;
            this.lblCardMount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardMount.Location = new System.Drawing.Point(10, 8);
            this.lblCardMount.Name = "lblCardMount";
            this.lblCardMount.Size = new System.Drawing.Size(87, 15);
            this.lblCardMount.TabIndex = 0;
            this.lblCardMount.Text = "Mount control";
            // 
            // pnlCardActions
            // 
            this.pnlCardActions.Controls.Add(this.btSTOP);
            this.pnlCardActions.Controls.Add(this.btAutoPark);
            this.pnlCardActions.Controls.Add(this.btPark);
            this.pnlCardActions.Controls.Add(this.lblCardActions);
            this.pnlCardActions.Location = new System.Drawing.Point(10, 228);
            this.pnlCardActions.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlCardActions.Name = "pnlCardActions";
            this.pnlCardActions.Size = new System.Drawing.Size(210, 150);
            this.pnlCardActions.TabIndex = 2;
            this.pnlCardActions.Tag = "card";
            // 
            // btSTOP
            // 
            this.btSTOP.Location = new System.Drawing.Point(10, 98);
            this.btSTOP.Name = "btSTOP";
            this.btSTOP.Size = new System.Drawing.Size(190, 34);
            this.btSTOP.TabIndex = 16;
            this.btSTOP.Tag = "danger";
            this.btSTOP.Text = "STOP";
            this.btSTOP.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btAutoPark
            // 
            this.btAutoPark.Location = new System.Drawing.Point(10, 64);
            this.btAutoPark.Name = "btAutoPark";
            this.btAutoPark.Size = new System.Drawing.Size(190, 28);
            this.btAutoPark.TabIndex = 15;
            this.btAutoPark.Text = "Slave to Reference";
            this.btAutoPark.UseVisualStyleBackColor = true;
            this.btAutoPark.Click += new System.EventHandler(this.btAutoPark_Click);
            // 
            // btPark
            // 
            this.btPark.Location = new System.Drawing.Point(10, 30);
            this.btPark.Name = "btPark";
            this.btPark.Size = new System.Drawing.Size(190, 28);
            this.btPark.TabIndex = 1;
            this.btPark.Text = "Park";
            this.btPark.UseVisualStyleBackColor = true;
            this.btPark.Click += new System.EventHandler(this.btPark_Click);
            // 
            // lblCardActions
            // 
            this.lblCardActions.AutoSize = true;
            this.lblCardActions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardActions.Location = new System.Drawing.Point(10, 8);
            this.lblCardActions.Name = "lblCardActions";
            this.lblCardActions.Size = new System.Drawing.Size(48, 15);
            this.lblCardActions.TabIndex = 0;
            this.lblCardActions.Text = "Actions";
            // 
            // pnlCardAccessories
            // 
            this.pnlCardAccessories.Controls.Add(this.btLightOFF);
            this.pnlCardAccessories.Controls.Add(this.btLightON);
            this.pnlCardAccessories.Controls.Add(this.lblCardAccessories);
            this.pnlCardAccessories.Location = new System.Drawing.Point(10, 388);
            this.pnlCardAccessories.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlCardAccessories.Name = "pnlCardAccessories";
            this.pnlCardAccessories.Size = new System.Drawing.Size(210, 86);
            this.pnlCardAccessories.TabIndex = 3;
            this.pnlCardAccessories.Tag = "card";
            // 
            // btLightOFF
            // 
            this.btLightOFF.Location = new System.Drawing.Point(109, 30);
            this.btLightOFF.Name = "btLightOFF";
            this.btLightOFF.Size = new System.Drawing.Size(91, 28);
            this.btLightOFF.TabIndex = 3;
            this.btLightOFF.Text = "Light OFF";
            this.btLightOFF.UseVisualStyleBackColor = true;
            this.btLightOFF.Click += new System.EventHandler(this.btLightOFF_Click);
            // 
            // btLightON
            // 
            this.btLightON.Location = new System.Drawing.Point(10, 30);
            this.btLightON.Name = "btLightON";
            this.btLightON.Size = new System.Drawing.Size(91, 28);
            this.btLightON.TabIndex = 2;
            this.btLightON.Text = "Light ON";
            this.btLightON.UseVisualStyleBackColor = true;
            this.btLightON.Click += new System.EventHandler(this.btLightON_ClickAsync);
            // 
            // lblCardAccessories
            // 
            this.lblCardAccessories.AutoSize = true;
            this.lblCardAccessories.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardAccessories.Location = new System.Drawing.Point(10, 8);
            this.lblCardAccessories.Name = "lblCardAccessories";
            this.lblCardAccessories.Size = new System.Drawing.Size(71, 15);
            this.lblCardAccessories.TabIndex = 0;
            this.lblCardAccessories.Text = "Accessories";
            // 
            // btSettings
            // 
            this.btSettings.Image = ((System.Drawing.Image)(resources.GetObject("btSettings.Image")));
            this.btSettings.Location = new System.Drawing.Point(10, 484);
            this.btSettings.Margin = new System.Windows.Forms.Padding(0);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(210, 30);
            this.btSettings.TabIndex = 4;
            this.btSettings.Text = "Settings";
            this.btSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSettings.UseVisualStyleBackColor = true;
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
            // 
            // timerImage
            // 
            this.timerImage.Interval = 250;
            this.timerImage.Tick += new System.EventHandler(this.timerImage_Tick);
            // 
            // timerMountStat
            // 
            this.timerMountStat.Enabled = true;
            this.timerMountStat.Interval = 500;
            this.timerMountStat.Tick += new System.EventHandler(this.timerMountStat_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 572);
            this.Controls.Add(this.pnlImageBorder);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlToolbar);
            this.MinimumSize = new System.Drawing.Size(760, 520);
            this.Name = "MainForm";
            this.Text = "Telescope Visual Parking";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCurrent)).EndInit();
            this.pnlImageBorder.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlCardConnection.ResumeLayout(false);
            this.pnlCardConnection.PerformLayout();
            this.pnlCardMount.ResumeLayout(false);
            this.pnlCardMount.PerformLayout();
            this.pnlCardActions.ResumeLayout(false);
            this.pnlCardActions.PerformLayout();
            this.pnlCardAccessories.ResumeLayout(false);
            this.pnlCardAccessories.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picCurrent;
        private System.Windows.Forms.Panel pnlImageBorder;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.CheckBox chkImageSize;
        private System.Windows.Forms.Button btThemeToggle;
        private System.Windows.Forms.ComboBox cmbReferenceImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbImageToShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel pnlSidebar;
        private System.Windows.Forms.Panel pnlCardConnection;
        private System.Windows.Forms.Label lblConnectionStatus;
        private ThemedButton btConnect;
        private System.Windows.Forms.Label lblCardConnection;
        private System.Windows.Forms.Panel pnlCardMount;
        private ThemedButton btDecHigh2;
        private ThemedButton btDecHigh;
        private ThemedButton btDecLow;
        private ThemedButton btDecLow2;
        private System.Windows.Forms.Label label2;
        private ThemedButton btRaHigh2;
        private ThemedButton btRaHigh;
        private ThemedButton btRaLow;
        private ThemedButton btRaLow2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCardMount;
        private System.Windows.Forms.Panel pnlCardActions;
        private ThemedButton btSTOP;
        private ThemedButton btAutoPark;
        private ThemedButton btPark;
        private System.Windows.Forms.Label lblCardActions;
        private System.Windows.Forms.Panel pnlCardAccessories;
        private ThemedButton btLightOFF;
        private ThemedButton btLightON;
        private System.Windows.Forms.Label lblCardAccessories;
        private ThemedButton btSettings;
        private System.Windows.Forms.Timer timerImage;
        private System.Windows.Forms.Timer timerMountStat;
    }
}
