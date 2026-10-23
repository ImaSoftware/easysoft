Imports System.Data.SqlClient

Module FUGSD
 
    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal hProcess As IntPtr, ByVal dwMinimumWorkingSetSize As Int32, ByVal dwMaximumWorkingSetSize As Int32) As Int32
    Public Enum estadosEdicion
        Guardado
        Editando
        Nuevo
    End Enum
    Function Comprueba_Existe(ByVal strMesas As String) As Integer
        If String.IsNullOrEmpty(strMesas) Then
            Return 0
        End If
        Dim ids = Database.IdList(strMesas)
        Dim placeholders As New List(Of String)()
        Dim values As New List(Of Object)()
        For Each id In ids
            placeholders.Add("@p" & values.Count)
            values.Add(id)
        Next
        Dim dtt = cargarConsulta("SELECT A.ID FROM SD_CuentasCabecera A INNER JOIN SD_Cuentas_Mesas B ON A.id = B.IdCuenta WHERE A.estado = 'A' AND B.IdMesa IN (" & String.Join(",", placeholders) & ") GROUP BY A.ID", , values.ToArray())
        If dtt.Rows.Count = 0 Then
            Return 0
        Else
            If dtt.Rows.Count = 1 Then
                Return dtt.Rows(0)("Id")
            Else
                MsgBox("Se encontraron varias cuentas abiertas para la misma mesa")
                Return -1
            End If
        End If

    End Function
    Public Cn_x_Defecto = My.Settings.ConexionReportes
    Function EjecutarConsulta(ByVal Consulta As String, Optional ByVal cadenaconexion As String = "", Optional ByVal ControlarTransaccion As Boolean = False, Optional ByVal valores() As Object = Nothing) As Integer
        Return Database.Execute(Consulta, If(String.IsNullOrEmpty(cadenaconexion), CStr(Cn_x_Defecto), cadenaconexion), ControlarTransaccion, valores)
    End Function
    Function distancia(ByVal puntoA As Point, ByVal puntoB As Point) As Double
        Try
            Return System.Math.Sqrt(((puntoA.X - puntoB.X) ^ 2) + ((puntoA.Y - puntoB.Y) ^ 2))
        Catch ex As Exception
            MsgBox("Error en calculo de distancia entre puntos")
            Return 0
        End Try
    End Function
    Function cargarConsulta(ByVal Consulta As String, Optional ByVal cadenaconexion As String = Nothing, Optional ByVal valores() As Object = Nothing) As DataTable
        Return Database.Query(Consulta, If(String.IsNullOrEmpty(cadenaconexion), CStr(Cn_x_Defecto), cadenaconexion), valores)
    End Function
    Sub imprimeComanda(ByVal idC As Integer)
        Database.Exclusive("SAAB.Comanda." & idC, CStr(Cn_x_Defecto), Sub()
            Dim status = cargarConsulta("SELECT documento FROM SD_Comanda_Cabecera WHERE Id = @p0", , New Object() {idC})
            If status.Rows.Count <> 1 Then Throw New InvalidOperationException("La comanda no existe.")
            If Not String.IsNullOrEmpty(DataC(status(0)(0))) Then Return
            Dim kitchens = cargarConsulta("SELECT DISTINCT A.idCocina, ISNULL(B.nombreImpresora, '') AS Impresora, copias FROM SD_Comandas_Detalle A LEFT JOIN SD_Cocinas B ON A.idCocina = B.idCocina WHERE idComanda = @p0", , New Object() {idC})
            If kitchens.Rows.Count = 0 Then Throw New InvalidOperationException("La comanda no tiene cocinas configuradas.")
            Dim lastDocument As String = ""
            For Each kitchen As DataRow In kitchens.Rows
                Dim parameters As New List(Of Parametro) From {New Parametro("IdComanda", idC), New Parametro("idCocina", kitchen("idCocina"))}
                Dim copies As Integer
                Integer.TryParse(DataC(kitchen("copias")), copies)
                Using report As New vReport("Comanda.rdlc", parameters, True, DataC(kitchen("Impresora")), copies, idC)
                    lastDocument = report.DocumentoImpreso
                End Using
            Next
            EjecutarConsulta("UPDATE SD_Comanda_Cabecera SET documento = @p0 WHERE Id = @p1", , , New Object() {lastDocument, idC})
        End Sub)
    End Sub

    Sub imprimePrefactura(ByVal idP As Integer)
        Database.Exclusive("SAAB.Prefactura." & idP, CStr(Cn_x_Defecto), Sub()
            Dim status = cargarConsulta("SELECT documento FROM SD_Prefacturas_Cabecera WHERE Id = @p0", , New Object() {idP})
            If status.Rows.Count <> 1 Then Throw New InvalidOperationException("La prefactura no existe.")
            If Not String.IsNullOrEmpty(DataC(status(0)(0))) Then Return
            Dim printers = cargarConsulta("SELECT * FROM SD_Cocinas WHERE idCocina = 3")
            If printers.Rows.Count <> 1 Then Throw New InvalidOperationException("Configure la impresora de prefacturas.")
            Dim parameters As New List(Of Parametro) From {New Parametro("idPrefactura", idP)}
            Dim copies As Integer
            Integer.TryParse(DataC(printers(0)("copias")), copies)
            Using report As New vReport("Prefactura.rdlc", parameters, True, DataC(printers(0)("nombreImpresora")), copies, idP)
            End Using
        End Sub)
    End Sub

    Function MaxCampo(ByVal nomTabla As String, ByVal nomCampo As String, Optional filtro As String = "") As Object
        MaxCampo = Nothing
        Dim sql As String = String.Format("Select  MAX({0}) As Maximo FROM {1} {2}", _
                                          nomCampo, nomTabla, If(filtro = "", "", "where " & filtro))
        Dim res As DataTable = cargarConsulta(sql)
        If Not IsNothing(res) Then
            MaxCampo = res(0)("Maximo")
        End If
    End Function
    Public Function Numero(ByVal algo As Object)
        Dim retornar As Double
        Try
            retornar = CDbl(algo)
        Catch ex As Exception
            retornar = 0
        End Try
        Return retornar
    End Function

    Public Function DataC(ByVal Dato As Object) As String
        If Dato Is Nothing OrElse IsDBNull(Dato) Then
            Return ""
        Else
            Return Dato
        End If
    End Function
    Sub cargarcombos(ByVal Objeto As Control)
        For Each control As Control In Objeto.Controls
            If control.GetType().Name = "ComboBox" Then
                Dim combo As ComboBox = control
                Dim origen As DataTable = cargarConsulta(String.Format("Select * from {0}", combo.Name))
                'la vista creada debe tener dos columnas la primera para value y la segunda para display
                combo.DataSource = origen
                combo.ValueMember = origen.Columns(0).ColumnName
                combo.DisplayMember = origen.Columns(1).ColumnName
                combo.SelectedIndex = 0
            End If
            If control.HasChildren Then
                cargarcombos(control)
            End If
        Next
    End Sub
    Function NombreToTipo(ByVal n As String) As Type
        Select Case n
            Case "String"
                Return GetType(String)
            Case "ComboBox"
                Return GetType(ComboBox)
            Case "TextBox"
                Return GetType(TextBox)
            Case "NumericUpDown"
                Return GetType(NumericUpDown)
            Case "Button"
                Return GetType(Button)
            Case "CheckBox"
                Return GetType(CheckBox)
            Case "MyCheckBox"
                Return GetType(MyCheckBox)
            Case Else
                Return Nothing

        End Select



    End Function
    Function GetCampo(ByVal Id As Integer, ByVal Tabla As String, ByVal nomCampo As String, Optional nomId As String = "") As String
        Dim sql = "SELECT " & Database.Identifier(nomCampo) & " FROM " & Database.Identifier(Tabla) & " WHERE " & Database.Identifier(If(nomId = "", "Id", nomId)) & " = @p0"
        Dim result = cargarConsulta(sql, , New Object() {Id})
        If result.Rows.Count <> 1 Then Throw New InvalidOperationException("No se encontró un registro único en " & Tabla & ".")
        Return DataC(result(0)(0))
    End Function
    Sub destruir(ByRef argControl As Control)
        If IsNothing(argControl) Then Exit Sub

        argControl.Dispose()
        If argControl.HasChildren Then
            For Each ControlHIJO In argControl.Controls
                destruir(ControlHIJO)
            Next
        End If
    End Sub
    Public Sub CerrarTecladoVirtual(ByRef controlador As Process)
        If controlador IsNot Nothing AndAlso Not controlador.HasExited Then
            controlador.CloseMainWindow()
        End If
    End Sub
    Public Sub AbrirTecladoVirtual(ByRef controlador As Process)
        Dim progFiles As String = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles), "Microsoft Shared\ink")
        Dim onScreenKeyboardPath As String = System.IO.Path.Combine(progFiles, "TabTip.exe")
        controlador = Process.Start(onScreenKeyboardPath)
    End Sub
    Sub suspenderLayout(ByRef algo As Object)
        Try
            algo.SuspendLayout()
            If algo.HasChildren Then
                For Each ControlHIJO In algo.Controls
                    suspenderLayout(ControlHIJO)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub resumirLayout(ByRef algo As Object)
        Try
            algo.ResumeLayout()
            If algo.HasChildren Then
                For Each ControlHIJO In algo.Controls
                    resumirLayout(ControlHIJO)
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub


    'Funcion de liberacion de memoria
    Public Sub LiberarMemoria()
        Try

            Dim memoria As Process
            memoria = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(memoria.Handle, -1, -1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Function SQLFormatDate(ByVal Fecha As Date) As String
        If IsNothing(Fecha) Then
            Throw New Exception("La fecha no puede ser nula")
        Else
            Return Format(Fecha, "yyyyMMdd HH:mm:ss")
        End If
    End Function
    Function cargarImagen(ByVal pathImagen As String) As Image
        Dim pathresp As String = Application.StartupPath & "\BMPs\"
        Dim x() As String = pathImagen.Split("\")
        Dim fl As Boolean = False
        For i = 0 To x.Length - 1
            If x(i) = "sgrEX" Then
                fl = True
            End If
            If fl Then
                If i <> x.Length - 1 Then
                    pathresp = pathresp & x(i) & "\"
                Else
                    pathresp = pathresp & x(i)
                End If
            End If
        Next

        Try
            If System.IO.File.Exists(pathImagen) Then
                cargarImagen = Image.FromFile(pathImagen)
            ElseIf System.IO.File.Exists(pathresp) Then
                cargarImagen = Image.FromFile(pathresp)
            Else
                cargarImagen = Image.FromFile(Application.StartupPath & "\BMPs\NoSign.png")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            cargarImagen = Image.FromFile(Application.StartupPath & "\BMPs\NoSign.png")
        End Try
    End Function
    Function cargarImagen(ByVal pathImagen As String, ByVal imgsize As Size, ByVal transcolor As Color) As Image
        Dim tmpA As Image
        Dim imagenL As New ImageList

        Try
            If System.IO.File.Exists(pathImagen) Then
                tmpA = Image.FromFile(pathImagen)
            Else
                tmpA = Image.FromFile(Application.StartupPath & "\BMPs\NoSign.png")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            tmpA = Image.FromFile(Application.StartupPath & "\BMPs\NoSign.png")
        End Try
        imagenL.Images.Add(tmpA)
        imagenL.ImageSize = imgsize
        imagenL.TransparentColor = transcolor
        imagenL.ColorDepth = ColorDepth.Depth32Bit
        cargarImagen = imagenL.Images(0)
    End Function
    Public Class Parametro
        Sub New(ByVal argN As String, ByVal argVal As Object, Optional fsize As Integer = 0)
            Nombre = argN
            value = argVal
            size = fsize
        End Sub
        Public Nombre As String
        Public value As Object
        Public size As Integer
    End Class
    Function DevuelveValor(ByVal Consulta As String, Optional ByVal cadenaconexion As String = "") As Object
        Dim dtt As DataTable = cargarConsulta(Consulta, cadenaconexion)
        If IsNothing(dtt) Then Return Nothing
        If dtt.Rows.Count <> 1 Then Return Nothing
        Return dtt.Rows(0).Item(0)
    End Function
    Public Enum sp_ret
        filas_afectadas
        return_Value
        output_Vars
    End Enum

    Function EjecutarSP(ByVal nombre As String, ParametrosIN As List(Of Parametro),
            Optional ByRef ParametrosOut As List(Of Parametro) = Nothing, Optional optRet As sp_ret = sp_ret.output_Vars,
            Optional cadenaconexion As String = "") As Object
        Using cn As New SqlConnection(Database.ConnectionString(If(String.IsNullOrEmpty(cadenaconexion), CStr(Cn_x_Defecto), cadenaconexion))),
              command As New SqlCommand(nombre, cn)
            command.CommandType = CommandType.StoredProcedure
            command.CommandTimeout = 30
            For Each item In ParametrosIN
                command.Parameters.Add("@" & item.Nombre, TipoSQL(item.value)).Value = If(item.value, DBNull.Value)
            Next
            If ParametrosOut IsNot Nothing Then
                For Each item In ParametrosOut
                    Dim p = command.Parameters.Add(item.Nombre, TipoSQL(item.value), item.size)
                    p.Direction = ParameterDirection.Output
                Next
            End If
            If optRet = sp_ret.return_Value Then command.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.ReturnValue
            cn.Open()
            Dim affected = command.ExecuteNonQuery()
            If optRet = sp_ret.filas_afectadas Then Return affected
            If optRet = sp_ret.return_Value Then Return command.Parameters("@RetVal").Value
            Dim table As New DataTable()
            For Each p As SqlParameter In command.Parameters
                If p.Direction = ParameterDirection.Output Then table.Columns.Add(p.ParameterName)
            Next
            Dim row = table.NewRow()
            For Each p As SqlParameter In command.Parameters
                If p.Direction = ParameterDirection.Output Then row(p.ParameterName) = p.Value
            Next
            table.Rows.Add(row)
            Return row
        End Using
    End Function
    Function BuscaPos(ByVal grid As DataGridView, ByVal idval As Integer, ByVal idname As String)
        Dim i As Integer = 0
        For Each fila As DataGridViewRow In grid.Rows
            If fila.DataBoundItem.row(idname) = idval Then
                Return i
            End If
            i += 1
        Next
        Return -1.0F
    End Function
    Function TipoSQL(ByVal algo As Object) As SqlDbType
        If algo Is Nothing OrElse Convert.IsDBNull(algo) Then Return SqlDbType.Variant
        Select Case algo.GetType.ToString
            Case "System.String"
                Return SqlDbType.VarChar
            Case "System.Int32"
                Return SqlDbType.Int
            Case "System.Boolean"
                Return SqlDbType.Bit
            Case "System.Single", "System.Double", "System.Decimal"
                Return SqlDbType.Decimal
            Case "System.DateTime"
                Return SqlDbType.DateTime
            Case Else
                Return SqlDbType.VarChar
        End Select
    End Function
    Class RepoMan
        '***********************EMULACION DE REPOMAN ***************************
        'REPORTE DINAMICO A TRAVES DE SENTENCIA ALMACENADA EN BASE DE DATOS 
        'Clase pensada para usarse como extractor de info de repo
        '***********************************************************************
        Dim clave As String
        Friend Comentario As String
        Dim query As String
        Friend EnableExternalImages As Boolean = False
        Public db As New DataSet
        Sub New(ByVal _nR As String)
            clave = _nR

        End Sub
        Sub load()
            'El nombre del repo me indica que debo buscar
            Dim sql As String = "Select Sentencia, EnableExternalImages, comentario from repoman where namereport = @p0"
            Dim dtt As DataTable = cargarConsulta(sql, , New Object() {clave})
            If dtt.Rows.Count <> 1 Then
                Throw New InvalidOperationException("No existe una definición única para el reporte.")
            End If
            Me.Comentario = dtt.Rows(0).Item("COMENTARIO")
            Me.EnableExternalImages = DataC(dtt.Rows(0).Item("EnableExternalImages"))
            Dim query = dtt.Rows(0).Item("Sentencia").ToString.Trim()
            Using connection As New SqlConnection(Database.ConnectionString(CStr(Cn_x_Defecto))), command As New SqlCommand(query, connection)
                command.CommandTimeout = 30
                Using adapter As New SqlDataAdapter(command)
                    adapter.Fill(db)
                End Using
            End Using
            'Aqui necesito los nombres de las tablas para poder hacer match con el origen de datos 
            'que se pone en la definición del reporte. Para ello la primera tabla de todo conjunto de datos
            'deberá ser una que especifique dichos nombres
            For j = 0 To db.Tables.Count - 1
                If j = 0 Then Continue For
                Dim table As DataTable = db.Tables.Item(j)
                Dim nT As String = db.Tables.Item(0).Rows(0).Item("N" & j.ToString.Trim()).ToString
                table.TableName = nT
            Next

        End Sub

    End Class


    Function enletras(num As String) As String
        Dim Res, dec As String
        Res = "" : dec = ""
        Dim entero As Int64
        Dim decimales As Integer
        Dim nro As Double
        Try
            nro = Convert.ToDouble(num)
        Catch ex As Exception
            Return ""
        End Try
        entero = Convert.ToInt64(Math.Truncate(nro))
        decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2))
        If decimales > 0 Then
            'dec = " CON " + decimales.ToString() + "/100" 'Sin Decimales
        End If
        Res = toText(Convert.ToDouble(entero)) + dec
        Return Res
    End Function
    Private Function toText(value As Double) As String
        Dim Num2Text As String = ""
        value = Math.Truncate(value)
        If value = 0 Then
            Num2Text = "CERO"
        ElseIf value = 1 Then
            Num2Text = "UNO"
        ElseIf value = 2 Then
            Num2Text = "DOS"
        ElseIf value = 3 Then
            Num2Text = "TRES"
        ElseIf value = 4 Then
            Num2Text = "CUATRO"
        ElseIf value = 5 Then
            Num2Text = "CINCO"
        ElseIf value = 6 Then
            Num2Text = "SEIS"
        ElseIf value = 7 Then
            Num2Text = "SIETE"
        ElseIf value = 8 Then
            Num2Text = "OCHO"
        ElseIf value = 9 Then
            Num2Text = "NUEVE"
        ElseIf value = 10 Then
            Num2Text = "DIEZ"
        ElseIf value = 11 Then
            Num2Text = "ONCE"
        ElseIf value = 12 Then
            Num2Text = "DOCE"
        ElseIf value = 13 Then
            Num2Text = "TRECE"
        ElseIf value = 14 Then
            Num2Text = "CATORCE"
        ElseIf value = 15 Then
            Num2Text = "QUINCE"
        ElseIf value < 20 Then
            Num2Text = "DIECI" + toText(value - 10)
        ElseIf value = 20 Then
            Num2Text = "VEINTE"
        ElseIf value < 30 Then
            Num2Text = "VEINTI" + toText(value - 20)
        ElseIf value = 30 Then
            Num2Text = "TREINTA"
        ElseIf value = 40 Then
            Num2Text = "CUARENTA"
        ElseIf value = 50 Then
            Num2Text = "CINCUENTA"
        ElseIf value = 60 Then
            Num2Text = "SESENTA"
        ElseIf value = 70 Then
            Num2Text = "SETENTA"
        ElseIf value = 80 Then
            Num2Text = "OCHENTA"
        ElseIf value = 90 Then
            Num2Text = "NOVENTA"
        ElseIf value < 100 Then
            Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value Mod 10)
        ElseIf value = 100 Then
            Num2Text = "CIEN"

        ElseIf value < 200 Then
            Num2Text = "CIENTO " + toText(value - 100)
        ElseIf value = 200 Or value = 300 Or value = 400 Or value = 600 Or value = 800 Then
            Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS"
        ElseIf value = 500 Then
            Num2Text = "QUINIENTOS"
        ElseIf value = 700 Then
            Num2Text = "SETECIENTOS"
        ElseIf value = 900 Then
            Num2Text = "NOVECIENTOS"
        ElseIf value < 1000 Then
            Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value Mod 100)
        ElseIf value = 1000 Then
            Num2Text = "MIL"
        ElseIf value < 2000 Then
            Num2Text = "MIL " + toText(value Mod 1000)
        ElseIf value < 1000000 Then
            Num2Text = toText(Math.Truncate(value / 1000)) + " MIL"
            If value Mod 1000 > 0 Then
                Num2Text = Num2Text + " " + toText(value Mod 1000)
            End If
        ElseIf value = 1000000 Then
            Num2Text = "UN MILLON"
        ElseIf value < 2000000 Then
            Num2Text = "UN MILLON " + toText(value Mod 1000000)
        ElseIf value < 1000000000000 Then
            Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES "
            If (value - Math.Truncate(value / 1000000) * 1000000) > 0 Then
                Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000)
            End If
        ElseIf value = 1000000000000 Then
            Num2Text = "UN BILLON"
        ElseIf value < 2000000000000 Then
            Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000)
        Else
            Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES"
            If (value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0 Then
                Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000)
            End If
        End If

        Return Num2Text
    End Function



End Module






