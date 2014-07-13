using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using Microsoft.Win32;
using System.IO;
using Action_Analysis_Editor.Properties;
//using Profile;

namespace Action_Analysis_Editor
{
    public partial class Form1 : Form
    {
        private ActionAnalysis.ActionParsingRow aprSelected = null;
        PropertyEditor ped = new PropertyEditor();

        string codes = "\nTIPO: O=Occasioni, A=Assist, T=Tiri, S=Tiri nello specchio, G=Gol, D=Difesa, Y=Cart.Giallo, R=Cart.Rosso, E=Errore;" +
            "\nof=Palla Filtrante, op=passaggio, ol=Pass.Lungo, oc=Contropiede, ow=Ali, ok=Calcio di Punizione, or:Cross, od=Dribbling, ov=Velocità, ot=Tecnica, oy=Fermato con ammonizione, on=corner, os=pass.corti" +
            "\nTIRO FUORI: th=Colpo di Testa, tn=Tiro da vicino, tl=Tiro da lontano, tp=Calcio di punizione, tr=Rigore" +
            "\nDIFESA: dh=Colpo di Testa, dt=Tackle, dc=Contrasto, da=Anticipo, dp=Posizione, di=Palla Intercettata" +
            "\nPARATA: pb=Bloccata, pd=Deviata, pr=Riflessi, po=Uno-Uno, ps:Respinta, pa=Aerial, pj=Jump" +
            "\nERRORI: ed=Difensivo, ea=Attacco, ep=Passaggio, el=Lancio lungo, ew=Fascia, ec=Corner, ef:Pass.Filtrante, er:Riflessi Portiere, ek:Punizione sbagliata, eg:Errore Portiere, em=Marcatura, eh=Errore di testa, ev=Velocità, et=takle, eo=Posizione" +
            "\nGIALLO: yp=Proteste, yh=BruttoFallo, y=normale" +
            "\nSOSTITUZIONI: in=infortunato, is=sostituto, ic=sostituito";

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataRowView drv = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            ActionAnalysis.ActionParsingRow apr = (ActionAnalysis.ActionParsingRow)drv.Row;

            ped.dialogBag.Properties.Clear();
            ped.dialogBag.Properties.Add(new PropertySpec("Description", typeof(string),
                "Action Info", "The integral text of the action", apr.Description));

            ped.dialogBag.Properties.Add(new PropertySpec("1st Codes", typeof(string),
                "Player Info", "1st player codes: "+ codes, apr.Code1));
            ped.dialogBag.Properties.Add(new PropertySpec("2nd Codes", typeof(string),
                "Player Info", "2nd player codes: " + codes, apr.Code2));
            ped.dialogBag.Properties.Add(new PropertySpec("3rd Codes", typeof(string),
                "Player Info", "3rd player codes: " + codes, apr.Code3));
            ped.dialogBag.Properties.Add(new PropertySpec("4th Codes", typeof(string),
                "Player Info", "4th player codes: " + codes, apr.Code4));

            ped.dialogBag.GetValue += new PropertySpecEventHandler(dialogBag_GetValue);
            ped.dialogBag.SetValue += new PropertySpecEventHandler(dialogBag_SetValue);

            aprSelected = apr;

            ped.InitializeGrid();
            ped.Height = 360 + 20 * ped.dialogBag.Properties.Count;
            ped.Width = 450;

            ped.ShowDialog();
        }

        private void newActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionAnalysis.ActionParsingRow apr = actionAnalysis1.ActionParsing.NewActionParsingRow();

            apr.Description = "Action Description";
            apr.Code1 = "";
            apr.Code2 = "";
            apr.Code3 = "";
            apr.Code4 = "";

            ped.dialogBag.Properties.Clear();

            ped.dialogBag.Properties.Add(new PropertySpec("Description", typeof(string),
                "Action Info", "The integral text of the action", apr.Description));

