using A_TestForm.Properties;

namespace A_TestForm
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.tagsBar1 = new Common.TagsBar();
            this.SuspendLayout();
            // 
            // tagsBar1
            // 
            this.tagsBar1.BorderColor = System.Drawing.Color.Gray;
            this.tagsBar1.FillerColor = System.Drawing.Color.Aqua;
            this.tagsBar1.Location = new System.Drawing.Point(294, 108);
            this.tagsBar1.Max = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tagsBar1.Min = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tagsBar1.Name = "tagsBar1";
            this.tagsBar1.Size = new System.Drawing.Size(78, 147);
            this.tagsBar1.TabIndex = 0;
            this.tagsBar1.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("tagsBar1.Tags")));
            this.tagsBar1.TextColor = System.Drawing.Color.DarkBlue;
            this.tagsBar1.Title = "Title";
            this.tagsBar1.TitleColor = System.Drawing.Color.DarkMagenta;
            this.tagsBar1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 359);
            this.Controls.Add(this.tagsBar1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Common.TagsBar tagsBar1;
    }
}