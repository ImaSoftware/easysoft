Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Public Module Database
    Public Function ConnectionString(ByVal fallback As String) As String
        Dim configured = Environment.GetEnvironmentVariable("SAAB_SQL_CONNECTION")
        If String.IsNullOrWhiteSpace(configured) Then configured = fallback
        If String.IsNullOrWhiteSpace(configured) Then Throw New InvalidOperationException("Configure SAAB_SQL_CONNECTION para esta instalación.")
        Dim builder As New SqlConnectionStringBuilder(configured)
        If String.IsNullOrWhiteSpace(builder.DataSource) OrElse String.IsNullOrWhiteSpace(builder.InitialCatalog) Then
            Throw New InvalidOperationException("Configure SAAB_SQL_CONNECTION con el servidor y la base de datos de esta instalación.")
        End If
        builder.ConnectTimeout = 15
        Return builder.ConnectionString
    End Function

    Public Function Query(ByVal sql As String, ByVal connection As String, ByVal ParamArray values() As Object) As DataTable
        Using cn As New SqlConnection(ConnectionString(connection)), command = CreateCommand(cn, sql, values)
            Dim result As New DataTable()
            Using adapter As New SqlDataAdapter(command)
                adapter.Fill(result)
            End Using
            Return result
        End Using
    End Function

    Public Function Execute(ByVal sql As String, ByVal connection As String, ByVal transactional As Boolean,
                            ByVal ParamArray values() As Object) As Integer
        Using cn As New SqlConnection(ConnectionString(connection)), command = CreateCommand(cn, sql, values)
            cn.Open()
            If Not transactional OrElse Transactions.Transaction.Current IsNot Nothing Then Return command.ExecuteNonQuery()
            Using tx = cn.BeginTransaction()
                command.Transaction = tx
                Try
                    Dim affected = command.ExecuteNonQuery()
                    tx.Commit()
                    Return affected
                Catch
                    Try
                        tx.Rollback()
                    Catch rollbackError As Exception
                        Trace.TraceError("No se pudo revertir la transacción: {0}", rollbackError.GetType().Name)
                    End Try
                    Throw
                End Try
            End Using
        End Using
    End Function

    Public Function CreateCommand(ByVal cn As SqlConnection, ByVal sql As String, ByVal values() As Object) As SqlCommand
        Dim command As New SqlCommand(sql, cn)
        command.CommandTimeout = 30
        If values Is Nothing Then values = New Object() {}
        For i = 0 To values.Length - 1
            command.Parameters.AddWithValue("@p" & i, If(values(i), DBNull.Value))
        Next
        Return command
    End Function

    Public Function Identifier(ByVal name As String) As String
        If String.IsNullOrWhiteSpace(name) Then Throw New ArgumentException("Identificador SQL vacío.")
        Dim parts = name.Split("."c)
        For i = 0 To parts.Length - 1
            If Not System.Text.RegularExpressions.Regex.IsMatch(parts(i), "\A[A-Za-z_][A-Za-z0-9_]*\z") Then
                Throw New ArgumentException("Identificador SQL inválido.")
            End If
            parts(i) = "[" & parts(i) & "]"
        Next
        Return String.Join(".", parts)
    End Function

    Public Function IdList(ByVal value As String) As Integer()
        Return Array.ConvertAll(value.Split(","c), Function(item) Integer.Parse(item.Trim(), Globalization.CultureInfo.InvariantCulture))
    End Function

    Public Function UserError(ByVal errorValue As Exception) As String
        Trace.TraceError("SAAB: {0}", errorValue.GetType().FullName)
        If TypeOf errorValue Is SqlException Then Return "No se pudo completar la operación en la base de datos. Verifique la conexión y vuelva a intentar."
        Return "No se pudo completar la operación. Verifique la configuración y los datos e intente nuevamente."
    End Function

    ' Coordinate the desktop client and service against the same SQL database.
    Public Sub Exclusive(ByVal resource As String, ByVal connection As String, ByVal operation As Action)
        Using cn As New SqlConnection(ConnectionString(connection)), command As New SqlCommand("DECLARE @result int; EXEC @result = sys.sp_getapplock @Resource = @p0, @LockMode = 'Exclusive', @LockOwner = 'Session', @LockTimeout = 1000; SELECT @result;", cn)
            command.Parameters.AddWithValue("@p0", resource)
            command.CommandTimeout = 5
            cn.Open()
            If CInt(command.ExecuteScalar()) < 0 Then Return
            Try
                operation()
            Finally
                command.CommandText = "EXEC sys.sp_releaseapplock @Resource = @p0, @LockOwner = 'Session'"
                command.ExecuteNonQuery()
            End Try
        End Using
    End Sub
End Module

' Legacy format strings become parameters, including placeholders enclosed in SQL quotes.
' SQL identifiers and complete SQL fragments must never be supplied as values.
Public Class SqlBatch
    Private ReadOnly statements As New Text.StringBuilder()
    Private ReadOnly values As New Collections.Generic.List(Of Object)()

    Public Sub AddFormat(ByVal template As String, ByVal ParamArray arguments() As Object)
        Dim names(arguments.Length - 1) As Object
        For i = 0 To arguments.Length - 1
            names(i) = "@p" & (values.Count + i)
            template = template.Replace("'{" & i & "}'", "{" & i & "}")
        Next
        Dim statement = String.Format(Globalization.CultureInfo.InvariantCulture, template, names)
        statements.AppendLine(statement & ";")
        values.AddRange(arguments)
    End Sub

    Public Function Execute(ByVal connection As String) As Integer
        Return Database.Execute(statements.ToString(), connection, True, values.ToArray())
    End Function

    Public Function Query(ByVal connection As String) As DataTable
        Return Database.Query(statements.ToString(), connection, values.ToArray())
    End Function
End Class

