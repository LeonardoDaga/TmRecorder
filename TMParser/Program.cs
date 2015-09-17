using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SendFileTo;

namespace TMRecorder
{
    static class Program
    {
        public static AppSettings Setts = new AppSettings();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) 
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //DebugClass.TestLoadKampFromHTMLcode();
            DebugClass.TestLoadSquadShort();
            // Application.Run(new MainForm(args));
        }
    }
}
