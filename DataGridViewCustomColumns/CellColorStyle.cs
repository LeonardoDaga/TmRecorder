using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DataGridViewCustomColumns
{
    public class CellColorStyle
    {
        public decimal LoLimit;
        public decimal HiLimit;
        public Color BackColor;
        public Color ForeColor;
        public Color SelectionBackColor;
        public Color SelectionForeColor;

        public CellColorStyle(decimal lo, decimal hi, Color back, Color font, Color backhl, Color fonthl)
        {
            LoLimit = lo;
            HiLimit = hi;
            BackColor = back;
            ForeColor = font;
            SelectionBackColor = backhl;
            SelectionForeColor = fonthl;
        }
    }

    public class CellColorStyleList: List<CellColorStyle>
    {
        public CellColorStyle GetColorStyle(decimal val)
        {
            foreach (var colorStyle in this)
            {
                if ((val >= colorStyle.LoLimit) && (val < colorStyle.HiLimit))
                {
                    return colorStyle;
                }
            }

            return null;
        }

        public static CellColorStyleList DefaultGainColorStyle()
        {
            CellColorStyleList newList = new CellColorStyleList();

            newList.Add(new CellColorStyle(-100, 0, Color.FromArgb(255, 255, 255), Color.Black,
                Color.FromArgb(255, 255, 255), Color.Blue));
            newList.Add(new CellColorStyle(0, 15, Color.FromArgb(255, 255, 255), Color.Black,
                Color.FromArgb(255, 255, 255), Color.Blue));
            newList.Add(new CellColorStyle(15, 32, Color.FromArgb(255, 255, 192), Color.Black,
                Color.FromArgb(255, 255, 192), Color.Blue));
            newList.Add(new CellColorStyle(32, 60, Color.FromArgb(255, 255, 0), Color.Black,
                Color.FromArgb(255, 255, 0), Color.Blue));
            newList.Add(new CellColorStyle(60, 75, Color.FromArgb(255, 192, 0), Color.Black,
                Color.FromArgb(255, 192, 0), Color.Blue));
            newList.Add(new CellColorStyle(75, 90, Color.FromArgb(255, 128, 0), Color.Black,
                Color.FromArgb(255, 128, 0), Color.Blue));
            newList.Add(new CellColorStyle(90, 100, Color.FromArgb(255, 0, 0), Color.Black,
                Color.FromArgb(255, 0, 0), Color.Blue));
            return newList;
        }

        public static CellColorStyleList DefaultFpColorStyle()
        {
            CellColorStyleList newList = new CellColorStyleList();

            newList.Add(new CellColorStyle(-100, 0, Color.White, Color.Black,
                Color.FromArgb(255, 255, 255), Color.Blue));
            newList.Add(new CellColorStyle(0, 20, Color.DarkGreen, Color.RoyalBlue,
                Color.Green, Color.RoyalBlue));
            newList.Add(new CellColorStyle(20, 30, Color.DarkGreen, Color.Cyan,
                Color.Green, Color.Cyan));
            newList.Add(new CellColorStyle(30, 50, Color.DarkGreen, Color.Lime,
                Color.Green, Color.Lime));
            newList.Add(new CellColorStyle(50, 60, Color.DarkGreen, Color.Yellow,
                Color.Green, Color.Yellow));
            newList.Add(new CellColorStyle(60, 70, Color.DarkGreen, Color.Salmon,
                Color.Green, Color.Salmon));
            newList.Add(new CellColorStyle(70, 85, Color.DarkGreen, Color.Red,
                Color.Green, Color.Red));
            newList.Add(new CellColorStyle(85, 100, Color.DarkGreen, Color.Violet,
                Color.Green, Color.Violet));
            return newList;

        }
    }
}
