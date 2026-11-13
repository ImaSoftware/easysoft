param(
    [string]$RepositoryRoot = (Split-Path $PSScriptRoot -Parent)
)
$ErrorActionPreference = 'Stop'
$folder = Join-Path $RepositoryRoot 'docs/base-datos'
$tables = @(Import-Csv (Join-Path $folder 'tablas.csv'))
$columns = @(Import-Csv (Join-Path $folder 'columnas.csv'))
$mapping = @{}

# Solo se publican campos cuyo significado puede explicarse. Los restantes
# permanecen en el inventario como pendientes, sin inventar equivalencias.
function Add-Table($source, $target, $module, $evidence, $pairs) {
    $fields = [ordered]@{}
    foreach ($pair in $pairs.Split(';')) {
        if (-not $pair.Trim()) { continue }
        $parts = $pair.Trim().Split('=', 2)
        if ($parts.Count -ne 2) { throw "Equivalencia incompleta: $pair" }
        $old, $new = $parts
        if ($fields.Contains($old)) { throw "Campo repetido: $source.$old" }
        $fields[$old] = $new
    }
    $mapping[$source] = @{ Name=$target; Module=$module; Evidence=$evidence; Fields=$fields }
}

Add-Table 'DP05A110' 'clientes' 'cuentas_por_cobrar' 'sp_05P330; sp_05CreDisp; sp_05AutApliCre; columnas.csv' @'
codigo=codigo_cliente;empcli=nombre_cliente;pc_ncta=cuenta_contable_cliente;ruc=identificacion_tributaria;direccion=direccion_principal;direccion2=direccion_secundaria;fono1=telefono_principal;fono2=telefono_secundario;vendedor=codigo_vendedor;diasp=dias_plazo_pago;estado=codigo_estado;pordes=porcentaje_descuento;comenta=observaciones;zona=codigo_zona;sector=codigo_sector;ciudad=ciudad;email=correo_electronico;tipo_id=codigo_tipo_identificacion;antic_ncta=cuenta_contable_anticipos;codmain=codigo_cliente_principal
'@
Add-Table 'DP06A110' 'proveedores' 'cuentas_por_pagar' 'sp_06P310; sp_06P320; sp_06AutApliCre; columnas.csv' @'
codigo=codigo_proveedor;empresa=nombre_proveedor;contacto=nombre_contacto;contable1=cuenta_contable_proveedor;ruc=identificacion_tributaria;direccion=direccion;fono1=telefono_principal;fono2=telefono_secundario;observa=observaciones;tipo=codigo_tipo_persona;estado=codigo_estado;diasp=dias_plazo_pago;pordes=porcentaje_descuento;email=correo_electronico;tipoid=codigo_tipo_identificacion;cta_antic=cuenta_contable_anticipos
'@
Add-Table 'DP05ACAB' 'aplicaciones_cobros_clientes' 'cuentas_por_cobrar' 'sp_05AutApliCre; sp_05P330; sp_05PACA' @'
tipo=tipo_comprobante_aplicacion;numero=numero_comprobante_aplicacion;linea=numero_linea;fecha=fecha_aplicacion;codcli=codigo_cliente;tipodoc=tipo_documento_destino;numdoc=numero_documento_destino;fecha_ven=fecha_vencimiento_documento;tipopag=tipo_documento_pago;numpago=numero_documento_pago;monto=importe_aplicado;codban=codigo_banco;ctaban=cuenta_bancaria;fecha_doc=fecha_documento_pago;comenta=observaciones;usersys=usuario_registro;fechasys=fecha_registro;horasys=hora_registro;anulada=esta_anulada;fechaanu=fecha_anulacion_registrada;horaanu=hora_anulacion;useranu=usuario_anulacion;comproba=referencia_comprobante_contable;cajero=codigo_cajero;IdCuota=numero_cuota;bodega=codigo_bodega
'@
Add-Table 'DP06ACAB' 'aplicaciones_pagos_proveedores' 'cuentas_por_pagar' 'sp_06AutApliCre; sp_06can; sp_06P350' @'
tipo=tipo_comprobante_aplicacion;numero=numero_comprobante_aplicacion;linea=numero_linea;fecha=fecha_aplicacion;codpro=codigo_proveedor;tipodoc=tipo_documento_destino;numdoc=numero_documento_destino;fecha_ven=fecha_vencimiento_documento;tipopag=tipo_documento_pago;numpago=numero_documento_pago;monto=importe_aplicado;codban=codigo_banco;ctaban=cuenta_bancaria;fecha_doc=fecha_documento_pago;fac_pro=referencia_factura_proveedor;comenta=observaciones;usersys=usuario_registro;fechasys=fecha_registro;horasys=hora_registro;anulada=esta_anulada;fechaanu=fecha_anulacion;horaanu=hora_anulacion;useranu=usuario_anulacion;comproba=referencia_comprobante_contable;cajero=codigo_cajero
'@
Add-Table 'DP05ACUO' 'cuotas_documentos_clientes' 'cuentas_por_cobrar' 'fxEstadoCuota; VistaCuotas; spWW_CuotasDOC' @'
tipoDoc=tipo_documento;numDoc=numero_documento;idCuota=numero_cuota;Vencimiento=fecha_vencimiento;Valor=importe_cuota
'@
foreach ($item in @(@('DP05ANC','creditos_y_anticipos_clientes','codcli','codigo_cliente','cuentas_por_cobrar','sp_05CreDisp; sp_05AutApliCre; sp_05P350'), @('DP06ANC','creditos_y_anticipos_proveedores','codpro','codigo_proveedor','cuentas_por_pagar','sp_06nc; sp_06AutApliCre'))) {
    $pairs = 'tipo=tipo_documento;numero=numero_documento;fecha=fecha_documento;comenta=observaciones;base=importe_base;descu=importe_descuento;iva=importe_iva;valmov=importe_documento;aplicado=importe_aplicado_acumulado;documento=referencia_documento;asiento=referencia_asiento;integra=indicador_integracion_contable;tiponc=codigo_tipo_nota_credito;anulada=esta_anulada;fecanu=fecha_anulacion;horanu=hora_anulacion;useranu=usuario_anulacion;valanu=importe_anulado;'
    Add-Table $item[0] $item[1] $item[4] $item[5] ($pairs + $item[2] + '=' + $item[3])
}
foreach ($item in @(@('DP05AND','notas_debito_clientes','codcli','codigo_cliente','cuentas_por_cobrar','sp_05P330'), @('DP06AND','notas_debito_proveedores','codpro','codigo_proveedor','cuentas_por_pagar','sp_06nd; sp_06P320'))) {
    $pairs = 'tipo=tipo_documento;numero=numero_documento;fecha_tra=fecha_transaccion;fecha_ven=fecha_vencimiento;codven=codigo_vendedor;comenta=observaciones;subt=importe_subtotal;otroc=importe_otros_cargos;valmov=importe_documento;abono=importe_abonado_acumulado;anulada=esta_anulada;tipond=codigo_tipo_nota_debito;valanu=importe_anulado;useranu=usuario_anulacion;fecanu=fecha_anulacion;horanu=hora_anulacion;asiento=referencia_asiento;'
    Add-Table $item[0] $item[1] $item[4] $item[5] ($pairs + $item[2] + '=' + $item[3])
}
Add-Table 'DP05ACH' 'cheques_clientes' 'tesoreria' 'sp_05P330; VistaCuotas; columnas.csv' @'
tipo=tipo_documento;numero=numero_documento;codcli=codigo_cliente;fec_cobro=fecha_cobro_registrada;fec_vence=fecha_vencimiento;codban=codigo_banco;ctaban=cuenta_bancaria;monto=importe_cheque;documento=referencia_documento;estado=codigo_estado;comenta=observaciones;lote=referencia_lote;bco_depo=codigo_banco_deposito;fecha_depo=fecha_deposito;trn_conta=referencia_transaccion_contable;nc_genera=referencia_nota_credito_generada
'@
Add-Table 'DP06ACH' 'cheques_proveedores' 'tesoreria' 'sp_06P330; columnas.csv' @'
tipo=tipo_documento;numero=numero_documento;codpro=codigo_proveedor;fec_emisi=fecha_emision;fec_ch=fecha_cheque;codban=codigo_banco;ctaban=cuenta_bancaria;monto=importe_cheque;documento=referencia_documento;estado=codigo_estado;comenta=observaciones;lote=referencia_lote
'@
Add-Table 'DPINVCAB' 'documentos_comerciales' 'compras_ventas_inventario' 'sp_05P330; sp_05PACA; sp_06P320; sp_06AutApliCre' @'
tipo=tipo_documento;numero=numero_documento;grupo=codigo_grupo_operacion;fecha_tra=fecha_transaccion;fecha_ven=fecha_vencimiento;bodega=codigo_bodega;bodega_d=codigo_bodega_destino;prov_cli=codigo_cliente_o_proveedor;vendedor=codigo_vendedor;total_mov=importe_movimientos;pordes=porcentaje_descuento;total_des=importe_descuento;poriva=porcentaje_iva;total_iva=importe_iva;total_trn=importe_total;comenta=observaciones;anulada=esta_anulado;fecha_anu=fecha_anulacion_registrada;user_anu=usuario_anulacion;abono=importe_abonado_acumulado;fac_pro=referencia_factura_externa;total_ice=importe_ice;ce_autoriz=numero_autorizacion_electronica;ce_clave=clave_acceso_electronica;ce_fecaut=fecha_autorizacion_electronica;ce_estado=codigo_estado_electronico;ce_deserra=descripcion_error_electronico
'@
Add-Table 'DP03ACOM' 'tipos_documentos_comerciales' 'compras_ventas_inventario' 'sp_05PACA; sp_06P320; columnas.csv' @'
codigo=codigo_tipo_documento;nombre=nombre_tipo_documento;grupo=codigo_grupo_operacion;ctaxpagar=genera_cuenta_por_pagar;serie=serie_comprobante;inventario=indicador_afectacion_inventario;signo=signo_movimiento;fiscal=indicador_documento_fiscal;celectro=indicador_comprobante_electronico
'@
Add-Table 'DP01A110' 'cuentas_contables' 'contabilidad' 'df_Saldo_cnt; sp_CuadraSaldoCnt; columnas.csv' @'
codigo=codigo_cuenta;codigo_aux=codigo_cuenta_auxiliar;nombre=nombre_cuenta;detalle=es_cuenta_detalle;estado=codigo_estado
'@
Add-Table 'DP01AMOV' 'asientos_contables_detalle' 'contabilidad' 'sp_05AutApliCre; sp_06AutApliCre' @'
tipo_asi=tipo_asiento;asiento=numero_asiento;linea=numero_linea;fecha_asi=fecha_asiento;codmov=codigo_cuenta_contable;tipo=tipo_documento_referencia;refer=numero_documento_referencia;concepto=concepto;importe=importe;cerrado=esta_cerrado;anulado=esta_anulado;centro_cos=codigo_centro_costo
'@
Add-Table 'DPCABTRA' 'asientos_contables_cabecera' 'contabilidad' 'sp_05AutApliCre; sp_06AutApliCre; columnas.csv' @'
tipo_asi=tipo_asiento;asiento=numero_asiento;fecha_asi=fecha_asiento;desc_asi=descripcion_asiento;beneficiar=nombre_beneficiario;debitos=total_debitos;creditos=total_creditos;cedruc=identificacion_beneficiario;chequeno=numero_cheque;usuario=usuario_registro;fechasys=fecha_registro;horasys=hora_registro;cerrado=esta_cerrado;anulado=esta_anulado;fechaanu=fecha_anulacion;horaanu=hora_anulacion;usuanu=usuario_anulacion;auditado=esta_auditado
'@
Add-Table 'DP01ACCO' 'centros_costo' 'contabilidad' 'columnas.csv; DP01AMOV.centro_cos (relacion por verificar)' @'
cod_centro=codigo_centro_costo;nombre=nombre_centro_costo
'@
Add-Table 'dp03a110' 'productos' 'inventario' 'columnas.csv; SDSP_* (uso de catalogo en Restaurante)' @'
no_parte=codigo_producto;codinter=codigo_interno;nombre=nombre_producto;codbarra=codigo_barras;modelo=modelo;proveedor=codigo_proveedor;marca=codigo_marca;desunidad=codigo_unidad;exmin=existencia_minima;exmax=existencia_maxima;estado=codigo_estado;fecha_crea=fecha_creacion;fecha_modi=fecha_modificacion;idCocina=id_cocina
'@
Add-Table 'DP03AMOV' 'documentos_comerciales_detalle' 'compras_ventas_inventario' 'columnas.csv; sp_03actsaldos; df_resaldos03' @'
tipo=tipo_documento;numero=numero_documento;linea=numero_linea;fecha_tra=fecha_transaccion;no_parte=codigo_producto;bodega=codigo_bodega;cantidad=cantidad;precio_u=precio_unitario;precio_t=precio_total;costo_u=costo_unitario;costo_t=costo_total;poriva=porcentaje_iva;valiva=importe_iva;pordes=porcentaje_descuento;valdes=importe_descuento;lote=codigo_lote;serie=numero_serie;devol=indicador_devolucion;cant_devol=cantidad_devuelta
'@
Add-Table 'tbunidad' 'unidades_medida' 'inventario' 'columnas.csv' 'codunidad=codigo_unidad;nomunidad=nombre_unidad'
Add-Table 'tbmarca' 'marcas_productos' 'inventario' 'columnas.csv' 'codmarca=codigo_marca;nommarca=nombre_marca'
Add-Table 'tbpais' 'paises' 'catalogos' 'columnas.csv' 'codpais=codigo_pais;nompais=nombre_pais'
Add-Table 'ALPTABLA' 'catalogos_generales_heredados' 'configuracion' 'sp_05P330; sp_05PACA; sp_06P320' 'master=codigo_catalogo_padre;codigo=codigo_elemento;nombre=nombre_elemento;nomtag=etiqueta_catalogo'

