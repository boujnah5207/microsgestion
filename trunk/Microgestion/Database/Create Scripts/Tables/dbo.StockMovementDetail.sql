CREATE TABLE [dbo].[StockMovementDetail]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF__StockMovemen__ID__15502E78] DEFAULT (newid()),
[ItemID] [uniqueidentifier] NOT NULL,
[Amount] [float] NOT NULL,
[StockMovementID] [uniqueidentifier] NOT NULL,
[SaleDetailID] [uniqueidentifier] NULL
)

GO
ALTER TABLE [dbo].[StockMovementDetail] ADD CONSTRAINT [PK_StockMovementDetail] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[StockMovementDetail] ADD CONSTRAINT [Item_StockMovementDetail] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Item] ([ID])
GO
ALTER TABLE [dbo].[StockMovementDetail] ADD CONSTRAINT [SaleDetail_StockMovementDetail] FOREIGN KEY ([SaleDetailID]) REFERENCES [dbo].[SaleDetail] ([ID])
GO
ALTER TABLE [dbo].[StockMovementDetail] ADD CONSTRAINT [StockMovement_StockMovementDetail] FOREIGN KEY ([StockMovementID]) REFERENCES [dbo].[StockMovement] ([ID])
GO
