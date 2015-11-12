using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NTR_Db;
using Gecko;
using NTR_Controls.Properties;
using System.IO;
using Common;

namespace NTR_Controls
{
    public delegate void ImportedContentHandler(Content content);

    public partial class NTR_Browser : UserControl
    {
        public class Pages
        {
            public const string Home = "http://trophymanager.com/";
            public const string AdobeFlashplayer = "http://www.adobe.com/products/flashplayer/";
            public const string Club = "http://trophymanager.com/club/";
            public const string Trainers = "http://trophymanager.com/coaches/";
            public const string Players = "http://trophymanager.com/players/";
        }

        string navigationAddress = "";
        string startnavigationAddress = "";

        private string _defaultDirectory = "";
        public string DefaultDirectory
        {
            get { return _defaultDirectory; }
            set
            {
                _defaultDirectory = value;
            }
        }

        public NTR_Browser()
        {
            InitializeComponent();
        }

        public void SetXUL(string xulRunnerPath)
        {
            Gecko.Xpcom.Initialize(xulRunnerPath);
        }

        private void NTR_Browser_Load(object sender, EventArgs e)
        {
        }

        #region Navigation
        public void Goto(string address)
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
        #endregion

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            GoForward();
        }

        private void gotoTmHome_Click(object sender, EventArgs e)
        {
            Goto(Pages.Home);
        }

        private void gotoAdobeFlashplayerPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Goto(Pages.AdobeFlashplayer);
        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            webBrowser.Reload();
        }

        #region Getting Browser Content functions
        private string GetHiddenBrowserContent(string startnavigationAddress)
        {
            string doctext = "";

            if (startnavigationAddress.Contains("/matches/"))
            {
                doctext = Import_Matches_Adv();
                if ((doctext == "") || (doctext == null))
                {
                    if (doctext == null)
                        doctext = "GBC error: failed importing players  (text is null)";
                    else
                        doctext = "GBC error: failed importing players  (text is empty)";

                    doctext += "\nJs content (in " + Resources.match_loader;

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

                    doctext += "\nJs content (in " + Resources.players_loader;

                    doctext += "\n";
                }

                string training_doctext = Import_Players_Training_Adv();
                if ((training_doctext == "") || (training_doctext == null))
                {
                    if (training_doctext == null)
                        training_doctext = "GBC error: failed importing players training  (text is null)";
                    else
                        training_doctext = "GBC error: failed importing players training  (text is empty)";

                    doctext += "\nJs content (in " + Resources.get_players_training_loader;

                    training_doctext += "\n";
                }

                doctext += "\n\r\n" + training_doctext;
            }
            else if (startnavigationAddress.Contains("/fixtures/club/"))
            {
                doctext = Import_Fixtures_Adv();
                if ((doctext == "") || (doctext == null))
                {
                    if (doctext == null)
                        doctext = "GBC error: failed importing players  (text is null)";
                    else
                        doctext = "GBC error: failed importing players  (text is empty)";


                    doctext += "\nJs content (in " + Resources.fixture_loader;

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


                    doctext += "\nJs content (in " + Resources.training_loader;

                    doctext += "\n";
                }
            }
            else
            {
                doctext = "Doc Text: \n" + webBrowser.Document.TextContent;
            }

            return doctext;
        }

        private string Import_Players_Training_Adv()
        {
            string pl_data = "";

            try
            {
                using (AutoJSContext java = new AutoJSContext(webBrowser.Window.JSContext))
                {
                    string result;
                    if (!java.EvaluateScript(Resources.get_players_training_loader,
                        (nsISupports)webBrowser.Window.DomWindow,
                        out result))
                    {
                        pl_data = result;
                    }
                }

                pl_data = AppendScriptAndExecute(Resources.get_players_training_loader,
                                                "get_players_training()");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private string AppendScriptAndExecute(string script, string command)
        {
            AppendScript(script);

            return ExecuteScript(command);
        }

        private GeckoNode AppendScript(string script)
        {
            GeckoElement scriptEl = webBrowser.Document.CreateElement("script");
            scriptEl.TextContent = script;
            GeckoNode res = webBrowser.Document.Head.AppendChild(scriptEl);

            return res;
        }

        private string ExecuteScript(string command)
        {
            string pl_data;

            using (var java = new AutoJSContext(webBrowser.Window.JSContext))
            {
                JsVal result = java.EvaluateScript(command, webBrowser.Window.DomWindow);
                pl_data = result.ToString();
            }

            return pl_data;
        }


        private string Import_Players_Adv()
        {
            string pl_data = "";

            try
            {
                pl_data = AppendScriptAndExecute(Resources.players_loader,
                                                "get_players()");
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
                pl_data = AppendScriptAndExecute(Resources.player_info_loader,
                                                "get_player_info()");
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
                AppendScript(Resources.player_info_loader);

                string lineup = ExecuteScript("get_lineup()");
                string match_info = ExecuteScript("get_match_info()");
                string report = ExecuteScript("get_report()");

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
                fix_data = AppendScriptAndExecute(Resources.fixture_loader,
                                                "get_fixture()");
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
                fix_data = AppendScriptAndExecute(Resources.training_loader,
                                                "get_training()");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return fix_data;
        }
        #endregion

        //internal Content Import(NTR_SquadDb.ActionsDecoderDataTable ActionsDecoderDT)
        //{
        //    string doctext = "";
        //    Content returnedContent = new Content();

        //    // Read the browser content to extract the TeamID and the Team name
        //    doctext = webBrowser.Document.TextContent;
        //    int actualTeamId = 0;
        //    string actTeamIdString = HTML_Parser.GetNumberAfter(doctext, "SESSION[\"id\"] = ");
        //    int.TryParse(actTeamIdString, out actualTeamId);

        //    returnedContent.TeamID = actualTeamId;
        //    returnedContent.ClubName = HTML_Parser.GetField(doctext, "SESSION[\"clubname\"] = '", "';");
        //    returnedContent.DocText = "";

        //    if (webBrowser.Url == null) return null;
        //    if ((!webBrowser.Url.OriginalString.Contains("http://trophymanager.com/players/")) &&
        //        (!webBrowser.Url.OriginalString.Contains("http://trophymanager.com/matches/")))
        //    {
        //        MessageBox.Show("Sorry, cannot import this page!", "TmRecorder");
        //        return null;
        //    }

        //    try
        //    {
        //        doctext = GetHiddenBrowserContent(webBrowser.Url.OriginalString);
        //    }
        //    catch (Exception ex)
        //    {
        //        doctext = "Exception error:\nWeb Site: " + startnavigationAddress + "\nException: " + ex.Message;
        //    }

        //    returnedContent.DocText = doctext;

        //    if (doctext.Contains("Javascript error: data doesn't exists"))
        //        return returnedContent;

        //    if (doctext.StartsWith("Exception error") || doctext.StartsWith("GBC error") || doctext.Contains("Javascript error"))
        //        return returnedContent;

        //    string page = webBrowser.Url + "\n" + doctext;

        //    if (page.Contains("You are not logged in"))
        //    {
        //        MessageBox.Show("You are not logged in. Please, login");
        //        return null;
        //    }

        //    SaveImportedFile(page, webBrowser.Url);

        //    // Initialize the datatable to parse the actual content and avoid to fill it again with
        //    // old values
        //    if (returnedContent.squadDB == null)
        //        returnedContent.squadDB = new NTR_SquadDb();
        //    if (ActionsDecoderDT != null)
        //        returnedContent.squadDB.ActionsDecoder.Merge(ActionsDecoderDT);

        //    returnedContent.ParsePage(page, webBrowser.Url.OriginalString);

        //    return returnedContent;
        //}

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
                // TODO: Find an unique way to save the match data
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

        private void webBrowser_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser_ProgressChanged(object sender, GeckoProgressEventArgs e)
        {
            if (e.CurrentProgress <= 0)
            {
                //if (theBrowser.ReadyState == WebBrowserReadyState.Complete)
                //{
                //    tsbProgressText.Text = "100%";
                //    tsbProgressBar.ForeColor = Color.Green;
                //    tsbProgressBar.Value = 100;
                //}
                return;
            }

            long maxProgress = e.MaximumProgress;
            if (maxProgress == 0)
                maxProgress = 1;
            int perc = (int)((e.CurrentProgress * 100) / maxProgress);
            if (perc > 100) perc = 100;
            if (perc < 0) perc = 0;
            tsbProgressBar.Value = perc;
            tsbProgressText.Text = perc.ToString() + "%";
            tsbProgressBar.ForeColor = Color.Blue;
        }
    }
}
