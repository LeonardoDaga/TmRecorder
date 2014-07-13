using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common;

namespace FieldFormationControl
{
    public partial class LineupPlayer : UserControl
    {
        public class LupPlayer
        {
            public int Num;
            public string Name;
            public string Rule;
            public int Vote;
            public int Skills;
            public string Info;
            public string Tip;
            public int playerID;

            public LupPlayer(int num, string name, string rule, int skills)
            {
                Num = num;
                Name = name;
                Rule = rule;
                Skills = skills;
                Vote = -1;
                Info = "";
                Tip = "";
                playerID = 0;
            }
        }
        public bool tooltipVisible = false;

        List<LupPlayer> playerList = new List<LupPlayer>();

        Shirt shirt = new Shirt();
        public bool showDataPanel = true;
        FlyingPlayerDataPanel fdp = null;

        public Player Data
        {
            set
            {
                Number = value.number;
                PlName = value.name;
                Skills = value.skills;
                Rules = value.pf.ToUpper();
                Display = value.visible;
                Vote = value.vote;
                Value = value.value;
                Tip = value.tip;
                PlayerID = value.playerID;

                ShirtColor = value.shirtColor;

                float bright = value.shirtColor.GetBrightness();
                if (bright > 0.5)
                    NumberColor = Color.Black;
                else
                    NumberColor = Color.White;
            }
        }

        private Font _rulefont = new Font("Arial", 7);
        public Font RuleFont
        {
            get { return _rulefont; }
            set { _rulefont = value; this.Invalidate(); }
        }

        private Color _rulecolor1 = Color.White;
        public Color RuleColor1
        {
            get { return _rulecolor1; }
            set { _rulecolor1 = value; this.Invalidate(); }
        }

        private Color _rulecolor2 = Color.White;
        public Color RuleColor2
        {
            get { return _rulecolor2; }
            set { _rulecolor2 = value; this.Invalidate(); }
        }
        
        private Color _numbercolor = Color.White;
        public Color NumberColor
        {
            get { return _numbercolor; }
            set { _numbercolor = value; this.Invalidate(); }
        }

        private int _playerID = 0;
        public int PlayerID
        {
            get { return _playerID; }
            set { _playerID = value; }
        }

        private Font _valuefont = new Font("Arial", 8, FontStyle.Regular);
        public Font ValueFont
        {
            get { return _valuefont; }
            set { _valuefont = value; this.Invalidate(); }
        }

        private Font _namefont = new Font("Arial", 8);
        public Font NameFont
        {
            get { return _namefont; }
            set { _namefont = value; this.Invalidate(); }
        }

        private Color _namecolor = Color.LightYellow;
        public Color NameColor
        {
            get { return _namecolor; }
            set { _namecolor = value; this.Invalidate(); }
        }

        private Color _evidencecolor = Color.Transparent;
        public Color EvidenceColor
        {
            get { return _evidencecolor; }
            set { _evidencecolor = value; this.Invalidate(); }
        }

        private string _rule1 = "OMC";
        private string _rule2 = "OML";
        public string Rules
        {
            set
            {
                string[] rules = value.Split('/');
                _rule1 = rules[0];
                if (rules.Length > 1)
                    _rule2 = rules[1];
                else
                    _rule2 = "";

                this.Invalidate();
            }
            get
            {
                return _rule1 + "/" + _rule2;
            }
        }

        private float _vote = -1;
        public float Vote
        {
            set
            {
                _vote = value;
                this.Invalidate();
            }
            get
            {
                return _vote;
            }
        }

        private float _value = -1;
        public float Value
        {
            set
            {
                _value = value;
                this.Invalidate();
            }
            get
            {
                return _value;
            }
        }

        private string _tip = "";
        public string Tip
        {
            set
            {
                _tip = value;
                this.Invalidate();
            }
            get
            {
                return _tip;
            }
        }

        private string _titletip = "";
        public string TitleTip
        {
            set
            {
                _titletip = value;
                this.Invalidate();
            }
            get
            {
                return _titletip;
            }
        }


        private int _card = -1;
        public int Card
        {
            set
            {
                _card = value;
                this.Invalidate();
            }
            get
            {
                return _card;
            }
        }

