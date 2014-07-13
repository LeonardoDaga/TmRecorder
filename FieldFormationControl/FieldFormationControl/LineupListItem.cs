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
    public partial class LineupListItem : UserControl
    {
        public enum eDrawMode
        {
            UniformColor,
            ColorByPosition,
        }

        public event EventHandler ItemSelected;

        #region Properties
        private Formation _formation = new Formation(eFormationTypes.Type_4_4_2);
        public Formation formation
        {
            get
            {
                return _formation;
            }
            set
            {
                _formation = value;
                Invalidate();
            }
        }

        private bool _isselected = false;
        public bool IsSelected
        {
            get { return _isselected; }
            set { _isselected = value; this.Invalidate(); }
        }

        private Color _selectedcolor = Color.DarkOliveGreen;
        public Color SelectedColor
        {
            get { return _selectedcolor; }
            set { _selectedcolor = value; this.Invalidate(); }
        }

        private eDrawMode _drawMode = eDrawMode.UniformColor;
        public eDrawMode DrawMode
        {
            get { return _drawMode; }
            set { _drawMode = value; this.Invalidate(); }
        }
        #endregion

        public LineupListItem()
        {
            InitializeComponent();
        }

        private void LineupListItem_Paint(object sender, PaintEventArgs e)
        {
            Brush brBack = new SolidBrush(BackColor);
            Brush brSelect = new SolidBrush(SelectedColor);
            
            Brush brFore = null;
            Brush brGKo = null;
            Brush brDef = null; 
            Brush brMid = null; 
            Brush brAtt = null;
            Pen penCnt = null;
            Pen penLin = null;
            Brush brLin = null;
            Brush brCnt = null;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (_drawMode == eDrawMode.UniformColor)
            {
                brFore = new SolidBrush(ForeColor);
            }
            else
            {
                brGKo = new SolidBrush(Color.Blue);
                brDef = new SolidBrush(Color.Cyan);
                brMid = new SolidBrush(Color.Gold);
                brAtt = new SolidBrush(Color.Red);
                penCnt = new Pen(Color.Black);
                brCnt = new SolidBrush(Color.Black);
                penLin = new Pen(Color.White);
                brLin = new SolidBrush(Color.White);
            }

            Pen penL = new Pen(Color.LightYellow);
            Pen penD = new Pen(Color.DarkKhaki);

            if (_isselected)
                e.Graphics.FillRectangle(brSelect, this.ClientRectangle);
            else
                e.Graphics.FillRectangle(brBack, this.ClientRectangle);

            int w = this.ClientRectangle.Width-1;
            int h = this.ClientRectangle.Height-1;

            if (_drawMode != eDrawMode.ColorByPosition)
            {
                if (!_isselected)
                {
                    e.Graphics.DrawLine(penL, 0, 0, 0, h);
                    e.Graphics.DrawLine(penL, 0, h, w, h);
                    e.Graphics.DrawLine(penD, w, h, w, 0);
                    e.Graphics.DrawLine(penD, 0, 0, w, 0);
                }
                else
                {
                    e.Graphics.DrawLine(penD, 0, 0, 0, h);
                    e.Graphics.DrawLine(penD, 0, h, w, h);
                    e.Graphics.DrawLine(penL, w, h, w, 0);
                    e.Graphics.DrawLine(penL, 0, 0, w, 0);
                }
            }
            else
            {
                e.Graphics.DrawRectangle(penLin, 0, -1, w, h+1);
                e.Graphics.DrawRectangle(penLin, 0, h/3, w, h-h/3);
                e.Graphics.DrawRectangle(penLin, w / 4, (5 * h) / 6, w - w / 2, h - (5 * h) / 6);
            }
            
            for (int i=0; i<_formation.players.Length; i++)
            {
                if (!_formation.players[i].visible) continue;

                Rectangle rect = GetRectangleFromIndex(i);

                if (_drawMode == eDrawMode.UniformColor)
                    e.Graphics.FillEllipse(brFore, rect);
                else
                {
                    if ((_formation.players[i].bitPosition & BitP.MID) > 0)
                        e.Graphics.FillEllipse(brMid, rect);
                    else if ((_formation.players[i].bitPosition & BitP.DEF) > 0)
                        e.Graphics.FillEllipse(brDef, rect);
                    else if (_formation.players[i].bitPosition == BitP.GOK)
                        e.Graphics.FillEllipse(brGKo, rect);
                    else 
                        e.Graphics.FillEllipse(brAtt, rect);                    
                    e.Graphics.DrawEllipse(penCnt, rect);
                }
            }

            penL.Dispose();
            penD.Dispose();
            brBack.Dispose();
            brSelect.Dispose();

            if (brFore != null) brFore.Dispose();
            if (brDef != null) brDef.Dispose();
            if (brMid != null) brMid.Dispose();
            if (brAtt != null) brAtt.Dispose();
            if (brLin != null) brLin.Dispose();
            if (penLin != null) penLin.Dispose();
            if (brCnt != null) brCnt.Dispose();
            if (penCnt != null) penCnt.Dispose();
        }

        private Rectangle GetRectangleFromIndex(int i)
        {
            float left = 0f, top = 0f;
            float wd5 = (float)(this.ClientRectangle.Width-2) / 5f;
            float hd6 = (float)(this.ClientRectangle.Height-2) / 6f;

            switch (i)
            {
                case 1:
                case 6:
                case 11:
                case 16:
                    left = 1f; break;
                case 2:
                case 7:
                case 12:
                case 17:
                case 21:
                    left = 1f + wd5; break;
                case 0:
                case 3:
                case 8:
                case 13:
                case 18:
                case 22:
                    left = 1f + 2f * wd5; break;
                case 4:
                case 9:
                case 14:
                case 19:
                case 23:
                    left = 1f + 3f * wd5; break;
                case 5:
                case 10:
                case 15:
                case 20:
                    left = 1f + 4f * wd5; break;
            }
            switch (i)
            {
                case 0:
                    top = 1f + 5f * hd6; break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    top = 1f + 4f * hd6; break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    top = 1f + 3f * hd6; break;
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    top = 1f + 2f * hd6; break;
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    top = 1f + hd6; break;
                case 21:
                case 22:
                case 23:
                    top = 1f; break;
            }
            
            return new Rectangle((int)left, (int)top, (int)wd5, (int)hd6);
        }

        private void LineupListItem_Click(object sender, EventArgs e)
        {
            if (_isselected) return;

            ItemSelected(this, e);
        }


    }
}
