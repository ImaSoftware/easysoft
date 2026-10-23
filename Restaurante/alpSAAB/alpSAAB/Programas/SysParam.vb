Public Class SysParam

    Private Sub cmdGrabar_Click(sender As Object, e As EventArgs) Handles cmdGrabar.Click
        'validaciones
        If txtpwd.Text.Length > 0 AndAlso Not System.Text.RegularExpressions.Regex.IsMatch(txtpwd.Text, "^[0-9]{4,32}$") Then
            MsgBox("La nueva clave debe contener entre 4 y 32 dígitos. Deje vacío para conservar la actual.", MsgBoxStyle.Exclamation, "Un momento!!!")
            Exit Sub
        End If
        GrabarParametros()
    End Sub
    Sub GrabarParametros()

        Dim lin As New List(Of Parametro)
        lin.Add(New Parametro("Instancia", 1))
        lin.Add(New Parametro("ClaveAdmin", "0"))
        lin.Add(New Parametro("MeseroDigitos", MeseroDigitos.Value))
        lin.Add(New Parametro("CombinacionColores", SD_SysParam_Temas.SelectedValue))
        lin.Add(New Parametro("TiempoEsperaMaximo", TiempoEsperaMaximo.Value))
        lin.Add(New Parametro("TiempoEsperaAceptable", TiempoEsperaAceptable.Value))
        lin.Add(New Parametro("ParadiseName", ParadiseName.Text))
        lin.Add(New Parametro("VerEsquema", ChkVerEsquema.Checked))
        lin.Add(New Parametro("ResMesero", chkResMesero.Checked))
        lin.Add(New Parametro("OrigenMeseros", SD_OrigenesMeseros.SelectedValue))
        lin.Add(New Parametro("ImagenInicio", lblimg.Text))

        lin.Add(New Parametro("imagenArriba", lblimg2.Text))
        lin.Add(New Parametro("asistenteEspera", asistenteEspera.Value))
        lin.Add(New Parametro("nombreAsistente", txtNombreAsistente.Text))
        lin.Add(New Parametro("recargaSector", recargaSector.Value))

        lin.Add(New Parametro("tpProf", txtProfo.Text))
        lin.Add(New Parametro("bode", txtBode.Text))
        lin.Add(New Parametro("t_codcli", txtTempCli.Text))
        lin.Add(New Parametro("confiCierre", chkCierre.Checked))
        lin.Add(New Parametro("topPedi", NuMtop.Value))
        lin.Add(New Parametro("idMesaLleva", txtMesaLLeva.Text))
        lin.Add(New Parametro("idMesaDomi", txtMesaDomi.Text))

        'Lista 
        Dim newAdminHash As String = Nothing
        Using transaction As New System.Transactions.TransactionScope()
            EjecutarSP("dbo.SDSP_ActualizaParametros", lin)
            If txtpwd.Text.Length > 0 Then
                Dim hash = AdminSecurity.HashPassword(txtpwd.Text)
                If EjecutarConsulta("UPDATE dbo.SD_AdminCredenciales SET PasswordHash = @p0 WHERE Instancia = @p1", , , New Object() {hash, 1}) <> 1 Then Throw New InvalidOperationException("No se pudo actualizar la clave administrativa.")
                newAdminHash = hash
            End If
            transaction.Complete()
        End Using
        If newAdminHash IsNot Nothing Then Parametros.AdminHash = newAdminHash
        If MsgBox("Los parametros han sido actualizados. Es necesario que se reiniciar para que surta efecto. ¿Desea hacerlo ahora?", MsgBoxStyle.YesNo, "Confirmacion") = MsgBoxResult.Yes Then
            Application.Restart()
        Else
            CargarInfo()
        End If


    End Sub

 
    Sub CargarInfo()
        cargarcombos(Me)
        SD_SysParam_Temas.ValueMember = "id"
        SD_SysParam_Temas.DisplayMember = "Nombre"
        txtpwd.UseSystemPasswordChar = True
        txtpwd.Text = ""
        MeseroDigitos.Value = parametros.MeseroDigitos
        SD_SysParam_Temas.SelectedValue = parametros.CombinacionColores
        TiempoEsperaMaximo.Value = parametros.TiempoEsperaMaximo
        TiempoEsperaAceptable.Value = parametros.TiempoEsperaAceptable
        'ItemsMostrar.Value = Numero(DataC(parametros.ItemsMostrar))
        ParadiseName.Text = Parametros.ParadiseName
        NuMtop.Value = Parametros.topPedidos
        ChkVerEsquema.Checked = parametros.VerEsquema
        chkResMesero.Checked = parametros.ResMesero
        SD_OrigenesMeseros.SelectedValue = parametros.origenMeseros
        lblimg.Text = Parametros.imgpublicidad
        txtMesaDomi.Text = Parametros.idMesaDomicilio
        txtMesaLLeva.Text = Parametros.idMesaLLevar
        txtBode.Text = Parametros.Bodega
        txtTempCli.Text = Parametros.cliProfo
        txtProfo.Text = Parametros.tpProfo
        chkCierre.Checked = Parametros.confirmaCierre
        lblimg2.Text = Parametros.imagenArriba
        asistenteEspera.Value = Parametros.esperaAsistente
        txtNombreAsistente.Text = Parametros.nombreAsistente
        recargaSector.Value = Parametros.EsperaSector
        Me.Visible = True
    End Sub

    Private Sub SysParam_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarInfo()
        Panel1.Height = Me.Parent.ClientRectangle.Height
        Panel1.Width = Me.Parent.ClientRectangle.Width

    End Sub
    Overloads Sub loader()
        CargarInfo()
    End Sub

    Private Sub cmdEditar_Click(sender As Object, e As EventArgs) Handles cmdEditar.Click, btnAdd.Click

        Dim frmTema As New TemaDialog
        If sender.name <> btnAdd.Name Then
            frmTema = New TemaDialog(SD_SysParam_Temas.SelectedItem.row)
        End If
        If frmTema.ShowDialog <> DialogResult.Cancel Then
            Dim lo As New List(Of Parametro)
            lo.Add(New Parametro("Nombre", frmTema.nombre))
            lo.Add(New Parametro("DolphinColor1", frmTema.colorPrimario.ToArgb))
            lo.Add(New Parametro("DolphinColor2", frmTema.colorSecundario.ToArgb))
            lo.Add(New Parametro("f_name", frmTema.FontName))
            lo.Add(New Parametro("f_size", frmTema.fontsize))

            If sender.name <> btnAdd.Name Then
                lo.Add(New Parametro("id", frmTema.ID))
            End If
            'lista
            If sender.name = btnAdd.Name Then
                EjecutarSP("dbo.SDSP_creaTema", lo)
            Else
                EjecutarSP("dbo.SDSP_ActualizaTema", lo)
            End If

            cargarcombos(Me)
            SD_SysParam_Temas.SelectedValue = frmTema.ID
        End If
    End Sub

  

    Private Sub txtpwd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpwd.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtpwd_TextChanged(sender As Object, e As EventArgs) Handles txtpwd.TextChanged
        If txtpwd.Text.Length = 0 Then
            ep1.SetError(txtpwd, "El valor no puede ser una cadena en blanco")
            Exit Sub
        End If
        If Not IsNumeric(txtpwd.Text) Then
            ep1.SetError(txtpwd, "Solo valores numericos permitidos")
            Exit Sub
        End If
        ep1.Clear()
    End Sub

   
   


    
    Private Sub Button1_MouseDown(sender As Object, e As MouseEventArgs) Handles Button1.MouseDown
        txtpwd.UseSystemPasswordChar = False
        txtpwd.Refresh()
    End Sub

    Private Sub Button1_MouseUp(sender As Object, e As MouseEventArgs) Handles Button1.MouseUp
        txtpwd.UseSystemPasswordChar = True
        txtpwd.Refresh()
    End Sub

   
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If escoge.ShowDialog <> DialogResult.Cancel Then
            If escoge.FileName <> "" Then
                lblimg.Text = escoge.FileName
            End If

        End If
    End Sub

    Private Sub btnBusqSP1_Click(sender As Object, e As EventArgs) Handles btnBusqSP1.Click
        Dim frmB As BusquedaS = New BusquedaS("xTpProf", "codigo")
        frmB.Text = "Seleccione Documento de Proforma"
        frmB.ShowDialog()
        If frmB.DialogResult = DialogResult.OK Then
            txtProfo.Text = Convert.ToString(frmB.xdev)
        End If
    End Sub

    Private Sub btnBusqSP2_Click(sender As Object, e As EventArgs) Handles btnBusqSP2.Click
        Dim frmB As BusquedaS = New BusquedaS("xBode", "codigo")
        frmB.Text = "Seleccione Bodega"
        frmB.ShowDialog()
        If frmB.DialogResult = DialogResult.OK Then
            txtBode.Text = Convert.ToString(frmB.xdev)
        End If
    End Sub

    Private Sub btnBusqSP3_Click(sender As Object, e As EventArgs) Handles btnBusqSP3.Click
        Dim frmB As BusquedaS = New BusquedaS("xCliMae", "codigo")
        frmB.Text = "Seleccione Cliente Temporal"
        frmB.ShowDialog()
        If frmB.DialogResult = DialogResult.OK Then
            txtTempCli.Text = Convert.ToString(frmB.xdev)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim frmB As BusquedaS = New BusquedaS("xMesas", "ID")
        frmB.Text = "Seleccione Cliente Temporal"
        frmB.ShowDialog()
        If frmB.DialogResult = DialogResult.OK Then
            txtMesaLLeva.Text = Convert.ToString(frmB.xdev)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim frmB As BusquedaS = New BusquedaS("xMesas", "ID")
        frmB.Text = "Seleccione Cliente Temporal"
        frmB.ShowDialog()
        If frmB.DialogResult = DialogResult.OK Then
            txtMesaDomi.Text = Convert.ToString(frmB.xdev)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If escoge.ShowDialog <> DialogResult.Cancel Then
            If escoge.FileName <> "" Then
                lblimg2.Text = escoge.FileName
            End If

        End If
    End Sub
End Class


