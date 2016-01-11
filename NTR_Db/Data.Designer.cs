using NTR_Common;
namespace NTR_Db
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
            this.gainDS = new Common.NTR_Gains();
            this.trainersSkillsDS = new Common.TrainersSkills();
            this.nationsDS = new Common.NationsDS();
            this.scoutSkillsDS = new Common.ScoutsNReviews();
            this.squadDB = new Common.NTR_SquadDb();
            ((System.ComponentModel.ISupportInitialize)(this.gainDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainersSkillsDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nationsDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoutSkillsDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.squadDB)).BeginInit();
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
            // 
            // squadDB
            // 
            this.squadDB.DataSetName = "NTR_SquadDb";
            this.squadDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.gainDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainersSkillsDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nationsDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoutSkillsDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.squadDB)).EndInit();

        }

        #endregion

        public Common.TrainersSkills trainersSkillsDS;
        public Common.NationsDS nationsDS;
        private Common.NTR_Gains gainDS;
        private Common.ScoutsNReviews scoutSkillsDS;
        public Common.NTR_SquadDb squadDB;

    }
}