            ped.dialogBag.Properties.Add(new PropertySpec("1st Codes", typeof(string),
                "Player Info", "1st player codes: " + codes, apr.Code1));
            ped.dialogBag.Properties.Add(new PropertySpec("2nd Codes", typeof(string),
                "Player Info", "2nd player codes: " + codes, apr.Code2));
            ped.dialogBag.Properties.Add(new PropertySpec("3rd Codes", typeof(string),
                "Player Info", "3rd player codes: " + codes, apr.Code3));
            ped.dialogBag.Properties.Add(new PropertySpec("4th Codes", typeof(string),
                "Player Info", "4th player codes: " + codes, apr.Code4));

            ped.dialogBag.GetValue += new PropertySpecEventHandler(dialogBag_GetValue);
            ped.dialogBag.SetValue += new PropertySpecEventHandler(dialogBag_SetValue);

            aprSelected = apr;

            ped.InitializeGrid();
            ped.Height = 360 + 20 * ped.dialogBag.Properties.Count;
            ped.Width = 450;


            ped.ShowDialog();

            actionAnalysis1.ActionParsing.AddActionParsingRow(apr);
        }

        void dialogBag_SetValue(object sender, PropertySpecEventArgs e)
        {
            switch (e.Property.Name)
            {
                case "Description": aprSelected.Description = (string)e.Value; break;
                case "1st Codes": aprSelected.Code1 = (string)e.Value; break;
                case "2nd Codes": aprSelected.Code2 = (string)e.Value; break;
                case "3rd Codes": aprSelected.Code3 = (string)e.Value; break;
                case "4th Codes": aprSelected.Code4 = (string)e.Value; break;
            }
        }

        void dialogBag_GetValue(object sender, PropertySpecEventArgs e)
        {
            switch (e.Property.Name)
            {
                case "Description": e.Value = (string)aprSelected.Description; break;
                case "1st Codes": e.Value = (string)aprSelected.Code1; break;
                case "2nd Codes": e.Value = (string)aprSelected.Code2; break;
                case "3rd Codes": e.Value = (string)aprSelected.Code3; break;
                case "4th Codes": e.Value = (string)aprSelected.Code4; break;
            }
        }

        private void pasteMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string page = "";
            if (Clipboard.ContainsData(System.Windows.Forms.DataFormats.Html))
            {
                page = (string)Clipboard.GetData(DataFormats.Html);

                if (page.Contains("SourceURL:http://trophymanager.com/kamp.php"))
                    page = page.Replace("SourceURL:http://trophymanager.com/kamp.php", "SourceURL:<TM - Kamp>");
                else
                    page = "";
            }

            if (page == "")
                page = Clipboard.GetText();

            if (!page.Contains("TM - Kamp"))
            {
                MessageBox.Show("The clipboard doesn't contain Match data\n" +
                    "To use this menu item, you must copy the content of the page that opens when you\n" +
                    "request the HTML code of page from which you are trying to paste data.",
                    "Paste from Clipboard", MessageBoxButtons.OK);
                return;
            }

            LoadHTMLfile(page);
        }

        private void LoadHTMLfile(string page)
        {
            if (page.Contains("TM - Kamp"))
            {
                LoadKampFromHTMLcode(page);
                return;
            }
        }

        private void LoadKampFromHTMLcode(string page)
        {
            ChampDS.MatchRow matchRow = champDS.Match.NewMatchRow();

            matchRow.MatchID = 0;

            matchDS.Clear();
            matchDS.Analyze(page, ref matchRow);

            int newAddedActions = 0;
            int alreadyPresentActions = 0;

            foreach (MatchDS.ActionsRow ar in matchDS.Actions)
            {
                string desc = ar.Description;

                List<int> IdList = ActionAnalysis.CleanActionRow(ref desc, matchDS.clubNicks[0], matchDS.clubNicks[1]);
                if (IdList == null) continue;

                int IdDesc = desc.GetHashCode();

                if (actionAnalysis1.ActionParsing.FindByID(IdDesc) == null)
                {
                    ActionAnalysis.ActionParsingRow apr = actionAnalysis1.ActionParsing.NewActionParsingRow();

                    apr.ID = IdDesc;
                    apr.Description = desc;
                    apr.Code1 = "";
                    apr.Code2 = "";
                    apr.Code3 = "";
                    apr.Code4 = "";

                    ped.dialogBag.Properties.Clear();

                    ped.dialogBag.Properties.Add(new PropertySpec("Description", typeof(string),
                        "Action Info", "The integral text of the action", apr.Description));

                    ped.dialogBag.Properties.Add(new PropertySpec("1st Codes", typeof(string),
                        "Player Info", "1st player codes: " + codes, apr.Code1));
                    ped.dialogBag.Properties.Add(new PropertySpec("2nd Codes", typeof(string),
                        "Player Info", "2nd player codes: " + codes, apr.Code2));
                    ped.dialogBag.Properties.Add(new PropertySpec("3rd Codes", typeof(string),
                        "Player Info", "3rd player codes: " + codes, apr.Code3));
                    ped.dialogBag.Properties.Add(new PropertySpec("4th Codes", typeof(string),
                        "Player Info", "4th player codes: " + codes, apr.Code4));

                    ped.dialogBag.GetValue += new PropertySpecEventHandler(dialogBag_GetValue);
                    ped.dialogBag.SetValue += new PropertySpecEventHandler(dialogBag_SetValue);

                    aprSelected = apr;

                    ped.InitializeGrid();
                    ped.Height = 360 + 20 * ped.dialogBag.Properties.Count;
                    ped.Width = 450;
                    ped.Text = "Actions: New Added=" + newAddedActions.ToString() + 
                        ",Already Present=" + alreadyPresentActions.ToString();


                    ped.ShowDialog();

                    actionAnalysis1.ActionParsing.AddActionParsingRow(apr);

                    newAddedActions++;
                }
                else
                {
                    alreadyPresentActions++;
                }
            }

            MessageBox.Show("New added actions = "+ newAddedActions.ToString() + 
                "\nalready present actions = " + alreadyPresentActions.ToString());

            this.Text = "Action Analysis Editor: " +
                actionAnalysis1.ActionParsing.Count.ToString() +
                " actions translated";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.Default.LastSavedFile == "")
            {
                saveAsToolStripMenuItem_Click(sender, e);
                return;
            }

            actionAnalysis1.WriteXml(Settings.Default.LastSavedFile);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = Settings.Default.LastSavedFile;
            if (sfd.FileName == "") 
            {
                string defaultDirectory = Settings.Default.DefaultDirectory;
                sfd.FileName = Path.Combine(defaultDirectory, "ActionAnalysis.xml");
            }

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.LastSavedFile = sfd.FileName;
                Settings.Default.Save();
                actionAnalysis1.WriteXml(Settings.Default.LastSavedFile);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.FileName = Settings.Default.LastSavedFile;
            if (ofd.FileName == "")
            {
                string defaultDirectory = Settings.Default.DefaultDirectory;
                ofd.FileName = Path.Combine(defaultDirectory, "ActionAnalysis.xml");
            }

            ofd.FileName = Settings.Default.LastSavedFile;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.LastSavedFile = ofd.FileName;
                actionAnalysis1.ReadXml(Settings.Default.LastSavedFile);
            }

            this.Text = "Action Analysis Editor: " +
                actionAnalysis1.ActionParsing.Count.ToString() +
                " actions translated";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Settings.Default.LastSavedFile != "")
            {
                actionAnalysis1.ReadXml(Settings.Default.LastSavedFile);
            }

            this.Text = "Action Analysis Editor: " +
                actionAnalysis1.ActionParsing.Count.ToString() +
                " actions translated";
        }

        private void deleteActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0) return;
            int row = dataGridView1.SelectedCells[0].RowIndex;
            DataRowView drv = (DataRowView)dataGridView1.Rows[row].DataBoundItem;
            ActionAnalysis.ActionParsingRow apr = (ActionAnalysis.ActionParsingRow)drv.Row;

            if (MessageBox.Show("Delete the action row: \n\"" + apr.Description + "\"?",
                "Delete Action", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                actionAnalysis1.ActionParsing.RemoveActionParsingRow(apr);
            }

            this.Text = "Action Analysis Editor: " +
                actionAnalysis1.ActionParsing.Count.ToString() +
                " actions translated";
        }
    }
}