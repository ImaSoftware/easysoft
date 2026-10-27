-- Solo lectura. Cuenta grupos duplicados y registros inconsistentes.
-- Los vinculos son candidatos funcionales, no claves foraneas validadas.
-- Sin nombres, identificaciones, contactos ni importes individuales.
SET NOCOUNT ON;
SELECT N'clientes_codigo_duplicado' control, COUNT_BIG(*) incidencias
FROM (SELECT codigo FROM dbo.DP05A110 GROUP BY codigo HAVING COUNT_BIG(*)>1) d
UNION ALL
SELECT N'proveedores_codigo_duplicado', COUNT_BIG(*)
FROM (SELECT codigo FROM dbo.DP06A110 GROUP BY codigo HAVING COUNT_BIG(*)>1) d
UNION ALL
SELECT N'documentos_tipo_numero_duplicado', COUNT_BIG(*)
FROM (SELECT tipo,numero FROM dbo.DPINVCAB GROUP BY tipo,numero HAVING COUNT_BIG(*)>1) d
UNION ALL
SELECT N'cuotas_clave_duplicada', COUNT_BIG(*)
FROM (SELECT tipoDoc,numDoc,idCuota FROM dbo.DP05ACUO GROUP BY tipoDoc,numDoc,idCuota HAVING COUNT_BIG(*)>1) d
UNION ALL
SELECT N'cuotas_sin_documento',COUNT_BIG(*) FROM dbo.DP05ACUO q
WHERE NOT EXISTS(SELECT 1 FROM dbo.DPINVCAB h WHERE h.tipo=q.tipoDoc AND h.numero=q.numDoc)
UNION ALL
SELECT N'cuotas_sin_vencimiento',COUNT_BIG(*) FROM dbo.DP05ACUO WHERE Vencimiento IS NULL
UNION ALL
SELECT N'cuotas_importe_nulo_o_no_positivo',COUNT_BIG(*) FROM dbo.DP05ACUO WHERE Valor IS NULL OR Valor<=0
UNION ALL
SELECT N'detalles_sin_documento',COUNT_BIG(*) FROM dbo.DP03AMOV d
WHERE NOT EXISTS(SELECT 1 FROM dbo.DPINVCAB h WHERE h.tipo=d.tipo AND h.numero=d.numero)
UNION ALL
SELECT N'detalles_sin_producto',COUNT_BIG(*) FROM dbo.DP03AMOV d
WHERE NOT EXISTS(SELECT 1 FROM dbo.dp03a110 p WHERE p.no_parte=d.no_parte)
UNION ALL
SELECT N'documentos_sin_tipo_configurado',COUNT_BIG(*) FROM dbo.DPINVCAB h
WHERE NOT EXISTS(SELECT 1 FROM dbo.dp03acom t WHERE t.codigo=h.tipo)
UNION ALL
SELECT N'documentos_venta_sin_cliente',COUNT_BIG(*) FROM dbo.DPINVCAB h
WHERE h.grupo='V' AND NOT EXISTS(SELECT 1 FROM dbo.DP05A110 c WHERE c.codigo=h.prov_cli)
UNION ALL
SELECT N'documentos_compra_sin_proveedor',COUNT_BIG(*) FROM dbo.DPINVCAB h
WHERE h.grupo='C' AND NOT EXISTS(SELECT 1 FROM dbo.DP06A110 c WHERE c.codigo=h.prov_cli)
UNION ALL
SELECT N'cobros_sin_cliente',COUNT_BIG(*) FROM dbo.DP05ACAB a
WHERE NOT EXISTS(SELECT 1 FROM dbo.DP05A110 c WHERE c.codigo=a.codcli)
UNION ALL
SELECT N'pagos_sin_proveedor',COUNT_BIG(*) FROM dbo.DP06ACAB a
WHERE NOT EXISTS(SELECT 1 FROM dbo.DP06A110 c WHERE c.codigo=a.codpro)
UNION ALL
SELECT N'creditos_proveedor_sin_proveedor',COUNT_BIG(*) FROM dbo.DP06ANC a
WHERE NOT EXISTS(SELECT 1 FROM dbo.DP06A110 c WHERE c.codigo=a.codpro)
UNION ALL
SELECT N'credito_proveedor_acumulado_distinto_aplicaciones',COUNT_BIG(*) FROM dbo.DP06ANC n
OUTER APPLY(SELECT SUM(a.monto) importe FROM dbo.DP06ACAB a
WHERE a.tipopag=n.tipo AND a.numpago=n.numero AND a.codpro=n.codpro AND ISNULL(a.anulada,0)=0) x
WHERE ISNULL(n.anulada,0)=0 AND ABS(ISNULL(n.aplicado,0)-ISNULL(x.importe,0))>0.01
ORDER BY control;

-- Dimensiones cuya ausencia impide calcular antiguedad con confianza.
SELECT N'documentos_sin_fecha_vencimiento' control, COUNT_BIG(*) incidencias
FROM dbo.DPINVCAB WHERE fecha_ven IS NULL;
