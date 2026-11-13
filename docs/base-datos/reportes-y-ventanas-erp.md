# Reportes y ventanas del ERP

Documento de trabajo, 27 de octubre de 2026. Los nombres son propuestas para el nuevo ERP, no objetos ya renombrados ni pantallas implementadas.

## Evidencia y límites

Se revisaron `tablas.csv`, `columnas.csv`, `rutinas.csv` y referencias del código disponible. El inventario procede de la restauración del 19 de octubre. La conexión a LocalDB y su inicio fallaron durante esta revisión; no se validaron registros, SQL de las rutinas ni resultados financieros.

La estructura apunta a clientes en `DP05A110`, proveedores en `DP06A110`, cuotas en `DP05ACUO`, movimientos de cobro/aplicación en `DP05ACAB` y de pago/aplicación en `DP06ACAB`. La interpretación de estas dos últimas tablas necesita confirmar si cada fila representa una aplicación y cómo se vincula con su cabecera y documento. Ambas tienen `tipo`, `numero`, `linea`, `tipodoc`, `numdoc`, `monto`, fechas y anulación. No deben sumarse con otras tablas antes de verificar su granularidad.

Actualización posterior del 27 de octubre: se recuperó LocalDB, se revisaron las definiciones SQL y se confirmó el uso de aplicaciones y anticipos descrito en el [diccionario y transición](diccionario-y-migracion.md). Se instalaron 23 vistas descriptivas. La auditoría encontró 140 cuotas sin documento y tres discrepancias de acumulados de créditos de proveedores; estos hallazgos impiden considerar conciliada la cartera de esta copia. Las limitaciones iniciales de acceso quedan superadas, pero continúa pendiente validar los resultados financieros y completar las interpretaciones restantes.

`DP05ANC` y `DP06ANC` parecen notas de crédito de clientes y proveedores; `DP05AND` y `DP06AND`, notas de débito. `DP05ACH` y `DP06ACH` contienen instrumentos bancarios con fechas y estado; no se debe interpretar cada fila como dinero efectivamente cobrado o pagado sin conocer esos estados.

La fotografía contiene cero filas en varias tablas transaccionales, entre ellas `DP05ACAB`, `DP06ACAB`, `DP05ACH`, `DP06ACH` y `DP01AMOV`. Esto limita las pruebas de negocio con esta copia; no demuestra que los módulos no existieran en otras instalaciones.

## Primera entrega: cuentas por cobrar

| Reporte / ventana | Decisión que permite tomar | Contenido y condiciones |
|---|---|---|
| Antigüedad de cartera | A quién cobrar primero | Por cliente y documento: no vencido, vencido 1–30, 31–60, 61–90 y más de 90 días; saldo al corte y detalle por cuota. Separar anticipos y créditos a favor. |
| Estado de cuenta del cliente | Explicar exactamente la deuda | Saldo inicial, documentos, abonos, créditos, retenciones aplicadas y saldo final, con acceso al documento y a sus aplicaciones. |
| Agenda de cobros | Organizar la semana | Vencimientos de hoy, próximos 7 y 30 días, responsable y monto pendiente. No asumir que vencimiento equivale a promesa de pago. |
| Cartera por vendedor, zona y cliente | Asignar gestión y detectar concentración | Saldo, porcentaje vencido y clientes que concentran la exposición; mostrar qué dimensión es histórica y cuál viene del maestro actual. |
| Crédito disponible y excepciones | Decidir nuevas ventas a crédito | Cupo, exposición, mora y disponible. `DP05A110.credito` es candidato a cupo; confirmar su significado y qué consumos comprometen el cupo antes de calcularlo. |
| Cobros pendientes de aplicación | Corregir saldos aparentes | Abonos, anticipos y créditos sin documento aplicado o con remanentes. Requiere reconstruir las aplicaciones y sus reversos. |
| Seguimiento de cobranza | Dar continuidad a las gestiones | Contacto, compromiso, fecha prometida, responsable y resultado. Se propone registrar esta información en el nuevo ERP: no se ha identificado una fuente suficiente en el inventario. |

