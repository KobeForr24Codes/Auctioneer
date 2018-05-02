namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToAuction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Auctions", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Auctions", new[] { "User_Id" });
            RenameColumn(table: "dbo.Auctions", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Auctions", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Auctions", "UserId");
            AddForeignKey("dbo.Auctions", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auctions", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Auctions", new[] { "UserId" });
            AlterColumn("dbo.Auctions", "UserId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Auctions", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Auctions", "User_Id");
            AddForeignKey("dbo.Auctions", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
