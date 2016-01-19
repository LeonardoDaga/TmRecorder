using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NTR_Common;
using Common;
using System.Diagnostics;

namespace NTR_Db
{
    public partial class NTR_PlayerData : UserControl
    {
        List<Label> phyLabels = new List<Label>();
        List<Label> tacLabels = new List<Label>();
        List<Label> tecLabels = new List<Label>();

        public NTR_PlayerData()
        {
            InitializeComponent();

            // Create the labels lists
            phyLabels.Add(lblStrCapt);
            phyLabels.Add(lblStaCapt);
            phyLabels.Add(lblPacCapt);
            phyLabels.Add(lblHeaCapt);

            tacLabels.Add(lblMarCapt);
            tacLabels.Add(lblTakCapt);
            tacLabels.Add(lblWorCapt);
            tacLabels.Add(lblPosCapt);

            tacLabels.Add(lblPasCapt);
            tecLabels.Add(lblCroCapt);
            tecLabels.Add(lblTecCapt);
            tecLabels.Add(lblFinCapt);
            tecLabels.Add(lblLonCapt);
            tecLabels.Add(lblSetCapt);
        }

        public decimal BloomAge
        {
            set
            {
                if (value == -1M)
                    lblBlooming.Text = "-";
                else
                    lblBlooming.Text = value.ToString() + "y";
            }
        }

        public int Wage
        {
            set { lblWage.Text = value.ToString(); }
        }

