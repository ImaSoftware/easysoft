Public Class GridTouch
    Public loading As Boolean
    Dim estasinfilas As Boolean = False
    Public indiceSelect As Integer = -1
    Public elementoSeleccionado As DataGridViewRow = Nothing
    Public Event CambioSeleccion(ByVal argelementoSeleccionado As DataGridViewRow)
    Public Event ClickAreaControl(ByVal sender As GridTouch)

    Public Event DobleClickGrid(ByVal sender As GridTouch)

    Sub cargarTabla(ByVal argtabla As DataTable, Optional sPrimero As Boolean = True)
        GridDeDatos.DataSource = Nothing
        loading = True
        If IsNothing(argtabla) Then
            loading = False
            Exit Sub
        End If
        If argtabla.Rows.Count = 0 Then
            estasinfilas = True
        End If
        'grid
        GridDeDatos.DataSource = argtabla
        GridDeDatos.Update()
        If Not estasinfilas Then
            If sPrimero Then
                indiceSelect = 0
                GridDeDatos.Rows(indiceSelect).Selected = True
                elementoSeleccionado = GridDeDatos.SelectedRows(0)
            End If
        End If
        loading = False
    End Sub

    Private Sub Abajo_Click(sender As Object, e As EventArgs) Handles Arriba.Click, Abajo.Click
        If GridDeDatos.Rows.Count = 0 Then Exit Sub
        If sender.name = Arriba.Name Then
            If indiceSelect - 1 >= 0 Then
                indiceSelect -= 1
                GridDeDatos.Rows(indiceSelect).Selected = True
            End If
        ElseIf sender.name = Abajo.Name Then
            If indiceSelect + 1 <= GridDeDatos.Rows.Count - 1 Then
                indiceSelect += 1
                GridDeDatos.Rows(indiceSelect).Selected = True
            End If
        End If
        'encontrar la primera columna visible
        For i = 0 To GridDeDatos.Columns.Count - 1
            If GridDeDatos.Columns(i).Visible Then
                GridDeDatos.CurrentCell = GridDeDatos.Rows(indiceSelect).Cells(i)
                Exit For
            End If
        Next



    End Sub

    Private Sub GridDeDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridDeDatos.CellClick
        elementoSeleccionado = GridDeDatos.SelectedRows(0)
        Me.indiceSelect = elementoSeleccionado.Index
        RaiseEvent ClickAreaControl(Me)
    End Sub

    Private Sub GridDeDatos_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridDeDatos.CellContentDoubleClick
        RaiseEvent DobleClickGrid(Me)
    End Sub

    Private Sub GridTouch_Click(sender As Object, e As EventArgs) Handles Me.Click, GridDeDatos.Click

        RaiseEvent ClickAreaControl(Me)
    End Sub
    Public Sub Seleccionar(ByVal indexS As Integer)
        If GridDeDatos.Rows.Count = 0 Then Exit Sub
        If indexS >= 0 And indexS < GridDeDatos.Rows.Count Then
            GridDeDatos.Rows(indexS).Selected = True
        End If
        'encontrar la primera columna visible
        If indexS = -1 Then Exit Sub
        For i = 0 To GridDeDatos.Columns.Count - 1
            If GridDeDatos.Columns(i).Visible Then
                GridDeDatos.CurrentCell = GridDeDatos.Rows(indexS).Cells(i)
                Exit For
            End If
        Next
        indiceSelect = indexS
        elementoSeleccionado = GridDeDatos.SelectedRows(0)
    End Sub

   

  

    Private Sub GridDeDatos_SelectionChanged(sender As Object, e As EventArgs) Handles GridDeDatos.SelectionChanged
        If loading Then Exit Sub
        If GridDeDatos.SelectedRows.Count > 0 Then
            indiceSelect = GridDeDatos.SelectedRows(0).Index
            elementoSeleccionado = GridDeDatos.SelectedRows(0)
            RaiseEvent CambioSeleccion(elementoSeleccionado)
        End If

    End Sub

  
End Class
