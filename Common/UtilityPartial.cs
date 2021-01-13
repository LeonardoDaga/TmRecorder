using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public partial class Tm_Training
    {
        public static UInt64 OldTdsGiocatoriToTrCode2(TrainingDataSet.GiocatoriRow gr)
        {
            UInt64 res = 0;

            try
            {
                UInt64 fact = 1;
                for (int i = 1; i <= 14; i++, fact <<= 3)
                {
                    decimal tr = (decimal)gr[i];
                    UInt64 val = (UInt64)((int)tr + 2);
                    res = res + val * fact;
                }
            }
            catch (Exception)
            {
            }

            return res;
        }

        public static int[] OldTdsGiocatoriToTrCode(TrainingDataSet.GiocatoriRow gr)
        {
            int[] res = new int[2];
            res[0] = 0;
            res[1] = 0;

            try
            {
                int fact;
                for (int i = 1; i <= 14; i++)
                {
                    fact = 1 << (2 * i - 2);
                    if ((decimal)gr[i] == 1) res[0] += fact;
                    if ((decimal)gr[i] == -1) res[1] += fact;
                    fact = 1 << (2 * i - 1);
                    if ((decimal)gr[i] == 2) res[0] += fact;
                    if ((decimal)gr[i] == -2) res[1] += fact;
                }
            }
            catch (Exception ex)
            {
            }

            return res;
        }

        public static int[] OldTdsPortieriToTrCode(TrainingDataSet.PortieriRow pr)
        {
            int[] res = new int[2];
            res[0] = 0;
            res[1] = 0;

            int fact;
            for (int i = 1; i <= 11; i++)
            {
                fact = 1 << (2 * i - 2);
                if ((decimal)pr[i] == 1) res[0] += fact;
                if ((decimal)pr[i] == -1) res[1] += fact;
                fact = 1 << (2 * i - 1);
                if ((decimal)pr[i] == 2) res[0] += fact;
                if ((decimal)pr[i] == -2) res[1] += fact;
            }

            return res;
        }

        public static UInt64 OldTdsPortieriToTrCode2(TrainingDataSet.PortieriRow gr)
        {
            UInt64 res = 0;

            try
            {
                UInt64 fact = 1;
                for (int i = 1; i <= 11; i++, fact <<= 3)
                {
                    decimal tr = (decimal)gr[i];
                    UInt64 val = (UInt64)((int)tr + 2);
                    res = res + val * fact;
                }
            }
            catch (Exception)
            {
            }

            return res;
        }



    }
}
