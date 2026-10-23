Public Class BarraNavegacionProducto
    Public Property pagina As Integer
    Property total As Integer
    Public Event Adelante()
    Public Event Atras()
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub New(ByVal argtotal)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        pagina = 1
        total = argTotal
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        lblPagina.Text = String.Format("Pagina {0} de {1}", pagina, total)
    End Sub

    Private Sub cmdback_Click(sender As Object, e As EventArgs) Handles cmdback.Click
        If pagina - 1 >= 1 Then
            pagina = pagina - 1
            lblPagina.Text = String.Format("Pagina {0} de {1}", pagina, total)
            RaiseEvent Atras()
        End If
       
    End Sub

    Private Sub cmdNext_Click(sender As Object, e As EventArgs) Handles cmdNext.Click
        If pagina + 1 <= total Then
            pagina = pagina + 1
            lblPagina.Text = String.Format("Pagina {0} de {1}", pagina, total)
            RaiseEvent Atras()
        End If
    End Sub
End Class
