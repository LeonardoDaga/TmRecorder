using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TM_Scanner
{
    public class HTML_Parser
    {
        public static List<string> GetTags(string html, string tagType)
        {
            int pos = 0;
            int posEnd = 0;
            string tagIn = "<" + tagType;
            string tagOut = "</" + tagType + ">";

            List<string> stringlist = new List<string>();

            while ((pos = html.IndexOf(tagIn, posEnd, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                pos = html.IndexOf(">", pos) + 1;

                posEnd = html.IndexOf(tagOut, pos, StringComparison.OrdinalIgnoreCase);

                if (posEnd == -1) return stringlist;

                stringlist.Add(html.Substring(pos, posEnd - pos));
            }

            return stringlist;
        }

        public static string GetTag(string html, string tagType)
        {
            int pos = 0;
            int posEnd = 0;
            string tagIn = "<" + tagType;
            string tagOut = "</" + tagType + ">";

            string str = "";

            if ((pos = html.IndexOf(tagIn, posEnd, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                pos = html.IndexOf(">", pos) + 1;

                posEnd = html.IndexOf(tagOut, pos, StringComparison.OrdinalIgnoreCase);

                if (posEnd == -1) return "";

                str = html.Substring(pos, posEnd - pos);
            }

            return str;
        }

        internal static string Cut(string str, string cut)
        {
            int pos = 0;
            while ((pos = str.IndexOf(cut, pos, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                str = str.Substring(0, pos) + str.Substring(pos + cut.Length);
            }
            return str;
        }

        internal static string CutField(string str, string tagType)
        {
            string tagIn = "<" + tagType;
            string outstr = str;

            int ipos = 0;
            while ((ipos = outstr.IndexOf(tagIn, ipos, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                int epos = ipos;
                int level = 1;

                while (level > 0)
                {
                    int open = outstr.IndexOf("<", epos+1);
                    int close = outstr.IndexOf(">", epos);

                    if ((open < close)&&(open != -1))
                    {
                        level++;
                        epos = open + 1;
                    }
                    else
                    {
                        level--;
                        epos = close + 1;
                    }
                }

                outstr = outstr.Substring(0, ipos) + outstr.Substring(epos); 
            }

            return outstr;
        }

        internal static string GetField(string str, string l1, string l2)
        {
            int i0 = str.IndexOf(l1);
            if (i0 == -1) return "";
            int i1 = i0 + l1.Length;
            int i2 = str.IndexOf(l2, i1);
            return str.Substring(i1, i2 - i1);
        }

        internal static string GetField(string str, string l1, string l2, string defstr)
        {
            int i0 = str.IndexOf(l1);
            if (i0 == -1) return defstr;
            int i1 = i0 + l1.Length;
            int i2 = str.IndexOf(l2, i1);
            return str.Substring(i1, i2 - i1);
        }
    }
}
