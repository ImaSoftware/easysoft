$ErrorActionPreference = 'Stop'
$projectRoot = Split-Path -Parent $PSScriptRoot
$msbuildCommand = Get-Command MSBuild.exe -ErrorAction SilentlyContinue
if ($msbuildCommand) {
    $msbuildPath = $msbuildCommand.Source
} else {
    $vswhere = Join-Path ${env:ProgramFiles(x86)} 'Microsoft Visual Studio\Installer\vswhere.exe'
    if (-not (Test-Path -LiteralPath $vswhere)) { throw 'Instale MSBuild y las herramientas de Visual Basic.' }
    $msbuildPath = & $vswhere -latest -products '*' -requires Microsoft.Component.MSBuild -find 'MSBuild\**\Bin\MSBuild.exe' | Select-Object -First 1
    if (-not $msbuildPath) { throw 'No se encontró MSBuild.' }
}
foreach ($configuration in @('Debug', 'Release')) {
    & $msbuildPath (Join-Path $projectRoot 'SAAB.sln') /t:Build "/p:Configuration=$configuration" /nologo /verbosity:minimal
    if ($LASTEXITCODE -ne 0) { throw "Falló la compilación $configuration." }
}
& $msbuildPath (Join-Path $projectRoot 'tests\Regression.vbproj') /t:Build /nologo /verbosity:minimal
if ($LASTEXITCODE -ne 0) { throw 'Falló la compilación de las pruebas.' }
& (Join-Path $projectRoot 'tests\bin\Regression.exe')
if ($LASTEXITCODE -ne 0) { throw 'Fallaron las pruebas de regresión.' }
