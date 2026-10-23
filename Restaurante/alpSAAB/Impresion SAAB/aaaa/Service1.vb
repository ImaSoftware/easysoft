Public Class Service1
    Private WithEvents temporizador As Timers.Timer
    Private intervalo As Integer = 8000
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CanPauseAndContinue = True
        Dim sett As String = ""
        sett = GetSetting("alpWin", "ImpresionSAAB", "Intervalo")
        If String.IsNullOrEmpty(sett.Trim()) Then
            SaveSetting("alpWin", "ImpresionSAAB", "Intervalo", 8000)
            SaveSetting("alpWin", "ImpresionSAAB", "Intervalo", 8000)
        End If
        Integer.TryParse(sett, intervalo)
    End Sub
    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Agregue el código aquí para iniciar el servicio. Este método debería poner
        ' en movimiento los elementos para que el servicio pueda funcionar.
        EventLog.WriteEntry("IMPRESION SAAB HA ARRANCADO")
        temporizador = New Timers.Timer(intervalo)
        temporizador.Start()
    End Sub

    Protected Overrides Sub OnStop()
        EventLog.WriteEntry("IMPRESION SAAB SE DETIENE")
        temporizador.Stop()
        ' Agregue el código aquí para realizar cualquier anulación necesaria para detener el servicio.

    End Sub
    Private Sub temporizador_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles temporizador.Elapsed
        '
        ' deshabilitar temporalmente el timer
        temporizador.Enabled = False
        'leer nuevo valor de temporizador 
        Dim sett As String = ""
        sett = GetSetting("alpWin", "ImpresionSAAB", "Intervalo")
        If Not String.IsNullOrEmpty(sett.Trim()) Then Integer.TryParse(sett, intervalo)
        ' asignar el nuevo valor del temporizador
        If intervalo <> temporizador.Interval Then
            temporizador.Interval = intervalo
        End If

        'aqui realizar todo lo que debo hacer 

        Dim Documentos As DataTable = cargarConsulta("EXEC SDSP_BuscaDocu")
        If Not IsNothing(Documentos) Then

            For Each Documento As DataRow In Documentos.Rows
                ' MsgBox(Documento.Item("tipo"))
                If Documento.Item("tipo") = "C" Then
                    If Not String.IsNullOrEmpty(DataC(Documento.Item("id"))) Then imprimeComanda(DataC(Documento.Item("id")))
                End If
                If Documento.Item("tipo") = "P" Then
                    If Not String.IsNullOrEmpty(DataC(Documento.Item("id"))) Then imprimePrefactura(DataC(Documento.Item("id")))
                End If

            Next
        End If

        ' volver a habilitar el timer
        temporizador.Enabled = True
    End Sub

End Class
