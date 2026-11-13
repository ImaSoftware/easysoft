# Numeración electrónica AP e investigación de cartera

Revisión del 27 de octubre de 2026 sobre `EasySoft_Patricks_Dev`. Consultas reproducibles en `004-investigar-cartera-y-ap.sql` y resultados agregados en `resultado-investigacion-cartera-y-ap.txt`. No se modificaron registros de negocio ni se ejecutaron rutinas de aplicación o numeración.

## Cobertura respaldada por rutinas

La única rutina de la fotografía SQL que menciona las cabeceras AP es `dbo.sp_secuenciaCE`. Se revisó su definición completa local en `.vs/EasySoft/Database/definiciones-rutinas.csv`. Las coincidencias de `dependencias-textuales.csv` siguen siendo candidatas, no un inventario completo de consumidores.

| Rama de la rutina | Tabla | Vista en erp_lectura | Evidencia concreta |
|---|---|---|---|
| FE, comentario FACTURA | APCabFac | facturas_electronicas_numeracion | Lee conseFactu y comprueba estab+ptoemi+secuencia |
| CE, comentario Credito Electronico | APCabCre | notas_credito_electronicas_numeracion | Lee conseCredi y comprueba la misma identidad |
| DE, comentario Debito Electronico | APCabDeb | notas_debito_electronicas_numeracion | Lee conseDebit y comprueba la misma identidad |
| GE, comentario Guia de Remision | APCabGui | guias_electronicas_numeracion | Lee conseGuia y comprueba la misma identidad |
| RE, comentario Retencion | apCabRet | retenciones_electronicas_numeracion | Lee conseRete y comprueba la misma identidad |
| Todas | apPtoEmi | puntos_emision_electronica | Filtra ptoestab y ptoemi; lee e incrementa los cinco consecutivos |

Las cabeceras publican únicamente `estab`, `ptoemi` y `secuencia`, con alias `codigo_establecimiento`, `codigo_punto_emision` y `numero_secuencial`. La configuración publica `ptoestab`, `ptoemi` y cinco consecutivos. Son 22 alias nuevos: total 29 vistas / 332 alias sobre el mismo inventario de 262 tablas / 4.210 campos. La evidencia respalda la numeración, no que una fila esté autorizada, vigente o constituya una deuda. No sumar AP a DPINVCAB como ventas adicionales.

La rutina incrementa el consecutivo antes de comprobar duplicados y devuelve la secuencia. Su definición no contiene una transacción explícita ni un bloqueo de asignación; esto requiere revisar las transacciones de sus llamadores y probar concurrencia antes de reutilizarla. Además, el valor predeterminado de @xTipo es FA, pero las ramas reconocen FE, RE, GE, DE y CE: una invocación que omita el tipo no entra en esas ramas. Son riesgos estáticos comprobados, no fallos de producción demostrados; no se cambió la rutina.

Hay 89 filas de factura, 2 de crédito, 72 de retención y ninguna de débito/guía. La identidad candidata por clase/establecimiento/punto/secuencial no tiene grupos duplicados en esta copia. No acredita unicidad por empresa/ambiente en otras instalaciones. Las tablas AP no publican en esta ampliación emisor, ambiente, importes, estados ni autorizaciones: se necesita evidencia de escritura y lectura y contraste con XML/respuestas anonimizados. Tampoco se publican APCIAS ni APUsersWEB, que contienen campos de credenciales. Detalles, destinatarios y catálogos AP permanecen pendientes; no se les asigna significado fiscal por prefijo.

## Cuotas sin cabecera: causa demostrable y límite

Las 140 cuotas corresponden a 40 pares tipo/número diferentes; ninguno tiene cabecera. Tampoco hay coincidencias por número solo ni por concatenación de tipo y número, descartando esas dos variantes simples de enlace en esta fotografía. Los vencimientos van del 21/07/2016 al 19/10/2017; las únicas dos cabeceras tienen fecha de transacción 05/04/2018. Esas fechas son dimensiones distintas: el contraste no prueba por sí solo una depuración ni su fecha.

La causa inmediata demostrable es ausencia de cabeceras relacionadas en la copia. No hay evidencia suficiente para atribuirla a borrado, importación, restauración selectiva o error de generación de cuotas. En las definiciones disponibles no se encontraron instrucciones directas INSERT/DELETE de DP05ACUO; eso no descarta SQL dinámico ni consumidores externos. Para determinar la causa histórica: revisar procedencia y procesos de limpieza de bdpatricks.bak, localizar otro respaldo del mismo período y empresa y comparar cabeceras/cuotas, y recuperar los escritores del calendario. Conservar ambos pares como columnas separadas, sin rellenar cabeceras ni eliminar cuotas.

`fxEstadoCuota` usa LEFT JOIN con cabecera: su CASE puede clasificar una cuota huérfana según importes sin exponer la falta de cabecera. `VistaCuotas` depende de un INNER JOIN con documento y puede ocultar estas filas. `spWW_CuotasDOC` suma DP05ACAB sin filtro de anulación y puede ofrecer un saldo diferente al de consultas que sí excluyen anuladas. Estas diferencias se sostienen en las definiciones; no se probaron escenarios con aplicaciones reales porque la copia carece de ellas. La nueva ventana de diagnóstico deberá mostrar huérfanos antes de cualquier estado de cobranza calculado.

## Créditos de proveedor: acumulado e historial ausente

