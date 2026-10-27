# Pendientes de integración y despliegue

## Diccionario ERP y primera capa descriptiva — 27 de octubre de 2026

- Rama: `codex/diccionario-erp-cartera`.
- Estado actualizado al iniciar el bloque AP: **integrado** en `master` remoto mediante `8d6f23c` (PR #1 cerrado e integrado, comprobado en GitHub); **pendiente de despliegue**. Esta integración ya estaba realizada al comenzar el trabajo; no la ejecutó este bloque.
- Alcance: inventario y diccionario de la base heredada, 23 vistas con 310 alias en español, generador, instalación/reversión/verificación SQL, auditoría de cartera y especificación de reportes y ventanas.
- Commit de implementación: `07591b3` (diccionario, scripts, auditoría y documentación inicial). La rama incluye un seguimiento documental y de formato posterior.
- PR: [#1 — Diccionario ERP y primera capa descriptiva de cartera](https://github.com/ImaSoftware/easysoft/pull/1), integrado hacia `master` mediante `8d6f23c`. No consta despliegue publicado.
- Destino comprobado: exclusivamente la copia local `EasySoft_Patricks_Dev`. Las vistas están instaladas en `erp_lectura`; no se modificaron datos de negocio ni se renombraron las tablas originales. Esto es una validación de desarrollo, no un despliegue publicado.
- Validación: generación del diccionario; instalación, reversión y reinstalación de 23 vistas; comparación de recuentos y tipos de 310 campos; auditoría de vínculos y acumulados. Resultados en `docs/base-datos/resultado-verificacion-vistas.txt` y `resultado-auditoria-cartera.txt`.
- Hallazgos pendientes: 140 cuotas sin cabecera y tres diferencias de créditos aplicados en esta copia; completar interpretación de tablas/campos restantes y dependencias externas. No habilitar reportes financieros como conciliados con esta información.
- No se implementaron pantallas ni se completó el renombrado físico. La siguiente etapa debe validar las fuentes y mantener las preferencias de foco y desplazamiento documentadas.
- Los scripts de instalación están restringidos deliberadamente a la base de desarrollo. Cualquier despliegue futuro requiere su procedimiento y autorización explícita; no ejecutarlos directamente contra producción.

Documentación: [diccionario y transición](base-datos/diccionario-y-migracion.md), [reportes previstos](base-datos/reportes-y-ventanas-erp.md) y [ventanas de cartera](base-datos/ventanas-cartera.md).


## Ampliación AP y análisis de cartera — 27 de octubre de 2026

- Rama: `codex/ap-electronica-auditoria-cartera`, creada desde `origin/master` (`8d6f23c`) en worktree aislado para conservar cambios ajenos.
- Estado: **pendiente de integrar**; sin integración ni despliegue ejecutados por este bloque.
- Alcance: seis vistas de numeración AP, 22 alias nuevos (total 29/332), ampliación/reversión incremental `003-*`, auditoría agregada `004-*`, evidencia de rutinas y especificación de diagnóstico y bandeja futura. Las tablas y consumidores heredados conservan sus nombres y comportamiento.
- Commit de implementación: `1a0f5c3`, subido a la rama remota. PR [#2 — Amplía numeración AP e investiga inconsistencias de cartera](https://github.com/ImaSoftware/easysoft/pull/2), abierto hacia `master`. Este registro se conserva en un commit documental posterior.
- Validación local: instalación, verificación, reversión AP con regresión de las 23 vistas anteriores, reinstalación, tipos/recuentos de 332 alias y rechazo de instalación repetida/reversión de objeto con marca ajena. Generación reproducible de ocho artefactos. Resultados permanentes en `docs/base-datos/resultado-*.txt` de este bloque.
- Hallazgos: 140 cuotas / 40 documentos sin cabecera, tres acumulados de cinco créditos de proveedor sin aplicaciones disponibles; las causas históricas no se han demostrado. Diferencias de filtros heredados y riesgos de numeración/transacciones documentados; sin corrección de datos ni saldos conciliados.
- Destino validado: únicamente LocalDB `EasySoft_Patricks_Dev`; esto no es despliegue publicado. No se enviaron comprobantes ni se consumieron secuenciales. Falta completar evidencia de campos/estados AP, recuperar historial de cartera y validar consumidores antes de migración física o reportes definitivos.
- Documentación: [investigación AP/cartera](base-datos/ap-y-cartera-investigacion.md), diccionario, catálogo de reportes, ventanas de cartera e índice de base de datos. Se conserva la especificación obligatoria de foco/desplazamiento para futuros flujos.
- Comprobación final: referencias remotas actualizadas; la rama contiene $('origin/master') ($('8d6f23c')); sin conflictos de integración. No se ejecutó integración ni despliegue.
