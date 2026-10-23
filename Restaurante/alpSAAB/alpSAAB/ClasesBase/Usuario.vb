
Public Class Usuario

    Property nombre As String

    Property password As String

    Property IDSesion As Object

    Sub IniciarSesion()
        Me.IDSesion = Nothing
        Throw New NotSupportedException("Use la identificación de meseros o el acceso administrativo del sistema.")

    End Sub


End Class

