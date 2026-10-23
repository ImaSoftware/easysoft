Imports System.Reflection
Imports System.Data.SqlClient

Module Program
    Private passed As Integer

    Friend Sub Check(ByVal condition As Boolean, ByVal message As String)
        If Not condition Then Throw New Exception(message)
        passed += 1
    End Sub

    Private Sub Reject(ByVal operation As Action)
        Dim rejected As Boolean
        Try
            operation()
        Catch ex As ArgumentException
            rejected = True
        Catch ex As FormatException
            rejected = True
        End Try
        Check(rejected, "Se aceptó una entrada SQL inválida.")
    End Sub

    Sub Main()
        Try
            FlowTests.Run()
            Check(SAAB_IMP.ParseInterval(Nothing) = 8000, "Intervalo ausente")
            Check(SAAB_IMP.ParseInterval("") = 8000, "Intervalo vacío")
            Check(SAAB_IMP.ParseInterval("0") = 8000, "Intervalo cero")
            Check(SAAB_IMP.ParseInterval("-1") = 8000, "Intervalo negativo")
            Check(SAAB_IMP.ParseInterval("invalido") = 8000, "Intervalo inválido")
            Check(SAAB_IMP.ParseInterval("99999999999") = 8000, "Desbordamiento")
            Check(SAAB_IMP.ParseInterval("12000") = 12000, "Intervalo válido")

            Dim hash = AdminSecurity.HashPassword("123456")
            Check(hash <> AdminSecurity.HashPassword("123456"), "Falta sal aleatoria")
            Check(AdminSecurity.Verify("123456", hash), "Verificación correcta")
            Check(Not AdminSecurity.Verify("654321", hash), "Clave incorrecta aceptada")
            Check(Not AdminSecurity.Verify("", hash), "Clave vacía aceptada")
            Check(Not AdminSecurity.Verify("123456", "PBKDF2$100000$!$!"), "Hash corrupto aceptado")
            Check(AdminSecurity.Verify("123456", hash), "Fallos anteriores invalidan la clave correcta")

            Check(Database.Identifier("dbo.SD_Mesas") = "[dbo].[SD_Mesas]", "Identificador compuesto")
            Reject(Sub() Database.Identifier("SD_Mesas; DROP TABLE x"))
            Reject(Sub() Database.IdList("1,2); DROP TABLE x"))
            Check(Database.IdList("1, 2,3")(1) = 2, "Lista de identificadores")

            Dim payload = "O'Brien'; DROP TABLE SD_Mesas;--"
            Dim batch As New SqlBatch()
            batch.AddFormat("UPDATE SD_Mesas SET Alias = '{0}' WHERE Id = {1}", payload, 7)
            batch.AddFormat("UPDATE SD_Textos SET Texto = '{0}' WHERE Id = {1}", "{0}", 8)
            Dim sql = DirectCast(GetType(SqlBatch).GetField("statements", BindingFlags.Instance Or BindingFlags.NonPublic).GetValue(batch), Text.StringBuilder).ToString()
            Dim values = DirectCast(GetType(SqlBatch).GetField("values", BindingFlags.Instance Or BindingFlags.NonPublic).GetValue(batch), Collections.Generic.List(Of Object))
            Check(Not sql.Contains(payload) AndAlso Not sql.Contains("'{0}'"), "Entrada concatenada al SQL")
            Check(sql.Contains("@p0") AndAlso sql.Contains("@p2"), "Parámetros de lote repetidos")
            Check(CStr(values(0)) = payload AndAlso CInt(values(3)) = 8, "Valores alterados")
            Using connection As New SqlConnection(), command = Database.CreateCommand(connection, "SELECT @p0", New Object() {payload})
                Check(CStr(command.Parameters("@p0").Value) = payload, "Parámetro alterado")
                Check(command.CommandTimeout = 30, "Consulta sin tiempo límite")
            End Using

            Dim oldConnection = Environment.GetEnvironmentVariable("SAAB_SQL_CONNECTION")
            Try
                Environment.SetEnvironmentVariable("SAAB_SQL_CONNECTION", "Data Source=example;Initial Catalog=restaurant;Integrated Security=True")
                Check(New SqlConnectionStringBuilder(Database.ConnectionString("invalid")).InitialCatalog = "restaurant", "Se ignoró la configuración externa")
            Finally
                Environment.SetEnvironmentVariable("SAAB_SQL_CONNECTION", oldConnection)
            End Try

            Using service As New SAAB_IMP()
                Dim flags = BindingFlags.Instance Or BindingFlags.NonPublic
                Dim serviceType = GetType(SAAB_IMP)
                serviceType.GetMethod("OnStart", flags).Invoke(service, New Object() {New String() {}})
                Try
                    FUGSD.FailQuery = True
                    serviceType.GetMethod("temporizador_Elapsed", flags).Invoke(service, New Object() {Nothing, Nothing})
                    Dim timer = DirectCast(serviceType.GetProperty("temporizador", flags).GetValue(service, Nothing), Timers.Timer)
                    Check(timer.Enabled, "El temporizador no se recuperó de un error SQL")
                    FUGSD.FailQuery = False
                    serviceType.GetMethod("temporizador_Elapsed", flags).Invoke(service, New Object() {Nothing, Nothing})
                    Check(FUGSD.Printed = 1, "Un documento fallido impidió procesar el siguiente")
                    Check(timer.Enabled, "El temporizador quedó detenido tras un error de impresión")
                Finally
                    serviceType.GetMethod("OnStop", flags).Invoke(service, Nothing)
                End Try
                serviceType.GetMethod("temporizador_Elapsed", flags).Invoke(service, New Object() {Nothing, Nothing})
                Check(serviceType.GetProperty("temporizador", flags).GetValue(service, Nothing) Is Nothing, "Se reinició el servicio después de detenerlo")
            End Using

            For i = 1 To 5
                AdminSecurity.Verify("incorrecta", hash)
            Next
            Check(Not AdminSecurity.Verify("123456", hash), "No se limitan los intentos de acceso")
            Console.WriteLine("PASS: " & passed & " comprobaciones; sin conexión SQL ni impresora.")
        Catch ex As Exception
            Console.Error.WriteLine(ex)
            Environment.ExitCode = 1
        End Try
    End Sub
