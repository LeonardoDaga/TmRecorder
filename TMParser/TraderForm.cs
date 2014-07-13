using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using TMRecorder.Properties;
using System.IO;
using Languages;
using SendFileTo;

namespace TMRecorder
{
    public partial class TraderForm : Form
    {
        public TraderForm()
        {
            InitializeComponent();

            string listFilePath = Path.Combine(Program.Setts.DefaultDirectory, "TradeList.xml");

            FileInfo fi = new FileInfo(listFilePath);
            if (fi.Exists)
                trading.ReadXml(listFilePath);

            ComputeSum();
        }

        private void ComputeSum()
        {
            int sumAcqPrices = 0, sumSellPrices = 0, sumManagCosts = 0, totalGain = 0;
            foreach (Trading.PlayersRow pr in trading.Players)
            {
                //SetGain(pr);
                if (!pr.IsSellPriceNull()) sumSellPrices += pr.SellPrice;
                if (!pr.IsAcquirePriceNull()) sumAcqPrices += pr.AcquirePrice;
                if (!pr.IsManagCostNull()) sumManagCosts += pr.ManagCost;
                if (!pr.IsGainNull()) totalGain += pr.Gain;
            }

            txtSumAcqPrices.Text = sumAcqPrices.ToString("N0");
            txtSumSellPrices.Text = sumSellPrices.ToString("N0");
            txtSumManagCosts.Text = sumManagCosts.ToString("N0");
            txtTotalGain.Text = totalGain.ToString("N0");
        }

