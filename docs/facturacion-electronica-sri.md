# Evaluación de TimbradoSRI y propuesta de facturación electrónica

Fecha: 22 de octubre de 2026.

## Dictamen

Sí sirve como referencia para implementar facturación electrónica ecuatoriana. No es un componente listo para integrar: contiene varios experimentos, clientes SOAP generados y bibliotecas de terceros, sin un flujo completo de emisión demostrado. La pieza propia más amplia es `TimbradoSRI/Gustavo/proofC6/SRI_LIB.cs`; existe otra variante en `Gustavo/proofC`.

Conviene recuperar conocimiento del protocolo, contratos y casos de prueba, y construir un motor independiente de EasySoft. EasySoft será su primer consumidor; otras aplicaciones podrán consumir el mismo servicio sin depender de WinForms, COM ni de las tablas particulares de EasySoft.

El término operativo será **emisión, firma, recepción y autorización de comprobantes electrónicos**. La firma local y la recepción del SRI no sustituyen la comprobación del estado de autorización.

## Alcance y límites de la revisión

Revisión estática de proyectos, código propio principal, referencias SOAP, dependencias y licencias incluidas; contraste con la documentación oficial del SRI. No se ejecutaron los prototipos, certificados, binarios antiguos ni envíos al SRI. No se verificó criptográficamente una factura producida por este código. No se inspeccionó cada archivo del archivo histórico de incidencias ni se descomprimieron los RAR/ZIP; pueden contener material adicional.

El repositorio ya tenía cambios de otros trabajos. Esta revisión únicamente añade este documento. Las conclusiones sobre fallas históricas son diagnósticos del código disponible, no una reconstrucción confirmada de lo ocurrido en la instalación original.

## Inventario y reutilización

| Carpeta | Contenido observado | Decisión propuesta |
| --- | --- | --- |
| `Gustavo/proofC6` y `Gustavo/proofC` | Aplicación de prueba WinForms, clases COM para XML, SOAP, firma, correo y RIDE; referencias para pruebas y producción. `proofC6` apunta a .NET Framework 4.7.1. | Referencia principal del intento propio. Extraer escenarios y conocimiento; no enlazar todo `SRI_LIB.cs` al producto. El nombre `proofC6` no demuestra que sea la última versión funcional. |
| `utilWs` | Clientes WCF, constructor genérico de SOAP, probadores y ejecutables auxiliares. | Usar WSDL como referencia histórica y regenerar/verificar contratos actuales. Evitar el constructor SOAP genérico cuando existen operaciones conocidas. |
| `pruebaRR` | Otro experimento COM/WinForms de validación XML y consumo de servicios. | Comparar comportamientos útiles con `utilWs`; evitar mantener ambas variantes. |
| `pruebaCrypy` | Proyecto cuyo `Main` está vacío. | No aporta implementación de cifrado o firma funcional en ese punto de entrada. |
| `XADES` | FirmaXadesNet, Microsoft.Xades y demos, incluido Facturae español. | Evaluar compatibilidad técnica, mantenimiento y licencias antes de elegir un firmador. Un ejemplo Facturae no equivale a una factura del SRI. |
| `xadesnet` | Biblioteca XAdES, pruebas, certificados de prueba y archivo histórico de wiki/incidencias. | Referencia y posibles escenarios de prueba. Su metadato de licencia indica GPLv2; no incorporarla por defecto al producto. |

En `XADES/License/LICENSE.txt` se declara LGPLv3 o posterior para FirmaXadesNet, junto con avisos de otros componentes. Son dependencias distintas de `xadesnet`; no asumir una licencia común. La selección requiere revisar los avisos de los componentes efectivamente utilizados. Esto es un inventario de los archivos de licencia, no una conclusión jurídica sobre una futura distribución.

## Hallazgos concretos

