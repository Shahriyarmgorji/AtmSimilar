USE [ATM]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 02/22/2022 12:42:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TXTBank] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[Id_Card] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[Id_Account] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[Card_Inventory] [int] NULL,
	[Name_Bank_Account_Holder] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[Date] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[PassWord] [nchar](10) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[BankCard]    Script Date: 02/22/2022 12:42:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BankCard]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BankCard](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameBank] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[IDCard] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[Name_Bank_Account_Holder] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_BankCard] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Deposit]    Script Date: 02/22/2022 12:42:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Deposit]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Deposit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BankName] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[IDCard] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[Depositm] [int] NULL,
	[Date] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[Information] [nvarchar](max) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_Deposit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[movement]    Script Date: 02/22/2022 12:42:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[movement]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[movement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdCardDestination] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[BankName] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[AccountHolder] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[Moneytransfrom] [int] NULL,
	[Date] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[Time] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_movement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Wishlist]    Script Date: 02/22/2022 12:42:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wishlist]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Wishlist](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameBank] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[IdCard] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[Depositm] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[Date] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_Wishlist] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
