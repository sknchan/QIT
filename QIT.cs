﻿using System;
using System.IO;
using System.Windows.Forms;

namespace QIT
{
	static class Program
	{
		public static string ProductName = String.Format("QIT v{0}", Application.ProductVersion);

		[STAThread]
		static void Main(string[] args)
		{
			Settings.CKey		= 0;
			Settings.CSecret	= 0;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Settings.Load();

			if (String.IsNullOrEmpty(Settings.UToken))
				Application.Run(new frmPin());

			if (!String.IsNullOrEmpty(Settings.UToken))
			{
				if (args.Length == 0)
				{
					Application.Run(new frmMain());
				}
				else if (File.Exists(args[0]))
				{
					frmUpload frm = new frmUpload();

					frm.AutoStart = (Array.IndexOf(args, "/a") >= 0);

					if (frm.SetImage(new DragDropInfo(args[0])))
						Application.Run(frm);
				}
			}
		}
	}
}