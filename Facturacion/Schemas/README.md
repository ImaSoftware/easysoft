# Esquemas oficiales fijados

- `factura_V1.1.0.xsd`: extraído sin modificaciones del [ZIP oficial de factura del SRI](https://www.sri.gob.ec/o/sri-portlet-biblioteca-alfresco-internet/descargar/05546998-6f29-4870-be3b-62650f312a6c/XML%20y%20XSD%20Factura.zip), enlazado desde su página de facturación electrónica. SHA256 del ZIP descargado: `BA1FF0C4E329FE759C3F88DC75F2975780B315B6EB3D0069071B77C1F26FEC03`.
- `xmldsig-core-schema.xsd`: descargado sin modificaciones de [W3C XMLDSig](https://www.w3.org/TR/xmldsig-core/xmldsig-core-schema.xsd). Conserva los avisos de copyright/licencia. Se ignora su DOCTYPE y no se resuelven recursos externos.
- `XAdES.xsd`: descargado sin modificaciones de [ETSI XAdES 1.3.2](https://uri.etsi.org/01903/v1.3.2/XAdES.xsd). Permite validar también la estructura de las propiedades XAdES dentro de la firma.

Fecha de descarga: 22 de octubre de 2026. Los archivos se cargan localmente con resolución externa deshabilitada. No se descarga ningún esquema durante una emisión.

La versión de la ficha técnica (2.34) y la versión del documento XML (1.1.0) son identificadores distintos. El alcance actual genera factura nacional simple 1.1.0; no usa las plantillas ficticias incluidas en el ZIP como facturas emitibles.
