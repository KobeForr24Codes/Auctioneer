namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevisedBidAndAuctionTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Auctions", "BidId", "dbo.Bids");
            DropIndex("dbo.Auctions", new[] { "BidId" });
            RenameColumn(table: "dbo.Auctions", name: "BidId", newName: "Bid_Id");
            AlterColumn("dbo.Auctions", "Bid_Id", c => c.Int());
            CreateIndex("dbo.Auctions", "Bid_Id");
            AddForeignKey("dbo.Auctions", "Bid_Id", "dbo.Bids", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auctions", "Bid_Id", "dbo.Bids");
            DropIndex("dbo.Auctions", new[] { "Bid_Id" });
            AlterColumn("dbo.Auctions", "Bid_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Auctions", name: "Bid_Id", newName: "BidId");
            CreateIndex("dbo.Auctions", "BidId");
            AddForeignKey("dbo.Auctions", "BidId", "dbo.Bids", "Id", cascadeDelete: true);
        }
    }
}
