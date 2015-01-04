using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace Common
{
    public class SettingsBase: Hashtable
    {
        public FileInfo fi = null;

        public string SettingsFilename
        {
            get { return fi.FullName; }
            set { fi = new FileInfo(value); }
        }

        public void Save()
        {
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            fi.Delete();
            StreamWriter sw = File.CreateText(fi.FullName);

            foreach (DictionaryEntry item in this)
            {
                sw.WriteLine("{0}({1})={2}", item.Key, item.Value.GetType().ToString(), item.Value);
            }

            sw.Close();
        }

        public void Load()
        {
            try
            {
                if ((fi == null) || (!fi.Exists)) return;

                StreamReader sr = File.OpenText(fi.FullName);

                this.Clear();

                string s = sr.ReadToEnd();
                string[] lines = s.Split('\n');

                foreach (string line in lines)
                {
                    int i0 = line.IndexOf("(");
                    int i1 = line.IndexOf(")");
                    if ((i0 == -1) || (i1 == -1)) continue;
                    string key = line.Substring(0, i0);
                    string type = line.Substring(i0 + 1, i1 - i0 - 1);
                    string value = line.Substring(i1 + 2).TrimEnd('\r');

                    switch (type)
                    {
                        case "System.String": this.Add(key, value); break;
                        case "System.Boolean": this.Add(key, bool.Parse(value)); break;
                        case "System.Int32": this.Add(key, int.Parse(value)); break;
                        case "System.UInt32": this.Add(key, UInt32.Parse(value)); break;
                        case "System.Single": this.Add(key, float.Parse(value)); break;
                        case "System.Decimal": this.Add(key, decimal.Parse(value)); break;
                        case "System.Double": this.Add(key, double.Parse(value)); break;
                        case "System.Int64": this.Add(key, Int64.Parse(value)); break;
                        case "System.UInt64": this.Add(key, UInt64.Parse(value)); break;
                    }
                }

                sr.Close();
            }
            catch (Exception)
            {
                return;
            }
        }

        public void Def(object key, object o)
        {
            if (!this.Contains(key))
                Add(key, o);
        }

        /// <summary>
        /// Clone the input settings object
        /// </summary>
        /// <param name="input"></param>
        static public SettingsBase Clone(SettingsBase input)
        {
            return (SettingsBase)input.MemberwiseClone();
        }
    }
}
