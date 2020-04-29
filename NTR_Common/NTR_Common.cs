using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTR_Common
{
    public enum eRatingFunctionType
    {
        RatingR2,
        RatingR3,
        RatingAtleticoCassina,
        RUSCheratte,
        RatingL2,
        RatingR4,
    }

    public class FormattedString : IComparable<FormattedString>
    {
        public bool isBold;
        public string value;
        public Color backColor = Color.White;
        public Color fontColor = Color.Black;
        public Color tagColor = Color.Black;

        public string ToolTip { get; set; }

        public FormattedString(string s)
        {
            value = s;
        }

        public static implicit operator FormattedString(string s)
        {
            return new FormattedString(s);
        }

        public override string ToString()
        {
            return value;
        }

        public int CompareTo(FormattedString other)
        {
            return this.ToString().CompareTo(other.ToString());
        }

        public static Color VoteColor(float vote)
        {
            if (vote < 4)
                return Color.Goldenrod;
            else if (vote < 7)
                return Color.Green;
            else
                return Color.DarkViolet;
        }
    }
}