        public TeamDS.GiocatoriNSkillRow PlayerRow
        {
            set
            {
                TeamDS.GiocatoriNSkillRow pr = value;

                try
                {
                    if (pr.FPn != 0)
                    {
                        lblAdaCapt.Visible = true;
                        lblFinCapt.Visible = true;
                        lblSetCapt.Visible = true;
                        lblLonCapt.Visible = true;
                        lblAda.Visible = true;
                        lblFin.Visible = true;
                        lblCP.Visible = true;
                        lblDis.Visible = true;

                        lblTakCapt.Text = "Tak";
                        lblCroCapt.Text = "Cro";
                        lblFinCapt.Text = "Fin";
                        lblStrCapt.Text = "Str";
                        lblMarCapt.Text = "Mar";
                        lblPasCapt.Text = "Pas";
                        lblPosCapt.Text = "Pos";
                        lblStaCapt.Text = "Sta";
                        lblTecCapt.Text = "Tec";
                        lblHeaCapt.Text = "Hea";
                        lblLonCapt.Text = "Lon";
                        lblPacCapt.Text = "Pac";
                        lblWorCapt.Text = "Wor";
                        lblSetCapt.Text = "Set";

                        lblCon.Text = pr.Con.ToString();
                        lblCro.Text = pr.Cro.ToString();
                        lblFin.Text = pr.Fin.ToString();
                        lblFor.Text = pr.For.ToString();
                        lblMar.Text = pr.Mar.ToString();
                        lblPas.Text = pr.Pas.ToString();
                        lblPos.Text = pr.Pos.ToString();
                        lblRes.Text = pr.Res.ToString();
                        lblTec.Text = pr.Tec.ToString();
                        lblTes.Text = pr.Tes.ToString();
                        lblDis.Text = pr.Dis.ToString();
                        lblVel.Text = pr.Vel.ToString();
                        lblImp.Text = pr.Wor.ToString();
                        lblCP.Text = pr.Cal.ToString();

                        if (pr.Ada > 0)
                            lblAda.Text = pr.Ada.ToString() + "/20";
                        else
                            lblAda.Text = "- ";
                    }
                    else
                    {
                        lblAdaCapt.Visible = false;
                        lblFinCapt.Visible = false;
                        lblSetCapt.Visible = false;
                        lblLonCapt.Visible = false;
                        lblAda.Visible = false;
                        lblFin.Visible = false;
                        lblCP.Visible = false;
                        lblDis.Visible = false;

                        lblTakCapt.Text = "One";
                        lblCroCapt.Text = "Com";
                        lblStrCapt.Text = "Str";
                        lblMarCapt.Text = "Han";
                        lblPasCapt.Text = "Jum";
                        lblPosCapt.Text = "Ari";
                        lblStaCapt.Text = "Sta";
                        lblTecCapt.Text = "Kic";
                        lblHeaCapt.Text = "Thr";
                        lblPacCapt.Text = "Pac";
                        lblWorCapt.Text = "Ref";

                        lblCon.Text = pr.Con.ToString();
                        lblCro.Text = pr.Cro.ToString();
                        lblFor.Text = pr.For.ToString();
                        lblMar.Text = pr.Mar.ToString();
                        lblPas.Text = pr.Pas.ToString();
                        lblPos.Text = pr.Pos.ToString();
                        lblRes.Text = pr.Res.ToString();
                        lblTec.Text = pr.Tec.ToString();
                        lblTes.Text = pr.Tes.ToString();
                        lblVel.Text = pr.Vel.ToString();
                        lblImp.Text = pr.Wor.ToString();
                    }

                    if (!pr.IsRouNull())
                        lblRou.Text = pr.Rou.ToString();
                    else
                        lblRou.Text = "-";

                    lblASI.Text = pr.ASI.ToString();
                    TmWeek born = new TmWeek(pr.wBorn);
                    lblAge.Text = born.ToAge(DateTime.Today);

                    lblSOi.Text = pr.OSi.ToString("N1") + "/100";

                    if (!pr.IsSSDNull())
                        lblSsd.Text = pr.SSD.ToString("N2");
                    else
                        lblSsd.Text = "-";

                    lblName.Text = pr.Nome.Split('|')[0];

                    int injWeeks = int.Parse(pr.Nome.Split('|')[1]);
                    int banWeeks = int.Parse(pr.Nome.Split('|')[2]);
                    int teamB = int.Parse(pr.Nome.Split('|')[3]);

                    if (injWeeks == 0)
                    {
                        pctInj.Visible = false;
                        lblInjDays.Visible = false;
                    }
                    else
                    {
                        pctInj.Visible = true;
                        lblInjDays.Visible = true;
                        lblInjDays.Text = injWeeks.ToString();
                    }

                    if (banWeeks == 0)
                    {
                        pctBan.Visible = false;
                        lblBanDays.Visible = false;
                    }
                    else if (banWeeks < 3)
                    {
                        pctBan.Visible = true;
                        lblBanDays.Visible = true;

                        int ix = banImgList.Images.IndexOfKey("Green.png");
                        pctBan.Image = banImgList.Images[ix];

                        lblBanDays.Text = banWeeks.ToString();
                    }
                    else if (banWeeks == 3)
                    {
                        pctBan.Visible = true;
                        lblBanDays.Visible = false;

                        int ix = banImgList.Images.IndexOfKey("Yellow.png");
                        pctBan.Image = banImgList.Images[ix];
                    }
                    else
                    {
                        pctBan.Visible = true;
                        lblBanDays.Visible = true;

                        int ix = banImgList.Images.IndexOfKey("Red.png");
                        pctBan.Image = banImgList.Images[ix];

                        lblBanDays.Text = (banWeeks - 4).ToString();
                    }

                    pctTeamB.Visible = (teamB != 0);
                    pctRetiring.Visible = false; // TODO!!

                    if (!pr.IsCStrNull())
                        lblCRec.Text = pr.CStr.ToString("N1") + "/5";
                    else
                        lblCRec.Text = "-";

                    if (!pr.IsRecNull())
                        lblRec.Text = pr.Rec.ToString("N1") + "/5";
                    else
                        lblRec.Text = "-";

                    if (!pr.IsNationalityNull())
                    {
                        int ix = flagImgList.Images.IndexOfKey(pr.Nationality.ToString() + ".png");
                        pictFlag.Image = flagImgList.Images[ix];
                    }

                    if (!pr.IsProNull())
                        lblProfessionalism.Text = pr.Pro.ToString() + "/20";
                    else
                        lblProfessionalism.Text = "-";

                    if (!pr.IsAggNull())
                        lblAggression.Text = pr.Agg.ToString() + "/20";
                    else
                        lblAggression.Text = "-";

                    if (!pr.IsLeaNull())
                        lblLea.Text = pr.Lea.ToString() + "/20";
                    else
                        lblLea.Text = "-";

                    if (!pr.IsPotNull())
                        lblPot.Text = pr.Pot.ToString();
                    else
                        lblPot.Text = "-";

                    if (!pr.IsInjPronNull())
                        lblInjuryPro.Text = pr.InjPron.ToString() + "/20";
                    else
                        lblInjuryPro.Text = "-";

                    string FP = Tm_Utility.FPnToFP(pr.FPn);

                    string[] FPs = FP.Split('/');
                    if (FPs.Length == 1)
                    {
                        lblFP1.Text = FPs[0];
                        SetLabelBack(lblFP1, FPs[0]);
                        lblFP2.Visible = false;
                    }
                    else if (FPs.Length == 2)
                    {
                        lblFP1.Text = FPs[0];
                        lblFP2.Text = FPs[1];
                        SetLabelBack(lblFP1, FPs[0]);
                        SetLabelBack(lblFP2, FPs[1]);
                        lblFP2.Visible = true;
                    }

                    RatingR2 R2 = RatingR2.CalculateREREC(pr);

                    int[] FPv = Tm_Utility.FPnToFPvector(pr.FPn);

                    lblR2Rat1.Text = R2.ratingR2[FPv[0]].ToString("N1");
                    lblReRec1.Text = R2.rec[FPv[0]].ToString("N2");
                    lblRouEff1.Text = (R2.ratingR2[FPv[0]] - R2.ratingR[FPv[0]]).ToString("N1");
                    lblRsSk1.Text = FPs[0];
                    SetLabelBack(lblRsSk1, FPs[0]);

                    lblR2Rat2.Visible = (FPv[1] != -1);
                    lblReRec2.Visible = (FPv[1] != -1);
                    lblRouEff2.Visible = (FPv[1] != -1);
                    lblRsSk2.Visible = (FPv[1] != -1);

                    if (FPv[1] != -1)
                    {
                        lblR2Rat2.Text = R2.ratingR2[FPv[1]].ToString("N1");
                        lblReRec2.Text = R2.rec[FPv[1]].ToString("N2");
                        lblRouEff2.Text = (R2.ratingR2[FPv[1]] - R2.ratingR[FPv[1]]).ToString("N1");
                        lblRsSk2.Text = FPs[1];
                        SetLabelBack(lblRsSk2, FPs[1]);
                    }

                    Color labelColor;
                    if (!pr.IsSpecialitiesNull())
                    {
                        Dictionary<string,string> specialities = HTML_Parser.String2Dictionary(pr.Specialities);

                        labelColor = Utility.GradeColor(float.Parse(specialities["Phy"]), 20f);
                        foreach (Label label in phyLabels)
                        {
                            label.ForeColor = labelColor;
                            if (label.Text == specialities["Spe"])
                                label.Font = new Font(label.Font, FontStyle.Bold | FontStyle.Underline);
                            else if (label.Font.Bold)
                                label.Font = new Font(label.Font, FontStyle.Regular);
                        }

                        labelColor = Utility.GradeColor(float.Parse(specialities["Tec"]), 20f);
                        foreach (Label label in tecLabels)
                        {
                            label.ForeColor = labelColor;
                            if (label.Text == specialities["Spe"])
                                label.Font = new Font(label.Font, FontStyle.Bold | FontStyle.Underline);
                            else if (label.Font.Bold)
                                label.Font = new Font(label.Font, FontStyle.Regular);

                        }

                        labelColor = Utility.GradeColor(float.Parse(specialities["Tac"]), 20f);
                        foreach (Label label in tacLabels)
                        {
                            label.ForeColor = labelColor;
                            if (label.Text == specialities["Spe"])
                                label.Font = new Font(label.Font, FontStyle.Bold | FontStyle.Underline);
                            else if (label.Font.Bold)
                                label.Font = new Font(label.Font, FontStyle.Regular);

                        }
                    }
                    else
                    {
                        foreach (Label label in phyLabels)
                        {
                            label.ForeColor = Color.Gainsboro;
                            if (label.Font.Bold)
                                label.Font = new Font(label.Font, FontStyle.Regular);
                        }

                        foreach (Label label in tecLabels)
                        {
                            label.ForeColor = Color.Gainsboro;
                            if (label.Font.Bold)
                                label.Font = new Font(label.Font, FontStyle.Regular);
                        }

                        foreach (Label label in tacLabels)
                        {
                            label.ForeColor = Color.Gainsboro;
                            if (label.Font.Bold)
                                label.Font = new Font(label.Font, FontStyle.Regular);
                        }
                    }
                }
                catch(Exception e)
                { }
            }
        }

