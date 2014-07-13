using System.Collections.Generic;
using Common;
using System.Windows.Forms;
using System;
using SendFileTo;
using System.IO;
using System.Globalization;
using Languages;

namespace NTR_Common
{
    partial class TeamDS
    {
        public TSquad Squad = new TSquad();

        #region Alarm Management

        public List<GiocatoriNSkillRow> AlarmList = new List<GiocatoriNSkillRow>();

        public void LoadBidAlarms()
        {
            // search in the list of players first
            foreach (GiocatoriNSkillRow adr in GiocatoriNSkill)
            {
                if (adr.Alarm)
                {
                    adr.AlarmGenerated = false;
                    AlarmList.Add(adr);
                }
            }
        }

        public void AddEndBidAlarm(GiocatoriNSkillRow adr)
        {
            AlarmForm af = new AlarmForm();
            af.txtEndTime.Text = adr.Ends.ToShortDateString() + " " + adr.Ends.ToShortTimeString();
            af.txtMinutesBefore.Text = "5";
            af.Text = "Set Alarm for " + adr.Nome;
            af.txtPlayerID.Text = adr.PlayerID.ToString();

            if (af.ShowDialog() == DialogResult.OK)
            {
                adr.Alarm = true;
                adr.AlarmTime = adr.Ends.AddMinutes(-int.Parse(af.txtMinutesBefore.Text));
                AlarmList.Add(adr);
                adr.AlarmGenerated = false;
                adr.PlayerID = int.Parse(af.txtPlayerID.Text);
            }
        }

        public bool CheckPendingAlarms()
        {
            bool areThereAlarms = false;

            foreach (GiocatoriNSkillRow row in AlarmList)
            {
                try
                {
                    string res = row.Nome;
                }
                catch (System.Data.RowNotInTableException)
                {
                    AlarmList.Remove(row);
                    break;
                }

                if (row.Alarm) areThereAlarms = true;

                if ((DateTime.Now > row.AlarmTime) && (row.AlarmGenerated == false))
                {
                    RingDialog rd = new RingDialog();
                    rd.Text = "Transfert Manager Alert!!";
                    rd.Message.Text = "The player " + row.Nome + " bids end at " +
                        row.Ends.ToShortTimeString() + "!";
                    rd.TopMost = true;
                    rd.Show();
                    row.AlarmGenerated = true;
                }
            }

            return areThereAlarms;
        }

        #endregion

        public int last_week_loaded
        {
            get
            {
                if (Data.Count == 0)
                {
                    Data.AddDataRow(Data.NewDataRow());
                    Data[0].last_week_loaded = -1;
                }
                return Data[0].last_week_loaded;
            }
            set
            {
                if (Data.Count == 0)
                {
                    Data.AddDataRow(Data.NewDataRow());
                }
                Data[0].last_week_loaded = value;
            }
        }

        #region Gain Set Management
        public GainDS GD = new GainDS();
        public bool LoadGains(string gainSetName)
        {
            FileInfo fi = new FileInfo(gainSetName);

            if (fi.Exists)
            {
                GD.Clear();
                GD.ReadXml(gainSetName);
                GD.GainDSfilename = gainSetName;
                return true;
            }
            else
            {
                if (MessageBox.Show("Select a Gain Set (Reply Yes) or use a default set (Reply No)?" +
                    "\n(A Gain set is an xml file that is used to weigth the skill of a player to evaluate his " +
                    "\nperformance in the different position of the match field. You can use the default set" +
                    "\nnow - you can change it once the tool is started. The default extension of a gain set file is 'tmgain'" +
                    "\nand you can download it from the website http://tmrecorder.insyde.it/",
                    "TM Recorder - Load Gain Set", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.FileName = gainSetName;
                    ofd.Filter = "TMGain File (*.tmgain;*.tmgain.xml)|*.tmgain;*.tmgain.xml|All Files|*.*";
                    ofd.DefaultExt = "*.tmgain*";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        GD.GainDSfilename = ofd.FileName;
                        return LoadGains(GD.GainDSfilename);
                    }
                    else
                    {
                        GD.SetDefaultValues();
                        return false;
                    }
                }
                else
                {
                    GD.SetDefaultValues();

                    SaveFileDialog ofd = new SaveFileDialog();
                    ofd.FileName = "Default.tmgain";
                    ofd.Filter = "TMGain File (*.tmgain;*.tmgain.xml)|*.tmgain;*.tmgain.xml|All Files|*.*";
                    ofd.DefaultExt = "*.tmgain*";
                    ofd.Title = "Select the location where to save the gain file";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        GD.GainDSfilename = ofd.FileName;
                        GD.WriteXml(GD.GainDSfilename);
                        return true;
                    }

                    return false;
                }
            }
        }
        #endregion

