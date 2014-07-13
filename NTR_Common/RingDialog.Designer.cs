namespace NTR_Common
{
    partial class RingDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RingDialog));
            this.btnStop = new System.Windows.Forms.Button();
            this.Message = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStop.Location = new System.Drawing.Point(124, 58);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(113, 24);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "Stop Dialog";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(3, 1);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(356, 49);
            this.Message.TabIndex = 1;
            this.Message.Text = "label1";
            this.Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 4000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RingDialog
            // 
            this.AcceptButton = this.btnStop;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 88);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.btnStop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RingDialog";
            this.Text = "RingDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        public System.Windows.Forms.Label Message;
        private System.Windows.Forms.Timer timer1;
    }
}