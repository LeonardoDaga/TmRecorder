using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using Common;
using System.Net.Mail;
using SendFileTo;
using Languages;

namespace Common {


    partial class ExtraDS
    {
        partial class GiocatoriDataTable
        {
        }
    
        public string[] specs = new string[] { "DC", "DR", "DL", "DMC", "DMR", "DML", "MC", "MR", "ML", "OMC", "OMR", "OML", "FC" };

        public partial class ScoutsDataTable
        {
            public ScoutsRow DefaultRow()
            {
                ScoutsRow sr = this.NewScoutsRow();
                sr.Development = sr.Physical = sr.Psychology = sr.Senior = sr.Tactical =
                    sr.Technical = sr.Youth = 5;
                return sr;
            }

            public int ParseScoutPage(string page)
            {
                int count = 0;

                Clear();

                List<string> rows = HTML_Parser.GetTags(page, "TR");

                foreach (string row in rows)
                {
                    List<string> td = HTML_Parser.GetTags(row, "TD");

                    if ((td.Count < 8) || (td.Count == 11)) continue;

                    for (int i = 1; i < 8; i++)
                    {
                        if (td[i].Contains("star_silver"))
                            td[i] = "19";
                        else if (td[i].Contains("star"))
                            td[i] = "20";
                    }

                    ExtraDS.ScoutsRow sr = NewScoutsRow();
                    sr.Name = td[0].Trim();
                    sr.Senior = byte.Parse(td[1]);
                    sr.Youth = byte.Parse(td[2]);
                    sr.Physical = byte.Parse(td[3]);
                    sr.Tactical = byte.Parse(td[4]);
                    sr.Technical = byte.Parse(td[5]);
                    sr.Development = byte.Parse(td[6]);
                    sr.Psychology = byte.Parse(td[7]);
                    AddScoutsRow(sr);
                    count++;
                }
                return count;
            }
        }

        partial class GiocatoriRow
        {
            public bool isDirty = false;

            public int numReview
            {
                get 
                {
                    if (ScoutVoto == "0")
                        return 0;
                    else
                        return this.ScoutVoto.Split('|').Length; 
                }
            }

            public int[] ScoutVotes
            {
                get 
                {
                    string[] svotes = ScoutVoto.Split('|');
                    int n = svotes.Length;
                    int[] votes = new int[n];

                    for (int i = 0; i < n; i++)
                    {
                        votes[i] = 0;
                        int.TryParse(svotes[i], out votes[i]);
                    }

                    return votes; 
                }
            }

            public string[] ScoutReviews
            {
                get
                {
                    return ScoutGiudizio.Split('|');
                }
            }

            public string[] ScoutNames
            {
                get
                {
                    return ScoutName.Split('|');
                }
            }

            public DateTime[] ScoutDates
            {
                get
                {
                    string[] sdates = ScoutDate.Split('|');
                    int n = sdates.Length;
                    DateTime[] dates = new DateTime[n];

                    for (int i = 0; i < n; i++)
                    {
                        dates[i] = TmWeek.SWDtoDateTime(sdates[i]);
                        if (dates[i] == DateTime.MinValue)
                            dates[i] = DateTime.Now;
                    }

                    return dates;
                }
            }

            public decimal LastTI
            {
                get
                {
                    if (IsTSINull()) return 0M;

                    string[] splTI = TSI.Split(';');

                    try
                    {
                        if (splTI.Length > 1)
                            return decimal.Parse(splTI[splTI.Length - 1], Common.CommGlobal.ciUs);
                        else
                            return 0M;
                    }
                    catch (Exception)
                    {
                        return 0M;
                    }
                }
            }

            public void FillWithScoutReviewList(List<ScoutReview> srList)
            {
                if (srList == null) return;
                this.ScoutGiudizio = "";
                this.ScoutName = "";
                this.ScoutDate = "";
                this.ScoutVoto = "";

                float sumVote = 0.0f;

                foreach (ScoutReview sr in srList)
                {
                    this.ScoutGiudizio += sr.Review + "|";
                    this.ScoutName += sr.ScoutName + "|";
                    this.ScoutDate += TmWeek.ToSWDString(sr.Date) + "|";
                    this.ScoutVoto += sr.Vote.ToString() + "|";
                    sumVote += (float)sr.Vote;
                }

                this.ScoutGiudizio = this.ScoutGiudizio.TrimEnd('|');
                this.ScoutName = this.ScoutName.TrimEnd('|');
                this.ScoutDate = this.ScoutDate.TrimEnd('|');
                this.ScoutVoto = this.ScoutVoto.TrimEnd('|');

                if (srList.Count == 0)
                    this.MediaVoto = 0;
                else
                    this.MediaVoto = sumVote / (float)srList.Count;
            }

            public void SetTI(DateTime pageDate, string training)
            {
                // Create a scructure based on the actual TI string that contains the
                // TI history
                WeekHistorical whTI = null;
                
                if (this.IsTSINull())
                    whTI = new WeekHistorical();
                else
                    whTI = new WeekHistorical(TSI);

                int index = 0;

                if (training.Contains("peaks"))
                    training = HTML_Parser.GetField(training, "peaks='", "'", ref index);

                // Add the new training info
                training = training.Trim(';');
                whTI.Add(pageDate, training);

                // Store the structure into a TI string
                TSI = whTI.ToString();
            }

            #region BloomValues
            int _bloomStart = -1;
            public int wBloomStart
            {
                get
                {
                    if (_bloomStart == -1)
                    {
                        ParseBloomValues();
                    }
                    return _bloomStart;
                }
                set
                {
                    _bloomStart = value;
                    SetBloomValues();
                }
            }

            decimal _beforeExplTI = -100M;
            public decimal BeforeExplTI
            {
                get
                {
                    if (_beforeExplTI == -100M)
                    {
                        ParseBloomValues();
                        if (_beforeExplTI == -100M) return 0M;
                    }
                    return _beforeExplTI;
                }
                set
                {
                    _beforeExplTI = value;
                    SetBloomValues();
                }
            }

            decimal _explosionTI = -100M;
            public decimal ExplosionTI
            {
                get
                {
                    if (_explosionTI == -100M)
                    {
                        ParseBloomValues();
                        if (_explosionTI == -100M) return 0M;
                    }
                    return _explosionTI;
                }
                set
                {
                    _explosionTI = value;
                    SetBloomValues();
                }
            }

            decimal _afterBloomTI = -100M;
            public decimal AfterBloomTI
            {
                get
                {
                    if (_afterBloomTI == -100M)
                    {
                        ParseBloomValues();
                        if (_afterBloomTI == -100M) return 0M;
                    }
                    return _afterBloomTI;
                }
                set
                {
                    _afterBloomTI = value;
                    SetBloomValues();
                }
            }

            decimal _asi30 = -100M;
            public decimal Asi30
            {
                get
                {
                    if (_asi30 == -100M)
                    {
                        ParseBloomValues();
                        if (_asi30 == -100M) return 0M;
                    }
                    return _asi30;
                }
                set
                {
                    _asi30 = value;
                    SetBloomValues();
                }
            }

            decimal _asi25 = -100M;
            public decimal Asi25
            {
                get
                {
                    if (_asi25 == -100M)
                    {
                        ParseBloomValues();
                        if (_asi25 == -100M) return 0M;
                    }
                    return _asi25;
                }
                set
                {
                    _asi25 = value;
                    SetBloomValues();
                }
            }

            private void ParseBloomValues()
            {
                if (IswBloomDataNull()) return;
                string[] split = wBloomData.Split(';');
                if (split.Length > 0) _bloomStart = int.Parse(split[0]);
                if (split.Length > 1) _beforeExplTI = decimal.Parse(split[1]);
                if (split.Length > 2) _explosionTI = decimal.Parse(split[2]);
                if (split.Length > 3) _afterBloomTI = decimal.Parse(split[3]);
                if (split.Length > 4) _asi30 = decimal.Parse(split[4]);
                if (split.Length > 5) _asi25 = decimal.Parse(split[5]);
            }

            private void SetBloomValues()
            {
                wBloomData = _bloomStart.ToString();
                wBloomData += ";" + _beforeExplTI.ToString();
                wBloomData += ";" + _explosionTI.ToString();
                wBloomData += ";" + _afterBloomTI.ToString();
                wBloomData += ";" + _asi30.ToString();
                wBloomData += ";" + _asi25.ToString();
            }
            #endregion

            #region TrainingAbilities
            decimal _physics = 0M;
            decimal _tactics = 0M;
            decimal _technics = 0M;

            decimal _strength = 0M;
            decimal _stamina = 0M;
            decimal _pace = 0M;

            decimal _marking = 0M;
            decimal _takling = 0M;
            decimal _workrate = 0M;

            decimal _positioning = 0M;
            decimal _passage = 0M;
            decimal _cross = 0M;

            decimal _tecnique = 0M;
            decimal _head = 0M;
            decimal _finalization = 0M;
            decimal _longdistance = 0M;
            decimal _setpieces = 0M;

