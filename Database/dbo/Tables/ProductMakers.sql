CREATE TABLE [dbo].[ProductMakers] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ProductMakers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

