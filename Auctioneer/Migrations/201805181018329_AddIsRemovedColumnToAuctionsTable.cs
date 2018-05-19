namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsRemovedColumnToAuctionsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "IsRemoved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auctions", "IsRemoved");
        }
    }
}
