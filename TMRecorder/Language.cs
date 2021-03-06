using System;
using System.Collections.Generic;
using System.Text;
using Languages;

namespace TMRecorder
{
    partial class MainForm
    {
        public void SetLanguage()
        {
            this.tabATeamPage.Text = Current.Language.ATeamPlayers;
            this.movePlayerToATeamToolStripMenuItem.Text = Current.Language.MovePlayerToATeam;
            this.movePlayerToBTeamToolStripMenuItem.Text = Current.Language.MovePlayerToBTeam;
            this.evidenceSkillsForGainsMenuItem2.Text = Current.Language.EvidenceSkillsForGains;
            this.tabBTeamPage.Text = Current.Language.BTeamPlayers;
            this.tabGK.Text = Current.Language.GoalKeepers;
            this.tabInfo.Text = Current.Language.PlayersInfo;
            this.tabInfoMain.Text = Current.Language.TeamInfo;
            this.groupBox4.Text = Current.Language.Location;
            this.chkHome.Text = Current.Language.Home;
            this.chkAway.Text = Current.Language.Away;
            this.groupBox3.Text = Current.Language.Squad;
            this.groupBox2.Text = Current.Language.Season;
            this.groupBox1.Text = Current.Language.Type;
            this.gotoMatchReportPageToolStripMenuItem.Text = Current.Language.GotoMatchReportPage;
            this.deleteSelectedMatchToolStripMenuItem.Text = Current.Language.DeleteSelectedMatch;
            this.showMatchActionsListToolStripMenuItem.Text = Current.Language.ShowMatchActionsList;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripDropDownButton1.Text = Current.Language.File;
            this.miReloadFixturesAndMatches.Text = Current.Language.ReloadFixturesAndMatches;
            this.toolStripMenuItem2.Text = Current.Language.SaveTeamData;
            this.toolStripMenuItem4.Text = Current.Language.Exit;
            this.toolStripDropDownButton4.Text = Current.Language.Edit;
            this.toolStripMenuItem11.Text = Current.Language.PasteSquadPageFromClipboard;
            this.toolStripMenuItem7.Text = Current.Language.PasteTrainingPageFromClipboard;
            this.toolStripMenuItem9.Text = Current.Language.LoadTeamFileFromXML;
            this.toolStripMenuItem10.Text = Current.Language.PasteSquadDataFromExcelForm;
            this.exportTeamInToolStripMenuItem.Text = Current.Language.ExportTeamToClipboardInExcelFormat;
            this.evidenceSkillsForGainsToolStripMenuItem.Text = Current.Language.EvidenceSkillsForGains;
            this.toolStripDropDownButton2.Text = Current.Language.Tools;
            this.toolStripMenuItem6.Text = Current.Language.Options;
            this.transferManagerToolStripMenuItem.Text = Current.Language.TransferManager;
            this.importPlayersDataToolStripMenuItem.Text = Current.Language.ImportPrivatePlayersData;
            this.tMRBrowserToolStripMenuItem.Text = "TMR Browser";
            this.tMFinanceCalculatorToolStripMenuItem.Text = "TM Finance Calculator";
            this.aSIToTICalculatorToolStripMenuItem.Text = Current.Language.ASIToTICalculator;
            this.youthDevelopmentToolStripMenuItem.Text = Current.Language.YouthDevelopment;
            this.toolStripDropDownButton6.Text = "Calc";
            this.toolStripMenuItem3.Text = Current.Language.RecalculatePlayersScoutsMeanVote;
            this.toolStripMenuItem5.Text = Current.Language.ParseScoutReviewForHiddenData;
            this.recalculatePlayersStatisticsToolStripMenuItem.Text = Current.Language.RecalculatePlayersStatistics;
            this.toolStripDropDownButton5.Text = Current.Language.Training;
            this.clearDecimalsToolStripMenuItem.Text = Current.Language.ClearDecimals;
            this.reapplyTrainingsToolStripMenuItem.Text = Current.Language.ReapplyTrainings;
            this.exportTrainingWeekInTheClipboardInExcelFormatToolStripMenuItem.Text = Current.Language.ExportTrainingWeekToClipboardInExcelFormat;
            this.importTrainingWeekFromClipboardInExcelFormatToolStripMenuItem.Text = Current.Language.ImportTrainingWeekFromClipboardInExcelFormat;
            this.toolStripDropDownButton8.Text = "Stats";
            this.toolStripMenuItem12.Text = Current.Language.TeamGraphicalStatistics;
            this.playersStatisticsToolStripMenuItem.Text = Current.Language.PlayersStatistics;
            this.tradToolStripMenuItem.Text = Current.Language.TradingInfo;
            this.toolStripDropDownButton7.Text = Current.Language.Help;
            this.gotoCalendarToolStripMenuItem.Text = Current.Language.OpenTeamCalendarPage;
            this.showMatchesPerformarcesOnTheFieldToolStripMenuItem.Text = Current.Language.ShowMatchesPerformarcesOnTheField;
            this.toolStripLabel1.Text = Current.Language.WeeksData;
            this.toolStripDropDownButton3.Text = Current.Language.DataEdit;
            this.deleteDataSetToolStripMenuItem.Text = Current.Language.DeleteDataSet;
            this.toolStripButton1.Text = Current.Language.ASIToTICalculator;
            this.toolStripButton2.Text = Current.Language.TransferManager;
            this.toolStripButton3.Text = Current.Language.TradingForm;
            this.Text = "Trophy Manager - Team Recorder X.X.X";
            this.PlayerID.HeaderText = "ID";
            this.Num.HeaderText = "N";
            this.FP.HeaderText = "FP";
            this.DC.HeaderText = "DC";
            this.DR.HeaderText = "DR";
            this.DL.HeaderText = "DL";
            this.DMC.HeaderText = "DMC";
            this.DMR.HeaderText = "DMR";
            this.DML.HeaderText = "DML";
            this.MC.HeaderText = "MC";
            this.MR.HeaderText = "MR";
            this.ML.HeaderText = "ML";
            this.OMC.HeaderText = "OMC";
            this.OMR.HeaderText = "OMR";
            this.OML.HeaderText = "OML";
            this.FC.HeaderText = "FC";
            this.OSi.HeaderText = "SOi";
            this.squalificatoDataGridViewCheckBoxColumn.HeaderText = "Sql";
            this.infortunatoDataGridViewCheckBoxColumn.HeaderText = "Rou";
            this.calDataGridViewTextBoxColumn.HeaderText = Current.Language.Set;
            this.tirDataGridViewTextBoxColumn.HeaderText = Current.Language.Lon;
            this.tesDataGridViewTextBoxColumn.HeaderText = Current.Language.Hea;
            this.tecDataGridViewTextBoxColumn.HeaderText = Current.Language.Tec;
            this.croDataGridViewTextBoxColumn.HeaderText = Current.Language.Cro;
            this.pasDataGridViewTextBoxColumn.HeaderText = Current.Language.Pas;
            this.posDataGridViewTextBoxColumn.HeaderText = Current.Language.Pos;
            this.worDataGridViewTextBoxColumn.HeaderText = Current.Language.Wor;
            this.conDataGridViewTextBoxColumn.HeaderText = Current.Language.Tac;
            this.marDataGridViewTextBoxColumn.HeaderText = Current.Language.Mar;
            this.Age.HeaderText = Current.Language.Age;
            this.dataGridViewTextBoxColumn6.HeaderText = "ASI";
        }
    }

