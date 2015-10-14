namespace TMRecorder
{
    partial class MatchStats
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
            Common.Formation formation3 = new Common.Formation();
            Common.Formation formation4 = new Common.Formation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchStats));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtLineUp1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLineUp2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPossession1 = new System.Windows.Forms.Label();
            this.txtPossession2 = new System.Windows.Forms.Label();
            this.txtShots1 = new System.Windows.Forms.Label();
            this.txtOnTarget1 = new System.Windows.Forms.Label();
            this.txtShots2 = new System.Windows.Forms.Label();
            this.txtOnTarget2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.oppsTeamLineup = new FieldFormationControl.LineupListItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.yourTeamLineup = new FieldFormationControl.LineupListItem();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSprinklers = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblDraining = new System.Windows.Forms.Label();
            this.lblHeating = new System.Windows.Forms.Label();
            this.lblPitchCondition = new System.Windows.Forms.Label();
            this.lblPitchCover = new System.Windows.Forms.Label();
            this.weatherImgList = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictWeather = new System.Windows.Forms.PictureBox();
            this.lblWeather = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictWeather)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtLineUp1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLineUp2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPossession1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPossession2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtShots1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtOnTarget1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtShots2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtOnTarget2, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(87, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(214, 277);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtLineUp1
            // 
            this.txtLineUp1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLineUp1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLineUp1.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtLineUp1.Location = new System.Drawing.Point(3, 20);
            this.txtLineUp1.Name = "txtLineUp1";
            this.txtLineUp1.Size = new System.Drawing.Size(43, 20);
            this.txtLineUp1.TabIndex = 3;
            this.txtLineUp1.Text = "0-0-0";
            this.txtLineUp1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(52, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Match Stats";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label5.Location = new System.Drawing.Point(52, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Line Up";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLineUp2
            // 
            this.txtLineUp2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLineUp2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLineUp2.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtLineUp2.Location = new System.Drawing.Point(167, 20);
            this.txtLineUp2.Name = "txtLineUp2";
            this.txtLineUp2.Size = new System.Drawing.Size(44, 20);
            this.txtLineUp2.TabIndex = 3;
            this.txtLineUp2.Text = "0-0-0";
            this.txtLineUp2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label6.Location = new System.Drawing.Point(52, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Possession";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label8.Location = new System.Drawing.Point(52, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Shots";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label11.Location = new System.Drawing.Point(52, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "On Target";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPossession1
            // 
            this.txtPossession1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPossession1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPossession1.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtPossession1.Location = new System.Drawing.Point(3, 40);
            this.txtPossession1.Name = "txtPossession1";
            this.txtPossession1.Size = new System.Drawing.Size(43, 20);
            this.txtPossession1.TabIndex = 3;
            this.txtPossession1.Text = "0%";
            this.txtPossession1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPossession2
            // 
            this.txtPossession2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPossession2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPossession2.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtPossession2.Location = new System.Drawing.Point(167, 40);
            this.txtPossession2.Name = "txtPossession2";
            this.txtPossession2.Size = new System.Drawing.Size(44, 20);
            this.txtPossession2.TabIndex = 3;
            this.txtPossession2.Text = "0%";
            this.txtPossession2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtShots1
            // 
            this.txtShots1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShots1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtShots1.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtShots1.Location = new System.Drawing.Point(3, 60);
            this.txtShots1.Name = "txtShots1";
            this.txtShots1.Size = new System.Drawing.Size(43, 20);
            this.txtShots1.TabIndex = 3;
            this.txtShots1.Text = "0";
            this.txtShots1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOnTarget1
            // 
            this.txtOnTarget1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOnTarget1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOnTarget1.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtOnTarget1.Location = new System.Drawing.Point(3, 80);
            this.txtOnTarget1.Name = "txtOnTarget1";
            this.txtOnTarget1.Size = new System.Drawing.Size(43, 20);
            this.txtOnTarget1.TabIndex = 3;
            this.txtOnTarget1.Text = "0";
            this.txtOnTarget1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShots2
            // 
            this.txtShots2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShots2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtShots2.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtShots2.Location = new System.Drawing.Point(167, 60);
            this.txtShots2.Name = "txtShots2";
            this.txtShots2.Size = new System.Drawing.Size(44, 20);
            this.txtShots2.TabIndex = 3;
            this.txtShots2.Text = "0";
            this.txtShots2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOnTarget2
            // 
            this.txtOnTarget2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOnTarget2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOnTarget2.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtOnTarget2.Location = new System.Drawing.Point(167, 80);
            this.txtOnTarget2.Name = "txtOnTarget2";
            this.txtOnTarget2.Size = new System.Drawing.Size(44, 20);
            this.txtOnTarget2.TabIndex = 3;
            this.txtOnTarget2.Text = "0";
            this.txtOnTarget2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(604, 283);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.oppsTeamLineup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(307, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 277);
            this.panel1.TabIndex = 2;
            // 
            // oppsTeamLineup
            // 
            this.oppsTeamLineup.BackColor = System.Drawing.Color.DarkGreen;
            this.oppsTeamLineup.DrawMode = FieldFormationControl.LineupListItem.eDrawMode.ColorByPosition;
            formation3.ShowValue = false;
            formation3.TeamColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            formation3.Type = Common.eFormationTypes.Type_4_4_2;
            this.oppsTeamLineup.formation = formation3;
            this.oppsTeamLineup.IsSelected = false;
            this.oppsTeamLineup.Location = new System.Drawing.Point(2, 24);
            this.oppsTeamLineup.Name = "oppsTeamLineup";
            this.oppsTeamLineup.SelectedColor = System.Drawing.Color.DarkOliveGreen;
            this.oppsTeamLineup.Size = new System.Drawing.Size(61, 74);
            this.oppsTeamLineup.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.yourTeamLineup);
            this.panel2.Location = new System.Drawing.Point(17, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(64, 277);
            this.panel2.TabIndex = 3;
            // 
            // yourTeamLineup
            // 
            this.yourTeamLineup.BackColor = System.Drawing.Color.DarkGreen;
            this.yourTeamLineup.DrawMode = FieldFormationControl.LineupListItem.eDrawMode.ColorByPosition;
            formation4.ShowValue = false;
            formation4.TeamColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            formation4.Type = Common.eFormationTypes.Type_4_4_2;
            this.yourTeamLineup.formation = formation4;
            this.yourTeamLineup.IsSelected = false;
            this.yourTeamLineup.Location = new System.Drawing.Point(2, 24);
            this.yourTeamLineup.Name = "yourTeamLineup";
            this.yourTeamLineup.SelectedColor = System.Drawing.Color.DarkOliveGreen;
            this.yourTeamLineup.Size = new System.Drawing.Size(61, 74);
            this.yourTeamLineup.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblSprinklers, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label12, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label13, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.lblDraining, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblHeating, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblPitchCondition, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.lblPitchCover, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 1, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(391, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(194, 277);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.OliveDrab;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pitch";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sprinklers";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSprinklers
            // 
            this.lblSprinklers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSprinklers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSprinklers.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblSprinklers.Location = new System.Drawing.Point(83, 20);
            this.lblSprinklers.Name = "lblSprinklers";
            this.lblSprinklers.Size = new System.Drawing.Size(108, 20);
            this.lblSprinklers.TabIndex = 3;
            this.lblSprinklers.Text = "No";
            this.lblSprinklers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label7.Location = new System.Drawing.Point(3, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Draining";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label9.Location = new System.Drawing.Point(3, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Heating";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label10.Location = new System.Drawing.Point(3, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Pitch Condition";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label12.Location = new System.Drawing.Point(3, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 20);
            this.label12.TabIndex = 2;
            this.label12.Text = "Pitch Cover";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label13.Location = new System.Drawing.Point(3, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "Weather";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDraining
            // 
            this.lblDraining.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDraining.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDraining.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblDraining.Location = new System.Drawing.Point(83, 40);
            this.lblDraining.Name = "lblDraining";
            this.lblDraining.Size = new System.Drawing.Size(108, 20);
            this.lblDraining.TabIndex = 3;
            this.lblDraining.Text = "No";
            this.lblDraining.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHeating
            // 
            this.lblHeating.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeating.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeating.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblHeating.Location = new System.Drawing.Point(83, 60);
            this.lblHeating.Name = "lblHeating";
            this.lblHeating.Size = new System.Drawing.Size(108, 20);
            this.lblHeating.TabIndex = 3;
            this.lblHeating.Text = "No";
            this.lblHeating.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPitchCondition
            // 
            this.lblPitchCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPitchCondition.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPitchCondition.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblPitchCondition.Location = new System.Drawing.Point(83, 80);
            this.lblPitchCondition.Name = "lblPitchCondition";
            this.lblPitchCondition.Size = new System.Drawing.Size(108, 20);
            this.lblPitchCondition.TabIndex = 3;
            this.lblPitchCondition.Text = "82%";
            this.lblPitchCondition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPitchCover
            // 
            this.lblPitchCover.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPitchCover.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPitchCover.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblPitchCover.Location = new System.Drawing.Point(83, 100);
            this.lblPitchCover.Name = "lblPitchCover";
            this.lblPitchCover.Size = new System.Drawing.Size(108, 20);
            this.lblPitchCover.TabIndex = 3;
            this.lblPitchCover.Text = "Yes";
            this.lblPitchCover.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // weatherImgList
            // 
            this.weatherImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("weatherImgList.ImageStream")));
            this.weatherImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.weatherImgList.Images.SetKeyName(0, "cloudy1.png");
            this.weatherImgList.Images.SetKeyName(1, "cloudy2.png");
            this.weatherImgList.Images.SetKeyName(2, "cloudy3.png");
            this.weatherImgList.Images.SetKeyName(3, "cloudy4.png");
            this.weatherImgList.Images.SetKeyName(4, "cloudy5.png");
            this.weatherImgList.Images.SetKeyName(5, "rainy1.png");
            this.weatherImgList.Images.SetKeyName(6, "rainy2.png");
            this.weatherImgList.Images.SetKeyName(7, "rainy3.png");
            this.weatherImgList.Images.SetKeyName(8, "rainy4.png");
            this.weatherImgList.Images.SetKeyName(9, "rainy5.png");
            this.weatherImgList.Images.SetKeyName(10, "sunny1.png");
            this.weatherImgList.Images.SetKeyName(11, "sunny2.png");
            this.weatherImgList.Images.SetKeyName(12, "sunny3.png");
            this.weatherImgList.Images.SetKeyName(13, "sunny4.png");
            this.weatherImgList.Images.SetKeyName(14, "sunny5.png");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictWeather);
            this.panel3.Controls.Add(this.lblWeather);
            this.panel3.Location = new System.Drawing.Point(83, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(108, 41);
            this.panel3.TabIndex = 4;
            // 
            // pictWeather
            // 
            this.pictWeather.Location = new System.Drawing.Point(0, 3);
            this.pictWeather.Name = "pictWeather";
            this.pictWeather.Size = new System.Drawing.Size(39, 35);
            this.pictWeather.TabIndex = 0;
            this.pictWeather.TabStop = false;
            // 
            // lblWeather
            // 
            this.lblWeather.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWeather.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWeather.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblWeather.Location = new System.Drawing.Point(42, 3);
            this.lblWeather.Margin = new System.Windows.Forms.Padding(0);
            this.lblWeather.Name = "lblWeather";
            this.lblWeather.Size = new System.Drawing.Size(62, 35);
            this.lblWeather.TabIndex = 3;
            this.lblWeather.Text = "Yes";
            this.lblWeather.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MatchStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "MatchStats";
            this.Size = new System.Drawing.Size(604, 283);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictWeather)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label txtLineUp1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtLineUp2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtPossession1;
        private System.Windows.Forms.Label txtPossession2;
        private System.Windows.Forms.Label txtShots1;
        private System.Windows.Forms.Label txtOnTarget1;
        private System.Windows.Forms.Label txtShots2;
        private System.Windows.Forms.Label txtOnTarget2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public FieldFormationControl.LineupListItem oppsTeamLineup;
        public FieldFormationControl.LineupListItem yourTeamLineup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSprinklers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblDraining;
        private System.Windows.Forms.Label lblHeating;
        private System.Windows.Forms.Label lblPitchCondition;
        private System.Windows.Forms.Label lblPitchCover;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictWeather;
        private System.Windows.Forms.Label lblWeather;
        private System.Windows.Forms.ImageList weatherImgList;
    }
}
