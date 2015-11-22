using System;
using System.Drawing;
using System.Windows.Forms;
using Gecko;
using NTR_WebBrowser.Properties;
using Common;
using System.IO;
using System.Collections.Generic;

namespace NTR_WebBrowser
{
    public delegate void ImportedContentHandler(string content, string address);

    public partial class NTR_Browser : UserControl
    {
        public enum eNavigationMode
        {
            Main,
            Players,
        };


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

                if (_startnavigationAddress.Contains(TM_Pages.Players))
                {
                    int playerID = 0;
                    string number = HTML_Parser.GetNumberAfter(_startnavigationAddress, TM_Pages.Players);
                    if (int.TryParse(number, out playerID))
                        ActualPlayerID = playerID;
                    NavigationMode = eNavigationMode.Players;
                }
                else
                    NavigationMode = eNavigationMode.Main;
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

        public eNavigationMode _navigationMode = eNavigationMode.Main;
        public eNavigationMode NavigationMode
        {
            get
            {
                return _navigationMode;
            }

            set
            {
                if (value != _navigationMode)
                {
                    switch(value)
                    {
                        case eNavigationMode.Main:
                            tsbPlayersNavigationType.Visible = false;
                            break;
                        case eNavigationMode.Players:
                            tsbPlayersNavigationType.Visible = true;
                            break;
                    }

                    _navigationMode = value;
                }
            }
        }

        public int ActualPlayerID { get; private set; }
        public ReportParser SelectedReportParser { get; set; }

        private GeckoWebBrowser webBrowser;

        public event ImportedContentHandler ImportedContent;

        public NTR_Browser()
        {
            InitializeComponent();

            if (!IsInDesignMode())
            {
                webBrowser = new GeckoWebBrowser();
                webBrowser.Location = new System.Drawing.Point(3, 54);
                webBrowser.Width = this.Width - 6;
                webBrowser.Height = this.Height - 44;
                webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
                this.webBrowser.Name = "webBrowser";
                this.webBrowser.UseHttpActivityObserver = false;
                this.webBrowser.DocumentCompleted += new System.EventHandler<Gecko.Events.GeckoDocumentCompletedEventArgs>(this.webBrowser_DocumentCompleted);
                this.webBrowser.ProgressChanged += new System.EventHandler<Gecko.GeckoProgressEventArgs>(this.webBrowser_ProgressChanged);
                this.webBrowser.Navigating += WebBrowser_Navigating;
                this.webBrowser.WindowClosed += WebBrowser_WindowClosed;
                this.webBrowser.Visible = true;
                this.Controls.Add(webBrowser);
            }
        }

        private void WebBrowser_WindowClosed(object sender, EventArgs e)
        {
            //webBrowser.Stop();
            //webBrowser.Dispose();            
        }

        private void WebBrowser_Navigating(object sender, Gecko.Events.GeckoNavigatingEventArgs e)
        {
            string address = e.Uri.AbsoluteUri;

            if ((address.Contains(TM_Pages.Players)) && (address != StartnavigationAddress))
            {
                int playerID = 0;
                string number = HTML_Parser.GetNumberAfter(address, TM_Pages.Players);
                if (int.TryParse(number, out playerID))
                {
                    if (playerID != ActualPlayerID)
                    {
                        webBrowser.Stop();
                        GotoPlayer(playerID, this.navigationType);
                    }
                }
            }

            NavigationAddress = address;
            StartnavigationAddress = address;
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
            NavigationMode = eNavigationMode.Main;
        }

        #region Navigation
        public void Goto(string address)
        {
            NavigationAddress = address;
            webBrowser.Navigate(NavigationAddress);
            StartnavigationAddress = NavigationAddress;
        }

        public bool CheckXulInitialization()
        {
            string xulRunnerPath = Properties.Settings.Default.xulRunnerPath;

            if (!XulInitialized)
            {
                bool xulFound = CheckXulDir(xulRunnerPath);

                if (!xulFound)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.SelectedPath = xulRunnerPath;
                    fbd.Description = "Select the Folder where the XUL dll is located";
                    if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        xulRunnerPath = fbd.SelectedPath;
                        xulFound = CheckXulDir(xulRunnerPath);
                    }
                }