    partial class PlayerForm
    {
        public void SetLanguage()
        {
            this.PlayerAge.HeaderText = Current.Language.Age;
            this.tmR_AgeColumn1.HeaderText = Current.Language.Age;
            this.tmR_DateColumn1.HeaderText = Current.Language.Week;
            this.dataGridViewTextBoxColumn1.HeaderText = Current.Language.Str;
            this.dataGridViewTextBoxColumn2.HeaderText = Current.Language.Res;
            this.dataGridViewTextBoxColumn3.HeaderText = Current.Language.Pac;
            this.dataGridViewTextBoxColumn4.HeaderText = Current.Language.Mar;
            this.dataGridViewTextBoxColumn5.HeaderText = Current.Language.Tak;
            this.dataGridViewTextBoxColumn6.HeaderText = Current.Language.Wor;
            this.dataGridViewTextBoxColumn7.HeaderText = Current.Language.Pos;
            this.dataGridViewTextBoxColumn8.HeaderText = Current.Language.Pas;
            this.dataGridViewTextBoxColumn9.HeaderText = Current.Language.Cro;
            this.dataGridViewTextBoxColumn10.HeaderText = Current.Language.Tec;
            this.dataGridViewTextBoxColumn11.HeaderText = Current.Language.Hea;
            this.dataGridViewTextBoxColumn12.HeaderText = Current.Language.Fin;
            this.dataGridViewTextBoxColumn13.HeaderText = Current.Language.Tir;
            this.dataGridViewTextBoxColumn14.HeaderText = Current.Language.CP;
            this.dataGridViewTextBoxColumn15.HeaderText = "TI";
            this.dataGridViewTextBoxColumn16.HeaderText = Current.Language.Trainer;
            this.dataGridViewTextBoxColumn17.HeaderText = Current.Language.Program;
            this.dataGridViewTextBoxColumn18.HeaderText = "%";
            this.tabSkills.Text = Current.Language.Skills;
            this.tabPage1.Text = "ASI";
            this.linkLabel1.Text = "Delta ASI - By FS Paystu";
            this.chkShowTGI.Text = "Show TGI";
            this.tabPage2.Text = Current.Language.Injuries;
            this.tabPage3.Text = "Specs";
            this.tabPagePerfGraph.Text = Current.Language.Performances;
            this.lblSeason.Text = Current.Language.Season;
            this.chkNormalized.Text = Current.Language.Normalized;
            this.chkShowPosition.Text = Current.Language.ShowPosition;
            this.tabControlPlayerHistory.Text = Current.Language.TrainingPotential;
            this.btnGetVotenSkillAuto.Text = Current.Language.GetAutomatically;
            this.tabPage6.Text = Current.Language.PlayerTraining;
            this.label5.Text = Current.Language.Notes;
            this.groupBox2.Text = Current.Language.PlayerInfo;
            this.toolStripLabel2.Text = Current.Language.Browse;
            this.toolStripButton1.Text = Current.Language.PrevPlayer;
            this.toolStripButton2.Text = Current.Language.NextPlayer;
            this.toolStripLabel1.Text = Current.Language.Edit;
            this.toolStripButton4.Text = Current.Language.ExplorePlayer;
            this.toolStripButton3.Text = Current.Language.ExportHistoryToExcel;
            this.tsbComputeGrowth.Text = Current.Language.ComputeGrowth;
            this.Text = Current.Language.PlayerHistory;
        }
    }

