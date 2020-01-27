namespace testForEducationErp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserInFilm : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Films", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Films", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Films", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Films", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
