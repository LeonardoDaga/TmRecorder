using System;
using System.Drawing;
using System.Windows.Forms;
using NTR_WebBrowser.Properties;
using Common;
using System.IO;
using System.Collections.Generic;
using mshtml;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NTR_WebBrowser
{
    public delegate void ImportedContentHandler(string content, string address);
    public delegate void NavigationCompleteHandler();

    public partial class NTR_Browser : UserControl
    {
        [DllImport("KERNEL32.DLL", EntryPoint = "SetProcessWorkingSetSize", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        [DllImport("KERNEL32.DLL", EntryPoint = "GetCurrentProcess", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr GetCurrentProcess();

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

        public bool ShowTransfer
        {
            get { return tsbTransferPage.Visible; }
            set
            {
                tsbTransferPage.Visible = value;
            }
        }

        public bool ShowShortlist
        {
            get { return tsbShortList.Visible; }
            set
            {
                tsbShortList.Visible = value;
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
        public int MainTeamId { get; set; }

        private WebBrowser webBrowser;

        public event ImportedContentHandler ImportedContent;
        public event NavigationCompleteHandler NavigationComplete;

        public NTR_Browser()
        {
            InitializeComponent();

            if (!IsInDesignMode())
                CreateAndAttachBrowser();
        }

        private void CreateAndAttachBrowser()
        {
            if (webBrowser != null)
            {
                GC.Collect();

                webBrowser.Dispose();

                webBrowser = null;
            }

            webBrowser = new WebBrowser();
            webBrowser.Location = new System.Drawing.Point(3, 54);
            webBrowser.Width = this.Width - 6;
            webBrowser.Height = this.Height - 44;
            webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            this.webBrowser.ProgressChanged += webBrowser_ProgressChanged;
            this.webBrowser.Navigating += WebBrowser_Navigating;
            //this.webBrowser.Lo += WebBrowser_Navigating;
            this.webBrowser.Visible = true;
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.Controls.Add(webBrowser);
        }


        public static bool IsInDesignMode()
        {
            if (Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1)
            {
                return true;
            }
            return false;
        }

        private void NTR_Browser_Load(object sender, EventArgs e)
        {
            NavigationMode = eNavigationMode.Main;
        }

        #region Navigation
        public bool Goto(string address)
        {
            if (webBrowser.IsBusy)
            {
                webBrowser.Stop();
                return false;
            }

            NavigationAddress = address;
            Debug.WriteLine(string.Format("Navigating to :{0}", NavigationAddress));
            try
            {
                webBrowser.Navigate(NavigationAddress);
                StartnavigationAddress = NavigationAddress;
                return true;
            }
            catch (Exception ex)
            {
                webBrowser.Stop();
                Debug.WriteLine(string.Format("Navigation failed with exception {0}", ex.Message));
                return false;
            }
        }

        public bool CheckXulInitialization()
        {
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
            Goto("http://www.instagram.com");
        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
            bool showImportedText = false;
            if ((Control.ModifierKeys & Keys.Control) != 0)
                showImportedText = true;
            Import(showImportedText);
        }

        private void Import(bool showImportedText)
        {
            string importedPage = GetHiddenBrowserContent();

            if (showImportedText)
            {
                FillInfoMessageBox fimb = new FillInfoMessageBox();
                fimb.Comments = importedPage;
                fimb.Text = "Copy of the imported string";
                fimb.Message = "Copy the comment and paste it in an email to tmrecorder@gmail.com if something goes wrong";
                fimb.ShowDialog();
            }

            ImportedContent?.Invoke(importedPage, NavigationAddress);
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        #region Getting Browser Content functions
        public string GetHiddenBrowserContent()
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
            else if (StartnavigationAddress.Contains("/club/"))
            {
                doctext = ImportClubDocumentContent();
            }
            else if ((StartnavigationAddress.Contains(TM_Pages.Players)) && (ActualPlayerID > 0))
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
            else if (StartnavigationAddress.Contains("/shortlist/"))
            {
                doctext = Import_Shortlist_Adv();
                if (string.IsNullOrEmpty(doctext))
                {
                    doctext = doctext == null ?
                        "GBC error: failed importing shortlist (text is null)" :
                        "GBC error: failed importing shortlist (text is empty)";

                    doctext += "\nJs content (in " + Resources.shortlist_loader;

                    doctext += "\n";
                }
            }
            else if (StartnavigationAddress.Contains("/transfer/"))
            {
                doctext = Import_Transfer_Adv();
                if (string.IsNullOrEmpty(doctext))
                {
                    doctext = doctext == null ?
                        "GBC error: failed importing shortlist (text is null)" :
                        "GBC error: failed importing shortlist (text is empty)";

                    doctext += "\nJs content (in " + Resources.shortlist_loader;

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
                doctext = "Doc Text: \n" + webBrowser.DocumentText;
            }

            return doctext;
        }

        private string ImportClubDocumentContent()
        {
            return ParseClubPage(webBrowser.Document);
        }

        private string ParseClubPage(HtmlDocument htmlDocument)
        {
            HtmlElement hidden = htmlDocument.GetElementById("club_info");
            if (hidden == null) return "";
            var textItems = hidden.OuterText.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string result = "";

            // Getting clubId
            result += ";ClubId=" + HTML_Parser.GetFirstNumberInString(textItems[1]);
            result += ";Fans=" + HTML_Parser.GetFirstNumberInString(textItems[9].Replace(",", "").Replace(".", ""));
            if (textItems.Length >= 12)
                result += ";BTeamClubId=" + HTML_Parser.GetFirstNumberInString(textItems[12]);

            result += ";Cash=" + HTML_Parser.GetNumberAfter(webBrowser.DocumentText, "SESSION[\"cash\"] = ");

            return result;
        }

        public void ReleaseResources()
        {
            IntPtr pHandle = GetCurrentProcess();
            SetProcessWorkingSetSize(pHandle, -1, -1);

            CreateAndAttachBrowser();
        }

        private string Import_Player_Document_Content()
        {
            string resultBase = ParsePlayerPage(webBrowser.Document);
            string resultExtra = ParsePlayerPage_Extras(webBrowser.Document);

            return resultBase + resultExtra;
        }

        public string ParsePlayerPage_Extras(HtmlDocument htmlDocument)
        {
            HtmlElement hidden = htmlDocument.GetElementById("hidden_skill_table");
            if (hidden == null) return "";
            var element = hidden.GetElementsByTagName("td");

            string result = "";

            for (var i = 0; i < 4; i++)
            {
                string tooltip = element[i].GetAttribute("tooltip");

                if ((tooltip == null) || (tooltip == ""))
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

        public string ParsePlayerPage(HtmlDocument htmlDocument)
        {
            if (this.TopLevelControl.Name == "MainForm")
            {
                MessageBox.Show("Sorry but this is not the place where you can import the player page. You must open the Player History page (double click on the player row in the Team Players Tabs of this app) and import the player page from there");
                return "";
            }

            string result = "";
            string page = webBrowser.DocumentText;

            // Import only the report to analyze it
            string report = HTML_Parser.CutBefore(page, "player_scout_new");

            if (SelectedReportParser == null)
            {
                MessageBox.Show("Please select the Scout Report parser (in Tools->Options->Report Analysis) before");
                return "";
            }

            result += "PlayerID=" + HTML_Parser.GetNumberAfter(page, "var player_id = ");
            result += ";PlayerName=" + HTML_Parser.GetField(page, "var player_name = '", "';");
            string playerFp = HTML_Parser.GetField(page, "var player_fp = '", "';").ToUpper().Replace(",", "/");
            result += ";PlayerFp=" + playerFp;
            result += ";IsUsersPlayer=" + (page.Contains("is_users_player = true")?"Yes":"No");

            int FPn = Tm_Utility.FPToNumber(playerFp);                

            int i = 0;
            if (page.Contains("info_table"))
            {
                var elements = htmlDocument.All;
                foreach (var element in elements)
                {
                    HtmlElement htmlElement = (HtmlElement)element;
                    if (htmlElement.InnerHtml == null) continue;
                    if (htmlElement.InnerHtml.Contains("info_table") && (htmlElement.TagName == "DIV"))
                    {
                        if (htmlElement.Children.Count == 0) continue;
                        if (htmlElement.Children[0].Children.Count == 0) continue;
                        if (htmlElement.Children[0].Children[0].Children.Count == 9)
                        {
                            // Parse Age
                            var childAge = htmlElement.Children[0].Children[0].Children[2];

                            string yearsStr = childAge.InnerText;
                            string strYear = HTML_Parser.GetFirstNumberInString(yearsStr);
                            int pos = yearsStr.IndexOf(strYear) + strYear.Length;
                            string monthsStr = yearsStr.Substring(pos);
                            string strMonth = HTML_Parser.GetFirstNumberInString(monthsStr);
                            int year = int.Parse(strYear);
                            int month = int.Parse(strMonth);
                            result += ";BornWeek=" + TmWeek.GetBornWeekFromAge(DateTime.Now, month, year).ToString();

                            string wageStr = htmlElement.Children[0].Children[0].Children[4].InnerText;
                            wageStr = wageStr.Replace(",", "");
                            string strWage = HTML_Parser.GetFirstNumberInString(wageStr);
                            int wage = int.Parse(strWage);
                            result += ";Wage=" + wage.ToString();

                            string siStr = htmlElement.Children[0].Children[0].Children[6].InnerText;
                            siStr = siStr.Replace(",", "");
                            string strSI = HTML_Parser.GetFirstNumberInString(siStr);
                            int ASI = int.Parse(strSI);
                            result += ";ASI=" + ASI.ToString();

                            string rouStr = htmlElement.Children[0].Children[0].Children[8].InnerText;
                            rouStr = rouStr.Replace(",", "").Replace(",", "").Replace("RatingR2\r\n", "");
                            string strRou = HTML_Parser.GetFirstFloatInString(rouStr);
                            decimal Routine = decimal.Parse(strRou);
                            result += ";Routine=" + Routine.ToString();
                        }
                    }
                    else if (htmlElement.InnerHtml.Contains("skill_table") && (htmlElement.TagName == "DIV"))
                    {
                        List<string> tdTags = HTML_Parser.GetTags(htmlElement.InnerHtml, "td");
                        for (int ix=0; ix<tdTags.Count; ix++)
                        {
                            if (tdTags[ix].Contains("star_silver"))
                                tdTags[ix] = "19";
                            else if (tdTags[ix].Contains("star.png"))
                                tdTags[ix] = "20";
                            else if (tdTags[ix].Contains("span"))
                                tdTags[ix] = HTML_Parser.CleanTags(tdTags[ix]);
                        }

                        string[] strArray = tdTags.ToArray();
                        result += ";Str=" + strArray[0];
                        result += ";Pas=" + strArray[1];
                        result += ";Sta=" + strArray[2];
                        result += ";Cro=" + strArray[3];
                        result += ";Vel=" + strArray[4];
                        result += ";Tec=" + strArray[5];
                        result += ";Mar=" + strArray[6];
                        result += ";Hea=" + strArray[7];
                        result += ";Tak=" + strArray[8];
                        result += ";Fin=" + strArray[9];
                        result += ";Wor=" + strArray[10];
                        result += ";Lon=" + strArray[11];
                        result += ";Pos=" + strArray[12];
                        result += ";Set=" + strArray[13];
                    }
                }
            }

            if (page.Contains("id=\"tabplayer_scout_new"))
            {
                HtmlElement element = htmlDocument.GetElementById("player_scout_new");

                string ScoutName = "";
                string ScoutDate = "";
                string ScoutVoto = "";
                string ScoutGiudizio = "";
                string ScoutInfo = "";

                if (element != null)
                foreach (var child in element.Children)
                {
                    if (((HtmlElement)child).InnerHtml.Contains("<tbody>"))
                    {
                        var rows = ((HtmlElement)child).GetElementsByTagName("tr");
                        foreach (var row in rows)
                        {
                            var cols = ((HtmlElement)row).GetElementsByTagName("td");

                            if ((cols == null) || (cols.Count < 8))
                                continue;

                            string name = ((HtmlElement)(cols[0])).InnerHtml;
                            string sen = ((HtmlElement)(cols[1])).InnerHtml;
                            string yth = ((HtmlElement)(cols[2])).InnerHtml;
                            string phy = ((HtmlElement)(cols[3])).InnerHtml;
                            string tac = ((HtmlElement)(cols[4])).InnerHtml;
                            string tec = ((HtmlElement)(cols[5])).InnerHtml;
                            string dev = ((HtmlElement)(cols[6])).InnerHtml;
                            string psy = ((HtmlElement)(cols[7])).InnerHtml;

                            ScoutInfo += "Name:" + name;
                            ScoutInfo += ",Sen:" + sen;
                            ScoutInfo += ",Yth:" + yth;
                            ScoutInfo += ",Phy:" + phy;
                            ScoutInfo += ",Tac:" + tac;
                            ScoutInfo += ",Tec:" + tec;
                            ScoutInfo += ",Dev:" + dev;
                            ScoutInfo += ",Psy:" + psy + "|";
                        }

                        ScoutInfo = ScoutInfo.TrimEnd('|');
                    }
                    else if (((HtmlElement)child).InnerHtml.Contains("report_header"))
                    {
                        var div = ((HtmlElement)child).GetElementsByTagName("div");

                        ScoutName += HTML_Parser.GetTag(((HtmlElement)(div[0])).InnerHtml, "strong") + "|";

                        string date = HTML_Parser.GetTag(((HtmlElement)(div[0])).InnerHtml, "span").TrimStart('(').TrimEnd(')');
                        DateTime dt = DateTime.Parse(date);
                        ScoutDate += TmWeek.ToSWDString(dt) + "|";

                        string age = HTML_Parser.GetFirstNumberInString(((HtmlElement)(div[2])).InnerHtml);

                        string giudizio = "";
                        giudizio += "Age:" + age + ",";

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

                        string field = ((HtmlElement)(div[3])).InnerHtml;
                        if (field.Contains(this.SelectedReportParser.Dict["Keys"][(int)ReportParser.Keys.Potential]))
                        {
                            // It's the potential
                            string potential_string = HTML_Parser.GetFirstNumberInString(field);
                            giudizio += "Pot:" + potential_string + ",";

                            ScoutVoto += potential_string + "|";
                        }
                        else
                        {
                            string message = string.Format("Cannot translate Scout reports: check if your language is properly configured in the options. Language used: {0}",
                                SelectedReportParser.ConfiguredLanguage);
                            MessageBox.Show(message);
                            return "";
                        }

                        if (div.Count > 5)
                        {
                            field = ((HtmlElement)(div[4])).InnerHtml;
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

                            field = ((HtmlElement)(div[5])).InnerHtml;
                            if (field.Contains(SelectedReportParser.Dict["Keys"][(int)ReportParser.Keys.DevStatus]))
                            {
                                // It's the DevStatus
                                string[] devstats = field.Split(':');
                                dev_status = SelectedReportParser.find("Development", devstats[1]);
                            }

                            field = ((HtmlElement)(div[6])).InnerHtml;
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

                            field = ((HtmlElement)child).InnerHtml;
                            try
                            {
                                physique = SelectedReportParser.find("Physique", field, physique);
                                technics = SelectedReportParser.find("Technics", field, technics);
                                tactics = SelectedReportParser.find("Tactics", field, tactics);
                                aggressivity = SelectedReportParser.find("Aggressivity", field, aggressivity);
                                leadership = SelectedReportParser.find("Charisma", field, leadership);
                                professionalism = SelectedReportParser.find("Professionalism", field, professionalism);
                            }
                            catch(Exception)
                            { }

                            if (physique != 0) giudizio += "Phy:" + physique + ",";
                            if (technics != 0) giudizio += "Tec:" + technics + ",";
                            if (tactics != 0) giudizio += "Tac:" + tactics + ",";
                            if (leadership != 0) giudizio += "Lea:" + leadership + ",";
                            if (blooming_status != 0) giudizio += "BlS:" + blooming_status + ",";
                            if (blooming != 0) giudizio += "Blo:" + blooming + ",";
                            if (dev_status != 0) giudizio += "Dev:" + dev_status + ",";
                            if (speciality != 0) giudizio += "Spe:" + speciality + ",";
                            if (aggressivity != 0) giudizio += "Agg:" + aggressivity + ",";
                            if (professionalism != 0) giudizio += "Pro:" + professionalism + ",";
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
                result += ";ScoutInfo=" + ScoutInfo;
                result += ";FPn=" + FPn;
            }

            var divHistory = htmlDocument.GetElementById("tabplayer_history_new");
            if (divHistory.OuterHtml.Contains("class=\"active_tab"))
            {
                string history = Import_Player_History();

                GameTable gameTable = new GameTable();

                string[] seasons = history.Split('\n');

                foreach (var season in seasons)
                {
                    var seasonDict = HTML_Parser.String2Dictionary(season);

                    if (seasonDict.Count == 0) continue;

                    GameTable.PerformancesRow pr = null;

                    if (seasonDict["season"] == "transfer")
                        continue;

                    bool added = false;
                    int seasonNum = 0;
                    int lastSeason = 0;

                    if (!int.TryParse(seasonDict["season"], out seasonNum))
                        continue;

                    for (int ip = 0; ip < gameTable.Performances.Count; ip++)
                    {
                        if (gameTable.Performances[ip].Season == seasonNum)
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

                    if (lastSeason != seasonNum)
                    {
                        pr.Season = seasonNum;
                        pr.GP = int.Parse(seasonDict["games"]);
                        pr.G = int.Parse(seasonDict["goals"]);
                        pr.A = int.Parse(seasonDict["assists"]);
                        pr.Cards = int.Parse(seasonDict["cards"]);
                        if (seasonDict.ContainsKey("mom"))
                            pr.MoM = int.Parse(seasonDict["mom"]);

                        if (pr.GP > 0)
                            pr.Rat = decimal.Parse(seasonDict["rating"], CommGlobal.ciUs) / pr.GP;
                        else
                            pr.Rat = decimal.Parse(seasonDict["rating_avg"], CommGlobal.ciUs);
                    }

                    lastSeason = seasonNum;

                    if (added)
                        gameTable.Performances.AddPerformancesRow(pr);
                }

                result = "GameTable|" + gameTable.ToString();
            }

            return result;
        }

        private string Import_Players_Training_Adv()
        {
            string pl_data = "";

            try
            {
                pl_data = AppendScriptAndExecute(Resources.get_players_training_loader,
                                                "get_players_training");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private string Import_Shortlist_Adv()
        {
            string pl_data = "";

            try
            {
                pl_data = AppendScriptAndExecute(Resources.shortlist_loader,
                                                "get_shortlist");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private string Import_Transfer_Adv()
        {
            string pl_data = "";

            try
            {
                pl_data = AppendScriptAndExecute(Resources.transfer_loader,
                                                "get_transfer");
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
            HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
            IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
            element.text = script;
            HtmlElement res = head.AppendChild(scriptEl);
        }

        private string ExecuteScript(string command)
        {
            string pl_data;

            try
            {
                pl_data = (string)webBrowser.Document.InvokeScript(command);
            }
            catch (Exception)
            {
                pl_data = "";
            }

            return pl_data;
        }


        private string Import_Players_Adv()
        {
            string pl_data = "";

            try
            {
                pl_data = AppendScriptAndExecute(Resources.players_loader,
                                                "get_players");
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
                                                "get_player_info");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private string Import_Player_History()
        {
            string history_data = "";

            try
            {
                AppendScript(Resources.get_player_history);

                string history = ExecuteScript("get_history");

                history_data = history;

                if (history_data.Contains("Javascript error"))
                {
                    //MessageBox.Show("Error executing java scripts");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return history_data;
        }

        private string Import_Matches_Adv()
        {
            string matches_data = "";

            try
            {
                AppendScript(Resources.match_loader);

                string lineup = ExecuteScript("get_lineup");
                string match_info = ExecuteScript("get_match_info");
                string report = ExecuteScript("get_report");

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
                                                "get_fixture");
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
                                                "get_training");
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


        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (ActualPlayerID > 0)
            {
                AppendScriptAndExecute(Resources.RatingR2_user, "ApplyRatingR2");
                tsbPlayersNavigationType.Visible = true;
            }
            else
            {
                tsbPlayersNavigationType.Visible = false;
            }

            CheckMainId(webBrowser.DocumentText);
        }

        private void CheckMainId(string documentText)
        {
            if (!StartnavigationAddress.Contains(TM_Pages.Home))
                return;

            string main_id = HTML_Parser.GetNumberAfter(documentText, "SESSION[\"id\"] = ");

            if (main_id != MainTeamId.ToString())
                SwitchToMainTeam();
        }

        private void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string address = e.Url.AbsoluteUri;

            if (!address.Contains(TM_Pages.Home) || (address.Contains("http://trophymanager.com/banners")))
                return;

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

        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
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
                                       "club_login");
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
                                       "club_int_change");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SwitchToMainTeam()
        {
            string id = MainTeamId.ToString();

            try
            {
                string function =
                    "function club_int_change(){$.post(\"/ajax/club_change.ajax.php\", {\"change\": " +
                    "\"club\",\"club_id\": " + id + "}, function(data) { if (data != null) { if (data[\"success\"])" +
                    " page_refresh(); } }, \"json\");}";

                AppendScriptAndExecute(function,
                                       "club_int_change");
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
            webBrowser.Stop();
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

        private void tsbShortList_Click(object sender, EventArgs e)
        {
            Goto(TM_Pages.Shortlist);
        }

        private void tsbTransferPage_Click(object sender, EventArgs e)
        {
            Goto(TM_Pages.Transfer);
        }

        public void Stop()
        {
            webBrowser.Stop();
        }
    }
}
