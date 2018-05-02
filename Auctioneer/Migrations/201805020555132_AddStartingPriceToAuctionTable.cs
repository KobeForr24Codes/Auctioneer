namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStartingPriceToAuctionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "StartingPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auctions", "StartingPrice");
        }
    }
}
