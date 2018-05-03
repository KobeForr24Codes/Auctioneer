namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBidTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        AuctionId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        IsAwarded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.AuctionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AuctionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bids", "AuctionId", "dbo.Auctions");
            DropIndex("dbo.Bids", new[] { "AuctionId" });
            DropIndex("dbo.Bids", new[] { "UserId" });
            DropTable("dbo.Bids");
        }
    }
}
