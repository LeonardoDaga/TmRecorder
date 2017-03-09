using System.Data;
namespace Common
{


    partial class FormationDS
    {
        public int SelectedFormation
        {
            get
            {
                if (this.Formation.Count == 0)
                {
                    FormationRow fr = Formation.NewFormationRow();
                    fr.SelectedForm = 0;
                    this.Formation.AddFormationRow(fr);
                }

                return Formation[0].SelectedForm;
            }
            set
            {
                if (this.Formation.Count == 0)
                {
                    FormationRow fr = Formation.NewFormationRow();
                    this.Formation.AddFormationRow(fr);
                }

                Formation[0].SelectedForm = value;
            }
        }

        partial class FormationDataTable
        {
        }

        public void Add(Formation formation, int formID)
        {
            for (int i = 0; i < formation.players.Length; i++)
            {
                PlayerRow pr = Player.NewPlayerRow();

                formation.players[i].CopyTo(pr);
                pr.PosID = i;
                pr.formID = formID;

                Player.AddPlayerRow(pr);
            }
        }

        public Formation Get(int formID)
        {
            Formation formation = new Formation();
            DataRow[] prs = Player.Select("formID = " + formID.ToString());

            for (int i = 0; i < prs.Length; i++)
            {
                PlayerRow pl = (PlayerRow)prs[i];
                formation.players[pl.PosID].CopyFrom(pl);
            }

            return formation;
        }
    }
}
