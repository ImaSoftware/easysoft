Public Class Inicio
    

    Private Sub Inicio_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        presentadorR()
    End Sub
    Overloads Sub loader()
        presentador.Image = cargarImagen(Parametros.imgpublicidad)
    End Sub


    Sub presentadorR()
        Dim tam As Rectangle = Me.DisplayRectangle
        presentador.Height = tam.Height - Panel2.Bottom
        presentador.Width = tam.Width
        presentador.Location = New Point(0, Panel2.Bottom)
        presentador.Update()
        presentador.Refresh()
    End Sub
End Class
