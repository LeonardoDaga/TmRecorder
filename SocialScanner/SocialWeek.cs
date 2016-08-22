using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialScanner
{
    class SsWeek
    {
        public static readonly DateTime ssDay0 = new DateTime(2016, 6, 4, new System.Globalization.GregorianCalendar());

        public static int ThisWeek()
        {
            return (DateTime.Today - ssDay0).Days / 7;
        }
    }
}
