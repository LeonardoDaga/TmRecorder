using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using System.IO;
using ActionAnalysisTool.Properties;

namespace ActionAnalysisTool
{
    public partial class ActionForm : Form
    {
        string navigationAddress = "";
        string startnavigationAddress = "";
        bool changed = false;

        public ActionForm()
        {
            InitializeComponent();
            Program.Setts.Initialize();

            // Load last saved file
            FileInfo fi = new FileInfo(Program.Setts.LastSavedFile);

            if (fi.Exists)
                actionAnalysisDS.ReadXml(Program.Setts.LastSavedFile);

            UpdateTitle();

            changed = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        #region Navigation
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString() != startnavigationAddress) return;

            // this.Text = "TMR Browser - Navigation Complete";
            tsbProgressBar.ForeColor = Color.Green;
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if ((e.Url.ToString().StartsWith("http://trophymanager.com/livematch.php?matchid=")) ||
                (e.Url.ToString().StartsWith("http://trophymanager.com/live_prematch.php?matchid=")))
            {
                string kampid = e.Url.ToString().Split('=')[1];
                navigationAddress = "http://trophymanager.com/kamp.php?kampid=" + kampid + ",0,0&show=report";
                webBrowser.Navigate(navigationAddress);
                startnavigationAddress = navigationAddress;
            }
            else if (e.Url.ToString().StartsWith("http://trophymanager.com/kamp"))
            {
                string kampid = HTML_Parser.GetNumberAfter(e.Url.ToString(), "kampid=");

                ActionAnalysis.TranslatedMatchesRow tmr = actionAnalysisDS.TranslatedMatches.FindByMatchID(int.Parse(kampid));
                if (tmr != null)
                {
                    lblMatchStored.Text = tmr.Languages;
                    lblMatchStored.ForeColor = Color.Green;
                }
                else
                {
                    lblMatchStored.Text = "Not translated";
                    lblMatchStored.ForeColor = Color.DarkRed;
                }
            }
            else if (e.Url.ToString().StartsWith("http://trophymanager.com"))
            {
                lblMatchStored.Text = "Stored?";
                lblMatchStored.ForeColor = Color.Orange;
                navigationAddress = e.Url.ToString();
            }

            tsbProgressBar.Value = 0;
            tsbProgressText.Text = "0%";
            tsbProgressBar.ForeColor = Color.Blue;
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
            int perc = (int)((e.CurrentProgress * 100) / e.MaximumProgress);
            tsbProgressBar.Value = perc;
            tsbProgressText.Text = perc.ToString() + "%";
            tsbProgressBar.ForeColor = Color.Blue;
        }
        #endregion

        private void gotoMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
            string doctext;

            try
            {
                doctext = webBrowser.DocumentText;
            }
            catch (FileNotFoundException)
            {
                doctext = "";
            }

            if (doctext == "")
            {
                if (webBrowser.Document == null) return;
                foreach (HtmlElement hel in webBrowser.Document.All)
                {
                    if (hel.InnerHtml != null)
                        doctext += hel.InnerHtml;
                }
            }

            string page = doctext;

            SaveImportedFile(page, webBrowser.Url);

