Public Class SplitCuenta
    Inherits DolphinForm
    Dim loading As Boolean = False
    Dim totalInicial As Double = 0
    Public noPedido As Integer
    Public TablaDisponiblesa As DataTable
    Private listapreFact As New List(Of FacturaV)
    Dim moviendo As Boolean = False
    Dim indexambActual As Integer = 0
    Dim Ambactual As DataTable
    Dim IdMesero As Integer = 0
    Dim ElementoDispSeleccionado As DataGridViewRow
    Public sinCons As Boolean = False
    ' Public Event noConsumos As EventHandler

    Sub New(ByVal argcuenta As Integer, ByVal argidMesero As Integer)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        noPedido = argcuenta
        IdMesero = argidMesero
        Me.MasterTip.SetToolTip(cmdAnt, "Anterior")
        Me.MasterTip.SetToolTip(cmdsig, "Siguiente")
        Me.MasterTip.SetToolTip(cmdNuevo, "Nuevo")
        Me.MasterTip.SetToolTip(cmdDelete, "Eliminar")
        Me.MasterTip.SetToolTip(cmdGP1, "Generar Proforma")
        Me.MasterTip.SetToolTip(cmdGPT, "Generar Todas las Proformas")
        Me.MasterTip.SetToolTip(cmdGrabar1, "Generar Prefactura")
        Me.MasterTip.SetToolTip(cmdGrabarT, "Generar Todas las PreFacturas")
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.lblTotal.BackColor = ColorPrimario
        Me.Label1.BackColor = ColorSecundario
        Me.Label3.BackColor = ColorSecundario
    End Sub
