Public Class DolphinCtl
    Private Property estadoCTL As estadosEdicion
    Public ColorPrimario As Color
    Public ColorSecundario As Color
    Public fontTheme As Font
    Public rectanguloDestino As Rectangle
    Event _botonDelfin()
    Public noTema As Boolean = False
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Not Globales.Parametros.OK Then
            If Not Globales.Parametros.Cargar(1) Then
                Environment.Exit(-1)
            End If
        End If
    End Sub
    Sub New(ByVal _noTema As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.noTema = _noTema
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Public Sub AplicarTema(ByVal codigoTema As Integer)
        If noTema Then Exit Sub
        ColorPrimario = Globales.Parametros.Tema.colorPrimario
        ColorSecundario = Globales.Parametros.Tema.colorSecundario
        fontTheme = New Font(Globales.Parametros.Tema.FontName, Globales.Parametros.Tema.fontsize)
        Me.Font = fontTheme
    End Sub
    Sub loader()
        'If Not IsNothing(parametros) Then
    End Sub
    Sub DarTamaño()
        Me.Width = rectanguloDestino.Width
        Me.Height = rectanguloDestino.Height
    End Sub

    Private Sub DolphinCtl_Load(sender As Object, e As EventArgs) Handles Me.Load
        'parametros.Cargar(1)
        estadoCTL = estadosEdicion.Guardado
        AplicarTema(Globales.Parametros.CombinacionColores)
    End Sub
    Public Sub botonDelfin()
        RaiseEvent _botonDelfin()
    End Sub
End Class
