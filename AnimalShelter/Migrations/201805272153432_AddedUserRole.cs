namespace AnimalShelter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Role_ID = c.Int(nullable: false, identity: true),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.User_Role_ID);
            
            AddColumn("dbo.AspNetUsers", "UserRole_User_Role_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "UserRole_User_Role_ID");
            AddForeignKey("dbo.AspNetUsers", "UserRole_User_Role_ID", "dbo.UserRoles", "User_Role_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserRole_User_Role_ID", "dbo.UserRoles");
            DropIndex("dbo.AspNetUsers", new[] { "UserRole_User_Role_ID" });
            DropColumn("dbo.AspNetUsers", "UserRole_User_Role_ID");
            DropTable("dbo.UserRoles");
        }
    }
}