            if (startnavigationAddress.Contains("kamp.php"))
                page = "SourceURL:<TM - Kamp>\n" + "Address:" + startnavigationAddress + "\n" + page;
            else
            {
                if (startnavigationAddress.Contains("index.php"))
                {
                    MessageBox.Show("I'm sorry, but the Trophy Manager home page cannot be imported in TmRecorder. You think it could be useful? Contact me at led.lennon@gmail.com");
                    return;
                }

                if (startnavigationAddress.Contains("klubhus.php"))
                {
                    MessageBox.Show("I'm sorry, but the club house page cannot be imported in TmRecorder. You think it could be useful? Contact me at led.lennon@gmail.com");
                    return;
                }

                if (startnavigationAddress.Contains("shortlist.php"))
                {
                    MessageBox.Show("I'm sorry, but the shortlist page cannot be imported in TmRecorder. You think it could be useful? Contact me at led.lennon@gmail.com");
                    return;
                }

                if (startnavigationAddress.Contains("live_prematch.php"))
                {
                    MessageBox.Show("I'm sorry, this page cannot be imported now. Try once again to load this page.");
                    return;
                }

                if (MessageBox.Show("Cannot import this page here. Here you can import only squad, training, calendar and matches.\n" +
                    "Pressing OK, you send a report to Atletico Granata that will try to detect the reason of the error.",
                    "Import error", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string swRelease = "Sw Release:" + Application.ProductName + "("
                       + Application.ProductVersion + ")";
                    page = "Navigation Address: " + startnavigationAddress + "\n" + page;
                    Exception ex = new Exception("Navigation error");
                    SendFileTo.ErrorReport.Send(ex, page, Environment.StackTrace, swRelease);
                }

                changed = true;

                return;
            }

            if ((!page.Contains("TM - Kamp")))
            {
                return;
            }

            LoadHTMLfile_newPage(page);

            {
                if (startnavigationAddress.StartsWith("http://trophymanager.com/kamp"))
                {
                    string kampid = HTML_Parser.GetNumberAfter(startnavigationAddress, "kampid=");

                    ActionAnalysis.TranslatedMatchesRow tmr = actionAnalysisDS.TranslatedMatches.FindByMatchID(int.Parse(kampid));
                    if (tmr != null)
                    {
                        lblMatchStored.Text = "Lang: " + tmr.Languages;
                        lblMatchStored.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblMatchStored.Text = "Not translated";
                        lblMatchStored.ForeColor = Color.DarkRed;
                    }
                }
            }
        }

        private void LoadHTMLfile_newPage(string page)
        {
            actionAnalysisDS.AnalyzeReport(page);
            UpdateTitle();
        }

