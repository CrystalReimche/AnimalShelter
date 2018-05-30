namespace AnimalShelter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedcrap : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pets", "PetID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "PetID", c => c.Int(nullable: false));
        }
    }
}
