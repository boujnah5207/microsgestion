CREATE TABLE [dbo].[Role]
(
[ID] [uniqueidentifier] NOT NULL,
[Name] [nvarchar] (50) COLLATE Traditional_Spanish_CI_AS NULL,
[Timestamp] [timestamp] NOT NULL
)
GO
ALTER TABLE [dbo].[Role] ADD CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED  ([ID])
GO
