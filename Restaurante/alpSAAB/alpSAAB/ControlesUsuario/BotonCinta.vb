Public Class BotonCinta
    Public Form, Imagen As String
    Public inform, adminrequired As Boolean
    Public Event ClickOPT(ByVal sender As BotonCinta)
    Sub New(ByVal argadmin As Boolean, ByVal arginform As Boolean, ByVal refform As String, ByVal refPng As String, ByVal refDes As String, ByVal txttooltipdes As String)
        Me.Form = refform
        Me.Imagen = Application.StartupPath & "\BMPs\" & refPng
        Me.inform = arginform
        Me.adminrequired = argadmin
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CmdDes.Text = refDes
        ', cmBotonRb.Size, Color.White)
        If DataC(txttooltipdes) <> "" Then
            ToolTipbtn.SetToolTip(cmBotonRb, txttooltipdes)
        End If
    End Sub

    Private Sub cmBotonRb_Click(sender As Object, e As EventArgs) Handles cmBotonRb.Click
        RaiseEvent ClickOPT(Me)
    End Sub

    Private Sub BotonCinta_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.cmBotonRb.BackColor = Me.ColorPrimario
        cmBotonRb.BackgroundImage = cargarImagen(Me.Imagen)
    End Sub
End Class
