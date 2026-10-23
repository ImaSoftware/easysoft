Imports System.Drawing.Drawing2D

Public Class botonpunto
    Dim loaded As Boolean = False
    Public Event SeMovio(ByVal nuevaPos As Point)
    Public Event Eliminarpto(ByVal boton As botonpunto)
    Public Const TAM As Integer = 20
    Private arrastrar As Boolean = False
    Public orx As Double
    Public ory As Double
    Public Id As Integer
    Public IdPunto As Integer
    Public IdArea As Integer
    Dim InicioMouse As Point
    Sub New(ByVal refID As Integer, ByVal refIdp As Integer, ByVal refIdArea As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Id = refID
        Me.IdPunto = refIdp
        Me.IdArea = refIdArea
        Dim gp As New GraphicsPath(FillMode.Alternate)
        gp.AddEllipse(New Rectangle(0, 0, TAM, TAM))
        Me.Region = New Region(gp)
        Me.Location = New Point(Me.Location.X, Me.Location.Y)
        Me.orx = Me.Location.X
        Me.ory = Me.Location.Y
        ActualizaId(Me.IdPunto)
    End Sub
    Public Sub ActualizaId(ByVal IDval As Integer)
        Me.IdPunto = IDval
        ToolTip1.SetToolTip(Me, "Id : " + CStr(Me.IdPunto))
        Me.Text = Me.IdPunto
        Me.Name = "btnpto" + CStr(IdPunto)
    End Sub

    Private Sub botonpunto_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        RaiseEvent SeMovio(DirectCast(sender, botonpunto).Location)
    End Sub

    Private Sub botonpunto_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick

    End Sub



    Private Sub botonpunto_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            arrastrar = True
        End If
    End Sub

    Private Sub botonpunto_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If arrastrar Then
            If ((Me.Location.X + e.X) <= 10) Or ((Me.Location.Y + e.Y) <= 10) Then Exit Sub
            Me.Location = New Point(Me.Location.X + e.X - TAM / 2, Me.Location.Y + e.Y - TAM / 2)
            orx = Me.Location.X
            ory = Me.Location.Y
            arrastrar = False
        End If

    End Sub



    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles Eliminar.Click
        If MsgBox("¿Esta seguro de eliminar este vértice?", MsgBoxStyle.YesNo, "Confirmacion") = MsgBoxResult.Yes Then
            RaiseEvent Eliminarpto(Me)
        Else
            Return
        End If
    End Sub

    Private Sub Menupunto_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Menupunto.Opening
        If Not DirectCast(Me.Parent, Area).Diseño Or DirectCast(Me.Parent, Area).Edicion Then
            e.Cancel = True
        End If
    End Sub
End Class
