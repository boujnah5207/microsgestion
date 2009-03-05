CREATE TABLE [dbo].[RoleAction]
(
[RoleID] [uniqueidentifier] NOT NULL,
[ActionID] [int] NOT NULL,
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF__RoleAction__ID__03317E3D] DEFAULT (newid()),
[Timestamp] [timestamp] NOT NULL
)
GO
ALTER TABLE [dbo].[RoleAction] ADD CONSTRAINT [PK_RoleAction] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[RoleAction] ADD CONSTRAINT [Role_RoleAction] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([ID])
GO
