Public Class ItemInventario
    Public Codigo As String
    Public tipo As String
    Public nombre As String
    Public pathImagen As String
    Public Imagenproducto As Image
    Public Precio As Double
    Public Event CLickItemInv(ByVal sender As ItemInventario)
    Sub cargaritem(ByVal argCodigo As String, ByVal argtipo As String, ByVal argnombre As String, ByVal argpathImg As String, _
                   ByVal argPrecio As Double)
        Codigo = argCodigo
        tipo = argtipo
        Precio = argPrecio
        nombre = argnombre
        Me.lblDesc.Text = nombre
        pathImagen = argpathImg
        Imagenproducto = cargarImagen(Me.pathImagen)
        BtnImagen.BackgroundImage = Imagenproducto
        BtnImagen.BackgroundImageLayout = ImageLayout.Stretch
        txtNum.Text = 0
    End Sub
  
    Private Sub BtnImagen_DoubleClick(sender As Object, e As EventArgs) Handles BtnImagen.Click, Me.Click
        txtNum.Text = Numero(txtNum.Text) + 1
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub txtNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNum.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Arriba_Click(sender As Object, e As EventArgs) Handles Arriba.Click
        txtNum.Text = Numero(txtNum.Text) + 1
    End Sub

    Private Sub BtnImagen_DoubleClick1(sender As Object, e As EventArgs) Handles lblDesc.DoubleClick
        RaiseEvent CLickItemInv(Me)
    End Sub

    Private Sub Abajo_Click(sender As Object, e As EventArgs) Handles Abajo.Click
        If (Numero(txtNum.Text) - 1) >= 0 Then
            txtNum.Text = Numero(txtNum.Text) - 1
        End If
    End Sub
End Class
