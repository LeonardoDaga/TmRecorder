using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Common;
using NTR_Common;

namespace TMRecorder
{

    public partial class AsyncProgressForm : Form
    {
        public delegate void AsyncOperation(AsyncProgressForm form);

        AsyncOperation OperationToExecute = null;

        public DateTime lastUpdate = DateTime.Now;

        public int Value
        {
            set
            {
                if (value < 0)
                    progressBar.Value = progressBar.Minimum;
                else if (value < progressBar.Maximum)
                    progressBar.Value = value;
                else
                    progressBar.Value = progressBar.Maximum;

                //TimeSpan ts = DateTime.Now - lastUpdate;
                //if (ts.TotalSeconds > 1)
                //{
                //    this.Invalidate();
                //    this.Update();
                //    lastUpdate = DateTime.Now;
                //}
            }
            get { return progressBar.Value; }
        }

        public AsyncProgressForm(AsyncOperation operationToExecute)
        {
            InitializeComponent();

            OperationToExecute = operationToExecute;
        }

        private void AsyncProgressForm_Shown(object sender, EventArgs e)
        {
            OperationToExecute(this);
        }

        public void Redraw()
        {
            Invalidate();
            Update();
        }

        /// <summary>
        /// Changes the HTML File Name standard to preserve the same name for all the date standards
        /// </summary>
        static public void ChangeFileNamesStandard(AsyncProgressForm apf)
        {
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.DefaultDirectory, "ImportedPages"));
            if (!di.Exists)
            {
                apf.Close();
                return;
            }
            if (di.GetFiles("*.*.htm").Length > 0)
            {
                apf.Close();
                return;
            }

            apf.progressBar.Value = 0;
            apf.Text = "Changing filenames standard: Please wait";

            float tot = (float)di.GetFiles("squad_res_*.htm").Length;
            apf.progressBar.Maximum = (int)tot;
            apf.lblProgressDescription.Text = "Changing files from a total of " + apf.progressBar.Maximum.ToString();

            int count = 0;

            foreach (FileInfo fi in di.GetFiles("squad_res_*.htm"))
            {
                try
                {
                    string[] sp = fi.Name.Split("_.".ToCharArray());
                    int day = int.Parse(sp[2]);
                    int year = int.Parse(sp[3]);

                    DateTime dt = new DateTime(year, 1, 1);
                    dt = dt + new TimeSpan(day - 1, 0, 0, 0);

                    string filedate = TmWeek.ToSWDString(dt);

                    string filename = "squad-res-" + filedate + ".2.htm";

                    File.Move(fi.FullName, Path.Combine(di.FullName, filename));

                    apf.lblProgressDescription.Text = "File rename " + count.ToString() +
                        " of " + tot.ToString();
                    apf.Value = count++;
                    apf.Redraw();
                }
                catch (Exception ex)
                {
                    File.Delete(fi.FullName);
                }
            }

            tot = (float)di.GetFiles("squad_*.htm").Length;
            apf.progressBar.Maximum = (int)tot;
            count = 0;

            foreach (FileInfo fi in di.GetFiles("squad_*.htm"))
            {
                try
                {
                    string[] sp = fi.Name.Split("_.".ToCharArray());
                    int day = int.Parse(sp[1]);
                    int year = int.Parse(sp[2]);

                    DateTime dt = new DateTime(year, 1, 1);
                    dt = dt + new TimeSpan(day - 1, 0, 0, 0);

                    string filedate = TmWeek.ToSWDString(dt);

                    string filename = "squad-" + filedate + ".2.htm";

                    File.Move(fi.FullName, Path.Combine(di.FullName, filename));

                    apf.lblProgressDescription.Text = "File rename " + count.ToString() +
                        " of " + tot.ToString();
                    apf.Value = count++;
                    apf.Redraw();
                }
                catch (Exception ex)
                {
                    File.Delete(fi.FullName);
                }
            }

