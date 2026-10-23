Imports System.Drawing.Drawing2D

Public Class Principal

    Const margenRibbon As Integer = 10

    Dim ventanas As New List(Of DolphinForm)
    Dim poseInicial As Integer
    Dim panelMIni As Boolean = False
    Dim cerrar As Boolean = False
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        Dim args As String = Command()
        If args = "Mesero" Then
            Parametros.Cargar(1)
            cerrar = True
            Dim programa As New Restaurante
            programa.Dock = DockStyle.Fill
            Dim frm As New DolphinForm
            frm.Name = programa.Name
            frm.Text = programa.Name
            frm.WindowState = FormWindowState.Maximized
            frm.Ventana.Controls.Add(programa)
            ' programa.rectanguloDestino = frm.ClientRectangle
            programa.loader()

            frm.Show()
            programa.ocultades()

            '  programa.DarTamaño()
        ElseIf args = "Cocina" Then
            Parametros.Cargar(1)
            cerrar = True
            Dim programa As New Comandas
            programa.Dock = DockStyle.Fill
            Dim frm As New DolphinForm
            frm.Name = programa.Name
            frm.Text = programa.Name
            frm.WindowState = FormWindowState.Maximized
            frm.Ventana.Controls.Add(programa)
            ' programa.rectanguloDestino = frm.ClientRectangle
            programa.loader()

            frm.Show()


        End If

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles Me.Load

        CargarElementosDePantalla()
        Dibujar()
        poseInicial = SplitContainer1.SplitterDistance
        InicioP()


    End Sub
    Sub InicioP()
        Dim a As New Inicio
        a.loader()
        Dim p As New TabPage
        a.Dock = DockStyle.Fill
        p.Text = "Inicio"
        p.Name = "Inicio"
        p.Controls.Add(a)
        TabContainer.TabPages.Add(p)
    End Sub

    Sub CargarElementosDePantalla()
        If Not Parametros.ParadiseName = "" Then Button1.Text = Parametros.ParadiseName
        cargarRibbon()
    End Sub

    Sub cargarRibbon()
        Dim TablaRibbon As DataTable = cargarConsulta("Select * from SD_MenuOpciones ORDER BY Codigo")
        ' SplitContainer1.Panel1.BackgroundImage = My.Resources.fondo_opt
        If Not String.IsNullOrEmpty(Globales.Parametros.imagenArriba) Then
            SplitContainer1.Panel1.BackgroundImage = Bitmap.FromFile(Globales.Parametros.imagenArriba)
        End If

        For Each elemento As DataRow In TablaRibbon.Rows
            'Determinar que tipo de elemento es. Si boton o menu
            Dim x() As String = Split(elemento("Codigo"), ".")
            If Numero(x(1)) = 0 Then 'Elemento Menu
                Dim z As New DolphinButton
                z.FlatStyle = FlatStyle.Flat
                z.Text = elemento("Texto")
                z.Tag = Numero(x(0))
                Dim maxright As Integer = 0
                For i = 0 To PanelBotones.Controls.Count - 1
                    If PanelBotones.Controls(i).Right > maxright Then
                        maxright = PanelBotones.Controls(i).Right
                    End If
                Next
                z.Location = New Point(maxright, 0)
                z.AutoSize = True
                z.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowOnly
                PanelBotones.Controls.Add(z)
                AddHandler z.Click, AddressOf clickBotonTab
            ElseIf Numero(x(1)) > 0 Then
                Dim y As New BotonCinta(DataC(elemento("AdminRequired")), DataC(elemento("inform")), DataC(elemento("Form")), DataC(elemento("Imagen")), DataC(elemento("Texto")), DataC(elemento("txtTooltip")))
                y.Name = "Cinta" & x(0) & "_Opt" & x(1)
                y.BackColor = Color.Transparent
                y.Visible = False
                ' y.Flatstyle = FlatStyle.Flat
                AddHandler y.ClickOPT, AddressOf ClickCinta
                y.Location = UbicaEnRibbon(SplitContainer1.Panel1, y)
                SplitContainer1.Panel1.Controls.Add(y)
            End If
        Next
    End Sub
    Public Sub CerrarControlActual(sender As Object, e As EventArgs) Handles ToolStripStatusLabel2.Click
        If IsNothing(TabContainer.SelectedTab) Then Exit Sub
        If TabContainer.SelectedTab.Controls.Count <> 0 Then TabContainer.SelectedTab.Controls(0).Dispose() 'Release el control del tab 
        TabContainer.TabPages.Remove(TabContainer.SelectedTab)

    End Sub

    Sub invisibleTodos()
        For Each elemento As Control In SplitContainer1.Panel1.Controls
            If elemento.Name.Contains("Cinta") Then
                elemento.Visible = False
            End If
        Next
    End Sub
    Sub clickBotonTab(ByVal sender As Button, ByVal e As EventArgs)
        suspenderLayout(Me)
        panelMIni = True
        minMax()
        panelMIni = False
        invisibleTodos()
        For Each elemento As Control In SplitContainer1.Panel1.Controls
            If elemento.Name.Contains("Cinta" & sender.Tag) Then
                elemento.Visible = True
            End If
        Next
        resumirLayout(Me)

    End Sub
    Function UbicaEnRibbon(ByRef punteropag As Panel, ByRef boton As BotonCinta)
        Dim contador As Integer = 0
        Dim xa() As String = boton.Name.Split("_")
        For Each elemento As Control In SplitContainer1.Panel1.Controls
            If elemento.Name.Contains(xa(0)) Then
                contador += 1
            End If
        Next
        Dim y As Integer = PanelBotones.Bottom + PanelBotones.Top
        Dim x As Integer = (contador * (2 * margenRibbon + boton.Width)) + margenRibbon + 25
        UbicaEnRibbon = New Point(x + Button1.Right, y)
    End Function

    Sub ClickCinta(ByVal opcion As BotonCinta)
        '  suspenderLayout(Me)
        Cursor = Cursors.WaitCursor
        'Buscar si ya esta abierta y focus
        Dim a As Object = TabContainer.Controls.Find("Tab" & opcion.Form, True)
        If DirectCast(a, Array).Length <> 0 Then
            TabContainer.SelectTab(a(0))
            GoTo salidaSub
        End If
        'buscar si esta abierta como form y show
        For Each vent As Form In ventanas
            If vent.Name = "Tab" & opcion.Form Then
                vent.Show()
                vent.Focus()
                GoTo salidaSub
            End If
        Next
        'si no esta abierta -> Abrir
        '?es adminrequired??
        If opcion.adminrequired Then
            Dim frmClave As New InputClave
            Dim result As Integer = frmClave.ShowDialog
            If result <> InputClave.Res_Input.Exito Then
                GoTo salidaSub
            Else
                'aprobado. continuar
            End If
        End If
        Dim y As New TabPage

        y.Text = opcion.CmdDes.Text
        y.Name = "Tab" & opcion.Form
        y.BackColor = Color.White
        Dim programa As Object
        Try
            If opcion.Form.Length > 12 Then
                If opcion.Form.Substring(0, 12) = "ModificaData" Then
                    Dim id As Integer = CInt(opcion.Form.Substring(12, opcion.Form.Length - 12))
                    programa = New ModificaData(id, {Parametros.MeserosOrigen.NombreTabla,
                                                     Parametros.MeserosOrigen.FiltroMesero, Parametros.MeserosOrigen.Campos})
                Else
                    programa = Activator.CreateInstance(Type.GetType("SAAB." & opcion.Form))
                End If
            Else
                programa = Activator.CreateInstance(Type.GetType("SAAB." & opcion.Form))
            End If
        Catch ex As Exception
            MsgBox("Opcion en construccion. Consulte a su proveedor de sistemas", MsgBoxStyle.Information, "Un Momento!!!")
            GoTo salidaSub
        End Try
        'minimizar panel superior
        panelMIni = False
        programa.visible = False
        Me.SuspendLayout()
        minMax()
        Me.ResumeLayout(False)
        If opcion.inform Then
            DirectCast(programa, UserControl).Dock = DockStyle.Fill
            y.Controls.Add(programa)
            TabContainer.TabPages.Add(y)
            TabContainer.SelectTab(y)
            DirectCast(programa, DolphinCtl).rectanguloDestino = y.ClientRectangle
            DirectCast(programa, DolphinCtl).DarTamaño()
            Me.ResumeLayout(False)
            If opcion.Form.Length > 12 Then
                If opcion.Form.Substring(0, 12) = "ModificaData" Then
                    programa.Inicializar(True)
                End If
            End If
            programa.loader()
        Else
            Me.ResumeLayout(False)
            DirectCast(programa, DolphinForm).ShowDialog()
        End If
