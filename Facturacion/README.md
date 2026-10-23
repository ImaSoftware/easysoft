# Facturación electrónica SRI · primer circuito de certificación

Motor independiente de EasySoft, API HTTP y consola web local. Solo utiliza el ambiente de **PRUEBAS** del SRI; no contiene una ruta de producción.

**Estado:** generación XML, validación contra esquemas oficiales, firma XAdES-BES y verificación criptográfica local implementadas. Flujo de recepción/autorización probado con respuestas simuladas; conectividad HTTPS de ambos WSDL de pruebas verificada. **Todavía no existe una factura autorizada realmente por el SRI:** faltan cargar los datos y la firma del emisor. Un certificado autofirmado de las pruebas automatizadas no cumple ese requisito.

## Iniciar la consola

Requisitos: Windows, SDK .NET 10.0.401 (o parche compatible), acceso a NuGet para restaurar y conexión HTTPS a `celcer.sri.gob.ec` para emitir en pruebas. La aplicación EasySoft actual no necesita migrarse a .NET 10.

Desde PowerShell, en esta carpeta:

```powershell
./tools/Start-Pruebas.ps1
```

Abra [la consola local](http://127.0.0.1:5088). Copie en el acceso el contenido de `secrets/api-key.txt`. El script crea esa clave aleatoria y restringe las carpetas de datos y secretos a su usuario y SYSTEM. No incluya esa clave en capturas o mensajes. Detenga el servicio con Ctrl+C.

1. En **Configuración**, complete RUC, razón social, direcciones, establecimiento y punto de emisión. Indique un secuencial de pruebas que no choque con otros sistemas del mismo emisor/serie. Incluya los datos tributarios adicionales y RUC del proveedor cuando correspondan; no se deducen automáticamente del RUC.
2. Guarde el emisor. Indique la ruta absoluta de su `.p12`/`.pfx`, introduzca la contraseña y confirme que corresponde al emisor o a su representante autorizado. Cargue la firma. La clave privada y contraseña se mantienen únicamente en memoria; debe volver a cargarla tras reiniciar. No admite tokens todavía. El SRI comprobará la confianza y relación tributaria del certificado; la verificación local no sustituye ese control.
3. En **Factura de prueba**, use la fecha actual de Ecuador continental, una referencia comercial única y datos de prueba adecuados. El servicio recalcula los importes y valida el XML antes de asignar y confirmar la numeración.
4. Pulse **Firmar y enviar a pruebas**. En **Seguimiento** verá los estados, mensajes, historial y descargas de XML generado, firmado y autorizado.
5. El hito solo se considera conseguido cuando el SRI responde `AUTORIZADO`, se valida que corresponde al XML enviado y queda almacenado el XML de autorización. Una recepción `RECIBIDA`, una prueba automatizada o un estado simulado no son autorización del SRI.

La consola aplica foco accesible y desplazamiento al destino después de acciones de navegación, incluso al reseleccionar una sección; respeta movimiento reducido. Escribir y consultar estados en segundo plano no mueven la vista. El diseño se adapta mediante CSS a pantallas pequeñas; la revisión visual realizada inicialmente fue en escritorio.

## Alternativa por script/API

Los archivos en `examples/` son plantillas con marcadores, no credenciales ni facturas listas para transmitir. Copie versiones propias a `secrets/`, complete los datos y la fecha actual. Con el servicio iniciado:

```powershell
./tools/Invoke-PruebaSri.ps1 `
  -EmisorJson ./secrets/emisor.json `
  -FacturaJson ./secrets/factura.json `
  -Certificado 'C:\Firmas\emisor.p12'
```

El script solicita la contraseña de forma oculta, la envía únicamente a la API local y no la guarda. Espera hasta 180 segundos por defecto; una consulta pendiente continúa en el servicio. No cambie la referencia para resolver un timeout. Al autorizar, descarga los XML y respuestas del SRI en `artifacts/<id>/`. Retorna código 2 si no se obtiene autorización dentro de la espera o existe un rechazo/error.

API actual, todos los endpoints bajo `/api` exigen `Authorization: Bearer <clave local>`:

| Método y ruta | Función |
| --- | --- |
| `GET /api/configuracion` | Configuración del emisor y estado de carga de la firma, sin contraseña ni clave privada. |
| `PUT /api/configuracion/emisor` | Guardar un emisor/serie de esta instalación. |
| `POST /api/configuracion/firma` | Cargar `{ "ruta": "C:\\Firmas\\emisor.p12", "password": "…" }` en memoria. |
| `POST /api/facturas` | Crear solicitud con contrato de `examples/factura.json` y cabecera `Idempotency-Key` obligatoria. Devuelve 202 con ID, clave y estado. |
| `GET /api/comprobantes` | Últimas 100 solicitudes. |
| `GET /api/comprobantes/{id}` | Estado, mensajes e historial de una solicitud. |
| `GET /api/comprobantes/{id}/xml/{kind}` | Descargar `generado`, `firmado` o `autorizado`, si existe. |
| `GET /api/comprobantes/{id}/evidencia` | Respuestas SOAP recibidas, incluida evidencia de errores de protocolo. |
| `POST /api/comprobantes/{id}/reactivar` | Reintentar firma tras error local o reanudar consulta tras revisión; conserva identidad fiscal. No reenvía recepciones inciertas. |

`/health` es público en loopback y solo informa el estado técnico, no la autorización tributaria. Error de entrada: 400; falta de autenticación: 401; conflicto de idempotencia/referencia o firma pendiente: 409; archivo/comprobante inexistente: 404. Una respuesta 202 significa que la solicitud se persistió, no que está autorizada.

La consola conserva la clave de idempotencia en memoria para reintentar el mismo formulario tras un error de red. También existe una restricción única por referencia comercial, para impedir duplicados después de recargar el navegador. Las aplicaciones consumidoras deben conservar su clave de idempotencia y el ID devuelto de forma durable. Si se pierde la respuesta inicial, consulte Seguimiento antes de crear otra solicitud.

## Consistencia y recuperación

- SQLite guarda solicitud, configuración del emisor, clave de acceso, XML, historial y respuestas. Asignación de secuencial y solicitud se confirman en una misma transacción; las validaciones fallidas revierten el contador.
- La numeración se separa por RUC, ambiente de pruebas, documento, establecimiento y punto de emisión. `primerSecuencial` se aplica solo a una serie nueva, nunca reinicia el contador existente. No borre la base para reiniciar numeración ni comparta una serie con otro emisor sin coordinarla.
- Misma clave de idempotencia y mismos datos: devuelve la solicitud original. Misma clave o referencia con otros datos: conflicto. La configuración del emisor forma parte de la instantánea y huella de la solicitud.
- Un bloqueo de archivo impide dos hosts sobre la misma base. El procesador y las reactivaciones manuales se serializan. Es un despliegue de una sola instancia; no es un sistema distribuido.
- Antes de transmitir se persiste el estado incierto. Si se pierde la respuesta o se reinicia el proceso, se consulta autorización de la **misma clave**, sin volver a firmar ni enviar otra factura. También se consultan duplicados y código 70. No se modifican los bytes firmados para reintentarlos.
- Después de 30 ciclos o 24 horas sin resultado definitivo requiere revisión. **Reanudar consulta** permite otra consulta sin reenviar. Si el envío nunca llegó al SRI, esta versión prioriza no duplicar: requiere diagnóstico y un futuro flujo explícito de reenvío/corrección, no crea automáticamente otra clave.
- Un rechazo tributario es distinto de un error de transporte. La corrección de facturas rechazadas conservando su identidad fiscal no está implementada en esta entrega. El historial y la respuesta se conservan para diagnosticarla; no cree una nueva factura como corrección automática.

Datos locales: `data/issuer.json`, `data/invoices.db` y los archivos WAL/SHM de SQLite. No se guardan certificados ni contraseñas en esa base. Las carpetas `data/`, `secrets/` y `artifacts/` están excluidas de Git. Detenga el servicio antes de copiar todos los archivos de `data/` como respaldo de esta instalación.

## Compilar y verificar

```powershell
dotnet restore Facturacion.slnx
dotnet build Facturacion.slnx -c Release --no-restore
dotnet test Facturacion.slnx -c Release --no-restore
```

Las pruebas usan un certificado RSA sintético creado en memoria y respuestas SOAP simuladas claramente separadas del cliente real. Cubren vectores de clave de acceso, cálculos/precisión, XSD de factura y propiedades XAdES, alteraciones de las tres partes firmadas, concurrencia, idempotencia, rollback, reinicios, respuesta perdida después de aceptación, estados pendientes/rechazados y contrato SOAP con base64 exacto. No envían comprobantes a la red.

La firma usa canonicalización inclusiva y RSA-SHA1 por el perfil publicado del SRI 2.34. La integridad se verifica sobre el XML final usando `SignedXml`, separado del código que construye y firma. Se usan APIs públicas, sin reflexión sobre detalles internos ni código de las bibliotecas históricas GPL/LGPL. La aceptación final depende de probar el certificado y emisor reales con el SRI.

Fuentes: [SRI facturación electrónica](https://www.sri.gob.ec/facturacion-electronica), [esquemas fijados](Schemas/README.md), [Microsoft SignedXml](https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.xml.signedxml?view=windowsdesktop-10.0), [transacciones SQLite](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/transactions).

## Alcance y próximos pasos

Esta entrega admite factura nacional ordinaria XML 1.1.0 en USD, IVA 0 % y 15 %, descuentos por línea, propina y pagos. Las condiciones fiscales de cada emisor deben parametrizarse; no es un asesor que determine automáticamente el tratamiento tributario. La consola ofrece un subconjunto de las formas de pago admitidas por el contrato.

No se han implementado producción, notas de crédito/débito, retenciones, casos sectoriales, RIDE, correo, integración de ventas de EasySoft ni alojamiento remoto. La API es local para un operador confiable y una instalación; los datos históricos de emisores configurados en esa instalación son accesibles con la misma clave. Antes de exponerla a otras máquinas o empresas hacen falta autenticación por aplicación/empresa, autorización por recurso, HTTPS y aislamiento de datos. El núcleo y el adaptador SOAP ya están separados para esa evolución.

El siguiente paso para el hito es cargar el emisor y la firma mediante la consola, emitir una factura de pruebas y revisar la respuesta real del SRI. Solo entonces se podrá declarar conseguida la autorización y conectar las ventas reales de EasySoft a ese circuito.
