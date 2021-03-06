namespace TMRecorder
{
    partial class PlayersStatsForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersStatsForm));
            this.dgPlayersStats = new NTR_Controls.AeroDataGrid();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goalsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.normValDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefActs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OffActs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Errors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shots = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InShots = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GKd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YellowCards = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RedCards = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.champDS = new Common.ChampDS();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbSquad = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbSeason = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkMT1 = new System.Windows.Forms.CheckBox();
            this.chkMT2 = new System.Windows.Forms.CheckBox();
            this.chkMT3 = new System.Windows.Forms.CheckBox();
            this.chkMT4 = new System.Windows.Forms.CheckBox();
            this.chkMT5 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayersStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.champDS)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgPlayersStats
            // 
            this.dgPlayersStats.AllowUserToAddRows = false;
            this.dgPlayersStats.AllowUserToResizeRows = false;
            this.dgPlayersStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPlayersStats.AutoGenerateColumns = false;
            this.dgPlayersStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlayersStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeDataGridViewTextBoxColumn,
            this.PG,
            this.goalsDataGridViewTextBoxColumn,
            this.Assist,
            this.valueDataGridViewTextBoxColumn,
            this.normValDataGridViewTextBoxColumn,
            this.MoM,
            this.DefActs,
            this.OffActs,
            this.Errors,
            this.Shots,
            this.InShots,
            this.GKd,
            this.YellowCards,
            this.RedCards});
            this.dgPlayersStats.DataCollection = null;
            this.dgPlayersStats.DataSource = this.matchBindingSource;
            this.dgPlayersStats.Location = new System.Drawing.Point(2, 83);
            this.dgPlayersStats.Name = "dgPlayersStats";
            this.dgPlayersStats.RowHeadersWidth = 20;
            this.dgPlayersStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPlayersStats.Size = new System.Drawing.Size(722, 348);
            this.dgPlayersStats.TabIndex = 11;
            this.dgPlayersStats.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPlayersStats_ColumnHeaderMouseClick);
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // PG
            // 
            this.PG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PG.DataPropertyName = "PG";
            this.PG.HeaderText = "PG";
            this.PG.Name = "PG";
            this.PG.Width = 47;
            // 
            // goalsDataGridViewTextBoxColumn
            // 
            this.goalsDataGridViewTextBoxColumn.DataPropertyName = "Goals";
            dataGridViewCellStyle29.NullValue = "-";
            this.goalsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle29;
            this.goalsDataGridViewTextBoxColumn.HeaderText = "G";
            this.goalsDataGridViewTextBoxColumn.Name = "goalsDataGridViewTextBoxColumn";
            this.goalsDataGridViewTextBoxColumn.ToolTipText = "Goals";
            this.goalsDataGridViewTextBoxColumn.Width = 33;
            // 
            // Assist
            // 
            this.Assist.DataPropertyName = "Assist";
            this.Assist.HeaderText = "A";
            this.Assist.Name = "Assist";
            this.Assist.ToolTipText = "Assists";
            this.Assist.Width = 30;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            dataGridViewCellStyle30.Format = "N2";
            dataGridViewCellStyle30.NullValue = "-";
            this.valueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle30;
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ToolTipText = "Performance value of the player in this match";
            this.valueDataGridViewTextBoxColumn.Width = 50;
            // 
            // normValDataGridViewTextBoxColumn
            // 
            this.normValDataGridViewTextBoxColumn.DataPropertyName = "NormVal";
            dataGridViewCellStyle31.Format = "N2";
            dataGridViewCellStyle31.NullValue = "-";
            this.normValDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle31;
            this.normValDataGridViewTextBoxColumn.HeaderText = "NrmVal";
            this.normValDataGridViewTextBoxColumn.Name = "normValDataGridViewTextBoxColumn";
            this.normValDataGridViewTextBoxColumn.ToolTipText = "Normalized performance Value (to the whole team performance)";
            this.normValDataGridViewTextBoxColumn.Width = 50;
            // 
            // MoM
            // 
            this.MoM.DataPropertyName = "MoM";
            this.MoM.HeaderText = "MoM";
            this.MoM.Name = "MoM";
            this.MoM.ToolTipText = "Man of the Match";
            this.MoM.Width = 33;
            // 
            // DefActs
            // 
            this.DefActs.DataPropertyName = "DefActs";
            this.DefActs.HeaderText = "Df";
            this.DefActs.Name = "DefActs";
            this.DefActs.ToolTipText = "Defensive Actions";
            this.DefActs.Visible = false;
            this.DefActs.Width = 30;
            // 
            // OffActs
            // 
            this.OffActs.DataPropertyName = "OffActs";
            this.OffActs.HeaderText = "Of";
            this.OffActs.Name = "OffActs";
            this.OffActs.ToolTipText = "Offensive Actions";
            this.OffActs.Visible = false;
            this.OffActs.Width = 30;
            // 
            // Errors
            // 
            this.Errors.DataPropertyName = "Errors";
            this.Errors.HeaderText = "Er";
            this.Errors.Name = "Errors";
            this.Errors.ToolTipText = "Errors";
            this.Errors.Visible = false;
            this.Errors.Width = 30;
            // 
            // Shots
            // 
            this.Shots.DataPropertyName = "Shots";
            this.Shots.HeaderText = "Sh";
            this.Shots.Name = "Shots";
            this.Shots.ToolTipText = "Shots";
            this.Shots.Visible = false;
            this.Shots.Width = 30;
            // 
            // InShots
            // 
            this.InShots.DataPropertyName = "InShots";
            this.InShots.HeaderText = "iS";
            this.InShots.Name = "InShots";
            this.InShots.ToolTipText = "In Targets Shots";
            this.InShots.Visible = false;
            this.InShots.Width = 30;
            // 
            // GKd
            // 
            this.GKd.DataPropertyName = "GKd";
            this.GKd.HeaderText = "GK";
            this.GKd.Name = "GKd";
            this.GKd.ReadOnly = true;
            this.GKd.ToolTipText = "Opposite team shots saved by the GK";
            this.GKd.Visible = false;
            this.GKd.Width = 30;
            // 
            // YellowCards
            // 
            this.YellowCards.DataPropertyName = "YellowCards";
            dataGridViewCellStyle32.NullValue = "-";
            this.YellowCards.DefaultCellStyle = dataGridViewCellStyle32;
            this.YellowCards.HeaderText = "YC";
            this.YellowCards.Name = "YellowCards";
            this.YellowCards.ToolTipText = "Yellow Cards";
            this.YellowCards.Visible = false;
            this.YellowCards.Width = 30;
            // 
            // RedCards
            // 
            this.RedCards.DataPropertyName = "RedCards";
            dataGridViewCellStyle33.NullValue = "-";
            this.RedCards.DefaultCellStyle = dataGridViewCellStyle33;
            this.RedCards.HeaderText = "RC";
            this.RedCards.Name = "RedCards";
            this.RedCards.ToolTipText = "Red Cards";
            this.RedCards.Visible = false;
            this.RedCards.Width = 30;
            // 
            // matchBindingSource
            // 
            this.matchBindingSource.DataMember = "PlyStats";
            this.matchBindingSource.DataSource = this.champDS;
            // 
            // champDS
            // 
            this.champDS.DataSetName = "ChampDS";
            this.champDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PG";
            this.dataGridViewTextBoxColumn1.HeaderText = "PG";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "RedCards";
            dataGridViewCellStyle34.NullValue = "-";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle34;
            this.dataGridViewTextBoxColumn2.HeaderText = "RedCards";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ToolTipText = "Assists";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "YellowCards";
            dataGridViewCellStyle35.NullValue = "-";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle35;
            this.dataGridViewTextBoxColumn3.HeaderText = "YellowCards";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ToolTipText = "Goals";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MoM";
            this.dataGridViewTextBoxColumn4.HeaderText = "MoM";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ToolTipText = "Defensive Actions";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DefActs";
            dataGridViewCellStyle36.Format = "N2";
            dataGridViewCellStyle36.NullValue = "-";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle36;
            this.dataGridViewTextBoxColumn5.HeaderText = "D";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ToolTipText = "Offensive Actions";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "OffActs";
            dataGridViewCellStyle37.Format = "N2";
            dataGridViewCellStyle37.NullValue = "-";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle37;
            this.dataGridViewTextBoxColumn6.HeaderText = "O";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ToolTipText = "Errors";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Assist";
            this.dataGridViewTextBoxColumn7.HeaderText = "A";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ToolTipText = "Shots";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Errors";
            this.dataGridViewTextBoxColumn8.HeaderText = "E";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ToolTipText = "In Targets Shots";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Shots";
            dataGridViewCellStyle38.NullValue = "-";
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle38;
            this.dataGridViewTextBoxColumn9.HeaderText = "T";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.ToolTipText = "Off Target Shots";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "InShots";
            dataGridViewCellStyle39.NullValue = "-";
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle39;
            this.dataGridViewTextBoxColumn10.HeaderText = "S";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ToolTipText = "In Targets Shots";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Shots";
            dataGridViewCellStyle40.NullValue = "-";
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle40;
            this.dataGridViewTextBoxColumn11.HeaderText = "Sh";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ToolTipText = "Shots";
            this.dataGridViewTextBoxColumn11.Width = 30;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "InShots";
            this.dataGridViewTextBoxColumn12.HeaderText = "iS";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ToolTipText = "In Targets Shots";
            this.dataGridViewTextBoxColumn12.Width = 30;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "GKd";
            this.dataGridViewTextBoxColumn13.HeaderText = "GK";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.ToolTipText = "Opposite team shots saved by the GK";
            this.dataGridViewTextBoxColumn13.Width = 30;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "YellowCards";
            dataGridViewCellStyle41.NullValue = "-";
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle41;
            this.dataGridViewTextBoxColumn14.HeaderText = "YC";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ToolTipText = "Yellow Cards";
            this.dataGridViewTextBoxColumn14.Width = 30;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "RedCards";
            dataGridViewCellStyle42.NullValue = "-";
            this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle42;
            this.dataGridViewTextBoxColumn15.HeaderText = "RC";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ToolTipText = "Red Cards";
            this.dataGridViewTextBoxColumn15.Width = 30;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbSquad);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox3.Location = new System.Drawing.Point(417, 6);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(199, 45);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Team";
            // 
            // cmbSquad
            // 
            this.cmbSquad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSquad.FormattingEnabled = true;
            this.cmbSquad.Location = new System.Drawing.Point(15, 16);
            this.cmbSquad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbSquad.Name = "cmbSquad";
            this.cmbSquad.Size = new System.Drawing.Size(178, 21);
            this.cmbSquad.TabIndex = 6;
            this.cmbSquad.SelectionChangeCommitted += new System.EventHandler(this.UpdateMatchList_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbSeason);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox2.Location = new System.Drawing.Point(254, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(148, 45);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Season";
            // 
            // cmbSeason
            // 
            this.cmbSeason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeason.FormattingEnabled = true;
            this.cmbSeason.Location = new System.Drawing.Point(55, 16);
            this.cmbSeason.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbSeason.Name = "cmbSeason";
            this.cmbSeason.Size = new System.Drawing.Size(87, 21);
            this.cmbSeason.TabIndex = 5;
            this.cmbSeason.SelectionChangeCommitted += new System.EventHandler(this.UpdateMatchList_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkMT1);
            this.groupBox1.Controls.Add(this.chkMT2);
            this.groupBox1.Controls.Add(this.chkMT3);
            this.groupBox1.Controls.Add(this.chkMT4);
            this.groupBox1.Controls.Add(this.chkMT5);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(247, 74);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Match Type";
            // 
            // chkMT1
            // 
            this.chkMT1.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMT1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkMT1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkMT1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMT1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkMT1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMT1.Image = ((System.Drawing.Image)(resources.GetObject("chkMT1.Image")));
            this.chkMT1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkMT1.Location = new System.Drawing.Point(7, 15);
            this.chkMT1.Margin = new System.Windows.Forms.Padding(1);
            this.chkMT1.Name = "chkMT1";
            this.chkMT1.Size = new System.Drawing.Size(81, 25);
            this.chkMT1.TabIndex = 2;
            this.chkMT1.Text = "League";
            this.chkMT1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMT1.UseVisualStyleBackColor = false;
            this.chkMT1.CheckedChanged += new System.EventHandler(this.UpdateMatchList_Click);
            // 
            // chkMT2
            // 
            this.chkMT2.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMT2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkMT2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkMT2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMT2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkMT2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMT2.Image = ((System.Drawing.Image)(resources.GetObject("chkMT2.Image")));
            this.chkMT2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkMT2.Location = new System.Drawing.Point(125, 44);
            this.chkMT2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkMT2.Name = "chkMT2";
            this.chkMT2.Size = new System.Drawing.Size(98, 25);
            this.chkMT2.TabIndex = 2;
            this.chkMT2.Text = "Intl. Match";
            this.chkMT2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMT2.UseVisualStyleBackColor = false;
            this.chkMT2.CheckedChanged += new System.EventHandler(this.UpdateMatchList_Click);
            // 
            // chkMT3
            // 
            this.chkMT3.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMT3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkMT3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkMT3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMT3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkMT3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMT3.Image = ((System.Drawing.Image)(resources.GetObject("chkMT3.Image")));
            this.chkMT3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkMT3.Location = new System.Drawing.Point(155, 15);
            this.chkMT3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkMT3.Name = "chkMT3";
            this.chkMT3.Size = new System.Drawing.Size(88, 25);
            this.chkMT3.TabIndex = 2;
            this.chkMT3.Text = "Friendly";
            this.chkMT3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMT3.UseVisualStyleBackColor = false;
            this.chkMT3.CheckedChanged += new System.EventHandler(this.UpdateMatchList_Click);
            // 
            // chkMT4
            // 
            this.chkMT4.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMT4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkMT4.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkMT4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMT4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkMT4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMT4.Image = ((System.Drawing.Image)(resources.GetObject("chkMT4.Image")));
            this.chkMT4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkMT4.Location = new System.Drawing.Point(7, 44);
            this.chkMT4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkMT4.Name = "chkMT4";
            this.chkMT4.Size = new System.Drawing.Size(112, 25);
            this.chkMT4.TabIndex = 2;
            this.chkMT4.Text = "Friendly Lea.";
            this.chkMT4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMT4.UseVisualStyleBackColor = false;
            this.chkMT4.CheckedChanged += new System.EventHandler(this.UpdateMatchList_Click);
            // 
            // chkMT5
            // 
            this.chkMT5.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMT5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkMT5.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkMT5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMT5.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkMT5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMT5.Image = ((System.Drawing.Image)(resources.GetObject("chkMT5.Image")));
            this.chkMT5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkMT5.Location = new System.Drawing.Point(92, 15);
            this.chkMT5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkMT5.Name = "chkMT5";
            this.chkMT5.Size = new System.Drawing.Size(60, 25);
            this.chkMT5.TabIndex = 2;
            this.chkMT5.Text = "Cup";
            this.chkMT5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMT5.UseVisualStyleBackColor = false;
            this.chkMT5.CheckedChanged += new System.EventHandler(this.UpdateMatchList_Click);
            // 
            // PlayersStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 430);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgPlayersStats);
            this.Name = "PlayersStats";
            this.Text = "PlayersStats";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayersStats_FormClosing);
            this.Load += new System.EventHandler(this.PlayersStats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayersStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.champDS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private NTR_Controls.AeroDataGrid dgPlayersStats;
        private System.Windows.Forms.BindingSource matchBindingSource;
        private Common.ChampDS champDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PG;
        private System.Windows.Forms.DataGridViewTextBoxColumn goalsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assist;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn normValDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoM;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefActs;
        private System.Windows.Forms.DataGridViewTextBoxColumn OffActs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Errors;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shots;
        private System.Windows.Forms.DataGridViewTextBoxColumn InShots;
        private System.Windows.Forms.DataGridViewTextBoxColumn GKd;
        private System.Windows.Forms.DataGridViewTextBoxColumn YellowCards;
        private System.Windows.Forms.DataGridViewTextBoxColumn RedCards;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbSquad;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbSeason;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkMT1;
        private System.Windows.Forms.CheckBox chkMT2;
        private System.Windows.Forms.CheckBox chkMT3;
        private System.Windows.Forms.CheckBox chkMT4;
        private System.Windows.Forms.CheckBox chkMT5;
    }
}