CREATE TABLE [dbo].[Price]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Price__ID__145C0A3F] DEFAULT (newid()),
[ItemID] [uniqueidentifier] NOT NULL,
[Date] [datetime] NOT NULL,
[Value] [float] NOT NULL
)
GO
ALTER TABLE [dbo].[Price] ADD CONSTRAINT [PK_Price] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[Price] ADD CONSTRAINT [Item_Price] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Item] ([ID])
GO
