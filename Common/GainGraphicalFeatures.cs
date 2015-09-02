using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Common
{
    public class ColorUtilities
    {
        public static void SelectGainColor(float f, ref DataGridViewCellStyle Style)
        {
            float grade = (float)(f * 10f);

            //if (grade < 15)
            //{
            //    Style.BackColor = Color.FromArgb(255, 255, 255);
            //    Style.SelectionBackColor = Color.FromArgb(255, 255, 224);
            //}
            //else if (grade < 32)
            //{
            //    Style.BackColor = Color.FromArgb(255, 255, 192);
            //    Style.SelectionBackColor = Color.FromArgb(255, 255, 160);
            //}
            //else 
            //    if (grade < 55)
            //{
            //    Style.BackColor = Color.FromArgb(255, 255, 32);
            //    Style.SelectionBackColor = Color.FromArgb(255, 255, 0);
            //}
            if (grade < 55)
            {
                Style.BackColor = Color.FromArgb(255, 255, 32 + (int)((222f * (55f - grade)) / 55f));
                Style.SelectionBackColor = Color.FromArgb(255, 255, (int)((224f * (55f - grade)) / 55f));
            }
            //else if (grade < 70)
            //{
            //    Style.BackColor = Color.FromArgb(255, 192, 0);
            //    Style.SelectionBackColor = Color.FromArgb(255, 160, 0);
            //}
            //else if (grade < 90)
            //{
            //    Style.BackColor = Color.FromArgb(255, 128, 0);
            //    Style.SelectionBackColor = Color.FromArgb(255, 96, 0);
            //}
            //else
            //{
            //    Style.BackColor = Color.FromArgb(255, 32, 0);
            //    Style.SelectionBackColor = Color.FromArgb(255, 0, 0);
            //}
            else
            {
                Style.BackColor = Color.FromArgb(255, 32 + (int)((222f * (100f - grade)) / 45f), 0);
                Style.SelectionBackColor = Color.FromArgb(255, (int)((222f * (100f - grade)) / 45f), 0);
            }

            Style.ForeColor = Color.Black;
            Style.SelectionForeColor = Color.Blue;
        }

    }
}