## Primera entrega: cuentas por pagar

| Reporte / ventana | Decisión que permite tomar | Contenido y condiciones |
|---|---|---|
| Antigüedad de obligaciones | Conocer la deuda exigible | Por proveedor, documento y vencimiento, con los mismos rangos de mora de cartera y separación de anticipos. |
| Agenda y propuesta de pagos | Elegir qué pagar y cuándo | Vencidos y próximos vencimientos, saldo, prioridad y efectivo requerido. Una propuesta no genera un pago; autorización y ejecución son pasos separados. |
| Estado de cuenta del proveedor | Resolver diferencias | Compras/deudas, pagos, notas de crédito, retenciones y saldo, con trazabilidad de aplicaciones. |
| Calendario de compromisos bancarios | Evitar faltantes de caja | Instrumentos emitidos por fecha e importe, diferenciando emitido, entregado, compensado, anulado y otros estados solo después de verificar el catálogo real. |
| Anticipos y pagos sin aplicar | Recuperar o aplicar valores | Proveedor, origen, importe entregado, aplicado y disponible; mantenerlos separados de las obligaciones. |
| Concentración y dependencia de proveedores | Reducir exposición operativa | Participación de cada proveedor en compras y deuda, vencimientos y condiciones pactadas; las condiciones históricas requieren fuente documental. |
| Posibles facturas duplicadas | Revisar pagos repetidos | Comparar proveedor/identificación, tipo, serie, número e importe; presentar alertas para revisión, sin eliminar ni bloquear automáticamente por coincidencia. |

## Reportes transversales

| Área | Reporte | Valor y requisito |
|---|---|---|
| Tesorería | Flujo de caja previsto a 13 semanas | Escenarios de cobros probables, pagos, nómina y otros compromisos; separar previsión de saldo bancario conciliado. Requiere fuentes de compromisos y reglas explícitas de probabilidad. |
| Contabilidad | Conciliación de auxiliares contra mayor | Comparar cartera y proveedores con sus cuentas contables a la misma fecha; abrir las diferencias hasta el documento/asiento. Confirmar integración y signos de `DP01AMOV`. |
| Contabilidad | Balance de comprobación y mayor por cuenta | Saldos iniciales, movimientos y saldos finales; confirmar reglas de débito/crédito, cierres y saldos de apertura. `DP01A110` parece el plan contable; la tabla `cuentas` contiene una correspondencia ANTIGUA/NUEVA y no debe confundirse con él. |
| Ventas | Ventas netas y margen por producto/cliente/vendedor | Descontar devoluciones y notas; costo histórico al momento de venta. No sustituirlo por el costo actual del maestro. |
| Inventario | Existencias, valoración y kardex por bodega | Entradas, salidas, saldo y costo, con trazabilidad documental; confirmar signos y método de valoración. `DP03AMOV` contiene cantidades, costos y bodega. |
| Inventario | Productos sin movimiento y necesidad de reposición | Antigüedad desde el último movimiento válido, cobertura, mínimos/máximos y demanda. Distinguir existencias físicas, reservas y disponible. |
| Inventario | Trazabilidad por lote | Movimientos y saldos por lote; `dp03asal2` y `DP03AMOV` tienen lote. No prometer caducidades hasta identificar una fecha de vencimiento vinculada al lote. |
| Facturación electrónica | Comprobantes pendientes, rechazados y anulados | Estado, error, clave de acceso y autorización; confirmar el significado de los estados y el origen de la respuesta en `APCabFac` y tablas relacionadas. |
| Control | Documentos y aplicaciones inconsistentes | Huérfanos, sobreaplicaciones, referencias duplicadas, anulados con saldo y fechas incompatibles; reportar evidencia para revisión. |