End Module

' Test doubles for the external queue and the Windows service designer only.
Partial Public Class SAAB_IMP
    Inherits ServiceProcess.ServiceBase
    Private Sub InitializeComponent()
    End Sub
End Class

Module FUGSD
    Public FailQuery As Boolean
    Public Printed As Integer
    Public Documents As DataTable
    Public QueryCount As Integer
    Public ReadOnly Calls As New Collections.Generic.List(Of String)()
    Public FailComanda As Boolean = True
    Public FailPrefactura As Boolean
    Public Function cargarConsulta(ByVal sql As String) As DataTable
        QueryCount += 1
        If FailQuery Then Throw New InvalidOperationException("Simulated SQL failure")
        If Documents IsNot Nothing Then Return Documents
        Dim table As New DataTable()
        table.Columns.Add("id", GetType(Integer))
        table.Columns.Add("tipo", GetType(String))
        table.Rows.Add(1, "C")
        table.Rows.Add(2, "P")
        Return table
    End Function
    Public Function DataC(ByVal value As Object) As String
        Return Convert.ToString(value)
    End Function
    Public Sub imprimeComanda(ByVal id As Integer)
        Calls.Add("C:" & id)
        If FailComanda Then Throw New InvalidOperationException("Simulated printer failure")
    End Sub
    Public Sub imprimePrefactura(ByVal id As Integer)
        Calls.Add("P:" & id)
        If FailPrefactura Then Throw New InvalidOperationException("Simulated printer failure")
        Printed += 1
    End Sub
End Module

