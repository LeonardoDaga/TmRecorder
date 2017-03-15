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
using NTR_Common;
//using Common;

namespace NTR_Controls
{
    public partial class AeroDataGrid : DataGridView
    {
        OrderCommand lastOrderCommand;
        BindingSource dataBindingSource = new BindingSource();
        public Type DataType;

        ImgContainer imgContainer = new ImgContainer();

        object _dataCollection = null;
        public object DataCollection
        {
            get { return _dataCollection; }
            set
            {
                _dataCollection = value;
                dataBindingSource.DataSource = _dataCollection;
                this.DataSource = dataBindingSource;
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
            if (collectionToReorder != null)
            {
                var orderedDataCollection = collectionToReorder.Order(dgvColumn.DataPropertyName, lastOrderCommand.isAscending);
                dataBindingSource.DataSource = orderedDataCollection;
            }
            else
            {
                List<T> listToReorder = _dataCollection as List<T>;
                var orderedDataCollection = listToReorder.Order(dgvColumn.DataPropertyName, lastOrderCommand.isAscending);
                dataBindingSource.DataSource = orderedDataCollection;
            }
        }

        public DataGridViewColumn AddColumn(string Title, string Property, int width, AG_Style styles,
            DataGridViewCellStyle dgvCellStyle)
        {
            DefaultCellStyle = dgvCellStyle;
            return AddColumn(Title, Property, width, styles);
        }


        public void AddFpColumn(string skill, DataGridViewCellStyle dgvcsPosCells, int size = 30)
        {
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)this.AddColumn(skill, skill, size, AG_Style.NumDec, dgvcsPosCells);
            dgvc.CellColorStyles = CellColorStyleList.DefaultFpColorStyle();
        }

        public void AddSkColumn(string skill, bool evidenceGain, int size = 25)
        {
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)this.AddColumn(skill, skill, size, AG_Style.NumDec);
            if (evidenceGain)
                dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();
            else
                dgvc.CellColorStyles = CellColorStyleList.NoGainColorStyle();
        }

        public DataGridViewColumn AddColumn(string Title, string Property, int width, AG_Style styles, string description = "")
        {
            DataGridViewColumn dgv = null;
            DataGridViewCellStyle dgvCellStyle = new DataGridViewCellStyle();

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
            else if ((int)(styles & AG_Style.Checkbox) > 0)
            {
                dgv = new DataGridViewCheckBoxColumn();
            }
            else if ((int)(styles & AG_Style.FavPosition) > 0)
            {
                dgv = new TMR_FpColumn();
            }
            else if ((int)(styles & AG_Style.NameInj) > 0)
            {
                dgv = new TMR_NameInjurySqColumn();
            }
            else if ((int)(styles & AG_Style.TextAndImage) > 0)
            {
                dgv = new NTR_TxtAndImgColumn(imgContainer.GetImageList(ImgContainer.ImgListType.Match));
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
            else if ((int)(styles & AG_Style.HiddenSkill) > 0)
            {
                dgv = new NTR_HiddenSkillColumn();
            }
            else if ((int)(styles & AG_Style.MatchResults) > 0)
            {
                dgv = new NTR_MatchPerfColumn();
            }
            else if ((int)(styles & AG_Style.Blooming) > 0)
            {
                dgv = new NTR_BloomColumn();
            }
            else if ((int)(styles & AG_Style.Stars) > 0)
            {
                dgv = new NTR_ImgColumn(imgContainer.GetImageList(ImgContainer.ImgListType.StarsLine));
            }
            else if ((int)(styles & AG_Style.Time_ddmm_hhmm) > 0)
            {
                dgv = new DataGridViewTextBoxColumn();
                dgvCellStyle.NullValue = "-";
                dgvCellStyle.Format = "dd/MM HH:mm";
            }

            dgv.Name = Title;
            dgv.DataPropertyName = Property;
            dgv.Width = width;
            dgv.ToolTipText = description;
            dgv.SortMode = DataGridViewColumnSortMode.Automatic;

            this.Columns.Add(dgv);

            dgv.Frozen = ((int)(styles & AG_Style.Frozen) > 0);

            if ((int)(styles & AG_Style.ResizeAllCells) > 0)
            {
                dgv.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                dgv.Width = width;
                dgv.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            if ((int)(styles & AG_Style.Fill) > 0)
            {
                dgv.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if ((int)(styles & AG_Style.RightJustified) > 0)
                dgvCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var NumStyle = (int)(styles & AG_Style.NF);

            if (NumStyle == (int)AG_Style.N4)
                dgvCellStyle.Format = "N4";
            else if (NumStyle == (int)AG_Style.N3)
                dgvCellStyle.Format = "N3";
            else if (NumStyle == (int)AG_Style.N2)
                dgvCellStyle.Format = "N2";
            else if (NumStyle == (int)AG_Style.N1)
                dgvCellStyle.Format = "N1";
            else if (NumStyle == (int)AG_Style.N0)
                dgvCellStyle.Format = "N0";

            dgv.DefaultCellStyle = dgvCellStyle.Clone();
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
        N1 = 0x0400,
        N0 = 0x0800,
        N2 = 0x0C00,
        N3 = 0x1000,
        N4 = 0x1400,
        NF = 0x1f00,
        MatchType = 0x2000,
        Stars = 0x4000,
        TextAndImage = 0x8000,
        Checkbox = 0x10000,
        Time_ddmm_hhmm = 0x20000,
        HiddenSkill = 0x40000,
        Blooming = 0x80000,
        Fill = 0x100000,
        MatchResults = 0x200000,
        FormatString = 0x400000,
    }
}
