
USE [Microgestion]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 04/09/2009 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measurement]    Script Date: 04/09/2009 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measurement](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Abbreviation] [nvarchar](10) NULL,
 CONSTRAINT [PK_Measurement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemType]    Script Date: 04/09/2009 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemType](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_ItemType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 04/09/2009 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 04/09/2009 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserID] [uniqueidentifier] NOT NULL,
	[RoleID] [uniqueidentifier] NOT NULL,
	[ID] [uniqueidentifier] NOT NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasurementConversion]    Script Date: 04/09/2009 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasurementConversion](
	[ID] [uniqueidentifier] NOT NULL,
	[BaseID] [uniqueidentifier] NOT NULL,
	[ConvertedID] [uniqueidentifier] NOT NULL,
	[BaseValue] [float] NOT NULL,
	[ConvertedValue] [float] NOT NULL,
 CONSTRAINT [PK_MeasurementConversion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 04/09/2009 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[ID] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[Total] [float] NOT NULL,
	[InternalID] [int] NOT NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleAction]    Script Date: 04/09/2009 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAction](
	[RoleID] [uniqueidentifier] NOT NULL,
	[ActionID] [int] NOT NULL,
	[ID] [uniqueidentifier] NOT NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_RoleAction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 04/09/2009 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ID] [uniqueidentifier] NOT NULL,
	[InternalCode] [nvarchar](50) NULL,
	[ExternalCode] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[BaseMeasurementID] [uniqueidentifier] NOT NULL,
	[MovesStock] [bit] NOT NULL,
	[MinimumStock] [float] NOT NULL,
	[ItemTypeID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockMovement]    Script Date: 04/09/2009 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockMovement](
	[ID] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[Comment] [nvarchar](1000) NULL,
 CONSTRAINT [PK_StockMovement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Price]    Script Date: 04/09/2009 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Price](
	[ID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Value] [float] NOT NULL,
 CONSTRAINT [PK_Price] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleDetail]    Script Date: 04/09/2009 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleDetail](
	[ID] [uniqueidentifier] NOT NULL,
	[SaleID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[Amount] [float] NOT NULL,
	[PriceID] [uniqueidentifier] NOT NULL,
	[Subtotal] [float] NOT NULL,
 CONSTRAINT [PK_SaleDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockMovementDetail]    Script Date: 04/09/2009 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockMovementDetail](
	[ID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[Amount] [float] NOT NULL,
	[StockMovementID] [uniqueidentifier] NOT NULL,
	[SaleDetailID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_StockMovementDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF__ItemType__ID__1B0907CE]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[ItemType] ADD  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF__Price__ID__15502E78]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[Price] ADD  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF__RoleAction__ID__03317E3D]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[RoleAction] ADD  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF__SaleDetail__ID__1273C1CD]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[SaleDetail] ADD  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF__StockMovemen__ID__182C9B23]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[StockMovementDetail] ADD  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF__UserRoles__ID__060DEAE8]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[UserRoles] ADD  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  ForeignKey [ItemType_Item]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [ItemType_Item] FOREIGN KEY([ItemTypeID])
REFERENCES [dbo].[ItemType] ([ID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [ItemType_Item]
GO
/****** Object:  ForeignKey [Measurement_Item]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [Measurement_Item] FOREIGN KEY([BaseMeasurementID])
REFERENCES [dbo].[Measurement] ([ID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [Measurement_Item]
GO
/****** Object:  ForeignKey [Measurement_MeasurementConversion]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[MeasurementConversion]  WITH CHECK ADD  CONSTRAINT [Measurement_MeasurementConversion] FOREIGN KEY([BaseID])
REFERENCES [dbo].[Measurement] ([ID])
GO
ALTER TABLE [dbo].[MeasurementConversion] CHECK CONSTRAINT [Measurement_MeasurementConversion]
GO
/****** Object:  ForeignKey [Measurement_MeasurementConversion1]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[MeasurementConversion]  WITH CHECK ADD  CONSTRAINT [Measurement_MeasurementConversion1] FOREIGN KEY([ConvertedID])
REFERENCES [dbo].[Measurement] ([ID])
GO
ALTER TABLE [dbo].[MeasurementConversion] CHECK CONSTRAINT [Measurement_MeasurementConversion1]
GO
/****** Object:  ForeignKey [Item_Price]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[Price]  WITH CHECK ADD  CONSTRAINT [Item_Price] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ID])
GO
ALTER TABLE [dbo].[Price] CHECK CONSTRAINT [Item_Price]
GO
/****** Object:  ForeignKey [Role_RoleAction]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[RoleAction]  WITH CHECK ADD  CONSTRAINT [Role_RoleAction] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[RoleAction] CHECK CONSTRAINT [Role_RoleAction]
GO
/****** Object:  ForeignKey [User_Sale]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [User_Sale] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [User_Sale]
GO
/****** Object:  ForeignKey [Item_SaleDetail]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[SaleDetail]  WITH CHECK ADD  CONSTRAINT [Item_SaleDetail] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ID])
GO
ALTER TABLE [dbo].[SaleDetail] CHECK CONSTRAINT [Item_SaleDetail]
GO
/****** Object:  ForeignKey [Price_SaleDetail]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[SaleDetail]  WITH CHECK ADD  CONSTRAINT [Price_SaleDetail] FOREIGN KEY([PriceID])
REFERENCES [dbo].[Price] ([ID])
GO
ALTER TABLE [dbo].[SaleDetail] CHECK CONSTRAINT [Price_SaleDetail]
GO
/****** Object:  ForeignKey [Sale_SaleDetail]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[SaleDetail]  WITH CHECK ADD  CONSTRAINT [Sale_SaleDetail] FOREIGN KEY([SaleID])
REFERENCES [dbo].[Sale] ([ID])
GO
ALTER TABLE [dbo].[SaleDetail] CHECK CONSTRAINT [Sale_SaleDetail]
GO
/****** Object:  ForeignKey [User_StockMovement]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[StockMovement]  WITH CHECK ADD  CONSTRAINT [User_StockMovement] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[StockMovement] CHECK CONSTRAINT [User_StockMovement]
GO
/****** Object:  ForeignKey [Item_StockMovementDetail]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[StockMovementDetail]  WITH CHECK ADD  CONSTRAINT [Item_StockMovementDetail] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ID])
GO
ALTER TABLE [dbo].[StockMovementDetail] CHECK CONSTRAINT [Item_StockMovementDetail]
GO
/****** Object:  ForeignKey [SaleDetail_StockMovementDetail]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[StockMovementDetail]  WITH CHECK ADD  CONSTRAINT [SaleDetail_StockMovementDetail] FOREIGN KEY([SaleDetailID])
REFERENCES [dbo].[SaleDetail] ([ID])
GO
ALTER TABLE [dbo].[StockMovementDetail] CHECK CONSTRAINT [SaleDetail_StockMovementDetail]
GO
/****** Object:  ForeignKey [StockMovement_StockMovementDetail]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[StockMovementDetail]  WITH CHECK ADD  CONSTRAINT [StockMovement_StockMovementDetail] FOREIGN KEY([StockMovementID])
REFERENCES [dbo].[StockMovement] ([ID])
GO
ALTER TABLE [dbo].[StockMovementDetail] CHECK CONSTRAINT [StockMovement_StockMovementDetail]
GO
/****** Object:  ForeignKey [Role_UserRoles]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [Role_UserRoles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [Role_UserRoles]
GO
/****** Object:  ForeignKey [User_UserRoles]    Script Date: 04/09/2009 11:31:20 ******/
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [User_UserRoles] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [User_UserRoles]
GO
