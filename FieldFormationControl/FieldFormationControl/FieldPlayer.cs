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
    public partial class FieldPlayer : UserControl
    {
        public bool showDataPanel = false;
        FlyingPlayerDataPanel fdp = null;

        public class FldPlayer
        {
            public int Num;
            public string Name;
            public string Rule;
            public int Vote;
            public int Skills;
            public string Info;
            public string Tip;
            public int playerID;

            public FldPlayer(int num, string name, string rule, int skills)
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

        List<FldPlayer> playerList = new List<FldPlayer>();

        Shirt shirt = new Shirt();

        public Player Data
        {
            set
            {
                Number = value.number;
                PlName = value.name;
                Skills = value.skills;
                Rules = value.pf.ToUpper();
                Visible = value.visible;
                Vote = value.vote;
                Value = value.value;
                ShowValue = value.showValue;
                Info = value.info;
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

        private Color _rulecolor = Color.White;
        public Color RuleColor
        {
            get { return _rulecolor; }
            set { _rulecolor = value; this.Invalidate(); }
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

        private Font _votefont = new Font("Arial", 10);
        public Font VoteFont
        {
            get { return _votefont; }
            set { _votefont = value; this.Invalidate(); }
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

        private bool _showValue = false;
        public bool ShowValue
        {
            set
            {
                _showValue = value;
                this.Invalidate();
            }
            get
            {
                return _showValue;
            }
        }

        private string _info = "";
        public string Info
        {
            set
            {
                _info = value;
                this.Invalidate();
            }
            get
            {
                return _info;
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

        public FieldPlayer()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            /*
            FillContextMenu();
             */
        }

        public void FillContextMenu()
        {
            this.ContextMenuStrip.Items.Clear();

            foreach (FldPlayer pl in playerList)
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
            FldPlayer pl = (FldPlayer)tsmi.Tag;

            this.PlName = pl.Name;
            this.Number = pl.Num;
            this.Rules = pl.Rule;
            this.Skills = pl.Skills;
            this.Vote = pl.Vote;
            this.Info = pl.Info;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush brBack = new SolidBrush(_shirtcolor);
            Brush brShade = new SolidBrush(Color.DarkGray);
            Brush brNumb = new SolidBrush(_numbercolor);
            Brush brRule = new SolidBrush(_rulecolor);
            Brush brName = new SolidBrush(_namecolor);

            Pen penEvid = new Pen(_evidencecolor);
            Pen pen = new Pen(_numbercolor);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            if (_evidencecolor != Color.Transparent)
            {
                e.Graphics.DrawRectangle(penEvid, new Rectangle(1, 0, this.ClientSize.Width - 2, this.ClientSize.Height - 1));
            }

            shirt.Draw(e.Graphics, brShade, brBack, pen);

            // Draw the number
            SizeF szf = e.Graphics.MeasureString(_number.ToString(), this.Font);
            RectangleF rectText = new RectangleF(40 - szf.Width / 2, 24 - szf.Height/2, szf.Width, szf.Height);
            if (_number != -1)
                e.Graphics.DrawString(_number.ToString(), this.Font, brNumb, rectText, sf);

            // Draw the rules
            sf.Alignment = StringAlignment.Far;
            rectText = new RectangleF(-2, 13, 26, _rulefont.SizeInPoints + 2);
            e.Graphics.DrawString(_rule1, _rulefont, brRule, rectText, sf);
            rectText = new RectangleF(-2, 13 + _rulefont.SizeInPoints + 2, 26, _rulefont.SizeInPoints + 2);
            e.Graphics.DrawString(_rule2, _rulefont, brRule, rectText, sf);

            // Draw the vote
            if (_vote != -1)
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Near;
                rectText = new RectangleF(52, 14, 24, 25);

                if (_showValue)
                    e.Graphics.DrawString(_value.ToString("N1"), _votefont, brRule, rectText, sf);
                else
                    e.Graphics.DrawString(_vote.ToString("N0"), _votefont, brRule, rectText, sf);
            }
            else // Draw the info
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                rectText = new RectangleF(52, 14, 24, 25);
                e.Graphics.DrawString(_info.ToString(), _rulefont, brRule, rectText, sf);
            }

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
            if ((_skills & (int)eSkills.RedCross) != 0) count++;
            if ((_skills & (int)eSkills.Star) != 0) count++;
            if ((_skills & (int)eSkills.RedCard) != 0) count++;
            if ((_skills & (int)eSkills.YellowCard) != 0) count++;

            int posSt = this.Width / 2 - (12 * count / 2);

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
            if ((_skills & (int)eSkills.RedCross) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[8], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.Star) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[9], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.RedCard) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[11], rect);
                rect.Offset(12, 0);
            }
            if ((_skills & (int)eSkills.YellowCard) != 0)
            {
                e.Graphics.DrawImage(assImageList.Images[10], rect);
                rect.Offset(12, 0);
            }


            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Near;
            
            // Modificare interlinea
            rectText = new RectangleF(0, 37, 78, 40);
            e.Graphics.DrawString(_name.ToString(), _namefont, brName, rectText, sf);

            // Fill the Tooltip
            toolTipText.ToolTipTitle = _name;
            toolTipText.SetToolTip(this, _tip);

            penEvid.Dispose();
            brBack.Dispose();
            brShade.Dispose();
            brNumb.Dispose();
            brRule.Dispose();
            brName.Dispose();
            pen.Dispose();
        }

        private void FieldPlayer_MouseEnter(object sender, EventArgs e)
        {
            if (showDataPanel)
            {
                fdp = new FlyingPlayerDataPanel();
                // fdp.
                fdp.Show();
            }
        }

        private void FieldPlayer_MouseLeave(object sender, EventArgs e)
        {
            if (fdp != null)
            {
                fdp = null;
            }
        }

        private void FieldPlayer_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }


}