No se incluyen todavía indicadores normativos ni reglas tributarias actuales: requieren verificar la normativa aplicable cuando se implemente el módulo.

## Reglas para resultados confiables

1. Todo reporte financiero debe mostrar empresa, fecha de corte, moneda, filtros y fecha de generación. Confirmar cómo se separan empresas en esta instalación; no asumir que un número documental es único globalmente.
2. Reconstruir el saldo al corte con saldo de apertura conciliado, documentos y aplicaciones vigentes a esa fecha. No usar directamente `balance` del maestro para cortes históricos. La semántica de cada tipo determinará el signo de notas, retenciones y reversos.
3. Antigüedad se calcula por vencimiento de la cuota pendiente; el documento se utiliza cuando no existe calendario de cuotas y la regla de vencimiento está confirmada. Una deuda que vence el día del corte tiene cero días de mora. Una fecha desconocida va en un grupo visible, sin inventar vencimientos.
4. Un documento anulado después del corte puede haber estado vigente en el corte. Se necesitan fecha efectiva y reversos; una bandera actual de anulación por sí sola no reconstruye el pasado. Si falta ese historial, mostrar la limitación y restringir el reporte.
5. Distinguir fecha de documento, aplicación, registro y compensación. Un cheque pendiente no es efectivo conciliado. Una retención no es un cobro en efectivo. No duplicar la reducción de deuda al registrar el instrumento y su compensación.
6. Consolidar por separado cada origen antes de unir cabecera, detalles, cuotas y aplicaciones. Evitar multiplicar importes al cruzar relaciones de uno a muchos.
7. Mantener anticipos, créditos no aplicados y obligaciones identificables; mostrar deuda bruta, créditos disponibles y posición neta sin ocultar partidas.
8. Usar precisión decimal y una política de redondeo documentada. No mezclar monedas ni comparar importes sin confirmar la moneda y, cuando corresponda, tipo de cambio y fecha.
9. Si no puede reconstruirse el saldo, mostrar «datos insuficientes»; cero significa un resultado calculado, no ausencia de información.

## Ventanas que vamos a crear

Orden propuesto, sujeto a validar fuentes y reglas antes de implementar:

1. **Explorador de datos y diccionario:** nombre anterior/nuevo, descripción, módulo, evidencia y dudas pendientes. Punto de partida para el cambio de nombres de tablas y campos.
2. **Clientes y condiciones de crédito:** ficha general, contactos, condiciones, cuentas contables y documentos asociados.
3. **Cuentas por cobrar:** cartera al corte, antigüedad y filtros; acceso al estado de cuenta, documento, cuotas y aplicaciones.
4. **Registro y aplicación de cobros:** selección de deudas/cuotas, distribución, anticipos, retenciones e instrumentos; validaciones antes de confirmar.
5. **Gestión de cobranza:** agenda, compromisos y seguimiento.
6. **Proveedores y condiciones de pago:** ficha general, condiciones y cuentas contables.
7. **Cuentas por pagar:** obligaciones al corte y acceso al estado de cuenta y documentos.
8. **Planificación y aplicación de pagos:** propuesta por vencimiento, revisión, aprobación, registro y aplicación, con permisos por función.
9. **Tesorería y conciliación bancaria:** compromisos, instrumentos, extractos y conciliación. Confirmar disponibilidad de extractos y movimientos bancarios antes de diseñar su importación.
10. **Inventario:** productos, bodegas, existencias, kardex y lotes; reservas como vista separada del saldo físico.
11. **Contabilidad:** plan de cuentas, asientos, mayor, balance y conciliación de auxiliares.
12. **Centro de reportes:** filtros guardados, vistas de detalle y exportación coherente con lo mostrado.

