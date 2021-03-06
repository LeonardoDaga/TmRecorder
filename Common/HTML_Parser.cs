using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public class HTML_Parser
    {
        #region Unicodes definition
        static char[] unicodes = {
            '€', '', '‚', 'ƒ', '„', '…', '†', '‡', 'ˆ', '‰', 'Š', '‹', 'Œ', '', 'Ž', '', '', '‘', '’', '“', '”', '•', '–', '—', '˜', '™', 'š', '›', 'œ', '', 'ž', 'Ÿ',
            ' ', '¡', '¢', '£', '¤', '¥', '¦', '§', '¨', '©', 'ª', '«', '¬', ' ', '®', '¯', '°', '±', '²', '³', '´', 'µ', '¶', '·', '¸', '¹', 'º', '»', '¼', '½', '¾', '¿',
            'À', 'Á', 'Â', 'Ã', 'Ä', 'Å', 'Æ', 'Ç', 'È', 'É', 'Ê', 'Ë', 'Ì', 'Í', 'Î', 'Ï', 'Ð', 'Ñ', 'Ò', 'Ó', 'Ô', 'Õ', 'Ö', '×', 'Ø', 'Ù', 'Ú', 'Û', 'Ü', 'Ý', 'Þ', 'ß',
            'à', 'á', 'â', 'ã', 'ä', 'å', 'æ', 'ç', 'è', 'é', 'ê', 'ë', 'ì', 'í', 'î', 'ï', 'ð', 'ñ', 'ò', 'ó', 'ô', 'õ', 'ö', '÷', 'ø', 'ù', 'ú', 'û', 'ü', 'ý', 'þ', 'ÿ',
            'Ā', 'ā', 'Ă', 'ă', 'Ą', 'ą', 'Ć', 'ć', 'Ĉ', 'ĉ', 'Ċ', 'ċ', 'Č', 'č', 'Ď', 'ď', 'Đ', 'đ', 'Ē', 'ē', 'Ĕ', 'ĕ', 'Ė', 'ė', 'Ę', 'ę', 'Ě', 'ě', 'Ĝ', 'ĝ', 'Ğ', 'ğ',
            'Ġ', 'ġ', 'Ģ', 'ģ', 'Ĥ', 'ĥ', 'Ħ', 'ħ', 'Ĩ', 'ĩ', 'Ī', 'ī', 'Ĭ', 'ĭ', 'Į', 'į', 'İ', 'ı', 'Ĳ', 'ĳ', 'Ĵ', 'ĵ', 'Ķ', 'ķ', 'ĸ', 'Ĺ', 'ĺ', 'Ļ', 'ļ', 'Ľ', 'ľ', 'Ŀ',
            'ŀ', 'Ł', 'ł', 'Ń', 'ń', 'Ņ', 'ņ', 'Ň', 'ň', 'ŉ', 'Ŋ', 'ŋ', 'Ō', 'ō', 'Ŏ', 'ŏ', 'Ő', 'ő', 'Œ', 'œ', 'Ŕ', 'ŕ', 'Ŗ', 'ŗ', 'Ř', 'ř', 'Ś', 'ś', 'Ŝ', 'ŝ', 'Ş', 'ş',
            'Š', 'š', 'Ţ', 'ţ', 'Ť', 'ť', 'Ŧ', 'ŧ', 'Ũ', 'ũ', 'Ū', 'ū', 'Ŭ', 'ŭ', 'Ů', 'ů', 'Ű', 'ű', 'Ų', 'ų', 'Ŵ', 'ŵ', 'Ŷ', 'ŷ', 'Ÿ', 'Ź', 'ź', 'Ż', 'ż', 'Ž', 'ž', 'ſ',
            'ƀ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'Ɖ', 'Ɗ', 'Ƌ', 'ƌ', 'ƍ', 'Ǝ', 'Ə', 'Ɛ', 'Ƒ', 'ƒ', 'Ɠ', 'Ɣ', 'ƕ', 'Ɩ', 'Ɨ', 'Ƙ', 'ƙ', 'ƚ', 'ƛ', 'Ɯ', 'Ɲ', 'ƞ', 'Ɵ',
            'Ơ', 'ơ', 'Ƣ', 'ƣ', 'Ƥ', 'ƥ', 'Ʀ', 'Ƨ', 'ƨ', 'Ʃ', 'ƪ', 'ƫ', 'Ƭ', 'ƭ', 'Ʈ', 'Ư', 'ư', 'Ʊ', 'Ʋ', 'Ƴ', 'ƴ', 'Ƶ', 'ƶ', 'Ʒ', 'Ƹ', 'ƹ', 'ƺ', 'ƻ', 'Ƽ', 'ƽ', 'ƾ', 'ƿ',
            'ǀ', 'ǁ', 'ǂ', 'ǃ', 'Ǆ', 'ǅ', 'ǆ', 'Ǉ', 'ǈ', 'ǉ', 'Ǌ', 'ǋ', 'ǌ', 'Ǎ', 'ǎ', 'Ǐ', 'ǐ', 'Ǒ', 'ǒ', 'Ǔ', 'ǔ', 'Ǖ', 'ǖ', 'Ǘ', 'ǘ', 'Ǚ', 'ǚ', 'Ǜ', 'ǜ', 'ǝ', 'Ǟ', 'ǟ',
            'Ǡ', 'ǡ', 'Ǣ', 'ǣ', 'Ǥ', 'ǥ', 'Ǧ', 'ǧ', 'Ǩ', 'ǩ', 'Ǫ', 'ǫ', 'Ǭ', 'ǭ', 'Ǯ', 'ǯ', 'ǰ', 'Ǳ', 'ǲ', 'ǳ', 'Ǵ', 'ǵ', 'Ƕ', 'Ƿ', 'Ǹ', 'ǹ', 'Ǻ', 'ǻ', 'Ǽ', 'ǽ', 'Ǿ', 'ǿ',
            'Ȁ', 'ȁ', 'Ȃ', 'ȃ', 'Ȅ', 'ȅ', 'Ȇ', 'ȇ', 'Ȉ', 'ȉ', 'Ȋ', 'ȋ', 'Ȍ', 'ȍ', 'Ȏ', 'ȏ', 'Ȑ', 'ȑ', 'Ȓ', 'ȓ', 'Ȕ', 'ȕ', 'Ȗ', 'ȗ', 'Ș', 'ș', 'Ț', 'ț', 'Ȝ', 'ȝ', 'Ȟ', 'ȟ',
            'Ƞ', 'ȡ', 'Ȣ', 'ȣ', 'Ȥ', 'ȥ', 'Ȧ', 'ȧ', 'Ȩ', 'ȩ', 'Ȫ', 'ȫ', 'Ȭ', 'ȭ', 'Ȯ', 'ȯ', 'Ȱ', 'ȱ', 'Ȳ', 'ȳ', 'ȴ', 'ȵ', 'ȶ', 'ȷ', 'ȸ', 'ȹ', 'Ⱥ', 'Ȼ', 'ȼ', 'Ƚ', 'Ⱦ', 'ȿ',
            'ɀ', 'Ɂ', 'ɂ', 'Ƀ', 'Ʉ', 'Ʌ', 'Ɇ', 'ɇ', 'Ɉ', 'ɉ', 'Ɋ', 'ɋ', 'Ɍ', 'ɍ', 'Ɏ', 'ɏ', 'ɐ', 'ɑ', 'ɒ', 'ɓ', 'ɔ', 'ɕ', 'ɖ', 'ɗ', 'ɘ', 'ə', 'ɚ', 'ɛ', 'ɜ', 'ɝ', 'ɞ', 'ɟ',
            'ɠ', 'ɡ', 'ɢ', 'ɣ', 'ɤ', 'ɥ', 'ɦ', 'ɧ', 'ɨ', 'ɩ', 'ɪ', 'ɫ', 'ɬ', 'ɭ', 'ɮ', 'ɯ', 'ɰ', 'ɱ', 'ɲ', 'ɳ', 'ɴ', 'ɵ', 'ɶ', 'ɷ', 'ɸ', 'ɹ', 'ɺ', 'ɻ', 'ɼ', 'ɽ', 'ɾ', 'ɿ', 
            'ʀ', 'ʁ', 'ʂ', 'ʃ', 'ʄ', 'ʅ', 'ʆ', 'ʇ', 'ʈ', 'ʉ', 'ʊ', 'ʋ', 'ʌ', 'ʍ', 'ʎ', 'ʏ', 'ʐ', 'ʑ', 'ʒ', 'ʓ', 'ʔ', 'ʕ', 'ʖ', 'ʗ', 'ʘ', 'ʙ', 'ʚ', 'ʛ', 'ʜ', 'ʝ', 'ʞ', 'ʟ'};
        #endregion

        public static string ConvertHTML(string html)
        {
            //int ix = html.IndexOf("\xc4\x2021");
            char[] ch = html.ToCharArray();
            html = html.Replace("\xc5\xa1", "\u0161");

            html = html.Replace("\xc3\x81", "\xc1");

            html = html.Replace("\xc3\xa0", "\xe0");
            html = html.Replace("\xc3\xa1", "\xe1");
            html = html.Replace("\xc3\xa2", "\xe2");
            html = html.Replace("\xc3\xa3", "\xe3");
            html = html.Replace("\xc3\xa4", "\xe4");
            html = html.Replace("\xc3\xa5", "\xe5");
            html = html.Replace("\xc3\xa6", "\xe6");
            html = html.Replace("\xc3\xa7", "\xe7");
            html = html.Replace("\xc3\xa8", "\xe8");
            html = html.Replace("\xc3\xa9", "\xe9");
            html = html.Replace("\xc3\xaa", "\xea");
            html = html.Replace("\xc3\xab", "\xeb");
            html = html.Replace("\xc3\xac", "\xec");
            html = html.Replace("\xc3\xad", "\xed");
            html = html.Replace("\xc3\xae", "\xee");
            html = html.Replace("\xc3\xaf", "\xef");
            html = html.Replace("\xc3\xb0", "\xf0");
            html = html.Replace("\xc3\xb1", "\xf1");
            html = html.Replace("\xc3\xb2", "\xf2");
            html = html.Replace("\xc3\xb3", "\xf3");
            html = html.Replace("\xc3\xb4", "\xf4");
            html = html.Replace("\xc3\xb5", "\xf5");
            html = html.Replace("\xc3\xb6", "\xf6");
            html = html.Replace("\xc3\xb8", "\xf8");
            html = html.Replace("\xc3\xb9", "\xf9");
            html = html.Replace("\xc3\xba", "\xfa");
            html = html.Replace("\xc3\xbb", "\xfb");
            html = html.Replace("\xc3\xbc", "\xfc");

            html = html.Replace("\xc3\x2021", "\xc7");
            html = html.Replace("\xc3\x201c", "\xd3");
            html = html.Replace("\xc3\x2030", "\xc9");
            html = html.Replace("\xc3\x02dc", "\xd8");

            html = html.Replace("\xc4\x8d", "\u010D");
            html = html.Replace("\xc4\xbc", "\u013c");
            html = html.Replace("\xc4\x2018", "\u0111");
            html = html.Replace("\xc4\x2021", "\u0107");
            html = html.Replace("\xc4\x2026", "\u0105");
            html = html.Replace("\xc4\x0152", "\u010c");

            html = html.Replace("\xc5\xab", "\u0160");
            html = html.Replace("\xc5\xbd", "\u017d");
            html = html.Replace("\xc5\xbe", "\u017e");
            html = html.Replace("\xc5\x2122", "\u0159");
            html = html.Replace("\xc5\x0161", "\u015a");
            html = html.Replace("\xc5\xa0", "\u0160");
            html = html.Replace("\xc5\x201a", "\u0142");
            html = html.Replace("\xc5\x201e", "\u0144");

            html = html.Replace("\x00c3\x0153", "\xdc");
            html = html.Replace("\xd8\xa7", "\u0627");
            html = html.Replace("\xd8\xa8", "\u0628");
            html = html.Replace("\xd8\xa9", "\u0629");
            html = html.Replace("\xd8\xaa", "\u062a");
            html = html.Replace("\xd8\xab", "\u062b");
            html = html.Replace("\xd8\xac", "\u062c");
            html = html.Replace("\xd8\xad", "\u062d");
            html = html.Replace("\xd8\xae", "\u062e");
            html = html.Replace("\xd8\xaf", "\u062f");
            html = html.Replace("\xd8\xb0", "\u0630");
            html = html.Replace("\xd8\xb1", "\u0631");
            html = html.Replace("\xd8\xb2", "\u0632");
            html = html.Replace("\xd8\xb3", "\u0633");
            html = html.Replace("\xd8\xb4", "\u0634");
            html = html.Replace("\xd8\xb5", "\u0635");
            html = html.Replace("\xd8\xb6", "\u0636");
            html = html.Replace("\xd8\xb7", "\u0637");
            html = html.Replace("\xd8\xb8", "\u0638");
            html = html.Replace("\xd8\xb9", "\u0639");
            html = html.Replace("\xd8\xba", "\u063a");
            html = html.Replace("\xd8\xbb", "\u063b");
            html = html.Replace("\xd8\xbc", "\u063c");
            html = html.Replace("\xd8\xbd", "\u063d");
            html = html.Replace("\xd8\xbe", "\u063e");
            html = html.Replace("\xd8\xbf", "\u063f");
            html = html.Replace("\xd9\x80", "\u0640");
            html = html.Replace("\xd9\x81", "\u0641");
            html = html.Replace("\xd9\x82", "\u0642");
            html = html.Replace("\xd9\x83", "\u0643");
            html = html.Replace("\xd9\x84", "\u0644");
            html = html.Replace("\xd9\x85", "\u0645");
            html = html.Replace("\xd9\x86", "\u0646");
            html = html.Replace("\xd9\x87", "\u0647");
            html = html.Replace("\xd9\x88", "\u0648");
            html = html.Replace("\xd9\x89", "\u0649");
            html = html.Replace("\xd9\x8a", "\u064a");
            html = html.Replace("\xd9\x8b", "\u064b");
            html = html.Replace("\xd9\x8c", "\u064c");
            html = html.Replace("\xd9\x8d", "\u064d");
            html = html.Replace("\xd9\x8e", "\u064e");
            html = html.Replace("\xd9\x8f", "\u064f");

            return html;
        }

        public static List<string> GetTags(string html, List<string> tagTypes)
        {
            int pos = 0;
            int posEnd = 0;
            int posEnd1 = 0;
            int posEnd2 = 0;
            int ixSel = -1;

            List<string> tagsIn = new List<string>();
            List<string> tagsOut = new List<string>();

            foreach (string tagType in tagTypes)
            {
                tagsIn.Add("<" + tagType);
                tagsOut.Add("</" + tagType + ">");
            }

            List<string> stringlist = new List<string>();

            pos = html.Length;
            for (int i = 0; i < tagTypes.Count; i++)
            {
                string tagIn = tagsIn[i];
                int newpos = html.IndexOf(tagIn, posEnd, StringComparison.OrdinalIgnoreCase);
                if (newpos == -1) continue;
                if (newpos < pos)
                {
                    pos = newpos;
                    ixSel = i;
                }
            }

            while (pos != html.Length)
            {
                string tagIn = tagsIn[ixSel];
                string tagOut = tagsOut[ixSel];

                // int posm = html.IndexOf(">", pos) + 1;
                int posm = pos+1;

                if (posm == 0) break;

                posEnd1 = html.IndexOf(tagOut, posm, StringComparison.OrdinalIgnoreCase);
                posEnd2 = html.IndexOf(tagIn, posm, StringComparison.OrdinalIgnoreCase);

                if (posEnd1 == -1) posEnd1 = posEnd2;
                if (posEnd2 == -1) posEnd2 = posEnd1;

                if (posEnd1 > posEnd2)
                    posEnd = posEnd2;
                else
                    posEnd = posEnd1;

                if (posEnd == -1) return stringlist;

                stringlist.Add(html.Substring(posm, posEnd - posm));

                pos = html.Length;
                for (int i = 0; i < tagTypes.Count; i++)
                {
                    tagIn = tagsIn[i];
                    int newpos = html.IndexOf(tagIn, posEnd, StringComparison.OrdinalIgnoreCase);
                    if (newpos == -1) continue;
                    if (newpos < pos)
                    {
                        pos = newpos;
                        ixSel = i;
                    }
                }
            }

            return stringlist;
        }

        /// <summary>
        /// Returns a list of string contained into the specified tag
        /// </summary>
        /// <param name="html">the string to analyze</param>
        /// <param name="tagType">The name of the tag</param>
        /// <returns>The list of strings</returns>
        public static List<string> GetTags(string html, string tagType)
        {
            int pos = 0;
            int posEnd = 0;
            int posEnd1 = 0;
            int posEnd2 = 0;
            string tagIn = "<" + tagType;
            string tagOut = "</" + tagType + ">";

            List<string> stringlist = new List<string>();

            while ((pos = html.IndexOf(tagIn, posEnd, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                int posm = html.IndexOf(">", pos) + 1;

                if (posm == 0) break;

                posEnd1 = html.IndexOf(tagOut, posm, StringComparison.OrdinalIgnoreCase);
                posEnd2 = html.IndexOf(tagIn, posm, StringComparison.OrdinalIgnoreCase);

                if (posEnd1 == -1) posEnd1 = posEnd2;
                if (posEnd2 == -1) posEnd2 = posEnd1;

                if (posEnd1 > posEnd2)
                    posEnd = posEnd2;
                else
                    posEnd = posEnd1;

                if (posEnd == -1) return stringlist;

                stringlist.Add(html.Substring(posm, posEnd - posm));
            }

            return stringlist;
        }

        public static List<string> GetFullTags(string html, string tagType)
        {
            int pos = 0;
            int posEnd = 0;
            int posEnd1 = 0;
            int posEnd2 = 0;
            string tagIn = "<" + tagType;
            string tagOut = "</" + tagType + ">";

            List<string> stringlist = new List<string>();

            while ((pos = html.IndexOf(tagIn, posEnd, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                int posm = pos;

                if (posm == -1) break;

                posEnd1 = html.IndexOf(tagOut, posm, StringComparison.OrdinalIgnoreCase) + tagOut.Length;
                posEnd2 = html.IndexOf(tagIn, posm + tagIn.Length, StringComparison.OrdinalIgnoreCase);

                if (posEnd1 == -1) posEnd1 = posEnd2;
                if (posEnd2 == -1) posEnd2 = posEnd1;

                if (posEnd1 > posEnd2)
                    posEnd = posEnd2;
                else
                    posEnd = posEnd1;

                if (posEnd == -1) return stringlist;

                stringlist.Add(html.Substring(posm, posEnd - posm));
            }

            return stringlist;
        }

        public static List<string> GetTags2(string html, string tagType)
        {
            int pos = 0;
            int posEnd = 0;
            string tagIn = "<" + tagType;

            List<string> stringlist = new List<string>();

            while ((pos = html.IndexOf(tagIn, posEnd, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                pos = html.IndexOf(">", pos) + 1;

                posEnd = html.IndexOf(tagIn, pos, StringComparison.OrdinalIgnoreCase);

                if (posEnd == -1)
                {
                    posEnd = html.Length;
                }

                stringlist.Add(html.Substring(pos, posEnd - pos));
            }

            return stringlist;
        }

        public static string GetTag(string html, string tagType)
        {
            return GetTag(html, tagType, 0);
        }

        public static string GetTag(string html, string tagType, int nTag)
        {
            int pos = 0;
            int posEnd = 0;
            string tagIn = "<" + tagType;
            string tagOut = "</" + tagType + ">";

            string str = "";

            for (int i = 0; i < nTag; i++)
            {
                posEnd = html.IndexOf(tagIn, posEnd, StringComparison.OrdinalIgnoreCase) + 3;

                if (posEnd == -1) return str;
            }

            if ((pos = html.IndexOf(tagIn, posEnd, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                pos = html.IndexOf(">", pos) + 1;

                posEnd = html.IndexOf(tagOut, pos, StringComparison.OrdinalIgnoreCase);

                if (posEnd == -1) return "";

                str = html.Substring(pos, posEnd - pos);
            }

            return str;
        }

        /// <summary>
        /// Remove the string from the source string, returning what precedes and what is successive
        /// </summary>
        /// <param name="str"></param>
        /// <param name="cut"></param>
        /// <returns></returns>
        public static string Cut(string str, string cut)
        {
            int pos = 0;
            while ((pos = str.IndexOf(cut, pos, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                str = str.Substring(0, pos) + str.Substring(pos + cut.Length);
            }
            return str;
        }

        /// <summary>
        /// Returns the string preceding and containing the cut string
        /// </summary>
        /// <param name="str">source string</param>
        /// <param name="cut">cut string</param>
        /// <returns>what remains</returns>
        public static string CutAfter(string str, string cut)
        {
            int pos = 0;
            if ((pos = str.IndexOf(cut, pos, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                str = str.Substring(0, pos);
            }
            return str;
        }

        /// <summary>
        /// Returns the string after and containing the cut string
        /// </summary>
        /// <param name="str">source string</param>
        /// <param name="cut">cut string</param>
        /// <returns>what remains</returns>
        public static string CutBefore(string str, string cut)
        {
            int pos = 0;
            if ((pos = str.IndexOf(cut, pos, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                str = str.Substring(pos);
            }
            return str;
        }

        public static string CutField(string str, string tagType)
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
                    int open = outstr.IndexOf("<", epos + 1);
                    int close = outstr.IndexOf(">", epos);

                    if ((open < close) && (open != -1))
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

        public static string GetFirstFloatInString(string str)
        {
            int ix = 0;
            int ixs, ixe;
            for (; ix < str.Length; ix++)
                if (char.IsDigit(str[ix])) break;

            ixs = ix;

            for (; ix < str.Length; ix++)
            {
                if (str[ix] == '.') continue;
                if (!char.IsDigit(str[ix])) break;
            }

            ixe = ix;

            if (ixs == ixe) return "";

            return str.Substring(ixs, ixe - ixs);
        }

        public static string GetNumberAfter(string str, string l1)
        {
            if (str == null)
                return "-1";
            try
            {
                int i0 = str.IndexOf(l1, StringComparison.OrdinalIgnoreCase);
                if (i0 == -1) return "";
                int i1 = i0 + l1.Length;
                int ix = i1 + 1;
                for (; ix < str.Length; ix++)
                {
                    if (char.IsDigit(str[ix])) continue;
                    if (str[ix] == '.') continue;
                    break;
                }
                int i2 = ix;

                if (i2 > str.Length)
                    str = "-1";
                else
                    str = str.Substring(i1, i2 - i1);
            }
            catch
            {
                str = "-1";
            }

            return str;
        }

        public static string GetHexAfter(string str, string l1)
        {
            str = str.ToLower();
            int i0 = str.IndexOf(l1, StringComparison.OrdinalIgnoreCase);
            if (i0 == -1) return "";
            int i1 = i0 + l1.Length;
            int ix = i1 + 1;
            for (; ix < str.Length; ix++)
            {
                if (char.IsDigit(str[ix])) continue;
                if ((char.IsLetter(str[ix])) && (str[ix] < 'g')) continue;
                break;
            }
            int i2 = ix;
            return str.Substring(i1, i2 - i1);
        }

        public static string GetNumberFromStart(string str)
        {
            int ix = 0;
            for (; ix < str.Length; ix++)
            {
                if (char.IsDigit(str[ix])) continue;
                if (str[ix] == ',') continue;
                break;
            }
            int i2 = ix;
            return str.Substring(0, i2).Replace(",", "");
        }

        public static string GetFirstNumberInString(string str)
        {
            int ix = 0;
            int ixs, ixe;
            for (; ix < str.Length; ix++)
                if (char.IsDigit(str[ix])) break;

            ixs = ix;

            for (; ix < str.Length; ix++)
                if (!char.IsDigit(str[ix])) break;

            ixe = ix;

            if (ixs == ixe) return "";

            return str.Substring(ixs, ixe-ixs);
        }

        public static string GetField(string str, string l1, string l2)
        {
            int i0 = str.IndexOf(l1, StringComparison.OrdinalIgnoreCase);
            if (i0 == -1) return "";
            int i1 = i0 + l1.Length;
            int i2 = str.IndexOf(l2, i1, StringComparison.OrdinalIgnoreCase);
            if (i2 == -1) return "";
            return str.Substring(i1, i2 - i1);
        }

        public static string GetFieldRev(string str, string l1, string l2)
        {
            int i2 = str.IndexOf(l2, StringComparison.OrdinalIgnoreCase);
            if (i2 == -1) return "";
            int i1 = str.LastIndexOf(l1, i2, StringComparison.OrdinalIgnoreCase);
            if (i1 == -1) return "";
            i1 += l1.Length;
            string s = str.Substring(i1, i2 - i1);
            return s;
        }

        public static string GetFieldNC(string str, string l1, string l2)
        {
            int i0 = str.IndexOf(l1, StringComparison.OrdinalIgnoreCase);
            if (i0 == -1) return "";
            int i1 = i0 + l1.Length;
            int i2 = str.IndexOf(l2, i1, StringComparison.OrdinalIgnoreCase);
            if (i2 == -1) return "";
            return str.Substring(i1, i2 - i1);
        }

        public static string GetField(string str, string l1, string l2, string defstr)
        {
            int i0 = str.IndexOf(l1);
            if (i0 == -1) return defstr;
            int i1 = i0 + l1.Length;
            int i2 = str.IndexOf(l2, i1);
            return str.Substring(i1, i2 - i1);
        }

        public static string GetField(string str, string l1, string l2, ref int ix)
        {
            if ((ix < 0) || (ix > str.Length)) return "";
            int i0 = str.IndexOf(l1, ix, StringComparison.OrdinalIgnoreCase);
            if (i0 == -1) return "";
            int i1 = i0 + l1.Length;
            int i2 = str.IndexOf(l2, i1, StringComparison.OrdinalIgnoreCase);
            ix = i2 + l2.Length;
            return str.Substring(i1, i2 - i1);
        }

        public static List<string> GetFields(string html, string tagIn, string tagOut)
        {
            int pos = 0;
            int posEnd = -1;

            List<string> stringlist = new List<string>();

            if (html == "") return stringlist;

            while ((pos = html.IndexOf(tagIn, posEnd + 1, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                posEnd = html.IndexOf(tagOut, pos, StringComparison.OrdinalIgnoreCase);

                if (posEnd == -1) return stringlist;

                stringlist.Add(html.Substring(pos, posEnd - pos));
            }

            return stringlist;
        }

        public static List<string> GetFieldsCut(string html, string tagIn, string tagOut)
        {
            int pos = 0;
            int posEnd = -1;

            List<string> stringlist = new List<string>();

            if (html == "") return stringlist;

            while ((pos = html.IndexOf(tagIn, posEnd + 1, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                posEnd = html.IndexOf(tagOut, pos, StringComparison.OrdinalIgnoreCase);

                if (posEnd == -1) return stringlist;

                stringlist.Add(html.Substring(pos + tagIn.Length, posEnd - pos - tagIn.Length));
            }

            return stringlist;
        }

        public static string CleanTags(string html)
        {
            string outstr = "";

            int pos = 0;
            int posEnd = 0;
            string tagIn = "<";
            string tagOut = ">";

            if (html == "") return outstr;

            while ((pos = html.IndexOf(tagIn, posEnd)) != -1)
            {
                outstr += html.Substring(posEnd, pos - posEnd);

                posEnd = html.IndexOf(tagOut, pos);

                if (posEnd == -1) return outstr;

                posEnd = posEnd + tagOut.Length;
            }

            if (posEnd == 0) outstr = html;

            outstr = outstr.Replace("\r\n", "");
            outstr = outstr.Replace("&nbsp;", " ");
            return outstr;
        }

        public static string CleanTagsWithRest(string html)
        {
            string outstr = "";

            int pos = 0;
            int posEnd = 0;
            string tagIn = "<";
            string tagOut = ">";

            if (html == "") return outstr;

            while ((pos = html.IndexOf(tagIn, posEnd)) != -1)
            {
                outstr += html.Substring(posEnd, pos - posEnd);

                posEnd = html.IndexOf(tagOut, pos);

                if (posEnd == -1) return outstr;

                posEnd = posEnd + tagOut.Length;
            }

            if (posEnd == 0) outstr = html;

            if (posEnd < html.Length - 1)
            {
                outstr += html.Substring(posEnd, html.Length - posEnd);
            }

            outstr = outstr.Replace("\r\n", "");
            outstr = outstr.Replace("&nbsp;", " ");
            return outstr;
        }

        internal static string GetFieldInTags(string str, string item)
        {
            int i0 = str.IndexOf(item, StringComparison.OrdinalIgnoreCase);
            if (i0 == -1) return "";
            i0 = str.IndexOf(">", i0, StringComparison.OrdinalIgnoreCase);
            int i1 = i0 + 1; // ">".Length
            int i2 = str.IndexOf("<", i1, StringComparison.OrdinalIgnoreCase);
            if (i2 == -1) return "";
            return str.Substring(i1, i2 - i1);
        }

        public static string ReplaceNumbOutsideTags(string str, string l1, string l2)
        {
            int iS = 0;
            int iE = str.IndexOf(l1);

            if (iE == -1) iE = str.Length;

            while (iS != -1)
            {

                int iNi = str.IndexOfAny("0123456789".ToCharArray(), iS, iE-iS);
                int lenStr = str.Length;

                while (iNi != -1)
                {
                    int iNe = iNi+1;

                    while ((iNe < lenStr) && char.IsDigit(str[iNe])) 
                    { 
                        iNe++; 
                    };

                    str = str.Substring(0, iNi) + "%" + str.Substring(iNe);

                    if (iE > str.Length) iE = str.Length;

                    iNi = str.IndexOfAny("0123456789".ToCharArray(), iS, iE - iS);
                }

                iS = str.IndexOf(l2, iE);
                if (iS != -1)
                {
                    iE = str.IndexOf(l1, iS);
                    if (iE == -1) iE = str.Length;
                }
            }

            return str;
        }

        public static string ConvertUnicodes_Text(string str)
        {
            int ix = 0;

            while ((ix = str.IndexOf("\\u", ix)) != -1)
            {
                string s = str.Substring(ix - 10, 30);
                string hex = str.Substring(ix + 2, 4);
                int n = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                if (n >= 128)
                    str = str.Replace("\\u" + hex, unicodes[n - 128].ToString());
                else
                    str = str.Replace("\\u" + hex, "");
                ix++;
            }

            return str;
        }

        public static string ConvertUnicodes_MoreText(string str)
        {
            str = str.Replace("&#39;", "'");
            return str;
        }

        public static string ConvertHTML_Text(string str)
        {
            str = str.Replace("&#256;", "A");
            str = str.Replace("&#257;", "a");
            str = str.Replace("&#258;", "A");
            str = str.Replace("&#259;", "a");
            str = str.Replace("&#260;", "A");
            str = str.Replace("&#261;", "a");
            str = str.Replace("&#262;", "C");
            str = str.Replace("&#263;", "c");
            str = str.Replace("&#264;", "C");
            str = str.Replace("&#265;", "c");
            str = str.Replace("&#268;", "C");
            str = str.Replace("&#269;", "c");
            str = str.Replace("&#270;", "D");
            str = str.Replace("&#271;", "d");
            str = str.Replace("&#272;", "Ð");
            str = str.Replace("&#273;", "d");
            str = str.Replace("&#274;", "E");
            str = str.Replace("&#275;", "e");
            str = str.Replace("&#280;", "E");
            str = str.Replace("&#281;", "e");
            str = str.Replace("&#282;", "E");
            str = str.Replace("&#283;", "e");
            str = str.Replace("&#284;", "G");
            str = str.Replace("&#285;", "g");
            str = str.Replace("&#286;", "G");
            str = str.Replace("&#287;", "g");
            str = str.Replace("&#290;", "G");
            str = str.Replace("&#291;", "g");
            str = str.Replace("&#292;", "H");
            str = str.Replace("&#293;", "h");
            str = str.Replace("&#298;", "I");
            str = str.Replace("&#299;", "i");
            str = str.Replace("&#304;", "I");
            str = str.Replace("&#305;", "i");
            str = str.Replace("&#308;", "J");
            str = str.Replace("&#309;", "j");
            str = str.Replace("&#310;", "K");
            str = str.Replace("&#311;", "k");
            str = str.Replace("&#313;", "L");
            str = str.Replace("&#314;", "l");
            str = str.Replace("&#315;", "L");
            str = str.Replace("&#316;", "l");
            str = str.Replace("&#317;", "L");
            str = str.Replace("&#318;", "l");
            str = str.Replace("&#321;", "L");
            str = str.Replace("&#322;", "l");
            str = str.Replace("&#323;", "N");
            str = str.Replace("&#324;", "n");
            str = str.Replace("&#325;", "N");
            str = str.Replace("&#326;", "n");
            str = str.Replace("&#327;", "N");
            str = str.Replace("&#328;", "n");
            str = str.Replace("&#336;", "O");
            str = str.Replace("&#337;", "o");
            str = str.Replace("&#340;", "R");
            str = str.Replace("&#341;", "r");
            str = str.Replace("&#342;", "R");
            str = str.Replace("&#343;", "r");
            str = str.Replace("&#344;", "R");
            str = str.Replace("&#345;", "r");
            str = str.Replace("&#346;", "S");
            str = str.Replace("&#347;", "s");
            str = str.Replace("&#348;", "S");
            str = str.Replace("&#349;", "s");
            str = str.Replace("&#350;", "S");
            str = str.Replace("&#351;", "s");
            str = str.Replace("&#352;", "Š");
            str = str.Replace("&#353;", "š");
            str = str.Replace("&#354;", "T");
            str = str.Replace("&#355;", "t");
            str = str.Replace("&#356;", "T");
            str = str.Replace("&#357;", "t");
            str = str.Replace("&#362;", "U");
            str = str.Replace("&#363;", "u");
            str = str.Replace("&#364;", "U");
            str = str.Replace("&#365;", "u");
            str = str.Replace("&#366;", "U");
            str = str.Replace("&#367;", "u");
            str = str.Replace("&#368;", "U");
            str = str.Replace("&#369;", "u");
            str = str.Replace("&#376;", "Ÿ");
            str = str.Replace("&#377;", "Z");
            str = str.Replace("&#378;", "z");
            str = str.Replace("&#379;", "Z");
            str = str.Replace("&#380;", "z");
            str = str.Replace("&#381;", "Ž");
            str = str.Replace("&#382;", "ž");
            str = str.Replace("&AElig;", "Æ");
            str = str.Replace("&Aacute;", "Á");
            str = str.Replace("&Acirc;", "Â");
            str = str.Replace("&Agrave;", "À");
            str = str.Replace("&Aring;", "Å");
            str = str.Replace("&Atilde;", "Ã");
            str = str.Replace("&Auml;", "Ä");
            str = str.Replace("&Ccedil;", "Ç");
            str = str.Replace("&ETH;", "Ð");
            str = str.Replace("&Eacute;", "É");
            str = str.Replace("&Ecirc;", "Ê");
            str = str.Replace("&Egrave;", "È");
            str = str.Replace("&Euml;", "Ë");
            str = str.Replace("&Iacute;", "Í");
            str = str.Replace("&Icirc;", "Î");
            str = str.Replace("&Igrave;", "Ì");
            str = str.Replace("&Iuml;", "Ï");
            str = str.Replace("&Ntilde;", "Ñ");
            str = str.Replace("&OElig;", "Œ");
            str = str.Replace("&Oacute;", "Ó");
            str = str.Replace("&Ocirc;", "Ô");
            str = str.Replace("&Ograve;", "Ò");
            str = str.Replace("&Oslash;", "Ø");
            str = str.Replace("&Otilde;", "Õ");
            str = str.Replace("&Ouml;", "Ö");
            str = str.Replace("&THORN;", "Þ");
            str = str.Replace("&Uacute;", "Ú");
            str = str.Replace("&Ucirc;", "Û");
            str = str.Replace("&Ugrave;", "Ù");
            str = str.Replace("&Uuml;", "Ü");
            str = str.Replace("&Yacute;", "Ý");
            str = str.Replace("&aacute;", "á");
            str = str.Replace("&acirc;", "â");
            str = str.Replace("&aelig;", "æ");
            str = str.Replace("&agrave;", "à");
            str = str.Replace("&aring;", "å");
            str = str.Replace("&atilde;", "ã");
            str = str.Replace("&auml;", "ä");
            str = str.Replace("&ccedil;", "ç");
            str = str.Replace("&eacute;", "é");
            str = str.Replace("&ecirc;", "ê");
            str = str.Replace("&egrave;", "è");
            str = str.Replace("&eth;", "ð");
            str = str.Replace("&euml;", "ë");
            str = str.Replace("&iacute;", "í");
            str = str.Replace("&icirc;", "î");
            str = str.Replace("&iexcl;", "¡");
            str = str.Replace("&igrave;", "ì");
            str = str.Replace("&iquest;", "¿");
            str = str.Replace("&iuml;", "ï");
            str = str.Replace("&middot;", "·");
            str = str.Replace("&ntilde;", "ñ");
            str = str.Replace("&oacute;", "ó");
            str = str.Replace("&ocirc;", "ô");
            str = str.Replace("&oelig;", "œ");
            str = str.Replace("&ograve;", "ò");
            str = str.Replace("&ordf;", "ª");
            str = str.Replace("&ordm;", "º");
            str = str.Replace("&oslash;", "ø");
            str = str.Replace("&otilde;", "õ");
            str = str.Replace("&ouml;", "ö");
            str = str.Replace("&quot;", "'");
            str = str.Replace("&szlig;", "ß");
            str = str.Replace("&scaron;", "š");
            str = str.Replace("&thorn;", "þ");
            str = str.Replace("&uacute;", "ú");
            str = str.Replace("&ucirc;", "û");
            str = str.Replace("&ugrave;", "ù");
            str = str.Replace("&uml;", "ö");
            str = str.Replace("&uuml;", "ü");
            str = str.Replace("&yacute;", "ý");
            str = str.Replace("&yuml;", "ÿ");

            str = str.Replace("&brvbar;", "");
            str = str.Replace("&macr;", "");
            
            str = str.Replace("&scout_mode=1", "");

            while (str.IndexOf('&') != -1)
            {
                int ix = str.IndexOf('&');
                int ixf = str.IndexOf(';', ix + 1);
                string ss = str.Substring(ix, ixf - ix + 1);
                string ss_sub = ss[1].ToString();
                str = str.Replace(ss, ss_sub);
            }
            return str;
        }

        public static string CleanAllCharsOusideSet(string str, string set)
        {
            string strout = "";
            for (int i= 0; i<str.Length; i++)
            {
                char c = str[i];

                if (set.IndexOf(c) != -1)
                    strout += c;
            }

            return strout;
        }

        public static string RemoveTag(string str_in)
        {
            string str = str_in;
            str = str.Replace("&middot;", "·");
            str = str.Replace("&ordf;", "ª");
            str = str.Replace("&ordm;", "º");
            str = str.Replace("&brvbar;", "");
            str = str.Replace("&macr;", "");
            str = str.Replace("&amp;", "&");
            str = str.Replace("&gt;", ">");
            str = str.Replace("&lt;", "<");
            return str;
        }

        internal static string CleanFlashVars(string training)
        {
            training = training.Replace("%22%2C%22", ";");
            training = training.Replace("%22%3A", "=");
            training = training.Replace("%2C%22", ";");
            training = training.Replace("%5B%22", "'");
            training = training.Replace("%22%5D", "'");
            return training;
        }

        public static string GetTagContainingText(string page, string txt)
        {
            int inTag = page.IndexOf(txt);
            int sttTag = page.LastIndexOf("<span", 0, inTag, StringComparison.OrdinalIgnoreCase);
            int endTag = page.IndexOf("/span>", inTag, StringComparison.OrdinalIgnoreCase);
            return page.Substring(sttTag, endTag - sttTag);
        }

        internal static List<int> FindPlayersID(string str)
        {
            List<string> toks = HTML_Parser.GetFieldsCut(str, "<a href=showprofile.php?playerid=", ">");
            List<int> ids = new List<int>();

            foreach (string tok in toks)
            {
                try
                {
                    ids.Add(int.Parse(tok));
                }
                catch (Exception e)
                {
                }
            }

            return ids;
        }

        public static Dictionary<string, string> CreateDictionary(string row, char sep)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            string[] items = row.Split(sep);

            foreach (string item in items)
            {
                string itemc = item.Replace("<", "").Replace(">", "");
                string[] vals = itemc.Split('=');
                if (vals.Length < 2) continue;
                string key = vals[0].Trim();
                string value = itemc.Substring(key.Length+1);
                if (!dict.ContainsKey(key))
                    dict.Add(key, value);
                else
                    dict[key] += ";" + value;
            }

            return dict;
        }

        public static Dictionary<string, string> String2Dictionary(string strDictionary, char split = '=')
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            string[] items = strDictionary.Split(';');

            foreach (string item in items)
            {
                string[] vals = item.Split(split);
                if (vals.Length < 2) continue;
                string key = vals[0].Trim();
                if (key == "") continue;
                string value = vals[1].Trim();
                if (!dict.ContainsKey(key))
                    dict.Add(key, value);
            }

            return dict;
        }

        public static string Dictionary2String(Dictionary<string, string> Dictionary)
        {
            string strDictionary = "";

            foreach (string key in Dictionary.Keys)
            {
                strDictionary += key + "=" + Dictionary[key] + ";";
            }

            return strDictionary;
        }

        /// <summary>
        /// Returns all the numbers in the string between the given tags. Multiple numbers 
        /// are returned as just one occurrence.
        /// </summary>
        /// <param name="html">string to explore</param>
        /// <param name="tagIn">start of the characters sequence that identify the number</param>
        /// <param name="tagOut">end of the sequence</param>
        /// <returns>List of the integers</returns>
        public static List<int> GetNumbersBetween(string html, string tagIn, string tagOut)
        {
            List<int> numberList = new List<int>();

            int pos = 0;
            int posEnd = 0;
            string tempString; 

            while ((pos = html.IndexOf(tagIn, posEnd)) != -1)
            {
                posEnd = html.IndexOf(tagOut, pos);

                tempString = html.Substring(pos + tagIn.Length, posEnd - pos - tagIn.Length);

                if (posEnd == -1) return numberList;

                int outNum;
                if (int.TryParse(tempString, out outNum))
                {
                    if (!numberList.Contains(outNum))
                        numberList.Add(outNum);
                }

                posEnd = posEnd + tagOut.Length;
            }

            return numberList;
        }

        /// <summary>
        /// Split the source string in many strings using the token as splitter
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="token">Token string</param>
        /// <returns>Array of string returned</returns>
        public static string[] Split(string source, string token)
        {
            if (source == null)
                return null;

            List<string> strs = new List<string>();

            int pos = 0;
            int endPos = 0;
            while ((endPos = source.IndexOf(token, pos, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                strs.Add(source.Substring(pos, endPos - pos));
                pos = endPos + token.Length;
            }

            if (pos < source.Length)
            {
                strs.Add(source.Substring(pos, source.Length - pos));
            }

            return strs.ToArray();
        }        
    }
}
