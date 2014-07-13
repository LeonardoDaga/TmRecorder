using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using TMR_YouthDevelopment.Properties;
using System.IO;

namespace TMRecorder
{
    public partial class YouthDevelopment : Form
    {
        public bool isDirty = false;
        private YouthDev.ScoutReportRow ydSelectedSrr = null;

        public YouthDevelopment()
        {
            InitializeComponent();

            Text = "Youth Development - Youth Level " + Settings.Default.YouthLevel.ToString();
        }

        private void pasteYouthReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string page = "";
            if (Clipboard.ContainsData(System.Windows.Forms.DataFormats.Html))
            {
                page = (string)Clipboard.GetData(DataFormats.Html);

                if (page.Contains("SourceURL:http://trophymanager.com/ungdom.php"))
                    page = page.Replace("http://trophymanager.com/ungdom.php", "SourceURL:<TM - Ungdom>");
                else
                    page = "";
            }

            if (page == "")
                page = Clipboard.GetText();

            if (!page.Contains("TM - Ungdom"))
            {
                MessageBox.Show("The pasted HTML code is not valid");
                return;
            }

            youthDev.ParsePlayerPage(page, Settings.Default.YouthLevel, Settings.Default.HomeNation);

            isDirty = true;
        }

        private void updateYouthDevelopmentLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyEditor ped = new PropertyEditor();
            ped.dialogBag.Properties.Add(new PropertySpec("Youth Development Level", typeof(int),
                null, "The actual level of your Youth development structure", Settings.Default.YouthLevel));
            ped.dialogBag.GetValue += new PropertySpecEventHandler(dialogBag_GetValue);
            ped.dialogBag.SetValue += new PropertySpecEventHandler(dialogBag_SetValue);

            ped.InitializeGrid();

            ped.ShowDialog();

            Text = "Youth Development - Youth Level " + Settings.Default.YouthLevel.ToString();
            Settings.Default.Save();

