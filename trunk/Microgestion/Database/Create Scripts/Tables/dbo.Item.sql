CREATE TABLE [dbo].[Item]
(
[ID] [uniqueidentifier] NOT NULL,
[InternalCode] [nvarchar] (50) COLLATE Latin1_General_CI_AI NULL,
[ExternalCode] [nvarchar] (50) COLLATE Latin1_General_CI_AI NULL,
[Name] [nvarchar] (50) COLLATE Latin1_General_CI_AI NULL,
[BaseMeasurementID] [uniqueidentifier] NOT NULL,
[DefaultSalesAmount] [float] NOT NULL,
[MovesStock] [bit] NOT NULL,
[MinimumStock] [float] NOT NULL
)


GO
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [Measurement_Item] FOREIGN KEY ([BaseMeasurementID]) REFERENCES [dbo].[Measurement] ([ID])
GO
