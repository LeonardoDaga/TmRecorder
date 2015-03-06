namespace A_TestForm
{
    partial class FormTest
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NTR_Controls.Column column1 = new NTR_Controls.Column();
            NTR_Controls.Row row1 = new NTR_Controls.Row();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            this.matchStats2 = new NTR_Controls.MatchStats();
            this.SuspendLayout();
            // 
            // matchStats2
            // 
            column1.Alignment = System.Drawing.StringAlignment.Near;
            column1.Color = System.Drawing.Color.Black;
            column1.ColumnSize = 100;
            column1.ColumnSizeType = NTR_Controls.SizeType.Percentage;
            column1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            column1.Name = "Name";
            column1.Property = null;
            this.matchStats2.Columns = new NTR_Controls.Column[] {
        column1};
            this.matchStats2.HeaderColor = System.Drawing.Color.Black;
            this.matchStats2.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.matchStats2.Location = new System.Drawing.Point(321, 83);
            this.matchStats2.Name = "matchStats2";
            this.matchStats2.Size = new System.Drawing.Size(166, 146);
            this.matchStats2.TabIndex = 0;
            row1.Format = "{0}";
            row1.IsHeader = true;
            row1.Items = ((System.Collections.Generic.List<NTR_Controls.Item>)(resources.GetObject("row1.Items")));
            row1.Name = "Title";
            row1.Text = "Title";
            this.matchStats2.Rows = new NTR_Controls.Row[] {
        row1};
            this.matchStats2.Title = "Title";
            this.matchStats2.TitleAlignment = System.Drawing.StringAlignment.Near;
            this.matchStats2.TitleColor = System.Drawing.Color.Black;
            this.matchStats2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            // 
            // FormTest
            // 
            this.ClientSize = new System.Drawing.Size(670, 342);
            this.Controls.Add(this.matchStats2);
            this.Name = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private NTR_Controls.MatchStats matchStats1;
        private NTR_Controls.MatchStats matchStats2;
    }
}