            private void ParseTrainingAbilities()
            {
                if (IsTrainingAbilitiesNull()) return;
                string[] split = TrainingAbilities.Split(';');

                if (split.Length > 0) _physics = decimal.Parse(split[0]);
                if (split.Length > 1) _tactics = decimal.Parse(split[1]);
                if (split.Length > 2) _technics = decimal.Parse(split[2]);
                if (split.Length > 3) _strength = decimal.Parse(split[3]);
                if (split.Length > 4) _stamina = decimal.Parse(split[4]);
                if (split.Length > 5) _pace = decimal.Parse(split[5]);
                if (split.Length > 6) _marking = decimal.Parse(split[6]);
                if (split.Length > 7) _takling = decimal.Parse(split[7]);
                if (split.Length > 8) _workrate = decimal.Parse(split[8]);
                if (split.Length > 9) _positioning = decimal.Parse(split[9]);
                if (split.Length > 10) _passage = decimal.Parse(split[10]);
                if (split.Length > 11) _cross = decimal.Parse(split[11]);
                if (split.Length > 12) _tecnique = decimal.Parse(split[12]);
                if (split.Length > 13) _head = decimal.Parse(split[13]);
                if (split.Length > 14) _finalization = decimal.Parse(split[14]);
                if (split.Length > 15) _longdistance = decimal.Parse(split[15]);
                if (split.Length > 16) _setpieces = decimal.Parse(split[16]);
            }

            private void SetTrainingAbilities()
            {
                TrainingAbilities = _physics.ToString();
                TrainingAbilities += ";" + _tactics.ToString();
                TrainingAbilities += ";" + _technics.ToString();
                TrainingAbilities += ";" + _strength.ToString();
                TrainingAbilities += ";" + _stamina.ToString();
                TrainingAbilities += ";" + _pace.ToString();
                TrainingAbilities += ";" + _marking.ToString();
                TrainingAbilities += ";" + _takling.ToString();
                TrainingAbilities += ";" + _workrate.ToString();
                TrainingAbilities += ";" + _positioning.ToString();
                TrainingAbilities += ";" + _passage.ToString();
                TrainingAbilities += ";" + _cross.ToString();
                TrainingAbilities += ";" + _tecnique.ToString();
                TrainingAbilities += ";" + _head.ToString();
                TrainingAbilities += ";" + _finalization.ToString();
                TrainingAbilities += ";" + _longdistance.ToString();
                TrainingAbilities += ";" + _setpieces.ToString();
            }

