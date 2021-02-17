USE [Alpaca]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 2021/2/17 21:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET IDENTITY_INSERT [dbo].[Permission] ON 
GO
INSERT [dbo].[Permission] ([ID], [Name], [Code], [IsDeleted], [CreateUserID], [CreateTime], [UpdateUserID], [UpdateTime]) VALUES (1, N'Admin', N'100', 0, 0, CAST(N'2021-02-17T20:48:43.250' AS DateTime), 0, CAST(N'2021-02-17T20:48:43.250' AS DateTime))
GO
INSERT [dbo].[Permission] ([ID], [Name], [Code], [IsDeleted], [CreateUserID], [CreateTime], [UpdateUserID], [UpdateTime]) VALUES (3, N'UserPermissionManage', N'100101', 0, 0, CAST(N'2021-02-17T20:55:30.470' AS DateTime), 0, CAST(N'2021-02-17T20:55:30.470' AS DateTime))
GO
INSERT [dbo].[Permission] ([ID], [Name], [Code], [IsDeleted], [CreateUserID], [CreateTime], [UpdateUserID], [UpdateTime]) VALUES (4, N'UserManage', N'100102', 0, 0, CAST(N'2021-02-17T20:55:40.167' AS DateTime), 0, CAST(N'2021-02-17T20:55:40.167' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Permission] OFF
GO