using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NTR_Db;

namespace NTR_Controls
{
    public delegate void ImportedContentHandler(Content content);    

    public partial class NTR_Browser : UserControl
    {
        Browser TheBrowser = null;

        public event ImportedContentHandler ImportedContent;

        private string _defaultDirectory = "";
        public string DefaultDirectory 
        { 
            get { return _defaultDirectory; } 
            set 
            {
                _defaultDirectory = value;
                if (TheBrowser != null)
                    TheBrowser.DefaultDirectory = _defaultDirectory;
            }
        }

        public NTR_Browser()
        {
            InitializeComponent();
        }

        private void NTR_Browser_Load(object sender, EventArgs e)
        {
            TheBrowser = new Browser(webBrowser);
            TheBrowser.DefaultDirectory = this.DefaultDirectory;
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            TheBrowser.GoBack();
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            TheBrowser.GoForward();
        }

        private void gotoTmHome_Click(object sender, EventArgs e)
        {
            TheBrowser.Goto(Browser.Pages.Home);
        }

        private void gotoAdobeFlashplayerPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TheBrowser.Goto(Browser.Pages.AdobeFlashplayer);
        }

        public void Goto(string address)
        {
            TheBrowser.Goto(address);
        }

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

        private void tsbImport_Click(object sender, EventArgs e)
        {
            Content content = TheBrowser.Import();
            if (content == null)
                return;

            if (ImportedContent != null)
                ImportedContent(content);
        }

    }
}
