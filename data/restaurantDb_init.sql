-- This is init database script
-- The connection string will depend on the name of the database
-- USE database

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [categories] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [Description] nvarchar(255) NULL,
    CONSTRAINT [PK_categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [coupontypes] (
    [Id] int NOT NULL IDENTITY,
    [StartTime] datetime2 NOT NULL,
    [EndTime] datetime2 NOT NULL,
    [PercentValue] int NOT NULL,
    [HardValue] float NOT NULL,
    CONSTRAINT [PK_coupontypes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [customer] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [Phone] nvarchar(10) NULL,
    [Email] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_customer] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [products] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [UnitPrice] float NOT NULL,
    [Image] nvarchar(max) NOT NULL,
    [Description] nvarchar(255) NULL,
    [CategoryId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_products_categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [categories] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [coupons] (
    [Id] uniqueidentifier NOT NULL,
    [IsUsed] Bit NOT NULL,
    [CouponTypeId] int NOT NULL,
    [CustomerId] uniqueidentifier NULL,
    CONSTRAINT [PK_coupons] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_coupons_coupontypes_CouponTypeId] FOREIGN KEY ([CouponTypeId]) REFERENCES [coupontypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_coupons_customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [customer] ([Id]) ON DELETE SET NULL
);
GO

CREATE TABLE [orders] (
    [Id] uniqueidentifier NOT NULL,
    [OrderTime] datetime2 NOT NULL,
    [Address] nvarchar(450) NOT NULL,
    [SubTotal] float NOT NULL,
    [Discount] float NOT NULL,
    [Total] float NOT NULL,
    [Note] nvarchar(255) NULL,
    [CustomerId] uniqueidentifier NULL,
    CONSTRAINT [PK_orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_orders_customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [customer] ([Id]) ON DELETE SET NULL
);
GO

CREATE TABLE [combodetails] (
    [Id] int NOT NULL IDENTITY,
    [Quantity] int NOT NULL,
    [ComboId] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_combodetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_combodetails_products_ComboId] FOREIGN KEY ([ComboId]) REFERENCES [products] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_combodetails_products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [products] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [discounts] (
    [Id] int NOT NULL IDENTITY,
    [StartTime] datetime2 NOT NULL,
    [EndTime] datetime2 NOT NULL,
    [PercentValue] int NOT NULL,
    [HardValue] float NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_discounts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_discounts_products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [products] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [orderdetails] (
    [Id] int NOT NULL IDENTITY,
    [ProductName] nvarchar(100) NOT NULL,
    [UnitPrice] float NOT NULL,
    [Quantity] int NOT NULL,
    [Note] nvarchar(255) NULL,
    [OrderId] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NULL,
    CONSTRAINT [PK_orderdetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_orderdetails_orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [orders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_orderdetails_products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [products] ([Id]) ON DELETE SET NULL
);
GO

CREATE UNIQUE INDEX [IX_categories_Name] ON [categories] ([Name]);
GO

CREATE INDEX [IX_combodetails_ComboId] ON [combodetails] ([ComboId]);
GO

CREATE INDEX [IX_combodetails_ProductId] ON [combodetails] ([ProductId]);
GO

CREATE INDEX [IX_coupons_CouponTypeId] ON [coupons] ([CouponTypeId]);
GO

CREATE INDEX [IX_coupons_CustomerId] ON [coupons] ([CustomerId]);
GO

CREATE INDEX [IX_discounts_ProductId] ON [discounts] ([ProductId]);
GO

CREATE INDEX [IX_orderdetails_OrderId] ON [orderdetails] ([OrderId]);
GO

CREATE INDEX [IX_orderdetails_ProductId] ON [orderdetails] ([ProductId]);
GO

CREATE INDEX [IX_orders_CustomerId] ON [orders] ([CustomerId]);
GO

CREATE INDEX [IX_products_CategoryId] ON [products] ([CategoryId]);
GO

CREATE UNIQUE INDEX [IX_products_Name] ON [products] ([Name]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240625073848_FFOEContext_01', N'8.0.6');
GO

COMMIT;
GO