#Region "Carga de datos"
    Sub InicializarTodo(Optional ByVal cargaGuardados As Boolean = True)

        Dim sql As String = String.Format("SELECT     SD_CuentasDetalle.Id, SD_CuentasDetalle.IdConsumo as CodigoItem, SD_CuentasDetalle.Cantidad - SD_CuentasDetalle.CantFact as Cantidad, cast((SD_CuentasDetalle.Cantidad - SD_CuentasDetalle.CantFact) as varchar) + ' ' + SD_CuentasDetalle.DescConsumo as Consumo,   " _
                                          & " SD_CuentasDetalle.ValorUnitario, SD_CuentasDetalle.ValorUnitario * (SD_CuentasDetalle.Cantidad - SD_CuentasDetalle.CantFact) as ValorTotal" _
                                          & " FROM            SD_Consumos_Estados INNER JOIN " _
                                          & " SD_CuentasDetalle ON SD_Consumos_Estados.Id = SD_CuentasDetalle.Estado" _
                                          & " where SD_CuentasDetalle.IdCabecera = {0} and SD_Consumos_Estados.Facturable = 'True' " _
                                          & "and  SD_CuentasDetalle.Cantidad - SD_CuentasDetalle.CantFact > 0", Me.noPedido)
        Dim TablaDisponibles As DataTable = cargarConsulta(sql)
        ''Si no hay nada Regresar avisando
        'Dim vbool As Boolean = False
        'If IsNothing(TablaDisponibles) Then
        '    vbool = True
        'Else
        '    If TablaDisponibles.Rows.Count = 0 Then
        '        vbool = True
        '    End If
        'End If
        'If vbool Then
        '    onNoConsumo()
        '    Return
        'End If
        loading = True
        If Not IsNothing(TablaDisponibles) Or TablaDisponibles.Rows.Count = 0 Then 'toda cuenta deberia tener consumos
            GridTouchDisp.cargarTabla(TablaDisponibles)
            GridTouchDisp.GridDeDatos.Columns(0).Visible = False
            GridTouchDisp.GridDeDatos.Columns(1).Visible = False
            GridTouchDisp.GridDeDatos.Columns(2).Visible = False
            GridTouchDisp.GridDeDatos.Columns(4).Visible = False
            GridTouchDisp.GridDeDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If
        If cargaGuardados Then
            'cargarGuardados
            Dim sqlss As String = String.Format("Declare @cuenta as int = {0} " _
                                    & " Select A.id idPref, D.Id,D.IdConsumo CodigoItem , B.Cantidad, B.DscConsumo Consumo, B.PrecioUnitario ,b.TotalConsumo" _
                                    & " from SD_Prefacturas_Cabecera A " _
                                    & " left join SD_prefactura_Detalle B on A.id=B.idCab " _
                                    & " left join SD_Prefactura_Movimientos C on B.id = C.idPref_Detalle " _
                                    & " left join SD_CuentasDetalle D on C.idCuentasDetalle = D.id " _
                                    & " left join dp03a110 E on D.IdConsumo = E.no_parte " _
                                    & " where A.cuenta = @cuenta And A.Estado='A' and A.fac_pro is null " _
                                    & " order by  A.id,  D.Id", Me.noPedido)
            Dim TablaPref As DataTable = cargarConsulta(sqlss)
            If Not IsNothing(TablaPref) Then
                If TablaPref.Rows.Count > 0 Then
                    'Subselect para sacar las prefacturas
                    Dim dtURecords As New DataTable()
                    dtURecords = TablaPref.DefaultView.ToTable(True, "idPref")
                    For Each fila As DataRow In dtURecords.Rows
                        'Yo se que para que salga por lo menos debe tener una fila
                        añadirAmbiente()
                        listapreFact(listapreFact.Count - 1).grabada = True
                        listapreFact(listapreFact.Count - 1).idPref = fila.Item(0)
                        Dim fPref As DataRow() = TablaPref.Select("idPref = " & fila.Item(0).ToString.Trim())

                        For Each fCons As DataRow In fPref
                            Dim itm As Object() = fCons.ItemArray
                            listapreFact(listapreFact.Count - 1).contenido.Rows.Add(fCons(1),
                            fCons(2), fCons(3), fCons(4), fCons(5), fCons(6))
                        Next
                    Next
                End If
            End If
        End If
        Dim nuevoTotal As Double = 0
        For i = 0 To listapreFact.Count - 1
            If listapreFact(i).grabada Then Continue For
            nuevoTotal = nuevoTotal + Math.Round(Numero(listapreFact(i).contenido.Compute("Sum(ValorTotal)", "")), 2)
        Next
        totalInicial = nuevoTotal + Math.Round(Numero(TablaDisponibles.Compute("Sum(ValorTotal)", "")), 2)
        If listapreFact.Count = 0 Then añadirAmbiente()         'carga del primer ambiente
        cargarAmbiente(1)
        'TotalInicial para Comprobacion 
        'totalInicial = Math.Round(Numero(TablaDisponibles.Compute("Sum(ValorTotal)", "")), 2)
        loading = False
    End Sub
    'Sub onNoConsumo()
    '    Me.sinCons = True
    '    RaiseEvent noConsumos(Me, New EventArgs)
    '    Me.Close()
    'End Sub
    Sub TotalFacturaSelect()
        If loading Then Exit Sub
        lblTotal.Text = CStr(Math.Round(Numero(listapreFact(indexambActual - 1).contenido.Compute("Sum(ValorTotal)", "")), 2))
        'comprobacion Disponibles + no guardados 
        Dim nuevoTotal As Double = 0
        For i = 0 To listapreFact.Count - 1
            If listapreFact(i).grabada Then Continue For
            nuevoTotal = nuevoTotal + Math.Round(Numero(listapreFact(i).contenido.Compute("Sum(ValorTotal)", "")), 2)
        Next
        nuevoTotal = nuevoTotal + Math.Round(Numero(GridTouchDisp.GridDeDatos.DataSource.Compute("Sum(ValorTotal)", "")), 2)
        If Math.Abs(nuevoTotal - totalInicial) > 1 Then 'le doy margen de error en decimales
            MsgBox("Error grave de diseño: Total final diferente de total inicial. El algoritmo ha fallado. Contacte al desarrollador", MsgBoxStyle.Critical, "Opps categoria 1")
            Environment.Exit(-1)
        End If
    End Sub

#End Region


