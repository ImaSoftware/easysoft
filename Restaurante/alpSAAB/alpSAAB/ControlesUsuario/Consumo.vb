Public Class Consumo
    Public Event check_Cons As EventHandler
    Friend absID As Integer
    Sub New(ByVal Id As Integer, ByVal Cant As Integer, ByVal NomProd As String, _comm As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.absID = Id
        lblNomProd.Text = NomProd
        lblCant.Text = Cant.ToString
        comm.Text = _comm

    End Sub

    Private Sub chkCons_CheckedChanged(sender As Object, e As EventArgs) Handles chkCons.CheckedChanged
        If chkCons.Checked Then
            chkCons.Enabled = False
            Me.BackColor = Color.LightGray
            Dim sql As String = String.Format("Update SD_CuentasDetalle Set Estado = Estado + 1 where Id = {0}", Me.absID)
            EjecutarConsulta(sql)
            oncheck_Cons(Me, e)
        End If
    End Sub
    Protected Overridable Sub oncheck_Cons(sender As Object, e As EventArgs)

        RaiseEvent check_Cons(sender, e)
    End Sub

    Private Sub Consumo_Load(sender As Object, e As EventArgs) Handles Me.Load
        If String.IsNullOrEmpty(comm.Text.Trim) Then
            'transformar
            Me.TableLayoutPanel1.Controls.Remove(comm)
            TableLayoutPanel1.RowStyles.Item(1).Height = 0
            Me.Height = Me.Height / 2
        End If
    End Sub
End Class
