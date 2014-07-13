using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;

namespace TMRecorder
{
    public partial class Trainers : Form
    {
        private TrainersSkills dbTrainers;
        private BindingSource trainersBindingSource;
        private IContainer components;
        private Label label2;
        private ToolStrip toolStrip1;
        private ToolStripButton tsParseTrainers;
        private Label label1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridView dgBestSkills;
        private BindingSource skillsBindingSource;
        private Label label3;
        private DataGridViewTextBoxColumn resultDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bestSkillsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn motDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fisDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn porDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn difDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tecDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn heaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn winDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn attDataGridViewTextBoxColumn;
        private LinkLabel linkLabel1;
        private Label label10;
        private DataGridView dgTrainersList;
    
        public Trainers()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trainers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgTrainersList = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fisDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.difDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tecDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbTrainers = new Common.TrainersSkills();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsParseTrainers = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBestSkills = new System.Windows.Forms.DataGridView();
            this.resultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bestSkillsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skillsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgTrainersList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTrainers)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBestSkills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTrainersList
            // 
            this.dgTrainersList.AllowUserToAddRows = false;
            this.dgTrainersList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgTrainersList.AutoGenerateColumns = false;
            this.dgTrainersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTrainersList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.motDataGridViewTextBoxColumn,
            this.fisDataGridViewTextBoxColumn,
            this.porDataGridViewTextBoxColumn,
            this.difDataGridViewTextBoxColumn,
            this.tecDataGridViewTextBoxColumn,
            this.heaDataGridViewTextBoxColumn,
            this.winDataGridViewTextBoxColumn,
            this.attDataGridViewTextBoxColumn});
            this.dgTrainersList.DataSource = this.trainersBindingSource;
            this.dgTrainersList.Location = new System.Drawing.Point(12, 43);
            this.dgTrainersList.MultiSelect = false;
            this.dgTrainersList.Name = "dgTrainersList";
            this.dgTrainersList.RowHeadersWidth = 20;
            this.dgTrainersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTrainersList.Size = new System.Drawing.Size(560, 182);
            this.dgTrainersList.TabIndex = 0;
            this.dgTrainersList.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // motDataGridViewTextBoxColumn
            // 
            this.motDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.motDataGridViewTextBoxColumn.DataPropertyName = "Mot";
            this.motDataGridViewTextBoxColumn.HeaderText = "Mot";
            this.motDataGridViewTextBoxColumn.Name = "motDataGridViewTextBoxColumn";
            this.motDataGridViewTextBoxColumn.Width = 50;
            // 
            // fisDataGridViewTextBoxColumn
            // 
            this.fisDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fisDataGridViewTextBoxColumn.DataPropertyName = "Fis";
            this.fisDataGridViewTextBoxColumn.HeaderText = "Phy";
            this.fisDataGridViewTextBoxColumn.Name = "fisDataGridViewTextBoxColumn";
            this.fisDataGridViewTextBoxColumn.Width = 50;
            // 
            // porDataGridViewTextBoxColumn
            // 
            this.porDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.porDataGridViewTextBoxColumn.DataPropertyName = "Por";
            this.porDataGridViewTextBoxColumn.HeaderText = "GK";
            this.porDataGridViewTextBoxColumn.Name = "porDataGridViewTextBoxColumn";
            this.porDataGridViewTextBoxColumn.Width = 47;
            // 
            // difDataGridViewTextBoxColumn
            // 
            this.difDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.difDataGridViewTextBoxColumn.DataPropertyName = "Dif";
            this.difDataGridViewTextBoxColumn.HeaderText = "Def";
            this.difDataGridViewTextBoxColumn.Name = "difDataGridViewTextBoxColumn";
            this.difDataGridViewTextBoxColumn.Width = 49;
            // 
            // tecDataGridViewTextBoxColumn
            // 
            this.tecDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tecDataGridViewTextBoxColumn.DataPropertyName = "Tec";
            this.tecDataGridViewTextBoxColumn.HeaderText = "Tec";
            this.tecDataGridViewTextBoxColumn.Name = "tecDataGridViewTextBoxColumn";
            this.tecDataGridViewTextBoxColumn.Width = 51;
            // 
            // heaDataGridViewTextBoxColumn
            // 
            this.heaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.heaDataGridViewTextBoxColumn.DataPropertyName = "Hea";
            this.heaDataGridViewTextBoxColumn.HeaderText = "Hea";
            this.heaDataGridViewTextBoxColumn.Name = "heaDataGridViewTextBoxColumn";
            this.heaDataGridViewTextBoxColumn.Width = 52;
            // 
            // winDataGridViewTextBoxColumn
            // 
            this.winDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.winDataGridViewTextBoxColumn.DataPropertyName = "Win";
            this.winDataGridViewTextBoxColumn.HeaderText = "Win";
            this.winDataGridViewTextBoxColumn.Name = "winDataGridViewTextBoxColumn";
            this.winDataGridViewTextBoxColumn.Width = 51;
            // 
            // attDataGridViewTextBoxColumn
            // 
            this.attDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.attDataGridViewTextBoxColumn.DataPropertyName = "Att";
            this.attDataGridViewTextBoxColumn.HeaderText = "Att";
            this.attDataGridViewTextBoxColumn.Name = "attDataGridViewTextBoxColumn";
            this.attDataGridViewTextBoxColumn.Width = 45;
            // 
            // trainersBindingSource
            // 
            this.trainersBindingSource.DataMember = "Trainers";
            this.trainersBindingSource.DataSource = this.dbTrainers;
            // 
            // dbTrainers
            // 
            this.dbTrainers.DataSetName = "TrainersSkills";
            this.dbTrainers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(538, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsParseTrainers});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(918, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsParseTrainers
            // 
            this.tsParseTrainers.Image = global::TMRecorder.Properties.Resources.Coach;
            this.tsParseTrainers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsParseTrainers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsParseTrainers.Name = "tsParseTrainers";
            this.tsParseTrainers.Size = new System.Drawing.Size(107, 22);
            this.tsParseTrainers.Text = "Parse Trainers";
            this.tsParseTrainers.Click += new System.EventHandler(this.tsParseTrainers_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Trainers List";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Mot";
            this.dataGridViewTextBoxColumn2.HeaderText = "Mot";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Fis";
            this.dataGridViewTextBoxColumn3.HeaderText = "Fis";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Por";
            this.dataGridViewTextBoxColumn4.HeaderText = "Por";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Dif";
            this.dataGridViewTextBoxColumn5.HeaderText = "Dif";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Tec";
            this.dataGridViewTextBoxColumn6.HeaderText = "Tec";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Hea";
            this.dataGridViewTextBoxColumn7.HeaderText = "Hea";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Win";
            this.dataGridViewTextBoxColumn8.HeaderText = "Win";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Att";
            this.dataGridViewTextBoxColumn9.HeaderText = "Att";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dgBestSkills
            // 
            this.dgBestSkills.AllowUserToAddRows = false;
            this.dgBestSkills.AllowUserToDeleteRows = false;
            this.dgBestSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBestSkills.AutoGenerateColumns = false;
            this.dgBestSkills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBestSkills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.resultDataGridViewTextBoxColumn,
            this.bestSkillsDataGridViewTextBoxColumn});
            this.dgBestSkills.DataSource = this.skillsBindingSource;
            this.dgBestSkills.Location = new System.Drawing.Point(596, 44);
            this.dgBestSkills.MultiSelect = false;
            this.dgBestSkills.Name = "dgBestSkills";
            this.dgBestSkills.RowHeadersWidth = 20;
            this.dgBestSkills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBestSkills.Size = new System.Drawing.Size(312, 217);
            this.dgBestSkills.TabIndex = 4;
            // 
            // resultDataGridViewTextBoxColumn
            // 
            this.resultDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.resultDataGridViewTextBoxColumn.DataPropertyName = "Result";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.resultDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.resultDataGridViewTextBoxColumn.HeaderText = "Result";
            this.resultDataGridViewTextBoxColumn.Name = "resultDataGridViewTextBoxColumn";
            this.resultDataGridViewTextBoxColumn.Width = 62;
            // 
            // bestSkillsDataGridViewTextBoxColumn
            // 
            this.bestSkillsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bestSkillsDataGridViewTextBoxColumn.DataPropertyName = "BestSkills";
            this.bestSkillsDataGridViewTextBoxColumn.HeaderText = "BestSkills";
            this.bestSkillsDataGridViewTextBoxColumn.Name = "bestSkillsDataGridViewTextBoxColumn";
            // 
            // skillsBindingSource
            // 
            this.skillsBindingSource.DataMember = "Skills";
            this.skillsBindingSource.DataSource = this.dbTrainers;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(593, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Best Skills";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(54, 258);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(39, 12);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Palmyra";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "Thanks to Palmyra for his idea";
            // 
            // Trainers
            // 
            this.ClientSize = new System.Drawing.Size(918, 273);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgBestSkills);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgTrainersList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Trainers";
            this.Text = "Trainers Evaluation Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgTrainersList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTrainers)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBestSkills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void tsParseTrainers_Click(object sender, EventArgs e)
        {
            dbTrainers.LoadPasteTrainers();

            dbTrainers.ComputeBestCombination();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgTrainersList.SelectedRows.Count == 0) return;

            System.Data.DataRowView selTrainer = (System.Data.DataRowView)dgTrainersList.SelectedRows[0].DataBoundItem;
            TrainersSkills.TrainersRow rowTrainer = (TrainersSkills.TrainersRow)selTrainer.Row;
            rowTrainer.ComputeBestSkills();

            dgBestSkills.DataSource = rowTrainer.sdt;
            //dgBestSkills.DataMember = rowTrainer.sdt;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://trophymanager.com/klubhus.php?showclub=218974");
        }
    }
}