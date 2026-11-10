# Servicio compartido de facturación electrónica
Investigación y propuesta · 9 de noviembre de 2026.

## Base existente y primer hito

Usar [Facturacion](../Facturacion/README.md) como motor común .NET 10. Ya genera la clave y el XML, valida XSD, firma XAdES-BES, persiste el secuencial y procesa recepción y autorización SOAP. Es local, de una sola instancia, con SQLite, un emisor configurado a la vez y firma en memoria. Las [pruebas previas](../Facturacion/VERIFICACION.md) verificaron firma local y recuperación simulada; falta una factura realmente autorizada en certificación. [TimbradoSRI](facturacion-electronica-sri.md) queda como referencia histórica; el motor actual evita heredar sus dependencias y la desactivación de TLS.

El [SRI publica la ficha 2.34 y los XSD oficiales](https://www.sri.gob.ec/facturacion-electronica). En el esquema offline se genera la clave de acceso antes de transmitir; el SRI exige [transmisión inmediata desde el 1 de enero de 2026](https://www.sri.gob.ec/detalle-noticias?idnoticia=1239&marquesina=1). La cola debe despachar al persistir y servir para recuperar fallos. Una solicitud aceptada por nuestra API o una recepción `RECIBIDA` no prueban autorización. El servicio solo mostrará «Autorizada» cuando verifique y conserve la respuesta de autorización para el XML enviado. Certificación no tiene validez tributaria.

## Referencias de mercado

| Plataforma | Capacidades documentadas | Aplicación a EasySoft |
| --- | --- | --- |
| [Ecuafact](https://docsapi.ecuafact.com/) | JSON con idempotencia y 202, sandbox, contexto de emisores, consulta o webhook, XML/RIDE, SDK y seis tipos de comprobante. | Modelo para el contrato común y ejemplos de integración. |
| [Facturón](https://facturon.ec/docs/api) | Eventos de autorización, rechazo y fallo técnico, webhooks firmados con HMAC y descarga de RIDE. | Notificar cambios y distinguir errores técnicos de rechazos fiscales. |
| [Faktur](https://faktur.com.ec/docs/) | Credenciales por empresa o punto de emisión, permisos, operación síncrona o asíncrona, reintentos y entrega por correo. | Limitar series por credencial y mostrar intentos. Preferir asincronía para no bloquear la venta. |
| [Facturador SRI](https://www.sri.gob.ec/facturacion-electronica) | Generación, firma, transmisión, RIDE y notificación por correo desde una aplicación web. | Referencia para el flujo del operador y la entrega al comprador. |

La comparación describe capacidades publicadas; no mide costos, rendimiento ni disponibilidad.

## Contrato propuesto para las apps

- Cada app conserva su venta, una referencia estable y la intención de emitir. Su servidor llama por HTTPS a una API REST versionada. Una app instalada que pueda quedar sin red guarda la solicitud en su almacenamiento local y la despacha al recuperar conexión, con estado visible y alerta; si dispone de base transaccional, guarda venta e intención en la misma transacción. No distribuir credenciales compartidas en aplicaciones cliente.
- El servicio fiscal valida y asigna secuencial y clave en una transacción. `POST /v1/facturas` devuelve 202 con ID de seguimiento; `GET /v1/comprobantes/{id}` devuelve estado, códigos, historial y enlaces a artefactos disponibles. Son rutas propuestas; la consola actual usa `/api`. La app reusa la misma clave de idempotencia tras un timeout; datos distintos con esa clave devuelven 409. Restringir claves y referencias al emisor, ambiente y sistema de origen; coordinar una referencia común si dos apps pueden emitir la misma venta.
- El servicio es dueño de la numeración por RUC, ambiente, tipo, establecimiento y punto. Si otro facturador opera sobre el mismo RUC, asignar al piloto una serie coordinada antes de emitir. Separar credenciales por app, permisos por recurso y ambiente, y administración de firma de la operación de ventas. Rotar y alertar por vencimiento del certificado; guardar sus secretos fuera de la base comercial y de los registros.
- El procesador conserva XML firmado y evidencia. Ante envío incierto o código 70, consulta por la misma clave antes de considerar un reenvío; un rechazo fiscal va a corrección revisada. Si el SRI no confirma recepción, escalar a un operador con evidencia y procedimiento explícito; nunca regenerar otra clave para despejar la cola. Registrar motivo, responsable y resultado de cada intervención.
- La bandeja distingue pendiente, autorizado, rechazado y requiere revisión. Medir antigüedad del pendiente, latencia de autorización, errores por código y vencimiento de firma. Separar el estado fiscal de la generación de RIDE, correo y webhooks: reintentar esas entregas no debe emitir otra factura. Cuando se añadan webhooks, firmar cada entrega y dar a cada evento un ID para que el consumidor descarte duplicados. Mantener la consulta como respaldo.

## Orden de entrega y criterios de salida

1. **Certificación real:** usar la consola existente, un emisor habilitado y su certificado. Salida: `AUTORIZADO` real en pruebas, XML autorizado recuperable y respuesta vinculada al XML firmado. El operador carga la firma localmente.
2. **Piloto con EasySoft:** adaptar una venta realista de desarrollo y completar el ciclo en certificación. Salida: dos solicitudes repetidas para la misma venta conservan ID, clave y secuencial; un reinicio recupera pendientes; rechazo y timeout se distinguen y quedan visibles. En navegación por clic, enfocar el título y situarlo cerca del centro tras renderizar, también al reseleccionar; respetar movimiento reducido y no desplazar por actualizaciones en segundo plano.
3. **Servicio compartido:** probar dos apps, separación por emisor y permisos, numeración concurrente, respaldo y restauración; añadir XML/RIDE y alertas operativas. Evaluar SQL Server para concurrencia y operación central, manteniendo la base fiscal independiente de las ventas. Elegir alojamiento y custodia de firma antes de habilitar acceso remoto. Añadir webhooks y correo según el piloto.
4. **Ampliación:** notas de crédito y flujos de anulación tras verificar sus reglas específicas, luego retenciones, notas de débito, guías y liquidaciones según demanda. Habilitar producción solo tras validar el circuito y por petición de despliegue.

Alternativas de operación: el motor propio da control sobre la identidad fiscal, los artefactos y la recuperación; una API gestionada reduce la operación del motor, pero añade dependencia y custodia externa de datos/firma. Si se contrata un proveedor, conservar el contrato de las apps y adaptar el motor detrás de él. No usar dos motores en paralelo para emitir la misma venta ni conmutar automáticamente después de un envío incierto.
