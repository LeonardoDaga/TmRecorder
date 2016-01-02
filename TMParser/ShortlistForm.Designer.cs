﻿using NTR_Controls;
using NTR_Db;

namespace TMRecorder
{
    partial class ShortlistForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle61 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShortlistForm));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openPlayersPropertyPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlayersPageInTheTrophyManagerWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlayersTeamPageInTrophyBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindPL = new System.Windows.Forms.BindingSource(this.components);
            this.teamDS = new NTR_Common.TeamDS();
            this.bindGK = new System.Windows.Forms.BindingSource(this.components);
            this.playersDS = new NTR_Common.PlayersDS();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPlayers = new System.Windows.Forms.TabPage();
            this.dgGiocatori = new NTR_Controls.AeroDataGrid();
            this.nomeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_AgeColumn(this.components);
            this.nationalityDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_NationColumn(this.components);
            this.fPDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_FpColumn(this.components);
            this.aSIDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.forDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.resDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.velDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.marPreDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.conUnoDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.worRifDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.posAerDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.pasEleDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.croComDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.tecTirDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.tesLanDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.finDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.disDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.calDataGridViewTextBoxColumn1 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.rouDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dRDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dLDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dMCDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dMRDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dMLDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mCDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mRDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mLDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oMCDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oMRDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oMLDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ends = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabGK = new System.Windows.Forms.TabPage();
            this.dgPortieri = new NTR_Controls.AeroDataGrid();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmR_AgeColumn1 = new DataGridViewCustomColumns.TMR_AgeColumn(this.components);
            this.tmR_NationColumn1 = new DataGridViewCustomColumns.TMR_NationColumn(this.components);
            this.tmR_FpColumn1 = new DataGridViewCustomColumns.TMR_FpColumn(this.components);
            this.dataGridViewTextBoxColumn3 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.dataGridViewTextBoxColumn4 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.dataGridViewTextBoxColumn5 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.dataGridViewTextBoxColumn6 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.dataGridViewTextBoxColumn7 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.dataGridViewTextBoxColumn8 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.dataGridViewTextBoxColumn9 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.dataGridViewTextBoxColumn10 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.dataGridViewTextBoxColumn11 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.dataGridViewTextBoxColumn12 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.dataGridViewTextBoxColumn13 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.dataGridViewTextBoxColumn14 = new DataGridViewCustomColumns.TMR_PlayerDSColumn(this.components);
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CStrGK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportedNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabBrowser = new System.Windows.Forms.TabPage();
            this.webBrowser = new NTR_WebBrowser.NTR_Browser();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.loadFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedPlayersFromVisualizationAndDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateOnlyListedPlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindPL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindGK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersDS)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGiocatori)).BeginInit();
            this.tabGK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPortieri)).BeginInit();
            this.tabBrowser.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPlayersPropertyPageToolStripMenuItem,
            this.openPlayersPageInTheTrophyManagerWebsiteToolStripMenuItem,
            this.toolStripMenuItem4,
            this.openPlayersTeamPageInTrophyBrowserToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(329, 92);
            // 
            // openPlayersPropertyPageToolStripMenuItem
            // 
            this.openPlayersPropertyPageToolStripMenuItem.Name = "openPlayersPropertyPageToolStripMenuItem";
            this.openPlayersPropertyPageToolStripMenuItem.Size = new System.Drawing.Size(328, 22);
            this.openPlayersPropertyPageToolStripMenuItem.Text = "Open Player\'s property page [double click]";
            this.openPlayersPropertyPageToolStripMenuItem.Click += new System.EventHandler(this.openPlayersPropertyPageToolStripMenuItem_Click);
            // 
            // openPlayersPageInTheTrophyManagerWebsiteToolStripMenuItem
            // 
            this.openPlayersPageInTheTrophyManagerWebsiteToolStripMenuItem.Name = "openPlayersPageInTheTrophyManagerWebsiteToolStripMenuItem";
            this.openPlayersPageInTheTrophyManagerWebsiteToolStripMenuItem.Size = new System.Drawing.Size(328, 22);
            this.openPlayersPageInTheTrophyManagerWebsiteToolStripMenuItem.Text = "Open Players Profile Page in the Trophy Browser";
            this.openPlayersPageInTheTrophyManagerWebsiteToolStripMenuItem.Click += new System.EventHandler(this.openPlayersPageInTheTrophyManagerWebsiteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(328, 22);
            this.toolStripMenuItem4.Text = "Open Players Scouts Page in the Trophy Browser";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.openPlayersScoutPageInTheTrophyManagerWebsiteToolStripMenuItem_Click);
            // 
            // openPlayersTeamPageInTrophyBrowserToolStripMenuItem
            // 
            this.openPlayersTeamPageInTrophyBrowserToolStripMenuItem.Name = "openPlayersTeamPageInTrophyBrowserToolStripMenuItem";
            this.openPlayersTeamPageInTrophyBrowserToolStripMenuItem.Size = new System.Drawing.Size(328, 22);
            this.openPlayersTeamPageInTrophyBrowserToolStripMenuItem.Text = "Open Player\'s Team Page in Trophy Browser";
            this.openPlayersTeamPageInTrophyBrowserToolStripMenuItem.Click += new System.EventHandler(this.openPlayersTeamPageInTrophyBrowserToolStripMenuItem_Click);
            // 
            // bindPL
            // 
            this.bindPL.DataMember = "GiocatoriNSkill";
            this.bindPL.DataSource = this.teamDS;
            this.bindPL.Filter = "FPn>0";
            // 
            // teamDS
            // 
            this.teamDS.DataSetName = "TeamDS";
            this.teamDS.last_week_loaded = -1;
            this.teamDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindGK
            // 
            this.bindGK.DataMember = "GiocatoriNSkill";
            this.bindGK.DataSource = this.teamDS;
            this.bindGK.Filter = "FPn=0";
            // 
            // playersDS
            // 
            this.playersDS.DataSetName = "PlayersData";
            this.playersDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(885, 350);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(885, 375);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Click += new System.EventHandler(this.toolStripContainer1_TopToolStripPanel_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPlayers);
            this.tabControl.Controls.Add(this.tabGK);
            this.tabControl.Controls.Add(this.tabBrowser);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(885, 350);
            this.tabControl.TabIndex = 2;
            // 
            // tabPlayers
            // 
            this.tabPlayers.Controls.Add(this.dgGiocatori);
            this.tabPlayers.Location = new System.Drawing.Point(4, 22);
            this.tabPlayers.Name = "tabPlayers";
            this.tabPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlayers.Size = new System.Drawing.Size(877, 324);
            this.tabPlayers.TabIndex = 0;
            this.tabPlayers.Text = "Players";
            this.tabPlayers.UseVisualStyleBackColor = true;
            // 
            // dgGiocatori
            // 
            this.dgGiocatori.AllowUserToAddRows = false;
            this.dgGiocatori.AllowUserToDeleteRows = false;
            this.dgGiocatori.AllowUserToOrderColumns = true;
            this.dgGiocatori.AutoGenerateColumns = false;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgGiocatori.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle33;
            this.dgGiocatori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGiocatori.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeDataGridViewTextBoxColumn1,
            this.ageDataGridViewTextBoxColumn,
            this.nationalityDataGridViewTextBoxColumn1,
            this.fPDataGridViewTextBoxColumn1,
            this.aSIDataGridViewTextBoxColumn1,
            this.forDataGridViewTextBoxColumn1,
            this.resDataGridViewTextBoxColumn1,
            this.velDataGridViewTextBoxColumn1,
            this.marPreDataGridViewTextBoxColumn1,
            this.conUnoDataGridViewTextBoxColumn1,
            this.worRifDataGridViewTextBoxColumn1,
            this.posAerDataGridViewTextBoxColumn1,
            this.pasEleDataGridViewTextBoxColumn1,
            this.croComDataGridViewTextBoxColumn1,
            this.tecTirDataGridViewTextBoxColumn1,
            this.tesLanDataGridViewTextBoxColumn1,
            this.finDataGridViewTextBoxColumn1,
            this.disDataGridViewTextBoxColumn,
            this.calDataGridViewTextBoxColumn1,
            this.rouDataGridViewTextBoxColumn1,
            this.cTI,
            this.SSD,
            this.Rec,
            this.CStr,
            this.dCDataGridViewTextBoxColumn1,
            this.dRDataGridViewTextBoxColumn1,
            this.dLDataGridViewTextBoxColumn1,
            this.dMCDataGridViewTextBoxColumn1,
            this.dMRDataGridViewTextBoxColumn1,
            this.dMLDataGridViewTextBoxColumn1,
            this.mCDataGridViewTextBoxColumn1,
            this.mRDataGridViewTextBoxColumn1,
            this.mLDataGridViewTextBoxColumn1,
            this.oMCDataGridViewTextBoxColumn1,
            this.oMRDataGridViewTextBoxColumn1,
            this.oMLDataGridViewTextBoxColumn1,
            this.fCDataGridViewTextBoxColumn1,
            this.Team,
            this.Ends,
            this.Notes});
            this.dgGiocatori.ContextMenuStrip = this.contextMenuStrip;
            this.dgGiocatori.DataCollection = null;
            this.dgGiocatori.DataSource = this.bindPL;
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle53.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle53.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            dataGridViewCellStyle53.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle53.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle53.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle53.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgGiocatori.DefaultCellStyle = dataGridViewCellStyle53;
            this.dgGiocatori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgGiocatori.Location = new System.Drawing.Point(3, 3);
            this.dgGiocatori.Name = "dgGiocatori";
            this.dgGiocatori.ReadOnly = true;
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle54.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle54.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle54.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle54.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle54.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgGiocatori.RowHeadersDefaultCellStyle = dataGridViewCellStyle54;
            this.dgGiocatori.RowHeadersWidth = 20;
            this.dgGiocatori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgGiocatori.Size = new System.Drawing.Size(871, 318);
            this.dgGiocatori.TabIndex = 0;
            this.dgGiocatori.Sorted += new System.EventHandler(this.dgGiocatori_Sorted);
            this.dgGiocatori.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgGiocatori_MouseDoubleClick);
            // 
            // nomeDataGridViewTextBoxColumn1
            // 
            this.nomeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nomeDataGridViewTextBoxColumn1.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn1.Frozen = true;
            this.nomeDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nomeDataGridViewTextBoxColumn1.MinimumWidth = 10;
            this.nomeDataGridViewTextBoxColumn1.Name = "nomeDataGridViewTextBoxColumn1";
            this.nomeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nomeDataGridViewTextBoxColumn1.Width = 55;
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "wBorn";
            this.ageDataGridViewTextBoxColumn.Frozen = true;
            this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            this.ageDataGridViewTextBoxColumn.ReadOnly = true;
            this.ageDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ageDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ageDataGridViewTextBoxColumn.When = new System.DateTime(2015, 12, 27, 10, 9, 51, 210);
            this.ageDataGridViewTextBoxColumn.Width = 32;
            // 
            // nationalityDataGridViewTextBoxColumn1
            // 
            this.nationalityDataGridViewTextBoxColumn1.DataPropertyName = "Nationality";
            this.nationalityDataGridViewTextBoxColumn1.Frozen = true;
            this.nationalityDataGridViewTextBoxColumn1.HeaderText = "Nat";
            this.nationalityDataGridViewTextBoxColumn1.MinimumWidth = 30;
            this.nationalityDataGridViewTextBoxColumn1.Name = "nationalityDataGridViewTextBoxColumn1";
            this.nationalityDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nationalityDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nationalityDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.nationalityDataGridViewTextBoxColumn1.ToolTipText = "Nationality";
            this.nationalityDataGridViewTextBoxColumn1.Width = 30;
            // 
            // fPDataGridViewTextBoxColumn1
            // 
            this.fPDataGridViewTextBoxColumn1.DataPropertyName = "FPn";
            this.fPDataGridViewTextBoxColumn1.Frozen = true;
            this.fPDataGridViewTextBoxColumn1.HeaderText = "FP";
            this.fPDataGridViewTextBoxColumn1.Name = "fPDataGridViewTextBoxColumn1";
            this.fPDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fPDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fPDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fPDataGridViewTextBoxColumn1.ToolTipText = "Favourite Position";
            this.fPDataGridViewTextBoxColumn1.Width = 42;
            // 
            // aSIDataGridViewTextBoxColumn1
            // 
            this.aSIDataGridViewTextBoxColumn1.DataPropertyName = "ASI";
            this.aSIDataGridViewTextBoxColumn1.HeaderText = "ASI";
            this.aSIDataGridViewTextBoxColumn1.Name = "aSIDataGridViewTextBoxColumn1";
            this.aSIDataGridViewTextBoxColumn1.ReadOnly = true;
            this.aSIDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aSIDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.aSIDataGridViewTextBoxColumn1.Width = 46;
            // 
            // forDataGridViewTextBoxColumn1
            // 
            this.forDataGridViewTextBoxColumn1.DataPropertyName = "For";
            this.forDataGridViewTextBoxColumn1.HeaderText = "Str";
            this.forDataGridViewTextBoxColumn1.Name = "forDataGridViewTextBoxColumn1";
            this.forDataGridViewTextBoxColumn1.ReadOnly = true;
            this.forDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.forDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.forDataGridViewTextBoxColumn1.ToolTipText = "Strength";
            this.forDataGridViewTextBoxColumn1.Width = 23;
            // 
            // resDataGridViewTextBoxColumn1
            // 
            this.resDataGridViewTextBoxColumn1.DataPropertyName = "Res";
            this.resDataGridViewTextBoxColumn1.HeaderText = "Sta";
            this.resDataGridViewTextBoxColumn1.Name = "resDataGridViewTextBoxColumn1";
            this.resDataGridViewTextBoxColumn1.ReadOnly = true;
            this.resDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.resDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.resDataGridViewTextBoxColumn1.ToolTipText = "Stamina";
            this.resDataGridViewTextBoxColumn1.Width = 23;
            // 
            // velDataGridViewTextBoxColumn1
            // 
            this.velDataGridViewTextBoxColumn1.DataPropertyName = "Vel";
            this.velDataGridViewTextBoxColumn1.HeaderText = "Pac";
            this.velDataGridViewTextBoxColumn1.Name = "velDataGridViewTextBoxColumn1";
            this.velDataGridViewTextBoxColumn1.ReadOnly = true;
            this.velDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.velDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.velDataGridViewTextBoxColumn1.ToolTipText = "Pace";
            this.velDataGridViewTextBoxColumn1.Width = 23;
            // 
            // marPreDataGridViewTextBoxColumn1
            // 
            this.marPreDataGridViewTextBoxColumn1.DataPropertyName = "Mar-Pre";
            this.marPreDataGridViewTextBoxColumn1.HeaderText = "Mar";
            this.marPreDataGridViewTextBoxColumn1.Name = "marPreDataGridViewTextBoxColumn1";
            this.marPreDataGridViewTextBoxColumn1.ReadOnly = true;
            this.marPreDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.marPreDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.marPreDataGridViewTextBoxColumn1.ToolTipText = "Marking";
            this.marPreDataGridViewTextBoxColumn1.Width = 23;
            // 
            // conUnoDataGridViewTextBoxColumn1
            // 
            this.conUnoDataGridViewTextBoxColumn1.DataPropertyName = "Con-Uno";
            this.conUnoDataGridViewTextBoxColumn1.HeaderText = "Tak";
            this.conUnoDataGridViewTextBoxColumn1.Name = "conUnoDataGridViewTextBoxColumn1";
            this.conUnoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.conUnoDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.conUnoDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.conUnoDataGridViewTextBoxColumn1.ToolTipText = "Takling";
            this.conUnoDataGridViewTextBoxColumn1.Width = 23;
            // 
            // worRifDataGridViewTextBoxColumn1
            // 
            this.worRifDataGridViewTextBoxColumn1.DataPropertyName = "Wor-Rif";
            this.worRifDataGridViewTextBoxColumn1.HeaderText = "Wor";
            this.worRifDataGridViewTextBoxColumn1.Name = "worRifDataGridViewTextBoxColumn1";
            this.worRifDataGridViewTextBoxColumn1.ReadOnly = true;
            this.worRifDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.worRifDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.worRifDataGridViewTextBoxColumn1.ToolTipText = "Work Rate";
            this.worRifDataGridViewTextBoxColumn1.Width = 23;
            // 
            // posAerDataGridViewTextBoxColumn1
            // 
            this.posAerDataGridViewTextBoxColumn1.DataPropertyName = "Pos-Aer";
            this.posAerDataGridViewTextBoxColumn1.HeaderText = "Pos";
            this.posAerDataGridViewTextBoxColumn1.Name = "posAerDataGridViewTextBoxColumn1";
            this.posAerDataGridViewTextBoxColumn1.ReadOnly = true;
            this.posAerDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.posAerDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.posAerDataGridViewTextBoxColumn1.ToolTipText = "Position";
            this.posAerDataGridViewTextBoxColumn1.Width = 23;
            // 
            // pasEleDataGridViewTextBoxColumn1
            // 
            this.pasEleDataGridViewTextBoxColumn1.DataPropertyName = "Pas-Ele";
            this.pasEleDataGridViewTextBoxColumn1.HeaderText = "Pas";
            this.pasEleDataGridViewTextBoxColumn1.Name = "pasEleDataGridViewTextBoxColumn1";
            this.pasEleDataGridViewTextBoxColumn1.ReadOnly = true;
            this.pasEleDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pasEleDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.pasEleDataGridViewTextBoxColumn1.ToolTipText = "Passing";
            this.pasEleDataGridViewTextBoxColumn1.Width = 23;
            // 
            // croComDataGridViewTextBoxColumn1
            // 
            this.croComDataGridViewTextBoxColumn1.DataPropertyName = "Cro-Com";
            this.croComDataGridViewTextBoxColumn1.HeaderText = "Cro";
            this.croComDataGridViewTextBoxColumn1.Name = "croComDataGridViewTextBoxColumn1";
            this.croComDataGridViewTextBoxColumn1.ReadOnly = true;
            this.croComDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.croComDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.croComDataGridViewTextBoxColumn1.ToolTipText = "Cross";
            this.croComDataGridViewTextBoxColumn1.Width = 23;
            // 
            // tecTirDataGridViewTextBoxColumn1
            // 
            this.tecTirDataGridViewTextBoxColumn1.DataPropertyName = "Tec-Tir";
            this.tecTirDataGridViewTextBoxColumn1.HeaderText = "Tec";
            this.tecTirDataGridViewTextBoxColumn1.Name = "tecTirDataGridViewTextBoxColumn1";
            this.tecTirDataGridViewTextBoxColumn1.ReadOnly = true;
            this.tecTirDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tecTirDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tecTirDataGridViewTextBoxColumn1.ToolTipText = "Technique";
            this.tecTirDataGridViewTextBoxColumn1.Width = 23;
            // 
            // tesLanDataGridViewTextBoxColumn1
            // 
            this.tesLanDataGridViewTextBoxColumn1.DataPropertyName = "Tes-Lan";
            this.tesLanDataGridViewTextBoxColumn1.HeaderText = "Hea";
            this.tesLanDataGridViewTextBoxColumn1.Name = "tesLanDataGridViewTextBoxColumn1";
            this.tesLanDataGridViewTextBoxColumn1.ReadOnly = true;
            this.tesLanDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tesLanDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tesLanDataGridViewTextBoxColumn1.ToolTipText = "Heading";
            this.tesLanDataGridViewTextBoxColumn1.Width = 23;
            // 
            // finDataGridViewTextBoxColumn1
            // 
            this.finDataGridViewTextBoxColumn1.DataPropertyName = "Fin";
            this.finDataGridViewTextBoxColumn1.HeaderText = "Fin";
            this.finDataGridViewTextBoxColumn1.Name = "finDataGridViewTextBoxColumn1";
            this.finDataGridViewTextBoxColumn1.ReadOnly = true;
            this.finDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.finDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.finDataGridViewTextBoxColumn1.ToolTipText = "Finalization";
            this.finDataGridViewTextBoxColumn1.Width = 23;
            // 
            // disDataGridViewTextBoxColumn
            // 
            this.disDataGridViewTextBoxColumn.DataPropertyName = "Dis";
            this.disDataGridViewTextBoxColumn.HeaderText = "Lon";
            this.disDataGridViewTextBoxColumn.Name = "disDataGridViewTextBoxColumn";
            this.disDataGridViewTextBoxColumn.ReadOnly = true;
            this.disDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.disDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.disDataGridViewTextBoxColumn.ToolTipText = "Longshots";
            this.disDataGridViewTextBoxColumn.Width = 23;
            // 
            // calDataGridViewTextBoxColumn1
            // 
            this.calDataGridViewTextBoxColumn1.DataPropertyName = "Cal";
            this.calDataGridViewTextBoxColumn1.HeaderText = "Set";
            this.calDataGridViewTextBoxColumn1.Name = "calDataGridViewTextBoxColumn1";
            this.calDataGridViewTextBoxColumn1.ReadOnly = true;
            this.calDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.calDataGridViewTextBoxColumn1.ToolTipText = "Set Pieces";
            this.calDataGridViewTextBoxColumn1.Width = 23;
            // 
            // rouDataGridViewTextBoxColumn1
            // 
            this.rouDataGridViewTextBoxColumn1.DataPropertyName = "Rou";
            dataGridViewCellStyle34.Format = "N1";
            dataGridViewCellStyle34.NullValue = "-";
            this.rouDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle34;
            this.rouDataGridViewTextBoxColumn1.HeaderText = "Rou";
            this.rouDataGridViewTextBoxColumn1.Name = "rouDataGridViewTextBoxColumn1";
            this.rouDataGridViewTextBoxColumn1.ReadOnly = true;
            this.rouDataGridViewTextBoxColumn1.ToolTipText = "Routine";
            this.rouDataGridViewTextBoxColumn1.Width = 33;
            // 
            // cTI
            // 
            this.cTI.DataPropertyName = "cTI";
            dataGridViewCellStyle35.Format = "N1";
            dataGridViewCellStyle35.NullValue = "-";
            this.cTI.DefaultCellStyle = dataGridViewCellStyle35;
            this.cTI.HeaderText = "cTI";
            this.cTI.Name = "cTI";
            this.cTI.ReadOnly = true;
            this.cTI.ToolTipText = "Calculated TI, computed from the ASI increase from the last week";
            this.cTI.Width = 32;
            // 
            // SSD
            // 
            this.SSD.DataPropertyName = "SSD";
            dataGridViewCellStyle36.Format = "N1";
            dataGridViewCellStyle36.NullValue = "-";
            this.SSD.DefaultCellStyle = dataGridViewCellStyle36;
            this.SSD.HeaderText = "SSD";
            this.SSD.Name = "SSD";
            this.SSD.ReadOnly = true;
            this.SSD.ToolTipText = "Skill sum deviation - The sum of the skill decimal, computed from the actual ASI";
            this.SSD.Width = 26;
            // 
            // Rec
            // 
            this.Rec.DataPropertyName = "Rec";
            this.Rec.HeaderText = "Rec";
            this.Rec.Name = "Rec";
            this.Rec.ReadOnly = true;
            this.Rec.ToolTipText = "Official TM Rating";
            this.Rec.Width = 26;
            // 
            // CStr
            // 
            this.CStr.DataPropertyName = "CStr";
            dataGridViewCellStyle37.Format = "N2";
            dataGridViewCellStyle37.NullValue = null;
            this.CStr.DefaultCellStyle = dataGridViewCellStyle37;
            this.CStr.HeaderText = "CStr";
            this.CStr.Name = "CStr";
            this.CStr.ReadOnly = true;
            this.CStr.ToolTipText = "Computed Stars (taking into account the SSD)";
            this.CStr.Width = 32;
            // 
            // dCDataGridViewTextBoxColumn1
            // 
            this.dCDataGridViewTextBoxColumn1.DataPropertyName = "DC";
            dataGridViewCellStyle38.Format = "N1";
            this.dCDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle38;
            this.dCDataGridViewTextBoxColumn1.HeaderText = "DC";
            this.dCDataGridViewTextBoxColumn1.Name = "dCDataGridViewTextBoxColumn1";
            this.dCDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dCDataGridViewTextBoxColumn1.Width = 30;
            // 
            // dRDataGridViewTextBoxColumn1
            // 
            this.dRDataGridViewTextBoxColumn1.DataPropertyName = "DR";
            dataGridViewCellStyle39.Format = "N1";
            this.dRDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle39;
            this.dRDataGridViewTextBoxColumn1.HeaderText = "DR";
            this.dRDataGridViewTextBoxColumn1.Name = "dRDataGridViewTextBoxColumn1";
            this.dRDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dRDataGridViewTextBoxColumn1.Width = 30;
            // 
            // dLDataGridViewTextBoxColumn1
            // 
            this.dLDataGridViewTextBoxColumn1.DataPropertyName = "DL";
            dataGridViewCellStyle40.Format = "N1";
            this.dLDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle40;
            this.dLDataGridViewTextBoxColumn1.HeaderText = "DL";
            this.dLDataGridViewTextBoxColumn1.Name = "dLDataGridViewTextBoxColumn1";
            this.dLDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dLDataGridViewTextBoxColumn1.Width = 30;
            // 
            // dMCDataGridViewTextBoxColumn1
            // 
            this.dMCDataGridViewTextBoxColumn1.DataPropertyName = "DMC";
            dataGridViewCellStyle41.Format = "N1";
            this.dMCDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle41;
            this.dMCDataGridViewTextBoxColumn1.HeaderText = "DMC";
            this.dMCDataGridViewTextBoxColumn1.Name = "dMCDataGridViewTextBoxColumn1";
            this.dMCDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dMCDataGridViewTextBoxColumn1.Width = 30;
            // 
            // dMRDataGridViewTextBoxColumn1
            // 
            this.dMRDataGridViewTextBoxColumn1.DataPropertyName = "DMR";
            dataGridViewCellStyle42.Format = "N1";
            this.dMRDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle42;
            this.dMRDataGridViewTextBoxColumn1.HeaderText = "DMR";
            this.dMRDataGridViewTextBoxColumn1.Name = "dMRDataGridViewTextBoxColumn1";
            this.dMRDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dMRDataGridViewTextBoxColumn1.Width = 30;
            // 
            // dMLDataGridViewTextBoxColumn1
            // 
            this.dMLDataGridViewTextBoxColumn1.DataPropertyName = "DML";
            dataGridViewCellStyle43.Format = "N1";
            this.dMLDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle43;
            this.dMLDataGridViewTextBoxColumn1.HeaderText = "DML";
            this.dMLDataGridViewTextBoxColumn1.Name = "dMLDataGridViewTextBoxColumn1";
            this.dMLDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dMLDataGridViewTextBoxColumn1.Width = 30;
            // 
            // mCDataGridViewTextBoxColumn1
            // 
            this.mCDataGridViewTextBoxColumn1.DataPropertyName = "MC";
            dataGridViewCellStyle44.Format = "N1";
            this.mCDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle44;
            this.mCDataGridViewTextBoxColumn1.HeaderText = "MC";
            this.mCDataGridViewTextBoxColumn1.Name = "mCDataGridViewTextBoxColumn1";
            this.mCDataGridViewTextBoxColumn1.ReadOnly = true;
            this.mCDataGridViewTextBoxColumn1.Width = 30;
            // 
            // mRDataGridViewTextBoxColumn1
            // 
            this.mRDataGridViewTextBoxColumn1.DataPropertyName = "MR";
            dataGridViewCellStyle45.Format = "N1";
            this.mRDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle45;
            this.mRDataGridViewTextBoxColumn1.HeaderText = "MR";
            this.mRDataGridViewTextBoxColumn1.Name = "mRDataGridViewTextBoxColumn1";
            this.mRDataGridViewTextBoxColumn1.ReadOnly = true;
            this.mRDataGridViewTextBoxColumn1.Width = 30;
            // 
            // mLDataGridViewTextBoxColumn1
            // 
            this.mLDataGridViewTextBoxColumn1.DataPropertyName = "ML";
            dataGridViewCellStyle46.Format = "N1";
            this.mLDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle46;
            this.mLDataGridViewTextBoxColumn1.HeaderText = "ML";
            this.mLDataGridViewTextBoxColumn1.Name = "mLDataGridViewTextBoxColumn1";
            this.mLDataGridViewTextBoxColumn1.ReadOnly = true;
            this.mLDataGridViewTextBoxColumn1.Width = 30;
            // 
            // oMCDataGridViewTextBoxColumn1
            // 
            this.oMCDataGridViewTextBoxColumn1.DataPropertyName = "OMC";
            dataGridViewCellStyle47.Format = "N1";
            this.oMCDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle47;
            this.oMCDataGridViewTextBoxColumn1.HeaderText = "OMC";
            this.oMCDataGridViewTextBoxColumn1.Name = "oMCDataGridViewTextBoxColumn1";
            this.oMCDataGridViewTextBoxColumn1.ReadOnly = true;
            this.oMCDataGridViewTextBoxColumn1.Width = 30;
            // 
            // oMRDataGridViewTextBoxColumn1
            // 
            this.oMRDataGridViewTextBoxColumn1.DataPropertyName = "OMR";
            dataGridViewCellStyle48.Format = "N1";
            this.oMRDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle48;
            this.oMRDataGridViewTextBoxColumn1.HeaderText = "OMR";
            this.oMRDataGridViewTextBoxColumn1.Name = "oMRDataGridViewTextBoxColumn1";
            this.oMRDataGridViewTextBoxColumn1.ReadOnly = true;
            this.oMRDataGridViewTextBoxColumn1.Width = 30;
            // 
            // oMLDataGridViewTextBoxColumn1
            // 
            this.oMLDataGridViewTextBoxColumn1.DataPropertyName = "OML";
            dataGridViewCellStyle49.Format = "N1";
            this.oMLDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle49;
            this.oMLDataGridViewTextBoxColumn1.HeaderText = "OML";
            this.oMLDataGridViewTextBoxColumn1.Name = "oMLDataGridViewTextBoxColumn1";
            this.oMLDataGridViewTextBoxColumn1.ReadOnly = true;
            this.oMLDataGridViewTextBoxColumn1.Width = 30;
            // 
            // fCDataGridViewTextBoxColumn1
            // 
            this.fCDataGridViewTextBoxColumn1.DataPropertyName = "FC";
            dataGridViewCellStyle50.Format = "N1";
            this.fCDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle50;
            this.fCDataGridViewTextBoxColumn1.HeaderText = "FC";
            this.fCDataGridViewTextBoxColumn1.Name = "fCDataGridViewTextBoxColumn1";
            this.fCDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fCDataGridViewTextBoxColumn1.Width = 30;
            // 
            // Team
            // 
            this.Team.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Team.DataPropertyName = "Bid";
            dataGridViewCellStyle51.Format = "N0";
            dataGridViewCellStyle51.NullValue = "-";
            this.Team.DefaultCellStyle = dataGridViewCellStyle51;
            this.Team.HeaderText = "Bid";
            this.Team.Name = "Team";
            this.Team.ReadOnly = true;
            this.Team.ToolTipText = "Current Bid";
            this.Team.Width = 43;
            // 
            // Ends
            // 
            this.Ends.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ends.DataPropertyName = "Ends";
            dataGridViewCellStyle52.Format = "dd/MM hh:mm";
            dataGridViewCellStyle52.NullValue = "-";
            this.Ends.DefaultCellStyle = dataGridViewCellStyle52;
            this.Ends.HeaderText = "Bid End";
            this.Ends.Name = "Ends";
            this.Ends.ReadOnly = true;
            this.Ends.Width = 61;
            // 
            // Notes
            // 
            this.Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Notes.DataPropertyName = "Notes";
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            this.Notes.ReadOnly = true;
            // 
            // tabGK
            // 
            this.tabGK.Controls.Add(this.dgPortieri);
            this.tabGK.Location = new System.Drawing.Point(4, 22);
            this.tabGK.Name = "tabGK";
            this.tabGK.Padding = new System.Windows.Forms.Padding(3);
            this.tabGK.Size = new System.Drawing.Size(877, 324);
            this.tabGK.TabIndex = 1;
            this.tabGK.Text = "GKs";
            this.tabGK.UseVisualStyleBackColor = true;
            // 
            // dgPortieri
            // 
            this.dgPortieri.AllowUserToAddRows = false;
            this.dgPortieri.AllowUserToDeleteRows = false;
            this.dgPortieri.AllowUserToOrderColumns = true;
            this.dgPortieri.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPortieri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPortieri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPortieri.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.tmR_AgeColumn1,
            this.tmR_NationColumn1,
            this.tmR_FpColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn15,
            this.CStrGK,
            this.dataGridViewTextBoxColumn32,
            this.Bid,
            this.dataGridViewTextBoxColumn18,
            this.ImportedNotes});
            this.dgPortieri.DataCollection = null;
            this.dgPortieri.DataSource = this.bindGK;
            dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle60.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle60.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            dataGridViewCellStyle60.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle60.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle60.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle60.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPortieri.DefaultCellStyle = dataGridViewCellStyle60;
            this.dgPortieri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPortieri.Location = new System.Drawing.Point(3, 3);
            this.dgPortieri.Name = "dgPortieri";
            this.dgPortieri.ReadOnly = true;
            dataGridViewCellStyle61.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle61.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle61.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle61.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle61.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle61.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPortieri.RowHeadersDefaultCellStyle = dataGridViewCellStyle61;
            this.dgPortieri.RowHeadersWidth = 20;
            this.dgPortieri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPortieri.Size = new System.Drawing.Size(871, 318);
            this.dgPortieri.TabIndex = 1;
            this.dgPortieri.Sorted += new System.EventHandler(this.dgPortieri_Sorted);
            this.dgPortieri.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgGiocatori_MouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nome";
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 55;
            // 
            // tmR_AgeColumn1
            // 
            this.tmR_AgeColumn1.DataPropertyName = "wBorn";
            this.tmR_AgeColumn1.Frozen = true;
            this.tmR_AgeColumn1.HeaderText = "Age";
            this.tmR_AgeColumn1.Name = "tmR_AgeColumn1";
            this.tmR_AgeColumn1.ReadOnly = true;
            this.tmR_AgeColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_AgeColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_AgeColumn1.When = new System.DateTime(2015, 12, 27, 10, 9, 51, 680);
            this.tmR_AgeColumn1.Width = 32;
            // 
            // tmR_NationColumn1
            // 
            this.tmR_NationColumn1.DataPropertyName = "Nationality";
            this.tmR_NationColumn1.Frozen = true;
            this.tmR_NationColumn1.HeaderText = "Nat";
            this.tmR_NationColumn1.MinimumWidth = 30;
            this.tmR_NationColumn1.Name = "tmR_NationColumn1";
            this.tmR_NationColumn1.ReadOnly = true;
            this.tmR_NationColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_NationColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_NationColumn1.ToolTipText = "Nationality";
            this.tmR_NationColumn1.Width = 30;
            // 
            // tmR_FpColumn1
            // 
            this.tmR_FpColumn1.DataPropertyName = "FPn";
            this.tmR_FpColumn1.Frozen = true;
            this.tmR_FpColumn1.HeaderText = "FP";
            this.tmR_FpColumn1.Name = "tmR_FpColumn1";
            this.tmR_FpColumn1.ReadOnly = true;
            this.tmR_FpColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_FpColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_FpColumn1.ToolTipText = "Favourite Position";
            this.tmR_FpColumn1.Width = 42;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ASI";
            this.dataGridViewTextBoxColumn3.HeaderText = "ASI";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.Width = 46;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "For";
            this.dataGridViewTextBoxColumn4.HeaderText = "Str";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.ToolTipText = "Strength";
            this.dataGridViewTextBoxColumn4.Width = 25;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Res";
            this.dataGridViewTextBoxColumn5.HeaderText = "Sta";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn5.ToolTipText = "Stamina";
            this.dataGridViewTextBoxColumn5.Width = 25;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Vel";
            this.dataGridViewTextBoxColumn6.HeaderText = "Pac";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn6.ToolTipText = "Pace";
            this.dataGridViewTextBoxColumn6.Width = 25;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Mar-Pre";
            this.dataGridViewTextBoxColumn7.HeaderText = "Han";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn7.ToolTipText = "Hamdling";
            this.dataGridViewTextBoxColumn7.Width = 25;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Con-Uno";
            this.dataGridViewTextBoxColumn8.HeaderText = "One";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn8.ToolTipText = "One to One";
            this.dataGridViewTextBoxColumn8.Width = 25;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Wor-Rif";
            this.dataGridViewTextBoxColumn9.HeaderText = "Ref";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn9.ToolTipText = "Reflexes";
            this.dataGridViewTextBoxColumn9.Width = 25;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Pos-Aer";
            this.dataGridViewTextBoxColumn10.HeaderText = "Ari";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn10.ToolTipText = "Arial Ability";
            this.dataGridViewTextBoxColumn10.Width = 25;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Pas-Ele";
            this.dataGridViewTextBoxColumn11.HeaderText = "Jum";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn11.ToolTipText = "Jumping";
            this.dataGridViewTextBoxColumn11.Width = 25;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Cro-Com";
            this.dataGridViewTextBoxColumn12.HeaderText = "Com";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn12.ToolTipText = "Communication";
            this.dataGridViewTextBoxColumn12.Width = 25;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Tec-Tir";
            this.dataGridViewTextBoxColumn13.HeaderText = "Kic";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn13.ToolTipText = "Kicking";
            this.dataGridViewTextBoxColumn13.Width = 25;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Tes-Lan";
            this.dataGridViewTextBoxColumn14.HeaderText = "Thr";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn14.ToolTipText = "Throwing";
            this.dataGridViewTextBoxColumn14.Width = 25;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Rou";
            dataGridViewCellStyle21.Format = "N1";
            dataGridViewCellStyle21.NullValue = "-";
            this.dataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn19.HeaderText = "Rou";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 35;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "cTI";
            dataGridViewCellStyle22.Format = "N1";
            dataGridViewCellStyle22.NullValue = "-";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn1.HeaderText = "cTI";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Computed TI - TI calculated from the ASI of the actual and last week";
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "SSD";
            dataGridViewCellStyle55.Format = "N1";
            dataGridViewCellStyle55.NullValue = "-";
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle55;
            this.dataGridViewTextBoxColumn16.HeaderText = "SSD";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.ToolTipText = "Skill Sum Deviation - Missed skill decimals, computed from actual ASI";
            this.dataGridViewTextBoxColumn16.Width = 30;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Rec";
            this.dataGridViewTextBoxColumn15.HeaderText = "Rec";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.ToolTipText = "Official TM Rating";
            this.dataGridViewTextBoxColumn15.Width = 26;
            // 
            // CStrGK
            // 
            this.CStrGK.DataPropertyName = "CStr";
            dataGridViewCellStyle56.Format = "N2";
            dataGridViewCellStyle56.NullValue = "-";
            this.CStrGK.DefaultCellStyle = dataGridViewCellStyle56;
            this.CStrGK.HeaderText = "CStar";
            this.CStrGK.Name = "CStrGK";
            this.CStrGK.ReadOnly = true;
            this.CStrGK.ToolTipText = "Computed Stars (taking into account the SSD)";
            this.CStrGK.Width = 31;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "GK";
            dataGridViewCellStyle57.Format = "N1";
            this.dataGridViewTextBoxColumn32.DefaultCellStyle = dataGridViewCellStyle57;
            this.dataGridViewTextBoxColumn32.HeaderText = "GK";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            this.dataGridViewTextBoxColumn32.Width = 35;
            // 
            // Bid
            // 
            this.Bid.DataPropertyName = "Bid";
            dataGridViewCellStyle58.Format = "N0";
            dataGridViewCellStyle58.NullValue = "-";
            this.Bid.DefaultCellStyle = dataGridViewCellStyle58;
            this.Bid.HeaderText = "Bid";
            this.Bid.Name = "Bid";
            this.Bid.ReadOnly = true;
            this.Bid.Width = 70;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Ends";
            dataGridViewCellStyle59.Format = "dd/MM hh:mm";
            dataGridViewCellStyle59.NullValue = "-";
            this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle59;
            this.dataGridViewTextBoxColumn18.HeaderText = "Bid End";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 61;
            // 
            // ImportedNotes
            // 
            this.ImportedNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ImportedNotes.DataPropertyName = "ImportedNotes";
            this.ImportedNotes.HeaderText = "Notes";
            this.ImportedNotes.Name = "ImportedNotes";
            this.ImportedNotes.ReadOnly = true;
            // 
            // tabBrowser
            // 
            this.tabBrowser.Controls.Add(this.webBrowser);
            this.tabBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabBrowser.Name = "tabBrowser";
            this.tabBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.tabBrowser.Size = new System.Drawing.Size(877, 324);
            this.tabBrowser.TabIndex = 2;
            this.tabBrowser.Text = "Trophy Browser";
            this.tabBrowser.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.DefaultDirectory = "";
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(3, 3);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.NavigationAddress = "";
            this.webBrowser.NavigationMode = NTR_WebBrowser.NTR_Browser.eNavigationMode.Main;
            this.webBrowser.SelectedReportParser = null;
            this.webBrowser.ShowShortlist = true;
            this.webBrowser.ShowTransfer = true;
            this.webBrowser.Size = new System.Drawing.Size(871, 318);
            this.webBrowser.StartnavigationAddress = "";
            this.webBrowser.TabIndex = 0;
            this.webBrowser.ImportedContent += new NTR_WebBrowser.ImportedContentHandler(this.webBrowser_ImportedContent);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFile,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(122, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsbFile
            // 
            this.tsbFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromFileToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.tsbFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbFile.Image")));
            this.tsbFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFile.Name = "tsbFile";
            this.tsbFile.Size = new System.Drawing.Size(54, 22);
            this.tsbFile.Text = "File";
            // 
            // loadFromFileToolStripMenuItem
            // 
            this.loadFromFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadFromFileToolStripMenuItem.Image")));
            this.loadFromFileToolStripMenuItem.Name = "loadFromFileToolStripMenuItem";
            this.loadFromFileToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.loadFromFileToolStripMenuItem.Text = "Load From Backup Files...";
            this.loadFromFileToolStripMenuItem.Click += new System.EventHandler(this.loadFromFileToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.deleteSelectedPlayersFromVisualizationAndDatabaseToolStripMenuItem,
            this.updateOnlyListedPlayersToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(56, 22);
            this.toolStripDropDownButton1.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(363, 22);
            this.cutToolStripMenuItem.Text = "Delete Selected Players from visualization";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // deleteSelectedPlayersFromVisualizationAndDatabaseToolStripMenuItem
            // 
            this.deleteSelectedPlayersFromVisualizationAndDatabaseToolStripMenuItem.Image = global::TMRecorder.Properties.Resources.Waste;
            this.deleteSelectedPlayersFromVisualizationAndDatabaseToolStripMenuItem.Name = "deleteSelectedPlayersFromVisualizationAndDatabaseToolStripMenuItem";
            this.deleteSelectedPlayersFromVisualizationAndDatabaseToolStripMenuItem.Size = new System.Drawing.Size(363, 22);
            this.deleteSelectedPlayersFromVisualizationAndDatabaseToolStripMenuItem.Text = "Delete selected players from visualization and database";
            // 
            // updateOnlyListedPlayersToolStripMenuItem
            // 
            this.updateOnlyListedPlayersToolStripMenuItem.CheckOnClick = true;
            this.updateOnlyListedPlayersToolStripMenuItem.Name = "updateOnlyListedPlayersToolStripMenuItem";
            this.updateOnlyListedPlayersToolStripMenuItem.Size = new System.Drawing.Size(363, 22);
            this.updateOnlyListedPlayersToolStripMenuItem.Text = "Update Only listed players";
            this.updateOnlyListedPlayersToolStripMenuItem.Click += new System.EventHandler(this.updateOnlyListedPlayersToolStripMenuItem_Click);
            // 
            // ShortlistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 375);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShortlistForm";
            this.Text = "Shortlist Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShortlistForm_FormClosing);
            this.Load += new System.EventHandler(this.ShortlistForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindPL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindGK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersDS)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPlayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgGiocatori)).EndInit();
            this.tabGK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPortieri)).EndInit();
            this.tabBrowser.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPlayers;
        private AeroDataGrid dgGiocatori;
        private System.Windows.Forms.BindingSource bindPL;
        private System.Windows.Forms.TabPage tabGK;
        private AeroDataGrid dgPortieri;
        private System.Windows.Forms.BindingSource bindGK;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openPlayersPropertyPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPlayersPageInTheTrophyManagerWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsbFile;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        public NTR_Common.TeamDS teamDS;
        public NTR_Common.PlayersDS playersDS;
        private System.Windows.Forms.ToolStripMenuItem openPlayersTeamPageInTrophyBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromFileToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_AgeColumn ageDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_NationColumn nationalityDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_FpColumn fPDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn aSIDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn forDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn resDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn velDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn marPreDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn conUnoDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn worRifDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn posAerDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn pasEleDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn croComDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn tecTirDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn tesLanDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn finDataGridViewTextBoxColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn disDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn calDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rouDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTI;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec;
        private System.Windows.Forms.DataGridViewTextBoxColumn CStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dLDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dMCDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dMRDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dMLDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mCDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mRDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mLDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn oMCDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn oMRDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn oMLDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fCDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ends;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewCustomColumns.TMR_AgeColumn tmR_AgeColumn1;
        private DataGridViewCustomColumns.TMR_NationColumn tmR_NationColumn1;
        private DataGridViewCustomColumns.TMR_FpColumn tmR_FpColumn1;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn dataGridViewTextBoxColumn3;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn dataGridViewTextBoxColumn4;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn dataGridViewTextBoxColumn5;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn dataGridViewTextBoxColumn6;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn dataGridViewTextBoxColumn7;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn dataGridViewTextBoxColumn8;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn dataGridViewTextBoxColumn9;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn dataGridViewTextBoxColumn10;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn dataGridViewTextBoxColumn11;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn dataGridViewTextBoxColumn12;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn dataGridViewTextBoxColumn13;
        private DataGridViewCustomColumns.TMR_PlayerDSColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn CStrGK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportedNotes;
        private System.Windows.Forms.TabPage tabBrowser;
        private NTR_WebBrowser.NTR_Browser webBrowser;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedPlayersFromVisualizationAndDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateOnlyListedPlayersToolStripMenuItem;
    }
}