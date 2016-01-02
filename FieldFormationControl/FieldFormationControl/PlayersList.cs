using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common;
using System.IO;

namespace FieldFormationControl
{
    public partial class PlayersList : UserControl
    {
        ListPlayer[] listplayers = null;
        //bool isUpdated = false;

        public PlayersList()
        {
            InitializeComponent();
        }

        private ExtraDS.GiocatoriRow[] _players = null;
        public ExtraDS.GiocatoriRow[] Players
        {
            get { return _players; }
        }

        public void UpdatePlayersList()
        {
            if ((listplayers == null) || (listplayers.Length == 0))
            {
                panelPlayers.Visible = false;
                return;
            }
            panelPlayers.Visible = true;

            panelPlayers.Height = 35 * listplayers.Length;
            panelPlayers.Controls.Clear();
            for (int i = 0; i < listplayers.Length; i++)
            {
                panelPlayers.Controls.Add(listplayers[i]);
                listplayers[i].Top = i * 35;
                listplayers[i].Left = 0;
                listplayers[i].Visible = true;
                listplayers[i].Width = panelPlayers.Width;
                listplayers[i].Height = 35;
            }
        }

        private void PlayersList_Paint(object sender, PaintEventArgs e)
        {

        }

        public void SetPlayers(ExtraDS.GiocatoriRow[] gr, ExtTMDataSet extTMDataSet)
        {
            listplayers = new ListPlayer[gr.Length];

            for (int i = 0; i < gr.Length; i++)
            {
                listplayers[i] = new ListPlayer();

                if (gr[i].FPn == 0)
                    listplayers[i].SetDataGk(gr[i], extTMDataSet.GiocatoriNSkill.FindByPlayerID(gr[i].PlayerID));
                else
                    listplayers[i].SetData(gr[i], extTMDataSet.GiocatoriNSkill.FindByPlayerID(gr[i].PlayerID));

                listplayers[i].MouseDown += PlayersList_MouseDown;
                listplayers[i].MouseUp += PlayersList_MouseUp;
                listplayers[i].MouseMove += PlayersList_MouseMove;
            }

            UpdatePlayersList();
        }

        #region Drag And Drop Management
        private Rectangle dragBoxFromMouseDown;
        ListPlayer mouseDownPlayer = null;
        private Cursor MyNoDropCursor;
        private Cursor MyNormalCursor;
        private Point screenOffset;
        private bool UseCustomCursorsCheck = true;

        private void PlayersList_DragLeave(object sender, EventArgs e)
        {

        }

        private void listPlayer_DragLeave(object sender, EventArgs e)
        {

        }

        private void PlayersList_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender.GetType() != typeof(ListPlayer))
                return;

            mouseDownPlayer = (ListPlayer)sender;

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

        private void PlayersList_MouseUp(object sender, MouseEventArgs e)
        {
            // Reset the drag rectangle when the mouse button is raised.
            dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void PlayersList_MouseMove(object sender, MouseEventArgs e)
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
        private void PlayersList_GiveFeedback(object sender, GiveFeedbackEventArgs e)
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

        private void PlayersList_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            // Cancel the drag if the mouse moves off the form.
            PlayersList lb = sender as PlayersList;

            if (lb != null) {

                Form f = lb.FindForm();

                // Cancel the drag if the mouse moves off the form. The screenOffset
                // takes into account any desktop bands that may be at the top or left
                // side of the screen.
                if (((Control.MousePosition.X - screenOffset.X) < f.DesktopBounds.Left) ||
                    ((Control.MousePosition.X - screenOffset.X) > f.DesktopBounds.Right) ||
                    ((Control.MousePosition.Y - screenOffset.Y) < f.DesktopBounds.Top) ||
                    ((Control.MousePosition.Y - screenOffset.Y) > f.DesktopBounds.Bottom)) {

                    e.Action = DragAction.Cancel;
                }
            }
        }

        #endregion
    }
}