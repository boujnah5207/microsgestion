CREATE TABLE [dbo].[Item]
(
[ID] [uniqueidentifier] NOT NULL,
[InternalCode] [nvarchar] (50) COLLATE Traditional_Spanish_CI_AS NULL,
[ExternalCode] [nvarchar] (50) COLLATE Traditional_Spanish_CI_AS NULL,
[Name] [nvarchar] (50) COLLATE Traditional_Spanish_CI_AS NULL,
[BaseMeasurementID] [uniqueidentifier] NOT NULL,
[DefaultSalesAmount] [float] NOT NULL,
[MovesStock] [bit] NOT NULL,
[ActualStock] [float] NOT NULL,
[MinimumStock] [float] NOT NULL
)
GO
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [Measurement_Item] FOREIGN KEY ([BaseMeasurementID]) REFERENCES [dbo].[Measurement] ([ID])
GO
