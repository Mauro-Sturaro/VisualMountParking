using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChekMountPosition
{
	public partial class EditCommand : Form
	{
		public EditCommand()
		{
			InitializeComponent();
		}

		public CommandUri Command { get; set; }
		 

		private void EditCommand_Load(object sender, EventArgs e)
		{
			if(Command == null)
				Command = new CommandUri();

			foreach (var verb in Enum.GetNames(typeof(CommandVerb))){
				cmbVerb.Items.Add(verb);
			}
			cmbVerb.SelectedIndex= (int)Command.CommandVerb;
			txtURI.Text = Command.Uri;
			txtBody.Text = Command.Body;
		}

		private void cmbVerb_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void btOK_Click(object sender, EventArgs e)
		{
			FillCommand(Command);

			DialogResult= DialogResult.OK;
			Close();
		}

		private void btTest_Click(object sender, EventArgs e)
		{
			var cmd = new CommandUri();
			FillCommand(cmd);

			try
			{
				var ut = new WebUtils();
				var result = AsyncUtil.RunSync(() => ut.RunCommandURIAsync(cmd));
				 
				if (result.IsSuccessStatusCode)
				{
					var resp = AsyncUtil.RunSync(() => result.Content.ReadAsStringAsync());
					if(resp.Length> 1000)
						resp = resp.Substring(0, 1000);
					MessageBox.Show( resp, "Command Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
 
				} else
				{
					MessageBox.Show( $"Return code={result.StatusCode}", "Command Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FillCommand(CommandUri cmd)
		{
			Enum.TryParse(cmbVerb.Text, out CommandVerb verb);
			cmd.CommandVerb = verb;

			cmd.Uri = txtURI.Text;
			cmd.Body = txtBody.Text;
		}
	}
}