        private Color _shirtcolor = Color.DarkRed;
        public Color ShirtColor
        {
            get { return _shirtcolor; }
            set { _shirtcolor = value; this.Invalidate(); }
        }


        private int _number;
        public int Number
        {
            set
            {
                _number = value;
                this.Invalidate();
            }
            get
            {
                return _number;
            }
        }

        private int _skills = 0;
        public int Skills
        {
            set
            {
                _skills = value;
                this.Invalidate();
            }

            get
            {
                return _skills;
            }
        }

        private string _name = "NNNNNNN Nome Cognome";
        public string PlName
        {
            set
            {
                 _name = value;
                 Invalidate();
            }
            get
            {
                return _name;
            }
        }

        private bool _display = false;
        public bool Display
        {
            get { return _display; }
            set { _display = value; }
        }

        private object _extradsRow = null;
        public object ExtraDsRow
        {
            get { return _extradsRow; }
            set { _extradsRow = value; }
        }

        private object _pldataRow = null;
        public object PlayerDataRow
        {
            get { return _pldataRow; }
            set { _pldataRow = value; }
        }

        public LineupPlayer()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            toolTipText.ToolTipTitle = "";
            toolTipText.SetToolTip(this, "");
        }

        public void FillContextMenu()
        {
            this.ContextMenuStrip.Items.Clear();

            foreach (LupPlayer pl in playerList)
            {
                string[] rules = pl.Rule.Split('/');

                foreach (string rule in rules)
                {
                    ToolStripItem mis = null;
                    foreach (ToolStripMenuItem mi0 in ContextMenuStrip.Items)
                    {
                        if (mi0.Text == rule)
                        {
                            mis = mi0;
                            break;
                        }
                    }

                    ToolStripMenuItem mi = null;
                    if (mis == null)
                    {
                        mi = new ToolStripMenuItem(rule);
                        this.ContextMenuStrip.Items.Add(mi);
                    }
                    else
                        mi = (ToolStripMenuItem)mis;

                    ToolStripMenuItem tsmi = new ToolStripMenuItem(pl.Num.ToString() + " - " + pl.Name + " (" + pl.Rule + ")");
                    tsmi.Click += new EventHandler(selectItemToolStripMenuItem_Click);
                    tsmi.Tag = pl;
                    mi.DropDownItems.Add(tsmi);
                }
            }
        }

        private void selectItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            LupPlayer pl = (LupPlayer)tsmi.Tag;

