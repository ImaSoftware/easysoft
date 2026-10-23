Imports System.Data.SqlClient
Imports System.Reflection

Module FlowTests
    Private Const Hidden As BindingFlags = BindingFlags.NonPublic Or BindingFlags.Instance

    Friend Sub Run()
        ConfigurationFlow()
        BatchFlow()
        SecurityFlow()
        QueueFlow()
    End Sub

    Private Sub Expect(Of T As Exception)(ByVal action As Action, ByVal description As String)
        Try
            action()
        Catch ex As Exception
            Program.Check(TypeOf ex Is T, description & ": excepción inesperada " & ex.GetType().Name)
            Return
        End Try
        Program.Check(False, description & ": faltó rechazar la entrada")
    End Sub

    Private Sub ConfigurationFlow()
        Dim previous = Environment.GetEnvironmentVariable("SAAB_SQL_CONNECTION")
        Try
            Environment.SetEnvironmentVariable("SAAB_SQL_CONNECTION", Nothing)
            Expect(Of InvalidOperationException)(Sub() Database.ConnectionString(Nothing), "Configuración ausente")
            Expect(Of InvalidOperationException)(Sub() Database.ConnectionString("Data Source=server"), "Base ausente")
            Expect(Of InvalidOperationException)(Sub() Database.ConnectionString("Initial Catalog=db"), "Servidor ausente")
            Dim fallback = "Data Source=local;Initial Catalog=test;Integrated Security=True;Connect Timeout=90"
            Dim parsed As New SqlConnectionStringBuilder(Database.ConnectionString(fallback))
            Program.Check(parsed.ConnectTimeout = 15 AndAlso parsed.IntegratedSecurity, "Fallback y límite de conexión")
            Environment.SetEnvironmentVariable("SAAB_SQL_CONNECTION", "   ")
            Program.Check(New SqlConnectionStringBuilder(Database.ConnectionString(fallback)).DataSource = "local", "Entorno vacío usa fallback")
            Environment.SetEnvironmentVariable("SAAB_SQL_CONNECTION", "invalid")
            Expect(Of ArgumentException)(Sub() Database.ConnectionString(fallback), "Configuración externa inválida no usa fallback silencioso")
        Finally
            Environment.SetEnvironmentVariable("SAAB_SQL_CONNECTION", previous)
        End Try
        For Each candidate As String In New String() {Nothing, "", "dbo..Mesas", "dbo.Mesas]", "dbo.Mesas--", "1mesa", "dbo.Mesas" & vbLf}
            Expect(Of ArgumentException)(Sub() Database.Identifier(candidate), "Identificador inválido")
        Next
        Program.Check(Database.Identifier("_schema.Mesas_2") = "[_schema].[Mesas_2]", "Identificador válido")
        Expect(Of OverflowException)(Sub() Database.IdList("2147483648"), "ID fuera de rango")
        Expect(Of FormatException)(Sub() Database.IdList("1,,2"), "Lista incompleta")
        Program.Check(Not Database.UserError(New Exception("password=secret")).Contains("secret"), "Error sin secretos")
        Program.Check(SAAB_IMP.ParseInterval("999") = 8000, "Intervalo bajo mínimo")
        Program.Check(SAAB_IMP.ParseInterval("1000") = 1000, "Intervalo mínimo")
    End Sub

    Private Sub BatchFlow()
        Dim batch As New SqlBatch()
        batch.AddFormat("INSERT INTO demo VALUES ({0}, {1}, {2}, {0})", "O'Brien", 1.25D, Nothing)
        Expect(Of FormatException)(Sub() batch.AddFormat("SELECT {1}", "discard"), "Formato inválido")
        batch.AddFormat("SELECT '{0}'", "next")
        Dim sql = DirectCast(GetType(SqlBatch).GetField("statements", Hidden).GetValue(batch), Text.StringBuilder).ToString()
        Dim values = DirectCast(GetType(SqlBatch).GetField("values", Hidden).GetValue(batch), Collections.Generic.List(Of Object))
        Program.Check(values.Count = 4 AndAlso CStr(values(3)) = "next", "Lote fallido no deja parámetros huérfanos")
        Program.Check(sql.Contains("@p0, @p1, @p2, @p0") AndAlso sql.Contains("SELECT @p3"), "Parámetros repetidos y consecutivos")
        Using cn As New SqlConnection(), command = Database.CreateCommand(cn, sql, values.ToArray())
            Program.Check(command.Parameters.Count = 4, "Cantidad de parámetros")
            Program.Check(command.Parameters("@p2").Value Is DBNull.Value, "Nothing se convierte a SQL NULL")
            Program.Check(CDec(command.Parameters("@p1").Value) = 1.25D, "Decimal conserva precisión")
        End Using
        Using command = Database.CreateCommand(Nothing, "SELECT 1", Nothing)
            Program.Check(command.Parameters.Count = 0, "Comando sin argumentos")
        End Using
    End Sub

    Private Sub ResetSecurity()
        GetType(AdminSecurity).GetField("failures", BindingFlags.NonPublic Or BindingFlags.Static).SetValue(Nothing, 0)
        GetType(AdminSecurity).GetField("blockedUntil", BindingFlags.NonPublic Or BindingFlags.Static).SetValue(Nothing, DateTime.MinValue)
    End Sub

    Private Sub SecurityFlow()
        ResetSecurity()
        Try
            Expect(Of ArgumentException)(Sub() AdminSecurity.HashPassword(Nothing), "Clave nula")
            Dim hash = AdminSecurity.HashPassword("0123")
            For Each invalid In New String() {Nothing, "", "PBKDF2$99999$a$b", "PBKDF2$1000001$a$b", "PBKDF2$2147483648$a$b", "PBKDF2$100000$AA==$AA==", "OTHER$100000$a$b"}
                ResetSecurity()
                Program.Check(Not AdminSecurity.Verify("0123", invalid), "Credencial dañada rechazada")
            Next
            ResetSecurity()
            For i = 1 To 4
                Program.Check(Not AdminSecurity.Verify("bad", hash), "Intento incorrecto")
            Next
            Program.Check(AdminSecurity.Verify("0123", hash), "Cuatro fallos permiten autenticación")
            For i = 1 To 4
                AdminSecurity.Verify("bad", hash)
            Next
            Program.Check(AdminSecurity.Verify("0123", hash), "Autenticación reinicia contador")
            For i = 1 To 5
                AdminSecurity.Verify("bad", hash)
            Next
            Program.Check(Not AdminSecurity.Verify("0123", hash), "Quinto fallo bloquea clave correcta")
            GetType(AdminSecurity).GetField("blockedUntil", BindingFlags.NonPublic Or BindingFlags.Static).SetValue(Nothing, DateTime.UtcNow.AddSeconds(-1))
            Program.Check(AdminSecurity.Verify("0123", hash), "Acceso tras vencer bloqueo sin esperar un minuto")
        Finally
            ResetSecurity()
        End Try
    End Sub

    Private Sub QueueFlow()
        Dim table As New DataTable()
        table.Columns.Add("id", GetType(String))
        table.Columns.Add("tipo", GetType(String))
        For Each invalid In New String() {Nothing, "", "bad", "0", "-1", "2147483648"}
            table.Rows.Add(If(invalid Is Nothing, CType(DBNull.Value, Object), invalid), "C")
        Next
        table.Rows.Add("1", "unknown")
        table.Rows.Add("2", "C")
        table.Rows.Add("3", "P")
        table.Rows.Add("4", "C")
        FUGSD.Documents = table
        FUGSD.Calls.Clear()
        FUGSD.FailComanda = False
        FUGSD.FailPrefactura = True
        FUGSD.QueryCount = 0
        Using service As New SAAB_IMP()
            Dim serviceType = GetType(SAAB_IMP)
            serviceType.GetMethod("OnStart", Hidden).Invoke(service, New Object() {New String() {}})
            Try
                ' Disable real callbacks: this test invokes each cycle synchronously.
                Dim timer = DirectCast(serviceType.GetProperty("temporizador", Hidden).GetValue(service, Nothing), Timers.Timer)
                timer.Stop()
                serviceType.GetMethod("temporizador_Elapsed", Hidden).Invoke(service, New Object() {Nothing, Nothing})
                timer.Stop()
                Program.Check(String.Join(",", FUGSD.Calls) = "C:2,P:3,C:4", "Filtra IDs/tipos y continúa tras prefactura fallida")
                table.Clear()
                FUGSD.Calls.Clear()
                serviceType.GetMethod("temporizador_Elapsed", Hidden).Invoke(service, New Object() {Nothing, Nothing})
                Program.Check(timer.Enabled AndAlso FUGSD.Calls.Count = 0, "Cola vacía rearma temporizador sin imprimir")
            Finally
                serviceType.GetMethod("OnStop", Hidden).Invoke(service, Nothing)
                FUGSD.Documents = Nothing
                FUGSD.FailComanda = True
                FUGSD.FailPrefactura = False
            End Try
            Dim queries = FUGSD.QueryCount
            serviceType.GetMethod("temporizador_Elapsed", Hidden).Invoke(service, New Object() {Nothing, Nothing})
            Program.Check(FUGSD.QueryCount = queries, "Servicio detenido no consulta cola")
        End Using
    End Sub
End Module
