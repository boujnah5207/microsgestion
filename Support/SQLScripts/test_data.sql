USE Microgestion

DELETE FROM [Microgestion].[dbo].[StockMovementDetail]
DELETE FROM [Microgestion].[dbo].[StockMovement]
DELETE FROM [Microgestion].[dbo].[SaleDetail]
DELETE FROM [Microgestion].[dbo].[Sale]
DELETE FROM [Microgestion].[dbo].[Price]
DELETE FROM [Microgestion].[dbo].[Item]
DELETE FROM [Microgestion].[dbo].[ItemType]
DELETE FROM [Microgestion].[dbo].[Measurement]
DELETE FROM [Microgestion].[dbo].[UserRoles]
DELETE FROM [Microgestion].[dbo].[RoleAction]
DELETE FROM [Microgestion].[dbo].[User]
DELETE FROM [Microgestion].[dbo].[Role]

DECLARE @unId uniqueidentifier
DECLARE @cigId uniqueidentifier
DECLARE @mb10 uniqueidentifier
DECLARE @mb20 uniqueidentifier
DECLARE @mc20 uniqueidentifier

SET @unId = newid();
SET @cigId = newid();
SET @mb10 = newid();
SET @mb20 = newid();
SET @mc20 = newid();

-- Unidades de Medida
INSERT INTO [Microgestion].[dbo].[Measurement] ([ID],[Name],[Abbreviation]) VALUES (@unId,'Unidad/es','Un.')
-- Rubros
INSERT INTO [Microgestion].[dbo].[ItemType] ([ID],[Name]) VALUES (@cigId,'Cigarrillos')
-- Art�culos
INSERT INTO [Microgestion].[dbo].[Item]([ID],[InternalCode],[ExternalCode],[Name],[BaseMeasurementID],[MovesStock],[MinimumStock],[ItemTypeID])
     VALUES (@mb10,'321','321','Marlboro Box 10',@unId,1,50,@cigId)
INSERT INTO [Microgestion].[dbo].[Item]([ID],[InternalCode],[ExternalCode],[Name],[BaseMeasurementID],[MovesStock],[MinimumStock],[ItemTypeID])
     VALUES (@mb20,'654','654','Marlboro Box 20',@unId,1,50,@cigId)
INSERT INTO [Microgestion].[dbo].[Item]([ID],[InternalCode],[ExternalCode],[Name],[BaseMeasurementID],[MovesStock],[MinimumStock],[ItemTypeID])
     VALUES (@mc20,'987','987','Marlboro Comun 20',@unId,1,50,@cigId)
-- Precios
INSERT INTO [Microgestion].[dbo].[Price]([ID],[ItemID],[Date],[Value])
     VALUES(NEWID(),@mb10, getdate(),2.5)
INSERT INTO [Microgestion].[dbo].[Price]([ID],[ItemID],[Date],[Value])
     VALUES(NEWID(),@mb20,getdate(),5.0)
INSERT INTO [Microgestion].[dbo].[Price]([ID],[ItemID],[Date],[Value])
     VALUES(NEWID(),@mc20,getdate(),4.5)
-- Usuarios
INSERT INTO [Microgestion].[dbo].[User]([ID],[Username],[Password],[Name],[LastName])
     VALUES('{00000000-0000-0000-0000-000000000001}','admin','009b927906b97d1507451f45d795d55e','Administrador',NULL)
GO
