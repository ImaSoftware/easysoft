# Dependencias locales

## Preparación después de clonar

Esta es una entrega de fuentes: las DLL locales no se suben a Git. Antes de compilar, obtener las dependencias de los proveedores o del responsable de la instalación y comprobar las huellas de esta tabla. Colocar las cinco DLL MetroFramework/ReportViewer indicadas debajo en `Restaurante/alpSAAB/lib/`, y `alpSeguridad.dll` y `Spire.Barcode.dll` en `Restaurante/alpSAAB/alpSAAB/` (rutas relativas a la raíz del repositorio). `alpSeguridad` no tiene fuentes ni paquete restaurable incluido: solicitar esa biblioteca al propietario del sistema. No existe restauración automática completa para este proyecto.

MetroFramework.dll y Microsoft.ReportViewer.WinForms.dll provienen de los binarios Debug existentes del proyecto. No se cambió su versión deliberadamente.

Microsoft.ReportViewer.Common.dll, Microsoft.ReportViewer.DataVisualization.dll y Microsoft.ReportViewer.ProcessingObjectModel.dll se recuperaron del paquete NuGet comunitario Microsoft.ReportViewer.Runtime.Common 12.0.2402.15 para completar las referencias heredadas. El paquete conserva copyright de Microsoft; su nuspec se incluye como registro de origen. No es un paquete publicado por Microsoft. Revisar los términos de distribución antes de redistribuir comercialmente.

Origen del paquete: https://www.nuget.org/packages/Microsoft.ReportViewer.Runtime.Common/12.0.2402.15

El proyecto principal conserva también alpSeguridad.dll y Spire.Barcode.dll, ya presentes junto al .vbproj.

| Archivo | SHA-256 |
|---|---|
| MetroFramework.dll | 31C086DB4DDFAE22AC08DA79157A1946B180796249FE35DDD3EA2CCD24D26007 |
| Microsoft.ReportViewer.Common.dll | 8B08367FFD590F3ED5E4ACC4D5EB2C4CD11D8B5E5790278B7237DABA03F47A0B |
| Microsoft.ReportViewer.DataVisualization.dll | DF63666F01516C56C600128EF2B50D3695DFFDF598E1367E7DEF9E9D6A123A92 |
| Microsoft.ReportViewer.ProcessingObjectModel.dll | B8C8935806F8777F301D563F937D40BB066C929EE956E9C79E892235A3FECF43 |
| Microsoft.ReportViewer.WinForms.dll | B10ADA2D6881EEAD90DC319F791ABD0D5D6F028E3532B7D7641ADDD001AFB93C |
