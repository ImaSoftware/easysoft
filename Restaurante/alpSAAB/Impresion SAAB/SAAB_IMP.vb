Imports System.ServiceProcess

Public Class SAAB_IMP
    Private WithEvents temporizador As Timers.Timer
    Private ReadOnly processingLock As New Object()
    Private stopping As Boolean = True
    Private Const DefaultInterval As Integer = 8000

    Sub New()
        InitializeComponent()
        CanPauseAndContinue = False
    End Sub

    Private Function ReadInterval() As Integer
        Return ParseInterval(GetSetting("alpWin", "ImpresionSAAB", "Intervalo", DefaultInterval.ToString()))
    End Function

    Friend Shared Function ParseInterval(ByVal value As String) As Integer
        Dim interval As Integer
        If Not Integer.TryParse(value, interval) OrElse interval < 1000 Then
            interval = DefaultInterval
        End If
        Return interval
    End Function

    Protected Overrides Sub OnStart(ByVal args() As String)
        SyncLock processingLock
            stopping = False
            temporizador = New Timers.Timer(ReadInterval()) With {.AutoReset = False}
            temporizador.Start()
        End SyncLock
    End Sub

    Protected Overrides Sub OnStop()
        SyncLock processingLock
            stopping = True
            If temporizador IsNot Nothing Then
                temporizador.Stop()
                temporizador.Dispose()
                temporizador = Nothing
            End If
        End SyncLock
    End Sub

    Private Sub LogFailure(ByVal failure As Exception)
        Try
            EventLog.WriteEntry(Database.UserError(failure), Diagnostics.EventLogEntryType.Error)
        Catch
            Diagnostics.Trace.TraceError("SAAB_IMP: {0}", failure.GetType().Name)
        End Try
    End Sub

    Private Sub temporizador_Elapsed(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs) Handles temporizador.Elapsed
        SyncLock processingLock
            If stopping Then Return
            Try
                Dim documents = cargarConsulta("EXEC SDSP_BuscaDocu")
                For Each document As DataRow In documents.Rows
                    If Threading.Volatile.Read(stopping) Then Exit For
                    Try
                        Dim documentId As Integer
                        If Not Integer.TryParse(DataC(document("id")), documentId) OrElse documentId <= 0 Then Continue For
                        Select Case DataC(document("tipo"))
                            Case "C" : imprimeComanda(documentId)
                            Case "P" : imprimePrefactura(documentId)
                        End Select
                    Catch failure As Exception
                        LogFailure(failure)
                    End Try
                Next
            Catch failure As Exception
                LogFailure(failure)
            Finally
                If Not stopping AndAlso temporizador IsNot Nothing Then
                    temporizador.Interval = ReadInterval()
                    temporizador.Start()
                End If
            End Try
        End SyncLock
    End Sub
End Class


