#requires -Version 5.1
param([string]$ConnectionString = $env:EASYSOFT_ROOT_CONNECTION)
$ErrorActionPreference = 'Stop'
if ($PSVersionTable.PSEdition -ne 'Desktop') { throw 'Ejecute con Windows PowerShell 5.1 (powershell.exe).' }
if ([string]::IsNullOrWhiteSpace($ConnectionString)) { throw 'Configure EASYSOFT_ROOT_CONNECTION.' }
$library = Join-Path $PSScriptRoot '..\easySoft\DLIB\bin\Release\DLIB.dll'
if (!(Test-Path -LiteralPath $library)) { throw 'Compile Release antes de migrar.' }
Add-Type -Path $library
Add-Type -AssemblyName System.Data
$connection = New-Object System.Data.SqlClient.SqlConnection($ConnectionString)
$transaction = $null
try {
    $connection.Open()
    $transaction = $connection.BeginTransaction([System.Data.IsolationLevel]::Serializable)
    $command = $connection.CreateCommand()
    $command.Transaction = $transaction
    $command.CommandTimeout = 60
    $command.CommandText = "IF COL_LENGTH('dbo.usuarios','userpwdhash') IS NULL ALTER TABLE dbo.usuarios ADD userpwdhash nvarchar(256) NULL;"
    [void]$command.ExecuteNonQuery()
    $command.CommandText = 'SELECT codigo, userpwd, userpwdhash FROM dbo.usuarios WITH (UPDLOCK, HOLDLOCK)'
    $table = New-Object System.Data.DataTable
    $adapter = New-Object System.Data.SqlClient.SqlDataAdapter($command)
    [void]$adapter.Fill($table)
    $count = 0
    foreach ($row in $table.Rows) {
        if (![string]::IsNullOrWhiteSpace([string]$row.userpwdhash)) {
            if ([string]$row.userpwdhash -notmatch '^PBKDF2-SHA256\$600000\$[A-Za-z0-9+/]{22}==\$[A-Za-z0-9+/]{43}=$') {
                throw ('Hash no reconocido: código ' + $row.codigo + '. Se cancela la migración.')
            }
            continue
        }
        if ($row.userpwd -eq [DBNull]::Value -or [string]::IsNullOrEmpty([string]$row.userpwd)) {
            throw ('Usuario sin contraseña: código ' + $row.codigo + '. Restablezca su contraseña antes de migrar.')
        }
        $hash = [DLIB.PasswordSecurity]::Hash([string]$row.userpwd)
        $update = $connection.CreateCommand()
        try {
            $update.Transaction = $transaction
            $update.CommandTimeout = 30
            $update.CommandText = "UPDATE dbo.usuarios SET userpwdhash=@hash, userpwd='' WHERE codigo=@code AND ISNULL(userpwdhash,'')=''"
            [void]$update.Parameters.Add('@hash', [System.Data.SqlDbType]::NVarChar, 256)
            $update.Parameters['@hash'].Value = $hash
            [void]$update.Parameters.Add('@code', [System.Data.SqlDbType]::Int)
            $update.Parameters['@code'].Value = $row.codigo
            if ($update.ExecuteNonQuery() -ne 1) { throw 'La actualización del usuario no fue única; se cancela la migración.' }
            $count++
        } finally { $update.Dispose() }
    }
    $transaction.Commit()
    Write-Output ('Usuarios migrados: ' + $count)
} catch {
    if ($transaction) { try { $transaction.Rollback() } catch { } }
    throw
} finally {
    if ($adapter) { $adapter.Dispose() }
    if ($command) { $command.Dispose() }
    if ($transaction) { $transaction.Dispose() }
    $connection.Dispose()
}
