namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNullableInSoldDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "SoldDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "SoldDate", c => c.DateTime());
        }
    }
}
