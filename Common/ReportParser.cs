using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public class ReportParser
    {
        public Dictionary<string, Dictionary<int, string>> Dict = new Dictionary<string, Dictionary<int, string>>();

        public enum Keys
        {
            BloomStatus = 1,
            DevStatus = 2,
            Speciality = 3,
        }

        public ReportParser(string filename)
        {
            FileInfo fi = new FileInfo(filename);
            if (!fi.Exists)
            {
                MessageBox.Show("The Scout Report is not available in your language, or the file " + filename + " has been deleted");
                return;
            }

            StreamReader sr = new StreamReader(fi.FullName);
            string text = sr.ReadToEnd();
            sr.Close();

            string[] strs = text.Replace("\r", "").Split('\n');
            string category = "";
            Dictionary<int, string> Category = null; 

            foreach (string str in strs)
            {
                string[] items = str.Split('\t');

                // Initial list
                if (items[0] == "List")
                {
                    category = items[1];
                    Category = new Dictionary<int, string>();

                    continue;
                }

                // End of the list
                if (items[0] == "")
                {
                    if (Category.Count > 0)
                    {
                        Dict.Add(category, Category);
                    }

                    continue;
                }

                if (items[0] == "Vote") continue;

                int key = int.Parse(items[0]);

                Category.Add(key, items[2]);
            }
        }

        internal int find(string dictionary, string item)
        {
            return find(dictionary, item, 0);
        }

        internal int find(string dictionary, string item, int defaultVal)
        {
            for (int i = 1; i <= Dict[dictionary].Count; i++)
            {
                if (item.Contains(Dict[dictionary][i]))
                {
                    return i;
                }
            }

            return defaultVal;
        }
    }
}
