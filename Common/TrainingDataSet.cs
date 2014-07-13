using System;
namespace Common
{


    partial class TrainingDataSet
    {
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
                        row += "-\t-\t-\t" + this[i].ToString()+ "\t";
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
    }
}
