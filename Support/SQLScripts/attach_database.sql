USE [master]
GO
CREATE DATABASE [Microgestion] ON 
( FILENAME = N'C:\Archivos de programa\SysQ\MicroGestion\Data\Microgestion.mdf' ),
( FILENAME = N'C:\Archivos de programa\SysQ\MicroGestion\Data\Microgestion_log.LDF' )
 FOR ATTACH
GO
