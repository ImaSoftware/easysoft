SET NOCOUNT ON;
SET XACT_ABORT ON;
IF DB_NAME() <> N'EasySoft_Patricks_Dev'
    THROW 51000, 'Este script solo admite la copia EasySoft_Patricks_Dev.', 1;
BEGIN TRY
BEGIN TRANSACTION;
IF OBJECT_ID(N'erp_lectura.notas_credito_electronicas_numeracion', N'V') IS NOT NULL BEGIN IF NOT EXISTS (SELECT 1 FROM sys.extended_properties WHERE class=1 AND major_id=OBJECT_ID(N'erp_lectura.notas_credito_electronicas_numeracion') AND minor_id=0 AND name=N'EasySoftDiccionario' AND CONVERT(nvarchar(10),value)=N'v1') THROW 51001, 'Objeto ajeno al diccionario.', 1; DROP VIEW [erp_lectura].[notas_credito_electronicas_numeracion]; END;
IF OBJECT_ID(N'erp_lectura.notas_debito_electronicas_numeracion', N'V') IS NOT NULL BEGIN IF NOT EXISTS (SELECT 1 FROM sys.extended_properties WHERE class=1 AND major_id=OBJECT_ID(N'erp_lectura.notas_debito_electronicas_numeracion') AND minor_id=0 AND name=N'EasySoftDiccionario' AND CONVERT(nvarchar(10),value)=N'v1') THROW 51001, 'Objeto ajeno al diccionario.', 1; DROP VIEW [erp_lectura].[notas_debito_electronicas_numeracion]; END;
IF OBJECT_ID(N'erp_lectura.facturas_electronicas_numeracion', N'V') IS NOT NULL BEGIN IF NOT EXISTS (SELECT 1 FROM sys.extended_properties WHERE class=1 AND major_id=OBJECT_ID(N'erp_lectura.facturas_electronicas_numeracion') AND minor_id=0 AND name=N'EasySoftDiccionario' AND CONVERT(nvarchar(10),value)=N'v1') THROW 51001, 'Objeto ajeno al diccionario.', 1; DROP VIEW [erp_lectura].[facturas_electronicas_numeracion]; END;
IF OBJECT_ID(N'erp_lectura.guias_electronicas_numeracion', N'V') IS NOT NULL BEGIN IF NOT EXISTS (SELECT 1 FROM sys.extended_properties WHERE class=1 AND major_id=OBJECT_ID(N'erp_lectura.guias_electronicas_numeracion') AND minor_id=0 AND name=N'EasySoftDiccionario' AND CONVERT(nvarchar(10),value)=N'v1') THROW 51001, 'Objeto ajeno al diccionario.', 1; DROP VIEW [erp_lectura].[guias_electronicas_numeracion]; END;
IF OBJECT_ID(N'erp_lectura.retenciones_electronicas_numeracion', N'V') IS NOT NULL BEGIN IF NOT EXISTS (SELECT 1 FROM sys.extended_properties WHERE class=1 AND major_id=OBJECT_ID(N'erp_lectura.retenciones_electronicas_numeracion') AND minor_id=0 AND name=N'EasySoftDiccionario' AND CONVERT(nvarchar(10),value)=N'v1') THROW 51001, 'Objeto ajeno al diccionario.', 1; DROP VIEW [erp_lectura].[retenciones_electronicas_numeracion]; END;
IF OBJECT_ID(N'erp_lectura.puntos_emision_electronica', N'V') IS NOT NULL BEGIN IF NOT EXISTS (SELECT 1 FROM sys.extended_properties WHERE class=1 AND major_id=OBJECT_ID(N'erp_lectura.puntos_emision_electronica') AND minor_id=0 AND name=N'EasySoftDiccionario' AND CONVERT(nvarchar(10),value)=N'v1') THROW 51001, 'Objeto ajeno al diccionario.', 1; DROP VIEW [erp_lectura].[puntos_emision_electronica]; END;
COMMIT TRANSACTION;
END TRY
BEGIN CATCH
IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
THROW;
END CATCH;
