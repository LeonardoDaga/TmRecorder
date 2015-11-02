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
            NTR_Controls.ActionsStats.Row row1 = new NTR_Controls.ActionsStats.Row();
            NTR_Controls.ActionsStats.Row row2 = new NTR_Controls.ActionsStats.Row();
            this.actionsStats2 = new NTR_Controls.ActionsStats();
            this.actionsStats1 = new NTR_Controls.ActionsStats();
            this.webBrowser = new Gecko.GeckoWebBrowser();
            this.SuspendLayout();
            // 
            // actionsStats2
            // 
            this.actionsStats2.ActionRows = null;
            this.actionsStats2.ColumnsAlignment = System.Drawing.StringAlignment.Near;
            this.actionsStats2.ColumnsHeaders = new string[] {
        "Goal",
        "In",
        "Out",
        "Tot",
        "",
        "Tot",
        "Out",
        "In",
        "Goal"};
            this.actionsStats2.HeaderColor = System.Drawing.Color.Black;
            this.actionsStats2.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.actionsStats2.Location = new System.Drawing.Point(38, 199);
            this.actionsStats2.Name = "actionsStats2";
            this.actionsStats2.RowsTitleColor = System.Drawing.Color.Black;
            this.actionsStats2.RowsTitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.actionsStats2.RowsTitlePosition = 0;
            this.actionsStats2.RowsTitleWidth = 120F;
            this.actionsStats2.Size = new System.Drawing.Size(279, 116);
            this.actionsStats2.TabIndex = 1;
            this.actionsStats2.Title = "Title";
            this.actionsStats2.TitleAlignment = System.Drawing.StringAlignment.Near;
            this.actionsStats2.TitleColor = System.Drawing.Color.Black;
            this.actionsStats2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            // 
            // actionsStats1
            // 
            row1.Title = "Through Pass";
            row1.values = new string[] {
        "1",
        "2",
        "3",
        "4",
        "",
        "1",
        "2",
        "3",
        "4"};
            row2.Title = "Short Pass";
            row2.values = new string[] {
        "3",
        "4",
        "5",
        "6",
        "",
        "11",
        "22",
        "13",
        "47"};
            this.actionsStats1.ActionRows = new NTR_Controls.ActionsStats.Row[] {
        row1,
        row2};
            this.actionsStats1.BackColor = System.Drawing.Color.LightYellow;
            this.actionsStats1.ColumnsAlignment = System.Drawing.StringAlignment.Center;
            this.actionsStats1.ColumnsHeaders = new string[] {
        "Goal",
        "In",
        "Out",
        "Total",
        "",
        "Total",
        "Out",
        "In",
        "Goal"};
            this.actionsStats1.HeaderColor = System.Drawing.Color.Maroon;
            this.actionsStats1.HeaderFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionsStats1.Location = new System.Drawing.Point(38, 25);
            this.actionsStats1.Name = "actionsStats1";
            this.actionsStats1.RowsTitleColor = System.Drawing.Color.Black;
            this.actionsStats1.RowsTitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.actionsStats1.RowsTitlePosition = 4;
            this.actionsStats1.RowsTitleWidth = 100F;
            this.actionsStats1.Size = new System.Drawing.Size(343, 157);
            this.actionsStats1.TabIndex = 0;
            this.actionsStats1.Title = "Title";
            this.actionsStats1.TitleAlignment = System.Drawing.StringAlignment.Center;
            this.actionsStats1.TitleColor = System.Drawing.Color.Black;
            this.actionsStats1.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(407, 17);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(319, 287);
            this.webBrowser.TabIndex = 2;
            this.webBrowser.UseHttpActivityObserver = false;
            // 
            // FormTest
            // 
            this.ClientSize = new System.Drawing.Size(762, 342);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.actionsStats2);
            this.Controls.Add(this.actionsStats1);
            this.Name = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private NTR_Controls.MatchStats matchStats1;
        private NTR_Controls.ActionsStats actionsStats1;
        private NTR_Controls.ActionsStats actionsStats2;
        private Gecko.GeckoWebBrowser webBrowser;
    }
}