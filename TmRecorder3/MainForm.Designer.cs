namespace TmRecorder3
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.varDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nTR_SquadDb = new NTR_Db.NTR_SquadDb();
            this.DB = new NTR_Db.Data(this.components);
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTR_SquadDb)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeDataGridViewTextBoxColumn,
            this.weekDataGridViewTextBoxColumn,
            this.aSIDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.varDataBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(951, 482);
            this.dataGridView1.TabIndex = 0;
            // 
            // varDataBindingSource
            // 
            this.varDataBindingSource.DataSource = typeof(NTR_Db.PlayerData);
            // 
            // nTR_SquadDb
            // 
            this.nTR_SquadDb.DataSetName = "NTR_SquadDb";
            this.nTR_SquadDb.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // weekDataGridViewTextBoxColumn
            // 
            this.weekDataGridViewTextBoxColumn.DataPropertyName = "Week";
            this.weekDataGridViewTextBoxColumn.HeaderText = "Week";
            this.weekDataGridViewTextBoxColumn.Name = "weekDataGridViewTextBoxColumn";
            // 
            // aSIDataGridViewTextBoxColumn
            // 
            this.aSIDataGridViewTextBoxColumn.DataPropertyName = "ASI";
            this.aSIDataGridViewTextBoxColumn.HeaderText = "ASI";
            this.aSIDataGridViewTextBoxColumn.Name = "aSIDataGridViewTextBoxColumn";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 482);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTR_SquadDb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NTR_Db.NTR_SquadDb nTR_SquadDb;
        private System.Windows.Forms.BindingSource varDataBindingSource;
        private NTR_Db.Data DB;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSIDataGridViewTextBoxColumn;
    }
}