1. **Causa histórica de la firma no confirmada; corrección del diagnóstico inicial.** En `Gustavo/proofC6/SRI_LIB.cs:747–748`, `ComputeSignature` descarta el resultado de `GetC14NDigest(hash, prefix)` y pasa el objeto hash a `CreateSignature`. Inicialmente se señaló como defecto, pero esa conclusión era incorrecta: el cálculo actualiza el estado del hash, y la implementación oficial de `SignedXml` utiliza el mismo patrón. Descartar el valor devuelto no demuestra que la firma sea inválida. Es necesario verificar un archivo firmado y su canonicalización para identificar la causa concreta; no se ha demostrado el motivo histórico del fallo.
2. **Firma dependiente de detalles internos y de serialización.** `PrefixedSignedXML` invoca por reflexión un método privado de `SignedXml`, modifica prefijos y usa `RSACryptoServiceProvider` mediante una conversión directa de la clave privada. Esto es frágil ante certificados con otro proveedor y cambios del runtime. Además, al recargar el XML firmado se asigna `PreserveWhitespace` a `testDoc`, no a `xdoc` (`SRI_LIB.cs:416`); la comprobación posterior no preserva los espacios como aparentemente se pretendía. Deben verificarse firma y referencias sobre los bytes finales guardados.
3. **TLS desactivado globalmente.** `Net_Mail` asigna a `ServicePointManager.ServerCertificateValidationCallback` un delegado que siempre devuelve `true` (`SRI_LIB.cs:278` y `322`). Puede afectar otras conexiones del proceso. No trasladar este código al servicio ni a EasySoft.
4. **Respuestas SOAP sin contrato de salida firme.** `NET_WServ` convierte respuestas `object` a `XmlNode[]` (`SRI_LIB.cs:130–160`). Los proxies activos efectivamente devuelven `object`; sin una respuesta real o una prueba de deserialización no se puede declarar que esa conversión falle siempre. Aun así, asume una representación concreta y devuelve XML concatenado bajo `<root>`, sin un resultado de negocio tipado. Sustituir por contratos explícitos y pruebas con respuestas de recepción y autorización.
5. **Producción por omisión.** `consumirServicio(..., bool ambientePrueba = false)` selecciona producción cuando se omite el parámetro. El nuevo sistema debe exigir un ambiente explícito y comenzar configurado en pruebas.
6. **Estado de error persistente.** `Errores`, `validateResult`, `hayErr` y `sErr` pertenecen a instancias reutilizables y no se reinician al comenzar cada operación. Un fallo puede contaminar operaciones posteriores. La validación XML usa lectores antiguos y no los libera con `using`. Rehacer con resultados por operación y lectura XML que prohíba DTD y resolución externa no autorizada.
7. **RIDE incompleto y con errores de contenido.** `Net_RIDE` obtiene el ambiente desde `secuencial`, intercambia las direcciones de matriz y establecimiento, y lanza `BarcodeCreatorDemo.exe` con espera activa sin límite (`SRI_LIB.cs`, clase desde línea 827). Depende de `Select.HtmlToPdf.dll`, un ejecutable y una plantilla externa. Rehacer la representación desde un modelo validado y comprobar PDF, códigos de barras y datos fiscales.
8. **Puntos de entrada experimentales.** `utilWs/ws_SRI/Program.cs` exige seis argumentos, utiliza tres e ignora la URL leída. No constituye una API de emisión. Las operaciones de prueba se disparan por separado desde formularios; no se observa una transacción de emisión con recuperación tras fallos.

No se encontró en el flujo propio revisado una implementación completa de generación fiscal de factura desde datos comerciales, asignación concurrente de secuenciales, clave de acceso, almacenamiento durable de estados y recuperación de envíos inciertos. Los XSD identificados dentro de estas bibliotecas son principalmente de firma; hay que incorporar los esquemas de comprobantes del SRI que correspondan al alcance inicial.

## Referencia vigente del SRI

