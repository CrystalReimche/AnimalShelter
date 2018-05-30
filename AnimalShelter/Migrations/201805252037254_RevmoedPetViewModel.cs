namespace AnimalShelter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevmoedPetViewModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pets", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pets", "Photo", c => c.Binary());
        }
    }
}
