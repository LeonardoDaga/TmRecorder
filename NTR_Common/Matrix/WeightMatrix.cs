using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NTR_Common
{
    public class WeightMatrix: Matrix
    {
        public WeightMatrix(int iRows, int iCols) : base(iRows, iCols)
        { }

        public WeightMatrix(double[,] values) : base(values)
        { }

        public new static WeightMatrix Parse(string s, IFormatProvider iFP)    // Function parses the matrix from string file
        {
            string[] rows = Regex.Split(s, ";");
            string[] nums = rows[0].Split('\t');
            WeightMatrix matrix = new WeightMatrix(rows.Length, nums.Length);
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

        public new WeightMatrix Transpose()
        {
            base.Transpose();
            return this;
        }

        public string ToExcelString(string[] rows, 
            string[] cols)                         // Function returns matrix as a string file
        {
            string s = "Skill";

            for (int j = 0; j < cols.Length; j++)
            {
                s += String.Format("\t{0}", cols[j]);
            }

            s += "\n";

            for (int i = 0; i < rows.Length; i++)
            {
                s += String.Format("{0}", rows[i]);

                for (int j = 0; j < cols.Length; j++)
                {
                    s += String.Format("\t{0:G5}", this[j, i]);
                }

                if (i < Rows - 1)
                {
                    s += "\n";
                }
            }
            return s;
        }

        static public implicit operator WeightMatrix(double[,] values)
        {
            return new WeightMatrix(values);
        }

        public static WeightMatrix ParseExcel(string paste)
        {
            paste = paste.Replace(";\n", "\n");
            paste = paste.TrimEnd('\n');

            string[] rows = Regex.Split(paste, "\n");
            string[] nums = rows[0].Split('\t');

            WeightMatrix matrix = new WeightMatrix(rows.Length-1, nums.Length-1);
            try
            {
                for (int i = 1; i < rows.Length; i++)
                {
                    nums = rows[i].Split('\t');

                    for (int j = 1; j < nums.Length; j++)
                    {
                        if (nums[j].Length > 0)
                        {
                            matrix[i-1, j-1] = double.Parse(nums[j]);
                        }
                    }
                }
            }
            catch (Exception)
            {
                if (!paste.Contains("Skill\tDC") && !paste.Contains("Str\t"))
                {
                    MessageBox.Show("The text to paste must contain the row and column header.");
                }
            }

            return matrix;
        }
    }
}