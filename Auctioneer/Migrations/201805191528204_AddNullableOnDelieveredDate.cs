namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableOnDelieveredDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "DeliveredDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "DeliveredDate", c => c.DateTime(nullable: false));
        }
    }
}