#Region "Emision de Pre-Facturas"

    Private Sub cmdGrabar_Click(sender As Object, e As EventArgs) Handles cmdGrabarT.Click, CmdCancel.Click
        If sender.name = cmdGrabarT.Name Then
            Dim contador As Integer = 0
            For Each FVs As FacturaV In listapreFact
                Dim FV As DataTable = FVs.contenido
                If Not IsNothing(FV) And Not FVs.grabada Then
                    If FV.Rows.Count > 0 Then
                        contador += 1
                    End If
                End If
            Next
            If contador > 0 Then
                If MsgBox("Se grabarán " & contador & " Pre-Factura(s). ¿Desea continuar?", MsgBoxStyle.YesNo, "Confirmacion") = MsgBoxResult.Yes Then
                    PreFacturar()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                MsgBox("No hay ninguna Pre-Factura pendiente de grabarse", MsgBoxStyle.Information, "Un momento!!")
            End If
        ElseIf sender.name = CmdCancel.Name Then
            'Añadir codigo para boton cancelar
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub
    Sub PreFacturar()
        Using transaction As New System.Transactions.TransactionScope()
        ' Recorrer cada una de las Pre - facturas  y actualizar la cantidad facturada
        If listapreFact.Count > 0 Then
            For Each FVIRTs As FacturaV In listapreFact
                If FVIRTs.grabada Then Continue For
                Dim FVIRT As DataTable = FVIRTs.contenido
                If FVIRT.Rows.Count > 0 Then
                    Dim linCab As New List(Of Parametro)
                    linCab.Add(New Parametro("UsuarioCreacion", Me.IdMesero))
                    linCab.Add(New Parametro("TiempoCreacion", SQLFormatDate(Now())))
                    linCab.Add(New Parametro("TotalPrefactura",
                    Math.Round(Numero(FVIRT.Compute("Sum(ValorTotal)", "")), 2)))
                    linCab.Add(New Parametro("Cuenta", noPedido))
                    Dim Lout As New List(Of Parametro)
                    Lout.Add(New Parametro("NoCabecera", 0))
                    Dim IdCabecera As Integer = EjecutarSP("dbo.SDSP_InsertaPrefactura", linCab, Lout)("NoCabecera")
                    For Each consumo In FVIRT.Rows
                        If consumo("Cantidad") > 0 Then
                            Dim linDET As New List(Of Parametro)
                            linDET.Add(New Parametro("cantFact", consumo("Cantidad")))
                            linDET.Add(New Parametro("Id", consumo("Id")))
                            linDET.Add(New Parametro("IdCab", IdCabecera))
                            linDET.Add(New Parametro("DscConsumo", consumo("Consumo")))
                            linDET.Add(New Parametro("PrecioUnitario", Numero(consumo("ValorUnitario"))))
                            linDET.Add(New Parametro("TotalConsumo", Numero(consumo("ValorTotal"))))
                            EjecutarSP("dbo.SDSP_PrefacturaConsumo", linDET)
                        End If

                    Next
                End If
            Next
        End If

        transaction.Complete()
        End Using
    End Sub

#End Region




