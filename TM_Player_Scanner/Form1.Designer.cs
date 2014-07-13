namespace TM_Player_Scanner
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.matchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoTrophyManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadTableMatchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMatchListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skipPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.playerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giocatoriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playerScanInfo = new TM_Player_Scanner.PlayerScanInfo();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giocatoriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerScanInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matchesToolStripMenuItem,
            this.skipPlayerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(680, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // matchesToolStripMenuItem
            // 
            this.matchesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoTrophyManagerToolStripMenuItem,
            this.fillToolStripMenuItem,
            this.downloadTableMatchesToolStripMenuItem,
            this.saveMatchListToolStripMenuItem});
            this.matchesToolStripMenuItem.Name = "matchesToolStripMenuItem";
            this.matchesToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.matchesToolStripMenuItem.Text = "Players";
            // 
            // gotoTrophyManagerToolStripMenuItem
            // 
            this.gotoTrophyManagerToolStripMenuItem.Name = "gotoTrophyManagerToolStripMenuItem";
            this.gotoTrophyManagerToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.gotoTrophyManagerToolStripMenuItem.Text = "Goto TrophyManager Squad Page";
            this.gotoTrophyManagerToolStripMenuItem.Click += new System.EventHandler(this.gotoTrophyManagerToolStripMenuItem_Click);
            // 
            // fillToolStripMenuItem
            // 
            this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            this.fillToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.fillToolStripMenuItem.Text = "Parse Squad page";
            this.fillToolStripMenuItem.Click += new System.EventHandler(this.fillToolStripMenuItem_Click);
            // 
            // downloadTableMatchesToolStripMenuItem
            // 
            this.downloadTableMatchesToolStripMenuItem.Name = "downloadTableMatchesToolStripMenuItem";
            this.downloadTableMatchesToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.downloadTableMatchesToolStripMenuItem.Text = "Download Table Players";
            this.downloadTableMatchesToolStripMenuItem.Click += new System.EventHandler(this.downloadTableMatchesToolStripMenuItem_Click);
            // 
            // saveMatchListToolStripMenuItem
            // 
            this.saveMatchListToolStripMenuItem.Name = "saveMatchListToolStripMenuItem";
            this.saveMatchListToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.saveMatchListToolStripMenuItem.Text = "Save Players List";
            // 
            // skipPlayerToolStripMenuItem
            // 
            this.skipPlayerToolStripMenuItem.Name = "skipPlayerToolStripMenuItem";
            this.skipPlayerToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.skipPlayerToolStripMenuItem.Text = ">> Skip Player >>";
            this.skipPlayerToolStripMenuItem.Click += new System.EventHandler(this.skipPlayerToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(680, 332);
            this.splitContainer1.SplitterDistance = 130;
            this.splitContainer1.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playerIDDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.giocatoriBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(680, 130);
            this.dataGridView1.TabIndex = 0;
            // 
            // playerIDDataGridViewTextBoxColumn
            // 
            this.playerIDDataGridViewTextBoxColumn.DataPropertyName = "PlayerID";
            this.playerIDDataGridViewTextBoxColumn.HeaderText = "PlayerID";
            this.playerIDDataGridViewTextBoxColumn.Name = "playerIDDataGridViewTextBoxColumn";
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // giocatoriBindingSource
            // 
            this.giocatoriBindingSource.DataMember = "Giocatori";
            this.giocatoriBindingSource.DataSource = this.playerScanInfo;
            // 
            // playerScanInfo
            // 
            this.playerScanInfo.DataSetName = "PlayerScanInfo";
            this.playerScanInfo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.webBrowser);
            this.panel1.Controls.Add(this.txtUrl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 198);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "URL";
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(6, 36);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(671, 159);
            this.webBrowser.TabIndex = 6;
            this.webBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(38, 10);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(630, 20);
            this.txtUrl.TabIndex = 7;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 356);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "TM Players Scanner";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giocatoriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerScanInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem matchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadTableMatchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMatchListToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource giocatoriBindingSource;
        private PlayerScanInfo playerScanInfo;
        private System.Windows.Forms.ToolStripMenuItem gotoTrophyManagerToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem fillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skipPlayerToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Timer timer;
    }
}