# Bloque AP limitado a campos utilizados por sp_secuenciaCE. No publicar
# credenciales de APCIAS/APUsersWEB ni deducir estados por sus nombres.
foreach ($item in @(@('APCabFac','facturas_electronicas_numeracion'), @('APCabCre','notas_credito_electronicas_numeracion'), @('APCabDeb','notas_debito_electronicas_numeracion'), @('APCabGui','guias_electronicas_numeracion'), @('apCabRet','retenciones_electronicas_numeracion'))) {
    Add-Table $item[0] $item[1] 'facturacion_electronica' 'sp_secuenciaCE: rama FE/CE/DE/GE/RE, consulta de duplicados estab+ptoemi+secuencia; no demuestra autorizacion' 'estab=codigo_establecimiento;ptoemi=codigo_punto_emision;secuencia=numero_secuencial'
}
Add-Table 'apPtoEmi' 'puntos_emision_electronica' 'facturacion_electronica' 'sp_secuenciaCE: lee e incrementa consecutivos por ptoestab y ptoemi; no acredita concurrencia segura' 'ptoestab=codigo_establecimiento;ptoemi=codigo_punto_emision;conseFactu=consecutivo_factura;conseGuia=consecutivo_guia;conseCredi=consecutivo_nota_credito;conseDebit=consecutivo_nota_debito;conseRete=consecutivo_retencion'
# Rechazar inferencias que no correspondan al inventario, alias repetidos o
# identificadores que requieran SQL construido de forma insegura.
foreach ($source in $mapping.Keys) {
    $entry = $mapping[$source]
    if (-not ($tables | Where-Object tabla -eq $source)) { throw "Tabla inexistente: $source" }
    $actual = @($columns | Where-Object tabla -eq $source | ForEach-Object columna)
    foreach ($field in @($entry.Fields.Keys)) {
        if ($field -notin $actual) { throw "Campo inexistente: $source.$field" }
    }
    $aliases = @($entry.Fields.Values)
    if (@($aliases | Select-Object -Unique).Count -ne $aliases.Count) { throw "Alias duplicados en $source" }
    foreach ($identifier in @($source, $entry.Name) + @($entry.Fields.Keys) + $aliases) {
        if ($identifier -notmatch '^[A-Za-z_][A-Za-z0-9_]*$' -or $identifier.Length -gt 128) { throw "Identificador invalido: $identifier" }
    }
}
if (@($mapping.Values.Name | Select-Object -Unique).Count -ne $mapping.Count) { throw 'Nombres de vista repetidos' }

