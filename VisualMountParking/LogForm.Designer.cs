namespace VisualMountParking
{
	partial class LogForm
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
			this.txt = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txt
			// 
			this.txt.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt.Location = new System.Drawing.Point(0, 0);
			this.txt.Multiline = true;
			this.txt.Name = "txt";
			this.txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txt.Size = new System.Drawing.Size(433, 256);
			this.txt.TabIndex = 0;
			// 
			// LogForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(433, 256);
			this.Controls.Add(this.txt);
			this.Name = "LogForm";
			this.Text = "LogForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txt;
	}
}