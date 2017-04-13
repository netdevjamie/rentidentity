namespace RentIdentity.Data.Migrations.RentIdentityDB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserType = c.String(),
                        PersonId = c.Int(nullable: false),
                        AspNetUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.AspNetUserId);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        EmailAddress = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 15),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetNumber = c.String(),
                        Street = c.String(),
                        AptNumber = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId, name: "IX_Person_Id");
            
            CreateTable(
                "dbo.Broker",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsLandlord = c.Boolean(nullable: false),
                        BrokerLicenseId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        LandlordId = c.Int(nullable: false),
                        PersonId = c.Int(),
                        FavoritesId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BrokerLicense", t => t.BrokerLicenseId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .ForeignKey("dbo.Favorites", t => t.FavoritesId)
                .Index(t => t.BrokerLicenseId)
                .Index(t => t.PersonId, name: "IX_Person_Id")
                .Index(t => t.FavoritesId, name: "IX_Favorites_Id");
            
            CreateTable(
                "dbo.BrokerLicense",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicenseNumber = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Landlord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HasBroker = c.Boolean(nullable: false),
                        BrokerId = c.Int(nullable: false),
                        PropertyId = c.Int(),
                        RentalUnitId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Property", t => t.PropertyId)
                .ForeignKey("dbo.RentalUnit", t => t.RentalUnitId)
                .Index(t => t.PropertyId, name: "IX_Property_Id")
                .Index(t => t.RentalUnitId, name: "IX_RentalUnit_Id");
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        BrokerId = c.Int(nullable: false),
                        LandlordId = c.Int(nullable: false),
                        RentalUnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .ForeignKey("dbo.Broker", t => t.BrokerId)
                .Index(t => t.AddressId)
                .Index(t => t.BrokerId);
            
            CreateTable(
                "dbo.RentalUnit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentalUnitBrokerId = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsAvailable = c.Boolean(nullable: false),
                        DateAvailable = c.DateTimeOffset(nullable: false, precision: 7),
                        RentalUnitAddress = c.String(),
                        SquareFeet = c.Int(nullable: false),
                        NumStories = c.Int(nullable: false),
                        NumRooms = c.Int(nullable: false),
                        NumBath = c.Int(nullable: false),
                        IsPetFriendly = c.Boolean(nullable: false),
                        TenantId = c.Int(nullable: false),
                        LandlordId = c.Int(nullable: false),
                        FavoritesId = c.Int(),
                        PropertyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Favorites", t => t.FavoritesId)
                .ForeignKey("dbo.Property", t => t.PropertyId)
                .Index(t => t.FavoritesId, name: "IX_Favorites_Id")
                .Index(t => t.PropertyId, name: "IX_Property_Id");
            
            CreateTable(
                "dbo.Tenant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FavoritesId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        RentalUnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Favorites", t => t.FavoritesId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .ForeignKey("dbo.RentalUnit", t => t.RentalUnitId)
                .Index(t => t.FavoritesId)
                .Index(t => t.PersonId)
                .Index(t => t.RentalUnitId);
            
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        RentalUnitId = c.Int(nullable: false),
                        BrokerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                        UserRating = c.String(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BrokerLandlords",
                c => new
                    {
                        BrokerId = c.Int(nullable: false),
                        LandlordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BrokerId, t.LandlordId })
                .ForeignKey("dbo.Broker", t => t.BrokerId, cascadeDelete: true)
                .ForeignKey("dbo.Landlord", t => t.LandlordId, cascadeDelete: true)
                .Index(t => t.BrokerId, name: "IX_Broker_Id")
                .Index(t => t.LandlordId, name: "IX_Landlord_Id");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rating", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Property", "BrokerId", "dbo.Broker");
            DropForeignKey("dbo.RentalUnit", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.Tenant", "RentalUnitId", "dbo.RentalUnit");
            DropForeignKey("dbo.Tenant", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Tenant", "FavoritesId", "dbo.Favorites");
            DropForeignKey("dbo.RentalUnit", "FavoritesId", "dbo.Favorites");
            DropForeignKey("dbo.Broker", "FavoritesId", "dbo.Favorites");
            DropForeignKey("dbo.Landlord", "RentalUnitId", "dbo.RentalUnit");
            DropForeignKey("dbo.Landlord", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.Property", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Broker", "PersonId", "dbo.Person");
            DropForeignKey("dbo.BrokerLandlords", "LandlordId", "dbo.Landlord");
            DropForeignKey("dbo.BrokerLandlords", "BrokerId", "dbo.Broker");
            DropForeignKey("dbo.Broker", "BrokerLicenseId", "dbo.BrokerLicense");
            DropForeignKey("dbo.AppUser", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Address", "PersonId", "dbo.Person");
            DropForeignKey("dbo.AppUser", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.BrokerLandlords", "IX_Landlord_Id");
            DropIndex("dbo.BrokerLandlords", "IX_Broker_Id");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.Rating", new[] { "PersonId" });
            DropIndex("dbo.Tenant", new[] { "RentalUnitId" });
            DropIndex("dbo.Tenant", new[] { "PersonId" });
            DropIndex("dbo.Tenant", new[] { "FavoritesId" });
            DropIndex("dbo.RentalUnit", "IX_Property_Id");
            DropIndex("dbo.RentalUnit", "IX_Favorites_Id");
            DropIndex("dbo.Property", new[] { "BrokerId" });
            DropIndex("dbo.Property", new[] { "AddressId" });
            DropIndex("dbo.Landlord", "IX_RentalUnit_Id");
            DropIndex("dbo.Landlord", "IX_Property_Id");
            DropIndex("dbo.Broker", "IX_Favorites_Id");
            DropIndex("dbo.Broker", "IX_Person_Id");
            DropIndex("dbo.Broker", new[] { "BrokerLicenseId" });
            DropIndex("dbo.Address", "IX_Person_Id");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AppUser", new[] { "AspNetUserId" });
            DropIndex("dbo.AppUser", new[] { "PersonId" });
            DropTable("dbo.BrokerLandlords");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Rating");
            DropTable("dbo.Favorites");
            DropTable("dbo.Tenant");
            DropTable("dbo.RentalUnit");
            DropTable("dbo.Property");
            DropTable("dbo.Landlord");
            DropTable("dbo.BrokerLicense");
            DropTable("dbo.Broker");
            DropTable("dbo.Address");
            DropTable("dbo.Person");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AppUser");
        }
    }
}
