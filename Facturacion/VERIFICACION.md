# Verificación del primer circuito

22 de octubre de 2026.

## Resultados comprobados

- Restauración con auditoría NuGet habilitada y versiones transitivas guardadas en `packages.lock.json`.
- Compilación Release de los cuatro proyectos: cero errores y cero advertencias.
- 19 pruebas automatizadas correctas. Las respuestas de autorización en estas pruebas son **simuladas**, no emitidas por el SRI.
- Generación de clave de acceso contrastada con un vector de factura de la documentación del SRI y vectores de módulo 11.
- XML generado y firmado válidos contra XSD oficial de factura 1.1.0, XMLDSig W3C y XAdES 1.3.2 ETSI.
- Firma con certificado sintético RSA de 2048 bits verificada por `SignedXml` sobre el XML serializado final. Alteraciones en factura, propiedades firmadas y certificado detectadas.
- Asignación concurrente de secuenciales sin duplicados, idempotencia, conflicto por referencia y rollback de numeración cuando falla el XSD.
- Recuperación desde SQLite tras respuesta perdida después de aceptación simulada: consulta la misma clave, sin firmar ni enviar de nuevo. Estados pendiente, rechazado y autorizado separados; reactivación manual conserva clave y secuencial.
- API local: 401 sin credenciales, 400 para emisor inválido o campos desconocidos, 409 al intentar emitir sin firma. Producción deshabilitada y ninguna factura creada por las pruebas de interfaz.
- Revisión de consola en navegador de escritorio: acceso, guardado de parámetros sintéticos en un directorio aislado, navegación, reselección de la sección activa y adición/eliminación de líneas. El foco va al título o al contenido recién añadido y queda visible cerca del centro, sin activar un campo editable. No se observaron errores de consola ni desbordamiento horizontal en la ventana revisada.
- Lectura HTTPS de los WSDL de recepción y autorización de `celcer.sri.gob.ec`: ambos respondieron HTTP 200 con validación TLS habilitada. No se transmitieron facturas con el certificado sintético.
- Revisión final de paquetes directos y transitivos: NuGet no informó vulnerabilidades conocidas en sus fuentes consultadas. Se sustituyó el paquete SQLite nativo antiguo que había generado un aviso de gravedad alta; no se suprimió la advertencia.
- Script `Start-Pruebas.ps1 -NoBuild` ejecutado: inicia el servicio Release, crea la clave local y aplica permisos a datos/secretos. Instalación final vacía, sin emisor ni certificado cargado. Datos, secretos y artefactos excluidos de Git.

## Pendiente para el hito real

El usuario cargará después el emisor y su firma electrónica. No hay todavía respuesta real `AUTORIZADO`, número de autorización real ni XML autorizado por el SRI. La aceptación del certificado, datos tributarios y XML debe comprobarse en esa ejecución; podrían requerir ajustes según la respuesta del SRI.

La revisión visual de movimiento reducido se limita al código que consulta `prefers-reduced-motion`; no se cambió la preferencia del sistema del usuario. La prueba visual inicial fue en escritorio. No se verificó emisión real, RIDE, entrega por correo, integración con las ventas de EasySoft, tokens ni producción.
