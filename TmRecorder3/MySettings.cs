using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Common;
using System.Windows.Forms;

namespace TmRecorder3
{
    public class AppSettings
    {
        Common.SettingsBase sb;

        public void Initialize()
        {
            int op = 0;

            try
            {
                op++;

                sb = new Common.SettingsBase();

                op++;                

                // Do it this way to recover old written settings
                string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string settsFilename = Path.Combine(Path.Combine(appDataFolder, 
                    "TmRecorder"), 
                    "TmRecorderSettings.tmcnf");
                
                // Check the existence of the settings file in the new settings folder
                FileInfo fi = new FileInfo(settsFilename);

                if (!fi.Exists)
                {
                    try
                    {
                        fi = new FileInfo(@"./TmRecorderSettings.tmcnf");

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

                // SetForced Set the values whose value must changed with a release of the Setts
                SetForced();

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
            // Before release 1, the rouparams was wrong
            if (SettsRelease < 1) RouParams = new float[]{1.0F,0.004F};
        }

        private void SetDefault()
        {
            FileInfo fi = new FileInfo(sb.SettingsFilename);
            string appDataFolder = fi.DirectoryName;
            sb.Def("SquadFilename", "squad.htm");
            sb.Def("DefaultDirectory", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"TmRecorder\Data"));
            sb.Def("InstallationDirectory", Application.StartupPath);
            sb.Def("GainSet", Path.Combine(appDataFolder, @"RUSCheratte.tmgain.xml"));
            sb.Def("HomeNation", "it");
            sb.Def("NationListFile", Path.Combine(appDataFolder, @"NationList.xml"));
            sb.Def("NormalizeGains", false);
            sb.Def("PlayersPagesFolder", appDataFolder);
            sb.Def("ReportAnalysisFile", Path.Combine(appDataFolder, @"ReportAnalysisFileEN.xml"));
            sb.Def("ShowTGI", false);
            sb.Def("Setting", "");
            sb.Def("UseTMRBrowser", false);
            sb.Def("MatchesFileName", "MatchesHistory.3.xml");
            sb.Def("ShowStatsNormalized", false);
            sb.Def("ShowPosition", false);
            sb.Def("MatchTypes", "L,C,F,FL,CC");
            sb.Def("ClubNickname", "");
            sb.Def("MainSquadName", "");
            sb.Def("ReserveSquadName", "");
            sb.Def("MainSquadID", 0);
            sb.Def("ReserveSquadID", 0);
            sb.Def("PlayerType", 0);
            sb.Def("YouthLevel", 0);
            sb.Def("ActionAnalysisFile", "ActionAnalysis.xml");
            sb.Def("ShowActions", 0);
            sb.Def("EvidenceGain", false);
            sb.Def("UsingStartingPathDisk", false);
            sb.Def("RouParams", "1.0;0.004");
            sb.Def("RouFunction", "Linear");
            sb.Def("GainFunction", "RusCheratte");
            sb.Def("Language", "en");
            sb.Def("Trace", 0);
            sb.Def("ApplicationFolder", appDataFolder);
            sb.Def("UseOldHTMLImportStyle", false);
            sb.Def("MatchOnFieldFilter", 0);
            sb.Def("TacticsDBFilename", Path.Combine(appDataFolder, @"TacticsFile.xml"));
            sb.Def("DebugFunction", 0);
            sb.Def("FirstInstallation", true);
            
            // Always the last settings
            sb.Def("SettsRelease", 1);
        }

        public bool FirstInstallation
        {
            get { return (bool)sb["FirstInstallation"]; }
            set { sb["FirstInstallation"] = (bool)value; }
        }
        public string TacticsDBFilename
        {
            get { return (string)sb["TacticsDBFilename"]; }
            set { sb["TacticsDBFilename"] = (string)value; }
        }
        public string ApplicationFolder
        {
            get { return (string)sb["ApplicationFolder"]; }
            set
            {
                sb["ApplicationFolder"] = (string)value;
                DirectoryInfo di = new DirectoryInfo(value);
                if (!di.Exists) di.Create();
            }
        }
        public int DebugFunction
        {
            // 101: ChampDS.LoadSeasonFileFlash
            get { return (int)sb["DebugFunction"]; }
            set { sb["DebugFunction"] = (int)value; }
        }
        public int MatchOnFieldFilter
        {
            get { return (int)sb["MatchOnFieldFilter"]; }
            set { sb["MatchOnFieldFilter"] = (int)value; }
        }
        public bool UseOldHTMLImportStyle
        {
            get { return (bool)sb["UseOldHTMLImportStyle"]; }
            set { sb["UseOldHTMLImportStyle"] = (bool)value; }
        }
        public int Trace
        {
            get { return (int)sb["Trace"]; }
            set { sb["Trace"] = (int)value; }
        }
        public string Language
        {
            get { return (string)sb["Language"]; }
            set { sb["Language"] = (string)value; }
        }
        public int SettsRelease
        {
            get { return (int)sb["SettsRelease"]; }
            set { sb["SettsRelease"] = (int)value; }
        }
        public Gain_Function.FunctionType GainFunction
        {
            get { return Gain_Function.FromName((string)sb["GainFunction"]); }
            set { sb["GainFunction"] = Gain_Function.ToString(value); }
        }
        public Function.FunctionType RouFunction
        {
            get { return Function.FromName((string)sb["RouFunction"]); }
            set { sb["RouFunction"] = Function.ToString(value); }
        }
        public float[] RouParams
        {
            get {return Common.Utility.StringToFloatArray((string)sb["RouParams"]);}
            set {sb["RouParams"] = Common.Utility.FloatArrayToString((float[])value);}
        }
        public bool UsingStartingPathDisk
        {
            get { return (bool)sb["UsingStartingPathDisk"]; }
            set { sb["UsingStartingPathDisk"] = (bool)value; }
        }
        public bool EvidenceGain
        {
            get { return (bool)sb["EvidenceGain"]; }
            set { sb["EvidenceGain"] = (bool)value; }
        }
        public int ShowActions
        {
            get { return (int)sb["ShowActions"]; }
            set { sb["ShowActions"] = (int)value; }
        }
        public string ActionAnalysisFile
        {
            get { return (string)sb["ActionAnalysisFile"]; }
            set { sb["ActionAnalysisFile"] = (string)value; }
        }
        public int YouthLevel
        {
            get { return (int)sb["YouthLevel"]; }
            set { sb["YouthLevel"] = (int)value; }
        }
        public int PlayerType
        {
            get { return (int)sb["PlayerType"]; }
            set { sb["PlayerType"] = (int)value; }
        }
        public int ReserveSquadID
        {
            get { return (int)sb["ReserveSquadID"]; }
            set { sb["ReserveSquadID"] = (int)value; }
        }
        public int MainSquadID
        {
            get { return (int)sb["MainSquadID"]; }
            set { sb["MainSquadID"] = (int)value; }
        }
        public string ReserveSquadName
        {
            get { return (string)sb["ReserveSquadName"]; }
            set { sb["ReserveSquadName"] = (string)value; }
        }
        public string MainSquadName
        {
            get { return (string)sb["MainSquadName"]; }
            set { sb["MainSquadName"] = (string)value; }
        }
        public string ClubNickname
        {
            get { return (string)sb["ClubNickname"]; }
            set { sb["ClubNickname"] = (string)value; }
        }
        public string MatchTypes
        {
            get { return (string)sb["MatchTypes"]; }
            set { sb["MatchTypes"] = (string)value; }
        }
        public bool ShowPosition
        {
            get { return (bool)sb["ShowPosition"]; }
            set { sb["ShowPosition"] = (bool)value; }
        }
        public bool ShowStatsNormalized
        {
            get { return (bool)sb["ShowStatsNormalized"]; }
            set { sb["ShowStatsNormalized"] = (bool)value; }
        }
        public string MatchesFileName
        {
            get { return (string)sb["MatchesFileName"]; }
            set { sb["MatchesFileName"] = (string)value; }
        }
        public bool UseTMRBrowser
        {
            get { return (bool)sb["UseTMRBrowser"]; }
            set { sb["UseTMRBrowser"] = (bool)value; }
        }
        public string Setting
        {
            get { return (string)sb["Setting"]; }
            set { sb["Setting"] = (string)value; }
        }
        public bool ShowTGI
        {
            get { return (bool)sb["ShowTGI"]; }
            set { sb["ShowTGI"] = (bool)value; }
        }
        public string ReportAnalysisFile
        {
            get { return (string)sb["ReportAnalysisFile"]; }
            set { sb["ReportAnalysisFile"] = (string)value; }
        }
        public string PlayersPagesFolder
        {
            get { return (string)sb["PlayersPagesFolder"]; }
            set { sb["PlayersPagesFolder"] = (string)value; }
        }
        public bool NormalizeGains
        {
            get { return (bool)sb["NormalizeGains"]; }
            set { sb["NormalizeGains"] = (bool)value; }
        }
        public string NationListFile
        {
            get { return (string)sb["NationListFile"]; }
            set { sb["NationListFile"] = (string)value; }
        }
        public string HomeNation
        {
            get { return (string)sb["HomeNation"]; }
            set { sb["HomeNation"] = (string)value; }
        }
        public string GainSet
        {
            get { return (string)sb["GainSet"]; }
            set { sb["GainSet"] = (string)value; }
        }
        public string InstallationDirectory
        {
            get { return (string)sb["InstallationDirectory"]; }
            set { sb["InstallationDirectory"] = (string)value; }
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
        public string SquadFilename
        {
            get { return (string)sb["SquadFilename"]; }
            set { sb["SquadFilename"] = value; }
        }

        public void SetDisk(string disk)
        {
            ReportAnalysisFile = SetDiskForFile(disk, ReportAnalysisFile);
            DefaultDirectory = SetDiskForFile(disk, DefaultDirectory);
            InstallationDirectory = SetDiskForFile(disk, InstallationDirectory);
            NationListFile = SetDiskForFile(disk, NationListFile);
            GainSet = SetDiskForFile(disk, GainSet);
        }

        #region Private functions
        private string SetDiskForFile(string disk, string file)
        {
            FileInfo fi = new FileInfo(file);

            string[] part = fi.FullName.Split(':');

            return disk + ":" + part[1];
        }
        #endregion // Private functions
    }
}
