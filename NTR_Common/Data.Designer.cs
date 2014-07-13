namespace NTR_Common
{
    partial class Data
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
            this.teamDS = new NTR_Common.TeamDS();
            this.gainDS = new NTR_Common.GainDS();
            this.trainersSkillsDS = new Common.TrainersSkills();
            this.nationsDS = new Common.NationsDS();
            this.scoutSkillsDS = new Common.ScoutsNReviews();
            ((System.ComponentModel.ISupportInitialize)(this.teamDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gainDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainersSkillsDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nationsDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoutSkillsDS)).BeginInit();
            // 
            // teamDS
            // 
            this.teamDS.DataSetName = "TeamDS";
            this.teamDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gainDS
            // 
            this.gainDS.DataSetName = "GainDS";
            this.gainDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // trainersSkillsDS
            // 
            this.trainersSkillsDS.DataSetName = "TrainersSkills";
            this.trainersSkillsDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nationsDS
            // 
            this.nationsDS.DataSetName = "NationsDS";
            this.nationsDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // scoutSkillsDS
            // 
            this.scoutSkillsDS.DataSetName = "ScoutNReviews";
            this.scoutSkillsDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.teamDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gainDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainersSkillsDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nationsDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoutSkillsDS)).EndInit();

        }

        #endregion

        public Common.TrainersSkills trainersSkillsDS;
        public Common.NationsDS nationsDS;
        public TeamDS teamDS;
        private GainDS gainDS;
        private Common.ScoutsNReviews scoutSkillsDS;

    }
}