        public void LoadSquad(string squad, PlayersDS playersDS, string HomeNation)
        {
            short isReserves = 0;
            DateTime timeOfData;

            try
            {

                DialogResult res = MessageBox.Show("Is the squad data relative to today? (Press No to change the date)", "Paste Squad Data",
                    MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Cancel) return;
                if (res == DialogResult.Yes)
                {
                    timeOfData = DateTime.Today;
                }
                else
                {
                    SelectDataDate sdd = new SelectDataDate();
                    sdd.SelectedDate = DateTime.Today;
                    sdd.ShowDialog();
                    timeOfData = sdd.SelectedDate;
                }

                squad = HTML_Parser.ConvertHTML(squad);

                GiocatoriNSkill.Clear();

                // There will be two tables (0: players, 1: GK)
                List<string> tables = HTML_Parser.GetTags(squad, "TABLE");

                if (tables.Count == 0)
                {
                    MessageBox.Show("The content of what you pasted is not the one expected", "Error", MessageBoxButtons.OK);
                    return;
                }

                // Get all rows of the players table
                List<string> plRows = HTML_Parser.GetTags(tables[0], "TR");

                // Row 0 is the table header
                for (int player = 1; player < plRows.Count; player++)
                {
                    AlarmInfo ai = new AlarmInfo();

                    int ID = Squad.ParsePlayer(timeOfData, plRows[player], HomeNation, ref ai);

                    if (ID == -1) continue;

                    this.GiocatoriNSkill.AddPlayer(ID, Squad[ID], GD, ai);
                }

                // Get all rows of the gk table
                List<string> gkRows = HTML_Parser.GetTags(tables[1], "TR");

                // Row 0 is the table header
                for (int player = 0; player < gkRows.Count; player++)
                {
                    if (gkRows[player].Contains("ASI")) continue;

                    int ID = Squad.ParseGK(timeOfData, gkRows[player], HomeNation);

                    if (ID == -1) continue;

                    this.GiocatoriNSkill.AddPlayer(ID, Squad[ID], GD, null);
                }

            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                ErrorReport.Send(e, squad, Environment.StackTrace, swRelease);
                MessageBox.Show("Sorry. The importing process has failed. If you clicked ok, the info of the error have " +
                    "been sent to Led Lennon that will remove this bug as soon as possible.");
            }

        }

        partial class GiocatoriNSkillDataTable
        {
            internal void AddPlayer(int ID, PlayersDS plData, GainDS gd, AlarmInfo ai)
            {
                TeamDS.GiocatoriNSkillRow gsr = this.FindByPlayerID(ID);

                if (gsr == null)
                {
                    gsr = NewGiocatoriNSkillRow();
                    gsr.PlayerID = ID;
                    AddGiocatoriNSkillRow(gsr);
                }

                PlayersDS.FixDataRow fdr = plData.FixData[0];

                gsr.Nationality = fdr.Nationality;
                gsr.Nome = fdr.Nome;

                if (!fdr.IsNumeroNull())
                    gsr.Numero = fdr.Numero;
                else
                    gsr.Numero = 0;
                gsr.Age = TmWeek.GetAge(fdr.wBorn, DateTime.Today).Years;
                gsr.FP = fdr.FP;
                gsr.FPn = fdr.FPn;
                gsr.Ada = fdr.Ada;
                gsr.wBorn = fdr.wBorn;
                gsr.TeamID = int.Parse(fdr.TeamID);
                if (!fdr.IsRecNull()) gsr.Rec = fdr.Rec;

                if (!fdr.IsNotesNull())
                    gsr.ImportedNotes = fdr.Notes;

                int week = TmWeek.GetTmAbsWk(DateTime.Today);
                PlayersDS.VarDataRow actualVdr = plData.VarData.FindByWeek(week);
                PlayersDS.VarDataRow prevVdr = plData.VarData.FindByWeek(week - 1);
                PlayersDS.FixDataRow fixData = plData.FixDataVal;

                if (actualVdr != null)
                {
                    gsr.ASI = actualVdr.ASI;
                    gsr.GetSkills(actualVdr);
                }
                else if (prevVdr != null)
                {
                    gsr.ASI = prevVdr.ASI;
                    gsr.GetSkills(prevVdr);
                }

                if ((prevVdr != null) && (actualVdr != null))
                {
                    decimal ssNew = Tm_Utility.ASItoSkSum((decimal)actualVdr.ASI, gsr.FPn == 0);
                    decimal ssOld = Tm_Utility.ASItoSkSum((decimal)prevVdr.ASI, gsr.FPn == 0);
                    gsr.cTI = 10.0M * (ssNew - ssOld);
                }

                gsr.SSD = Tm_Utility.ASItoSkSum((decimal)gsr.ASI, gsr.FPn == 0) - gsr.SkillSum;

                if (!fixData.IsRouNull())
                    gsr.Rou = fixData.Rou;

                gsr.SetFP(gd);

                if (ai != null)
                {
                    gsr.Bid = ai.Bid;
                    if (ai.Ends != DateTime.MinValue)
                        gsr.Ends = ai.Ends;
                    else
                        gsr.SetEndsNull();
                }
            }

