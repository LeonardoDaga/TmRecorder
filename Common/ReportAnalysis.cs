namespace Common
{
    public class HiddenData
    {
        public decimal Agg, Blo, Lea, Phy, Pro, Tac, Abi, Tec;

        public HiddenData()
        {
            Agg = Blo = Lea = Phy = Pro = Tac = Tec = 0;
        }

        public static HiddenData operator +(HiddenData hd1, HiddenData hd2)
        {
            HiddenData sumHd = new HiddenData();
            sumHd.Agg = hd1.Agg + hd2.Agg;
            sumHd.Abi = hd1.Abi + hd2.Abi;
            sumHd.Blo = hd1.Blo + hd2.Blo;
            sumHd.Lea = hd1.Lea + hd2.Lea;
            sumHd.Phy = hd1.Phy + hd2.Phy;
            sumHd.Pro = hd1.Pro + hd2.Pro;
            sumHd.Tac = hd1.Tac + hd2.Tac;
            sumHd.Tec = hd1.Tec + hd2.Tec;
            return sumHd;
        }

        public static HiddenData operator *(HiddenData f, HiddenData hd)
        {
            HiddenData proHd = new HiddenData();
            proHd.Agg = f.Agg * hd.Agg;
            proHd.Abi = f.Abi * hd.Abi;
            proHd.Blo = f.Blo * hd.Blo;
            proHd.Lea = f.Lea * hd.Lea;
            proHd.Phy = f.Phy * hd.Phy;
            proHd.Pro = f.Pro * hd.Pro;
            proHd.Tac = f.Tac * hd.Tac;
            proHd.Tec = f.Tec * hd.Tec;
            return proHd;
        }
    }

    partial class ReportAnalysis
    {
        public bool Changed = false;

        public void CopyReportAnalysis(ReportAnalysis from)
        {
            this.Clear();
            foreach (ReportAnalysis.AggressivityRow row in from.Aggressivity)
            {
                ReportAnalysis.AggressivityRow arow = this.Aggressivity.NewAggressivityRow();
                arow.ItemArray = row.ItemArray;
                this.Aggressivity.AddAggressivityRow(arow);
            }
            foreach (ReportAnalysis.AbilityRow row in from.Ability)
            {
                ReportAnalysis.AbilityRow arow = this.Ability.NewAbilityRow();
                arow.ItemArray = row.ItemArray;
                this.Ability.AddAbilityRow(arow);
            }
            foreach (ReportAnalysis.BloomingRow row in from.Blooming)
            {
                ReportAnalysis.BloomingRow arow = this.Blooming.NewBloomingRow();
                arow.ItemArray = row.ItemArray;
                this.Blooming.AddBloomingRow(arow);
            }
            foreach (ReportAnalysis.LeadershipRow row in from.Leadership)
            {
                ReportAnalysis.LeadershipRow arow = this.Leadership.NewLeadershipRow();
                arow.ItemArray = row.ItemArray;
                this.Leadership.AddLeadershipRow(arow);
            }
            foreach (ReportAnalysis.PhysiqueRow row in from.Physique)
            {
                ReportAnalysis.PhysiqueRow arow = this.Physique.NewPhysiqueRow();
                arow.ItemArray = row.ItemArray;
                this.Physique.AddPhysiqueRow(arow);
            }
            foreach (ReportAnalysis.ProfessionalityRow row in from.Professionality)
            {
                ReportAnalysis.ProfessionalityRow arow = this.Professionality.NewProfessionalityRow();
                arow.ItemArray = row.ItemArray;
                this.Professionality.AddProfessionalityRow(arow);
            }
            foreach (ReportAnalysis.StaminaRow row in from.Stamina)
            {
                ReportAnalysis.StaminaRow arow = this.Stamina.NewStaminaRow();
                arow.ItemArray = row.ItemArray;
                this.Stamina.AddStaminaRow(arow);
            }
            foreach (ReportAnalysis.TacticsRow row in from.Tactics)
            {
                ReportAnalysis.TacticsRow arow = this.Tactics.NewTacticsRow();
                arow.ItemArray = row.ItemArray;
                this.Tactics.AddTacticsRow(arow);
            }
            foreach (ReportAnalysis.TechnicsRow row in from.Technics)
            {
                ReportAnalysis.TechnicsRow arow = this.Technics.NewTechnicsRow();
                arow.ItemArray = row.ItemArray;
                this.Technics.AddTechnicsRow(arow);
            }
        }

        internal HiddenData GetHiddenData(string review)
        {
            HiddenData hd = new HiddenData();

            foreach (ReportAnalysis.AggressivityRow row in this.Aggressivity)
            {
                if (row.IsReviewNull()) break;

                if (review.Contains(row.Review))
                {
                    hd.Agg += row.Vote;
                    break;
                }
            }
            foreach (ReportAnalysis.AbilityRow row in this.Ability)
            {
                if (row.IsReviewNull()) break;

                if (review.Contains(row.Review))
                {
                    hd.Abi += row.Vote;
                    break;
                }
            }
            foreach (ReportAnalysis.BloomingRow row in this.Blooming)
            {
                if (row.IsReviewNull()) break;

                if (review.Contains(row.Review))
                {
                    hd.Blo += row.Vote;
                    break;
                }
            }
            foreach (ReportAnalysis.LeadershipRow row in this.Leadership)
            {
                if (row.IsReviewNull()) break;

                if (review.Contains(row.Review))
                {
                    hd.Lea += row.Vote;
                    break;
                }
            }
            foreach (ReportAnalysis.PhysiqueRow row in this.Physique)
            {
                if (row.IsReviewNull()) break;

                if (review.Contains(row.Review))
                {
                    hd.Phy += row.Vote;
                    break;
                }
            }
            foreach (ReportAnalysis.ProfessionalityRow row in this.Professionality)
            {
                if (row.IsReviewNull()) break;

                if (review.Contains(row.Review))
                {
                    hd.Pro += row.Vote;
                    break;
                }
            }
            // first, get the review with vote 0, if any
            string tech0 = "";
            foreach (ReportAnalysis.TechnicsRow row in this.Technics)
            {
                if (row.IsReviewNull()) break;

                if (row.Vote == 0)
                {
                    tech0 = row.Review;
                    break;
                }
            }
            if (tech0 != "")
            {
                if (review.Contains(tech0))
                {
                    int ix0 = review.IndexOf(tech0) + tech0.Length;
                    int ixMin = review.Length;
                    int voteToAdd = 0;
                    foreach (ReportAnalysis.TechnicsRow row in this.Technics)
                    {
                        int ix = review.IndexOf(row.Review, ix0);
                        if (ix == -1) continue;
                        if (ix < ixMin) voteToAdd = row.Vote;
                    }
                    hd.Tec += voteToAdd;
                }
            }
            else
            {
                // Simply look for the given technical review
                foreach (ReportAnalysis.TechnicsRow row in this.Technics)
                {
                    if (row.IsReviewNull()) break;

                    if (review.Contains(row.Review))
                    {
                        hd.Tec += row.Vote;
                        break;
                    }
                }
            }
            foreach (ReportAnalysis.TacticsRow row in this.Tactics)
            {
                if (row.IsReviewNull()) break;

                if (review.Contains(row.Review))
                {
                    hd.Tac += row.Vote;
                    break;
                }
            }

            return hd;
        }
    }
}
