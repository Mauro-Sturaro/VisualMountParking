using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualMountParking
{
	public partial class LogForm : Form
	{
		public LogForm()
		{
			InitializeComponent();
		}
		public void WriteLine(string message)
		{
			txt.Text = txt.Text + message + "\r\n";
		}
		public void Write(string message)
		{
			txt.Text = txt.Text + message;
		}
	}


}
