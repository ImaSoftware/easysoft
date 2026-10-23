Imports System.Data
Imports System.Threading
Imports System.Speech.Recognition
Imports System.Speech.Synthesis


Public Class Comandas
    Inherits DolphinCtl
    Dim miniOrdenes As List(Of miniOrden) = New List(Of miniOrden)
    Dim sc_Nav As Integer = 0
    Dim loading As Boolean = False
    Dim SelectedMini As miniOrden
    Dim margen_x = 10
    Dim margen_y = 10
    Dim hiloord As Thread
    Dim ordenesDtt As DataTable = Nothing
    Dim ordenes As List(Of ordStruc) = New List(Of ordStruc)
    Dim ordTemp As List(Of ordStruc) = New List(Of ordStruc)
    Public noCocina As Integer = 0
    Dim ptoInsertar As System.Drawing.Point = New System.Drawing.Point(margen_x, margen_y)
    Dim posX As Integer = 0
    Dim offset As Point
    Dim btnDown As Boolean = False
    Dim dttMini As DataTable = New DataTable
    Dim treeview1 As New TreeView()
    Dim treeExpa As Boolean = False
    Dim escuchando As Boolean = False
    Dim unaCarga As Boolean = False
    Dim reconocimiento_de_voz As SpeechRecognitionEngine
    Dim synth As SpeechSynthesizer = New SpeechSynthesizer()
    Dim TablaOrdenVoz As DataTable = New DataTable()
    Sub New()
        Dim idC As DataColumn = New DataColumn("id", GetType(Integer))
        TablaOrdenVoz.Columns.Add(idC)
        TablaOrdenVoz.PrimaryKey = New DataColumn() {idC}
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.noTema = True
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        treeview1.Visible = False
    End Sub
    Overloads Sub loader()
        Me.Visible = True
    End Sub

    'Delegate Sub moverOrdenCallBack(ByVal orden As Orden, newLoc As Point)
    'Public Sub _moverOrden(ByVal Item As Orden, newLoc As Point)
    '    If Item.InvokeRequired Then
    '        Dim d As New moverOrdenCallBack(AddressOf _moverOrden)
    '        Me.Invoke(d, New Object() {Item, newLoc})
    '    Else
    '        Item.Location = newLoc
    '    End If
    'End Sub
    Delegate Sub cargarOrdenesCallBack(idCocina As Integer, start_idC As Integer)
    Public Sub _cargarOrdenes(idCocina As Integer, Optional start_idC As Integer = -1)
        If pnlOrd.InvokeRequired Then
            Dim d As New cargarOrdenesCallBack(AddressOf _cargarOrdenes)
            Me.Invoke(d, New Object() {idCocina, start_idC})
        Else
            cargarOrdenes(idCocina, start_idC)
        End If
    End Sub

    Private Sub Comandas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loading = True
        Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-ES")
        Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es-ES")
        btnEscucha.PerformClick()
        ' synth.SelectVoiceByHints(VoiceGender.Female)
        pnlNav.RowTemplate.Height = Me.Button1.Height - 2
        cargarOrdenes(1, True)

        GetOrders.Interval = 5000
        GetOrders.Start()
        NomCocina.BackColor = ColorSecundario
        loading = False
        If miniOrdenes.Count > 0 Then
            miniOrdenes.ElementAt(0).lblOrden.PerformClick()
            miniOrdenes.ElementAt(0).Focus()
        End If
        pnlNav.DataSource = dttMini
        '  pnlNav.Refresh()

    End Sub
    Function setEscucha() As Boolean
        Try
            reconocimiento_de_voz = New SpeechRecognitionEngine(New System.Globalization.CultureInfo("es-ES"))
            Dim phrases As String() = New String() {Globales.Parametros.nombreAsistente.Trim(), "hola " + Globales.Parametros.nombreAsistente.Trim(), "aldelo", "comandos ayuda", "lista", "oculta resumen", "muestra resumen", "expande resumen", "contrae resumen", "cerrar módulo", "cerrar aplicacion", "si", "no", "activar voz", "desactivar voz"}
            Dim choiceSet As Choices = New Choices(phrases)
            Dim GrammarBuilder As GrammarBuilder = New GrammarBuilder(choiceSet)
            GrammarBuilder.Culture = reconocimiento_de_voz.RecognizerInfo.Culture
            Dim myGrammar As Grammar = New Grammar(GrammarBuilder)
            myGrammar.Priority = 127
            reconocimiento_de_voz.SetInputToDefaultAudioDevice()
            reconocimiento_de_voz.LoadGrammar(myGrammar)
            AddHandler reconocimiento_de_voz.SpeechRecognized, AddressOf dijisteAlgo
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        Return True
    End Function
    Sub arrancaEscucha()
        reconocimiento_de_voz.RecognizeAsync(RecognizeMode.Multiple)
        keyBoca = "boca.png"
        btnEscucha.ImageKey = keyBoca
        ToolTip1.SetToolTip(btnEscucha, "Comandos por voz activado")
    End Sub
    Dim esperaLista As Boolean = False
    Dim esperaConf As Boolean = False
    Dim confSalir As Boolean = False
    Dim confCerrar As Boolean = False
    Dim endijiste As Boolean = False
    Dim keyBoca As String = "boca.png"
    Sub dijisteAlgo(sender As Object, e As SpeechRecognizedEventArgs)
        If Not escuchaHabilitada Then Exit Sub
        If endijiste Then Exit Sub
        endijiste = True
        'Comandos con Nombre
        If meLLamaron Then
            If e.Result.Text.ToUpper.Trim().Equals("ACTIVAR VOZ") Then
                keyBoca = "boca.png"
                btnEscucha.ImageKey = keyBoca
                synth.Volume = 100
            ElseIf e.Result.Text.ToUpper.Trim().Equals("DESACTIVAR VOZ") Then
                keyBoca = "noboca.png"
                btnEscucha.ImageKey = keyBoca
                synth.Volume = 0
            ElseIf e.Result.Text.ToUpper.Trim().Equals("OCULTA RESUMEN") Then
                If treeview1.Visible Then
                    btnS_Res.PerformClick()
                End If
            ElseIf e.Result.Text.ToUpper.Trim().Equals("MUESTRA RESUMEN") Then
                If Not treeview1.Visible Then
                    btnS_Res.PerformClick()
                End If
            ElseIf e.Result.Text.ToUpper.Trim().Equals("EXPANDE RESUMEN") Then
                If Not treeExpa Then
                    btnShrink.PerformClick()
                End If
            ElseIf e.Result.Text.ToUpper.Trim().Equals("CONTRAE RESUMEN") Then
                If treeExpa Then
                    btnShrink.PerformClick()
                End If
            ElseIf existeMini(Convert.ToInt64(e.Result.Semantics.Value)) Then
                'DIJO LA ORDEN Y EL NUMERO
                NomCocina.Text = e.Result.Text.ToUpper()
                pnlNav.CurrentCell = pnlNav.Rows(0).Cells(e.Result.Semantics.Value.ToString())
                clickMini(e.Result.Semantics.Value)
                waitinLista.Interval = Globales.Parametros.esperaAsistente
                waitinLista.Stop()
                waitinLista.Start()
                esperaLista = True
            ElseIf e.Result.Text.ToUpper.Trim().Equals("CERRAR APLICACION") Then
                Habla("¿Está seguro de que desea cerrar la aplicacion?")
                waitinConf.Interval = Globales.Parametros.esperaAsistente
                waitinConf.Stop()
                waitinConf.Start()
                esperaConf = True
                confSalir = True
            ElseIf e.Result.Text.ToUpper.Trim().Equals("CERRAR MÓDULO") Then
                Habla("¿Está seguro de cerrar la ventana de producción?")
                waitinConf.Interval = Globales.Parametros.esperaAsistente
                waitinConf.Start()
                esperaConf = True
                confCerrar = True
            ElseIf e.Result.Text.ToUpper.Trim().Equals("COMANDOS AYUDA") Then
                Habla("Los comandos disponibles son: COMANDOS AYUDA, oculta resumen, muestra resumen, expande resumen, contrae resumen, cerrar ventana, cerrar aplicacion , activar voz, desactivar voz,  y , orden lista")
            End If
        End If
        'Comandos sin  Nombre
        If e.Result.Text.ToUpper.Trim().Equals("LISTA") Then
            If esperaLista Then
                Dim seleOrd As Orden = buscaOrden(pnlNav.Columns(pnlNav.CurrentCell.ColumnIndex).DataPropertyName)
                If (IsNothing(seleOrd)) Then
                    seleOrd = New Orden(pnlNav.Columns(pnlNav.CurrentCell.ColumnIndex).DataPropertyName, 10, 10)
                End If
                seleOrd.chkOrden.Checked = True
                esperaLista = False
                Habla("Orden lista")
            End If
        ElseIf e.Result.Text.ToUpper.Trim().Equals(Globales.Parametros.nombreAsistente.Trim().ToUpper()) Then
            'DIJO EL NOMBRE A ESCUCHAR
            btnEscucha.ImageKey = "oreja.png"
            waitinComando.Interval = Globales.Parametros.esperaAsistente
            waitinComando.Stop()
            waitinComando.Start()
            NomCocina.Text = "Escuchando..."
            meLLamaron = True
        ElseIf e.Result.Text.ToUpper.Trim().Equals("HOLA " + Globales.Parametros.nombreAsistente.Trim().ToUpper()) Then
            Habla("Hola usuario, estoy aqui para ayudarle. Diga mi nombre y el comando que desea ejecutar y lo interpretaré lo mejor posible")
            'ElseIf e.Result.Text.ToUpper.Trim().Equals("ALDELO") Then
            '    synth.Volume = 100
            '    synth.Speak("Me has ofendido maldito insecto, SOY MUUCHO MEJOR QUE ESE PROGRAMA CHIMBA. ADIOS PUERCO INMUNDO")
            '    Environment.Exit(0)
        ElseIf e.Result.Text.ToUpper.Trim().Equals("SI") Then
            If esperaConf Then
                If confSalir Then
                    'cierra ventana
                    Habla("Cerrando A L P SAAB. Adios")
                    Me.ParentForm.Close()
                    confSalir = False
                ElseIf confCerrar Then
                    Habla("Cerrando ventana de Producción. Hasta Luego")
                    If Me.ParentForm.GetType.Equals(GetType(Principal)) Then
                        DirectCast(Me.ParentForm, Principal).CerrarControlActual(Me, New EventArgs())
                    Else
                        Me.ParentForm.Close()
                    End If
                    confCerrar = False
                End If
            End If
        ElseIf e.Result.Text.ToUpper.Trim().Equals("NO") Then
            If esperaConf Then
                Habla("Comando Cancelado")
                waitinConf_Tick(Me, New EventArgs())
            End If
        End If
        endijiste = False
    End Sub
    Private Sub waitinConf_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles waitinConf.Tick
        waitinConf.Stop()
        If esperaConf Then
            If confCerrar Then confCerrar = False
            If confSalir Then confSalir = False
            If Not confSalir And Not confCerrar Then esperaConf = False
        End If
        Habla("Comando Cancelado")
        endijiste = False
    End Sub
    Sub correHilo()
        Dim sqlestados As String = String.Format("EXEC dbo.SDSP_OrdenesCocina @noCocina= {0}, @ultId= {1}, @resPlat= 0 ",
                                                  Me.noCocina.ToString.Trim(), -1)
        Dim dtt As DataTable = cargarConsulta(sqlestados)
        Dim dttRes As DataTable = getDifferentRecords(dtt, ordenesDtt)
        If dttRes.Rows.Count > 0 Then
            Dim recargar As Boolean = False
            For Each dr As DataRow In dttRes.Rows
                If dr.Item("Accion").ToString = "A" Then
                    recargar = True

                ElseIf dr.Item("Accion").ToString = "D" Then
                    borraLista(dr.Item("idComanda"))
                    recargar = True
                End If
            Next
            If recargar Then
                ordenesDtt = dtt
                If pnlOrd.Controls.Count > 0 Then
                    Dim ctlOrd As Orden = pnlOrd.Controls(0)
                    _cargarOrdenes(Me.noCocina, ctlOrd.IDCabeceraComanda)
                Else
                    _cargarOrdenes(Me.noCocina)
                End If
            End If
        End If
        'un forazo para los consumos con visto 
        For Each oO As Orden In pnlOrd.Controls
            If oO.Visible Then
                oO.reordenar()
                oO.ajustarAlto()
            End If
        Next
        ordenesDtt = dtt
        hiloord = Nothing

    End Sub


    Public Function getDifferentRecords(FirstDataTable As DataTable, SecondDataTable As DataTable) As DataTable
        'Create Empty Table   
        Dim ResultDataTable As New DataTable("ResultDataTable")
        'use a Dataset to make use of a DataRelation object   
        Using ds As New DataSet()
            'Add tables   
            ds.Tables.AddRange(New DataTable() {FirstDataTable.Copy(), SecondDataTable.Copy()})

            'Get Columns for DataRelation   
            Dim firstColumns As DataColumn() = New DataColumn(ds.Tables(0).Columns.Count - 1) {}
            For i As Integer = 0 To firstColumns.Length - 1
                firstColumns(i) = ds.Tables(0).Columns(i)
            Next

            Dim secondColumns As DataColumn() = New DataColumn(ds.Tables(1).Columns.Count - 1) {}
            For i As Integer = 0 To secondColumns.Length - 1
                secondColumns(i) = ds.Tables(1).Columns(i)
            Next

            'Create DataRelation   
            Dim r1 As New DataRelation(String.Empty, firstColumns, secondColumns, False)
            ds.Relations.Add(r1)

            Dim r2 As New DataRelation(String.Empty, secondColumns, firstColumns, False)
            ds.Relations.Add(r2)

            'Create columns for return table   
            For i As Integer = 0 To FirstDataTable.Columns.Count - 1
                ResultDataTable.Columns.Add(FirstDataTable.Columns(i).ColumnName, FirstDataTable.Columns(i).DataType)
            Next
            ResultDataTable.Columns.Add("Accion", System.Type.GetType("System.String"))
            'If FirstDataTable Row not in SecondDataTable, Add to ResultDataTable.   
            'Es nueva=> agregar
            ResultDataTable.BeginLoadData()
            For Each parentrow As DataRow In ds.Tables(0).Rows
                Dim childrows As DataRow() = parentrow.GetChildRows(r1)
                If childrows Is Nothing OrElse childrows.Length = 0 Then
                    ResultDataTable.Rows.Add(parentrow.ItemArray(0), "A")
                End If
            Next
            'If SecondDataTable Row not in FirstDataTable, Add to ResultDataTable.  
            'ya no existe => eliminar
            For Each parentrow As DataRow In ds.Tables(1).Rows
                Dim childrows As DataRow() = parentrow.GetChildRows(r2)
                If childrows Is Nothing OrElse childrows.Length = 0 Then
                    ResultDataTable.Rows.Add(parentrow.ItemArray(0), "D")
                End If
            Next
            ResultDataTable.EndLoadData()
        End Using

        Return ResultDataTable
    End Function


    Private Sub GetOrders_Tick(sender As Object, e As EventArgs) Handles GetOrders.Tick

        GetOrders.Stop()
        GetOrders.Interval = 5000
        GetOrders.Start()
        If Not IsNothing(hiloord) Then Exit Sub
        ' If hiloord.ThreadState = ThreadState.Running Then Exit Sub
        Dim hilo As Thread = New Thread(AddressOf Me.correHilo)
        hiloord = hilo
        hilo.Start()
        Dim hiloVoz As Thread = New Thread(AddressOf Me.añade_recoOrden)
        hiloVoz.Start()
    End Sub
    Sub mueveOrdenes()
        Return
        If ordenes.Count = 0 Then Return
        'lanzador de hilos
        ' Dim ordBorrar As ordStruc
        For Each inst As ordStruc In ordenes
            If inst.orden.Visible = False Then
                Continue For
            End If
            'If IsNothing(inst.orden.Parent) Then
            '    ordBorrar = inst
            '    Exit For
            'End If
            'Se da de baja la animacion porque consume demasiados recursos
            'inst.orden.Location = inst.newLoc
            'inst.hilo = Nothing
            'Dim hilo As Thread = New Thread(AddressOfa Me.moverOrden)
            'inst.hilo = hilo
            'hilo.Start(inst)
        Next
        Dim hilo_fin As Thread = New Thread(AddressOf Me.miraleesehilo)
        hilo_fin.Start()
        'ordenes.Remove(ordBorrar)

    End Sub
    Sub miraleesehilo()
        'A veces los hilos mueren sin terminar su trabajo, o se superponen los resultados 
        ' así que cuando ya todos esten muertos voy a ubicarlos en su posición final original
        Dim salir As Boolean = False
        Dim cnt As Integer = 0
        While Not salir
            Dim muertos As Boolean = False
            For i = 0 To ordenes.Count - 1
                Try
                    Dim inst As ordStruc = ordenes.ElementAt(i)
                    If IsNothing(inst.hilo) Then Continue For
                    inst.hilo.Join()
                    'Aqui llega solo cuando ya esté muerto 
                    'Verifico si el punto está donde debe
                    If Not inst.orden.Location.Equals(inst.newLoc) Then
                        inst.hilo = Nothing
                        inst.orden.Location = inst.newLoc
                        Dim hiloN As Thread = New Thread(AddressOf Me.moverOrden)
                        inst.hilo = hiloN
                        hiloN.Start(inst)
                        'moverOrden(inst)
                    End If
                    muertos = muertos Or inst.hilo.IsAlive
                Catch ex As Exception

                End Try
            Next
            'muertos viene en 0 => todos han muerto
            'muertos viene en 1 => alguien sigue vivo
            salir = Not muertos
        End While
        'De aqui solo sale cuando ya todos hallan muerto



    End Sub
    Public Sub moverOrden(inst As ordStruc)
        'Para este algoritmo usaré el modelado de una ecuación de la recta. 
        'Y=mx+Y0; entiendase que m será la pendiente 
        'para exactitud usare m en single
        Dim ptoIni As System.Drawing.Point
        Dim ptoFin As System.Drawing.Point

        ptoIni = inst.orden.Location
        ptoFin = inst.newLoc



        'pto inicial igual a final hace pendiente = NaN -> No es un caso aplicable así que descarto       
        If ptoIni.Equals(ptoFin) Then Return
        'Pto Inicial a distancia menor a 5 px -> Saltemos la animacion
        Dim d As Integer = Math.Sqrt((ptoFin.Y - ptoIni.Y) ^ 2 + (ptoFin.X - ptoIni.X) ^ 2)
        If d <= 5 Then Return

        '1.- calcular la pendiente y el desplazamiento Y0
        Dim m As Single = 0
        Dim _Y0 As Integer = 0
        m = (ptoFin.Y - ptoIni.Y) / (ptoFin.X - ptoIni.X)
        If Not Single.IsInfinity(m) Then 'pendiente infinita describe una recta de tipo x = x1. No tiene contacto con Y0
            'para Y0 podemos usar cualquier punto. Yo usaré el Final
            _Y0 = ptoFin.Y - (m * ptoFin.X)
        End If
        'Se recorre el desplazamiento haciendo como variable de recorrido al eje x y la calculada solo la y
        Dim desp_x As Integer = Math.Abs(ptoFin.X - ptoIni.X)
        Dim desp_y As Integer = Math.Abs(ptoFin.Y - ptoIni.Y)
        Dim var_desp As Integer
        'If Single.IsInfinity(m) Then 'OTRA FORMA 
        '    var_desp = desp_y
        'Else
        '    var_desp = desp_x
        'End If
        Dim ptoNuevo As System.Drawing.Point = New System.Drawing.Point(margen_x, margen_y)
        var_desp = IIf(desp_x > desp_y, desp_x, desp_y) 'Escojo siempre el mayor
        For i = 1 To var_desp Step Globales.Parametros.velocidad_Orden

            Dim posY, posX As Integer

            If desp_x > desp_y Then ' If Not Single.IsInfinity(m) Then
                posY = (m * (IIf(ptoIni.X > ptoFin.X, ptoIni.X - i, ptoIni.X + i))) + _Y0
                If ptoIni.X > ptoFin.X Then
                    ptoNuevo = New System.Drawing.Point(ptoIni.X - i, posY)
                Else
                    ptoNuevo = New System.Drawing.Point(ptoIni.X + i, posY)
                End If
            Else
                If Single.IsInfinity(m) Then
                    posX = ptoIni.X
                Else
                    posX = (IIf(ptoIni.Y > ptoFin.Y, ptoIni.Y - i, ptoIni.Y + i) - _Y0) / m
                End If

                If ptoIni.Y > ptoFin.Y Then
                    ptoNuevo = New System.Drawing.Point(posX, ptoIni.Y - i)
                Else
                    ptoNuevo = New System.Drawing.Point(posX, ptoIni.Y + i)
                End If
            End If
            If Not inst.orden.Visible Then Continue For
            'Me._moverOrden(inst.orden, ptoNuevo)
            inst.orden.Location = ptoNuevo
            Thread.Sleep(50)
        Next
