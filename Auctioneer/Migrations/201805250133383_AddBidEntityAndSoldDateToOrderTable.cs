namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBidEntityAndSoldDateToOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "SoldDate", c => c.DateTime());
            AddColumn("dbo.Orders", "Bid_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Bid_Id");
            AddForeignKey("dbo.Orders", "Bid_Id", "dbo.Bids", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Bid_Id", "dbo.Bids");
            DropIndex("dbo.Orders", new[] { "Bid_Id" });
            DropColumn("dbo.Orders", "Bid_Id");
            DropColumn("dbo.Orders", "SoldDate");
        }
    }
}
