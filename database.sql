
CREATE TABLE AdminMenu(
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
CREATE TABLE GI(
	[UID] [int] NULL,
	[LV] [int] NULL,
	[CharCount] [int] NULL,
	[Weapon] [int] NULL,
	[Server] [char](10) NULL,
	[Type] [char](10) NULL,
	[UserName] [char](30) NULL,
	[Password] [char](30) NULL,
	[Sold] [int] NULL,
	[Img] [char](256) NULL
) ON [PRIMARY]
GO
CREATE TABLE HI(
	[UID] [int] NOT NULL,
	[LV] [int] NULL,
	[CharCount] [int] NULL,
	[Weapon] [int] NULL,
	[Server] [char](10) NULL,
	[Type] [char](10) NULL,
	[UserName] [char](30) NULL,
	[Password] [char](30) NULL,
	[Sold] [int] NULL,
	[Img] [char](256) NULL
) ON [PRIMARY]
GO
CREATE TABLE HSR(
	[UID] [int] NULL,
	[LV] [int] NULL,
	[CharCount] [int] NULL,
	[Weapon] [int] NULL,
	[Server] [char](10) NULL,
	[Type] [char](10) NULL,
	[UserName] [char](30) NULL,
	[Password] [char](30) NULL,
	[Sold] [int] NULL,
	[Img] [char](256) NULL
) ON [PRIMARY]
GO
CREATE TABLE Menu(
	[MenuID] [int] NOT NULL,
	[MenuName] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[ControllerName] [nvarchar](50) NULL,
	[ActionName] [nvarchar](50) NULL,
	[Levels] [int] NULL,
	[ParentID] [int] NULL,
	[Link] [nvarchar](50) NULL,
	[MenuOrder] [int] NULL
) ON [PRIMARY]
GO
CREATE TABLE [User](
	[ID] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[username] [char](30) NULL,
	[Phone] [nchar](11) NULL,
	[Mail] [char](30) NULL,
	[Password] [char](30) NULL
) ON [PRIMARY]
GO
INSERT INTO [AdminMenu] VALUES
(1,N'Bảng điều khiển',0,0,1,0,NULL,'Admin','Home','Index',NULL,NULL),
(2,N'Thông tin cá nhân',0,0,1,0,NULL,'Admin','Home','Index',NULL,NULL),
(3,N'Hướng dẫn sử dụng',0,0,2,0,NULL,'Admin','Home','Index',NULL,NULL),
(4,N'Liên Lạc',0,0,3,0,NULL,'Admin','Home','Index',NULL,NULL),
(5,N'Đăng xuất',0,0,4,0,NULL,'Admin','Home','Index',NULL,NULL),
(6,N'Quản lý tài khoản bán',1,0,1,1,'components-nav','Admin','Home','Index','bi bi-menu-button-wide','components-nav'),
(7,N'Thêm tài khoản',2,6,1,1,NULL,'Admin','Home','Index',NULL,NULL),
(8,N'Xoá tài khoản',2,6,2,1,NULL,'Admin','Home','Index',NULL,NULL),
(9,N'Xem danh sách tài khoản',2,6,3,1,NULL,'Admin','Home','Index',NULL,NULL),
(10,N'Quản lý menu',1,0,1,1,'forms-nav','Admin','Home','Index','bi bi-journal-text','forms-nav'),
(11,N'Thêm mới menu',2,10,1,1,NULL,'Admin','Menu','Index',NULL,NULL),
(12,N'Chỉnh sửa menu',2,10,2,1,NULL,'Admin','Home','Index',NULL,NULL),
(13,N'Quản lý slide',1,0,1,1,'charts-nav','Admin','Home','Index','bi bi-bar-chart','charts-nav'),
(14,N'Thêm mới slide',2,13,1,1,NULL,'Admin','Home','Index',NULL,NULL),
(15,N'Chỉnh sửa slide',2,13,2,1,NULL,'Admin','Home','Index',NULL,NULL)
INSERT INTO [dbo].[Menu] VALUES
(1,'Honkai Impact 3',1,NULL,NULL,1,0,NULL,1),
(2,'Genshin Impact',1,NULL,NULL,1,0,NULL,2),
(3,'Honkai: Star Rail',1,NULL,NULL,1,0,NULL,3),
(4,N'Lịch sử mua',1,NULL,NULL,1,0,NULL,4),
(5,'Honkai Impact 3',1,NULL,NULL,2,4,NULL,1),
(6,'Genshin Impact',1,NULL,NULL,2,4,NULL,2),
(7,'Honkai: Star Rail',1,NULL,NULL,2,4,NULL,3)