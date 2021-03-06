USE [master]
GO
/****** Object:  Database [CabAge]    Script Date: 24-07-2015 00:56:50 ******/
CREATE DATABASE [CabAge]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CabAge', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CabAge.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CabAge_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CabAge_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CabAge] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CabAge].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CabAge] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CabAge] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CabAge] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CabAge] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CabAge] SET ARITHABORT OFF 
GO
ALTER DATABASE [CabAge] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CabAge] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CabAge] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CabAge] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CabAge] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CabAge] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CabAge] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CabAge] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CabAge] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CabAge] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CabAge] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CabAge] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CabAge] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CabAge] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CabAge] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CabAge] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CabAge] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CabAge] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CabAge] SET  MULTI_USER 
GO
ALTER DATABASE [CabAge] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CabAge] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CabAge] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CabAge] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CabAge] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CabAge]
GO
/****** Object:  Table [dbo].[CategoryMaster]    Script Date: 24-07-2015 00:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
 CONSTRAINT [PK_category_master] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeLocation]    Script Date: 24-07-2015 00:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLocation](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[GeoLocation] [geography] NULL,
 CONSTRAINT [PK_EmployeeLocation] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeMaster]    Script Date: 24-07-2015 00:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeMaster](
	[ID] [int] NOT NULL,
	[Name] [nchar](300) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Mobile] [bigint] NULL,
 CONSTRAINT [PK_EmployeeMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeSurveyResults]    Script Date: 24-07-2015 00:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSurveyResults](
	[EmployeeSurveyID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Rating] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_EmployeeSurveyResults] PRIMARY KEY CLUSTERED 
(
	[EmployeeSurveyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CategoryMaster] ON 

INSERT [dbo].[CategoryMaster] ([ID], [Name]) VALUES (1, N'Puntuality                                        ')
INSERT [dbo].[CategoryMaster] ([ID], [Name]) VALUES (2, N'Cab Cleanliness                                   ')
INSERT [dbo].[CategoryMaster] ([ID], [Name]) VALUES (3, N'Driver attitude                                   ')
SET IDENTITY_INSERT [dbo].[CategoryMaster] OFF
SET IDENTITY_INSERT [dbo].[EmployeeLocation] ON 

INSERT [dbo].[EmployeeLocation] ([LocationID], [ID], [GeoLocation]) VALUES (1, 4733, 0xE6100000010C7B14AE47E1D247404D158C4AEA885EC0)
SET IDENTITY_INSERT [dbo].[EmployeeLocation] OFF
INSERT [dbo].[EmployeeMaster] ([ID], [Name], [Email], [Mobile]) VALUES (4733, N'Krishna Chandran Mekkat                                                                                                                                                                                                                                                                                     ', N'krishna.chandran@socgen.com', 8861138821)
INSERT [dbo].[EmployeeMaster] ([ID], [Name], [Email], [Mobile]) VALUES (4734, N'Venkata Aratla                                                                                                                                                                                                                                                                                              ', N'venkata.aratla@socgen.com', 998877889)
INSERT [dbo].[EmployeeMaster] ([ID], [Name], [Email], [Mobile]) VALUES (4735, N'Ravi Boyina                                                                                                                                                                                                                                                                                                 ', N'ravi.boyina@socgen.com', 9988223365)
INSERT [dbo].[EmployeeMaster] ([ID], [Name], [Email], [Mobile]) VALUES (4736, N'Anitha Kesari                                                                                                                                                                                                                                                                                               ', N'anitha.kesari@socgen.com', 9900889900)
INSERT [dbo].[EmployeeMaster] ([ID], [Name], [Email], [Mobile]) VALUES (4900, N'TestEmployee                                                                                                                                                                                                                                                                                                ', N'test@test.com', 8861134421)
SET IDENTITY_INSERT [dbo].[EmployeeSurveyResults] ON 

INSERT [dbo].[EmployeeSurveyResults] ([EmployeeSurveyID], [EmployeeID], [CategoryID], [Rating], [CreatedDate]) VALUES (3, 4733, 1, 1, CAST(N'2015-07-24 00:37:49.950' AS DateTime))
INSERT [dbo].[EmployeeSurveyResults] ([EmployeeSurveyID], [EmployeeID], [CategoryID], [Rating], [CreatedDate]) VALUES (4, 4733, 2, 2, CAST(N'2015-07-24 00:37:50.120' AS DateTime))
INSERT [dbo].[EmployeeSurveyResults] ([EmployeeSurveyID], [EmployeeID], [CategoryID], [Rating], [CreatedDate]) VALUES (5, 4733, 3, 3, CAST(N'2015-07-24 00:37:50.317' AS DateTime))
INSERT [dbo].[EmployeeSurveyResults] ([EmployeeSurveyID], [EmployeeID], [CategoryID], [Rating], [CreatedDate]) VALUES (6, 4733, 1, 3, CAST(N'2015-07-25 00:37:50.573' AS DateTime))
INSERT [dbo].[EmployeeSurveyResults] ([EmployeeSurveyID], [EmployeeID], [CategoryID], [Rating], [CreatedDate]) VALUES (7, 4733, 2, 2, CAST(N'2015-07-25 00:37:50.727' AS DateTime))
INSERT [dbo].[EmployeeSurveyResults] ([EmployeeSurveyID], [EmployeeID], [CategoryID], [Rating], [CreatedDate]) VALUES (8, 4733, 3, 1, CAST(N'2015-07-25 00:37:51.097' AS DateTime))
SET IDENTITY_INSERT [dbo].[EmployeeSurveyResults] OFF
ALTER TABLE [dbo].[EmployeeLocation]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeLocation_EmployeeMaster] FOREIGN KEY([ID])
REFERENCES [dbo].[EmployeeMaster] ([ID])
GO
ALTER TABLE [dbo].[EmployeeLocation] CHECK CONSTRAINT [FK_EmployeeLocation_EmployeeMaster]
GO
ALTER TABLE [dbo].[EmployeeSurveyResults]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[CategoryMaster] ([ID])
GO
ALTER TABLE [dbo].[EmployeeSurveyResults]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[EmployeeMaster] ([ID])
GO
USE [master]
GO
ALTER DATABASE [CabAge] SET  READ_WRITE 
GO
