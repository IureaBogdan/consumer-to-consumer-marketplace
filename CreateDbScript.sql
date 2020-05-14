USE [master]
GO
/****** Object:  Database [IureaBogdanIulian]    Script Date: 14-May-20 9:04:31 PM ******/
CREATE DATABASE [IureaBogdanIulian]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IureaBogdanIulian', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\IureaBogdanIulian.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IureaBogdanIulian_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\IureaBogdanIulian_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [IureaBogdanIulian] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IureaBogdanIulian].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IureaBogdanIulian] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET ARITHABORT OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [IureaBogdanIulian] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IureaBogdanIulian] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IureaBogdanIulian] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET  ENABLE_BROKER 
GO
ALTER DATABASE [IureaBogdanIulian] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IureaBogdanIulian] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [IureaBogdanIulian] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IureaBogdanIulian] SET  MULTI_USER 
GO
ALTER DATABASE [IureaBogdanIulian] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IureaBogdanIulian] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IureaBogdanIulian] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IureaBogdanIulian] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IureaBogdanIulian] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IureaBogdanIulian] SET QUERY_STORE = OFF
GO
USE [IureaBogdanIulian]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 14-May-20 9:04:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 14-May-20 9:04:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[Adress] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[ImageLink] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfferImages]    Script Date: 14-May-20 9:04:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfferImages](
	[OfferImageId] [uniqueidentifier] NOT NULL,
	[OfferId] [uniqueidentifier] NOT NULL,
	[ImageLink] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.OfferImages] PRIMARY KEY CLUSTERED 
(
	[OfferImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offers]    Script Date: 14-May-20 9:04:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offers](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[Price] [real] NULL,
	[Date] [datetime] NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Subcategory] [nvarchar](max) NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Offers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_OfferId]    Script Date: 14-May-20 9:04:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_OfferId] ON [dbo].[OfferImages]
(
	[OfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AccountId]    Script Date: 14-May-20 9:04:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[Offers]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OfferImages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OfferImages_dbo.Offers_OfferId] FOREIGN KEY([OfferId])
REFERENCES [dbo].[Offers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OfferImages] CHECK CONSTRAINT [FK_dbo.OfferImages_dbo.Offers_OfferId]
GO
ALTER TABLE [dbo].[Offers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Offers_dbo.Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Offers] CHECK CONSTRAINT [FK_dbo.Offers_dbo.Accounts_AccountId]
GO
USE [master]
GO
ALTER DATABASE [IureaBogdanIulian] SET  READ_WRITE 
GO
