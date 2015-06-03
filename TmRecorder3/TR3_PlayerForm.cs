using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ZedGraph;
using System.Diagnostics;
using Common;
using System.IO;
using Languages;
using SendFileTo;
using NTR_Db;

namespace TmRecorder3
{
    public partial class TR3_PlayerForm : Form
    {
        private bool playerInfoChanged = false;
        public bool isDirty = false;
        public ChampDS.PlyStatsDataTable plyStatsTable = null;
        private PlayerData selectedPlayerData;
        private PlayerHistory playerHistory;
        private int selectedWeek;
        private int[] thisWeekPlayersIDs;

        public NTR_SquadDb SquadDB { get; set; }

        int _selectedPlayerIndex = -1;
        public int selectedPlayerIndex
        {
            get
            {
                if (_selectedPlayerIndex == -1)
                {
                    for (int i = 0; i < thisWeekPlayersIDs.Count(); i++)
                    {
                        if (selectedPlayerData.playerID == thisWeekPlayersIDs[i])
                        {
                            _selectedPlayerIndex = i;
                        }
                    }
                }
                return _selectedPlayerIndex;
            }

            set
            {
                _selectedPlayerIndex = value;
            }
        }

        public int selectedPlayerID
        {
            get
            {
                return selectedPlayerData.playerID;
            }
        }

        public int Wage
        {
            set { lblWage.Text = value.ToString(); }
        }

        public string Age
        {
            set { lblAge.Text = value; }
        }

        public int ASI
        {
            set { lblASI.Text = value.ToString(); }
        }

        public string PlayerName
        {
            set
            {
                string val = System.Convert.ToString(value);
                lblName.Text = val.Split('|')[0];
            }
        }

        public string PrefPos
        {
            set { lblPrefPos.Text = value; }
        }

        public decimal RoutineView
        {
            set { lblRoutine.Text = value.ToString(); }
        }

        public decimal BloomAgeView
        {
            set 
            {
                if (value == -1M)
                    lblBloomAge.Text = "-";
                else
                    lblBloomAge.Text = value.ToString(); 
            }
        }

        public TR3_PlayerForm(NTR_SquadDb squadDB, 
                            PlayerData playerData, 
                            TmSWD selectedWeek)
        {
            // Only for debug
            InitializeComponent();

            SetLanguage();

            SquadDB = squadDB;
            selectedPlayerData = playerData;

            this.selectedWeek = selectedWeek.AbsWeek;

            thisWeekPlayersIDs = (from c in SquadDB.HistData
                                  where (c.Week == this.selectedWeek)
                                  select c.PlayerID).ToArray();

            GetPlayerHistory();

            Initialize();

            chkNormalized_CheckedChanged(null, EventArgs.Empty);
        }

        public void GetPlayerHistory()
        {
            List<NTR_SquadDb.HistDataRow> playerHistoryList = (from c in SquadDB.HistData.AsEnumerable()
                             where (c.PlayerID == selectedPlayerData.playerID)
                             select c).OrderBy(p => p.Week).ToList();

            playerHistory = new PlayerHistory(playerHistoryList);
        }

        public void Initialize(int playerID)
        {
            NTR_SquadDb.HistDataRow selectedPlayerRow = (from c in SquadDB.HistData
                                                         where (c.PlayerID == playerID) && 
                                                         (c.Week == selectedWeek)
                                                         select c).Single<NTR_SquadDb.HistDataRow>();

            selectedPlayerData = new PlayerData(selectedPlayerRow, -1);

            GetPlayerHistory();

            Initialize();
        }

        public void Initialize()
        {
            chkShowTGI.Checked = Program.Setts.ShowTGI;

            FillBaseData(selectedPlayerData);

            FillPlayerData();

            if (selectedPlayerData.FPn != 0)
                FillSkillGraphPlayer();
            else
                FillSkillGraphGk();

            FillASIGraph();

            FillTIGraph();

            FillInjuriesGraph();

            if (selectedPlayerData.FPn != 0)
                FillSpecsGraphPlayer();
            else
                FillSpecsGraphGk();

            FillPlayerInfo(true);

            // SetTraining();

            //string expression = "(PlayerID = " + selectedPlayerData.playerID + ")";
            //ChampDS.PlyStatsRow[] drs = (ChampDS.PlyStatsRow[])plyStatsTable.Select(expression);

            //FillSeasonCombo(drs); 
            chkShowPosition.Checked = Program.Setts.ShowPosition;
            chkNormalized.Checked = Program.Setts.ShowStatsNormalized;

            FillMatchStatsGraph(plyStatsTable);

            playerInfoChanged = false;

            //FillTagsBar(History.reportParser);

            FillPlayerBar(selectedPlayerData.playerID);

            if (tabControl1.SelectedTab == tabPlayerBrowser)
            {
                tsbLoadPlayerPage_Click(null, EventArgs.Empty);
            }

            this.Refresh();
        }

        private void FillTagsBar(ReportParser reportParser)
        {
            SetTagBar(reportParser, tagsBarAgg, "Aggressivity");
            SetTagBar(reportParser, tagsBarPro, "Professionalism");
            SetTagBar(reportParser, tagsBarLea, "Charisma");
            SetTagBar(reportParser, tagsBarPhy, "Physique");
            SetTagBar(reportParser, tagsBarTac, "Tactics");
            SetTagBar(reportParser, tagsBarTec, "Technics");
        }

        private void SetTagBar(ReportParser reportParser, TagsBar tagsBar, string report)
        {
            tagsBar.Tags = new List<string>();
            if (!reportParser.Dict.ContainsKey(report))
                return;
            int cnt = reportParser.Dict[report].Count;
            tagsBar.Min = 1;
            tagsBar.Max = cnt;
            foreach (KeyValuePair<int, string> key in reportParser.Dict[report])
            {
                tagsBar.Tags.Add(key.Value);
            }
            tagsBar.Invalidate();       
        }

        private void SetTraining()
        {
            //ExtTMDataSet.GiocatoriNSkillRow playerDatarow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.Rows[iActualPlayer];
            //ExtraDS.GiocatoriRow gr = History.PlayersDS.FindByPlayerID(playerDatarow.PlayerID);

            //FillTrainingPsychologyGraph(gr);
            //FillTrainingPhysicsGraph(gr, playerDatarow);
            //FillTrainingTacticsGraph(gr, playerDatarow);
            //FillTrainingTechnicsGraph(gr, playerDatarow);
        }

        private void FillTrainingTechnicsGraph(ExtraDS.GiocatoriRow gr, ExtTMDataSet.GiocatoriNSkillRow gnsr)
        {
            // Training graph code
            GraphPane trainingPane = graphTrainingTechnics.GraphPane;

            // Set the title and axis labels
            trainingPane.Title.Text = "Technics Review";
            //trainingPane.XAxis.Title.Text = "Skill values";
            trainingPane.XAxis.Title.IsVisible = false;
            trainingPane.YAxis.Title.IsVisible = false;

            // Enter some random data values
            string[] labels = { Current.Language.Passing, Current.Language.Cross,
                Current.Language.Technique, Current.Language.Finishing,
                Current.Language.Longshots, Current.Language.SetPieces};
            double[] y = new double[6];
            double[] yv = new double[6];
            y[0] = (double)gr.Passage;
            y[1] = (double)gr.Cross;
            y[2] = (double)gr.Tecnique;
            y[3] = (double)gr.Finalization;
            y[4] = (double)gr.LongDistance;
            y[5] = (double)gr.SetPieces;
            if (gr.ScoutGiudizio.Contains("Spe=8;")) y[0] = 20;
            if (gr.ScoutGiudizio.Contains("Spe=9;")) y[1] = 20;
            if (gr.ScoutGiudizio.Contains("Spe=10;")) y[2] = 20;
            if (gr.ScoutGiudizio.Contains("Spe=12;")) y[3] = 20;
            if (gr.ScoutGiudizio.Contains("Spe=13;")) y[4] = 20;
            if (gr.ScoutGiudizio.Contains("Spe=14;")) y[5] = 20;
            yv[0] = (double)gnsr.Pas;
            yv[1] = (double)gnsr.Cro;
            yv[2] = (double)gnsr.Tec;
            yv[3] = (double)gnsr.Fin;
            yv[4] = (double)gnsr.Tir;
            yv[5] = (double)gnsr.Cal;

            // Generate a red bar with "Skill Value" in the legend
            trainingPane.CurveList.Clear();
            trainingPane.GraphObjList.Clear();
            CurveItem myCurve1 = trainingPane.AddBar("Potential Value", y, null, Color.Blue);
            CurveItem myCurve2 = trainingPane.AddBar("Actual Value", yv, null, Color.Red);

            trainingPane.YAxis.Scale.FontSpec.Size = 18.0F;
            trainingPane.XAxis.Scale.FontSpec.Size = 18.0F;
            trainingPane.Title.FontSpec.Size = 18.0F;

            trainingPane.XAxis.Title.FontSpec.Size = 18.0F;
            trainingPane.YAxis.Title.FontSpec.Size = 18.0F;
            trainingPane.Legend.FontSpec.Size = 18.0F;

            // Set the XAxis to an ordinal type
            //trainingPane.YAxis.Type = AxisType.Ordinal;
            trainingPane.YAxis.MajorTic.IsAllTics = true;
            // draw the X axis zero line
            trainingPane.XAxis.MajorGrid.IsZeroLine = true;

            //This is the part that makes the bars horizontal
            trainingPane.BarSettings.Base = BarBase.Y;
            trainingPane.YAxis.Type = AxisType.Text;
            trainingPane.YAxis.Scale.TextLabels = labels;
            trainingPane.XAxis.Scale.Max = 20;

            // Fill the axis background with a color gradient
            trainingPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0F);

