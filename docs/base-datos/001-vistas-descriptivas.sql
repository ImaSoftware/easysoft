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
EXEC(N'CREATE VIEW [erp_lectura].[catalogos_generales_heredados] AS SELECT
    [master] AS [codigo_catalogo_padre],
    [codigo] AS [codigo_elemento],
    [nombre] AS [nombre_elemento],
    [nomtag] AS [etiqueta_catalogo]
FROM [dbo].[ALPTABLA];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'catalogos_generales_heredados';
EXEC(N'CREATE VIEW [erp_lectura].[cuentas_contables] AS SELECT
    [codigo] AS [codigo_cuenta],
    [codigo_aux] AS [codigo_cuenta_auxiliar],
    [nombre] AS [nombre_cuenta],
    [detalle] AS [es_cuenta_detalle],
    [estado] AS [codigo_estado]
FROM [dbo].[DP01A110];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'cuentas_contables';
EXEC(N'CREATE VIEW [erp_lectura].[centros_costo] AS SELECT
    [cod_centro] AS [codigo_centro_costo],
    [nombre] AS [nombre_centro_costo]
FROM [dbo].[DP01ACCO];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'centros_costo';
EXEC(N'CREATE VIEW [erp_lectura].[asientos_contables_detalle] AS SELECT
    [tipo_asi] AS [tipo_asiento],
    [asiento] AS [numero_asiento],
    [linea] AS [numero_linea],
    [fecha_asi] AS [fecha_asiento],
    [codmov] AS [codigo_cuenta_contable],
    [tipo] AS [tipo_documento_referencia],
    [refer] AS [numero_documento_referencia],
    [concepto] AS [concepto],
    [importe] AS [importe],
    [cerrado] AS [esta_cerrado],
    [anulado] AS [esta_anulado],
    [centro_cos] AS [codigo_centro_costo]
FROM [dbo].[DP01AMOV];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'asientos_contables_detalle';
EXEC(N'CREATE VIEW [erp_lectura].[productos] AS SELECT
    [no_parte] AS [codigo_producto],
    [codinter] AS [codigo_interno],
    [nombre] AS [nombre_producto],
    [codbarra] AS [codigo_barras],
    [modelo] AS [modelo],
    [proveedor] AS [codigo_proveedor],
    [marca] AS [codigo_marca],
    [desunidad] AS [codigo_unidad],
    [exmin] AS [existencia_minima],
    [exmax] AS [existencia_maxima],
    [estado] AS [codigo_estado],
    [fecha_crea] AS [fecha_creacion],
    [fecha_modi] AS [fecha_modificacion],
    [idCocina] AS [id_cocina]
FROM [dbo].[dp03a110];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'productos';
EXEC(N'CREATE VIEW [erp_lectura].[tipos_documentos_comerciales] AS SELECT
    [codigo] AS [codigo_tipo_documento],
    [nombre] AS [nombre_tipo_documento],
    [grupo] AS [codigo_grupo_operacion],
    [ctaxpagar] AS [genera_cuenta_por_pagar],
    [serie] AS [serie_comprobante],
    [inventario] AS [indicador_afectacion_inventario],
    [signo] AS [signo_movimiento],
    [fiscal] AS [indicador_documento_fiscal],
    [celectro] AS [indicador_comprobante_electronico]
FROM [dbo].[DP03ACOM];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'tipos_documentos_comerciales';
EXEC(N'CREATE VIEW [erp_lectura].[documentos_comerciales_detalle] AS SELECT
    [tipo] AS [tipo_documento],
    [numero] AS [numero_documento],
    [linea] AS [numero_linea],
    [fecha_tra] AS [fecha_transaccion],
    [no_parte] AS [codigo_producto],
    [bodega] AS [codigo_bodega],
    [cantidad] AS [cantidad],
    [precio_u] AS [precio_unitario],
    [precio_t] AS [precio_total],
    [costo_u] AS [costo_unitario],
    [costo_t] AS [costo_total],
    [poriva] AS [porcentaje_iva],
    [valiva] AS [importe_iva],
    [pordes] AS [porcentaje_descuento],
    [valdes] AS [importe_descuento],
    [lote] AS [codigo_lote],
    [serie] AS [numero_serie],
    [devol] AS [indicador_devolucion],
    [cant_devol] AS [cantidad_devuelta]
FROM [dbo].[DP03AMOV];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'documentos_comerciales_detalle';
EXEC(N'CREATE VIEW [erp_lectura].[clientes] AS SELECT
    [codigo] AS [codigo_cliente],
    [empcli] AS [nombre_cliente],
    [pc_ncta] AS [cuenta_contable_cliente],
    [ruc] AS [identificacion_tributaria],
    [direccion] AS [direccion_principal],
    [direccion2] AS [direccion_secundaria],
    [fono1] AS [telefono_principal],
    [fono2] AS [telefono_secundario],
    [vendedor] AS [codigo_vendedor],
    [diasp] AS [dias_plazo_pago],
    [estado] AS [codigo_estado],
    [pordes] AS [porcentaje_descuento],
    [comenta] AS [observaciones],
    [zona] AS [codigo_zona],
    [sector] AS [codigo_sector],
    [ciudad] AS [ciudad],
    [email] AS [correo_electronico],
    [tipo_id] AS [codigo_tipo_identificacion],
    [antic_ncta] AS [cuenta_contable_anticipos],
    [codmain] AS [codigo_cliente_principal]
FROM [dbo].[DP05A110];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'clientes';
EXEC(N'CREATE VIEW [erp_lectura].[aplicaciones_cobros_clientes] AS SELECT
    [tipo] AS [tipo_comprobante_aplicacion],
    [numero] AS [numero_comprobante_aplicacion],
    [linea] AS [numero_linea],
    [fecha] AS [fecha_aplicacion],
    [codcli] AS [codigo_cliente],
    [tipodoc] AS [tipo_documento_destino],
    [numdoc] AS [numero_documento_destino],
    [fecha_ven] AS [fecha_vencimiento_documento],
    [tipopag] AS [tipo_documento_pago],
    [numpago] AS [numero_documento_pago],
    [monto] AS [importe_aplicado],
    [codban] AS [codigo_banco],
    [ctaban] AS [cuenta_bancaria],
    [fecha_doc] AS [fecha_documento_pago],
    [comenta] AS [observaciones],
    [usersys] AS [usuario_registro],
    [fechasys] AS [fecha_registro],
    [horasys] AS [hora_registro],
    [anulada] AS [esta_anulada],
    [fechaanu] AS [fecha_anulacion_registrada],
    [horaanu] AS [hora_anulacion],
    [useranu] AS [usuario_anulacion],
    [comproba] AS [referencia_comprobante_contable],
    [cajero] AS [codigo_cajero],
    [IdCuota] AS [numero_cuota],
    [bodega] AS [codigo_bodega]
FROM [dbo].[DP05ACAB];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'aplicaciones_cobros_clientes';
EXEC(N'CREATE VIEW [erp_lectura].[cheques_clientes] AS SELECT
    [tipo] AS [tipo_documento],
    [numero] AS [numero_documento],
    [codcli] AS [codigo_cliente],
    [fec_cobro] AS [fecha_cobro_registrada],
    [fec_vence] AS [fecha_vencimiento],
    [codban] AS [codigo_banco],
    [ctaban] AS [cuenta_bancaria],
    [monto] AS [importe_cheque],
    [documento] AS [referencia_documento],
    [estado] AS [codigo_estado],
    [comenta] AS [observaciones],
    [lote] AS [referencia_lote],
    [bco_depo] AS [codigo_banco_deposito],
    [fecha_depo] AS [fecha_deposito],
    [trn_conta] AS [referencia_transaccion_contable],
    [nc_genera] AS [referencia_nota_credito_generada]
FROM [dbo].[DP05ACH];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'cheques_clientes';
EXEC(N'CREATE VIEW [erp_lectura].[cuotas_documentos_clientes] AS SELECT
    [tipoDoc] AS [tipo_documento],
    [numDoc] AS [numero_documento],
    [idCuota] AS [numero_cuota],
    [Vencimiento] AS [fecha_vencimiento],
    [Valor] AS [importe_cuota]
FROM [dbo].[DP05ACUO];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'cuotas_documentos_clientes';
EXEC(N'CREATE VIEW [erp_lectura].[creditos_y_anticipos_clientes] AS SELECT
    [tipo] AS [tipo_documento],
    [numero] AS [numero_documento],
    [fecha] AS [fecha_documento],
    [comenta] AS [observaciones],
    [base] AS [importe_base],
    [descu] AS [importe_descuento],
    [iva] AS [importe_iva],
    [valmov] AS [importe_documento],
    [aplicado] AS [importe_aplicado_acumulado],
    [documento] AS [referencia_documento],
    [asiento] AS [referencia_asiento],
    [integra] AS [indicador_integracion_contable],
    [tiponc] AS [codigo_tipo_nota_credito],
    [anulada] AS [esta_anulada],
    [fecanu] AS [fecha_anulacion],
    [horanu] AS [hora_anulacion],
    [useranu] AS [usuario_anulacion],
    [valanu] AS [importe_anulado],
    [codcli] AS [codigo_cliente]
FROM [dbo].[DP05ANC];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'creditos_y_anticipos_clientes';
EXEC(N'CREATE VIEW [erp_lectura].[notas_debito_clientes] AS SELECT
    [tipo] AS [tipo_documento],
    [numero] AS [numero_documento],
    [fecha_tra] AS [fecha_transaccion],
    [fecha_ven] AS [fecha_vencimiento],
    [codven] AS [codigo_vendedor],
    [comenta] AS [observaciones],
    [subt] AS [importe_subtotal],
    [otroc] AS [importe_otros_cargos],
    [valmov] AS [importe_documento],
    [abono] AS [importe_abonado_acumulado],
    [anulada] AS [esta_anulada],
    [tipond] AS [codigo_tipo_nota_debito],
    [valanu] AS [importe_anulado],
    [useranu] AS [usuario_anulacion],
    [fecanu] AS [fecha_anulacion],
    [horanu] AS [hora_anulacion],
    [asiento] AS [referencia_asiento],
    [codcli] AS [codigo_cliente]
FROM [dbo].[DP05AND];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'notas_debito_clientes';
EXEC(N'CREATE VIEW [erp_lectura].[proveedores] AS SELECT
    [codigo] AS [codigo_proveedor],
    [empresa] AS [nombre_proveedor],
    [contacto] AS [nombre_contacto],
    [contable1] AS [cuenta_contable_proveedor],
    [ruc] AS [identificacion_tributaria],
    [direccion] AS [direccion],
    [fono1] AS [telefono_principal],
    [fono2] AS [telefono_secundario],
    [observa] AS [observaciones],
    [tipo] AS [codigo_tipo_persona],
    [estado] AS [codigo_estado],
    [diasp] AS [dias_plazo_pago],
    [pordes] AS [porcentaje_descuento],
    [email] AS [correo_electronico],
    [tipoid] AS [codigo_tipo_identificacion],
    [cta_antic] AS [cuenta_contable_anticipos]
FROM [dbo].[DP06A110];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'proveedores';
EXEC(N'CREATE VIEW [erp_lectura].[aplicaciones_pagos_proveedores] AS SELECT
    [tipo] AS [tipo_comprobante_aplicacion],
    [numero] AS [numero_comprobante_aplicacion],
    [linea] AS [numero_linea],
    [fecha] AS [fecha_aplicacion],
    [codpro] AS [codigo_proveedor],
    [tipodoc] AS [tipo_documento_destino],
    [numdoc] AS [numero_documento_destino],
    [fecha_ven] AS [fecha_vencimiento_documento],
    [tipopag] AS [tipo_documento_pago],
    [numpago] AS [numero_documento_pago],
    [monto] AS [importe_aplicado],
    [codban] AS [codigo_banco],
    [ctaban] AS [cuenta_bancaria],
    [fecha_doc] AS [fecha_documento_pago],
    [fac_pro] AS [referencia_factura_proveedor],
    [comenta] AS [observaciones],
    [usersys] AS [usuario_registro],
    [fechasys] AS [fecha_registro],
    [horasys] AS [hora_registro],
    [anulada] AS [esta_anulada],
    [fechaanu] AS [fecha_anulacion],
    [horaanu] AS [hora_anulacion],
    [useranu] AS [usuario_anulacion],
    [comproba] AS [referencia_comprobante_contable],
    [cajero] AS [codigo_cajero]
FROM [dbo].[DP06ACAB];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'aplicaciones_pagos_proveedores';
EXEC(N'CREATE VIEW [erp_lectura].[cheques_proveedores] AS SELECT
    [tipo] AS [tipo_documento],
    [numero] AS [numero_documento],
    [codpro] AS [codigo_proveedor],
    [fec_emisi] AS [fecha_emision],
    [fec_ch] AS [fecha_cheque],
    [codban] AS [codigo_banco],
    [ctaban] AS [cuenta_bancaria],
    [monto] AS [importe_cheque],
    [documento] AS [referencia_documento],
    [estado] AS [codigo_estado],
    [comenta] AS [observaciones],
    [lote] AS [referencia_lote]
FROM [dbo].[DP06ACH];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'cheques_proveedores';
EXEC(N'CREATE VIEW [erp_lectura].[creditos_y_anticipos_proveedores] AS SELECT
    [tipo] AS [tipo_documento],
    [numero] AS [numero_documento],
    [fecha] AS [fecha_documento],
    [comenta] AS [observaciones],
    [base] AS [importe_base],
    [descu] AS [importe_descuento],
    [iva] AS [importe_iva],
    [valmov] AS [importe_documento],
    [aplicado] AS [importe_aplicado_acumulado],
    [documento] AS [referencia_documento],
    [asiento] AS [referencia_asiento],
    [integra] AS [indicador_integracion_contable],
    [tiponc] AS [codigo_tipo_nota_credito],
    [anulada] AS [esta_anulada],
    [fecanu] AS [fecha_anulacion],
    [horanu] AS [hora_anulacion],
    [useranu] AS [usuario_anulacion],
    [valanu] AS [importe_anulado],
    [codpro] AS [codigo_proveedor]
FROM [dbo].[DP06ANC];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'creditos_y_anticipos_proveedores';
EXEC(N'CREATE VIEW [erp_lectura].[notas_debito_proveedores] AS SELECT
    [tipo] AS [tipo_documento],
    [numero] AS [numero_documento],
    [fecha_tra] AS [fecha_transaccion],
    [fecha_ven] AS [fecha_vencimiento],
    [codven] AS [codigo_vendedor],
    [comenta] AS [observaciones],
    [subt] AS [importe_subtotal],
    [otroc] AS [importe_otros_cargos],
    [valmov] AS [importe_documento],
    [abono] AS [importe_abonado_acumulado],
    [anulada] AS [esta_anulada],
    [tipond] AS [codigo_tipo_nota_debito],
    [valanu] AS [importe_anulado],
    [useranu] AS [usuario_anulacion],
    [fecanu] AS [fecha_anulacion],
    [horanu] AS [hora_anulacion],
    [asiento] AS [referencia_asiento],
    [codpro] AS [codigo_proveedor]
FROM [dbo].[DP06AND];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'notas_debito_proveedores';
EXEC(N'CREATE VIEW [erp_lectura].[asientos_contables_cabecera] AS SELECT
    [tipo_asi] AS [tipo_asiento],
    [asiento] AS [numero_asiento],
    [fecha_asi] AS [fecha_asiento],
    [desc_asi] AS [descripcion_asiento],
    [beneficiar] AS [nombre_beneficiario],
    [debitos] AS [total_debitos],
    [creditos] AS [total_creditos],
    [cedruc] AS [identificacion_beneficiario],
    [chequeno] AS [numero_cheque],
    [usuario] AS [usuario_registro],
    [fechasys] AS [fecha_registro],
    [horasys] AS [hora_registro],
    [cerrado] AS [esta_cerrado],
    [anulado] AS [esta_anulado],
    [fechaanu] AS [fecha_anulacion],
    [horaanu] AS [hora_anulacion],
    [usuanu] AS [usuario_anulacion],
    [auditado] AS [esta_auditado]
FROM [dbo].[DPCABTRA];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'asientos_contables_cabecera';
EXEC(N'CREATE VIEW [erp_lectura].[documentos_comerciales] AS SELECT
    [tipo] AS [tipo_documento],
    [numero] AS [numero_documento],
    [grupo] AS [codigo_grupo_operacion],
    [fecha_tra] AS [fecha_transaccion],
    [fecha_ven] AS [fecha_vencimiento],
    [bodega] AS [codigo_bodega],
    [bodega_d] AS [codigo_bodega_destino],
    [prov_cli] AS [codigo_cliente_o_proveedor],
    [vendedor] AS [codigo_vendedor],
    [total_mov] AS [importe_movimientos],
    [pordes] AS [porcentaje_descuento],
    [total_des] AS [importe_descuento],
    [poriva] AS [porcentaje_iva],
    [total_iva] AS [importe_iva],
    [total_trn] AS [importe_total],
    [comenta] AS [observaciones],
    [anulada] AS [esta_anulado],
    [fecha_anu] AS [fecha_anulacion_registrada],
    [user_anu] AS [usuario_anulacion],
    [abono] AS [importe_abonado_acumulado],
    [fac_pro] AS [referencia_factura_externa],
    [total_ice] AS [importe_ice],
    [ce_autoriz] AS [numero_autorizacion_electronica],
    [ce_clave] AS [clave_acceso_electronica],
    [ce_fecaut] AS [fecha_autorizacion_electronica],
    [ce_estado] AS [codigo_estado_electronico],
    [ce_deserra] AS [descripcion_error_electronico]
FROM [dbo].[DPINVCAB];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'documentos_comerciales';
EXEC(N'CREATE VIEW [erp_lectura].[marcas_productos] AS SELECT
    [codmarca] AS [codigo_marca],
    [nommarca] AS [nombre_marca]
FROM [dbo].[tbmarca];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'marcas_productos';
EXEC(N'CREATE VIEW [erp_lectura].[paises] AS SELECT
    [codpais] AS [codigo_pais],
    [nompais] AS [nombre_pais]
FROM [dbo].[tbpais];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'paises';
EXEC(N'CREATE VIEW [erp_lectura].[unidades_medida] AS SELECT
    [codunidad] AS [codigo_unidad],
    [nomunidad] AS [nombre_unidad]
FROM [dbo].[tbunidad];');
EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'unidades_medida';
COMMIT TRANSACTION;
END TRY
BEGIN CATCH
IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
THROW;
END CATCH;
