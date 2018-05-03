namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevisedBidAndAuctionTableFinal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Auctions", "Bid_Id", "dbo.Bids");
            DropIndex("dbo.Auctions", new[] { "Bid_Id" });
            AddColumn("dbo.Bids", "AuctionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bids", "AuctionId");
            AddForeignKey("dbo.Bids", "AuctionId", "dbo.Auctions", "Id", cascadeDelete: true);
            DropColumn("dbo.Auctions", "Bid_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auctions", "Bid_Id", c => c.Int());
            DropForeignKey("dbo.Bids", "AuctionId", "dbo.Auctions");
            DropIndex("dbo.Bids", new[] { "AuctionId" });
            DropColumn("dbo.Bids", "AuctionId");
            CreateIndex("dbo.Auctions", "Bid_Id");
            AddForeignKey("dbo.Auctions", "Bid_Id", "dbo.Bids", "Id");
        }
    }
}
