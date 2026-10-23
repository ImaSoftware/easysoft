Imports System.Drawing.Drawing2D
Imports System.IO
Imports Spire.Barcode

Public Class Mesa
    Public estadosActivos As New List(Of EstadoCuenta)
    Dim contador As Integer = 0
    Public esquema As Boolean = False
    Dim myGraphicsPath As New GraphicsPath
    Dim clickR As Boolean = False
    Dim clickM As Boolean = False
    Dim allowResize As Boolean = False
    Dim allowMove As Boolean = False
    Dim comandoEditar As Boolean = False
    Dim NuevoTam As Size
    Dim InicioMouse As Point
    Friend SoyImagen As Boolean = False
    Dim ColorFondo As Color
    Public AreaMadre As Area
    'Propiedades Bound
    Public IdMesa As Integer = -1
    Public IdSector As Integer
    Public IdArea As Integer
    Public _Alias As String
    Public AliasNum As Integer
    Public Estado As String
    ' Public Ocupada As Boolean
    Public Capacidad As Integer
    Public Textura As String
    Public Circular As Boolean
    Public DiseñoMesa As Boolean = False
    Public colorcito As Color = Nothing

    Public Event ClickMesa(ByVal sender As Mesa)
    Public Event DobleClickMesa(ByVal sender As Mesa)
    Public Event FueraMesa()
    Public Event UpdateMesa(ByVal sender As Mesa)

    Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Sub New(ByVal argID)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        Me.IdMesa = argID
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub cargarMesa()
        Me.SuspendLayout()
        If IdMesa > 0 Then
            Dim datamesa As DataTable = cargarConsulta(String.Format("Select * from SD_Mesas where Id = {0}", IdMesa))
            If datamesa.Rows.Count > 0 And datamesa.Rows.Count = 1 Then
                Me.IdSector = DataC(datamesa(0)("IdSector"))
                Me.IdArea = DataC(datamesa(0)("IdArea"))
                Me._Alias = DataC(datamesa(0)("Alias"))
                Me.AliasNum = CInt(Numero(DataC(datamesa(0)("NumAlias"))))
                Me.Estado = DataC(datamesa(0)("Estado"))
                numAlias.Text = AliasNum
                If Me._Alias = "" Then
                    SoyImagen = True
                End If
                Me.Capacidad = DataC(datamesa(0)("Capacidad"))
                Me.Textura = DataC(datamesa(0)("Textura"))
                Me.Circular = DataC(datamesa(0)("Circular"))
                Me.Location = New Point(Numero(DataC(datamesa(0)("PosicionX"))), Numero(DataC(datamesa(0)("PosicionY"))))
                If File.Exists(Application.StartupPath & "\BMPs\Texturas\" & Me.Textura) Then
                    Me.BackgroundImage = Image.FromFile(Application.StartupPath & "\BMPs\Texturas\" & Me.Textura)
                Else
                    Me.BackgroundImage = Nothing
                End If
                Me.BackColor = Color.FromArgb(CInt(Numero(DataC(datamesa(0)("BackColor")))))
                colorcito = Me.BackColor
                Me.Size = New Size(Numero(DataC(datamesa(0)("Ancho"))), Numero(DataC(datamesa(0)("Altura"))))

            Else
                    MsgBox("ID de mesa Repetido " & IdMesa, MsgBoxStyle.Critical)
            End If
        Else 'carga uno estandar
            Me._Alias = "MESA N"
            '     Me.Ocupada = False
            Me.Capacidad = 1
            Me.Textura = "mesa1.png"
            Me.Location = New Point(30, 30)
            Me.Size = New Size(100, 100)
            Me.BackgroundImage = Image.FromFile(Application.StartupPath & "\BMPs\Texturas\" & Me.Textura)
            Me.ResumeLayout()
        End If
        'Me.Scale(New System.Drawing.SizeF(1.01, 1.01))

    End Sub

    Private Sub Mesa_Click(sender As Object, e As EventArgs) Handles Me.Click, numAlias.Click

        RaiseEvent ClickMesa(Me)
    End Sub

    Private Sub Mesa_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick, numAlias.DoubleClick

        If SoyImagen Then Exit Sub
        RaiseEvent DobleClickMesa(Me)
    End Sub
#Region "Para mover y Resize"


    'Declaramos esta variable global que sera nuestro handle del evento Resize
    'En español la bandera para saber cuando el usuario quiere cambiar el tamaño del PictureBox
    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Me.ColorFondo = Me.BackColor
        If Not comandoEditar Then Exit Sub
        If allowResize Then clickR = True
        If allowMove Then clickM = True
        InicioMouse = Cursor.Position
        Me.BorderStyle = BorderStyle.FixedSingle
        If Circular Then
            Me.BackColor = Color.Red
        End If
        Me.BackgroundImage = Nothing
        comandoEditar = True
    End Sub


    'Evento MouseMove donde realizamos el Resize
    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If Not comandoEditar Then Exit Sub
        If allowResize And clickR Then
            If e.X >= (NuevoTam.Width) - 5 And e.Y >= (NuevoTam.Height) - 5 Then
                NuevoTam.Width = NuevoTam.Width + 5
                NuevoTam.Height = NuevoTam.Height + 5
            ElseIf e.X >= (NuevoTam.Width) - 5 Then
                NuevoTam.Width = NuevoTam.Width + 5
            ElseIf e.Y >= (NuevoTam.Height) - 5 Then
                NuevoTam.Height = NuevoTam.Height + 5
            ElseIf e.X < (NuevoTam.Width) - 10 And e.Y < (NuevoTam.Height) - 10 Then
                NuevoTam.Width = NuevoTam.Width - 3
                NuevoTam.Height = NuevoTam.Height - 3
            ElseIf e.X < (Me.Right - Me.Left) - 5 Then
                NuevoTam.Width = NuevoTam.Width - 3
            ElseIf e.Y < (NuevoTam.Height) - 5 Then
                NuevoTam.Height = NuevoTam.Height - 3
            End If
            If Me.Size.Width > 10 And Me.Size.Height > 10 Then
                Me.Size = NuevoTam
            Else
                Me.Size = New Size(20, 20)
            End If
            'cambiarReg()
        ElseIf allowMove And clickM Then
            Dim finMouse As Point = Cursor.Position
            Dim difx As Integer = finMouse.X - InicioMouse.X
            Dim dify As Integer = finMouse.Y - InicioMouse.Y
            InicioMouse = finMouse
            Dim nuevox As Integer = Me.Location.X + difx
            Dim nuevoy As Integer = Me.Location.Y + dify
            If nuevox > 0 And nuevoy > 0 Then
                Me.Location = New Point(nuevox, nuevoy)
            Else
                MsgBox("Nueva posicion inválida!!", MsgBoxStyle.Information, "Un Momento!!!")
                cargarMesa()
                Call PictureBox1_MouseUp(Me, Nothing)
            End If
        End If
    End Sub


    'Por ultimo el MouseUp que indica que termino el resize
    Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If comandoEditar Then
            If Not String.IsNullOrEmpty(Me.Textura) Then
                Me.BackgroundImage = Image.FromFile(Application.StartupPath & "\BMPs\Texturas\" & Me.Textura)
            End If
            Me.BorderStyle = Windows.Forms.BorderStyle.None
            Me.BackColor = ColorFondo
            comandoEditar = False
            If allowResize Then
                allowResize = False
                clickR = False
            End If
            If allowMove Then
                clickM = False
                allowMove = False
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub CambiarTamañoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarTamañoToolStripMenuItem.Click
        comandoEditar = True
        Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        NuevoTam = Me.Size
        Me.Cursor = Cursors.SizeNWSE
        allowResize = True
    End Sub

    Private Sub MoverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoverToolStripMenuItem.Click
        comandoEditar = True
        Me.Cursor = Cursors.SizeAll
        allowMove = True
    End Sub
#End Region


    Private Sub Mesa_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        'Dibujar Alias Numerico
        If Not SoyImagen Then
            If esquema Then
                numAlias.Visible = True
                'aumentar tamaño de fuente hasta llegar al maximo
                numAlias.Location = New Point((Me.Width - numAlias.Width) / 2, (Me.Height - numAlias.Height) / 2)
                'Dim myGraphicsPath = New GraphicsPath(FillMode.Alternate)
                'myGraphicsPath.AddRectangle(New Rectangle(0, 0, numAlias.Width, numAlias.Height))
                'numAlias.Region = New Region(myGraphicsPath)
            Else
                numAlias.Visible = True
                numAlias.Location = New Point((Me.Width - numAlias.Width) / 2, (Me.Height - numAlias.Height) / 2)
                'Dim myGraphicsPath = New GraphicsPath(FillMode.Alternate)
                'myGraphicsPath.AddEllipse(New Rectangle(0, 0, numAlias.Width, numAlias.Height))
                'numAlias.Region = New Region(myGraphicsPath)
            End If

        End If
        'Dar Apariencia de esquema
        If esquema Then
            If Circular Then
                Me.CreateGraphics.DrawEllipse(New Pen(Color.Black, 1), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
            Else
                Me.CreateGraphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
            End If
        Else
            'le doy la apariencia circular a la region
            If Circular Then
                Dim myGraphicsPath = New GraphicsPath(FillMode.Alternate)
                myGraphicsPath.AddEllipse(New Rectangle(2, 2, Me.Width - 5, Me.Height - 5))
                Me.Region = New Region(myGraphicsPath)
            Else
                Dim myGraphicsPath = New GraphicsPath(FillMode.Alternate)
                myGraphicsPath.AddRectangle(New Rectangle(0, 0, Me.Width, Me.Height))
                Me.Region = New Region(myGraphicsPath)
            End If

        End If

        ' para esquema y para Vista enriquecida  'dibujar estados
        If Not DiseñoMesa Then
            If Not IsNothing(AreaMadre) Then
                If Not AreaMadre.EsMiniatura Then
                    If Not SoyImagen Then
                        'Se cambia la verificacion de estados para que se ejecute desde un procedimiento almacenado superior 
                        ' DirectCast(Me.Parent.Parent, Area).verificarEstados()
                        If Not IsNothing(estadosActivos) Then
                            If estadosActivos.Count > 0 Then
                                Dim semiTransBrush As New SolidBrush(estadosActivos(0).R_Color)
                                '  e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected
                                If Me.Circular Then
                                    e.Graphics.FillEllipse(semiTransBrush, New Rectangle(0, 0, Me.Width, Me.Height))
                                Else
                                    e.Graphics.FillRectangle(semiTransBrush, New Rectangle(0, 0, Me.Width, Me.Height))
                                End If

                            End If
                        End If

                    End If
                End If
            End If

        End If

    End Sub
    'Sub VerificaEstados()
    '    If Me.Estado = "I" Then Exit Sub
    '    estadosActivos.Clear()
    '    If SoyImagen Then Exit Sub
    '    Dim Estados As DataTable = cargarConsulta("Select * from SD_Cuentas_Estados where Activo = 1 order by Orden desc")
    '    If Not IsNothing(Estados) Then
    '        If Estados.Rows.Count > 0 Then
    '            For Each estado As DataRow In Estados.Rows
    '                Dim lin As New List(Of Parametro) : lin.Add(New Parametro("NoMesa", IdMesa))
    '                Dim lout As New List(Of Parametro) : lout.Add(New Parametro("Resultado", 0))
    '                Dim Res As Boolean = CBool(EjecutarSP(DataC(estado("spComprueba")), lin, lout, sp_ret.output_Vars)("Resultado"))
    '                If Res Then
    '                    estadosActivos.Add(New EstadoCuenta(estado("Color"), estado("Dsc")))
    '                End If
    '            Next
    '        End If
    '    End If

    'If OcupaditaPAPA <> Me.Ocupada Then
    '    Dim sqlactualizaOcupada As String = String.Format("UPDATE SD_Mesas set Ocupada = '{0}' where id = {1}", _
    '                                                IIf(OcupaditaPAPA, "True", "False"), Me.IdMesa)
    '    If EjecutarConsulta(sqlactualizaOcupada) <> 1 Then
    '        MsgBox("Resultado Inesperado")
    '    End If
    '    Me.Ocupada = OcupaditaPAPA
    'End If

    ' End Sub

    Private Sub MenuMesa_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MenuMesa.Opening
        If Me.Parent.Parent.GetType.Name = "Area" Then
            If Not DirectCast(Me.Parent.Parent, Area).Diseño Or DirectCast(Me.Parent.Parent, Area).Edicion Then
                e.Cancel = True
            Else
                'If SoyImagen Then
                '    EliminarToolStripMenuItem.Visible = True
                'Else
                '    EliminarToolStripMenuItem.Visible = False
                'End If
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        If MsgBox("Se eliminará la imagen seleccionada. ¿Desea Continuar?", MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then

            If SoyImagen Then
                eliminar(Me.IdMesa)
            Else
                MsgBox("No se debe elimar una mesa. Desactívela cambiando su estado a 'I'")
            End If
        End If
    End Sub

    Sub eliminar(ByVal argid As Integer)
        Dim sql As String = String.Format("Delete SD_Mesas where id = {0}", argid)
        EjecutarConsulta(sql)
        RaiseEvent FueraMesa()
    End Sub

    Private Sub PropiedadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropiedadesToolStripMenuItem.Click
        Dim frmMesa As New MesaDialog()
        frmMesa.Text = Me._Alias & "  ;  Id: " & Me.IdMesa
        frmMesa.cargarInfoMesa(Me.IdMesa)
        If frmMesa.ShowDialog = DialogResult.OK Then
            Me.Size = frmMesa.tamanio
            Me.Location = frmMesa.posicion
            Me._Alias = frmMesa._AliasMesa
            Me.Capacidad = frmMesa.Capacidad
            Me.Circular = frmMesa.circular
            Me.Textura = frmMesa.textura
            Me.BackColor = frmMesa.ColorFondo
            If System.IO.File.Exists(Application.StartupPath & "\BMPs\Texturas\" & frmMesa.textura) Then
                Me.BackgroundImage = Image.FromFile(Application.StartupPath & "\BMPs\Texturas\" & frmMesa.textura)
            End If
            RaiseEvent UpdateMesa(Me)
        End If
    End Sub




    Private Sub Mesa_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        numAlias.Location = New Point((Me.Width - numAlias.Width) / 2, (Me.Height - numAlias.Height) / 2)
    End Sub

    Private Sub GenerarQRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarQRToolStripMenuItem.Click
        'Report con QR
        Dim rutaF As String = Path.GetFileNameWithoutExtension(Path.GetRandomFileName) & ".bmp"
        Dim settings As New BarcodeSettings()
        settings.Type = BarCodeType.QRCode
        settings.Unit = GraphicsUnit.Pixel
        settings.ShowText = False
        settings.ResolutionType = ResolutionType.UseDpi
        settings.X = 5.0F
        settings.Data = CStr(Me.IdMesa).Trim()
        Dim generator As New BarCodeGenerator(settings)
        Dim image As Image = generator.GenerateImage()
        image.Save(rutaF)
        Cursor = Cursors.WaitCursor
        Dim lo As New List(Of Parametro)
        lo.Add(New Parametro("iden", My.Application.Info.DirectoryPath & "\" & rutaF))
        Dim b As New vReport("qRIden.rdlc", lo)
        b.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub borraQR_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

    End Sub
End Class
Public Class EstadoCuenta
    Sub New(ByVal argR_color As Integer, ByVal argDesc As String)
        R_Color = Color.FromArgb(argR_color) : Descripcion = argDesc
    End Sub
    Property R_Color As Color
    Property Descripcion As String
End Class
