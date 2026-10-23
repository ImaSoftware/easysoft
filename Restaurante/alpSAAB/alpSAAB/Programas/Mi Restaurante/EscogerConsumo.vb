Public Class EscogerConsumo

    Public salta As Boolean = False
    Dim maximoItems As Integer = -1
    Public Class Consumo

        Property itemInv As ItemInventario
        Property cantidad As Integer
        Property comentario As String
        Sub New(ByVal argItmInv As ItemInventario, ByVal argcant As Integer, argcom As String)
            itemInv = argItmInv
            cantidad = argcant
            comentario = argcom
        End Sub
    End Class
    WithEvents barNavega As New BarraNavegacionProducto
    Dim TecladoP As Boolean = False
    Dim tecladoPantallaProc As Process
    Dim Niveles As DataTable
    Const margen As Integer = 10
    Property Resultados As New List(Of Consumo)
    Dim TablaItems As DataTable
    Public PanelesNivel As New List(Of Panel)
    Dim BotonesNivelOpt As New List(Of Button)
    Public panelItems As New Panel
    Dim TablaNiveles As DataTable
    Dim ItemEscogido As ItemInventario
    Dim Filtro As String = ""
    Private filtroValores As New List(Of Object)()
    'seleccion a nivel de item
    Dim Pagina As Integer = 0 'para paginacion
    Dim nivelActual As Integer = 0
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        loader()
        Me.lblTotal.BackColor = Me.ColorPrimario
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub clickLabel(ByVal sender As Label, e As EventArgs)
        ' MueveFiltro(sender.Tag)
        ProcesarNivel(sender.Tag)
    End Sub
    Overloads Sub loader()
        NumericaPad1.CuadroTexto(txtCant, 3)
        ProcesarNivel(0, True)
    End Sub


    Public Sub CargarNiveles()
        'Instancia = 1
        'dejo aqui el indicio de que se puedan usar varias 'Instancias del programa sobre la misma
        'base. Podria representar a varios restaurantes o talvez otra cosa (Multiempresa???)
        'Desarrollar mas la idea de darse
        'Principalmente añadire este campo de Instancia para aquellas configuraciones que 
        'sean parametros generales
        Dim sqlNiveles As String = String.Format("SELECT  Campo, Tipo, Orden, Alias FROM SD_SysParam_Niveles where Instancia = {0} ORDER BY Orden ", 1)
        TablaNiveles = cargarConsulta(sqlNiveles)
        nivelActual = 0
    End Sub
