namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'04069d24-278a-4dc8-ba33-1c49a4dae10a', N'victor@enclave.vn', 0, N'AN4ImaK9/38WdvPhNJsT2x51bym6ALyCc71w+oKKfnogC/9lfLzfsQ4F/7J8cdWHsw==', N'6b41388d-79a5-437e-b57a-d73e536ac3ac', NULL, 0, 0, NULL, 1, 0, N'victor@enclave.vn')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ce608f18-98b5-4392-b3fc-ab383084f532', N'admin@enclave.vn', 0, N'ALtwYxH7VLYL0b9bcO+zb8MBx4iUP4oed9KoBg00P+phxJSDI7GlYmsNU7ZhBWMf2g==', N'd4a3aa07-1ba6-4e11-b60b-d19b7a7933c9', NULL, 0, 0, NULL, 1, 0, N'admin@enclave.vn')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9583656d-0c01-4dab-b82c-74660576d0d6', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ce608f18-98b5-4392-b3fc-ab383084f532', N'9583656d-0c01-4dab-b82c-74660576d0d6')

");
        }

        public override void Down()
        {
        }
    }
}
