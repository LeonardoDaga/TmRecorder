using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common;
using System.IO;
using NTR_Db;
using System.Linq;

namespace FieldFormationControl
{
    public partial class FormationControl : UserControl
    {
        public event EventHandler FormationChanged;

        public FormationControl()
        {
            InitializeComponent();

            foreach (Control cnt in this.Controls)
            {
                if (cnt.GetType() == typeof(LineupPlayer))
                {
                    LineupPlayer lp = (LineupPlayer)cnt;

                    lp.DragDrop += LineupPlayer_DragDrop;
                    lp.DragOver += LineupPlayer_DragOver;
                    lp.DragEnter += LineupPlayer_DragEnter;
                    lp.DragLeave += LineupPlayer_DragLeave;
                    lp.MouseMove += LineupPlayer_MouseMove;
                    lp.MouseUp += LineupPlayer_MouseUp;
                    lp.MouseDown += LineupPlayer_MouseDown;
                    lp.GiveFeedback += LineupPlayer_GiveFeedback;
                }
            }
        }

        eFormationTypes formType = eFormationTypes.Type_4_4_2;
        public eFormationTypes FormationType
        {
            get { return formType; }
            set 
            { 
                formType = value;
                ShowFormationPlayers();
            }
        }

        private string _matchFile = "";
        public string MatchFile
        {
            get { return _matchFile; }
            set
            {
                _matchFile = value;
                if (_matchFile == "") return;

                FileInfo fi = new FileInfo(_matchFile);
                if (!fi.Exists)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.FileName = _matchFile;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        _matchFile = ofd.FileName;
                        LoadMatchFile(_matchFile);
                    }
                }
            }
        }

        public void LoadMatchFile(string matchFile)
        {
            matchDS.Clear();
            matchDS.ReadXml(matchFile);

            // eFormationTypes type = Formation.Recognize(matchDS.YourTeamPerf);
            // Formation form = new Formation(type);

            Formation f = new Formation(eFormationTypes.Type_Empty);

            foreach (MatchDS.YourTeamPerfRow row in matchDS.YourTeamPerf)
            {
                Player pl = f.SetPlayer(row);
            }

            ShowFormationPlayers(f);
        }

        public Formation GetFormationPlayers()
        {
            Formation form = new Formation();

            fpGK.CopyTo(ref form.players[Pos.GK]);

            fpDL.CopyTo(ref form.players[Pos.DL]);
            fpDCL.CopyTo(ref form.players[Pos.DCL]);
            fpDC.CopyTo(ref form.players[Pos.DC]);
            fpDCR.CopyTo(ref form.players[Pos.DCR]);
            fpDR.CopyTo(ref form.players[Pos.DR]);

            fpDML.CopyTo(ref form.players[Pos.DML]);
            fpDMCL.CopyTo(ref form.players[Pos.DMCL]);
            fpDMC.CopyTo(ref form.players[Pos.DMC]);
            fpDMCR.CopyTo(ref form.players[Pos.DMCR]);
            fpDMR.CopyTo(ref form.players[Pos.DMR]);

            fpML.CopyTo(ref form.players[Pos.ML]);
            fpMCL.CopyTo(ref form.players[Pos.MCL]);
            fpMC.CopyTo(ref form.players[Pos.MC]);
            fpMCR.CopyTo(ref form.players[Pos.MCR]);
            fpMR.CopyTo(ref form.players[Pos.MR]);

            fpOML.CopyTo(ref form.players[Pos.OML]);
            fpOMCL.CopyTo(ref form.players[Pos.OMCL]);
            fpOMC.CopyTo(ref form.players[Pos.OMC]);
            fpOMCR.CopyTo(ref form.players[Pos.OMCR]);
            fpOMR.CopyTo(ref form.players[Pos.OMR]);

            fpFCL.CopyTo(ref form.players[Pos.FCL]);
            fpFC.CopyTo(ref form.players[Pos.FC]);
            fpFCR.CopyTo(ref form.players[Pos.FCR]);

            return form;
        }

        private void ShowFormationPlayers()
        {
            Formation form = new Formation(formType);

            ShowGoalKee(form.players);
            ShowDefense(form.players);
            ShowMidDefn(form.players);
            ShowMidfiel(form.players);
            ShowOffense(form.players);
            ShowFrwdAttack(form.players);
        }

        private void ShowGoalKee(Player[] p)
        {
            fpGK.Data = p[Pos.GK];
        }

        public void ShowFormationPlayers(Formation form)
        {
            ShowGoalKee(form.players);
            ShowDefense(form.players);
            ShowMidDefn(form.players);
            ShowMidfiel(form.players);
            ShowOffense(form.players);
            ShowFrwdAttack(form.players);
        }

        public void ShowFormationPlayers(NTR_Formation form)
        {
            ShowGoalKee(form.players);
            ShowDefense(form.players);
            ShowMidDefn(form.players);
            ShowMidfiel(form.players);
            ShowOffense(form.players);
            ShowFrwdAttack(form.players);
        }

        private void ShowFrwdAttack(Player[] p)
        {
            Player CL = p[Pos.FCL], C = p[Pos.FC], CR = p[Pos.FCR];

            fpFCL.Data = CL;
            fpFC.Data = C;
            fpFCR.Data = CR;
        }

        private void ShowOffense(Player[] p)
        {
            Player L = p[Pos.OML], CL = p[Pos.OMCL], C = p[Pos.OMC], CR = p[Pos.OMCR], R = p[Pos.OMR];

            fpOML.Data = L;
            fpOMCL.Data = CL;
            fpOMC.Data = C;
            fpOMCR.Data = CR;
            fpOMR.Data = R;
        }

        private void ShowMidfiel(Player[] p)
        {
            Player L = p[Pos.ML], CL = p[Pos.MCL], C = p[Pos.MC], CR = p[Pos.MCR], R = p[Pos.MR];

            fpML.Data = L;
            fpMCL.Data = CL;
            fpMC.Data = C;
            fpMCR.Data = CR;
            fpMR.Data = R;
        }

        private void ShowMidDefn(Player[] p)
        {
            Player L = p[Pos.DML], CL = p[Pos.DMCL], C = p[Pos.DMC], CR = p[Pos.DMCR], R = p[Pos.DMR];

            fpDML.Data = L;
            fpDMCL.Data = CL;
            fpDMC.Data = C;
            fpDMCR.Data = CR;
            fpDMR.Data = R;
        }


        private void ShowDefense(Player[] p)
        {
            Player L = p[Pos.DL], CL = p[Pos.DCL], C = p[Pos.DC], CR = p[Pos.DCR], R = p[Pos.DR];

            fpDL.Data = L;
            fpDCL.Data = CL;
            fpDC.Data = C;
            fpDCR.Data = CR;
            fpDR.Data = R;
        }


        public void UpdateLPWithData(RatingFunction RF, List<PlayerDataSkills> allPlayersInTeam)
        {
            foreach (Control cnt in this.Controls)
            {
                if (cnt.GetType() == typeof(LineupPlayer))
                {
                    LineupPlayer lp = (LineupPlayer)cnt;

                    PlayerDataSkills pds = allPlayersInTeam.SingleOrDefault(p => p.ID == lp.PlayerID);

                    if (pds == null) continue;

                    Rating rat = RF.ComputeRating(pds);

                    if (pds.FPn == 0) // is a GK
                    {
                        lp.SetDataGk(rat, pds);
                    }
                    else
                    {
                        lp.SetData(rat, pds);
                    }
                }
            }
        }

        #region Drag And Drop Management

        LineupPlayer mouseDownPlayer = null;
        private Rectangle dragBoxFromMouseDown;
        private Cursor MyNoDropCursor;
        private Cursor MyNormalCursor;
        private Point screenOffset;
        private bool UseCustomCursorsCheck = true;

        private void LineupPlayer_DragDrop(object sender, DragEventArgs e)
        {
            // Ensure that the list item index is contained in the data.
            if (e.Data.GetDataPresent(typeof(ListPlayer)))
            {
                ListPlayer player = (ListPlayer)e.Data.GetData(typeof(ListPlayer));
                LineupPlayer lp = (LineupPlayer)sender;

                if (!lp.Display) return;

                // Perform drag-and-drop, depending upon the effect.
                if (e.Effect == DragDropEffects.Copy ||
                    e.Effect == DragDropEffects.Move)
                {
                    // Insert the item.
                    lp.PlName = player.PlName;
                    lp.PlayerID = player.PlayerID;
                    lp.Skills = player.Skills;
                    lp.Rules = player.Rules;
                    //lp.Tip = player.Tip;
                    lp.Number = player.Number;
                    lp.EvidenceColor = Color.Transparent;
                    lp.Rat = player.Rat;
                    lp.PDS = player.PDS;

                    if (lp.PDS.FPn == 0) // it's a gk
                    {
                        lp.Value = (float)lp.Rat.GK;
                    }
                    else
                    {
                        UpdateLineupPlayerWithRating(lp);
                    }

                    // Fire the event
                    FormationChanged(GetFormationPlayers(), EventArgs.Empty);
                }
            }

            // Ensure that the list item index is contained in the data.
            if (e.Data.GetDataPresent(typeof(LineupPlayer)))
            {
                LineupPlayer player = (LineupPlayer)e.Data.GetData(typeof(LineupPlayer));

                // Perform drag-and-drop, depending upon the effect.
                if (e.Effect == DragDropEffects.Copy ||
                    e.Effect == DragDropEffects.Move)
                {
                    // Insert the item.
                    // Create a intermediate item
                    LineupPlayer exc = new LineupPlayer();
                    LineupPlayer lp = (LineupPlayer)sender;

                    exc.PlName = lp.PlName;
                    exc.PlayerID = lp.PlayerID;
                    exc.Skills = lp.Skills;
                    exc.Rules = lp.Rules;
                    exc.Tip = lp.Tip;
                    exc.Number = lp.Number;
                    exc.Rat = lp.Rat;
                    exc.PDS = lp.PDS;
                    exc.Display = lp.Display;

                    lp.PlName = player.PlName;
                    lp.PlayerID = player.PlayerID;
                    lp.Skills = player.Skills;
                    lp.Rules = player.Rules;
                    lp.Tip = player.Tip;
                    lp.Number = player.Number;
                    lp.Rat = player.Rat;
                    lp.PDS = player.PDS;
                    lp.Display = player.Display;

                    player.PlName = exc.PlName;
                    player.PlayerID = exc.PlayerID;
                    player.Skills = exc.Skills;
                    player.Rules = exc.Rules;
                    player.Tip = exc.Tip;
                    player.Number = exc.Number;
                    player.Rat = exc.Rat;
                    player.PDS = exc.PDS;
                    player.Display = exc.Display;

                    lp.EvidenceColor = Color.Transparent;

                    if (lp.PDS.FPn == 0) // it's a gk
                    {
                        if (lp.Rat != null) UpdateLineupPlayerWithRating(lp);
                        lp.Value = (float)lp.Rat.GK;
                    }
                    else
                    {
                        if (lp.Rat != null) UpdateLineupPlayerWithRating(lp);
                        if (player.Rat != null) UpdateLineupPlayerWithRating(player);
                    }

                    // Fire the event
                    FormationChanged(GetFormationPlayers(), EventArgs.Empty);
                }
            }
        }

        private void UpdateLineupPlayerWithRating(LineupPlayer lp)
        {
            Rating rat = lp.Rat;

            if (lp == fpDC) lp.Value = (float)rat.DC;
            if (lp == fpDCR) lp.Value = (float)rat.DC;
            if (lp == fpDCL) lp.Value = (float)rat.DC;
            if (lp == fpDR) lp.Value = (float)rat.DR;
            if (lp == fpDL) lp.Value = (float)rat.DL;
            if (lp == fpDMC) lp.Value = (float)rat.DMC;
            if (lp == fpDMCR) lp.Value = (float)rat.DMC;
            if (lp == fpDMCL) lp.Value = (float)rat.DMC;
            if (lp == fpDMR) lp.Value = (float)rat.DMR;
            if (lp == fpDML) lp.Value = (float)rat.DML;
            if (lp == fpMC) lp.Value = (float)rat.MC;
            if (lp == fpMCR) lp.Value = (float)rat.MC;
            if (lp == fpMCL) lp.Value = (float)rat.MC;
            if (lp == fpMR) lp.Value = (float)rat.MR;
            if (lp == fpML) lp.Value = (float)rat.ML;
            if (lp == fpOMC) lp.Value = (float)rat.OMC;
            if (lp == fpOMCR) lp.Value = (float)rat.OMC;
            if (lp == fpOMCL) lp.Value = (float)rat.OMC;
            if (lp == fpOMR) lp.Value = (float)rat.OMR;
            if (lp == fpOML) lp.Value = (float)rat.OML;
            if (lp == fpFC) lp.Value = (float)rat.FC;
            if (lp == fpFCR) lp.Value = (float)rat.FC;
            if (lp == fpFCL) lp.Value = (float)rat.FC;
        }

        private void LineupPlayer_DragOver(object sender, DragEventArgs e)
        {
            bool checkEffect = false;
            LineupPlayer lp = (LineupPlayer)sender;

            // Determine whether string data exists in the drop data. If not, then
            // the drop effect reflects that the drop cannot occur.
            if ((lp.Display)&&
                (e.Data.GetDataPresent(typeof(ListPlayer))))
            {
                checkEffect = true;
            }

            if (e.Data.GetDataPresent(typeof(LineupPlayer)))
            {
                checkEffect = true;
            }

            if (!checkEffect)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {

                // By default, the drop action should be move, if allowed.
                e.Effect = DragDropEffects.Move;

            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void LineupPlayer_DragEnter(object sender, DragEventArgs e)
        {
            LineupPlayer lp = (LineupPlayer)sender;
            lp.EvidenceColor = Color.Gold;
        }

        private void LineupPlayer_DragLeave(object sender, EventArgs e)
        {
            LineupPlayer lp = (LineupPlayer)sender;
            lp.EvidenceColor = Color.Transparent;
        }

        private void LineupPlayer_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender.GetType() != typeof(LineupPlayer))
                return;

            mouseDownPlayer = (LineupPlayer)sender;

            if (mouseDownPlayer == null)
            {
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
            }
            else
            {
                // Remember the point where the mouse down occurred. The DragSize indicates
                // the size that the mouse can move before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)), dragSize);
            }
        }

        private void LineupPlayer_MouseUp(object sender, MouseEventArgs e)
        {
            // Reset the drag rectangle when the mouse button is raised.
            dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void LineupPlayer_MouseMove(object sender, MouseEventArgs e)
        {

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {

                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Create custom cursors for the drag-and-drop operation.
                    try
                    {
                        MyNormalCursor = new Cursor(GetType(), "DropShirt.cur");

                        MyNoDropCursor = new Cursor(GetType(), "NoDropShirt.cur");

                    }
                    catch
                    {
                        // An error occurred while attempting to load the cursors, so use
                        // standard cursors.
                        UseCustomCursorsCheck = false;
                    }
                    finally
                    {

                        // The screenOffset is used to account for any desktop bands 
                        // that may be at the top or left side of the screen when 
                        // determining when to cancel the drag drop operation.
                        screenOffset = SystemInformation.WorkingArea.Location;

                        // Proceed with the drag-and-drop, passing in the list item.                    
                        DragDropEffects dropEffect = this.DoDragDrop(mouseDownPlayer, DragDropEffects.All | DragDropEffects.Link);

                        // Dispose of the cursors since they are no longer needed.
                        if (MyNormalCursor != null)
                            MyNormalCursor.Dispose();

                        if (MyNoDropCursor != null)
                            MyNoDropCursor.Dispose();
                    }
                }
            }
        }

        private void LineupPlayer_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            // Use custom cursors if the check box is checked.
            if (UseCustomCursorsCheck)
            {

                // Sets the custom cursor based upon the effect.
                e.UseDefaultCursors = false;
                if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
                    Cursor.Current = MyNormalCursor;
                else
                    Cursor.Current = MyNoDropCursor;
            }

        }

        #endregion
    }
}