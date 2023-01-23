using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualMountParking
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			//
			// Ignore HTTPS certificate errors
			// I'm using only local netrwork and Reolink camera by defaut use self signed certificates
			ServicePointManager.ServerCertificateValidationCallback += 	(sender, cert, chain, sslPolicyErrors) => true;

			Application.Run(new MainForm());
		}
	}
}
