
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/03/2021 19:46:53
-- Generated from EDMX file: C:\Users\lenovo\source\repos\Portfolio\Portfolio.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [mfm];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Instrument_InstType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Instruments] DROP CONSTRAINT [FK_Instrument_InstType];
GO
IF OBJECT_ID(N'[dbo].[FK_StockPrice_Instrument]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockPrices] DROP CONSTRAINT [FK_StockPrice_Instrument];
GO
IF OBJECT_ID(N'[dbo].[FK_Trade_Instrument]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Trades] DROP CONSTRAINT [FK_Trade_Instrument];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Instruments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Instruments];
GO
IF OBJECT_ID(N'[dbo].[InstTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InstTypes];
GO
IF OBJECT_ID(N'[dbo].[InterestRates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InterestRates];
GO
IF OBJECT_ID(N'[dbo].[StockPrices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StockPrices];
GO
IF OBJECT_ID(N'[dbo].[Trades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trades];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Instruments'
CREATE TABLE [dbo].[Instruments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CompanyName] varchar(50)  NULL,
    [Exchange] varchar(max)  NULL,
    [Underlying] varchar(max)  NULL,
    [Strike] float  NULL,
    [Tenor] float  NULL,
    [IsCall] bit  NULL,
    [TypeID] int  NOT NULL,
    [Rebate] float  NULL,
    [Barrier] float  NULL,
    [BarrierType] varchar(max)  NULL,
    [Ticker] varchar(max)  NULL
);
GO

-- Creating table 'InstTypes'
CREATE TABLE [dbo].[InstTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Typename] varchar(max)  NULL
);
GO

-- Creating table 'InterestRates'
CREATE TABLE [dbo].[InterestRates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Tenor] float  NULL,
    [Rate] float  NULL
);
GO

-- Creating table 'StockPrices'
CREATE TABLE [dbo].[StockPrices] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NULL,
    [InstrumentID] int  NOT NULL,
    [ClosingPrice] float  NULL
);
GO

-- Creating table 'Trades'
CREATE TABLE [dbo].[Trades] (
    [TradeID] int IDENTITY(1,1) NOT NULL,
    [IsBuy] bit  NULL,
    [Quantity] float  NULL,
    [InstrumentID] int  NOT NULL,
    [Price] float  NULL,
    [Timestamp] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Instruments'
ALTER TABLE [dbo].[Instruments]
ADD CONSTRAINT [PK_Instruments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'InstTypes'
ALTER TABLE [dbo].[InstTypes]
ADD CONSTRAINT [PK_InstTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'InterestRates'
ALTER TABLE [dbo].[InterestRates]
ADD CONSTRAINT [PK_InterestRates]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'StockPrices'
ALTER TABLE [dbo].[StockPrices]
ADD CONSTRAINT [PK_StockPrices]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [TradeID] in table 'Trades'
ALTER TABLE [dbo].[Trades]
ADD CONSTRAINT [PK_Trades]
    PRIMARY KEY CLUSTERED ([TradeID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TypeID] in table 'Instruments'
ALTER TABLE [dbo].[Instruments]
ADD CONSTRAINT [FK_Instrument_InstType]
    FOREIGN KEY ([TypeID])
    REFERENCES [dbo].[InstTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Instrument_InstType'
CREATE INDEX [IX_FK_Instrument_InstType]
ON [dbo].[Instruments]
    ([TypeID]);
GO

-- Creating foreign key on [InstrumentID] in table 'StockPrices'
ALTER TABLE [dbo].[StockPrices]
ADD CONSTRAINT [FK_StockPrice_Instrument]
    FOREIGN KEY ([InstrumentID])
    REFERENCES [dbo].[Instruments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StockPrice_Instrument'
CREATE INDEX [IX_FK_StockPrice_Instrument]
ON [dbo].[StockPrices]
    ([InstrumentID]);
GO

-- Creating foreign key on [InstrumentID] in table 'Trades'
ALTER TABLE [dbo].[Trades]
ADD CONSTRAINT [FK_Trade_Instrument]
    FOREIGN KEY ([InstrumentID])
    REFERENCES [dbo].[Instruments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Trade_Instrument'
CREATE INDEX [IX_FK_Trade_Instrument]
ON [dbo].[Trades]
    ([InstrumentID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------