# Diccionario y transición de nombres

## Entrega del 27 de octubre de 2026

Se recuperó el acceso a `EasySoft_Patricks_Dev` iniciando LocalDB fuera del aislamiento que impedía acceder a su configuración. Se leyeron las definiciones SQL originales y los índices. Se instalaron **23 vistas y 310 campos descriptivos** en `erp_lectura`. No se renombraron físicamente tablas ni campos, ni se modificaron registros de negocio.

El inventario y los diccionarios cubren las **262 tablas y 4.210 campos** originales. Tener una fila en el diccionario no significa que su interpretación esté resuelta: los nombres sin evidencia suficiente quedan vacíos y su estado es `pendiente_investigacion`. Los 310 alias publicados son una primera versión revisable, basada en estructura y rutinas indicadas por tabla; no constituyen validación individual de todos los escenarios del negocio.

## Convenciones

- Español, minúsculas, palabras separadas por `_`, sin tildes en identificadores.
- `codigo_` para códigos de negocio existentes; `id_` no sustituye arbitrariamente códigos ni implica que se haya creado una clave.
- `tipo_documento` y `numero_documento` separados; no concatenarlos para definir relaciones nuevas.
- `importe_`, `porcentaje_`, `cantidad_` y `fecha_` explican la magnitud; los tipos, escalas y unidades heredados se conservan.
- Un código de estado conserva su código. No convertirlo a verdadero/falso ni asignarle una etiqueta sin confirmar todos sus valores y usos.
- Las referencias contables concatenadas conservan `referencia_` hasta entender cómo se separan tipo y número.

## Nombres principales disponibles

| Tabla heredada | Vista descriptiva en `erp_lectura` | Significado |
|---|---|---|
| `DP05A110` | `clientes` | Maestro de clientes; `empcli` se usa como nombre en los reportes. `nomcli` queda pendiente. |
| `DP06A110` | `proveedores` | Maestro de proveedores; `empresa` es el nombre del proveedor, no la empresa propietaria del ERP. |
| `DP05ACAB` | `aplicaciones_cobros_clientes` | Aplicaciones a documentos, con comprobante y línea; no una simple cabecera de recibo. |
| `DP06ACAB` | `aplicaciones_pagos_proveedores` | Aplicaciones a obligaciones de proveedores. |
| `DP05ACUO` | `cuotas_documentos_clientes` | Calendario por tipo, número y cuota. |
| `DP05ANC` / `DP06ANC` | `creditos_y_anticipos_clientes` / `creditos_y_anticipos_proveedores` | Contienen créditos que pueden actuar como anticipos según configuración; no asumir que todos son devoluciones. |
| `DP05AND` / `DP06AND` | `notas_debito_clientes` / `notas_debito_proveedores` | Documentos adicionales de deuda. |
| `DP05ACH` / `DP06ACH` | `cheques_clientes` / `cheques_proveedores` | Instrumentos con estado; su registro no demuestra compensación bancaria. |
| `DPINVCAB` | `documentos_comerciales` | Cabeceras compartidas entre operaciones; clasificar por configuración. |
| `DP03AMOV` | `documentos_comerciales_detalle` | Líneas de producto, cantidad, precio, costo, impuestos y lote. |
| `DP03ACOM` | `tipos_documentos_comerciales` | Configuración de los tipos y de su integración. |
| `DP01A110` | `cuentas_contables` | Plan contable; distinto de la tabla histórica `cuentas`. |
| `DPCABTRA` / `DP01AMOV` | `asientos_contables_cabecera` / `asientos_contables_detalle` | Cabecera y líneas de asientos. |
| `DP01ACCO` | `centros_costo` | Maestro; relación con movimientos aún por comprobar. |
| `dp03a110` | `productos` | Maestro de productos; no se interpretan todavía sus múltiples precios/factores. |
| `tbunidad` / `tbmarca` / `tbpais` | `unidades_medida` / `marcas_productos` / `paises` | Catálogos específicos. |
| `ALPTABLA` | `catalogos_generales_heredados` | Catálogos compartidos con agrupación padre y etiqueta. |

## Significados contrastados en rutinas

| Campo | Alias / interpretación | Evidencia y límite |
|---|---|---|
| `DP05ACAB.tipo`, `numero`, `linea` | Comprobante que registra la aplicación y su línea | Inserción en `sp_05AutApliCre`. La unicidad debe auditarse antes de imponer una clave. |
| `DP05ACAB.tipodoc`, `numdoc` | Documento destino cuya deuda se reduce | `sp_05P330` y `sp_05AutApliCre`. El destino puede ser de diferente clase, no solo una factura. |
| `DP05ACAB.tipopag`, `numpago` | Documento/instrumento origen de la aplicación | `sp_05P330` lo cruza con cheques y `sp_05CreDisp`/aplicación usan créditos. No llamarlo únicamente forma de pago sin considerar ese uso. |
| Campos equivalentes de `DP06ACAB` | Misma separación entre comprobante de aplicación, destino y origen | `sp_06AutApliCre`, `sp_06can` y `sp_06P350`. |
| `DP05ANC.aplicado`, `DP06ANC.aplicado` | Importe aplicado acumulado | Las rutinas de aplicación lo incrementan; compararlo con el detalle antes de usarlo como fuente autoritativa. |
| `DPINVCAB.abono` | Importe abonado acumulado | Las mismas rutinas lo actualizan. No reconstruye por sí solo el saldo a una fecha pasada. |
| `DPINVCAB.prov_cli` | Código de cliente o proveedor | Reportes de ventas/compras lo vinculan con maestros distintos. No crear una única clave foránea a clientes. |
| `DP06A110.tipo` | Tipo de persona | `sp_06P310` interpreta `N` como natural y el resto como jurídica. Esa lógica heredada no demuestra que cualquier otro valor sea válido. |
| `DP01AMOV.codmov` | Cuenta contable | Se inserta desde las cuentas del cliente/proveedor y se filtra por cuenta en `df_Saldo_cnt`. |
| `DP01AMOV.tipo`, `refer` | Tipo y número del documento de referencia | En `sp_05AutApliCre` y `sp_06AutApliCre` reciben el tipo y secuencia del comprobante de aplicación. **No representan la naturaleza débito/crédito.** |
| `DP01AMOV.importe` | Importe con signo | Esas rutinas insertan un valor positivo comentado como debe y otro negativo comentado como haber. Verificar otras rutas y cierres antes de generalizar a todo el mayor. |

