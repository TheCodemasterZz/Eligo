namespace Eligo.DataLayer.Tenants.EligoDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PublicoRefCities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(nullable: false, maxLength: 250),
                        RefCountryID = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UserIdCreatedBy = c.Int(nullable: false),
                        IsModified = c.Boolean(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        UserIdModifiedBy = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                        UserIdDeletedBy = c.Int(nullable: false),
                        IsMasterRecord = c.Boolean(nullable: false),
                        VersionedAt = c.DateTime(nullable: false),
                        VersionNumber = c.Int(nullable: false),
                        MasterRecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PublicoRefCountries", t => t.RefCountryID)
                .Index(t => t.RefCountryID);
            
            CreateTable(
                "dbo.PublicoRefCountries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Code = c.String(nullable: false, maxLength: 20),
                        CreatedAt = c.DateTime(nullable: false),
                        UserIdCreatedBy = c.Int(nullable: false),
                        IsModified = c.Boolean(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        UserIdModifiedBy = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                        UserIdDeletedBy = c.Int(nullable: false),
                        IsMasterRecord = c.Boolean(nullable: false),
                        VersionedAt = c.DateTime(nullable: false),
                        VersionNumber = c.Int(nullable: false),
                        MasterRecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PublicoUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        DateOfBirth = c.DateTime(),
                        RefCityIDPlaceOfBirth = c.Int(nullable: false),
                        RefCountryIDPlaceOfBirth = c.Int(nullable: false),
                        MobilePhoneNumber = c.String(maxLength: 25),
                        UserType = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UserIdCreatedBy = c.Int(nullable: false),
                        IsModified = c.Boolean(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        UserIdModifiedBy = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                        UserIdDeletedBy = c.Int(nullable: false),
                        IsMasterRecord = c.Boolean(nullable: false),
                        VersionedAt = c.DateTime(nullable: false),
                        VersionNumber = c.Int(nullable: false),
                        MasterRecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PublicoRefCities", t => t.RefCityIDPlaceOfBirth)
                .ForeignKey("dbo.PublicoRefCities", t => t.RefCountryIDPlaceOfBirth)
                .Index(t => t.RefCityIDPlaceOfBirth)
                .Index(t => t.RefCountryIDPlaceOfBirth);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublicoUsers", "RefCountryIDPlaceOfBirth", "dbo.PublicoRefCities");
            DropForeignKey("dbo.PublicoUsers", "RefCityIDPlaceOfBirth", "dbo.PublicoRefCities");
            DropForeignKey("dbo.PublicoRefCities", "RefCountryID", "dbo.PublicoRefCountries");
            DropIndex("dbo.PublicoUsers", new[] { "RefCountryIDPlaceOfBirth" });
            DropIndex("dbo.PublicoUsers", new[] { "RefCityIDPlaceOfBirth" });
            DropIndex("dbo.PublicoRefCities", new[] { "RefCountryID" });
            DropTable("dbo.PublicoUsers");
            DropTable("dbo.PublicoRefCountries");
            DropTable("dbo.PublicoRefCities");
        }
    }
}
