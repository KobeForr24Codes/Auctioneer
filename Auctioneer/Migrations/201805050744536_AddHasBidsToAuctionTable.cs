namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHasBidsToAuctionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "HasBids", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auctions", "HasBids");
        }
    }
}
