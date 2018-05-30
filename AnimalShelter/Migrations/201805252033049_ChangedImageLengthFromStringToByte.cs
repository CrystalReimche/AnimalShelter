namespace AnimalShelter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedImageLengthFromStringToByte : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "Photo", c => c.Binary());
            DropColumn("dbo.Pets", "Length");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "Length", c => c.String());
            DropColumn("dbo.Pets", "Photo");
        }
    }
}
