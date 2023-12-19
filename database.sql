USE [D:\CODE\DOAN_WEBACC\DB_WEBACC.MDF]
GO
/****** Object:  Table [dbo].[AdminMenu]    Script Date: 19/12/2023 5:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminMenu](
	[AdminMenuID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](50) NOT NULL,
	[ParentLevel] [int] NOT NULL,
	[ItemOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ItemDropDown] [nvarchar](50) NULL,
	[ControllerName] [nvarchar](50) NULL,
	[ActionName] [nvarchar](50) NULL,
	[Icon] [nvarchar](50) NULL,
 CONSTRAINT [PK_AdminMenu] PRIMARY KEY CLUSTERED 
(
	[AdminMenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminUser]    Script Date: 19/12/2023 5:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminUser](
	[AdminUserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nchar](256) NOT NULL,
	[Password] [nchar](256) NOT NULL,
	[Email] [nchar](256) NOT NULL,
 CONSTRAINT [PK_AdminUser] PRIMARY KEY CLUSTERED 
(
	[AdminUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Footer]    Script Date: 19/12/2023 5:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footer](
	[FooterID] [int] IDENTITY(1,1) NOT NULL,
	[ItemText] [nvarchar](200) NULL,
	[Column] [int] NOT NULL,
	[ParentID] [int] NOT NULL,
	[ItemOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Icon] [nvarchar](100) NULL,
	[TextLink] [nvarchar](100) NULL,
	[Link] [nchar](256) NULL,
 CONSTRAINT [PK_Footer] PRIMARY KEY CLUSTERED 
(
	[FooterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GI]    Script Date: 19/12/2023 5:04:03 CH ******/
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
	[UserName] [nchar](100) NULL,
	[Password] [nchar](100) NULL,
	[Sold] [int] NULL,
	[HoyolabID] [int] NULL,
	[Price] [int] NULL,
	[SoldDate] [datetime] NULL,
 CONSTRAINT [PK_GI] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HI]    Script Date: 19/12/2023 5:04:03 CH ******/
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
	[UserName] [nchar](100) NULL,
	[Password] [nchar](100) NULL,
	[Sold] [int] NULL,
	[HoyolabID] [int] NULL,
	[Price] [int] NULL,
	[SoldDate] [datetime] NULL,
 CONSTRAINT [PK_HI] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HSR]    Script Date: 19/12/2023 5:04:03 CH ******/
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
	[UserName] [nchar](100) NULL,
	[Password] [nchar](100) NULL,
	[Sold] [int] NULL,
	[HoyolabID] [int] NULL,
	[Price] [int] NULL,
	[SoldDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 19/12/2023 5:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ControllerName] [nvarchar](50) NULL,
	[ActionName] [nvarchar](50) NULL,
	[ParentID] [int] NULL,
	[Link] [nvarchar](50) NULL,
	[MenuOrder] [int] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 19/12/2023 5:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[username] [nchar](256) NOT NULL,
	[Password] [nchar](32) NOT NULL,
	[Phone] [nchar](15) NULL,
	[Mail] [nchar](256) NULL,
	[Ban] [bit] NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GI]  WITH NOCHECK ADD FOREIGN KEY([Sold])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[HI]  WITH NOCHECK ADD FOREIGN KEY([Sold])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[HSR]  WITH NOCHECK ADD FOREIGN KEY([Sold])
REFERENCES [dbo].[User] ([UserID])
GO
