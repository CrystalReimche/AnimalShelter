namespace AnimalShelter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkedUploadToPet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "Length", c => c.String());
            DropTable("dbo.FileUploads");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FileUploads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Length = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Pets", "Length");
        }
    }
}