        public void SetPlayerData(PlayerData plData)
        {
            try
            {
                if (plData.FPn != 0)
                {
                    lblAdaCapt.Visible = true;
                    lblFinCapt.Visible = true;
                    lblSetCapt.Visible = true;
                    lblLonCapt.Visible = true;
                    lblAda.Visible = true;
                    lblFin.Visible = true;
                    lblCP.Visible = true;
                    lblDis.Visible = true;

                    lblTakCapt.Text = "Tak";
                    lblCroCapt.Text = "Cro";
                    lblFinCapt.Text = "Fin";
                    lblStrCapt.Text = "Str";
                    lblMarCapt.Text = "Mar";
                    lblPasCapt.Text = "Pas";
                    lblPosCapt.Text = "Pos";
                    lblStaCapt.Text = "Sta";
                    lblTecCapt.Text = "Tec";
                    lblHeaCapt.Text = "Hea";
                    lblLonCapt.Text = "Lon";
                    lblPacCapt.Text = "Pac";
                    lblWorCapt.Text = "Wor";
                    lblSetCapt.Text = "Set";

                    lblCon.Text = plData.Tac.ToString();
                    lblCro.Text = plData.Cro.ToString();
                    lblFin.Text = plData.Fin.ToString();
                    lblFor.Text = plData.Str.ToString();
                    lblMar.Text = plData.Mar.ToString();
                    lblPas.Text = plData.Pas.ToString();
                    lblPos.Text = plData.Pos.ToString();
                    lblRes.Text = plData.Sta.ToString();
                    lblTec.Text = plData.Tec.ToString();
                    lblTes.Text = plData.Hea.ToString();
                    lblDis.Text = plData.Lon.ToString();
                    lblVel.Text = plData.Pac.ToString();
                    lblImp.Text = plData.Wor.ToString();
                    lblCP.Text = plData.Set.ToString();

                    if (plData.Ada > 0)
                        lblAda.Text = plData.Ada.ToString() + "/20";
                    else
                        lblAda.Text = "- ";
                }
                else
                {
                    lblAdaCapt.Visible = false;
                    lblFinCapt.Visible = false;
                    lblSetCapt.Visible = false;
                    lblLonCapt.Visible = false;
                    lblAda.Visible = false;
                    lblFin.Visible = false;
                    lblCP.Visible = false;
                    lblDis.Visible = false;

                    lblTakCapt.Text = "One";
                    lblCroCapt.Text = "Com";
                    lblStrCapt.Text = "Str";
                    lblMarCapt.Text = "Han";
                    lblPasCapt.Text = "Jum";
                    lblPosCapt.Text = "Ari";
                    lblStaCapt.Text = "Sta";
                    lblTecCapt.Text = "Kic";
                    lblHeaCapt.Text = "Thr";
                    lblPacCapt.Text = "Pac";
                    lblWorCapt.Text = "Ref";

                    lblCon.Text = plData.Tac.ToString();
                    lblCro.Text = plData.Cro.ToString();
                    lblFor.Text = plData.Str.ToString();
                    lblMar.Text = plData.Mar.ToString();
                    lblPas.Text = plData.Pas.ToString();
                    lblPos.Text = plData.Pos.ToString();
                    lblRes.Text = plData.Sta.ToString();
                    lblTec.Text = plData.Tec.ToString();
                    lblTes.Text = plData.Hea.ToString();
                    lblVel.Text = plData.Pac.ToString();
                    lblImp.Text = plData.Wor.ToString();
                }

                if (plData != null)
                    lblRou.Text = plData.Rou.ToString();
                else
                    lblRou.Text = "-";

                lblASI.Text = plData.ASI.ToString();
                TmWeek born = new TmWeek(plData.wBorn);
                lblAge.Text = born.ToAge(DateTime.Today);

                lblSOi.Text = "-";

                lblSsd.Text = plData.SSD.ToString("N2");

                lblName.Text = plData.Name;

                lblWage.Text = plData.Wage.ToString();

                int injWeeks = 0;
                int banWeeks = 0;
                int teamB = 0;

                if (injWeeks == 0)
                {
                    pctInj.Visible = false;
                    lblInjDays.Visible = false;
                }
                else
                {
                    pctInj.Visible = true;
                    lblInjDays.Visible = true;
                    lblInjDays.Text = injWeeks.ToString();
                }

                pctBan.Visible = false;
                lblBanDays.Visible = false;

                pctTeamB.Visible = (teamB != 0);
                pctRetiring.Visible = false; // TODO!!

                lblCRec.Text = plData.CStr.ToString("N1") + "/5";
                lblRec.Text = plData.Rec.ToString("N1") + "/5";

                int ix = flagImgList.Images.IndexOfKey(plData.Nationality.ToString() + ".png");
                pictFlag.Image = flagImgList.Images[ix];

                if (plData.Professionalism == null)
                    lblProfessionalism.Text = "-";
                else
                    lblProfessionalism.Text = plData.Professionalism.ToString();

                if (plData.Aggressivity == null)
                    lblAggression.Text = "-";
                else
                    lblAggression.Text = plData.Aggressivity.ToString();

                if (plData.Leadership == null)
                    lblLea.Text = "-";
                else
                    lblLea.Text = plData.Leadership.ToString();

                if (plData.Potential == null)
                    lblPot.Text = "-";
                else
                    lblPot.Text = plData.Potential.ToString();

                if (plData.Inj != 0)
                    lblInjuryPro.Text = plData.Inj.ToString() + "/20";
                else
                    lblInjuryPro.Text = "-";

                string FP = Tm_Utility.FPnToFP(plData.FPn);

                string[] FPs = FP.Split('/');
                if (FPs.Length == 1)
                {
                    lblFP1.Text = FPs[0];
                    SetLabelBack(lblFP1, FPs[0]);
                    lblFP2.Visible = false;
                }
                else if (FPs.Length == 2)
                {
                    lblFP1.Text = FPs[0];
                    lblFP2.Text = FPs[1];
                    SetLabelBack(lblFP1, FPs[0]);
                    SetLabelBack(lblFP2, FPs[1]);
                    lblFP2.Visible = true;
                }

                RatingR2 R2 = plData.CalculateREREC();

                int[] FPv = Tm_Utility.FPnToFPvector(plData.FPn);

                lblR2Rat1.Text = R2.ratingR2[FPv[0]].ToString("N1");
                lblReRec1.Text = R2.rec[FPv[0]].ToString("N2");
                lblRouEff1.Text = (R2.ratingR2[FPv[0]] - R2.ratingR[FPv[0]]).ToString("N1");
                lblRsSk1.Text = FPs[0];
                SetLabelBack(lblRsSk1, FPs[0]);

                lblR2Rat2.Visible = (FPv[1] != -1);
                lblReRec2.Visible = (FPv[1] != -1);
                lblRouEff2.Visible = (FPv[1] != -1);
                lblRsSk2.Visible = (FPv[1] != -1);

                if (FPv[1] != -1)
                {
                    lblR2Rat2.Text = R2.ratingR2[FPv[1]].ToString("N1");
                    lblReRec2.Text = R2.rec[FPv[1]].ToString("N2");
                    lblRouEff2.Text = (R2.ratingR2[FPv[1]] - R2.ratingR[FPv[1]]).ToString("N1");
                    lblRsSk2.Text = FPs[1];
                    SetLabelBack(lblRsSk2, FPs[1]);
                }

                Color labelColor;

                foreach (Label label in phyLabels)
                {
                    label.ForeColor = Color.Gainsboro;
                    if (label.Font.Bold)
                        label.Font = new Font(label.Font, FontStyle.Regular);
                }

                foreach (Label label in tecLabels)
                {
                    label.ForeColor = Color.Gainsboro;
                    if (label.Font.Bold)
                        label.Font = new Font(label.Font, FontStyle.Regular);
                }

                foreach (Label label in tacLabels)
                {
                    label.ForeColor = Color.Gainsboro;
                    if (label.Font.Bold)
                        label.Font = new Font(label.Font, FontStyle.Regular);
                }
            }
            catch(Exception e)
            { }
        }