salida:
        inst.orden.Location = ptoFin
    End Sub
    Public Sub mover_miniOrden(inst As miniOrden)
        inst.Location = inst.mini_newLoc
        Return
        'Para este algoritmo usaré el modelado de una ecuación de la recta. 
        'Y=mx+Y0; entiendase que m será la pendiente 
        'para exactitud usare m en single
        Dim ptoIni As System.Drawing.Point
        Dim ptoFin As System.Drawing.Point

        ptoIni = inst.Location
        ptoFin = inst.mini_newLoc

        'pto inicial igual a final hace pendiente = NaN -> No es un caso aplicable así que descarto       
        If ptoIni.Equals(ptoFin) Then Return
        'Pto Inicial a distancia menor a 5 px -> Saltemos la animacion
        Dim d As Integer = Math.Sqrt((ptoFin.Y - ptoIni.Y) ^ 2 + (ptoFin.X - ptoIni.X) ^ 2)
        If d <= 5 Then Return

        '1.- calcular la pendiente y el desplazamiento Y0
        Dim m As Single = 0
        Dim _Y0 As Integer = 0
        m = (ptoFin.Y - ptoIni.Y) / (ptoFin.X - ptoIni.X)
        If Not Single.IsInfinity(m) Then 'pendiente infinita describe una recta de tipo x = x1. No tiene contacto con Y0
            'para Y0 podemos usar cualquier punto. Yo usaré el Final
            _Y0 = ptoFin.Y - (m * ptoFin.X)
        End If
        'Se recorre el desplazamiento haciendo como variable de recorrido al eje x y la calculada solo la y
        Dim desp_x As Integer = Math.Abs(ptoFin.X - ptoIni.X)
        Dim desp_y As Integer = Math.Abs(ptoFin.Y - ptoIni.Y)
        Dim var_desp As Integer
        'If Single.IsInfinity(m) Then 'OTRA FORMA 
        '    var_desp = desp_y
        'Else
        '    var_desp = desp_x
        'End If
        Dim ptoNuevo As System.Drawing.Point = New System.Drawing.Point(margen_x, margen_y)
        var_desp = IIf(desp_x > desp_y, desp_x, desp_y) 'Escojo siempre el mayor
        For i = 1 To var_desp Step Globales.Parametros.velocidad_Orden

            Dim posY, posX As Integer

            If desp_x > desp_y Then ' If Not Single.IsInfinity(m) Then
                posY = (m * (IIf(ptoIni.X > ptoFin.X, ptoIni.X - i, ptoIni.X + i))) + _Y0
                If ptoIni.X > ptoFin.X Then
                    ptoNuevo = New System.Drawing.Point(ptoIni.X - i, posY)
                Else
                    ptoNuevo = New System.Drawing.Point(ptoIni.X + i, posY)
                End If
            Else
                If Single.IsInfinity(m) Then
                    posX = ptoIni.X
                Else
                    posX = (IIf(ptoIni.Y > ptoFin.Y, ptoIni.Y - i, ptoIni.Y + i) - _Y0) / m
                End If

                If ptoIni.Y > ptoFin.Y Then
                    ptoNuevo = New System.Drawing.Point(posX, ptoIni.Y - i)
                Else
                    ptoNuevo = New System.Drawing.Point(posX, ptoIni.Y + i)
                End If
            End If
            inst.Location = ptoNuevo
            Thread.Sleep(50)
        Next
