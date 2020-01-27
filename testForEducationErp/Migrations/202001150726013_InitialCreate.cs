namespace testForEducationErp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Description = c.String(nullable: false),
                        YearRelease = c.DateTime(nullable: false),
                        Producer = c.String(nullable: false, maxLength: 150),
                        Poster = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true)
                .Index(t => t.Title)
                .Index(t => t.YearRelease)
                .Index(t => t.Producer);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Films", new[] { "Producer" });
            DropIndex("dbo.Films", new[] { "YearRelease" });
            DropIndex("dbo.Films", new[] { "Title" });
            DropIndex("dbo.Films", new[] { "Id" });
            DropTable("dbo.Films");
        }
    }
}
