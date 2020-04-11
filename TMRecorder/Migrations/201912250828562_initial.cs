namespace TMRecorder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Numero = c.Byte(nullable: false),
                        Nationality = c.String(maxLength: 2),
                        Name = c.String(maxLength: 255),
                        FP = c.String(maxLength: 8),
                        Ada = c.Byte(nullable: false),
                        Note = c.String(maxLength: 512),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Players");
        }
    }
}
