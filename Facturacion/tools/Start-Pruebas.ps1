[CmdletBinding()]
param([switch]$NoBuild)
$ErrorActionPreference = 'Stop'
$taskRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..'))
$secretDirectory = Join-Path $taskRoot 'secrets'
$dataDirectory = Join-Path $taskRoot 'data'
New-Item -ItemType Directory -Force -Path $secretDirectory,$dataDirectory | Out-Null
if ($env:OS -eq 'Windows_NT') {
    foreach ($taskDirectory in @($secretDirectory,$dataDirectory)) {
        $taskAcl = New-Object System.Security.AccessControl.DirectorySecurity
        $taskAcl.SetAccessRuleProtection($true, $false)
        $taskIdentity = [Security.Principal.WindowsIdentity]::GetCurrent().User
        $taskRights = [Security.AccessControl.FileSystemRights]::FullControl
        $taskInheritance = [Security.AccessControl.InheritanceFlags]'ContainerInherit,ObjectInherit'
        $taskPropagation = [Security.AccessControl.PropagationFlags]::None
        $taskAllow = [Security.AccessControl.AccessControlType]::Allow
        $taskAcl.AddAccessRule((New-Object Security.AccessControl.FileSystemAccessRule($taskIdentity,$taskRights,$taskInheritance,$taskPropagation,$taskAllow)))
        $taskAcl.AddAccessRule((New-Object Security.AccessControl.FileSystemAccessRule('SYSTEM',$taskRights,$taskInheritance,$taskPropagation,$taskAllow)))
        Set-Acl -LiteralPath $taskDirectory -AclObject $taskAcl
    }
}
$keyPath = Join-Path $secretDirectory 'api-key.txt'
if (-not (Test-Path -LiteralPath $keyPath)) {
    $random = New-Object byte[] 32
    $rng = [Security.Cryptography.RandomNumberGenerator]::Create()
    try { $rng.GetBytes($random) } finally { $rng.Dispose() }
    [IO.File]::WriteAllText($keyPath,[Convert]::ToBase64String($random))
}
$env:Sri__ApiKey = [IO.File]::ReadAllText($keyPath).Trim()
$env:Sri__DataPath = $dataDirectory
$env:DOTNET_CLI_WORKLOAD_UPDATE_NOTIFY_DISABLE = 'true'
$env:DOTNET_CLI_TELEMETRY_OPTOUT = 'true'
$env:MSBuildEnableWorkloadResolver = 'false'
Push-Location $taskRoot
try {
    if (-not $NoBuild) {
        & dotnet build Facturacion.slnx -c Release
        if ($LASTEXITCODE -ne 0) { throw 'No se pudo compilar el servicio.' }
    }
    Write-Host 'Consola: http://127.0.0.1:5088 (solo PRUEBAS)'
    Write-Host "Clave de la consola: abre el archivo local $keyPath y copia su contenido."
    Write-Host 'Detener: Ctrl+C. La firma se carga en la consola y permanece solo en memoria.'
    & dotnet run --project src/Facturacion.Api -c Release --no-build --no-launch-profile
    if ($LASTEXITCODE -ne 0) { throw 'El servicio terminó con error.' }
} finally {
    Remove-Item Env:Sri__ApiKey -ErrorAction SilentlyContinue
    Pop-Location
}
