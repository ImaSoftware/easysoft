
Public Class SDParameters
    Property Instancia As Integer = 0
    Property AdminHash As String = ""
    Property ClaveAdmin As String = ""
    Property MeseroDigitos
    Property CombinacionColores
    Property TiempoEsperaMaximo
    Property TiempoEsperaAceptable

    Property velocidad_Orden As Integer
    Property ParadiseName
    Property VerEsquema As Boolean
    Property ResMesero As Boolean
    Property MeserosOrigen As New OrigendeMeseros
    Property origenMeseros As Integer
    Property imgpublicidad As String
    Property Depura As Boolean = False
    Property EsquemaCuenta As Boolean = False
    Property OK As Boolean = False
    Property Tema As New Tema
    Property confirmaCierre As Boolean = False
    Property tpProfo As String
    Property Bodega As String
    Property cliProfo As String
    Property idMesaLLevar As Integer
    Property idMesaDomicilio As Integer
    Property esperaAsistente
    Property topPedidos As Integer = 0
    Property nombreAsistente As String = ""
    Property EsperaSector As Integer = 0
    Property imagenArriba As String = ""
    Public Function Cargar(ByVal argIdInstancia As Integer) As Boolean

        'Parametros almacenados
        Dim sql As String = String.Format("Select * from SD_SysParam where Instancia = {0} ", argIdInstancia)
        Try
            Dim dtt As DataTable = cargarConsulta(sql)
            If Not IsNothing(dtt) Then
                Instancia = argIdInstancia
                If dtt.Rows.Count = 1 Then
                    Using migration As New System.Transactions.TransactionScope()
                        Dim credentials = cargarConsulta("SELECT PasswordHash FROM dbo.SD_AdminCredenciales WITH (UPDLOCK, HOLDLOCK) WHERE Instancia = @p0", , New Object() {argIdInstancia})
                        If credentials.Rows.Count = 0 Then
                            Dim legacy = DataC(dtt(0)("ClaveAdmin"))
                            If String.IsNullOrEmpty(legacy) Then Throw New InvalidOperationException("Configure una clave administrativa antes de migrar.")
                            AdminHash = AdminSecurity.HashPassword(legacy)
                            EjecutarConsulta("INSERT INTO dbo.SD_AdminCredenciales (Instancia, PasswordHash) VALUES (@p0, @p1); UPDATE SD_SysParam SET ClaveAdmin = '0' WHERE Instancia = @p0", , , New Object() {argIdInstancia, AdminHash})
                        Else
                            AdminHash = CStr(credentials(0)("PasswordHash"))
                        End If
                        migration.Complete()
                    End Using
                    MeseroDigitos = DataC(dtt(0)("MeseroDigitos"))
                    CombinacionColores = DataC(dtt(0)("CombinacionColores"))
                    TiempoEsperaMaximo = DataC(dtt(0)("TiempoEsperaMaximo"))
                    TiempoEsperaAceptable = DataC(dtt(0)("TiempoEsperaAceptable"))
                    ParadiseName = DataC(dtt(0)("ParadiseName"))
                    VerEsquema = CBool(DataC(dtt(0)("VerEsquema")))
                    ResMesero = CBool(DataC(dtt(0)("ResMesero")))
                    origenMeseros = Numero(DataC(dtt(0)("OrigenMeseros")))
                    imgpublicidad = DataC(dtt(0)("ImagenInicio"))
                    Depura = CBool(DataC(dtt(0)("Depuracion")))
                    EsquemaCuenta = CBool(DataC(dtt(0)("mostrarEsquemaCuenta")))
                    velocidad_Orden = DataC(dtt(0)("velocidad_Orden"))
                    confirmaCierre = DataC(dtt(0)("confirmaCierre"))
                    topPedidos = DataC(dtt(0)("topPedidos"))
                    tpProfo = DataC(dtt(0)("tpProf"))
                    Bodega = DataC(dtt(0)("Bodega"))
                    cliProfo = DataC(dtt(0)("temp_codcli"))
                    idMesaLLevar = DataC(dtt(0)("idMesaLlevar"))
                    idMesaDomicilio = DataC(dtt(0)("idMesaDomicilio"))
                    esperaAsistente = DataC(dtt(0)("esperaAsistente"))
                    nombreAsistente = DataC(dtt(0)("nombreAsistente"))
                    EsperaSector = DataC(dtt(0)("EsperaSector"))
                    imagenArriba = DataC(dtt(0)("ImagenArriba"))
                    'Ahora el origen de meseros
                    Dim dtta As DataTable = cargarConsulta(String.Format("Select * from SD_OrigenesMeseros where id = {0}", origenMeseros))
                    MeserosOrigen.SQLTotal = String.Format("Select  {2} from {0} {1}", DataC(dtta(0)("NombreTabla")), DataC(dtta(0)("FiltroMesero")), DataC(dtta(0)("Campos")))
                    MeserosOrigen.Campos = DataC(dtta(0)("Campos"))
                    MeserosOrigen.FiltroMesero = DataC(dtta(0)("FiltroMesero"))
                    MeserosOrigen.NombreTabla = DataC(dtta(0)("NombreTabla"))
                    Tema.cargarTema(Me.CombinacionColores)
                ElseIf dtt.Rows.Count > 1 Then
                    Me.OK = False
                    MsgBox("Id Instancia repetido. Consulte al desarrollador", MsgBoxStyle.Exclamation, "Un momento!!!")
                    Return False
                ElseIf dtt.Rows.Count = 0 Then
                    Me.OK = False
                    MsgBox("Configuracion de instancia no existe. Consulte al desarrollador", MsgBoxStyle.Exclamation, "Un momento!!!")
                    Return False
                End If
            Else
                MsgBox("No se han cargado los parametros de  la instancia", MsgBoxStyle.Exclamation, "Un momento!!!")
                Me.OK = False
                Return False
            End If
        Catch ex As Exception
            Dim mensaje As String = "Error en la carga de Parametros" & vbNewLine & Database.UserError(ex)
            If Not IsNothing(ex.InnerException) Then
                mensaje = mensaje & vbNewLine & "Revise la instalación y ejecute la migración de credenciales si corresponde."
            End If
            Me.OK = False
            MsgBox(mensaje, MsgBoxStyle.Exclamation, "Un momento!!!")
            Return False
        End Try
        Me.OK = True
        Return True
    End Function

End Class
Public Class OrigendeMeseros
    Public NombreTabla As String
    Public FiltroMesero As String
    Public Campos As String
    Public SQLTotal As String
End Class