            tot = (float)di.GetFiles("showprofile_*.htm").Length;
            apf.progressBar.Maximum = (int)tot;
            count = 0;

            foreach (FileInfo fi in di.GetFiles("showprofile_*.htm"))
            {
                try
                {
                    string[] sp = fi.Name.Split("_.".ToCharArray());
                    int playerid = int.Parse(sp[1]);
                    int day = int.Parse(sp[2]);
                    int year = int.Parse(sp[3]);

                    DateTime dt = new DateTime(year, 1, 1);
                    dt = dt + new TimeSpan(day - 1, 0, 0, 0);

                    string filedate = TmWeek.ToSWDString(dt);

                    string filename = "showprofile-" + playerid.ToString() + "-" + filedate + ".2.htm";

                    File.Move(fi.FullName, Path.Combine(di.FullName, filename));

                    apf.lblProgressDescription.Text = "File rename " + count.ToString() +
                        " of " + tot.ToString();
                    apf.Value = count++;
                    apf.Redraw();
                }
                catch (Exception ex)
                {
                    File.Delete(fi.FullName);
                }
            }

            tot = (float)di.GetFiles("shortlist_*.htm").Length;
            apf.progressBar.Maximum = (int)tot;
            count = 0;

            foreach (FileInfo fi in di.GetFiles("shortlist_*.htm"))
            {
                try
                {
                    string[] sp = fi.Name.Split("_.".ToCharArray());
                    int day = int.Parse(sp[1]);
                    int year = int.Parse(sp[2]);

                    DateTime dt = new DateTime(year, 1, 1);
                    dt = dt + new TimeSpan(day - 1, 0, 0, 0);

                    string filedate = TmWeek.ToSWDString(dt);

                    string filename = "shortlist-" + filedate + ".2.htm";

                    File.Move(fi.FullName, Path.Combine(di.FullName, filename));

                    apf.lblProgressDescription.Text = "File rename " + count.ToString() +
                        " of " + tot.ToString();
                    apf.Value = count++;
                    apf.Redraw();
                }
                catch (Exception ex)
                {
                    File.Delete(fi.FullName);
                }
            }

            tot = (float)di.GetFiles("training_new_*.htm").Length;
            apf.progressBar.Maximum = (int)tot;
            count = 0;

            foreach (FileInfo fi in di.GetFiles("training_new_*.htm"))
            {
                try
                {
                    string[] sp = fi.Name.Split("_.".ToCharArray());
                    int day = int.Parse(sp[1]);
                    int year = int.Parse(sp[2]);

                    DateTime dt = new DateTime(year, 1, 1);
                    dt = dt + new TimeSpan(day - 1, 0, 0, 0);

                    string filedate = TmWeek.ToSWDString(dt);

                    string filename = "training-new-" + filedate + ".2.htm";

                    File.Move(fi.FullName, Path.Combine(di.FullName, filename));

                    apf.lblProgressDescription.Text = "File rename " + count.ToString() +
                        " of " + tot.ToString();
                    apf.Value = count++;
                    apf.Redraw();
                }
                catch (Exception ex)
                {
                    File.Delete(fi.FullName);
                }
            }

            tot = (float)di.GetFiles("training_*.htm").Length;
            apf.progressBar.Maximum = (int)tot;
            count = 0;

            foreach (FileInfo fi in di.GetFiles("training_*.htm"))
            {
                try
                {
                    string[] sp = fi.Name.Split("_.".ToCharArray());
                    int day = int.Parse(sp[1]);
                    int year = int.Parse(sp[2]);

                    DateTime dt = new DateTime(year, 1, 1);
                    dt = dt + new TimeSpan(day - 1, 0, 0, 0);

                    string filedate = TmWeek.ToSWDString(dt);

                    string filename = "training-" + filedate + ".2.htm";

                    File.Move(fi.FullName, Path.Combine(di.FullName, filename));

                    apf.lblProgressDescription.Text = "File rename " + count.ToString() +
                        " of " + tot.ToString();
                    apf.Value = count++;
                    apf.Redraw();
                }
                catch (Exception ex)
                {
                    File.Delete(fi.FullName);
                }
            }

