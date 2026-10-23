# ALP-SAAB

Aplicación VB.NET / Windows Forms para mesas, pedidos, cocina, cuentas y prefacturas, con SQL Server y un servicio Windows de impresión.

## Compilación y pruebas

Requisitos: Windows, MSBuild con herramientas de Visual Basic y el Developer Pack de .NET Framework 4.8. Ambos proyectos usan ahora la misma versión del framework.

Desde la raíz de esta carpeta:

```powershell
.\tools\verify.ps1
```

El script compila Debug y Release y ejecuta las pruebas locales. No conecta a SQL Server, no restaura respaldos, no instala el servicio y no imprime. SqlClient necesita inicializar contadores de Windows incluso sin abrir conexiones; estas pruebas deben ejecutarse en Windows fuera de un AppContainer.

Las DLL heredadas necesarias se obtienen por separado: no se versionan binarios. Su origen, destinos y huellas están documentados en `lib/DEPENDENCIES.md`; deben recuperarse antes de compilar un clon. Los RDLC se copian automáticamente a `Reportes` junto a los ejecutables.

## Actualización de una instalación existente

1. Respaldar la base de datos. Probar la actualización primero sobre una copia.
2. Detener el servicio `SAAB_IMP` y cerrar **todos** los clientes antiguos.
3. Ejecutar `database/001_admin_credentials.sql` en la base existente. El script crea una tabla adicional; no reconstruye las tablas de negocio.
4. Configurar `SAAB_SQL_CONNECTION` para los clientes y el servicio, apuntando a la misma base. Preferir autenticación integrada con una cuenta de Windows autorizada en SQL Server. La cuenta del servicio también necesita acceso a las impresoras configuradas.
5. Desplegar la carpeta completa de Release de cada proyecto, incluyendo DLL y `Reportes`. El equipo necesita el runtime .NET Framework 4.8.
6. Iniciar un cliente actualizado. La primera carga migra el PIN administrativo a PBKDF2-SHA256, con sal aleatoria y 100.000 iteraciones, y sustituye el campo antiguo por `0` dentro de una transacción. La tabla de credenciales exige permisos SELECT, INSERT y UPDATE; `SD_SysParam` requiere UPDATE.
7. Actualizar todos los clientes antes de iniciar la operación. **Los clientes antiguos ya no son compatibles después de migrar la clave** y podrían interpretar el valor antiguo `0` como un PIN válido. Una reversión requiere restaurar la copia previa y revertir todos los binarios.
8. Arrancar el servicio y verificar mesas, consumos, comandas, división de cuentas, prefacturas, cierre y salida física de cada impresora.

Ejemplo de configuración para la sesión de un cliente, sin contraseña:

```powershell
$env:SAAB_SQL_CONNECTION = 'Data Source=SERVIDOR;Initial Catalog=BASE_RESTAURANTE;Integrated Security=True;Application Name=SAAB'
.\SAAB.exe
```

El servicio necesita esta variable en su entorno de ejecución; una variable definida solamente en una consola no se transmite al servicio instalado. Configurar el entorno de la cuenta/servicio y reiniciar su proceso después del cambio. Las conexiones del cliente, el servicio y el motor de reportes deben apuntar al mismo servidor y base.

No hay credenciales predeterminadas en los archivos de configuración. **Rotar las credenciales SQL anteriormente incluidas** en el proyecto: también pueden persistir en respaldos, archivos comprimidos, binarios antiguos o historial. Esta actualización no cambia contraseñas del servidor ni modifica los respaldos existentes.

## Impresión

Se utiliza la cola nativa de Windows; ya no se requiere Adobe Reader 10. Los PDF de auditoría se guardan con nombres únicos en `%ProgramData%\SAAB\Documentos`. Conceder permisos de escritura a las cuentas que ejecutan cliente y servicio. Validar márgenes, papel y copias con las impresoras reales antes de desplegar.

El intervalo del servicio se lee de la configuración heredada `alpWin/ImpresionSAAB/Intervalo` de su cuenta de Windows. Si falta o es inválido se usan 8 segundos; el mínimo admitido es 1 segundo. Los ciclos no se superponen y los errores de consulta o de un documento no detienen permanentemente el temporizador.

Cliente y servicio coordinan cada documento mediante `sp_getapplock`. La marca `documento` solo se actualiza después de enviar la impresión; para comandas, después de procesar todas las cocinas. Una avería después de enviar papel a una cocina pero antes de completar las demás puede producir una reimpresión al reintentar. La cola de Windows confirma el envío al spooler, no la entrega física del papel.

## Seguridad y datos

- Las entradas de texto de pedidos, áreas, etiquetas, búsqueda, PIN y filtros de productos se envían mediante parámetros SQL.
- Las cuentas nuevas recuperan su identidad mediante `OUTPUT INSERTED`, sin buscar un ID por `MAX` después de insertar.
- Cuentas, comandas, generación de prefacturas y cierre agrupan sus cambios en transacciones. Las operaciones SQL propagan los errores para que una transacción pueda revertirse.
- Los comandos SQL tienen un límite de 30 segundos y las conexiones uno de 15 segundos. Los recursos se liberan con `Using`.
- La clave administrativa no se vuelve a mostrar en configuración. Un campo vacío conserva la clave actual; una nueva exige de 4 a 32 dígitos. Tras cinco fallos se bloquea la verificación durante un minuto en ese proceso.
- La autenticación fija de la clase `Usuario`, que no tenía llamadas en el proyecto, fue retirada. Se mantienen los accesos de mesero y administrador.
- Las sentencias de `RepoMan`, `SD_ModificaData` y los metadatos de origen de meseros siguen siendo configuración SQL de confianza. Solo administradores de la base deben poder modificarlos; su contenido no viene incluido como migraciones en este repositorio.

## Alcance de la validación

La evaluación de los flujos, los hallazgos pendientes y la matriz de pruebas están en
[`tests/FLOW_REVIEW.md`](tests/FLOW_REVIEW.md). La suite incluye 73 comprobaciones locales.

Las pruebas de regresión cubren claves, sal, límites de intentos, entradas SQL maliciosas, parámetros de lote, configuración externa, intervalos inválidos y recuperación/detención del temporizador. Utilizan dobles para SQL y las impresoras.

La validación contra la base real y la impresión física requieren el entorno de instalación. No se han restaurado los `.bak`/`.rar`, ejecutado scripts sobre una base existente ni rotado credenciales remotas. La reconstrucción completa de procedimientos y esquema todavía depende de los respaldos disponibles: los scripts SQL de limpieza existentes **no son migraciones de instalación**.

El código heredado de interfaz conserva `Option Strict Off`; los módulos nuevos de datos y seguridad se compilan también con `Option Strict On` en las pruebas. Una conversión completa del código visual y sus hilos requiere validación funcional de las pantallas.
