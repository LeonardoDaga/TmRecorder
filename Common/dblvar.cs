using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class dblvar : basevar, IComparable<dblvar>
    {
        public double actual;
        public double prev = double.MinValue;
        public double quality;

        public dblvar()
        {
            quality = -1;
        }

        public dblvar(double actualVal, double prevVal)
        {
            actual = actualVal;
            prev = prevVal;
            quality = -1;
        }

        public dblvar(decimal actualVal, decimal prevVal)
        {
            actual = (double)actualVal;
            prev = (double)prevVal;
            quality = -1;
        }

        public dblvar(double actualVal, double prevVal, double qualityVal)
        {
            actual = actualVal;
            prev = prevVal;
            quality = qualityVal;
        }

        public dblvar(decimal actualVal, decimal prevVal, double qualityVal)
        {
            actual = (double)actualVal;
            prev = (double)prevVal;
            quality = qualityVal;
        }

        public dblvar(decimal actualVal, double prevVal, double qualityVal)
        {
            actual = (double)actualVal;
            prev = prevVal;
            quality = qualityVal;
        }

        public dblvar(double actualVal)
        {
            actual = actualVal;
            quality = -1;
        }

        public static dblvar operator +(dblvar add1, dblvar add2)
        {
            if (add1.prev == double.MinValue)
                return new dblvar(add1.actual + add2.actual, add2.prev);
            else if (add2.prev == double.MinValue)
                return new dblvar(add1.actual + add2.actual, add1.prev);
            else 
                return new dblvar(add1.actual + add2.actual, add1.prev + add2.prev);
        }

        public override string ToString()
        {
            if (prev != double.MinValue)
                return actual.ToString() + "|" + prev.ToString();
            else
                return actual.ToString();
        }

        public int CompareTo(dblvar other)
        {
            return actual.CompareTo(other.actual);
        }
    }
}
