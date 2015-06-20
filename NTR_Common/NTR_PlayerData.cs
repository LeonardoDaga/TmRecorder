using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NTR_Common;
using Common;

namespace NTR_Common
{
    public partial class NTR_PlayerData : UserControl
    {
        public NTR_PlayerData()
        {
            InitializeComponent();
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

                        lblAda.Text = pr.Ada.ToString();
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

                    lblSOi.Text = pr.OSi.ToString();

                    if (!pr.IsSSDNull())
                        lblSsd.Text = pr.SSD.ToString();
                    else
                        lblSsd.Text = "-";

                    lblName.Text = pr.Nome;

                    if (!pr.IsCStrNull())
                        lblCRec.Text = pr.CStr.ToString();
                    else
                        lblCRec.Text = "-";

                    if (!pr.IsRecNull())
                        lblRec.Text = pr.Rec.ToString();
                    else
                        lblRec.Text = "-";

                    if (!pr.IsNationalityNull())
                    {
                        int ix = flagImgList.Images.IndexOfKey(pr.Nationality.ToString() + ".png");
                        pictFlag.Image = flagImgList.Images[ix];
                    }

                    if (!pr.IsProNull())
                        lblProfessionalism.Text = pr.Pro.ToString();
                    if (!pr.IsAggNull())
                        lblAggression.Text = pr.Agg.ToString();
                    //if (!pr.IsInfortunatoNull())
                    //    lblInjuryPro.Text = pr.InjPro.ToString();

                    string FP = Tm_Utility.NumberToFP(pr.FPn);

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

                }
                catch(Exception e)
                { }
            }
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

        private void NTR_PlayerData_Load(object sender, EventArgs e)
        {

        }
    }
}
