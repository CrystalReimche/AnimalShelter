namespace AnimalShelter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AddressOne", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressTwo", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "Zip", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Zip");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "AddressTwo");
            DropColumn("dbo.AspNetUsers", "AddressOne");
        }
    }
}
