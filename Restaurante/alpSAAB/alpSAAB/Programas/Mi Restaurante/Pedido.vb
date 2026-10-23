Imports System.ComponentModel
Imports Microsoft.Reporting.WinForms

Public Class Pedido
    Inherits DolphinForm
    Public Enum Resultados
        CuentaModificada = 1
        NoGuardarCambios = 2
        CerrarCuenta = 3
    End Enum
    Dim CambiarEstTodos As Boolean = False
    Dim want As Integer = 0
    Dim hant As Integer = 0
    Dim Sector As Integer = 0
    Dim permanece As Boolean = False
    Dim filaEdit As Integer = 0
    Dim capacidad As Integer = 0
    Dim mesas As String = ""
    Dim NoCuenta As Integer = 0
    Dim _AliasCuenta As Integer = 0
    Dim Estado As String = ""
    Dim TotalCuenta As Double
    Dim IdMesero As Integer = 0
    Dim esNueva As Boolean = False
    Dim ConsPendientes As Integer = 0
    Dim resultado As Resultados

    'Dim Consumos() As Consumo
    Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.lblNoCuenta.BackColor = ColorPrimario
        Me.lblTotal.BackColor = ColorPrimario
    End Sub
    Sub New(ByVal ListaMesas As String, ByVal argIDMesero As Integer)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        Me.mesas = ListaMesas
        Me.IdMesero = argIDMesero
        esNueva = True
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.lblNoCuenta.BackColor = ColorPrimario
        Me.lblTotal.BackColor = ColorPrimario
    End Sub
    Sub New(ByVal IdCuenta As Integer, ByVal argIdMesero As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        esNueva = False
        NoCuenta = IdCuenta
        Me._AliasCuenta = GetCampo(NoCuenta, "SD_CuentasCabecera", "Alias")
        Me.IdMesero = argIdMesero
        Me.lblNoCuenta.BackColor = ColorPrimario
        Me.lblTotal.BackColor = ColorPrimario
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Sub cargarCuenta()
        Me.Ventana.Visible = False
        Me.PerformLayout()
        Me.SuspendLayout()
        If Not Parametros.EsquemaCuenta Then
            Me.TableLayoutPanel4.Controls.Remove(Me.minSector)
            Me.minSector = Nothing
        End If
        cargarMesas()
        If esNueva Then
            clickBoton(cmdGrabar)
        End If
        Me.cmdComanda.Enabled = Not esNueva
        Me.cmdGrabaPrefac.Enabled = Not esNueva
        Me.cmdCerrar.Enabled = Not esNueva
        Me.cmdNuevoConsumo.Enabled = Not esNueva
        Me.ResumeLayout(False)
        lblNoCuenta.Text = CStr(Me._AliasCuenta)
        If Parametros.ResMesero Then
            If NoCuenta > 0 Then
                Me.IdMesero = GetCampo(NoCuenta, "SD_CuentasCabecera", "IdMesero")
            End If
        End If
        lblMesero.Text = GetCampo(Me.IdMesero, "rola110", "Nombre", "codemp").ToString.ToLower.Split(" ")(0) & " " & Trim(GetCampo(Me.IdMesero, "rola110", "Apellido", "codemp")).ToLower
        If Not esNueva Then
            lblPersonas.Text = GetCampo(NoCuenta, "SD_CuentasCabecera", "NoPersonas")
        Else
            lblPersonas.Text = CStr(1)
        End If
        Me.ResumeLayout(False)
        If esNueva Then
            Me.Text = "Cuenta Nueva"
        Else
            Me.Text = "Cuenta " & _AliasCuenta
        End If

        Me.ResumeLayout(False)
        cargarConsumos()
        Me.ResumeLayout(False)
        Me.Ventana.Visible = True
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Sub cargarConsumos()
        If Not IsNothing(GridConsumos.DataSource) Then GridConsumos.DataSource.rows.clear()
        Dim sql As String = String.Format("SELECT        Id, CAST(Cantidad AS varchar) + ' ' + DescConsumo AS Consumo, ValorTotal, Estado, Comentario " _
                                          & "       FROM SD_CuentasDetalle " _
                                          & " WHERE        (IdCabecera = {0})", Me.NoCuenta)
        Dim consumos As DataTable = cargarConsulta(sql)
        If Not IsNothing(consumos) Then
            If consumos.Rows.Count > 0 Then
                lblTotal.Text = CStr(Math.Round(consumos.Compute("Sum(ValorTotal)", ""), 2))
                ConsPendientes = consumos.Compute("Count(Estado)", "Estado = 0")
                GridConsumos.DataSource = consumos
                GridConsumos.Update()
            Else
                lblTotal.Text = CStr(Math.Round(0, 2))
            End If
        End If

    End Sub
    Sub cargarMesas()
        capacidad = 0
        PanelMesas.Controls.Clear()
        Dim sql As String = String.Format("select IdMesa from SD_Cuentas_Mesas where IdCuenta = {0}", Me.NoCuenta)
        Dim tablaMesas As New DataTable
        If esNueva Then
            'ArmarTablaMesa
            tablaMesas.Columns.Add("IdMesa")
            Dim io() As String = Me.mesas.Split(",")
            For Each idMesa As String In io
                tablaMesas.Rows.Add(idMesa)
            Next
        Else
            tablaMesas = cargarConsulta(sql)
        End If
        Dim i = 0
        For Each mesita As DataRow In tablaMesas.Rows
            Dim botonx As New Button
            botonx.Tag = mesita("IdMesa")
            botonx.Text = GetCampo(mesita("IdMesa"), "SD_Mesas", "Alias")
            capacidad = capacidad + GetCampo(mesita("IdMesa"), "SD_Mesas", "Capacidad")
            botonx.Dock = DockStyle.Top
            PanelMesas.Controls.Add(botonx)
            AddHandler botonx.Click, AddressOf clickBotonMesa
            botonx.AutoSize = True
            If i = 0 Then
                Me.mesas = CStr(botonx.Tag)
            Else
                Me.mesas = Me.mesas & ", " & CStr(botonx.Tag)
            End If
            i += 1
        Next
        Dim boton As New Button
        boton.Tag = -1
        boton.Text = "Añadir Mesa"
        boton.Dock = DockStyle.Bottom
        PanelMesas.Controls.Add(boton)
        boton.AutoSize = True
        AddHandler boton.Click, AddressOf clickAgregaMesa
        PanelMesas.Enabled = Not esNueva
        If Parametros.EsquemaCuenta Then
            cargarMiniaturaMesas()
        End If
        If esNueva Then
            lblPersonas.Text = CStr(capacidad)
        End If
    End Sub
    Sub cargarMiniaturaMesas()
        If IsNothing(minSector) Then Exit Sub
        'codigo para Miniatura. carga a partir de la variable Me.mesas y el ultimo sector
        Dim x() = mesas.Split(",")
        For Each element In x
            ' por ahora coge solo del ultimo sector
            Sector = GetCampo(Trim(element), "SD_Mesas", "IdSector")
        Next

        minSector.EsEsquema = True : minSector.EsMiniatura = True
        minSector.cargarEsquema(Sector)
        minSector.Refresh()
        Me.ResumeLayout(False)
        minSector.PanelArea.PerformLayout()
        want = minSector.PanelArea.PreferredSize.Width
        hant = minSector.PanelArea.PreferredSize.Height
        escalar()
        Me.capacidad = minSector.resaltarMesa(Me.mesas)
        Me.PerformLayout()
    End Sub
    Sub escalar()
        Dim fSize As New SizeF((minSector.Width / want),
                                         (minSector.Height / hant))
        minSector.escalarMiniatura(fSize)
        minSector.PanelArea.Width = minSector.Width
        minSector.PanelArea.Height = minSector.Height
        want = minSector.Width
        hant = minSector.Height
    End Sub
    Sub clickAgregaMesa(ByVal boton As Button, e As EventArgs)
        Dim frmAgregaMesa As New AgregarMesa
        frmAgregaMesa.CargarTodo(Me.mesas)
        If frmAgregaMesa.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ProcesarNuevaListaMesas(frmAgregaMesa)
        End If
    End Sub
    Sub ProcesarNuevaListaMesas(ByVal argfrm As AgregarMesa)
        'Cambio de cuenta de los productos 
        Dim sqlCambiar As String = ""
        For Each Cuenta As AgregarMesa.ParCuentaMesa In argfrm.ListaCuentasAñadir
            sqlCambiar = sqlCambiar & String.Format(" Update SD_CuentasDetalle set IdCabecera = {0} where IdCabecera = {1} ; " _
                                                    & " Update SD_CuentasCabecera set estado = 'T' where id = {1} ; ", Me.NoCuenta, Cuenta.cuenta)
        Next
        If sqlCambiar <> "" Then
            EjecutarConsulta(sqlCambiar, , True)
        End If

        'representacion en pantalla
        esNueva = True
        Me.mesas = argfrm.ListaMesas
        cargarMesas()
        esNueva = False
        PanelMesas.Enabled = Not esNueva
        cargarConsumos()
    End Sub
    Sub clickBotonMesa(ByVal boton As Button, e As EventArgs)
        If MsgBox(String.Format("Desea quitar {0} de la cuenta {1} ", boton.Text, Me._AliasCuenta) _
                      , MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            If PanelMesas.Controls.Count > 2 Then
                PanelMesas.Controls.Remove(boton)
                rehacerListaMesas()
                cargarMiniaturaMesas()
            Else
                MsgBox("No puede quitar todas las mesas de la cuenta", MsgBoxStyle.Exclamation, "Un Momento!!!")
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Sub rehacerListaMesas()
        Dim i = 0
        For Each boton In PanelMesas.Controls
            If boton.tag <> -1 Then 'es mesa
                If i = 0 Then
                    Me.mesas = CStr(boton.Tag)
                Else
                    Me.mesas = Me.mesas & ", " & CStr(boton.Tag)
                End If
                i += 1
            End If
        Next
    End Sub

    Private Sub CmdVolver_Click_1(sender As Object, e As EventArgs) Handles CmdVolver.Click, CmdCancel.Click, cmdGrabar.Click
        clickBoton(sender)
    End Sub
    Sub clickBoton(ByVal sender As Object)
        Me.Cursor = Cursors.WaitCursor
        Ventana.Visible = False
        SuspendLayout()
        Select Case sender.name
            Case CmdVolver.Name, CmdCancel.Name
                resultado = Resultados.NoGuardarCambios
            Case cmdGrabaPrefac.Name
                resultado = Resultados.CerrarCuenta
            Case cmdGrabar.Name
                resultado = Resultados.CuentaModificada
        End Select
        SalirVentana(resultado)
        Me.ResumeLayout(False)
        If (resultado = Resultados.NoGuardarCambios) Or (Not esNueva And resultado = Resultados.CuentaModificada) Then
            Me.DialogResult = resultado
            Me.Close()
        ElseIf esNueva And resultado = Resultados.CuentaModificada Then
            'mantener porque es nueva
            Me.ResumeLayout(False)
            esNueva = False
            Me._AliasCuenta = GetCampo(NoCuenta, "SD_CuentasCabecera", "Alias")
            Me.cargarCuenta()
            Me.cargarMesas()
            Me.ResumeLayout(False)
            GoTo salida
        End If

salida:
        Cursor = Cursors.Default
        Me.ResumeLayout(False)
        Me.PerformLayout()
        Ventana.Visible = True
    End Sub
    Sub SalirVentana(ByVal res As Resultados)
        Select Case res
            Case Resultados.NoGuardarCambios
                GuardarCuenta(False, True)
                Exit Sub
            Case Resultados.CerrarCuenta
                GuardarCuenta(True)
            Case Resultados.CuentaModificada
                GuardarCuenta(False)
        End Select
    End Sub
    Sub GuardarCuenta(ByVal CerrarCuenta As Boolean, Optional solosalir As Boolean = False)
        Dim ids = Database.IdList(Me.mesas)
        Dim targetId = Me.NoCuenta
        Dim targetAlias = Me._AliasCuenta
        Dim names As New List(Of String)()
        Using transaction As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required,
                New System.Transactions.TransactionOptions With {.IsolationLevel = System.Transactions.IsolationLevel.Serializable, .Timeout = TimeSpan.FromSeconds(60)})
            For Each id In ids
                names.Add(GetCampo(id, "SD_Mesas", "Alias"))
            Next
            Dim tables = String.Join(", ", names)
            If esNueva Then
                targetId = Comprueba_Existe(Me.mesas)
                If targetId < 0 Then Return
            End If
            If targetId = 0 AndAlso Not solosalir Then
                Dim created = cargarConsulta("DECLARE @created TABLE (Id int, alias int); INSERT INTO SD_CuentasCabecera (alias, Mesas, estado, TotalCuenta, Idmesero, NoPersonas, TiempoCreacion) OUTPUT INSERTED.Id, INSERTED.alias INTO @created SELECT ISNULL(MAX(alias), 0) + 1, @p0, 'A', 0, @p1, @p2, @p3 FROM SD_CuentasCabecera WITH (UPDLOCK, HOLDLOCK); SELECT Id, alias FROM @created", , New Object() {tables, Me.IdMesero, CInt(lblPersonas.Text), Now})
                targetId = CInt(created(0)("Id"))
                targetAlias = CInt(created(0)("alias"))
            ElseIf targetId > 0 Then
                Dim total = Decimal.Parse(lblTotal.Text, Globalization.NumberStyles.Number, Globalization.CultureInfo.CurrentCulture)
                Dim updateSql = "UPDATE SD_CuentasCabecera SET Mesas = @p0, TotalCuenta = @p1"
                If Not solosalir Then updateSql &= ", NoPersonas = @p2"
                updateSql &= " WHERE Id = @p3"
                If EjecutarConsulta(updateSql, , , New Object() {tables, total, CInt(lblPersonas.Text), targetId}) <> 1 Then Throw New InvalidOperationException("No se pudo actualizar la cuenta.")
            End If
            If Not solosalir Then
                Dim batch As New SqlBatch()
                batch.AddFormat("DELETE FROM SD_Cuentas_Mesas WHERE IdCuenta = {0}", targetId)
                For Each id In ids
                    batch.AddFormat("INSERT INTO SD_Cuentas_Mesas (IdCuenta, IdMesa) VALUES ({0}, {1})", targetId, id)
                Next
                batch.Execute(CStr(Cn_x_Defecto))
            End If
            transaction.Complete()
        End Using
        Me.NoCuenta = targetId
        Me._AliasCuenta = targetAlias
        If targetId > 0 Then esNueva = False
        If CerrarCuenta Then Me.Close()
    End Sub
    Private Sub cmdMas_Click(sender As Object, e As EventArgs) Handles cmdMas.Click, cmdMenos.Click
        Dim Actual As Integer = CInt(lblPersonas.Text)
        Dim Nuevo As Integer = 0
        If sender.name = cmdMas.Name Then
            Nuevo = Actual + 1
        ElseIf sender.name = cmdMenos.Name Then
            Nuevo = Actual - 1
        End If
        If Nuevo > capacidad And sender.name = cmdMas.Name Then
            If MsgBox(String.Format("La capacidad sumada que se registra de las mesas incluídas es de {0}. ¿Desea aumentar las personas en esta cuenta de todas maneras?", Me.capacidad),
                   MsgBoxStyle.YesNo, "Un momento!!!") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If Nuevo < 1 Then
            Exit Sub
        End If
        lblPersonas.Text = CStr(Nuevo)
    End Sub

    Private Sub GridConsumos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridConsumos.CellClick
        If e.ColumnIndex = GridConsumos.Columns("_EstadoImagen").Index Then
            If e.RowIndex >= 0 Then
                CambiarEstTodos = False
                Dim ms As MenuEstados
                If GridConsumos.Rows(e.RowIndex).Cells("_Estado").Value = 0 Then
                    ms = New MenuEstados("Descripcion", "Id", TipoMenuEstado.NoComandado)
                Else
                    ms = New MenuEstados("Descripcion", "Id", TipoMenuEstado.Comandado)
                End If
                ms.Owner = Me : filaEdit = GridConsumos.Rows(e.RowIndex).Cells("IdConsumo").Value
                ms.Location = Cursor.Position
                AddHandler ms.res, AddressOf ckMenuEstados
                If GridConsumos.Rows(e.RowIndex).Cells("_Estado").Value = 0 Then
                    'PresentarMenuestados para eliminar o modificar
                    ms.CargarElementos(True)
                Else
                    ms.CargarElementos()
                End If
                ms.Show()
            ElseIf e.RowIndex = -1 Then
                Dim ms As New MenuEstados("Descripcion", "Id", TipoMenuEstado.Comandado)
                ms.Owner = Me
                ms.Location = Cursor.Position
                AddHandler ms.res, AddressOf ckMenuEstados
                ms.CargarElementos()
                CambiarEstTodos = True
                ms.Show()
            End If

        End If
    End Sub
    Sub ckMenuEstados(ByVal sender As MenuEstados)
        'Acabo de llegar desde cerrar un MenuEstados
        'Se debe controlar que venga para aplicar a todos o que venga desde una seleccion unitaria
        'Control para verificar que se haya hexo click en un estado
        If sender.DialogResult = Windows.Forms.DialogResult.None Or sender.DialogResult = Windows.Forms.DialogResult.Cancel Then
            'quitar bandera para modificacion de todos
            If CambiarEstTodos Then
                CambiarEstTodos = False
            End If
            Exit Sub
        End If

        'Comienza el Proceso

        'sin importar el tipo recogemos el resultado del valor
        Dim EstadoNuevo As Integer = sender.Tag 'Opcion seleccionada en el Menu Estados
        Dim EstadoViejo As Integer = 0
        Dim PresentaAR As Boolean = False
        Dim EstNuevoAR As Boolean
        Dim EstViejoAr As Boolean = False
        Dim VieneTodosHay1AR As Boolean = False
        Select Case sender.TipoMenu
            Case TipoMenuEstado.Comandado
                'es un consumo comandado 
                If CambiarEstTodos Then
                    'buscar si alguno de los estados comandados es un adminrequired
                    For Each fila As DataGridViewRow In GridConsumos.Rows
                        'esta confirmado???
                        If fila.Cells("_Estado").Value <> 0 Then
                            'es adminRequired??
                            If CBool(GetCampo(fila.Cells("_Estado").Value, "SD_Consumos_Estados", "AdminRequired")) Then
                                VieneTodosHay1AR = True
                                'Basta que haya uno para que pida permiso
                                Exit For
                            End If
                        End If
                    Next
                Else
                    'EstadoViejo solo toma un valor diferente de 0 si no viene desde el boton de la cabecera
                    EstadoViejo = GetCampo(filaEdit, "Sd_CuentasDetalle", "Estado")
                End If

                If EstadoNuevo = EstadoViejo Then GoTo salida 'para q cambiar si es el mismo
                EstNuevoAR = CBool(GetCampo(EstadoNuevo, "SD_consumos_Estados", "AdminRequired")) 'AR estado nuevo
                If EstadoViejo <> 0 Then  ' si es 0 viene desde chkTodos
                    EstViejoAr = CBool(GetCampo(EstadoViejo, "SD_consumos_Estados", "AdminRequired")) 'AR estado viejo. False si viene desde boton cabecera
                End If

                'Presentar requerimiento de clave 
                If EstNuevoAR Or EstViejoAr Or VieneTodosHay1AR Then
                    Dim frmClave As New InputClave
                    Dim result As Integer = frmClave.ShowDialog
                    If result <> InputClave.Res_Input.Exito Then
                        GoTo salida
                    Else
                        'aprobado. continuar
                    End If
                End If

                ' Dim resultado As String = sender.Resultado ' NO SE PORQUE LO PUSE :D

                'procesar el cambio de Estado
                If CambiarEstTodos Then
                    CambiaEstadoConsumo(NoCuenta, EstadoNuevo)
                Else
                    CambiaEstadoConsumo(filaEdit, EstadoNuevo)
                    '*************************Para comprobar si cambió***************************************
                    EstadoViejo = DataC(GetCampo(filaEdit, "Sd_CuentasDetalle", "Estado")) 'reutilizo la variable para ver el nuevo estado
                    If EstadoNuevo <> EstadoViejo Then
                        GoTo salida
                    End If
                    '****************************************************************************************
                End If
            Case TipoMenuEstado.NoComandado
                'verifico integridad de coherencia
                'no puedes haber mandado a suprimir todos desde el boton de la cabecera
                If CambiarEstTodos Then
                    CambiarEstTodos = False
                    MsgBox("Deteccion de incoherencia lógica. Menu opt no confirmado no puede modificar a todos los consumos.", MsgBoxStyle.Exclamation, "Opps cat 5")
                    Exit Sub
                End If
                'Procesar seleccion
                Select Case EstadoNuevo
                    Case 1 'Suprimir
                        If MsgBox("¿Esta seguro que desea remover el consumo seleccionado?", MsgBoxStyle.YesNo, "Confirmacion") = MsgBoxResult.Yes Then
                            EliminarConsumo(filaEdit)
                        End If
                    Case 2 ' Modificar
                        Dim frmconsumo As New EscogerConsumo
                        frmconsumo.Owner = Me
                        frmconsumo.salta = True
                        frmconsumo.CargarNiveles()
                        frmconsumo.CargaDirecta(filaEdit)
                        frmconsumo.panelNiveles.Visible = False
                        frmconsumo.panelItems.Visible = False
                        frmconsumo.PanelSelProd.Visible = True
                        frmconsumo.PanelSelProd.BringToFront()
                        Dim res = frmconsumo.ShowDialog()
                        'frmconsumo.Show() 'para depuracion
                        If res = Windows.Forms.DialogResult.OK Then
                            If Not frmconsumo.Resultados.Count = 0 Then
                                Dim consu As List(Of EscogerConsumo.Consumo) = frmconsumo.Resultados
                                If Not IsNothing(consu) Then
                                    EliminarConsumo(filaEdit)
                                    For Each cons As EscogerConsumo.Consumo In consu
                                        AgregarConsumo(cons)
                                    Next
                                End If
                            End If
                        End If
                End Select
            Case Else
                MsgBox("Error de programacion: caso de menu Estado no admitido para el form ", MsgBoxStyle.Critical, "Opps Categoria 1")
                End
        End Select
salida:
        cargarConsumos()
        Me.Focus()
        Exit Sub
    End Sub
    Sub EliminarConsumo(ByVal id As Integer)
        Dim sql As String = String.Format("Delete from SD_CuentasDetalle where Id = {0}", id)
        Dim ret As Integer = EjecutarConsulta(sql)
        If ret <> 1 Then
            MsgBox("Error grave: El proceso afectó a " & ret.ToString & "consumos. Contacte al desarrollador", MsgBoxStyle.Critical, "Oops!!!!!")
            End
        End If
        cargarConsumos()
    End Sub
    Sub CambiaEstadoConsumo(ByVal id As Integer, ByVal estadoNuevo As Integer)
        Dim sql As String
        If CambiarEstTodos Then
            ' Posible parametrizacion. Para version Nueva
            ' No se cambian los productos no comandados
            sql = String.Format("  Update SD_CuentasDetalle Set Estado = {0} where IdCabecera= {1} AND Estado <> 0", estadoNuevo, id)
            ' Se cambia TODOS (Desactivado)
            ' sql = String.Format("Update SD_CuentasDetalle Set Estado = {0} where IdCabecera= {1} ", estadoNuevo, id)
        Else
            sql = String.Format("Update SD_CuentasDetalle Set Estado = {0} where Id = {1}", estadoNuevo, id)
        End If
        EjecutarConsulta(sql)

        'Quitar la bandera de cambio de todos
        If CambiarEstTodos Then
            CambiarEstTodos = False
        End If
    End Sub



    Private Sub GridConsumos_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles GridConsumos.CellPainting
        If e.ColumnIndex = GridConsumos.Columns("_EstadoImagen").Index And e.RowIndex >= 0 Then
            Try
                Dim celBoton As DataGridViewButtonCell = TryCast(GridConsumos.Rows(e.RowIndex).Cells("_EstadoImagen"), DataGridViewButtonCell)
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                If CInt(GridConsumos.Rows(e.RowIndex).Cells("_Estado").Value) >= 1 And
                   CInt(GridConsumos.Rows(e.RowIndex).Cells("_Estado").Value) < EstadosImagen.Images.Count Then
                    Dim imagenEstado As Image = EstadosImagen.Images(CInt(GridConsumos.Rows(e.RowIndex).Cells("_Estado").Value) - 1)
                    e.Graphics.DrawImage(imagenEstado, e.CellBounds)
                    'GridConsumos.Columns(e.ColumnIndex).Width = imagenEstado.Width
                    e.Handled = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub Cuenta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If Application.OpenForms.Count > 0 Then
            For i = 0 To Application.OpenForms.Count - 1
                If Application.OpenForms(i).Text = "Restaurante" _
                    Or Application.OpenForms(i).Text = "Principal" Then
                    DirectCast(Application.OpenForms(i), DolphinForm).cargarEstadisticas()
                End If
            Next
        End If
        Dim ult As Integer = Application.OpenForms.Count - 1
        Try
            Application.OpenForms.Item(ult).Show()
            Application.OpenForms.Item(ult).Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Cuenta_Load(sender As Object, e As EventArgs) Handles Me.Load
        cargarImagenEstados()

        Me.ReportViewer1.RefreshReport()
    End Sub
    Sub cargarImagenEstados()
        Dim sqlestados As String = "select Path from SD_Consumos_Estados order by id Asc "
        Dim tablapaths As DataTable = cargarConsulta(sqlestados)
        If Not IsNothing(tablapaths) Then
            For Each Estado As DataRow In tablapaths.Rows
                EstadosImagen.Images.Add(Image.FromFile(Application.StartupPath & "\BMPs\" & Estado("path")))
            Next
        End If
    End Sub
    Private Sub cmdNuevoConsumo_Click(sender As Object, e As EventArgs) Handles cmdNuevoConsumo.Click
        Dim frmconsumo As New EscogerConsumo
        frmconsumo.WindowState = FormWindowState.Maximized
        frmconsumo.Owner = Me
        frmconsumo.ShowDialog()

        'frmconsumo.Show()
        Dim consu As List(Of EscogerConsumo.Consumo) = frmconsumo.Resultados
        If Not IsNothing(consu) Then
            If consu.Count > 0 Then
                For Each csn As EscogerConsumo.Consumo In consu
                    AgregarConsumo(csn)
                Next
            End If
        End If
    End Sub
    Sub AgregarConsumo(ByVal argconsu As EscogerConsumo.Consumo)
        Dim batch As New SqlBatch()
        batch.AddFormat("Insert into SD_CuentasDetalle (IdCabecera, Cantidad, IdConsumo, DescConsumo, Estado, ValorUnitario, ValorTotal, TiempoIni, Comentario, UsuarioCreacion, TiempoCreacion) VALUES ({0}, {1}, {2}, {3}, 0, {4}, {5}, {6}, {7}, {8}, {6})",
                        Me.NoCuenta, CDec(argconsu.cantidad), argconsu.itemInv.Codigo, argconsu.itemInv.nombre,
                        CDec(argconsu.itemInv.Precio), Math.Round(CDec(argconsu.itemInv.Precio) * CDec(argconsu.cantidad), 2), Now, argconsu.comentario, Me.IdMesero)
        If batch.Execute(CStr(Cn_x_Defecto)) <> 1 Then Throw New InvalidOperationException("No se pudo agregar el consumo.")
        cargarConsumos()
    End Sub

    Private Sub cmdComanda_Click(sender As Object, e As EventArgs) Handles cmdComanda.Click
        If ConsPendientes > 0 Then
            If MsgBox("¿Desea comandar los consumos que aun no han sido confirmados?", MsgBoxStyle.YesNo, "Confirmacion") = MsgBoxResult.Yes Then
                Try
                    cmdComanda.Enabled = False
                    Try
                        comandar()
                    Finally
                        cmdComanda.Enabled = True
                    End Try
                Catch ex As Exception
                    MsgBox(Database.UserError(ex), MsgBoxStyle.Exclamation)
                End Try

            End If
        End If

    End Sub
    Sub comandar()
        Dim IdCabecera As Integer
        Using transaction As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, New System.Transactions.TransactionOptions With {.IsolationLevel = System.Transactions.IsolationLevel.Serializable, .Timeout = TimeSpan.FromSeconds(60)})

        Dim listaMesas As String = GetCampo(Me.NoCuenta, "SD_CuentasCabecera", "Mesas")
        'en idc tengo todos los que debo generar comanda

        Dim Lin As New List(Of Parametro)
        Lin.Add(New Parametro("idImpresora", 1))
        Lin.Add(New Parametro("idUsuarioCrea", Me.IdMesero))
        Lin.Add(New Parametro("tiempoCreacion", SQLFormatDate(Now())))
        Lin.Add(New Parametro("UsuarioImprime", 1))
        Lin.Add(New Parametro("UltimaImpresion", SQLFormatDate(Now())))
        Lin.Add(New Parametro("Cuenta", Me.NoCuenta))
        Lin.Add(New Parametro("AliasCuenta", Me._AliasCuenta))
        Lin.Add(New Parametro("Mesa", Me.mesas))
        Lin.Add(New Parametro("Aliasmesa", listaMesas))
        Dim LOut As New List(Of Parametro)
        LOut.Add(New Parametro("NoCabecera", 0))
        IdCabecera = EjecutarSP("dbo.SDSP_InsertaComanda", Lin, LOut)("NoCabecera")

        'ahora los consumos

        'cambiar estado a primer estado de la tabla

        'buscando items no comandados
        For Each consumo As DataGridViewRow In GridConsumos.Rows
            If consumo.Cells("_Estado").Value = 0 Then
                Dim IdDc As Integer = consumo.Cells("IdConsumo").Value
                Dim IdNoparte As String = DataC(GetCampo(IdDc, "SD_CuentasDetalle", "IdConsumo"))
                Dim NombreConsumo As String = DataC(GetCampo(IdDc, "SD_CuentasDetalle", "DescConsumo"))
                Dim Cantidad As String = DataC(GetCampo(IdDc, "SD_CuentasDetalle", "Cantidad"))
                'agregar al detalle este consumo
                Lin.Clear()
                Lin.Add(New Parametro("idComanda", IdCabecera))
                Lin.Add(New Parametro("Cantidad", Cantidad))
                Lin.Add(New Parametro("IdConsumo", IdDc))
                Lin.Add(New Parametro("idProducto", IdNoparte))
                Lin.Add(New Parametro("NombreProducto", NombreConsumo))
                Lin.Add(New Parametro("Comentario", DataC(consumo.Cells("CCOM").Value)))
                Lin.Add(New Parametro("tiempoEmision", SQLFormatDate(Now())))
                Lin.Add(New Parametro("IdMesero", Me.IdMesero))
                EjecutarSP("dbo.SDSP_InsertaComandaDetalle", Lin, Nothing, sp_ret.filas_afectadas)
            End If
        Next
        transaction.Complete()
        End Using
        Try
            imprimeComanda(IdCabecera)
        Finally
            cargarConsumos()
        End Try
    End Sub

    Private Sub cmdCierraCuenta_Click(sender As Object, e As EventArgs) Handles cmdGrabaPrefac.Click
        Dim frmSplit As New SplitCuenta(Me.NoCuenta, Me.IdMesero)
        frmSplit.InicializarTodo()
        ' If Not frmSplit.sinCons Then
        frmSplit.ShowDialog()
        'frmSplit.Show()
        ' Else
        'MsgBox("No Existen consumos disponibles para ser pre-facturados")
        'End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        CerrarCuenta()
    End Sub
    Sub CerrarCuenta()
        'Lo primero es validar que los consumos esten todos con estado con final = true
        If Not validarCierre() Then
            MsgBox("La cuenta no puede ser cerrada aún pues existen consumos sin finalizar. Favor Verificar")
            Exit Sub
        End If
        'Esta validacion de confirmaCierre maneja todos los mensajes que se producen al cierre de cuenta
        'Debe considerarse que al cerrar la cuenta se prefactura todo lo que se pueda y se graban las 
        'proformas
        Dim prefTodos As Boolean = False
        Dim facturaTodos As Boolean = False
        If Globales.Parametros.confirmaCierre Then
            If MsgBox("Se procederá a cerrar la cuenta. ¿Desea continuar?", MsgBoxStyle.YesNo, "Confirmación") = DialogResult.No Then
                Exit Sub
            End If
            '************************Proformas************************
            If Not validarPrefactura() Then
                If MsgBox("Existen consumos que no han sido prefacturados. Se va a generar una pre-factura por todos ellos.  ¿Desea continuar? ", MsgBoxStyle.YesNo, "Confirmación") = DialogResult.No Then
                    Exit Sub
                End If
            End If
            If Not validarProforma() Then
                If MsgBox("Al cerrar la cuenta se guardarán las proformas faltantes. ¿Desea continuar?", MsgBoxStyle.YesNo, "Confirmación") = DialogResult.No Then
                    Exit Sub
                End If
            End If
        End If
        'SI HE LLEGADO HASTA ESTE PUNTO ES PORQUE EL USUARIO SABE QUE SE VA A GENERAR UNA PREFACTURA POR 
        'TODOS LOS CONSUMOS NO PREFACTURADOS Y UNA PROFORMA POR CADA PREFACTURA PENDIENTE DE PROFORMAR 
        Dim lin As New List(Of Parametro)
        lin.Add(New Parametro("cuenta", Me.NoCuenta))
        lin.Add(New Parametro("usuCrea", Me.IdMesero))
        lin.Add(New Parametro("idInst", Globales.Parametros.Instancia))
        Using transaction As New System.Transactions.TransactionScope()
        Dim iRes As Integer = EjecutarSP("dbo.SDSP_GrabarProformasT", lin, Nothing, sp_ret.return_Value)
        If iRes <> 1 Then
            MsgBox("Hubo un error al realizar el cierre. Consulte a su proveedor", MsgBoxStyle.Information, "Ooops!!")
            Exit Sub
        End If
        '************************Cerrar Cuenta************************
        lin = New List(Of Parametro)
        lin.Add(New Parametro("Estado", "O"))
        lin.Add(New Parametro("Id", Me.NoCuenta))
        EjecutarSP("dbo.SDSP_CambiaEstadoCuenta", lin)
        transaction.Complete()
        End Using
        If Globales.Parametros.confirmaCierre Then
            MsgBox("Se ha realizado el cierre de la cuenta con éxito", MsgBoxStyle.Information, "EnhoraBuena!!!")
        End If
        Me.Close()
    End Sub
    Function validarCierre() As Boolean
        Dim sql As String = String.Format("EXEC SDSP_CompruebaCierre @idCuenta = {0} ", Me.NoCuenta)
        Dim var As Object = DevuelveValor(sql)
        If Not IsNothing(var) Then
            If var.GetType = GetType(Boolean) Then
                If var Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function
    Function validarPrefactura() As Boolean
        Dim lin As New List(Of Parametro)
        lin.Add(New Parametro("idCuenta", Me.NoCuenta))
        Dim lout As New List(Of Parametro) : lout.Add(New Parametro("Resultado", False))
        Dim Res As Boolean = CBool(EjecutarSP("dbo.SDSP_CompruebaPrefactura2", lin, lout)("Resultado"))
        If Not IsNothing(Res) Then
            Return Res
        Else
            Return False
        End If
    End Function
    Function validarProforma() As Boolean
        Dim sql As String = String.Format("Select count(*) cuenta from SD_Prefacturas_Cabecera where estado = 'A' " &
           " and fac_pro is null and cuenta = {0} ", Me.NoCuenta)
        Dim cuentaNoProf As Object = DevuelveValor(sql)
        Dim sqlTodos As String = String.Format("Select count(*) cuenta from SD_Prefacturas_Cabecera where estado = 'A' " &
           " and cuenta = {0} ", Me.NoCuenta)
        Dim cuentaTodos As Object = DevuelveValor(sqlTodos)
        If Not IsNothing(cuentaNoProf) And Not IsNothing(cuentaTodos) Then
            If cuentaTodos = 0 Then
                Return False
            End If
            If cuentaNoProf.GetType = GetType(Integer) And cuentaTodos.GetType = GetType(Integer) Then
                If cuentaTodos - cuentaNoProf > 0 Then
                    Return False
                ElseIf cuentaTodos - cuentaNoProf = 0 Then
                    Return True
                Else
                    Return False
                End If
            End If
        End If
        Return False
    End Function

    Private Sub comm_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles comm.DoWork
        comandar()
    End Sub

    Private Sub comm_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles comm.ProgressChanged
        cargarConsumos()
    End Sub
End Class



