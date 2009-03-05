CREATE TABLE [dbo].[StockMovement]
(
[ID] [uniqueidentifier] NOT NULL,
[Date] [datetime] NOT NULL,
[UserID] [uniqueidentifier] NOT NULL,
[Comment] [nvarchar] (1000) COLLATE Latin1_General_CI_AI NULL
)


GO
ALTER TABLE [dbo].[StockMovement] ADD CONSTRAINT [PK_StockMovement] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[StockMovement] ADD CONSTRAINT [User_StockMovement] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([ID])
GO
