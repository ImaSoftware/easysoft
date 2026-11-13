# Base de desarrollo Patricks

Respaldo de origen: `Restaurante/alpSAAB/bdpatricks.bak`.
Restaurado y verificado el 19 de octubre de 2026 en una copia independiente.

## Conexión local

```text
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EasySoft_Patricks_Dev;Integrated Security=True;
```

Para iniciar la instancia si está detenida:

```powershell
SqlLocalDB start MSSQLLocalDB
sqlcmd -S '(localdb)\MSSQLLocalDB' -E -d EasySoft_Patricks_Dev
```

Los archivos restaurados están en `.vs/EasySoft/Database/`, carpeta excluida de Git. El respaldo original se conserva. La restauración actualizó el formato de la copia al motor local; para restaurar en otro motor debe partirse del `.bak` original y comprobar su compatibilidad.

## Resultado de la inspección

- Base en estado `ONLINE`.
- `DBCC CHECKDB WITH NO_INFOMSGS, MAXDOP=1` finalizó sin errores.
- 262 tablas y 4.210 columnas.
- 148 procedimientos almacenados, 34 funciones escalares, 2 funciones de tabla y 4 vistas.
- 55 restricciones de clave primaria; ninguna clave foránea declarada. Las relaciones deben contrastarse con las consultas y rutinas de las aplicaciones; la ausencia de claves foráneas no significa que no existan relaciones funcionales.

## Inventario

El [catálogo de reportes y ventanas del ERP](reportes-y-ventanas-erp.md) documenta las propuestas de cuentas por cobrar, cuentas por pagar, tesorería, inventario y contabilidad, sus fuentes candidatas y las validaciones pendientes antes de implementarlas o renombrar objetos.

El [diccionario y transición de nombres](diccionario-y-migracion.md) registra la revisión del 27 de octubre: 23 vistas descriptivas instaladas y verificadas, 310 campos publicados, inventario completo con pendientes y hallazgos de integridad. La [especificación de ventanas de cartera](ventanas-cartera.md) desarrolla los primeros flujos de cuentas por cobrar y pagar. Las tablas originales conservan sus nombres por compatibilidad; el renombrado físico aún no se ha ejecutado.

- `tablas.csv`: esquemas, tablas y número aproximado de filas según las particiones.
- `columnas.csv`: tipos, tamaños en bytes, nulabilidad, identidad y valores predeterminados.
- `rutinas.csv`: procedimientos, funciones y vistas.
- `relaciones.csv`: sin entradas porque no hay claves foráneas declaradas.

Estos archivos contienen metadatos; no exportan registros operativos. Son una fotografía de la copia restaurada y deben regenerarse si cambia el esquema.

## Restaurante y EasySoft

Restaurante contiene código Visual Basic en `Restaurante/alpSAAB/alpSAAB`. Sus consultas utilizan tablas `SD_…` y procedimientos `SDSP_…`, presentes en el respaldo. Entre ellas están mesas, áreas, cocinas, cuentas, consumos, comandas y prefacturas. Debe considerarse esta aplicación al modificar objetos compartidos.

EasySoft llama a `LOGGIN_001` y `LOBBY_001` desde `easySoft/Datos/Datos.cs`. Ninguno existe en esta copia. Su configuración actual también apunta a una base raíz `davmerRoot`, mientras Restaurante tiene configuraciones históricas para una base `Restaurante`. Esto requiere revisar la arquitectura de conexión y las dependencias antes de sustituir cadenas de conexión. No se modificó ninguna configuración de las aplicaciones.

La copia permite consultar el esquema y los datos para desarrollar; todavía no se ha validado el funcionamiento completo de ambas aplicaciones contra ella.

Ampliación posterior del 27 de octubre: **29 vistas / 332 alias**; `003-*` amplía y revierte únicamente numeración AP, conservando las 23 vistas anteriores. Consulte [evidencia y pendientes de AP/cartera](ap-y-cartera-investigacion.md), `004-investigar-cartera-y-ap.sql` y sus resultados agregados. No se consideran conciliados los saldos de la copia.
