using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Common;
using System.Windows.Forms;

namespace LeagueScanner
{
    public class AppSettings
    {
        Common.SettingsBase sb;

        public void Initialize()
        {
            sb = new Common.SettingsBase();

            // Do it this way to recover old written settings
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string settsFilename = Path.Combine(Path.Combine(appDataFolder,
                "LeagueScanner"),
                "LeagueScanner.tmcnf");

            // Check the existence of the settings file in the new settings folder
            FileInfo fi = new FileInfo(settsFilename);

            if (!fi.Exists)
            {
                sb.SettingsFilename = settsFilename;
                fi = new FileInfo(settsFilename);
                ApplicationFolder = fi.DirectoryName;
            }
            else
            {
                sb.SettingsFilename = settsFilename;
                Load();
            }

            // SetDefault setts only the missing values.
            SetDefault();

            // SetForced Set the values whose value must changed with a release of the Setts
            SetForced();

            // Makes a copy of what just loaded, with the add of the missing values, if any
            Save();
        }

        public void Load()
        {
            sb.Load();
        }

        public void Save()
        {
            sb.Save();
        }

        private void SetForced()
        {
        }

        private void SetDefault()
        {
            sb.Def("LastFilename", "LeagueScanner.xml");
            sb.Def("LastSelectedLeague", "it.1.1");
        }

        public string LastSelectedLeague
        {
            get { return (string)sb["LastSelectedLeague"]; }
            set { sb["LastSelectedLeague"] = value; }
        }

        public string ApplicationFolder
        {
            get { return (string)sb["ApplicationFolder"]; }
            set { sb["ApplicationFolder"] = value; }
        }

        public string LastFilename
        {
            get { return (string)sb["LastFilename"]; }
            set { sb["LastFilename"] = value; }
        }
    }
}
