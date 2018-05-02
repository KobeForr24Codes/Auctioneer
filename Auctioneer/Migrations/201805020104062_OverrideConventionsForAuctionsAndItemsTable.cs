namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForAuctionsAndItemsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "ItemName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Items", "Details", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Details", c => c.String());
            AlterColumn("dbo.Items", "ItemName", c => c.String());
        }
    }
}
