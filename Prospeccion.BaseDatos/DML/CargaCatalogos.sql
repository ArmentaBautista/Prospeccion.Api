/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

USE prospeccion
go
-- Inserción inicial

IF NOT EXISTS(select 1 from tActividades where Actividad='LLAMADA TELEFÓNICA')
	INSERT INTO Prospeccion.dbo.tActividades (Actividad) VALUES('LLAMADA TELEFÓNICA')
GO
IF NOT EXISTS(select 1 from tActividades where Actividad='VISITA DOMICILIO')
	INSERT INTO Prospeccion.dbo.tActividades (Actividad) VALUES('VISITA DOMICILIO')
GO
IF NOT EXISTS(select 1 from tActividades where Actividad='SMS')
	INSERT INTO Prospeccion.dbo.tActividades (Actividad) VALUES('SMS')
GO

IF NOT EXISTS(select 1 from tResultados where Resultado='NO CONTESTA')
	INSERT INTO Prospeccion.dbo.tResultados (Resultado) VALUES('NO CONTESTA')
GO

IF NOT EXISTS(select 1 from tResultados where Resultado='NO LOCALIZADO')
	INSERT INTO Prospeccion.dbo.tResultados (Resultado) VALUES('NO LOCALIZADO')
GO

IF NOT EXISTS(select 1 from tResultados where Resultado='RECHAZO OFERTA')
	INSERT INTO Prospeccion.dbo.tResultados (Resultado) VALUES('RECHAZO OFERTA')
GO

IF NOT EXISTS(select 1 from tResultados where Resultado='ACEPTO OFERTA')
	INSERT INTO Prospeccion.dbo.tResultados (Resultado) VALUES('ACEPTO OFERTA')
GO

IF NOT EXISTS(select 1 from tResultados where Resultado='SOLICITA MÁS INFO')
	INSERT INTO Prospeccion.dbo.tResultados (Resultado) VALUES('SOLICITA MÁS INFO')
GO

IF NOT EXISTS(select 1 from tResultados where Resultado='NÚMERO EQUIVOCADO')
	INSERT INTO Prospeccion.dbo.tResultados (Resultado) VALUES('NÚMERO EQUIVOCADO')
GO

IF NOT EXISTS(select 1 from tResultados where Resultado='DOMICILIO ERRONEO')
	INSERT INTO Prospeccion.dbo.tResultados (Resultado) VALUES('DOMICILIO ERRONEO')
GO

