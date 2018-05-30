namespace AnimalShelter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAroundUserRole : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "UserRole_User_Role_ID", "dbo.UserRoles");
            DropIndex("dbo.AspNetUsers", new[] { "UserRole_User_Role_ID" });
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "UserRole_User_Role_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserRole_User_Role_ID", c => c.Int());
            DropColumn("dbo.AspNetUsers", "LastName");
            CreateIndex("dbo.AspNetUsers", "UserRole_User_Role_ID");
            AddForeignKey("dbo.AspNetUsers", "UserRole_User_Role_ID", "dbo.UserRoles", "User_Role_ID");
        }
    }
}
