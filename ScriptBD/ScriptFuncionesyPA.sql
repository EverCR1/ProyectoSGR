
use bdSGR;

--Funci贸n para el Login
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


<<<<<<< HEAD

--Procedimiento para la Creaci髇 de Reportes
=======
--Procedimiento para la Creaci贸n de Reportes
>>>>>>> 1a711b3ec87296464c9c16e909abb73207133b3a
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
        -- Si se produce un error, revierte la transacci贸n
        ROLLBACK;
        
		INSERT INTO RegistroErrores (ErrorTime, ErrorMessage)
		VALUES (GETDATE(), ERROR_MESSAGE());

    END CATCH;
END;

--Ejemplo Crear Reporte
<<<<<<< HEAD
-- Declaraci髇 de una tabla de tipo tabla para la entrada de IngresosViaje
=======
-- Declaraci贸n de una tabla de tipo tabla para la entrada de IngresosViaje
>>>>>>> 1a711b3ec87296464c9c16e909abb73207133b3a
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

<<<<<<< HEAD

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
        -- Si se produce un error, revierte la transacci髇
        ROLLBACK;
        
		INSERT INTO ErrorLog (ErrorTime, ErrorMessage)
		VALUES (GETDATE(), ERROR_MESSAGE());

    END CATCH;
END;






--Procedimiento para la creaci髇 de usuarios