            public int GetIndexFromID(int actPlayerID)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].PlayerID == actPlayerID) return i;
                }

                return -1;
            }

            public int GetNextID(int actPlayerID)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].PlayerID == actPlayerID)
                    {
                        if (i + 1 < this.Count)
                        {
                            return this[i + 1].PlayerID;
                        }
                        else if (i == this.Count - 1)
                        {
                            return this[0].PlayerID;
                        }
                    }
                }

                return this[0].PlayerID;
            }

            public int GetPrevID(int actPlayerID)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].PlayerID == actPlayerID)
                    {
                        if (i == 0)
                        {
                            return this[this.Count - 1].PlayerID;
                        }
                        else if (i - 1 < this.Count)
                        {
                            return this[i - 1].PlayerID;
                        }
                    }
                }

                return this[0].PlayerID;
            }
        }

        partial class GiocatoriNSkillRow
        {
            public bool AlarmGenerated = false;
            bool isDirty = false;

            // Speciality FP amplification
            float[,] A = new float[,]{  {1.666f,1.331f,1.331f,1.496f,1.166f,1.166f,1.336f,1.000f,1.000f,1.167f,1.000f,1.000f,1.000f},
                                        {1.331f,1.666f,1.500f,1.164f,1.500f,1.331f,1.166f,1.337f,1.167f,1.000f,1.333f,1.167f,1.000f},
                                        {1.331f,1.500f,1.666f,1.164f,1.331f,1.500f,1.166f,1.167f,1.337f,1.000f,1.167f,1.333f,1.000f},
                                        {1.498f,1.166f,1.166f,1.664f,1.331f,1.331f,1.502f,1.167f,1.167f,1.335f,1.000f,1.000f,1.000f},
                                        {1.164f,1.500f,1.331f,1.332f,1.666f,1.500f,1.000f,1.504f,1.337f,1.000f,1.333f,1.167f,1.000f},
                                        {1.164f,1.331f,1.500f,1.332f,1.500f,1.666f,1.000f,1.337f,1.504f,1.000f,1.167f,1.333f,1.000f},
                                        {1.331f,1.000f,1.000f,1.496f,1.166f,1.166f,1.668f,1.337f,1.337f,1.498f,1.167f,1.167f,1.332f},
                                        {1.000f,1.331f,1.166f,1.164f,1.500f,1.331f,1.336f,1.670f,1.504f,1.167f,1.500f,1.333f,1.000f},
                                        {1.000f,1.166f,1.331f,1.164f,1.331f,1.500f,1.336f,1.504f,1.670f,1.167f,1.333f,1.500f,1.000f},
                                        {1.164f,1.000f,1.000f,1.332f,1.000f,1.000f,1.502f,1.167f,1.167f,1.665f,1.333f,1.333f,1.502f},
                                        {1.000f,1.166f,1.000f,1.000f,1.331f,1.166f,1.166f,1.504f,1.337f,1.335f,1.667f,1.500f,1.166f},
                                        {1.000f,1.000f,1.166f,1.000f,1.166f,1.331f,1.166f,1.337f,1.504f,1.335f,1.500f,1.667f,1.166f},
                                        {1.000f,1.000f,1.000f,1.164f,1.000f,1.000f,1.336f,1.000f,1.000f,1.498f,1.167f,1.167f,1.668f}};

            // Skill FP Gain
            float[,] K = new float[,] { {4.000f,3.000f,3.000f,2.880f,3.000f,3.000f,2.000f,1.560f,1.560f,1.910f,2.630f,2.630f,4.240f},
                                        {0.330f,0.430f,0.430f,1.680f,0.430f,0.430f,2.000f,1.560f,1.560f,0.270f,2.630f,2.630f,2.470f},
                                        {4.000f,5.140f,5.140f,1.680f,5.140f,5.140f,0.290f,2.670f,2.670f,0.270f,4.500f,4.500f,2.470f},
                                        {4.000f,5.140f,5.140f,2.880f,5.140f,5.140f,3.430f,2.670f,2.670f,1.910f,0.380f,0.380f,0.350f},
                                        {4.000f,5.140f,5.140f,2.880f,5.140f,5.140f,3.430f,2.670f,2.670f,1.910f,0.380f,0.380f,0.350f},
                                        {0.330f,0.430f,0.430f,2.880f,0.430f,0.430f,3.430f,2.670f,2.670f,3.270f,2.630f,2.630f,2.470f},
                                        {0.330f,0.430f,0.430f,2.880f,0.430f,0.430f,3.430f,2.670f,2.670f,3.270f,2.630f,2.630f,2.470f},
                                        {2.330f,3.000f,3.000f,2.880f,3.000f,3.000f,3.430f,2.670f,2.670f,3.270f,0.380f,0.380f,0.350f},
                                        {2.330f,3.000f,3.000f,1.680f,3.000f,3.000f,0.290f,2.670f,2.670f,0.270f,4.500f,4.500f,0.350f},
                                        {2.330f,3.000f,3.000f,1.680f,3.000f,3.000f,3.430f,2.670f,2.670f,3.270f,4.500f,4.500f,2.470f},
                                        {4.000f,3.000f,3.000f,2.880f,3.000f,3.000f,2.000f,1.560f,1.560f,1.910f,2.630f,2.630f,4.240f},
                                        {0.330f,0.430f,0.430f,0.240f,0.430f,0.430f,0.290f,0.220f,0.220f,3.270f,2.630f,2.630f,4.240f},
                                        {0.330f,0.430f,0.430f,0.240f,0.430f,0.430f,0.290f,0.220f,0.220f,3.270f,2.630f,2.630f,4.240f},
                                        {0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f}};

            string[] spec = new string[] { "DC", "DR", "DL", "DMC", "DMR", "DML", "MC", "MR", "ML", "OMC", "OMR", "OML", "FC" };
            int[] skillCol = new int[] { 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            internal void GetSkills(PlayersDS.VarDataRow vdr)
            {
                if (vdr.Is_ForNull()) return;
                For = vdr.For;
                Res = vdr.Res;
                Vel = vdr.Vel;
                Cro = vdr.Cro;
                Con = vdr.Con;
                Pas = vdr.Pas;
                Pos = vdr.Pos;
                Tec = vdr.Tec;
                Tes = vdr.Tes;
                Wor = vdr.Wor;
                Pre = vdr.Pre;
                if (FPn > 0)
                {
                    Fin = vdr.Fin;
                    Cal = vdr.Cal;
                    Dis = vdr.Dis;
                }
            }

            int _changeWeek = -1;
            GiocatoriNSkillRow _player_VDR_Change = null;
            public GiocatoriNSkillRow Player_VDR_Change
            {
                get
                {
                    TeamDS teamDS = (TeamDS)this.Table.DataSet;
                    if (_changeWeek != teamDS.last_week_loaded)
                    {
                        PlayersDS pDS = teamDS.Squad[PlayerID];

                        if (pDS.VarData.Count >= 2)
                        {
                            PlayersDS.VarDataRow lastVDR = pDS.VarData[pDS.VarData.Count - 1];
                            PlayersDS.VarDataRow prevVDR = pDS.VarData[pDS.VarData.Count - 2];
                            _player_VDR_Change = teamDS.GiocatoriNSkill.NewGiocatoriNSkillRow();
                            _player_VDR_Change.ASI = lastVDR.ASI - prevVDR.ASI;

                            for (int i = 0; i < 14; i++)
                            {
                                if (lastVDR[i + 3] != DBNull.Value)
                                    _player_VDR_Change[i + 7] = (decimal)lastVDR[i + 3] - (decimal)prevVDR[i + 3];
                            }
                            _changeWeek = lastVDR.Week;
                        }
                        else
                        {
                            PlayersDS.VarDataRow lastVDR = pDS.VarData[pDS.VarData.Count - 1];
                            _player_VDR_Change = teamDS.GiocatoriNSkill.NewGiocatoriNSkillRow();
                            _player_VDR_Change.ASI = 0;
                            for (int i = 0; i < 14; i++)
                            {
                                _player_VDR_Change[i + 7] = 0;
                            }
                            _changeWeek = lastVDR.Week;
                        }
                    }

                    if (teamDS.last_week_loaded == -1)
                    {
                        PlayersDS pDS = teamDS.Squad[PlayerID];
                        PlayersDS.VarDataRow lastVDR = pDS.VarData[pDS.VarData.Count - 1];
                        _player_VDR_Change = teamDS.GiocatoriNSkill.NewGiocatoriNSkillRow();
                        _player_VDR_Change.ASI = 0;
                        for (int i = 0; i < 14; i++)
                        {
                            _player_VDR_Change[i + 7] = 0;
                        }
                        _changeWeek = lastVDR.Week;
                    }

                    return _player_VDR_Change;
                }
            }

            public decimal Mar
            {
                get { return _Mar_Pre; }
                set { _Mar_Pre = value; }
            }
            public decimal Cro
            {
                get { return _Cro_Com; }
                set { _Cro_Com = value; }
            }
            public decimal Con
            {
                get { return _Con_Uno; }
                set { _Con_Uno = value; }
            }
            public decimal Pas
            {
                get { return _Pas_Ele; }
                set { _Pas_Ele = value; }
            }
            public decimal Pos
            {
                get { return _Pos_Aer; }
                set { _Pos_Aer = value; }
            }
            public decimal Tec
            {
                get { return _Tec_Tir; }
                set { _Tec_Tir = value; }
            }
            public decimal Tes
            {
                get { return _Tes_Lan; }
                set { _Tes_Lan = value; }
            }
            public decimal Wor
            {
                get { return _Wor_Rif; }
                set { _Wor_Rif = value; }
            }
            public decimal Pre
            {
                get { return _Mar_Pre; }
                set { _Mar_Pre = value; }
            }
            public decimal Com
            {
                get { return _Cro_Com; }
                set { _Cro_Com = value; }
            }
            public decimal Uno
            {
                get { return _Con_Uno; }
                set { _Con_Uno = value; }
            }
            public decimal Ele
            {
                get { return _Pas_Ele; }
                set { _Pas_Ele = value; }
            }
            public decimal Aer
            {
                get { return _Pos_Aer; }
                set { _Pos_Aer = value; }
            }
            public decimal Tir
            {
                get { return _Tec_Tir; }
                set { _Tec_Tir = value; }
            }
            public decimal Lan
            {
                get { return _Tes_Lan; }
                set { _Tes_Lan = value; }
            }
            public decimal Rif
            {
                get { return _Wor_Rif; }
                set { _Wor_Rif = value; }
            }

            public void SetFP(GainDS gds)
            {
                if (IsForNull())
                {
                    if (FPn == 0)
                        GK = 0F;
                    else
                        DC = DR = DL = DMC = DMR = DML = MC = MR = ML = OMC = OML = OMR = FC = 0.0f;
                    return;
                }
                if (FPn == 0)
                {
                    GK = 0F;
                    for (int skill = 0; skill < 11; skill++)
                    {
                        float fval = (float)((decimal)this[skillCol[skill]]);
                        GK += 0.1f * gds.K_GK(skill) * fval;
                    }
                    CStr = (decimal)MaxAttsToStar(MaxAtts() * (float)((SkillSum + SSD) / SkillSum));
                    return;
                }

                DC = DR = DL = DMC = DMR = DML = MC = MR = ML = OMC = OML = OMR = FC = 0.0f;

                for (int skill = 0; skill < 13; skill++)
                {
                    float fval = (float)((decimal)this[skillCol[skill]]);
                    DC += 0.1f * gds.K_FP(skill, 0) * fval;
                    DR += 0.1f * gds.K_FP(skill, 1) * fval;
                    DL += 0.1f * gds.K_FP(skill, 2) * fval;
                    DMC += 0.1f * gds.K_FP(skill, 3) * fval;
                    DMR += 0.1f * gds.K_FP(skill, 4) * fval;
                    DML += 0.1f * gds.K_FP(skill, 5) * fval;
                    MC += 0.1f * gds.K_FP(skill, 6) * fval;
                    MR += 0.1f * gds.K_FP(skill, 7) * fval;
                    ML += 0.1f * gds.K_FP(skill, 8) * fval;
                    OMC += 0.1f * gds.K_FP(skill, 9) * fval;
                    OMR += 0.1f * gds.K_FP(skill, 10) * fval;
                    OML += 0.1f * gds.K_FP(skill, 11) * fval;
                    FC += 0.1f * gds.K_FP(skill, 12) * fval;
                }

                string[] FPs = FP.Split('/');

                float kRou = 1;
                if (!IsRouNull())
                    kRou = gds.funRou.Value((float)Rou);

                if (FPs.Length == 1)
                {
                    int n;
                    for (n = 0; n < 13; n++)
                        if (FP == spec[n]) break;

                    if (IsAdaNull())
                        Ada = 0;
                    else if (Ada > 0)
                        Ada = Ada + 0;


                    DC = DC * gds.A_Ada(n, 0, Ada) * kRou;
                    DR = DR * gds.A_Ada(n, 1, Ada) * kRou;
                    DL = DL * gds.A_Ada(n, 2, Ada) * kRou;
                    DMC = DMC * gds.A_Ada(n, 3, Ada) * kRou;
                    DMR = DMR * gds.A_Ada(n, 4, Ada) * kRou;
                    DML = DML * gds.A_Ada(n, 5, Ada) * kRou;
                    MC = MC * gds.A_Ada(n, 6, Ada) * kRou;
                    MR = MR * gds.A_Ada(n, 7, Ada) * kRou;
                    ML = ML * gds.A_Ada(n, 8, Ada) * kRou;
                    OMC = OMC * gds.A_Ada(n, 9, Ada) * kRou;
                    OMR = OMR * gds.A_Ada(n, 10, Ada) * kRou;
                    OML = OML * gds.A_Ada(n, 11, Ada) * kRou;
                    FC = FC * gds.A_Ada(n, 12, Ada) * kRou;
                }

                if (FPs.Length == 2)
                {
                    int n1, n2;
                    for (n1 = 0; n1 < 13; n1++)
                        if (FPs[0] == spec[n1]) break;
                    for (n2 = 0; n2 < 13; n2++)
                        if (FPs[1] == spec[n2]) break;

                    if (IsAdaNull())
                        Ada = 0;
                    else if (Ada > 0)
                        Ada = Ada + 0;

                    DC = Math.Max(DC * gds.A_Ada(n1, 0, Ada), DC * gds.A_Ada(n2, 0, Ada)) * kRou;
                    DR = Math.Max(DR * gds.A_Ada(n1, 1, Ada), DR * gds.A_Ada(n2, 1, Ada)) * kRou;
                    DL = Math.Max(DL * gds.A_Ada(n1, 2, Ada), DL * gds.A_Ada(n2, 2, Ada)) * kRou;
                    DMC = Math.Max(DMC * gds.A_Ada(n1, 3, Ada), DMC * gds.A_Ada(n2, 3, Ada)) * kRou;
                    DMR = Math.Max(DMR * gds.A_Ada(n1, 4, Ada), DMR * gds.A_Ada(n2, 4, Ada)) * kRou;
                    DML = Math.Max(DML * gds.A_Ada(n1, 5, Ada), DML * gds.A_Ada(n2, 5, Ada)) * kRou;
                    MC = Math.Max(MC * gds.A_Ada(n1, 6, Ada), MC * gds.A_Ada(n2, 6, Ada)) * kRou;
                    MR = Math.Max(MR * gds.A_Ada(n1, 7, Ada), MR * gds.A_Ada(n2, 7, Ada)) * kRou;
                    ML = Math.Max(ML * gds.A_Ada(n1, 8, Ada), ML * gds.A_Ada(n2, 8, Ada)) * kRou;
                    OMC = Math.Max(OMC * gds.A_Ada(n1, 9, Ada), OMC * gds.A_Ada(n2, 9, Ada)) * kRou;
                    OMR = Math.Max(OMR * gds.A_Ada(n1, 10, Ada), OMR * gds.A_Ada(n2, 10, Ada)) * kRou;
                    OML = Math.Max(OML * gds.A_Ada(n1, 11, Ada), OML * gds.A_Ada(n2, 11, Ada)) * kRou;
                    FC = Math.Max(FC * gds.A_Ada(n1, 12, Ada), FC * gds.A_Ada(n2, 12, Ada)) * kRou;
                }

                CStr = (decimal)MaxAttsToStar(MaxAtts() * (float)((SkillSum + SSD) / SkillSum));

                if (gds.NormalizeGains)
                {
                    DC *= gds.K_DEM[0];
                    DR *= gds.K_DEM[1];
                    DL *= gds.K_DEM[2];
                    DMC *= gds.K_DEM[3];
                    DMR *= gds.K_DEM[4];
                    DML *= gds.K_DEM[5];
                    MC *= gds.K_DEM[6];
                    MR *= gds.K_DEM[7];
                    ML *= gds.K_DEM[8];
                    OMC *= gds.K_DEM[9];
                    OMR *= gds.K_DEM[10];
                    OML *= gds.K_DEM[11];
                    FC *= gds.K_DEM[12];
                }
            }

            public float MaxAtts()
            {
                if (FPn == 0) return GK / 5;
                float max = 0;
                max = (DL > max) ? DL : max;
                max = (DR > max) ? DR : max;
                max = (DC > max) ? DC : max;
                max = (DML > max) ? DML : max;
                max = (DMR > max) ? DMR : max;
                max = (DMC > max) ? DMC : max;
                max = (ML > max) ? ML : max;
                max = (MR > max) ? MR : max;
                max = (MC > max) ? MC : max;
                max = (OML > max) ? OML : max;
                max = (OMR > max) ? OMR : max;
                max = (OMC > max) ? OMC : max;
                max = (FC > max) ? FC : max;
                return max / 5;
            }

            public float MaxAttsToStar(float a)
            {
                return (a - 2.0f) / 3.0f;
            }

            public decimal SkillSum
            {
                get
                {
                    if (IsForNull()) return 0M;

                    if (FPn <= 0)
                    {
                        return Res + For + Vel + _Mar_Pre + _Con_Uno + _Cro_Com + _Pas_Ele + _Pos_Aer +
                            _Tec_Tir + _Tes_Lan + _Wor_Rif;
                    }
                    else
                    {
                        return Res + For + Vel + _Mar_Pre + _Con_Uno + _Cro_Com + _Pas_Ele + _Pos_Aer +
                            _Tec_Tir + _Tes_Lan + _Wor_Rif + Fin + Cal + Dis;
                    }
                }
            }

            public decimal[] Skills
            {
                get
                {
                    decimal[] skills = null;

                    if (!this.IsFinNull())
                        skills = new decimal[14];
                    else
                        skills = new decimal[11];

                    skills[0] = this.For;
                    skills[1] = this.Res;
                    skills[2] = this.Vel;
                    skills[3] = this.Mar;
                    skills[4] = this.Con;
                    skills[5] = this.Wor;
                    skills[6] = this.Pos;
                    skills[7] = this.Pas;
                    skills[8] = this.Cro;
                    skills[9] = this.Tec;
                    skills[10] = this.Tes;
                    if (!this.IsFinNull())
                    {
                        skills[11] = this.Fin;
                        skills[12] = this.Dis;
                        skills[13] = this.Cal;
                    }
                    return skills;
                }

                set
                {
                    decimal[] skills = value;
                    this.For = skills[0];
                    this.Res = skills[1];
                    this.Vel = skills[2];
                    this.Mar = skills[3];
                    this.Con = skills[4];
                    this.Wor = skills[5];
                    this.Pos = skills[6];
                    this.Pas = skills[7];
                    this.Cro = skills[8];
                    this.Tec = skills[9];
                    this.Tes = skills[10];

                    if (skills.Length == 14)
                    {
                        this.Fin = skills[11];
                        this.Dis = skills[12];
                        this.Cal = skills[13];
                    }
                }
            }

            internal void CopyFrom(GiocatoriNSkillRow gsr)
            {
                this.ItemArray = gsr.ItemArray;
            }
        }

        public void Save(FileInfo fi)
        {
            Save(fi.DirectoryName, fi.Name);
        }

        public void Save(string defaultDirPath, string filename)
        {
            string teamDataFile = Path.Combine(defaultDirPath, filename);
            this.WriteXml(teamDataFile);

            Squad.Save(defaultDirPath);
        }

        public void Load(FileInfo fi)
        {
            Load(fi.DirectoryName, fi.Name);
        }

        public void Load(string defaultDirPath, string filename)
        {
            GiocatoriNSkillRow gsrSearch = null;
            try
            {
                string teamDataFile = Path.Combine(defaultDirPath, filename);

                FileInfo fi = new FileInfo(teamDataFile);
                if (!fi.Exists) return;

                TeamDS newTeamDS = new TeamDS();
                newTeamDS.ReadXml(teamDataFile);

                foreach (GiocatoriNSkillRow gsr in newTeamDS.GiocatoriNSkill)
                {
                    if (this.GiocatoriNSkill.FindByPlayerID(gsr.PlayerID) == null)
                    {
                        GiocatoriNSkillRow addGsr = GiocatoriNSkill.NewGiocatoriNSkillRow();
                        addGsr.CopyFrom(gsr);
                        this.GiocatoriNSkill.AddGiocatoriNSkillRow(addGsr);
                    }
                }

                foreach (GiocatoriNSkillRow gsr in GiocatoriNSkill)
                {
                    gsrSearch = gsr;
                    Squad.LoadPlayer(defaultDirPath, gsr.PlayerID);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void ParsePlayerPage(string page, int actPlayerID)
        {
            page = page.Replace("'", "").Replace('"', '\'').Replace("'>", ">");
            page = page.Replace("&#39;", "'").Replace(" \r\n", " ");
            page = page.Replace("<span class='Apple-converted-space>Â </span>", "");
            DateTime pageDate = DateTime.Now;

            PlayersDS playerDS = Squad[actPlayerID];
            PlayersDS.FixDataRow fixData = playerDS.FixDataVal;

            TmWeek thisWeek = TmWeek.thisWeek();

            PlayersDS.VarDataRow varData = playerDS.VarData.FindByWeek(thisWeek.absweek);
            if (varData == null)
            {
                varData = playerDS.VarData.NewVarDataRow();
                varData.Week = thisWeek.absweek;
                playerDS.VarData.AddVarDataRow(varData);
            }

            List<string> tables = HTML_Parser.GetTags(page, "table");

            // It's a base page
            string[] pagelines = page.Split('\n');

            for (int ix = 0; ix < pagelines.Length; ix++)
            {
                string line = pagelines[ix];

                if (line.Contains("select_player"))
                {
                    // Line containing Age, Height and Weight
                    int index = 0;
                    index = line.IndexOf("</form>");

                    string Age = HTML_Parser.GetField(line, "</strong>", "<", ref index);

                    if (Age == "")
                    {
                        ix = ix + 1;
                        line = pagelines[ix];
                        Age = HTML_Parser.GetField(line, "</strong>", "<", ref index);
                    }
                    string Heigth = HTML_Parser.GetField(line, "</strong>", "<", ref index);
                    string Weight = HTML_Parser.GetField(line, "</strong>", "<", ref index);

                    fixData.wBorn = TmWeek.GetBornWeekFromAge(pageDate, Age);

                    TmWeek age = TmWeek.GetAge(fixData.wBorn, pageDate);
                    // Età = age.Years;
                }

                //if (line.Contains("'importage'"))
                //{
                //    // Line containing Age, Height and Weight
                //    int index = 0;
                //    string training = HTML_Parser.GetField(line, "'importage', '", "');", ref index);

                //    gRow.SetTI(pageDate, training);
                //    gRow.AvTSI = Utility.WeightedMean(gRow.TSI);

                //    continue;
                //}

                if (line.Contains("nickname"))
                {
                    string full_line = "";
                    ix++;

                    for (; ix < pagelines.Length; ix++)
                    {
                        line = pagelines[ix];
                        full_line += line.TrimEnd('\r');
                        if (line.Contains("<!-- Header end -->")) break;
                    }

                    // Season line
                    int index = 0;
                    string FullName = HTML_Parser.GetField(full_line, "</div>", " <a href", ref index);
                    string RealCountry = HTML_Parser.GetField(full_line, "showcountry=", "><img", ref index);
                    fixData.Nome = FullName;
                    fixData.Nationality = RealCountry;

                    continue;
                }
            } // end for (int ix = 0; ix < lines.Length; ix++)

            foreach (string table in tables)
            {
                if (table.Contains(">ASI<"))
                {
                    // Line containing Age, Height and Weight
                    string partline = table.Substring(table.IndexOf(">ASI<") + 5);
                    List<string> tags = HTML_Parser.GetTags(partline, "td");
                    string FP = tags[0];
                    string routine = tags[1];
                    string wage = tags[2];
                    wage = wage.Replace(",", "");
                    // fixData.Wage = int.Parse(wage);
                    fixData.Rou = decimal.Parse(routine, Common.CommGlobal.ciUs);
                    continue;
                }

                if (table.Contains("<!-- Season -->"))
                {
                    List<string> rows = HTML_Parser.GetTags2(table, "tr");

                    for (int ir = 1; ir < rows.Count; ir++)
                    {
                        List<string> tdFields = HTML_Parser.GetTags(rows[ir], "td");

                        if (tdFields == null) continue;

                        string Fee;

                        if (tdFields.Count == 12)
                        {
                            // Season  = tdFields[0]; 
                            fixData.TeamID = Common.HTML_Parser.GetNumberAfter(tdFields[1], "teamID=");
                            // Nation  = tdFields[2]; 
                            // Age     = tdFields[3]; 
                            Fee = tdFields[4];
                            // GP      = tdFields[5]; 
                            // Gol     = tdFields[6]; 
                            // Assist  = tdFields[7]; 
                            // Prod    = tdFields[8]; 
                            // Mom     = tdFields[9];
                            // Cards   = tdFields[10];
                            float avRating;
                            // float.TryParse(tdFields[11], NumberStyles.Float, CommGlobal.ci, out avRating);
                            // gRow.AvRating = avRating;
                            break; // Get only the first season
                            // continue;
                        }

                        if (tdFields.Count == 9)
                        {
                            // GP      = tdFields[2; 
                            // Gol     = tdFields[3]; 
                            // Assist  = tdFields[4]; 
                            // Prod    = tdFields[5]; 
                            // Mom     = tdFields[6];
                            // Cards   = tdFields[7];
                            // float.TryParse(tdFields[8], out gr.AvRating);
                        }
                    }
                }

                RefreshTeamData(actPlayerID);
            }
        }

        private void RefreshTeamData(int ID)
        {
            GiocatoriNSkill.AddPlayer(ID, Squad[ID], GD, null);
        }

        public void LoadTransferFromHTML(string page, bool updateDeletedPlayers)
        {
            DateTime timeOfData = DateTime.Now;

            string result = HTML_Parser.ConvertUnicodes_MoreText(page);

            string[] players = result.Split('\n');

            // Row 0 is the table header
            bool newData = false;
            for (int player = 0; player < players.Length; player++)
            {
                if (!players[player].Contains("id=")) continue;

                AlarmInfo ai = new AlarmInfo();

                string plRow = players[player];

                int ID = Squad.ParseTransferPlayer(timeOfData, plRow, ref ai);

                if (ID == -1) continue;

                if (GiocatoriNSkill.FindByPlayerID(ID) == null)
                {
                    if (!updateDeletedPlayers)
                    {
                        Squad.Remove(ID);
                        continue;
                    }
                }

                newData = true;
                this.GiocatoriNSkill.AddPlayer(ID, Squad[ID], GD, ai);
            }

            if (newData) last_week_loaded = TmWeek.thisWeek().absweek;
        }

        public void LoadShortlistFromHTML(string page, bool updateDeletedPlayers, DateTime timeOfData)
        {
            // There will be two tables (0: players, 1: GK)
            List<string> tables = HTML_Parser.GetTags(page, "TABLE");

            if (tables.Count == 0)
            {
                MessageBox.Show("The content of what you pasted is not the one expected", "Error", MessageBoxButtons.OK);
                return;
            }

            // Get all rows of the players table
            List<string> plRows = HTML_Parser.GetTags(tables[0], "TR");

            // Row 0 is the table header
            bool newData = false;
            for (int player = 0; player < plRows.Count; player++)
            {
                AlarmInfo ai = new AlarmInfo();

                string HomeNation = "it";
                int ID = Squad.ParsePlayer(timeOfData, plRows[player], HomeNation, ref ai);

                if (ID == -1) continue;

                if (GiocatoriNSkill.FindByPlayerID(ID) == null)
                {
                    if (!updateDeletedPlayers)
                    {
                        Squad.Remove(ID);
                        continue;
                    }
                }

                newData = true;
                this.GiocatoriNSkill.AddPlayer(ID, Squad[ID], GD, ai);
            }

            if (newData) last_week_loaded = TmWeek.thisWeek().absweek;
        }

        public void CopyFrom(TeamDS History_TeamDS)
        {
            Clear();
            GiocatoriNSkill.Merge(History_TeamDS.GiocatoriNSkill);

            Squad.Clear();
            foreach (int key in History_TeamDS.Squad.Keys)
            {
                PlayersDS pDS = new PlayersDS();
                pDS.Merge(History_TeamDS.Squad[key]);
                Squad.Add(key, pDS);
            }
            last_week_loaded = History_TeamDS.last_week_loaded;
        }

        public void CopyTo(TeamDS History_TeamDS)
        {
            History_TeamDS.Clear();
            History_TeamDS.GiocatoriNSkill.Merge(GiocatoriNSkill);

            History_TeamDS.Squad.Clear();
            foreach (int key in Squad.Keys)
            {
                PlayersDS pDS = new PlayersDS();
                pDS.Merge(Squad[key]);
                History_TeamDS.Squad.Add(key, pDS);
            }
            History_TeamDS.last_week_loaded = last_week_loaded;
        }

        public void LoadClubhouseFromHTML(string page, bool updateDeletedPlayers, DateTime timeOfData)
        {
            // There will be two tables (0: players, 1: GK)
            List<string> tables = HTML_Parser.GetTags(page, "TABLE");

            if (tables.Count == 0)
            {
                MessageBox.Show("The content of what you pasted is not the one expected",
                    "Error", MessageBoxButtons.OK);
                return;
            }

            foreach (string table in tables)
            {
                // Get all rows of the players table
                List<string> plRows = HTML_Parser.GetTags(table, "TR");

                // Row 0 is the table header
                for (int player = 0; player < plRows.Count; player++)
                {
                    AlarmInfo ai = new AlarmInfo();

                    string HomeNation = "it";
                    int ID = Squad.ParseClubhousePlayer(timeOfData, plRows[player], HomeNation, ref ai);

                    if (ID == -1) continue;

                    if (GiocatoriNSkill.FindByPlayerID(ID) == null)
                    {
                        if (!updateDeletedPlayers)
                        {
                            Squad.Remove(ID);
                            continue;
                        }
                    }

                    this.GiocatoriNSkill.AddPlayer(ID, Squad[ID], GD, ai);
                }
            }
        }

        public void RecalculateSpecData(GainDS gainDS)
        {
            foreach (TeamDS.GiocatoriNSkillRow gsr in this.GiocatoriNSkill)
            {
                gsr.SetFP(gainDS);
            }
        }

        public void LoadNewShortlistFromHTML(string page, bool updateDeletedPlayers, DateTime timeOfData)
        {
            string originalSquadString = page;
            Db_TrophyDataSet db_TrophyDataSet = null;
            short isReserves = 0;
            int player = 0;
            bool newData = false;

            try
            {

                string players_ar = HTML_Parser.GetField(page, "var players_ar = [", "}]") + "}";
                string pl2 = HTML_Parser.ConvertHTML_Text(players_ar);
                List<string> plRows = HTML_Parser.GetFields(pl2, "{", "}");

                // Row 0 is the table header
                for (player = 0; player < plRows.Count; player++)
                {
                    AlarmInfo ai = new AlarmInfo();

                    string HomeNation = "it";
                    int ID = Squad.ParsePlayer2(timeOfData, plRows[player], HomeNation, ref ai);

                    if (ID == -1) continue;

                    if (GiocatoriNSkill.FindByPlayerID(ID) == null)
                    {
                        if (!updateDeletedPlayers)
                        {
                            Squad.Remove(ID);
                            continue;
                        }
                    }

                    newData = true;
                    this.GiocatoriNSkill.AddPlayer(ID, Squad[ID], GD, ai);
                }

                if (newData) last_week_loaded = TmWeek.thisWeek().absweek;
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string info = "";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(Path.GetTempPath(), filename);
                FileInfo fi = new FileInfo(pathfilename);

                this.WriteXml(fi.FullName);

                StreamReader file = new StreamReader(fi.FullName);
                info += "PlayersDS:\r\n" + file.ReadToEnd();
                file.Close();

                db_TrophyDataSet.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "TDS:\r\n" + file.ReadToEnd();
                file.Close();

                info += "isReserves:" + isReserves.ToString();
                info += "player:" + player.ToString();
                info += "Squad:" + originalSquadString;

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        public void LoadShortlistFromHTML_New(string page, bool updateDeletedPlayers, DateTime timeOfData)
        {
            string originalSquadString = page;
            Db_TrophyDataSet db_TrophyDataSet = null;
            short isReserves = 0;
            int player = 0;
            bool newData = false;

            try
            {
                string squad = page;
                squad = HTML_Parser.ConvertUnicodes_Text(squad);
                squad = HTML_Parser.ConvertUnicodes_MoreText(squad);

                string[] plRows = squad.Split('\n');

                // Row 0 is the table header
                for (player = 0; player < plRows.Length; player++)
                {
                    AlarmInfo ai = new AlarmInfo();

                    if (!plRows[player].Contains("id=")) continue;

                    string HomeNation = "it";
                    int ID = Squad.ParsePlayer2(timeOfData, plRows[player], HomeNation, ref ai);

                    if (ID == -1) continue;

                    if (GiocatoriNSkill.FindByPlayerID(ID) == null)
                    {
                        if (!updateDeletedPlayers)
                        {
                            Squad.Remove(ID);
                            continue;
                        }
                    }

                    newData = true;
                    this.GiocatoriNSkill.AddPlayer(ID, Squad[ID], GD, ai);
                }

                if (newData) last_week_loaded = TmWeek.thisWeek().absweek;
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string info = "";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(Path.GetTempPath(), filename);
                FileInfo fi = new FileInfo(pathfilename);

                this.WriteXml(fi.FullName);

                StreamReader file = new StreamReader(fi.FullName);
                info += "PlayersDS:\r\n" + file.ReadToEnd();
                file.Close();

                db_TrophyDataSet.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "TDS:\r\n" + file.ReadToEnd();
                file.Close();

                info += "isReserves:" + isReserves.ToString();
                info += "player:" + player.ToString();
                info += "Squad:" + originalSquadString;

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }
    }
}
