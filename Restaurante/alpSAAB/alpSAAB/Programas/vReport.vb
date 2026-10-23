Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Reporting.WinForms

Public Class vReport
    Public Shared Sub PrintComanda(ByVal documentId As Integer)
        FUGSD.imprimeComanda(documentId)
    End Sub

    Public Shared Sub PrintPrefactura(ByVal documentId As Integer)
        FUGSD.imprimePrefactura(documentId)
    End Sub
    Dim nameReport As String = ""
    Dim Paramis As New List(Of Parametro)
    Dim id As Integer = 0
    Property copias As Integer = 0
    Public Property DocumentoImpreso As String = ""
    Sub New(ByVal nomRepo As String, Optional ByVal argparam As Object = Nothing, Optional directPrint As Boolean = False,
            Optional nombreImp As String = "", Optional _copias As Integer = 0, Optional _id As Integer = 0)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        nameReport = nomRepo
        copias = _copias
        Paramis = argparam
        id = _id
        If directPrint Then
            soloImprime(nombreImp)
            Me.Close()
        End If
    End Sub
    Private Sub soloImprime(ByVal nombreImpresora As String)
        'cargar DataSource

        Dim repo As New RepoMan(nameReport)
        repo.load()
        Try
            For j = 0 To repo.db.Tables.Count - 1
                If j = 0 Then Continue For
                Dim table As DataTable = repo.db.Tables.Item(j)
                visor.LocalReport.DataSources.Add(New ReportDataSource(table.TableName, table))
            Next
            visor.LocalReport.ReportPath = My.Application.Info.DirectoryPath & "\Reportes\" & nameReport
            Me.visor.ProcessingMode = ProcessingMode.Local
            visor.LocalReport.EnableExternalImages = repo.EnableExternalImages
            Me.visor.RefreshReport()
            'Parametros
            If Not IsNothing(Paramis) Then
                Dim parametr() As ReportParameter = Nothing
                Array.Resize(parametr, Paramis.Count)
                Dim i = 0
                For Each parametrito As Parametro In Paramis
                    parametr(i) = New ReportParameter(parametrito.Nombre, CStr(parametrito.value))
                    i += 1
                Next
                visor.LocalReport.SetParameters(parametr)
            End If
            'MsgBox(nameReport)
            Dim nombreDocu As String = Impresion.Imprimir(visor.LocalReport, nombreImpresora, copias) ' ejecuta la libreria
            DocumentoImpreso = nombreDocu
            If nameReport.Equals("Prefactura.rdlc") Then
                'MsgBox(nombreDocu)
                EjecutarConsulta("Update SD_Prefacturas_Cabecera set documento = @p0 where id = @p1", , , New Object() {nombreDocu, id})
            End If


        Catch ex As Exception
            Throw New InvalidOperationException("No se pudo imprimir el documento.", ex)
        End Try
    End Sub

    Private Sub vReport_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Borrar los temporales
        If Me.nameReport = "qRIden.rdlc" AndAlso Not borraTemp.IsBusy Then borraTemp.RunWorkerAsync()
    End Sub

    Private Sub vReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim repo As New RepoMan(nameReport)
        repo.load()
        Me.visor.SetDisplayMode(DisplayMode.PrintLayout)
        Me.Text = repo.Comentario
        Me.visor.LocalReport.ReportPath = My.Application.Info.DirectoryPath & "\Reportes\" & nameReport
        Me.WindowState = FormWindowState.Maximized
        Me.visor.ProcessingMode = ProcessingMode.Local

        Try
            For j = 0 To repo.db.Tables.Count - 1
                If j = 0 Then Continue For
                Dim table As DataTable = repo.db.Tables.Item(j)
                Me.visor.LocalReport.DataSources.Add(New ReportDataSource(table.TableName, table))
            Next
        Catch ex As Exception
            MsgBox("opps")
        End Try

        visor.LocalReport.EnableExternalImages = repo.EnableExternalImages
        If Not IsNothing(Paramis) Then
            Dim parametr() As ReportParameter = Nothing
            Array.Resize(parametr, Paramis.Count)
            Dim i = 0
            For Each parametrito As Parametro In Paramis
                parametr(i) = New ReportParameter(parametrito.Nombre, CStr(parametrito.value))
                i += 1
            Next
            Try
                visor.LocalReport.SetParameters(parametr)
            Catch ex As Exception
                MsgBox("opps")
            End Try
        End If


        'Me.ReportViewer1.LocalReport.DataSources.Add()
        Me.visor.RefreshReport()

    End Sub

    Private Sub borraTemp_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles borraTemp.DoWork
        If Me.nameReport = "qRIden.rdlc" Then
            Dim pathQR As String = Paramis(0).value
            If String.IsNullOrEmpty(pathQR) Then Exit Sub
            Dim borrado As Boolean = False
            Do While Not borrado
                If File.Exists(pathQR) Then
                    Try
                        File.Delete(pathQR)
                    Catch
                    End Try
                End If
            Loop
        End If
    End Sub
End Class





