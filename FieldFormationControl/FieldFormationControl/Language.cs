using System;
using System.Collections.Generic;
using System.Text;
using Languages;
using System.Drawing;

namespace FieldFormationControl
{
    partial class FlyingPlayerDataPanel
    {
        int actualPanelType = -1;

        /// <summary>
        /// Set the language of the flying panel
        /// </summary>
        /// <param name="panelType">0: Player, 1: Goalkeeper</param>
        public void SetLanguage(int panelType)
        {
            if (actualPanelType == panelType) return;

            if (panelType == 0)
            {
                this.label2.Text = Languages.Current.Language.Age;
                this.lblTtl1.Text = Languages.Current.Language.Str;
                this.lblTtl2.Text = Languages.Current.Language.Res;
                this.lblTtl3.Text = Languages.Current.Language.Pac;
                this.lblTtl4.Text = Languages.Current.Language.Mar;
                this.lblTtl5.Text = Languages.Current.Language.Tak;
                this.lblTtl6.Text = Languages.Current.Language.Wor;
                this.lblTtl7.Text = Languages.Current.Language.Pos;
                this.lblTtl8.Text = Languages.Current.Language.Pas;
                this.lblTtl9.Text = Languages.Current.Language.Cro;
                this.lblTtl10.Text = Languages.Current.Language.Tec;
                this.lblTtl11.Text = Languages.Current.Language.Hea;
                this.lblTtl12.Text = Languages.Current.Language.Fin;
                this.lblTtl12.ForeColor = Color.LimeGreen;
                this.lblTtl13.Text = Languages.Current.Language.Tir;
                this.lblTtl14.Text = Languages.Current.Language.Kic;
                this.lblTtl15.Text = Languages.Current.Language.Rou;
                this.lblTtl15.ForeColor = Color.SandyBrown;

                this.lblTtl16.Text = "Win";
                this.lblTtl17.Text = "ShP";
                this.lblTtl18.Text = "Lon";
                this.lblTtl19.Text = "Thr";
            }
            else
            {
                this.label2.Text = Languages.Current.Language.Age;
                this.lblTtl1.Text = Languages.Current.Language.Str;
                this.lblTtl2.Text = Languages.Current.Language.Res;
                this.lblTtl3.Text = Languages.Current.Language.Pac;
                this.lblTtl4.Text = Languages.Current.Language.Han;
                this.lblTtl5.Text = Languages.Current.Language.One;
                this.lblTtl6.Text = Languages.Current.Language.Ref;
                this.lblTtl7.Text = Languages.Current.Language.Ari;
                this.lblTtl8.Text = Languages.Current.Language.Jum;
                this.lblTtl9.Text = Languages.Current.Language.Com;
                this.lblTtl10.Text = Languages.Current.Language.Kic;
                this.lblTtl11.Text = Languages.Current.Language.Thr;
                this.lblTtl12.Text = Languages.Current.Language.Rou;
                this.lblTtl12.ForeColor = Color.SandyBrown;
                this.lblTtl13.Visible = false;
                this.lblTtl14.Visible = false;

                this.lblTtl15.Visible = false;
                this.lblTtl16.Visible = false;
                this.lblTtl17.Visible = false;
                this.lblTtl18.Visible = false;
                this.lblTtl19.Visible = false;
            }

            actualPanelType = panelType;
        }
    }
}