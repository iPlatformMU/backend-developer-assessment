USE [master]
GO
/****** Object:  Database [DBArtist]    Script Date: 10/21/2020 9:41:20 PM ******/
CREATE DATABASE [DBArtist]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBArtist', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\DBArtist.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBArtist_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\DBArtist_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBArtist] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBArtist].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBArtist] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBArtist] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBArtist] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBArtist] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBArtist] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBArtist] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBArtist] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBArtist] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBArtist] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBArtist] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBArtist] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBArtist] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBArtist] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBArtist] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBArtist] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBArtist] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBArtist] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBArtist] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBArtist] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBArtist] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBArtist] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBArtist] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBArtist] SET RECOVERY FULL 
GO
ALTER DATABASE [DBArtist] SET  MULTI_USER 
GO
ALTER DATABASE [DBArtist] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBArtist] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBArtist] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBArtist] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBArtist] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBArtist', N'ON'
GO
ALTER DATABASE [DBArtist] SET QUERY_STORE = OFF
GO
USE [DBArtist]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 10/21/2020 9:41:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[ArtisteId] [uniqueidentifier] NOT NULL,
	[ArtisteName] [varchar](100) NULL,
	[Country] [varchar](50) NULL,
	[Aliases] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ArtisteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'6456a893-c1e9-4e3d-86f7-0008b0a3ac8a', N'Jack Johnson ', N'US', N'Jack Hody Johnson ')
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'144ef525-85e9-40c3-8335-02c32d0861f3', N'John Mayer ', N'US', N'')
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699', N'Transplants ', N'US', N'The Transplants ')
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'd700b3f5-45af-4d02-95ed-57d301bda93e', N'Mogwai ', N'GB', N'Mogwa ')
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'650e7db6-b795-4eb5-a702-5ea2fc46c848', N'Lady Gaga ', N'US', N'Lady Ga Ga, Stefani Joanne Angelina Germanotta')
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f', N'Johnny Cash', N'US', N'Johhny Cash,Jonny Cash')
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'b625448e-bf4a-41c3-a421-72ad46cdb831', N'John Coltrane ', N'US', N'John Coltraine, John William Coltrane')
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'24f8d8a5-269b-475c-a1cb-792990b0b2ee', N'Rancid ', N'US', N'ランシド ')
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'b83bc61f-8451-4a5d-8b8e-7e9ed295e822', N'Elton John', N'GB', N'E. John, Elthon John,Elton Jphn,John Elton, Regina')
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab', N'Metallica ', N'US', N'Metalica, 메탈리카')
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'a9044915-8be3-4c7e-b11f-9e2d2ea0a91e', N'Megadeth', N'US', N'Megadeath ')
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'435f1441-0f43-479d-92db-a506449a686b', N'Mott the Hoople ', N'GB', N'Mott The Hoppie, Mott The Hopple')
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'931e1d1f-6b2f-4ff8-9f70-aa537210cd46', N'Operation Ivy ', N'US', N'Op Ivy ')
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'f1571db1-c672-4a54-a2cf-aaa329f26f0b', N'John Frusciante ', N'US', N'John Anthony Frusciante ')
GO
INSERT [dbo].[Artist] ([ArtisteId], [ArtisteName], [Country], [Aliases]) VALUES (N'c44e9c22-ef82-4a77-9bcd-af6c958446d6', N'Mumford & Sons ', N'GB', N'')
GO
