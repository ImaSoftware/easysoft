Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Public Class MesaDialog
    Public _AliasMesa As String
    Public Capacidad As Integer
    Public circular As String
    Public textura As String
    Public posicion As Point
    Public tamanio As Size
    Public ColorFondo As Color
  
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        _AliasMesa = txtAlias.Text
        Capacidad = ControlCapacidad.Value
        circular = chkescirc.Checked
        textura = ElementoMesa.Textura
        posicion = New Point(posx.Value, posy.Value)
        tamanio = New Size(tam_width.Value, tam_height.Value)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Sub cargarInfoMesa(Optional argid As Integer = -1)
        'carga de elementoMesa
        ElementoMesa.IdMesa = argid
        ElementoMesa.cargarMesa()
        Dim esImagen As Boolean = IIf(ElementoMesa._Alias = "", True, False)
        lblfullname.Text = Application.StartupPath & "\BMPs\Texturas\" & ElementoMesa.Textura
        posx.Value = ElementoMesa.Location.X
        posy.Value = ElementoMesa.Location.Y
        tam_width.Value = ElementoMesa.Width
        tam_height.Value = ElementoMesa.Height
        txtAlias.Text = ElementoMesa._Alias
        chkescirc.Checked = ElementoMesa.Circular
        ElementoMesa.Location = New Point(0, 0)
        ElementoMesa.Visible = True
        If Not esImagen Then
            ControlCapacidad.Value = ElementoMesa.Capacidad
        End If
        ControlCapacidad.Enabled = Not esImagen
        txtAlias.Enabled = Not esImagen

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        If textDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not System.IO.File.Exists(Application.StartupPath & "\BMPs\Texturas\" & textDialog.SafeFileName) Then
                System.IO.File.Copy(textDialog.FileName, Application.StartupPath & "\BMPs\Texturas\" & textDialog.SafeFileName)
            End If
            ElementoMesa.Textura = textDialog.SafeFileName
            ElementoMesa.BackgroundImage = Image.FromFile(Application.StartupPath & "\BMPs\Texturas\" & textDialog.SafeFileName)
            lblfullname.Text = textDialog.FileName
        End If
    End Sub
    Private Sub chkescirc_CheckedChanged(sender As Object, e As EventArgs) Handles chkescirc.CheckedChanged
        Dim myGraphicsPath = New GraphicsPath(FillMode.Alternate)
        If chkescirc.Checked Then
            myGraphicsPath.AddEllipse(New Rectangle(2, 2, ElementoMesa.Width - 5, ElementoMesa.Height - 5))
        Else
            myGraphicsPath.AddRectangle(New Rectangle(0, 0, ElementoMesa.Width, ElementoMesa.Height))
        End If
        ElementoMesa.Region = New Region(myGraphicsPath)
    End Sub

    Private Sub chkTrans_CheckedChanged(sender As Object, e As EventArgs) Handles chkTrans.CheckedChanged
        AbrirDialog.Enabled = Not chkTrans.Checked
        If chkTrans.Checked Then
            Me.ColorFondo = Color.Transparent
            Me.ElementoMesa.BackColor = Me.ColorFondo
        Else
            Me.ColorFondo = AbrirDialog.BackColor
            Me.ElementoMesa.BackColor = Me.ColorFondo
        End If
    End Sub

    Private Sub AbrirDialog_Click(sender As Object, e As EventArgs) Handles AbrirDialog.Click
        If ColorPick.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Me.ColorFondo = ColorPick.Color
            Me.ElementoMesa.BackColor = Me.ColorFondo
            AbrirDialog.BackColor = ColorPick.Color
        End If
    End Sub

    Private Sub MesaDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim a As Boolean = True
    End Sub
End Class
