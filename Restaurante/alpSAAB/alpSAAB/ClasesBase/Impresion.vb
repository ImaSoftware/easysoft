Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms

Public Class Impresion
    Implements IDisposable
    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)
    Private nombreImpresora As String = ""
    Property copias As Integer

    ' Routine to provide to the report renderer, in order to
    ' save an image for each page of the report.
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function

    ' Export the given report as an EMF (Enhanced Metafile) file.
    Private Sub Export(ByVal report As LocalReport)
        Dim nameCnf As String = AppDomain.CurrentDomain.BaseDirectory & Path.GetFileNameWithoutExtension(report.ReportPath) & ".cnf"
        Dim deviceInfo As String = If(File.Exists(nameCnf), File.ReadAllText(nameCnf), "<DeviceInfo><OutputFormat>EMF</OutputFormat></DeviceInfo>")
        Dim warnings As Warning() = {}
        Dispose()
        m_streams = New List(Of Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
            For Each stream As Stream In m_streams
                stream.Position = 0
            Next
    End Sub

    ' Handler for PrintPageEvents
    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Using pageImage As New Metafile(m_streams(m_currentPageIndex))
            Dim destination As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX), ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY), ev.PageBounds.Width, ev.PageBounds.Height)
            ev.Graphics.FillRectangle(Brushes.White, destination)
            ev.Graphics.DrawImage(pageImage, destination)
        End Using
        m_currentPageIndex += 1
        ev.HasMorePages = m_currentPageIndex < m_streams.Count
    End Sub

    Private Sub Print()
        If m_streams Is Nothing OrElse m_streams.Count = 0 Then Throw New InvalidOperationException("El reporte no contiene páginas.")
        Using document As New PrintDocument()
            If Not String.IsNullOrWhiteSpace(nombreImpresora) Then document.PrinterSettings.PrinterName = nombreImpresora
            If Not document.PrinterSettings.IsValid Then Throw New InvalidOperationException("No se encontró la impresora configurada.")
            AddHandler document.PrintPage, AddressOf PrintPage
            m_currentPageIndex = 0
            document.Print()
        End Using
    End Sub

    ' Create a local report for Report.rdlc, load the data,
    ' export the report to an .emf file, and print it.
    Private Sub Run(ByVal rp As LocalReport)
        If copias < 1 Then copias = 1
        For i = 1 To copias
            Export(rp)
            Print()
        Next


    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If m_streams IsNot Nothing Then
            For Each stream As Stream In m_streams
                stream.Close()
            Next
            m_streams = Nothing
        End If
    End Sub

    Public Shared Function Imprimir(ByRef rp As LocalReport, ByVal impresora As String, Optional ByVal _copias As Integer = 0) As String
        If String.IsNullOrWhiteSpace(impresora) Then Throw New InvalidOperationException("Configure una impresora para este documento.")
        Dim directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "SAAB", "Documentos")
        System.IO.Directory.CreateDirectory(directory)
        Dim fileName = Path.Combine(directory, Guid.NewGuid().ToString("N") & ".pdf")
        Dim bytes = rp.Render("PDF")
        File.WriteAllBytes(fileName, bytes)
        Using printer As New Impresion()
            printer.copias = _copias
            printer.nombreImpresora = impresora
            printer.Run(rp)
        End Using
        Return fileName
    End Function
End Class

