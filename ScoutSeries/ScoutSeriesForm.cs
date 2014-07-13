using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using System.IO;
using System.Threading;

namespace ScoutSeries
{
    public partial class ScoutSeriesForm : Form
    {
        public enum State
        {
            None,
            NavigationStart,
            NavigatingCountryList,
            NavigatingLeagues,
            NavigatingMatchesList,
            NavigatingMatches,
            NavigatingTeams,
            NavigatingStadii
        }

        public enum Mode
        {
            Wait,
            DontWait,
        }

        public State actualStatus = State.None;
        bool isDirty = false;
        string nation = "";
        string league = "";
        string group = "";
        int lastScannedMatch = -1;
        int lastScannedTeam = -1;
        int lastScannedStadium = -1;
        ProgressForm pform = null;
        bool pageComplete = false;
        bool recallMe = false;

        public ScoutSeriesForm()
        {
            InitializeComponent();

            Program.Setts.Initialize();
        }

        private void tbGotoPage_Click(object sender, EventArgs e)
        {
            AskForString afs = new AskForString();
            afs.Text = "Set the League";
            afs.Message = "Please insert the number of desired League to scan (es. it.1.2)";
            afs.EntryText = Program.Setts.LastSelectedLeague;
            if (afs.ShowDialog() == DialogResult.OK)
            {
                string[] val = afs.EntryText.Split('.');
                nation = val[0];
                league = val[1];
                group = val[2];
                Program.Setts.LastSelectedLeague = afs.EntryText;
                Program.Setts.Save();

                navigationAddress = "league.php?liga1=" + league + "&gurli1=" + group + "&country=" + nation;
                navigationAddress = "http://trophymanager.com/" + navigationAddress;
                actualStatus = State.None;
                webBrowser.Navigate(navigationAddress);
                startnavigationAddress = navigationAddress;
            }
        }

        //--------------------------------------------------------------------------------------
        //
        //                                  MAIN LOOP
        //
        //--------------------------------------------------------------------------------------
        private void ScanAllLeagues()
        {
            Random rand = new Random(882);
            Form parent = Application.OpenForms[0];

            // Starting navigation
            if (actualStatus == State.NavigationStart)
            {
                // Resetting counters
                lastScannedMatch = -1;
                lastScannedTeam = -1;
                lastScannedStadium = -1;

                // Change status
                actualStatus = State.NavigatingMatchesList;

                // Scan Country list
                if (ScanCountryList())
                {
                    // The page has been downloaded from inet
                    TimerSleep(5000 + (int)(15000.0 * rand.NextDouble()));
                }
                else
                {
                    TimerSleep(1);
                }
            }

            // Starting navigation
            if (actualStatus == State.NavigatingLeagues)
            {
                // Resetting counters
                lastScannedMatch = -1;
                lastScannedTeam = -1;
                lastScannedStadium = -1;

                // Change status
                actualStatus = State.NavigatingMatchesList;

                // Scan League page
                if (ScanLeague())
                {
                    // The page has been downloaded from inet
                    TimerSleep(5000 + (int)(15000.0 * rand.NextDouble()));
                }
                else
                {
                    TimerSleep(1);
                }
            }

            if (actualStatus == State.NavigatingTeams)
            {
                // Preparing a progress form
                if (pform == null)
                {
                    pform = new ProgressForm();
                    pform.Show(parent);
                }

                // Scan each team
                pform.Text = "Scanning the squads";
                pform.progressBar.Maximum = scoutseriesDS.Squad.Count;
                lastScannedTeam++;
                pform.progressBar.Value = lastScannedTeam;

                if (lastScannedTeam < scoutseriesDS.Squad.Count)
                {
                    ScoutSeriesDS.SquadRow sr = scoutseriesDS.Squad[lastScannedTeam];

                    pform.lblProgressDescription.Text = "Scanning " + lastScannedTeam.ToString() + " of " +
                        scoutseriesDS.Squad.Count.ToString() + " squads";
                    parent.Refresh();
                    pform.Refresh();

                    // Scan League Calendar page
                    if (ScanSquad(sr))
                    {
                        // The page has been downloaded from inet
                        TimerSleep(5000 + (int)(15000.0 * rand.NextDouble()));
                    }
                    else
                    {
                        TimerSleep(1);
                    }
                }
                else
                {
                    // Change status if at the end
                    actualStatus = State.NavigatingStadii;
                    TimerSleep(1);
                }
            }
        }

