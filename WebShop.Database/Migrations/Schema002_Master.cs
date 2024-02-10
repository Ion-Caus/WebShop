using Migr8;

namespace WebShop.Database.Migrations;

[Migration(2, "Create the starting schema for the database")]
public class Schema002_Master : ISqlMigration
{
    public string Sql => @"
CREATE TABLE [dbo].[Warehouses] (
    [Id] INT IDENTITY NOT NULL,
    [Name] NVARCHAR(255) NOT NULL,
    [Address1] NVARCHAR(200) NULL,
    [Address2] NVARCHAR(200) NULL,
    [City] NVARCHAR(150) NULL,
    [Country] NVARCHAR(150) NULL,

    CONSTRAINT [PK_Warehouses] PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[Categories] (
    [Id] INT IDENTITY NOT NULL,
    [Name] NVARCHAR(150) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[Products] (
    [Id] INT IDENTITY NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(250) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    [PricePerKg] DECIMAL(18, 5) NOT NULL,
    [CurrencyCode] NVARCHAR(5) NOT NULL,
    [ImageUrl] NVARCHAR(MAX) NULL,
    [CategoryId] INT NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Products_ProductId] UNIQUE ([ProductId]),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id])
);

CREATE TABLE [dbo].[ProductStocks] (
    [Id] INT IDENTITY NOT NULL,
    [ProductId] INT NOT NULL,
    [WarehouseId] INT NOT NULL,
    [Weight] DECIMAL(18, 5) NOT NULL,
    [ExpirationDate] DATETIMEOFFSET NOT NULL,
    CONSTRAINT [PK_ProductStocks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductStocks_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [FK_ProductStocks_Warehouses_WarehouseId] FOREIGN KEY ([WarehouseId]) REFERENCES [dbo].[Warehouses] ([Id])
);

CREATE TABLE [dbo].[Carts] (
    [Id] INT IDENTITY NOT NULL,
    [CartId] UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt] DATETIMEOFFSET NOT NULL,
    CONSTRAINT [PK_Carts] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Carts_CartId] UNIQUE ([CartId])
);

CREATE TABLE [dbo].[CartItems] (
    [Id] INT IDENTITY NOT NULL,
    [CartItemId] UNIQUEIDENTIFIER NOT NULL,
    [CartId] INT NOT NULL,
    [ProductId] INT NOT NULL,
    [Quantity] INT NOT NULL,
    CONSTRAINT [PK_CartItems] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_CartItems_CartItemId] UNIQUE ([CartItemId]),
    CONSTRAINT [FK_CartItems_Carts_CartId] FOREIGN KEY ([CartId]) REFERENCES [dbo].[Carts] ([Id]),
    CONSTRAINT [FK_CartItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);

CREATE TABLE [dbo].[Orders] (
    [Id] INT IDENTITY NOT NULL,
    [OrderId] UNIQUEIDENTIFIER NOT NULL,
    [OrderDate] DATETIMEOFFSET NOT NULL,
    [TotalAmount] DECIMAL(18, 5) NOT NULL,
    [CurrencyCode] NVARCHAR(5) NOT NULL,
    [Status] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Orders_OrderId] UNIQUE ([OrderId])
);

CREATE TABLE [dbo].[OrderItems] (
    [Id] INT IDENTITY NOT NULL,
    [OrderItemId] UNIQUEIDENTIFIER NOT NULL,
    [Quantity] INT NOT NULL,
    [UnitPrice] DECIMAL(18, 5) NOT NULL,
    [CurrencyCode] NVARCHAR(5) NOT NULL,
    [OrderId] INT NOT NULL,
    [ProductId] INT NOT NULL,
    CONSTRAINT [PK_OrderItems] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_OrderItems_OrderItemId] UNIQUE ([OrderItemId]),
    CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]),
    CONSTRAINT [FK_OrderItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);
";
}