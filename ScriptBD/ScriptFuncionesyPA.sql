
use bdSGR;

--Función para el Login
create function Flogin(@Usuario varchar(50), @Pass varchar(50))
returns int
as begin
	Declare @idUsuario as int
	set @idUsuario = (select idUsuario from tbUsuario
					where username = @Usuario and
					DECRYPTBYPASSPHRASE('sgr', Pass) = @Pass)
	return @idUsuario
end

select dbo.FLogin('ever8','passever');

--- Procedimiento para el Registro (Ejemplo)
CREATE PROCEDURE FRegistro(@Usuario varchar(100), @Pass varchar(max), @idPer int)
AS BEGIN
    INSERT INTO tbUsuario (Usuario, Pass, idPersona)
    VALUES (@Usuario, ENCRYPTBYPASSPHRASE('sgr', @Pass), @idPer)
END



--Procedimiento para la Creación de Reportes
CREATE PROCEDURE pCrearReporte (@CantViajes int, @Vehiculo int, @Fecha date, @turno tinyint, @pPiloto int,
@pAyudante int, @pCombustible int, @pViaticos int, @pExtras decimal(8,2), @tIngresos decimal(8,2),
@tEgresos decimal(8,2), @Capital decimal(8,2), @Comentario text, @Usuario int,
@Ingresos IngresosViaje readonly)
AS BEGIN

	DECLARE @NuevoReporteID INT;
	BEGIN TRANSACTION;

    BEGIN TRY
		INSERT INTO tbReporte values (@CantViajes, @Vehiculo, @Fecha, @turno, 
		@pPiloto, @pAyudante, @pCombustible, @pViaticos, @pExtras, @tIngresos,
		@tEgresos, @Capital, @Comentario, @Usuario);
		
		SET @NuevoReporteID = SCOPE_IDENTITY();

		INSERT INTO tbReportexVuelta (idReporte,idVuelta,Ingreso)
        SELECT @NuevoReporteID, idVuelta, Ingreso
        FROM @Ingresos;

	COMMIT;

	END TRY
    BEGIN CATCH
        -- Si se produce un error, revierte la transacción
        ROLLBACK;
        
		INSERT INTO ErrorLog (ErrorTime, ErrorMessage)
		VALUES (GETDATE(), ERROR_MESSAGE());

    END CATCH;
END;

--Ejemplo Crear Reporte
-- Declaración de una tabla de tipo tabla para la entrada de IngresosViaje
DECLARE @Ingre IngresosViaje
INSERT INTO @Ingre (idVuelta, Ingreso)
VALUES
    (1, 100.00),
    (2, 150.00),
    (3, 120.00);

-- Ejemplo de llamada al procedimiento almacenado pCrearReporte
--DECLARE @NewReporteID INT;

EXEC pCrearReporte
	@CantViajes = 3,
    @Vehiculo = 1,
    @Fecha = '2023-10-20',
    @turno = 1,
    @pPiloto = 101,
    @pAyudante = 102,
    @pCombustible = 50.00,
    @pViaticos = 30.00,
    @pExtras = 25.00,
    @tIngresos = 400.00,
    @tEgresos = 100.00,
    @Capital = 300.00,
    @Comentario = 'Reporte de ejemplo',
    @Usuario = 1,
    @Ingresos = @Ingre;

select * from tbReporte;
select * from tbReportexVuelta;

delete from tbReporte where idReporte = 3;


CREATE PROCEDURE pCrearReporte (@CantViajes int, @Vehiculo int, @Fecha date, @turno tinyint, @pPiloto int,
@pAyudante int, @pCombustible int, @pViaticos int, @pExtras decimal(8,2), @tIngresos decimal(8,2),
@tEgresos decimal(8,2), @Capital decimal(8,2), @Comentario text, @Usuario int,
@Ingresos IngresosViaje readonly)
AS BEGIN

	DECLARE @NuevoReporteID INT;
	BEGIN TRANSACTION;

    BEGIN TRY
		INSERT INTO tbReporte values (@CantViajes, @Vehiculo, @Fecha, @turno, 
		@pPiloto, @pAyudante, @pCombustible, @pViaticos, @pExtras, @tIngresos,
		@tEgresos, @Capital, @Comentario, @Usuario);
		
		SET @NuevoReporteID = SCOPE_IDENTITY();

		INSERT INTO tbReportexVuelta (idReporte,idVuelta,Ingreso)
        SELECT @NuevoReporteID, idVuelta, Ingreso
        FROM @Ingresos;

	COMMIT;

	END TRY
    BEGIN CATCH
        -- Si se produce un error, revierte la transacción
        ROLLBACK;
        
		INSERT INTO ErrorLog (ErrorTime, ErrorMessage)
		VALUES (GETDATE(), ERROR_MESSAGE());

    END CATCH;
END;






--Procedimiento para la creación de usuarios

CREATE PROCEDURE pCrearUsuario( @DPI bigint, @nombres varchar(75), @apellidos varchar(75), 
@username varchar(50),@pass varchar(max),@fechaNac date, @idCargo int)
AS BEGIN
    INSERT INTO tbUsuario (DPI,nombres,apellidos,username,pass,fechaNac,idCargo)
    VALUES (@DPI,@nombres,@apellidos,@username, ENCRYPTBYPASSPHRASE('sgr', @pass), @fechaNac,@idCargo)
END


CREATE PROCEDURE pUsuarioLicencia
    @DPI BIGINT,
    @nombres VARCHAR(75),
    @apellidos VARCHAR(75),
    @username VARCHAR(50),
    @pass VARCHAR(MAX),
    @fechaNac DATE,
    @idCargo INT,
    @tipoLicencia VARCHAR(5)
AS
BEGIN
    -- Declarar una variable para almacenar el ID generado
    DECLARE @NuevoID INT;

    -- Insertar en la tabla de usuarios
    INSERT INTO dbo.tbUsuario (DPI, nombres, apellidos, username, pass, fechaNac, idCargo)
    VALUES (@DPI, @nombres, @apellidos, @username, ENCRYPTBYPASSPHRASE('sgr', @pass), @fechaNac, @idCargo);

    -- Obtener el ID generado
    SET @NuevoID = SCOPE_IDENTITY();

    -- Insertar en la tabla de licencias
    INSERT INTO dbo.tbPiloto (idUsuario, tipoLicencia)
    VALUES (@NuevoID, @tipoLicencia);
END;
