Public Class miniOrden
    Public IdCom As Integer
    Public mini_newLoc As Point
    Public isFocus As Boolean = False
    Public Event enMiClick(sender As miniOrden)

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub New(_id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.IdCom = _id
        Me.lblOrden.Text = "# " + _id.ToString().Trim()

    End Sub


    Private Sub lblOrden_Click(sender As Object, e As EventArgs)
        Me.setFocus()
    End Sub
    Public Sub setFocus()
        isFocus = True
        Me.lblOrden.FlatAppearance.BorderSize = 5
        RaiseEvent enMiClick(Me)
    End Sub
    Public Sub quitFocus()
        isFocus = False
        Me.lblOrden.FlatAppearance.BorderSize = 0
    End Sub

    Private Sub lblOrden_GotFocus(sender As Object, e As EventArgs) Handles lblOrden.GotFocus
        Me.setFocus()
    End Sub



    Private Sub miniOrden_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub
End Class
Public Class miniSearch
    Dim _noIdCom As Integer

    Public Sub New(s As String)
        _noIdCom = s
    End Sub

    Public Function coincide(e As miniOrden) As Boolean
        Return e.IdCom = Me._noIdCom
    End Function
End Class