La [página oficial de facturación electrónica](https://www.sri.gob.ec/facturacion-electronica) enlaza la ficha técnica offline **2.34, actualizada a julio de 2026**. La [ficha técnica oficial](https://www.sri.gob.ec/o/sri-portlet-biblioteca-alfresco-internet/descargar/f8d9bb36-5632-4f96-b463-b9265b55338c/FICHA%20TE%CC%81CNICA%20COMPROBANTES%20ELECTRO%CC%81NICOS%20ESQUEMA%20OFFLINE%20Versio%CC%81n%202.34.pdf), secciones 5–7, describe la firma XAdES-BES enveloped, la recepción y la consulta de autorización en ambientes separados.

La ficha todavía especifica RSA-SHA1 en la sección 6.8. Por ello no se debe diagnosticar la incompatibilidad únicamente por encontrar SHA1 ni cambiar algoritmos sin validar el perfil exigido. La compatibilidad final debe comprobarse con el perfil completo y el ambiente de pruebas; el tratamiento del valor devuelto del hash no demuestra un defecto, según la corrección anterior.

La versión 2.34 también incluye un anexo relativo al RUC del proveedor de sistemas o servicios de facturación. Su aplicación al producto debe revisarse al cerrar el formato XML inicial. No basta con actualizar las URLs del proyecto antiguo.

## Arquitectura recomendada

```text
EasySoft / otras aplicaciones
           |
           | HTTPS, contrato versionado, identidad de aplicación y empresa
           v
API de facturación electrónica
           |
           +-- Núcleo: comprobantes, validaciones, importes y clave de acceso
           +-- Persistencia: solicitudes, secuenciales, estados, historial y archivos
           +-- Procesador durable: XML -> XSD -> firma -> recepción -> autorización
           +-- Adaptador SRI: SOAP y traducción de respuestas
           +-- Firmador: certificado y perfil XAdES del SRI
           +-- Entrega: XML, RIDE y notificaciones con seguimiento independiente
```

Construir el núcleo sin referencias a WinForms, COM ni a las bases particulares. Mantener el adaptador de EasySoft separado y definir un contrato de factura con emisor, establecimiento, punto de emisión, comprador, líneas, impuestos, descuentos, pagos e información adicional. Empezar con factura de venta común; añadir otros comprobantes y casos sectoriales cuando exista una necesidad concreta.

La GUI actual usa .NET Framework 4.8 y puede consumir HTTP sin migrarla por completo. El servicio puede usar un runtime .NET moderno con soporte vigente al iniciar la implementación. No es necesario incorporar criptografía al proceso de la GUI. Para un primer despliegue puede funcionar como servicio local o en servidor de la instalación; la misma API permite centralizarlo después. Si la firma debe permanecer en el equipo del emisor, la ubicación del firmador se ajustará a ese requisito.

## Contrato y consistencia que deben existir desde el inicio

- Solicitud de emisión con clave de idempotencia estable, empresa y referencia comercial. La empresa autorizada se determina también por la identidad autenticada; no confiar únicamente en un identificador enviado por el cliente.
- Una solicitud repetida con los mismos datos recupera el mismo comprobante; con datos distintos devuelve conflicto. Un timeout no debe crear otra factura ni consumir otro secuencial automáticamente.
- Identidad fiscal y secuencial con restricciones únicas y asignación atómica por emisor, ambiente, establecimiento, punto de emisión y tipo de documento. Resolver expresamente quién administra los secuenciales si también existe otro emisor externo.
- Guardar una instantánea comercial, versión de esquema, clave de acceso, XML generado, bytes firmados, respuestas SRI y autorización. No reconstruir una factura ya emitida a partir de tablas comerciales que puedan cambiar.
- Distinguir estado de negocio, error de transporte, rechazo SRI y entrega al cliente. Una respuesta de recepción favorable no equivale a autorización; la ausencia temporal de autorización no es un rechazo definitivo.
- Ante respuesta incierta, reconciliar por clave y aplicar reintentos controlados. No generar otra clave, modificar el XML firmado ni reenviar indefinidamente por un error de red. Las correcciones fiscales requieren un flujo explícito, trazable y acorde con las reglas vigentes.
- Conservar certificado y contraseña fuera de código, argumentos de procesos, solicitudes registradas y logs. Separar acceso y almacenamiento por empresa; validar certificado, clave privada y vigencia antes de emitir.
- Guardar el trabajo pendiente de manera durable para continuar después de reiniciar el servicio. El envío de correo fallido se reintenta por separado y no vuelve a emitir la factura.

API propuesta: `POST /v1/facturas`, `GET /v1/comprobantes/{id}` y descarga autenticada de XML/RIDE. La creación puede devolver un identificador y estado pendiente; la consulta muestra el avance. Los nombres son una propuesta, no endpoints implementados.

## Integración concreta con EasySoft

La capa `easySoft/Negocio/Negocio.cs` revisada está orientada a sesión y menú; no contiene un proceso completo de emisión de ventas. No se encontró un flujo de facturación electrónica integrado en las capas revisadas.

La documentación de `docs/base-datos` describe una copia de **Patricks**, procedente de `Restaurante/alpSAAB/bdpatricks.bak`, e incluye `APCabFac`, `apDetFac`, `apEstab` y `apPtoEmi`. Es una pista para el mapeo, no prueba de que esas tablas sean las de ventas de la instalación de EasySoft objetivo: deben verificarse su significado, consultas y relaciones. No asignar campos fiscales por similitud de nombres.

El primer adaptador deberá identificar la fuente real de ventas, cliente, impuestos, pagos y configuración del emisor. Necesita una estrategia durable entre guardar la venta y solicitar la emisión: por ejemplo, una bandeja de salida transaccional en la base comercial. Así un fallo entre ambas operaciones no pierde la solicitud ni la duplica.

En la interfaz, una acción explícita de emitir o consultar abrirá el resultado y dirigirá foco accesible y vista al título o contenido relevante, también al volver a seleccionarlo. Evitar activar controles editables o abrir teclado innecesariamente; respetar movimiento reducido y cabeceras fijas. El sondeo de estados en segundo plano no moverá el foco ni la vista, ni interrumpirá la escritura.

## Orden de implementación y criterios de aceptación

1. **Contrato y origen de datos.** Confirmar instalación/empresa inicial y una factura representativa anonimizada; documentar el mapeo comercial, responsabilidades de cálculo y numeración. Elegir versión XML y requisitos tributarios aplicables.
2. **Núcleo verificable.** Implementar clave de acceso, importes y XML con XSD oficial versionado. Probar casos monetarios, caracteres especiales, impuestos aplicables y concurrencia en secuenciales/idempotencia.
3. **Firma como primer hito técnico.** Firmar una factura sintética con un certificado de pruebas controlado; verificar criptográficamente las referencias y el archivo final, incluyendo detección de alteración. No usar los `.p12` históricos como credenciales de un emisor.
4. **Ciclo completo en pruebas SRI.** Obtener recepción y autorización, conservar evidencias y probar rechazo, respuesta pendiente, timeout, duplicación de solicitudes y reinicio del procesador. El hito se cumple cuando una factura del ambiente de pruebas queda autorizada y se recuperan sus artefactos.
5. **EasySoft y entrega.** Conectar la venta real mediante el adaptador, mostrar estados, recuperar XML/RIDE y comprobar la navegación accesible. Validar representación visual y que los reintentos de correo no dupliquen emisiones.
6. **Despliegue y ampliación.** Configurar emisores y secretos, respaldos, observabilidad y separación de empresas; pasar a producción después de validar el circuito de pruebas. Incorporar nuevas aplicaciones mediante el contrato ya existente y otros comprobantes como extensiones del núcleo.

Para la siguiente fase hacen falta decisiones de negocio: cuál instalación emitirá primero, dónde se guardan sus ventas, si el certificado será de archivo o token, dónde puede residir la firma y quién controla los secuenciales. No es necesario compartir contraseñas ni certificados en el chat para resolver estas decisiones.

## Resultado de esta fase

El análisis inicial identificó una base histórica útil y un camino viable hacia un servicio común. Después de autorizarse la implementación, se creó el motor y la consola local en `Facturacion/`. Consulte [el estado e instrucciones actuales](../Facturacion/README.md). Se verificaron firma local, persistencia, respuestas simuladas y conectividad con los servicios de pruebas. La autorización real sigue pendiente de cargar el emisor y su firma; no se declara conseguido ese hito.
