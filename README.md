# EasySoft

## Visión de la versión final

EasySoft evolucionará hacia una **plataforma ERP web**, accesible desde el navegador. Este es el objetivo del producto final; los proyectos de escritorio y componentes actuales son la base existente para esa evolución.

El stack definido para la plataforma ERP web es **.NET 10 con ASP.NET Core y Razor**, con **Microsoft SQL Server (MSSQL)** como base de datos. Esta elección queda registrada como preferencia del propietario para este proyecto.

En esta etapa se registra únicamente la visión del producto. La arquitectura, el alcance de los módulos y el plan de migración se definirán posteriormente, sin iniciar ahora su implementación.

La navegación web deberá dirigir la vista y el foco accesible al contenido de destino una vez renderizado, también al reseleccionar la sección actual. El título o primer contenido relevante deberá quedar cerca del centro visible, sin quedar oculto por cabeceras fijas, sin activar controles ni abrir el teclado innecesariamente. Se respetará `prefers-reduced-motion` y no se desplazará la vista por actualizaciones de fondo ni durante la escritura. Este comportamiento deberá verificarse al crear o modificar flujos de navegación.

## Proyectos incluidos y entrega a desarrollo

| Proyecto | Solución / instrucciones |
|---|---|
| EasySoft (C#, Windows Forms) | `easySoft/easySoft.sln`; instrucciones abajo |
| Timbrado SRI heredado (C#, SOAP y XAdES) | [TimbradoSRI/README.md](TimbradoSRI/README.md); comenzar por `TimbradoSRI/utilWs/SRI_Ws.sln` |
| Restaurante ALP-SAAB (VB.NET, cliente y servicio de impresión) | [Restaurante/alpSAAB/README.md](Restaurante/alpSAAB/README.md); `Restaurante/alpSAAB/SAAB.sln` |
| Facturación electrónica independiente | [Facturacion/README.md](Facturacion/README.md) |

```powershell
git clone https://github.com/ImaSoftware/EasySoft.git
cd EasySoft
```

La entrega contiene código, soluciones, recursos necesarios para los formularios y reportes, contratos SOAP, scripts y documentación. Se excluyen compilaciones, cachés del IDE, DLL de terceros, respaldos de bases de datos y certificados con claves privadas. Los archivos excluidos se conservan localmente; no se publican con Git.

Clonar permite continuar el desarrollo. Para compilar Restaurante y los prototipos históricos de SRI también es necesario recuperar sus dependencias externas documentadas; para ejecutar se necesitan bases de datos y configuración de la instalación. No hay una restauración completa de las bases incluida ni una compilación autónoma de todos los prototipos. Consultar las instrucciones de cada proyecto.

El nuevo motor independiente y la consola local de facturación electrónica se encuentran en [Facturacion/README.md](Facturacion/README.md). Está limitado al ambiente de pruebas del SRI; la autorización real queda pendiente de cargar los datos y la firma del emisor.

Aplicación Windows Forms para acceso por empresa, consultas, reportes y exportación bancaria. La solución principal está en `easySoft/easySoft.sln`; `GUI` es el ejecutable. `proof` es únicamente un proyecto auxiliar, sin un formulario de ejemplo completo en el código original.

## Compilar y comprobar

Requisitos: Windows, Visual Studio con desarrollo de escritorio .NET y Developer Pack de .NET Framework 4.8; acceso a NuGet para la primera restauración.

Desde Developer PowerShell de Visual Studio:

```powershell
msbuild easySoft/easySoft.sln /t:Restore /p:RestorePackagesConfig=true
msbuild easySoft/easySoft.sln /t:Build /p:Configuration=Release
msbuild tests/Regression.csproj /t:Build /p:Configuration=Release
& ./tests/bin/Release/Regression.exe
```

Las DLL nativas de SQL Server se copian desde el paquete NuGet para ambas arquitecturas. Se conservan las versiones declaradas de los paquetes para evitar cambiar el contrato de ReportViewer durante esta corrección; esto no constituye una auditoría de sus vulnerabilidades.

## Configuración e instalación

1. Configure `EASYSOFT_ROOT_CONNECTION` en el entorno del proceso que ejecuta GUI, o la conexión con nombre `GUI.Properties.Settings.connSQL` en `GUI.exe.config`. Ejemplo sin contraseña:

   ```text
   Data Source=SERVIDOR;Initial Catalog=davmerRoot;Integrated Security=True;Encrypt=True;TrustServerCertificate=False;Persist Security Info=False;Connect Timeout=30
   ```

   El servidor necesita un certificado confiable cuyo nombre coincida con el servidor de la conexión. El programa exige cifrado y rechaza el usuario `sa`. Use una identidad con permisos mínimos; la migración necesita permisos adicionales y debe ejecutarse con una cuenta administrativa distinta de la cuenta de ejecución.

2. Revise las conexiones almacenadas en `empresas.connstring`: necesitan una cuenta de permisos mínimos y un certificado confiable. No se han modificado los datos del servidor.
3. Rote las credenciales expuestas anteriormente. Quitar sus valores de los archivos actuales no las revoca ni las elimina del historial Git.
4. Migre las contraseñas como se indica más abajo **antes de ejecutar esta versión contra usuarios existentes**.
5. Recupere los RDLC originales y colóquelos en `easySoft/GUI/Reportes/`. Se copian al directorio `Reportes` junto al ejecutable tanto en Debug como en Release. El programa informa el nombre del archivo que falta. No se inventaron definiciones de reportes ni consultas de negocio.
6. Si utiliza la integración con otro ejecutable, configure su ruta completa en `ExternalApplicationPath` dentro de `GUI.exe.config`.

La base central debe contener las empresas, usuarios, permisos y definiciones de menú. Las bases empresariales necesitan las tablas y definiciones de consultas y reportes originales (`davmerTablas`, `repoman`, etc.). Este repositorio no incluye una restauración completa de esos datos. Las definiciones SQL almacenadas son código ejecutable: restrinja quién puede modificarlas y limite los permisos de la cuenta de la aplicación.

## Migrar contraseñas

La nueva autenticación lee `dbo.usuarios.userpwdhash`, con PBKDF2-SHA256, sal aleatoria de 16 bytes y 600 000 iteraciones. No acepta contraseñas almacenadas en texto claro. Todos los programas que creen o cambien contraseñas deben guardar `DLIB.PasswordSecurity.Hash(password)` en esa columna.

Antes de migrar, haga un respaldo verificado y pruebe en una copia de la base. Detenga todos los clientes durante la migración, incluidos los antiguos. Desde **Windows PowerShell 5.1**, con la DLL Release ya compilada y `EASYSOFT_ROOT_CONNECTION` configurada:

```powershell
./tools/Migrate-Passwords.ps1
```

El script agrega `userpwdhash nvarchar(256)`, convierte las contraseñas existentes y vacía `userpwd`, dentro de una transacción con bloqueo de la tabla. Si un usuario carece de contraseña o no se actualiza exactamente una fila, revierte la transacción. Conserva el valor exacto de las contraseñas originales, incluidos espacios. Revise previamente restricciones y triggers particulares de su instalación. El proceso puede tardar por el costo deliberado del hash. No se ha ejecutado esta migración contra un servidor real.

Después de migrar, los clientes antiguos ya no podrán autenticar con `userpwd`. Para revertir un despliegue use el respaldo y la versión anterior en una ventana de mantenimiento; los hashes no pueden convertirse de nuevo a texto claro. Proteja también los respaldos antiguos.

## Verificación pendiente en la instalación

Las pruebas locales cubren hashes, rechazo de contraseñas incorrectas y de formatos inseguros, filtros con caracteres especiales y cultura decimal, y rutas de reportes. La validación funcional requiere la base y los RDLC originales: comprobar acceso válido e inválido, permisos por empresa, cambio de usuario, reportes, archivos aceptados por cada banco y puerto serial. No se han enviado archivos bancarios ni ejecutado consultas contra el servidor del cliente.
