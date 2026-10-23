# Timbrado SRI: fuentes heredadas

Este directorio conserva el código C# recibido de firma XML/XAdES y consumo SOAP del SRI. Es independiente de EasySoft y del motor nuevo en `../Facturacion`; no existe una integración automática entre ellos.

## Punto de entrada

Abrir `utilWs/SRI_Ws.sln`: contiene la biblioteca `utilWs` y el formulario de pruebas `probador`. Requiere Windows, Visual Studio con desarrollo de escritorio .NET y el Developer Pack de .NET Framework 4.5.2.

Desde Developer PowerShell, para compilar la biblioteca sin certificados ni registro COM:

```powershell
msbuild TimbradoSRI/utilWs/utilWs/utilWs.csproj /t:Build /p:Configuration=Release /p:SignAssembly=false /p:RegisterForComInterop=false
msbuild TimbradoSRI/utilWs/SRI_Ws.sln /t:Build /p:Configuration=Release /p:SignAssembly=false /p:RegisterForComInterop=false
```

La firma de ensamblados y el registro COM de una instalación necesitan configuración propia. No equivalen a la firma electrónica de comprobantes. Los certificados referidos como `servSingkey.pfx` y `CertiReg.pfx` no se distribuyen.

Validación de esta entrega: `SRI_Ws.sln` compila en Release con el SDK local de .NET Framework 4.8, agregando `/p:TargetFrameworkVersion=v4.8` a los comandos anteriores; quedan advertencias heredadas. La compilación con el destino original 4.5.2 no pudo comprobarse porque falta su Developer Pack. No se realizaron solicitudes al SRI.

## Otros proyectos conservados

- `pruebaRR`: versión anterior de la biblioteca y pruebas de interfaz.
- `Gustavo/proofC` y `Gustavo/proofC6`: prototipos de firma y generación de documentos.
- `XADES/FirmaXadesNet.sln`: biblioteca y demostraciones; conservar las licencias en `XADES/License`.
- `xadesnet/sourceCode/xadesnet/XadesNet.sln`: otra implementación y pruebas de XAdES.
- `pruebaCrypy`: proyecto experimental con entrada vacía.

Son variantes históricas, no una única solución validada. `utilWs/ws_SRI/ws_SRI.csproj` referencia un `pruebaRR.csproj` ausente en los originales; no forma parte del punto de entrada recomendado.

## Dependencias excluidas

Solo se versionan fuentes, definiciones de proyecto, recursos y documentación. No se incluyen ejecutables, DLL, paquetes descargados, respaldos ni claves, incluso las de demostración. Las referencias SOAP generadas, WSDL y XSD se conservan porque describen los contratos utilizados por el código.

Los prototipos pueden requerir ColorCode, Select.HtmlToPdf, PQScan.BarcodeCreator, CryptoSysPKI y dependencias de XAdES/NUnit. Consultar las referencias y `HintPath` de cada `.csproj`, obtener versiones compatibles de sus proveedores y respetar sus licencias. No copiar binarios desconocidos a la instalación. Los proyectos de XAdES con firma de ensamblado requieren una clave propia o desactivar `SignAssembly` para desarrollo. Las pruebas que usan `xadesnettest.p12` requieren crear un certificado de prueba local.

Configurar rutas y certificados propios fuera de Git. Los ejemplos históricos pueden apuntar a producción: revisar los endpoints y utilizar el ambiente de pruebas antes de ejecutar. No se ha validado autorización real ni vigencia del protocolo de estos prototipos.
