Public Class Orden
    Public IDCabeceraComanda As Integer = 0
    Public excedeLimites As Boolean = False
    Dim noCol As Integer = 1
    Dim noCocina As Integer = -1
    Public mostrar As Boolean = True
    Public maxSize As Integer = 0
    Dim consumos As List(Of Consumo) = New List(Of Consumo)
    Public Event click_Ok As EventHandler
    Sub New(ByVal cmdId As Integer, innerHeight As Integer, ByVal noC As Integer)
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        IDCabeceraComanda = cmdId
        Me.Height = innerHeight
        Me.maxSize = Me.Height
        Me.lblOrden.Text = "Orden #" + cmdId.ToString
        Me.noCocina = noC
        Me.CheckForIllegalCrossThreadCalls = False
        representar()
    End Sub
    Public Sub representar()
        noCol = 1
        'consumos = New List(Of Consumo)
        'pnlCons.Controls.Clear()
        Dim sql As String = "SELECT SD_Comandas_Detalle.idConsumo, SD_Comandas_Detalle.NombreProducto, SD_Comandas_Detalle.Cantidad,SD_Comandas_Detalle.Comentario "
        sql = sql + " From SD_CuentasDetalle INNER JOIN "
        sql = sql + " SD_Consumos_Estados On SD_CuentasDetalle.Estado = SD_Consumos_Estados.Id "
        sql = sql + " inner Join SD_Comandas_Detalle On SD_CuentasDetalle.Id=SD_Comandas_Detalle.idConsumo "
        sql = sql + " WHERE (SD_Comandas_Detalle.idCocina={1}) and (SD_Comandas_Detalle.idComanda = {0}) And (SD_Consumos_Estados.Facturable = 0) And (SD_Consumos_Estados.produciendo = 1) "
        sql = sql + " And (SD_CuentasDetalle.IdCabecera In (Select  SD_CuentasCabecera.Id As Cuenta  FROM  "
        sql = sql + " SD_Cuentas_Mesas INNER JOIN  SD_Mesas On SD_Cuentas_Mesas.IdMesa = SD_Mesas.Id "
        sql = sql + " INNER Join  SD_CuentasCabecera On SD_Cuentas_Mesas.IdCuenta = SD_CuentasCabecera.id "
        sql = sql + " WHERE(SD_CuentasCabecera.estado = 'A')))" 'Consulta basada en SDSP_CompruebaDespacho
        sql = String.Format(sql, IDCabeceraComanda.ToString.Trim, Me.noCocina)
        Dim dttCons As DataTable = cargarConsulta(sql)
        Dim insPoint As System.Drawing.Point = New System.Drawing.Point(0, 0)
        For Each ConsRow As DataRow In dttCons.Rows
            Dim c_pr As Consumo = buscaCons(ConsRow("idConsumo"))
            If Not IsNothing(c_pr) Then Continue For 'Si ya Existe pasa cantando 
            'Existe en la lista?
            Dim ctlCons As New Consumo(ConsRow("idConsumo"), ConsRow("Cantidad"), ConsRow("NombreProducto"), ConsRow("Comentario"))
            AddHandler ctlCons.check_Cons, AddressOf Me.uncheckCambió
            ctlCons.Location = insPoint
            pnlCons.Controls.Add(ctlCons)
            If noCol = 1 And insPoint.X = 0 And insPoint.Y = 0 Then
                'solo el primer elemento 
                Me.Width = ctlCons.Width
            End If
            If (insPoint.Y + ctlCons.Height) > pnlCons.Height Then
                'Avanzar en Columna y aumentar el ancho
                noCol = noCol + 1
                Me.Width = insPoint.X + (2 * ctlCons.Width)
                insPoint = New System.Drawing.Point((noCol - 1) * ctlCons.Width, 0)
            End If
            ctlCons.Location = insPoint
            consumos.Add(ctlCons)
            'Recorro el punto
            insPoint = New System.Drawing.Point(insPoint.X, insPoint.Y + ctlCons.Height)
        Next
        'Buscar si los que estan en la lista siguen existiendo en el resultado de la consulta. Si no 
        'Matarlo
        Dim _brr As New List(Of Consumo)
        If dttCons.Rows.Count > 0 Then
            For Each cons As Consumo In consumos
                Dim expression As String = String.Format("idConsumo = '{0}'", cons.absID)
                Dim foundRows As DataRow()
                foundRows = dttCons.Select(expression)
                If foundRows.Count = 0 Then
                    _brr.Add(cons)
                End If
            Next
        End If
        For Each cons As Consumo In _brr
            consumos.Remove(cons)
            pnlCons.Controls.Remove(cons)
        Next
        'Ajustar alto
        ajustarAlto()

    End Sub
    Function buscaCons(_id As Integer) As Consumo
        For Each cons As Consumo In consumos
            If cons.absID = _id Then
                Return cons
            End If
        Next
        Return Nothing
    End Function
    Public Sub ajustarAlto()
        Me.reordenar()
        Dim consum As Consumo = Nothing
        Dim consMasBajo As Integer = 0
        For Each cons In consumos
            If cons.Location.Y >= consMasBajo Then
                consMasBajo = cons.Location.Y
                consum = cons
            End If
        Next
        If Not consumos.Count = 0 Then 'consum viene en nothing 
            Dim xvar1 As Integer = pnlCons.Location.Y + consum.Location.Y + 1.5 * consum.Height + pnlListo.Height
            pnlCons.Height = consum.Location.Y + 1.5 * consum.Height
            If Math.Abs(Me.Height - xvar1) > 5 Then
                Me.Height = xvar1
            End If
        Else
            Me.btnOK.PerformClick()
        End If

    End Sub
    Sub uncheckCambió(sender As Object, e As EventArgs)
        If Not chkOrden.Checked Then
            chkOrden.Checked = BuscarTodosChecked()
        End If

    End Sub
    Function BuscarTodosChecked() As Boolean
        For Each consumo In consumos
            If Not consumo.chkCons.Checked Then
                Return False
            End If
        Next
        Return True
    End Function
    Public Sub reordenar()
        If consumos.Count = 0 Then Return
        Dim pnlConsH As Integer = Me.maxSize - Me.lblOrden.Height - Me.pnlListo.Height

        Me.Width = consumos.ElementAt(0).Width
        noCol = 1
        Dim _borr As New List(Of Consumo)
        Dim insPoint As System.Drawing.Point = New System.Drawing.Point(0, 0)
        For Each ctlCons As Consumo In consumos
            If ctlCons.chkCons.Checked Then
                _borr.Add(ctlCons)
                Continue For
            End If
            ctlCons.Location = insPoint
            'pnlCons.Controls.Add(ctlCons)
            If (insPoint.Y + ctlCons.Height) > pnlConsH Then
                'Avanzar en Columna y aumentar el ancho
                noCol = noCol + 1
                Me.Width = insPoint.X + (2 * ctlCons.Width)
                insPoint = New System.Drawing.Point((noCol - 1) * ctlCons.Width, 0)
            End If
            If Not insPoint.Equals(ctlCons.Location) Then
                ctlCons.Location = insPoint
            End If
            'Recorro el punto
            insPoint = New System.Drawing.Point(insPoint.X, insPoint.Y + ctlCons.Height)
        Next
        For Each b As Consumo In _borr
            consumos.Remove(b)
            pnlCons.Controls.Remove(b)
        Next
        If _borr.Count > 0 Then
            ajustarAlto()
        End If
        _borr.Clear()
    End Sub
    Private Sub chkOrden_CheckedChanged(sender As Object, e As EventArgs) Handles chkOrden.CheckedChanged
        If chkOrden.Checked Then
            chkOrden.Enabled = False
        End If
        checkTodas()
        pnlListo.Visible = chkOrden.Checked
    End Sub
    Private Sub checkTodas()
        'Hacer check en todos los objetos 
        For Each cons As Consumo In consumos
            cons.chkCons.Checked = True
        Next

    End Sub

    Private Sub Orden_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Protected Overridable Sub onclick_OK(sender As Object, e As EventArgs)
        RaiseEvent click_Ok(sender, e)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        onclick_OK(Me, e)
    End Sub
End Class
