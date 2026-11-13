# Especificación inicial de ventanas de cartera

Estado: diseño funcional para implementar después de reconciliar las fuentes. No hay nuevas pantallas ni reportes financieros implementados en esta entrega.

## Cuentas por cobrar

Entrada: menú Finanzas → Cuentas por cobrar. Encabezado «Cuentas por cobrar» con fecha de corte y empresa visibles. Filtros de cliente, vendedor, zona, estado y vencimiento; los códigos de estado no se convierten a etiquetas sin catálogo confirmado.

La consulta se inicia con «Consultar»; escribir filtros no mueve la vista. Una vez renderizados los resultados, llevar el título «Cartera al [fecha]» cerca del centro visible y darle foco programático con `tabindex=-1`, sin enfocar inputs. Si hay movimiento reducido, usar desplazamiento instantáneo. Compensar la altura de la cabecera fija. Volver a pulsar la sección actual repite esta navegación.

Resumen: deuda bruta, vencida, no vencida, anticipos/créditos disponibles y posición neta. Si la reconstrucción histórica no es posible, mostrar el motivo en lugar de valores aparentemente definitivos. Un conjunto vacío muestra «Sin documentos para estos filtros», no un error.

Tabla: cliente, tipo/serie/número de documento cuando exista cada dimensión, emisión, vencimiento, cuota, importe, aplicaciones al corte, saldo y días de mora. Rangos: no vencido, 1–30, 31–60, 61–90 y más de 90. Fechas desconocidas se muestran aparte. Una deuda vence hoy con cero días de mora.

Acciones por fila: «Ver documento», «Ver aplicaciones» y «Estado de cuenta». El detalle debe explicar de dónde salió cada saldo. Desde el detalle se vuelve al mismo conjunto de resultados con filtros, selección y posición conservados; el foco vuelve al disparador o a la fila si sigue existiendo. Las actualizaciones de fondo no desplazan ni roban el foco.

La exportación incluye filtros, corte y moneda y coincide con el resultado consultado. No se exportan contactos ni identificaciones personales por defecto.

## Cuentas por pagar

Entrada: Finanzas → Cuentas por pagar. Comparte navegación, filtros, fecha de corte, reglas de accesibilidad y detalle con cartera, usando proveedor y sus obligaciones.

Resumen: deuda bruta, vencida, próximos 7/30 días y anticipos/créditos disponibles. Tabla: proveedor, documento, emisión, vencimiento, importe, pagos aplicados y saldo. Acciones: «Ver documento», «Ver aplicaciones», «Estado de cuenta» y «Agregar a propuesta de pago».

«Propuesta de pago» mantiene la selección explícita, permite registrar prioridad y justificación, muestra total propuesto y fecha planeada. Guardar una propuesta no registra una aplicación, no emite un cheque ni modifica el saldo. Aprobar y ejecutar necesitan permisos diferenciados cuando se implemente el flujo.

## Estado de cuenta y aplicaciones

Encabezado con cliente/proveedor y período. Secciones: saldo inicial conciliado, débitos, créditos/aplicaciones y saldo final. Separar emisión, aplicación y compensación bancaria. Las notas de crédito y los anticipos se identifican por su configuración real, no solo por la tabla que los contiene.

Detalle de aplicación: comprobante que la registra, documento destino, cuota cuando exista, instrumento/documento de origen, importe, fecha, usuario, estado y reverso. Nunca ofrecer borrar una aplicación contabilizada: el diseño de corrección debe conservar trazabilidad y validar el período contable.

## Fuentes de la primera capa

- `erp_lectura.clientes` y `erp_lectura.proveedores`: identificación operativa y dimensiones actuales; no representan necesariamente la dimensión histórica del documento.
- `erp_lectura.documentos_comerciales`: mezcla operaciones. Clasificar con `tipos_documentos_comerciales` y validar reglas de grupo/integración, sin asumir que cada cabecera es una factura exigible.
- `erp_lectura.cuotas_documentos_clientes`: calendario contractual. Antes de usarlo, resolver cuotas sin documento.
- `erp_lectura.aplicaciones_cobros_clientes` y `aplicaciones_pagos_proveedores`: una fila puede ser una aplicación; no son resúmenes de caja y no representan necesariamente efectivo.
- Créditos, anticipos y notas de débito: fuentes adicionales; no restar a la vez el crédito original y su aplicación.

Las vistas conservan tipos y valores y no calculan saldos. Tampoco validan referencias ni sustituyen reglas contables.

## Comprobación antes de implementar

Resolver el significado de fechas de anulación alternativas, los estados de cheques y los documentos de origen/destino polimórficos. Probar casos de cuotas, anticipos, retenciones, aplicaciones parciales, reversos posteriores al corte y referencias repetidas. Verificar resultados contra auxiliares y mayor antes de presentar los totales como financieros.

## Diagnóstico previo obligatorio

La [investigación AP/cartera](ap-y-cartera-investigacion.md) concreta una ventana de integridad anterior a los saldos definitivos: 140 cuotas de 40 documentos sin cabecera y tres acumulados de créditos sin aplicaciones disponibles. La ventana mostrará fuente y limitación, sin ocultar huérfanos mediante INNER JOIN ni convertirlos automáticamente en cuotas por cobrar. Las diferencias entre criterios de anulación/proveedor de rutinas heredadas deben resolverse con historial antes de calcular saldos al corte. Aplican las mismas reglas de foco y desplazamiento a cada apertura y reselección del diagnóstico.
