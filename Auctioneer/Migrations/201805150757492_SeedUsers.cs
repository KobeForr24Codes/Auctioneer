namespace Auctioneer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FullName]) VALUES (N'33f96ac2-b72a-44df-897c-1a777bac5ccc', N'admin@admin.com', 0, N'ABaAGZjK/xxrADJ1CWDKnA3TRPUyZKtVeYPc7T9FzgF9wbLcZHMpojYWS+IB93K8Ow==', N'7d68a4ef-277f-4384-8224-a76c6426f400', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com', N'Kobe Admin')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b7832943-1c35-4cfa-8d47-d763302c95ec', N'CanManage')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'33f96ac2-b72a-44df-897c-1a777bac5ccc', N'b7832943-1c35-4cfa-8d47-d763302c95ec')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