#Region "Items"
    Sub Items(Optional ByVal Top As Integer = 0)
        reiniciar(TablaNiveles.Rows.Count)
        panelItems = New Panel
        panelItems.BorderStyle = BorderStyle.FixedSingle
        'calculo de la posicion del panel de items
        Dim mayorBottom As Integer = 0
        For Each panelNivel In PanelesNivel
            If panelNivel.Location.Y + panelNivel.Height < mayorBottom Then
                mayorBottom = panelNivel.Location.Y + panelNivel.Height
            End If
        Next
        panelItems.Location = New Point(0, mayorBottom)
        panelItems.Width = Ventana.Width
        panelItems.Height = Ventana.Height - (mayorBottom + PanelBotones.Height)
        panelItems.AutoSize = True
        panelItems.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowOnly
        panelItems.AutoScroll = True
        Ventana.Controls.Add(panelItems)
        panelItems.BringToFront()

        Dim sql As String = ""
        If Top = -1 Then
            sql = String.Format("  Select DISTINCT  no_parte As Codigo, tipo, nombre, imagen, pvpu1 " &
            " From dbo.dp03a110	Where no_parte In ( " &
            " Select  Top {0} A.idProducto from (      " &
            " Select  count(idProducto) Cuenta , idProducto from SD_Comandas_Detalle " &
            " group by idProducto ) A order by A.Cuenta desc )", Globales.Parametros.topPedidos.ToString.Trim())
        Else
            sql = String.Format(" Select DISTINCT  no_parte As Codigo, tipo, nombre, imagen, pvpu1 " _
                            & " FROM dbo.dp03a110 {0} ", Filtro)
        End If

        TablaItems = cargarConsulta(sql, , filtroValores.ToArray())
        '**********************************************************
        '               carga de la barra de navegacion 
        '**********************************************************

        'Calcular el numero máximo de items 
        Dim tamV As Size = panelItems.Size
        Dim aItm As New ItemInventario
        Dim tamItm As Size = aItm.Size
        maximoItems = Math.Truncate(tamV.Width / (tamItm.Width + margen)) * Math.Truncate(tamV.Height / (tamItm.Height + margen))
        barNavega = New BarraNavegacionProducto
        panelItems.Controls.Add(barNavega)
        barNavega.Dock = DockStyle.Bottom
        Dim n As Integer = TablaItems.Rows.Count 'Items
        Dim p As Integer = Math.Truncate(n / maximoItems)

        If (n Mod maximoItems) > 0 Then
            p = p + 1
        End If
        barNavega = New BarraNavegacionProducto(p)
        barNavega.pagina = 1
        barNavega.lblPagina.Text = String.Format("Pagina {0} de {1}",
                                                 barNavega.pagina, barNavega.total)
        '**************************************************************

        'Mostrar barra de paginacion
        cargarPaginaItems()
    End Sub
    Sub cargarPaginaItems()
        If (Me.maximoItems = -1) Then Exit Sub
        panelItems.Controls.Clear()
        panelItems.Controls.Add(barNavega)
        barNavega.Dock = DockStyle.Bottom
        Dim lblNombre As New Label : lblNombre.Font = New Font("Harrington", 16)
        lblNombre.Text = "Consumos" : lblNombre.AutoSize = True
        lblNombre.Location = New Point(margen, margen)
        AddHandler lblNombre.Click, AddressOf clickLabel
        panelItems.Controls.Add(lblNombre) 'Titulo del panel de botones
        If Not IsNothing(TablaItems) Then
            Dim xant As ItemInventario = Nothing
            Dim i As Integer = 0
            Dim puntoI As New Point(lblNombre.Left + margen, lblNombre.Bottom + margen)
            For j = 0 To maximoItems - 1
                Dim iterador As Integer = j + (maximoItems * (barNavega.pagina - 1))
                If iterador < 0 Or iterador >= TablaItems.Rows.Count Then Exit For
                Dim itm As DataRow = TablaItems(iterador)
                Dim X As New ItemInventario
                X.cargaritem(DataC(itm("Codigo")), DataC(itm("Tipo")), DataC(itm("nombre")), DataC(itm("imagen")), Numero(DataC(itm("pvpu1"))))
                AddHandler X.CLickItemInv, AddressOf ClickEnItem
                If i = 0 Then
                    xant = X
                Else
                    If (xant.Right + margen + X.Width) > panelItems.Width Then
                        puntoI = New Point((2 * margen), xant.Bottom + margen) 'Salto de linea
                        xant = X
                    Else
                        puntoI = New Point((xant.Right + margen), xant.Top)
                        xant = X
                    End If
                End If
                X.Location = puntoI
                panelItems.Controls.Add(X)
                i += 1
            Next
        End If
        btnAceptar.Enabled = True
        btnAceptar2.Enabled = True
    End Sub
    Sub ClickEnItem(ByVal sender As ItemInventario)
        ItemEscogido = sender
        reiniciar(TablaNiveles.Rows.Count)
        lblNombreProd.Text = ItemEscogido.nombre
        ImgItmEscogido.Image = ItemEscogido.Imagenproducto
        txtCant.Text = 1
        txtComent.Text = ""
        txtCant.Select()
        recalcularPrecio()
        PanelSelProd.Visible = True
    End Sub
