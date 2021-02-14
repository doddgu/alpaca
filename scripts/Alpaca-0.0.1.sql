USE [master]
GO
/****** Object:  Database [Alpaca]    Script Date: 2021/2/14 20:53:44 ******/
CREATE DATABASE [Alpaca]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Alpaca', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Alpaca.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Alpaca_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Alpaca_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Alpaca] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Alpaca].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Alpaca] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Alpaca] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Alpaca] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Alpaca] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Alpaca] SET ARITHABORT OFF 
GO
ALTER DATABASE [Alpaca] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Alpaca] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Alpaca] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Alpaca] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Alpaca] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Alpaca] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Alpaca] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Alpaca] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Alpaca] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Alpaca] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Alpaca] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Alpaca] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Alpaca] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Alpaca] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Alpaca] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Alpaca] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Alpaca] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Alpaca] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Alpaca] SET  MULTI_USER 
GO
ALTER DATABASE [Alpaca] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Alpaca] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Alpaca] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Alpaca] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Alpaca] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Alpaca] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Alpaca] SET QUERY_STORE = OFF
GO
USE [Alpaca]
GO
/****** Object:  Table [dbo].[ConfigApp]    Script Date: 2021/2/14 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigApp](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[VerifyMissingDays] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateUserID] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateUserID] [int] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_CONFIGAPP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConfigAppEnvironment]    Script Date: 2021/2/14 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigAppEnvironment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ConfigAppID] [int] NOT NULL,
	[ConfigEnvironmentID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateUserID] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateUserID] [int] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_CONFIGAPPENVIRONMENT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConfigDispatch]    Script Date: 2021/2/14 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigDispatch](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[JsonConfig] [ntext] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateUserID] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateUserID] [int] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_CONFIGDISPATCH] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConfigEnvironment]    Script Date: 2021/2/14 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigEnvironment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateUserID] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateUserID] [int] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_CONFIGENVIRONMENT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConfigItem]    Script Date: 2021/2/14 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigItem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Namespace] [varchar](100) NOT NULL,
	[ConfigAppID] [int] NOT NULL,
	[ConfigEnvironmentID] [int] NOT NULL,
	[Value] [ntext] NOT NULL,
	[Description] [ntext] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateUserID] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateUserID] [int] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_CONFIGITEM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConfigItemSniffer]    Script Date: 2021/2/14 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigItemSniffer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ConfigAppID] [int] NOT NULL,
	[Namespace] [varchar](100) NOT NULL,
	[Status] [int] NOT NULL,
	[VerifyMissingTime] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateUserID] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateUserID] [int] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_CONFIGITEMSNIFFER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2021/2/14 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[NickName] [nvarchar](20) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateUserID] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateUserID] [int] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Name]    Script Date: 2021/2/14 20:53:44 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Name] ON [dbo].[ConfigEnvironment]
(
	[Name] ASC
)
WHERE ([IsDeleted]=(0))
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ConfigApp] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ConfigApp] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[ConfigApp] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[ConfigAppEnvironment] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ConfigAppEnvironment] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[ConfigAppEnvironment] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[ConfigDispatch] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ConfigDispatch] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[ConfigDispatch] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[ConfigEnvironment] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ConfigEnvironment] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[ConfigEnvironment] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[ConfigItem] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ConfigItem] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[ConfigItem] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[ConfigItemSniffer] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ConfigItemSniffer] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[ConfigItemSniffer] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
USE [master]
GO
ALTER DATABASE [Alpaca] SET  READ_WRITE 
GO
