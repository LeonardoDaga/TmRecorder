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
            this.tagsBar1 = new Common.TagsBar();
            this.quantitySelector1 = new NTR_Controls.QuantitySelector();
            this.SuspendLayout();
            // 
            // tagsBar1
            // 
            this.tagsBar1.BorderColor = System.Drawing.Color.Gray;
            this.tagsBar1.FillerColor = System.Drawing.Color.Aqua;
            this.tagsBar1.Location = new System.Drawing.Point(79, 55);
            this.tagsBar1.Max = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tagsBar1.Min = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tagsBar1.Name = "tagsBar1";
            this.tagsBar1.Size = new System.Drawing.Size(150, 150);
            this.tagsBar1.TabIndex = 0;
            this.tagsBar1.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("tagsBar1.Tags")));
            this.tagsBar1.TextColor = System.Drawing.Color.DarkBlue;
            this.tagsBar1.Title = "Title";
            this.tagsBar1.TitleColor = System.Drawing.Color.DarkMagenta;
            this.tagsBar1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // quantitySelector1
            // 
            this.quantitySelector1.Location = new System.Drawing.Point(166, 70);
            this.quantitySelector1.Name = "quantitySelector1";
            this.quantitySelector1.Size = new System.Drawing.Size(150, 28);
            this.quantitySelector1.TabIndex = 1;
            this.quantitySelector1.Value = 3.51F;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 261);
            this.Controls.Add(this.quantitySelector1);
            this.Controls.Add(this.tagsBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Common.TagsBar tagsBar1;
        private NTR_Controls.QuantitySelector quantitySelector1;

    }
}