#End Region
#Region "Niveles"
    Sub ProcesarNivel(ByVal Nivel As String, Optional ByVal primera As Boolean = False)
        If Globales.Parametros.Depura = True Then
            Me.Hide()
        End If
        If primera And Globales.Parametros.topPedidos > 0 Then
            CargarNiveles()
            Items(-1)
            Exit Sub
        End If
        If Nivel = 0 Then
            CargarNiveles()
        End If
        If Nivel = TablaNiveles.Rows.Count Then
            Items()
            Exit Sub
        End If
        Dim NumeroCampo As Integer = TablaNiveles(Nivel)("Campo")
        Dim _Alias As String = DataC(TablaNiveles(Nivel)("Alias"))
        Dim PanelNivelAnterior As New Panel
        Dim PanelNivelAgregar As New Panel : PanelNivelAgregar.Name = "Panel" & NumeroCampo
        reiniciar(Nivel)
        If Nivel = 0 Then
            PanelNivelAnterior = Nothing
        ElseIf Nivel > 1 Then
            PanelNivelAnterior = Me.Controls.Find("Panel" & TablaNiveles(Nivel - 1)("Campo"), True)(0)
        End If
        If IsNothing(PanelNivelAnterior) Then
            PanelNivelAgregar.Location = New Point(0, 0)
            PanelNivelAgregar.Location = New Point(0, 0)
            PanelNivelAgregar.Dock = DockStyle.Top
        Else
            PanelNivelAgregar.Location = New Point(PanelNivelAnterior.Right, 0)
            PanelNivelAgregar.Width = Ventana.Width - PanelNivelAnterior.Right
        End If
        PanelNivelAgregar.AutoSize = True
        PanelNivelAgregar.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowOnly
        PanelNivelAgregar.BorderStyle = BorderStyle.FixedSingle
        panelNiveles.Controls.Add(PanelNivelAgregar)
        nivelActual = Nivel
        PanelesNivel.Add(PanelNivelAgregar)
        'Extraccion del nombre del campo
        Dim NombreCampo As String
        NombreCampo = cargarConsulta("Select TOP 1 *  from dp03a110").Columns(NumeroCampo).ColumnName

        'Creacion del la etiqueta del nombre
        Dim lblNombre As New Label : lblNombre.Font = New Font("Harrington", 16)
        lblNombre.Text = _Alias : lblNombre.AutoSize = True
        lblNombre.Location = New Point(margen, margen)
        lblNombre.Tag = nivelActual
        AddHandler lblNombre.Click, AddressOf clickLabel
        PanelNivelAgregar.Controls.Add(lblNombre) 'Titulo del panel Nivel
        Dim sql As String = String.Format("Select DISTINCT ltrim(rtrim(dbo.ALPTABLA.nombre)) nombre, dbo.ALPTABLA.codigo" _
                            & " FROM dbo.dp03a110 INNER JOIN " _
                            & " dbo.ALPTABLA On dbo.dp03a110.{0} = dbo.ALPTABLA.codigo " _
                            & "{1} order by dbo.ALPTABLA.codigo ", Database.Identifier(NombreCampo), Filtro)
        Dim TablaOPT As DataTable = cargarConsulta(sql, , filtroValores.ToArray())
        If Not IsNothing(TablaOPT) Then
            Dim xant As Button = Nothing
            Dim i As Integer = 0
            Dim puntoI As New Point(lblNombre.Left + margen, lblNombre.Bottom + margen)
            For Each Opt As DataRow In TablaOPT.Rows
                Dim X As New Button : X.FlatStyle = FlatStyle.Flat
                PanelNivelAgregar.Controls.Add(X)
                X.Name = Opt("codigo") & "_" & Opt("nombre")
                X.Text = Opt("nombre")
                X.AutoSize = True : X.Refresh()
                AddHandler X.Click, AddressOf clickOptNivel
                AddHandler X.DoubleClick, AddressOf DClickOptNivel
                'determinacion de la posicion del boton
                If i = 0 Then
                    xant = X
                Else
                    If (xant.Location.X + xant.Width + margen + X.Width) > PanelNivelAgregar.Width Then
                        puntoI = New Point((2 * margen), xant.Bottom + margen) 'Salto de linea
                        xant = X
                    Else
                        puntoI = New Point((xant.Location.X + xant.Width + margen), xant.Location.Y)
                        xant = X
                    End If
                End If
                X.Location = puntoI
                X.Tag = {Nivel, Opt("codigo")}

                'If Nivel = 0 Then
                '    Dim Xa As New Button : Xa.FlatStyle = FlatStyle.Flat
                '    Xa.Name = "TOP"
                '    X.Text = "MAS VENDIDOS"
                '    X.AutoSize = True : X.Refresh()
                '    AddHandler X.Click, AddressOf clickOptNivel
                '    puntoI = New Point((xant.Right + margen), xant.Top)
                '    X.Location = puntoI
                '    xant = Xa
                'End If

                i += 1
            Next
            Me.Refresh()
        End If
    End Sub
    Sub DClickOptNivel(ByVal sender As Button, e As EventArgs)
        Items()
        Exit Sub
    End Sub
    Sub clickOptNivel(ByVal sender As Button, e As EventArgs)
        Dim ListaElimina As New List(Of Button)
        For Each boton As Control In PanelesNivel(sender.Tag(0)).Controls
            If boton.GetType.Name = "Button" Then
                If Not DirectCast(boton, Button).Equals(sender) Then
                    ListaElimina.Add(boton)
                End If
            End If
        Next
        For Each elemento In ListaElimina
            PanelesNivel(sender.Tag(0)).Controls.Remove(elemento)
        Next
        'recomponer el panel ahora con solo un boton
        sender.Location = New Point((5 * margen), (5 * margen))
        BotonesNivelOpt.Add(sender)
        PanelesNivel(sender.Tag(0)).Dock = DockStyle.None

        PanelesNivel(sender.Tag(0)).Refresh()
        PanelesNivel(sender.Tag(0)).PerformLayout()
        Me.PerformLayout()
        For i = sender.Tag(0) + 1 To PanelesNivel.Count - 1
            PanelesNivel(i).Visible = False
        Next
        If nivelActual <> 0 And nivelActual <> PanelesNivel.Count - 1 Then
            Dim pf As New Point : pf.X = PanelesNivel(sender.Tag(0) - 1).Width + margen
            pf.Y = PanelesNivel(sender.Tag(0) - 1).Top
            PanelesNivel(sender.Tag(0)).Location = pf
            Me.Refresh()
        End If
        'recomponer el filtro afectando solo al nivel del boton que afecta
        Dim NumeroCampo As Integer = TablaNiveles(sender.Tag(0))("Campo")
        Dim NombreCampo As String = cargarConsulta("Select TOP 1 *  from dp03a110").Columns(NumeroCampo).ColumnName
        Dim fltroVar As String = Filtro.Replace("And", "%")
        Dim x() As String
        If fltroVar <> "" Then
            x = fltroVar.Substring(7).Split("%")
        Else
            x = fltroVar.Split("%")
        End If
        Filtro = ""
        For i = 0 To nivelActual
            If i = 0 Then
                Filtro = " Where "
            End If
            If i = nivelActual Then
                While filtroValores.Count <= nivelActual
                    filtroValores.Add(Nothing)
                End While
                If TablaNiveles(nivelActual)("Tipo").ToString.ToUpperInvariant() = "STRING" Then
                    filtroValores(nivelActual) = CStr(sender.Tag(1)).Trim()
                Else
                    filtroValores(nivelActual) = Decimal.Parse(CStr(sender.Tag(1)).Trim(), Globalization.CultureInfo.InvariantCulture)
                End If
                Filtro &= " (dbo.dp03a110." & Database.Identifier(NombreCampo) & " = @p" & nivelActual & ") "
                Exit For
            Else
                Filtro = Filtro & x(i) & " AND "
            End If
        Next
        ProcesarNivel(nivelActual + 1)
    End Sub
