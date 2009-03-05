CREATE TABLE [dbo].[Sale]
(
[ID] [uniqueidentifier] NOT NULL,
[Date] [datetime] NOT NULL,
[UserID] [uniqueidentifier] NOT NULL,
[Total] [float] NOT NULL,
[InternalID] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[Sale] ADD CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[Sale] ADD CONSTRAINT [User_Sale] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([ID])
GO
