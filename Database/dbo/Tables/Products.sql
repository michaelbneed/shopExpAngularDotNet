CREATE TABLE [dbo].[Products] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (100)  NOT NULL,
    [Description]    NVARCHAR (255)  NOT NULL,
    [PictureUrl]     NVARCHAR (MAX)  NOT NULL,
    [Price]          DECIMAL (18, 2) DEFAULT ((0.0)) NOT NULL,
    [ProductMakerId] INT             DEFAULT ((0)) NOT NULL,
    [ProductTypeId]  INT             DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Products_ProductMakers_ProductMakerId] FOREIGN KEY ([ProductMakerId]) REFERENCES [dbo].[ProductMakers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Products_ProductTypes_ProductTypeId] FOREIGN KEY ([ProductTypeId]) REFERENCES [dbo].[ProductTypes] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Products_ProductTypeId]
    ON [dbo].[Products]([ProductTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Products_ProductMakerId]
    ON [dbo].[Products]([ProductMakerId] ASC);

