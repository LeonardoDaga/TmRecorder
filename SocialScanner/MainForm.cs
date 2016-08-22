using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FacebookParse(SocialData.CorporateRow corporateRow, string content)
        {
            string fbLikes = Common.HTML_Parser.GetField(content, "PagesLikesTab", "IEPinnedSite");
            fbLikes = fbLikes.Replace("]", "");
            string[] sections = Common.HTML_Parser.Split(fbLikes, ",");

            int i = 0;

            var facebookRow = socialDataDB.Facebook.FindByWeekCorporateID(SsWeek.ThisWeek(), corporateRow.CorporateID);
            if (facebookRow == null)
            {
                facebookRow = socialDataDB.Facebook.NewFacebookRow();
                facebookRow.Week = SsWeek.ThisWeek();
                facebookRow.CorporateID = corporateRow.CorporateID;
                socialDataDB.Facebook.AddFacebookRow(facebookRow);
            }

            for (i = 0; i < sections.Length; i++)
            {
                var section = sections[i];

                if (section.Contains("renderLikesData"))
                {
                    i = i + 5;
                    string last14DaysLikes = "";

                    int i14DaysLikes = i;
                    for (; i < i14DaysLikes + 13; i++)
                    {
                        section = sections[i];

                        last14DaysLikes += section + ",";
                    }

                    int totLikes = int.Parse(sections[i]);

                    facebookRow.Last14DaysLikes = last14DaysLikes;
                    facebookRow.Likes = totLikes;
                }

                if (section.Contains("renderPTATData"))
                {
                    int peopleTalking = int.Parse(sections[i + 3]);
                    facebookRow.Talking = peopleTalking;
                }

                if (section.Contains("renderTotalVisitsData"))
                {
                    int beenHere = int.Parse(sections[i + 3]);
                    facebookRow.BeenHere = beenHere;
                }
            }
        }

        private void TwitterParse(SocialData.CorporateRow corporateRow, string content)
        {
            string twLikes = Common.HTML_Parser.GetField(content, "ProfileNav-list", "ProfileNav-item--more dropdown");
            twLikes = twLikes.Replace(",", "").Replace(".", "").Replace("\"", "").Replace("\\", "").Replace("><", "\r\n");
            string[] sections = Common.HTML_Parser.Split(twLikes, "\r\n");

            int i = 0;

            var twitterRow = socialDataDB.Twitter.FindByWeekCorporateID(SsWeek.ThisWeek(), corporateRow.CorporateID);
            if (twitterRow == null)
            {
                twitterRow = socialDataDB.Twitter.NewTwitterRow();
                twitterRow.Week = SsWeek.ThisWeek();
                twitterRow.CorporateID = corporateRow.CorporateID;
                socialDataDB.Twitter.AddTwitterRow(twitterRow);
            }

            for (i = 0; i < sections.Length; i++)
            {
                var section = sections[i];

                if (section.Contains("title=") && (section.Contains("Tweets") || section.Contains("Tweet")))
                {
                    int num = int.Parse(Common.HTML_Parser.GetNumberAfter(section, "title="));
                    twitterRow.Tweets = num;
                }

                if (section.Contains("title=") && (section.Contains("Followers") || section.Contains("follower")))
                {
                    int num = int.Parse(Common.HTML_Parser.GetNumberAfter(section, "title="));
                    twitterRow.Followers = num;
                }

                if (section.Contains("title=") && (section.Contains("Following") || section.Contains("following")))
                {
                    int num = int.Parse(Common.HTML_Parser.GetNumberAfter(section, "title="));
                    twitterRow.Following = num;
                }

                if (section.Contains("title=") && (section.Contains("Likes") || section.Contains("Mi piace")))
                {
                    int num = int.Parse(Common.HTML_Parser.GetNumberAfter(section, "title="));
                    twitterRow.Likes = num;
                }
            }
        }

        private void InstagramParse(SocialData.CorporateRow corporateRow, string content)
        {
            string igLikes = Common.HTML_Parser.GetField(content, "\"ProfilePage\"", "has_next_page");
            igLikes = igLikes.Replace(".", "").Replace("\"", "").Replace("\\", "");
            string[] sections = Common.HTML_Parser.Split(igLikes, ",");

            int i = 0;

            var instagramRow = socialDataDB.Instagram.FindByWeekCorporateID(SsWeek.ThisWeek(), corporateRow.CorporateID);
            if (instagramRow == null)
            {
                instagramRow = socialDataDB.Instagram.NewInstagramRow();
                instagramRow.Week = SsWeek.ThisWeek();
                instagramRow.CorporateID = corporateRow.CorporateID;
                socialDataDB.Instagram.AddInstagramRow(instagramRow);
            }

            for (i = 0; i < sections.Length; i++)
            {
                var section = sections[i];

                if (section.Contains("media:"))
                {
                    int num = int.Parse(Common.HTML_Parser.GetNumberAfter(section, "count: "));
                    instagramRow.Post = num;
                }

                if (section.Contains("followed_by:"))
                {
                    int num = int.Parse(Common.HTML_Parser.GetNumberAfter(section, "count: "));
                    instagramRow.Followers = num;
                }

                if (section.Contains("follows:"))
                {
                    int num = int.Parse(Common.HTML_Parser.GetNumberAfter(section, "count: "));
                    instagramRow.Following = num;
                }
            }
        }

        int numNavigatedCorporate = 0;
        private void startScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doLoop = true;
            numNavigatedCorporate = 0;

            NavigateNextCorporate();
        }

        bool waitingFbPage = false;
        bool waitingTwPage = false;
        bool waitingIgPage = false;
        bool doLoop = false;
        int entranceFlag = 0;
        int loopCount = 0;
        private int startNavigatedCorporate;

        private void NavigateNextCorporate()
        {
            if (entranceFlag > 0)
                return;

            entranceFlag++;

            timer1.Stop();

            // Get the corporate ID
            if (numNavigatedCorporate >= socialDataDB.Corporate.Count)
            {
                numNavigatedCorporate = 0;

                //ntrBrowser.Na
                timer1.Interval = 1000;
                timer1.Start();

                entranceFlag = 0;
                startNavigatedCorporate = startNavigatedCorporate - socialDataDB.Corporate.Count;

                return;
            }

            if (numNavigatedCorporate - startNavigatedCorporate > 20)
            {
                this.Close();
                Application.Exit();
                timer1.Stop();
                return;
            }

            var corporateRow = socialDataDB.Corporate[numNavigatedCorporate];

            // Check if FB is already navigated
            while (!waitingTwPage && !waitingIgPage)
            {
                if (corporateRow.IsFbOfficialWebSiteNull())
                    break;

                // Check if already navigated to the website
                if (ntrBrowser.NavigationAddress == corporateRow.FbOfficialWebSite)
                {
                    // Try to import it
                    string importedPage = ntrBrowser.GetHiddenBrowserContent();
                    FacebookParse(corporateRow, importedPage);
                    waitingFbPage = false;
                    break;
                }

                // Navigate to the facebook social page
                waitingFbPage = true;

                if (!ntrBrowser.Goto(corporateRow.FbOfficialWebSite))
                {
                    ntrBrowser.NavigationAddress = "";
                    waitingFbPage = false;
                }

                //ntrBrowser.Na
                timer1.Interval = 10000;
                timer1.Start();

                entranceFlag = 0;

                return;
            }

            // Check if TW is already navigated
            while (!waitingFbPage && !waitingIgPage)
            {
                if (corporateRow.IsTwOfficialWebSiteNull())
                    break;

                // Check if already navigated to the website
                if (ntrBrowser.NavigationAddress == corporateRow.TwOfficialWebSite)
                {
                    // Try to import it
                    string importedPage = ntrBrowser.GetHiddenBrowserContent();
                    TwitterParse(corporateRow, importedPage);
                    waitingTwPage = false;
                    break;
                }

                // Navigate to the facebook social page
                waitingTwPage = true;

                if (!ntrBrowser.Goto(corporateRow.TwOfficialWebSite))
                {
                    ntrBrowser.NavigationAddress = "";
                    waitingTwPage = false;
                }

                //ntrBrowser.Na
                timer1.Interval = 10000;
                timer1.Start();

                entranceFlag = 0;

                return;
            }

            // Check if TW is already navigated
            while (!waitingFbPage && !waitingTwPage)
            {
                if (corporateRow.IsIgOfficialWebSiteNull())
                    break;

                // Check if already navigated to the website
                if (ntrBrowser.NavigationAddress == corporateRow.IgOfficialWebSite)
                {
                    // Try to import it
                    string importedPage = ntrBrowser.GetHiddenBrowserContent();
                    InstagramParse(corporateRow, importedPage);
                    waitingIgPage = false;
                    break;
                }

                // Navigate to the facebook social page
                waitingIgPage = true;

                if (!ntrBrowser.Goto(corporateRow.IgOfficialWebSite))
                {
                    ntrBrowser.NavigationAddress = "";
                    waitingIgPage = false;
                }

                //ntrBrowser.Na
                timer1.Interval = 10000;
                timer1.Start();

                entranceFlag = 0;

                return;
            }

            if (!doLoop)
            {
                entranceFlag = 0;
                return;
            }

            SaveCorporateList();

            ntrBrowser.ReleaseResources();
            GC.Collect();

            numNavigatedCorporate++;
            Properties.Settings.Default.NumNavigatedCorporate = numNavigatedCorporate;
            Properties.Settings.Default.Save();

            timer1.Interval = 10000;
            timer1.Start();

            entranceFlag = 0;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            NavigateNextCorporate();
        }

        private void saveCorporateListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCorporateList();
        }

        private void SaveCorporateList()
        {
            FileInfo fi = new FileInfo(Properties.Settings.Default.DBFile);
            socialDataDB.WriteXml(fi.FullName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(Properties.Settings.Default.DBFile);
            if (fi.Exists)
                socialDataDB.ReadXml(fi.FullName);
            this.Text = "Social Scanner, Week:" + SsWeek.ThisWeek().ToString();
            InternetExplorerBrowserEmulation.SetBrowserEmulationVersion(BrowserEmulationVersion.Version11Edge);

            numNavigatedCorporate = Properties.Settings.Default.NumNavigatedCorporate;
            startNavigatedCorporate = numNavigatedCorporate;

            if (Properties.Settings.Default.DoLoop)
            {
                doLoop = true;

                NavigateNextCorporate();
            }
        }

        private void scanSelectedCorporateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rows = dgvCorporate.SelectedRows;

            if (rows.Count > 0)
            {
                // Take the first
                int index = rows[0].Index;
                numNavigatedCorporate = index;
                doLoop = false;

                NavigateNextCorporate();
            }
        }

        private void stopScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doLoop = false;
            numNavigatedCorporate = 0;
            timer1.Stop();
        }

        private void gotoFacebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ntrBrowser.Goto("www.facebook.com");
        }

        private void gotoTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ntrBrowser.Goto("www.twitter.com");
        }

        private void gotoInstagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ntrBrowser.Goto("www.instagram.com");
        }

        private void scanStartingFromSelectedCorporateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rows = dgvCorporate.SelectedRows;

            if (rows.Count > 0)
            {
                // Take the first
                int index = rows[0].Index;
                numNavigatedCorporate = index;
                doLoop = true;

                NavigateNextCorporate();
            }
        }
    }
}