## Auditoría ejecutada

Resultados reproducibles en `002-auditoria-cartera.sql` y `resultado-auditoria-cartera.txt`:

- **140 cuotas sin cabecera correspondiente en `DPINVCAB`**; son las 140 cuotas disponibles. No se borraron ni se reconstruyeron cabeceras por suposición.
- **3 créditos de proveedores** con diferencia superior a 0,01 entre acumulado aplicado y aplicaciones vigentes disponibles en la copia. Se trata de una discrepancia que investigar, no prueba suficiente para corregir el acumulado.
- No se detectaron grupos duplicados en las claves candidatas comprobadas de clientes, proveedores, documentos ni cuotas. La copia pequeña y la ausencia de varias clases de movimientos no prueban que esas claves sean suficientes para todas las empresas/instalaciones.
- Los controles ejecutados no encontraron detalles sin cabecera/producto, documentos sin tipo configurado ni créditos de proveedor sin proveedor. Los controles sobre tablas vacías son limitados.

La combinación de cuotas huérfanas, dos cabeceras comerciales y ausencia de aplicaciones sugiere una copia parcial o depurada; requiere contrastar su procedencia. No permite presentar aún una cartera histórica conciliada.

## Archivos y reproducción

- `diccionario-tablas.csv`: una fila por tabla original, propuesta de nombre, módulo, cobertura y evidencia.
- `diccionario-campos.csv`: una fila por campo original, alias cuando existe, tipo y estado de investigación. La descripción inicial se deriva del alias; esta tabla es un índice de trabajo, no una definición exhaustiva del negocio.
- `indices.csv`: fotografía de índices leída el 27 de octubre; no se crearon índices ni restricciones.
- `dependencias-textuales.csv`: 646 coincidencias tabla/rutina originales, incluyendo SQL construido en cadenas. Pueden incluir comentarios y omitir nombres construidos por fragmentos; no sustituyen un análisis completo de dependencias.
- Las definiciones SQL completas se conservaron localmente en `.vs/EasySoft/Database/definiciones-rutinas.csv`, fuera de Git; los metadatos publicados no contienen filas operativas.

Desde la raíz del repositorio:

```powershell
./tools/Build-ErpDictionary.ps1
sqlcmd -S '(localdb)\MSSQLLocalDB' -E -d EasySoft_Patricks_Dev -b -i docs/base-datos/001-vistas-descriptivas.sql
sqlcmd -S '(localdb)\MSSQLLocalDB' -E -d EasySoft_Patricks_Dev -b -i docs/base-datos/001-verificar-vistas-descriptivas.sql
```

El generador valida objetos/campos contra el inventario y rechaza identificadores inseguros y alias duplicados. No consulta SQL ni instala objetos. La instalación es transaccional, restringida a esta base de desarrollo y de primera ejecución: si las vistas ya existen falla, sin sobrescribirlas. Para sustituir esta versión, primero ejecutar `001-revertir-vistas-descriptivas.sql`, que solo admite vistas con la marca del diccionario y conserva el esquema. Se comprobó reversión y reinstalación de las vistas.

La verificación comparó recuentos de filas y nombres/tipos, longitudes, precisión, escala y nulabilidad de los 310 campos en las 23 vistas. Las vistas son proyecciones directas sin filtros, uniones ni conversiones; no incluyen todos los campos heredados y no calculan importes financieros. No se cambiaron permisos; el nombre `erp_lectura` expresa el destino de uso y no impone por sí mismo permisos de solo lectura.

Consulta de ejemplo, sin datos personales en la salida:

```sql
SELECT COUNT_BIG(*) AS cantidad_clientes
FROM erp_lectura.clientes;
```

## Renombrado físico pendiente

No basta `sp_rename`: las rutinas contienen nombres SQL y referencias construidas en cadenas; también los clientes externos y reportes pueden depender de ellos. Las vistas permiten comenzar a consultar con nombres claros mientras se prepara la transición.

Para completar el renombrado físico se debe resolver el resto del diccionario, identificar lectores y escritores externos, transformar las rutinas y SQL de reportes con revisión de cada contexto y probar en una segunda copia. No reemplazar texto globalmente: `tipo`, `codigo` o `numero` cambian de significado por tabla, y una sustitución ciega altera literales y lógica.

El siguiente bloque de investigación debe cubrir `AP*` (emisión electrónica), `DP02*` (bancos/configuración), saldos y lotes de inventario, nómina `ROL*` y restaurante `SD_*`. Los prefijos restantes no se asignarán a módulos solo por su número. Mantener las tablas auxiliares, de importación y antiguas separadas de los maestros hasta verificar su uso.
