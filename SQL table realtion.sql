USE [master]
GO
/****** Object:  Database [mfm]    Script Date: 2021/3/15 9:31:31 ******/
CREATE DATABASE [mfm]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mfm', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER1\MSSQL\DATA\mfm.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'mfm_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER1\MSSQL\DATA\mfm_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [mfm] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mfm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [mfm] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mfm] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mfm] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mfm] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mfm] SET ARITHABORT OFF 
GO
ALTER DATABASE [mfm] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [mfm] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [mfm] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mfm] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mfm] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mfm] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mfm] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mfm] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mfm] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mfm] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mfm] SET  DISABLE_BROKER 
GO
ALTER DATABASE [mfm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mfm] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mfm] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mfm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [mfm] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mfm] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [mfm] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mfm] SET RECOVERY FULL 
GO
ALTER DATABASE [mfm] SET  MULTI_USER 
GO
ALTER DATABASE [mfm] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mfm] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mfm] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mfm] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'mfm', N'ON'
GO
USE [mfm]
GO
/****** Object:  User [test1]    Script Date: 2021/3/15 9:31:31 ******/
CREATE USER [test1] FOR LOGIN [test1] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [test1]
GO
/****** Object:  StoredProcedure [dbo].[insert_persons]    Script Date: 2021/3/15 9:31:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_persons]
    -- Add the parameters for the stored procedure here
    @id int, 
    @lastname varchar(255),
    @firstname varchar(255),
    @adress varchar(255),
    @city varchar(255)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    INSERT Persons (Id_P, LastName, FirstName, Address, City)
	VALUES (@id, @lastname, @firstname, @adress, @city)
END

GO
/****** Object:  Table [dbo].[Company]    Script Date: 2021/3/15 9:31:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[ID] [int] NOT NULL,
	[Companyname] [varchar](50) NULL,
	[Ticker] [varchar](50) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Instrument]    Script Date: 2021/3/15 9:31:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Instrument](
	[CompanyID] [int] NULL,
	[ID] [int] NOT NULL,
	[Exchange] [varchar](50) NOT NULL,
	[Underlying] [float] NULL,
	[Strike] [float] NULL,
	[Tenor] [float] NULL,
	[IsCall] [bit] NULL,
	[TypeID] [int] NOT NULL,
 CONSTRAINT [PK_Instrument_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InstType]    Script Date: 2021/3/15 9:31:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InstType](
	[Typename] [varchar](50) NULL,
	[ID] [int] NOT NULL,
 CONSTRAINT [PK_InstType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InterestRate]    Script Date: 2021/3/15 9:31:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterestRate](
	[RateID] [int] NOT NULL,
	[Tenor] [float] NULL,
	[Rate] [float] NULL,
 CONSTRAINT [PK_InterestRate] PRIMARY KEY CLUSTERED 
(
	[RateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockPrice]    Script Date: 2021/3/15 9:31:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockPrice](
	[CompanyID] [int] NOT NULL,
	[Date] [date] NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_StockPrice] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Trade]    Script Date: 2021/3/15 9:31:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trade](
	[TradeID] [int] NOT NULL,
	[IsBuy] [bit] NULL,
	[Quantity] [float] NULL,
	[InstrumentID] [int] NULL,
	[Price] [float] NULL,
	[Timestamp] [date] NULL,
	[RateID] [int] NULL,
	[StockID] [int] NULL,
 CONSTRAINT [PK_Trade] PRIMARY KEY CLUSTERED 
(
	[TradeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Instrument]  WITH CHECK ADD  CONSTRAINT [FK_Instrument_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([ID])
GO
ALTER TABLE [dbo].[Instrument] CHECK CONSTRAINT [FK_Instrument_Company]
GO
ALTER TABLE [dbo].[Instrument]  WITH CHECK ADD  CONSTRAINT [FK_Instrument_TypeID] FOREIGN KEY([TypeID])
REFERENCES [dbo].[InstType] ([ID])
GO
ALTER TABLE [dbo].[Instrument] CHECK CONSTRAINT [FK_Instrument_TypeID]
GO
ALTER TABLE [dbo].[StockPrice]  WITH CHECK ADD  CONSTRAINT [FK_StockPrice_CompanyID] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([ID])
GO
ALTER TABLE [dbo].[StockPrice] CHECK CONSTRAINT [FK_StockPrice_CompanyID]
GO
ALTER TABLE [dbo].[Trade]  WITH CHECK ADD  CONSTRAINT [FK_Trade_Instrument] FOREIGN KEY([InstrumentID])
REFERENCES [dbo].[Instrument] ([ID])
GO
ALTER TABLE [dbo].[Trade] CHECK CONSTRAINT [FK_Trade_Instrument]
GO
ALTER TABLE [dbo].[Trade]  WITH CHECK ADD  CONSTRAINT [FK_Trade_RateID] FOREIGN KEY([RateID])
REFERENCES [dbo].[InterestRate] ([RateID])
GO
ALTER TABLE [dbo].[Trade] CHECK CONSTRAINT [FK_Trade_RateID]
GO
ALTER TABLE [dbo].[Trade]  WITH CHECK ADD  CONSTRAINT [FK_Trade_StockID] FOREIGN KEY([StockID])
REFERENCES [dbo].[StockPrice] ([CompanyID])
GO
ALTER TABLE [dbo].[Trade] CHECK CONSTRAINT [FK_Trade_StockID]
GO
USE [master]
GO
ALTER DATABASE [mfm] SET  READ_WRITE 
GO
