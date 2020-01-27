namespace testForEducationErp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTypeYearRelease : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Films", new[] { "YearRelease" });
            AlterColumn("dbo.Films", "YearRelease", c => c.Int(nullable: false));
            CreateIndex("dbo.Films", "YearRelease");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Films", new[] { "YearRelease" });
            AlterColumn("dbo.Films", "YearRelease", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Films", "YearRelease");
        }
    }
}
