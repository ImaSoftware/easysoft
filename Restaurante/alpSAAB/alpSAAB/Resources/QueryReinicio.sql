-- DESTRUCTIVO: no ejecutar como parte de instalación o actualización.
-- Cambiar esta bandera solo al preparar deliberadamente una base vacía de pruebas.
DECLARE @ConfirmarBorrado bit = 0;
IF @ConfirmarBorrado <> 1
BEGIN
    RAISERROR('Borrado deshabilitado. Revise el script y confirme explícitamente.', 16, 1);
    RETURN;
END;
SET XACT_ABORT ON;
BEGIN TRANSACTION;
--Consulta para encerar la base en terminos operativos
--Se eliminaran :
--   -	los consumos ingresados
--   -	las cuentas generadas
--	 -	las comandas
--   -	las prefacturas

truncate table SD_Comanda_Cabecera
truncate table SD_Comandas_Detalle
truncate table SD_Cuentas_Mesas
truncate table SD_CuentasCabecera
truncate table SD_CuentasDetalle
truncate table SD_Prefactura_Detalle
truncate table SD_PreFactura_Movimientos
truncate table SD_Prefacturas_Cabecera


SELECT    SD_Mesas.Id, SD_Mesas.Alias AS 'Nombre de Mesa', SD_CuentasCabecera.estado
FROM       SD_Mesas LEFT OUTER JOIN
                 SD_Cuentas_Mesas ON SD_Mesas.Id = SD_Cuentas_Mesas.IdMesa LEFT OUTER JOIN
                 SD_CuentasCabecera ON SD_Cuentas_Mesas.IdCuenta = SD_CuentasCabecera.id
WHERE    (SD_CuentasCabecera.estado IS NULL OR
                 SD_CuentasCabecera.estado <> 'A') AND (SD_Mesas.EsMesa = 1)
ORDER BY SD_Mesas.NumAlias
COMMIT TRANSACTION;