            graphTrainingTechnics.AxisChange();
            graphTrainingTechnics.Refresh();
        }

        private void FillTrainingTacticsGraph(ExtraDS.GiocatoriRow gr, ExtTMDataSet.GiocatoriNSkillRow gnsr)
        {
            // Training graph code
            GraphPane trainingPane = graphTrainingTactics.GraphPane;

            // Set the title and axis labels
            trainingPane.Title.Text = "Tactics Review";
            //trainingPane.XAxis.Title.Text = "Skill values";
            trainingPane.XAxis.Title.IsVisible = false;
            trainingPane.YAxis.Title.IsVisible = false;

            // Enter some random data values
            string[] labels = { Current.Language.Marking, Current.Language.Takling,
                Current.Language.WorkRate, Current.Language.Positioning};
            double[] y = new double[4];
            double[] yv = new double[4];
            y[0] = (double)gr.Marking;
            y[1] = (double)gr.Takling;
            y[2] = (double)gr.WorkRate;
            y[3] = (double)gr.Positioning;
            if (gr.ScoutGiudizio.Contains("Spe=4;")) y[0] = 20;
            if (gr.ScoutGiudizio.Contains("Spe=5;")) y[1] = 20;
            if (gr.ScoutGiudizio.Contains("Spe=6;")) y[2] = 20;
            if (gr.ScoutGiudizio.Contains("Spe=7;")) y[3] = 20;
            yv[0] = (double)gnsr.Mar;
            yv[1] = (double)gnsr.Con;
            yv[2] = (double)gnsr.Wor;
            yv[3] = (double)gnsr.Pos;

            // Generate a red bar with "Skill Value" in the legend
            trainingPane.CurveList.Clear();
            trainingPane.GraphObjList.Clear();
            CurveItem myCurve1 = trainingPane.AddBar("Potential Value", y, null, Color.Blue);
            CurveItem myCurve2 = trainingPane.AddBar("Actual Value", yv, null, Color.Red);

            trainingPane.YAxis.Scale.FontSpec.Size = 18.0F;
            trainingPane.XAxis.Scale.FontSpec.Size = 18.0F;
            trainingPane.Title.FontSpec.Size = 18.0F;

            trainingPane.XAxis.Title.FontSpec.Size = 18.0F;
            trainingPane.YAxis.Title.FontSpec.Size = 18.0F;
            trainingPane.Legend.FontSpec.Size = 18.0F;

            // Set the XAxis to an ordinal type
            trainingPane.YAxis.Type = AxisType.Ordinal;
            // draw the X axis zero line
            trainingPane.XAxis.MajorGrid.IsZeroLine = true;

            //This is the part that makes the bars horizontal
            trainingPane.BarSettings.Base = BarBase.Y;
            trainingPane.YAxis.Type = AxisType.Text;
            trainingPane.YAxis.Scale.TextLabels = labels;
            trainingPane.XAxis.Scale.Max = 20;

            // Fill the axis background with a color gradient
            trainingPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0F);