            isDirty = true;
        }

        void dialogBag_SetValue(object sender, PropertySpecEventArgs e)
        {
            switch (e.Property.Name)
            {
                case "Youth Development Level": Settings.Default.YouthLevel = (int)e.Value; break;
            }
            isDirty = true;
        }

        void dialogBag_GetValue(object sender, PropertySpecEventArgs e)
        {
            switch (e.Property.Name)
            {
                case "Youth Development Level": 
                    e.Value = Settings.Default.YouthLevel; 
                    break;
            }
        }

        private void dataGridGiocatori_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int ID = (int)dataGridGiocatori[0, e.RowIndex].Value;

            YouthDev.ScoutReportRow ydSrr = youthDev.ScoutReport.FindByID(ID);

            PropertyEditor ped = new PropertyEditor();
            //PropertySpec ps = new PropertySpec("Player Name", typeof(string), null, "Name of the player",
            //    ydSrr.Name);
            //ps.Attributes = new Attribute[] {ReadOnlyAttribute.Yes};
            //ped.dialogBag.Properties.Add(ps);

            ped.dialogBag.Properties.Add(new PropertySpec("Name", typeof(string), "Data of the Player", "Name of the player",
                ydSrr.Name));
            ped.dialogBag.Properties.Add(new PropertySpec("Age", typeof(int), "Data of the Player", "Age of the player",
                ydSrr.Age));
            ped.dialogBag.Properties.Add(new PropertySpec("Week", typeof(int), "Development", 
                "TM Week of the Review: The actual week is " + TmWeek.GetTmAbsWk(DateTime.Now).ToString(),
                ydSrr.Week));
            ped.dialogBag.Properties.Add(new PropertySpec("FP", typeof(string), "Data of the Player", "Preferred Position",
                ydSrr.FP));

            ped.dialogBag.Properties.Add(new PropertySpec("Str", typeof(decimal), "Skill", "Strength",
                ydSrr.For));
            ped.dialogBag.Properties.Add(new PropertySpec("Res", typeof(decimal), "Skill", "Resistance",
                ydSrr.Res));
            ped.dialogBag.Properties.Add(new PropertySpec("Pac", typeof(decimal), "Skill", "Pace",
                ydSrr.Vel));

            ped.dialogBag.Properties.Add(new PropertySpec("Mar", typeof(decimal), "Skill", "Marking",
                ydSrr.Mar_Pre));
            ped.dialogBag.Properties.Add(new PropertySpec("Tak", typeof(decimal), "Skill", "Takling",
                ydSrr.Con_Uno));
            ped.dialogBag.Properties.Add(new PropertySpec("Wor", typeof(decimal), "Skill", "Worth",
                ydSrr.Wor_Rif));
            ped.dialogBag.Properties.Add(new PropertySpec("Pos", typeof(decimal), "Skill", "Position",
                ydSrr.Pos_Aer));
            ped.dialogBag.Properties.Add(new PropertySpec("Pas", typeof(decimal), "Skill", "Passage",
                ydSrr.Pas_Ele));
            ped.dialogBag.Properties.Add(new PropertySpec("Cro", typeof(decimal), "Skill", "Cross",
                ydSrr.Cro_Com));
            ped.dialogBag.Properties.Add(new PropertySpec("Tec", typeof(decimal), "Skill", "Tecnique",
                ydSrr.Tec_Tir));
            ped.dialogBag.Properties.Add(new PropertySpec("Hea", typeof(decimal), "Skill", "Heading",
                ydSrr.Tes_Lan));
            ped.dialogBag.Properties.Add(new PropertySpec("Fin", typeof(decimal), "Skill", "Finalization",
                ydSrr.Fin));
            ped.dialogBag.Properties.Add(new PropertySpec("Lon", typeof(decimal), "Skill", "Long Passage",
                ydSrr.Tir));
            ped.dialogBag.Properties.Add(new PropertySpec("Set", typeof(decimal), "Skill", "Set Pieces",
                ydSrr.Cal));

            if (ydSrr.IsTeamScoutsVoteNull())
                ydSrr.TeamScoutsVote = 0;
            ped.dialogBag.Properties.Add(new PropertySpec("Youth Scout Vote", typeof(int),
                "Development", "The vote of the Youths Development Scouts", ydSrr.YouthScoutVote));
            ped.dialogBag.Properties.Add(new PropertySpec("Team Scouts Vote", typeof(int),
                "Development", "The vote of the Team Scouts", ydSrr.TeamScoutsVote));
            ped.dialogBag.Properties.Add(new PropertySpec("Promotion Youth Level", typeof(int),
                "Development", "The level of your Youth development structure at the time of the promotion", 
                ydSrr.PromotYouthLev));

            if (ydSrr.IsRealASINull()) ydSrr.RealASI = 0;
            ped.dialogBag.Properties.Add(new PropertySpec("Real ASI", typeof(int),
                "Development", "The Real ASI, once promoted", ydSrr.RealASI));
            ped.dialogBag.Properties.Add(new PropertySpec("Promoted", typeof(bool),
                "Development", "True if the players has been promoted", ydSrr.Promoted));

            ped.dialogBag.GetValue += new PropertySpecEventHandler(dialogBag_GetPlayerValue);
            ped.dialogBag.SetValue += new PropertySpecEventHandler(dialogBag_SetPlayerValue);

            ydSelectedSrr = ydSrr;

            ped.InitializeGrid();

            ped.ShowDialog();
        }

        void dialogBag_GetPlayerValue(object sender, PropertySpecEventArgs e)
        {
            switch (e.Property.Name)
            {
                case "Name": e.Value = ydSelectedSrr.Name; break;
                case "Age": e.Value = ydSelectedSrr.Age; break;
                case "Week": e.Value = ydSelectedSrr.Week; break;
                case "FP": e.Value = ydSelectedSrr.FP; break;

                case "Str": e.Value = ydSelectedSrr.For; break;
                case "Res": e.Value = ydSelectedSrr.Res; break;
                case "Pac": e.Value = ydSelectedSrr.Vel; break;

                case "Mar": e.Value = ydSelectedSrr.Mar_Pre; break;
                case "Tak": e.Value = ydSelectedSrr.Con_Uno; break;
                case "Wor": e.Value = ydSelectedSrr.Wor_Rif; break;

                case "Pos": e.Value = ydSelectedSrr.Pos_Aer; break;
                case "Pas": e.Value = ydSelectedSrr.Pas_Ele; break;
                case "Cro": e.Value = ydSelectedSrr.Cro_Com; break;
                case "Tec": e.Value = ydSelectedSrr.Tec_Tir; break;
                case "Hea": e.Value = ydSelectedSrr.Tes_Lan; break;

                case "Fin": e.Value = ydSelectedSrr.Fin; break;
                case "Lon": e.Value = ydSelectedSrr.Tir; break;
                case "Set": e.Value = ydSelectedSrr.Cal; break;

                case "Youth Scout Vote": e.Value = ydSelectedSrr.YouthScoutVote; break;
                case "Team Scouts Vote": e.Value = ydSelectedSrr.TeamScoutsVote; break;
                case "Promotion Youth Level": e.Value = ydSelectedSrr.PromotYouthLev; break;

                case "Real ASI": e.Value = ydSelectedSrr.RealASI; break;
                case "Promoted": e.Value = ydSelectedSrr.Promoted; break;
            }
        }

        void dialogBag_GetGKValue(object sender, PropertySpecEventArgs e)
        {
            switch (e.Property.Name)
            {
                case "Name": e.Value = ydSelectedSrr.Name; break;
                case "Age": e.Value = ydSelectedSrr.Age; break;
                case "Week": e.Value = ydSelectedSrr.Week; break;
                case "FP": e.Value = ydSelectedSrr.FP; break;

                case "Str": e.Value = ydSelectedSrr.For; break;
                case "Res": e.Value = ydSelectedSrr.Res; break;
                case "Pac": e.Value = ydSelectedSrr.Vel; break;

                case "Han": e.Value = ydSelectedSrr.Mar_Pre; break;
                case "One": e.Value = ydSelectedSrr.Con_Uno; break;
                case "Ref": e.Value = ydSelectedSrr.Wor_Rif; break;

                case "Ari": e.Value = ydSelectedSrr.Pos_Aer; break;
                case "Jum": e.Value = ydSelectedSrr.Pas_Ele; break;
                case "Com": e.Value = ydSelectedSrr.Cro_Com; break;
                case "Kic": e.Value = ydSelectedSrr.Tec_Tir; break;
                case "Thr": e.Value = ydSelectedSrr.Tes_Lan; break;

                case "Youth Scout Vote": e.Value = ydSelectedSrr.YouthScoutVote; break;
                case "Team Scouts Vote": e.Value = ydSelectedSrr.TeamScoutsVote; break;
                case "Promotion Youth Level": e.Value = ydSelectedSrr.PromotYouthLev; break;

                case "Real ASI": e.Value = ydSelectedSrr.RealASI; break;
                case "Promoted": e.Value = ydSelectedSrr.Promoted; break;
            }
        }

        void dialogBag_SetPlayerValue(object sender, PropertySpecEventArgs e)
        {
            switch (e.Property.Name)
            {
                case "Name": ydSelectedSrr.Name = (string)e.Value; break;
                case "Age": ydSelectedSrr.Age = (int)e.Value; break;
                case "Week": ydSelectedSrr.Week = (int)e.Value; break;
                case "FP": 
                    ydSelectedSrr.FP = (string)e.Value;
                    ydSelectedSrr.FPn = Tm_Utility.FPToNumber(ydSelectedSrr.FP);
                    break;
                case "Str": 
                    ydSelectedSrr.For = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Res": 
                    ydSelectedSrr.Res = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Pac": 
                    ydSelectedSrr.Vel = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Mar": 
                    ydSelectedSrr.Mar_Pre = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Tak": 
                    ydSelectedSrr.Con_Uno = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Wor": 
                    ydSelectedSrr.Wor_Rif = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Pos": 
                    ydSelectedSrr.Pos_Aer = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Pas": 
                    ydSelectedSrr.Pas_Ele = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Cro": 
                    ydSelectedSrr.Cro_Com = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Tec": 
                    ydSelectedSrr.Tec_Tir = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Hea": 
                    ydSelectedSrr.Tes_Lan = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Fin": 
                    ydSelectedSrr.Fin = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Lon": 
                    ydSelectedSrr.Tir = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Set": 
                    ydSelectedSrr.Cal = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;

                case "Youth Scout Vote": ydSelectedSrr.YouthScoutVote = (int)e.Value; break;
                case "Team Scouts Vote": ydSelectedSrr.TeamScoutsVote = (int)e.Value; break;
                case "Promotion Youth Level": ydSelectedSrr.PromotYouthLev = (int)e.Value; break;

                case "Real ASI": ydSelectedSrr.RealASI = (int)e.Value; break;
                case "Promoted": ydSelectedSrr.Promoted = (bool)e.Value; break;
            }
            isDirty = true;
        }

        void dialogBag_SetGKValue(object sender, PropertySpecEventArgs e)
        {
            switch (e.Property.Name)
            {
                case "Name": ydSelectedSrr.Name = (string)e.Value; break;
                case "Age": ydSelectedSrr.Age = (int)e.Value; break;
                case "Week": ydSelectedSrr.Week = (int)e.Value; break;
                case "FP":
                    ydSelectedSrr.FP = (string)e.Value;
                    ydSelectedSrr.FPn = Tm_Utility.FPToNumber(ydSelectedSrr.FP);
                    break;
                case "Str":
                    ydSelectedSrr.For = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Res":
                    ydSelectedSrr.Res = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Pac":
                    ydSelectedSrr.Vel = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Han":
                    ydSelectedSrr.Mar_Pre = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "One":
                    ydSelectedSrr.Con_Uno = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Ref":
                    ydSelectedSrr.Wor_Rif = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Ari":
                    ydSelectedSrr.Pos_Aer = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Jum":
                    ydSelectedSrr.Pas_Ele = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Com":
                    ydSelectedSrr.Cro_Com = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Kic":
                    ydSelectedSrr.Tec_Tir = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;
                case "Thr":
                    ydSelectedSrr.Tes_Lan = (decimal)e.Value;
                    ydSelectedSrr.SkillSum = ydSelectedSrr.GetSkillSum();
                    ydSelectedSrr.EstimASI = ydSelectedSrr.GetEstimASI();
                    break;

                case "Youth Scout Vote": ydSelectedSrr.YouthScoutVote = (int)e.Value; break;
                case "Team Scouts Vote": ydSelectedSrr.TeamScoutsVote = (int)e.Value; break;
                case "Promotion Youth Level": ydSelectedSrr.PromotYouthLev = (int)e.Value; break;

                case "Real ASI": ydSelectedSrr.RealASI = (int)e.Value; break;
                case "Promoted": ydSelectedSrr.Promoted = (bool)e.Value; break;
            }
            isDirty = true;
        }

        private void dataGridPortieri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int ID = (int)dataGridPortieri[0, e.RowIndex].Value;

            YouthDev.ScoutReportRow ydSrr = youthDev.ScoutReport.FindByID(ID);

            PropertyEditor ped = new PropertyEditor();

            ped.dialogBag.Properties.Add(new PropertySpec("Name", typeof(string), "Data of the Player", "Name of the player",
                ydSrr.Name));
            ped.dialogBag.Properties.Add(new PropertySpec("Age", typeof(int), "Data of the Player", "Age of the player",
                ydSrr.Age));
            ped.dialogBag.Properties.Add(new PropertySpec("Week", typeof(int), "Development",
                "TM Week of the Review: The actual week is " + TmWeek.GetTmAbsWk(DateTime.Now).ToString(),
                ydSrr.Week));
            ped.dialogBag.Properties.Add(new PropertySpec("FP", typeof(string), "Data of the Player", "Preferred Position",
                ydSrr.FP));

            ped.dialogBag.Properties.Add(new PropertySpec("Str", typeof(decimal), "Skill", "Strength",
                ydSrr.For));
            ped.dialogBag.Properties.Add(new PropertySpec("Res", typeof(decimal), "Skill", "Resistance",
                ydSrr.Res));
            ped.dialogBag.Properties.Add(new PropertySpec("Pac", typeof(decimal), "Skill", "Pace",
                ydSrr.Vel));

            ped.dialogBag.Properties.Add(new PropertySpec("Han", typeof(decimal), "Skill", "Handling",
                ydSrr.Mar_Pre));
            ped.dialogBag.Properties.Add(new PropertySpec("One", typeof(decimal), "Skill", "One-on-One",
                ydSrr.Con_Uno));
            ped.dialogBag.Properties.Add(new PropertySpec("Ref", typeof(decimal), "Skill", "Reflexes",
                ydSrr.Wor_Rif));
            ped.dialogBag.Properties.Add(new PropertySpec("Ari", typeof(decimal), "Skill", "Arial",
                ydSrr.Pos_Aer));
            ped.dialogBag.Properties.Add(new PropertySpec("Jum", typeof(decimal), "Skill", "Jumps",
                ydSrr.Pas_Ele));
            ped.dialogBag.Properties.Add(new PropertySpec("Com", typeof(decimal), "Skill", "Communication",
                ydSrr.Cro_Com));
            ped.dialogBag.Properties.Add(new PropertySpec("Kic", typeof(decimal), "Skill", "Kicks",
                ydSrr.Tec_Tir));
            ped.dialogBag.Properties.Add(new PropertySpec("Thr", typeof(decimal), "Skill", "Throws",
                ydSrr.Tes_Lan));

            if (ydSrr.IsTeamScoutsVoteNull())
                ydSrr.TeamScoutsVote = 0;
            ped.dialogBag.Properties.Add(new PropertySpec("Youth Scout Vote", typeof(int),
                "Development", "The vote of the Youths Development Scouts", ydSrr.YouthScoutVote));
            ped.dialogBag.Properties.Add(new PropertySpec("Team Scouts Vote", typeof(int),
                "Development", "The vote of the Team Scouts", ydSrr.TeamScoutsVote));
            ped.dialogBag.Properties.Add(new PropertySpec("Promotion Youth Level", typeof(int),
                "Development", "The level of your Youth development structure at the time of the promotion",
                ydSrr.PromotYouthLev));

            if (ydSrr.IsRealASINull()) ydSrr.RealASI = 0;
            ped.dialogBag.Properties.Add(new PropertySpec("Real ASI", typeof(int),
                "Development", "The Real ASI, once promoted", ydSrr.RealASI));
            ped.dialogBag.Properties.Add(new PropertySpec("Promoted", typeof(bool),
                "Development", "True if the players has been promoted", ydSrr.Promoted));

            ped.dialogBag.GetValue += new PropertySpecEventHandler(dialogBag_GetGKValue);
            ped.dialogBag.SetValue += new PropertySpecEventHandler(dialogBag_SetGKValue);

            ydSelectedSrr = ydSrr;

            ped.InitializeGrid();

            ped.ShowDialog();
        }

        private void YouthDevelopment_Load(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(Path.Combine(Settings.Default.DefaultDirectory, "YouthDevelopment.xml"));
            if (fi.Exists)
            {
                youthDev.Clear();
                youthDev.ReadXml(fi.FullName);
            }
            isDirty = false;
        }

        private void YouthDevelopment_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void reloadListWithoutChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(Path.Combine(Settings.Default.DefaultDirectory, "YouthDevelopment.xml"));
            if (fi.Exists)
            {
                youthDev.Clear();
                youthDev.ReadXml(fi.FullName);
            }
            else
                MessageBox.Show("No Youth Development List Saved");
        }

        private void addManuallyAPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YouthDev.ScoutReportRow ydSrr = youthDev.ScoutReport.NewScoutReportRow();

            PropertyEditor ped = new PropertyEditor();

            ydSrr.Name = "New Player";
            ydSrr.Age = 16;
            ydSrr.Week = TmWeek.GetTmAbsWk(DateTime.Now);
            ydSrr.FP = "DC";
            ydSrr.For = 0;
            ydSrr.Res = 0;
            ydSrr.Vel = 0;
            ydSrr.Mar_Pre = 0;
            ydSrr.Con_Uno = 0;
            ydSrr.Wor_Rif = 0;
            ydSrr.Pos_Aer = 0;
            ydSrr.Pas_Ele = 0;
            ydSrr.Cro_Com = 0;
            ydSrr.Tec_Tir = 0;
            ydSrr.Tes_Lan = 0;
            ydSrr.Fin = 0;
            ydSrr.Tir = 0;
            ydSrr.Cal = 0;
            ydSrr.YouthScoutVote = 0;
            ydSrr.PromotYouthLev = Settings.Default.YouthLevel;
            ydSrr.RealASI = 0;
            ydSrr.Promoted = false;

            ped.dialogBag.Properties.Add(new PropertySpec("Name", typeof(string), "Data of the Player", "Name of the player",
                ydSrr.Name));
            ped.dialogBag.Properties.Add(new PropertySpec("Age", typeof(int), "Data of the Player", "Age of the player",
                ydSrr.Age));
            ped.dialogBag.Properties.Add(new PropertySpec("Week", typeof(int), "Development",
                "TM Week of the Review: The actual week is " + TmWeek.GetTmAbsWk(DateTime.Now).ToString(),
                ydSrr.Week));
            ped.dialogBag.Properties.Add(new PropertySpec("FP", typeof(string), "Data of the Player", "Preferred Position",
                ydSrr.FP));

            ped.dialogBag.Properties.Add(new PropertySpec("Str", typeof(decimal), "Skill", "Strength",
                ydSrr.For));
            ped.dialogBag.Properties.Add(new PropertySpec("Res", typeof(decimal), "Skill", "Resistance",
                ydSrr.Res));
            ped.dialogBag.Properties.Add(new PropertySpec("Pac", typeof(decimal), "Skill", "Pace",
                ydSrr.Vel));

            ped.dialogBag.Properties.Add(new PropertySpec("Mar", typeof(decimal), "Skill", "Marking",
                ydSrr.Mar_Pre));
            ped.dialogBag.Properties.Add(new PropertySpec("Tak", typeof(decimal), "Skill", "Takling",
                ydSrr.Con_Uno));
            ped.dialogBag.Properties.Add(new PropertySpec("Wor", typeof(decimal), "Skill", "Worth",
                ydSrr.Wor_Rif));
            ped.dialogBag.Properties.Add(new PropertySpec("Pos", typeof(decimal), "Skill", "Position",
                ydSrr.Pos_Aer));
            ped.dialogBag.Properties.Add(new PropertySpec("Pas", typeof(decimal), "Skill", "Passage",
                ydSrr.Pas_Ele));
            ped.dialogBag.Properties.Add(new PropertySpec("Cro", typeof(decimal), "Skill", "Cross",
                ydSrr.Cro_Com));
            ped.dialogBag.Properties.Add(new PropertySpec("Tec", typeof(decimal), "Skill", "Tecnique",
                ydSrr.Tec_Tir));
            ped.dialogBag.Properties.Add(new PropertySpec("Hea", typeof(decimal), "Skill", "Heading",
                ydSrr.Tes_Lan));
            ped.dialogBag.Properties.Add(new PropertySpec("Fin", typeof(decimal), "Skill", "Finalization",
                ydSrr.Fin));
            ped.dialogBag.Properties.Add(new PropertySpec("Lon", typeof(decimal), "Skill", "Long Passage",
                ydSrr.Tir));
            ped.dialogBag.Properties.Add(new PropertySpec("Set", typeof(decimal), "Skill", "Set Pieces",
                ydSrr.Cal));

            if (ydSrr.IsTeamScoutsVoteNull())
                ydSrr.TeamScoutsVote = 0;
            ped.dialogBag.Properties.Add(new PropertySpec("Youth Scout Vote", typeof(int),
                "Development", "The vote of the Youths Development Scouts", ydSrr.YouthScoutVote));
            ped.dialogBag.Properties.Add(new PropertySpec("Team Scouts Vote", typeof(int),
                "Development", "The vote of the Team Scouts", ydSrr.TeamScoutsVote));
            ped.dialogBag.Properties.Add(new PropertySpec("Promotion Youth Level", typeof(int),
                "Development", "The level of your Youth development structure at the time of the promotion",
                ydSrr.PromotYouthLev));

            if (ydSrr.IsRealASINull()) ydSrr.RealASI = 0;
            ped.dialogBag.Properties.Add(new PropertySpec("Real ASI", typeof(int),
                "Development", "The Real ASI, once promoted", ydSrr.RealASI));
            ped.dialogBag.Properties.Add(new PropertySpec("Promoted", typeof(bool),
                "Development", "True if the players has been promoted", ydSrr.Promoted));

            ped.dialogBag.GetValue += new PropertySpecEventHandler(dialogBag_GetPlayerValue);
            ped.dialogBag.SetValue += new PropertySpecEventHandler(dialogBag_SetPlayerValue);

            ydSelectedSrr = ydSrr;

            ped.InitializeGrid();

            ped.ShowDialog();

            ydSrr.ID = ydSrr.GetHashCode();
            ydSrr.Nationality = Settings.Default.HomeNation;
            youthDev.ScoutReport.AddScoutReportRow(ydSrr);
        }

        private void addManuallyAGKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YouthDev.ScoutReportRow ydSrr = youthDev.ScoutReport.NewScoutReportRow();

            PropertyEditor ped = new PropertyEditor();

            ydSrr.Name = "New Player";
            ydSrr.Age = 16;
            ydSrr.Week = TmWeek.GetTmAbsWk(DateTime.Now);
            ydSrr.FP = "GK";
            ydSrr.For = 0;
            ydSrr.Res = 0;
            ydSrr.Vel = 0;
            ydSrr.Mar_Pre = 0;
            ydSrr.Con_Uno = 0;
            ydSrr.Wor_Rif = 0;
            ydSrr.Pos_Aer = 0;
            ydSrr.Pas_Ele = 0;
            ydSrr.Cro_Com = 0;
            ydSrr.Tec_Tir = 0;
            ydSrr.Tes_Lan = 0;

            ydSrr.Fin = 0;
            ydSrr.Tir = 0;
            ydSrr.Cal = 0;

            ydSrr.YouthScoutVote = 0;
            ydSrr.PromotYouthLev = Settings.Default.YouthLevel;
            ydSrr.RealASI = 0;
            ydSrr.Promoted = false;

            ped.dialogBag.Properties.Add(new PropertySpec("Name", typeof(string), "Data of the Player", "Name of the player",
                ydSrr.Name));
            ped.dialogBag.Properties.Add(new PropertySpec("Age", typeof(int), "Data of the Player", "Age of the player",
                ydSrr.Age));
            ped.dialogBag.Properties.Add(new PropertySpec("Week", typeof(int), "Development",
                "TM Week of the Review: The actual week is " + TmWeek.GetTmAbsWk(DateTime.Now).ToString(),
                ydSrr.Week));
            ped.dialogBag.Properties.Add(new PropertySpec("FP", typeof(string), "Data of the Player", "Preferred Position",
                ydSrr.FP));

            ped.dialogBag.Properties.Add(new PropertySpec("Str", typeof(decimal), "Skill", "Strength",
                ydSrr.For));
            ped.dialogBag.Properties.Add(new PropertySpec("Res", typeof(decimal), "Skill", "Resistance",
                ydSrr.Res));
            ped.dialogBag.Properties.Add(new PropertySpec("Pac", typeof(decimal), "Skill", "Pace",
                ydSrr.Vel));

            ped.dialogBag.Properties.Add(new PropertySpec("Han", typeof(decimal), "Skill", "Handling",
                ydSrr.Mar_Pre));
            ped.dialogBag.Properties.Add(new PropertySpec("One", typeof(decimal), "Skill", "One-on-One",
                ydSrr.Con_Uno));
            ped.dialogBag.Properties.Add(new PropertySpec("Ref", typeof(decimal), "Skill", "Reflexes",
                ydSrr.Wor_Rif));
            ped.dialogBag.Properties.Add(new PropertySpec("Ari", typeof(decimal), "Skill", "Arial",
                ydSrr.Pos_Aer));
            ped.dialogBag.Properties.Add(new PropertySpec("Jum", typeof(decimal), "Skill", "Jumps",
                ydSrr.Pas_Ele));
            ped.dialogBag.Properties.Add(new PropertySpec("Com", typeof(decimal), "Skill", "Communication",
                ydSrr.Cro_Com));
            ped.dialogBag.Properties.Add(new PropertySpec("Kic", typeof(decimal), "Skill", "Kicks",
                ydSrr.Tec_Tir));
            ped.dialogBag.Properties.Add(new PropertySpec("Thr", typeof(decimal), "Skill", "Throws",
                ydSrr.Tes_Lan));

            if (ydSrr.IsTeamScoutsVoteNull())
                ydSrr.TeamScoutsVote = 0;
            ped.dialogBag.Properties.Add(new PropertySpec("Youth Scout Vote", typeof(int),
                "Development", "The vote of the Youths Development Scouts", ydSrr.YouthScoutVote));
            ped.dialogBag.Properties.Add(new PropertySpec("Team Scouts Vote", typeof(int),
                "Development", "The vote of the Team Scouts", ydSrr.TeamScoutsVote));
            ped.dialogBag.Properties.Add(new PropertySpec("Promotion Youth Level", typeof(int),
                "Development", "The level of your Youth development structure at the time of the promotion",
                ydSrr.PromotYouthLev));

            if (ydSrr.IsRealASINull()) ydSrr.RealASI = 0;
            ped.dialogBag.Properties.Add(new PropertySpec("Real ASI", typeof(int),
                "Development", "The Real ASI, once promoted", ydSrr.RealASI));
            ped.dialogBag.Properties.Add(new PropertySpec("Promoted", typeof(bool),
                "Development", "True if the players has been promoted", ydSrr.Promoted));

            ped.dialogBag.GetValue += new PropertySpecEventHandler(dialogBag_GetGKValue);
            ped.dialogBag.SetValue += new PropertySpecEventHandler(dialogBag_SetGKValue);

            ydSelectedSrr = ydSrr;

            ped.InitializeGrid();

            ped.ShowDialog();

            ydSrr.ID = ydSrr.GetHashCode();
            ydSrr.Nationality = Settings.Default.HomeNation;
            youthDev.ScoutReport.AddScoutReportRow(ydSrr);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            youthDev.WriteXml(Path.Combine(Settings.Default.DefaultDirectory, "YouthDevelopment.xml"));
            isDirty = false;
        }

        private void YouthDevelopment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDirty)
            {
                DialogResult res = MessageBox.Show("Save Changes?", "Youth Development", MessageBoxButtons.YesNoCancel);

                if (res == DialogResult.Yes)
                    youthDev.WriteXml(Path.Combine(Settings.Default.DefaultDirectory, "YouthDevelopment.xml"));
                else if (res == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void deleteSelectedRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Data.DataRowView sel;

            if (this.tabControl1.SelectedTab == this.tabPage1)
            {
                sel = (System.Data.DataRowView)dataGridGiocatori.SelectedRows[0].DataBoundItem;
            }
            else
            {
                sel = (System.Data.DataRowView)dataGridPortieri.SelectedRows[0].DataBoundItem;
            }

            YouthDev.ScoutReportRow ydSrr = (YouthDev.ScoutReportRow)sel.Row;

            DialogResult res = MessageBox.Show("Delete Player " + ydSrr.Name + "?",
                                    "Youth Development",
                                    MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                youthDev.ScoutReport.RemoveScoutReportRow(ydSrr);
                isDirty = true;
            }
        }
    }
}