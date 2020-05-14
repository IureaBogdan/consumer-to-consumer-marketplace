namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatingtablesforonlinestorage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AccountImages", "AccountImageId", "dbo.Accounts");
            DropIndex("dbo.AccountImages", new[] { "AccountImageId" });
            AddColumn("dbo.Accounts", "ImageLink", c => c.String());
            AddColumn("dbo.OfferImages", "ImageLink", c => c.String());
            DropColumn("dbo.OfferImages", "ImageData");
            DropTable("dbo.AccountImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AccountImages",
                c => new
                    {
                        AccountImageId = c.Guid(nullable: false),
                        ImageData = c.String(),
                    })
                .PrimaryKey(t => t.AccountImageId);
            
            AddColumn("dbo.OfferImages", "ImageData", c => c.String());
            DropColumn("dbo.OfferImages", "ImageLink");
            DropColumn("dbo.Accounts", "ImageLink");
            CreateIndex("dbo.AccountImages", "AccountImageId");
            AddForeignKey("dbo.AccountImages", "AccountImageId", "dbo.Accounts", "AccountId");
        }
    }
}
