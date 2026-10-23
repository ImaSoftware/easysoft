Public Class SplashSD
    Sub New()
        'evaluar Licencia 
        'Dim verificador As alpSecurity.verilic = New alpSecurity.verilic()
        'If Not verificador.verificarLicencia(Globales.idProducto, Globales.NombreProducto) Then
        '    If verificador.ErrFlag Then
        '        Dim Errs As String = ""
        '        For i = 0 To verificador.ErrMsg.Length - 1 Step 1
        '            Errs = Errs + verificador.ErrMsg(i) + Environment.NewLine
        '        Next
        '        MessageBox.Show("Se han presentado Errores: " + Environment.NewLine + Errs)
        '    End If
        '    End
        'End If
        '' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Dim lblInformativo As New labelBuffer
    Private Property usuario As Usuario

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        System.Diagnostics.Process.Start("http://syscompsa.com/")
    End Sub

    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox4.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox4.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub SplashSD_Load(sender As Object, e As EventArgs) Handles Me.Load


        Me.WindowState = FormWindowState.Normal
        Me.Show()

    End Sub









End Class
