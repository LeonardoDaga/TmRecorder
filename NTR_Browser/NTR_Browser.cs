using System;
using System.Drawing;
using System.Windows.Forms;
using Gecko;
using NTR_WebBrowser.Properties;
using Common;
using System.IO;

namespace NTR_WebBrowser
{
    public delegate void ImportedContentHandler(string content, string address);

    public partial class NTR_Browser : UserControl
    {

        private string _defaultDirectory = "";
        public string DefaultDirectory
        {
            get { return _defaultDirectory; }
            set
            {
                _defaultDirectory = value;
            }
        }

        string _startnavigationAddress = "";
        public string StartnavigationAddress
        {
            get
            {
                return _startnavigationAddress;
            }

            set
            {
                _startnavigationAddress = value;
                tbTxtAddress.Text = _startnavigationAddress;
            }
        }

        string _navigationAddress = "";
        public string NavigationAddress
        {
            get
            {
                return _navigationAddress;
            }

            set
            {
                _navigationAddress = value;
            }
        }

        public bool XulInitialized { get; private set; }

        private GeckoWebBrowser webBrowser;

        public event ImportedContentHandler ImportedContent;

        public NTR_Browser()
        {
            InitializeComponent();

            if (!IsInDesignMode())
            {
                webBrowser = new GeckoWebBrowser();
                webBrowser.Location = new System.Drawing.Point(3, 41);
                webBrowser.Width = this.Width - 6;
                webBrowser.Height = this.Height - 44;
                webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
                this.webBrowser.Name = "webBrowser";
                this.webBrowser.UseHttpActivityObserver = false;
                this.webBrowser.DocumentCompleted += new System.EventHandler<Gecko.Events.GeckoDocumentCompletedEventArgs>(this.webBrowser_DocumentCompleted);
                this.webBrowser.ProgressChanged += new System.EventHandler<Gecko.GeckoProgressEventArgs>(this.webBrowser_ProgressChanged);
                this.webBrowser.Visible = true;
                this.Controls.Add(webBrowser);
            }
        }

        public static bool IsInDesignMode()
        {
            if (Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1)
            {
                return true;
            }
            return false;
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
            NavigationAddress = address;
            webBrowser.Navigate(NavigationAddress);
            StartnavigationAddress = NavigationAddress;
        }

        public string CheckXulInitialization(string xulRunnerPath)
        {
            if (!XulInitialized)
            {
                bool checkResult = CheckXulDir(xulRunnerPath);

                if (!checkResult)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.SelectedPath = xulRunnerPath;
                    fbd.Description = "Select the Folder where the XUL dll is located";
                    if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        xulRunnerPath = fbd.SelectedPath;
                        checkResult = CheckXulDir(xulRunnerPath);
                    }
                }

                if (!checkResult)
                {
                    MessageBox.Show("This application needs XUL, sorry");
                    return "";
                }

                if (checkResult)
                {
                    SetXUL(xulRunnerPath);
                    XulInitialized = true;
                }
            }