$tableRows = foreach ($table in $tables) {
    $m = $mapping[$table.tabla]
    [pscustomobject]@{
        esquema_origen=$table.esquema; tabla_origen=$table.tabla
        nombre_descriptivo=$(if ($m) {$m.Name} else {''})
        modulo=$(if ($m) {$m.Module} else {'pendiente'})
        estado=$(if ($m) {'primera_version_revisable'} else {'pendiente_investigacion'})
        campos_publicados=$(if ($m) {$m.Fields.Count} else {0})
        campos_totales=@($columns | Where-Object tabla -eq $table.tabla).Count
        filas_fotografia=$table.filas_aproximadas
        evidencia=$(if ($m) {$m.Evidence} else {'Solo inventario; no asignar significado por prefijo'})
    }
}
$columnRows = foreach ($column in $columns) {
    $m = $mapping[$column.tabla]
    $alias = if ($m) { $m.Fields[$column.columna] } else { $null }
    [pscustomobject]@{
        esquema_origen=$column.esquema; tabla_origen=$column.tabla; campo_origen=$column.columna
        tabla_descriptiva=$(if ($m) {$m.Name} else {''})
        campo_descriptivo=$alias
        descripcion=$(if ($alias) {$alias.Replace('_',' ')} else {'Significado pendiente de contrastar'})
        estado=$(if ($alias) {'primera_version_revisable'} else {'pendiente_investigacion'})
        tipo=$column.tipo; longitud_bytes=$column.longitud_bytes; precision=$column.precision
        escala=$column.escala; permite_null=$column.permite_null; identidad=$column.identidad
        valor_predeterminado=$column.valor_predeterminado
        evidencia=$(if ($alias) {$m.Evidence} else {'Sin evidencia suficiente para renombrar'})
    }
}
$tableRows | Export-Csv (Join-Path $folder 'diccionario-tablas.csv') -NoTypeInformation -Encoding utf8
$columnRows | Export-Csv (Join-Path $folder 'diccionario-campos.csv') -NoTypeInformation -Encoding utf8

