using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace TMCopy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0) return;

            FileInfo fi = new FileInfo(args[0]);

            if (!fi.Exists) return;

            StreamReader file = new StreamReader(args[0]);

            string squad = file.ReadToEnd();

            file.Close();

            Clipboard.SetText(squad, TextDataFormat.Text);

            Application.Exit();
        }
    }
}