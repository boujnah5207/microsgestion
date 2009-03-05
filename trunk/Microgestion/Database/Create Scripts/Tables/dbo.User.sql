CREATE TABLE [dbo].[User]
(
[ID] [uniqueidentifier] NOT NULL,
[Username] [nvarchar] (50) COLLATE Traditional_Spanish_CI_AS NULL,
[Password] [nvarchar] (50) COLLATE Traditional_Spanish_CI_AS NULL,
[Name] [nvarchar] (50) COLLATE Traditional_Spanish_CI_AS NULL,
[LastName] [nvarchar] (50) COLLATE Traditional_Spanish_CI_AS NULL,
[Timestamp] [timestamp] NOT NULL
)
GO
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED  ([ID])
GO
