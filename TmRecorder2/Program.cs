using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TmRecorder2
{
    static class Program
    {
        public static AppSettings Setts = new AppSettings();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
