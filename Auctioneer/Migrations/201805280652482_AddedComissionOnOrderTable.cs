namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedComissionOnOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Comission", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Comission");
        }
    }
}
