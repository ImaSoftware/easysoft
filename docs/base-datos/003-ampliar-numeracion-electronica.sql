-- Generado por tools/Build-ErpDictionary.ps1. Ejecutar con sqlcmd -b.
-- Proyecciones sin conversiones, filtros, joins ni cambios en datos heredados.
-- Primera instalacion solamente. Un conflicto revierte toda la transaccion.
SET NOCOUNT ON;
SET XACT_ABORT ON;
IF DB_NAME() <> N'EasySoft_Patricks_Dev'
    THROW 51000, 'Este script solo admite la copia EasySoft_Patricks_Dev.', 1;
BEGIN TRY
BEGIN TRANSACTION;
IF SCHEMA_ID(N'erp_lectura') IS NULL EXEC(N'CREATE SCHEMA [erp_lectura] AUTHORIZATION [dbo]');
EXEC(N'CREATE VIEW [erp_lectura].[notas_credito_electronicas_numeracion] AS SELECT
    [estab] AS [codigo_establecimiento],
    [ptoemi] AS [codigo_punto_emision],
    [secuencia] AS [numero_secuencial]
FROM [dbo].[APCabCre];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'notas_credito_electronicas_numeracion';
EXEC(N'CREATE VIEW [erp_lectura].[notas_debito_electronicas_numeracion] AS SELECT
    [estab] AS [codigo_establecimiento],
    [ptoemi] AS [codigo_punto_emision],
    [secuencia] AS [numero_secuencial]
FROM [dbo].[APCabDeb];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'notas_debito_electronicas_numeracion';
EXEC(N'CREATE VIEW [erp_lectura].[facturas_electronicas_numeracion] AS SELECT
    [estab] AS [codigo_establecimiento],
    [ptoemi] AS [codigo_punto_emision],
    [secuencia] AS [numero_secuencial]
FROM [dbo].[APCabFac];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'facturas_electronicas_numeracion';
EXEC(N'CREATE VIEW [erp_lectura].[guias_electronicas_numeracion] AS SELECT
    [estab] AS [codigo_establecimiento],
    [ptoemi] AS [codigo_punto_emision],
    [secuencia] AS [numero_secuencial]
FROM [dbo].[APCabGui];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'guias_electronicas_numeracion';
EXEC(N'CREATE VIEW [erp_lectura].[retenciones_electronicas_numeracion] AS SELECT
    [estab] AS [codigo_establecimiento],
    [ptoemi] AS [codigo_punto_emision],
    [secuencia] AS [numero_secuencial]
FROM [dbo].[apCabRet];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'retenciones_electronicas_numeracion';
EXEC(N'CREATE VIEW [erp_lectura].[puntos_emision_electronica] AS SELECT
    [ptoestab] AS [codigo_establecimiento],
    [ptoemi] AS [codigo_punto_emision],
    [conseFactu] AS [consecutivo_factura],
    [conseGuia] AS [consecutivo_guia],
    [conseCredi] AS [consecutivo_nota_credito],
    [conseDebit] AS [consecutivo_nota_debito],
    [conseRete] AS [consecutivo_retencion]
FROM [dbo].[apPtoEmi];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'puntos_emision_electronica';
COMMIT TRANSACTION;
END TRY
BEGIN CATCH
IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
THROW;
END CATCH;
