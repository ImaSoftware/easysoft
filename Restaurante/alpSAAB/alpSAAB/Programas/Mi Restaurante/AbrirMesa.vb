Public Class AbrirMesa
   
    Public Property focusHijo As Boolean = False
    Public Property forma As DolphinForm
    Property ListaMesas As String
    Dim Identificado As Boolean = False
    Property IdMesero As Integer

    Property IdCuenta As Integer = -1
    Dim AbreCrea As Boolean = False
    Dim puedoCrear As Boolean = True
    Sub New(ByVal argListaMesa As String, ByVal nomMesaD As String)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        lblMesaD.Text = nomMesaD
        ListaMesas = argListaMesa
        Me.lblNoCuenta.BackColor = ColorPrimario
    End Sub

    Private Sub AbrirMesa_Load(sender As Object, e As EventArgs) Handles Me.Load
        NumericaPad1.CuadroTexto(txtClave, Parametros.MeseroDigitos)
        NumericaPad1.ocultaEnter()
        limpiarInfoCuenta()
    End Sub
    Private Sub txtClave_TextChanged(sender As Object, e As EventArgs) Handles txtClave.TextChanged
        If txtClave.Text.Length > Parametros.MeseroDigitos Then
            txtClave.Text = Mid(txtClave.Text, 1, Len(txtClave.Text) - 1)
        End If
    End Sub



    Private Sub NumericaPad1_Entrar() Handles NumericaPad1.Entrar
        If verificaClave(txtClave.Text) Then
            PanelIDentificado.Visible = True
            cargarInfoCuenta()
            Identificado = True
            'CmdCrear.Text = "&Crear"
        Else
            PanelIDentificado.Visible = False
            MsgBox("IdMesero Incorrecto, Intente de nuevo", MsgBoxStyle.Information, "Un Momento!!!!")
            txtClave.Text = ""
        End If
    End Sub
    Function verificaClave(ByVal claveMesero As String) As Boolean
        If String.IsNullOrEmpty(claveMesero) OrElse Not System.Text.RegularExpressions.Regex.IsMatch(claveMesero, "^[0-9]+$") Then Return False
        Dim sql As String = "Select codemp, apellido, nombre, cedula, empfoto from rola110 where ClaveMesero = @p0"
        Dim a As DataTable = cargarConsulta(sql, , New Object() {claveMesero})
        If a IsNot Nothing AndAlso a.Rows.Count = 1 Then
            Dim xN() As String = Trim(a(0)("nombre")).ToString.Split(" ")
            Dim xApl() As String = Trim(a(0)("apellido")).ToString.Split(" ")
            txtNombres.Text = xN(0) & " " & xApl(0)
            Dim imagenprueba As Image = Nothing
            Dim cambia As Boolean = False
            Try
                imagenprueba = cargarImagen(Application.StartupPath & "\BMPs\Empleados\" & a(0)("empfoto"))
                cambia = True
            Catch ex As Exception
                cambia = False
            End Try
            If cambia Then
                imagenEpl.Image = imagenprueba
            End If
            Me.IdMesero = a(0)("codemp")
            txtCod.Text = a(0)("codemp")
            Return True
        Else
            Return False
        End If



    End Function

    Private Sub cmdAbrir_Click(sender As Object, e As EventArgs) Handles cmdAbrir.Click
        AbreCrea = False

        If txtClave.Text.Length <> 0 Then
            If IdCuenta = -1 Then
                If verificaClave(txtClave.Text) Then
                    Identificado = True
                    cargarInfoCuenta()
                    If Identificado And IdCuenta <> -1 Then
                        'Abir Cuenta
                        PanelIDentificado.Visible = True
                        AbreCrea = True
                        tmrIden.Start()
                        Exit Sub
                    ElseIf Identificado And puedoCrear Then
                        PanelIDentificado.Visible = True
                        AbreCrea = False
                        tmrIden.Start()
                        Exit Sub
                    End If

                Else
                    PanelIDentificado.Visible = False
                    MsgBox("IdMesero Incorrecto, Intente de nuevo", MsgBoxStyle.Information, "Un Momento!!!!")
                    txtClave.Text = ""
                End If

            End If
        End If
    End Sub

    Private Sub CmdCrear_Click(sender As Object, e As EventArgs)

    End Sub
    Sub limpiarInfoCuenta()
        lblNoCuenta.Text = CStr(0)
        lblTotal.Text = CStr(0)
        lblMesas.Text = "Mesas: "
        PanelCuenta.Visible = False
    End Sub
    Sub cargarInfoCuenta()
        puedoCrear = True
        Dim sql As String = String.Format("	SELECT DISTINCT  " _
               & " SD_CuentasCabecera.id, 'CUENTA ' + CAST(SD_CuentasCabecera.alias AS VARCHAR) AS Cuenta, SD_CuentasCabecera.Mesas,  " _
               & " SD_CuentasCabecera.TotalCuenta, SD_CuentasCabecera.Idmesero " _
               & " FROM            SD_CuentasCabecera INNER JOIN " _
               & " SD_Cuentas_Mesas ON SD_CuentasCabecera.id = SD_Cuentas_Mesas.IdCuenta " _
               & " where SD_CuentasCabecera.estado = 'A'" _
               & " GROUP BY SD_CuentasCabecera.id, SD_CuentasCabecera.alias, SD_CuentasCabecera.Mesas, SD_CuentasCabecera.estado, SD_CuentasCabecera.TotalCuenta,  " _
               & " SD_CuentasCabecera.Idmesero, SD_Cuentas_Mesas.IdMesa " _
               & " HAVING        SD_Cuentas_Mesas.IdMesa  IN ({0})", Me.ListaMesas)

        Dim a As DataTable = cargarConsulta(sql)
        If IsNothing(a) Then
            MsgBox("Error Sql", MsgBoxStyle.Critical, "Ops!!")
        Else
            If a.Rows.Count = 0 Then
                cmdAbrir.Enabled = False
                Exit Sub
            ElseIf a.Rows.Count = 1 Then 'solo debe haber una cuenta como maximo abierta sobre cada mesa
                If Globales.Parametros.ResMesero Then
                    If a(0)("Idmesero") <> Me.IdMesero Then
                        MsgBox("Acceso Denegado", MsgBoxStyle.Exclamation, "Un Momento!!!")
                        txtClave.Text = ""
                        Identificado = False
                        Exit Sub
                    End If
                End If
                puedoCrear = False
                Me.IdCuenta = a(0)("Id")
                lblNoCuenta.Text = a(0)("Cuenta")
                lblMesas.Text = "Mesas: " & a(0)("Mesas")
                lblTotal.Text = a(0)("TotalCuenta")
                PanelCuenta.Visible = True
                Exit Sub
            ElseIf a.Rows.Count > 1 Then
                MsgBox("Mas de una cuenta abierta para esta mesa. Error de forma Consulte al desarrollador", MsgBoxStyle.Exclamation, "Un momento")
                Me.Close()
            End If
        End If
    End Sub

    Private Sub tmrIden_Tick(sender As Object, e As EventArgs) Handles tmrIden.Tick
        tmrIden.Stop()
        If AbreCrea Then
            Me.DialogResult = Windows.Forms.DialogResult.Yes
        Else
            Me.DialogResult = Windows.Forms.DialogResult.No
        End If
        Me.Close()
    End Sub


End Class

