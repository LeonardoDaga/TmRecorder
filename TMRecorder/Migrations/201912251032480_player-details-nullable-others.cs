namespace TMRecorder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playerdetailsnullableothers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "Ada", c => c.Byte());
            AlterColumn("dbo.Players", "FirstData", c => c.DateTime());
            AlterColumn("dbo.Players", "LastData", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "LastData", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Players", "FirstData", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Players", "Ada", c => c.Byte(nullable: false));
        }
    }
}