    partial class PlayerFormSL
    {
        public void SetLanguage()
        {
            this.tmR_AgeColumn1.HeaderText = Current.Language.Age;
            this.tmR_DateColumn1.HeaderText = Current.Language.Week;
            this.tabControlPlayerHistory.Text = Current.Language.TrainingPotential;
            this.label5.Text = Current.Language.Notes;
            this.groupBox2.Text = Current.Language.PlayerInfo;
            this.toolStripLabel2.Text = Current.Language.Browse;
            this.toolStripButton1.Text = Current.Language.PrevPlayer;
            this.toolStripButton2.Text = Current.Language.NextPlayer;
            this.toolStripLabel1.Text = Current.Language.Edit;
            this.toolStripButton4.Text = Current.Language.ExplorePlayer;
            this.toolStripButton3.Text = Current.Language.ExportHistoryToExcel;
            this.tsbComputeGrowth.Text = Current.Language.ComputeGrowth;
            this.Text = Current.Language.PlayerHistory;
        }
    }

    partial class StartInfoBox
    {
        public void SetLanguage()
        {
            this.label4.Text = Current.Language.DataDirectory;
        }
    }

    partial class OptionsForm
    {
        public void SetLanguage()
        {
            this.button1.Text = Current.Language.Cancel;
            this.button2.Text = "OK";
            this.tabGenerali.Text = Current.Language.Generics;
            this.label5.Text = Current.Language.ActionsAnalysisFile;
            this.label6.Text = Current.Language.InstallationDirectory;
            this.label2.Text = Current.Language.DefaultPlayerNation;
            this.label1.Text = Current.Language.SquadDataDirectory;
            this.tabPageYourTeamData.Text = Current.Language.YourTeamsData;
            this.groupBox3.Text = Current.Language.UserType;
            this.rbPro.Text = "PRO";
            this.rbNonPro.Text = "Non PRO";
            this.label11.Text = "ID";
            this.label10.Text = Current.Language.Name;
            this.label12.Text = Current.Language.ReserveSquad;
            //this.label13.Text = resources.GetString("label13.Text");
            this.label9.Text = Current.Language.MainSquad;
            this.chkEvidenceGains.Text = Current.Language.EvidenceGainOnThePlayersTable;
            this.pasteScoutListToolStripMenuItem.Text = Current.Language.PasteScoutList;
            this.pasteTrainersListToolStripMenuItem.Text = Current.Language.PasteTrainersList;
            this.tabScout.Text = "Scouts";
            this.nameDataGridViewTextBoxColumn.HeaderText = Current.Language.Name;
            this.developmentDataGridViewTextBoxColumn.HeaderText = Current.Language.Dev;
            this.seniorDataGridViewTextBoxColumn.HeaderText = Current.Language.Senr;
            this.youthDataGridViewTextBoxColumn.HeaderText = Current.Language.Youth;
            this.physicalDataGridViewTextBoxColumn.HeaderText = Current.Language.Phys;
            this.tacticalDataGridViewTextBoxColumn.HeaderText = Current.Language.Tact;
            this.technicalDataGridViewTextBoxColumn.HeaderText = Current.Language.Tech;
            this.psychologyDataGridViewTextBoxColumn.HeaderText = Current.Language.Psyc;
            this.tabPage3.Text = Current.Language.ReportAnalysis;
            this.tabPage31.Text = Current.Language.OtherOptions;
            this.label30.Text = Current.Language.ThisOptionIsUsefulWhenYouMountTmRecorderInAMovableDiskWhoseLetterMa;
            this.chkUseStartupDisk.Text = Current.Language.UseTheStartupDiskForAllPaths;
            this.tabPage5.Text = Current.Language.Tactics;
            this.dataGridViewTextBoxColumn1.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn2.HeaderText = Current.Language.Review;
            this.tabPage6.Text = Current.Language.Tactics;
            this.dataGridViewTextBoxColumn3.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn4.HeaderText = Current.Language.Review;
            this.dataGridViewTextBoxColumn7.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn8.HeaderText = Current.Language.Review;
            this.tabPage14.Text = Current.Language.Generics;
            this.groupBox2.Text = Current.Language.MatchTypes;
            this.label14.Text = Current.Language.ConfiguredMatchTypes;
            this.checkBox1.Text = Current.Language.UseTMRBrowserInsteadOfTheDefaultBrowser;
            this.button3.Text = "...";
            this.label15.Text = Current.Language.ReportAnalysisFilename;
            this.button4.Text = "...";
            this.label16.Text = Current.Language.DefaultPlayerNation;
            this.label17.Text = Current.Language.DataDirectory;
            this.tabPage15.Text = Current.Language.YourTeamsData;
            this.label18.Text = "ID";
            this.label19.Text = Current.Language.Name;
            this.label20.Text = Current.Language.ReserveSquad;
            this.label21.Text = Current.Language.MainSquad;
            this.tabPage16.Text = Current.Language.GainSet;
            this.button5.Text = "...";
            this.label22.Text = Current.Language.GainSet;
            this.checkBox2.Text = Current.Language.NormalizeGains;
            this.tabPage17.Text = "Scouts";
            this.label23.Text = Current.Language.InsertHereTheInformationRelativeToYourScouts;
            this.dataGridViewTextBoxColumn19.HeaderText = Current.Language.Name;
            this.dataGridViewTextBoxColumn20.HeaderText = Current.Language.Dev;
            this.dataGridViewTextBoxColumn21.HeaderText = Current.Language.Senr;
            this.dataGridViewTextBoxColumn22.HeaderText = Current.Language.Youth;
            this.dataGridViewTextBoxColumn23.HeaderText = Current.Language.Phys;
            this.dataGridViewTextBoxColumn24.HeaderText = Current.Language.Tact;
            this.dataGridViewTextBoxColumn25.HeaderText = Current.Language.Tech;
            this.dataGridViewTextBoxColumn26.HeaderText = Current.Language.Psyc;
            this.tabPage18.Text = Current.Language.ReportAnalysis;
            this.label24.Text = Current.Language.FillThisCellsWithThePhrasesThatScoutsUsesToReviewYourPlayers;
            this.tabPage19.Text = Current.Language.Ability;
            this.dataGridViewTextBoxColumn27.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn28.HeaderText = Current.Language.Review;
            this.tabPage20.Text = Current.Language.Tactics;
            this.dataGridViewTextBoxColumn29.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn30.HeaderText = Current.Language.Review;
            this.tabPage21.Text = Current.Language.Physique;
            this.dataGridViewTextBoxColumn31.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn32.HeaderText = Current.Language.Review;
            this.tabPage22.Text = Current.Language.Blooming;
            this.dataGridViewTextBoxColumn33.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn34.HeaderText = Current.Language.Review;
            this.tabPage23.Text = Current.Language.Leadership;
            this.dataGridViewTextBoxColumn35.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn36.HeaderText = Current.Language.Review;
            this.tabPage24.Text = Current.Language.Aggressivity;
            this.dataGridViewTextBoxColumn37.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn38.HeaderText = Current.Language.Review;
            this.tabPage25.Text = Current.Language.Professionality;
            this.dataGridViewTextBoxColumn39.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn40.HeaderText = Current.Language.Review;
            //this.label25.Text = resources.GetString("label25.Text");
            this.dataGridViewTextBoxColumn41.HeaderText = Current.Language.Name;
            this.dataGridViewTextBoxColumn42.HeaderText = Current.Language.Dev;
            this.dataGridViewTextBoxColumn43.HeaderText = Current.Language.Senr;
            this.dataGridViewTextBoxColumn44.HeaderText = Current.Language.Youth;
            this.dataGridViewTextBoxColumn45.HeaderText = Current.Language.Phys;
            this.dataGridViewTextBoxColumn46.HeaderText = Current.Language.Tact;
            this.dataGridViewTextBoxColumn47.HeaderText = Current.Language.Tech;
            this.dataGridViewTextBoxColumn48.HeaderText = Current.Language.Psyc;
            //this.label29.Text = resources.GetString("label29.Text");
            this.tabPage4.Text = Current.Language.Ability;
            this.dataGridViewTextBoxColumn50.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn51.HeaderText = Current.Language.Review;
            this.tabPage7.Text = Current.Language.Blooming;
            this.dataGridViewTextBoxColumn52.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn53.HeaderText = Current.Language.Review;
            this.tabPage26.Text = Current.Language.Leadership;
            this.dataGridViewTextBoxColumn54.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn55.HeaderText = Current.Language.Review;
            this.tabPage27.Text = Current.Language.Aggressivity;
            this.dataGridViewTextBoxColumn56.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn57.HeaderText = Current.Language.Review;
            this.tabPage28.Text = Current.Language.Professionality;
            this.dataGridViewTextBoxColumn58.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn59.HeaderText = Current.Language.Review;
            this.tabPage29.Text = Current.Language.Tactics;
            this.dataGridViewTextBoxColumn60.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn61.HeaderText = Current.Language.Review;
            this.tabPage30.Text = Current.Language.Physique;
            this.dataGridViewTextBoxColumn62.HeaderText = Current.Language.Vote;
            this.dataGridViewTextBoxColumn63.HeaderText = Current.Language.Review;
            this.Text = "Options";
        }
    }
}