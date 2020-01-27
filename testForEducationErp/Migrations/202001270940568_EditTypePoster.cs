namespace testForEducationErp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTypePoster : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Poster", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Films", "Poster", c => c.Binary());
        }
    }
}
