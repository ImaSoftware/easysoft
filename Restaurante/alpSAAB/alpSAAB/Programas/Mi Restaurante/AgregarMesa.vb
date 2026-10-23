Public Class AgregarMesa
    Public ListaMesas As String = ""
    Public ListaCuentasAñadir As New List(Of ParCuentaMesa)
    Class ParCuentaMesa
        Public cuenta As String
        Public mesa As String
        Sub New(argcuenta, argmesa)
            cuenta = argcuenta : mesa = argmesa
        End Sub

    End Class
    Private Sub cmdGrabar_Click(sender As Object, e As EventArgs) Handles cmdGrabar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Sub CargarTodo(ByVal arglistamesas As String)
        ListaMesas = arglistamesas
        cargarMesas(arglistamesas)
        Dim sqlMesasDisp As String = "SELECT  SD_Mesas.Id, SD_Mesas.NumAlias, SD_Mesas.Alias " _
                                     & " FROM       SD_Mesas LEFT OUTER JOIN " _
                                     & " SD_Cuentas_Mesas ON SD_Mesas.Id = SD_Cuentas_Mesas.IdMesa left outer JOIN " _
                                     & " SD_CuentasCabecera ON " _
                                     & " SD_Cuentas_Mesas.IdCuenta = SD_CuentasCabecera.id " _
                                     & " wHERE    (SD_Mesas.EsMesa = 1) AND ((SD_CuentasCabecera.estado NOT IN ('A', 'O'))  " _
                                     & " or (SD_CuentasCabecera.ESTADO IS NULL))            " _
                                     & " ORDER BY SD_Mesas.NumAlias "

        Dim sqlMesasOcupadas As String = "SELECT id, 'Cuenta ' + CAST(alias AS varchar) AS Cuenta, Mesas" _
                                        & " FROM SD_CuentasCabecera " _
                                        & " WHERE        (estado = 'A')"
        Dim dttdisp As DataTable = cargarConsulta(sqlMesasDisp)
        Dim dttOcupada As DataTable = cargarConsulta(sqlMesasOcupadas)
        If Not IsNothing(dttdisp) Then
            gridDisponibles.cargarTabla(dttdisp)
            gridDisponibles.GridDeDatos.Columns(0).Visible = False
            gridDisponibles.GridDeDatos.Columns(1).Visible = False
        End If
        If Not IsNothing(dttOcupada) Then
            gridOcupadas.cargarTabla(dttOcupada)
            gridOcupadas.GridDeDatos.Columns(0).Visible = False
        End If
    End Sub

    Private Sub Ventana_Paint(sender As Object, e As PaintEventArgs) Handles Ventana.Paint

    End Sub
    Sub cargarMesas(ByVal argmesas As String)
        ListaMesas = argmesas
        PanelMesas.Controls.Clear()
        Dim tablaMesas As New DataTable
        tablaMesas.Columns.Add("IdMesa")
        Dim x() As String = argmesas.Split(",")
        For Each idMesa As String In x
            tablaMesas.Rows.Add(idMesa)
        Next
        For Each y As String In x

            Dim botonx As New Button
            botonx.Tag = y
            botonx.Text = GetCampo(y, "SD_Mesas", "Alias")
            botonx.BackColor = Color.FromArgb(100, 255, 192, 128)
            botonx.Dock = DockStyle.Top
            PanelMesas.Controls.Add(botonx)
            AddHandler botonx.Click, AddressOf clickbotonmesa
            botonx.AutoSize = True
        Next
    End Sub
    Sub clickbotonmesa(ByVal boton As Button, e As EventArgs)
        Dim listadelete As New List(Of ParCuentaMesa)
        If PanelMesas.Controls.Count > 1 Then
            If ListaCuentasAñadir.Count > 0 Then 'comprueba las cuentas
                For Each parCtaMsa As ParCuentaMesa In ListaCuentasAñadir
                    If parCtaMsa.mesa = boton.Tag Then
                        If MsgBox("Si elimina este item no añadirá los consumos de la cuenta asociada. ¿Desea continuar?", MsgBoxStyle.YesNo, "Confirmacion") = MsgBoxResult.Yes Then
                            PanelMesas.Controls.Remove(boton)
                            listadelete.Add(parCtaMsa)
                        End If
                    End If
                Next
                If listadelete.Count > 0 Then
                    For Each elemento In listadelete
                        ListaCuentasAñadir.Remove(elemento)
                    Next
                End If
            Else 'No hay que comprobar. Directo
                If MsgBox("El item se removera de la lista. ¿Desea continuar?", MsgBoxStyle.YesNo, "Confirmacion") = MsgBoxResult.Yes Then
                    PanelMesas.Controls.Remove(boton)
                End If
            End If
          
        Else
            MsgBox("No puede quitar todas las mesas de la cuenta", MsgBoxStyle.Exclamation, "Un Momento!!!")
        End If
        cargarLista()
    End Sub

    Private Sub gridDisponibles_DobleClickGrid(sender As GridTouch) Handles gridDisponibles.DobleClickGrid
        'griddisponibles. Mesas sin cuenta abierta. añadir a la lista de mesas que se retorna
        Dim idNuevaMesadisp As Integer = sender.elementoSeleccionado.DataBoundItem.row("id")
        Dim x() = ListaMesas.Split(",")
        For Each y In x
            If Trim(y) = Trim(idNuevaMesadisp) Then
                'ya existe no hacer nada
                Exit Sub
            End If
        Next
        'si llegó ak no existe
        If x.Length > 0 Then
            ListaMesas = ListaMesas & "," & idNuevaMesadisp 'añadido
        Else
            ListaMesas = idNuevaMesadisp ' no creo que jamas llegue ak
            MsgBox("Mira tu. estaba equivocado....")
            End
        End If
        cargarMesas(ListaMesas)
    End Sub
    Sub cargarLista()
        Dim lstMesas As String = ""
        Dim i = 0
        For Each boton As Button In PanelMesas.Controls
            If i = 0 Then
                lstMesas = boton.Tag
            Else
                lstMesas = lstMesas & ", " & boton.Tag
            End If
            i += 1
        Next
        Me.ListaMesas = lstMesas
    End Sub
    Private Sub gridOcupadas_DobleClickGrid(sender As GridTouch) Handles gridOcupadas.DobleClickGrid
        'gridOcupadas. Mesas con cuenta abierta. añadir a la lista de mesas que se retorna
        'advertir sobre consumos
        Dim idCuenta As Integer = sender.elementoSeleccionado.DataBoundItem.row("id")
        If MsgBox("Se añadiran las mesas asociadas y sus respectivos consumos. ¿Desea continuar?", MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
            Dim sqlmesas As String = String.Format("Select IdMesa from SD_Cuentas_Mesas where IdCuenta = {0}", idCuenta)
            Dim dttmesas As DataTable = cargarConsulta(sqlmesas)
            If Not IsNothing(dttmesas) Then
                For Each Mesa In dttmesas.Rows
                    'buscar en la listamesas
                    Dim Encontrado As Boolean = False
                    Dim x() = ListaMesas.Split(",")
                    For Each y In x
                        If CStr(Trim(y)) = CStr(Trim(Mesa("IdMesa"))) Then
                            'ya existe no hacer nada
                            encontrado = True
                        End If
                    Next
                    'sino se la encontró agregarla
                    If Not Encontrado Then
                        If x.Length > 0 Then
                            ListaMesas = ListaMesas & "," & Mesa("IdMesa") 'añadido
                            ListaCuentasAñadir.Add(New ParCuentaMesa(idCuenta, Mesa("IdMesa")))
                        End If
                    End If
                Next
            Else
                MsgBox("Error SQL")
            End If
        End If
        cargarMesas(ListaMesas)
    End Sub

End Class