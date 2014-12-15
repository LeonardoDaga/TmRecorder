namespace TmRecorder3
{
    partial class MainForm3
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm3));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMainBar = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.importDataFromTmR1xFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDataFromFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSquadA = new System.Windows.Forms.TabPage();
            this.chkBTeam = new System.Windows.Forms.CheckBox();
            this.chkU21 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.qsMinRating = new NTR_Controls.QuantitySelector();
            this.chkShowF = new System.Windows.Forms.CheckBox();
            this.chkShowOM = new System.Windows.Forms.CheckBox();
            this.chkShowM = new System.Windows.Forms.CheckBox();
            this.chkShowDM = new System.Windows.Forms.CheckBox();
            this.chkShowD = new System.Windows.Forms.CheckBox();
            this.cbDataDay = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgPlayers = new NTR_Controls.AeroDataGrid();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wBornDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nTR_SquadDb = new NTR_Db.NTR_SquadDb();
            this.DB = new NTR_Db.Data(this.components);
            this.chkO21 = new System.Windows.Forms.CheckBox();
            this.tsMainBar.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabSquadA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTR_SquadDb)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMainBar
            // 
            this.tsMainBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton3});
            this.tsMainBar.Location = new System.Drawing.Point(0, 0);
            this.tsMainBar.Name = "tsMainBar";
            this.tsMainBar.Size = new System.Drawing.Size(951, 36);
            this.tsMainBar.TabIndex = 2;
            this.tsMainBar.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDataFromTmR1xFormatToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 33);
            this.toolStripDropDownButton1.Text = "File";
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // importDataFromTmR1xFormatToolStripMenuItem
            // 
            this.importDataFromTmR1xFormatToolStripMenuItem.Name = "importDataFromTmR1xFormatToolStripMenuItem";
            this.importDataFromTmR1xFormatToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.importDataFromTmR1xFormatToolStripMenuItem.Text = "Import Data from TmR 1.x format";
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOptions,
            this.reloadDataFromFilesToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(47, 33);
            this.toolStripDropDownButton3.Text = "Tools";
            this.toolStripDropDownButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsOptions
            // 
            this.tsOptions.Name = "tsOptions";
            this.tsOptions.Size = new System.Drawing.Size(188, 22);
            this.tsOptions.Text = "Options";
            // 
            // reloadDataFromFilesToolStripMenuItem
            // 
            this.reloadDataFromFilesToolStripMenuItem.Name = "reloadDataFromFilesToolStripMenuItem";
            this.reloadDataFromFilesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.reloadDataFromFilesToolStripMenuItem.Text = "Reload Data from files";
            this.reloadDataFromFilesToolStripMenuItem.Click += new System.EventHandler(this.reloadDataFromFilesToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSquadA);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(951, 446);
            this.tabControl1.TabIndex = 3;
            // 
            // tabSquadA
            // 
            this.tabSquadA.Controls.Add(this.chkBTeam);
            this.tabSquadA.Controls.Add(this.chkO21);
            this.tabSquadA.Controls.Add(this.chkU21);
            this.tabSquadA.Controls.Add(this.label2);
            this.tabSquadA.Controls.Add(this.qsMinRating);
            this.tabSquadA.Controls.Add(this.chkShowF);
            this.tabSquadA.Controls.Add(this.chkShowOM);
            this.tabSquadA.Controls.Add(this.chkShowM);
            this.tabSquadA.Controls.Add(this.chkShowDM);
            this.tabSquadA.Controls.Add(this.chkShowD);
            this.tabSquadA.Controls.Add(this.cbDataDay);
            this.tabSquadA.Controls.Add(this.label1);
            this.tabSquadA.Controls.Add(this.dgPlayers);
            this.tabSquadA.Location = new System.Drawing.Point(4, 22);
            this.tabSquadA.Name = "tabSquadA";
            this.tabSquadA.Padding = new System.Windows.Forms.Padding(3);
            this.tabSquadA.Size = new System.Drawing.Size(943, 420);
            this.tabSquadA.TabIndex = 0;
            this.tabSquadA.Text = "Field Players";
            this.tabSquadA.UseVisualStyleBackColor = true;
            // 
            // chkBTeam
            // 
            this.chkBTeam.AutoSize = true;
            this.chkBTeam.Location = new System.Drawing.Point(715, 6);
            this.chkBTeam.Name = "chkBTeam";
            this.chkBTeam.Size = new System.Drawing.Size(63, 17);
            this.chkBTeam.TabIndex = 8;
            this.chkBTeam.Text = "B-Team";
            this.chkBTeam.UseVisualStyleBackColor = true;
            this.chkBTeam.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkU21
            // 
            this.chkU21.AutoSize = true;
            this.chkU21.Location = new System.Drawing.Point(611, 6);
            this.chkU21.Name = "chkU21";
            this.chkU21.Size = new System.Drawing.Size(46, 17);
            this.chkU21.TabIndex = 8;
            this.chkU21.Text = "U21";
            this.chkU21.UseVisualStyleBackColor = true;
            this.chkU21.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Min. Rating";
            // 
            // qsMinRating
            // 
            this.qsMinRating.Location = new System.Drawing.Point(507, 5);
            this.qsMinRating.Name = "qsMinRating";
            this.qsMinRating.Size = new System.Drawing.Size(85, 17);
            this.qsMinRating.TabIndex = 6;
            this.qsMinRating.Value = 0F;
            this.qsMinRating.ValueChanged += new NTR_Controls.QuantitySelector.ValueChangedHandler(this.qsMinRating_ValueChanged);
            // 
            // chkShowF
            // 
            this.chkShowF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowF.Image = global::TmRecorder3.Properties.Resources.F;
            this.chkShowF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowF.Location = new System.Drawing.Point(387, 3);
            this.chkShowF.Name = "chkShowF";
            this.chkShowF.Size = new System.Drawing.Size(40, 22);
            this.chkShowF.TabIndex = 5;
            this.chkShowF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowF.UseVisualStyleBackColor = true;
            this.chkShowF.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkShowOM
            // 
            this.chkShowOM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowOM.Image = global::TmRecorder3.Properties.Resources.OM;
            this.chkShowOM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowOM.Location = new System.Drawing.Point(341, 3);
            this.chkShowOM.Name = "chkShowOM";
            this.chkShowOM.Size = new System.Drawing.Size(40, 22);
            this.chkShowOM.TabIndex = 5;
            this.chkShowOM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowOM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowOM.UseVisualStyleBackColor = true;
            this.chkShowOM.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkShowM
            // 
            this.chkShowM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowM.Image = global::TmRecorder3.Properties.Resources.M;
            this.chkShowM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowM.Location = new System.Drawing.Point(295, 3);
            this.chkShowM.Name = "chkShowM";
            this.chkShowM.Size = new System.Drawing.Size(40, 22);
            this.chkShowM.TabIndex = 5;
            this.chkShowM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowM.UseVisualStyleBackColor = true;
            this.chkShowM.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkShowDM
            // 
            this.chkShowDM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowDM.Image = global::TmRecorder3.Properties.Resources.DM;
            this.chkShowDM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowDM.Location = new System.Drawing.Point(249, 3);
            this.chkShowDM.Name = "chkShowDM";
            this.chkShowDM.Size = new System.Drawing.Size(40, 22);
            this.chkShowDM.TabIndex = 5;
            this.chkShowDM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowDM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowDM.UseVisualStyleBackColor = true;
            this.chkShowDM.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkShowD
            // 
            this.chkShowD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowD.Image = global::TmRecorder3.Properties.Resources.D;
            this.chkShowD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowD.Location = new System.Drawing.Point(203, 3);
            this.chkShowD.Name = "chkShowD";
            this.chkShowD.Size = new System.Drawing.Size(40, 22);
            this.chkShowD.TabIndex = 5;
            this.chkShowD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowD.UseVisualStyleBackColor = true;
            this.chkShowD.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // cbDataDay
            // 
            this.cbDataDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataDay.FormattingEnabled = true;
            this.cbDataDay.Location = new System.Drawing.Point(82, 4);
            this.cbDataDay.Name = "cbDataDay";
            this.cbDataDay.Size = new System.Drawing.Size(106, 21);
            this.cbDataDay.TabIndex = 4;
            this.cbDataDay.SelectedIndexChanged += new System.EventHandler(this.cbDataDay_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Weeks Data";
            // 
            // dgPlayers
            // 
            this.dgPlayers.AllowUserToAddRows = false;
            this.dgPlayers.AllowUserToDeleteRows = false;
            this.dgPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPlayers.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPlayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.weekDataGridViewTextBoxColumn,
            this.aSIDataGridViewTextBoxColumn,
            this.wBornDataGridViewTextBoxColumn});
            this.dgPlayers.DataSource = this.varDataBindingSource;
            this.dgPlayers.Location = new System.Drawing.Point(3, 27);
            this.dgPlayers.Name = "dgPlayers";
            this.dgPlayers.ReadOnly = true;
            this.dgPlayers.RowHeadersWidth = 20;
            this.dgPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPlayers.Size = new System.Drawing.Size(937, 391);
            this.dgPlayers.TabIndex = 1;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // weekDataGridViewTextBoxColumn
            // 
            this.weekDataGridViewTextBoxColumn.DataPropertyName = "Week";
            this.weekDataGridViewTextBoxColumn.HeaderText = "Week";
            this.weekDataGridViewTextBoxColumn.Name = "weekDataGridViewTextBoxColumn";
            this.weekDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aSIDataGridViewTextBoxColumn
            // 
            this.aSIDataGridViewTextBoxColumn.DataPropertyName = "ASI";
            this.aSIDataGridViewTextBoxColumn.HeaderText = "ASI";
            this.aSIDataGridViewTextBoxColumn.Name = "aSIDataGridViewTextBoxColumn";
            this.aSIDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // wBornDataGridViewTextBoxColumn
            // 
            this.wBornDataGridViewTextBoxColumn.DataPropertyName = "wBorn";
            this.wBornDataGridViewTextBoxColumn.HeaderText = "wBorn";
            this.wBornDataGridViewTextBoxColumn.Name = "wBornDataGridViewTextBoxColumn";
            this.wBornDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // varDataBindingSource
            // 
            this.varDataBindingSource.DataSource = typeof(NTR_Db.PlayerData);
            // 
            // nTR_SquadDb
            // 
            this.nTR_SquadDb.DataSetName = "NTR_SquadDb";
            this.nTR_SquadDb.GDS = null;
            this.nTR_SquadDb.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DB
            // 
            this.DB.latestDataDay = new System.DateTime(((long)(0)));
            // 
            // chkO21
            // 
            this.chkO21.AutoSize = true;
            this.chkO21.Location = new System.Drawing.Point(663, 6);
            this.chkO21.Name = "chkO21";
            this.chkO21.Size = new System.Drawing.Size(47, 17);
            this.chkO21.TabIndex = 8;
            this.chkO21.Text = "O21";
            this.chkO21.UseVisualStyleBackColor = true;
            this.chkO21.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // MainForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 482);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tsMainBar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm3";
            this.Text = "TmRecorder 3.x.x.x";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tsMainBar.ResumeLayout(false);
            this.tsMainBar.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabSquadA.ResumeLayout(false);
            this.tabSquadA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTR_SquadDb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NTR_Db.NTR_SquadDb nTR_SquadDb;
        private System.Windows.Forms.BindingSource varDataBindingSource;
        private NTR_Db.Data DB;
        private System.Windows.Forms.ToolStrip tsMainBar;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem importDataFromTmR1xFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem tsOptions;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSquadA;
        private NTR_Controls.AeroDataGrid dgPlayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wBornDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem reloadDataFromFilesToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbDataDay;
        private System.Windows.Forms.CheckBox chkShowD;
        private System.Windows.Forms.Label label2;
        private NTR_Controls.QuantitySelector qsMinRating;
        private System.Windows.Forms.CheckBox chkShowF;
        private System.Windows.Forms.CheckBox chkShowOM;
        private System.Windows.Forms.CheckBox chkShowM;
        private System.Windows.Forms.CheckBox chkShowDM;
        private System.Windows.Forms.CheckBox chkBTeam;
        private System.Windows.Forms.CheckBox chkU21;
        private System.Windows.Forms.CheckBox chkO21;
    }
}

