namespace TMRecorder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playerdetailsnullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "Numero", c => c.Byte());
            AlterColumn("dbo.Players", "Age", c => c.Byte());
            AlterColumn("dbo.Players", "MediaVoto", c => c.Single());
            AlterColumn("dbo.Players", "ASI", c => c.Int());
            AlterColumn("dbo.Players", "Wage", c => c.Int());
            AlterColumn("dbo.Players", "AvRating", c => c.Single());
            AlterColumn("dbo.Players", "AvTSI", c => c.Single());
            AlterColumn("dbo.Players", "Blooming", c => c.Single());
            AlterColumn("dbo.Players", "Professionalism", c => c.Single());
            AlterColumn("dbo.Players", "Aggressivity", c => c.Single());
            AlterColumn("dbo.Players", "Leadership", c => c.Single());
            AlterColumn("dbo.Players", "Ability", c => c.Single());
            AlterColumn("dbo.Players", "InjPron", c => c.Byte());
            AlterColumn("dbo.Players", "wBorn", c => c.Int());
            AlterColumn("dbo.Players", "Routine", c => c.Single());
            AlterColumn("dbo.Players", "isRetire", c => c.Boolean());
            AlterColumn("dbo.Players", "isYoungTeam", c => c.Byte());
            AlterColumn("dbo.Players", "FPn", c => c.Short());
            AlterColumn("dbo.Players", "Potential", c => c.Single());
            AlterColumn("dbo.Players", "HiddenRevealed", c => c.Boolean());
            AlterColumn("dbo.Players", "Rec", c => c.Single());
            AlterColumn("dbo.Players", "SPn", c => c.Short());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "SPn", c => c.Short(nullable: false));
            AlterColumn("dbo.Players", "Rec", c => c.Single(nullable: false));
            AlterColumn("dbo.Players", "HiddenRevealed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Players", "Potential", c => c.Single(nullable: false));
            AlterColumn("dbo.Players", "FPn", c => c.Short(nullable: false));
            AlterColumn("dbo.Players", "isYoungTeam", c => c.Byte(nullable: false));
            AlterColumn("dbo.Players", "isRetire", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Players", "Routine", c => c.Single(nullable: false));
            AlterColumn("dbo.Players", "wBorn", c => c.Int(nullable: false));
            AlterColumn("dbo.Players", "InjPron", c => c.Byte(nullable: false));
            AlterColumn("dbo.Players", "Ability", c => c.Single(nullable: false));
            AlterColumn("dbo.Players", "Leadership", c => c.Single(nullable: false));
            AlterColumn("dbo.Players", "Aggressivity", c => c.Single(nullable: false));
            AlterColumn("dbo.Players", "Professionalism", c => c.Single(nullable: false));
            AlterColumn("dbo.Players", "Blooming", c => c.Single(nullable: false));
            AlterColumn("dbo.Players", "AvTSI", c => c.Single(nullable: false));
            AlterColumn("dbo.Players", "AvRating", c => c.Single(nullable: false));
            AlterColumn("dbo.Players", "Wage", c => c.Int(nullable: false));
            AlterColumn("dbo.Players", "ASI", c => c.Int(nullable: false));
            AlterColumn("dbo.Players", "MediaVoto", c => c.Single(nullable: false));
            AlterColumn("dbo.Players", "Age", c => c.Byte(nullable: false));
            AlterColumn("dbo.Players", "Numero", c => c.Byte(nullable: false));
        }
    }
}
