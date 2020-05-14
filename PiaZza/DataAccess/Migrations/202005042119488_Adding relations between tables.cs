namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingrelationsbetweentables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Adress = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.AccountImages",
                c => new
                    {
                        AccountImageId = c.Guid(nullable: false),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.AccountImageId)
                .ForeignKey("dbo.Accounts", t => t.AccountImageId)
                .Index(t => t.AccountImageId);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Location = c.String(),
                        Price = c.Single(),
                        Date = c.DateTime(nullable: false),
                        Category = c.String(),
                        Subcategory = c.String(),
                        AccountId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.OfferImages",
                c => new
                    {
                        OfferImageId = c.Guid(nullable: false),
                        ImageData = c.Binary(),
                        OfferId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OfferImageId)
                .ForeignKey("dbo.Offers", t => t.OfferId, cascadeDelete: true)
                .Index(t => t.OfferId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfferImages", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.Offers", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.AccountImages", "AccountImageId", "dbo.Accounts");
            DropIndex("dbo.OfferImages", new[] { "OfferId" });
            DropIndex("dbo.Offers", new[] { "AccountId" });
            DropIndex("dbo.AccountImages", new[] { "AccountImageId" });
            DropTable("dbo.OfferImages");
            DropTable("dbo.Offers");
            DropTable("dbo.AccountImages");
            DropTable("dbo.Accounts");
        }
    }
}
