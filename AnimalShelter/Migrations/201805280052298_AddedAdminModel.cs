namespace AnimalShelter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAdminModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Discriminator");
        }
    }
}