$sql = [System.Collections.Generic.List[string]]::new()
$sql.Add(@'
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
'@)
$rollback = [System.Collections.Generic.List[string]]::new()
$rollback.Add(@'
SET NOCOUNT ON;
SET XACT_ABORT ON;
IF DB_NAME() <> N'EasySoft_Patricks_Dev'
    THROW 51000, 'Este script solo admite la copia EasySoft_Patricks_Dev.', 1;
BEGIN TRY
BEGIN TRANSACTION;
'@)
$verify = [System.Collections.Generic.List[string]]::new()
$verify.Add('SET NOCOUNT ON;')
$apSql = [System.Collections.Generic.List[string]]::new()
$apRollback = [System.Collections.Generic.List[string]]::new()
$apVerify = [System.Collections.Generic.List[string]]::new()
$apSql.Add($sql[0])
$apRollback.Add($rollback[0])
$apVerify.Add($verify[0])
foreach ($source in @($mapping.Keys | Sort-Object)) {
    $sqlStart = $sql.Count; $rollbackStart = $rollback.Count; $verifyStart = $verify.Count
    $m = $mapping[$source]
    $target = $m.Name
    $projection = ($m.Fields.GetEnumerator() | ForEach-Object { '[' + $_.Key + '] AS [' + $_.Value + ']' }) -join ",`n    "
    $viewSql = "CREATE VIEW [erp_lectura].[$target] AS SELECT`n    $projection`nFROM [dbo].[$source];"
    $sql.Add("EXEC(N'" + $viewSql.Replace("'", "''") + "');")
    $sql.Add("EXEC sys.sp_addextendedproperty @name=N'EasySoftDiccionario', @value=N'v1', @level0type=N'SCHEMA', @level0name=N'erp_lectura', @level1type=N'VIEW', @level1name=N'$target';")
    $rollback.Add("IF OBJECT_ID(N'erp_lectura.$target', N'V') IS NOT NULL BEGIN IF NOT EXISTS (SELECT 1 FROM sys.extended_properties WHERE class=1 AND major_id=OBJECT_ID(N'erp_lectura.$target') AND minor_id=0 AND name=N'EasySoftDiccionario' AND CONVERT(nvarchar(10),value)=N'v1') THROW 51001, 'Objeto ajeno al diccionario.', 1; DROP VIEW [erp_lectura].[$target]; END;")
    $verify.Add("SELECT N'$target' AS vista, (SELECT COUNT_BIG(*) FROM [dbo].[$source]) AS filas_origen, (SELECT COUNT_BIG(*) FROM [erp_lectura].[$target]) AS filas_vista;")
    $verify.Add("IF (SELECT COUNT_BIG(*) FROM [dbo].[$source]) <> (SELECT COUNT_BIG(*) FROM [erp_lectura].[$target]) THROW 51002, 'Diferencia de filas: $target', 1;")
    $verify.Add("IF (SELECT COUNT(*) FROM sys.columns WHERE object_id=OBJECT_ID(N'erp_lectura.$target')) <> $($m.Fields.Count) THROW 51003, 'Diferencia de columnas: $target', 1;")
    foreach ($pair in $m.Fields.GetEnumerator()) {
        $verify.Add("IF NOT EXISTS (SELECT 1 FROM sys.columns s JOIN sys.columns v ON v.object_id=OBJECT_ID(N'erp_lectura.$target') AND v.name=N'$($pair.Value)' AND v.system_type_id=s.system_type_id AND v.max_length=s.max_length AND v.precision=s.precision AND v.scale=s.scale AND v.is_nullable=s.is_nullable WHERE s.object_id=OBJECT_ID(N'dbo.$source') AND s.name=N'$($pair.Key)') THROW 51004, 'Tipo o alias distinto: $target.$($pair.Value)', 1;")
    }
    if ($source -like 'AP*' -and $mapping[$source].Module -eq 'facturacion_electronica') {
        for ($i=$sqlStart; $i -lt $sql.Count; $i++) { $apSql.Add($sql[$i]) }
        for ($i=$rollbackStart; $i -lt $rollback.Count; $i++) { $apRollback.Add($rollback[$i]) }
        for ($i=$verifyStart; $i -lt $verify.Count; $i++) { $apVerify.Add($verify[$i]) }
    }
}
$end = "COMMIT TRANSACTION;`nEND TRY`nBEGIN CATCH`nIF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;`nTHROW;`nEND CATCH;"
$sql.Add($end)
$apSql.Add($end); $apRollback.Add($end)
$rollback.Add('-- Se conserva el esquema: podria haber existido antes de esta instalacion.')
$rollback.Add($end)
$sql | Set-Content (Join-Path $folder '001-vistas-descriptivas.sql') -Encoding utf8
$rollback | Set-Content (Join-Path $folder '001-revertir-vistas-descriptivas.sql') -Encoding utf8
$verify | Set-Content (Join-Path $folder '001-verificar-vistas-descriptivas.sql') -Encoding utf8
Write-Output "Inventario: $($tables.Count) tablas y $($columns.Count) campos. Primera capa: $($mapping.Count) vistas y $(@($columnRows | Where-Object campo_descriptivo).Count) campos."
$apSql | Set-Content (Join-Path $folder '003-ampliar-numeracion-electronica.sql') -Encoding utf8
$apRollback | Set-Content (Join-Path $folder '003-revertir-numeracion-electronica.sql') -Encoding utf8
$apVerify | Set-Content (Join-Path $folder '003-verificar-numeracion-electronica.sql') -Encoding utf8
