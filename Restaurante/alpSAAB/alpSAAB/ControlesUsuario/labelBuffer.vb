Public Class labelBuffer
    Dim TamañoF As Single = 9
    Public Enum TipoMensajeBuffer
        Informativo = 0
        Alerta_Verde = 1
        Alerta_Amarilla = 2
        Alerta_Roja = 3
    End Enum
    Sub CargarMensaje(ByVal Mensaje As String, ByVal Modo As TipoMensajeBuffer)
        Me.Text = Mensaje
        Select Case Modo
            Case TipoMensajeBuffer.Informativo
                Me.ForeColor = Color.Black
                Me.Font = New Font(Me.Font.Name, TamañoF)
            Case TipoMensajeBuffer.Alerta_Verde
                Me.ForeColor = Color.Green
                Me.Font = New Font(Me.Font.Name, TamañoF + 1)
            Case TipoMensajeBuffer.Alerta_Amarilla
                Me.ForeColor = Color.Yellow
                Me.Font = New Font(Me.Font.Name, TamañoF + 2)
            Case TipoMensajeBuffer.Alerta_Roja
                Me.ForeColor = Color.Red
                Me.Font = New Font(Me.Font.Name, TamañoF + 3)
        End Select
        Me.Refresh()
    End Sub
End Class