            return xulRunnerPath;
        }

        private bool CheckXulDir(string xulDir)
        {
            bool DialogResult = false;

            try
            {
                DirectoryInfo di = new DirectoryInfo(xulDir);
                if (di.Exists)
                {
                    FileInfo[] fis = di.GetFiles("xul.dll");
                    if (fis.Length == 0)
                    {
                        string message = string.Format("The folder {0} does not contain the xul DLL. Press OK to select another folder, otherwise press CANCEL to close the application.", xulDir)
                            + string.Format("\nIf you want to download XUL, see instructions in {0}", TM_Pages.TmrWebSiteXul);
                        if (MessageBox.Show(message, "XP and Linux versions need XUL!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                            DialogResult = true;
                    }
                    else
                        DialogResult = true;
                }
                else
                {
                    DialogResult = false;
                }
            }
            catch (Exception)
            {
                DialogResult = true;
            }

            return DialogResult;
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
            Goto(TM_Pages.Home);
        }

        private void gotoAdobeFlashplayerPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Goto(TM_Pages.AdobeFlashplayer);
        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
            string importedPage = GetHiddenBrowserContent();

            ImportedContent(importedPage, NavigationAddress);
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            webBrowser.Reload();
        }

        #region Getting Browser Content functions
        private string GetHiddenBrowserContent()
        {
            string doctext;

            if (StartnavigationAddress.Contains("/matches/"))
            {
                doctext = Import_Matches_Adv();
                if (string.IsNullOrEmpty(doctext))
                {
                    doctext = doctext == null ? "GBC error: failed importing players  (text is null)" : "GBC error: failed importing players  (text is empty)";

                    doctext += "\nJs content (in " + Resources.match_loader;

                    doctext += "\n";
                }
            }
            else if (StartnavigationAddress.Contains("/players/#") || StartnavigationAddress.EndsWith("/players/"))
            {
                doctext = Import_Players_Adv();
                if (string.IsNullOrEmpty(doctext))
                {
                    doctext = doctext == null ? "GBC error: failed importing players  (text is null)" : "GBC error: failed importing players  (text is empty)";

                    doctext += "\nJs content (in " + Resources.players_loader;

                    doctext += "\n";
                }

                string trainingDoctext = Import_Players_Training_Adv();
                if (string.IsNullOrEmpty(trainingDoctext))
                {
                    trainingDoctext = trainingDoctext == null ? "GBC error: failed importing players training  (text is null)" : "GBC error: failed importing players training  (text is empty)";

                    doctext += "\nJs content (in " + Resources.get_players_training_loader;

                    trainingDoctext += "\n";
                }

                doctext += "\n\r\n" + trainingDoctext;
            }
            else if (StartnavigationAddress.Contains("/fixtures/club/"))
            {
                doctext = Import_Fixtures_Adv();
                if (string.IsNullOrEmpty(doctext))
                {
                    doctext = doctext == null ? 
                        "GBC error: failed importing players  (text is null)" : 
                        "GBC error: failed importing players  (text is empty)";


                    doctext += "\nJs content (in " + Resources.fixture_loader;

                    doctext += "\n";
                }
            }
            else if (StartnavigationAddress.Contains("/training/"))
            {
                doctext = Import_Training();
                if (string.IsNullOrEmpty(doctext))
                {
                    doctext = doctext == null ? 
                        "GBC error: failed importing training  (text is null)" : 
                        "GBC error: failed importing training  (text is empty)";


                    doctext += "\nJs content (in " + Resources.training_loader;

                    doctext += "\n";
                }
            }
            else if (StartnavigationAddress.Contains("/scouts/"))
            {
                MessageBox.Show("The scouts data are imported automatically when you import the players data");
                doctext = "Doc Text: \nScouts data not imported";
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

        private void AppendScript(string script)
        {
            GeckoElement scriptEl = webBrowser.Document.CreateElement("script");
            scriptEl.TextContent = script;
            webBrowser.Document.Head.AppendChild(scriptEl);
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
                AppendScript(Resources.match_loader);

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

        ///// <summary>
        ///// Save imported file
        ///// </summary>
        ///// <param name="page"></param>
        ///// <param name="url"></param>
        //private void SaveImportedFile(string page, Uri url)
        //{
        //    // Check the existence of the folder
        //    DirectoryInfo di = new DirectoryInfo(Path.Combine(DefaultDirectory, "ImportedPages"));
        //    if (!di.Exists)
        //    {
        //        di.Create();
        //    }

        //    string filedate = TmWeek.ToSWDString(DateTime.Now);

        //    string filename = "NF-" + url.LocalPath.Replace(".php", "").Replace("/", "");

        //    if (filename == "kamp")
        //    {
        //        string kampid = HTML_Parser.GetField(webBrowser.Url.Query, "=", ",");
        //        filename += "_" + kampid + ".2.htm";
        //    }
        //    else if (filename == "matches")
        //    {
        //        filename += "-" + TmWeek.GetSeason(DateTime.Now) + ".2.htm";
        //    }
        //    else if (filename == "players")
        //    {
        //        if (webBrowser.Url.ToString().Contains("reserves"))
        //        {
        //            filename += "-res-" + filedate + ".2.htm";
        //        }
        //        else
        //            filename += "-" + filedate + ".2.htm";
        //    }
        //    else if (filename == "showprofile")
        //    {
        //        string playerid = HTML_Parser.GetNumberAfter(url.ToString(), "playerid=");
        //        filename += "-" + playerid + "-" + filedate + ".2.htm";
        //    }
        //    else
        //    {
        //        filename += "-" + filedate + ".2.htm";
        //    }

        //    FileInfo fi = new FileInfo(Path.Combine(di.FullName, filename));

        //    StreamWriter file = new StreamWriter(fi.FullName);
        //    file.Write(page);
        //    file.Close();
        //}

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
            tsbProgressText.Text = perc + "%";
            tsbProgressBar.ForeColor = Color.Blue;
        }

        private void Login(string username, string password)
        {
            try
            {
                string function =
                    "function club_login(){" +
                    "var type; var captcha;" +
                    "$.post(\"/ajax/login.ajax.php\", " +
                    "{" +
                    "\"type\": type," +
                    "\"user\": \"" + username + "\"," +
                    "\"password\": \"" + password + "\"," +
                    "\"remember\": 1, " +
                    "\"captcha\": captcha}," +
                    "function(data) { if (data != null) { if (data[\"success\"])" +
                    " page_refresh(); } }, \"json\");}";

                AppendScriptAndExecute(function,
                                       "club_login()");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeTeam_Adv(string id)
        {
            try
            {
                string function =
                    "function club_int_change(){$.post(\"/ajax/club_change.ajax.php\", {\"change\": " +
                    "\"club\",\"club_id\": " + id + "}, function(data) { if (data != null) { if (data[\"success\"])" +
                    " page_refresh(); } }, \"json\");}";

                AppendScriptAndExecute(function,
                                       "club_int_change()");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void loginTrophyManagercomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
                Login(loginForm.UserName, loginForm.Password);
        }
    }
}
