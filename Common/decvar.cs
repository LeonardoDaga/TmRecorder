using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class decvar : basevar, IComparable<decvar>
    {
        public decimal actual;
        public decimal prev = decimal.MinValue;
        public double quality;

        public decvar()
        {
            quality = -1;
        }

        public decvar(decimal actualVal, decimal prevVal)
        {
            actual = actualVal;
            prev = prevVal;
            quality = -1;
        }

        public decvar(decimal actualVal, decimal prevVal, double qualityVal)
        {
            actual = actualVal;
            prev = prevVal;
            quality = qualityVal;
        }

        public decvar(decimal actualVal)
        {
            actual = actualVal;
            quality = -1;
        }

        public static decvar operator +(decvar add1, decvar add2)
        {
            if (add1.prev == decimal.MinValue)
                return new decvar(add1.actual + add2.actual, add2.prev);
            else if (add2.prev == decimal.MinValue)
                return new decvar(add1.actual + add2.actual, add1.prev);
            else 
                return new decvar(add1.actual + add2.actual, add1.prev + add2.prev);
        }

        public override string ToString()
        {
            if (prev != decimal.MinValue)
                return actual.ToString() + "|" + prev.ToString();
            else
                return actual.ToString();
        }

        public int CompareTo(decvar other)
        {
            return actual.CompareTo(other.actual);
        }
    }
}
