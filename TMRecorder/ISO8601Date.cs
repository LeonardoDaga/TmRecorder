using System;
using System.Collections.Generic;
using System.Text;

namespace TMRecorder
{
    public class ISO8601Date
    {
        // Static Method to check Leap Year
        public static bool IsLeapYear(int yyyy)
        {

            if ((yyyy % 4 == 0 && yyyy % 100 != 0) || (yyyy % 400 == 0))
                return true;
            else
                return false;
        }


        // Static Method to return ISO WeekNumber (1-53) for a given year
        public static int WeekNumber(DateTime dt)
        {

            // Set Year
            int yyyy = dt.Year;

            // Set Month
            int mm = dt.Month;

            // Set Day
            int dd = dt.Day;

            // Declare other required variables
            int DayOfYearNumber;
            int Jan1WeekDay;
            int WeekNumber = 0, WeekDay;


            int i, j, k, l, m, n;
            int[] Mnth = new int[12] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };

            int YearNumber;


            // Set DayofYear Number for yyyy mm dd
            DayOfYearNumber = dd + Mnth[mm - 1];

            // Increase of Dayof Year Number by 1, if year is leapyear and month is february
            if ((IsLeapYear(yyyy) == true) && (mm == 2))
                DayOfYearNumber += 1;

            // Find the Jan1WeekDay for year 
            i = (yyyy - 1) % 100;
            j = (yyyy - 1) - i;
            k = i + i / 4;
            Jan1WeekDay = 1 + (((((j / 100) % 4) * 5) + k) % 7);

            // Calcuate the WeekDay for the given date
            l = DayOfYearNumber + (Jan1WeekDay - 1);
            WeekDay = 1 + ((l - 1) % 7);

            // Find if the date falls in YearNumber set WeekNumber to 52 or 53
            if ((DayOfYearNumber <= (8 - Jan1WeekDay)) && (Jan1WeekDay > 4))
            {
                YearNumber = yyyy - 1;
                if ((Jan1WeekDay == 5) || ((Jan1WeekDay == 6) && (Jan1WeekDay > 4)))
                    WeekNumber = 53;
                else
                    WeekNumber = 52;
            }
            else
                YearNumber = yyyy;


            // Set WeekNumber to 1 to 53 if date falls in YearNumber
            if (YearNumber == yyyy)
            {
                if (IsLeapYear(yyyy) == true)
                    m = 366;
                else
                    m = 365;
                if ((m - DayOfYearNumber) < (4 - WeekDay))
                {
                    YearNumber = yyyy + 1;
                    WeekNumber = 1;
                }
            }

            if (YearNumber == yyyy)
            {
                n = DayOfYearNumber + (7 - WeekDay) + (Jan1WeekDay - 1);
                WeekNumber = n / 7;
                if (Jan1WeekDay > 4)
                    WeekNumber -= 1;
            }

            return (WeekNumber);
        }


        // Static Method to Calculate WeekDay (Monday=1...Sunday=7)
        public static int WeekDay(DateTime dt)
        {

            // Set Year
            int yyyy = dt.Year;

            // Set Month
            int mm = dt.Month;

            // Set Day
            int dd = dt.Day;

            // Declare other required variables
            int DayOfYearNumber;
            int Jan1WeekDay;
            int WeekDay;


            int i, j, k, l;
            int[] Mnth = new int[12] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };


            // Set DayofYear Number for yyyy mm dd
            DayOfYearNumber = dd + Mnth[mm - 1];

            // Increase of Dayof Year Number by 1, if year is leapyear and month is february
            if ((IsLeapYear(yyyy) == true) && (mm == 2))
                DayOfYearNumber += 1;

            // Find the Jan1WeekDay for year 
            i = (yyyy - 1) % 100;
            j = (yyyy - 1) - i;
            k = i + i / 4;
            Jan1WeekDay = 1 + (((((j / 100) % 4) * 5) + k) % 7);

            // Calcuate the WeekDay for the given date
            l = DayOfYearNumber + (Jan1WeekDay - 1);
            WeekDay = 1 + ((l - 1) % 7);

            return WeekDay;
        }


        // Static Method to Display date in ISO Format (Year - WeekNumber - WeekDay)
        public static string DisplayISODate(DateTime dt)
        {
            string str;
            int year, weekday, weeknumber;

            year = dt.Year;
            weeknumber = WeekNumber(dt);
            weekday = WeekDay(dt);

            str = year.ToString("d0") + "-" + weeknumber.ToString("d0")
                                      + "-" + weekday.ToString("d0");
            return str;
        }
    }
}
