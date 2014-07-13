namespace TMRecorder
{
    partial class TraderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TraderForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nationDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_NationColumn(this.components);
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateAcquireDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_DateColumn(this.components);
            this.aSIwhenBuyedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acquirePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekInTeamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.managCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateSell = new DataGridViewCustomColumns.TMR_DateColumn(this.components);
            this.ASIwhenSold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tradingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trading = new TMRecorder.Trading();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbNewPlayer = new System.Windows.Forms.ToolStripButton();
            this.tbCutPlayer = new System.Windows.Forms.ToolStripButton();
            this.tbEditPlayer = new System.Windows.Forms.ToolStripButton();
            this.toolPasteTransferHistory = new System.Windows.Forms.ToolStripButton();
            this.tbSaveList = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmR_NationColumn1 = new DataGridViewCustomColumns.TMR_NationColumn(this.components);
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSumAcqPrices = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSumManagCosts = new System.Windows.Forms.TextBox();
            this.lbl77 = new System.Windows.Forms.Label();
            this.txtSumSellPrices = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalGain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trading)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.nationDataGridViewTextBoxColumn,
            this.Age,
            this.dateAcquireDataGridViewTextBoxColumn,
            this.aSIwhenBuyedDataGridViewTextBoxColumn,
            this.acquirePriceDataGridViewTextBoxColumn,
            this.weekInTeamDataGridViewTextBoxColumn,
            this.managCostDataGridViewTextBoxColumn,
            this.DateSell,
            this.ASIwhenSold,
            this.sellPriceDataGridViewTextBoxColumn,
            this.gainDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.playersBindingSource;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.Location = new System.Drawing.Point(0, 54);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(882, 391);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.ToolTipText = "Name of the player";
            // 
            // nationDataGridViewTextBoxColumn
            // 
            this.nationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nationDataGridViewTextBoxColumn.DataPropertyName = "Nation";
            this.nationDataGridViewTextBoxColumn.HeaderText = "Nat";
            this.nationDataGridViewTextBoxColumn.Name = "nationDataGridViewTextBoxColumn";
            this.nationDataGridViewTextBoxColumn.ReadOnly = true;
            this.nationDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nationDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.nationDataGridViewTextBoxColumn.ToolTipText = "Nation";
            this.nationDataGridViewTextBoxColumn.Width = 49;
            // 
            // Age
            // 
            this.Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            this.Age.ToolTipText = "Last Age when he was in the Squad";
            this.Age.Width = 51;
            // 
            // dateAcquireDataGridViewTextBoxColumn
            // 
            this.dateAcquireDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateAcquireDataGridViewTextBoxColumn.DataPropertyName = "DateAcquire";
            this.dateAcquireDataGridViewTextBoxColumn.HeaderText = "1st Week";
            this.dateAcquireDataGridViewTextBoxColumn.Name = "dateAcquireDataGridViewTextBoxColumn";
            this.dateAcquireDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateAcquireDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dateAcquireDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dateAcquireDataGridViewTextBoxColumn.ToolTipText = "First week in squad";
            this.dateAcquireDataGridViewTextBoxColumn.Width = 78;
            // 
            // aSIwhenBuyedDataGridViewTextBoxColumn
            // 
            this.aSIwhenBuyedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.aSIwhenBuyedDataGridViewTextBoxColumn.DataPropertyName = "ASIwhenBuyed";
            this.aSIwhenBuyedDataGridViewTextBoxColumn.HeaderText = "1st ASI";
            this.aSIwhenBuyedDataGridViewTextBoxColumn.Name = "aSIwhenBuyedDataGridViewTextBoxColumn";
            this.aSIwhenBuyedDataGridViewTextBoxColumn.ReadOnly = true;
            this.aSIwhenBuyedDataGridViewTextBoxColumn.ToolTipText = "ASI when arrived in the squad";
            this.aSIwhenBuyedDataGridViewTextBoxColumn.Width = 66;
            // 
            // acquirePriceDataGridViewTextBoxColumn
            // 
            this.acquirePriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.acquirePriceDataGridViewTextBoxColumn.DataPropertyName = "AcquirePrice";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.acquirePriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.acquirePriceDataGridViewTextBoxColumn.HeaderText = "Acq Price";
            this.acquirePriceDataGridViewTextBoxColumn.Name = "acquirePriceDataGridViewTextBoxColumn";
            this.acquirePriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.acquirePriceDataGridViewTextBoxColumn.ToolTipText = "Price Payed when bought";
            this.acquirePriceDataGridViewTextBoxColumn.Width = 78;
            // 
            // weekInTeamDataGridViewTextBoxColumn
            // 
            this.weekInTeamDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.weekInTeamDataGridViewTextBoxColumn.DataPropertyName = "WeekInTeam";
            this.weekInTeamDataGridViewTextBoxColumn.HeaderText = "WkIn";
            this.weekInTeamDataGridViewTextBoxColumn.Name = "weekInTeamDataGridViewTextBoxColumn";
            this.weekInTeamDataGridViewTextBoxColumn.ReadOnly = true;
            this.weekInTeamDataGridViewTextBoxColumn.ToolTipText = "Week in Team";
            this.weekInTeamDataGridViewTextBoxColumn.Width = 58;
            // 
            // managCostDataGridViewTextBoxColumn
            // 
            this.managCostDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.managCostDataGridViewTextBoxColumn.DataPropertyName = "ManagCost";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.managCostDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.managCostDataGridViewTextBoxColumn.HeaderText = "MngCost";
            this.managCostDataGridViewTextBoxColumn.Name = "managCostDataGridViewTextBoxColumn";
            this.managCostDataGridViewTextBoxColumn.ReadOnly = true;
            this.managCostDataGridViewTextBoxColumn.ToolTipText = "Cost of management (Wages considering a linear growth of wage)";
            this.managCostDataGridViewTextBoxColumn.Width = 74;
            // 
            // DateSell
            // 
            this.DateSell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateSell.DataPropertyName = "DateSell";
            this.DateSell.HeaderText = "Last Week";
            this.DateSell.Name = "DateSell";
            this.DateSell.ReadOnly = true;
            this.DateSell.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DateSell.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DateSell.ToolTipText = "Last week in the squad";
            this.DateSell.Width = 84;
            // 
            // ASIwhenSold
            // 
            this.ASIwhenSold.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ASIwhenSold.DataPropertyName = "ASIwhenSold";
            this.ASIwhenSold.HeaderText = "Last ASI";
            this.ASIwhenSold.Name = "ASIwhenSold";
            this.ASIwhenSold.ReadOnly = true;
            this.ASIwhenSold.ToolTipText = "ASI when he left the squad";
            this.ASIwhenSold.Width = 72;
            // 
            // sellPriceDataGridViewTextBoxColumn
            // 
            this.sellPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sellPriceDataGridViewTextBoxColumn.DataPropertyName = "SellPrice";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.sellPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.sellPriceDataGridViewTextBoxColumn.HeaderText = "Sell Price";
            this.sellPriceDataGridViewTextBoxColumn.Name = "sellPriceDataGridViewTextBoxColumn";
            this.sellPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.sellPriceDataGridViewTextBoxColumn.ToolTipText = "Price received when it was sold";
            this.sellPriceDataGridViewTextBoxColumn.Width = 76;
            // 
            // gainDataGridViewTextBoxColumn
            // 
            this.gainDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gainDataGridViewTextBoxColumn.DataPropertyName = "Gain";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N0";
            dataGridViewCellStyle12.NullValue = null;
            this.gainDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.gainDataGridViewTextBoxColumn.HeaderText = "Gain";
            this.gainDataGridViewTextBoxColumn.Name = "gainDataGridViewTextBoxColumn";
            this.gainDataGridViewTextBoxColumn.ReadOnly = true;
            this.gainDataGridViewTextBoxColumn.ToolTipText = "Gain considering the Sell Price, the Acquire Price and the Management cost";
            this.gainDataGridViewTextBoxColumn.Width = 54;
            // 
            // playersBindingSource
            // 
            this.playersBindingSource.DataMember = "Players";
            this.playersBindingSource.DataSource = this.tradingBindingSource;
            // 
            // tradingBindingSource
            // 
            this.tradingBindingSource.DataSource = this.trading;
            this.tradingBindingSource.Position = 0;
            // 
            // trading
            // 
            this.trading.DataSetName = "Trading";
            this.trading.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNewPlayer,
            this.tbCutPlayer,
            this.tbEditPlayer,
            this.toolPasteTransferHistory,
            this.tbSaveList,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(882, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbNewPlayer
            // 
            this.tbNewPlayer.Image = ((System.Drawing.Image)(resources.GetObject("tbNewPlayer.Image")));
            this.tbNewPlayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbNewPlayer.Name = "tbNewPlayer";
            this.tbNewPlayer.Size = new System.Drawing.Size(81, 22);
            this.tbNewPlayer.Text = "New Player";
            this.tbNewPlayer.Click += new System.EventHandler(this.tbNewPlayer_Click);
            // 
            // tbCutPlayer
            // 
            this.tbCutPlayer.Image = ((System.Drawing.Image)(resources.GetObject("tbCutPlayer.Image")));
            this.tbCutPlayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCutPlayer.Name = "tbCutPlayer";
            this.tbCutPlayer.Size = new System.Drawing.Size(77, 22);
            this.tbCutPlayer.Text = "Cut Player";
            this.tbCutPlayer.Click += new System.EventHandler(this.tbCutPlayer_Click);
            // 
            // tbEditPlayer
            // 
            this.tbEditPlayer.Image = ((System.Drawing.Image)(resources.GetObject("tbEditPlayer.Image")));
            this.tbEditPlayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbEditPlayer.Name = "tbEditPlayer";
            this.tbEditPlayer.Size = new System.Drawing.Size(78, 22);
            this.tbEditPlayer.Text = "Edit Player";
            this.tbEditPlayer.Click += new System.EventHandler(this.tbEditPlayer_Click);
            // 
            // toolPasteTransferHistory
            // 
            this.toolPasteTransferHistory.Image = ((System.Drawing.Image)(resources.GetObject("toolPasteTransferHistory.Image")));
            this.toolPasteTransferHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPasteTransferHistory.Name = "toolPasteTransferHistory";
            this.toolPasteTransferHistory.Size = new System.Drawing.Size(135, 22);
            this.toolPasteTransferHistory.Text = "Paste Transfer History";
            this.toolPasteTransferHistory.Click += new System.EventHandler(this.toolPasteTransferHistory_Click);
            // 
            // tbSaveList
            // 
            this.tbSaveList.Image = ((System.Drawing.Image)(resources.GetObject("tbSaveList.Image")));
            this.tbSaveList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSaveList.Name = "tbSaveList";
            this.tbSaveList.Size = new System.Drawing.Size(70, 22);
            this.tbSaveList.Text = "Save List";
            this.tbSaveList.Click += new System.EventHandler(this.tbSaveList_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(48, 22);
            this.toolStripButton1.Text = "Help";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // tmR_NationColumn1
            // 
            this.tmR_NationColumn1.DataPropertyName = "Nation";
            this.tmR_NationColumn1.HeaderText = "Nation";
            this.tmR_NationColumn1.Name = "tmR_NationColumn1";
            this.tmR_NationColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_NationColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_NationColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DateAcquire";
            this.dataGridViewTextBoxColumn2.HeaderText = "DateAcquire";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ASIwhenBuyed";
            this.dataGridViewTextBoxColumn3.HeaderText = "ASIwhenBuyed";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "AcquirePrice";
            this.dataGridViewTextBoxColumn4.HeaderText = "AcquirePrice";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "WeekInTeam";
            this.dataGridViewTextBoxColumn5.HeaderText = "WeekInTeam";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ManagCost";
            this.dataGridViewTextBoxColumn6.HeaderText = "ManagCost";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DateSell";
            this.dataGridViewTextBoxColumn7.HeaderText = "DateSell";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ASIwhenSold";
            this.dataGridViewTextBoxColumn8.HeaderText = "ASIwhenSold";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "SellPrice";
            this.dataGridViewTextBoxColumn9.HeaderText = "SellPrice";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Gain";
            this.dataGridViewTextBoxColumn10.HeaderText = "Gain";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // txtSumAcqPrices
            // 
            this.txtSumAcqPrices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(223)))));
            this.txtSumAcqPrices.Location = new System.Drawing.Point(236, 28);
            this.txtSumAcqPrices.Name = "txtSumAcqPrices";
            this.txtSumAcqPrices.Size = new System.Drawing.Size(96, 20);
            this.txtSumAcqPrices.TabIndex = 2;
            this.txtSumAcqPrices.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sum Acq Prices";
            // 
            // txtSumManagCosts
            // 
            this.txtSumManagCosts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(223)))));
            this.txtSumManagCosts.Location = new System.Drawing.Point(433, 28);
            this.txtSumManagCosts.Name = "txtSumManagCosts";
            this.txtSumManagCosts.Size = new System.Drawing.Size(96, 20);
            this.txtSumManagCosts.TabIndex = 2;
            this.txtSumManagCosts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl77
            // 
            this.lbl77.AutoSize = true;
            this.lbl77.Location = new System.Drawing.Point(338, 31);
            this.lbl77.Name = "lbl77";
            this.lbl77.Size = new System.Drawing.Size(96, 13);
            this.lbl77.TabIndex = 3;
            this.lbl77.Text = "Sum Manag. Costs";
            // 
            // txtSumSellPrices
            // 
            this.txtSumSellPrices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(223)))));
            this.txtSumSellPrices.Location = new System.Drawing.Point(613, 28);
            this.txtSumSellPrices.Name = "txtSumSellPrices";
            this.txtSumSellPrices.Size = new System.Drawing.Size(96, 20);
            this.txtSumSellPrices.TabIndex = 2;
            this.txtSumSellPrices.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sum Sell Prices";
            // 
            // txtTotalGain
            // 
            this.txtTotalGain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(223)))));
            this.txtTotalGain.Location = new System.Drawing.Point(767, 28);
            this.txtTotalGain.Name = "txtTotalGain";
            this.txtTotalGain.Size = new System.Drawing.Size(96, 20);
            this.txtTotalGain.TabIndex = 2;
            this.txtTotalGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(712, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total Gain";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(12, 37);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(94, 12);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Calcio Catania S.p.A.";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 29);
            this.label10.TabIndex = 5;
            this.label10.Text = "From an idea of";
            // 
            // TraderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 445);
            this.Controls.Add(this.txtSumManagCosts);
            this.Controls.Add(this.txtSumAcqPrices);
            this.Controls.Add(this.txtSumSellPrices);
            this.Controls.Add(this.txtTotalGain);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl77);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "TraderForm";
            this.Text = "Trader Form";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TraderForm_KeyPress);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TraderForm_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trading)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource playersBindingSource;
        private System.Windows.Forms.BindingSource tradingBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolPasteTransferHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_NationColumn tmR_NationColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        public Trading trading;
        private System.Windows.Forms.ToolStripButton tbNewPlayer;
        private System.Windows.Forms.ToolStripButton tbCutPlayer;
        private System.Windows.Forms.ToolStripButton tbEditPlayer;
        private System.Windows.Forms.ToolStripButton tbSaveList;
        private System.Windows.Forms.TextBox txtSumAcqPrices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSumManagCosts;
        private System.Windows.Forms.Label lbl77;
        private System.Windows.Forms.TextBox txtSumSellPrices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalGain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_NationColumn nationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private DataGridViewCustomColumns.TMR_DateColumn dateAcquireDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSIwhenBuyedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn acquirePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekInTeamDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn managCostDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_DateColumn DateSell;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASIwhenSold;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gainDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label10;
    }
}