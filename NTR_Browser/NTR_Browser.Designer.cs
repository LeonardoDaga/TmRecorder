namespace NTR_Browser
{
    partial class NTR_Browser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NTR_Browser));
            this.tsToolBar = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbPrev = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLabelAddedMenu = new System.Windows.Forms.ToolStripLabel();
            this.tsmFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.loginTrophyManagercomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbGotoMainTrophyPage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbGotoAdobePage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSendThisPageForDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbPlayersNavigationType = new System.Windows.Forms.ToolStripDropDownButton();
            this.navigateProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigateReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbShortList = new System.Windows.Forms.ToolStripButton();
            this.tsbTransferPage = new System.Windows.Forms.ToolStripButton();
            this.tsAddressBar = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tbTxtAddress = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tsbProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.timerProgress = new System.Windows.Forms.Timer(this.components);
            this.tsToolBar.SuspendLayout();
            this.tsAddressBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsToolBar
            // 
            this.tsToolBar.AutoSize = false;
            this.tsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsbPrev,
            this.tsbNext,
            this.tsbUpdate,
            this.tsbImport,
            this.toolStripSeparator1,
            this.tsLabelAddedMenu,
            this.tsmFile,
            this.tsbPlayersNavigationType,
            this.tsbShortList,
            this.tsbTransferPage});
            this.tsToolBar.Location = new System.Drawing.Point(0, 0);
            this.tsToolBar.Name = "tsToolBar";
            this.tsToolBar.Size = new System.Drawing.Size(874, 36);
            this.tsToolBar.TabIndex = 3;
            this.tsToolBar.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(67, 33);
            this.toolStripLabel1.Text = "Navigation";
            // 
            // tsbPrev
            // 
            this.tsbPrev.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrev.Image")));
            this.tsbPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrev.Name = "tsbPrev";
            this.tsbPrev.Size = new System.Drawing.Size(34, 33);
            this.tsbPrev.Text = "Prev";
            this.tsbPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrev.Click += new System.EventHandler(this.tsbPrev_Click);
            // 
            // tsbNext
            // 
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(36, 33);
            this.tsbNext.Text = "Next";
            this.tsbNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.Image = global::NTR_Browser.Properties.Resources.Update;
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(49, 33);
            this.tsbUpdate.Text = "Update";
            this.tsbUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
            // 
            // tsbImport
            // 
            this.tsbImport.Image = global::NTR_Browser.Properties.Resources.ImportIcon;
            this.tsbImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Size = new System.Drawing.Size(47, 33);
            this.tsbImport.Text = "Import";
            this.tsbImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbImport.Click += new System.EventHandler(this.tsbImport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // tsLabelAddedMenu
            // 
            this.tsLabelAddedMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsLabelAddedMenu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tsLabelAddedMenu.Name = "tsLabelAddedMenu";
            this.tsLabelAddedMenu.Size = new System.Drawing.Size(24, 33);
            this.tsLabelAddedMenu.Text = "TM";
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginTrophyManagercomToolStripMenuItem,
            this.tsbGotoMainTrophyPage,
            this.tsbGotoAdobePage,
            this.toolStripSeparator17,
            this.tsbSendThisPageForDebug});
            this.tsmFile.Image = global::NTR_Browser.Properties.Resources.Folder;
            this.tsmFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.Size = new System.Drawing.Size(38, 33);
            this.tsmFile.Text = "File";
            this.tsmFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // loginTrophyManagercomToolStripMenuItem
            // 
            this.loginTrophyManagercomToolStripMenuItem.Name = "loginTrophyManagercomToolStripMenuItem";
            this.loginTrophyManagercomToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.loginTrophyManagercomToolStripMenuItem.Text = "Login TrophyManager.com";
            this.loginTrophyManagercomToolStripMenuItem.Click += new System.EventHandler(this.loginTrophyManagercomToolStripMenuItem_Click);
            // 
            // tsbGotoMainTrophyPage
            // 
            this.tsbGotoMainTrophyPage.Name = "tsbGotoMainTrophyPage";
            this.tsbGotoMainTrophyPage.Size = new System.Drawing.Size(283, 22);
            this.tsbGotoMainTrophyPage.Text = "Goto Main TrophyManager page";
            this.tsbGotoMainTrophyPage.Click += new System.EventHandler(this.gotoTmHome_Click);
            // 
            // tsbGotoAdobePage
            // 
            this.tsbGotoAdobePage.Name = "tsbGotoAdobePage";
            this.tsbGotoAdobePage.Size = new System.Drawing.Size(283, 22);
            this.tsbGotoAdobePage.Text = "Goto Adobe Flashplayer page";
            this.tsbGotoAdobePage.Click += new System.EventHandler(this.gotoAdobeFlashplayerPageToolStripMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(280, 6);
            // 
            // tsbSendThisPageForDebug
            // 
            this.tsbSendThisPageForDebug.Name = "tsbSendThisPageForDebug";
            this.tsbSendThisPageForDebug.Size = new System.Drawing.Size(283, 22);
            this.tsbSendThisPageForDebug.Text = "Send this page to LedLennon for Debug";
            // 
            // tsbPlayersNavigationType
            // 
            this.tsbPlayersNavigationType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigateProfilesToolStripMenuItem,
            this.navigateReportsToolStripMenuItem});
            this.tsbPlayersNavigationType.Image = ((System.Drawing.Image)(resources.GetObject("tsbPlayersNavigationType.Image")));
            this.tsbPlayersNavigationType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPlayersNavigationType.Name = "tsbPlayersNavigationType";
            this.tsbPlayersNavigationType.Size = new System.Drawing.Size(59, 33);
            this.tsbPlayersNavigationType.Text = "Profiles";
            this.tsbPlayersNavigationType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPlayersNavigationType.Visible = false;
            // 
            // navigateProfilesToolStripMenuItem
            // 
            this.navigateProfilesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("navigateProfilesToolStripMenuItem.Image")));
            this.navigateProfilesToolStripMenuItem.Name = "navigateProfilesToolStripMenuItem";
            this.navigateProfilesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.navigateProfilesToolStripMenuItem.Text = "Navigate Profiles";
            this.navigateProfilesToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.navigateProfilesToolStripMenuItem.Click += new System.EventHandler(this.navigateProfilesToolStripMenuItem_Click);
            // 
            // navigateReportsToolStripMenuItem
            // 
            this.navigateReportsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("navigateReportsToolStripMenuItem.Image")));
            this.navigateReportsToolStripMenuItem.Name = "navigateReportsToolStripMenuItem";
            this.navigateReportsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.navigateReportsToolStripMenuItem.Text = "Navigate Reports";
            this.navigateReportsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.navigateReportsToolStripMenuItem.Click += new System.EventHandler(this.navigateReportsToolStripMenuItem_Click);
            // 
            // tsbShortList
            // 
            this.tsbShortList.Image = global::NTR_Browser.Properties.Resources.Lens2;
            this.tsbShortList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShortList.Name = "tsbShortList";
            this.tsbShortList.Size = new System.Drawing.Size(57, 33);
            this.tsbShortList.Text = "ShortList";
            this.tsbShortList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbShortList.ToolTipText = "Shortlist";
            this.tsbShortList.Click += new System.EventHandler(this.tsbShortList_Click);
            // 
            // tsbTransferPage
            // 
            this.tsbTransferPage.Image = global::NTR_Browser.Properties.Resources.TwoArrows;
            this.tsbTransferPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTransferPage.Name = "tsbTransferPage";
            this.tsbTransferPage.Size = new System.Drawing.Size(81, 33);
            this.tsbTransferPage.Text = "Transfer Page";
            this.tsbTransferPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbTransferPage.Click += new System.EventHandler(this.tsbTransferPage_Click);
            // 
            // tsAddressBar
            // 
            this.tsAddressBar.AutoSize = false;
            this.tsAddressBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.tbTxtAddress,
            this.toolStripLabel3,
            this.tsbProgressBar});
            this.tsAddressBar.Location = new System.Drawing.Point(0, 36);
            this.tsAddressBar.Name = "tsAddressBar";
            this.tsAddressBar.Size = new System.Drawing.Size(874, 18);
            this.tsAddressBar.TabIndex = 4;
            this.tsAddressBar.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(51, 15);
            this.toolStripLabel2.Text = "Address";
            // 
            // tbTxtAddress
            // 
            this.tbTxtAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbTxtAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.tbTxtAddress.AutoSize = false;
            this.tbTxtAddress.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbTxtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTxtAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbTxtAddress.Name = "tbTxtAddress";
            this.tbTxtAddress.Size = new System.Drawing.Size(350, 18);
            this.tbTxtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTxtAddress_KeyDown);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(51, 15);
            this.toolStripLabel3.Text = "Loading";
            // 
            // tsbProgressBar
            // 
            this.tsbProgressBar.AutoSize = false;
            this.tsbProgressBar.ForeColor = System.Drawing.Color.LimeGreen;
            this.tsbProgressBar.Name = "tsbProgressBar";
            this.tsbProgressBar.Size = new System.Drawing.Size(70, 20);
            this.tsbProgressBar.Step = 5;
            this.tsbProgressBar.Value = 20;
            // 
            // timerProgress
            // 
            this.timerProgress.Interval = 200;
            this.timerProgress.Tick += new System.EventHandler(this.timerProgress_Tick);
            // 
            // NTR_Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tsAddressBar);
            this.Controls.Add(this.tsToolBar);
            this.Name = "NTR_Browser";
            this.Size = new System.Drawing.Size(874, 406);
            this.Load += new System.EventHandler(this.NTR_Browser_Load);
            this.Resize += new System.EventHandler(this.NTR_Browser_Resize);
            this.tsToolBar.ResumeLayout(false);
            this.tsToolBar.PerformLayout();
            this.tsAddressBar.ResumeLayout(false);
            this.tsAddressBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip tsToolBar;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbPrev;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel tsLabelAddedMenu;
        private System.Windows.Forms.ToolStripDropDownButton tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsbGotoMainTrophyPage;
        private System.Windows.Forms.ToolStripMenuItem tsbGotoAdobePage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem tsbSendThisPageForDebug;
        private System.Windows.Forms.ToolStripButton tsbImport;
        private System.Windows.Forms.ToolStripButton tsbUpdate;
        private System.Windows.Forms.ToolStripMenuItem loginTrophyManagercomToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsbPlayersNavigationType;
        private System.Windows.Forms.ToolStripMenuItem navigateProfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navigateReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tsAddressBar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tbTxtAddress;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripProgressBar tsbProgressBar;
        private System.Windows.Forms.ToolStripButton tsbShortList;
        private System.Windows.Forms.ToolStripButton tsbTransferPage;
        private System.Windows.Forms.Timer timerProgress;
    }
}
