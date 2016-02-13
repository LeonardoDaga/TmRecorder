using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Common;

namespace Common
{
    public class WeekHistorical: List<float>
    {
        TmWeek startWeek = new TmWeek();

        public WeekHistorical()
        {
            this.startWeek.absweek = -1;
        }

        public WeekHistorical(TmWeek startWeek)
        {
            this.startWeek = startWeek;
        }

        public WeekHistorical(string fullhistorystring)
        {
            string[] data = fullhistorystring.Split(';');

            int hl = data.Length - 1;

            if (hl < 1)
            {
                startWeek = new TmWeek(-1);
                return;
            }

            startWeek = new TmWeek(data[0]);

            string history = fullhistorystring.Substring(fullhistorystring.IndexOf(';') + 1);

            Add(startWeek, history);
        }


        public float ActualTI
        {
            get 
            {
                if (Count == 0) return 0.0f;
                return this[Count-1]; 
            }
        }

        public TmWeek lastWeek
        {
            get { return startWeek - this.Count + 1; }
        }

        public void Add(DateTime dt, string historical)
        {
            Add(new TmWeek(dt), historical);
        }

        public void Add(TmWeek tw, string historical)
        {
            if (startWeek.absweek == -1)
                startWeek = tw;

            historical = historical.Replace(",", ".");

            string[] data = historical.Split(';');

            int hl = data.Length;

            for (int i = 0; i < hl; i++)
            {
                TmWeek dataTW = tw + (i - hl + 1);
                
                float val = 0;
                if (!float.TryParse(data[i], NumberStyles.Float, CommGlobal.ciUs, out val))
                    val = float.NaN;

                Set(dataTW, val);
            }
        }

        public void Set(DateTime dt, float value)
        {
            Set(new TmWeek(dt), value);
        }

        public void Set(TmWeek tw, float value)
        {
            if (tw.absweek < lastWeek.absweek)
            {
                // Create a collection to insert
                WeekHistorical wh = new WeekHistorical();

                wh.Add(value);
                for (int i = 1; i < lastWeek.absweek - tw.absweek; i++)
                    wh.Add(float.NaN);

                this.InsertRange(0, wh);
            }
            else if (tw.absweek > startWeek.absweek)
            {
                for (int i = 0; i < tw.absweek - startWeek.absweek - 1; i++)
                    this.Add(float.NaN);

                this.Add(value);

                startWeek = tw;
            }
            else
            {
                int ix = tw.absweek - lastWeek.absweek;
                this[ix] = value;
            }
        }

        public override string ToString()
        {
            string rtStr = startWeek.ToString();
            foreach (float val in this)
            {
                if (float.IsNaN(val))
                    rtStr += ";";
                else
                    rtStr += ";" + val.ToString("N0", CommGlobal.ciUs);
            }
            return rtStr;
        }

        public string ToString(string format)
        {
            string rtStr = startWeek.ToString();
            foreach (float val in this)
            {
                rtStr += ";" + val.ToString(format);
            }
            return rtStr;
        }

        public float GetWeekVal(int week)
        {
            if (this.Count == 0)
                return 0f;
            else if (week < lastWeek.absweek)
            {
                if (this.Count > 0)
                    return this[0];
                else
                    return float.NaN;
            }
            else if (week > startWeek.absweek)
                return float.NaN;
            else
                return this[week - lastWeek.absweek];
        }

        public string GenerateHistoryString(int iniWeek, int thisWeek, char separator)
        {
            string str = "";
            for (int i = iniWeek; i <= thisWeek; i++)
            {
                float f = GetWeekVal(i);

                if (float.IsNaN(f))
                    str += separator;
                else
                    str += f.ToString("N2") + separator;
            }
            return str;
        }

        public int FindBloomStart()
        {
            float oldTI = 1000f;

            for (int ix = 0; ix < this.Count; ix++)
            {
                float TI = this[ix];
                if ((TI / oldTI > 3) && (oldTI > 2))
                {
                    return startWeek.absweek + ix;
                }
            }

            return TmWeek.thisWeek().absweek;
        }
    }
}
