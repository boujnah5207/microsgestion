CREATE TABLE [dbo].[MeasurementConversion]
(
[ID] [uniqueidentifier] NOT NULL,
[BaseID] [uniqueidentifier] NOT NULL,
[ConvertedID] [uniqueidentifier] NOT NULL,
[BaseValue] [float] NOT NULL,
[ConvertedValue] [float] NOT NULL
)
GO
ALTER TABLE [dbo].[MeasurementConversion] ADD CONSTRAINT [PK_MeasurementConversion] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[MeasurementConversion] ADD CONSTRAINT [Measurement_MeasurementConversion] FOREIGN KEY ([BaseID]) REFERENCES [dbo].[Measurement] ([ID])
GO
ALTER TABLE [dbo].[MeasurementConversion] ADD CONSTRAINT [Measurement_MeasurementConversion1] FOREIGN KEY ([ConvertedID]) REFERENCES [dbo].[Measurement] ([ID])
GO