            this.PlName = pl.Name;
            this.Number = pl.Num;
            this.Rules = pl.Rule;
            this.Skills = pl.Skills;
            this.Vote = pl.Vote;
        }

        internal void SetData(ExtraDS.GiocatoriRow gr, ExtTMDataSet.GiocatoriNSkillRow gnsr)
        {
            this.PlName = gr.Nome;
            this.Rules = gr.FP;
            this.Number = gr.Numero;
            this.PlayerID = gr.PlayerID;

            this.PlayerDataRow = gnsr;
            this.ExtraDsRow = gr;

            _skills = 0;

            _skills += SkillCheck(gnsr.For, 12, 15, (int)(eSkills.Strong));
            _skills += SkillCheck(gnsr.Vel, 12, 15, (int)(eSkills.Fast));
            _skills += SkillCheck(gnsr.Mar + gnsr.Con, 24, 30, (int)(eSkills.Defender));
            _skills += SkillCheck(gnsr.Wor + gnsr.Pos, 24, 30, (int)(eSkills.Tactician));
            _skills += SkillCheck(gnsr.Pas + gnsr.Tec, 24, 30, (int)(eSkills.Playmaker));
            _skills += SkillCheck(gnsr.Vel + gnsr.Cro + gnsr.Tec, 36, 45, (int)(eSkills.Winger));
            _skills += SkillCheck(gnsr.Fin + gnsr.Tir, 24, 30, (int)(eSkills.Finisher));
            _skills += SkillCheck(gnsr.Tes, 12, 15, (int)(eSkills.Header));

            //string skString = "";
            //string stString = "";

            //int lowskills = _skills >> 16;

            //if ((_skills & (int)eSkills.Strong) != 0)
            //{
            //    skString += "[Str]";
            //}
            //if ((_skills & (int)eSkills.Defender) != 0)
            //{
            //    skString += "[Def]";
            //}
            //if ((_skills & (int)eSkills.Fast) != 0)
            //{
            //    skString += "[Pac]";
            //}
            //if ((_skills & (int)eSkills.Finisher) != 0)
            //{
            //    skString += "[Fin]";
            //}
            //if ((_skills & (int)eSkills.Header) != 0)
            //{
            //    skString += "[Hea]";
            //}
            //if ((_skills & (int)eSkills.Playmaker) != 0)
            //{
            //    skString += "[Ply]";
            //}
            //if ((_skills & (int)eSkills.Tactician) != 0)
            //{
            //    skString += "[Tac]";
            //}
            //if ((_skills & (int)eSkills.Winger) != 0)
            //{
            //    skString += "[Win]";
            //}
            //if ((_skills & (int)eSkills.RedCross) != 0)
            //{
            //    stString += "[Inj]";
            //}
            //if ((_skills & (int)eSkills.RedCard) != 0)
            //{
            //    stString += "[Ban]";
            //}

            //// Lower skills
            //if ((lowskills & (int)eSkills.Strong) != 0)
            //{
            //    skString += ",Str";
            //}
            //if ((lowskills & (int)eSkills.Defender) != 0)
            //{
            //    skString += ",Def";
            //}
            //if ((lowskills & (int)eSkills.Fast) != 0)
            //{
            //    skString += ",Pac";
            //}
            //if ((lowskills & (int)eSkills.Finisher) != 0)
            //{
            //    skString += ",Fin";
            //}
            //if ((lowskills & (int)eSkills.Header) != 0)
            //{
            //    skString += ",Hea";
            //}
            //if ((lowskills & (int)eSkills.Playmaker) != 0)
            //{
            //    skString += ",Ply";
            //}
            //if ((lowskills & (int)eSkills.Tactician) != 0)
            //{
            //    skString += ",Tac";
            //}
            //if ((lowskills & (int)eSkills.Winger) != 0)
            //{
            //    skString += ",Win";
            //}

            //_tip = ((skString != "") ? ("Skills = " + skString.TrimStart(',') + "\n") : "") +
            //    ((stString != "") ? ("Status = " + stString + "\n") : "");

            //_tip += "\nASI = " + gnsr.ASI.ToString() + "\n";

            //_tip += "\nStr\tSta\tPac\tMar\tTac\tWor\tPos\n" +
            //    gnsr.For.ToString() + "\t" +
            //    gnsr.Res.ToString() + "\t" +
            //    gnsr.Vel.ToString() + "\t" +
            //    gnsr.Mar.ToString() + "\t" +
            //    gnsr.Con.ToString() + "\t" +
            //    gnsr.Wor.ToString() + "\t" +
            //    gnsr.Pos.ToString() + "\t\n\n" +
            //    "Pas\tCro\tTec\tHea\tFin\tLon\tSet\n" +
            //    gnsr.Pas.ToString() + "\t" +
            //    gnsr.Cro.ToString() + "\t" +
            //    gnsr.Tec.ToString() + "\t" +
            //    gnsr.Tes.ToString() + "\t" +
            //    gnsr.Fin.ToString() + "\t" +
            //    gnsr.Tir.ToString() + "\t" +
            //    gnsr.Cal.ToString() + "\t";


            //_tip +=
            //    "\n----------------------------------------------------------" +
            //    "\n[DC]\t[DL]\t[DR]\t[DMC]\t[DML]\t[DMR]\n" +
            //    gnsr.DC.ToString("N1") + "\t" +
            //    gnsr.DL.ToString("N1") + "\t" +
            //    gnsr.DR.ToString("N1") + "\t" +
            //    gnsr.DMC.ToString("N1") + "\t" +
            //    gnsr.DML.ToString("N1") + "\t" +
            //    gnsr.DMR.ToString("N1") + "\n" +
            //    "\n[MC]\t[ML]\t[MR]\t[OMC]\t[OML]\t[OMR]\t[FC]\n" +
            //    gnsr.MC.ToString("N1") + "\t" +
            //    gnsr.ML.ToString("N1") + "\t" +
            //    gnsr.MR.ToString("N1") + "\t" +
            //    gnsr.OMC.ToString("N1") + "\t" +
            //    gnsr.OML.ToString("N1") + "\t" +
            //    gnsr.OMR.ToString("N1") + "\t" +
            //    gnsr.FC.ToString("N1") + "\n";

            //_titletip = _name + " (" + _rule1;
            //if (_rule2 != "") _titletip += "/" + _rule2;
            //_titletip += ")";
        }
        internal void SetData(ExtraDS.GiocatoriRow gr, ExtTMDataSet.PortieriNSkillRow gnsr)
        {
            this.PlName = gr.Nome;
            this.Rules = gr.FP;
            this.Number = gr.Numero;
            this.PlayerID = gr.PlayerID;

            this.PlayerDataRow = gnsr;
            this.ExtraDsRow = gr;

            _skills = 0;

            _skills += SkillCheck((decimal)gnsr.PO, 50, 75, (int)(eSkills.GK));
            _skills += SkillCheck(gnsr.For, 12, 15, (int)(eSkills.Strong));
            _skills += SkillCheck(gnsr.Vel, 12, 15, (int)(eSkills.Fast));

            //float grade = gnsr.PO;

            //this.RuleColor1 = Color.White;

            //string skString = "";
            //string stString = "";

            //int lowskills = _skills >> 16;

            //if ((_skills & (int)eSkills.GK) != 0)
            //{
            //    skString += "[GK!]";
            //}
            //if ((_skills & (int)eSkills.Strong) != 0)
            //{
            //    skString += "[Str]";
            //}
            //if ((_skills & (int)eSkills.Defender) != 0)
            //{
            //    skString += "[Def]";
            //}
            //if ((_skills & (int)eSkills.Fast) != 0)
            //{
            //    skString += "[Pac]";
            //}
            //if ((_skills & (int)eSkills.RedCross) != 0)
            //{
            //    stString += "[Inj]";
            //}
            //if ((_skills & (int)eSkills.RedCard) != 0)
            //{
            //    stString += "[Ban]";
            //}
            //if ((lowskills & (int)eSkills.Strong) != 0)
            //{
            //    skString += ",Str";
            //}
            //if ((lowskills & (int)eSkills.Defender) != 0)
            //{
            //    skString += ",Def";
            //}
            //if ((lowskills & (int)eSkills.Fast) != 0)
            //{
            //    skString += ",Pac";
            //}
            //if ((lowskills & (int)eSkills.GK) != 0)
            //{
            //    skString += ",GK!";
            //}

            //_tip = ((skString != "") ? ("Skills = " + skString.TrimStart(',') + "\n") : "") +
            //    ((stString != "") ? ("Status = " + stString + "\n") : "");

            //_tip += "\nASI = " + gnsr.ASI.ToString() + "\n";

            //_tip += "\nStr\tSta\tPac\tHan\tOne\tRef\n" +
            //    gnsr.For.ToString() + "\t" +
            //    gnsr.Res.ToString() + "\t" +
            //    gnsr.Vel.ToString() + "\t" +
            //    gnsr.Pre.ToString() + "\t" +
            //    gnsr.Uno.ToString() + "\t" +
            //    gnsr.Rif.ToString() + "\t\n\n" +
            //    "Ari\tJum\tCom\tKic\tThr\n" +
            //    gnsr.Aer.ToString() + "\t" +
            //    gnsr.Ele.ToString() + "\t" +
            //    gnsr.Com.ToString() + "\t" +
            //    gnsr.Tir.ToString() + "\t" +
            //    gnsr.Lan.ToString();


            //_tip += "\n\nGK = " + gnsr.PO.ToString("N2");

            //_titletip = _name + " (GK)";
        }

        private int SkillCheck(decimal grade, int l1, int l2, int eskill)
        {
            if (grade >= l2)
                return eskill;
            else if (grade >= l1)
                return eskill << 16;
            else
                return 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_evidencecolor != Color.Transparent)
            {
                Pen penEvid = new Pen(_evidencecolor);
                e.Graphics.DrawRectangle(penEvid, new Rectangle(1, 0, this.ClientSize.Width - 2, this.ClientSize.Height - 1));
                penEvid.Dispose();
            }

            if (!_display)
            {
                // Fill the Tooltip
                // toolTipText.ToolTipTitle = "";
                // toolTipText.SetToolTip(this, "");
                return;
            }

            // Fill the Tooltip
            // toolTipText.ToolTipTitle = _name;
            // toolTipText.SetToolTip(this, _tip);
            
            Brush brBack = new SolidBrush(_shirtcolor);
            Brush brShade = new SolidBrush(Color.DarkGray);
            Brush brNumb = new SolidBrush(_numbercolor);
            Brush brRule1 = new SolidBrush(_rulecolor1);
            Brush brRule2 = new SolidBrush(_rulecolor2);
            Brush brName = new SolidBrush(_namecolor);

            Pen pen = new Pen(_numbercolor);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            shirt.Draw(e.Graphics, brShade, brBack, pen);

            // Draw the number
            SizeF szf = e.Graphics.MeasureString(_number.ToString(), this.Font);
            RectangleF rectText = new RectangleF(40 - szf.Width / 2, 24 - szf.Height/2, szf.Width, szf.Height);
            if (_number != -1)
                e.Graphics.DrawString(_number.ToString(), this.Font, brNumb, rectText, sf);

            // Draw the rules
            sf.Alignment = StringAlignment.Far;
            rectText = new RectangleF(-2, 13, 26, _rulefont.SizeInPoints + 2);
            e.Graphics.DrawString(_rule1, _rulefont, brRule1, rectText, sf);
            rectText = new RectangleF(-2, 13 + _rulefont.SizeInPoints + 2, 26, _rulefont.SizeInPoints + 2);
            e.Graphics.DrawString(_rule2, _rulefont, brRule2, rectText, sf);

            // Draw the value
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Near;
            rectText = new RectangleF(54, 14, 24, 25);
            if (_value < 100)
                e.Graphics.DrawString(_value.ToString("N1"), _valuefont, brRule1, rectText, sf);
            else
                e.Graphics.DrawString(_value.ToString("N0"), _valuefont, brRule1, rectText, sf);

            //-------------------------------------------------
            // Draw the status and the skills
            // 1) Count the number of the status and skills to draw
            // 2) Calc the needed space
            // 3) Draw the images
            int count = 0;

            if ((_skills & (int)eSkills.Strong) != 0) count++;
            if ((_skills & (int)eSkills.Fast) != 0) count++;
            if ((_skills & (int)eSkills.Defender) != 0) count++;
            if ((_skills & (int)eSkills.Tactician) != 0) count++;
            if ((_skills & (int)eSkills.Playmaker) != 0) count++;
            if ((_skills & (int)eSkills.Winger) != 0) count++;
            if ((_skills & (int)eSkills.Finisher) != 0) count++;
            if ((_skills & (int)eSkills.Header) != 0) count++;
            if ((_skills & (int)eSkills.GK) != 0) count++;
            if ((_skills & (int)eSkills.RedCross) != 0) count++;
            if ((_skills & (int)eSkills.Star) != 0) count++;
            if ((_skills & (int)eSkills.RedCard) != 0) count++;
            if ((_skills & (int)eSkills.YellowCard) != 0) count++;

            int lowskills = _skills >> 16;

            if ((lowskills & (int)eSkills.Strong) != 0) count++;
            if ((lowskills & (int)eSkills.Fast) != 0) count++;
            if ((lowskills & (int)eSkills.Defender) != 0) count++;
            if ((lowskills & (int)eSkills.Tactician) != 0) count++;
            if ((lowskills & (int)eSkills.Playmaker) != 0) count++;
            if ((lowskills & (int)eSkills.Winger) != 0) count++;
            if ((lowskills & (int)eSkills.Finisher) != 0) count++;
            if ((lowskills & (int)eSkills.Header) != 0) count++;
            if ((lowskills & (int)eSkills.GK) != 0) count++;

            int posSt = this.Width / 2 - (12 * count / 2);
            if (posSt < 0) posSt = 0;

            Rectangle rect = new Rectangle(posSt, 0, 12, 12);
            // Draw status, if any
            if ((_skills & (int)eSkills.Strong) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[0], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.Defender) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[2], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.Fast) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[1], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.Finisher) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[6], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.Header) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[7], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.Playmaker) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[4], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.Tactician) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[3], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.Winger) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[5], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.GK) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[8], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.RedCross) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[9], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.Star) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[10], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.RedCard) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[12], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.YellowCard) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[11], rect);
                rect.Offset(12, 0);
            }

            // Lower skills
            if ((lowskills & (int)eSkills.Strong) != 0)
            {
                e.Graphics.DrawImage(assImageList0.Images[0], rect);
                rect.Offset(12, 0);
            }
            if ((lowskills & (int)eSkills.Defender) != 0)
            {
                e.Graphics.DrawImage(assImageList0.Images[2], rect);
                rect.Offset(12, 0);
            }
            if ((lowskills & (int)eSkills.Fast) != 0)
            {
                e.Graphics.DrawImage(assImageList0.Images[1], rect);
                rect.Offset(12, 0);
            }
            if ((lowskills & (int)eSkills.Finisher) != 0)
            {
                e.Graphics.DrawImage(assImageList0.Images[6], rect);
                rect.Offset(12, 0);
            }
            if ((lowskills & (int)eSkills.Header) != 0)
            {
                e.Graphics.DrawImage(assImageList0.Images[7], rect);
                rect.Offset(12, 0);
            }
            if ((lowskills & (int)eSkills.Playmaker) != 0)
            {
                e.Graphics.DrawImage(assImageList0.Images[4], rect);
                rect.Offset(12, 0);
            }
            if ((lowskills & (int)eSkills.Tactician) != 0)
            {
                e.Graphics.DrawImage(assImageList0.Images[3], rect);
                rect.Offset(12, 0);
            }
            if ((lowskills & (int)eSkills.Winger) != 0)
            {
                e.Graphics.DrawImage(assImageList0.Images[5], rect);
                rect.Offset(12, 0);
            }
            if ((lowskills & (int)eSkills.GK) != 0)
            {
                e.Graphics.DrawImage(assImageList0.Images[8], rect);
                rect.Offset(12, 0);
            }


            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Near;
            
            // Modificare interlinea
            rectText = new RectangleF(0, 37, 78, 40);
            e.Graphics.DrawString(_name.ToString(), _namefont, brName, rectText, sf);

            brBack.Dispose();
            brShade.Dispose();
            brNumb.Dispose();
            brRule1.Dispose();
            brRule2.Dispose();
            brName.Dispose();
            pen.Dispose();
        }

        internal void CopyTo(ref Player player)
        {
            player.number = Number;
            player.name = PlName;
            player.skills = Skills;
            player.pf = Rules;
            player.visible = Display;
            player.vote = Vote;
            player.value = Value;
            player.tip = Tip;
            player.playerID = PlayerID;
            player.shirtColor = ShirtColor;
        }

        private void LineupPlayer_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void LineupPlayer_MouseEnter(object sender, EventArgs e)
        {
            if (showDataPanel)
            {
                if (PlayerDataRow == null) return;
                if (_display == false) return;
                fdp = new FlyingPlayerDataPanel();
                fdp.Left = this.Right + this.Parent.Left + this.ParentForm.Left;
                fdp.Top = this.Bottom + this.Parent.Top + this.ParentForm.Top;
                fdp.SetData(PlayerDataRow, ExtraDsRow);
                fdp.Show(ParentForm);
            }
        }

        private void LineupPlayer_MouseLeave(object sender, EventArgs e)
        {
            if (fdp != null)
            {
                fdp.Close();
                fdp = null;
            }
        }

        private void LineupPlayer_MouseHover(object sender, EventArgs e)
        {
            if (fdp != null)
            {
                //Point pos = MousePosition;
                //fdp.Left = pos.X + 5;
                //fdp.Top = pos.Y + 5;
            }
        }
    }


}