salidaSub:
        Me.PerformLayout()
        resumirLayout(Me)
        Cursor = Cursors.Default
    End Sub

    Sub Dibujar()
        Dim myGraphicsPath = New GraphicsPath(FillMode.Alternate)
        myGraphicsPath.AddEllipse(New Rectangle(2, 2, Button1.Width - 5, Button1.Height - 5))
        Dim regnueva As Region = New Region(myGraphicsPath)
        Button1.Region = regnueva
        Me.WindowState = FormWindowState.Maximized
        Me.Show()
        Button1.BringToFront()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        panelMIni = Not panelMIni
        minMax()
        If IsNothing(TabContainer.SelectedTab) Then Exit Sub
        If TabContainer.SelectedTab.Controls.Count = 0 Then Exit Sub
        If TabContainer.SelectedTab.Controls(0).GetType.BaseType.Name <> "DolphinCtl" Then Exit Sub
        Dim a As DolphinCtl = TabContainer.SelectedTab.Controls(0)
        a.botonDelfin()
    End Sub

    Sub minMax()
        If panelMIni Then
            'aumentar
            SplitContainer1.SplitterDistance = poseInicial

        Else
            'hacer pequeño
            SplitContainer1.SplitterDistance = PanelBotones.Bottom + PanelBotones.Top
        End If
    End Sub

    Private Sub TabContainer_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TabContainer.MouseDoubleClick
        sacarAventana()
    End Sub
    Sub sacarAventana()
        Dim frm As New DolphinForm
        frm.AplicarTema(Globales.Parametros.CombinacionColores)
        ventanas.Add(frm)
        AddHandler frm.FormClosing, AddressOf ventanaHijaCerrada
        frm.Name = TabContainer.SelectedTab.Name
        frm.Text = TabContainer.SelectedTab.Text
        Dim ctlComm As Object = TabContainer.SelectedTab.Controls(0)
        frm.Ventana.Controls.Add(TabContainer.SelectedTab.Controls(0))

        frm.Ventana.Controls(0).Dock = DockStyle.Fill
        ToolStripStatusLabel2.PerformClick()
        frm.WindowState = FormWindowState.Maximized
        frm.Show()

        If ctlComm.GetType.ToString = "SARC.Comandas" Then
            DirectCast(ctlComm, Comandas).reordenar(True)
        End If
    End Sub

    Sub ventanaHijaCerrada(sender As Object, e As FormClosingEventArgs)
        ventanas.Remove(sender)
    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If cerrar Then
            Me.Close()
        End If
    End Sub
End Class
