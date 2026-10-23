# Evaluación de flujos

Revisión del código y ejecución local de `tools/verify.ps1`. Las 73 comprobaciones
ejecutan los módulos reales de seguridad, datos y servicio de impresión. La cola,
la consulta del servicio y la impresión se sustituyen por dobles. No se abrió una
conexión SQL ni se imprimió. Esto no constituye una prueba integral del restaurante.

## Cobertura automatizada

| Flujo | Casos verificados |
| --- | --- |
| Acceso administrativo | Sal aleatoria, clave correcta/incorrecta/vacía/nula, credenciales corruptas, límites de iteraciones, cuatro fallos, reinicio del contador tras acceso, bloqueo al quinto fallo y acceso tras caducar |
| Configuración SQL | Variable externa, fallback, entorno vacío, ausencia de servidor/base, rechazo de configuración externa inválida, timeout de conexión |
| Construcción SQL | Texto malicioso preservado como valor, identificadores inválidos, lista incompleta/desbordada, parámetros repetidos y consecutivos, NULL, decimal y timeout del comando |
| Recuperación de lote | Una llamada AddFormat inválida no altera los parámetros de las sentencias válidas siguientes |
| Cola de impresión | Comanda y prefactura, errores de consulta y documento, continuidad tras ambos tipos de fallo de impresión, IDs inválidos, tipo desconocido, cola vacía y ausencia de consultas después de detener el servicio |
| Intervalos | Ausente, vacío, negativo, cero, no numérico, desbordamiento, mínimo y valor válido |

Se corrigieron tres defectos cubiertos por estos casos: credencial nula que lanzaba
NullReferenceException; salto de línea final aceptado en identificadores SQL por
el ancla `$`; y parámetros huérfanos después de un formato de lote inválido.

Las pruebas de caducidad manipulan el estado privado del limitador y lo restauran;
no esperan un minuto. Las del servicio invocan ciclos síncronos: no demuestran
ausencia de carreras entre hilos ni coordinación entre procesos.

## Hallazgos pendientes de los flujos de negocio

1. **Cocina, prioridad alta:** `ControlesUsuario/Orden.vb`, `representar`, solo
   busca consumos que desaparecieron cuando la consulta devuelve alguna fila.
   Si devuelve cero, mantiene controles antiguos y no dispara la finalización de
   la orden vacía. Reproducir: cargar una orden, finalizar o retirar todos sus
   consumos desde otro cliente y refrescar; debe desaparecer sin intervención.
2. **División de cuentas, prioridad alta:** `SplitCuenta.vb`, `TotalFacturaSelect`,
   admite diferencias de hasta 1 entre el total inicial y el repartido y termina
   el proceso con `Environment.Exit(-1)` si se supera. Debe definirse la precisión
   monetaria y verificarse conservación del total, especialmente con cantidades
   fraccionarias y repartos repetidos. El manejo de la diferencia debe preservar
   el trabajo del usuario.
3. **Anulación de prefactura, prioridad alta:** `SplitCuenta.vb`, `cmdDelete_Click`,
   continúa eliminando el ambiente de la interfaz cuando `SDSP_AnulaPreFactura`
   devuelve un resultado distinto de 1. La base y la pantalla pueden divergir.
   Simular rechazo de anulación: la prefactura debe permanecer visible.
4. **Proformado individual, prioridad media:** `cmdGP1_Click` continúa hacia
   `SDSP_Prefactura_a_Proforma` después de `cmdGrabar1.PerformClick()` sin verificar
   que la prefactura haya quedado grabada. Con ambiente vacío, el guardado avisa
   pero no establece un ID válido. Debe impedirse proformar en ese estado.

Estos hallazgos provienen de inspección estática; no se modificaron las pantallas
ni se ejecutaron procedimientos de negocio contra una instalación.

## Validación de integración requerida

Usar una copia de la base con sus procedimientos almacenados y dos clientes.

| Flujo revisado | Validación pendiente |
| --- | --- |
| Abrir/guardar cuenta (`Pedido.GuardarCuenta`) | Dos clientes sobre la misma mesa; identidad y alias coherentes; fallo al asociar mesas revierte cabecera y relaciones |
| Agregar consumo (`Pedido.AgregarConsumo`) | Cantidades/precios fraccionarios, comentario con apóstrofes, filas afectadas y recarga del total |
| Comandar (`Pedido.comandar`) | Cabecera y detalles atómicos; fallo intermedio revierte; impresión posterior al commit; reintento sin duplicar consumos |
| Cocina (`Orden.representar`) | Actualización entre clientes, retirada del último consumo, orden vacía y estados finales |
| Dividir/prefacturar (`SplitCuenta`) | Conservación de cantidad/importe, fracciones, guardar una/todas, fallo en segundo detalle revierte todo, anulación rechazada mantiene pantalla |
| Proformar y cerrar (`Pedido.CerrarCuenta`) | Consumos no finalizados impiden cierre; error del procedimiento revierte estado; no generar proforma de prefactura inexistente |
| Impresión cliente/servicio (`FUGSD`) | Exclusión con sp_getapplock, marca documento solo después de imprimir todas las cocinas, reintento tras fallo y validación física de copias/márgenes |
| Migración de PIN | Primera carga migra y limpia valor anterior atómicamente; segunda carga conserva credencial; fallo SQL revierte ambas escrituras |

La revisión observa transacciones en guardado, comandas, prefacturas y cierre,
pero sin esquema/procedimientos de una base de pruebas no verifica su aislamiento,
enlistamiento efectivo, rollback ni comportamiento concurrente.
