using System.Windows.Forms;
namespace NationListEditor {


    partial class DataSet1
    {
        partial class NationNamesDataTable
        {
            protected override void OnTableNewRow(System.Data.DataTableNewRowEventArgs e)
            {
                base.OnTableNewRow(e);
            }
        }

        internal string GetTabbedList()
        {
            string text = "";
            foreach (NationNamesRow nnr in NationNames)
            {
                text += nnr.Name + "\t" + nnr.Abbreviation + "\n";
            }

            text = text.TrimEnd('\n');

            return text;
        }

        internal void PutTabbedList(string tabtext)
        {
            string[] lines = tabtext.Split('\n');

            foreach (string line in lines)
            {
                NationNamesRow nnr = this.NationNames.NewNationNamesRow();

                nnr.Name = line.Split('\t')[0];
                
                string abbr = line.Split('\t')[1];
                abbr = abbr.TrimEnd('\r');

                if (abbr == "") continue;
                NationNamesRow nnrf = NationNames.FindByAbbreviation(abbr);
                if (nnrf == null)
                {
                    nnr.Abbreviation = abbr;
                    NationNames.AddNationNamesRow(nnr);
                }
                else
                {
                    if (MessageBox.Show("Sostitute previous definition of abbreviation " + abbr,
                        "Paste from Excel format",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        nnr.Abbreviation = abbr;
                        NationNames.AddNationNamesRow(nnr);
                    }
                }
            }
        }
    }
}
