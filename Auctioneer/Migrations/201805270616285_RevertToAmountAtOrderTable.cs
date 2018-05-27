namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertToAmountAtOrderTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Bid_Id", "dbo.Bids");
            DropIndex("dbo.Orders", new[] { "Bid_Id" });
            AddColumn("dbo.Orders", "Amount", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Bid_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Bid_Id", c => c.Int());
            DropColumn("dbo.Orders", "Amount");
            CreateIndex("dbo.Orders", "Bid_Id");
            AddForeignKey("dbo.Orders", "Bid_Id", "dbo.Bids", "Id");
        }
    }
}