#Region "Pre-Facturas"
    Private Sub cmdAnt_Click(sender As Object, e As EventArgs) Handles cmdAnt.Click, cmdsig.Click
        If sender.name = cmdAnt.Name Then
            If indexambActual - 1 < 1 Then
                Exit Sub
            Else
                indexambActual -= 1
            End If
        ElseIf sender.name = cmdsig.Name Then
            If indexambActual + 1 > listapreFact.Count Then
                Exit Sub
            Else
                indexambActual += 1
            End If
        End If
        cargarAmbiente(indexambActual)
    End Sub
    Sub cargarAmbiente(ByVal index As Integer)
        Ambactual = listapreFact(index - 1).contenido
        GridTouchSeparado.cargarTabla(Ambactual)
        GridTouchSeparado.GridDeDatos.Columns(0).Visible = False
        GridTouchSeparado.GridDeDatos.Columns(1).Visible = False
        GridTouchSeparado.GridDeDatos.Columns(2).Visible = False
        GridTouchSeparado.GridDeDatos.Columns(4).Visible = False
        GridTouchSeparado.GridDeDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        If listapreFact(index - 1).grabada Then
            GridTouchSeparado.GridDeDatos.Enabled = False
            GridTouchSeparado.GridDeDatos.DefaultCellStyle.BackColor = ColorSecundario
            cmdGrabar1.Enabled = False
            If listapreFact(index - 1).proformada Then
                cmdDelete.Enabled = False
                cmdGP1.Enabled = False
            Else
                cmdDelete.Enabled = True
                cmdGP1.Enabled = True
            End If
        Else
            GridTouchSeparado.GridDeDatos.DefaultCellStyle.BackColor = Color.White
            GridTouchSeparado.GridDeDatos.Enabled = True
            cmdGrabar1.Enabled = True
            cmdDelete.Enabled = False
        End If
        txtNoFac.Text = CStr(index)
        indexambActual = index
        TotalFacturaSelect()
    End Sub
    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        añadirAmbiente()
        cargarAmbiente(listapreFact.Count)
    End Sub
    Sub añadirAmbiente()
        Dim AmbNuevo As DataTable = GridTouchDisp.GridDeDatos.DataSource.clone
        If AmbNuevo.Rows.Count > 0 Then
            AmbNuevo.Rows.Clear()
        End If
        Dim miFV As New FacturaV(AmbNuevo)
        listapreFact.Add(miFV)
        lbltotamb.Text = "/" & listapreFact.Count
    End Sub
#End Region
#Region "Movimiento de elementos"

    Private Sub Arriba_Click(sender As Object, e As EventArgs) Handles Arriba.Click, Abajo.Click

        If Trim(txtcantPasar.Text) = "" Then Exit Sub
        Dim cantPasarAct As Integer = CInt(txtcantPasar.Text)
        If sender.name = Abajo.Name Then
            If cantPasarAct - 1 < 1 Then
                Exit Sub
            Else
                cantPasarAct -= 1
            End If

        ElseIf sender.name = Arriba.Name Then
            ' Me.Hide()
            'If ElementoDispSeleccionado.Index = -1 Then

            '    Exit Sub
            If cantPasarAct + 1 > ElementoDispSeleccionado.Cells("Cantidad").Value Then
                Exit Sub
            Else
                cantPasarAct += 1
            End If
        End If
        txtcantPasar.Text = CStr(cantPasarAct)

    End Sub

    Private Sub derTodos_Click(sender As Object, e As EventArgs) Handles izqTodos.Click, izqcant.Click, derTodos.Click, dercant.Click

        Dim Todos As Boolean = False 'Todos o solo el seleccionado
        Dim OrgDisp As Boolean = False 'Desde Disponibles o desde separado
        If sender.name.contains("Todos") Then
            Todos = True
        End If
        If sender.name.contains("der") Then
            OrgDisp = True
        End If
        moviendo = True

        If Todos Then
            If OrgDisp Then
                MoverElemento(GridTouchDisp, GridTouchSeparado, 0, True)
            Else
                MoverElemento(GridTouchSeparado, GridTouchDisp, 0, True)
            End If
        Else
            If OrgDisp Then
                MoverElemento(GridTouchDisp, GridTouchSeparado, CInt(Numero(txtcantPasar.Text)))
            Else
                MoverElemento(GridTouchSeparado, GridTouchDisp, CInt(Numero(txtcantPasar.Text)))
            End If
        End If
        TotalFacturaSelect()
        moviendo = False
        If OrgDisp Then
            ElementoDispSeleccionado = GridTouchDisp.elementoSeleccionado
        Else
            ElementoDispSeleccionado = GridTouchSeparado.elementoSeleccionado
        End If
    End Sub
    Sub MoverElemento(ByVal origen As GridTouch, ByVal Destino As GridTouch, ByVal cantidad As Integer, Optional Todos As Boolean = False)
        'si se encuentra bloqueado el grid de datos salir
        'Me.Hide() 'ESTO HAY QUE QUITARLO
        If Not GridTouchSeparado.GridDeDatos.Enabled Then Exit Sub
        ' Me.Show() 'ESTO HAY QUE QUITARLO
        Dim borrar As Boolean = False

        If Todos Then
            For Each fila As DataRow In origen.GridDeDatos.DataSource.rows
                Destino.GridDeDatos.DataSource.Rows.Add(fila.ItemArray)
            Next
            origen.GridDeDatos.DataSource.Rows.Clear()
            Exit Sub
        Else
            Dim elemento As DataGridViewRow = origen.elementoSeleccionado
            If Not IsNothing(elemento) Then
                If elemento.Index = -1 Then
                    MsgBox("No existen elementos en el origen", MsgBoxStyle.Information, "Un momento!!!")
                    Exit Sub
                End If
            Else
                MsgBox("No existen elementos en el origen", MsgBoxStyle.Information, "Un momento!!!")
                Exit Sub
            End If
            'obtener el indice de elemento en datasource de origen
            'localizo por id indice unico de cada consumo porloque continuo con el 1er indice encontrado
            Dim FilaEnOrigen As DataRow = elemento.DataBoundItem.row
            If cantidad > FilaEnOrigen("Cantidad") Then 'validacion porsi los usuarios se pasan de mañosos :D 
                cantidad = FilaEnOrigen("Cantidad")
            End If
            If cantidad < FilaEnOrigen("Cantidad") Then
                FilaEnOrigen("Cantidad") =
                    FilaEnOrigen("Cantidad") - cantidad
            ElseIf cantidad = FilaEnOrigen("Cantidad") Then
                borrar = True
            End If
            componerFila(FilaEnOrigen)
            Dim FilaEnDestino As DataRow = DirectCast(Destino.GridDeDatos.DataSource, DataTable).Rows.Add()
            FilaEnDestino.ItemArray = FilaEnOrigen.ItemArray.Clone
            FilaEnDestino("Cantidad") = cantidad
            componerFila(FilaEnDestino)
            If borrar Then DirectCast(origen.GridDeDatos.DataSource, DataTable).Rows.Remove(FilaEnOrigen)
        End If
    End Sub
    Sub componerFila(ByVal fila As DataRow)
        Dim x() As String = fila("Consumo").ToString.Split()
        Dim longitudNumero As Integer = x(0).Length
        fila("Consumo") = fila("Cantidad") & " " & fila("Consumo").ToString.Substring(longitudNumero + 1)
        fila("ValorTotal") = CStr(Numero(CInt(fila("Cantidad")) * CDbl(fila("ValorUnitario"))))
    End Sub
