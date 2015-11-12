namespace NTR_Controls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NTR_Browser));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbPrev = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel11 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.loginTrophyManagercomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbGotoMainTrophyPage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbGotoAdobePage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSendThisPageForDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel12 = new System.Windows.Forms.ToolStripLabel();
            this.tsbProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsbProgressText = new System.Windows.Forms.ToolStripLabel();
            this.tbTxtAddress = new System.Windows.Forms.ToolStripTextBox();
            this.webBrowser = new Gecko.GeckoWebBrowser();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsbPrev,
            this.tsbNext,
            this.tsbUpdate,
            this.tsbImport,
            this.toolStripSeparator1,
            this.toolStripLabel11,
            this.toolStripDropDownButton1,
            this.toolStripSeparator2,
            this.toolStripLabel12,
            this.tsbProgressBar,
            this.tsbProgressText,
            this.tbTxtAddress});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(698, 38);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(67, 35);
            this.toolStripLabel1.Text = "Navigation";
            // 
            // tsbPrev
            // 
            this.tsbPrev.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrev.Image")));
            this.tsbPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrev.Name = "tsbPrev";
            this.tsbPrev.Size = new System.Drawing.Size(34, 35);
            this.tsbPrev.Text = "Prev";
            this.tsbPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrev.Click += new System.EventHandler(this.tsbPrev_Click);
            // 
            // tsbNext
            // 
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(35, 35);
            this.tsbNext.Text = "Next";
            this.tsbNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.Image = global::NTR_Controls.Properties.Resources.Update;
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(49, 35);
            this.tsbUpdate.Text = "Update";
            this.tsbUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
            // 
            // tsbImport
            // 
            this.tsbImport.Image = global::NTR_Controls.Properties.Resources.ImportIcon;
            this.tsbImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Size = new System.Drawing.Size(47, 35);
            this.tsbImport.Text = "Import";
            this.tsbImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbImport.Click += new System.EventHandler(this.tsbImport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripLabel11
            // 
            this.toolStripLabel11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolStripLabel11.Name = "toolStripLabel11";
            this.toolStripLabel11.Size = new System.Drawing.Size(24, 35);
            this.toolStripLabel11.Text = "TM";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginTrophyManagercomToolStripMenuItem,
            this.tsbGotoMainTrophyPage,
            this.tsbGotoAdobePage,
            this.toolStripSeparator17,
            this.tsbSendThisPageForDebug});
            this.toolStripDropDownButton1.Image = global::NTR_Controls.Properties.Resources.Folder;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 35);
            this.toolStripDropDownButton1.Text = "File";
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // loginTrophyManagercomToolStripMenuItem
            // 
            this.loginTrophyManagercomToolStripMenuItem.Name = "loginTrophyManagercomToolStripMenuItem";
            this.loginTrophyManagercomToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.loginTrophyManagercomToolStripMenuItem.Text = "Login TrophyManager.com";
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripLabel12
            // 
            this.toolStripLabel12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel12.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolStripLabel12.Name = "toolStripLabel12";
            this.toolStripLabel12.Size = new System.Drawing.Size(87, 35);
            this.toolStripLabel12.Text = "Load progress";
            // 
            // tsbProgressBar
            // 
            this.tsbProgressBar.AutoSize = false;
            this.tsbProgressBar.Name = "tsbProgressBar";
            this.tsbProgressBar.Size = new System.Drawing.Size(70, 20);
            this.tsbProgressBar.Step = 5;
            // 
            // tsbProgressText
            // 
            this.tsbProgressText.Name = "tsbProgressText";
            this.tsbProgressText.Size = new System.Drawing.Size(17, 35);
            this.tsbProgressText.Text = "%";
            // 
            // tbTxtAddress
            // 
            this.tbTxtAddress.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbTxtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTxtAddress.Name = "tbTxtAddress";
            this.tbTxtAddress.ReadOnly = true;
            this.tbTxtAddress.Size = new System.Drawing.Size(350, 16);
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(3, 41);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(692, 362);
            this.webBrowser.TabIndex = 4;
            this.webBrowser.UseHttpActivityObserver = false;
            this.webBrowser.DocumentCompleted += new System.EventHandler<Gecko.Events.GeckoDocumentCompletedEventArgs>(this.webBrowser_DocumentCompleted);
            this.webBrowser.ProgressChanged += new System.EventHandler<Gecko.GeckoProgressEventArgs>(this.webBrowser_ProgressChanged);
            // 
            // NTR_Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.toolStrip1);
            this.Name = "NTR_Browser";
            this.Size = new System.Drawing.Size(698, 406);
            this.Load += new System.EventHandler(this.NTR_Browser_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbPrev;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel12;
        private System.Windows.Forms.ToolStripProgressBar tsbProgressBar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tsbGotoMainTrophyPage;
        private System.Windows.Forms.ToolStripMenuItem tsbGotoAdobePage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem tsbSendThisPageForDebug;
        private System.Windows.Forms.ToolStripLabel tsbProgressText;
        private System.Windows.Forms.ToolStripButton tsbImport;
        private System.Windows.Forms.ToolStripButton tsbUpdate;
        private System.Windows.Forms.ToolStripMenuItem loginTrophyManagercomToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tbTxtAddress;
        private Gecko.GeckoWebBrowser webBrowser;
    }
}
