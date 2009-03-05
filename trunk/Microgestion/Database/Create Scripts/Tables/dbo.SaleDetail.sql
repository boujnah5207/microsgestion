CREATE TABLE [dbo].[SaleDetail]
(
[ID] [uniqueidentifier] NOT NULL,
[SaleID] [uniqueidentifier] NOT NULL,
[ItemID] [uniqueidentifier] NOT NULL,
[Amount] [float] NOT NULL,
[PriceID] [uniqueidentifier] NOT NULL,
[Subtotal] [float] NOT NULL
)
GO
ALTER TABLE [dbo].[SaleDetail] ADD CONSTRAINT [PK_SaleDetail] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[SaleDetail] ADD CONSTRAINT [Item_SaleDetail] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Item] ([ID])
GO
ALTER TABLE [dbo].[SaleDetail] ADD CONSTRAINT [Price_SaleDetail] FOREIGN KEY ([PriceID]) REFERENCES [dbo].[Price] ([ID])
GO
ALTER TABLE [dbo].[SaleDetail] ADD CONSTRAINT [Sale_SaleDetail] FOREIGN KEY ([SaleID]) REFERENCES [dbo].[Sale] ([ID])
GO