CREATE PROCEDURE pCrearUsuario( @DPI bigint, @nombres varchar(75), @apellidos varchar(75), 
=======
SELECT * FROM tbReporte
ORDER BY Fecha DESC;

--Procedimiento para Actualizar Reportes
CREATE PROCEDURE pEditarReporte(@ide int,@CantViajes int, @Vehiculo int, @Fecha date, @turno tinyint, @pPiloto int,
@pAyudante int, @pCombustible int, @pViaticos int, @pExtras decimal(8,2), @tIngresos decimal(8,2),
@tEgresos decimal(8,2), @Capital decimal(8,2), @Comentario text, @Usuario int,
@Ingresos IngresosViaje readonly)
AS 
Begin
	BEGIN TRANSACTION;

    BEGIN TRY
		Update tbReporte set cantViajes = @CantViajes, idVehiculo = @Vehiculo, fecha = @Fecha,
		turno = @turno, pagoPiloto = @pPiloto, pagoAyudante = @pAyudante, pagoCombustible = @pCombustible,
		pagoViaticos = @pViaticos, pagoExtras = @pExtras, totalIngresos = @tIngresos,
		totalEgresos = @tEgresos, capital = @Capital,comentario = @Comentario, idUsuario = @Usuario
		where idReporte = @ide;

		-- Borra los ingresos anteriores asociados al Reporte
        DELETE FROM tbReportexVuelta WHERE idReporte = @ide;

        -- Inserta los nuevos ingresos
        INSERT INTO tbReportexVuelta (idReporte, idVuelta, Ingreso)
        SELECT @ide, idVuelta, Ingreso
        FROM @Ingresos;

		COMMIT;

	END TRY
    BEGIN CATCH
        -- Si se produce un error, revierte la transacci贸n
        ROLLBACK;

        INSERT INTO RegistroErrores (ErrorTime, ErrorMessage)
        VALUES (GETDATE(), ERROR_MESSAGE());
    END CATCH;
END;

--Ejemplo Editar Reporte
-- Declaraci贸n de una tabla de tipo tabla para la entrada de IngresosViaje
DECLARE @Ingre IngresosViaje
INSERT INTO @Ingre (idVuelta, Ingreso)
VALUES
    (1, 100.00),
    (2, 150.00),
    (3, 120.00);

-- Ejemplo de llamada al procedimiento almacenado pCrearReporte
--DECLARE @NewReporteID INT;

EXEC pEditarReporte
	@ide = 43,
	@CantViajes = 3,
    @Vehiculo = 1,
    @Fecha = '2023-10-15',
    @turno = 1,
    @pPiloto = 101,
    @pAyudante = 102,
    @pCombustible = 50.00,
    @pViaticos = 30.00,
    @pExtras = 25.00,
    @tIngresos = 400.00,
    @tEgresos = 100.00,
    @Capital = 300.00,
    @Comentario = 'Reporte de edicion',
    @Usuario = 1,
    @Ingresos = @Ingre;

select * from tbReporte



--Procedimiento para Eliminar un Reporte
CREATE PROCEDURE pEliminarReporte
    @ReporteID INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Elimina el reporte seg煤n el ID proporcionado
        DELETE FROM tbReporte WHERE idReporte = @ReporteID;

        COMMIT;
    END TRY
    BEGIN CATCH
        -- Si se produce un error, revierte la transacci贸n
        ROLLBACK;

        INSERT INTO RegistroErrores (ErrorTime, ErrorMessage)
        VALUES (GETDATE(), ERROR_MESSAGE());
    END CATCH;
END;

select * from tbReporte

--Procedimiento para Buscar Reportes de acuerdo a la fecha
CREATE PROCEDURE pBuscarReporte
    @FechaBuscada DATE
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Seleccione los reportes que coinciden con la fecha especificada
        SELECT *
        FROM tbReporte
        WHERE Fecha = @FechaBuscada;

        COMMIT;
    END TRY
    BEGIN CATCH
        -- Si se produce un error, revierte la transacci贸n
        ROLLBACK;
        
        -- Registra el error
        INSERT INTO RegistroErrores (ErrorTime, ErrorMessage)
        VALUES (GETDATE(), ERROR_MESSAGE());
    END CATCH;
END;

exec pBuscarReporte '2023-10-17'
select * from tbReporte

--Procedimiento para Mostrar Reportes
CREATE PROCEDURE pListarReporte
AS
BEGIN
    BEGIN TRY
        -- Inicia una transacci贸n
        BEGIN TRANSACTION;

        --Consulta SELECT con JOIN para obtener datos de ambas tablas
        SELECT 
            R.idReporte, R.idVehiculo, V.nombre, R.fecha, R.cantViajes, R.turno, 
            R.PagoPiloto, R.PagoAyudante, R.PagoCombustible, R.PagoViaticos, R.PagoExtras, 
            R.TotalIngresos, R.TotalEgresos, R.Capital, R.Comentario, R.idUsuario
        FROM tbReporte R inner join tbVehiculo V on R.idVehiculo = V.idVehiculo
        ORDER BY fecha DESC;

        -- Si todo va bien, confirma la transacci贸n
        COMMIT;
    END TRY
    BEGIN CATCH
        -- Si se produce un error, revierte la transacci贸n
        ROLLBACK;

        INSERT INTO RegistroErrores (ErrorTime, ErrorMessage)
        VALUES (GETDATE(), ERROR_MESSAGE());
        
    END CATCH;
END;

exec pListarReporte

SELECT 
    R.idReporte, R.fecha, R.cantViajes, R.turno, 
    R.PagoPiloto, R.PagoAyudante, R.PagoCombustible, R.PagoViaticos, R.PagoExtras, 
    R.TotalIngresos, R.TotalEgresos, R.Capital, R.Comentario, R.idUsuario,
    V.idVuelta, V.Ingreso
FROM tbReporte R
LEFT JOIN tbReportexVuelta V ON R.idReporte = V.idReporte
ORDER BY R.Fecha DESC; -- Ordena po


CREATE PROCEDURE pCrearUsuario(@DPI bigint, @nombres varchar(75), @apellidos varchar(75), 
>>>>>>> 1a711b3ec87296464c9c16e909abb73207133b3a
@username varchar(50),@pass varchar(max),@fechaNac date, @idCargo int)
AS BEGIN
    INSERT INTO tbUsuario (DPI,nombres,apellidos,username,pass,fechaNac,idCargo)
    VALUES (@DPI,@nombres,@apellidos,@username, ENCRYPTBYPASSPHRASE('sgr', @pass), @fechaNac,@idCargo)
END

<<<<<<< HEAD

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
=======
exec pCrearUsuario 1234567891234,'Prueba','Pasas','pruebas','sd1','2020-10-12',1

select * from tbUsuario

--Mostrar Resumen de Reportes
CREATE PROCEDURE pResumenReporte
AS
BEGIN
    BEGIN TRY
        -- Inicia una transacci贸n
        BEGIN TRANSACTION;

        --Consulta SELECT con JOIN para obtener datos 
        SELECT 
            idReporte, fecha, turno, PagoPiloto, PagoAyudante, 
			PagoCombustible, TotalIngresos, TotalEgresos, Capital
        FROM tbReporte
        ORDER BY fecha DESC;

        -- Si todo va bien, confirma la transacci贸n
        COMMIT;
    END TRY
    BEGIN CATCH
        -- Si se produce un error, revierte la transacci贸n
        ROLLBACK;

        INSERT INTO RegistroErrores (ErrorTime, ErrorMessage)
        VALUES (GETDATE(), ERROR_MESSAGE());
        
    END CATCH;
END;

select * from tbReporte


--Procedimiento para Obtener los Ingresos de un Reporte
CREATE PROCEDURE pListarIngresos(@ideRep int)
AS
BEGIN
    BEGIN TRY
        -- Inicia una transacci贸n
        BEGIN TRANSACTION;

        --Consulta SELECT con JOIN para obtener datos de ambas tablas
        SELECT 
            V.nombre as Viaje , R.Ingreso as Ingreso
        FROM tbReportexVuelta as R inner join tbVuelta as V on R.idVuelta = V.idVuelta
		where idReporte = @ideRep;

        -- Si todo va bien, confirma la transacci贸n
        COMMIT;
    END TRY
    BEGIN CATCH
        -- Si se produce un error, revierte la transacci贸n
        ROLLBACK;

        INSERT INTO RegistroErrores (ErrorTime, ErrorMessage)
        VALUES (GETDATE(), ERROR_MESSAGE());
        
    END CATCH;
END;

exec pListarIngresos 1

select * from tbReporte
select * from tbReportexVuelta

--Procedimiento para Listar los nombres de los Vehiculos
CREATE PROC ListarVehiculos
AS BEGIN
	select idVehiculo as IdVehiculo, nombre as Nombre 
	from tbVehiculo order by nombre asc
END

exec ListarVehiculos

>>>>>>> 1a711b3ec87296464c9c16e909abb73207133b3a
