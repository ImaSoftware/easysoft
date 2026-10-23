Public Class busqueda
    Public Event ctlReturn(ByVal sender As busqueda, ByVal e As EventArgs)
    Dim tbl_Prin As DataTable
    Public id_Form As String = "xDis"
    Dim colSearch As String = "xCol"
    Dim idCol As String = ""
    Public Resultado As Object

    Dim L_Modo As Boolean = False
    Sub New()
        InitializeComponent()
    End Sub
    Sub New(ByVal idForm As String, ByVal colRet As String)
        InitializeComponent()
        id_Form = idForm
        idCol = colRet
    End Sub

    Private Sub btnMode_Click(sender As Object, e As EventArgs) Handles btnMode.Click
        If Not L_Modo Then
            btnMode.Image = Me.imageList1.Images(0)
        Else
            btnMode.Image = Nothing
        End If
        L_Modo = Not L_Modo
    End Sub
    Protected Overridable Sub OnctlReturn(ByVal e As EventArgs)
        RaiseEvent ctlReturn(Me, e)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If L_Modo Then
            FiltraDtt(0)
        Else
            FiltraDtt(1)
        End If
    End Sub

    Private Sub busqueda_Load(sender As Object, e As EventArgs) Handles Me.Load
        Consultar()
    End Sub

    Private Sub GV_Consulta_KeyDown(sender As Object, e As KeyEventArgs) Handles GV_Consulta.KeyDown, txtSearch.KeyDown

    End Sub
    Private Sub Consultar()
        Dim Dt As DataTable = New DataTable()
        Dim strCommand As String = "Exec BUSQUEDA_SIMPLE @ID_CONSULTA = @p0"
        Dt = cargarConsulta(strCommand, , New Object() {id_Form})
        If IsNothing(Dt) Then
            Return
        End If
        tbl_Prin = Dt
        colSearch = tbl_Prin.Columns(0).ColumnName
        GV_Consulta.AutoGenerateColumns = True
        GV_Consulta.DataSource = tbl_Prin
        GV_Consulta.Refresh()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If L_Modo Then
            FiltraDtt(0)
        Else
            FiltraDtt(1)
        End If
    End Sub
    Private Sub FiltraDtt(ByVal opt As Integer)
        ErrP.SetError(txtSearch, "")
        If opt = 0 Then
            Try
                tbl_Prin.DefaultView.RowFilter = txtSearch.Text
            Catch ex As Exception
                ErrP.SetError(txtSearch, ex.Message)
            End Try
        Else
            Try
                If String.IsNullOrEmpty(txtSearch.Text) Then
                    tbl_Prin.DefaultView.RowFilter = ""
                Else
                    If tbl_Prin.Columns(colSearch).DataType = GetType(String) Then
                        tbl_Prin.DefaultView.RowFilter = "[" & colSearch.Replace("]", "\\]") & "] like '%" & txtSearch.Text.Trim().Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]") & "%'"
                    Else
                        tbl_Prin.DefaultView.RowFilter = colSearch & " = " + txtSearch.Text.Trim()
                    End If
                End If
            Catch ex As Exception
                ErrP.SetError(txtSearch, ex.Message)
            End Try
        End If
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave
        If L_Modo Then
            FiltraDtt(0)
        Else
            FiltraDtt(1)
        End If
    End Sub

    Private Sub GV_Consulta_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles GV_Consulta.ColumnHeaderMouseClick
        colSearch = tbl_Prin.Columns(e.ColumnIndex).ColumnName
        If L_Modo Then
            txtSearch.Text = txtSearch.Text + " " + colSearch
        End If
    End Sub

    Private Sub busqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then Retornar(1)
        If e.KeyCode = Keys.Escape Then Retornar(0)
    End Sub
    Private Sub Retornar(ByVal opt As Integer)
        Me.Resultado = Nothing
        Dim activa As DataGridViewCell = GV_Consulta.CurrentCell
        If opt = 1 Then
            If GV_Consulta.Rows.Count > 0 AndAlso activa IsNot Nothing Then
                Me.Resultado = GV_Consulta.Rows(activa.RowIndex).Cells(Me.idCol).Value
            End If
        Else
            Me.Resultado = Nothing
        End If
        OnctlReturn(New EventArgs())
    End Sub

    Private Sub GV_Consulta_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GV_Consulta.CellDoubleClick
        If e.RowIndex = -1 Then Return
        If GV_Consulta.Rows.Count > 0 AndAlso GV_Consulta.CurrentCell IsNot Nothing Then Retornar(1)
    End Sub

    Private Sub GV_Consulta_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GV_Consulta.CellContentDoubleClick

    End Sub
End Class