            tot = (float)di.GetFiles("staff_trainers_*.htm").Length;
            apf.progressBar.Maximum = (int)tot;
            count = 0;

            foreach (FileInfo fi in di.GetFiles("staff_trainers_*.htm"))
            {
                try
                {
                    string[] sp = fi.Name.Split("_.".ToCharArray());
                    int day = int.Parse(sp[2]);
                    int year = int.Parse(sp[3]);

                    DateTime dt = new DateTime(year, 1, 1);
                    dt = dt + new TimeSpan(day - 1, 0, 0, 0);

                    string filedate = TmWeek.ToSWDString(dt);

                    string filename = "staff_trainers-" + filedate + ".2.htm";

                    File.Move(fi.FullName, Path.Combine(di.FullName, filename));

                    apf.lblProgressDescription.Text = "File rename " + count.ToString() +
                        " of " + tot.ToString();
                    apf.Value = count++;
                    apf.Redraw();
                }
                catch (Exception ex)
                {
                    File.Delete(fi.FullName);
                }
            }

            apf.Close();
        }

        static public void ChangeXmlFileNamesStandard(AsyncProgressForm apf)
        {

            DirectoryInfo di = new DirectoryInfo(Program.Setts.DefaultDirectory);
            if (!di.Exists)
            {
                apf.Close();
                return;
            }

            apf.progressBar.Value = 0;
            apf.Text = "Changing XML filenames standard: Please wait";
            Form parent = Application.OpenForms[0];

            float tot = (float)di.GetFiles("HistTM_*.xml").Length;
            apf.progressBar.Maximum = (int)tot;
            apf.lblProgressDescription.Text = "Changing files from a total of " + apf.progressBar.Maximum.ToString();

            int count = 0;

            foreach (FileInfo fi in di.GetFiles("HistTM_*.xml"))
            {
                try
                {
                    string[] sp = fi.Name.Split("_.".ToCharArray());
                    int day = int.Parse(sp[2]);
                    int year = int.Parse(sp[1]);

                    DateTime dt = new DateTime(year, 1, 1);
                    dt = dt + new TimeSpan(day - 1, 0, 0, 0);

                    string filedate = TmWeek.ToSWDString(dt);

                    string filename = "HistTM-" + filedate + ".2.xml";

                    File.Move(fi.FullName, Path.Combine(di.FullName, filename));

                    apf.lblProgressDescription.Text = "File rename " + count.ToString() +
                        " of " + tot.ToString();
                    apf.Value = count++;
                    apf.Redraw();
                }
                catch (Exception ex)
                {
                    File.Delete(fi.FullName);
                }
            }

            tot = (float)di.GetFiles("TrainTM_*.xml").Length;
            apf.progressBar.Maximum = (int)tot;
            count = 0;

            foreach (FileInfo fi in di.GetFiles("TrainTM_*.xml"))
            {
                try
                {
                    string[] sp = fi.Name.Split("_.".ToCharArray());
                    int day = int.Parse(sp[2]);
                    int year = int.Parse(sp[1]);

                    DateTime dt = new DateTime(year, 1, 1);
                    dt = dt + new TimeSpan(day - 1, 0, 0, 0);

                    string filedate = TmWeek.ToSWDString(dt);

                    string filename = "TrainTM-" + filedate + ".2.xml";

                    File.Move(fi.FullName, Path.Combine(di.FullName, filename));

                    apf.lblProgressDescription.Text = "File rename " + count.ToString() +
                        " of " + tot.ToString();
                    apf.Value = count++;
                    apf.Redraw();
                }
                catch (Exception ex)
                {
                    File.Delete(fi.FullName);
                }
            }

            tot = (float)di.GetFiles("Player_*.3.xml").Length;
            apf.progressBar.Maximum = (int)tot;
            count = 0;

            foreach (FileInfo fi in di.GetFiles("Player_*.3.xml"))
            {
                try
                {
                    PlayersDS pDS = new PlayersDS();
                    pDS.ReadXml(fi.FullName);

                    string[] sdates = pDS.FixDataVal.ScoutDate.Split('|');
                    string scoutdates = "";
                    foreach (string sdate in sdates)
                    {
                        DateTime dt = DateTime.Parse(sdate);
                        scoutdates += TmWeek.ToSWDString(dt) + "|";
                    }

                    pDS.FixDataVal.ScoutDate = scoutdates.Trim('|');

                    string filename = "Player-" + pDS.FixDataVal.PlayerID.ToString() + ".4.xml";

                    pDS.WriteXml(Path.Combine(di.FullName, filename));
                    File.Delete(fi.FullName);

                    apf.lblProgressDescription.Text = "File format update " + count.ToString() +
                        " of " + tot.ToString();
                    apf.Value = count++;
                    apf.Redraw();
                }
                catch (Exception ex)
                {
                    File.Delete(fi.FullName);
                }
            }

            count = 0;

            foreach (FileInfo fi in di.GetFiles("TeamPlayersDB.2.xml"))
            {
                ExtraDS eDS = new ExtraDS();
                eDS.ReadXml(fi.FullName);

                tot = (float)eDS.Giocatori.Count;
                apf.progressBar.Maximum = (int)tot;

                foreach (ExtraDS.GiocatoriRow gr in eDS.Giocatori)
                {

                    try
                    {
                        string[] sdates = gr.ScoutDate.Split('|');
                        string scoutdates = "";
                        foreach (string sdate in sdates)
                        {
                            DateTime dt = DateTime.Parse(sdate);
                            scoutdates += TmWeek.ToSWDString(dt) + "|";
                        }

                        gr.ScoutDate = scoutdates.Trim('|');

                        apf.lblProgressDescription.Text = "Player date format update " + count.ToString() +
                            " of " + tot.ToString();
                        apf.Value = count++;
                        apf.Redraw();
                    }
                    catch (Exception ex)
                    {
                    }
                }

                string filename = "TeamPlayersDB.3.xml";

                eDS.WriteXml(Path.Combine(di.FullName, filename));
                File.Delete(fi.FullName);
            }

            count = 0;
            foreach (FileInfo fi in di.GetFiles("MatchesHistory.xml"))
            {
                ChampDS cDS = new ChampDS();
                cDS.ReadXml(fi.FullName);

                tot = (float)cDS.PlyStats.Count;
                apf.progressBar.Maximum = (int)tot;

                foreach (ChampDS.PlyStatsRow pr in cDS.PlyStats)
                {
                    try
                    {
                        if (pr.IsVotesNull()) continue;

                        string[] votes = pr.Votes.Split(';');
                        string newvotes = "";

                        foreach (string vote in votes)
                        {
                            string[] pars = vote.Split('|');

                            DateTime dt = DateTime.Parse(pars[0]);

                            newvotes += TmWeek.ToSWDString(dt) + "|" + pars[1] + "|" + pars[2] + "|" + pars[3] + ";";
                        }

                        pr.Votes = newvotes.Trim(';');

                        apf.lblProgressDescription.Text = "Vote date format update " + count.ToString() +
                            " of " + tot.ToString();
                        apf.Value = count++;
                        apf.Redraw();
                    }
                    catch (Exception ex)
                    {
                    }
                }

                string filename = "MatchesHistory.3.xml";

                cDS.WriteXml(Path.Combine(di.FullName, filename));
                File.Delete(fi.FullName);
            }

            apf.Close();
        }
    
    }
}