[CmdletBinding()]
param(
    [Parameter(Mandatory=$true)][string]$EmisorJson,
    [Parameter(Mandatory=$true)][string]$FacturaJson,
    [Parameter(Mandatory=$true)][string]$Certificado,
    [int]$TimeoutSeconds = 180
)
$ErrorActionPreference = 'Stop'
$taskRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..'))
$apiKey = [IO.File]::ReadAllText((Join-Path $taskRoot 'secrets/api-key.txt')).Trim()
$headers = @{ Authorization = "Bearer $apiKey" }
$baseUrl = 'http://127.0.0.1:5088/api'
$issuerBody = [IO.File]::ReadAllText((Resolve-Path -LiteralPath $EmisorJson))
$invoiceBody = [IO.File]::ReadAllText((Resolve-Path -LiteralPath $FacturaJson))
$invoice = $invoiceBody | ConvertFrom-Json
# Deterministic across invocations for the same reference. Changed content with that reference is a conflict.
$headers['Idempotency-Key'] = $invoice.referencia
Invoke-RestMethod -Method Put -Uri "$baseUrl/configuracion/emisor" -Headers $headers -ContentType 'application/json; charset=utf-8' -Body ([Text.Encoding]::UTF8.GetBytes($issuerBody)) | Out-Null
$securePassword = Read-Host 'Contraseña de la firma (no se guardará)' -AsSecureString
$passwordPointer = [Runtime.InteropServices.Marshal]::SecureStringToBSTR($securePassword)
try {
    $credentialBody = @{ ruta = [IO.Path]::GetFullPath((Resolve-Path -LiteralPath $Certificado)); password = [Runtime.InteropServices.Marshal]::PtrToStringBSTR($passwordPointer) } | ConvertTo-Json
    Invoke-RestMethod -Method Post -Uri "$baseUrl/configuracion/firma" -Headers $headers -ContentType 'application/json; charset=utf-8' -Body ([Text.Encoding]::UTF8.GetBytes($credentialBody)) | Out-Null
} finally {
    [Runtime.InteropServices.Marshal]::ZeroFreeBSTR($passwordPointer)
    $credentialBody = $null
    $securePassword.Dispose()
}
$result = Invoke-RestMethod -Method Post -Uri "$baseUrl/facturas" -Headers $headers -ContentType 'application/json; charset=utf-8' -Body ([Text.Encoding]::UTF8.GetBytes($invoiceBody))
$deadline = [DateTimeOffset]::UtcNow.AddSeconds($TimeoutSeconds)
do {
    $result = Invoke-RestMethod -Uri "$baseUrl/comprobantes/$($result.id)" -Headers $headers
    Write-Host "$($result.state) - $($result.accessKey)"
    if ($result.state -in @('Authorized','Rejected','LocalError','NeedsAttention')) { break }
    Start-Sleep -Seconds 5
} while ([DateTimeOffset]::UtcNow -lt $deadline)
if ($result.state -eq 'Authorized') {
    $outputDirectory = Join-Path $taskRoot "artifacts/$($result.id)"
    New-Item -ItemType Directory -Force -Path $outputDirectory | Out-Null
    foreach ($kind in @('generado','firmado','autorizado')) {
        Invoke-WebRequest -Uri "$baseUrl/comprobantes/$($result.id)/xml/$kind" -Headers $headers -OutFile (Join-Path $outputDirectory "$kind.xml") -UseBasicParsing
    }
    Invoke-WebRequest -Uri "$baseUrl/comprobantes/$($result.id)/evidencia" -Headers $headers -OutFile (Join-Path $outputDirectory 'respuestas-sri.json') -UseBasicParsing
    Write-Host "AUTORIZADO EN PRUEBAS. Evidencia: $outputDirectory"
} else {
    $result | Select-Object id,state,lastError,messages | Format-List
    Write-Host 'El hito todavía no está cumplido. Consulta la consola; no cambies referencia ni crees otra factura para resolver un timeout.'
    exit 2
}
