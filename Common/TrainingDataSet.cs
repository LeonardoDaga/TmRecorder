using System;
using System.Collections.Generic;

namespace Common
{
    public class ListTrainingDataSet : List<TrainingDataSet>
    {
        public bool sorted = false;

        internal TrainingDataSet LastTraining()
        {
            if (!sorted)
            {
                this.Sort(CompareTrainingByDate);
                sorted = true;
            }

            return this[0];
        }

        public new void Add(TrainingDataSet tds)
        {
            base.Add(tds);
            sorted = false;
        }

        public new void Insert(int index, TrainingDataSet tds)
        {
            base.Insert(index, tds);
            sorted = false;
        }

        public static int CompareTrainingByDate(TrainingDataSet tds1, TrainingDataSet tds2)
        {
            if (tds1.WeekNoData[0].Date == tds2.WeekNoData[0].Date)
                return 0;
            else if (tds1.WeekNoData[0].Date > tds2.WeekNoData[0].Date)
                return -1;
            else
                return 1;
        }
    }

    partial class TrainingDataSet
    {
        partial class WeekNoDataDataTable
        {
        }

        partial class GiocatoriDataTable
        {
        }

        public partial class TrainersRow
        {
        }

        public partial class PortieriRow
        {
            public string ToExcelString()
            {
                string row = "";

                for (int i = 0; i < this.ItemArray.Length; i++)
                {
                    if (i == 12)
                        row += "-\t-\t-\t" + this[i].ToString() + "\t";
                    else if (i == 0)
                        row += this[i].ToString() + "\t";
                    else if (i == 13)
                        row += this[i].ToString();
                    else
                    {
                        try
                        {
                            switch ((int)(decimal)this[i])
                            {
                                case 1: row += (0.1).ToString() + "\t"; break;
                                case 2: row += "1\t"; break;
                                case -2: row += "-1\t"; break;
                                case -1: row += (-0.1).ToString() + "\t"; break;
                                default: row += "0\t"; break;
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                return row;
            }

            public bool ParseExcelString(string[] items)
            {
                for (int ix = 1; ix < 14; ix++)
                {
                    int i = ix - 1;
                    if (i == 12)
                        this[i] = float.Parse(items[16]);
                    else
                    {
                        decimal val = decimal.Parse(items[ix]);
                        if (i == 0)
                            this[i] = val;
                        else if (val == 0.1M)
                            this[i] = 1;
                        else if (val == -0.1M)
                            this[i] = -1;
                        else if (val == 1)
                            this[i] = 2;
                        else if (val == -1)
                            this[i] = -2;
                        else this[i] = 0;
                    }
                }

                return true;
            }

            public float DeltaSkillPos()
            {
                float res = 0;

                for (int ix = 1; ix < 12; ix++)
                {
                    int val = (int)((decimal)this[ix]);

                    if (val == 1)
                        res += 0.1f;
                    else if (val == 2)
                        res += 1.0f;
                }

                return res;
            }

            public float DeltaSkillNeg()
            {
                float res = 0;

                for (int ix = 1; ix < 12; ix++)
                {
                    int val = (int)((decimal)this[ix]);

                    if (val == -1)
                        res -= 0.1f;
                    else if (val == -2)
                        res -= 1.0f;
                }

                return res;
            }
        }

        public partial class GiocatoriRow
        {
            public string ToExcelString()
            {
                string row = "";

                for (int i = 0; i < this.ItemArray.Length; i++)
                {
                    if (i == 16)
                        row += this[i].ToString();
                    else if (i == 0)
                        row += this[i].ToString() + "\t";
                    else if (i == 15)
                        row += this[i].ToString() + "\t";
                    else
                    {
                        try
                        {
                            switch ((int)(decimal)this[i])
                            {
                                case 1: row += (0.1).ToString() + "\t"; break;
                                case 2: row += "1\t"; break;
                                case -2: row += "-1\t"; break;
                                case -1: row += (-0.1).ToString() + "\t"; break;
                                default: row += "0\t"; break;
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                return row;
            }


            public bool ParseExcelString(string[] items)
            {
                for (int ix = 1; ix < 17; ix++)
                {
                    int i = ix - 1;
                    if (i == 15)
                        this[i] = float.Parse(items[ix]);
                    else
                    {
                        decimal val = decimal.Parse(items[ix]);
                        if (i == 0)
                            this[i] = val;
                        else if (val == 0.1M)
                            this[i] = 1;
                        else if (val == -0.1M)
                            this[i] = -1;
                        else if (val == 1)
                            this[i] = 2;
                        else if (val == -1)
                            this[i] = -2;
                        else this[i] = 0;
                    }
                }

                return true;
            }

            public float DeltaSkillPos()
            {
                float res = 0;

                for (int ix = 1; ix < 15; ix++)
                {
                    int val = (int)((decimal)this[ix]);

                    if (val == 1)
                        res += 0.1f;
                    else if (val == 2)
                        res += 1.0f;
                }

                return res;
            }

            public float DeltaSkillNeg()
            {
                float res = 0;

                for (int ix = 1; ix < 15; ix++)
                {
                    int val = (int)((decimal)this[ix]);

                    if (val == -1)
                        res -= 0.1f;
                    else if (val == -2)
                        res -= 1.0f;
                }

                return res;
            }
        }


        public DateTime Date
        {
            set
            {
                WeekNoDataRow row = null;

                // Create Row if needed
                if (WeekNoData.Rows.Count == 0)
                {
                    row = (WeekNoDataRow)WeekNoData.NewRow();
                    WeekNoData.Rows.Add(row);
                }
                else
                {
                    row = (WeekNoDataRow)WeekNoData.Rows[0];
                }

                row.Date = value;
            }

            get
            {
                // Create Row if needed
                if (WeekNoData.Rows.Count == 0)
                {
                    return DateTime.Now;
                }

                WeekNoDataRow row = (WeekNoDataRow)WeekNoData.Rows[0];
                return row.Date;
            }
        }

        public bool ProgramUpdated
        {
            set
            {
                WeekNoDataRow row = null;

                // Create Row if needed
                if (WeekNoData.Rows.Count == 0)
                {
                    row = (WeekNoDataRow)WeekNoData.NewRow();
                    WeekNoData.Rows.Add(row);
                }
                else
                {
                    row = (WeekNoDataRow)WeekNoData.Rows[0];
                }

                row.ProgramUpdated = value;
            }

            get
            {
                // Create Row if needed
                if (WeekNoData.Rows.Count == 0)
                {
                    return false;
                }

                WeekNoDataRow row = (WeekNoDataRow)WeekNoData.Rows[0];
                if (row.IsProgramUpdatedNull())
                    return false;

                return row.ProgramUpdated;
            }
        }
    }
}