        private void TimerSleep(int delay)
        {
            recallMe = true;
            timer.Interval = delay;
            timer.Enabled = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            timer.Stop();

            if (recallMe)
            {
                recallMe = false;
                ScanForInjuries();
            }
        }

        private void ScanForInjuries()
        {
            throw new NotImplementedException();
        }

        #region SCAN COUNTRY LIST
        //--------------------------------------------------------------------------------------
        //
        //                               SCAN COUNTRY LIST
        //
        //--------------------------------------------------------------------------------------
        private bool ScanCountryList()
        {
            navigationAddress = "countries.php";

            // Check the existence of the folder
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.ApplicationFolder, "ImportedPages"));
            if (!di.Exists)
            {
                di.Create();
            }

            string filedate = TmWeek.ToSWDString(DateTime.Now);

            string filename = navigationAddress.Replace(".php", "").Replace("/", "").Replace("?", "!");

            filename += "_" + filedate + ".htm";

            FileInfo fi = new FileInfo(Path.Combine(di.FullName, filename));

            if (fi.Exists)
            {
                StreamReader file = new StreamReader(fi.FullName);
                string page = file.ReadToEnd();
                file.Close();

                ScanCountryPage(navigationAddress, page);

                return false;
            }
            else
            {
                navigationAddress = "http://trophymanager.com/" + navigationAddress;
                startnavigationAddress = navigationAddress;

                actualStatus = State.NavigatingCountryList; // Setting next state
                webBrowser.Navigate(navigationAddress);

                return true;
            }
        }

        private void ScanCountryPage(string navigationaddress, string page)
        {
            List<string> Tables = HTML_Parser.GetTags(page, "TABLE");

            List<string> rows = HTML_Parser.GetTags(Tables[0], "TR");

            foreach (string row in rows)
            {
                bool newTeam = false;

                List<string> td = HTML_Parser.GetTags(row, "TD");

                if (td.Count == 0) continue;

                string ID = HTML_Parser.GetNumberAfter(td[1], "klubhus.php?showclub=");
                string name = HTML_Parser.GetTag(td[1], "span");

                int teamID = int.Parse(ID);

                ScoutSeriesDS.SquadRow sr = scoutseriesDS.Squad.FindByTeamID(teamID);
                if (sr == null)
                {
                    sr = scoutseriesDS.Squad.NewSquadRow();
                    sr.TeamID = teamID;
                    newTeam = true;
                }

                sr.Name = name;
                sr.League = nation + "." + league + "." + group;

                if (newTeam)
                {
                    scoutseriesDS.Squad.AddSquadRow(sr);
                }
            }
        }
        #endregion

        #region LEAGUE LOOP
        //--------------------------------------------------------------------------------------
        //
        //                                  LEAGUE LOOP
        //
        //--------------------------------------------------------------------------------------
        private bool ScanLeague()
        {
            navigationAddress = "league.php?liga1=" + league + "&gurli1=" + group + "&country=" + nation;

            // Check the existence of the folder
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.ApplicationFolder, "ImportedPages"));
            if (!di.Exists)
            {
                di.Create();
            }

            string filedate = TmWeek.ToSWDString(DateTime.Now);

            string filename = navigationAddress.Replace(".php", "").Replace("/", "").Replace("?", "!");

            filename += "_" + filedate + ".htm";

            FileInfo fi = new FileInfo(Path.Combine(di.FullName, filename));

            if (fi.Exists)
            {
                StreamReader file = new StreamReader(fi.FullName);
                string page = file.ReadToEnd();
                file.Close();

                ScanLeaguePage(page);

                return false;
            }
            else
            {
                navigationAddress = "http://trophymanager.com/" + navigationAddress;
                startnavigationAddress = navigationAddress;
                
                actualStatus = State.NavigatingLeagues; // Setting next state
                webBrowser.Navigate(navigationAddress);

                return true;
            }
        }

        private void ScanLeaguePage(string page)
        {
            List<string> Tables = HTML_Parser.GetTags(page, "TABLE");

            List<string> rows = HTML_Parser.GetTags(Tables[0], "TR");

            foreach (string row in rows)
            {
                bool newTeam = false;

                List<string> td = HTML_Parser.GetTags(row, "TD");

                if (td.Count == 0) continue;

                string ID = HTML_Parser.GetNumberAfter(td[1], "klubhus.php?showclub=");
                string name = HTML_Parser.GetTag(td[1], "span");

                int teamID = int.Parse(ID);

                ScoutSeriesDS.SquadRow sr = scoutseriesDS.Squad.FindByTeamID(teamID);
                if (sr == null)
                {
                    sr = scoutseriesDS.Squad.NewSquadRow();
                    sr.TeamID = teamID;
                    newTeam = true;
                }

                sr.Name = name;
                sr.League = nation + "." + league + "." + group;

                if (newTeam)
                {
                    scoutseriesDS.Squad.AddSquadRow(sr);
                }
            }
        }
        #endregion

        #region SQUADS LOOP
        //--------------------------------------------------------------------------------------
        //
        //                                  SQUADS LOOP
        //
        //--------------------------------------------------------------------------------------
        private bool ScanSquad(ScoutSeriesDS.SquadRow sr)
        {
            int teamID = sr.TeamID;

            navigationAddress = "klubhus_squad.php?showclub=" + teamID.ToString();

            // Check the existence of the folder
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.ApplicationFolder, "ImportedPages"));
            if (!di.Exists)
            {
                di.Create();
            }

            string filename = navigationAddress.Replace(".php", "").Replace("/", "").Replace("?", "!");
            string filedate = TmWeek.thisWeek().absweek.ToString();
            filename += "_" + filedate + ".htm";

            FileInfo fi = new FileInfo(Path.Combine(di.FullName, filename));

            if (fi.Exists)
            {
                StreamReader file = new StreamReader(fi.FullName);
                string page = file.ReadToEnd();
                file.Close();

                ScanTeamPage(navigationAddress, page);
                return false;
            }
            else
            {
                navigationAddress = "http://trophymanager.com/" + navigationAddress;
                startnavigationAddress = navigationAddress;

                actualStatus = State.NavigatingTeams;
                webBrowser.Navigate(navigationAddress);
                return true;
            }
        }

        private void ScanTeamPage(string navigationAddress, string page)
        {
            List<string> Tables = HTML_Parser.GetTags(page, "TABLE");

            foreach (string table in Tables)
            {
                List<string> rows = HTML_Parser.GetTags(table, "TR");

                foreach (string row in rows)
                {
                    List<string> td = HTML_Parser.GetTags(row, "TD");
                    if (td.Count < 2) continue;

                    int playerId = int.Parse(HTML_Parser.GetNumberAfter(td[1], "playerid="));
                    int age = int.Parse(HTML_Parser.CleanTags(td[4]));
                    string rule = td[5];
                    string asi = HTML_Parser.GetNumberFromStart(td[7]);
                    int iasi = int.Parse(asi);

                    ScoutSeriesDS.PlayerRow pr = scoutseriesDS.Player.FindByPlayerID(playerId);
                    if (pr == null) continue;

                    pr.ASI = iasi;
                    pr.FP = rule;
                    pr.Age = age;
                }
            }
        }
        #endregion

        #region STADII LOOP
        //--------------------------------------------------------------------------------------
        //
        //                                  SQUADS LOOP
        //
        //--------------------------------------------------------------------------------------
        private bool ScanStadium(ScoutSeriesDS.SquadRow sr)
        {
            int teamID = sr.TeamID;

            navigationAddress = "showstadium.php?showclub=" + teamID.ToString();

            // Check the existence of the folder
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.ApplicationFolder, "ImportedPages"));
            if (!di.Exists)
            {
                di.Create();
            }

            string filename = navigationAddress.Replace(".php", "").Replace("/", "").Replace("?", "!");
            string filedate = TmWeek.thisWeek().absweek.ToString() + "_" +
                    DateTime.Now.Year.ToString();
            filename += "_" + filedate + ".htm";

            FileInfo fi = new FileInfo(Path.Combine(di.FullName, filename));

            if (fi.Exists)
            {
                StreamReader file = new StreamReader(fi.FullName);
                string page = file.ReadToEnd();
                file.Close();

                ScanStadiumPage(navigationAddress, page);
                return false;
            }
            else
            {
                navigationAddress = "http://trophymanager.com/" + navigationAddress;
                startnavigationAddress = navigationAddress;
                actualStatus = State.NavigatingStadii;
                webBrowser.Navigate(navigationAddress);
                return true;
            }
        }

        private void ScanStadiumPage(string navigationAddress, string page)
        {
            int squadId = int.Parse(HTML_Parser.GetNumberAfter(navigationAddress, "showstadium.php?showclub="));

            ScoutSeriesDS.SquadRow sr = scoutseriesDS.Squad.FindByTeamID(squadId);

            List<string> Tables = HTML_Parser.GetTags(page, "TABLE");

            // Getting data of external structures
            {
                string table = Tables[0];
                List<string> rows = HTML_Parser.GetTags(table, "TR");
                List<string> td = null;

                td = HTML_Parser.GetTags(rows[1], "TD");
                int campoAllenamento = int.Parse(HTML_Parser.CleanTags(td[1]));

                td = HTML_Parser.GetTags(rows[2], "TD");
                int settoreGiovanile = int.Parse(HTML_Parser.CleanTags(td[1]));

                td = HTML_Parser.GetTags(rows[3], "TD");
                int centroMedico = int.Parse(HTML_Parser.CleanTags(td[1]));

                sr.MedCenter = centroMedico;
            }

            // Getting data of external structures
            {
                string table = Tables[4];
                List<string> rows = HTML_Parser.GetTags(table, "TR");
                List<string> td = null;

                td = HTML_Parser.GetTags(rows[7], "TD");
                sr.Heating = int.Parse(HTML_Parser.CleanTags(td[1]));

                td = HTML_Parser.GetTags(rows[8], "TD");
                sr.Dreinage = int.Parse(HTML_Parser.CleanTags(td[1]));

                td = HTML_Parser.GetTags(rows[9], "TD");
                sr.PitchCovers = int.Parse(HTML_Parser.CleanTags(td[1]));

                td = HTML_Parser.GetTags(rows[10], "TD");
                sr.Sprinklers = int.Parse(HTML_Parser.CleanTags(td[1]));

                td = HTML_Parser.GetTags(rows[2], "TD");
                sr.PhysioRoom = int.Parse(HTML_Parser.CleanTags(td[1]));
            }
        }
        #endregion

        #region WebBrowser Navigation
        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress <= 0)
            {
                if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
                {
                    tsbProgressText.Text = "100%";
                    tsbProgressBar.ForeColor = Color.Green;
                    tsbProgressBar.Value = 100;
                }
                return;
            }

            int perc = (int)((e.CurrentProgress * 100) / e.MaximumProgress);
            tsbProgressBar.Value = perc;
            tsbProgressText.Text = perc.ToString() + "%";
            tsbProgressBar.ForeColor = Color.Blue;
        }

        string navigationAddress = "";
        string startnavigationAddress = "";

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString() != navigationAddress) return;

            tsbProgressBar.ForeColor = Color.Green;

            if (actualStatus == State.NavigatingLeagues)
            {
                string page = ImportBrowserContent();
                ScanLeaguePage(page);
            }
            else if (actualStatus == State.NavigatingCountryList)
            {
                string page = ImportBrowserContent();
                ScanCountryPage(navigationAddress, page);
            }
            else if (actualStatus == State.NavigatingTeams)
            {
                string page = ImportBrowserContent();
                ScanTeamPage(navigationAddress, page);
            }
            else if (actualStatus == State.NavigatingStadii)
            {
                string page = ImportBrowserContent();
                ScanStadiumPage(navigationAddress, page);
            }

            Random rand = new Random(882);
            TimerSleep(5000 + (int)(15000.0 * rand.NextDouble()));
        }


        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            navigationAddress = e.Url.ToString();

            tsbProgressBar.Value = 0;
            tsbProgressText.Text = "0%";
            tsbProgressBar.ForeColor = Color.Blue;
        }
        #endregion

        private string ImportBrowserContent()
        {
            string doctext = "";

            HtmlElementCollection hmtlElColl = webBrowser.Document.All;

            try
            {
                if (startnavigationAddress.Contains("ungdom.php"))
                {
                    doctext = webBrowser.Document.Body.InnerHtml;
                }
                else
                {
                    doctext = webBrowser.DocumentText;
                }
            }
            catch (FileNotFoundException)
            {
                doctext = "";
            }

            if (doctext == "")
            {
                foreach (HtmlElement hel in webBrowser.Document.All)
                {
                    if (hel.InnerHtml != null)
                        doctext += hel.InnerHtml;
                }
            }

            string page = doctext;

            SaveImportedFile(page, webBrowser.Url);

            isDirty = true;

            return page;
        }

        private void SaveImportedFile(string page, Uri url)
        {
            // Check the existence of the folder
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.ApplicationFolder, "ImportedPages"));
            if (!di.Exists)
            {
                di.Create();
            }

            string filename = url.PathAndQuery.Replace(".php", "").Replace("/", "").Replace("?", "!");

            if (filename.Contains("kampid"))
            {
                filename += ".htm";
            }
            else if (filename.Contains("klubhus_squad"))
            {
                string filedate = TmWeek.thisWeek().absweek.ToString();
                filename += "_" + filedate + ".htm";
            }
            else if (filename.Contains("showstadium"))
            {
                string filedate = TmWeek.thisWeek().absweek.ToString() + "_" +
                    DateTime.Now.Year.ToString();
                filename += "_" + filedate + ".htm";
            }
            else
            {
                string filedate = TmWeek.ToSWDString(DateTime.Now);

                filename += "_" + filedate + ".htm";
            }

            FileInfo fi = new FileInfo(Path.Combine(di.FullName, filename));

            StreamWriter file = new StreamWriter(fi.FullName);
            file.Write(page);
            file.Close();
        }

        private void ScoutSeriesForm_Load(object sender, EventArgs e)
        {
            LoadDb();
        }

        private void LoadDb()
        {
            string datafile = Path.Combine(Program.Setts.ApplicationFolder, Program.Setts.LastFilename);

            FileInfo fi = new FileInfo(datafile);

            if (fi.Exists)
                scoutseriesDS.ReadXml(datafile);
        }

        private void loadDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete actual data and reload DB from file?",
                "Injuries Scanner", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                scoutseriesDS.Clear();

                LoadDb();
            }
        }

        private void saveDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void ScoutSeriesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDirty)
            {
                DialogResult dr = MessageBox.Show("Save the modified database?", "League Scanner", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    Save();
                }
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }


        private void Save()
        {
            scoutseriesDS.WriteXml(Path.Combine(Program.Setts.ApplicationFolder, Program.Setts.LastFilename));
            isDirty = false;
        }

        private void clearDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete actual data from the DB?",
                "Injuries Scanner", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                scoutseriesDS.Clear();
            }
        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
            actualStatus = State.NavigationStart; 
            ScanAllLeagues();
        }

        private void copyTeamTableInExcelFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strToCopy = "";
            foreach (ScoutSeriesDS.SquadRow srr in scoutseriesDS.Squad.Rows)
            {
                strToCopy += srr.TeamID + "\t";
                strToCopy += srr.League + "\t";
                strToCopy += srr.Name + "\t";
                strToCopy += srr.Matches + "\t";
                strToCopy += srr.TotalInjuriesWeeks + "\t";
                strToCopy += srr.TotalInjuries + "\t";
                strToCopy += srr.MedCenter + "\t";
                strToCopy += srr.PhysioRoom + "\t";
                strToCopy += srr.Dreinage + "\t";
                strToCopy += srr.PitchCovers + "\t";
                strToCopy += srr.Sprinklers + "\t";
                strToCopy += srr.Heating + "\t";
                strToCopy += "\n";
            }

            strToCopy = strToCopy.TrimEnd('\n');

            Clipboard.SetText(strToCopy);
        }
    }
}