En todas estas ventanas: al abrir, cambiar o volver a seleccionar una sección, centrar visualmente el título o primer contenido relevante después del renderizado y darle foco accesible sin activar controles ni abrir el teclado. Respetar movimiento reducido y cabeceras fijas. No desplazar por escritura ni actualizaciones de fondo. Verificar también apertura del detalle y retorno a resultados preservando filtros y contexto.

## Mejoras justificadas y validación previa

| Hallazgo | Mejora | Qué falta comprobar |
|---|---|---|
| 262 tablas y solo 55 claves primarias; sin claves foráneas declaradas según el inventario | Definir identidad y relaciones explícitas, comenzando por documentos, cuotas y aplicaciones | Unicidad real, claves compuestas, huérfanos y dependencias; no agregar restricciones a ciegas. |
| Saldos en maestros, tablas mensuales y movimientos | Definir movimientos y aperturas como origen conciliable; tratar acumulados como derivados cuando se confirme su función | Rutinas de recálculo, cierres, historia disponible y diferencias actuales. |
| Campos `saldo00` a `saldo12` en tablas de saldos | Evaluar saldos por período en filas para facilitar consultas y control | Significado de `00`, ejercicio, costo y rendimiento; no transformar sin reconciliar resultados. |
| Columnas numeradas de impuestos y pagos en `APCabFac` y detalle | Evaluar colecciones hijas de impuestos y condiciones de pago en el modelo nuevo | Si las tablas heredadas son una instantánea de emisión/XML que debe conservarse como evidencia. |
| Maestros de clientes con campos generales mezclados con datos educativos y otros sectores | Separar información común de extensiones por actividad | Uso real de los campos, instalaciones y obligaciones de conservación. |
| Nombres breves o ambiguos como `tipo`, `codigo`, `balance` y `aplicado` | Diccionario contextual y nombres descriptivos en español, sin tildes en identificadores | Lecturas/escrituras de código, rutinas, reportes y significado por tabla. Un mismo nombre no implica una misma función. |

## Pruebas de aceptación de los reportes financieros

- Una factura con dos cuotas y un abono parcial no multiplica importes; cada cuota cae en su rango correcto.
- Un cobro posterior al corte no reduce el saldo histórico; una anulación posterior respeta la vigencia anterior si existe evidencia temporal suficiente.
- Nota de crédito parcial, anticipo no aplicado, retención y cheque pendiente conservan su trazabilidad y efecto correcto sin duplicarse.
- El total por cliente/proveedor coincide con el detalle; los totales de rangos coinciden con el pendiente clasificado.
- Auxiliares y mayor se concilian o muestran diferencias explicables, con tolerancia de redondeo explícita.
- Una empresa, tipo o serie no se cruza con otra por compartir un número de documento.
- Los filtros y la exportación producen los mismos importes y la navegación cumple la preferencia de foco y desplazamiento.

## Próximos pasos del diccionario y renombrado

El renombrado físico sigue pendiente. Primero recuperar acceso a la copia local y leer definiciones de rutinas, vistas, SQL de reportes y dependencias externas. Completar una correspondencia por cada tabla/campo, distinguiendo significado verificado, inferido y desconocido. Preparar migración y reversión y comprobar consumidores antes de ejecutarlas. Este documento no cambia objetos SQL ni convierte una inferencia en una definición definitiva.

## Ampliación AP y puerta de entrada a reportes definitivos

La [investigación AP/cartera](ap-y-cartera-investigacion.md) distingue ausencia demostrada de historial de causas históricas no confirmadas. Priorizar diagnóstico de integridad y consulta de numeración electrónica; los reportes financieros definitivos esperan aplicaciones, cabeceras e historial de reversos contrastados. La nueva capa alcanza 29 vistas / 332 alias y no permite aún traducir estados electrónicos ni sumar AP a ventas/cartera. Los riesgos de concurrencia en sp_secuenciaCE y los filtros distintos de sp_06nc/spWW_CuotasDOC requieren pruebas con fuentes completas antes de implementar emisión o cálculos.