        private void toolPasteTransferHistory_Click(object sender, EventArgs e)
        {
            string page = "";
            int pageType = 0;

            try
            {
                if (Clipboard.ContainsData(System.Windows.Forms.DataFormats.Html))
                {
                    page = (string)Clipboard.GetData(DataFormats.Html);

                    if (page.Contains("SourceURL:http://trophymanager.com/transferhistory.php?mode=bought&showclub"))
                        pageType = 2; // Bought players page
                    else if (page.Contains("SourceURL:http://trophymanager.com/transferhistory.php"))
                        pageType = 1; // Sold players page

                    if (page.Contains("SourceURL:http://trophymanager.com/transferhistory.php"))
                        page = page.Replace("SourceURL:http://trophymanager.com/transferhistory.php", "SourceURL:<TM - Transferhistory>");
                    else
                        page = "";
                }

                if (page == "")
                    page = Clipboard.GetText();

                if (!page.Contains("TM - Transferhistory"))
                {
                    MessageBox.Show("The clipboard doesn't contain Transfer History data\n",
                        Current.Language.PasteFromClipboard, MessageBoxButtons.OK);
                    return;
                }

                page = page.Replace("'", "");
                page = page.Replace('"', '\'');
                page = page.Replace("'>", ">");
                page = page.Replace("&#39;", "'");

                if ((pageType == 0) && (MessageBox.Show("Specify the type of Transfer Page (Yes: Bought Players (Acquistati)," +
                    "No: Sold Players (Venduti))", "Specify Page type", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    LoadBougthPlayersfile(page);
                }
                else if (pageType == 2)
                {
                    LoadBougthPlayersfile(page);
                }
                else
                {
                    LoadSoldPlayersfile(page);
                }
            }
            catch (Exception ex)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string filename = "matchRowTable." + DateTime.Now.Hour.ToString() + "_" +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";

                string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                appDataFolder = Path.Combine(appDataFolder, "TmRecorder");

                string pathfilename = Path.Combine(appDataFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                trading.WriteXml(fi.FullName);
                StreamReader file = new StreamReader(fi.FullName);
                string reportInfo = "Trading:\r\n" + file.ReadToEnd();
                file.Close();

                reportInfo += "\r\nPage:\r\n" + page;

                ErrorReport.Send(ex, reportInfo, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        private void LoadBougthPlayersfile(string page)
        {
            List<string> tables = HTML_Parser.GetTags(page, "TABLE");

            if (tables.Count == 0) return;

            List<string> rows = HTML_Parser.GetTags(tables[1], "TR");

            if (rows.Count == 0) return;

            int lastBought = 0;
            // Ricava la data più recente tra le date di vendita già memorizzate
            foreach (Trading.PlayersRow tpr in trading.Players)
            {
                if (tpr.IsDateAcquireNull()) continue;

                if ((!tpr.IsAcquirePriceNull()) &&
                    (tpr.AcquirePrice != 0) &&
                    (lastBought < tpr.DateAcquire))
                    lastBought = tpr.DateAcquire;
            }

            foreach (string row in rows)
            {
                List<string> fd = HTML_Parser.GetTags(row, "TD");

                if (fd.Count == 0) continue;

                // Get the player id
                int id = 0;

                Trading.PlayersRow tpr = null;
                bool isNew = false;
                DateTime dtAcquire;

                if (!int.TryParse(HTML_Parser.GetField(fd[1], "playerid=", ">"), out id))
                {
                    // Si tratta di un giocatore sconosciuto, bisogna fare una gestione a parte
                    tpr = trading.Players.NewPlayersRow();
                    id = fd.GetHashCode();

                    if ((tpr = trading.Players.FindByPlayerID(id)) == null)
                    {
                        tpr = trading.Players.NewPlayersRow();
                        isNew = true;
                        tpr.PlayerID = id;
                        tpr.Name = HTML_Parser.ConvertHTML(fd[1]).Replace("\r\n", "");
                    }

                    dtAcquire = DateTime.Parse(fd[0].Trim("\t\r\n".ToCharArray()));
                    tpr.DateAcquire = TmWeek.GetTmAbsWk(dtAcquire);

                    if (tpr.DateAcquire < lastBought)
                        continue;

                    tpr.Nation = HTML_Parser.GetField(fd[2], "showcountry=", ">");
                    tpr.ASIwhenBuyed = int.Parse(fd[3].Replace(",", "").Replace(".", ""));
                    tpr.AcquirePrice = int.Parse(fd[4].Replace(",", "").Replace(".", ""));

                    trading.Players.AddPlayersRow(tpr);
                    continue;
                }

                if ((tpr = trading.Players.FindByPlayerID(id)) == null)
                {
                    tpr = trading.Players.NewPlayersRow();
                    isNew = true;
                    tpr.PlayerID = id;
                    tpr.Name = HTML_Parser.GetTag(fd[1], "span").Replace("  ", " ");
                    tpr.Name = HTML_Parser.ConvertHTML(tpr.Name);
                }

                dtAcquire = DateTime.Parse(fd[0].Trim("\t\r\n".ToCharArray()));
                tpr.DateAcquire = TmWeek.GetTmAbsWk(dtAcquire);

                if (tpr.DateAcquire < lastBought)
                    continue;

                tpr.Nation = HTML_Parser.GetField(fd[2], "showcountry=", ">");
                tpr.ASIwhenBuyed = int.Parse(fd[3].Replace(",", "").Replace(".", ""));
                tpr.AcquirePrice = int.Parse(fd[4].Replace(",", "").Replace(".", ""));

                if (!tpr.IsASIwhenSoldNull())
                {
                    SetWeekInTeam(tpr);
                    tpr.ManagCost = ManagementCost(tpr);
                    SetGain(tpr);
                }

                if (isNew)
                {
                    trading.Players.AddPlayersRow(tpr);
                }
            }
        }

        public static int ManagementCost(Trading.PlayersRow tpr)
        {
            int ASIstart = tpr.ASIwhenBuyed;
            int ASIend = tpr.ASIwhenSold;
            int week = tpr.WeekInTeam;

            int wageStart = Tm_Utility.ASItoWage(ASIstart);
            int wageEnd = Tm_Utility.ASItoWage(ASIend);

            return ((wageStart + wageEnd) * week / 2);
        }

        private void LoadSoldPlayersfile(string page)
        {
            List<string> tables = HTML_Parser.GetTags(page, "TABLE");

            if (tables.Count == 0) return;

            List<string> rows = HTML_Parser.GetTags(tables[1], "TR");

            if (rows.Count == 0) return;

            int lastSell = 0;
            // Ricava la data più recente tra le date di vendita già memorizzate
            foreach (Trading.PlayersRow tpr in trading.Players)
            {
                if ((!tpr.IsSellPriceNull()) && 
                    (tpr.SellPrice != 0) &&
                    (lastSell < tpr.DateSell))
                    lastSell = tpr.DateSell;
            }

            foreach (string row in rows)
            {
                List<string> fd = HTML_Parser.GetTags(row, "TD");

                if (fd.Count == 0) continue;

                // Get the player id
                int id = 0;

                Trading.PlayersRow tpr = null;
                bool isNew = false;
                DateTime dtSell;

                if (!int.TryParse(HTML_Parser.GetField(fd[1], "playerid=", ">"), out id))
                {
                    // Si tratta di un giocatore sconosciuto, bisogna fare una gestione a parte
                    tpr = trading.Players.NewPlayersRow();
                    id = fd.GetHashCode();

                    if ((tpr = trading.Players.FindByPlayerID(id)) == null)
                    {
                        tpr = trading.Players.NewPlayersRow();
                        isNew = true;
                        tpr.PlayerID = id;
                        tpr.Name = HTML_Parser.ConvertHTML(fd[1]).Replace("\r\n", "");
                    }

                    dtSell = DateTime.Parse(fd[0].Trim("\t\r\n".ToCharArray()));
                    tpr.DateSell = TmWeek.GetTmAbsWk(dtSell);

                    if (tpr.DateSell < lastSell)
                        continue;

                    tpr.Nation = HTML_Parser.GetField(fd[2], "showcountry=", ">");
                    tpr.ASIwhenSold = int.Parse(fd[3].Replace(",", "").Replace(".", ""));
                    tpr.SellPrice = int.Parse(fd[4].Replace(",", "").Replace(".", ""));

                    if (!tpr.IsASIwhenBuyedNull())
                    {
                        SetWeekInTeam(tpr);
                        tpr.ManagCost = ManagementCost(tpr);
                        SetGain(tpr);
                    }

                    trading.Players.AddPlayersRow(tpr);
                    continue;
                }

                if ((tpr = trading.Players.FindByPlayerID(id)) == null)
                {
                    tpr = trading.Players.NewPlayersRow();
                    isNew = true;
                    tpr.PlayerID = id;
                    tpr.Name = HTML_Parser.GetTag(fd[1], "span").Replace("  ", " ");
                    tpr.Name = HTML_Parser.ConvertHTML(tpr.Name);
                }

                dtSell = DateTime.Parse(fd[0].Trim("\t\r\n".ToCharArray()));
                tpr.DateSell = TmWeek.GetTmAbsWk(dtSell);

                if (tpr.DateSell < lastSell)
                    continue;

                tpr.Nation = HTML_Parser.GetField(fd[2], "showcountry=", ">");
                tpr.ASIwhenSold = int.Parse(fd[3].Replace(",", "").Replace(".", ""));
                tpr.SellPrice = int.Parse(fd[4].Replace(",", "").Replace(".", ""));

                if (isNew)
                {
                    trading.Players.AddPlayersRow(tpr);
                }
            }
        }

        private void SetWeekInTeam(Trading.PlayersRow tpr)
        {
            if (!tpr.IsDateSellNull() && !tpr.IsDateAcquireNull())
                tpr.WeekInTeam = tpr.DateSell - tpr.DateAcquire;
        }

        private void SetGain(Trading.PlayersRow tpr)
        {
            int gain = 0; bool set = false;
            if (!tpr.IsSellPriceNull()) { gain += tpr.SellPrice; set = true; }
            if (!tpr.IsAcquirePriceNull()) { gain -= tpr.AcquirePrice; set = true; }
            if (!tpr.IsManagCostNull()) { gain -= tpr.ManagCost; set = true; }
            if (set) tpr.Gain = gain;
        }

        private void TraderForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraderEditInfo tei = new TraderEditInfo();
            tei.trading = this.trading;
            DataRowView drv = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            Trading.PlayersRow pr = (Trading.PlayersRow)drv.Row;
            tei.SetPlayer(ref pr);

            if (tei.ShowDialog() == DialogResult.OK)
            {
                tei.GetPlayer(ref pr);
                SetWeekInTeam(pr);
                pr.ManagCost = ManagementCost(pr);
                SetGain(pr);
            }
        }

        private void tbCutPlayer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;

            DataRowView drv = (DataRowView)dataGridView1.SelectedRows[0].DataBoundItem;
            Trading.PlayersRow pr = (Trading.PlayersRow)drv.Row;

            trading.Players.RemovePlayersRow(pr);
        }

        private void tbNewPlayer_Click(object sender, EventArgs e)
        {
            TraderEditInfo tei = new TraderEditInfo();
            tei.trading = this.trading;

            Trading.PlayersRow pr = trading.Players.NewPlayersRow();
            pr.PlayerID = 0;
            pr.Name = "New Player";

            tei.SetPlayer(ref pr);

            if (tei.ShowDialog() == DialogResult.OK)
            {
                tei.GetPlayer(ref pr);
                trading.Players.AddPlayersRow(pr);
                SetWeekInTeam(pr);
                pr.ManagCost = ManagementCost(pr);
                SetGain(pr);
            }
        }

        private void tbEditPlayer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;

            DataRowView drv = (DataRowView)dataGridView1.SelectedRows[0].DataBoundItem;
            Trading.PlayersRow pr = (Trading.PlayersRow)drv.Row;

            TraderEditInfo tei = new TraderEditInfo();
            tei.trading = this.trading;
            tei.SetPlayer(ref pr);

            if (tei.ShowDialog() == DialogResult.OK)
            {
                tei.GetPlayer(ref pr);
                SetWeekInTeam(pr);
                pr.ManagCost = ManagementCost(pr);
                SetGain(pr);
            }

            ComputeSum();
        }

        private void tbSaveList_Click(object sender, EventArgs e)
        {
            string listFilePath = Path.Combine(Program.Setts.DefaultDirectory, "TradeList.xml");
            trading.WriteXml(listFilePath);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add to this form the transfer history pages for your players. Select the content\n" +
                "of the pages where your sold players are listed pressing CTRL+A or select from the menu of the\n" +
                "browser the item Edit->Select All, then press CTRL+C to copy the selected content and then press\n" +
                "the button Paste Transfer History (or press CTRL+V) to paste the content in the form. Do\n" +
                "the same with the bought players list. At the end, edit the list to give a name, if you want,\n" +
                "to all the players of which TM loses traces. \n" +
                "This form, at his first start, is automatically filled with the players that TmRec recorded during\n" +
                "all the time that you used it", "Trader Form Help");
        }

        private void TraderForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x16) // CTRL+V
            {
                toolPasteTransferHistory_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://trophymanager.com/klubhus.php?showclub=599573");
        }
    }
}