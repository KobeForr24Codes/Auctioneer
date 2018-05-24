namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSellerIdToOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "SellerId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "SellerId");
        }
    }
}
