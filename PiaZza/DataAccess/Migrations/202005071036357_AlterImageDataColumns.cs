namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterImageDataColumns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccountImages", "ImageData", c => c.String());
            AlterColumn("dbo.OfferImages", "ImageData", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OfferImages", "ImageData", c => c.Binary());
            AlterColumn("dbo.AccountImages", "ImageData", c => c.Binary());
        }
    }
}
