Public Class Esquematizador
    Property IdArea As Integer = -1
    Dim EsTexto As Boolean = False
    Public Sub cargarTodo(ByVal argArea As Integer)
        Me.IdArea = argArea
        Sector.Diseño = True
        Sector.cargarSector(Me.IdArea)
        Me.Text = Sector.Nombre & "; Id : " & Sector.Id
        Sector.VisiblePuntos(True)
        Me.lblNombre.Text = Sector.Nombre
        Sector.cargarTodo()
        LiberarMemoria()
    End Sub
    Private Sub cmdImagen_Click(sender As Object, e As EventArgs) Handles cmdImagen.Click
        Sector.PegarElemento(Area.tipoElemento.imagen)
    End Sub

    Private Sub cmdGrabar_Click(sender As Object, e As EventArgs) Handles cmdGrabar.Click
        Sector.GuardarArea()
        cargarTodo(Sector.Id)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Sector.PegarElemento(Area.tipoElemento.texto)
        LiberarMemoria()
    End Sub
   
    Private Sub cmdMesa_Click(sender As Object, e As EventArgs) Handles cmdMesa.Click
        Sector.PegarElemento(Area.tipoElemento.mesa)
        LiberarMemoria()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.IdArea = -1 Then

        End If
        Sector.cargarTodo()
        LiberarMemoria()
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub
End Class