Public Class ModificaData
    Enum estadosMD
        editando
        Guardado
    End Enum
    Enum TipoModificacion
        EsquemaMesa

    End Enum

    Dim want As Integer = 0
    Dim hant As Integer = 0
    Dim Modificado As Boolean = False
    Dim Estado As estadosMD
    Dim i_edit As Integer = 0
    Dim consultaSQL As String
    Dim StoredP As String
    Dim TabladeDatos As DataTable
    Dim loading As Boolean = False
    Dim Ocultar As New List(Of Integer)
    Dim idMD As Integer
    Dim t_mod As TipoModificacion = Nothing
    Const Margen As Integer = 5
    Sub New(ByVal id As Integer, ByVal Parameters() As Object)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        idMD = id
        Dim sql As String = String.Format("Select * from SD_ModificaData where id = {0}", id)
        Dim dttTemp As DataTable = cargarConsulta(sql)
        If Not IsNothing(dttTemp) Then
            If dttTemp.Rows.Count = 0 Then
                MsgBox("El ID especificado no existe. ID = " & id, MsgBoxStyle.Information, "Un momento!!!")
                Me.Hide()
            ElseIf dttTemp.Rows.Count > 1 Then
                MsgBox("ID repetido. varios resultados para id " & id, MsgBoxStyle.Exclamation, "Ops Categoria 5")
                Me.Hide()
            ElseIf dttTemp.Rows.Count = 1 Then
                'caso correcto Avanzar en la carga
                If Not IsNothing(Parameters) Then
                    consultaSQL = String.Format(DataC(dttTemp(0)("Consulta")).ToString, Parameters)
                Else
                    consultaSQL = DataC(dttTemp(0)("Consulta")).ToString
                End If

                StoredP = DataC(dttTemp(0)("StoredProcedure")).ToString
                If DataC(dttTemp(0)("Ocultar")) <> "" Then
                    Dim x() As String = DataC(dttTemp(0)("Ocultar")).Split(",")
                    For Each columna In x
                        Ocultar.Add(CInt(Trim(columna)))
                    Next
                End If
                If DataC(dttTemp(0)("Modificado")) <> "" Then
                    Me.Modificado = True
                    Try
                        t_mod = Numero(DataC(dttTemp(0)("Modificado")))
                    Catch ex As Exception
                        t_mod = Nothing
                    End Try
                End If
                End If
        Else
            MsgBox("Consulta Fallida SD_ModificaData, id = " & id, MsgBoxStyle.Critical, "Opps Categoria 2")
            End
        End If
    End Sub
    Sub Inicializar(Optional primera As Boolean = False)
        Me.SuspendLayout()
        cargarGridTouch()
        Me.ResumeLayout(False)
        CargarPanelControles()
        Me.ResumeLayout(false)
        If primera Then
            Estado = estadosMD.Guardado
        End If
        EncerarxEstado()
        i_edit = 0
        Modificar()
        CargarValores()
    End Sub
    Sub Modificar()
        If Not Modificado Then Exit Sub
        Select Case t_mod
            Case TipoModificacion.EsquemaMesa
                TableLayoutPanel1.SetColumnSpan(gtData, 3)
                Me.TableLayoutPanel1.Controls.Add(Minsector, 3, 0)
                Minsector.EsEsquema = True : Minsector.EsMiniatura = True
                cargarMiniatura(gtData.GridDeDatos.Rows(i_edit).DataBoundItem.row("IdSector"))
            Case Nothing
                Exit Sub
        End Select
    End Sub
    Sub CargarValores()
        Me.Cursor = Cursors.WaitCursor
        gtData.Seleccionar(i_edit)
        Dim datar As DataRow = gtData.elementoSeleccionado.DataBoundItem.row
        For Each ctl As CtlMod_Data In PanelControles.Controls
            ctl.CargarValor(datar(ctl.DataId))
        Next
        seleccionarMesa(gtData.elementoSeleccionado.DataBoundItem.row)
        Me.Cursor = Cursors.Default
    End Sub
    Sub CargarValores(ByVal argelemento As DataGridViewRow)
        Me.Cursor = Cursors.WaitCursor
        Dim datar As DataRow = argelemento.DataBoundItem.row
        For Each ctl As CtlMod_Data In PanelControles.Controls
            ctl.CargarValor(datar(ctl.DataId))
        Next
        seleccionarMesa(argelemento.DataBoundItem.row)
        Me.Cursor = Cursors.Default
    End Sub
    Sub EncerarxEstado()
        Select Case Estado
            Case estadosMD.editando
                PanelControles.Enabled = True
                cmdGrabar.Enabled = True
                gtData.Enabled = False
            Case estadosMD.Guardado
                PanelControles.Enabled = False
                cmdGrabar.Enabled = False
                gtData.Enabled = True
        End Select
    End Sub
    Sub cargarGridTouch(Optional sPrimero As Boolean = True)
        TabladeDatos = cargarConsulta(consultaSQL)
        gtData.cargarTabla(TabladeDatos, sPrimero)
        For Each xNum In Ocultar
            gtData.GridDeDatos.Columns(xNum).Visible = False
        Next
    End Sub
    Sub CargarPanelControles()
        Me.ResumeLayout(False)
        Dim sql As String = String.Format("Select * from SD_ModificaData_Controles where IdModificaData = {0}", idMD)
        Dim dtt As DataTable = cargarConsulta(sql)
        If Not IsNothing(dtt) Then
            If dtt.Rows.Count = 0 Then
                MsgBox("No se han encontrado controles para agregar", MsgBoxStyle.Information, "Un momento !!!")
                Exit Sub
            ElseIf dtt.Rows.Count > 0 Then
                'caso correcto seguir
            End If
        Else
            MsgBox("Error al cargar consulta de controles. ID = " & idMD, MsgBoxStyle.Critical, "Opps cat 3")
            End
        End If
        Dim a
        a = PanelControles.Size.Width
        PanelControles.PerformLayout()
        PanelControles.Update()
        PanelControles.Show()
        PanelControles.Refresh()

        a = PanelControles.Size.Width
        Dim i As Integer = 0
        Dim ctlAnt As CtlMod_Data = Nothing
        Dim puntoAgregar As New Point(Margen, Margen)
        For Each dttCvb As DataRow In dtt.Rows
            Dim ctl As New CtlMod_Data(DataC(dttCvb("DataId")), TabladeDatos.Columns(dttCvb("DataId")).ColumnName, dttCvb("BoundedName"), dttCvb("ControlName") _
                                       , DataC(dttCvb("param1")), DataC(dttCvb("param2")), DataC(dttCvb("param3")), DataC(dttCvb("validar")))

            ctl.CargarCTl()
            ctl.PerformAutoScale()
            If i <> 0 Then
                Dim ptoTenta As New Point(ctlAnt.Right + Margen, puntoAgregar.Y)
                'probar si cabe en ancho
                If ptoTenta.X + ctl.Size.Width > PanelControles.Size.Width Then
                    'bajar a la sgte linea
                    puntoAgregar = New Point(Margen, ctlAnt.Bottom + Margen)
                Else
                    'agregar en la misma linea
                    puntoAgregar = ptoTenta
                End If
            End If
            ctl.Location = puntoAgregar
            ctlAnt = ctl
            PanelControles.Controls.Add(ctl)
            i = i + 1
        Next
    End Sub

    Private Sub gtData_CambioSeleccion(argelementoSeleccionado As DataGridViewRow) Handles gtData.CambioSeleccion
        If Estado = estadosMD.editando Then Exit Sub
        CargarValores(argelementoSeleccionado)
        i_edit = gtData.indiceSelect
       
    End Sub
    Sub seleccionarMesa(ByVal argdr As DataRow)
        If Not Modificado Then Exit Sub
        If t_mod <> TipoModificacion.EsquemaMesa Then Exit Sub
        'estamos seguros que es ventana de mesa asi que esperemos que no entre si es diferente
        If IsNothing(Minsector) Then Exit Sub
        'si ya no es el sector de la miniatura recargar miniatura
        If argdr("IdSector") <> Minsector.Id Then
            cargarMiniatura(argdr("IdSector"))
        End If
        Minsector.resaltarMesa(argdr("ID"))
    End Sub
    Sub cargarMiniatura(ByVal argIdArea As Integer)
        Minsector.EsEsquema = True : Minsector.EsMiniatura = True
        Minsector.cargarEsquema(argIdArea)
        Minsector.Refresh()
        want = Minsector.PanelArea.PreferredSize.Width
        hant = Minsector.PanelArea.PreferredSize.Height

        'Minsector.cargarTodo(argIdArea)
        escalar()
        '  want = Minsector.PanelArea.Region.GetBounds(Me.CreateGraphics).Width
        ' hant = Minsector.PanelArea.Region.GetBounds(Me.CreateGraphics).Height
    End Sub

    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        If Estado = estadosMD.editando Then
            Estado = estadosMD.Guardado
            For Each ctl As CtlMod_Data In PanelControles.Controls
                ctl.cleanErrProv()
            Next
            CargarValores()
        Else
            i_edit = gtData.indiceSelect
            Estado = estadosMD.editando
        End If
        CambiarBotonEdit()
        EncerarxEstado()
    End Sub

    Private Sub cmdGrabar_Click(sender As Object, e As EventArgs) Handles cmdGrabar.Click
        If Estado = estadosMD.Guardado Then Exit Sub
        If Not validar() Then Exit Sub
        Estado = estadosMD.Guardado
        Me.Cursor = Cursors.WaitCursor
        EncerarxEstado()
        CambiarBotonEdit()
        GuardarData()
        Dim tmpElemento As Integer = CInt(gtData.elementoSeleccionado.DataBoundItem.row(0))
        suspenderLayout(Me)
        Dim ordenada As Boolean = Not IsNothing(gtData.GridDeDatos.SortedColumn)
        Dim so As Windows.Forms.SortOrder = SortOrder.None
        Dim sc As String = ""
        If ordenada Then
            so = gtData.GridDeDatos.SortOrder : sc = gtData.GridDeDatos.SortedColumn.Name
        End If
        gtData.loading = True
        cargarGridTouch(False) 'RecargarValoresNuevos

        If ordenada Then
            gtData.GridDeDatos.Sort(gtData.GridDeDatos.Columns(sc), IIf(so = SortOrder.Ascending, System.ComponentModel.ListSortDirection.Ascending, System.ComponentModel.ListSortDirection.Descending)) 'volver a ordenar
        End If
        i_edit = BuscaPos(gtData.GridDeDatos, tmpElemento, TabladeDatos.Columns(0).ColumnName)
        CargarValores()
        gtData.Seleccionar(i_edit)
        If Modificado Then
            If t_mod = TipoModificacion.EsquemaMesa Then
                cargarMiniatura(gtData.elementoSeleccionado.DataBoundItem.row("IdSector"))
                seleccionarMesa(gtData.elementoSeleccionado.DataBoundItem.row)
                escalar()
            End If
        End If

        resumirLayout(Me)
        gtData.loading = False
        Me.Cursor = Cursors.Default
    End Sub
    Sub CambiarBotonEdit()
        If Estado = estadosMD.Guardado Then
            cmdEdit.Text = "&Editar"
            cmdEdit.ImageIndex = 7

        ElseIf Estado = estadosMD.editando Then
            cmdEdit.Text = "&Cancelar"
            cmdEdit.ImageIndex = 1
        End If

    End Sub
    Function validar() As Boolean
        'Validar que lo que se intenta guardar tenga sentido
        For Each ctl As CtlMod_Data In PanelControles.Controls
            If Not ctl.Validar(gtData.elementoSeleccionado.DataBoundItem.row(0)) Then
                'Primera fila tiene el id absoluto
                Return False
            End If
        Next
        Return True
    End Function

    Sub GuardarData()

        Dim parametritos As New List(Of Parametro)
        For Each ctl As CtlMod_Data In PanelControles.Controls
            parametritos.Add(New Parametro(ctl.BoundedName, ctl.GetValor))
        Next
        'Por ahora coge la primera columna de la tabla
        parametritos.Add(New Parametro(TabladeDatos.Columns(0).ColumnName, gtData.elementoSeleccionado.DataBoundItem.row(0)))
        Try
            EjecutarSP(StoredP, parametritos)
        Catch ex As Exception
            MsgBox("Error al modificar los datos", MsgBoxStyle.Exclamation, "Opps categoria 3")
        End Try
    End Sub

    Overloads Sub loader()
        Me.Visible = True
    End Sub

    Private Sub ModificaData_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        escalar()
    End Sub
  
    Sub escalar()
        Dim fSize As New SizeF((Minsector.Width / want), _
                                         (Minsector.Height / hant))
        Minsector.escalarMiniatura(fSize)
        Minsector.PanelArea.Width = Minsector.Width
        Minsector.PanelArea.Height = Minsector.Height
        want = Minsector.Width
        hant = Minsector.Height
    End Sub
    Private Sub Minsector_ClicMesaEsquema(argMesa As Mesa) Handles Minsector.ClicMesaEsquema
        If Estado = estadosMD.editando Then Exit Sub
        gtData.Seleccionar(BuscaPos(gtData.GridDeDatos, argMesa.IdMesa, "Id"))
        CargarValores(gtData.elementoSeleccionado)
        seleccionarMesa(gtData.elementoSeleccionado.DataBoundItem.row)
    End Sub
End Class

