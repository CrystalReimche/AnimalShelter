namespace AnimalShelter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdoptedPets",
                c => new
                    {
                        Adopted_Pet_ID = c.Int(nullable: false, identity: true),
                        Date_Adopted = c.DateTime(nullable: false),
                        Notes = c.String(),
                        Thank_You_Letter_Sent = c.Boolean(nullable: false),
                        Adopter_Adopter_ID = c.Int(),
                        Adopter_Adopter_ID1 = c.Int(),
                        Adopter_ID_Adopter_ID = c.Int(),
                        Pet_ID_Pet_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Adopted_Pet_ID)
                .ForeignKey("dbo.Adopters", t => t.Adopter_Adopter_ID)
                .ForeignKey("dbo.Adopters", t => t.Adopter_Adopter_ID1)
                .ForeignKey("dbo.Adopters", t => t.Adopter_ID_Adopter_ID)
                .ForeignKey("dbo.Pets", t => t.Pet_ID_Pet_ID)
                .Index(t => t.Adopter_Adopter_ID)
                .Index(t => t.Adopter_Adopter_ID1)
                .Index(t => t.Adopter_ID_Adopter_ID)
                .Index(t => t.Pet_ID_Pet_ID);
            
            CreateTable(
                "dbo.Adopters",
                c => new
                    {
                        Adopter_ID = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Adopter_ID);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Pet_ID = c.Int(nullable: false, identity: true),
                        Breed = c.String(),
                        Species_Type = c.Int(nullable: false),
                        Name = c.String(),
                        Age = c.String(),
                        Gender = c.Int(nullable: false),
                        Coat_Color = c.String(),
                        Date_Arrived_In_Shelter = c.DateTime(nullable: false),
                        Spayed = c.Boolean(nullable: false),
                        Neutered = c.Boolean(nullable: false),
                        Notes = c.String(),
                        PetID = c.Int(nullable: false),
                        Adopted_Pets_Adopted_Pet_ID = c.Int(),
                        Date_Adopted_Adopted_Pet_ID = c.Int(),
                        AdoptedPet_Adopted_Pet_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Pet_ID)
                .ForeignKey("dbo.AdoptedPets", t => t.Adopted_Pets_Adopted_Pet_ID)
                .ForeignKey("dbo.AdoptedPets", t => t.Date_Adopted_Adopted_Pet_ID)
                .ForeignKey("dbo.AdoptedPets", t => t.AdoptedPet_Adopted_Pet_ID)
                .Index(t => t.Adopted_Pets_Adopted_Pet_ID)
                .Index(t => t.Date_Adopted_Adopted_Pet_ID)
                .Index(t => t.AdoptedPet_Adopted_Pet_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Pets", "AdoptedPet_Adopted_Pet_ID", "dbo.AdoptedPets");
            DropForeignKey("dbo.AdoptedPets", "Pet_ID_Pet_ID", "dbo.Pets");
            DropForeignKey("dbo.Pets", "Date_Adopted_Adopted_Pet_ID", "dbo.AdoptedPets");
            DropForeignKey("dbo.Pets", "Adopted_Pets_Adopted_Pet_ID", "dbo.AdoptedPets");
            DropForeignKey("dbo.AdoptedPets", "Adopter_ID_Adopter_ID", "dbo.Adopters");
            DropForeignKey("dbo.AdoptedPets", "Adopter_Adopter_ID1", "dbo.Adopters");
            DropForeignKey("dbo.AdoptedPets", "Adopter_Adopter_ID", "dbo.Adopters");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Pets", new[] { "AdoptedPet_Adopted_Pet_ID" });
            DropIndex("dbo.Pets", new[] { "Date_Adopted_Adopted_Pet_ID" });
            DropIndex("dbo.Pets", new[] { "Adopted_Pets_Adopted_Pet_ID" });
            DropIndex("dbo.AdoptedPets", new[] { "Pet_ID_Pet_ID" });
            DropIndex("dbo.AdoptedPets", new[] { "Adopter_ID_Adopter_ID" });
            DropIndex("dbo.AdoptedPets", new[] { "Adopter_Adopter_ID1" });
            DropIndex("dbo.AdoptedPets", new[] { "Adopter_Adopter_ID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Pets");
            DropTable("dbo.Adopters");
            DropTable("dbo.AdoptedPets");
        }
    }
}
