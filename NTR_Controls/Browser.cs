using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using System.IO;

namespace NTR_Controls
{
    class Browser
    {
        public class Pages
        {
            public const string Home = "http://trophymanager.com/";
            public const string AdobeFlashplayer = "http://www.adobe.com/products/flashplayer/";
            public const string Club = "http://trophymanager.com/club/";
            public const string Trainers = "http://trophymanager.com/coaches/";
        }

        public class Content
        {
            public int TeamID;

            public string ClubName { get; set; }

            public string DocText { get; set; }
        }

        string navigationAddress = "";
        string startnavigationAddress = "";
        private WebBrowser webBrowser;
        public string DefaultDirectory { get; set; }

        public Browser(WebBrowser webBrowser)
        {
            this.webBrowser = webBrowser;
        }

        internal void Goto(string address)
        {
            navigationAddress = address;
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        internal void GoForward()
        {
            webBrowser.GoForward();
        }

        internal void GoBack()
        {
            webBrowser.GoBack();
        }


        internal Content Import()
        {
            string doctext = "";

            if (!startnavigationAddress.StartsWith("http://trophymanager.com/"))
                return null;

            if (startnavigationAddress.StartsWith("http://trophymanager.com/buy-pro/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/forum/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/club/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/league/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/fixtures/league/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/home/"))
            {
                MessageBox.Show("This page cannot be imported in TmRecorder");
                return null;
            }

            if (startnavigationAddress.StartsWith("http://trophymanager.com/players/"))
            {
                string str = HTML_Parser.GetNumberAfter(startnavigationAddress, "players/");
                if (str != "-1")
                {
                    MessageBox.Show("This page has to be imported in the Player Info Panel");
                    return null;
                }
            }

            Content returnedContent = new Content();

            // Read the browser content to extract the TeamID and the Team name
            doctext = webBrowser.DocumentText;
            int actualTeamId = 0;
            string actTeamIdString = HTML_Parser.GetNumberAfter(doctext, "SESSION[\"id\"] = ");
            int.TryParse(actTeamIdString, out actualTeamId);

            returnedContent.TeamID = actualTeamId;
            returnedContent.ClubName = HTML_Parser.GetField(doctext, "SESSION[\"clubname\"] = '", "';");
            returnedContent.DocText = "";

            try
            {
                doctext = GetWebBrowserContent(startnavigationAddress);
            }
            catch (Exception ex)
            {
                doctext = "Exception error:\nWeb Site: " + startnavigationAddress + "\nException: " + ex.Message;
            }

            returnedContent.DocText = doctext;

            if (doctext.Contains("Javascript error: data doesn't exists"))
            {
                return returnedContent;
            }

            string page = "";

            if (doctext.StartsWith("Exception error") || doctext.StartsWith("GBC error") || doctext.Contains("Javascript error"))
            {
                return returnedContent;
            }

            page = startnavigationAddress + "\n" + doctext;

            if (page.Contains("You are not logged in"))
            {
                MessageBox.Show("You are not logged in. Please, login");
                return null;
            }

            if (startnavigationAddress.Contains("tactics.php"))
                return null;

            if (startnavigationAddress.Contains("squad.php?reserves"))
                page = "SourceURL:<TM - Squad - Reserves>\n" + page;
            else if (startnavigationAddress.Contains("players/"))
                page = "SourceURL:<NewTM - Squad>\n" + page;
            else if (startnavigationAddress.Contains("training-overview/advanced/"))
                page = "SourceURL:<NewTM - Training>\n" + page;
            else if (startnavigationAddress.Contains("training_new.php"))
                page = "SourceURL:<TM - Training_new>\n" + page;
            else if (startnavigationAddress.Contains("squad.php?reserves"))
                page = "SourceURL:<TM - Squad - Reserves>\n" + page;
            else if (startnavigationAddress.Contains("squad.php"))
                page = "SourceURL:<TM - Squad>\n" + page;
            else if (startnavigationAddress.Contains("training.php"))
                page = "SourceURL:<TM - Training>\n" + page;
            else if (startnavigationAddress.Contains("training/"))
                page = "SourceURL:<NewTM - TrainingNew>\n" + page;
            else if (startnavigationAddress.Contains("training_new.php"))
                page = "SourceURL:<TM - Training_new>\n" + page;
            else if (startnavigationAddress.Contains("matches.php"))
                page = "SourceURL:<TM - Matches>\n" + page;
            else if (startnavigationAddress.Contains("/fixtures/club/"))
                page = "SourceURL:<NewTM - Matches>\n" + page;
            else if (startnavigationAddress.Contains("kamp.php"))
                page = "SourceURL:<TM - Kamp>\n" + page;
            else if (startnavigationAddress.Contains("/matches/"))
                page = "SourceURL:<NewTM - Kamp>\n" + page;
            else if (startnavigationAddress.Contains("/trophymanager.com/scouts/"))
                page = "SourceURL:<NewTM - Scouts>\n" + page;
            else if (startnavigationAddress.Contains("showprofile.php?playerid="))
                page = "SourceURL:<TM - Player>\n" + page;
            else if (startnavigationAddress.Contains("staff_trainers.php"))
                page = "SourceURL:<TM - Staff_trainers>\n" + page;
            else if (startnavigationAddress.Contains("coaches/"))
                page = "SourceURL:<NewTM - Staff_trainers>\n" + page;
            else
            {
                if (startnavigationAddress.Contains("index.php"))
                {
                    MessageBox.Show("I'm sorry, but the Trophy Manager home page cannot be imported in TmRecorder. You think it could be useful? Contact me at led.lennon@gmail.com");
                    return null;
                }

                if (startnavigationAddress.Contains("klubhus.php"))
                {
                    MessageBox.Show("I'm sorry, but the club house page cannot be imported in TmRecorder. You think it could be useful? Contact me at led.lennon@gmail.com");
                    return null;
                }

                if (startnavigationAddress.Contains("shortlist.php"))
                {
                    MessageBox.Show("I'm sorry, but the shortlist page cannot be imported in TmRecorder. You think it could be useful? Contact me at led.lennon@gmail.com");
                    return null;
                }

                if (startnavigationAddress.Contains("live_prematch.php"))
                {
                    MessageBox.Show("I'm sorry, this page cannot be imported now. Try once again to load this page.");
                    return null;
                }

                if (MessageBox.Show("Cannot import this page here. Here you can import only squad, training, calendar and matches.\n" +
                    "Pressing OK, you send a report to Atletico Granata that will try to detect the reason of the error.",
                    "Import error", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string swRelease = "Sw Release:" + Application.ProductName + "("
                       + Application.ProductVersion + ")";
                    page = "Navigation Address: " + startnavigationAddress + "\n" + page;
                    Exception ex = new Exception("Navigation error");
                    SendFileTo.ErrorReport.Send(ex, page, Environment.StackTrace, swRelease);
                }
                return null;
            }

            SaveImportedFile(page, webBrowser.Url);

            if ((!page.Contains("TM - Squad")) &&
                (!page.Contains("TM - Squad")) &&
                (!page.Contains("TM - Kamp")) &&
                (!page.Contains("TM - Training")) &&
                (!page.Contains("TM - Matches")) &&
                (!page.Contains("TM - Training_new")) &&
                (!page.Contains("TM - Scouts")) &&
                (!page.Contains("TM - Player")) &&
                (!page.Contains("TM - Staff_trainers")))
            {
                return null;
            }

            LoadHTMLfile_newPage(page);

            ChampDS.MatchRow cmr = champDS.Match.FindByMatchID(lastBarMatch);
            tsBrowseMatches.Visible = (cmr != null) && (startnavigationAddress.Contains("kamp.php"));

            if (cmr != null)
            {
                if (cmr.Report == false)
                {
                    lblMatchStored.Text = "Match not stored";
                    lblMatchStored.ForeColor = Color.Red;
                }
                else
                {
                    lblMatchStored.Text = "Match stored";
                    lblMatchStored.ForeColor = Color.Green;
                }
            }

            champDS.UpdateSeason(cmbSeason);

            UpdateBrowserImportPanel();
        }

        private void LoadHTMLfile_newPage(string page)
        {
            if (page.Contains("Navigation Address: http://trophymanager.com/players/"))
            {
                string[] stringSeparators = new string[] { "\n\r\n" };
                string[] pages = page.Split(stringSeparators, StringSplitOptions.None);

                if (pages.Length < 2)
                {
                    string swRelease = "Sw Release:" + Application.ProductName + "("  + Application.ProductVersion + ")";
                    page = "Navigation Address: " + startnavigationAddress + "\n" + page;

                    string message = "Error retrieving data from the players page";
                    SendFileTo.ErrorReport.SendPage(message, page, Environment.StackTrace, swRelease);
                }
                else
                {
                    History.LoadSquad_NewTm(dt, pages[0]);
                    History.LoadTraining_NewTM2(dt, pages[1]);
                }
            }
        }

        internal void LoadSquad_NewTm(DateTime dt, string squad)
        {
            string originalSquadString = squad;
            Db_TrophyDataSet db_TrophyDataSet = null;
            short isReserves = 0;
            int player = 0;

            try
            {
                if (Program.Setts.MainSquadID <= 0)
                {
                    int Id = 0;
                    int.TryParse(HTML_Parser.GetNumberAfter(originalSquadString, "A_team="), out Id);
                    Program.Setts.MainSquadID = Id;
                    Program.Setts.Save();
                }
                if (Program.Setts.ReserveSquadID <= 0)
                {
                    int Id = 0;
                    int.TryParse(HTML_Parser.GetNumberAfter(originalSquadString, "B_team="), out Id);
                    Program.Setts.ReserveSquadID = Id;
                    Program.Setts.Save();
                }

                // squad = HTML_Parser.ConvertHTML_Text(squad);
                squad = HTML_Parser.ConvertUnicodes_Text(squad);
                squad = HTML_Parser.ConvertUnicodes_MoreText(squad);

                db_TrophyDataSet = new Db_TrophyDataSet();
                db_TrophyDataSet.Date = dt;
                db_TrophyDataSet.Giocatori.Clear();
                db_TrophyDataSet.Portieri.Clear();

                string[] plRows = squad.Split('\n');

                // Row 0 is the table header
                for (player = 0; player < plRows.Length; player++)
                {
                    if (!plRows[player].Contains("id=")) continue;

                    if (plRows[player].Contains("fp=GK"))
                    {
                        Db_TrophyDataSet.PortieriRow row = (Db_TrophyDataSet.PortieriRow)db_TrophyDataSet.Portieri.NewRow();

                        string strrow = plRows[player].Trim(';');
                        TM_Parser.ParseGK_NewTM(ref row, strrow);

                        if (row != null)
                            db_TrophyDataSet.Portieri.AddPortieriRow(row);
                    }
                    else
                    {
                        Db_TrophyDataSet.GiocatoriRow row = (Db_TrophyDataSet.GiocatoriRow)db_TrophyDataSet.Giocatori.NewRow();

                        string strrow = plRows[player].Trim(';');
                        TM_Parser.ParsePlayer_NewTM(ref row, strrow);

                        if (row != null)
                            db_TrophyDataSet.Giocatori.AddGiocatoriRow(row);
                    }
                }

                // Aggiunge i dati alla history
                AddData_NewTM(db_TrophyDataSet);

                // Aggiunge i dati alle extra info
                if (PlayersDS == null) PlayersDS = new ExtraDS();
                PlayersDS.AddPlyrDataFromTDS_NewTM(db_TrophyDataSet);
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string info = "";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(Program.Setts.TeamDataFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                PlayersDS.WriteXml(fi.FullName);

                StreamReader file = new StreamReader(fi.FullName);
                info += "PlayersDS:\r\n" + file.ReadToEnd();
                file.Close();

                db_TrophyDataSet.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "TDS:\r\n" + file.ReadToEnd();
                file.Close();

                info += "isReserves:" + isReserves.ToString();
                info += "player:" + player.ToString();
                info += "Squad:" + originalSquadString;

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        private string GetWebBrowserContent(string startnavigationAddress)
        {
            string doctext = "";

            //if ((startnavigationAddress.Contains("showprofile.php?playerid=")))
            //{
            //    doctext = webBrowser.Document.Body.InnerHtml;
            //}
            //else 
            if (startnavigationAddress.Contains("/matches/"))
            {
                doctext = Import_Matches_Adv();
                if ((doctext == "") || (doctext == null))
                {
                    if (doctext == null)
                        doctext = "GBC error: failed importing players  (text is null)";
                    else
                        doctext = "GBC error: failed importing players  (text is empty)";

                    FileInfo fi = new FileInfo(Program.Setts.DatafilePath + "\\match_loader.js");
                    if (!fi.Exists)
                    {
                        doctext += "\nThe js does not exists in " + Program.Setts.DatafilePath;
                    }
                    else
                    {
                        doctext += "\nJs content (in " + Program.Setts.DatafilePath + "): \n";
                        doctext += System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\match_loader.js");
                    }
                    doctext += "\n";
                }
            }
            else if (startnavigationAddress.Contains("/players/#") || startnavigationAddress.EndsWith("/players/"))
            {
                doctext = Import_Players_Adv();
                if ((doctext == "") || (doctext == null))
                {
                    if (doctext == null)
                        doctext = "GBC error: failed importing players  (text is null)";
                    else
                        doctext = "GBC error: failed importing players  (text is empty)";

                    FileInfo fi = new FileInfo(Program.Setts.DatafilePath + "\\players_loader.js");
                    if (!fi.Exists)
                    {
                        doctext += "\nThe js does not exists in " + Program.Setts.DatafilePath;
                    }
                    else
                    {
                        doctext += "\nJs content (in " + Program.Setts.DatafilePath + "): \n";
                        doctext += System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\players_loader.js");
                    }
                    doctext += "\n";
                }

                string training_doctext = Import_Players_Training_Adv();
                if ((training_doctext == "") || (training_doctext == null))
                {
                    if (training_doctext == null)
                        training_doctext = "GBC error: failed importing players training  (text is null)";
                    else
                        training_doctext = "GBC error: failed importing players training  (text is empty)";

                    FileInfo fi = new FileInfo(Program.Setts.DatafilePath + "\\get_players_training_loader.js");
                    if (!fi.Exists)
                    {
                        training_doctext += "\nThe js does not exists in " + Program.Setts.DatafilePath;
                    }
                    else
                    {
                        training_doctext += "\nJs content (in " + Program.Setts.DatafilePath + "): \n";
                        training_doctext += System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\get_players_training_loader.js");
                    }
                    training_doctext += "\n";
                }

                doctext += "\n\r\n" + training_doctext;
            }
            //else if (startnavigationAddress.Contains("/players/"))
            //{
            //    doctext = Import_Player_Adv();
            //}
            else if (startnavigationAddress.Contains("/fixtures/club/"))
            {
                doctext = Import_Fixtures_Adv();
                if ((doctext == "") || (doctext == null))
                {
                    if (doctext == null)
                        doctext = "GBC error: failed importing players  (text is null)";
                    else
                        doctext = "GBC error: failed importing players  (text is empty)";

                    FileInfo fi = new FileInfo(Program.Setts.DatafilePath + "\\fixture_loader.js");
                    if (!fi.Exists)
                    {
                        doctext += "\nThe js does not exists in " + Program.Setts.DatafilePath;
                    }
                    else
                    {
                        doctext += "\nJs content (in " + Program.Setts.DatafilePath + "): \n";
                        doctext += System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\fixture_loader.js");
                    }
                    doctext += "\n";
                }
            }
            else if (startnavigationAddress.Contains("/training/"))
            {
                doctext = Import_Training();
                if ((doctext == "") || (doctext == null))
                {
                    if (doctext == null)
                        doctext = "GBC error: failed importing training  (text is null)";
                    else
                        doctext = "GBC error: failed importing training  (text is empty)";

                    FileInfo fi = new FileInfo(Program.Setts.DatafilePath + "\\training_loader.js");
                    if (!fi.Exists)
                    {
                        doctext += "\nThe js does not exists in " + Program.Setts.DatafilePath;
                    }
                    else
                    {
                        doctext += "\nJs content (in " + Program.Setts.DatafilePath + "): \n";
                        doctext += System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\training_loader.js");
                    }
                    doctext += "\n";
                }
            }
            else
            {
                doctext = "Doc Text: \n" + webBrowser.DocumentText;
            }

            return doctext;
        }

        private string Import_Players_Training_Adv()
        {
            string pl_data = "";

            if (false) // (!CheckLicense("Import_Players_Training_Adv"))
            {
                pl_data = "License not valid";
                return pl_data;
            }

            try
            {
                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                element.text = System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\get_players_training_loader.js");
                HtmlElement res = head.AppendChild(scriptEl);
                pl_data = (string)webBrowser.Document.InvokeScript("get_players_training");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private string Import_Players_Adv()
        {
            string pl_data = "";

            try
            {
                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                element.text = System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\players_loader.js");
                HtmlElement res = head.AppendChild(scriptEl);
                pl_data = (string)webBrowser.Document.InvokeScript("get_players");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private string Import_Player_Adv()
        {
            string pl_data = "";

            try
            {
                object doc = webBrowser.Document.DomDocument;
                doctext = webBrowser.Document.Body.InnerHtml;

                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
                return pl_data;

                element.text = System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\player_info_loader.js");
                HtmlElement res = head.AppendChild(scriptEl);
                pl_data = (string)webBrowser.Document.InvokeScript("get_player_info");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private string Import_Matches_Adv()
        {
            string matches_data = "";

            try
            {
                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                element.text = System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\match_loader.js");
                HtmlElement res = head.AppendChild(scriptEl);
                string lineup = (string)webBrowser.Document.InvokeScript("get_lineup");
                string match_info = (string)webBrowser.Document.InvokeScript("get_match_info");
                string report = (string)webBrowser.Document.InvokeScript("get_report");

                matches_data = "<TABLE>" + lineup + "</TABLE>" +
                    "<TABLE>" + match_info + "</TABLE>" +
                    "<TABLE>" + report + "</TABLE>";

                if (matches_data.Contains("Javascript error"))
                {
                    //MessageBox.Show("Error executing java scripts");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return matches_data;
        }

        private string Import_Fixtures_Adv()
        {
            string fix_data = "";

            try
            {
                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                element.text = System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\fixture_loader.js");
                HtmlElement res = head.AppendChild(scriptEl);
                fix_data = (string)webBrowser.Document.InvokeScript("get_fixture");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return fix_data;
        }

        private string Import_Training()
        {
            string fix_data = "";

            try
            {
                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                element.text = System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\training_loader.js");
                HtmlElement res = head.AppendChild(scriptEl);
                fix_data = (string)webBrowser.Document.InvokeScript("get_training");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return fix_data;
        }

        /// <summary>
        /// Save imported file
        /// </summary>
        /// <param name="page"></param>
        /// <param name="url"></param>
        private void SaveImportedFile(string page, Uri url)
        {
            // Check the existence of the folder
            DirectoryInfo di = new DirectoryInfo(Path.Combine(DefaultDirectory, "ImportedPages"));
            if (!di.Exists)
            {
                di.Create();
            }

            string filedate = TmWeek.ToSWDString(DateTime.Now);

            string filename = "NF-" + url.LocalPath.Replace(".php", "").Replace("/", "");

            if (filename == "kamp")
            {
                string kampid = HTML_Parser.GetField(webBrowser.Url.Query, "=", ",");
                filename += "_" + kampid + ".2.htm";
            }
            else if (filename == "matches")
            {
                if (url.ToString().Contains(Program.Setts.ReserveSquadID.ToString()))
                {
                    filename += "-res-" + TmWeek.GetSeason(DateTime.Now).ToString() + ".2.htm";
                }
                else
                    filename += "-" + TmWeek.GetSeason(DateTime.Now).ToString() + ".2.htm";
            }
            else if (filename == "players")
            {
                if (webBrowser.Url.ToString().Contains("reserves"))
                {
                    filename += "-res-" + filedate + ".2.htm";
                }
                else
                    filename += "-" + filedate + ".2.htm";
            }
            else if (filename == "showprofile")
            {
                string playerid = HTML_Parser.GetNumberAfter(url.ToString(), "playerid=");
                filename += "-" + playerid + "-" + filedate + ".2.htm";
            }
            else
            {
                filename += "-" + filedate + ".2.htm";
            }

            FileInfo fi = new FileInfo(Path.Combine(di.FullName, filename));

            StreamWriter file = new StreamWriter(fi.FullName);
            file.Write(page);
            file.Close();
        }
    }
}
