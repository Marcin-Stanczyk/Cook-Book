namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3c57ea59-9322-45fd-a14d-070ecfde491a', N'guest@cookbook.com', 0, N'AHeDF3cVyi7hHfGUg5faTytMOYdcCzriVztCObPZQu166ItCkAEugZi9C0jA+MUVgA==', N'01435780-0bff-4a5d-a19d-d14edc023918', NULL, 0, 0, NULL, 1, 0, N'guest@cookbook.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cc52d67c-dc88-4a04-8012-f700fbfe0054', N'admin@cookbook.com', 0, N'ANT2nawnmAFmYIlpAys9i6iZSahdKdSLSbwp7RYYD18oLeGlzWakzYI0ALvT743s9w==', N'3eaa71a4-161a-42b5-b203-605d70af0b93', NULL, 0, 0, NULL, 1, 0, N'admin@cookbook.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'592ef441-0710-445d-bdb3-93767537b704', N'CanManageProducts')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cc52d67c-dc88-4a04-8012-f700fbfe0054', N'592ef441-0710-445d-bdb3-93767537b704')

");
        }
        
        public override void Down()
        {
        }
    }
}
