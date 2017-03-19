using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTR_Common
{
    public class StdSettings : SortedDictionary<string, object>
    {
        private FileInfo fi = null;

        public string SettingsFilename
        {
            get { return fi.FullName; }
            set { fi = new FileInfo(value); }
        }

        public void Delete()
        {
            fi.Delete();
        }

        public bool SettingsFileExists()
        {
            if (fi != null)
                return fi.Exists;
            else
                return false;
        }

        public void Save()
        {
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            fi.Delete();
            StreamWriter sw = File.CreateText(fi.FullName);

            foreach (var item in this)
            {
                string itemType = item.Value.GetType().ToString();

                if (item.Value.GetType() == typeof(Matrix))
                    sw.WriteLine("{0}({1})={2}", item.Key, itemType, ((Matrix)item.Value).ToString(CommGlobal.ciInv));
                else if (item.Value.GetType() == typeof(double))
                    sw.WriteLine("{0}({1})={2}", item.Key, itemType, String.Format(CommGlobal.ciInv, "{0:G16}", item.Value));
                else if (item.Value.GetType() == typeof(float))
                    sw.WriteLine("{0}({1})={2}", item.Key, itemType, string.Format(CommGlobal.ciInv, "{0:G8}", item.Value));
                else if (item.Value.GetType() == typeof(decimal))
                    sw.WriteLine("{0}({1})={2}", item.Key, itemType, string.Format(CommGlobal.ciInv, "{0:G8}", item.Value));
                else
                    sw.WriteLine("{0}({1})={2}", item.Key, itemType, item.Value);
            }

            sw.Close();
        }

        public void Load()
        {
            if ((fi == null) || (!fi.Exists)) return;

            StreamReader sr = File.OpenText(fi.FullName);

            string s = sr.ReadToEnd();
            string[] lines = s.Split('\n');

            string line = "";
            foreach (string row in lines)
            {
                line += row;
                if (row.EndsWith("..."))
                {
                    line = line.TrimEnd(".".ToCharArray());
                    continue;
                }

                int i0 = line.IndexOf("(");
                int i1 = line.IndexOf(")");
                if ((i0 == -1) || (i1 == -1)) continue;
                string key = line.Substring(0, i0);
                string type = line.Substring(i0 + 1, i1 - i0 - 1);
                string value = line.Substring(i1 + 2).TrimEnd('\r');

                switch (type)
                {
                    case "System.String": this.Set(key, value); break;
                    case "System.Boolean": this.Set(key, bool.Parse(value)); break;
                    case "System.Int32": this.Set(key, int.Parse(value)); break;
                    case "System.UInt32": this.Set(key, UInt32.Parse(value)); break;
                    case "System.Decimal": this.Set(key, decimal.Parse(value, CommGlobal.ciInv)); break;
                    case "System.Double": this.Set(key, double.Parse(value, CommGlobal.ciInv)); break;
                    case "System.Int64": this.Set(key, Int64.Parse(value)); break;
                    case "System.UInt64": this.Set(key, UInt64.Parse(value)); break;
                    case "NTR_Common.Matrix": this.Set(key, Matrix.Parse(value, CommGlobal.ciInv)); break;
                    case "NTR_Common.eRatingFunctionType": this.Set(key, Enum.Parse(typeof(eRatingFunctionType), value)); break;
                }

                line = "";
            }

            sr.Close();
        }

        public void Def(string key, object o)
        {
            if (!this.ContainsKey(key))
                Add(key, o);
        }

        public void Set(string key, object o)
        {
            if (!this.ContainsKey(key))
                Add(key, o);
            else
                this[key] = o;
        }

        /// <summary>
        /// Clone the input settings object
        /// </summary>
        /// <param name="input"></param>
        static public StdSettings Clone(StdSettings input)
        {
            return (StdSettings)input.MemberwiseClone();
        }
    }
}
