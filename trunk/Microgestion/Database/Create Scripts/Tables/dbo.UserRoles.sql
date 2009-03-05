CREATE TABLE [dbo].[UserRoles]
(
[UserID] [uniqueidentifier] NOT NULL,
[RoleID] [uniqueidentifier] NOT NULL,
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF__UserRoles__ID__0425A276] DEFAULT (newid()),
[Timestamp] [timestamp] NOT NULL
)

GO
ALTER TABLE [dbo].[UserRoles] ADD CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[UserRoles] ADD CONSTRAINT [Role_UserRoles] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[UserRoles] ADD CONSTRAINT [User_UserRoles] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([ID])
GO
