using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DataGridViewCustomColumns;
//using Common;

namespace NTR_Controls
{
    public partial class AeroDataGrid : DataGridView
    {
        OrderCommand lastOrderCommand;
        BindingSource dataBindingSource = new BindingSource();
        public Type DataType;

        object _dataCollection = null;
        public object DataCollection
        {
            get { return _dataCollection; }
            set
            {
                _dataCollection = value;
                this.DataSource = dataBindingSource;
                dataBindingSource.DataSource = _dataCollection;
            }
        }

        //[DllImport("uxtheme", ExactSpelling = true, CharSet = CharSet.Unicode)]
        //public extern static Int32 SetWindowTheme(IntPtr hWnd,
        //              String textSubAppName, String textSubIdList);
        public AeroDataGrid()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            this.CellPainting += AeroDataGrid_CellPainting;
        }

        void AeroDataGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
        }

        //void AeroDataGrid_CellMouseDown(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.RowIndex == -1)
        //        return;
        //    if (e.Button == System.Windows.Forms.MouseButtons.Left)
        //        return;

        //    if (Control.ModifierKeys != Keys.Control)
        //        foreach (DataGridViewRow row in this.SelectedRows)
        //        {
        //            row.Selected = false;
        //        }

        //    this.Rows[e.RowIndex].Selected = true; // !dgPlayersGK.Rows[e.RowIndex].Selected;
        //}

        public void AeroDataGrid_ColumnHeaderMouseClick<T>(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn dgvColumn = Columns[e.ColumnIndex];

            if (lastOrderCommand == null)
                lastOrderCommand = new OrderCommand();

            if (lastOrderCommand.columnOrdered == dgvColumn.DataPropertyName)
                lastOrderCommand.isAscending = !lastOrderCommand.isAscending;
            else
            {
                lastOrderCommand.columnOrdered = dgvColumn.DataPropertyName;
                lastOrderCommand.isAscending = true;
            }

            EnumerableRowCollection<T> collectionToReorder = _dataCollection as EnumerableRowCollection<T>;
            var orderedDataCollection = collectionToReorder.Order(dgvColumn.DataPropertyName, lastOrderCommand.isAscending);
            dataBindingSource.DataSource = orderedDataCollection;
        }

        public DataGridViewColumn AddColumn(string Title, string Property, int width, AG_Style styles,
            DataGridViewCellStyle dgvCellStyle)
        {
            DefaultCellStyle = dgvCellStyle;
            return AddColumn(Title, Property, width, styles);
        }

        public DataGridViewColumn AddColumn(string Title, string Property, int width, AG_Style styles, string description = "")
        {
            DataGridViewColumn dgv = null;

            if ((int)(styles & AG_Style.Numeric) > 0)
            {
                dgv = new DataGridViewTextBoxColumn();
            }
            else if ((int)(styles & AG_Style.Age) > 0)
            {
                dgv = new TMR_AgeColumn();
            }
            else if ((int)(styles & AG_Style.String) > 0)
            {
                dgv = new DataGridViewTextBoxColumn();
            }
            else if ((int)(styles & AG_Style.FavPosition) > 0)
            {
                dgv = new TMR_FpColumn();
            }
            else if ((int)(styles & AG_Style.NameInj) > 0)
            {
                dgv = new TMR_NameInjurySqColumn();
            }
            else if ((int)(styles & AG_Style.Nationality) > 0)
            {
                dgv = new TMR_NationColumn();
            }
            else if ((int)(styles & AG_Style.NumDec) > 0)
            {
                dgv = new TMR_NumDecColumn();
            }
            else if ((int)(styles & AG_Style.FormatString) > 0)
            {
                dgv = new NTR_FormatStringColumn();
            }
            else if ((int)(styles & AG_Style.MatchType) > 0)
            {
                dgv = new TMR_MatchTypeColumn();
            }
            else if ((int)(styles & AG_Style.Stars) > 0)
            {
                dgv = new NTR_ImgColumn(NTR_ImgColumn.ImgType.Rec);
            }

            dgv.Name = Title;
            dgv.DataPropertyName = Property;
            dgv.Width = width;
            dgv.ToolTipText = description;
            dgv.SortMode = DataGridViewColumnSortMode.Automatic;

            this.Columns.Add(dgv);

            dgv.Frozen = ((int)(styles & AG_Style.Frozen) > 0);

            if ((int)(styles & AG_Style.ResizeAllCells) > 0)
                dgv.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if ((int)(styles & AG_Style.RightJustified) > 0)
                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if ((int)(styles & AG_Style.N1) > 0)
                dgv.DefaultCellStyle.Format = "N1";

            if ((int)(styles & AG_Style.N0) > 0)
                dgv.DefaultCellStyle.Format = "N0";

            return dgv;
        }

        public void SetWhen(DateTime when)
        {
            foreach (DataGridViewColumn dgv in this.Columns)
            {
                if (dgv.GetType() == typeof(TMR_AgeColumn))
                {
                    TMR_AgeColumn ageCol = (TMR_AgeColumn)dgv;
                    ageCol.When = when;
                }
            }
        }
    }

    public class OrderCommand
    {
        public string columnOrdered;
        public bool isAscending;
    }

    [Flags]
    public enum AG_Style
    {
        Numeric = 0x01,
        Frozen = 0x02,
        Age = 0x04,
        String = 0x08,
        FavPosition = 0x10,
        NameInj = 0x20,
        ResizeAllCells = 0x40,
        Nationality = 0x80,
        NumDec = 0x100,
        RightJustified = 0x200,
        N1 = 0x400,
        N0 = 0x800,
        FormatString = 0x1000,
        MatchType = 0x2000,
        Stars = 0x4000,
    }
}
