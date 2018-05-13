namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToAuctionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auctions", "Image");
        }
    }
}