#End Region


#Region "Seleccion de elemento a pasar"

    Private Sub GridTouchDisp_CambioSeleccion(argelementoSeleccionado As DataGridViewRow) Handles GridTouchDisp.CambioSeleccion, GridTouchSeparado.CambioSeleccion
        If moviendo Then Exit Sub
        If DataC(argelementoSeleccionado.DataBoundItem.row("Cantidad")) = "" Then Exit Sub

        txtcantPasar.Text = CInt(DataC(argelementoSeleccionado.DataBoundItem.row("Cantidad")))
        ElementoDispSeleccionado = argelementoSeleccionado
    End Sub
    Private Sub GridTouchDisp_ClickAreaControl(sender As Object) Handles GridTouchDisp.ClickAreaControl, GridTouchSeparado.ClickAreaControl
        If moviendo Then Exit Sub
        Dim argelementoSeleccionado = sender.elementoSeleccionado
        If IsNothing(argelementoSeleccionado) Then Exit Sub
        If argelementoSeleccionado.Index < 0 Then Exit Sub
        If Not IsNothing(argelementoSeleccionado) Then
            txtcantPasar.Text = CInt(argelementoSeleccionado.Cells("Cantidad").Value)
            ElementoDispSeleccionado = argelementoSeleccionado
        End If
    End Sub

