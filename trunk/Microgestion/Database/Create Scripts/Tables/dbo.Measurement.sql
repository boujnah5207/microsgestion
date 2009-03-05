CREATE TABLE [dbo].[Measurement]
(
[ID] [uniqueidentifier] NOT NULL,
[Name] [nvarchar] (50) COLLATE Latin1_General_CI_AI NULL,
[Abbreviation] [nvarchar] (10) COLLATE Latin1_General_CI_AI NULL
)

GO
ALTER TABLE [dbo].[Measurement] ADD CONSTRAINT [PK_Measurement] PRIMARY KEY CLUSTERED  ([ID])
GO
