Public Class Restaurante
    Friend WithEvents Label8 As Label
    Private MesaSelect As New Mesa
    Private loading As Boolean = False
    Private cambtam As Boolean = False
    Private InfoCargada As Boolean
    Dim capacidadtotal As Integer = 0
    Overloads Sub loader()
        loading = True
        cargarcombos(Me)
        loading = False
        Actualizar()
        TimerClock.Interval = Globales.Parametros.EsperaSector
        TimerClock.Start()
        PanelInfo.Width = TabControl1.Width
    End Sub
    
    Sub pegarLabelNada()
        For Each ctl In PanelInfo.Controls
            ctl.visible = False
        Next
        Me.Label8 = New Label
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(693, 150)
        Me.Label8.TabIndex = 1
        Label8.BringToFront()
        Me.Label8.Text = "Haga click en una mesa para visualizar su estado"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Label8.Visible = True
        PanelInfo.Controls.Add(Label8)
        InfoCargada = False
    End Sub
    Sub ocultades()
        Me.PanelInfo.Controls.Remove(Me.design)
    End Sub
    Private Sub Sector_ClicMesaEsquema(argMesa As Mesa) Handles Sector.ClicMesaEsquema
        If IsNothing(argMesa) Then Exit Sub
        If argMesa.SoyImagen Then Exit Sub
        MesaSelect = argMesa
        cargarEstadisticas()
        Me.Refresh()
        InfoCargada = True
        For Each ctl In PanelInfo.Controls
            ctl.visible = True
        Next
        panelestAct.Controls.Clear()
        Label8.Visible = False
        Dim lin As New List(Of Parametro) : Dim lout As New List(Of Parametro)
        lin.Add(New Parametro("NoMesa", argMesa.IdMesa))
        lout.Add(New Parametro("CuentaActiva", 0))
        lout.Add(New Parametro("Mesas", "", 300))
        lout.Add(New Parametro("tiempoInicio", Now(), 8))
        lout.Add(New Parametro("mesero", "", 40))
        Dim res As DataRow = EjecutarSP("SDSP_CuentaActiva", lin, lout)
        If DataC(res("CuentaActiva")) = "" Then
            lblCuenta.Text = "MESA " & MesaSelect.AliasNum & " LIBRE"
        Else
            lblCuenta.Text = DataC(res("CuentaActiva"))
        End If
        lblMesasIncl.Text = DataC(res("Mesas"))
        lblmesero.Text = DataC(res("mesero"))
        For Each est As EstadoCuenta In argMesa.estadosActivos
            Dim itm As New ItemLeyenda(est.Descripcion, est.R_Color)
            itm.Dock = DockStyle.Left
            panelestAct.Controls.Add(itm)
        Next
        'calcular tiempo
        If DataC(res("tiempoInicio")) <> "" Then
            calcularTiempoenMesa(DataC(res("tiempoInicio")))
        Else
            lblTiempo.Visible = False
        End If
        txtNoMesa.Text = MesaSelect.AliasNum
        PanelInfo.Visible = True
    End Sub
    Sub calcularTiempoenMesa(Optional ByVal tiempoCreacion As DateTime = Nothing)
        Dim minutos As Integer = 0
        If Not IsNothing(tiempoCreacion) Then
            minutos = DateDiff(DateInterval.Minute, tiempoCreacion, Now())
        End If
        lblTiempo.Tag = tiempoCreacion
        lblTiempo.Text = componerTiempo(minutos)
    End Sub
    Sub Actualizar()
        Me.Visible = False
        Me.Dock = DockStyle.Fill
        Me.Width = Parent.Width
        Me.Height = Parent.Height
        Me.Cursor = Cursors.WaitCursor

        Me.SuspendLayout()
        If loading Then Exit Sub
        Sector.PanelArea.Controls.Clear()
        Sector.EsEsquema = Globales.Parametros.VerEsquema
        capacidadtotal = Sector.cargarTodo(cmbSectores.SelectedValue)
        Me.ResumeLayout(False)
        cargarEstadisticas()
        cargarLeyenda()
        pegarLabelNada()
        Me.Sector.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()
        numpad.CuadroTexto(txtNoMesa, 3)
        Me.Cursor = Cursors.Default
        Me.Visible = True
    End Sub
    Sub cargarLeyenda()
        PanLeyenda.Controls.Clear()
        Dim dtt As DataTable = cargarConsulta("Select * from SD_Cuentas_Estados where Activo = 1")
        If Not IsNothing(dtt) Then
            If dtt.Rows.Count > 0 Then
                For Each estado As DataRow In dtt.Rows
                    Dim itml As New ItemLeyenda(DataC(estado("Dsc")), Color.FromArgb(DataC(estado("Color"))))
                    itml.Dock = DockStyle.Left
                    PanLeyenda.Controls.Add(itml)
                Next
            End If
        End If
    End Sub
    Sub cargarEstadisticas()
        'de aqui obtengo Personas en Sector y cuentas activas
        Dim sqlEstadisticas As String = String.Format("SELECT   SUM(SD_CuentasCabecera.NoPersonas) AS Personas, COUNT(SD_CuentasCabecera.id) AS Cuenta  " _
                                                      & " FROM            SD_CuentasCabecera INNER JOIN " _
                                                      & " (SELECT DISTINCT SD_Mesas.IdSector, SD_Cuentas_Mesas.IdCuenta " _
                                                      & " FROM            SD_Mesas INNER JOIN " _
                                                      & " SD_Cuentas_Mesas ON SD_Mesas.Id = SD_Cuentas_Mesas.IdMesa CROSS JOIN " _
                                                      & " SD_CuentasCabecera " _
                                                      & " where IdSector= {0} )as A ON SD_CuentasCabecera.id = A.IdCuenta " _
                                                      & " where SD_CuentasCabecera.estado= 'A' ", Sector.Id)
        Dim dttest As DataTable = cargarConsulta(sqlEstadisticas)
        Dim sqlMesasActivas As String = String.Format(" SELECT        COUNT(SD_Cuentas_Mesas.IdMesa) AS MesasActivas " _
            & " FROM            SD_CuentasCabecera INNER JOIN " _
            & " SD_Cuentas_Mesas ON SD_CuentasCabecera.id = SD_Cuentas_Mesas.IdCuenta INNER JOIN " _
            & " SD_Mesas ON SD_Cuentas_Mesas.IdMesa = SD_Mesas.Id " _
            & " WHERE        (SD_CuentasCabecera.estado = 'A') AND (SD_Mesas.IdSector = {0})", Sector.Id)
        Dim dttMA As DataTable = cargarConsulta(sqlMesasActivas)

        Dim sqlmeserosxsec = String.Format("SELECT DISTINCT SD_CuentasCabecera.Idmesero, COUNT(SD_CuentasCabecera.id) AS totCta " _
                                           & " FROM       SD_CuentasCabecera INNER JOIN " _
                                           & " SD_Cuentas_Mesas ON SD_CuentasCabecera.id = SD_Cuentas_Mesas.IdCuenta INNER JOIN " _
                                           & " SD_Mesas ON SD_Cuentas_Mesas.IdMesa = SD_Mesas.Id " _
                                           & " WHERE    (SD_CuentasCabecera.estado = 'A') AND (SD_Mesas.IdSector = {0}) " _
                                           & " GROUP BY SD_CuentasCabecera.Idmesero", Sector.Id)
        Dim dttmeseros As DataTable = cargarConsulta(sqlmeserosxsec)
        If Not IsNothing(dttest) And Not IsNothing(dttMA) Then
            If dttest.Rows.Count = 1 And dttMA.Rows.Count = 1 Then
                lblCuentas.Text = Numero(dttest(0)("Cuenta"))
                If Not IsNothing(dttmeseros) Then
                    lblMeserosxSec.Text = dttmeseros.Rows.Count
                End If
                lblPersonasSector.Text = Numero(dttest(0)("Personas")) & "/" & CStr(capacidadtotal)
                Dim totmesas As String = cargarConsulta(String.Format("select count(id) as Total from SD_Mesas where IdSector = {0} and EsMesa = 'True'", Sector.Id))(0)("Total")
                lblMesas.Text = Numero(DataC(dttMA(0)("MesasActivas"))) & "/" & CStr(totmesas)
            Else
                MsgBox("Caso no contemplado. Cargar estadisticas")
            End If
        Else
            MsgBox("Error al cargar las estadisticas", MsgBoxStyle.Information, "Opss!!")
            Exit Sub
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Sector.GuardarArea()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Actualizar()
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Sector.zoom(-0.05)
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Sector.zoom(+0.05)
    End Sub
    Private Sub cmbSectores_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSectores.SelectedIndexChanged
        Actualizar()
    End Sub

    Private Sub Sector_DobleClickMesa(argMesa As Mesa) Handles Sector.DoubleClicMesa
        If argMesa._Alias = "" Then Exit Sub
        AbirLaMesa(argMesa.IdMesa, argMesa._Alias)
    End Sub
    Sub AbirLaMesa(ByVal argid As Integer, ByVal nomMesa As String)
        Dim frmAbrirMesa As New AbrirMesa(argid, nomMesa)
        frmAbrirMesa.Tag = "ABRELA"
        AddHandler frmAbrirMesa.DelfinCerrado, AddressOf VentanaHijaCerrada
        'Dim noCuenta As Integer = frmAbrirMesa.ShowDialog()
        frmAbrirMesa.Show()

        'If frmAbrirMesa.focusHijo Then
        '    frmAbrirMesa..Show()
        'End If
    End Sub
    Sub VentanaHijaCerrada(ByVal sender As DolphinForm)
        If sender.Tag = "ABRELA" Then
            Dim ventana As AbrirMesa = DirectCast(sender, AbrirMesa)
            If sender.DialogResult = DialogResult.Yes Then
                Dim a As Pedido = New Pedido(ventana.IdCuenta, ventana.IdMesero)
                'Abrir cuenta de Id seleccionado
                'Nueva cuenta para las mesas en la lista
                AddHandler a.DelfinCerrado, AddressOf VentanaHijaCerrada
                a.cargarCuenta()
                a.WindowState = FormWindowState.Maximized
                'focusHijo = True
                'forma = a
                a.Show()
                a.Focus()
            ElseIf sender.DialogResult = DialogResult.No Then
                Dim a As Pedido
                'Nueva cuenta para las mesas en la lista
                a = New Pedido(ventana.ListaMesas, ventana.IdMesero)
                AddHandler a.DelfinCerrado, AddressOf VentanaHijaCerrada
                a.cargarCuenta()
                a.WindowState = FormWindowState.Maximized
                'focusHijo = True
                'forma = a
                a.Show()
                a.Focus()
            End If
        End If
        Me.Refresh()
    End Sub
    Private Sub Sector_Load(sender As Object, e As EventArgs) Handles Sector.Load
        Sector.verificarEstados()
        Sector.Refresh()
    End Sub


    Private Sub cmdAbrir_Click(sender As Object, e As EventArgs) Handles cmdAbrir.Click
        If txtNoMesa.Text.Length = 0 Then Exit Sub
        'buscar si existe el alias y traer el id
        Dim sql As String = String.Format("Select Id,Alias from SD_Mesas where NumAlias = {0} and IdSector = {1}",
                                          txtNoMesa.Text, Sector.Id)
        Dim dtt As DataTable = cargarConsulta(sql)
        If Not IsNothing(dtt) Then
            If dtt.Rows.Count = 1 Then
                AbirLaMesa(Numero(DataC(dtt(0)("Id"))), DataC(dtt(0)("Alias")))
            End If
        End If
        txtNoMesa.Text = ""
    End Sub

    Private Sub Restaurante_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Me.Sector.PanelArea.Refresh()
    End Sub

    Private Sub numericaMesa_Entrar() Handles numpad.Entrar
        Actualizar()
    End Sub
    Private Sub Restaurante_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        MsgBox("Espacio Vacio")
    End Sub

    Private Sub TimerClock_Tick(sender As Object, e As EventArgs) Handles TimerClock.Tick
        'If Not InfoCargada Then Exit Sub
        calcularTiempoenMesa(lblTiempo.Tag)
        cargarEstadisticas()
        Sector.verificarEstados()
        Sector.Refresh()
    End Sub
    Function componerTiempo(ByVal argminutos As Integer) As String
        Dim minutos = argminutos
        Dim horas = Math.Truncate(minutos / 60)
        Dim minutosr = minutos Mod 60
        componerTiempo = String.Format("{0} horas, {1} minutos", horas, minutosr)
        If minutos > parametros.TiempoEsperaMaximo Then
            lblTiempo.ForeColor = Color.Red
        Else
            lblTiempo.ForeColor = Color.Black
        End If
    End Function


    Private Sub lblMeserosxSec_Click(sender As Object, e As EventArgs) Handles lblMeserosxSec.Click
        Dim sqlmeserosxsec = String.Format("SELECT DISTINCT (SELECT    TOP (1) splitdata " _
                                           & " FROM       dbo.fnSplitString(LTRIM(RTRIM(rola110.nombre)), '')) + ' ' + SUBSTRING(RTRIM(LTRIM(rola110.apellido)), 1, 1) + '.' AS Mesero, A.Cuentas from rola110 inner join  " _
                                           & " (SELECT   SD_CuentasCabecera.Idmesero, count(SD_CuentasCabecera.Idmesero) as Cuentas " _
                                           & " FROM       SD_CuentasCabecera INNER JOIN " _
                                           & " rola110 ON SD_CuentasCabecera.Idmesero = rola110.codemp " _
                                           & " where SD_CuentasCabecera.estado = 'A' " _
                                           & " group by SD_CuentasCabecera.Idmesero ) A on rola110.codemp = idmesero ", Sector.Id)
        Dim dttmeseros As DataTable = cargarConsulta(sqlmeserosxsec)
        Dim gr As New Grafico(tipoGrafico.Meseros_Cuentas, dttmeseros)
        AddHandler gr.DelfinCerrado, AddressOf VentanaHijaCerrada
        gr.ShowDialog()

    End Sub

    Private Sub lblPersonasSector_Click(sender As Label, e As EventArgs) Handles lblPersonasSector.Click, lblMesas.Click
        Dim tablaO As New DataTable : tablaO.Columns.Add("Estado") : tablaO.Columns.Add("Valor")
        Dim x() As String = sender.Text.Split("/")
        tablaO.Rows.Add("Ocupado", x(0)) : tablaO.Rows.Add("Libre", x(1) - x(0))
        Dim gr As New Grafico(tipoGrafico.Ocupacion, tablaO)
        AddHandler gr.DelfinCerrado, AddressOf VentanaHijaCerrada
        gr.ShowDialog()
    End Sub

   
    Private Sub lblCuentas_Click(sender As Object, e As EventArgs) Handles lblCuentas.Click
        Dim dtt As DataTable = cargarConsulta("select 'Cta. ' + cast(alias as varchar) as Cuenta, totalCuenta from SD_CuentasCabecera where estado = 'A'")
        Dim gr As New Grafico(tipoGrafico.Cuentas, dtt)
        AddHandler gr.DelfinCerrado, AddressOf VentanaHijaCerrada
        gr.ShowDialog()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles design.Click
        Dim frmDiseño As New Esquematizador
        frmDiseño.cargarTodo(Sector.Id)
        AddHandler frmDiseño.DelfinCerrado, AddressOf VentanaHijaCerrada
        frmDiseño.Show()
        frmDiseño.Focus()
    End Sub

    Private Sub PanelInfo_DoubleClick(sender As Object, e As EventArgs) Handles PanelInfo.DoubleClick, Label8.DoubleClick
        PanelInfo.Visible = False
    End Sub


    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        PanelInfo.Visible = False
    End Sub

    Private Sub Sector_Click(sender As Object, e As EventArgs) Handles Sector.Click

        Sector.Refresh()
    End Sub
End Class