                if (!xulFound)
                {
                    MessageBox.Show("This application needs XUL, sorry");
                    return false;
                }

                if (xulFound)
                {
                    SetXUL(xulRunnerPath);
                    XulInitialized = true;
                }
            }

            if (xulRunnerPath != Properties.Settings.Default.xulRunnerPath)
            {
                Properties.Settings.Default.xulRunnerPath = xulRunnerPath;
                Properties.Settings.Default.Save();
            }

            return true;
        }

        private bool CheckXulDir(string xulDir)
        {
            bool xulFound = false;

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
                            xulFound = false;
                    }
                    else
                        xulFound = true;
                }
                else
                {
                    xulFound = false;
                }
            }
            catch (Exception)
            {
                xulFound = false;
            }

            return xulFound;
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
            else if ((StartnavigationAddress.Contains(TM_Pages.Players)) && (ActualPlayerID != 0))
            {
                doctext = Import_Player_Document_Content();
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

        private string Import_Player_Document_Content()
        {
            string resultBase = ParsePlayerPage(webBrowser.Document);
            string resultExtra = ParsePlayerPage_Extras(webBrowser.Document);

            return resultExtra;
        }

        public string ParsePlayerPage_Extras(GeckoDocument htmlDocument)
        {
            GeckoElement hidden = htmlDocument.GetElementById("hidden_skill_table");
            var element = hidden.GetElementsByTagName("td");

            string result = "";

            for (var i = 0; i < 4; i++)
            {
                string tooltip = element[i].GetAttribute("tooltip");

                if (tooltip == "")
                    return "";

                string field = HTML_Parser.GetField(tooltip, "<strong>", "/");

                int val = int.Parse(field);

                switch (i)
                {
                    case 0: result += ";InjPron=" + val; break;
                    case 1: result += ";Aggressivity=" + val; break;
                    case 2: result += ";Professionalism=" + val; break;
                    case 3: result += ";Ada=" + val; break;
                }
            }

            return result;
        }

        public string ParsePlayerPage(GeckoDocument htmlDocument)
        {
            GeckoElement element = htmlDocument.GetElementById("player_scout_new");
            var elementCollection = element.GetElementsByTagName("tr");

            string result = "";
            string page = htmlDocument.TextContent;

            // Import only the report to analyze it
            string str = HTML_Parser.CutBefore(page, "player_scout_new");

            if (SelectedReportParser == null)
            {
                MessageBox.Show("Please select the Scout Report parser before");
                return "";
            }

            int i = 0;
            if (page.Contains("active_tab\" id=\"tabplayer_scout_new"))
            {
                string ScoutName = "";
                string ScoutDate = "";
                string ScoutVoto = "";
                string ScoutGiudizio = "";
                int FPn = 0;

                foreach (var child in element.ChildNodes)
                {
                    if (child.TextContent.Contains("report_header"))
                    {
                        HtmlElementCollection div = null; //  child.GetElementsByTagName("div");

                        ScoutName += HTML_Parser.GetTag(div[0].InnerHtml, "strong") + "|";

                        string date = HTML_Parser.GetTag(div[0].InnerHtml, "span").TrimStart('(').TrimEnd(')');
                        DateTime dt = DateTime.Parse(date);
                        ScoutDate += TmWeek.ToSWDString(dt) + "|";

                        string age = HTML_Parser.GetFirstNumberInString(div[2].InnerText);

                        string giudizio = "";
                        giudizio += "Age=" + age + ";";

                        int blooming_status = 0;
                        int blooming = 0;
                        int dev_status = 0;
                        int speciality = 0;
                        int physique = 0;
                        int technics = 0;
                        int tactics = 0;
                        int professionalism = 0;
                        int leadership = 0;
                        int aggressivity = 0;
                        int potential = 0;

                        string field = div[3].InnerText;
                        if (field.Contains(SelectedReportParser.Dict["Keys"][(int)ReportParser.Keys.Potential]))
                        {
                            // It's the potential
                            string potential_string = HTML_Parser.GetFirstNumberInString(field);
                            giudizio += "Pot=" + potential_string + ";";

                            ScoutVoto += potential_string + "|";
                        }
                        else
                        {
                            string message = string.Format("Cannot translate Scout reports: check if your language is properly configured in the options. Filename used: {0}",
                                SelectedReportParser.UsedFilename);
                            MessageBox.Show(message);
                            return "";
                        }

                        if (div.Count > 5)
                        {
                            field = div[4].InnerText;
                            if (field.Contains(SelectedReportParser.Dict["Keys"][(int)ReportParser.Keys.BloomStatus]))
                            {
                                // It's the bloom status
                                string[] blooms = field.Split(":-".ToCharArray());
                                if (blooms.Length == 2)
                                {
                                    blooming_status = SelectedReportParser.find("Blooming_Status", blooms[1]);
                                }
                                else if (blooms.Length == 3)
                                {
                                    blooming_status = SelectedReportParser.find("Blooming_Status", blooms[1]);
                                    blooming = SelectedReportParser.find("Blooming", blooms[2]);
                                }
                            }

                            field = div[5].InnerText;
                            if (field.Contains(SelectedReportParser.Dict["Keys"][(int)ReportParser.Keys.DevStatus]))
                            {
                                // It's the DevStatus
                                string[] devstats = field.Split(':');
                                dev_status = SelectedReportParser.find("Development", devstats[1]);
                            }

                            field = div[6].InnerText;
                            if (field.Contains(SelectedReportParser.Dict["Keys"][(int)ReportParser.Keys.Speciality]))
                            {
                                // It's the Speciality
                                string[] spectats = field.Split(':');
                                if (FPn == 0) // GK
                                {
                                    speciality = SelectedReportParser.find("GK_Skill", spectats[1]);
                                }
                                else
                                {
                                    speciality = SelectedReportParser.find("Player_Skill", spectats[1]);
                                }
                            }

                            field = child.TextContent;
                            if (field.Contains("Should Develop:"))
                            {
                                physique = SelectedReportParser.find("Physique", field, physique);
                                technics = SelectedReportParser.find("Technics", field, technics);
                                tactics = SelectedReportParser.find("Tactics", field, tactics);
                                aggressivity = SelectedReportParser.find("Aggressivity", field, aggressivity);
                                leadership = SelectedReportParser.find("Charisma", field, leadership);
                                professionalism = SelectedReportParser.find("Professionalism", field, professionalism);
                            }

                            if (physique != 0) giudizio += "Phy=" + physique + ",";
                            if (technics != 0) giudizio += "Tec=" + technics + ",";
                            if (tactics != 0) giudizio += "Tac=" + tactics + ",";
                            if (leadership != 0) giudizio += "Lea=" + leadership + ",";
                            if (blooming_status != 0) giudizio += "BlS=" + blooming_status + ",";
                            if (blooming != 0) giudizio += "Blo=" + blooming + ",";
                            if (dev_status != 0) giudizio += "Dev=" + dev_status + ",";
                            if (speciality != 0) giudizio += "Spe=" + speciality + ",";
                            if (aggressivity != 0) giudizio += "Agg=" + aggressivity + ",";
                            if (professionalism != 0) giudizio += "Pro=" + professionalism + ",";
                        }

                        if (ScoutGiudizio != "")
                            ScoutGiudizio = ScoutGiudizio + "|" + giudizio.TrimEnd(',');
                        else
                            ScoutGiudizio = giudizio.TrimEnd(',');

                    }
                }

                ScoutName = ScoutName.TrimEnd('|');
                ScoutDate = ScoutDate.TrimEnd('|');
                ScoutVoto = ScoutVoto.TrimEnd('|');

                result += ";ScoutName=" + ScoutName;
                result += ";ScoutDate=" + ScoutDate;
                result += ";ScoutVoto=" + ScoutVoto;
                result += ";ScoutGiudizio=" + ScoutGiudizio;
                result += ";FPn=" + FPn;
            }
            else if (page.Contains("active_tab\" id=\"tabplayer_history_new"))
            {
                string[] divs = str.Split('\n');

                List<string> bodies = HTML_Parser.GetTags(page, "tbody");

                int ix = 0;
                for (; ix < bodies.Count; ix++)
                {
                    if (bodies[ix].Contains("text_fade_overlay")) break;
                }

                string body = bodies[ix];

                List<string> trs = HTML_Parser.GetTags(body, "tr");

                GameTable gameTable = new GameTable();

                int lastSeason = 0;

                foreach (string tr in trs)
                {
                    List<string> tds = HTML_Parser.GetTags(tr, "td");

                    try
                    {
                        if (tds.Count < 8) continue;

                        int season = int.Parse(tds[0]);

                        GameTable.PerformancesRow pr = null;
                        bool added = false;

                        for (int ip = 0; ip < gameTable.Performances.Count; ip++)
                        {
                            if (gameTable.Performances[ip].Season == season)
                            {
                                pr = gameTable.Performances[ip];
                                break;
                            }
                        }

                        if (pr == null)
                        {
                            pr = gameTable.Performances.NewPerformancesRow();
                            added = true;
                        }

                        if (lastSeason != season)
                        {
                            pr.Season = season;
                            pr.GP = int.Parse(tds[3]);
                            pr.G = int.Parse(tds[4]);
                            pr.A = int.Parse(tds[5]);
                            pr.Cards = int.Parse(tds[6]);
                            pr.Rat = decimal.Parse(tds[7], Common.CommGlobal.ciUs);
                        }
                        else
                        {
                            decimal rat1 = decimal.Parse(tds[7], Common.CommGlobal.ciUs);
                            decimal rat2 = pr.Rat;
                            decimal gp1 = (decimal)(int.Parse(tds[3]));
                            decimal gp2 = (decimal)(pr.GP);

                            decimal rat = (rat1 * gp1 + rat2 * gp2) / (gp1 + gp2);

                            pr.Rat = rat;
                            pr.GP += int.Parse(tds[3]);
                            pr.G += int.Parse(tds[4]);
                            pr.A += int.Parse(tds[5]);
                            pr.Cards += int.Parse(tds[6]);
                        }

                        lastSeason = season;

                        if (added)
                            gameTable.Performances.AddPerformancesRow(pr);
                    }
                    catch
                    {
                        continue;
                    }
                }

                result += ";GameTable=" + gameTable.ToString();
            }

            return result;
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
            if (ActualPlayerID != 0)
            {
                AppendScriptAndExecute(Resources.RatingR2_user, "ApplyRatingR2()");
            }
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

        #region Player Profiles Navigation
        public enum PlayerNavigationType
        {
            NavigateProfiles,
            NavigateReports
        }

        PlayerNavigationType navigationType = PlayerNavigationType.NavigateReports;

        private void navigateProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoPlayer(ActualPlayerID, PlayerNavigationType.NavigateProfiles);
        }

        private void navigateReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoPlayer(ActualPlayerID, PlayerNavigationType.NavigateReports);
        }

        public void GotoPlayer(int playerID, PlayerNavigationType playerNavigationType)
        {
            ActualPlayerID = playerID;

            if (playerNavigationType == PlayerNavigationType.NavigateProfiles)
            {
                tsbPlayersNavigationType.Text = "Profiles";
                tsbPlayersNavigationType.Image = navigateProfilesToolStripMenuItem.Image;
                navigationType = PlayerNavigationType.NavigateProfiles;

                NavigationAddress = TM_Pages.Players + playerID.ToString();
            }
            else
            {
                tsbPlayersNavigationType.Text = "Reports";
                tsbPlayersNavigationType.Image = navigateReportsToolStripMenuItem.Image;
                navigationType = PlayerNavigationType.NavigateReports;

                NavigationAddress = TM_Pages.Players +
                    playerID.ToString() + "/#/page/scout/";
            }

            StartnavigationAddress = NavigationAddress;
            webBrowser.Navigate(NavigationAddress);
        }
        #endregion

        private void tbTxtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Goto(tbTxtAddress.Text);
        }

        private void NTR_Browser_Resize(object sender, EventArgs e)
        {
            tbTxtAddress.Width = this.Width - 260;
        }
    }
}
