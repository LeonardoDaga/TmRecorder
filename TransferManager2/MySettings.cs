using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TransferManager
{
    public class AppSettings
    {
        Common.SettingsBase sb;
        bool isExtraTeam = false;
        string exTeamId = "";
        string _baseDataFolderPath = "";
        public string BaseDataFolderPath
        {
            get { return _baseDataFolderPath; }
            set { _baseDataFolderPath = value; }
        }

        string _datafilePath = "";
        public string DatafilePath
        {
            get { return _datafilePath; }
            set { _datafilePath = value; }
        }

        public void Initialize()
        {
            string[] args = new string[0];
            Initialize(args);
        }

        public void Initialize(string[] args)
        {
            int op = 0;

            try
            {
                op++;

                sb = new Common.SettingsBase();

                op++;

                // Do it this way to recover old written settings
                string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                _datafilePath = Path.Combine(Environment.CurrentDirectory, "Datafiles\\");

                string settsFilename = "";
                if (args.Length > 0)
                {
                    exTeamId = args[0];
                    settsFilename = Path.Combine(Path.Combine(_baseDataFolderPath, exTeamId), "TransferManagerSettings.tmcnf");
                    isExtraTeam = true;
                }
                else
                {
                    settsFilename = Path.Combine(_baseDataFolderPath,
                        "TransferManagerSettings.tmcnf");
                }

                _datafilePath = Path.Combine(Environment.CurrentDirectory, "Datafiles\\");

                // Check the existence of the settings file in the new settings folder
                FileInfo fi = new FileInfo(settsFilename);

                if (!fi.Exists)
                {
                    try
                    {
                        fi = new FileInfo(@"./TransferManagerSettings.tmcnf");

                        op++;
                        if (fi.Exists)
                        {
                            sb.SettingsFilename = fi.FullName;
                            ApplicationFolder = fi.DirectoryName;
                            Load();
                        }
                        else
                        {
                            sb.SettingsFilename = settsFilename;
                            fi = new FileInfo(settsFilename);
                            ApplicationFolder = fi.DirectoryName;
                        }


                    }
                    catch (Exception)
                    {
                    }

                    // Then, change to the new settings folder
                    // sb.SettingsFilename = settsFilename;
                    // The use of the Application Folder is not forced anymore
                }
                else
                {
                    sb.SettingsFilename = settsFilename;
                    Load();
                }

                op++;

                // SetDefault setts only the missing values.
                SetDefault();

                op++;

                // Makes a copy of what just loaded, with the add of the missing values, if any
                Save();
            }
            catch (Exception ex)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                SendFileTo.ErrorReport.Send(ex, op.ToString(), Environment.StackTrace, swRelease);
            }
        }

        public AppSettings()
        {
            sb = new Common.SettingsBase();

            // Do it this way to recover old written settings
            string settsFilename = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "TmRecorder"),
                "TransferManagerSettings.tmcnf");
            sb.SettingsFilename = settsFilename;

            Load();

            // SetDefault setts only the missing values.
            SetDefault();

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

        private void SetDefault()
        {
            FileInfo fi = new FileInfo(sb.SettingsFilename);
            string appDataFolder = fi.DirectoryName;
            sb.Def("GainDSfilename", Path.Combine(appDataFolder, @"LedNygaardDataSet.tmgain.xml"));
            sb.Def("LastFileUsed", "transferList.xml");
            sb.Def("NormalizeGains", false);
            sb.Def("RingWavefile", "c:/Windows/Media/chimes.wav");
            sb.Def("PlaySound", true);
            sb.Def("NationListFile", "./NationList.xml");
            sb.Def("HomeNation", "it");
            sb.Def("AutoSaveAndLoad", true);
            sb.Def("RefreshDataOnly", false);
            sb.Def("ApplicationFolder", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "TmRecorder"));
            sb.Def("DefaultDirectory", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"TmRecorder\Data"));
            sb.Def("EvidenceGain", false);
            sb.Def("Language", "en");
        }

        public string Language
        {
            get { return (string)sb["Language"]; }
            set { sb["Language"] = (string)value; }
        }
        public bool EvidenceGain
        {
            get { return (bool)sb["EvidenceGain"]; }
            set { sb["EvidenceGain"] = (bool)value; }
        }
        public string DefaultDirectory
        {
            get { return (string)sb["DefaultDirectory"]; }
            set
            {
                sb["DefaultDirectory"] = (string)value;
                DirectoryInfo di = new DirectoryInfo(value);
                if (!di.Exists) di.Create();
            }
        }
        public string ApplicationFolder
        {
            get { return (string)sb["ApplicationFolder"]; }
            set { sb["ApplicationFolder"] = (string)value; }
        }
        public bool RefreshDataOnly
        {
            get { return (bool)sb["RefreshDataOnly"]; }
            set { sb["RefreshDataOnly"] = (bool)value; }
        }
        public string GainDSfilename
        {
            get { return (string)sb["GainDSfilename"]; }
            set { sb["GainDSfilename"] = value; }
        }
        public bool AutoSaveAndLoad
        {
            get { return (bool)sb["AutoSaveAndLoad"]; }
            set { sb["AutoSaveAndLoad"] = (bool)value; }
        }
        public string HomeNation
        {
            get { return (string)sb["HomeNation"]; }
            set { sb["HomeNation"] = value; }
        }
        public string NationListFile
        {
            get { return (string)sb["NationListFile"]; }
            set { sb["NationListFile"] = value; }
        }

        public string LastFileUsed
        {
            get { return (string)sb["LastFileUsed"]; }
            set { sb["LastFileUsed"] = value; }
        }
        public bool NormalizeGains
        {
            get { return (bool)sb["NormalizeGains"]; }
            set { sb["NormalizeGains"] = (bool)value; }
        }
        public string RingWavefile
        {
            get { return (string)sb["RingWavefile"]; }
            set { sb["RingWavefile"] = value; }
        }
        public bool PlaySound
        {
            get { return (bool)sb["PlaySound"]; }
            set { sb["PlaySound"] = (bool)value; }
        }
    }
}
