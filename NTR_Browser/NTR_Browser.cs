using System;
using System.Drawing;
using System.Windows.Forms;
using NTR_Browser.Properties;
using Common;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace NTR_Browser
{
    public delegate void ImportedContentHandler(string content, string address);
    public delegate void NavigationCompleteHandler();

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
                _startnavigationAddress = value.Replace("http:", "https:"); ;
                if (_startnavigationAddress == "") return;
                tbTxtAddressSet(_startnavigationAddress);

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
        public eRatingVersion RatingVersion { get; set; }

        public event ImportedContentHandler ImportedContent;
        public event NavigationCompleteHandler NavigationComplete;

        public bool ReloadedTmRPage = true;
        
        private string InitialPage { get; set; }

        public NTR_Browser()
        {
            InitializeComponent();
        }

        private async void NTR_Browser_Load(object sender, EventArgs e)
        {
            NavigationMode = eNavigationMode.Main;

            // Select a folder where to host the browser cache
            var userDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TmRecorder.2.21";

            // Create the environment. The first argument is null to indicate to use To create WebView2 controls that use 
            // the installed version of the WebView2 Runtime that exists on user machines 
            var env = await CoreWebView2Environment.CreateAsync(null, userDataFolder);

            // Pass the environment as argument
            await webBrowser.EnsureCoreWebView2Async(env);

            webBrowser.NavigationStarting += WebBrowser_NavigationStarting;
            webBrowser.NavigationCompleted += WebBrowser_NavigationCompleted;

            if (InitialPage != null)
                this.Goto(InitialPage);
        }

        private void WebBrowser_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            String address = e.Uri;

            tbTxtAddressSet(webBrowser.Source.AbsoluteUri);
            timerProgress.Enabled = true;
            progress = 0;

            if (!ReloadedTmRPage && address.Contains(TM_Pages.TmrWebSite))
            {
                ReloadedTmRPage = true;
                webBrowser.Reload();
            }

            if (!(address.Contains(TM_Pages.Home) || address.Contains(TM_Pages.Homes)) || (address.Contains("http://trophymanager.com/banners")))
                return;

            if ((address.Contains(TM_Pages.Players)) && (address != StartnavigationAddress))
            {
                int playerID = 0;
                string number = HTML_Parser.GetNumberAfter(address, TM_Pages.Players);
                if (int.TryParse(number, out playerID))
                {
                    if ((playerID != -1) && (playerID != ActualPlayerID))
                    {
                        webBrowser.Stop();
                        GotoPlayer(playerID, this.navigationType);
                        return;
                    }
                }
            }

            NavigationAddress = address;
            StartnavigationAddress = address;
        }

        string DocumentText;

        private async void WebBrowser_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            timerProgress.Enabled = false;
            tsbProgressBarSet(100, Color.Green);


            if (ActualPlayerID > 0)
            {
                if (true) // (lastRatingR4Id != ActualPlayerID)
                {
                    string script = "";
                    if (RatingVersion == eRatingVersion.RatingR4)
                        script = Resources.RatingR4_user;
                    else if (RatingVersion == eRatingVersion.RatingR5)
                        script = Resources.RatingR5_user;
                    else
                        script = Resources.RatingNone;

                    string res = await AppendScriptAndExecute(script, "");
                    tsbPlayersNavigationType.Visible = true;
                }
            }
            else
            {
                tsbPlayersNavigationType.Visible = false;
            }

            DocumentText = await GetSource();

            CheckMainId(DocumentText);
        }

        public async Task<string> GetSource()
        {
            string html = await webBrowser.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
            var htmldecoded = System.Web.Helpers.Json.Decode(html);
            return htmldecoded;
        }

        public static bool IsInDesignMode()
        {
            if (Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1)
            {
                return true;
            }
            return false;
        }

        #region Navigation
        public bool Goto(string address)
        {
            NavigationAddress = address;
            Debug.WriteLine(string.Format("Navigating to :{0}", NavigationAddress));
            try
            {
                if (webBrowser.CoreWebView2 == null)
                {
                    // The control is still not initialized. Store the address
                    // where to navigate after the initialization
                    InitialPage = NavigationAddress;
                    return true;
                }
                else
                {
                    webBrowser.CoreWebView2.Navigate(NavigationAddress);
                    StartnavigationAddress = NavigationAddress;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Stop();
                Debug.WriteLine(string.Format("Navigation failed with exception {0}", ex.Message));
                return false;
            }
        }

        internal void GoForward()
        {
            if (webBrowser.CanGoForward)
                webBrowser.GoForward();
        }

        internal void GoBack()
        {
            if (webBrowser.CanGoBack)
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

        private async Task Import(bool showImportedText)
        {
            string importedPage = await GetHiddenBrowserContent();

            if (showImportedText)
            {
                FillInfoMessageBox fimb = new FillInfoMessageBox();
                fimb.Comments = importedPage;
                fimb.Text = "Copy of the imported string";
                fimb.Message = "Copy the comment and paste it in an email to tmrecorder@gmail.com if something goes wrong";
                fimb.ShowDialog();
            }

            //NavigationAddress = NavigationAddress.Replace("https", "http");

            ImportedContent?.Invoke(importedPage, NavigationAddress);
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            webBrowser.Reload();
        }

        #region Safe Invoke to UI

        private delegate void SafeCallDelegate(string text);
        private delegate void ProgressBarSetDelegate(int value, Color color);

        private void tbTxtAddressSet(string text)
        {
            if (!timerProgress.Enabled)
                return;

            if (tsAddressBar.InvokeRequired)
            {
                var d = new SafeCallDelegate(tbTxtAddressSet);
                if (tsAddressBar.IsDisposed) return;
                try
                {
                    tsAddressBar.Invoke(d, new object[] { text });
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
            }
            else
            {
                if (tsAddressBar.IsDisposed) return;
                tbTxtAddress.Text = text;
            }
        }

        private void tsbProgressBarSet(int value, Color color)
        {
            //if (!timerProgress.Enabled)
            //    return;

            if (tsAddressBar.InvokeRequired)
            {
                if (tsAddressBar.IsDisposed) return;
                var d = new ProgressBarSetDelegate(tsbProgressBarSet);
                try
                {
                    if (((NTR_Browser)d.Target).IsDisposed) return;
                    if (((NTR_Browser)d.Target).Disposing) return;
                    tsAddressBar.Invoke(d, new object[] { value, color });
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
            }
            else
            {
                if (tsAddressBar.IsDisposed) return;
                tsbProgressBar.Value = value;
                tsbProgressBar.ForeColor = color;
            }
        }

        #endregion

        #region Getting Browser Content functions
        public async Task<string> GetHiddenBrowserContent()
        {
            string doctext;

            if (StartnavigationAddress.Contains("/matches/"))
            {
                doctext = await Import_Matches_Adv();
                if (string.IsNullOrEmpty(doctext))
                {
                    doctext = doctext == null ? "GBC error: failed importing players  (text is null)" : "GBC error: failed importing players  (text is empty)";

                    doctext += "\nJs content (in " + Resources.match_loader;

                    doctext += "\n";
                }
            }
            else if (StartnavigationAddress.Contains("/fixtures/club/"))
            {
                doctext = await Import_Fixtures_Adv();
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
                doctext = await ImportClubDocumentContent();
            }
            else if ((StartnavigationAddress.Contains(TM_Pages.Players)) && (ActualPlayerID > 0))
            {
                doctext = await Import_Player_Document_Content();
            }
            else if (StartnavigationAddress.Contains("/players/#") || StartnavigationAddress.EndsWith("/players/"))
            {
                doctext = await Import_Players_Adv();
                if (string.IsNullOrEmpty(doctext))
                {
                    doctext = doctext == null ? "GBC error: failed importing players  (text is null)" : "GBC error: failed importing players  (text is empty)";

                    doctext += "\nJs content (in " + Resources.players_loader;

                    doctext += "\n";
                }

                string trainingDoctext = await Import_Players_Training_Adv();
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
                doctext = await Import_Training();
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
                doctext = await Import_Shortlist_Adv();
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
                doctext = await Import_Transfer_Adv();
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
                doctext = "Doc Text: \n" + DocumentText;
            }

            return doctext;
        }

        private async Task<string> ImportClubDocumentContent()
        {
            string club_info = "cash = " + await AppendScriptAndExecute("$('.coin').html()", ""); 
            
            club_info += "\n" + await AppendScriptAndExecute("$('#club_info > div')[0].outerText", "");                        

            return ParseClubPage(club_info);
        }

        private string ParseClubPage(string club_info)
        {
            var textItems = club_info.Split('\n');

            string result = "";

            // Getting clubId
            result += ";ClubId=" + HTML_Parser.GetFirstNumberInString(textItems[1]);
            result += ";ClubName=" + HTML_Parser.CutBefore(textItems[6], ":").TrimStart(" :".ToCharArray());
            result += ";Fans=" + HTML_Parser.GetFirstNumberInString(textItems[9].Replace(",", "").Replace(".", ""));
            if (textItems.Length > 12)
            {
                result += ";BTeamClubId=" + HTML_Parser.GetFirstNumberInString(textItems[12]);
                result += ";BTeamClubName=" + HTML_Parser.GetField(textItems[11], ":", "-").Trim(' ');
            }

            result += ";Cash=" + HTML_Parser.GetFirstNumberInString(textItems[0].Replace(",", "").Replace(".", ""));

            return result;
        }

        private async Task<string> Import_Player_Document_Content()
        {
            var playerPage = await RetrievePlayerPage();
            string resultBase = ParsePlayerPage(playerPage);
            string resultExtra = ParsePlayerPage_Extras(playerPage);

            return resultBase + resultExtra;
        }

        public async Task<Dictionary<string, string>> RetrievePlayerPage()
        {
            Dictionary<string, string> playerPage = new Dictionary<string, string>();

            playerPage["data"] = await AppendScriptAndExecute(Resources.player_data, "get_player_data");
            playerPage["scout"] = await AppendScriptAndExecute("get_scout_info();", "");
            playerPage["history"] = await AppendScriptAndExecute("get_player_history();", "");
            playerPage["extras"] = await AppendScriptAndExecute("get_extra_info();", "");

            return playerPage;
        }

        public string ParsePlayerPage_Extras(Dictionary<string, string> playerPage)
        {
            string result = "";

            string extras = playerPage["extras"];

            if (extras == "na")
                return "";

            result += ";InjPron=" + HTML_Parser.GetField(extras, "inj:", "/"); 
            result += ";Aggressivity=" + HTML_Parser.GetField(extras, "agg:", "/"); 
            result += ";Professionalism=" + HTML_Parser.GetField(extras, "pro:", "/"); 
            result += ";Ada=" + HTML_Parser.GetField(extras, "ada:", "/"); 

            return result;
        }

        public string ParsePlayerPage(Dictionary<string, string> playerPage)
        {
            if (this.TopLevelControl.Name == "MainForm")
            {
                MessageBox.Show("Sorry but this is not the place where you can import the player page. You must open the Player History page (double click on the player row in the Team Players Tabs of this app) and import the player page from there");
                return "";
            }

            string result = "";

            string page = playerPage["data"];

            if (SelectedReportParser == null)
            {
                MessageBox.Show("Please select the Scout Report parser (in Tools->Options->Report Analysis) before");
                return "";
            }

            result += "PlayerID=" + HTML_Parser.GetNumberAfter(page, "player_id=");
            result += ";PlayerName=" + HTML_Parser.GetField(page, "player_name=", ";");
            string playerFp = HTML_Parser.GetField(page, "player_fp=", ";").ToUpper().Replace(",", "/");
            result += ";PlayerFp=" + playerFp;
            result += ";IsUsersPlayer=" + (page.Contains("is_users_player=true")?"Yes":"No");

            int FPn = Tm_Utility.FPToNumber(playerFp);

            if (playerPage.ContainsKey("data"))
            {
                string strYear = HTML_Parser.GetNumberAfter(page, "agey=");
                string strMonth = HTML_Parser.GetNumberAfter(page, "agem=");
                int year = int.Parse(strYear);
                int month = int.Parse(strMonth);
                result += ";BornWeek=" + TmWeek.GetBornWeekFromAge(DateTime.Now, month, year).ToString();

                result += ";Wage=" + HTML_Parser.GetNumberAfter(page, "wage=");
                result += ";ASI=" + HTML_Parser.GetNumberAfter(page, "SI=");
                result += ";Routine=" + HTML_Parser.GetNumberAfter(page, "rou=");
            }

            if (playerPage.ContainsKey("scout"))
            {
                string ScoutName = "";
                string ScoutDate = "";
                string ScoutVoto = "";
                string ScoutGiudizio = "";

                string scoutPage = playerPage["scout"];

                string ScoutInfo = HTML_Parser.GetField(scoutPage, "ScoutInfo=", "\n");

                var Reviews = HTML_Parser.GetFields(scoutPage, "Review:", "\n\n");

                foreach(var review in Reviews)
                {
                    string[] lines = review.Split("\n".ToCharArray());
                    ScoutName += lines[0].Split(':')[1] + '|';

                    string date = HTML_Parser.GetField(lines[1], "(", ")");
                    DateTime dt = DateTime.Parse(date);
                    ScoutDate += TmWeek.ToSWDString(dt) + "|";

                    string age = HTML_Parser.GetFirstNumberInString(lines[2]);

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

                    string field;
                    
                    // It's the potential
                    string potential_string = HTML_Parser.GetFirstNumberInString(lines[3]);
                    giudizio += "Pot:" + potential_string + ",";

                    ScoutVoto += potential_string + "|";

                    if (lines.Length > 5)
                    {
                        field = lines[4];
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

                        field = lines[5];
                        if (field.Contains(SelectedReportParser.Dict["Keys"][(int)ReportParser.Keys.DevStatus]))
                        {
                            // It's the DevStatus
                            string[] devstats = field.Split(':');
                            dev_status = SelectedReportParser.find("Development", devstats[1]);
                        }

                        field = lines[6];
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

                        try
                        {
                            physique = SelectedReportParser.find("Physique", lines[8], physique);
                            technics = SelectedReportParser.find("Technics", lines[10], technics);
                            tactics = SelectedReportParser.find("Tactics", lines[9], tactics);
                            aggressivity = SelectedReportParser.find("Aggressivity", lines[13], aggressivity);
                            leadership = SelectedReportParser.find("Charisma", lines[11], leadership);
                            professionalism = SelectedReportParser.find("Professionalism", lines[12], professionalism);
                        }
                        catch (Exception)
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


            if (playerPage["history"] != "no data")
            {
                string history = playerPage["history"];

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

                result += ";GameTable|" + gameTable.ToString();
            }
            
            return result;
        }

        private async Task<string> Import_Players_Training_Adv()
        {
            string pl_data = "";

            try
            {
                pl_data = await AppendScriptAndExecute(Resources.get_players_training_loader,
                                                "get_players_training");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private async Task<string> Import_Shortlist_Adv()
        {
            string pl_data = "";

            try
            {
                pl_data = await AppendScriptAndExecute(Resources.shortlist_loader,
                                                "get_shortlist");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private async Task<string> Import_Transfer_Adv()
        {
            string pl_data = "";

            try
            {
                pl_data = await AppendScriptAndExecute(Resources.transfer_loader,
                                                "get_transfer");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private async Task<string> AppendScriptAndExecute(string script, string command)
        {
            string scriptAndCommand = script;
            if (command != "")
                scriptAndCommand += "\r\n" + command + "()";

            var result = await webBrowser.CoreWebView2.ExecuteScriptAsync(scriptAndCommand);

            result = result.Trim('"').Replace("\\n", "\n");
            result = result.Replace("\\u003C", "\u003C");

            if (result == null)
                return "";

            //.ContinueWith(t => 
            //{
            //    var res = t.Result;
            //    if (res.Result == null)
            //        return "";
            //    else
            //        return (string)res.Result.ToString();
            //});

            return result;
        }

        private async Task<string> AppendScriptAndExecute(string script, List<string> commands)
        {
            string scriptAndCommand = script + "\r\n";
            //if (commands.Count > 0)
            //    scriptAndCommand += "return";
            foreach (var command in commands)
            {
                if (command != "")
                    scriptAndCommand += " '<TABLE>' + " + command + "() + '</TABLE>' +";
            }
            if (commands.Count > 0)
            {
                scriptAndCommand = scriptAndCommand.TrimEnd('+');
                scriptAndCommand += ";\r\n";
            }

            var result = await webBrowser.CoreWebView2.ExecuteScriptAsync(scriptAndCommand);

            result = result.Trim('"').Replace("\\n", "\n");
            result = result.Replace("\\u003C", "\u003C");

            if (result == null)
                return "";

            //.ContinueWith(t => 
            //{
            //    var res = t.Result;
            //    if (res.Result == null)
            //        return "";
            //    else
            //        return (string)res.Result.ToString();
            //});

            return result;
        }

        private async Task<string> Import_Players_Adv()
        {
            string pl_data = "";

            try
            {
                pl_data = await AppendScriptAndExecute(Resources.players_loader,
                                                "get_players");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private async Task<string> Import_Player_Adv()
        {
            string pl_data = "";

            try
            {
                pl_data = await AppendScriptAndExecute(Resources.player_info_loader,
                                                "get_player_info");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private async Task<string> Import_Matches_Adv()
        {
            string matches_data = "";

            try
            {
                matches_data = await AppendScriptAndExecute(Resources.match_loader,
                    new List<string> { "get_lineup", "get_match_info", "get_report" });

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

        private async Task<string> Import_Fixtures_Adv()
        {
            string fix_data = "";

            try
            {
                fix_data = await AppendScriptAndExecute(Resources.fixture_loader,
                                                "get_fixture");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return fix_data;
        }

        private async Task<string> Import_Training()
        {
            string fix_data = "";

            try
            {
                fix_data = await AppendScriptAndExecute(Resources.training_loader,
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


        //private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    //if (ActualPlayerID > 0)
        //    //{
        //    //    string script = Resources.RatingR4_user;
        //    //    AppendScriptAndExecute(script, "ApplyRatingR4");
        //    //    tsbPlayersNavigationType.Visible = true;
        //    //}
        //    //else
        //    //{
        //    //    tsbPlayersNavigationType.Visible = false;
        //    //}

        //    //CheckMainId(webBrowser.DocumentText);
        //}

        private void CheckMainId(string documentText)
        {
            if (!StartnavigationAddress.Contains(TM_Pages.Home))
                return;

            string main_id = HTML_Parser.GetNumberAfter(documentText, "SESSION[\"id\"] = ");

            if ((MainTeamId != 0) && (main_id != MainTeamId.ToString()))
                SwitchToMainTeam();
        }

        //private void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        //{
        //    string address = e.Url.AbsoluteUri.Replace("https:", "http:");

        //    if (!(address.Contains(TM_Pages.Home) || address.Contains(TM_Pages.Homes)) || (address.Contains("http://trophymanager.com/banners")))
        //        return;

        //    if ((address.Contains(TM_Pages.Players)) && (address != StartnavigationAddress))
        //    {
        //        int playerID = 0;
        //        string number = HTML_Parser.GetNumberAfter(address, TM_Pages.Players);
        //        if (int.TryParse(number, out playerID))
        //        {
        //            if (playerID != ActualPlayerID)
        //            {
        //                webBrowser.Stop();
        //                GotoPlayer(playerID, this.navigationType);
        //            }
        //        }
        //    }

        //    NavigationAddress = address;
        //    StartnavigationAddress = address;
        //}

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
            Stop();
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

            this.Goto(NavigationAddress);
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
            timerProgress.Enabled = false;
            timerProgress.Stop();
            tsbProgressBarSet(100, Color.Blue);

            //if (webBrowser.IsBrowserInitialized)
            //    webBrowser.Stop();
        }

        public void Close()
        {
            webBrowser.Visible = false;
            //if (webBrowser.IsBrowserInitialized)
            //    webBrowser.Stop();
            timerProgress.Enabled = false;
            timerProgress.Stop();
        }

        public int progress = 0;
        private void timerProgress_Tick(object sender, EventArgs e)
        {
            progress = (progress + 5) % 100;
            tsbProgressBarSet(progress, Color.Blue);
        }
    }

    public class TimedScript
    {
        public string Command { get; set; }
        public string Script { get; set; }
        // public IFrame Frame { get; set; }
    }
}
