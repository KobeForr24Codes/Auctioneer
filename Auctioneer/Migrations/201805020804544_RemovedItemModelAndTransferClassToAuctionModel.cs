namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedItemModelAndTransferClassToAuctionModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Auctions", "Item_ID", "dbo.Items");
            DropIndex("dbo.Auctions", new[] { "Item_ID" });
            AddColumn("dbo.Auctions", "ItemName", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Auctions", "Details", c => c.String(nullable: false));
            DropColumn("dbo.Auctions", "Item_ID");
            DropTable("dbo.Items");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false, maxLength: 200),
                        Details = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Auctions", "Item_ID", c => c.Int());
            DropColumn("dbo.Auctions", "Details");
            DropColumn("dbo.Auctions", "ItemName");
            CreateIndex("dbo.Auctions", "Item_ID");
            AddForeignKey("dbo.Auctions", "Item_ID", "dbo.Items", "ID");
        }
    }
}
