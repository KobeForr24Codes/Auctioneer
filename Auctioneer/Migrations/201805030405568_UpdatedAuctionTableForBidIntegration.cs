namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAuctionTableForBidIntegration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bids", "AuctionId", "dbo.Auctions");
            DropIndex("dbo.Bids", new[] { "AuctionId" });
            AddColumn("dbo.Auctions", "BidId", c => c.Int(nullable: false));
            AddColumn("dbo.Auctions", "IsAwarded", c => c.Boolean(nullable: false));
            AddColumn("dbo.Auctions", "AwardedId", c => c.String());
            CreateIndex("dbo.Auctions", "BidId");
            AddForeignKey("dbo.Auctions", "BidId", "dbo.Bids", "Id", cascadeDelete: true);
            DropColumn("dbo.Bids", "AuctionId");
            DropColumn("dbo.Bids", "IsAwarded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bids", "IsAwarded", c => c.Boolean(nullable: false));
            AddColumn("dbo.Bids", "AuctionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Auctions", "BidId", "dbo.Bids");
            DropIndex("dbo.Auctions", new[] { "BidId" });
            DropColumn("dbo.Auctions", "AwardedId");
            DropColumn("dbo.Auctions", "IsAwarded");
            DropColumn("dbo.Auctions", "BidId");
            CreateIndex("dbo.Bids", "AuctionId");
            AddForeignKey("dbo.Bids", "AuctionId", "dbo.Auctions", "Id", cascadeDelete: true);
        }
    }
}
