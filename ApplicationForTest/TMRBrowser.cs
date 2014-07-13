using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMRBrowser
{
    public partial class TMRBrowser : Form
    {
        public TMRBrowser()
        {
            InitializeComponent();
            txtUrl.Text = "http://trophymanager.com/klubhus.php";
            webBrowser.Navigate(txtUrl.Text);
        }

        public TMRBrowser(string argUrl)
        {
            InitializeComponent();
            txtUrl.Text = argUrl;
            webBrowser.Navigate(txtUrl.Text);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate(txtUrl.Text);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            txtUrl.Text = "http://trophymanager.com/klubhus.php";
            webBrowser.Navigate(txtUrl.Text);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
            txtUrl.Text = webBrowser.Url.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
            txtUrl.Text = webBrowser.Url.ToString();
        }

        private void btnCopyHTML_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(webBrowser.DocumentText);
        }

        private void copyHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCopyHTML_Click(sender, e);
        }

        private void previousURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPrev_Click(sender, e);
        }

        private void nexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNext_Click(sender, e);
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnHome_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            long perc = (e.CurrentProgress*100) / e.MaximumProgress;

            if (perc < 100)
            {
                this.Text = "TMR Browser - Navigating... (" + perc.ToString() + "%)";
            }
            else
            {
                this.Text = "TMR Browser - Navigation Complete";
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString() != txtUrl.Text) return;

            this.Text = "TMR Browser - Navigation Complete";
        }
    }
}