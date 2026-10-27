# Pendientes de integración y despliegue

## Diccionario ERP y primera capa descriptiva — 27 de octubre de 2026

- Rama: `codex/diccionario-erp-cartera`.
- Estado: **pendiente de integrar** en `master`; no se ha solicitado integración ni despliegue.
- Alcance: inventario y diccionario de la base heredada, 23 vistas con 310 alias en español, generador, instalación/reversión/verificación SQL, auditoría de cartera y especificación de reportes y ventanas.
- Commit de implementación: `07591b3` (diccionario, scripts, auditoría y documentación inicial). La rama incluye un seguimiento documental y de formato posterior.
- PR: [#1 — Diccionario ERP y primera capa descriptiva de cartera](https://github.com/ImaSoftware/easysoft/pull/1), abierto para revisión hacia `master`. Rama subida al remoto; integración pendiente de orden explícita.
- Destino comprobado: exclusivamente la copia local `EasySoft_Patricks_Dev`. Las vistas están instaladas en `erp_lectura`; no se modificaron datos de negocio ni se renombraron las tablas originales. Esto es una validación de desarrollo, no un despliegue publicado.
- Validación: generación del diccionario; instalación, reversión y reinstalación de 23 vistas; comparación de recuentos y tipos de 310 campos; auditoría de vínculos y acumulados. Resultados en `docs/base-datos/resultado-verificacion-vistas.txt` y `resultado-auditoria-cartera.txt`.
- Hallazgos pendientes: 140 cuotas sin cabecera y tres diferencias de créditos aplicados en esta copia; completar interpretación de tablas/campos restantes y dependencias externas. No habilitar reportes financieros como conciliados con esta información.
- No se implementaron pantallas ni se completó el renombrado físico. La siguiente etapa debe validar las fuentes y mantener las preferencias de foco y desplazamiento documentadas.
- Los scripts de instalación están restringidos deliberadamente a la base de desarrollo. Cualquier despliegue futuro requiere su procedimiento y autorización explícita; no ejecutarlos directamente contra producción.

Documentación: [diccionario y transición](base-datos/diccionario-y-migracion.md), [reportes previstos](base-datos/reportes-y-ventanas-erp.md) y [ventanas de cartera](base-datos/ventanas-cartera.md).
