using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using System.IO;
using System.ComponentModel;
using NTR_Controls.Properties;
using NTR_Db;
using mshtml;

namespace NTR_Controls
{
    public class Browser
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
        private WebBrowser webBrowser;
        public string DefaultDirectory { get; set; }
        
        // Path where the js scripts are located
        public string DatafilePath = "";

        public Browser(WebBrowser webBrowser)
        {
            this.webBrowser = webBrowser;
        }

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

        internal Content Import()
        {
            string doctext = "";
            Content returnedContent = new Content();

            // Read the browser content to extract the TeamID and the Team name
            doctext = webBrowser.DocumentText;
            int actualTeamId = 0;
            string actTeamIdString = HTML_Parser.GetNumberAfter(doctext, "SESSION[\"id\"] = ");
            int.TryParse(actTeamIdString, out actualTeamId);

            returnedContent.TeamID = actualTeamId;
            returnedContent.ClubName = HTML_Parser.GetField(doctext, "SESSION[\"clubname\"] = '", "';");
            returnedContent.DocText = "";

            if (webBrowser.Url == null) return null;
            if ((!webBrowser.Url.OriginalString.Contains("http://trophymanager.com/players/")) &&
                (!webBrowser.Url.OriginalString.Contains("http://trophymanager.com/matches/")))
            {
                MessageBox.Show("Sorry, cannot import this page!", "TmRecorder");
                return null;
            }

            try
            {
                doctext = GetHiddenBrowserContent(webBrowser.Url.OriginalString);
            }
            catch (Exception ex)
            {
                doctext = "Exception error:\nWeb Site: " + startnavigationAddress + "\nException: " + ex.Message;
            }

            returnedContent.DocText = doctext;

            if (doctext.Contains("Javascript error: data doesn't exists"))
                return returnedContent;

            if (doctext.StartsWith("Exception error") || doctext.StartsWith("GBC error") || doctext.Contains("Javascript error"))
                return returnedContent;

            string page = webBrowser.Url + "\n" + doctext;

            if (page.Contains("You are not logged in"))
            {
                MessageBox.Show("You are not logged in. Please, login");
                return null;
            }

            SaveImportedFile(page, webBrowser.Url);

            returnedContent.ParsePage(page, webBrowser.Url.OriginalString);

            return returnedContent;
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
                doctext = "Doc Text: \n" + webBrowser.DocumentText;
            }

            return doctext;
        }

        private string Import_Players_Training_Adv()
        {
            string pl_data = "";

            try
            {
                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                element.text = Resources.get_players_training_loader;
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

                element.text = Resources.players_loader;
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
                string doctext = webBrowser.Document.Body.InnerHtml;

                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                element.text = Resources.player_info_loader;
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

                element.text = Resources.match_loader;
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

                element.text = Resources.fixture_loader;
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

                element.text = Resources.training_loader;
                HtmlElement res = head.AppendChild(scriptEl);
                fix_data = (string)webBrowser.Document.InvokeScript("get_training");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return fix_data;
        }
        #endregion

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

        internal void Update()
        {
            webBrowser.Update();
        }
    }
}
