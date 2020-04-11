namespace TMRecorder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playerdetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "ScoutVoto", c => c.String());
            AddColumn("dbo.Players", "ScoutGiudizio", c => c.String());
            AddColumn("dbo.Players", "FirstData", c => c.DateTime(nullable: false));
            AddColumn("dbo.Players", "LastData", c => c.DateTime(nullable: false));
            AddColumn("dbo.Players", "ScoutDate", c => c.String());
            AddColumn("dbo.Players", "ScoutName", c => c.String());
            AddColumn("dbo.Players", "Age", c => c.Byte(nullable: false));
            AddColumn("dbo.Players", "MediaVoto", c => c.Single(nullable: false));
            AddColumn("dbo.Players", "ASI", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "Team", c => c.String(maxLength: 4));
            AddColumn("dbo.Players", "TSI", c => c.String());
            AddColumn("dbo.Players", "Wage", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "AvRating", c => c.Single(nullable: false));
            AddColumn("dbo.Players", "AvTSI", c => c.Single(nullable: false));
            AddColumn("dbo.Players", "Blooming", c => c.Single(nullable: false));
            AddColumn("dbo.Players", "Professionalism", c => c.Single(nullable: false));
            AddColumn("dbo.Players", "Aggressivity", c => c.Single(nullable: false));
            AddColumn("dbo.Players", "Leadership", c => c.Single(nullable: false));
            AddColumn("dbo.Players", "Ability", c => c.Single(nullable: false));
            AddColumn("dbo.Players", "InjPron", c => c.Byte(nullable: false));
            AddColumn("dbo.Players", "wBorn", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "Routine", c => c.Single(nullable: false));
            AddColumn("dbo.Players", "wBloomData", c => c.String(maxLength: 256));
            AddColumn("dbo.Players", "isRetire", c => c.Boolean(nullable: false));
            AddColumn("dbo.Players", "isYoungTeam", c => c.Byte(nullable: false));
            AddColumn("dbo.Players", "TrainingAbilities", c => c.String());
            AddColumn("dbo.Players", "FPn", c => c.Short(nullable: false));
            AddColumn("dbo.Players", "Speciality", c => c.String(maxLength: 12));
            AddColumn("dbo.Players", "GameTable", c => c.String());
            AddColumn("dbo.Players", "Potential", c => c.Single(nullable: false));
            AddColumn("dbo.Players", "HiddenRevealed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Players", "Rec", c => c.Single(nullable: false));
            AddColumn("dbo.Players", "SPn", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "SPn");
            DropColumn("dbo.Players", "Rec");
            DropColumn("dbo.Players", "HiddenRevealed");
            DropColumn("dbo.Players", "Potential");
            DropColumn("dbo.Players", "GameTable");
            DropColumn("dbo.Players", "Speciality");
            DropColumn("dbo.Players", "FPn");
            DropColumn("dbo.Players", "TrainingAbilities");
            DropColumn("dbo.Players", "isYoungTeam");
            DropColumn("dbo.Players", "isRetire");
            DropColumn("dbo.Players", "wBloomData");
            DropColumn("dbo.Players", "Routine");
            DropColumn("dbo.Players", "wBorn");
            DropColumn("dbo.Players", "InjPron");
            DropColumn("dbo.Players", "Ability");
            DropColumn("dbo.Players", "Leadership");
            DropColumn("dbo.Players", "Aggressivity");
            DropColumn("dbo.Players", "Professionalism");
            DropColumn("dbo.Players", "Blooming");
            DropColumn("dbo.Players", "AvTSI");
            DropColumn("dbo.Players", "AvRating");
            DropColumn("dbo.Players", "Wage");
            DropColumn("dbo.Players", "TSI");
            DropColumn("dbo.Players", "Team");
            DropColumn("dbo.Players", "ASI");
            DropColumn("dbo.Players", "MediaVoto");
            DropColumn("dbo.Players", "Age");
            DropColumn("dbo.Players", "ScoutName");
            DropColumn("dbo.Players", "ScoutDate");
            DropColumn("dbo.Players", "LastData");
            DropColumn("dbo.Players", "FirstData");
            DropColumn("dbo.Players", "ScoutGiudizio");
            DropColumn("dbo.Players", "ScoutVoto");
        }
    }
}
