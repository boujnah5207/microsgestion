CREATE TABLE [dbo].[User]
(
[ID] [uniqueidentifier] NOT NULL,
[Username] [nvarchar] (50) COLLATE Latin1_General_CI_AI NULL,
[Password] [nvarchar] (50) COLLATE Latin1_General_CI_AI NULL,
[Name] [nvarchar] (50) COLLATE Latin1_General_CI_AI NULL,
[LastName] [nvarchar] (50) COLLATE Latin1_General_CI_AI NULL,
[Timestamp] [timestamp] NOT NULL
)

GO
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED  ([ID])
GO
