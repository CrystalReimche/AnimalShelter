namespace AnimalShelter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAdminModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Admins", new[] { "User_Id" });
            DropTable("dbo.Admins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Guid_ID = c.Guid(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Guid_ID);
            
            CreateIndex("dbo.Admins", "User_Id");
            AddForeignKey("dbo.Admins", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
