using NTR_Controls;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShortlistForm));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openPlayersPropertyPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlayersPageInTheTrophyManagerWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlayersTeamPageInTrophyBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPlayers = new System.Windows.Forms.TabPage();
            this.dgPlayers = new NTR_Controls.AeroDataGrid();
            this.tabGK = new System.Windows.Forms.TabPage();
            this.dgPlayersGK = new NTR_Controls.AeroDataGrid();
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
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).BeginInit();
            this.tabGK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayersGK)).BeginInit();
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
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(875, 350);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(875, 375);
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
            this.tabControl.Size = new System.Drawing.Size(875, 350);
            this.tabControl.TabIndex = 2;
            // 
            // tabPlayers
            // 
            this.tabPlayers.Controls.Add(this.dgPlayers);
            this.tabPlayers.Location = new System.Drawing.Point(4, 22);
            this.tabPlayers.Name = "tabPlayers";
            this.tabPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlayers.Size = new System.Drawing.Size(867, 324);
            this.tabPlayers.TabIndex = 0;
            this.tabPlayers.Text = "Players";
            this.tabPlayers.UseVisualStyleBackColor = true;
            // 
            // dgPlayers
            // 
            this.dgPlayers.AllowUserToAddRows = false;
            this.dgPlayers.AllowUserToDeleteRows = false;
            this.dgPlayers.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPlayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlayers.ContextMenuStrip = this.contextMenuStrip;
            this.dgPlayers.DataCollection = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPlayers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPlayers.Location = new System.Drawing.Point(3, 3);
            this.dgPlayers.Name = "dgPlayers";
            this.dgPlayers.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPlayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgPlayers.RowHeadersWidth = 20;
            this.dgPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPlayers.Size = new System.Drawing.Size(861, 318);
            this.dgPlayers.TabIndex = 0;
            this.dgPlayers.Sorted += new System.EventHandler(this.dgGiocatori_Sorted);
            this.dgPlayers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgGiocatori_MouseDoubleClick);
            // 
            // tabGK
            // 
            this.tabGK.Controls.Add(this.dgPlayersGK);
            this.tabGK.Location = new System.Drawing.Point(4, 22);
            this.tabGK.Name = "tabGK";
            this.tabGK.Padding = new System.Windows.Forms.Padding(3);
            this.tabGK.Size = new System.Drawing.Size(867, 324);
            this.tabGK.TabIndex = 1;
            this.tabGK.Text = "GKs";
            this.tabGK.UseVisualStyleBackColor = true;
            // 
            // dgPlayersGK
            // 
            this.dgPlayersGK.AllowUserToAddRows = false;
            this.dgPlayersGK.AllowUserToDeleteRows = false;
            this.dgPlayersGK.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPlayersGK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgPlayersGK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlayersGK.DataCollection = null;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPlayersGK.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgPlayersGK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPlayersGK.Location = new System.Drawing.Point(3, 3);
            this.dgPlayersGK.Name = "dgPlayersGK";
            this.dgPlayersGK.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPlayersGK.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgPlayersGK.RowHeadersWidth = 20;
            this.dgPlayersGK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPlayersGK.Size = new System.Drawing.Size(861, 318);
            this.dgPlayersGK.TabIndex = 1;
            this.dgPlayersGK.Sorted += new System.EventHandler(this.dgPortieri_Sorted);
            this.dgPlayersGK.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgGiocatori_MouseDoubleClick);
            // 
            // tabBrowser
            // 
            this.tabBrowser.Controls.Add(this.webBrowser);
            this.tabBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabBrowser.Name = "tabBrowser";
            this.tabBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.tabBrowser.Size = new System.Drawing.Size(867, 324);
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
            this.webBrowser.ShowShortlist = false;
            this.webBrowser.ShowTransfer = false;
            this.webBrowser.Size = new System.Drawing.Size(861, 318);
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
            this.ClientSize = new System.Drawing.Size(875, 375);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShortlistForm";
            this.Text = "Shortlist Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShortlistForm_FormClosing);
            this.Load += new System.EventHandler(this.ShortlistForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPlayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).EndInit();
            this.tabGK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayersGK)).EndInit();
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
        private AeroDataGrid dgPlayers;
        private System.Windows.Forms.TabPage tabGK;
        private AeroDataGrid dgPlayersGK;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openPlayersPropertyPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPlayersPageInTheTrophyManagerWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsbFile;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPlayersTeamPageInTrophyBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromFileToolStripMenuItem;
        private System.Windows.Forms.TabPage tabBrowser;
        private NTR_WebBrowser.NTR_Browser webBrowser;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedPlayersFromVisualizationAndDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateOnlyListedPlayersToolStripMenuItem;
    }
}