#End Region

#Region "Eventos"
    Private Sub NumericaPad1_Load(sender As Object, e As EventArgs) Handles NumericaPad1.Load
        NumericaPad1.ocultaEnter()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub EscogerConsumo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(Me.Owner) Then Me.Owner.Show()
    End Sub
  
    Private Sub txtCant_TextChanged(sender As Object, e As EventArgs) Handles txtCant.TextChanged

        txtCant.Text = CStr(Math.Round(Numero(txtCant.Text), 2))
        recalcularPrecio()


    End Sub
    Private Sub cmdReiniciar_Click(sender As Object, e As EventArgs) Handles cmdReiniciar.Click
        If Directo Then
            Directo = False
            btnAceptar.Visible = True
            layoutBotones.SetColumnSpan(btnAceptar2, 1)
        End If
        ProcesarNivel(0)
        panelNiveles.Visible = True
        panelItems.Visible = True
    End Sub
#End Region
#Region "Metodos"
    Sub recalcularPrecio()
        If Not IsNothing(ItemEscogido) Then
            Dim Precio As Double = ItemEscogido.Precio
            lblTotal.Text = FormatCurrency((Numero(txtCant.Text) * Precio), 2)
            If Numero(txtCant.Text) > 0 Then
                btnAceptar.Enabled = True
                btnAceptar2.Enabled = True
            Else
                btnAceptar2.Enabled = True
                btnAceptar.Enabled = False
            End If
        End If

    End Sub
    Sub reiniciar(ByVal argpaso As Integer)
        For i = PanelesNivel.Count - 1 To argpaso Step -1
            Ventana.Controls.Remove(PanelesNivel(i))
            If Not IsNothing(PanelesNivel(i)) Then destruir(PanelesNivel(i))
            PanelesNivel.RemoveAt(i)
        Next
        If argpaso <= TablaNiveles.Rows.Count Then
            Ventana.Controls.Remove(panelItems)
            If Not IsNothing(panelItems) Then destruir(panelItems)
            If Not IsNothing(ImgItmEscogido.Image) Then ImgItmEscogido.Image.Dispose()
            txtCant.Text = 0
            PanelSelProd.Visible = False
            btnAceptar.Enabled = True
            btnAceptar2.Enabled = False
        End If
        MueveFiltro(argpaso)
    End Sub
    Sub MueveFiltro(ByVal argnivel As Integer)
        Dim FiltroVar As String = Filtro.Replace("AND", "%")
        Dim x() As String
        If Filtro <> "" Then
            x = FiltroVar.Substring(7).Split("%")
        Else
            x = FiltroVar.Split("%")
        End If
        Filtro = ""
        If FiltroVar <> "" Then
            For i = 0 To argnivel - 1
                If i = 0 Then
                    Filtro = " Where "
                End If
                If i < argnivel - 1 Then
                    Filtro = Filtro & x(i) & " AND "
                Else
                    Filtro = Filtro & x(i)
                End If
            Next
        End If

    End Sub
