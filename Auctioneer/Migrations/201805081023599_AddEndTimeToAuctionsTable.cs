namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEndTimeToAuctionsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auctions", "EndTime");
        }
    }
}
