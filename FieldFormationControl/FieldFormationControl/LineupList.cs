using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common;

namespace FieldFormationControl
{
    public partial class LineupList : UserControl
    {
        public delegate void SelectedFormationChangedHandler(Formation newForm, Formation oldForm);
        public event SelectedFormationChangedHandler SelectedFormationChanged;

        #region Properties

        #endregion

        LineupListItem[] LineupListItems = new LineupListItem[16];
        FormationDS formDS = new FormationDS();
        int ixLastSelectedItem = 0;

        public LineupList()
        {
            InitializeComponent();

            LineupListItems[0] = lup01;
            LineupListItems[1] = lup02;
            LineupListItems[2] = lup03;
            LineupListItems[3] = lup04;
            LineupListItems[4] = lup05;
            LineupListItems[5] = lup06;
            LineupListItems[6] = lup07;
            LineupListItems[7] = lup08;
            LineupListItems[8] = lup09;
            LineupListItems[9] = lup10;
            LineupListItems[10] = lup11;
            LineupListItems[11] = lup12;
            LineupListItems[12] = lup13;
            LineupListItems[13] = lup14;
            LineupListItems[14] = lup15;
            LineupListItems[15] = lup16;

            foreach (LineupListItem lli in LineupListItems)
            {
                lli.ItemSelected += new EventHandler(lli_ItemSelected);
            }
        }

        void lli_ItemSelected(object sender, EventArgs e)
        {
            LineupListItems[ixLastSelectedItem].IsSelected = false;

            LineupListItem lliSelected = (LineupListItem)sender;
            for (int i=0; i<LineupListItems.Length; i++)
            {
                if (lliSelected == LineupListItems[i])
                {
                    LineupListItems[i].IsSelected = true;
                    if (SelectedFormationChanged != null)
                        SelectedFormationChanged(LineupListItems[i].formation,
                            LineupListItems[ixLastSelectedItem].formation);
                    ixLastSelectedItem = i;
                }
                else
                {
                    LineupListItems[i].IsSelected = false;
                }
            }
        }

        public void SetCurrentFormation(Formation form)
        {
            LineupListItems[ixLastSelectedItem].formation = form;
        }

        public Formation GetCurrentFormation()
        {
            return LineupListItems[ixLastSelectedItem].formation;
        }

        public void Save(string filename)
        {
            formDS.Clear();

            for (int ix = 0; ix < LineupListItems.Length; ix++)
            {
                formDS.Add(LineupListItems[ix].formation, ix);
            }

            formDS.SelectedFormation = ixLastSelectedItem;

            formDS.WriteXml(filename);
        }

        public new void Load(string filename)
        {
            formDS.ReadXml(filename);

            for (int ix = 0; ix < LineupListItems.Length; ix++)
            {
                LineupListItems[ix].formation = formDS.Get(ix);
                LineupListItems[ix].IsSelected = false;
            }

            ixLastSelectedItem = formDS.SelectedFormation;
            LineupListItems[ixLastSelectedItem].IsSelected = true;
        }
    }
}
