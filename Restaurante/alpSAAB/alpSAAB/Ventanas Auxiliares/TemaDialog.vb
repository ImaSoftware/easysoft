Imports System.Windows.Forms

Public Class TemaDialog
    Property ID As Integer
    Property colorPrimario As Color
    Property colorSecundario As Color
    Property FontName As String
    Property fontsize As Integer
    Property nombre As String
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        colorPrimario = Color.Black
        colorSecundario = Color.White
        FontName = "Times New Roman"
        fontsize = 14
        nombre = "Nuevo Tema"
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarElementosPantalla()
    End Sub
    Sub New(ByVal datos As DataRow)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ID = DataC(datos("id"))
        colorPrimario = Color.FromArgb(datos("DolphinColor1"))
        colorSecundario = Color.FromArgb(datos("DolphinColor2"))
        FontName = DataC(datos("f_name"))
        fontsize = DataC(datos("f_size"))
        nombre = DataC(datos("Nombre"))
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarElementosPantalla()
    End Sub
    Sub cargarElementosPantalla()
        CD1.BackColor = colorPrimario
        CD2.BackColor = colorSecundario
        lblFn.Text = FontName
        lblFs.Text = fontsize
        txtnombre.Text = nombre
        Me.Text = "Editor de temas : " & nombre
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CD1_Click(sender As Button, e As EventArgs) Handles CD1.Click, CD2.Click
        If ColorDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            If sender.Name = CD1.Name Then
                colorPrimario = ColorDialog1.Color
            Else
                colorSecundario = ColorDialog1.Color
            End If
            cargarElementosPantalla()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FontDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            FontName = FontDialog1.Font.Name
            fontsize = FontDialog1.Font.SizeInPoints
            cargarElementosPantalla()
        End If
    End Sub

    Private Sub txtnombre_TextChanged(sender As Object, e As EventArgs) Handles txtnombre.TextChanged
        nombre = txtnombre.Text
        cargarElementosPantalla()
    End Sub
End Class
