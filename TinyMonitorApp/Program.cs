//*****************************************************************************************
//                           Tinny clock Monitor
//*****************************************************************************************
//   Autor Osman Mazinov;
//   Copyright (C) 2016
//   Email: mazzinov@gmail.com
//   Created: 18.11.2016
//*****************************************************************************************

using System;
using System.Windows.Forms;

namespace TinyMonitorApp
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			MessageBox.Show(e.ExceptionObject?.ToString(), "Error happened!");
		}
	}
}