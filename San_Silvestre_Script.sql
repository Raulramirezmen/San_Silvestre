USE [master]
GO
/****** Object:  Database [SanSilvestre]    Script Date: 13/12/2015 9:34:12 ******/
CREATE DATABASE [SanSilvestre] ON  PRIMARY 
( NAME = N'SanSilvestre', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\SanSilvestre.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SanSilvestre_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\SanSilvestre_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SanSilvestre] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SanSilvestre].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SanSilvestre] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SanSilvestre] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SanSilvestre] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SanSilvestre] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SanSilvestre] SET ARITHABORT OFF 
GO
ALTER DATABASE [SanSilvestre] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SanSilvestre] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SanSilvestre] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SanSilvestre] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SanSilvestre] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SanSilvestre] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SanSilvestre] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SanSilvestre] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SanSilvestre] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SanSilvestre] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SanSilvestre] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SanSilvestre] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SanSilvestre] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SanSilvestre] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SanSilvestre] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SanSilvestre] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SanSilvestre] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SanSilvestre] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SanSilvestre] SET  MULTI_USER 
GO
ALTER DATABASE [SanSilvestre] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SanSilvestre] SET DB_CHAINING OFF 
GO
USE [SanSilvestre]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 13/12/2015 9:34:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Competition]    Script Date: 13/12/2015 9:34:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Year] [int] NULL,
 CONSTRAINT [PK_Competition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Competition_Category]    Script Date: 13/12/2015 9:34:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competition_Category](
	[CompetitionId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[GenderId] [nvarchar](1) NOT NULL,
	[YearFrom] [int] NOT NULL,
	[YearTo] [int] NOT NULL,
	[Id] [int] NULL,
	[Description] [nvarchar](30) NULL,
 CONSTRAINT [PK_Runner_Category] PRIMARY KEY CLUSTERED 
(
	[CompetitionId] ASC,
	[CategoryId] ASC,
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Competition_Runner]    Script Date: 13/12/2015 9:34:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competition_Runner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompetitionId] [int] NOT NULL,
	[RunnerId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Dorsal] [int] NULL,
	[ElapsedTime] [timestamp] NULL,
	[PositionId] [int] NULL,
	[GeneralPosition] [int] NULL,
	[GenderId] [nvarchar](1) NULL,
	[Elapsed_Time] [nvarchar](20) NULL,
 CONSTRAINT [PK_CompetitionRunner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DocumentType]    Script Date: 13/12/2015 9:34:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gender]    Script Date: 13/12/2015 9:34:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [nvarchar](1) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Log]    Script Date: 13/12/2015 9:34:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Thread] [varchar](255) NOT NULL,
	[Level] [varchar](50) NOT NULL,
	[Logger] [varchar](255) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Exception] [nvarchar](max) NULL,
	[Source] [varchar](100) NULL,
	[HostName] [nvarchar](255) NULL,
	[User] [nvarchar](255) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 13/12/2015 9:34:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Runner]    Script Date: 13/12/2015 9:34:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Runner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SurName] [nvarchar](50) NOT NULL,
	[YearBirthday] [int] NOT NULL,
	[DocumentTypeId] [int] NULL,
	[DNI] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[Telephone] [int] NULL,
	[PostalCode] [int] NULL,
	[IsLocalRunner] [bit] NULL,
	[GenderId] [nvarchar](1) NULL,
	[Club] [nvarchar](30) NULL,
 CONSTRAINT [PK_Runner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 13/12/2015 9:34:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[EmailID] [nvarchar](128) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 13/12/2015 9:34:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Competition_Category]  WITH CHECK ADD  CONSTRAINT [FK_CompetitionCat_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Competition_Category] CHECK CONSTRAINT [FK_CompetitionCat_Category]
GO
ALTER TABLE [dbo].[Competition_Category]  WITH CHECK ADD  CONSTRAINT [FK_CompetitionCat_Competition] FOREIGN KEY([CompetitionId])
REFERENCES [dbo].[Competition] ([Id])
GO
ALTER TABLE [dbo].[Competition_Category] CHECK CONSTRAINT [FK_CompetitionCat_Competition]
GO
ALTER TABLE [dbo].[Competition_Category]  WITH CHECK ADD  CONSTRAINT [FK_CompetitionCat_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[Competition_Category] CHECK CONSTRAINT [FK_CompetitionCat_Gender]
GO
ALTER TABLE [dbo].[Competition_Runner]  WITH CHECK ADD  CONSTRAINT [FK_Competition_Runner_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Competition_Runner] CHECK CONSTRAINT [FK_Competition_Runner_Category]
GO
ALTER TABLE [dbo].[Competition_Runner]  WITH CHECK ADD  CONSTRAINT [FK_Competition_Runner_Competition] FOREIGN KEY([CompetitionId])
REFERENCES [dbo].[Competition] ([Id])
GO
ALTER TABLE [dbo].[Competition_Runner] CHECK CONSTRAINT [FK_Competition_Runner_Competition]
GO
ALTER TABLE [dbo].[Competition_Runner]  WITH CHECK ADD  CONSTRAINT [FK_Competition_Runner_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[Competition_Runner] CHECK CONSTRAINT [FK_Competition_Runner_Gender]
GO
ALTER TABLE [dbo].[Competition_Runner]  WITH CHECK ADD  CONSTRAINT [FK_Competition_Runner_Runner] FOREIGN KEY([RunnerId])
REFERENCES [dbo].[Runner] ([Id])
GO
ALTER TABLE [dbo].[Competition_Runner] CHECK CONSTRAINT [FK_Competition_Runner_Runner]
GO
ALTER TABLE [dbo].[Runner]  WITH CHECK ADD  CONSTRAINT [FK_Runner_DocumentType] FOREIGN KEY([DocumentTypeId])
REFERENCES [dbo].[DocumentType] ([Id])
GO
ALTER TABLE [dbo].[Runner] CHECK CONSTRAINT [FK_Runner_DocumentType]
GO
ALTER TABLE [dbo].[Runner]  WITH CHECK ADD  CONSTRAINT [FK_Runner_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[Runner] CHECK CONSTRAINT [FK_Runner_Gender]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRoles_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRoles_User]
GO
USE [master]
GO
ALTER DATABASE [SanSilvestre] SET  READ_WRITE 
GO
