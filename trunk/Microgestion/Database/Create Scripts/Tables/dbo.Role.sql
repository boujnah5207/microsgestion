CREATE TABLE [dbo].[Role]
(
[ID] [uniqueidentifier] NOT NULL,
[Name] [nvarchar] (50) COLLATE Latin1_General_CI_AI NULL,
[Timestamp] [timestamp] NOT NULL
)

GO
ALTER TABLE [dbo].[Role] ADD CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED  ([ID])
GO
