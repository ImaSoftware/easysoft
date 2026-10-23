Imports System.Windows.Forms

Public Class AreaDialog
    Dim id As Integer = 0
    Public ColorFondo As Color
    Public Textura As String
    Public _Name As String
    Public Desc As String
    Public backlay As Integer
    Public W_IMgTam As Integer
    Public H_IMgTam As Integer
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Sub cargarTodo(ByVal argId As Integer)
        'elementosLogicos
        id = argId
        Dim dameda As New Area()
        dameda.cargarSector(argId)
        Me._Name = dameda.Nombre
        cargarText()
        Me.Desc = dameda.Descripcion
        Me.ColorFondo = dameda.PanelArea.BackColor
       
        Me.Textura = dameda.ImgFondo
        Me.backlay = dameda.BackLayout
        W_IMgTam = dameda.sizeFondo.Width
        H_IMgTam = dameda.sizeFondo.Height
        'elementos de Pantalla
        txtName.Text = Me._Name
        txtDSC.Text = Me.Desc
        AbrirDialog.BackColor = Me.ColorFondo
        If Textura = "" Then
            chkNoImagen.Checked = True
        Else
            chkNoImagen.Checked = False
            lblfullname.Text = Application.StartupPath & "\BMPs\Texturas\" & Me.Textura
            OFD.FileName = lblfullname.Text
        End If
        CD.Color = Me.ColorFondo
      
        cmbLayout.SelectedIndex = Me.backlay
        Alto.Value = H_IMgTam
        Ancho.Value = W_IMgTam
    End Sub
    Sub cargarText()
        Me.Text = Me._Name & " ; Id: " & CStr(id)
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        If OFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not System.IO.File.Exists(Application.StartupPath & "\BMPs\Texturas\" & OFD.SafeFileName) Then
                System.IO.File.Copy(OFD.FileName, Application.StartupPath & "\BMPs\Texturas\" & OFD.SafeFileName)
            End If
            Me.Textura = OFD.SafeFileName
            lblfullname.Text = OFD.FileName
        End If
    End Sub

    Private Sub AbrirDialog_Click(sender As Object, e As EventArgs) Handles AbrirDialog.Click
        If CD.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Me.ColorFondo = CD.Color
            AbrirDialog.BackColor = CD.Color
        End If
    End Sub
    Private Sub chkNoImagen_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoImagen.CheckedChanged
        lblfullname.Enabled = Not chkNoImagen.Checked
        Ancho.Enabled = Not chkNoImagen.Checked
        Alto.Enabled = Not chkNoImagen.Checked
        cmbLayout.Enabled = Not chkNoImagen.Checked
        If chkNoImagen.Checked Then
            Me.Textura = ""
        Else
            Me.Textura = OFD.SafeFileName
        End If
    End Sub
    Private Sub chkTrans_CheckedChanged(sender As Object, e As EventArgs) Handles chkTrans.CheckedChanged
        AbrirDialog.Enabled = Not chkTrans.Checked
        If chkTrans.Checked Then
            Me.ColorFondo = Color.Transparent
        Else
            Me.ColorFondo = AbrirDialog.BackColor
        End If
    End Sub

    Private Sub txtDSC_TextChanged(sender As Object, e As EventArgs) Handles txtDSC.TextChanged
        Desc = txtDSC.Text
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        _Name = txtName.Text
        cargarText()
    End Sub




    Private Sub Alto_ValueChanged(sender As Object, e As EventArgs) Handles Alto.ValueChanged
        Me.H_IMgTam = Alto.Value
    End Sub

    Private Sub Ancho_ValueChanged(sender As Object, e As EventArgs) Handles Ancho.ValueChanged
        Me.W_IMgTam = Ancho.Value
    End Sub

    Private Sub cmbLayout_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLayout.SelectedIndexChanged
        Me.backlay = cmbLayout.SelectedIndex
    End Sub
End Class
