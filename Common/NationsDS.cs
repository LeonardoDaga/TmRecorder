using System.Windows.Forms;
namespace Common
{


    public partial class NationsDS
    {
        public void SetDefaultValues()
        {
            Clear();

            for (int i = 0; i < nations.GetLength(0); i++)
            {
                NamesRow nnr = this.Names.NewNamesRow();

                nnr.Name = nations[i, 0];
                nnr.Abbreviation = nations[i, 1];

                Names.AddNamesRow(nnr);
            }
        }

        internal string GetTabbedList()
        {
            string text = "";
            foreach (NamesRow nnr in Names)
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
                NamesRow nnr = this.Names.NewNamesRow();

                nnr.Name = line.Split('\t')[0];

                string abbr = line.Split('\t')[1];
                abbr = abbr.TrimEnd('\r');

                if (abbr == "") continue;
                NamesRow nnrf = Names.FindByAbbreviation(abbr);
                if (nnrf == null)
                {
                    nnr.Abbreviation = abbr;
                    Names.AddNamesRow(nnr);
                }
                else
                {
                    if (MessageBox.Show("Sostitute previous definition of abbreviation " + abbr,
                        "Paste from Excel format",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        nnr.Abbreviation = abbr;
                        Names.AddNamesRow(nnr);
                    }
                }
            }
        }

        public string[,] nations = new string[,]
           {{"Afghanistan","af"},
            {"Albania","al"},
            {"Algeria","dz"},
            {"Andorra","ad"},
            {"Angola","ao"},
            {"Argentina","ar"},
            {"Armenia","am"},
            {"Australia","au"},
            {"Austria","at"},
            {"Azerbaijan","az"},
            {"Bahrain","bh"},
            {"Bangladesh","bd"},
            {"Belarus","by"},
            {"Belgium","be"},
            {"Belize","bz"},
            {"Bolivia","bo"},
            {"Bosnia-Herzegovina","ba"},
            {"Botswana","bw"},
            {"Brazil","br"},
            {"Brunei Darussalam","bn"},
            {"Bulgaria","bg"},
            {"Cameroon","cm"},
            {"Canada","ca"},
            {"Chad","td"},
            {"Chile","cl"},
            {"China PR","cn"},
            {"Chinese Taipei","tw"},
            {"Colombia","co"},
            {"Costa Rica","cr"},
            {"Croatia","hr"},
            {"Cuba","cu"},
            {"Cyprus","cy"},
            {"Czech Republic","cz"},
            {"Denmark","dk"},
            {"Dominican Republic","do"},
            {"Ecuador","ec"},
            {"Egypt","eg"},
            {"El Salvador","sv"},
            {"England","en"},
            {"Estonia","ee"},
            {"Faroe Islands","fo"},
            {"Fiji","fj"},
            {"Finland","fi"},
            {"France","fr"},
            {"FYR Macedonia","mk"},
            {"Georgia","ge"},
            {"Germany","de"},
            {"Ghana","gh"},
            {"Greece","gr"},
            {"Guatemala","gt"},
            {"Honduras","hn"},
            {"Hong Kong","hk"},
            {"Hungary","hu"},
            {"Iceland","is"},
            {"India","in"},
            {"Indonesia","id"},
            {"Iran","ir"},
            {"Iraq","iq"},
            {"Ireland","ie"},
            {"Israel","il"},
            {"Italy","it"},
            {"Ivory Coast","ci"},
            {"Jamaica","jm"},
            {"Japan","jp"},
            {"Jordan","jo"},
            {"Kazakhstan","kz"},
            {"Korea Republic","kr"},
            {"Kuwait","kw"},
            {"Latvia","lv"},
            {"Lebanon","lb"},
            {"Libya","ly"},
            {"Lithuania","lt"},
            {"Luxembourg","lu"},
            {"Malaysia","my"},
            {"Malta","mt"},
            {"Mexico","mx"},
            {"Moldova","md"},
            {"Montenegro","me"},
            {"Morocco","ma"},
            {"Nepal","np"},
            {"Netherlands","nl"},
            {"New Zealand","nz"},
            {"Nigeria","ng"},
            {"Northern Ireland","rt"},
            {"Norway","no"},
            {"Oceania","oc"},
            {"Oman","om"},
            {"Pakistan","pk"},
            {"Palestine","so"},
            {"Panama","pa"},
            {"Paraguay","py"},
            {"Peru","pe"},
            {"Philippines","ph"},
            {"Poland","pl"},
            {"Portugal","pt"},
            {"Puerto Rico","pr"},
            {"Qatar","qa"},
            {"Romania","ro"},
            {"Russia","ru"},
            {"San Marino","sm"},
            {"Saudi Arabia","sa"},
            {"Scotland","ct"},
            {"Senegal","sn"},
            {"Serbia","cs"},
            {"Singapore","sg"},
            {"Slovakia","sk"},
            {"Slovenia","si"},
            {"South Africa","za"},
            {"Spain","es"},
            {"Sweden","se"},
            {"Switzerland","he"},
            {"Syria","sy"},
            {"Thailand","th"},
            {"Trinidad and Tobago","tt"},
            {"Tunisia","tn"},
            {"Turkey","tr"},
            {"Ukraine","ua"},
            {"United Arab Emirates","ae"},
            {"Uruguay","uy"},
            {"USA","us"},
            {"Venezuela","ve"},
            {"Vietnam","vn"},
            {"Wales","wa"},
            {"West Indies","vc"}};
    }


}
