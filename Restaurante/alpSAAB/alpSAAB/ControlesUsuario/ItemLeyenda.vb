Public Class ItemLeyenda
    Sub New(argdesc As String, argpcolor As Color)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        lblNombre.Text = argdesc
        PanelColor.BackColor = argpcolor
    End Sub
End Class