            public decimal Physics
            {
                get
                {
                    if (_physics == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _physics;
                }
                set
                {
                    _physics = value;
                    _pace = _strength = _stamina = _head = _physics;
                    SetTrainingAbilities();
                }
            }
            public decimal Tactics
            {
                get
                {
                    if (_tactics == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _tactics;
                }
                set
                {
                    _tactics = value;
                    _marking = _takling = _workrate = _positioning = _tactics;
                    SetTrainingAbilities();
                }
            }
            public decimal Technics
            {
                get
                {
                    if (_technics == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _technics;
                }
                set
                {
                    _technics = value;
                    _passage = _cross = _tecnique = _finalization = _longdistance = _setpieces = _technics;
                    SetTrainingAbilities();
                }
            }
            public decimal Strength
            {
                get
                {
                    if (_strength == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _strength;
                }
                set
                {
                    _strength = value;
                    SetTrainingAbilities();
                }
            }
            public decimal Stamina
            {
                get
                {
                    if (_stamina == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _stamina;
                }
                set
                {
                    _stamina = value;
                    SetTrainingAbilities();
                }
            }
            public decimal Pace
            {
                get
                {
                    if (_pace == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _pace;
                }
                set
                {
                    _pace = value;
                    SetTrainingAbilities();
                }
            }
            public decimal Marking
            {
                get
                {
                    if (_marking == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _marking;
                }
                set
                {
                    _marking = value;
                    SetTrainingAbilities();
                }
            }
            public decimal Takling
            {
                get
                {
                    if (_takling == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _takling;
                }
                set
                {
                    _takling = value;
                    SetTrainingAbilities();
                }
            }
            public decimal WorkRate
            {
                get
                {
                    if (_workrate == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _workrate;
                }
                set
                {
                    _workrate = value;
                    SetTrainingAbilities();
                }
            }
            public decimal Positioning
            {
                get
                {
                    if (_positioning == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _positioning;
                }
                set
                {
                    _positioning = value;
                    SetTrainingAbilities();
                }
            }
            public decimal Passage
            {
                get
                {
                    if (_passage == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _passage;
                }
                set
                {
                    _passage = value;
                    SetTrainingAbilities();
                }
            }
            public decimal Cross
            {
                get
                {
                    if (_cross == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _cross;
                }
                set
                {
                    _cross = value;
                    SetTrainingAbilities();
                }
            }
            public decimal Tecnique
            {
                get
                {
                    if (_tecnique == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _tecnique;
                }
                set
                {
                    _tecnique = value;
                    SetTrainingAbilities();
                }
            }
            public decimal Heading
            {
                get
                {
                    if (_head == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _head;
                }
                set
                {
                    _head = value;
                    SetTrainingAbilities();
                }
            }
            public decimal Finalization
            {
                get
                {
                    if (_finalization == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _finalization;
                }
                set
                {
                    _finalization = value;
                    SetTrainingAbilities();
                }
            }
            public decimal LongDistance
            {
                get
                {
                    if (_longdistance == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _longdistance;
                }
                set
                {
                    _longdistance = value;
                    SetTrainingAbilities();
                }
            }
            public decimal SetPieces
            {
                get
                {
                    if (_setpieces == 0M)
                    {
                        ParseTrainingAbilities();
                    }
                    return _setpieces;
                }
                set
                {
                    _setpieces = value;
                    SetTrainingAbilities();
                }
            }

            #endregion

            public void ClearReviews()
            {
                if (ScoutVoto.Length > ScoutReviews.Length)
                {
                    string[] votes = this.ScoutVoto.Split('|');
                    string scoutvoto = "";

                    foreach (string vote in votes)
                    {
                        if (vote == "") continue;
                        if (int.Parse(vote) != 0)
                        {
                            scoutvoto += vote + "|";
                        }
                    }

                    scoutvoto = scoutvoto.TrimEnd('|');

                    ScoutVoto = scoutvoto;
                }
            }

            public void SetTINew(DateTime dt, string ti_data, bool isGk)
            {
                string[] part = ti_data.Split(',');

                string training = "";

                int ixstart = 20;
                if (isGk)
                    ixstart = 17;

                for (int i = ixstart; i < part.Length; i++)
                {
                    training += part[i] + ";";
                }
                training = training.TrimEnd(';');

                SetTI(dt, training);
            }

            public void SetAddedSkill(ScoutsNReviews snr, ReportParser reportParser)
            {
                float Tec = 0; float f_Tec = 0;
                float Tac = 0; float f_Tac = 0;
                float Pro = 0; float f_Pro = 0;
                float Lea = 0; float f_Lea = 0;
                float Agg = 0; float f_Agg = 0;
                float Phy = 0; float f_Phy = 0;

                // Reset professionality
                for (int i = 0; i < ScoutNames.Length; i++)
                {
                    Dictionary<string, string> dict = HTML_Parser.String2Dictionary(ScoutReviews[i]);

                    ScoutsNReviews.ScoutsRow sr = snr.Scouts.FindByName(ScoutNames[i]);
                    if (sr == null)
                    {
                        sr = snr.Scouts.NewScoutsRow();
                        sr.Technical = 5;
                        sr.Tactical = 5;
                        sr.Psychology = 5;
                        sr.Physical = 5;
                    }


                    if (dict.ContainsKey("Tec"))
                    {
                        Tec += float.Parse(dict["Tec"]) * (float)sr.Technical;
                        f_Tec += (float)sr.Technical;
                    }
                    if (dict.ContainsKey("Tac"))
                    {
                        Tac += float.Parse(dict["Tac"]) * (float)sr.Tactical;
                        f_Tac += (float)sr.Tactical;
                    }
                    if (dict.ContainsKey("Pro"))
                    {
                        Pro += float.Parse(dict["Pro"]) * (float)sr.Psychology;
                        f_Pro += (float)sr.Psychology;
                    }
                    if (dict.ContainsKey("Lea"))
                    {
                        Lea += float.Parse(dict["Lea"]) * (float)sr.Psychology;
                        f_Lea += (float)sr.Psychology;
                    }
                    if (dict.ContainsKey("Agg"))
                    {
                        Agg += float.Parse(dict["Agg"]) * (float)sr.Psychology;
                        f_Agg += (float)sr.Psychology;
                    }
                    if (dict.ContainsKey("Phy"))
                    {
                        Phy += float.Parse(dict["Phy"]) * (float)sr.Physical;
                        f_Phy += (float)sr.Physical;
                    }
                    if (dict.ContainsKey("Spe")) 
                    {
                        int spec = int.Parse(dict["Spe"]);
                        string skill = reportParser.Dict["Player_Skill"][spec];
                        Speciality = skill.Substring(0, 3);
                    }
                    
                    //if (dict.ContainsKey("Dev")) rrow.Development = short.Parse(dict["Dev"]);
                    //if (dict.ContainsKey("Blo")) rrow.Blooming = short.Parse(dict["Blo"]);
                    //if (dict.ContainsKey("BlS")) rrow.BloomingStatus = short.Parse(dict["BlS"]);
                    //if (dict.ContainsKey("Age")) rrow.Age = short.Parse(dict["Age"]);
                    //if (dict.ContainsKey("Spe")) rrow.Speciality = short.Parse(dict["Spe"]);

                }

                if (IsHiddenRevealedNull() || !HiddenRevealed)
                {
                    SetProfessionalismNull();
                    SetAggressivityNull();
                    if (f_Pro != 0) Professionalism = Pro / f_Pro * 2;
                    if (f_Agg != 0) Aggressivity = Agg / f_Agg * 2;
                }

                SetLeadershipNull();

                if (f_Lea != 0) Leadership = Lea / f_Lea * 2;
                if (f_Phy != 0) Physics = (decimal)(Phy / f_Phy) * 5;
                if (f_Tec != 0) Technics = (decimal)(Tec / f_Tec) * 5;
                if (f_Tac != 0) Tactics = (decimal)(Tac / f_Tac) * 5;
            }

            public void ComputeBloomingFromGiudizio(ScoutsNReviews snr)
            {
                float bloomstart = 0;
                float totalbloomstart = 0;
                float fBloom = 0;
                for (int i = 0; i < ScoutNames.Length; i++)
                {
                    Dictionary<string, string> dict = HTML_Parser.String2Dictionary(ScoutReviews[i]);

                    ScoutsNReviews.ScoutsRow sr = null; 

                    for (int s = 0; s < snr.Scouts.Count; s++)
                    {
                        string name = snr.Scouts[s].Name;
                        name = name.Split('(')[0].TrimEnd();
                        if (name == ScoutNames[i])
                        {
                            sr = snr.Scouts[s];
                            break;
                        }
                    }

                    if (sr == null)
                    {
                        sr = snr.Scouts.NewScoutsRow();
                        sr.Development = 5;
                        sr.Youth = 5;
                        sr.Senior = 5;
                    }

                    int blooming_status = 5;
                    if (dict.ContainsKey("BlS"))
                    {
                        blooming_status = int.Parse(dict["BlS"]);
                    }
                    int age = 0;
                    if (dict.ContainsKey("Age"))
                    {
                        age = int.Parse(dict["Age"]);
                    }
                    int blooming = 0;
                    if (dict.ContainsKey("Blo"))
                    {
                        blooming = int.Parse(dict["Blo"]);
                    }

                    float weight = 1.0f;
                    if (blooming_status == 5) // Già esploso
                    {
                        // Se è già esploso inutile cambiare la data dell'esposione
                        if (wBloomStart == -1)
                            bloomstart = wBorn + (age - 3) * 12;
                    }
                    else if (blooming_status == 4) // Fine esplosione
                    {
                        bloomstart = wBorn + (age - 2) * 12;
                    }
                    else if (blooming_status == 3) // Metà esplosione
                    {
                        bloomstart = wBorn + (age - 1) * 12;
                    }
                    else if (blooming_status == 2) // Inizio esplosione
                    {
                        bloomstart = wBorn + (age) * 12;
                    }
                    else if (blooming_status == 1) // Non esploso
                    {
                        weight = 0.1f;
                        if (blooming == 1) // Precoce
                        {
                            bloomstart = wBorn + 17 * 12;
                        }
                        else if (blooming == 2) // Normale
                        {
                            bloomstart = wBorn + 19 * 12;
                        }
                        else if (blooming == 3) // Tardivo
                        {
                            bloomstart = wBorn + 22 * 12;
                        }
                    }

                    float competence = 0;
                    if (age < 17) 
                        competence = sr.Youth;
                    else if (age < 21)
                        competence = (sr.Youth * (21 - age) + sr.Senior * (age - 17))/4;
                    else
                        competence = sr.Senior;

                    // Oldness
                    float oldness = 20 - (Età - age);

                    fBloom += sr.Development * competence * oldness * weight;

                    totalbloomstart += bloomstart * sr.Development * competence * oldness * weight;
                }

                totalbloomstart /= fBloom;
                totalbloomstart = (float)Math.Round(totalbloomstart / 12) * 12;

                this.wBloomStart = (int)totalbloomstart;

            }

            public decimal CurrentSkillSum
            {
                get
                {
                    return (this.Strength + this.Stamina + this.Pace +
                        this.Marking + this.Takling + this.WorkRate + 
                        this.Passage + this.Positioning + this.Cross + 
                        this.Technics + this.Heading + this.Finalization + this.SetPieces);
                }
            }

            public void CalcBloom()
            {
                decimal[] devTI = new decimal[40];
                decimal[] ASIHist = new decimal[40];
                TmWeek age = TmWeek.GetAge(this.wBorn, DateTime.Now);
                TmWeek bloomStart = TmWeek.GetAge(this.wBloomStart, DateTime.Now);

                decimal ActualTI = this.getActualTI();

                decimal skillsum = CurrentSkillSum;
                decimal BeforeExplosionTI = 0M;
                decimal AfterBloomingTI = 2M * (30 - bloomStart.Years) / 2;

                if (age.Years - bloomStart.Years >= 3)
                {
                    // The player is already bloomed
                    for (int years = age.Years; years <= 32; years++)
                    {
                        devTI[years] = ActualTI + ((0M - ActualTI) * (decimal)(years - age.Years)) / (decimal)(30 - age.Years);
                    }

                }
                else if ((age.Years - bloomStart.Years >= 0) && (age.Years - bloomStart.Years < 3))
                {
                    // The player is blooming
                    int yy = age.Years;

                    if (bloomStart.Years >= 19)
                    {
                        devTI[yy] = ActualTI;
                        devTI[yy + 1] = ActualTI * 0.97M;
                        devTI[yy + 2] = ActualTI * 0.94M;

                        int r = age.Years - bloomStart.Years;
                        // The player is already bloomed

                        for (int years = yy + 3 - r; years <= 32; years++)
                        {
                            int ys = yy + 3 - r;
                            devTI[years] = AfterBloomingTI + ((0M - AfterBloomingTI) * (decimal)(years - ys)) / (decimal)(30 - ys);
                        }
                    }
                    else if (yy == bloomStart.Years)
                    {
                        devTI[yy] = ActualTI;
                        BeforeExplosionTI = devTI[yy - 1];

                        if ((yy + 1) < 19)
                            devTI[yy + 1] = ActualTI;
                        else
                            devTI[yy + 1] = ActualTI - BeforeExplosionTI / 2M;

                        if ((yy + 2) < 19)
                            devTI[yy + 2] = ActualTI;
                        else
                            devTI[yy + 2] = ActualTI - BeforeExplosionTI / 2M;

                        // The player is already bloomed
                        for (int years = yy + 3; years <= 32; years++)
                        {
                            devTI[years] = AfterBloomingTI + ((0M - AfterBloomingTI) * (decimal)(years - (yy + 3))) / (decimal)(30 - (yy + 3));
                        }
                    }
                    else if (yy == bloomStart.Years + 1)
                    {
                        devTI[yy] = ActualTI;

                        if (yy == 18)
                            devTI[yy + 1] = ActualTI - BeforeExplosionTI / 2M;
                        else // (yy > 18) OR ((yy+1 < 19) && (yy < 19))
                            devTI[yy + 1] = ActualTI;

                        // The player is already bloomed
                        for (int years = yy + 2; years <= 32; years++)
                        {
                            devTI[years] = AfterBloomingTI + ((0M - AfterBloomingTI) * (decimal)(years - (yy + 2))) / (decimal)(30 - (yy + 2));
                        }
                    }
                    else if (yy == bloomStart.Years + 2)
                    {
                        devTI[yy] = ActualTI;

                        // The player is already bloomed
                        for (int years = yy + 1; years <= 32; years++)
                        {
                            devTI[years] = AfterBloomingTI + ((0M - AfterBloomingTI) * (decimal)(years - (yy + 1))) / (decimal)(30 - (yy + 1));
                        }
                    }
                }
                else // (yy < AgeStartOfBloom)
                {
                    // The player is still not blooming
                    int yy = age.Years;

                    int years = yy;

                    // The player is already bloomed
                    for (; years < bloomStart.Years; years++)
                    {
                        if (years < 19)
                            devTI[years] = ActualTI;
                        else if (yy < 19)
                            devTI[years] = ActualTI / 2M;
                        else
                            devTI[years] = ActualTI;
                    }

                    decimal lastTI = devTI[years - 1];

                    // The player is already bloomed
                    for (; years <= bloomStart.Years + 2; years++)
                    {
                        if ((years < 19) || (bloomStart.Years > 18))
                            devTI[years] = ExplosionTI;
                        else
                            devTI[years] = ExplosionTI - lastTI / 2M;
                    }

                    int y0 = years;
                    // The player is already bloomed
                    for (; years <= 32; years++)
                    {
                        devTI[years] = AfterBloomingTI + ((0M - AfterBloomingTI) * (decimal)(years - y0)) / (decimal)(30 - y0);
                    }
                }

                decimal EndOfBloomSkillSum = skillsum;

                decimal[] SkillSumHist = new decimal[40];
                /*
                PointPairList ah = new PointPairList();
                PointPairList ati = new PointPairList();

                int wn = 0;
                DateTime firstWeek = TmWeek.thisWeek().ToDate();
                firstWeek = age.ToDate();

                XDate xdate = (double)new XDate(firstWeek + TimeSpan.FromDays(7.0 * wn));
                wn++;
                ah.Add(xdate, (double)ActualASI);
                ati.Add(xdate, (double)ActualTI);

                for (int week = age.absweek + 1; week < 32 * 12; week++, wn++)
                {
                    int years = week / 12;

                    if (week == (bloomStart.Years + 3) * 12)
                        EndOfBloomSkillSum = skillsum;

                    if (week % 12 == 0)
                    {
                        SkillSumHist[week / 12] = skillsum;
                    }

                    xdate = (double)new XDate(firstWeek + TimeSpan.FromDays(7.0 * wn));

                    skillsum += 0.1M * devTI[years];

                    ah.Add(xdate, (double)ActualASI + (double)Tm_Utility.SkSumToASI(skillsum, isGK) - (double)Tm_Utility.SkSumToASI(CurrentSkillSum, isGK));

                    ati.Add(xdate, (double)devTI[years]);
                }

                decimal DeltaBloomASI = 0;
                decimal Delta30sASI = 0;

                DeltaBloomASI = Tm_Utility.SkSumToASI(EndOfBloomSkillSum, isGK) - Tm_Utility.SkSumToASI(CurrentSkillSum, isGK);

                Delta30sASI = Tm_Utility.SkSumToASI(SkillSumHist[30], isGK) - Tm_Utility.SkSumToASI(CurrentSkillSum, isGK);

                EndOfBloomASI = (decimal)ActualASI + DeltaBloomASI;
                TopASI = (decimal)ActualASI + Delta30sASI;

                for (int yrs = age.Years; yrs <= 39; yrs++)
                {
                    ASIHist[yrs] = (decimal)ActualASI + Tm_Utility.SkSumToASI(SkillSumHist[yrs], isGK) - Tm_Utility.SkSumToASI(CurrentSkillSum, isGK);
                }

                FillAsiGraph(ah, ati);
                 * */
            }

            private decimal getActualTI()
            {
                string TIs = this.TSI;
                string[] TIv = TIs.Split(';');
                try
                {
                    decimal actualTI = decimal.Parse(TIv[TIv.Length]);
                    return actualTI;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public void FillWithActualPlayers(ExtraDS eds, DateTime dt)
        {
            foreach (ExtraDS.GiocatoriRow gr in this.Giocatori)
            {
                if ((dt >= gr.FirstData) && (dt <= gr.LastData))
                {
                    ExtraDS.GiocatoriRow newRow = eds.Giocatori.NewGiocatoriRow();
                    newRow.ItemArray = gr.ItemArray;

                    eds.Giocatori.AddGiocatoriRow(newRow);
                }
            }
        }

        public void AddPlyrDataFromTDS(Db_TrophyDataSet tds, short isReserves)
        {
            foreach (Db_TrophyDataSet.GiocatoriRow gr in tds.Giocatori)
            {
                int id = gr.PlayerID;

                GiocatoriRow gRow = Giocatori.FindByPlayerID(id);
                if (gRow == null)
                {
                    gRow = Giocatori.NewGiocatoriRow();

                    gRow.Ada = 0; // gr.Ada;
                    gRow.FP = gr.FP;
                    gRow.FPn = Tm_Utility.FPToNumber(gRow.FP);
                    gRow.Nome = gr.Nome.Replace("\r\n", "").Replace(" ", "").Replace(".", ". ");
                    gRow.Numero = gr.Numero;
                    gRow.PlayerID = gr.PlayerID;
                    gRow.Nationality = gr.Nationality;
                    gRow.LastData = gRow.FirstData = (DateTime)tds.WeekNoData[0][0];
                    gRow.Età = gr.Età;
                    gRow.ASI = gr.ASI;
                    if (!gr.IsRoutineNull())
                        gRow.Routine = gr.Routine;
                    else
                        gRow.Routine = 0;
                    gRow.isYoungTeam = isReserves;
                    gRow.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, 0, gRow.Età);
                    TmWeek age = TmWeek.GetAge(gRow.wBorn, DateTime.Now);

                    Giocatori.AddGiocatoriRow(gRow);
                }
                else
                {
                    if (gRow.LastData <= (DateTime)tds.WeekNoData[0][0])
                    {
                        gRow.Numero = gr.Numero;
                        string updatedNome = gr.Nome.Replace("\r\n", "").Replace(" ", "").Replace(".", ". ");
                        if (gRow.Nome.Contains("."))
                        {
                            gRow.Nome = updatedNome;
                        }

                        gRow.LastData = (DateTime)tds.WeekNoData[0][0];
                        gRow.Età = gr.Età;

                        TmWeek age = TmWeek.GetAge(gRow.wBorn, DateTime.Now);
                        if (age.Years < gRow.Età)
                            gRow.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, 0, gRow.Età);

                        gRow.ASI = gr.ASI;
                        gRow.Nationality = gr.Nationality;
                        gRow.isYoungTeam = isReserves;
                        if (!gr.IsRoutineNull())
                            gRow.Routine = gr.Routine;
                        else
                            gRow.Routine = 0;
                    }
                    
                    if (gRow.FirstData >= (DateTime)tds.WeekNoData[0][0])
                    {
                        gRow.FirstData = (DateTime)tds.WeekNoData[0][0];
                    }
                }
            }

            foreach (Db_TrophyDataSet.PortieriRow gr in tds.Portieri)
            {
                int id = gr.PlayerID;

                GiocatoriRow gRow = Giocatori.FindByPlayerID(id);
                if (gRow == null)
                {
                    gRow = Giocatori.NewGiocatoriRow();

                    gRow.Ada = 0;
                    gRow.FP = "GK";
                    gRow.FPn = Tm_Utility.FPToNumber(gRow.FP);
                    gRow.Nome = gr.Nome.Replace("\r\n", "").Replace(" ", "").Replace(".", ". ");
                    gRow.Numero = gr.Numero;
                    gRow.PlayerID = gr.PlayerID;
                    gRow.Nationality = gr.Nationality;
                    gRow.LastData = gRow.FirstData = (DateTime)tds.WeekNoData[0][0];
                    gRow.Età = gr.Età;
                    gRow.ASI = gr.ASI;
                    gRow.isYoungTeam = isReserves;
                    if (!gr.IsRoutineNull())
                        gRow.Routine = gr.Routine;
                    else
                        gRow.Routine = 0;
                    gRow.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, 0, gRow.Età);
                    TmWeek age = TmWeek.GetAge(gRow.wBorn, DateTime.Now);

                    Giocatori.AddGiocatoriRow(gRow);
                }
                else
                {
                    if (gRow.LastData <= (DateTime)tds.WeekNoData[0][0])
                    {
                        gRow.Numero = gr.Numero;
                        string updatedNome = gr.Nome.Replace("\r\n", "").Replace(" ", "").Replace(".", ". ");
                        if (gRow.Nome.Contains("."))
                        {
                            gRow.Nome = updatedNome;
                        }
                        gRow.LastData = (DateTime)tds.WeekNoData[0][0];
                        gRow.Età = gr.Età;

                        TmWeek age = TmWeek.GetAge(gRow.wBorn, DateTime.Now);
                        if (age.Years < gRow.Età)
                            gRow.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, 0, gRow.Età);

                        gRow.ASI = gr.ASI;
                        gRow.Nationality = gr.Nationality;
                        gRow.isYoungTeam = isReserves;
                        if (!gr.IsRoutineNull())
                            gRow.Routine = gr.Routine;
                        else
                            gRow.Routine = 0;
                    }

                    if (gRow.FirstData >= (DateTime)tds.WeekNoData[0][0])
                    {
                        gRow.FirstData = (DateTime)tds.WeekNoData[0][0];
                    }
                }
            }

        }

        public void AddPlyrDataFromTDS_NewTM(Db_TrophyDataSet tds)
        {
            foreach (Db_TrophyDataSet.GiocatoriRow gr in tds.Giocatori)
            {
                int id = gr.PlayerID;

                GiocatoriRow gRow = Giocatori.FindByPlayerID(id);
                if (gRow == null)
                {
                    gRow = Giocatori.NewGiocatoriRow();

                    gRow.Ada = 0; // gr.Ada;
                    gRow.FP = gr.FP;
                    gRow.FPn = Tm_Utility.FPToNumber(gRow.FP);
                    gRow.Nome = gr.Nome;
                    gRow.Numero = gr.Numero;
                    gRow.PlayerID = gr.PlayerID;
                    gRow.Nationality = gr.Nationality;
                    gRow.LastData = gRow.FirstData = (DateTime)tds.WeekNoData[0][0];
                    gRow.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, gr.Mesi, gr.Età);
                    gRow.Età = gr.Età;
                    gRow.ASI = gr.ASI;

                    gRow.SetTI(tds.Date, gr.TIs);

                    gRow.Note = gr.Note;

                    if (gRow.IsGameTableNull())
                        gRow.GameTable = GameTable.UpdateGameTableString(TmWeek.GetSeason(gRow.LastData), "", gr);
                    else
                        gRow.GameTable = GameTable.UpdateGameTableString(TmWeek.GetSeason(gRow.LastData), gRow.GameTable, gr);

                    if (!gr.IsRoutineNull())
                        gRow.Routine = gr.Routine;
                    else
                        gRow.Routine = 0;
                    gRow.isYoungTeam = gr.IsReserve;
                    
                    TmWeek age = TmWeek.GetAge(gRow.wBorn, DateTime.Now);

                    Giocatori.AddGiocatoriRow(gRow);
                }
                else
                {
                    if (gRow.LastData <= (DateTime)tds.WeekNoData[0][0])
                    {
                        gRow.Numero = gr.Numero;
                        string updatedNome = gr.Nome;
                        if (gRow.Nome.Contains("."))
                        {
                            gRow.Nome = updatedNome;
                        }

                        gRow.LastData = (DateTime)tds.WeekNoData[0][0];
                        gRow.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, gr.Mesi, gr.Età);
                        gRow.Età = gr.Età;

                        TmWeek age = TmWeek.GetAge(gRow.wBorn, DateTime.Now);

                        gRow.ASI = gr.ASI;
                        gRow.Nationality = gr.Nationality;
                        gRow.isYoungTeam = gr.IsReserve;

                        if (!gr.IsRoutineNull())
                            gRow.Routine = gr.Routine;
                        else
                            gRow.Routine = 0;

                        string TIs = gr.TIs;
                        gRow.SetTI(tds.Date, TIs);

                        if (gRow.IsGameTableNull())
                            gRow.GameTable = GameTable.UpdateGameTableString(TmWeek.GetSeason(gRow.LastData), "", gr);
                        else
                            gRow.GameTable = GameTable.UpdateGameTableString(TmWeek.GetSeason(gRow.LastData), gRow.GameTable, gr);

                        gRow.Note = gr.Note;
                    }

                    if (gRow.FirstData >= (DateTime)tds.WeekNoData[0][0])
                    {
                        gRow.FirstData = (DateTime)tds.WeekNoData[0][0];
                    }
                }
            }

            foreach (Db_TrophyDataSet.PortieriRow gr in tds.Portieri)
            {
                int id = gr.PlayerID;

                GiocatoriRow gRow = Giocatori.FindByPlayerID(id);
                if (gRow == null)
                {
                    gRow = Giocatori.NewGiocatoriRow();

                    gRow.Ada = 0;
                    gRow.FP = "GK";
                    gRow.FPn = Tm_Utility.FPToNumber(gRow.FP);
                    gRow.Nome = gr.Nome;
                    gRow.Numero = gr.Numero;
                    gRow.PlayerID = gr.PlayerID;
                    gRow.Nationality = gr.Nationality;
                    gRow.LastData = gRow.FirstData = (DateTime)tds.WeekNoData[0][0];
                    gRow.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, gr.Mesi, gr.Età);
                    gRow.Età = gr.Età;
                    gRow.ASI = gr.ASI;
                    gRow.isYoungTeam = gr.IsReserve;

                    string TIs = gr.TIs;
                    gRow.SetTI(tds.Date, TIs);
                    gRow.Note = gr.Note;

                    if (!gr.IsRoutineNull())
                        gRow.Routine = gr.Routine;
                    else
                        gRow.Routine = 0;

                    if (gRow.IsGameTableNull())
                        gRow.GameTable = GameTable.UpdateGameTableString(TmWeek.GetSeason(gRow.LastData), "", gr);
                    else
                        gRow.GameTable = GameTable.UpdateGameTableString(TmWeek.GetSeason(gRow.LastData), gRow.GameTable, gr);

                    gRow.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, 0, gRow.Età);
                    TmWeek age = TmWeek.GetAge(gRow.wBorn, DateTime.Now);

                    Giocatori.AddGiocatoriRow(gRow);
                }
                else
                {
                    if (gRow.LastData <= (DateTime)tds.WeekNoData[0][0])
                    {
                        gRow.Numero = gr.Numero;
                        string updatedNome = gr.Nome;
                        if (gRow.Nome.Contains("."))
                        {
                            gRow.Nome = updatedNome;
                        }
                        gRow.LastData = (DateTime)tds.WeekNoData[0][0];
                        gRow.Età = gr.Età;

                        gRow.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, gr.Mesi, gr.Età);
                        gRow.Età = gr.Età;
                        TmWeek age = TmWeek.GetAge(gRow.wBorn, DateTime.Now);

                        gRow.ASI = gr.ASI;
                        gRow.Nationality = gr.Nationality;
                        gRow.isYoungTeam = gr.IsReserve;
                        if (!gr.IsRoutineNull())
                            gRow.Routine = gr.Routine;
                        else
                            gRow.Routine = 0;

                        if (gRow.IsGameTableNull())
                            gRow.GameTable = GameTable.UpdateGameTableString(TmWeek.GetSeason(gRow.LastData), "", gr);
                        else
                            gRow.GameTable = GameTable.UpdateGameTableString(TmWeek.GetSeason(gRow.LastData), gRow.GameTable, gr);

                        string TIs = gr.TIs;
                        gRow.SetTI(tds.Date, TIs);
                        gRow.Note = gr.Note;
                    }

                    if (gRow.FirstData >= (DateTime)tds.WeekNoData[0][0])
                    {
                        gRow.FirstData = (DateTime)tds.WeekNoData[0][0];
                    }
                }
            }

        }

        public int FindPlayerIDByName(string Name)
        {
            foreach (GiocatoriRow gr in this.Giocatori)
            {
                if (gr.Nome == Name) return gr.PlayerID;
            }

            return 0;
        }

        public GiocatoriRow FindByPlayerID(int ID)
        {
            foreach (GiocatoriRow gr in this.Giocatori)
            {
                if (gr.PlayerID == ID) return gr;
            }

            return null;
        }

        public int[] GetStatsAge(int minASI, int maxASI)
        {
            int minAge = 100;
            int maxAge = 0;

            if (this.Giocatori.Count == 0) return null;

            foreach (GiocatoriRow gr in this.Giocatori)
            {
                if (gr.IsEtàNull()) continue;
                if (minAge > gr.Età) minAge = gr.Età;
                if (maxAge < gr.Età) maxAge = gr.Età;
            }

            int[] AgeStats = new int[maxAge - minAge + 3];
            AgeStats[0] = minAge;
            AgeStats[1] = maxAge;

            foreach (GiocatoriRow gr in this.Giocatori)
            {
                if (gr.IsEtàNull()) continue;
                if (gr.IsASINull()) continue;
                if ((gr.ASI < minASI) || (gr.ASI > maxASI)) continue;

                AgeStats[2 + gr.Età - minAge]++;
            }

            return AgeStats;
        }

        public int[] GetStatsASI()
        {
            int minAge = 100;
            int maxAge = 0;

            foreach (GiocatoriRow gr in this.Giocatori)
            {
                if (gr.IsASINull()) continue;
                if (minAge > gr.Età) minAge = gr.Età;
                if (maxAge < gr.Età) maxAge = gr.Età;
            }

            int[] AgeStats = new int[maxAge - minAge + 3];
            AgeStats[0] = minAge;
            AgeStats[1] = maxAge;

            foreach (GiocatoriRow gr in this.Giocatori)
            {
                if (gr.IsASINull()) continue;
                AgeStats[2 + gr.Età - minAge] += gr.ASI;
            }

            return AgeStats;
        }

        public int[] GetStatsAge()
        {
            return GetStatsAge(0, 10000000);
        }

        public int[] GetStatsPlyASIxRule(int minASI, int maxASI)
        {
            int[] SpecStats = new int[specs.Length];

            foreach (GiocatoriRow gr in this.Giocatori)
            {
                if (gr.IsASINull()) continue;
                if ((gr.ASI < minASI) || (gr.ASI > maxASI)) continue;

                for (int i=0; i<specs.Length ; i++)
                {
                    if (gr.FP.Contains(specs[i]))
                        SpecStats[i]++;
                }
            }

            return SpecStats;
        }

        public void SetSquad(int ID, string squad)
        {
            GiocatoriRow gr = Giocatori.FindByPlayerID(ID);
            gr.Team = squad;
        }

        public void GetDataFromPrivatePages(string dataDirectory)
        {
            DirectoryInfo di = new DirectoryInfo(dataDirectory);
            if (!di.Exists)
            {
                MessageBox.Show("The selected directory " + dataDirectory + " does'nt exists");
                return;
            }

            if (di.GetFiles("*.htm*").Length != 0)
            {
                // Using data type 1.0
                foreach (FileInfo fi in di.GetFiles("*.htm*"))
                {
                    StreamReader file = new StreamReader(fi.FullName);

                    string playerpage = file.ReadToEnd();

                    file.Close();

                    GetPlayerDataFromPrivatePage(playerpage, fi.Name);
                }

                RecomputePlayersMeanVote();
            }
        }

        private void GetPlayerDataFromPrivatePage(string playerpage, string filename)
        {
            // Find the ID
            int idSt = 0, idEnd = 100;

            playerpage = playerpage.Replace("\"", "'");

            while (idEnd - idSt > 15)
            {
                idSt = playerpage.IndexOf("showprofile.php?playerid=", idSt);
                if (idSt != -1)
                    idSt += 25;
                else
                {
                    if (filename != null)
                        MessageBox.Show(Current.Language.TheFile + filename + " is not a valid page");
                    else
                        MessageBox.Show("Pasted data is not valid");
                    return;
                }
                idEnd = playerpage.IndexOf("&", idSt);
            }

            int playerID = int.Parse(playerpage.Substring(idSt, idEnd-idSt));

            GiocatoriRow gRow = Giocatori.FindByPlayerID(playerID);
            if (gRow == null) return; 

            if (!playerpage.Contains("scouts.php"))
            {
                ParsePlayerPage(playerpage, ref gRow);
            }
            else // Scout page
            {
                List<string> tables = HTML_Parser.GetTags(playerpage, "table");

                foreach (string table in tables)
                {
                    if (!table.Contains("scouts.php")) continue;

                    // This is the table containing reviews
                    List<string> trs = HTML_Parser.GetTags(playerpage, "tr");

                    string Names = "", Reviews = "", Votes = "", Dates = "";

                    for (int i=0; i<trs.Count; i++)
                    {
                        string tr = trs[i];

                        if (!tr.Contains("scouts.php")) continue;

                        Names += HTML_Parser.GetTag(tr, "span") + "|";
                        Dates += HTML_Parser.GetTag(tr, "th", 1) + "|";

                        tr = trs[i + 1];

                        string review = HTML_Parser.GetTag(tr, "td");
                        Reviews += review + "|";
                        Votes += HTML_Parser.GetField(review, "(", ")") + "|";
                    }

                    gRow.ScoutName = Names.TrimEnd('|');
                    gRow.ScoutDate = Dates.TrimEnd('|');
                    gRow.ScoutGiudizio = Reviews.TrimEnd('|');
                    gRow.ScoutVoto = Votes.TrimEnd('|');

                    break;
                }
            }
        }

        public static void ParsePlayerPage_NewTM(string page, ref GiocatoriRow gRow, ReportParser reportParser)
        {
            // Import only the report to analyze it
            string str = HTML_Parser.CutBefore(page, "player_scout_new");
            str = HTML_Parser.CutAfter(str, "player_interested_new");
            str = str.Replace("</div>", "</div>\n").Replace("</table>", "</table>\n").Replace("<br>", "\n");

            int i = 0;
            if (page.Contains("active_tab\" id=\"tabplayer_scout_new"))
            {
                gRow.ScoutName = "";
                gRow.ScoutDate = "";
                gRow.ScoutVoto = "";
                gRow.ScoutGiudizio = "";

                string[] divs = str.Split('\n');

                while (i < divs.Length)
                {
                    for (; i < divs.Length; i++)
                    {
                        if (divs[i].Contains("megastar recomendation"))
                        {
                            i--; // go to the previous row to take the name of the scout
                            break;
                        }
                    }

                    if (i == divs.Length) break;

                    // Getting scout names and date of scouting
                    gRow.ScoutName += HTML_Parser.GetTag(divs[i], "strong") + "|";

                    string date = HTML_Parser.GetTag(divs[i], "span").TrimStart('(').TrimEnd(')');
                    DateTime dt = DateTime.Parse(date);
                    gRow.ScoutDate += TmWeek.ToSWDString(dt) + "|";

                    // Moving to recommendations
                    i++;

                    List<string> spanRecs = HTML_Parser.GetFullTags(divs[i], "span");
                    float vote = 0;
                    foreach (string spanRec in spanRecs)
                    {
                        if (spanRec.Contains("megastar recomendation"))
                            vote += 2;
                        else if (spanRec.Contains("megastar potential_half"))
                            vote += 1;
                        else if (spanRec.Contains("megastar potential"))
                            vote += 2;
                    }

                    gRow.ScoutVoto += vote.ToString() + "|";

                    // Moving to recommendation age
                    i++;

                    string age = HTML_Parser.GetFirstNumberInString(divs[i]);

                    string giudizio = "";
                    giudizio += "Age=" + age + ";";

                    // Other field
                    i++;

                    int blooming_status = 0;
                    int blooming = 0;
                    int dev_status = 0;
                    int speciality = 0;
                    int physique = 0;
                    int technics = 0;
                    int tactics = 0;
                    int professionalism = 0;
                    int leadership = 0;
                    int aggressivity = 0;

                    for (; i < divs.Length; i++)
                    {
                        if (divs[i].Contains(":"))
                        {
                            string field = HTML_Parser.CleanTagsWithRest(divs[i]);

                            if (field.Contains(reportParser.Dict["Keys"][(int)ReportParser.Keys.BloomStatus]))
                            {
                                // It's the bloom status
                                string[] blooms = field.Split(":-".ToCharArray());
                                if (blooms.Length == 2)
                                {
                                    blooming_status = reportParser.find("Blooming_Status", blooms[1]);
                                }
                                else if (blooms.Length == 3)
                                {
                                    blooming_status = reportParser.find("Blooming_Status", blooms[1]);
                                    blooming = reportParser.find("Blooming", blooms[2]);
                                }
                            }
                            else if (field.Contains(reportParser.Dict["Keys"][(int)ReportParser.Keys.DevStatus]))
                            {
                                // It's the DevStatus
                                string[] devstats = field.Split(':');
                                dev_status = reportParser.find("Development", devstats[1]);
                            }
                            else if (field.Contains(reportParser.Dict["Keys"][(int)ReportParser.Keys.Speciality]))
                            {
                                // It's the Speciality
                                string[] spectats = field.Split(':');
                                if (gRow.FPn == 0) // GK
                                {
                                    speciality = reportParser.find("GK_Skill", spectats[1]);
                                }
                                else
                                {
                                    speciality = reportParser.find("Player_Skill", spectats[1]);
                                }

                            }
                        }
                        else if (divs[i].Contains(" - "))
                        {
                            physique = reportParser.find("Physique", divs[i], physique);
                            technics = reportParser.find("Technics", divs[i], technics);
                            tactics = reportParser.find("Tactics", divs[i], tactics);
                            aggressivity = reportParser.find("Aggressivity", divs[i], aggressivity);
                            leadership = reportParser.find("Charisma", divs[i], leadership);
                            professionalism = reportParser.find("Professionalism", divs[i], professionalism);
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (physique != 0) giudizio += "Phy=" + physique + ";";
                    if (technics != 0) giudizio += "Tec=" + technics + ";";
                    if (tactics != 0) giudizio += "Tac=" + tactics + ";";
                    if (leadership != 0) giudizio += "Lea=" + leadership + ";";
                    if (blooming_status != 0) giudizio += "BlS=" + blooming_status + ";";
                    if (blooming != 0) giudizio += "Blo=" + blooming + ";";
                    if (dev_status != 0) giudizio += "Dev=" + dev_status + ";";
                    if (speciality != 0) giudizio += "Spe=" + speciality + ";";

                    if (gRow.ScoutGiudizio != "")
                        gRow.ScoutGiudizio = gRow.ScoutGiudizio + "|" + giudizio.TrimEnd(',');
                    else
                        gRow.ScoutGiudizio = giudizio.TrimEnd(',');

                    if (aggressivity != 0) giudizio += "Agg=" + aggressivity + ";";
                    if (professionalism != 0) giudizio += "Pro=" + professionalism + ";";
                }
            }
            else if (page.Contains("active_tab\" id=\"tabplayer_history_new"))
            {
                string[] divs = str.Split('\n');

                List<string> bodies = HTML_Parser.GetTags(page, "tbody");

                int ix = 0;
                for (; ix < bodies.Count; ix++)
                {
                    if (bodies[ix].Contains("text_fade_overlay")) break;
                }

                string body = bodies[ix];

                List<string> trs = HTML_Parser.GetTags(body, "tr");

                GameTable gameTable = new GameTable();
                gameTable.LoadSeasonsStrings(gRow.GameTable);

                int lastSeason = 0;

                foreach (string tr in trs)
                {
                    List<string> tds = HTML_Parser.GetTags(tr, "td");

                    try
                    {
                        if (tds.Count < 8) continue;

                        int season = int.Parse(tds[0]);

                        GameTable.PerformancesRow pr = null;
                        bool added = false;

                        for (int ip = 0; ip < gameTable.Performances.Count; ip++)
                        {
                            if (gameTable.Performances[ip].Season == season)
                            {
                                pr = gameTable.Performances[ip];
                                break;
                            }
                        }

                        if (pr == null)
                        {
                            pr = gameTable.Performances.NewPerformancesRow();
                            added = true;
                        }

                        if (lastSeason != season)
                        {
                            pr.Season = season;
                            pr.GP = int.Parse(tds[3]);
                            pr.G = int.Parse(tds[4]);
                            pr.A = int.Parse(tds[5]);
                            pr.Cards = int.Parse(tds[6]);
                            pr.Rat = decimal.Parse(tds[7], Common.CommGlobal.ciUs);
                        }
                        else
                        {
                            decimal rat1 = decimal.Parse(tds[7], Common.CommGlobal.ciUs);
                            decimal rat2 = pr.Rat;
                            decimal gp1 = (decimal)(int.Parse(tds[3]));
                            decimal gp2 = (decimal)(pr.GP);

                            decimal rat = (rat1 * gp1 + rat2 * gp2) / (gp1 + gp2);

                            pr.Rat = rat;
                            pr.GP += int.Parse(tds[3]);
                            pr.G += int.Parse(tds[4]);
                            pr.A += int.Parse(tds[5]);
                            pr.Cards += int.Parse(tds[6]);
                        }

                        lastSeason = season;

                        if (added)
                            gameTable.Performances.AddPerformancesRow(pr);
                    }
                    catch
                    {
                        continue;
                    }
                }

                gRow.GameTable = gameTable.ToString();
            }

            gRow.ScoutName = gRow.ScoutName.TrimEnd('|');
            gRow.ScoutDate = gRow.ScoutDate.TrimEnd('|');
            gRow.ScoutVoto = gRow.ScoutVoto.TrimEnd('|');
        }

        public static void ParsePlayerPage(string page, ref GiocatoriRow gRow)
        {
            page = page.Replace("'", "");
            page = page.Replace('"', '\'');
            page = page.Replace("'>", ">");
            page = page.Replace("&#39;", "'");
            page = page.Replace(" \r\n", " ");
            bool scout_parsed = false;

            DateTime pageDate = DateTime.Now;

            List<string> tables = HTML_Parser.GetTags(page, "table");

            // It's a base page
            string[] pagelines = page.Split('\n');

            for (int ix = 0; ix < pagelines.Length; ix++) 
            {
                string line = pagelines[ix];

                if (line.Contains("select_player"))
                {
                    // Line containing Age, Height and Weight
                    int index = 0;
                    string Age = HTML_Parser.GetField(line, "</strong>", "<", ref index);

                    if (Age == "")
                    {
                        ix = ix + 1;
                        line = pagelines[ix];
                        Age = HTML_Parser.GetField(line, "</strong>", "<", ref index);
                    }
                    string Heigth = HTML_Parser.GetField(line, "</strong>", "<", ref index);
                    string Weight = HTML_Parser.GetField(line, "</strong>", "<", ref index);

                    gRow.wBorn = TmWeek.GetBornWeekFromAge(pageDate, Age);

                    TmWeek age = TmWeek.GetAge(gRow.wBorn, pageDate);
                    gRow.Età = age.Years;

                    continue;
                }

                if (line.Contains("importage"))
                {
                    // Line containing Age, Height and Weight
                    int index = 0;
                    string training = HTML_Parser.GetField(line, "importage=", ">", ref index);
                    training = HTML_Parser.CleanFlashVars(training);
                    gRow.SetTSINull();
                    gRow.SetTI(pageDate, training);
                    gRow.AvTSI = Utility.WeightedMean(gRow.TSI);

                    continue;
                }

                if (line.Contains("<!-- Header start -->"))
                {
                    string full_line = "";
                    ix++;

                    for (; ix < pagelines.Length; ix++)
                    {
                        line = pagelines[ix];
                        full_line += line.TrimEnd('\r');
                        if (line.Contains("<!-- Header end -->")) break;
                    }

                    // Season line
                    int index = 0;
                    string FullName = HTML_Parser.GetField(full_line, "</div>", " <a href", ref index);
                    string RealCountry = HTML_Parser.GetField(full_line, "showcountry=", "><img", ref index);
                    gRow.Nome = FullName.Replace("  ", " ");
                    gRow.Nationality = RealCountry;

                    continue;
                }
            } // end for (int ix = 0; ix < lines.Length; ix++)

            for (int ix = 0; ix < tables.Count; ix++)
            {
                string table = tables[ix];

                if (table.Contains(">ASI<"))
                {
                    // Line containing Age, Height and Weight
                    string partline = table.Substring(table.IndexOf(">ASI<") + 5);
                    List<string> tags = HTML_Parser.GetTags(partline, "td");
                    string FP = TM_Compatible.ConvertNewFP(tags[0]);
                    string routine = tags[1];
                    string wage = tags[2];
                    wage = wage.Replace(",", "");
                    gRow.FP = FP;
                    gRow.Wage = int.Parse(wage);
                    gRow.Routine = decimal.Parse(routine, Common.CommGlobal.ciUs);
                    continue;
                }

                if (table.Contains("<!-- Season -->"))
                {
                    List<string> rows = HTML_Parser.GetTags2(table, "tr");

                    for (int ir = 1; ir < rows.Count; ir++)
                    {
                        List<string> tdFields = HTML_Parser.GetTags(rows[ir], "td");

                        if (tdFields == null) continue;

                        string Fee;

                        if (tdFields.Count == 12)
                        {
                            // Season  = tdFields[0]; 
                            // Club    = tdFields[1];; 
                            // Nation  = tdFields[2]; 
                            // Age     = tdFields[3]; 
                            Fee = tdFields[4];
                            // GP      = tdFields[5]; 
                            // Gol     = tdFields[6]; 
                            // Assist  = tdFields[7]; 
                            // Prod    = tdFields[8]; 
                            // Mom     = tdFields[9];
                            // Cards   = tdFields[10];
                            float avRating;
                            float.TryParse(tdFields[11], NumberStyles.Float, CommGlobal.ciUs, out avRating);
                            gRow.AvRating = avRating;
                            break; // Get only the first season
                            // continue;
                        }

                        if (tdFields.Count == 9)
                        {
                            // GP      = tdFields[2; 
                            // Gol     = tdFields[3]; 
                            // Assist  = tdFields[4]; 
                            // Prod    = tdFields[5]; 
                            // Mom     = tdFields[6];
                            // Cards   = tdFields[7];
                            // float.TryParse(tdFields[8], out gr.AvRating);
                        }
                    }
                }

                if ((table.Contains("scouts.php") && !table.Contains("scouts_table") && (!scout_parsed)) ||
                    ((ix < tables.Count - 1) && (ix == 1) && (tables[ix + 1].Contains("scouts.php"))))
                {
                    List<ScoutReview> srList = ScoutReview.ParseTable(table);
                    if (srList.Count == 0) continue;

                    gRow.FillWithScoutReviewList(srList);

                    scout_parsed = true;
                }
            }
        }

        public void RecomputePlayersMeanVote()
        {
            foreach (GiocatoriRow gr in this.Giocatori)
            {
                float sum = 0;
                float wsum = 0;
                for (int i = 0; i < gr.numReview; i++)
                {
                    if (i >= gr.ScoutNames.Length)
                    {
                        gr.ClearReviews();
                        continue;
                    }

                    string scoutname = gr.ScoutNames[i];
                    ScoutsRow sr = Scouts.FindByName(scoutname);
                    if (sr == null)
                        sr = Scouts.DefaultRow();

                    DateTime scouttime = gr.ScoutDates[i];
                    TimeSpan ts = (scouttime - DateTime.Now);
                    int plAge = gr.Età - ts.Days / (12 * 7);

                    float v17 = (float)sr.Youth;
                    float v28 = (float)sr.Senior;

                    float scAbility = v17 + (plAge - 17f) * (v28 - v17) / (28f - 17f);

                    wsum += (float)sr.Development + scAbility;
                    sum += (float)gr.ScoutVotes[i] * ((float)sr.Development + scAbility);
                }

                if ((sum == 0) || (wsum == 0))
                    gr.MediaVoto = 0.0f;
                else
                    gr.MediaVoto = sum / wsum;
            }
        }

        public void ParseScoutReviewForHiddenData(ReportAnalysis ra, int playerID)
        {
            GiocatoriRow grCopy = null;
            int iCopy = int.MinValue;
            try
            {
                int count = 0;
                ProgressForm pform = new ProgressForm();
                pform.progressBar.Maximum = this.Giocatori.Count;
                pform.progressBar.Value = 0;
                pform.Text = "Parsing scout reviews: Please wait";
                pform.lblProgressDescription.Text = "Scout review 0 of " + pform.progressBar.Maximum.ToString();
                Form parent = Application.OpenForms[0];
                pform.Show(parent);
                parent.Refresh();
                pform.Refresh();


                foreach (GiocatoriRow gr in this.Giocatori)
                {
                    count++;

                    if ((playerID != gr.PlayerID) && (playerID != -1))
                        continue;

                    pform.lblProgressDescription.Text = "Scout review " + count.ToString() +
                        " of " + this.Giocatori.Count.ToString();
                    pform.Value = count;
                    pform.Refresh();

                    grCopy = gr;

                    HiddenData hdSum = new HiddenData();
                    HiddenData wSum = new HiddenData();

                    for (int i = 0; ((i < gr.numReview) && (i < gr.ScoutDates.Length) && (i < gr.ScoutNames.Length)); i++)
                    {
                        iCopy = i;

                        if (i >= gr.ScoutNames.Length) continue;

                        string scoutname = gr.ScoutNames[i];
                        ScoutsRow sr = Scouts.FindByName(scoutname);
                        if (sr == null)
                            sr = Scouts.DefaultRow();

                        HiddenData w = new HiddenData();

                        TimeSpan ts = DateTime.Now - gr.ScoutDates[i];

                        // Valutazioni caratteristiche psicologiche
                        w.Agg = (decimal)sr.Psychology;
                        w.Blo = (decimal)sr.Development;
                        w.Abi = ((decimal)sr.Development) / (decimal)(1 + ts.Days);
                        w.Lea = (decimal)sr.Psychology;
                        w.Phy = (decimal)sr.Physical;
                        w.Pro = (decimal)sr.Psychology;
                        w.Tac = (decimal)sr.Tactical;
                        w.Tec = (decimal)sr.Technical;

                        HiddenData res = ra.GetHiddenData(gr.ScoutReviews[i]);

                        if (res.Abi > 0) wSum.Abi += w.Abi;
                        if (res.Agg > 0) wSum.Agg += w.Agg;
                        if (res.Blo > 0) wSum.Blo += w.Blo;
                        if (res.Lea > 0) wSum.Lea += w.Lea;
                        if (res.Phy > 0) wSum.Phy += w.Phy;
                        if (res.Pro > 0) wSum.Pro += w.Pro;
                        if (res.Tac > 0) wSum.Tac += w.Tac;
                        if (res.Tec > 0) wSum.Tec += w.Tec;

                        res = res * w;
                        hdSum = hdSum + res;
                    }

                    // Ability
                    if ((hdSum.Abi != 0) && (wSum.Abi != 0))
                        gr.Ability = (float)(hdSum.Abi / wSum.Abi);

                    // Blooming
                    if ((hdSum.Blo != 0) && (wSum.Blo != 0))
                        gr.Blooming = (float)(hdSum.Blo / wSum.Blo);

                    // Leadership
                    if ((hdSum.Lea != 0) && (wSum.Lea != 0))
                        gr.Leadership = (float)(hdSum.Lea / wSum.Lea);

                    if (gr.IsHiddenRevealedNull() || !gr.HiddenRevealed)
                    {
                        // Aggressivity
                        if ((hdSum.Agg != 0) && (wSum.Agg != 0))
                            gr.Aggressivity = (float)(hdSum.Agg / wSum.Agg);

                        // Professionalism
                        if ((hdSum.Pro != 0) && (wSum.Pro != 0))
                            gr.Professionalism = (float)(hdSum.Pro / wSum.Pro);
                    }

                    // Physics
                    if ((hdSum.Phy != 0) && (wSum.Phy != 0))
                        gr.Physics = (hdSum.Phy / wSum.Phy);
                    else
                        gr.Physics = 0;

                    // Tactical
                    if ((hdSum.Tac != 0) && (wSum.Tac != 0))
                        gr.Tactics = (hdSum.Tac / wSum.Tac);
                    else
                        gr.Tactics = 0;

                    // Technical
                    if ((hdSum.Tec != 0) && (wSum.Tec != 0))
                        gr.Technics = (hdSum.Tec / wSum.Tec);
                    else
                        gr.Technics = 0;
                }

                pform.CodeClose();
            }
            catch(Exception e)
            {
                string info = "";
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                info =  "Nome:" + grCopy.Nome +
                    "\r\nPlayerID:" + grCopy.PlayerID +
                    "\r\nReview:" + grCopy.numReview +
                    "\r\nScoutName:" + grCopy.ScoutName +
                    "\r\nDate:" + grCopy.ScoutDate +
                    "\r\nVoto:" + grCopy.ScoutVoto +
                    "\r\nGiudizio:" + grCopy.ScoutGiudizio +
                    "\r\nNo Scout:" + Scouts.Count.ToString() +
                    "\r\ni:" + iCopy.ToString() +
                    "\r\nCount Giocatori:" + this.Giocatori.Count.ToString();

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
            }
        }



        public void LoadPlayer_New(object dt, string page)
        {
            
        }

        public string GetTabbedList()
        {
            string text = "";
            foreach (GiocatoriRow nnr in Giocatori)
            {
                text += nnr.PlayerID + "\t";
                text += nnr.Numero + "\t";
                text += nnr.Nationality + "\t";
                text += nnr.Nome.Replace("\r\n", "").Replace(" ", "").Replace(".", ". ") + "\t";
                text += nnr.FP + "\n";
            }

            text = text.TrimEnd('\n');

            return text;
        }

        public void PutTabbedList(string tabtext)
        {
            string[] lines = tabtext.Split('\n');

            foreach (string line in lines)
            {
                if (line == "") continue;

                GiocatoriRow nnr = this.Giocatori.NewGiocatoriRow();

                int id = int.Parse(line.Split('\t')[0]);

                nnr.Numero = int.Parse(line.Split('\t')[1]);
                nnr.Nationality = line.Split('\t')[2];
                nnr.Nome = line.Split('\t')[3];
                nnr.FP = line.Split('\t')[4].TrimEnd('\r');

                GiocatoriRow nnrf = Giocatori.FindByPlayerID(id);
                if (nnrf == null)
                {
                    nnr.PlayerID = id;
                    Giocatori.AddGiocatoriRow(nnr);
                }
                else
                {
                    if (MessageBox.Show("Sostitute previous definition of ID " + id.ToString(),
                        "Paste from Excel format",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        nnr.PlayerID = id;
                        Giocatori.AddGiocatoriRow(nnr);
                    }
                }
            }
        }

        public static void ParsePlayerPage_Extras(HtmlDocument htmlDocument, ref GiocatoriRow gRow, ReportParser reportParser)
        {
            //{
            //    HtmlElement hidden = htmlDocument.GetElementById("player_scout_new");

            //    HtmlElementCollection element = hidden.GetElementsByTagName("div");

            //    for (var i = 0; i < element.Count; i++)
            //    {
            //        for (var n = 0; n < element[i].Children.Count; n++)
            //        {
            //            var child = element[i].Children[n];
            //            int blooming_status = 0;
            //            int blooming = 0;
   
            //            gRow.ScoutVoto = "";
            //            switch(n)
            //            {
            //                case 0:
            //                    // Name of the scout, date
            //                    gRow.ScoutName = child.Children[0].InnerText;
            //                    gRow.ScoutDate = child.Children[1].InnerText.TrimStart('(').TrimEnd(')');
            //                    break;
            //                case 1:
            //                    // recommendation
            //                    float vote = 0;
            //                    foreach (HtmlElement star in child.Children)
            //                    {
            //                        string spanRec = star.OuterHtml;
            //                        if (spanRec.Contains("megastar recomendation"))
            //                            vote += 2;
            //                        else if (spanRec.Contains("megastar potential_half"))
            //                            vote += 1;
            //                        else if (spanRec.Contains("megastar potential"))
            //                            vote += 2;
            //                    }
            //                    gRow.ScoutVoto += vote.ToString() + "|";
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}

            {
                HtmlElement hidden = htmlDocument.GetElementById("hidden_skill_table");
                HtmlElementCollection element = hidden.GetElementsByTagName("td");

                for (var i = 0; i < 4; i++)
                {
                    string tooltip = element[i].GetAttribute("tooltip");

                    if (tooltip == "")
                        return;

                    string field = HTML_Parser.GetField(tooltip, "<strong>", "/");

                    int val = int.Parse(field);

                    switch (i)
                    {
                        case 0: gRow.InjPron = val; break;
                        case 1: gRow.Aggressivity = val; break;
                        case 2: gRow.Professionalism = val; break;
                        case 3: gRow.Ada = val; break;
                    }
                }

                gRow.HiddenRevealed = true;
            }
        }
    }
}