Hay cinco créditos, ninguno anulado; tres tienen aplicado distinto de cero. DP06ACAB está vacía. Las tres discrepancias persisten al comparar con anulada=0, nulos tratados como vigentes y filtro adicional de proveedor. Por tanto, en esta copia la diferencia no se explica por elegir uno de esos filtros.

`sp_06AutApliCre` inserta en DP06ACAB y aumenta DP06ANC.aplicado, actualiza DPINVCAB.abono y después genera el asiento. Su definición no contiene BEGIN TRANSACTION explícito, no valida el saldo disponible del crédito y actualiza el crédito por tipo+numero, sin proveedor. Un error posterior puede dejar trabajo parcial si el llamador no aporta atomicidad; una llamada externa puede envolverlo en transacción. No hay historial que pruebe que esta ruta causó las tres diferencias; tampoco una ejecución parcial explica por sí sola la ausencia actual de todas las aplicaciones, pues el INSERT precede al UPDATE.

`sp_06nc` presenta un aplicado recalculado desde DP06ACAB con anulada=0, sin proveedor; no utiliza DP06ANC.aplicado para ese resultado. Podría informar cero mientras el acumulado conserva valores. Antes de unificar criterios se debe auditar unicidad por empresa/proveedor, semántica de NULL en anulada, reversos y llamadores. No ejecutar la rutina automática para intentar cuadrar la copia.

Causa inmediata: el acumulado no tiene detalle disponible que lo respalde. La causa histórica permanece abierta. Recuperar aplicaciones, anulaciones, asientos y registros de importación del mismo origen/período; comparar con auxiliar emitido en ese momento. No recalcular a cero el acumulado ni inventar aplicaciones. Los anticipos continúan separados de notas por su configuración real. DP01AMOV.tipo/refer siguen siendo referencia documental, no débito/crédito.

## Migración y compatibilidad

`001-*` representa ahora la instalación completa de 29 vistas en una base sin ellas. Para una copia con las 23 vistas anteriores, usar exclusivamente `003-ampliar-numeracion-electronica.sql`; `003-revertir-numeracion-electronica.sql` revierte solo las seis nuevas. No hace falta quitar las vistas de cartera para ampliar AP. Ambos caminos son transaccionales, restringidos a la copia de desarrollo y rechazan objetos existentes al instalar; la reversión exige la marca EasySoftDiccionario=v1. No cambiar permisos ni sustituir consumidores heredados en esta fase.

```powershell
./tools/Build-ErpDictionary.ps1
sqlcmd -S '(localdb)\MSSQLLocalDB' -E -d EasySoft_Patricks_Dev -b -i docs/base-datos/003-ampliar-numeracion-electronica.sql
sqlcmd -S '(localdb)\MSSQLLocalDB' -E -d EasySoft_Patricks_Dev -b -i docs/base-datos/001-verificar-vistas-descriptivas.sql
sqlcmd -S '(localdb)\MSSQLLocalDB' -E -d EasySoft_Patricks_Dev -b -i docs/base-datos/004-investigar-cartera-y-ap.sql
```

Se ejecutaron ampliación, verificación de AP, reversión de AP, regresión de las 23 vistas anteriores y reinstalación; luego comparación de recuentos y metadatos de los 332 alias. La regresión está registrada en `resultado-regresion-vistas-23.txt`. La verificación de tipos cubre longitud, precisión, escala y nulabilidad; no constituye conciliación financiera ni prueba del circuito de emisión. No se envió ningún comprobante ni se consumieron secuenciales.

## Ventanas y reportes siguientes

1. Diagnóstico de integridad: cuotas sin cabecera, acumulados sin aplicaciones y diferencias de criterio heredado; mostrar recuento, fuente, fecha de extracción y enlace al registro autorizado, sin acciones automáticas de corrección.
2. Numeración electrónica: clase, establecimiento, punto y secuencial; separar identidad comercial de identidad electrónica hasta comprobar su vínculo. No mostrar autorizado/rechazado a partir de una interpretación provisional de estado.
3. Bandeja de emisión futura: confirmar emisor/ambiente, estados y transiciones, respuesta y fechas, referencia comercial, XML y RIDE antes de habilitar reintentos. Priorizar recuperación de consumidores y concurrencia/idempotencia de numeración. La bandeja no genera otra venta ni duplica cartera.
4. Reportes definitivos de antigüedad, estados de cuenta y conciliación con mayor: bloqueados por historial faltante y reglas de reverso/corte no resueltas. Se permite un diagnóstico de la fotografía, explícitamente sin saldos conciliados.

Cada clic que abra o reseleccione sección, pestaña, documento o resultados llevará tras renderizar el título o primer contenido cerca del centro visible y foco accesible en un elemento no editable, sin activar controles ni abrir teclado. Compensar cabeceras fijas, respetar prefers-reduced-motion y conservar filtros al regresar. Escritura y actualización de estados en segundo plano no desplazan ni roban foco. Verificar estos escenarios cuando se implementen flujos. No se construyen pantallas ni se cambia la elección tecnológica en este bloque.

También se verificó el rechazo de instalación repetida y de reversión con marca ajena: `resultado-protecciones-ap.txt`. La marca ajena se simuló dentro de una transacción externa revertida; después se comprobaron las 29 marcas v1 y todas las vistas. Los ocho artefactos del generador se regeneraron con hashes idénticos. No se probó concurrencia de sp_secuenciaCE ni se ejecutó dicha rutina.
