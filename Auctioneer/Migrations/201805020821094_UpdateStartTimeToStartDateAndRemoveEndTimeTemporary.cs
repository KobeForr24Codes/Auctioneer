namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStartTimeToStartDateAndRemoveEndTimeTemporary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Auctions", "StartTime");
            DropColumn("dbo.Auctions", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auctions", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auctions", "StartTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Auctions", "StartDate");
        }
    }
}
