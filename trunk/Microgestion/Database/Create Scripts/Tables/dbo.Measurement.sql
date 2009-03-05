CREATE TABLE [dbo].[Measurement]
(
[ID] [uniqueidentifier] NOT NULL,
[Name] [nvarchar] (50) COLLATE Traditional_Spanish_CI_AS NULL,
[Abbreviation] [nvarchar] (10) COLLATE Traditional_Spanish_CI_AS NULL
)
GO
ALTER TABLE [dbo].[Measurement] ADD CONSTRAINT [PK_Measurement] PRIMARY KEY CLUSTERED  ([ID])
GO