#End Region


    Private Sub GridTouchDisp_DobleClickGrid(sender As GridTouch) Handles GridTouchDisp.DobleClickGrid, GridTouchSeparado.DobleClickGrid
        Dim argelementoseleccionado As DataGridViewRow = sender.elementoSeleccionado
        If IsNothing(argelementoseleccionado) Then Exit Sub
        If argelementoseleccionado.Index < 0 Then Exit Sub
        Dim otrogrid As GridTouch
        If sender.Name = GridTouchDisp.Name Then
            otrogrid = GridTouchSeparado
        Else
            otrogrid = GridTouchDisp
        End If
        MoverElemento(sender, otrogrid, argelementoseleccionado.DataBoundItem.row("Cantidad"))
    End Sub

    Private Sub cmdGPT_Click(sender As Object, e As EventArgs) Handles cmdGPT.Click
        Dim contador As Integer = 0
        For Each FVs As FacturaV In listapreFact
            Dim FV As DataTable = FVs.contenido
            If Not IsNothing(FV) And Not FVs.proformada Then
                If FV.Rows.Count > 0 Then
                    contador += 1
                End If
            End If
        Next
        If Not contador > 0 Then
            MsgBox("No hay datos pendientes de grabarse", MsgBoxStyle.Information, "Un momento!!")
            Exit Sub
        End If
        If MsgBox("Se procede a pre-facturar y proformar lo pendiente. ¿Desea continuar?", MsgBoxStyle.YesNo, "Confirmacion") = MsgBoxResult.No Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        ' SE VA A GENERAR UNA PREFACTURA POR TODOS LOS CONSUMOS NO PREFACTURADOS Y 
        ' UNA PROFORMA POR CADA PREFACTURA PENDIENTE DE PROFORMAR 
        Dim lin As New List(Of Parametro)
        lin.Add(New Parametro("cuenta", Me.noPedido))
        lin.Add(New Parametro("usuCrea", Me.IdMesero))
        lin.Add(New Parametro("idInst", Globales.Parametros.Instancia))
        Dim iRes As Integer = EjecutarSP("dbo.SDSP_GrabarProformasT", lin, Nothing, sp_ret.return_Value)
        If iRes <> 1 Then
            MsgBox("Hubo un error al realizar el cierre. Consulte a su proveedor", MsgBoxStyle.Information, "Ooops!!")
            Exit Sub
        Else
            MsgBox("Las proformas han sido grabadas!")
            Me.DialogResult = Windows.Forms.DialogResult.OK

        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub cmdGP1_Click(sender As Object, e As EventArgs) Handles cmdGP1.Click
        If IsNothing(GridTouchSeparado.GridDeDatos.DataSource) Then
            MsgBox("La Pre-Factura está vacía", MsgBoxStyle.Exclamation, "Un momento")
            Exit Sub
        End If

        'Proformar Pre-Factura 
        If Globales.Parametros.confirmaCierre Then
            If MsgBox("Esta seguro de proformar la pre-factura seleccionada?. Este paso es irreversible", MsgBoxStyle.YesNo, "Confirmacion") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Me.Cursor = Cursors.WaitCursor
        'No esta grabada -> Grábala 
        If Not listapreFact(indexambActual - 1).grabada Then
            cmdGrabar1.PerformClick()
        End If
        'prefacturarla
        Dim lIn As New List(Of Parametro)
        lIn.Add(New Parametro("idPref", listapreFact(indexambActual - 1).idPref))
        lIn.Add(New Parametro("idInst", Globales.Parametros.Instancia))
        If EjecutarSP("dbo.SDSP_Prefactura_a_Proforma", lIn, Nothing, sp_ret.return_Value) <> 1 Then
            MsgBox("Hubo un error durante el proformado de la pre-factura")
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdGrabar1_Click(sender As Object, e As EventArgs) Handles cmdGrabar1.Click
        Dim miFV As DataTable = New DataTable()
        If IsNothing(GridTouchSeparado.GridDeDatos.DataSource) Then
            MsgBox("La Pre-Factura está vacía", MsgBoxStyle.Exclamation, "Un momento")
        Else
            miFV = listapreFact(indexambActual - 1).contenido
        End If
        Me.Cursor = Cursors.WaitCursor
        If miFV.Rows.Count > 0 Then
            Dim savedId As Integer
            Using transaction As New System.Transactions.TransactionScope()
            Dim linCab As New List(Of Parametro)
            linCab.Add(New Parametro("UsuarioCreacion", Me.IdMesero))
            linCab.Add(New Parametro("TiempoCreacion", SQLFormatDate(Now())))
            linCab.Add(New Parametro("TotalPrefactura",
            Math.Round(Numero(miFV.Compute("Sum(ValorTotal)", "")), 2)))
            linCab.Add(New Parametro("Cuenta", noPedido))
            Dim Lout As New List(Of Parametro)
            Lout.Add(New Parametro("NoCabecera", 0))
            Dim IdCabecera As Integer = EjecutarSP("dbo.SDSP_InsertaPrefactura", linCab, Lout)("NoCabecera")
            For Each consumo In miFV.Rows
                If consumo("Cantidad") > 0 Then
                    Dim linDET As New List(Of Parametro)
                    linDET.Add(New Parametro("cantFact", consumo("Cantidad")))
                    linDET.Add(New Parametro("Id", consumo("Id")))
                    linDET.Add(New Parametro("IdCab", IdCabecera))
                    linDET.Add(New Parametro("DscConsumo", consumo("Consumo")))
                    linDET.Add(New Parametro("PrecioUnitario", Numero(consumo("ValorUnitario"))))
                    linDET.Add(New Parametro("TotalConsumo", Numero(consumo("ValorTotal"))))
                    EjecutarSP("dbo.SDSP_PrefacturaConsumo", linDET)
                End If
            Next
            savedId = IdCabecera
            transaction.Complete()
            End Using
            listapreFact(indexambActual - 1).grabada = True
            listapreFact(indexambActual - 1).idPref = savedId
            Dim restaIni As Double = Math.Round(Numero(listapreFact(indexambActual - 1).contenido.Compute("Sum(ValorTotal)", "")), 2)
            totalInicial = totalInicial - restaIni
            cargarAmbiente(indexambActual)
            Me.Cursor = Cursors.Default
        Else
            Me.Cursor = Cursors.Default
            MsgBox("La Pre-Factura está vacía", MsgBoxStyle.Exclamation, "Un momento")
            Exit Sub
        End If
    End Sub
    Private Class FacturaV
        Sub New()
            Me.contenido = Nothing
            Me.grabada = False
        End Sub
        Sub New(_contenido As DataTable)
            Me.contenido = _contenido
            Me.grabada = False
        End Sub
        Sub New(_contenido As DataTable, _grabada As Boolean)
            Me.contenido = _contenido
            Me.grabada = _grabada
        End Sub
        Sub New(_contenido As DataTable, _grabada As Boolean, _proformada As Boolean)
            Me.contenido = _contenido
            Me.grabada = _grabada
            Me.proformada = _proformada
        End Sub
        Public Property contenido As DataTable
        Public Property grabada As Boolean = False
        Public Property proformada As Boolean = False
        Public Property idPref As Integer
    End Class

    Private Sub layoutTablaPrinc_Paint(sender As Object, e As PaintEventArgs) Handles layoutTablaPrinc.Paint

    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        'Aqui debo de dar de baja la pre-Factura, reversar el cantFact y afectar la data donde 
        'tenga que afectarla. Refrescar los consumos disponibles y actualizar el total Inicial 

        Me.Cursor = Cursors.WaitCursor
        'Reversar en la DB
        Dim lIn As New List(Of Parametro)
        lIn.Add(New Parametro("idPref", listapreFact(indexambActual - 1).idPref))
        If EjecutarSP("dbo.SDSP_AnulaPreFactura", lIn, Nothing, sp_ret.return_Value) <> 1 Then
            MsgBox("Hubo un error durante la anulación de la pre-factura")
        End If
        'Borrar de la interfaz 
        listapreFact.RemoveAt(indexambActual - 1)
        GridTouchSeparado.GridDeDatos.DataSource = Nothing
        lbltotamb.Text = "/" & listapreFact.Count
        If indexambActual - 1 >= 1 Then
            indexambActual = indexambActual - 1
        End If
        InicializarTodo(False)
        Me.Cursor = Cursors.Default

    End Sub
End Class

