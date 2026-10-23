Public Class DolphinForm
    Private Arrastre As Boolean = False
    Private ptox, ptoy As Integer
    Public ColorPrimario As Color
    Public ColorSecundario As Color
    Public fontTheme As Font
    Public Event DelfinCerrado(ByVal sender As Object)
    Sub New()
        InitializeComponent()
        If Not Globales.Parametros.OK Then
            If Not Globales.Parametros.Cargar(1) Then
                Environment.Exit(-1)
            End If
        End If

        AplicarTema(Parametros.CombinacionColores)
    End Sub
    Private Sub DolphinForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        destruir(Me)
    End Sub

    Private Sub DolphinForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        RaiseEvent DelfinCerrado(Me)
    End Sub

    Private Sub DolphinForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
        If Me.Modal Then Me.TopMost = True
    End Sub
    Sub AplicarTema(ByVal codigoTema As Integer)

        ColorPrimario = Globales.Parametros.Tema.colorPrimario
        ColorSecundario = Globales.Parametros.Tema.colorSecundario
        fontTheme = New Font(Globales.Parametros.Tema.FontName, Globales.Parametros.Tema.fontsize)
        Me.Font = fontTheme
        PanelTitulo.BackColor = ColorPrimario
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelTitulo.MouseDown
        ptox = e.X
        ptoy = e.Y
        Arrastre = True
    End Sub


    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelTitulo.MouseUp
        If Arrastre Then Me.Location = Me.PointToScreen(New Point(MousePosition.X - Me.Location.X - ptox, MousePosition.Y - Me.Location.Y - ptoy))
        Arrastre = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles MINIMIZE.Click
        If Me.Modal Then Exit Sub
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub WINBTN_Click(sender As Object, e As EventArgs) Handles WINBTN.Click
        If Me.Modal Then Exit Sub
        Dim lista As FormCollection = Application.OpenForms
        panelForms.Controls.Clear()
        panelForms.Dock = DockStyle.None
        If lista.Count > 0 Then
            For i = 1 To lista.Count
                Dim btn As New Button
                btn.AutoSize = True
                btn.Dock = System.Windows.Forms.DockStyle.Top
                btn.Name = "btn" & lista(i - 1).Name
                btn.TabIndex = i
                btn.Text = lista(i - 1).Text
                btn.Tag = lista(i - 1)
                AddHandler btn.Click, AddressOf cambiaform
                panelForms.Controls.Add(btn)
                If i = lista.Count Then
                    panelForms.Height = btn.Bottom
                End If
            Next
        End If
        panelForms.Visible = Not panelForms.Visible
        panelForms.Location = New Point(Ventana.Right - panelForms.Width, 0)
        panelForms.BringToFront()
    End Sub
    Sub cambiaform(ByVal sender As Button, e As EventArgs)
        panelForms.Visible = Not panelForms.Visible
        If DirectCast(sender.Tag, Form).WindowState = FormWindowState.Minimized Then
            DirectCast(sender.Tag, Form).WindowState = FormWindowState.Maximized
        End If
        DirectCast(sender.Tag, DolphinForm).BringToFront()
        DirectCast(sender.Tag, Form).Show()
        DirectCast(sender.Tag, Form).Focus()
    End Sub

    Sub cargarEstadisticas()
        Dim ctlres As Restaurante = Nothing
        If Me.Text = "Principal" Then
            Dim t_form As Principal = DirectCast(Me, Principal)
            Dim a As Object = t_form.TabContainer.Controls.Find("TabRestaurante", True)
            If DirectCast(a, Array).Length <> 0 Then
                ctlres = DirectCast(DirectCast(a(0), TabPage).Controls(0), Restaurante)
                ctlres.cargarEstadisticas()
            End If
        ElseIf Me.Text = "Restaurante" Then
            ctlres = DirectCast(Me.Controls("Ventana").Controls(1), Restaurante)
        End If
        If IsNothing(ctlres) Then
            Exit Sub
        Else
            ctlres.cargarEstadisticas()
        End If
    End Sub

End Class