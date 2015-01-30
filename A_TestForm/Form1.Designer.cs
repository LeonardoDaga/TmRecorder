namespace A_TestForm
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.smallPlayer1 = new FieldFormationControl.SmallPlayer();
            this.rotFormationControl1 = new FieldFormationControl.RotLineupControl();
            this.SuspendLayout();
            // 
            // smallPlayer1
            // 
            this.smallPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.smallPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.smallPlayer1.Card = -1;
            this.smallPlayer1.EvidenceColor = System.Drawing.Color.DimGray;
            this.smallPlayer1.Info = "";
            this.smallPlayer1.Location = new System.Drawing.Point(952, 503);
            this.smallPlayer1.Name = "smallPlayer1";
            this.smallPlayer1.NameColor = System.Drawing.Color.Olive;
            this.smallPlayer1.NameFont = new System.Drawing.Font("Arial", 8F);
            this.smallPlayer1.Number = 0;
            this.smallPlayer1.NumberColor = System.Drawing.Color.White;
            this.smallPlayer1.PlayerID = 0;
            this.smallPlayer1.PlName = "NNNNNNN Nome Cognome";
            this.smallPlayer1.RuleColor = System.Drawing.Color.DimGray;
            this.smallPlayer1.RuleFont = new System.Drawing.Font("Arial", 7F);
            this.smallPlayer1.Rules = "OMC/OML";
            this.smallPlayer1.ShirtColor = System.Drawing.Color.DarkRed;
            this.smallPlayer1.ShowValue = true;
            this.smallPlayer1.Size = new System.Drawing.Size(66, 79);
            this.smallPlayer1.Skills = 0;
            this.smallPlayer1.TabIndex = 0;
            this.smallPlayer1.Tip = "";
            this.smallPlayer1.Value = 63.9F;
            this.smallPlayer1.Vote = 6F;
            this.smallPlayer1.VoteFont = new System.Drawing.Font("Arial", 8F);
            // 
            // rotFormationControl1
            // 
            this.rotFormationControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rotFormationControl1.BackgroundImage")));
            this.rotFormationControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rotFormationControl1.Location = new System.Drawing.Point(236, 12);
            this.rotFormationControl1.MatchFile = "";
            this.rotFormationControl1.Name = "rotFormationControl1";
            this.rotFormationControl1.OppFormationType = Common.eFormationTypes.Type_4_4_2;
            this.rotFormationControl1.Size = new System.Drawing.Size(771, 459);
            this.rotFormationControl1.TabIndex = 1;
            this.rotFormationControl1.YourFormationType = Common.eFormationTypes.Type_4_4_2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 594);
            this.Controls.Add(this.rotFormationControl1);
            this.Controls.Add(this.smallPlayer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private FieldFormationControl.SmallPlayer smallPlayer1;
        private FieldFormationControl.RotLineupControl rotFormationControl1;


    }
}

