Imports SAAB

Public Class BusquedaS
    Public xdev As Object = Nothing

    Private idForm As String = "xDis"
    Private idCol As String = "xcol"

    Sub New(IdForm As String, xidCol As String)
        Me.idForm = IdForm
        Me.idCol = xidCol
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub devRet(ByVal sender As Object, ByVal e As EventArgs) Handles busqueda1.ctlReturn
        If (CType(sender, busqueda)).Resultado Is Nothing Then
            Me.DialogResult = DialogResult.Cancel
            Me.xdev = (CType(sender, busqueda)).Resultado
            Me.Close()
        Else
            Me.DialogResult = DialogResult.OK
            Me.xdev = (CType(sender, busqueda)).Resultado
            Me.Close()
        End If
    End Sub


End Class