#End Region
    Sub ActualizaResultado()
        If panelItems.Visible Then
            For Each itminv In panelItems.Controls
                If itminv.GetType = GetType(ItemInventario) Then
                    Dim ItemEscogido As ItemInventario = itminv
                    If Numero(ItemEscogido.txtNum.Text) > 0 Then
                        Resultados.Add(New Consumo(ItemEscogido, Numero(ItemEscogido.txtNum.Text), ""))
                    End If
                End If
            Next
        Else
            Resultados.Add(New Consumo(ItemEscogido, Numero(txtCant.Text), txtComent.Text))
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Resultados = Nothing
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    
    Dim Directo As Boolean = False

    Sub CargaDirecta(ByVal filaEdit As Integer)
        Directo = True
        btnAceptar.Visible = False
        layoutBotones.SetColumnSpan(btnAceptar2, 2)
        Dim sqlTodo As String = String.Format("Select * from SD_CuentasDetalle where Id = {0}", filaEdit)
        Dim dttConsumo As DataTable = cargarConsulta(sqlTodo) 'siempre debe existir
        If Not IsNothing(dttConsumo) Then
            If dttConsumo.Rows.Count <> 1 Then
                MsgBox(dttConsumo.Rows.Count & "filas encontradas al rastrear el id " & filaEdit & "en Detalle de cuenta", MsgBoxStyle.Critical, "Opps!!!")
                End
            End If
        Else
            MsgBox("Error en la consulta", MsgBoxStyle.Critical, "Opps!!!")
            End
        End If
        Dim sqlItem As String = String.Format("SELECT nombre, pvpu1,tipo, imagen, clase, subclase, no_Parte ,Count(no_parte) as Cuenta " _
                                              & " from dbo.dp03a110 " _
                                              & "  where no_Parte = @p0 " _
                                              & " group by pvpu1, nombre, tipo, imagen, clase, subclase, no_Parte ")
        Dim dttDp03a110 As DataTable = cargarConsulta(sqlItem, , New Object() {dttConsumo.Rows(0)("IdConsumo")})
        If Not IsNothing(dttDp03a110) Then
            If dttDp03a110.Rows.Count <> 1 Then
                MsgBox(dttDp03a110.Rows.Count & "filas encontradas al rastrear el item " & filaEdit & "en Dp03a110", MsgBoxStyle.Critical, "Opps!!!")
                End
            End If
            If dttDp03a110(0)("Cuenta") <> 1 Then
                MsgBox("Item con no_parte repetido en Dp03a110. Contacte al desarrollador", MsgBoxStyle.Critical, "Opps!!!")
                End
            End If
        Else
            MsgBox("Error en la consulta", MsgBoxStyle.Critical, "Opps!!!")
            End
        End If
        'Si llega aca es porque no hubo errores
        ProcesarNivel(0)
        Dim itm As New ItemInventario
        itm.cargaritem(DataC(dttDp03a110(0)("no_parte")), DataC(dttDp03a110(0)("Tipo")), DataC(dttDp03a110(0)("nombre")),
                       DataC(dttDp03a110(0)("imagen")), Numero(DataC(dttDp03a110(0)("pvpu1"))))
        ClickEnItem(itm)
        txtCant.Text = dttConsumo(0)("Cantidad")
        txtComent.Text = DataC(dttConsumo(0)("Comentario"))
        recalcularPrecio()
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click, txtComent.Click
        AbrirTecladoVirtual(Me.tecladoPantallaProc)
        txtComent.Focus()
    End Sub

    Private Sub barNavega_Adelante() Handles barNavega.Adelante
        cargarPaginaItems()
    End Sub

    Private Sub barNavega_Atras() Handles barNavega.Atras
        cargarPaginaItems()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAceptar2.Click
        ActualizaResultado()
        If Directo Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            cmdReiniciar.PerformClick()
        End If
    End Sub

    Private Sub EscogerConsumo_Load(sender As Object, e As EventArgs) Handles Me.Load
        If salta Then
            salta = False
            Exit Sub
        End If
        loader()
    End Sub
End Class