salida:

        inst.Location = ptoFin

    End Sub
    Sub VolarOrden(sender As Orden, e As EventArgs)
        pnlOrd.Controls.Remove(sender)   'Eliminar del panel de ordenes
        borraLista(sender.IDCabeceraComanda) 'Borrar de la lista
        reordenar()
    End Sub
    Sub borraLista(id As Integer, Optional noBorrarMini As Boolean = False)
        Dim ctlStr As ordStruc = buscaInst(id)
        If Not IsNothing(ctlStr) Then
            ordenes.Remove(ctlStr)
        End If
        If Not noBorrarMini Then
            If existeMini(id) Then
                dttMini.Columns.Remove(dttMini.Columns(id.ToString))
            End If
            pnlNav.DataSource = dttMini
        End If
    End Sub

    Function buscaInst(noCom As Integer) As ordStruc
        Dim res As ordStruc = Nothing
        For Each inst As ordStruc In ordenes
            If inst.orden.IDCabeceraComanda = noCom Then
                res = inst
                Exit For
            End If
        Next
        Return res
    End Function

    Sub clickMini(ByVal idC As Integer)
        Dim pnlFF = pnlOrd.Controls.Find("ord" & idC, False)
        If pnlFF.Length = 1 Then
            'está en pantalla. No mover nada 
            Exit Sub
        End If
        'cargar Ordenes posteriores a esta
        cargarOrdenes(Me.noCocina, idC)
    End Sub
    Function buscaIndice(_idC As Integer) As Integer
        Dim ret As Integer = 0
        For i = 0 To ordenes.Count - 1
            If ordenes.ElementAt(i).orden.IDCabeceraComanda < _idC Then
                ret = i
            End If
        Next
        Return ret
    End Function
    Function buscaTemp(_idC As Integer) As ordStruc
        Dim ret As ordStruc = Nothing
        For i = 0 To ordTemp.Count - 1
            If ordTemp.ElementAt(i).orden.IDCabeceraComanda = _idC Then
                ret = ordTemp.ElementAt(i)
                Return ret
            End If
        Next
        Return ret
    End Function
    ''' <summary>
    ''' Recorre la tabla de ordenes y si no han sido representadas las agrega al lienzo.
    ''' También crea las miniOrdenes y las agrega a la barra de navegación
    ''' </summary>
    ''' <param name="idCocina">Identificador de la cocina a mostrar</param>
    ''' <param name="start_idC">Indica el numero inicial para cargar de ordenes </param>
    Public Sub cargarOrdenes(idCocina As Integer, Optional start_idC As Integer = -1)
        Dim PegarControl As Boolean = True
        If start_idC <> -1 Then
            If Not on_Screen(start_idC) Then
                pnlOrd.Controls.Clear()
            End If
        End If
        'Esta funcion se encarga únicamente de colocar las ordenes que se requieren en pantalla 
        'y el resto las dejo en el objeto datatable 
        If Me.noCocina <> idCocina Then
            ordenes.Clear()
            pnlOrd.Controls.Clear() 'Limpio el panel y las referencias a sus controles
            dttMini = New DataTable()
            pnlNav.DataSource = dttMini
            miniOrdenes.Clear()
            SelectedMini = Nothing
            ordenesDtt = Nothing
            ordTemp.Clear()
            Me.noCocina = idCocina 'Actualizo el id de la cocina 
        End If
        If (idCocina > 0) Then
            If IsNothing(ordenesDtt) Then
                Dim sqlestados As String = String.Format("EXEC dbo.SDSP_OrdenesCocina @noCocina= {0}, @ultId= {1}, @resPlat=0 ",
                                                     idCocina.ToString.Trim(), -1)
                ordenesDtt = cargarConsulta(sqlestados)
            End If


            If Not IsNothing(ordenesDtt) Then
                'Aqui tengo cargado todas las órdenes que estan con consumos activos 
                For Each ordenRow As DataRow In ordenesDtt.Rows
                    If Not existeMini(ordenRow("idComanda")) Then
                        'Creo el miniOrden y lo agrego de una
                        agregaMini(ordenRow("idComanda"))
                    End If
                    'Existe en la lista?
                    If Not on_Screen(ordenRow("idComanda")) Then
                        'Creo la orden Nueva
                        If start_idC <> -1 Then If ordenRow("idComanda") < start_idC Then Continue For 'Saltar a la siguiente
                        If PegarControl Then
                            Dim ctlOrden = agregarOrden(ordenRow("idComanda"))
                            pnlOrd.Controls.Add(ctlOrden)
                            ctlOrden.ajustarAlto()
                            reordenar()
                            If ctlOrden.Visible = False Then
                                'borraLista(ctlOrden.IDCabeceraComanda, True)
                                PegarControl = False
                                If Not IsNothing(ctlOrden.Parent) Then pnlOrd.Controls.Remove(ctlOrden)

                            End If
                        End If
                    Else
                        'Si Existe -> Dejelo ahí
                    End If
                Next
                'entraron todos!!!
                'mueveOrdenes()
            End If
        End If

        ' mueveOrdenes()
    End Sub
    Private Function agregarOrden(ByVal idC As Integer) As Orden

        Dim ctlOrden As New Orden(idC, pnlOrd.Height - margen_y, Me.noCocina)
        AddHandler ctlOrden.click_Ok, AddressOf Me.VolarOrden
        ctlOrden.Name = "ord" & idC.ToString
        'Lo agrego a la estructura de ordenes
        Dim ordS As ordStruc = New ordStruc(ctlOrden, ptoInsertar)
        ordenes.Add(ordS)
        Return ctlOrden
    End Function
    Dim enAñadeReco = False
    Sub añade_recoOrden()
        If Not escuchaHabilitada Then Exit Sub
        If enAñadeReco Then Exit Sub
        enAñadeReco = True
        Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-ES")
        Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es-ES")
        Dim idcOrd As Integer = 0
        While ColaVoz.Count > 0
            idcOrd = ColaVoz.Dequeue()
            'Añado la orden a las palabras reconocidas'
            Try
                Dim GrammarBuilder As GrammarBuilder = New GrammarBuilder()
                GrammarBuilder.Culture = reconocimiento_de_voz.RecognizerInfo.Culture
                Dim choiceSet As Choices = New Choices()
                Dim sR As SemanticResultValue = New SemanticResultValue("orden " & FUGSD.enletras(idcOrd.ToString()), idcOrd)
                choiceSet.Add(sR)
                GrammarBuilder.Append(sR)
                Dim myGrammar As Grammar = New Grammar(GrammarBuilder)
                myGrammar.Priority = 127
                reconocimiento_de_voz.LoadGrammar(myGrammar)
            Catch ex As Exception
                MsgBox("Error añadiendo reconocimiento de voz a comanda: " & ex.Message)
            End Try
            TablaOrdenVoz.Rows.Add(idcOrd)
        End While
        enAñadeReco = False
    End Sub
    Dim ColaVoz As New Queue()
    Sub agregaMini(idc As Integer)
        Dim miniR As DataColumn = dttMini.Columns.Add()
        miniR.ColumnName = idc.ToString
        If IsNothing(TablaOrdenVoz.Rows.Find(idc)) Then
            ColaVoz.Enqueue(idc)
        End If
        If dttMini.Rows.Count = 0 Then
            dttMini.Rows.Add()
        End If
        dttMini.Rows(0).Item(idc.ToString) = idc.ToString
        pnlNav.DataSource = dttMini
        pnlNav.Refresh()
    End Sub
    Private Function on_Screen(idComanda As Integer) As Boolean
        'Buscar en la tabla si existe una orden con ese idComanda
        For i = 0 To pnlOrd.Controls.Count - 1
            If TypeOf pnlOrd.Controls(i) Is Orden Then
                Dim ctlOrd As Orden = pnlOrd.Controls(i)
                If ctlOrd.IDCabeceraComanda = idComanda Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function
    Private Function existe_Orden(idComanda As Integer) As Boolean
        'Buscar en la tabla si existe una orden con ese idComanda
        For i = 0 To ordenes.Count - 1
            If ordenes.ElementAt(i).orden.IDCabeceraComanda = idComanda.ToString Then
                Return True
            End If
        Next
        Return False
    End Function

    Function existeMini(ByVal ordId As Integer) As Boolean
        For i = 0 To dttMini.Columns.Count - 1
            If dttMini.Columns(i).ColumnName = ordId Then
                Return True
            End If
        Next
        Return False
    End Function

    Sub sortOrdenes()
        For i = 2 To ordenes.Count
            Dim aux As ordStruc
            For j = 0 To ordenes.Count - i
                If ordenes.ElementAt(j).orden.IDCabeceraComanda > ordenes.ElementAt(j + 1).orden.IDCabeceraComanda Then
                    aux = ordenes.ElementAt(j)
                    ordenes.Item(j) = ordenes.ElementAt(j + 1)
                    ordenes.Item(j + 1) = aux
                End If
            Next
        Next
    End Sub
    ''' <summary>
    ''' Recorre ordenes y las ubica según disponibilidad en pantalla. Tambien las hace visibles
    ''' </summary>
    Public Sub reordenar(Optional ubicarUlt As Boolean = False)

        'Recorrer todas  las ordenes en pantalla y poner visible en false si no entra
        Dim ptoInsertar As New Point(margen_x, margen_y)
        Dim totOrds As Integer = pnlOrd.Controls.Count
        Dim i As Integer = 0
        Dim ultId As Integer = 0
        For Each ord In pnlOrd.Controls
            If TypeOf ord Is Orden Then
                Dim ctlOrd As Orden = ord
                If ubicarUlt Then
                    If i <> totOrds - 1 Then
                        Continue For
                    Else
                        'ptoInsertar = ptoPrueba
                    End If
                End If
                'primero pruebo abajo
                If ptoInsertar.Y + ctlOrd.Height > pnlOrd.Height Then
                    If ptoInsertar.X + ctlOrd.Size.Width > pnlOrd.Width Then
                        'Se pasó en ancho -> hacer invisible
                        ctlOrd.Visible = False
                        Exit For 'No me importa el resto
                    Else
                        ctlOrd.Location = New Point(ptoInsertar.X, margen_y)
                        'correr punto
                        ptoInsertar = New Point(ctlOrd.Location.X + ctlOrd.Size.Width + margen_x, ctlOrd.Location.Y + ctlOrd.Size.Height + margen_x)
                    End If
                Else
                    'ubicar abajo
                    ' ptoInsertar.Y > margen_y Then
                    If ptoInsertar.Y > margen_y Then
                        ctlOrd.Location = New Point(buscaOrden(ultId).Location.X, ptoInsertar.Y)
                    Else
                        ctlOrd.Location = ptoInsertar
                    End If
                    'correr punto
                    ptoInsertar = New Point(ctlOrd.Location.X + ctlOrd.Size.Width + margen_x, ctlOrd.Location.Y + ctlOrd.Size.Height + margen_x)
                End If
                ultId = ctlOrd.IDCabeceraComanda
            End If
            i += 1
        Next
    End Sub
    Function buscaOrden(idc As Integer) As Orden
        For Each ord In pnlOrd.Controls
            Dim ctlOrd As Orden = ord
            If idc = ctlOrd.IDCabeceraComanda Then
                Return ctlOrd
            End If
        Next
        Return Nothing
    End Function
    Dim escuchaHabilitada As Boolean = False
    Private Sub btnEscucha_Click(sender As Object, e As EventArgs) Handles btnEscucha.Click
        If btnEscucha.ImageKey <> "oreja.png" Then
            btnEscucha.ImageKey = "oreja.png"
            escuchaHabilitada = False
            ToolTip1.SetToolTip(btnEscucha, "Activar comandos por voz")
        Else
            Try
                If setEscucha() Then
                    arrancaEscucha()
                    escuchaHabilitada = True
                End If
            Catch ex As Exception
                MsgBox("Comandos por voz no se pudo configurar: " & ex.Message)
                btnEscucha.ImageKey = "oreja.png"
                ToolTip1.SetToolTip(btnEscucha, "Activar comandos por voz")
                escuchaHabilitada = False
            End Try
        End If

    End Sub

    Private Sub btnShrink_Click(sender As Object, e As EventArgs) Handles btnShrink.Click, btnEscucha.Click
        'debo volver a activar esto  Me.reordenar()
        If treeExpa Then
            treeview1.CollapseAll()
        Else
            treeview1.ExpandAll()
        End If
        treeExpa = Not treeExpa
    End Sub

    Private Sub Comandas__botonDelfin() Handles Me._botonDelfin
        Me.reordenar()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs)
        darFoco(+1)
    End Sub

    Sub darFoco(desp As Integer)
        Dim celdaACT As DataGridViewCell = pnlNav.CurrentCell
        If IsNothing(celdaACT) Then Exit Sub
        Dim prueba As Integer = celdaACT.ColumnIndex + desp
        If prueba >= 0 And prueba < pnlNav.ColumnCount Then
            pnlNav.CurrentCell = pnlNav.Item(prueba, 0)
            clickMini(pnlNav.CurrentCell.Value)
        End If
    End Sub



    Private Sub btnPrev_Click(sender As Object, e As EventArgs)
        darFoco(-1)
    End Sub

    Private Sub nextCoci_Click(sender As Object, e As EventArgs) Handles nextCoci.Click
        If cocinaExiste(Me.noCocina + 1) Then
            Me.cargarOrdenes(Me.noCocina + 1, True)
        End If
    End Sub

    Private Sub prevCoci_Click(sender As Object, e As EventArgs) Handles prevCoci.Click
        If Me.noCocina - 1 = 0 Then Exit Sub
        If cocinaExiste(Me.noCocina - 1) Then
            Me.cargarOrdenes(Me.noCocina - 1, True)
        End If
    End Sub
    Function cocinaExiste(_idCocina As Integer) As Boolean
        Dim ret As Boolean = False
        Dim sqlExiste As String = String.Format("Select NombreCocina from SD_Cocinas where idCocina = {0}", _idCocina.ToString.Trim())
        Dim dtt As DataTable = cargarConsulta(sqlExiste)
        If Not IsNothing(dtt) Then
            If dtt.Rows.Count = 1 Then
                Me.NomCocina.Text = dtt.Rows(0)(0)
                Return True
            End If
        End If
        Return ret
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        darFoco(+1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        darFoco(-1)
    End Sub

    Private Sub pnlNav_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles pnlNav.CellClick
        If e.RowIndex = -1 Then Exit Sub
        clickMini(pnlNav.Columns(e.ColumnIndex).DataPropertyName)
    End Sub
    Sub creaTree()
        treeview1 = New System.Windows.Forms.TreeView()
        treeview1.BackColor = SystemColors.HighlightText
        treeview1.Name = "treeview1"
        treeview1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D

        treeview1.Size = New Size(0.4 + Me.pnlOrd.Width, btnS_Res.Height)
        treeview1.Left = 0.6 * Me.pnlOrd.Width
        treeview1.Visible = False
        AddHandler treeview1.MouseDown, AddressOf treeClic
        AddHandler treeview1.MouseMove, AddressOf treemove
        AddHandler treeview1.MouseUp, AddressOf treesoltar

    End Sub
    Private Sub treeClic(sender As Object, e As MouseEventArgs)
        'el boton izquierdo esta pulsado
        If e.Button = MouseButtons.Left Then
            btnDown = True
            offset.X = e.X
            offset.Y = e.Y
        End If

    End Sub

    Private Sub treemove(sender As Object, e As MouseEventArgs)
        If btnDown Then
            'mover el pictureBox con el raton               
            treeview1.Left += e.X - offset.X
            treeview1.Top += e.Y - offset.Y
        End If
    End Sub

    Private Sub treesoltar(sender As Object, e As MouseEventArgs)
        ' el boton izquierdo se libera
        If e.Button = MouseButtons.Left Then
            btnDown = False
        End If
    End Sub
    Private Sub generatree()
        treeview1.Nodes.Clear()
        Dim sql As String = String.Format("EXEC dbo.SDSP_OrdenesCocina @noCocina= {0}, @ultId= -1, @resPlat= 1 ",
                                                  Me.noCocina.ToString.Trim())
        Dim dtt As DataTable = cargarConsulta(sql)
        'Agrupar por platos estos son los nodos padres 
        Dim u_view As DataView = dtt.DefaultView
        Dim soloItems As DataTable = u_view.ToTable(True, "IdConsumo", "DescConsumo")
        For Each dCons As DataRow In soloItems.Rows
            Dim sumObject As Object
            sumObject = dtt.Compute("Sum(Cantidad)", "IdConsumo = '" & dCons.Item("IdConsumo") & "'")
            Dim parentNode As TreeNode = treeview1.Nodes.Add(String.Format("{0} - {1}", sumObject.ToString.Trim(), dCons.Item("DescConsumo").ToString.Trim()))
            Dim u_view2 As DataView = dtt.DefaultView
            Dim itmCant As DataTable = u_view2.ToTable(True, "IdConsumo", "IdCabecera", "Mesas")
            Dim filasCons As DataRow() = itmCant.Select("IdConsumo= '" & dCons.Item("IdConsumo") & "'")
            For Each drCons As DataRow In filasCons
                Dim sumObject2 As Object
                sumObject2 = dtt.Compute("Sum(Cantidad)", "IdConsumo = '" & drCons("IdConsumo") & "' AND IdCabecera= " & drCons("IdCabecera"))
                Dim childNode = parentNode.Nodes.Add(String.Format("Pedido {0}; {1}; Cantidad: {2}", drCons("IdCabecera"), drCons("Mesas"), sumObject2.ToString.Trim()))
            Next
        Next

    End Sub


    Private Sub btnS_Res_Click(sender As Object, e As EventArgs) Handles btnS_Res.Click
        treeview1.Visible = Not treeview1.Visible
        Dim styles As TableLayoutColumnStyleCollection = Me.TableLayoutPanel1.ColumnStyles
        Dim style2 As ColumnStyle = styles(1)
        Dim style4 As ColumnStyle = styles(4)
        'Arreglar el layout
        If treeview1.Visible Then
            'mostrar
            TableLayoutPanel1.SetColumnSpan(pnlOrd, 4)
            style2.Width = 50
            style4.SizeType = SizeType.Percent
            style4.Width = 50
            TableLayoutPanel1.Controls.Add(treeview1, 4, 1)
            treeview1.Dock = DockStyle.Fill
            generatree()
        Else
            'mostrar
            TableLayoutPanel1.SetColumnSpan(pnlOrd, 5)
            style2.Width = 100
            style4.SizeType = SizeType.Absolute
            style4.Width = 50
            TableLayoutPanel1.Controls.Remove(treeview1)
        End If
    End Sub

    Private Sub Comandas_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        reconocimiento_de_voz.RecognizeAsyncStop()
        'MsgBox("se mato")
    End Sub

    Private Sub waitinLista_Tick(sender As Object, e As EventArgs) Handles waitinLista.Tick
        If esperaLista Then
            waitinLista.Stop()
            esperaLista = False
            endijiste = False
            cocinaExiste(Me.noCocina)
        End If

    End Sub
    Sub Habla(ByVal algo As String)
        If Not synth.State = SynthesizerState.Speaking Then
            synth.SpeakAsync(algo)
        End If
    End Sub
    Dim meLLamaron As Boolean = False
    Private Sub waitinComando_Tick(sender As Object, e As EventArgs) Handles waitinComando.Tick
        If meLLamaron Then
            If Not endijiste Then
                waitinComando.Stop()
                meLLamaron = False
                btnEscucha.ImageKey = keyBoca
                cocinaExiste(Me.noCocina)
            Else
                'estoy interpretando algo 
                waitinComando.Interval = Parametros.esperaAsistente
                waitinComando.Stop()
                waitinComando.Start()
            End If
        End If
    End Sub
End Class
Public Class ordStruc
    Public orden As Orden
    Public newLoc As Point
    Public hilo As Thread
    'Public mini As miniOrden
    Sub New(o As Orden, nl As Point)
        orden = o
        newLoc = nl
    End Sub

End Class


