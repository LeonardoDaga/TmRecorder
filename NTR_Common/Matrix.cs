using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NTR_Common
{
    public class Matrix
    {
        internal int Rows { get; set; }
        public int Cols;
        public double[] mat;

        public Matrix(int iRows, int iCols)         // Matrix Class constructor
        {
            Rows = iRows;
            Cols = iCols;
            mat = new double[Rows * Cols];
        }

        /// <summary>
        /// Creates matrix from 2-d double array.
        /// </summary>
        /// <param name="values"></param>
        public Matrix(double[,] values)
        {
            if (values == null)
            {
                Rows = 0;
                Cols = 0;
            }

            Rows = (int)values.GetLength(0);
            Cols = (int)values.GetLength(1);

            mat = new double[Rows * Cols];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    this[i, j] = values[i, j];
                }
            }
        }

        static public implicit operator Matrix(double[,] values)
        {
            return new Matrix(values);
        }

        public double this[int iRow, int iCol]      // Access this matrix as a 2D array
        {
            get { return mat[iRow * Cols + iCol]; }
            set { mat[iRow * Cols + iCol] = value; }
        }

        public string ToString(IFormatProvider iFP)                         // Function returns matrix as a string file
        {
            string s = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    s += String.Format(iFP, "{0:G16}", this[i, j]);
                    if (j < Cols - 1)
                    {
                        s += "\t";
                    }
                }

                if (i < Rows - 1)
                {
                    s += ";...\n";
                }
                else
                {
                    s += ";\n";
                }
            }
            return s;
        }

        public static Matrix Parse(string s, IFormatProvider iFP)    // Function parses the matrix from string file
        {
            string[] rows = Regex.Split(s, ";");
            string[] nums = rows[0].Split('\t');
            Matrix matrix = new Matrix(rows.Length, nums.Length);
            try
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    nums = rows[i].Split('\t');
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (nums[j].Length > 0)
                        {
                            matrix[i, j] = double.Parse(nums[j], iFP);
                        }
                    }
                }
            }
            catch (FormatException) { throw new MException("Wrong input format!"); }
            return matrix;
        }
    }

    internal class MException : Exception
    {
        public MException(string Message)
            : base(Message)
        { }
    }
}
