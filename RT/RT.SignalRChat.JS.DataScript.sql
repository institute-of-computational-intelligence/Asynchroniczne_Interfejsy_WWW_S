delete from [dbo].[ChatGroupToUsers];
delete from [dbo].[AspNetUsers];
delete from [dbo].[ChatGroups];

SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 
GO
--passwords for users: User1234
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (1, 0, N'668c4e1c-e58d-4fa1-9f31-50d8aa1f7c21', N's1@op.pl', 0, 1, NULL, N'S1@OP.PL', N'S1@OP.PL', N'AQAAAAEAACcQAAAAEL5luXXr+auYHroKazQLIljJqou2ERCuex8Hwco9xkjwBuE3y7IkN0IMf2XX5YGylg==', NULL, 0, N'08c20bd5-da34-4f56-8107-c463837818ad', 0, N's1@op.pl')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (2, 0, N'668c4e1c-e58d-4fa1-9f31-50d8aa1f7c21', N's2@op.pl', 0, 1, NULL, N'S2@OP.PL', N'S2@OP.PL', N'AQAAAAEAACcQAAAAEL5luXXr+auYHroKazQLIljJqou2ERCuex8Hwco9xkjwBuE3y7IkN0IMf2XX5YGylg==', NULL, 0, N'08c20bd5-da34-4f56-8107-c463837818ad', 0, N's2@op.pl')
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO

SET IDENTITY_INSERT [dbo].[ChatGroups] ON 
INSERT [dbo].[ChatGroups] ([Id], [Name]) VALUES (1, N'Cyberbezpieczenstwo')
INSERT [dbo].[ChatGroups] ([Id], [Name]) VALUES (2, N'ABIBD')
INSERT [dbo].[ChatGroups] ([Id], [Name]) VALUES (3, N'ZSZIAD')
SET IDENTITY_INSERT [dbo].[ChatGroups] OFF


INSERT [dbo].[ChatGroupToUsers] ([ChatGroupId], [UserId]) VALUES (1, 1)
INSERT [dbo].[ChatGroupToUsers] ([ChatGroupId], [UserId]) VALUES (2, 1)

INSERT [dbo].[ChatGroupToUsers] ([ChatGroupId], [UserId]) VALUES (2, 2)
INSERT [dbo].[ChatGroupToUsers] ([ChatGroupId], [UserId]) VALUES (3, 2)




