namespace FieldFormationControl
{
    partial class PlayersList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersList));
            this.matchDS = new Common.MatchDS();
            this.panelPlayers = new System.Windows.Forms.Panel();
            this.listPlayer1 = new FieldFormationControl.ListPlayer();
            this.listPlayer2 = new FieldFormationControl.ListPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.matchDS)).BeginInit();
            this.panelPlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // matchDS
            // 
            this.matchDS.DataSetName = "MatchDS";
            this.matchDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelPlayers
            // 
            this.panelPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlayers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelPlayers.BackgroundImage")));
            this.panelPlayers.Controls.Add(this.listPlayer1);
            this.panelPlayers.Controls.Add(this.listPlayer2);
            this.panelPlayers.Location = new System.Drawing.Point(0, 1);
            this.panelPlayers.Name = "panelPlayers";
            this.panelPlayers.Size = new System.Drawing.Size(153, 81);
            this.panelPlayers.TabIndex = 1;
            // 
            // listPlayer1
            // 
            this.listPlayer1.AllowDrop = true;
            this.listPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.listPlayer1.Card = -1;
            this.listPlayer1.EvidenceColor = System.Drawing.Color.Transparent;
            this.listPlayer1.Info = "";
            this.listPlayer1.Location = new System.Drawing.Point(2, 3);
            this.listPlayer1.Name = "listPlayer1";
            this.listPlayer1.NameColor = System.Drawing.Color.LightYellow;
            this.listPlayer1.NameFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPlayer1.Number = 0;
            this.listPlayer1.NumberColor = System.Drawing.Color.Black;
            this.listPlayer1.PlayerID = 0;
            this.listPlayer1.PlName = "Robert \'O Baixinho\' Sherpenzeel";
            this.listPlayer1.RuleColor1 = System.Drawing.Color.White;
            this.listPlayer1.RuleColor2 = System.Drawing.Color.White;
            this.listPlayer1.RuleFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPlayer1.Rules = "FC/OMR";
            this.listPlayer1.ShirtColor = System.Drawing.Color.OrangeRed;
            this.listPlayer1.ShowValue = false;
            this.listPlayer1.Size = new System.Drawing.Size(146, 35);
            this.listPlayer1.Skills = 259;
            this.listPlayer1.TabIndex = 0;
            //this.listPlayer1.Tip = "";
            //this.listPlayer1.TitleTip = "";
            this.listPlayer1.Value = 6.5F;
            this.listPlayer1.Vote = -1F;
            this.listPlayer1.VoteFont = new System.Drawing.Font("Arial", 10F);
            this.listPlayer1.DragLeave += new System.EventHandler(this.listPlayer_DragLeave);
            // 
            // listPlayer2
            // 
            this.listPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.listPlayer2.Card = -1;
            this.listPlayer2.EvidenceColor = System.Drawing.Color.Transparent;
            this.listPlayer2.Info = "";
            this.listPlayer2.Location = new System.Drawing.Point(2, 43);
            this.listPlayer2.Name = "listPlayer2";
            this.listPlayer2.NameColor = System.Drawing.Color.LightYellow;
            this.listPlayer2.NameFont = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPlayer2.Number = 0;
            this.listPlayer2.NumberColor = System.Drawing.Color.White;
            this.listPlayer2.PlayerID = 0;
            this.listPlayer2.PlName = "Robert \'O Baixinho\' Sherpenzeel";
            this.listPlayer2.RuleColor1 = System.Drawing.Color.White;
            this.listPlayer2.RuleColor2 = System.Drawing.Color.White;
            this.listPlayer2.RuleFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPlayer2.Rules = "OMC/OML";
            this.listPlayer2.ShirtColor = System.Drawing.Color.DarkRed;
            this.listPlayer2.ShowValue = false;
            this.listPlayer2.Size = new System.Drawing.Size(146, 35);
            this.listPlayer2.Skills = 7728817;
            this.listPlayer2.TabIndex = 0;
            //this.listPlayer2.Tip = "";
            //this.listPlayer2.TitleTip = "";
            this.listPlayer2.Value = 6.5F;
            this.listPlayer2.Vote = -1F;
            this.listPlayer2.VoteFont = new System.Drawing.Font("Arial", 10F);
            // 
            // PlayersList
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Green;
            this.Controls.Add(this.panelPlayers);
            this.Name = "PlayersList";
            this.Size = new System.Drawing.Size(153, 268);
            this.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.PlayersList_QueryContinueDrag);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PlayersList_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PlayersList_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayersList_MouseDown);
            this.DragLeave += new System.EventHandler(this.PlayersList_DragLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlayersList_MouseUp);
            this.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.PlayersList_GiveFeedback);
            ((System.ComponentModel.ISupportInitialize)(this.matchDS)).EndInit();
            this.panelPlayers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.MatchDS matchDS;
        private ListPlayer listPlayer1;
        private ListPlayer listPlayer2;
        private System.Windows.Forms.Panel panelPlayers;



    }
}
