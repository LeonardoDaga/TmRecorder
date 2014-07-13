using System;
using System.Windows.Forms;
namespace TeamFileEditor {


    partial class DB_TrophyDataSet2
    {
        public DateTime Date
        {
            set
            {
                WeekNoDataRow row = null;

                // Create Row if needed
                if (WeekNoData.Rows.Count == 0)
                {
                    row = (WeekNoDataRow)WeekNoData.NewRow();
                    WeekNoData.Rows.Add(row);
                }
                else
                {
                    row = (WeekNoDataRow)WeekNoData.Rows[0];
                }

                row.Date = value;
            }

            get
            {
                // Create Row if needed
                if (WeekNoData.Rows.Count == 0)
                {
                    return DateTime.Now;
                }

                WeekNoDataRow row = (WeekNoDataRow)WeekNoData.Rows[0];
                return row.Date;
            }
        }

        internal string GetPlayerTabbedList()
        {
            string text = "";
            foreach (GiocatoriRow gr in this.Giocatori)
            {
                text += gr.PlayerID + "\t";
                text += gr.Età + "\t";
                text += gr.ASI + "\t";
                text += gr.For + "\t";
                text += gr.Res + "\t";
                text += gr.Vel + "\t";
                text += gr.Mar + "\t";
                text += gr.Con + "\t";
                text += gr.Wor + "\t";
                text += gr.Pos + "\t";
                text += gr.Pas + "\t";
                text += gr.Cro + "\t";
                text += gr.Tec + "\t";
                text += gr.Tes + "\t";
                text += gr.Fin + "\t";
                text += gr.Tir + "\t";
                text += gr.Cal + "\t";
                text += gr.Infortunato + "\t";
                text += gr.Squalificato + "\t";
                text += gr.InFormazione + "\n";
            }

            text = text.TrimEnd('\n');

            return text;
        }

        internal string GetGKTabbedList()
        {
            string text = "";
            foreach (PortieriRow gr in this.Portieri)
            {
                text += gr.PlayerID + "\t";
                text += gr.Età + "\t";
                text += gr.ASI + "\t";
                text += gr.For + "\t";
                text += gr.Res + "\t";
                text += gr.Vel + "\t";
                text += gr.Pre + "\t";
                text += gr.Uno + "\t";
                text += gr.Rif + "\t";
                text += gr.Aer + "\t";
                text += gr.Ele + "\t";
                text += gr.Com + "\t";
                text += gr.Tir + "\t";
                text += gr.Lan + "\t";
                text += gr.Infortunato + "\t";
                text += gr.Squalificato + "\t";
                text += gr.InFormazione + "\n";
            }

            text = text.TrimEnd('\n');

            return text;
        }

        internal void PutPlayersTabbedList(string tabtext)
        {
            string[] lines = tabtext.Split('\n');

            foreach (string line in lines)
            {
                if (line == "") continue;

                GiocatoriRow gr = this.Giocatori.NewGiocatoriRow();

                int id = int.Parse(line.Split('\t')[0]);
                gr.Età = int.Parse(line.Split('\t')[1]);
                gr.ASI = int.Parse(line.Split('\t')[2]);
                gr.For = int.Parse(line.Split('\t')[3]);
                gr.Res = int.Parse(line.Split('\t')[4]);
                gr.Vel = int.Parse(line.Split('\t')[5]);
                gr.Mar = int.Parse(line.Split('\t')[6]);
                gr.Con = int.Parse(line.Split('\t')[7]);
                gr.Wor = int.Parse(line.Split('\t')[8]);
                gr.Pos = int.Parse(line.Split('\t')[9]);
                gr.Pas = int.Parse(line.Split('\t')[10]);
                gr.Cro = int.Parse(line.Split('\t')[11]);
                gr.Tec = int.Parse(line.Split('\t')[12]);
                gr.Tes = int.Parse(line.Split('\t')[13]);
                gr.Fin = int.Parse(line.Split('\t')[14]);
                gr.Tir = int.Parse(line.Split('\t')[15]);
                gr.Cal = int.Parse(line.Split('\t')[16]);
                gr.Infortunato = int.Parse(line.Split('\t')[17]);
                gr.Squalificato = int.Parse(line.Split('\t')[18]);
                gr.InFormazione = bool.Parse(line.Split('\t')[19].TrimEnd('\r'));

                GiocatoriRow grf = Giocatori.FindByPlayerID(id);
                if (grf == null)
                {
                    gr.PlayerID = id;
                    Giocatori.AddGiocatoriRow(gr);
                }
                else
                {
                    if (MessageBox.Show("Sostitute previous definition of id " + id,
                        "Paste from Excel format",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        gr.PlayerID = id;
                        Giocatori.AddGiocatoriRow(gr);
                    }
                }
            }
        }

        internal void PutGKTabbedList(string tabtext)
        {
            string[] lines = tabtext.Split('\n');

            foreach (string line in lines)
            {
                if (line == "") continue;

                PortieriRow gr = this.Portieri.NewPortieriRow();

                int id = int.Parse(line.Split('\t')[0]);
                gr.Età = int.Parse(line.Split('\t')[1]);
                gr.ASI = int.Parse(line.Split('\t')[2]);
                gr.For = int.Parse(line.Split('\t')[3]);
                gr.Res = int.Parse(line.Split('\t')[4]);
                gr.Vel = int.Parse(line.Split('\t')[5]);
                gr.Pre = int.Parse(line.Split('\t')[6]);
                gr.Uno = int.Parse(line.Split('\t')[7]);
                gr.Rif = int.Parse(line.Split('\t')[8]);
                gr.Aer = int.Parse(line.Split('\t')[9]);
                gr.Ele = int.Parse(line.Split('\t')[10]);
                gr.Com = int.Parse(line.Split('\t')[11]);
                gr.Tir = int.Parse(line.Split('\t')[12]);
                gr.Lan = int.Parse(line.Split('\t')[13]);
                gr.Infortunato = int.Parse(line.Split('\t')[14]);
                gr.Squalificato = int.Parse(line.Split('\t')[15]);
                gr.InFormazione = bool.Parse(line.Split('\t')[16].TrimEnd('\r'));

                PortieriRow grf = Portieri.FindByPlayerID(id);
                if (grf == null)
                {
                    gr.PlayerID = id;
                    Portieri.AddPortieriRow(gr);
                }
                else
                {
                    if (MessageBox.Show("Sostitute previous definition of id " + id,
                        "Paste from Excel format",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        gr.PlayerID = id;
                        Portieri.AddPortieriRow(gr);
                    }
                }
            }
        }
    }
}
