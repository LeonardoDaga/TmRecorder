using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TM_Player_Scanner.Properties;
using System.IO;

namespace TM_Player_Scanner
{
    public partial class Form1 : Form
    {
        int lastPageDownloaded = 0;
        int scout_mode = 0;
        string plAddr;

        public Form1()
        {
            InitializeComponent();
            skipPlayerToolStripMenuItem.Visible = false;
            timer.Enabled = false;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = Settings.Default.SquadPage;
            openFileDialog.Filter = "HTML file (*.htm;*.html)|*.htm;*.html|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // tMMatches.LoadSeasonFile(openFileDialog.FileName);

                Settings.Default.SquadPage = openFileDialog.FileName;
                Settings.Default.Save();
            }
        }

        private void gotoTrophyManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string matchAddr = "http://trophymanager.com/squad.php";

            txtUrl.Text = matchAddr;

            webBrowser.Navigate(new Uri(matchAddr));
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playerScanInfo.Reset();
            playerScanInfo.FindNameID(webBrowser.DocumentText);
            skipPlayerToolStripMenuItem.Visible = (playerScanInfo.Giocatori.Rows.Count > 0);
        }

        private void downloadTableMatchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.AddDays(-6.0) < Settings.Default.LastDownload)
            {
                MessageBox.Show("Sorry but you must wait a least 6 days between two downloads",
                    "Cannot download", MessageBoxButtons.OK);
                return;
            }

            folderBrowserDialog.SelectedPath = Settings.Default.SaveFolder;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SaveFolder = folderBrowserDialog.SelectedPath;
                Settings.Default.Save();
            }
            else
                return;

            lastPageDownloaded = 0;
            scout_mode = 0;
            LoopDownload();

            Settings.Default.LastDownload = DateTime.Now;
            Settings.Default.Save();
        }

        private void LoopDownload()
        {
            if (lastPageDownloaded >= playerScanInfo.Giocatori.Rows.Count)
            {
                if (scout_mode == 0)
                {
                    lastPageDownloaded = 0;
                    scout_mode = 1;
                    LoopDownload();
                }

                return;
            }

            PlayerScanInfo.GiocatoriRow gr = (PlayerScanInfo.GiocatoriRow)playerScanInfo.Giocatori.Rows[lastPageDownloaded];

            plAddr = "http://trophymanager.com/showprofile.php?playerid=" + gr.PlayerID.ToString();

            if (scout_mode == 1)
            {
                plAddr += "&scout_mode=1";
            }

            txtUrl.Text = plAddr;

            try
            {
                webBrowser.Navigate(new Uri(plAddr));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString() == plAddr) timer.Enabled = true;
        }

        private void NewLoop()
        {
            if (playerScanInfo.Giocatori.Count == 0) return;

            string page = webBrowser.DocumentText;

            PlayerScanInfo.GiocatoriRow gr = (PlayerScanInfo.GiocatoriRow)playerScanInfo.Giocatori.Rows[lastPageDownloaded];

            StreamWriter file = null;
            
            if (scout_mode == 0)
                file = new StreamWriter(Settings.Default.SaveFolder + "\\Player" + gr.PlayerID + ".htm");
            else
                file = new StreamWriter(Settings.Default.SaveFolder + "\\Player" + gr.PlayerID + ".scout.htm");

            file.Write(page);
            file.Close();

            lastPageDownloaded++;

            LoopDownload();
        }

        private void skipPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser.Stop();
            lastPageDownloaded++;
            LoopDownload();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;

            NewLoop();
        }

    }
}