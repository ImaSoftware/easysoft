Public Class CmdConfig
    Overloads Sub loader()
        Timerload.Start()
        Dim strC As String = "SELECT    MAX(SD_Comanda_Cabecera.id) AS MaxC FROM       SD_Comanda_Cabecera"
        Dim strP As String = "SELECT MAX(SD_Prefacturas_Cabecera.id) AS MaxP from SD_Prefacturas_Cabecera"
        Dim ca As Integer = Numero(cargarConsulta(strC)(0)("MaxC"))
        Dim cp As Integer = Numero(cargarConsulta(strP)(0)("MaxP"))
        lblc.Text = "Comanda Actual: " & CStr(ca)
        If ca = 0 Then Button1.Enabled = False
        lblp.Text = "Prefactura Actual: " & CStr(cp)
        If cp = 0 Then
            Button2.Enabled = False
        End If
        Me.Visible = True
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dtt As DataTable = cargarConsulta(String.Format("select distinct idCocina from SD_Comandas_Detalle where idComanda = {0} ", NumericUpDown1.Value))
        For i = 0 To dtt.Rows.Count - 1
            Cursor = Cursors.WaitCursor
            Dim lo As New List(Of Parametro)
            lo.Add(New Parametro("IdComanda", NumericUpDown1.Value))
            lo.Add(New Parametro("idCocina", DataC(dtt.Rows(i).Item("idCocina").ToString)))
            Dim b As New vReport("Comanda.rdlc", lo)
            b.Show()
            Cursor = Cursors.Default
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Cursor = Cursors.WaitCursor
        Dim lo As New List(Of Parametro)
        lo.Add(New Parametro("idPrefactura", NumericUpDown2.Value))
        Dim b As New vReport("Prefactura.rdlc", lo)
        b.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub bw_Documentos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw_Documentos.DoWork
        buscaDocumentos()
    End Sub
    Sub buscaDocumentos()

        Dim Documentos As DataTable = cargarConsulta("EXEC SDSP_BuscaDocu")
        If Not IsNothing(Documentos) Then

            For Each Documento As DataRow In Documentos.Rows
                ' MsgBox(Documento.Item("tipo"))
                If Documento.Item("tipo") = "C" Then
                    If Not String.IsNullOrEmpty(DataC(Documento.Item("id"))) Then imprimeComanda(DataC(Documento.Item("id")))
                End If
                If Documento.Item("tipo") = "P" Then
                    If Not String.IsNullOrEmpty(DataC(Documento.Item("id"))) Then imprimePrefactura(DataC(Documento.Item("id")))
                End If

            Next
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timerload.Tick
        '  MsgBox("Tick")
        Try
            bw_Documentos.RunWorkerAsync()
            loader()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
