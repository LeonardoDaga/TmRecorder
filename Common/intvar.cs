using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class basevar
    {
        public string description;

        public basevar()
        { }
    }

    public class intvar: basevar, IComparable<intvar>
    {
        public int actual;
        public int prev = int.MinValue;

        public intvar()
        { }

        public intvar(int actualVal, int prevVal)
        {
            actual = actualVal;
            prev = prevVal;
        }

        public intvar(int actualVal)
        {
            actual = actualVal;
        }

        public override string ToString()
        {
            if (prev != int.MinValue)
                return actual.ToString() + "|" + prev.ToString();
            else
                return actual.ToString();
        }

        public int CompareTo(intvar other)
        {
            return actual.CompareTo(other.actual);
        }
    }
}
