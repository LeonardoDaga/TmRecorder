using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScoutSeries
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static AppSettings Setts = new AppSettings();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScoutSeriesForm());
        }
    }
}
