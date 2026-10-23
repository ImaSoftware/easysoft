Public Class MenuEstados

    Public TipoMenu As TipoMenuEstado
    Public CampoTexto As String = ""
    Public CampoValor As String = ""
    Public nElementos As Integer = 0
    Private Elementos As List(Of Button)
    Public Resultado As String
    Public Event res(ByVal sender As MenuEstados)
    Dim cerrando As Boolean = False
    Dim desdeCocina As Boolean = False
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub New(ByVal argTxt As String, ByVal argValor As String, ByVal argtipo As TipoMenuEstado, Optional _dC As Boolean = False)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        CampoTexto = argTxt
        CampoValor = argValor
        TipoMenu = argtipo
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        desdeCocina = _dC
    End Sub

    Private Sub MenuEstados_Activated(sender As Object, e As EventArgs) Handles Me.Activated
    End Sub
    Private Sub MenuEstados_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        If cerrando Then Exit Sub
        Me.Close()
    End Sub

    Private Sub MenuEstados_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        cerrando = True
        RaiseEvent res(Me)
    End Sub

    Private Sub MenuEstados_Leave(sender As Object, e As EventArgs) Handles Me.Leave
    End Sub
    Private Sub MenuSecundario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   CargarElementos()
    End Sub
    Sub CargarElementos(Optional NoConfirmado As Boolean = False)
        Me.DialogResult = 0
        Dim a As DataTable = cargarConsulta("Select * from SD_Consumos_Estados " & IIf(desdeCocina, "", " where soloCocina= 0"))
        If NoConfirmado Then
            a = New DataTable
            a.Columns.Add("Descripcion")
            a.Columns.Add("Id")
            a.Rows.Add("Suprimir", 1)
            a.Rows.Add("Modificar", 2)
        End If
        For Each elemento As DataRow In a.Rows
            Dim b As New Button
            b.Text = elemento(CampoTexto)
            b.Tag = elemento(CampoValor)
            b.Height = 36
            If Not NoConfirmado Then
                Dim lista As New ImageList
                lista.ImageSize = New Size(24, 24)
                lista.Images.Add(Image.FromFile(Application.StartupPath & "\BMPs\" & elemento("path")))
                b.Image = lista.Images(0)
                b.ImageAlign = ContentAlignment.MiddleCenter
                b.TextImageRelation = TextImageRelation.TextBeforeImage
            End If
            b.TextAlign = ContentAlignment.MiddleCenter
            b.Dock = DockStyle.Bottom
            b.AutoSize = True
            b.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowOnly
            AddHandler b.Click, AddressOf clickBoton
            Me.Controls.Add(b)
            nElementos += 1
        Next
        Me.PerformAutoScale()
    End Sub
    Sub clickBoton(ByVal sender As Button, ByVal e As EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Tag = sender.Tag
        Me.Resultado = sender.Text
        Me.Close()
    End Sub
End Class
Public Enum TipoMenuEstado
    Comandado
    NoComandado
    OptForms
End Enum