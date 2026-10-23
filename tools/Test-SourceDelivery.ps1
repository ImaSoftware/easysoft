$ErrorActionPreference = 'Stop'
Push-Location (Split-Path -Parent $PSScriptRoot)
try {
    $files = @(git ls-files)
    if ($LASTEXITCODE -ne 0) { throw 'No se pudo leer el índice de Git.' }
    $forbidden = @($files | Where-Object {
        $_ -match '(^|/)(bin|obj|packages|node_modules|\.vs|\.hg|\.svn)/' -or
        $_ -match '\.(dll|exe|pdb|suo|user|zip|rar|7z|bak|p12|pfx|snk|key|pem|mdf|ldf|sqlite)$' -or
        $_ -match '(^|/)(certpass|cadenasConexion)\.txt$'
    })
    if ($forbidden.Count) { throw "Archivos ajenos a la entrega de fuentes:`n$($forbidden -join "`n")" }
    foreach ($required in @('easySoft/easySoft.sln', 'TimbradoSRI/utilWs/SRI_Ws.sln', 'Restaurante/alpSAAB/SAAB.sln')) {
        if ($files -notcontains $required) { throw "Falta en Git: $required" }
    }
    Write-Host "Entrega revisada: $($files.Count) archivos; tres soluciones presentes; sin binarios, claves, respaldos ni cachés en el índice."
    Write-Host 'Este control no sustituye una revisión de secretos dentro del código ni las pruebas de compilación.'
} finally {
    Pop-Location
}
