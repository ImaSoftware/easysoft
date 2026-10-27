-- Solo lectura; resultados agregados, sin identificadores ni importes individuales.
SET NOCOUNT ON;
IF DB_NAME() <> N'EasySoft_Patricks_Dev' THROW 51000, 'Base de desarrollo requerida.', 1;
SELECT N'cuotas' conjunto,COUNT(*) filas,COUNT(DISTINCT tipoDoc+numDoc) referencias_concatenadas,
 MIN(Vencimiento) vencimiento_min,MAX(Vencimiento) vencimiento_max FROM dbo.DP05ACUO;
SELECT N'documentos_cuotas' control,COUNT(*) grupos,
 SUM(CASE WHEN EXISTS_HEADER=0 THEN 1 ELSE 0 END) sin_cabecera
FROM (SELECT q.tipoDoc,q.numDoc,MAX(CASE WHEN h.tipo IS NULL THEN 0 ELSE 1 END) EXISTS_HEADER
 FROM dbo.DP05ACUO q LEFT JOIN dbo.DPINVCAB h ON h.tipo=q.tipoDoc AND h.numero=q.numDoc
 GROUP BY q.tipoDoc,q.numDoc) x;
SELECT N'cuotas_coinciden_solo_numero' control,COUNT(*) incidencias FROM dbo.DP05ACUO q
 WHERE EXISTS(SELECT 1 FROM dbo.DPINVCAB h WHERE h.numero=q.numDoc);
SELECT N'cuotas_coinciden_concatenadas' control,COUNT(*) incidencias FROM dbo.DP05ACUO q
 WHERE EXISTS(SELECT 1 FROM dbo.DPINVCAB h WHERE h.tipo+h.numero=q.tipoDoc+q.numDoc);
SELECT N'cabeceras' conjunto,COUNT(*) filas,MIN(fecha_tra) fecha_min,MAX(fecha_tra) fecha_max FROM dbo.DPINVCAB;
SELECT N'aplicaciones_proveedor' conjunto,COUNT(*) filas FROM dbo.DP06ACAB;
SELECT N'creditos_proveedor' conjunto,COUNT(*) filas,
 SUM(CASE WHEN ISNULL(aplicado,0)<>0 THEN 1 ELSE 0 END) acumulado_no_cero,
 SUM(CASE WHEN ISNULL(anulada,0)=1 THEN 1 ELSE 0 END) anulados FROM dbo.DP06ANC;
-- Contrastar criterios historicos sin ejecutar rutinas que escriben.
SELECT N'diferencias_acumulado' control,
 SUM(CASE WHEN ABS(ISNULL(n.aplicado,0)-ISNULL(a.estricto,0))>0.01 THEN 1 ELSE 0 END) criterio_sp_06nc,
 SUM(CASE WHEN ABS(ISNULL(n.aplicado,0)-ISNULL(a.normalizado,0))>0.01 THEN 1 ELSE 0 END) nulos_como_vigentes,
 SUM(CASE WHEN ABS(ISNULL(n.aplicado,0)-ISNULL(b.importe,0))>0.01 THEN 1 ELSE 0 END) con_proveedor
FROM dbo.DP06ANC n OUTER APPLY (
 SELECT SUM(CASE WHEN anulada=0 THEN monto ELSE 0 END) estricto,
 SUM(CASE WHEN ISNULL(anulada,0)=0 THEN monto ELSE 0 END) normalizado
 FROM dbo.DP06ACAB WHERE tipopag=n.tipo AND numpago=n.numero) a
OUTER APPLY (SELECT SUM(monto) importe FROM dbo.DP06ACAB
 WHERE tipopag=n.tipo AND numpago=n.numero AND codpro=n.codpro AND ISNULL(anulada,0)=0) b
WHERE ISNULL(n.anulada,0)=0;
-- Numeracion AP: cada identidad se conserva en columnas separadas.
SELECT N'APCabFac' tabla,COUNT(*) filas FROM dbo.APCabFac UNION ALL
SELECT N'APCabCre',COUNT(*) FROM dbo.APCabCre UNION ALL
SELECT N'APCabDeb',COUNT(*) FROM dbo.APCabDeb UNION ALL
SELECT N'APCabGui',COUNT(*) FROM dbo.APCabGui UNION ALL
SELECT N'apCabRet',COUNT(*) FROM dbo.apCabRet;
SELECT N'identidades_ap_duplicadas' control,COUNT(*) grupos FROM (
 SELECT N'FE' clase,estab,ptoemi,secuencia FROM dbo.APCabFac GROUP BY estab,ptoemi,secuencia HAVING COUNT(*)>1
 UNION ALL SELECT N'CE',estab,ptoemi,secuencia FROM dbo.APCabCre GROUP BY estab,ptoemi,secuencia HAVING COUNT(*)>1
 UNION ALL SELECT N'DE',estab,ptoemi,secuencia FROM dbo.APCabDeb GROUP BY estab,ptoemi,secuencia HAVING COUNT(*)>1
 UNION ALL SELECT N'GE',estab,ptoemi,secuencia FROM dbo.APCabGui GROUP BY estab,ptoemi,secuencia HAVING COUNT(*)>1
 UNION ALL SELECT N'RE',estab,ptoemi,secuencia FROM dbo.apCabRet GROUP BY estab,ptoemi,secuencia HAVING COUNT(*)>1) d;
