namespace ChekMountPosition
{
	partial class EditCommand
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtURI = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbVerb = new System.Windows.Forms.ComboBox();
			this.txtBody = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btOK = new System.Windows.Forms.Button();
			this.btTest = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "URI:";
			// 
			// txtURI
			// 
			this.txtURI.Location = new System.Drawing.Point(12, 59);
			this.txtURI.Multiline = true;
			this.txtURI.Name = "txtURI";
			this.txtURI.Size = new System.Drawing.Size(452, 78);
			this.txtURI.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "HTTP(S) Verb:";
			// 
			// cmbVerb
			// 
			this.cmbVerb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVerb.FormattingEnabled = true;
			this.cmbVerb.Location = new System.Drawing.Point(95, 6);
			this.cmbVerb.Name = "cmbVerb";
			this.cmbVerb.Size = new System.Drawing.Size(121, 21);
			this.cmbVerb.TabIndex = 3;
			this.cmbVerb.SelectedIndexChanged += new System.EventHandler(this.cmbVerb_SelectedIndexChanged);
			// 
			// txtBody
			// 
			this.txtBody.Location = new System.Drawing.Point(12, 173);
			this.txtBody.Multiline = true;
			this.txtBody.Name = "txtBody";
			this.txtBody.Size = new System.Drawing.Size(452, 123);
			this.txtBody.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 157);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Body:";
			// 
			// btOK
			// 
			this.btOK.Location = new System.Drawing.Point(389, 302);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(75, 23);
			this.btOK.TabIndex = 6;
			this.btOK.Text = "OK";
			this.btOK.UseVisualStyleBackColor = true;
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// btTest
			// 
			this.btTest.Location = new System.Drawing.Point(12, 302);
			this.btTest.Name = "btTest";
			this.btTest.Size = new System.Drawing.Size(75, 23);
			this.btTest.TabIndex = 7;
			this.btTest.Text = "Test";
			this.btTest.UseVisualStyleBackColor = true;
			this.btTest.Click += new System.EventHandler(this.btTest_Click);
			// 
			// EditCommand
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(476, 335);
			this.Controls.Add(this.btTest);
			this.Controls.Add(this.btOK);
			this.Controls.Add(this.txtBody);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbVerb);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtURI);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditCommand";
			this.Text = "EditCommand";
			this.Load += new System.EventHandler(this.EditCommand_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtURI;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbVerb;
		private System.Windows.Forms.TextBox txtBody;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btTest;
	}
}