        /// <summary>
        /// Save imported file
        /// </summary>
        /// <param name="page"></param>
        /// <param name="url"></param>
        private void SaveImportedFile(string page, Uri url)
        {
            // Check the existence of the folder
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.DefaultDirectory, "ImportedPages"));
            if (!di.Exists)
            {
                di.Create();
            }

            string filedate = TmWeek.ToSWDString(DateTime.Now);

            string filename = url.LocalPath.Replace(".php", "").Replace("/", "");

            if (filename == "kamp")
            {
                string kampid = HTML_Parser.GetField(webBrowser.Url.Query, "=", ",");
                filename += "_" + kampid + ".2.htm";
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

        private void tsbNext_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void saveDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.Setts.LastSavedFile == "")
            {
                saveDatasetAsToolStripMenuItem_Click(sender, e);
                return;
            }

            actionAnalysisDS.WriteXml(Program.Setts.LastSavedFile);
        }

        private void saveDatasetAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = Program.Setts.LastSavedFile;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Program.Setts.LastSavedFile = sfd.FileName;
                Settings.Default.Save();
                actionAnalysisDS.WriteXml(Program.Setts.LastSavedFile);
            }
        }

        private void loadDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.FileName = Program.Setts.LastSavedFile;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Program.Setts.LastSavedFile = ofd.FileName;
                actionAnalysisDS.Clear();
                actionAnalysisDS.ReadXml(Program.Setts.LastSavedFile);
            }

            UpdateTitle();
        }

        private void UpdateTitle()
        {
            int translated = 0;
            foreach(ActionAnalysis.ActionsRow ar in actionAnalysisDS.Actions)
            {
                if ((!ar.IsCodeA1Null()) && (ar.CodeA1 == ""))
                    continue;
                if ((!ar.IsCodeA2Null()) && (ar.CodeA2 == ""))
                    continue;
                if ((!ar.IsCodeD1Null()) && (ar.CodeD1 == ""))
                    continue;
                if ((!ar.IsCodeD2Null()) && (ar.CodeD2 == ""))
                    continue;
                if ((ar.IsAttackTypeNull()) || (ar.AttackType == ""))
                    continue;
                if ((ar.IsShotTypeNull()) || (ar.ShotType == ""))
                    continue;
                translated++;
            }

            this.Text = "Action Analysis Tool: " + actionAnalysisDS.Actions.Count.ToString() + " loaded, " +
                translated.ToString() + " translated";
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTitle();
            changed = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void copySelectedCellsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabActionTranslation)
            {
                string copiedText = "";
                DataGridView dgControl = dgActionTranslation;

                int firstRow = dgControl.SelectedCells[0].RowIndex;
                int lastRow = dgControl.SelectedCells[dgControl.SelectedCells.Count - 1].RowIndex;
                if (firstRow > lastRow)
                {
                    int pivot = firstRow;
                    firstRow = lastRow;
                    lastRow = pivot;
                }

                foreach (DataGridViewRow row in dgControl.Rows)
                {
                    if (row.Index < firstRow) continue;
                    if (row.Index > lastRow) continue;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Selected == false) continue;

                        if ((string)(cell.FormattedValue) == "-")
                            copiedText += "<null>\t";
                        else
                            copiedText += cell.Value.ToString() + "\t";
                    }

                    copiedText = copiedText.Trim('\t');
                    copiedText += "\n";
                }
                copiedText = copiedText.Trim('\n');

                Clipboard.SetText(copiedText);
            }
        }

        private void pasteCellsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabActionTranslation)
            {
                DataGridView dgControl = dgActionTranslation;
                
                string pastedText = Clipboard.GetText();

                int firstRow = -1;
                int firstCol = -1;

                if (dgControl.SelectedCells.Count == 0)
                {
                    firstRow = 0;
                    firstCol = 0;
                }
                else
                {
                    firstRow = dgControl.SelectedCells[0].RowIndex;
                    firstCol = dgControl.SelectedCells[0].ColumnIndex;
                }

                string[] rows = pastedText.Split('\n');

                int iRow = firstRow;

                foreach (string row in rows)
                {
                    if (row == "") continue;
                    string[] items = row.Split('\t');

                    BindingSource bs = (BindingSource)dgActionTranslation.DataSource;
                    ActionAnalysis ds = (ActionAnalysis)bs.DataSource;
                    DataTable dt = ds.Tables[dgActionTranslation.DataMember];

                    if (iRow > dgControl.Rows.Count - 2)
                    {
                        if (dt == null) continue;

                        DataRow dr = dt.NewRow();

                        int iCol = firstCol;

                        foreach (string item in items)
                        {
                            dr[iCol + 1] = item;
                            iCol++;
                        }
                        try
                        {
                            dt.Rows.Add(dr);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        int iCol = firstCol;

                        foreach (string item in items)
                        {
                            dgControl.Rows[iRow].Cells[iCol].Value = item;
                            iCol++;
                        }
                    }
                    iRow++;
                }
            }
        }

        private void deleteCellContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabActionTranslation)
            {
                DataGridView dgControl = dgActionTranslation;

                int firstRow = dgControl.SelectedCells[0].RowIndex;
                int lastRow = dgControl.SelectedCells[dgControl.SelectedCells.Count - 1].RowIndex;
                if (firstRow > lastRow)
                {
                    int pivot = firstRow;
                    firstRow = lastRow;
                    lastRow = pivot;
                }

                foreach (DataGridViewRow row in dgControl.Rows)
                {
                    if (row.Index < firstRow) continue;
                    if (row.Index > lastRow) continue;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Selected == false) continue;

                        if ((string)(cell.FormattedValue) == "-")
                            continue;
                        else
                            cell.Value = "";
                    }
                }
            }
        }

        private void changeMINToNUMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actionAnalysisDS.ConvertMinToNum();
        }

        private void txtDescriptionFilter_TextChanged(object sender, EventArgs e)
        {
            bindActionTraslation.Filter = "Description LIKE '%" + txtDescriptionFilter.Text + "%'";
        }
    }
}
