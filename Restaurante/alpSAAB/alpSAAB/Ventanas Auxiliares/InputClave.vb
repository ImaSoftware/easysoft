Public Class InputClave
    Public Enum Res_Input
        Exito = 1
        Failed = 2
    End Enum

    Private Sub InputClave_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Me.DialogResult = Res_Input.Failed
        End If
    End Sub
    Private Sub InputClave_Load(sender As Object, e As EventArgs) Handles Me.Load

        LabelBuffer1.CargarMensaje("Ingrese Clave Administrador", labelBuffer.TipoMensajeBuffer.Informativo)
        txtClave.UseSystemPasswordChar = True
        NumericaPad1.CuadroTexto(txtClave, 32)
    End Sub
    Private Sub NumericaPad1_Entrar() Handles NumericaPad1.Entrar
        'Dim a As DataTable = cargarConsulta("Select ClaveAdmin from SD_SysParam where Instancia ")
        'Dim clave As String = a(0)(0)
        If AdminSecurity.Verify(txtClave.Text, Parametros.AdminHash) Then
            Me.DialogResult = Res_Input.Exito
            Me.Close()
        Else
            LabelBuffer1.CargarMensaje("Clave incorrecta o acceso temporalmente bloqueado", labelBuffer.TipoMensajeBuffer.Alerta_Roja)
            txtClave.Text = ""
            txtClave.Focus()
        End If
    End Sub

End Class
