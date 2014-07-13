using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FieldFormationControl;

namespace TMR_Lineup
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
            Application.Run(new TestForm());
        }
    }
}