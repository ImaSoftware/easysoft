Public Class NumericaPad
    Public Event Entrar()
    Public salida As TextBox
    Public maxlen As Integer = 99
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub CuadroTexto(ByRef argsalida As TextBox, ByVal argmaxlen As Integer)
        maxlen = argmaxlen
        salida = argsalida
        salida.ReadOnly = True
    End Sub
    Private Sub btn_7_Click(sender As Object, e As EventArgs) Handles btn_0.Click, btn_1.Click, btn_2.Click, btn_3.Click, btn_4.Click, btn_5.Click, btn_6.Click, btn_7.Click, btn_8.Click, btn_9.Click
        Dim x() As String = Split(sender.name, "_")
        If Len(salida.Text) = maxlen Then
            Exit Sub
        End If
        If salida.SelectedText.Length > 0 Then
            salida.SelectedText = x(1)
        Else
            salida.Text = salida.Text & x(1)
        End If

    End Sub
    Private Sub btnBackspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackspace.Click
        Dim control As TextBox = salida
        If Len(control.Text) = 0 Then Exit Sub
        If control.SelectedText.Length > 0 Then
            control.SelectedText = ""
        Else
            control.Text = Mid(control.Text, 1, Len(control.Text) - 1)
        End If
    End Sub
    Sub ocultaEnter()
        Dim t_1 As Integer
        t_1 = Me.btnNext.Right
        btnNext.Visible = False
        btn_0.Size = New Size(t_1 - btn_0.Left, btn_0.Height)
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        RaiseEvent Entrar()
    End Sub

    Private Sub PanelNumerico_Paint(sender As Object, e As PaintEventArgs) Handles PanelNumerico.Paint

    End Sub
End Class