            graphTrainingTactics.AxisChange();
            graphTrainingTactics.Refresh();
        }

        private void FillTrainingPhysicsGraph(ExtraDS.GiocatoriRow gr, ExtTMDataSet.GiocatoriNSkillRow gnsr)
        {
            // Training graph code
            GraphPane trainingPane = graphTrainingPhisics.GraphPane;

            // Set the title and axis labels
            trainingPane.Title.Text = "Physics Review";
            trainingPane.XAxis.Title.IsVisible = false;
            trainingPane.YAxis.Title.IsVisible = false;

            // Enter some random data values
            string[] labels = { Current.Language.Strength, Current.Language.Stamina, Current.Language.Pace, Current.Language.Heading };
            double[] y = new double[4];
            double[] yv = new double[4];
            y[0] = (double)gr.Strength;
            y[1] = (double)gr.Stamina;
            y[2] = (double)gr.Pace;
            y[3] = (double)gr.Heading;
            if (gr.ScoutGiudizio.Contains("Spe=1;")) y[0] = 20;
            if (gr.ScoutGiudizio.Contains("Spe=2;")) y[1] = 20;
            if (gr.ScoutGiudizio.Contains("Spe=3;")) y[2] = 20;
            if (gr.ScoutGiudizio.Contains("Spe=11;")) y[3] = 20;
            yv[0] = (double)gnsr.For;
            yv[1] = (double)gnsr.Res;
            yv[2] = (double)gnsr.Vel;
            yv[3] = (double)gnsr.Tes;

            // Generate a red bar with "Skill Value" in the legend
            trainingPane.CurveList.Clear();
            trainingPane.GraphObjList.Clear();
            CurveItem myCurve1 = trainingPane.AddBar("Potential Value", y, null, Color.Blue);
            CurveItem myCurve2 = trainingPane.AddBar("Actual Value", yv, null, Color.Red);

            trainingPane.YAxis.Scale.FontSpec.Size = 18.0F;
            trainingPane.XAxis.Scale.FontSpec.Size = 18.0F;
            trainingPane.Title.FontSpec.Size = 18.0F;

            trainingPane.XAxis.Title.FontSpec.Size = 18.0F;
            trainingPane.YAxis.Title.FontSpec.Size = 18.0F;
            trainingPane.Legend.FontSpec.Size = 18.0F;

            // Set the XAxis to an ordinal type
            trainingPane.YAxis.Type = AxisType.Ordinal;
            // draw the X axis zero line
            trainingPane.XAxis.MajorGrid.IsZeroLine = true;
            trainingPane.XAxis.Scale.Max = 20;

            //This is the part that makes the bars horizontal
            trainingPane.BarSettings.Base = BarBase.Y;
            trainingPane.YAxis.Type = AxisType.Text;
            trainingPane.YAxis.Scale.TextLabels = labels;

            // Fill the axis background with a color gradient
            trainingPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0F);

            graphTrainingPhisics.AxisChange();
            graphTrainingPhisics.Refresh();
        }

        private void FillTrainingPsychologyGraph(ExtraDS.GiocatoriRow gr)
        {
            // Training graph code
            GraphPane trainingPane = graphTrainingPsychology.GraphPane;

            // Set the title and axis labels
            trainingPane.Title.Text = "Psychology Review";
            //trainingPane.XAxis.Title.Text = "Skill values";
            trainingPane.XAxis.Title.IsVisible = false;
            trainingPane.YAxis.Title.IsVisible = false;

            // Enter some random data values
            string[] labels = { "Leadership", "Aggressivity", "Professionalism" };
            double[] y = new double[3];
            y[0] = 0; y[1] = 0; y[2] = 0;
            if (!gr.IsLeadershipNull()) y[0] = gr.Leadership;
            if (!gr.IsAggressivityNull()) y[1] = gr.Aggressivity;
            if (!gr.IsProfessionalismNull()) y[2] = gr.Professionalism;

            // Generate a red bar with "Skill Value" in the legend
            trainingPane.CurveList.Clear();
            trainingPane.GraphObjList.Clear();
            CurveItem myCurve = trainingPane.AddBar("Reviewed Skill Value", y, null, Color.Blue);

            trainingPane.YAxis.Scale.FontSpec.Size = 18.0F;
            trainingPane.XAxis.Scale.FontSpec.Size = 18.0F;
            trainingPane.Title.FontSpec.Size = 18.0F;

            trainingPane.XAxis.Title.FontSpec.Size = 18.0F;
            trainingPane.YAxis.Title.FontSpec.Size = 18.0F;
            trainingPane.Legend.FontSpec.Size = 18.0F;

            // Set the XAxis to an ordinal type
            trainingPane.YAxis.Type = AxisType.Ordinal;
            // draw the X axis zero line
            trainingPane.XAxis.MajorGrid.IsZeroLine = true;

            //This is the part that makes the bars horizontal
            trainingPane.BarSettings.Base = BarBase.Y;
            trainingPane.YAxis.Type = AxisType.Text;
            trainingPane.YAxis.Scale.TextLabels = labels;
            trainingPane.XAxis.Scale.Max = 10;

            // Fill the axis background with a color gradient
            trainingPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0F);

            graphTrainingPsychology.AxisChange();
            graphTrainingPsychology.Refresh();
        }

        private void FillSeasonCombo(ChampDS.PlyStatsRow[] drs)
        {
            List<int> seasons = new List<int>();

            foreach (ChampDS.PlyStatsRow psr in drs)
            {
                if (!seasons.Contains(psr.SeasonID))
                    seasons.Add(psr.SeasonID);
            }

            cmbSeason.Items.Clear();

            cmbSeason.Items.Add("All seasons");

            foreach (int season in seasons)
            {
                cmbSeason.Items.Add(season);
            }

            if (cmbSeason.Items.Count > 0)
                cmbSeason.SelectedIndex = cmbSeason.Items.Count - 1;
        }

        public void FillMatchStatsGraph(ChampDS.PlyStatsDataTable psDT)
        {
            try
            {
                GraphPane pane = graphPerf.GraphPane;
                pane.CurveList.Clear();

                // Set the title and axis labels
                pane.Title.Text = "Performance History";
                pane.YAxis.Title.Text = "Match Vote";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Enter some random data values
                string[] MatchTypes = "L,C,F,FL,LL".Split(',');
                int numOfMatchTypes = MatchTypes.Length;
                List<PointPairList> votes = new List<PointPairList>();

                string[] votesSng = new string[numOfMatchTypes];
                string[][] votesStr = new string[numOfMatchTypes][];

                pane.GraphObjList.Clear();

                if (cmbSeason.Items.Count == 0) return;

                int season = -1;
                if (cmbSeason.SelectedItem.ToString() != "All seasons")
                    season = (int)(cmbSeason.SelectedItem);

                List<NTR_SquadDb.PlayerPerfRow> playerPerfRows = null;

                if (season == -1)
                    playerPerfRows = (from c in SquadDB.PlayerPerf
                                      where c.PlayerID == selectedPlayerID
                                      select c).ToList();
                else
                {
                    DateTime dtSeasonStart = TmWeek.GetDateTimeOfSeasonStart(season);
                    DateTime dtSeasonEnd = TmWeek.GetDateTimeOfSeasonStart(season + 1);

                    playerPerfRows = (from c in SquadDB.PlayerPerf
                                      where (c.PlayerID == selectedPlayerID) && 
                                      (c.MatchRow.Date >= dtSeasonStart) &&
                                      (c.MatchRow.Date < dtSeasonEnd)
                                      select c).ToList();
                }

                foreach (NTR_SquadDb.PlayerPerfRow playerPerfRow in playerPerfRows)
                {
                    if (playerPerfRow.IsVoteNull()) continue;

                    int type = playerPerfRow.MatchRow.MatchType;
                    if (type > 20) type = 4;
                    else if (type > 10) type = 1;
                    else if (type == 5) type = 0;
                    if (votesSng[type] == null)
                        votesSng[type] = playerPerfRow.Vote.ToString();
                    else
                        votesSng[type] += ";" + playerPerfRow.Vote.ToString();
                }

                for (int i = 0; i < numOfMatchTypes; i++)
                {
                    if (votesSng[i] != null)
                        votesStr[i] = votesSng[i].Split(';');
                    else
                        votesStr[i] = null;
                }

                XDate xdateMin = XDate.JulDayMax;
                XDate xdateMax = XDate.JulDayMin;

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

                Color[] colors = {Color.Red, Color.Blue, Color.Green, Color.Violet, 
                Color.Turquoise, Color.Cyan};

                for (int mt = 0; mt < numOfMatchTypes; mt++)
                {
                    votes.Add(new PointPairList());

                    if (votesStr[mt] == null) continue;

                    for (int i = 0; i < votesStr[mt].Length; i++)
                    {
                        string[] part = votesStr[mt][i].Split('|');

                        DateTime dt = TmWeek.SWDtoDateTime(part[0]);
                        XDate xdate = new XDate(dt);

                        if (xdate < xdateMin) xdateMin = xdate;
                        if (xdate > xdateMax) xdateMax = xdate;

                        float vote;
                        if (chkNormalized.Checked)
                            vote = float.Parse(part[3]);
                        else
                            vote = float.Parse(part[2]);

                        votes[mt].Add(xdate, vote, part[1]);
                    }

                    votes[mt].Sort(SortType.XValues);

                    LineItem myCurve = pane.AddCurve(MatchTypes[mt], votes[mt], colors[mt]);
                    myCurve.Symbol.Fill = new Fill(Color.White);
                }

                // Manually set the x axis range
                pane.YAxis.Scale.Min = 0;
                pane.YAxis.Scale.Max = 10;
                pane.XAxis.Scale.Min = xdateMin;
                pane.XAxis.Scale.Max = xdateMax;

                if (xdateMin == xdateMax)
                {
                    pane.XAxis.Scale.Min -= 7;
                    pane.XAxis.Scale.Max += 7;
                }

                pane.YAxis.Scale.MajorStep = 2;
                pane.YAxis.Scale.MinorStep = 1;
                if (pane.YAxis.Scale.MajorStep == 0) pane.YAxis.Scale.MajorStep = 1;
                if (pane.YAxis.Scale.MinorStep == 0) pane.YAxis.Scale.MinorStep = 1;

                pane.XAxis.MajorGrid.IsVisible = true;
                pane.YAxis.MajorGrid.IsVisible = true;

                if (chkShowPosition.Checked) CreateBarLabels(pane);

                graphPerf.Refresh();
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                string info = "";
                info += "iActualPlayer:" + selectedPlayerID.ToString() + "\r\n";
                info += "cmbSeason.SelectedItem:" + cmbSeason.SelectedItem.ToString() + "\r\n";
                info += "Program.Setts.MatchTypes:" + Program.Setts.MatchTypes + "\r\n";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(Program.Setts.ApplicationFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                //GDT.WriteXml(fi.FullName);

                StreamReader file = new StreamReader(fi.FullName);
                info += "\r\nGDT:\r\n" + file.ReadToEnd();
                file.Close();

                plyStatsTable.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "\r\nplyStatsTable:\r\n" + file.ReadToEnd();
                file.Close();

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
            }
        }

        /// <summary>
        /// Create a TextLabel for each bar in the GraphPane.
        /// Call this method only after calling AxisChange()
        /// </summary>
        /// <remarks>
        /// This method will go through the bars, create a label that corresponds to the bar value,
        /// and place it on the graph depending on user preferences.  This works for horizontal or
        /// vertical bars in clusters or stacks.</remarks>
        /// <param name="pane">The GraphPane in which to place the text labels.</param>
        /// <param name="isBarCenter">true to center the labels inside the bars, false to
        /// place the labels just above the top of the bar.</param>
        /// <param name="valueFormat">The double.ToString string format to use for creating
        /// the labels
        /// </param>
        private void CreateBarLabels(GraphPane pane)
        {
            // Make the gap between the bars and the labels = 2% of the axis range
            float labelOffset = (float)(pane.YAxis.Scale.Max - pane.YAxis.Scale.Min) * 0.02f;

            // keep a count of the number of BarItems
            int curveIndex = 0;

            // Get a valuehandler to do some calculations for us
            ValueHandler valueHandler = new ValueHandler(pane, true);

            // Loop through each curve in the list
            foreach (CurveItem curve in pane.CurveList)
            {
                IPointList points = curve.Points;

                // Loop through each point in the BarItem
                for (int i = 0; i < points.Count; i++)
                {
                    double val = points[i].Y;
                    if (val == 0.0) continue;

                    // Get the high, low and base values for the current bar
                    // note that this method will automatically calculate the "effective"
                    // values if the bar is stacked
                    double baseVal, lowVal, hiVal;
                    valueHandler.GetValues(curve, i, out baseVal, out lowVal, out hiVal);

                    // Get the value that corresponds to the center of the bar base
                    // This method figures out how the bars are positioned within a cluster
                    float centerVal = (float)valueHandler.BarCenterValue(curve,
                        0, i, baseVal, curveIndex);

                    // Create a text label -- note that we have to go back to the original point
                    // data for this, since hiVal and lowVal could be "effective" values from a bar stack
                    string barLabelText = (string)points[i].Tag;

                    // Calculate the position of the label -- this is either the X or the Y coordinate
                    // depending on whether they are horizontal or vertical bars, respectively
                    float position;
                    position = (float)hiVal; // (hiVal + lowVal) / 2.0f;

                    // Create the new TextObj
                    float offset = 0.35f;
                    TextObj label = new TextObj(barLabelText.ToUpper(), centerVal, position - offset);

                    // Configure the TextObj
                    label.Location.Width = 1;
                    label.Location.CoordinateFrame = CoordType.AxisXYScale;
                    label.FontSpec.Size = 9;
                    label.FontSpec.FontColor = Color.Black;
                    label.FontSpec.Angle = 0;
                    label.Location.AlignH = AlignH.Center;
                    label.Location.AlignV = AlignV.Center;
                    label.FontSpec.Border.IsVisible = false;
                    label.FontSpec.Fill.IsVisible = false;

                    // Add the TextObj to the GraphPane
                    pane.GraphObjList.Add(label);
                }

                curveIndex++;
            }
        }

        private void FillPlayerInfo(bool reset)
        {
            scoutsNReviews.Scouts.Clear();

            foreach (NTR_SquadDb.ScoutRow sr in SquadDB.Scout)
            {
                ScoutsNReviews.ScoutsRow srn = scoutsNReviews.Scouts.NewScoutsRow();
                srn.Name = sr.Name;
                srn.Physical = sr.Phy;
                srn.Psychology = sr.Psy;
                srn.Development = sr.Dev;
                srn.Senior = sr.Sen;
                srn.Youth = sr.Yth;
                srn.Tactical = sr.Tac;
                srn.Technical = sr.Tec;
                scoutsNReviews.Scouts.AddScoutsRow(srn);
            }

            scoutsNReviews.Review.Clear();

            //scoutsNReviews.FillTables(selectedPlayerData, History.reportParser);

            //reviewDataTableBindingSource.Filter = "PlayerID=" + selectedPlayerData.playerID.ToString();

            //txtNotes.Text = selectedPlayerData.Note;

            //foreach (DataGridViewColumn col in dgReviews.Columns)
            //{
            //    if (col.GetType() == typeof(DataGridViewCustomColumns.TMR_ReportColumn))
            //    {
            //        DataGridViewCustomColumns.TMR_ReportColumn repCol = 
            //            (DataGridViewCustomColumns.TMR_ReportColumn)col;

            //        repCol.reportParser = History.reportParser;
            //        repCol.FPn = selectedPlayerData.FPn;
            //    }
            //}

            //if (!gRow.IsAggressivityNull())
            //    tagsBarAgg.Value = (decimal)gRow.Aggressivity / 2M;
            //else
            //    tagsBarAgg.Value = 0;

            //if (!gRow.IsProfessionalismNull())
            //    tagsBarPro.Value = (decimal)gRow.Professionalism / 2M;
            //else
            //    tagsBarPro.Value = 0;

            //if (!gRow.IsLeadershipNull())
            //    tagsBarLea.Value = (decimal)gRow.Leadership / 2M;
            //else
            //    tagsBarLea.Value = 0;

            //tagsBarPhy.Value = (decimal)gRow.Physics / 5M;
            //tagsBarTac.Value = (decimal)gRow.Tactics / 5M;
            //tagsBarTec.Value = (decimal)gRow.Technics / 5M;

            //string gameTable = "";
            //if (!gRow.IsGameTableNull())
            //    gameTable = gRow.GameTable;
            //gameTableDS.LoadSeasonsStrings(gameTable);

            //if (gRow.wBloomStart != -1) 
            //    BloomAgeView = (gRow.wBloomStart - gRow.wBorn) / 12;
            //else
            //    BloomAgeView = -1M;
        }

        private void FillASIGraph()
        {
            GraphPane pane = graphASI.GraphPane;
            pane.CurveList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "ASI History";
            pane.YAxis.Title.Text = "ASI";
            pane.Y2Axis.Title.Text = "Delta ASI";
            pane.XAxis.Title.Text = "Weeks";

            // Enter some random data values
            PointPairList dataASI = new PointPairList();
            PointPairList deltaASI = new PointPairList();

            double dDataASI;
            double xdate = 0.0;
            double xdelta = 0.0;
            double xdate0 = 0.0;
            double xdateN = 0.0;

            double dMax = 0.0;
            double dMin2 = 0.0;
            double dMax2 = 0.0;

            int deltaASIcount = 0;
            int lastASI = 0;
            double lastXdate = 0.0;

            int i = 0;
            foreach (NTR_SquadDb.HistDataRow pr in playerHistory)
            {
                dDataASI = pr.ASI;
                xdate = (double)new XDate(pr.Date);

                if (i == 0)
                {
                    lastASI = pr.ASI;
                    xdate0 = xdate;
                }

                if (lastASI != pr.ASI) deltaASIcount++;

                dMax = Math.Max(dMax, dDataASI);

                dataASI.Add(xdate, dDataASI);

                lastASI = pr.ASI;
                i++;
            }

            xdateN = xdate;

            int count = 0;

            i = 0;
            foreach (NTR_SquadDb.HistDataRow pr in playerHistory)
            {
                xdate = (double)new XDate(pr.Date);

                if (i == 0)
                {
                    lastASI = pr.ASI;
                    lastXdate = xdate;
                }

                if (lastASI == pr.ASI) continue;

                dDataASI = (double)(pr.ASI - lastASI);
                xdelta = Utility.TrainingWeeksInDates(XDate.XLDateToDateTime(lastXdate), XDate.XLDateToDateTime(xdate));
                if (xdelta == 0) xdelta = 1;

                dMax2 = Math.Max(dMax2, dDataASI / xdelta);
                dMin2 = Math.Min(dMin2, dDataASI / xdelta);
                deltaASI.Add(xdate, dDataASI / xdelta);

                lastASI = pr.ASI;
                lastXdate = xdate;

                count++;
                i++;
            }

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with "ASI" in the legend
            LineItem asiCurve = pane.AddCurve("ASI", dataASI, Color.Red);

            // Generate a red curve with "ASI" in the legend
            LineItem deltaAsiCurve = pane.AddCurve("Delta ASI", deltaASI, Color.Blue);
            deltaAsiCurve.IsY2Axis = true;
            deltaAsiCurve.YAxisIndex = 0;

            // Make the symbols opaque by filling them with white
            asiCurve.Symbol.Fill = new Fill(Color.White);

            // Show the x axis grid
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.MajorStep = 7;
            pane.XAxis.Scale.MinorStep = 7;
            pane.XAxis.Scale.MajorUnit = DateUnit.Day;
            pane.XAxis.Scale.Format = "TW";
            pane.XAxis.Scale.Min = xdate0;
            pane.XAxis.Scale.Max = xdateN;
            pane.XAxis.MajorGrid.IsVisible = true;

            // Manually set the x axis range
            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = (double)((int)(dMax / 100.0)) * 100.0 + 100;
            pane.YAxis.MajorTic.IsOpposite = false;
            pane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            pane.YAxis.MajorGrid.IsZeroLine = false;
            pane.YAxis.Scale.Align = AlignP.Inside;
            pane.YAxis.Scale.MajorStep = (double)((int)((dMax) / 10.0));
            pane.YAxis.Scale.MinorStep = (double)((int)(dMax / 50.0));
            if (pane.YAxis.Scale.MajorStep == 0) pane.YAxis.Scale.MajorStep = 1;
            if (pane.YAxis.Scale.MinorStep == 0) pane.YAxis.Scale.MinorStep = 1;

            pane.Y2Axis.IsVisible = true;
            pane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
            pane.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
            pane.Y2Axis.Color = Color.Orange;
            pane.Y2Axis.IsAxisSegmentVisible = true;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            pane.Y2Axis.MajorTic.IsOpposite = false;
            pane.Y2Axis.MinorTic.IsOpposite = false;
            pane.Y2Axis.Scale.Max = dMax2 + (dMax2 - dMin2) / 10.0;
            pane.Y2Axis.Scale.Min = dMin2 - (dMax2 - dMin2) / 10.0;
            pane.Y2Axis.Scale.Align = AlignP.Inside;
            pane.Y2Axis.MajorGrid.IsVisible = true;

            graphASI.AxisChange();
            graphASI.Refresh();
        }

        private void FillTIGraph()
        {
            string playerTIs = playerHistory.getTIs();

            WeekHistorical whTI = new WeekHistorical(playerTIs);

            DateTime firstTI = whTI.lastWeek.ToDate();

            GraphPane pane = graphTI.GraphPane;
            pane.CurveList.Clear();

            // Set the title and axis labels
            if (chkShowTGI.Checked)
            {
                pane.Title.Text = "TI and TGI History";
                pane.YAxis.Title.Text = "TI and TGI";
            }
            else
            {
                pane.Title.Text = "TI History";
                pane.YAxis.Title.Text = "TI";
            }
            pane.XAxis.Title.Text = "Weeks";

            // Enter some random data values
            PointPairList dataTI = new PointPairList();
            PointPairList dataTGI = new PointPairList();

            double dMax = 0.0;
            double dMin2 = 0.0;
            double dMax2 = 0.0;

            double xdate = 0.0;
            double xdate0 = 0.0;

            int tiCount = whTI.Count;
            int i = 0;
            for (; i < tiCount; i++)
            {
                double dDataTI = 0.0;

                if (float.IsNaN(whTI[i]))
                    continue;
                else
                    dDataTI = (double)(decimal)(whTI[i]);

                xdate = (double)new XDate(firstTI + TimeSpan.FromDays(7.0 * i));
                dataTI.Add(xdate, dDataTI);

                dMax = Math.Max(dMax, dDataTI);
            }

            int lastASI = 0;
            double lastXdate = 0.0;

            i = 0;
            if (chkShowTGI.Checked)
                foreach (NTR_SquadDb.HistDataRow pr in playerHistory)
                {
                    xdate = (double)new XDate(pr.Date);

                    if (i == 0)
                    {
                        lastASI = pr.ASI;
                        lastXdate = xdate;
                        xdate0 = xdate;
                    }

                    if (lastASI == pr.ASI) continue;

                    double dDataASI = (double)(pr.ASI - lastASI);
                    double xdelta = Utility.TrainingWeeksInDates(XDate.XLDateToDateTime(lastXdate), XDate.XLDateToDateTime(xdate));
                    if (xdelta == 0) continue;

                    double deltaASI = dDataASI / xdelta;
                    double TGI = deltaASI * 200 / ((pr.ASI + lastASI) / 2.0);
                    dataTGI.Add(xdate, TGI);

                    dMax2 = Math.Max(dMax2, TGI);
                    dMin2 = Math.Min(dMin2, TGI);

                    lastASI = pr.ASI;
                    lastXdate = xdate;

                    i++;
                }

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with "TI" in the legend
            LineItem myCurve1 = pane.AddCurve("TI", dataTI, Color.Red);

            LineItem myCurve2 = null;
            if (chkShowTGI.Checked)
                myCurve2 = pane.AddCurve("TGI", dataTGI, Color.Blue);

            // Make the symbols opaque by filling them with white
            myCurve1.Symbol.Fill = new Fill(Color.White);

            // Manually set the x axis range
            pane.YAxis.Scale.Min = 0;

            if (dataTI.Count > 0)
            {
                pane.XAxis.Scale.Min = dataTI[0].X;
                pane.XAxis.Scale.Max = dataTI[dataTI.Count - 1].X;
            }
            else
            {
                pane.XAxis.Scale.Min = double.MaxValue;
                pane.XAxis.Scale.Max = double.MinValue;
            }

            if (chkShowTGI.Checked)
                if (dataTGI.Count > 0)
                {
                    pane.XAxis.Scale.Min = Math.Min(dataTGI[0].X, pane.XAxis.Scale.Min);
                    pane.XAxis.Scale.Max = Math.Max(dataTGI[dataTGI.Count - 1].X, pane.XAxis.Scale.Max);
                }

            // Show the x axis grid
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.MajorStep = 7;
            pane.XAxis.Scale.MinorStep = 7;
            pane.XAxis.Scale.MajorUnit = DateUnit.Day;
            pane.XAxis.Scale.Format = "TW";
            pane.XAxis.MajorGrid.IsVisible = true;

            // Manually set the x axis range
            pane.YAxis.Scale.Min = dMin2;
            if (chkShowTGI.Checked)
                pane.YAxis.Scale.Max = Math.Max(dMax, dMax2);
            else
                pane.YAxis.Scale.Max = dMax;
            pane.YAxis.MajorTic.IsOpposite = false;
            pane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            pane.YAxis.MajorGrid.IsZeroLine = true;
            pane.YAxis.Color = Color.Orange;
            pane.YAxis.Scale.Align = AlignP.Inside;
            pane.YAxis.Scale.MajorStep = (double)((int)((pane.YAxis.Scale.Max) / 10.0));
            pane.YAxis.Scale.MinorStep = (double)((int)(pane.YAxis.Scale.MajorStep / 5.0));
            if (pane.YAxis.Scale.MajorStep == 0) pane.YAxis.Scale.MajorStep = 1;
            if (pane.YAxis.Scale.MinorStep == 0) pane.YAxis.Scale.MinorStep = 1;

            graphTI.AxisChange();
            graphTI.Refresh();
        }

        private void FillInjuriesGraph()
        {
            GraphPane pane = graphInjuries.GraphPane;
            pane.CurveList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "Injuries History";
            pane.YAxis.Title.Text = "Injuries Level";
            pane.XAxis.Title.Text = "Weeks";
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.MajorStep = 7;
            pane.XAxis.Scale.MinorStep = 7;
            pane.XAxis.Scale.MajorUnit = DateUnit.Day;
            pane.XAxis.Scale.Format = "TW";

            // Enter some random data values
            double[] dDataInj = new double[playerHistory.Count];
            double[] xdate = new double[playerHistory.Count];
            double dMin = 1.0;
            double dMax = -1.0;

            int i = 0;
            foreach(NTR_SquadDb.HistDataRow pr in playerHistory)
            {
                dDataInj[i] = (double)pr.Inj;
                xdate[i] = (double)new XDate(pr.Date);
                dMin = Math.Min(dMin, dDataInj[i]);
                dMax = Math.Max(dMax, dDataInj[i]);

                i++;
            }

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with "ASI" in the legend
            LineItem myCurve = pane.AddCurve("Injuries", xdate, dDataInj, Color.Red);

            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);

            // Manually set the x axis range
            pane.YAxis.Scale.Min = dMin - 1.0;
            pane.YAxis.Scale.Max = dMax + 1.0;
            pane.XAxis.Scale.Min = xdate[0];
            pane.XAxis.Scale.Max = xdate[xdate.Length - 1];

            pane.YAxis.Scale.MajorStep = (double)((int)((dMax) / 10.0));
            pane.YAxis.Scale.MinorStep = (double)((int)(dMax / 50.0));
            if (pane.YAxis.Scale.MajorStep == 0) pane.YAxis.Scale.MajorStep = 1;
            if (pane.YAxis.Scale.MinorStep == 0) pane.YAxis.Scale.MinorStep = 1;
        }

        private void FillBaseData(PlayerData selectedPlayer)
        {
            PlayerName = selectedPlayer.Name;

            Age = selectedPlayerData.Age;
            Wage = selectedPlayerData.Wage;

            UpdatePlayerRoutine();

            RoutineView = selectedPlayer.Rou;

            PrefPos = Tm_Utility.NumberToFP(selectedPlayer.FPn);
        }

        private void UpdatePlayerRoutine()
        {

        }

        private void FillPlayerData()
        {
            ASI = selectedPlayerData.ASI.actual;
        }

        internal void FillSkillGraphGk()
        {
            MasterPane master = graphSkills.MasterPane;

            // Remove the default pane that comes with the ZedGraphControl.MasterPane
            master.PaneList.Clear();

            // Set the master pane title
            master.Title.Text = "Player History";
            master.Title.IsVisible = true;

            // Fill the axis background with a color gradient
            master.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Set the margins and the space between panes to 10 points
            master.Margin.All = 10;
            master.InnerPaneGap = 10;

            int historyDataCount = playerHistory.Count;

            double[] dDataFor = new double[historyDataCount];
            double[] dDataVel = new double[historyDataCount];
            double[] dDataRes = new double[historyDataCount];
            double[] dDataPre = new double[historyDataCount];
            double[] dDataUno = new double[historyDataCount];
            double[] dDataRif = new double[historyDataCount];
            double[] dDataAer = new double[historyDataCount];
            double[] dDataEle = new double[historyDataCount];
            double[] dDataCom = new double[historyDataCount];
            double[] dDataTir = new double[historyDataCount];
            double[] dDataLan = new double[historyDataCount];
            double[] xdate = new double[historyDataCount];

            int i = 0;
            foreach (NTR_SquadDb.HistDataRow pr in playerHistory)
            {
                dDataFor[i] = (double)pr.For;
                dDataVel[i] = (double)pr.Vel;
                dDataRes[i] = (double)pr.Res;
                dDataPre[i] = (double)pr.Pre;
                dDataUno[i] = (double)pr.Uno;
                dDataRif[i] = (double)pr.Rif;
                dDataAer[i] = (double)pr.Aer;
                dDataEle[i] = (double)pr.Ele;
                dDataCom[i] = (double)pr.Com;
                dDataTir[i] = (double)pr.Tir;
                dDataLan[i] = (double)pr.Lan;
                xdate[i] = (double)new XDate(pr.Date);

                i++;
            }

            LineItem myCurve;

            // 1o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Physic Skills";
                pane.YAxis.Title.Text = "Skill Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "For" in the legend
                myCurve = pane.AddCurve("For", xdate, dDataFor, Color.DarkGreen);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Res" in the legend
                myCurve = pane.AddCurve("Res", xdate, dDataRes, Color.Indigo);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Vel" in the legend
                myCurve = pane.AddCurve("Vel", xdate, dDataVel, Color.Turquoise);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.Min = 0;
                pane.YAxis.Scale.Max = 20;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // 2o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Goal Defense Skills";
                pane.YAxis.Title.Text = "Skill Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "Pre" in the legend
                myCurve = pane.AddCurve("Pre", xdate, dDataPre, Color.Blue);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Uno" in the legend
                myCurve = pane.AddCurve("Uno", xdate, dDataUno, Color.Green);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Rif" in the legend
                myCurve = pane.AddCurve("Rif", xdate, dDataRif, Color.Brown);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.Min = 0;
                pane.YAxis.Scale.Max = 20;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // 3o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Area Defense Skills";
                pane.YAxis.Title.Text = "Skill Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "Aer" in the legend
                myCurve = pane.AddCurve("Aer", xdate, dDataAer, Color.Black);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Ele" in the legend
                myCurve = pane.AddCurve("Ele", xdate, dDataEle, Color.Cyan);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.Min = 0;
                pane.YAxis.Scale.Max = 20;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // 4o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Offensive Skills";
                pane.YAxis.Title.Text = "Skill Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "Com" in the legend
                myCurve = pane.AddCurve(Current.Language.Com, xdate, dDataCom, Color.Blue);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Tir" in the legend
                myCurve = pane.AddCurve("Tir", xdate, dDataTir, Color.Red);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Square;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Lan" in the legend
                myCurve = pane.AddCurve("Lan", xdate, dDataLan, Color.SlateGray);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.Min = 0;
                pane.YAxis.Scale.Max = 20;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // Tell ZedGraph to auto layout all the panes
            using (Graphics g = graphSkills.CreateGraphics())
            {
                master.SetLayout(g, PaneLayout.SquareColPreferred);
                master.AxisChange(g);
            }
        }

        internal void FillSkillGraphPlayer()
        {
            MasterPane master = graphSkills.MasterPane;

            // Remove the default pane that comes with the ZedGraphControl.MasterPane
            master.PaneList.Clear();

            // Set the master pane title
            master.Title.Text = "Player History";
            master.Title.IsVisible = true;

            // Fill the axis background with a color gradient
            master.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Set the margins and the space between panes to 10 points
            master.Margin.All = 10;
            master.InnerPaneGap = 10;

            int historyDataCount = playerHistory.Count;

            double[] dDataCal = new double[historyDataCount];
            double[] dDataCon = new double[historyDataCount];
            double[] dDataCro = new double[historyDataCount];
            double[] dDataFin = new double[historyDataCount];
            double[] dDataFor = new double[historyDataCount];
            double[] dDataHea = new double[historyDataCount];
            double[] dDataMar = new double[historyDataCount];
            double[] dDataPas = new double[historyDataCount];
            double[] dDataPos = new double[historyDataCount];
            double[] dDataRes = new double[historyDataCount];
            double[] dDataTec = new double[historyDataCount];
            double[] dDataTir = new double[historyDataCount];
            double[] dDataVel = new double[historyDataCount];
            double[] dDataWor = new double[historyDataCount];
            double[] xdate = new double[historyDataCount];

            int i = 0;
            foreach (NTR_SquadDb.HistDataRow pr in playerHistory)
            {
                dDataCal[i] = (double)pr.Cal;
                dDataCon[i] = (double)pr.Con;
                dDataCro[i] = (double)pr.Cro;
                dDataFin[i] = (double)pr.Fin;
                dDataFor[i] = (double)pr.For;
                dDataHea[i] = (double)pr.Tes;
                dDataMar[i] = (double)pr.Mar;
                dDataPas[i] = (double)pr.Pas;
                dDataPos[i] = (double)pr.Pos;
                dDataRes[i] = (double)pr.Res;
                dDataTec[i] = (double)pr.Tec;
                dDataTir[i] = (double)pr.Tir;
                dDataVel[i] = (double)pr.Vel;
                dDataWor[i] = (double)pr.Wor;
                xdate[i] = (double)new XDate(pr.Date);

                i++;
            }

            LineItem myCurve;

            // 1o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Physic Skills";
                pane.YAxis.Title.Text = "Skill Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "For" in the legend
                myCurve = pane.AddCurve("Str", xdate, dDataFor, Color.DarkGreen);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Res" in the legend
                myCurve = pane.AddCurve("Sta", xdate, dDataRes, Color.Indigo);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Vel" in the legend
                myCurve = pane.AddCurve("Pac", xdate, dDataVel, Color.Turquoise);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.Min = 0;
                pane.YAxis.Scale.Max = 20;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // 2o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Defensive Skills";
                pane.YAxis.Title.Text = "Skill Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "Mar" in the legend
                myCurve = pane.AddCurve("Mar", xdate, dDataMar, Color.Brown);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Tak" in the legend
                myCurve = pane.AddCurve("Tak", xdate, dDataCon, Color.Blue);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Cro" in the legend
                myCurve = pane.AddCurve("Cro", xdate, dDataCro, Color.Green);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Hea" in the legend
                myCurve = pane.AddCurve("Head", xdate, dDataHea, Color.Green);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.Min = 0;
                pane.YAxis.Scale.Max = 20;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // 3o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Midfielder Skills";
                pane.YAxis.Title.Text = "Skill Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "Pas" in the legend
                myCurve = pane.AddCurve("Pas", xdate, dDataPas, Color.Black);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Pos" in the legend
                myCurve = pane.AddCurve("Pos", xdate, dDataPos, Color.Cyan);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Tec" in the legend
                myCurve = pane.AddCurve("Tec", xdate, dDataTec, Color.Violet);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Square;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Wor" in the legend
                myCurve = pane.AddCurve("Wor", xdate, dDataWor, Color.Orange);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.Min = 0;
                pane.YAxis.Scale.Max = 20;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // 4o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Attack Skills";
                pane.YAxis.Title.Text = "Skill Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "Fin" in the legend
                myCurve = pane.AddCurve("Fin", xdate, dDataFin, Color.Blue);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Set" in the legend
                myCurve = pane.AddCurve("Set", xdate, dDataCal, Color.Red);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Square;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Tir" in the legend
                myCurve = pane.AddCurve("Tir", xdate, dDataTir, Color.SlateGray);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Hea" in the legend
                myCurve = pane.AddCurve("Head", xdate, dDataHea, Color.Green);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.Min = 0;
                pane.YAxis.Scale.Max = 20;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // Tell ZedGraph to auto layout all the panes
            using (Graphics g = graphSkills.CreateGraphics())
            {
                master.SetLayout(g, PaneLayout.SquareColPreferred);
                master.AxisChange(g);
            }
        }

        internal void FillSpecsGraphGk()
        {
            MasterPane master = graphSpecs.MasterPane;

            // Remove the default pane that comes with the ZedGraphControl.MasterPane
            master.PaneList.Clear();

            // Set the master pane title
            master.Title.Text = "Specialities History";
            master.Title.IsVisible = true;

            // Fill the axis background with a color gradient
            master.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Set the margins and the space between panes to 10 points
            master.Margin.All = 10;
            master.InnerPaneGap = 10;

            int historyDataCount = playerHistory.Count;

            double[] dGK = new double[historyDataCount];
            double[] xdate = new double[historyDataCount];

            int i = 0;
            foreach (NTR_SquadDb.HistDataRow ph in playerHistory)
            {
                PlayerData pr = new PlayerData(ph, -1);
                dGK[i] = (double)pr.GK;
                xdate[i] = (double)new XDate(ph.Date);

                i++;
            }

            LineItem myCurve;

            // 1o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "GK Speciality";
                pane.YAxis.Title.Text = "Specs Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

                // Generate a red curve with "For" in the legend
                myCurve = pane.AddCurve("GK", xdate, dGK, Color.DarkGreen);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // Tell ZedGraph to auto layout all the panes
            using (Graphics g = graphSkills.CreateGraphics())
            {
                master.SetLayout(g, PaneLayout.SquareColPreferred);
                master.AxisChange(g);
            }
        }

        internal void FillSpecsGraphPlayer()
        {
            MasterPane master = graphSpecs.MasterPane;

            // Remove the default pane that comes with the ZedGraphControl.MasterPane
            master.PaneList.Clear();

            // Set the master pane title
            master.Title.Text = "Specialities History";
            master.Title.IsVisible = true;

            // Fill the axis background with a color gradient
            master.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Set the margins and the space between panes to 10 points
            master.Margin.All = 10;
            master.InnerPaneGap = 10;

            int historyDataCount = playerHistory.Count;

            double[] dDC = new double[historyDataCount];
            double[] dDL = new double[historyDataCount];
            double[] dDR = new double[historyDataCount];
            double[] dDMC = new double[historyDataCount];
            double[] dDML = new double[historyDataCount];
            double[] dDMR = new double[historyDataCount];
            double[] dMC = new double[historyDataCount];
            double[] dML = new double[historyDataCount];
            double[] dMR = new double[historyDataCount];
            double[] dOMC = new double[historyDataCount];
            double[] dOML = new double[historyDataCount];
            double[] dOMR = new double[historyDataCount];
            double[] dFC = new double[historyDataCount];
            double[] xdate = new double[historyDataCount];

            int i = 0;
            foreach (NTR_SquadDb.HistDataRow ph in playerHistory)
            {
                PlayerData pr = new PlayerData(ph, -1);
                dDC[i] = (double)pr.DC;
                dDL[i] = (double)pr.DL;
                dDR[i] = (double)pr.DR;
                dDMC[i] = (double)pr.DMC;
                dDML[i] = (double)pr.DML;
                dDMR[i] = (double)pr.DMR;
                dMC[i] = (double)pr.MC;
                dML[i] = (double)pr.ML;
                dMR[i] = (double)pr.MR;
                dOMC[i] = (double)pr.OMC;
                dOML[i] = (double)pr.OML;
                dOMR[i] = (double)pr.OMR;
                dFC[i] = (double)pr.FC;
                xdate[i] = (double)new XDate(ph.Date);

                i++;
            }

            LineItem myCurve;

            // 1o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Defensive Specs";
                pane.YAxis.Title.Text = "Specs Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "For" in the legend
                myCurve = pane.AddCurve("DC", xdate, dDC, Color.DarkGreen);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Res" in the legend
                myCurve = pane.AddCurve("DL", xdate, dDL, Color.Indigo);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Vel" in the legend
                myCurve = pane.AddCurve("DR", xdate, dDR, Color.Turquoise);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                //pane.YAxis.Scale.Min = 0;
                //pane.YAxis.Scale.Max = 100;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // 2o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Defence/Midfield Specs";
                pane.YAxis.Title.Text = "Specs Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "Con" in the legend
                myCurve = pane.AddCurve("DMC", xdate, dDMC, Color.DarkGreen);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Cal" in the legend
                myCurve = pane.AddCurve("DML", xdate, dDML, Color.Indigo);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Mar" in the legend
                myCurve = pane.AddCurve("DMR", xdate, dDMR, Color.Turquoise);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                //pane.YAxis.Scale.Min = 0;
                //pane.YAxis.Scale.Max = 100;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // 3o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Midfielder Skills";
                pane.YAxis.Title.Text = "Skill Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "Con" in the legend
                myCurve = pane.AddCurve("MC", xdate, dMC, Color.DarkGreen);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Cal" in the legend
                myCurve = pane.AddCurve("ML", xdate, dML, Color.Indigo);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Mar" in the legend
                myCurve = pane.AddCurve("MR", xdate, dMR, Color.Turquoise);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                //pane.YAxis.Scale.Min = 0;
                //pane.YAxis.Scale.Max = 100;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // 4o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Attack Skills";
                pane.YAxis.Title.Text = "Skill Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "Con" in the legend
                myCurve = pane.AddCurve("OMC", xdate, dOMC, Color.DarkGreen);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Cal" in the legend
                myCurve = pane.AddCurve("OML", xdate, dOML, Color.Indigo);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Mar" in the legend
                myCurve = pane.AddCurve("OMR", xdate, dOMR, Color.Turquoise);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Mar" in the legend
                myCurve = pane.AddCurve("FC", xdate, dFC, Color.Orange);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.XCross;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                //pane.YAxis.Scale.Min = 0;
                //pane.YAxis.Scale.Max = 100;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // Tell ZedGraph to auto layout all the panes
            using (Graphics g = graphSkills.CreateGraphics())
            {
                master.SetLayout(g, PaneLayout.SquareColPreferred);
                master.AxisChange(g);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            selectedPlayerIndex++;

            if (selectedPlayerIndex > thisWeekPlayersIDs.Count() - 1)
            {
                selectedPlayerIndex = 0;
            }

            Initialize(thisWeekPlayersIDs[selectedPlayerIndex]);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            selectedPlayerIndex--;

            if (selectedPlayerIndex < 0)
            {
                selectedPlayerIndex = thisWeekPlayersIDs.Count() - 1;
            }

            Initialize(thisWeekPlayersIDs[selectedPlayerIndex]);
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            playerInfoChanged = true;
        }

        private void playersMainPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("http://trophymanager.com/players/" + selectedPlayerID);
        }

        private void playersScoutPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("http://trophymanager.com/players/" + selectedPlayerID + "/#/page/scout/");
        }

        private void openPlayerPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPlayerBrowser;
            tsbLoadPlayerPage_Click(sender, e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string arg = "http://trophymanager.com/club/11816/";

            if (Program.Setts.UseTMRBrowser)
            {
                string processName = Application.StartupPath + "/TMRBrowser.exe";
                FileInfo fi = new FileInfo(processName);

                if (!fi.Exists)
                    MessageBox.Show(Current.Language.TheTMRBrowserTMRBrowserExeDoesnTExistAtTheGivenPath +
                        Application.StartupPath + ")", "TM Recorder", MessageBoxButtons.OK);
                else
                    Process.Start(processName, arg);
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(arg);
                Process.Start(startInfo);
            }
        }

        private void chkShowTGI_CheckedChanged(object sender, EventArgs e)
        {
            FillTIGraph();
            Program.Setts.ShowTGI = chkShowTGI.Checked;
            Program.Setts.Save();
        }

        private void exportInExcelFormat_Click(object sender, EventArgs e)
        {
            //ExtTMDataSet.GiocatoriNSkillRow playerDatarow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.Rows[iActualPlayer];
            //ExtTMDataSet.PlayerHistoryDataTable table = History.GetPlayerHistory(playerDatarow.PlayerID);
            //ExtraDS.GiocatoriRow gRow = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);
            //WeekHistorical whTI = new WeekHistorical(gRow.TSI);
            //WeekHistorical whASI = new WeekHistorical(whTI.lastWeek);

            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    ExtTMDataSet.PlayerHistoryRow pr = (ExtTMDataSet.PlayerHistoryRow)table.Rows[i];
            //    whASI.Set(pr.Date, pr.ASI);
            //}

            //int iniWeek = Math.Min(whASI.lastWeek.absweek, whTI.lastWeek.absweek);
            //int thisWeek = TmWeek.thisWeek().absweek;

            //string dates = TmWeek.GenerateDatesString(iniWeek, thisWeek, '\t');
            //string asiHist = whASI.GenerateHistoryString(iniWeek, thisWeek, '\t');
            //string tiHist = whTI.GenerateHistoryString(iniWeek, thisWeek, '\t');

            //Clipboard.SetText("Date\t" + dates +
            //    "\r\nASI\t" + asiHist +
            //    "\r\nTI\t" + tiHist);

            //MessageBox.Show("The history of the player has been copied into the clipboard. \n" +
            //    "Open now Excel and paste into a sheet", "Copy to Excel");
        }

        private void chkNormalized_CheckedChanged(object sender, EventArgs e)
        {
            FillMatchStatsGraph(plyStatsTable);

            if (chkNormalized.Checked)
            {
                chkNormalized.Text = "Normalized (ON)";
            }
            else
            {
                chkNormalized.Text = "Normalized (OFF)";
            }

            if (chkShowPosition.Checked)
            {
                chkShowPosition.Text = "Show Position (ON)";
            }
            else
            {
                chkShowPosition.Text = "Show Position (OFF)";
            }

            Program.Setts.ShowStatsNormalized = chkNormalized.Checked;
            Program.Setts.ShowPosition = chkShowPosition.Checked;
            Program.Setts.Save();
        }

        private void cmbSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkNormalized_CheckedChanged(null, EventArgs.Empty);
        }

        private void tsbComputeGrowth_Click(object sender, EventArgs e)
        {
            ComputeBloom cb = new ComputeBloom();

            cb.ActualASI = selectedPlayerData.ASI.actual;
            cb.CurrentSkillSum = (decimal)Tm_Utility.ASItoSkSum((float)cb.ActualASI, false);
            cb.RealSkillSum = selectedPlayerData.SkillSum.actual;

            WeekHistorical whTI = new WeekHistorical(playerHistory.getTIs());
            if (!float.IsNaN(whTI.ActualTI))
                cb.ActualTI = (decimal)whTI.ActualTI;
            else
                cb.ActualTI = 0;

            cb.PlayerNameAndID = selectedPlayerData.Name + "\n(" + selectedPlayerData.playerID.ToString() + ")";

            if (selectedPlayerData.wBloomStart == -1)
            {
                selectedPlayerData.wBloomStart = whTI.FindBloomStart();

                cb.AgeStartOfBloom = (selectedPlayerData.wBloomStart - selectedPlayerData.wBorn) / 12;
                cb.ExplosionTI = selectedPlayerData.ExplosionTI;
                cb.AfterBloomingTI = selectedPlayerData.AfterBloomTI;
                cb.BeforeExplosionTI = selectedPlayerData.BeforeExplTI;
            }
            else
            {
                cb.AgeStartOfBloom = (selectedPlayerData.wBloomStart - selectedPlayerData.wBorn) / 12;
                cb.ExplosionTI = selectedPlayerData.ExplosionTI;
                cb.AfterBloomingTI = selectedPlayerData.AfterBloomTI;
                cb.BeforeExplosionTI = selectedPlayerData.BeforeExplTI;
            }

            int savedBloomStart = cb.AgeStartOfBloom;

            cb.isGK = false;
            cb.PlayerBornWeek = selectedPlayerData.wBorn;
            cb.ShowDialog();

            if ((savedBloomStart != cb.AgeStartOfBloom) ||
                (selectedPlayerData.ExplosionTI != cb.ExplosionTI) ||
                (selectedPlayerData.AfterBloomTI != cb.AfterBloomingTI) ||
                (selectedPlayerData.BeforeExplTI != cb.BeforeExplosionTI))
            {
                selectedPlayerData.wBloomStart = selectedPlayerData.wBorn + cb.AgeStartOfBloom * 12;
                selectedPlayerData.ExplosionTI = cb.ExplosionTI;
                selectedPlayerData.AfterBloomTI = cb.AfterBloomingTI;
                selectedPlayerData.BeforeExplTI = cb.BeforeExplosionTI;
                selectedPlayerData.isBloomDataDirty = true;
                isDirty = true;
            }
            selectedPlayerData.isBloomDataDirty = true;
            selectedPlayerData.Asi25 = (decimal)(int)cb.ASI25;
            selectedPlayerData.Asi30 = (decimal)(int)cb.ASI30;
        }

        private void btnGetVotenSkillAuto_Click(object sender, EventArgs e)
        {
            //ExtTMDataSet.GiocatoriNSkillRow playerDatarow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.Rows[iActualPlayer];

            //FileInfo fi = new FileInfo(Program.Setts.ReportAnalysisFile);

            //ReportAnalysis.Clear();
            //if (fi.Exists)
            //    ReportAnalysis.ReadXml(Program.Setts.ReportAnalysisFile);

            //History.PlayersDS.ParseScoutReviewForHiddenData(ReportAnalysis, playerDatarow.PlayerID);
            //SetTraining();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void chkNormalized_Click(object sender, EventArgs e)
        {
        }

        private void whatToDoHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Set here which is the potential of your player as is indicated from the scouts.\n" +
                "Remember that each scout has the a different ability of reviewing a skill of player, \n" +
                "so set the potential accordingly. These values will be used to find which is the best \n" +
                "training program for your player.");
        }

        private void getPotentialForThisPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ExtTMDataSet.GiocatoriNSkillRow playerDatarow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.Rows[iActualPlayer];

            //FileInfo fi = new FileInfo(Program.Setts.ReportAnalysisFile);

            //ReportAnalysis.Clear();
            //if (fi.Exists)
            //    ReportAnalysis.ReadXml(Program.Setts.ReportAnalysisFile);

            //History.PlayersDS.ParseScoutReviewForHiddenData(ReportAnalysis, playerDatarow.PlayerID);
            //SetTraining();
        }

        string navigationAddress = "";
        string startnavigationAddress = "";
        private void tsbLoadPlayerPage_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/players/" + selectedPlayerID.ToString() + "/#/page/history/";
            if (navigationType == NavigationType.NavigateReports)
                navigationAddress += "/#/page/scout/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        #region Player Profiles Navigation
        enum NavigationType
        {
            NavigateProfiles,
            NavigateReports
        }

        NavigationType navigationType = NavigationType.NavigateProfiles;
        int lastBarPlayer = 0;

        private void ChangePlayer_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsi = (ToolStripMenuItem)sender;
            int changeID = (int)tsi.Tag;
            Initialize(changeID);

            if (tabControl1.SelectedTab == tabPlayerBrowser)
            {
                tsbLoadPlayerPage_Click(sender, e);
            }
            else
            {
                FillPlayerBar(changeID);
            }
        }
        #endregion

        private void tsbImport_Click(object sender, EventArgs e)
        {
            string doctext = "";

            if (startnavigationAddress == "") return;

            HtmlElementCollection hmtlElColl = webBrowser.Document.All;

            string str = "";
            int cnt = 0;
            foreach (HtmlElement he in hmtlElColl)
            {
                cnt++;
                str += cnt.ToString() + ") InnerHtml = " + he.InnerHtml + "\n";
                str += cnt.ToString() + ") OuterHtml = " + he.OuterHtml + "\n\n";
            }

            try
            {
                if (HTML_Parser.GetNumberAfter(startnavigationAddress, "http://trophymanager.com/players/") != "-1")
                {
                    doctext = webBrowser.Document.Body.InnerHtml;
                }
                else
                {
                    doctext = webBrowser.DocumentText;
                }
            }
            catch (FileNotFoundException)
            {
                doctext = "";
            }

            if (doctext == "")
            {
                foreach (HtmlElement hel in webBrowser.Document.All)
                {
                    if (hel.InnerHtml != null)
                        doctext += hel.InnerHtml;
                }
            }

            string page = doctext;

            SaveImportedFile(page, webBrowser.Url);

            if (HTML_Parser.GetNumberAfter(startnavigationAddress, "http://trophymanager.com/players/") != "-1")
                page = "SourceURL:<TM - Showprofile>\n" + page;
            else
            {
                if (MessageBox.Show("Cannot import this page here. Here you can import only player profiles.\n" +
                    "Pressing OK, you send a report to Atletico Granata that will try to detect the reason of the error.",
                    "Import error", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string swRelease = "Sw Release:" + Application.ProductName + "("
                       + Application.ProductVersion + ")";
                    page = "Navigation Address: " + startnavigationAddress + "\n" + page;
                    Exception ex = new Exception("Navigation error");
                    SendFileTo.ErrorReport.Send(ex, page, Environment.StackTrace, swRelease);
                }
                return;
            }

            if (!page.Contains("TM - Showprofile"))
            {
                return;
            }

            //ExtTMDataSet.GiocatoriNSkillRow playerDatarow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.Rows[iActualPlayer];
            //ExtraDS.GiocatoriRow gRow = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);

            //ExtraDS.ParsePlayerPage_NewTM(page, ref gRow, History.reportParser);

            //// Aggiorna i dati di basi
            //playerDatarow.FP = gRow.FP;
            //gRow.FPn = Tm_Utility.FPToNumber(gRow.FP);
            //playerDatarow.FPn = gRow.FPn;
            //FillBaseData(playerDatarow);

            //isDirty = true;

            //ExtTMDataSet.PlayerHistoryDataTable table = History.GetPlayerHistory(playerDatarow.PlayerID);
            //// FillTIGraph(table);

            //gRow.SetAddedSkill(scoutsNReviews, History.reportParser);

            //gRow.ComputeBloomingFromGiudizio(scoutsNReviews);

            //FillPlayerInfo(false);

            //SetTraining();

            //gRow.isDirty = true;
        }

        private void navigateProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbNavigationType.Text = navigateProfilesToolStripMenuItem.Text;
            tsbNavigationType.Image = navigateProfilesToolStripMenuItem.Image;

            if (navigationType != NavigationType.NavigateProfiles)
            {
                navigationType = NavigationType.NavigateProfiles;
                navigationAddress = "http://trophymanager.com/players/" +
                    selectedPlayerID.ToString();
                webBrowser.Navigate(navigationAddress);
                startnavigationAddress = navigationAddress;
            }
        }

        private void navigateReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbNavigationType.Text = navigateReportsToolStripMenuItem.Text;
            tsbNavigationType.Image = navigateReportsToolStripMenuItem.Image;

            if (navigationType != NavigationType.NavigateReports)
            {
                navigationType = NavigationType.NavigateReports;
                navigationAddress = "http://trophymanager.com/players/" +
                    selectedPlayerID.ToString() + "/#/page/scout/";
                webBrowser.Navigate(navigationAddress);
                startnavigationAddress = navigationAddress;
            }
        }

        #region WebBrowser Navigation
        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress <= 0)
            {
                if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
                {
                    tsbProgressText.Text = "100%";
                    tsbProgressBar.ForeColor = Color.Green;
                    tsbProgressBar.Value = 100;
                }
                return;
            }

            int maxProgress = (int)e.MaximumProgress;
            if (maxProgress == 0) maxProgress = 1;
            int perc = (int)((e.CurrentProgress * 100) / maxProgress);
            if (perc < 0) perc = 0;
            if (perc > 100) perc = 100;
            tsbProgressBar.Value = perc;
            tsbProgressText.Text = perc.ToString() + "%";
            tsbProgressBar.ForeColor = Color.Blue;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString() != navigationAddress) return;

            // this.Text = "TMR Browser - Navigation Complete";
            tsbProgressBar.ForeColor = Color.Green;
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString().StartsWith("http://trophymanager.com/livematch.php?matchid="))
            {
                string kampid = e.Url.ToString().Split('=')[1];
                navigationAddress = "http://trophymanager.com/matches/" + kampid + "/";
                webBrowser.Navigate(navigationAddress);
                startnavigationAddress = navigationAddress;
            }
            else if (e.Url.ToString().StartsWith("http://trophymanager.com/"))
            {
                navigationAddress = e.Url.ToString();
                startnavigationAddress = navigationAddress;

                if (startnavigationAddress.Contains("trophymanager.com/players/"))
                {

                    lastBarPlayer = int.Parse(HTML_Parser.GetNumberAfter(startnavigationAddress, "trophymanager.com/players/"));

                    if (lastBarPlayer != -1)
                        FillPlayerBar(lastBarPlayer);
                    tsBrowsePlayers.Visible = true;
                }
                else
                {
                    tsBrowsePlayers.Visible = false;
                }
            }
            else
            {
                navigationAddress = e.Url.ToString();
            }

            tsbProgressBar.Value = 0;
            tsbProgressText.Text = "0%";
            tsbProgressBar.ForeColor = Color.Blue;
        }

        private void FillPlayerBar(int playerID)
        {
            //ExtTMDataSet.GiocatoriNSkillRow gRow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.FindByPlayerID(playerID);

            //if (gRow == null)
            //{
            //    tsBrowsePlayers.Visible = false;
            //    return;
            //}

            //tsBrowsePlayers.Visible = true;

            //tsbNumberOfReviews.Text = gRow.ScoutReviews.Length + " Scout Reviews stored";

            //tsbPlayers.Text = "[" + gRow.FP + "] " + gRow.Nome.Split('|')[0];

            //AddMenuItem(tsbPlayers, "", null);
            //for (int i = 0; i < GDT.Count; i++)
            //{
            //    ToolStripItem tsi = new ToolStripMenuItem();
            //    tsi.Text = "[" + GDT[i].FP + "] " + GDT[i].Nome.Split('|')[0];
            //    tsi.Tag = GDT[i].PlayerID;
            //    tsi.Click += ChangePlayer_Click;
            //    AddMenuItem(tsbPlayers, GDT[i].FP, tsi);
            //}
        }
        #endregion

        private void SaveImportedFile(string page, Uri url)
        {
            // Check the existence of the folder
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.DefaultDirectory, "ImportedPages"));
            if (!di.Exists)
            {
                di.Create();
            }

            string filedate = TmWeek.ToSWDString(DateTime.Now);

            string filename = url.LocalPath.Replace(".php", "").Replace("/", "");

            if (filename == "showprofile")
            {
                string playerid = HTML_Parser.GetNumberAfter(url.ToString(), "playerid=");
                filename += "_" + playerid + "_" + filedate + ".htm";
            }

            FileInfo fi = new FileInfo(Path.Combine(di.FullName, filename));

            StreamWriter file = new StreamWriter(fi.FullName);
            file.Write(page);
            file.Close();
        }

        private void AddMenuItem(ToolStripDropDownButton tsbPlayers, string FP, ToolStripItem tsi)
        {
            if (tsi == null)
            {
                // gKToolStripMenuItem.DropDownItems.Clear();
                dDefendersToolStripMenuItem.DropDownItems.Clear();
                dMDefenderMidfieldersToolStripMenuItem.DropDownItems.Clear();
                mMidfieldersToolStripMenuItem.DropDownItems.Clear();
                oMOffenderMidfieldersToolStripMenuItem.DropDownItems.Clear();
                fForwardsToolStripMenuItem.DropDownItems.Clear();
                return;
            }

            string[] fps = FP.Split('/');

            foreach (string fp in fps)
            {
                ToolStripItem itsi = new ToolStripMenuItem();
                itsi.Click += ChangePlayer_Click;
                itsi.Text = tsi.Text;
                itsi.Tag = tsi.Tag;

                if (fp == "GK")
                {
                    // gKToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if ((fp == "DC") || (fp == "DL") || (fp == "DR"))
                {
                    if (!FindItemInMenu(dDefendersToolStripMenuItem, itsi.Text))
                        dDefendersToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if ((fp == "DMC") || (fp == "DML") || (fp == "DMR"))
                {
                    if (!FindItemInMenu(dMDefenderMidfieldersToolStripMenuItem, itsi.Text))
                        dMDefenderMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if ((fp == "MC") || (fp == "ML") || (fp == "MR"))
                {
                    if (!FindItemInMenu(mMidfieldersToolStripMenuItem, itsi.Text))
                        mMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if ((fp == "OMC") || (fp == "OML") || (fp == "OMR"))
                {
                    if (!FindItemInMenu(oMOffenderMidfieldersToolStripMenuItem, itsi.Text))
                        oMOffenderMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if (fp == "FC")
                {
                    fForwardsToolStripMenuItem.DropDownItems.Add(itsi);
                }
            }
        }

        private bool FindItemInMenu(ToolStripMenuItem menu, string text)
        {
            bool found = false;
            foreach (ToolStripItem ftsi in menu.DropDownItems)
            {
                if (ftsi.Text == text)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            Rectangle pos = Program.Setts.PlayerFormPosition;

            if (pos.Height + pos.Width > 0)
                this.SetDesktopBounds(pos.X, pos.Y, pos.Width, pos.Height);

            PlayerForm_SizeChanged(this, EventArgs.Empty);
        }

        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Rectangle pos = new Rectangle(DesktopBounds.X, DesktopBounds.Y, DesktopBounds.Width, DesktopBounds.Height);
            Program.Setts.PlayerFormPosition = pos;
            Program.Setts.Save();
        }

        private void reviewDataTableBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void PlayerForm_SizeChanged(object sender, EventArgs e)
        {
            tagsBarPhy.Left = 0;
            tagsBarTac.Left = tabPlayerScouting.Width/6;
            tagsBarTec.Left = 2*tabPlayerScouting.Width / 6;
            tagsBarLea.Left = 3 * tabPlayerScouting.Width / 6;
            tagsBarAgg.Left = 4* tabPlayerScouting.Width / 6;
            tagsBarPro.Left = 5 * tabPlayerScouting.Width / 6;

            tagsBarPhy.Width = tabPlayerScouting.Width / 6;
            tagsBarTac.Width = tabPlayerScouting.Width / 6;
            tagsBarTec.Width = tabPlayerScouting.Width / 6;
            tagsBarLea.Width = tabPlayerScouting.Width / 6;
            tagsBarAgg.Width = tabPlayerScouting.Width / 6;
            tagsBarPro.Width = tabPlayerScouting.Width / 6;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPlayerScouting)
                PlayerForm_SizeChanged(this, EventArgs.Empty);
        }
    }

    public class PlayerHistory: List<NTR_SquadDb.HistDataRow>
    {
        public PlayerHistory(List<NTR_SquadDb.HistDataRow> s)
        {
            this.Clear();
            this.AddRange(s);
        }

        internal string getTIs()
        {
            string TIs = "";

            if (this.Count > 0)
                TIs = (new TmWeek(this[0].Week)).ToString();

            foreach(NTR_SquadDb.HistDataRow hr in this)
            {
                TIs += ";" + hr.TI.ToString();
            }
            return TIs;
        }
    }
}