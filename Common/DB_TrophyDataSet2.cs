using System;
using System.IO;
namespace Common {


    partial class DB_TrophyDataSet2
    {
        public FileInfo fiSource;

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
