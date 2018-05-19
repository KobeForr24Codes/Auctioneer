namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeliveredDateandIsDelieveredToOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DeliveredDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "IsDelivered", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsDelivered");
            DropColumn("dbo.Orders", "DeliveredDate");
        }
    }
}
