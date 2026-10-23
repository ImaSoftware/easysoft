Imports System.Drawing.Drawing2D

Public Class Area
    Friend EsEsquema As Boolean = False
    Friend EsMiniatura As Boolean = False
    Dim corx As Single
    Dim cory As Single
    Dim TablaPuntos As DataTable
    Friend Id As Integer
    Friend Nombre As String
    Public Descripcion As String
    Public Diseño As Boolean = False
    Public EsSector As Boolean = False

    Public Edicion As Boolean
    Public sizeFondo As Size
    Public ImgFondo As String
    Public BackLayout As Integer
    Public Puntos As New List(Of botonpunto)
    Public escala As Double = 1
    Friend WithEvents CDPropiedadesMesa As New MesaDialog 'Cuadro de Dialogo de propiedades de mesa
    Dim loquesepega As New resultadoC
    Dim myPoints() As Point
    Dim auxetiqueta As Label = Nothing
    Dim myGraphicsPath As GraphicsPath
    Dim PegandoElemento As Boolean = False
    Dim lblMoveResize As Boolean
    Dim InicioMouse As Point
    Dim allowMove As Boolean
    Dim clickM As Boolean

    Public Event DoubleClicMesa(ByVal argMesa As Mesa)
    Public Event ClicMesaEsquema(ByVal argMesa As Mesa)
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        myPoints = New Point() {New Point(PanelArea.Location.X, PanelArea.Location.Y), _
                                New Point(PanelArea.Location.X, PanelArea.Location.Y + PanelArea.Height), _
                                New Point(PanelArea.Location.X + PanelArea.Width, PanelArea.Location.Y + PanelArea.Height), _
                                New Point(PanelArea.Location.X + PanelArea.Width, PanelArea.Location.Y)}
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    ''' <summary>
    ''' Carga las etiquetas y las pone dentro del Sector
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub cargarEtiquetas()
        Dim sqlEtiquetas As String = String.Format("Select * from SD_Textos where IdArea = {0}", Me.Id)
        Dim tablaEtiquetas As DataTable = cargarConsulta(sqlEtiquetas)
        If Not IsNothing(tablaEtiquetas) Then
            If tablaEtiquetas.Rows.Count > 0 Then
                For Each etiqueta In tablaEtiquetas.Rows
                    Dim fst As FontStyle
                    If CBool(etiqueta("font_Bold")) Then
                        fst = FontStyle.Bold
                    End If
                    If CBool(etiqueta("font_Italic")) Then
                        fst = FontStyle.Italic
                    End If
                    If CBool(etiqueta("font_strikeout")) Then
                        fst = FontStyle.Strikeout
                    End If
                    If CBool(etiqueta("font_underline")) Then
                        fst = FontStyle.Underline
                    End If
                    Dim fuente As New Font(etiqueta("font_name").ToString, CSng(etiqueta("font_size")), fst)
                    Dim lblPegar As New Label : lblPegar.Text = etiqueta("Texto") : lblPegar.Name = "etiqueta" & etiqueta("id")
                    lblPegar.Font = fuente
                    lblPegar.AutoSize = True : lblPegar.Tag = etiqueta("Id")
                    lblPegar.BackColor = Color.FromArgb(CInt(Numero(DataC(etiqueta("Backcolor")))))
                    lblPegar.ForeColor = Color.FromArgb(CInt(Numero(DataC(etiqueta("ForeColor")))))
                    AddHandler lblPegar.MouseDown, AddressOf labelMD
                    AddHandler lblPegar.MouseUp, AddressOf labelMU
                    AddHandler lblPegar.MouseMove, AddressOf labelMM

                    lblPegar.ContextMenuStrip = MenuEtiquetas
                    lblPegar.Location = New Point(etiqueta("x"), etiqueta("y"))
                    PanelArea.Controls.Add(lblPegar)
                Next
            End If
        Else
            MsgBox("Error en la consulta cargarEtiquetas", MsgBoxStyle.Critical, "Ops!!!")
            Exit Sub
        End If
    End Sub
    Sub zoom(ByVal F As Double)
        Me.escala = Me.escala + F
        Dim sql As String = String.Format("Update SD_Areas set escala = {0} where id = {1}", _
                                          Me.escala.ToString.Replace(",", "."), Me.Id)
        EjecutarConsulta(sql)
        cargarTodo()
    End Sub

    ''' <summary>
    ''' Carga los puntos del sector y dibuja el Area
    ''' </summary> 
    ''' <param name="argId"></param>
    ''' 
    ''' <remarks>Id del Area en la tabla SD_Areas </remarks>
    Public Sub cargarSector(ByVal argId As Integer)

        ' Llamada necesaria para el diseñador.
        'RECOGER LOS PUNTOS A PARTIR DE DB
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Id = argId
        Dim DataArea As DataRow = cargarConsulta(String.Format("Select * from SD_Areas where Id = {0}", argId))(0)
        Me.EsSector = DataC(DataArea("EsSector"))
        Me.Nombre = DataC(DataArea("Nombre"))
        Me.Descripcion = DataC(DataArea("Descripcion"))
        Me.escala = Numero(DataC(DataArea("Escala")))
        Me.sizeFondo = New Size(Numero(DataC(DataArea("W_TamText"))), Numero(DataC(DataArea("H_TamText"))))
        Me.ImgFondo = DataC(DataArea("Textura"))

        Me.BackLayout = CInt(Numero(DataC(DataArea("Layout"))))
        ' carga de el fondo del sector
        Me.PanelArea.BackColor = Color.FromArgb(DataC(DataArea("BackColor")))
        If Me.ImgFondo = "" Then
            Me.PanelArea.BackgroundImage = Nothing
        Else
            Me.ImagenFondo.Images.Clear()
            Me.ImagenFondo.ImageSize = Me.sizeFondo
            Me.ImagenFondo.Images.Add(Image.FromFile(Application.StartupPath & "\BMPs\Texturas\" & Me.ImgFondo))
            Me.PanelArea.BackgroundImageLayout = Me.BackLayout
            Me.PanelArea.BackgroundImage = ImagenFondo.Images(0)
        End If

        ''carga de puntos de la forma
        'TablaPuntos = cargarConsulta(String.Format("Select * from SD_Puntos where IdArea = {0} order by IdPunto", argId))
        'Array.Resize(myPoints, TablaPuntos.Rows.Count)
        'Dim i = 0
        'For Each FilaPunto As DataRow In TablaPuntos.Rows
        '    myPoints(i) = New Point(FilaPunto("x"), FilaPunto("y"))
        '    i += 1
        'Next
        'AgregarBotonesPunto()
        'RedibujarArea()
        'If Not Diseño Then
        '    VisiblePuntos(False)
        'End If
        If EsEsquema Then
            PanelArea.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            PanelArea.BackColor = Color.White
            PanelArea.BackgroundImage = Nothing
            'corx = PanelArea.Region.GetBounds(Me.CreateGraphics).Left
            ' cory = PanelArea.Region.GetBounds(Me.CreateGraphics).Top
            'corx = PanelArea.Left
            'cory = PanelArea.Top
            'Dim heightn As Integer = PanelArea.Bottom - cory
            'Dim widthn As Integer = PanelArea.Right - corx
            'Dim heightn As Integer = PanelArea.Region.GetBounds(Me.CreateGraphics).Bottom - cory
            'Dim widthn As Integer = PanelArea.Region.GetBounds(Me.CreateGraphics).Right - corx
            '  PanelArea.Region.Translate(-corx, -cory)
            'PanelArea.Location = New Point(PanelArea.Location.X + corx, _
            '  PanelArea.Location.Y + cory)
            'PanelArea.Region = New Region(New Rectangle(0, 0, widthn, heightn))
        End If
        Me.ResumeLayout()
        PanelArea.Visible = True
    End Sub
    ''' <summary>
    ''' Pone visible o invisible los botones punto que definen el área a dibujarse
    ''' </summary>
    ''' <param name="Visibilidad"></param>
    ''' <remarks></remarks>
    Public Sub VisiblePuntos(ByVal Visibilidad As Boolean)
        For Each Control As Control In Me.Controls
            If Control.Name.Length > 6 Then
                If Control.Name.Substring(0, 6) = "btnpto" Then
                    Control.Visible = Visibilidad
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' Asumiendo que TablaPuntos tiene los valores cargados define la lista de botones y los agrega al control
    ''' </summary>
    ''' <remarks></remarks>
    Sub AgregarBotonesPunto()
        If IsNothing(myPoints) Then Exit Sub
        LimpiarBotonesPunto() 'Se quito de Pantalla y de Lista
        Dim i As Integer = 0
        For Each punto As Point In myPoints
            Dim btnpto As New botonpunto(TablaPuntos(i)("Id"), i, TablaPuntos(i)("IdArea"))
            btnpto.Location = punto
            btnpto.Location = New Point(btnpto.Location.X - (botonpunto.TAM / 2), _
                                          btnpto.Location.Y - (botonpunto.TAM / 2))
            Me.Controls.Add(btnpto) : Puntos.Add(btnpto)
            AddHandler btnpto.Eliminarpto, AddressOf EliminarPunto
            AddHandler btnpto.SeMovio, AddressOf btnptoMoved
            i += 1
        Next
    End Sub
    Sub EliminarPunto(ByVal punto As botonpunto)
        Dim id As Integer = punto.Id
        Puntos.Remove(punto)
        For Each p As botonpunto In Puntos
            If p.Id > id Then
                p.Id = p.Id - 1
                p.ActualizaId(p.Id)
            End If
        Next
        Dim sql As String = String.Format("delete from sd_puntos where id= {0}", punto.Id)
        EjecutarConsulta(sql)
        cargarSector(Me.Id)
    End Sub


    Sub btnptoMoved(ByVal NuevaPosicion As Point)
        ActualizaArreglo()
        RedibujarArea()
    End Sub
    Sub RedibujarArea()
        If IsNothing(myPoints) Then Exit Sub
        If myPoints.Count = 0 Then Exit Sub
        myGraphicsPath = New GraphicsPath(FillMode.Alternate)
        myGraphicsPath.AddPolygon(myPoints)
        '  Me.CreateGraphics.FillPath(New SolidBrush(Color.Red), myGraphicsPath)
        Dim regnueva As Region = New Region(myGraphicsPath)
        regnueva.Translate(-PanelArea.Location.X, -PanelArea.Location.Y)
        PanelArea.Region = regnueva
        PanelArea.Refresh()
    End Sub
    Sub ActualizaArreglo()
        myPoints = New Point() {}
        Array.Resize(myPoints, Puntos.Count)
        Dim i As Integer = 0
        For Each btn As botonpunto In Puntos
            myPoints(i) = New Point(btn.Location.X + (botonpunto.TAM / 2), btn.Location.Y + (botonpunto.TAM / 2))
            i += 1
        Next
    End Sub
    Sub LimpiarBotonesPunto()
        Dim a As New List(Of Control) 'Busco todos los puntos dibujados en el area
        For Each Control As Control In Me.Controls
            If Control.Name.Length > 6 Then
                If Control.Name.Substring(0, 6) = "btnpto" Then
                    a.Add(Control)
                End If
            End If
        Next
        For Each botonpunto As Control In a
            Me.Controls.Remove(botonpunto)
            destruir(botonpunto)
        Next
        Puntos.Clear()
    End Sub

    Private Sub AgregarPuntoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarPuntoToolStripMenuItem.Click
        agregarPuntoForma(Control.MousePosition)
    End Sub
    Sub agregarPuntoForma(ByVal MPos As Point)
        Dim nuevoIndice As Integer = IndiceAgrega(MPos)
        Dim nuevoboton As New botonpunto(-1, nuevoIndice, Me.Id)
        nuevoboton.Location = PointToClient(MPos) : nuevoboton.Name = "btnpto" + CStr(nuevoIndice)
        For Each punto In Puntos
            If punto.IdPunto >= nuevoIndice Then
                punto.IdPunto += 1 : punto.ActualizaId(punto.IdPunto)
            End If
        Next
        Puntos.Insert(nuevoIndice, nuevoboton)
        ActualizaArreglo()
        If TablaPuntos.Rows.Count < Puntos.Count Then
            Dim sql As String = String.Format("Insert into SD_Puntos (IdArea, IdPunto, x, y) values ({0}, {1}, {2}, {3})", _
                                              nuevoboton.IdArea, nuevoboton.IdPunto, nuevoboton.Location.X, nuevoboton.Location.Y)
            EjecutarConsulta(sql)
        End If
        cargarSector(Me.Id)
    End Sub

    ''' <summary>
    ''' 'Resalta las mesas enviadas  en la lista idMesas ej: 1,3,8,21
    ''' y devuelve la capacidad sumada de las mesas
    ''' </summary>
    ''' <param name="idMesas"></param>
    ''' <returns>Capacidad sumada de las mesas especificadas en idMesas</returns>
    ''' <remarks></remarks>
    Public Function resaltarMesa(ByVal idMesas As String) As Integer
        resaltarMesa = 0
        Dim x() = idMesas.Split(",")
        If Not Me.EsEsquema Then Exit Function
        For Each ctlMesa As Mesa In Me.PanelArea.Controls
            If DataC(Array.Find(x, Function(p) Trim(p) = ctlMesa.IdMesa)) = ctlMesa.IdMesa Then
                ctlMesa.BackColor = Color.Gainsboro
                resaltarMesa = resaltarMesa + ctlMesa.Capacidad
            Else
                ctlMesa.BackColor = Color.Transparent
            End If
        Next
    End Function
    Public Sub resaltarMesa(ByVal argIdMesa As Integer)
        If Not Me.EsEsquema Then Exit Sub
        For Each ctlMesa As Mesa In Me.PanelArea.Controls
            If ctlMesa.IdMesa = argIdMesa Then
                ctlMesa.BackColor = Color.Gainsboro
            Else
                ctlMesa.BackColor = Color.Transparent
            End If
        Next
    End Sub
    Public Sub cargarEsquema(ByVal argid As Integer)
        Me.Visible = False
        Me.Dock = DockStyle.Fill
        Me.cargarTodo(argid)
        Me.PanelArea.Dock = DockStyle.None
        Me.AutoScroll = False
        Me.PanelArea.AutoScroll = False
        Me.Visible = True
    End Sub
    Function IndiceAgrega(ByVal puntoMouse As Point) As Integer
        'calcular la distancia con cada punto
        'si la distancia es menor reemplazo el indice
        'asi queda solo la distancia menor
        Dim distanciamenor As Double = 0
        IndiceAgrega = 0
        For Each punto As botonpunto In Puntos
            Dim d As Double = distancia(puntoMouse, Me.PointToScreen(punto.Location))
            If distanciamenor = 0 Then
                distanciamenor = d : IndiceAgrega = punto.IdPunto + 1
            End If
            If d < distanciamenor Then
                distanciamenor = d : IndiceAgrega = punto.IdPunto + 1
            End If
        Next
    End Function
    ''' <summary>
    ''' Toma los elementos de pantalla y los guarda en la base de datos 
    ''' </summary>
    ''' <remarks></remarks>
    ''' asume que todo lo que esta en pantalla ya  ha sido creado en la base de datos
    Sub GuardarArea(Optional vienedeProp As Boolean = False)
        Dim CorreccionX As Integer = 0
        Dim CorreccionY As Integer = 0
        'Calcular corrector de Negativos
        'determinar punto con distancia mas larga desde puntos que tengan coordenadas negativas
        Dim indiceNegativo() As Integer = MayorDistanciaNegativa()
        If indiceNegativo(0) >= 0 Then
            CorreccionX = Math.Abs(myPoints(indiceNegativo(0)).X)
        End If
        If indiceNegativo(1) >= 0 Then
            CorreccionY = Math.Abs(myPoints(indiceNegativo(1)).Y)
        End If

        Dim batch As New SqlBatch()
        For Each punto As botonpunto In Puntos
            batch.AddFormat(" UPDATE  SD_Puntos set IdArea = {0}, IdPunto =  {1}, " _
                                                 & " x = {2}, y ={3}  where Id = {4} ; ", Me.Id, _
                           punto.IdPunto, (myPoints(punto.IdPunto).X + CorreccionX), (myPoints(punto.IdPunto).Y + CorreccionY), punto.Id)
        Next


        For Each Control In PanelArea.Controls
            If Control.name.ToString.StartsWith("Mesa", StringComparison.Ordinal) Then
                Dim a As Mesa = Control
                batch.AddFormat("UPDATE SD_Mesas  set IdSector = {0},  IdArea = {1}, Alias = '{2}', " _
                                                    & " PosicionX = {3}, PosicionY =  {4}, " _
                                                    & " Ancho = {6}, Altura =  {7}, Capacidad = {8}, Circular = '{11}', Textura = '{9}', BackColor = '{12}'  where Id = {10} ", _
                                                    a.IdSector, a.IdArea, a._Alias, (a.Location.X + CorreccionX), (a.Location.Y + CorreccionY), _
                                                    "nada", a.Size.Width, a.Size.Height, a.Capacidad, a.Textura, a.IdMesa, a.Circular, a.BackColor.ToArgb)

            ElseIf Control.name.ToString.StartsWith("etiqueta", StringComparison.Ordinal) Then
                Dim a As Label = Control
                batch.AddFormat("Update Sd_Textos set  idArea = {0},  Texto = '{1}', font_name = '{2}', font_size = {3}, " _
                                                            & " font_Bold = '{4}', font_Italic = '{5}', font_strikeout = '{6}', " _
                                                            & " font_underline = '{7}', x= '{8}', y = '{9}', Backcolor = {11}, ForeColor = {12} where id = {10} ; " _
                                                            , Id, a.Text, a.Font.Name, a.Font.SizeInPoints, a.Font.Bold, a.Font.Italic, a.Font.Strikeout, a.Font.Underline, _
                                                            a.Location.X, a.Location.Y, a.Tag, a.BackColor.ToArgb, a.ForeColor.ToArgb)

            End If
        Next


        If Diseño Then
            batch.AddFormat(" Update SD_Areas set Nombre = '{0}', Descripcion = '{1}', Escala = 1, W_TamText = {2}, H_TamText = {3}," _
                                      & "Textura = '{4}', Layout = {5}, BackColor = {7} where id = {6} ; ", Me.Nombre, Me.Descripcion, sizeFondo.Width, sizeFondo.Height, _
                                       Me.ImgFondo, Me.BackLayout, Me.Id, Me.PanelArea.BackColor.ToArgb)
        End If

        If batch.Execute(CStr(Cn_x_Defecto)) <= 0 Then
            MsgBox("El area no ha sido modificada, Verifique", MsgBoxStyle.Critical, "Alerta!!")
        End If
    End Sub


#Region "Label Resize y move"

    Sub labelMD(ByVal sender As Label, ByVal e As MouseEventArgs)
        If Not Diseño Then
            Exit Sub
        Else
            If Not Edicion Then
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    auxetiqueta = sender

                Else
                    auxetiqueta = Nothing
                    InicioMouse = Cursor.Position
                    If allowMove Then clickM = True
                    sender.BorderStyle = BorderStyle.FixedSingle
                End If

            Else
                Exit Sub
            End If
        End If


    End Sub
    Sub labelMM(ByVal sender As Object, ByVal e As MouseEventArgs)
        If allowMove And clickM Then
            Dim finMouse As Point = Cursor.Position
            Dim difx As Integer = finMouse.X - InicioMouse.X
            Dim dify As Integer = finMouse.Y - InicioMouse.Y
            InicioMouse = finMouse
            Dim nuevox As Integer = sender.Location.X + difx
            Dim nuevoy As Integer = sender.Location.Y + dify
            If nuevox > 0 And nuevoy > 0 Then
                sender.Location = New Point(nuevox, nuevoy)
            Else
                MsgBox("Nueva posicion inválida!!", MsgBoxStyle.Information, "Un Momento!!!")
                Call labelMU(Me, Nothing)
            End If
        End If
    End Sub

    Sub labelMU(ByVal sender As Object, ByVal e As MouseEventArgs)
        sender.BorderStyle = Windows.Forms.BorderStyle.None
        If allowMove Then
            clickM = False
            allowMove = False
        End If
        sender.Cursor = Cursors.Default
    End Sub

#End Region
    Function MayorDistanciaNegativa() As Integer()
        Dim memindex() As Integer = {-1, -1}
        For i = 0 To myPoints.Count - 1
            'analisis coordenada x
            If myPoints(i).X < 0 Then
                If memindex(0) = -1 Then
                    memindex(0) = i
                ElseIf myPoints(i).X < myPoints(memindex(0)).X Then
                    memindex(0) = i
                End If
            End If
            'analisis coordenada y
            If myPoints(i).Y < 0 Then
                If memindex(1) = -1 Then
                    memindex(1) = i
                ElseIf myPoints(i).Y < myPoints(memindex(1)).Y Then
                    memindex(1) = i
                End If
            End If
        Next
        Return memindex
    End Function
    Public Function cargarmesas(Optional esquema As Boolean = False) As Integer
        cargarmesas = 0
        If Not EsSector Then Exit Function
        Me.PanelArea.Controls.Clear()
        Dim sqlMesas As String = String.Format("Select Id, PosicionX, PosicionY , EsMesa from SD_Mesas where IdSector = {0}", Me.Id)

        Dim TablaMesas As DataTable = cargarConsulta(sqlMesas)
        '   TablaMesas.Compute("Min(X)")
        corx = TablaMesas.Compute("Min(PosicionX)", "EsMesa = 'True'")
        cory = TablaMesas.Compute("Min(PosicionY)", "EsMesa = 'True'")

        For Each Mesa As DataRow In TablaMesas.Rows
            Dim t_mesa As New Mesa(Mesa("Id"))
            t_mesa.Name = "Mesa" & t_mesa.IdMesa
            t_mesa.cargarMesa()
            If t_mesa.Estado = "I" Then Continue For
            t_mesa.DiseñoMesa = Me.Diseño
            t_mesa.esquema = esquema
            t_mesa.AreaMadre = Me
            If Not t_mesa.SoyImagen Then
                cargarmesas = cargarmesas + t_mesa.Capacidad
            End If
            If Not esquema Then
                Me.PanelArea.Controls.Add(t_mesa)
            Else
                t_mesa.BackgroundImage = Nothing
                t_mesa.BackColor = Color.White
                t_mesa.Location = New Point(t_mesa.Location.X - corx _
                                           , t_mesa.Location.Y - cory)
                If Not t_mesa.SoyImagen Then
                    Me.PanelArea.Controls.Add(t_mesa)
                End If

            End If
            AddHandler t_mesa.ClickMesa, AddressOf Me.Area_ClickMesa
            AddHandler t_mesa.DobleClickMesa, AddressOf Me.Area_DobleClickMesa
            AddHandler t_mesa.FueraMesa, AddressOf Me.cargarmesas
            AddHandler t_mesa.UpdateMesa, AddressOf Me.ActualizaMesa

        Next

    End Function
    Public Sub verificarEstados()
        Try
            bwEstados.RunWorkerAsync()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Estados_Mesas()
        Dim Estados As DataTable = cargarConsulta(String.Format("EXEC SDSP_CalcularEstados {0}", Me.Id))
        If Not IsNothing(Estados) Then
            For Each ctl As Control In Me.PanelArea.Controls
                If ctl.GetType() = GetType(Mesa) Then
                    Dim ctlmesa As Mesa = ctl
                    If Not ctlmesa.SoyImagen And ctlmesa.Estado <> "I" Then
                        ctlmesa.estadosActivos.Clear()
                        Dim estadosMesa() As DataRow = Estados.Select(String.Format("idMesa={0}", ctlmesa.IdMesa))
                        If estadosMesa.Count > 0 Then
                            ctlmesa.BackColor = Color.Transparent
                        Else
                            ctlmesa.BackColor = ctlmesa.colorcito
                        End If
                        For Each estado As DataRow In estadosMesa
                            ctlmesa.estadosActivos.Add(New EstadoCuenta(estado("Color"), estado("Dsc")))
                        Next
                    End If
                End If
            Next
        End If
    End Sub



    Sub ActualizaMesa(ByVal sender As Mesa)
        GuardarArea(True)
    End Sub


    Private Sub ModificarElementosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarElementosToolStripMenuItem.Click
        Dim frmDiseño As New Esquematizador
        frmDiseño.cargarTodo(Me.Id)
        frmDiseño.Show()
        frmDiseño.Focus()
    End Sub


    Private Sub MenuSector_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MenuSector.Opening
        If Diseño Then
            e.Cancel = True
        End If
    End Sub



    Private Sub menuArea_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles menuArea.Opening
        If Not Diseño Or PegandoElemento Then
            e.Cancel = True
        End If
    End Sub


    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        If IsNothing(auxetiqueta) Then Exit Sub
        PegarElemento(tipoElemento.texto)
    End Sub

    Private Sub MenuEtiquetas_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MenuEtiquetas.Opening
        If Not Diseño Or PegandoElemento Then
            e.Cancel = True
        End If
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        If IsNothing(auxetiqueta) Then Exit Sub
        If MsgBox("Se eliminara la etiqueta " & auxetiqueta.Text & ". ¿Desea continuar?", MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
            eliminarEtiqueta(auxetiqueta.Tag)
            auxetiqueta = Nothing
        End If
        cargarTodo()
    End Sub
    Sub eliminarEtiqueta(ByVal argIdEtq As Integer)
        Dim sqlborrar As String = String.Format("Delete from SD_textos where id = {0}", argIdEtq)
        EjecutarConsulta(sqlborrar)
    End Sub

    Enum tipoElemento
        texto
        imagen
        mesa
    End Enum
    Public Sub PegarElemento(ByVal argTipoElemento As tipoElemento)
        Select Case argTipoElemento
            Case tipoElemento.texto
                loquesepega.resultado = FontDialog1.ShowDialog()
            Case tipoElemento.imagen
                loquesepega.resultado = DialogoImagen.ShowDialog
            Case tipoElemento.mesa
                CDPropiedadesMesa.ElementoMesa.cargarMesa()
                loquesepega.resultado = CDPropiedadesMesa.ShowDialog
            Case Else
                loquesepega.resultado = Nothing
        End Select
        If loquesepega.resultado = Windows.Forms.DialogResult.OK Then
            loquesepega.tipo = argTipoElemento
            PanelArea.Cursor = Cursors.Cross
            PegandoElemento = True
        Else
            loquesepega.tipo = Nothing
            cargarTodo()
        End If
    End Sub

    Private Sub PanelArea_Click(sender As Object, e As MouseEventArgs) Handles PanelArea.Click
        ' intervencion del evento para pegar si esta en modo de cruz
        Dim puntoPegar As Point = e.Location
        If Not PegandoElemento Then Exit Sub 'entro solo si esta pegandose algun elemento
        'solo si es boton left quiero pegar
        PanelArea.Cursor = Cursors.Default
        If e.Button = Windows.Forms.MouseButtons.Left Then
            'quito bandera
            PegandoElemento = False
            Edicion = False
            Select Case loquesepega.tipo
                Case tipoElemento.imagen
                    Dim sqlNuevaImagen As New SqlBatch()
                    Dim tamaño As Size = New Size(60, 60)
                    If System.IO.File.Exists(DialogoImagen.FileName) Then
                        sqlNuevaImagen.AddFormat("Insert into SD_Mesas (IdSector, IdArea, Alias, PosicionX, PosicionY, Circular, Ancho, Altura, Capacidad, Textura) " _
                                                     & "values ({0}, 1,'',{1}, {2}, 'False', {3}, {4}, 0, '{5}')", _
                                                     Id, puntoPegar.X, puntoPegar.Y, tamaño.Width, tamaño.Height, DialogoImagen.SafeFileName)
                        If sqlNuevaImagen.Execute(CStr(Cn_x_Defecto)) > 0 Then
                            If Not System.IO.File.Exists(Application.StartupPath & "\BMPs\Texturas\" & DialogoImagen.SafeFileName) Then
                                System.IO.File.Copy(DialogoImagen.FileName, Application.StartupPath & "\BMPs\Texturas\" & DialogoImagen.SafeFileName)
                            End If
                        End If
                    End If
                Case tipoElemento.mesa
                    Dim sqlNuevaMesa As New SqlBatch()
                    Dim tamaño As Size = New Size(60, 60)
                    If System.IO.File.Exists(Application.StartupPath & "\BMPs\Texturas\" & CDPropiedadesMesa.textura) Then
                        sqlNuevaMesa.AddFormat("Insert into SD_Mesas (IdSector, IdArea, Alias, PosicionX, PosicionY, Circular,  Ancho, Altura, Capacidad, Textura,EsMesa, NumAlias) " _
                                                     & "values ({0}, 1,'{6}',{1}, {2}, '{7}',  {3}, {4}, {8}, '{5}', 1, (select isnull(Max(numAlias),0)+1 from SD_Mesas WHERE (SD_Mesas.EsMesa = 1)) )",
                                                     Id, puntoPegar.X, puntoPegar.Y, tamaño.Width, tamaño.Height,
                                                     CDPropiedadesMesa.textura, IIf(CDPropiedadesMesa._AliasMesa = "", "Mesa SN", CDPropiedadesMesa._AliasMesa), CDPropiedadesMesa.circular, CDPropiedadesMesa.Capacidad)
                        If sqlNuevaMesa.Execute(CStr(Cn_x_Defecto)) < 1 Then
                            MsgBox("Error al insertar nueva Mesa")
                        End If
                    End If
                Case tipoElemento.texto
                    Dim agregalabel As String = ""
                    If Not IsNothing(auxetiqueta) Then 'para modificar
                        agregalabel = auxetiqueta.Text
                    End If
                    'tomo la cadena de contenido de la etiqueta
                    agregalabel = InputBox("Ingrese el texto a insertar", agregalabel)
                    'solo agrego si no es vacia
                    If agregalabel <> "" Then
                        Dim sqllabel As New SqlBatch()
                        sqllabel.AddFormat("Insert  into SD_Textos (idArea, Texto, font_name, font_size,  font_Bold,  font_Italic, font_strikeout, font_underline, x, y) values " _
                                                               & "({0}, '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}', {8}, {9})", _
                                                              Id, agregalabel, FontDialog1.Font.Name, FontDialog1.Font.SizeInPoints, _
                                                               FontDialog1.Font.Bold, FontDialog1.Font.Italic, FontDialog1.Font.Strikeout, FontDialog1.Font.Underline, puntoPegar.X, puntoPegar.Y)
                        sqllabel.Execute(CStr(Cn_x_Defecto))
                    End If
                    If Not IsNothing(auxetiqueta) Then 'para modificar
                        eliminarEtiqueta(auxetiqueta.Tag)
                        auxetiqueta = Nothing
                    End If
                Case Else
                    MsgBox("Bienvenido a la region desconocida!!!!!") 'jamas deberia llegar a esta linea :D
                    End
            End Select
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            'quito las banderas para salir del modo de edicion
            PegandoElemento = False
            Edicion = False
        End If
        'de cualquier manera debo de retornar todo a su forma original
        cargarTodo()
    End Sub
    Public Function cargarTodo(Optional argid As Integer = -1) As Integer
        Dim ret As Integer = 0
        Me.Visible = False
        destruir(PanelArea)
        construirpanel()
        '  suspenderLayout(Me)
        If argid <> -1 Then
            cargarSector(argid)
        Else
            cargarSector(Me.Id)
        End If
        ret = cargarmesas(Me.EsEsquema)
        Me.ResumeLayout(False)
        If Not EsEsquema Then
            cargarEtiquetas()
        End If
        Me.ResumeLayout(False)
        Me.Visible = True
        PanelArea.Scale(New System.Drawing.SizeF(escala, escala))
        Me.ResumeLayout(False)
        LiberarMemoria()
        Me.PerformLayout()
        resumirLayout(Me)
        Me.Refresh()
        Return ret



    End Function


    Sub construirpanel()
        Me.PanelArea = New Panel()
        Me.PanelArea.AutoScroll = True
        Me.PanelArea.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PanelArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelArea.ContextMenuStrip = Me.menuArea
        Me.PanelArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelArea.Location = New System.Drawing.Point(0, 0)
        Me.PanelArea.Name = "PanelArea"
        ' Me.PanelArea.Size = New System.Drawing.Size(148, 131)
        Me.PanelArea.TabIndex = 0
        Me.Controls.Add(PanelArea)
    End Sub


    Class resultadoC
        Public resultado As New DialogResult 'el objeto que se va a pegar cuando esta editandose
        Public tipo As tipoElemento
        Sub New()
            resultado = New DialogResult
        End Sub

    End Class
    Public Sub Area_ClickMesa(argMesa As Mesa)
        RaiseEvent ClicMesaEsquema(argMesa)
    End Sub
    Public Sub Area_DobleClickMesa(argMesa As Mesa)
        RaiseEvent DoubleClicMesa(argMesa)
    End Sub


    Private Sub MoverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoverToolStripMenuItem.Click
        auxetiqueta.Cursor = Cursors.SizeAll
        allowMove = True 'bandera del move
    End Sub

    Private Sub ColorDeTextoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorDeTextoToolStripMenuItem.Click
        If CDColor.ShowDialog <> DialogResult.Cancel Then
            auxetiqueta.ForeColor = CDColor.Color
        End If
    End Sub
    Public Sub escalarMiniatura(ByVal factor As SizeF)
        ' MinSector.PanelArea.Scale(New SizeF((MinSector.Height / ), _
        '                     (MinSector.Width / Math.Abs(MinSector.PanelArea.Region.GetBounds(Me.CreateGraphics).Right))))
        Me.PanelArea.Scale(factor)
        'If fSize.Height <= fSize.Width Then
        '    Minsector.Scale(New SizeF(fSize.Height, fSize.Height))
        'Else
        '    Minsector.Scale(New SizeF(fSize.Width, fSize.Width))
        'End If
    End Sub
    Private Sub ColorDeFondoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorDeFondoToolStripMenuItem.Click
        If CDColor.ShowDialog <> DialogResult.Cancel Then
            auxetiqueta.BackColor = CDColor.Color
        End If
    End Sub

    Private Sub PropiedadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropiedadesToolStripMenuItem.Click
        Dim frmArea As New AreaDialog
        frmArea.cargarTodo(Me.Id)
        If frmArea.ShowDialog = DialogResult.OK Then
            Me.Nombre = frmArea._Name
            Me.Descripcion = frmArea.Desc
            Me.PanelArea.BackColor = frmArea.ColorFondo
            Me.ImgFondo = frmArea.Textura
            Me.BackLayout = frmArea.backlay
            Me.BackgroundImageLayout = frmArea.backlay
            Me.sizeFondo = New Size(frmArea.W_IMgTam, frmArea.H_IMgTam)
            Me.ImagenFondo.Images.Clear()
            Me.ImagenFondo.ImageSize = Me.sizeFondo
            If Me.ImgFondo = "" Then
                Me.PanelArea.BackgroundImage = Nothing
            Else
                Me.ImagenFondo.Images.Add(Image.FromFile(Application.StartupPath & "\BMPs\Texturas\" & Me.ImgFondo))
                Me.PanelArea.BackgroundImageLayout = Me.BackLayout
                Me.PanelArea.BackgroundImage = ImagenFondo.Images(0)
            End If




        End If
    End Sub


    Private Sub PanelArea_Click(sender As Object, e As EventArgs) Handles PanelArea.Click

    End Sub

    Private Sub Area_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

    End Sub

    Private Sub bwEstados_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwEstados.DoWork
        Estados_Mesas()
    End Sub
End Class