        private void SetLabelBack(Label lblFP, string FP)
        {
            int FPn = Tm_Utility.FPToNumber(FP);

            switch (FPn)
            {
                case 0:
                    lblFP.BackColor = Color.Blue;
                    break;
                case 10:
                case 13:
                case 15:
                    lblFP.BackColor = Color.FromArgb(0, 255, 255);
                    break;
                case 30:
                case 33:
                case 35:
                    lblFP.BackColor = Color.FromArgb(198, 255, 148);
                    break;
                case 50:
                case 53:
                case 55:
                    lblFP.BackColor = Color.FromArgb(255, 255, 2);
                    break;
                case 70:
                case 73:
                case 75:
                    lblFP.BackColor = Color.FromArgb(255, 101, 2);
                    break;
                case 90:
                    lblFP.BackColor = Color.FromArgb(255, 0, 0);
                    break;
            }
        }

        private void SetLabelFore(Label lblFP, string FP)
        {
            int FPn = Tm_Utility.FPToNumber(FP);

            switch (FPn)
            {
                case 0:
                    lblFP.ForeColor = Color.Blue;
                    break;
                case 10:
                case 13:
                case 15:
                    lblFP.ForeColor = Color.FromArgb(0, 192, 192);
                    break;
                case 30:
                case 33:
                case 35:
                    lblFP.ForeColor = Color.FromArgb(160, 192, 124);
                    break;
                case 50:
                case 53:
                case 55:
                    lblFP.ForeColor = Color.FromArgb(192, 192, 2);
                    break;
                case 70:
                case 73:
                case 75:
                    lblFP.ForeColor = Color.FromArgb(192, 81, 2);
                    break;
                case 90:
                    lblFP.ForeColor = Color.FromArgb(255, 0, 0);
                    break;
            }
        }
        private void NTR_PlayerData_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_DoubleClick(object sender, EventArgs e)
        {
            string arg = "http://trophymanager.com/club/2925434/";

            ProcessStartInfo startInfo = new ProcessStartInfo(arg);
            Process.Start(startInfo);
        }
    }
}
