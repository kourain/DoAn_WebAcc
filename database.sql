USE [DB_WEBACC]
GO
/****** Object:  Table [dbo].[AdminMenu]    Script Date: 28/11/2023 1:18:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminMenu](
	[AdminMenuID] [bigint] NOT NULL,
	[ItemName] [nvarchar](50) NULL,
	[ItemLevel] [int] NULL,
	[ParentLevel] [int] NULL,
	[ItemOrder] [int] NULL,
	[IsActive] [bit] NULL,
	[ItemTarget] [nvarchar](50) NULL,
	[AreaName] [nvarchar](50) NULL,
	[ControllerName] [nvarchar](50) NULL,
	[ActionName] [nvarchar](50) NULL,
	[Icon] [nvarchar](50) NULL,
	[IdName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminUser]    Script Date: 28/11/2023 1:19:00 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminUser](
	[UserID] [int] NOT NULL,
	[UserName] [nchar](256) NOT NULL,
	[Password] [nchar](256) NOT NULL,
	[Email] [nchar](256) NOT NULL,
	[IsActive] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Footer]    Script Date: 28/11/2023 1:19:00 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footer](
	[FooterID] [int] NOT NULL,
	[ItemText] [nvarchar](200) NULL,
	[Column] [int] NOT NULL,
	[ParentID] [int] NOT NULL,
	[ItemOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Icon] [nvarchar](100) NULL,
	[TextLink] [nvarchar](100) NULL,
	[Link] [nchar](256) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GI]    Script Date: 28/11/2023 1:19:00 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GI](
	[UID] [int] NOT NULL,
	[LV] [int] NULL,
	[CharCount] [int] NULL,
	[Weapon] [int] NULL,
	[Server] [nchar](10) NULL,
	[Type] [nchar](10) NULL,
	[UserName] [nchar](30) NULL,
	[Password] [nchar](30) NULL,
	[Sold] [int] NULL,
	[HoyolabID] [int] NULL,
	[Price] [int] NULL,
	[SoldDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HI]    Script Date: 28/11/2023 1:19:00 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HI](
	[UID] [int] NOT NULL,
	[LV] [int] NULL,
	[CharCount] [int] NULL,
	[Weapon] [int] NULL,
	[Server] [nchar](10) NULL,
	[Type] [nchar](10) NULL,
	[UserName] [nchar](30) NULL,
	[Password] [nchar](30) NULL,
	[Sold] [int] NULL,
	[HoyolabID] [int] NULL,
	[Price] [int] NULL,
	[SoldDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HSR]    Script Date: 28/11/2023 1:19:00 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HSR](
	[UID] [int] NOT NULL,
	[LV] [int] NULL,
	[CharCount] [int] NULL,
	[Weapon] [int] NULL,
	[Server] [nchar](10) NULL,
	[Type] [nchar](10) NULL,
	[UserName] [nchar](30) NULL,
	[Password] [nchar](30) NULL,
	[Sold] [int] NULL,
	[HoyolabID] [int] NULL,
	[Price] [int] NULL,
	[SoldDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 28/11/2023 1:19:00 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [int] NOT NULL,
	[MenuName] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[ControllerName] [nvarchar](50) NULL,
	[ActionName] [nvarchar](50) NULL,
	[ParentID] [int] NULL,
	[Link] [nvarchar](50) NULL,
	[MenuOrder] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 28/11/2023 1:19:00 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[username] [nchar](50) NOT NULL,
	[Phone] [nchar](15) NULL,
	[Mail] [nchar](50) NULL,
	[Password] [nchar](32) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (1, N'Bảng điều khiển', 0, 0, 1, 0, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (2, N'Thông tin cá nhân', 0, 0, 1, 0, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (3, N'Hướng dẫn sử dụng', 0, 0, 2, 0, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (4, N'Liên Lạc', 0, 0, 3, 0, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (5, N'Đăng xuất', 0, 0, 4, 0, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (6, N'Quản lý tài khoản bán', 1, 0, 1, 1, N'components-nav', N'Admin', N'Home', N'Index', N'bi bi-menu-button-wide', N'components-nav')
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (7, N'Honkai Impact 3', 2, 6, 1, 1, NULL, N'Admin', N'AccHI', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (8, N'Genshin Impact', 2, 6, 2, 1, NULL, N'Admin', N'AccGI', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (9, N'Honkai: Star Rail', 2, 6, 3, 1, NULL, N'Admin', N'AccHSR', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (10, N'Quản lý Menu', 1, 0, 1, 1, NULL, N'Admin', N'Menu', N'Index', N'bi bi-journal-text', NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (13, N'Quản lý Footer', 1, 0, 1, 1, NULL, N'Admin', N'Footer', N'Index', N'bi bi-journal-text', NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (14, N'Thêm mới slide', 2, 13, 1, 1, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (15, N'Chỉnh sửa slide', 2, 13, 2, 1, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminUser] ([UserID], [UserName], [Password], [Email], [IsActive]) VALUES (1, N'QUYEN                                                                                                                                                                                                                                                           ', N'a2fcd7c5eacade4a4e9a8d968167cda6                                                                                                                                                                                                                                ', N'maiquyen16503@gmail.com                                                                                                                                                                                                                                         ', 1)
GO
INSERT [dbo].[AdminUser] ([UserID], [UserName], [Password], [Email], [IsActive]) VALUES (2, N'chima4g                                                                                                                                                                                                                                                         ', N'0e5d3b34281de827648b89ab8a153f1f                                                                                                                                                                                                                                ', N'natra147258369@gmail.com                                                                                                                                                                                                                                        ', 1)
GO
INSERT [dbo].[Footer] ([FooterID], [ItemText], [Column], [ParentID], [ItemOrder], [IsActive], [Icon], [TextLink], [Link]) VALUES (1, N'Về HoyoGames Shop', 1, 0, 1, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[Footer] ([FooterID], [ItemText], [Column], [ParentID], [ItemOrder], [IsActive], [Icon], [TextLink], [Link]) VALUES (2, N'Chúng tôi làm việc chuyên nghiệp,', 1, 1, 1, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[Footer] ([FooterID], [ItemText], [Column], [ParentID], [ItemOrder], [IsActive], [Icon], [TextLink], [Link]) VALUES (3, N'Phục vụ Tận Tình và Chu Đáo nhất,', 1, 1, 2, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[Footer] ([FooterID], [ItemText], [Column], [ParentID], [ItemOrder], [IsActive], [Icon], [TextLink], [Link]) VALUES (4, N'Chúng tôi luôn luôn Bảo vệ lợi ích', 1, 1, 3, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[Footer] ([FooterID], [ItemText], [Column], [ParentID], [ItemOrder], [IsActive], [Icon], [TextLink], [Link]) VALUES (5, N'của khách hàng lên hàng đầu.', 1, 1, 4, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[Footer] ([FooterID], [ItemText], [Column], [ParentID], [ItemOrder], [IsActive], [Icon], [TextLink], [Link]) VALUES (6, N'Chúng tôi', 2, 0, 1, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[Footer] ([FooterID], [ItemText], [Column], [ParentID], [ItemOrder], [IsActive], [Icon], [TextLink], [Link]) VALUES (7, N'Group FB thảo luận và hỗ trợ: ', 2, 6, 1, 1, N'fab fa-facebook-square fa-2x mr-2', N'Tại đây', N'https://www.facebook.com/                                                                                                                                                                                                                                       ')
GO
INSERT [dbo].[Footer] ([FooterID], [ItemText], [Column], [ParentID], [ItemOrder], [IsActive], [Icon], [TextLink], [Link]) VALUES (8, N'Group Discord HoyoGames Shop', 2, 6, 2, 1, N'fab fa-discord fa-2x', N'Tại đây', N'https://discord.gg/FNZnRTMx                                                                                                                                                                                                                                     ')
GO
INSERT [dbo].[Footer] ([FooterID], [ItemText], [Column], [ParentID], [ItemOrder], [IsActive], [Icon], [TextLink], [Link]) VALUES (9, N'Link page hỗ trợ các vấn đề :', 2, 6, 3, 1, N'fab fa-facebook-square fa-2x mr-2', N'Tại đây', N'https://www.facebook.com/                                                                                                                                                                                                                                       ')
GO
INSERT [dbo].[Footer] ([FooterID], [ItemText], [Column], [ParentID], [ItemOrder], [IsActive], [Icon], [TextLink], [Link]) VALUES (10, N'Liên hệ', 3, 0, 1, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[Footer] ([FooterID], [ItemText], [Column], [ParentID], [ItemOrder], [IsActive], [Icon], [TextLink], [Link]) VALUES (11, N'Hotline: 0123456789', 3, 10, 1, 1, N'fa fa-phone mr-2', NULL, NULL)
GO
INSERT [dbo].[Footer] ([FooterID], [ItemText], [Column], [ParentID], [ItemOrder], [IsActive], [Icon], [TextLink], [Link]) VALUES (12, N'Work time: 24/7', 3, 10, 2, 1, N'fa fa-clock mr-2', NULL, NULL)
GO
INSERT [dbo].[Footer] ([FooterID], [ItemText], [Column], [ParentID], [ItemOrder], [IsActive], [Icon], [TextLink], [Link]) VALUES (13, N'Address: 182 Lê Duẩn, Vinh, Nghệ An', 3, 10, 3, 1, N'fa fa-map-marked-alt mr-2', NULL, NULL)
GO
INSERT [dbo].[Footer] ([FooterID], [ItemText], [Column], [ParentID], [ItemOrder], [IsActive], [Icon], [TextLink], [Link]) VALUES (14, N'Email: maiquyen16503@gmail.com', 3, 10, 4, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[GI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (805552681, 60, 64, 14, N'Asia      ', N'Vip       ', N'accgi1                        ', N'123123                        ', 1, NULL, 50000000, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[GI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (809916178, 60, 54, 15, N'Asia      ', N'Vip       ', N'accgi2                        ', N'123123                        ', 1, NULL, 40000000, CAST(N'2023-11-24T17:34:30.813' AS DateTime))
GO
INSERT [dbo].[GI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (848752662, 59, 60, 11, N'Asia      ', N'Vip       ', N'accgi3                        ', N'123123                        ', NULL, NULL, 45000000, NULL)
GO
INSERT [dbo].[GI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (807907052, 58, 55, 15, N'Asia      ', N'Vip       ', N'accgi4                        ', N'123123                        ', NULL, NULL, 64000000, NULL)
GO
INSERT [dbo].[GI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (837606940, 60, 56, 12, N'Asia      ', N'Vip       ', N'accgi5                        ', N'123123                        ', NULL, NULL, 45000000, NULL)
GO
INSERT [dbo].[GI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (809380886, 60, 61, 18, N'Asia      ', N'Vip       ', N'accgi6                        ', N'123123                        ', NULL, NULL, 60000000, NULL)
GO
INSERT [dbo].[GI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (800710664, 60, 62, 17, N'Sea       ', N'VIP       ', NULL, NULL, NULL, 44744663, 100000000, NULL)
GO
INSERT [dbo].[GI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (810181574, 60, 48, 19, N'Asia      ', N'Vip       ', N'accgi8                        ', N'123123                        ', NULL, NULL, 63000000, NULL)
GO
INSERT [dbo].[GI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (841744533, 59, 55, 11, N'Asia      ', N'Vip       ', N'accgi9                        ', N'123123                        ', NULL, NULL, 64000000, NULL)
GO
INSERT [dbo].[GI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (855273158, 59, 69, 16, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 2000000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000001, 88, 34, 33, N'Sea       ', N'VIP       ', NULL, NULL, NULL, 44744663, 1000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000002, 88, 36, 34, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 100000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000003, 88, 44, 40, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 1321313, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000004, 88, 56, 41, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 1111111, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000005, 88, 59, 52, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 430000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000006, 88, 49, 41, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 240000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000007, 88, 56, 51, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 320000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000008, 88, 55, 23, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 430000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000009, 88, 45, 22, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 112000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000010, 88, 55, 54, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 220000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000011, 88, 45, 40, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 320000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000012, 88, 65, 51, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 120000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000013, 88, 54, 36, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 140000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000014, 88, 51, 41, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 210000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000015, 88, 52, 47, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 150000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000016, 88, 53, 51, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 340000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000017, 88, 54, 50, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 123000, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000018, 88, 61, 32, N'Asia      ', N'VIP       ', N'acchi18                       ', N'147258                        ', 0, NULL, NULL, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000019, 88, 54, 55, N'Asia      ', N'VIP       ', N'acchi19                       ', N'147258                        ', 0, NULL, NULL, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000020, 88, 55, 41, N'Asia      ', N'VIP       ', N'acchi20                       ', N'147258                        ', 0, NULL, NULL, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000031, 11, 11, 11, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 123213213, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000021, 80, 45, 41, N'Asia      ', N'VIP       ', N'acchi21                       ', N'147258                        ', 0, NULL, NULL, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000022, 80, 34, 31, N'Asia      ', N'VIP       ', N'acchi22                       ', N'147258                        ', 0, NULL, NULL, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000023, 88, 39, 38, N'Asia      ', N'VIP       ', N'acchi23                       ', N'147258                        ', 0, NULL, NULL, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000024, 80, 36, 35, N'Asia      ', N'VIP       ', N'acchi24                       ', N'147258                        ', 0, NULL, NULL, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000025, 82, 45, 41, N'Asia      ', N'VIP       ', N'acchi25                       ', N'147258                        ', 0, NULL, NULL, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000026, 88, 66, 56, N'Asia      ', N'VIP       ', N'acchi26                       ', N'147258                        ', 0, NULL, NULL, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000027, 80, 55, 55, N'Asia      ', N'VIP       ', N'acchi27                       ', N'147258                        ', 0, NULL, NULL, NULL)
GO
INSERT [dbo].[HI] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (10000028, 88, 34, 56, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 250000, NULL)
GO
INSERT [dbo].[HSR] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (800107589, 60, 20, 11, N'Asia      ', N'Norm      ', N'acvhsr1                       ', N'pass1                         ', 0, NULL, 99999, NULL)
GO
INSERT [dbo].[HSR] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (800534484, 60, 30, 12, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 320000, NULL)
GO
INSERT [dbo].[HSR] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (800297271, 61, 31, 13, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 4000000, NULL)
GO
INSERT [dbo].[HSR] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (800443345, 63, 26, 14, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 4200000, NULL)
GO
INSERT [dbo].[HSR] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (804349046, 70, 33, 13, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 5100000, NULL)
GO
INSERT [dbo].[HSR] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (801271164, 56, 55, 23, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 2400000, NULL)
GO
INSERT [dbo].[HSR] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (827662480, 23, 34, 15, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 435000, NULL)
GO
INSERT [dbo].[HSR] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (824853530, 59, 24, 22, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 2000000, NULL)
GO
INSERT [dbo].[HSR] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (801345523, 45, 23, 13, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 4500000, NULL)
GO
INSERT [dbo].[HSR] ([UID], [LV], [CharCount], [Weapon], [Server], [Type], [UserName], [Password], [Sold], [HoyolabID], [Price], [SoldDate]) VALUES (824853530, 59, 24, 22, N'Sea       ', N'VIP       ', NULL, NULL, NULL, NULL, 2000000, NULL)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [ParentID], [Link], [MenuOrder]) VALUES (1, N'Honkai Impact 3', 1, N'AccHI', NULL, 0, NULL, 1)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [ParentID], [Link], [MenuOrder]) VALUES (2, N'Genshin Impact', 1, N'AccGI', NULL, 0, NULL, 2)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [ParentID], [Link], [MenuOrder]) VALUES (3, N'Honkai: Star Rail', 1, N'AccHSR', NULL, 0, NULL, 3)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [ParentID], [Link], [MenuOrder]) VALUES (4, N'Lịch sử mua', 1, NULL, NULL, 0, NULL, 4)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [ParentID], [Link], [MenuOrder]) VALUES (5, N'Honkai Impact 3', 1, N'AccHI', N'HistoryBuy', 4, NULL, 1)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [ParentID], [Link], [MenuOrder]) VALUES (6, N'Genshin Impact', 1, N'AccGI', N'HistoryBuy', 4, NULL, 2)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [ParentID], [Link], [MenuOrder]) VALUES (7, N'Honkai: Star Rail', 1, N'AccHSR', N'HistoryBuy', 4, NULL, 3)
GO
INSERT [dbo].[User] ([ID], [Name], [username], [Phone], [Mail], [Password]) VALUES (1, N'Kourain', N'kkk                                               ', N'135431534      ', N'1654646                                           ', N'a2fcd7c5eacade4a4e9a8d968167cda6')
GO
INSERT [dbo].[User] ([ID], [Name], [username], [Phone], [Mail], [Password]) VALUES (2, N'Kourain', N'abc                                               ', N'000191         ', N'11                                                ', N'a2fcd7c5eacade4a4e9a8d968167cda6')
GO
