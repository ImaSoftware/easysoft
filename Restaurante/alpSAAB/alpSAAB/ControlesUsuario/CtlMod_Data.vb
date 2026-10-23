Public Class CtlMod_Data

    Public BoundedName As String
    Public DataId As Integer
    Public ControlName As String
    Public Param1 As String
    Public Param2 As String
    Public Param3 As String
    Public Descripcion As String
    Public queryValid As String
    Public CtlALg As Control


    Sub New(ByVal argdi As Integer, ByVal argDesc As String, ByVal BN As String, ByVal CtlName As String, ByVal arg1 As String, ByVal arg2 As String, ByVal arg3 As String, ByVal qV As String)


        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        DataId = argdi
        Descripcion = argDesc
        BoundedName = BN
        ControlName = CtlName
        Param1 = arg1
        Param2 = arg2
        Param3 = arg3
        queryValid = qV

    End Sub
    Sub CargarCTl()
        lblCaption.Text = Descripcion
        Dim controlAlgo As Object
        Try
            controlAlgo = Activator.CreateInstance(NombreToTipo(Me.ControlName))
        Catch ex As Exception
            MsgBox("Error al crear el control " & Descripcion, MsgBoxStyle.Critical, "Opps cat 5 ")
            Exit Sub
        End Try
        DirectCast(controlAlgo, Control).Anchor = AnchorStyles.Top Or AnchorStyles.Left
        lblCaption.Location = New Point(0, (PanelControlData.Size.Height / 2) - (lblCaption.Size.Height / 2))
        controlAlgo.location = New Point(0, (PanelControlData.Size.Height / 2) - (controlAlgo.Size.Height / 2))
        CtlALg = controlAlgo
        PanelControlData.Controls.Add(controlAlgo)
        DirectCast(controlAlgo, Control).Dock = DockStyle.Fill
        'Acciones adicionales dependiendo de los parametros
        If Me.ControlName = "ComboBox" Then
            CtlALg.Name = Param1
            cargarcombos(PanelControlData)
            DirectCast(CtlALg, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList
        End If
        If Me.ControlName = "Button" Then
            AddHandler CtlALg.Click, AddressOf clickbtnOpt
            controlAlgo.location = New Point(0, 0)

            CtlALg.AutoSize = True
        End If
        If Me.ControlName = "NumericUpDown" Then
            If Param1 = "Lenght" Then
                If Param2 = "LenMeseros" Then
                    Dim numeromax As Integer = 1 * (10 ^ Numero(parametros.MeseroDigitos))
                    DirectCast(controlAlgo, NumericUpDown).Maximum = numeromax - 1
                End If
            Else
                DirectCast(controlAlgo, NumericUpDown).Maximum = 999999
            End If

        End If
    End Sub
    Sub CargarValor(ByVal valor As Object)
        TableLayoutPanel1.ColumnStyles(0).Width = lblCaption.Right
        Try
            Select Case ControlName
                Case "String"
                    CtlALg = valor
                Case "ComboBox"
                    DirectCast(CtlALg, ComboBox).SelectedValue = valor
                Case "TextBox"
                    DirectCast(CtlALg, TextBox).Text = valor
                Case "NumericUpDown"
                    DirectCast(CtlALg, NumericUpDown).Value = valor
                Case "Button"
                    DirectCast(CtlALg, Button).Tag = valor
                    If Param1 = "ColorDialog" Then
                        DirectCast(CtlALg, Button).BackColor = Color.FromArgb(valor)
                    ElseIf Param1 = "OpenFileDialog" Then
                        DirectCast(CtlALg, Button).TextAlign = ContentAlignment.MiddleCenter
                        If Param2 = "Imagen" Then
                            If Param3 <> "" Then
                                DirectCast(CtlALg, Button).BackgroundImage = cargarImagen(Application.StartupPath & "\BMPs\" & Param3 & "\" & valor)
                                DirectCast(CtlALg, Button).BackgroundImageLayout = ImageLayout.Zoom
                                '  DirectCast(CtlALg, Button).Size = New Size(150, 25)
                                If Param3 = "Texturas" Then
                                    DirectCast(CtlALg, Button).BackColor = Color.White
                                End If
                            End If
                        End If
                    ElseIf Param1 = "BusquedaS" Then
                        DirectCast(CtlALg, Button).Text = valor
                    End If

                Case "CheckBox"
                    DirectCast(CtlALg, CheckBox).Checked = valor
                Case "MyCheckBox"
                    DirectCast(CtlALg, MyCheckBox).Checked = valor
                Case Else
                    CtlALg = Nothing
            End Select
        Catch ex As Exception

        End Try

    End Sub
    Sub clickbtnOpt(ByVal sender As Button, ByVal e As EventArgs)
        Select Case Param1
            Case "OpenFileDialog"
                Dim a As New OpenFileDialog
                a.CheckFileExists = True
                a.Multiselect = False
                If Param2 = "Imagen" Then
                    a.InitialDirectory = Application.StartupPath + "\Bmps\" & Param3
                Else 'por ahora
                    a.InitialDirectory = Application.StartupPath
                End If
                a.InitialDirectory = Application.StartupPath + "\Bmps\" & Param3
                If System.IO.File.Exists(a.InitialDirectory & "\" & sender.Tag) Then
                    a.FileName = sender.Tag
                End If
                If a.ShowDialog = DialogResult.OK Then
                    If Param2 = "Imagen" Then
                        If Not System.IO.File.Exists(Application.StartupPath + "\Bmps\" & Param3 & "\" & a.SafeFileName) Then
                            System.IO.File.Copy(a.FileName, Application.StartupPath + "\Bmps\" & Param3 & "\" & a.SafeFileName)
                        End If
                        CtlALg.Tag = a.SafeFileName
                        If Param3 <> "" Then
                            DirectCast(CtlALg, Button).BackgroundImage = cargarImagen(Application.StartupPath & "\BMPs\" & Param3 & "\" & a.SafeFileName)
                            DirectCast(CtlALg, Button).BackgroundImageLayout = ImageLayout.Zoom
                            '  DirectCast(CtlALg, Button).Size = New Size(150, 25)
                            If Param3 = "Texturas" Then
                                DirectCast(CtlALg, Button).BackColor = Color.White
                            End If
                        End If
                    End If
                End If

            Case "ColorDialog"
                Dim a As New ColorDialog
                a.AllowFullOpen = True
                a.AnyColor = True
                a.FullOpen = True
                a.SolidColorOnly = False
                If Not IsDBNull(sender.Tag) Then
                    a.Color = Color.FromArgb(sender.Tag)
                End If
                If a.ShowDialog() = DialogResult.OK Then
                    CtlALg.Tag = a.Color.ToArgb
                    sender.BackColor = a.Color
                End If
            Case "BusquedaS"
                Dim frmB As BusquedaS = New BusquedaS("xVende", "codigo")
                frmB.Text = "Seleccione Vendedor"
                frmB.ShowDialog()
                If frmB.DialogResult = DialogResult.OK Then
                    CtlALg.Tag = Convert.ToString(frmB.xdev)
                    CtlALg.Text = Convert.ToString(frmB.xdev)
                End If
        End Select

    End Sub

    Public Function GetValor() As Object
        Try
            Select Case ControlName
                Case "String"
                    Return CtlALg
                Case "ComboBox"
                    Return DirectCast(CtlALg, ComboBox).SelectedValue
                Case "TextBox"
                    Return DirectCast(CtlALg, TextBox).Text
                Case "NumericUpDown"
                    Return DirectCast(CtlALg, NumericUpDown).Value
                Case "Button"
                    Return DirectCast(CtlALg, Button).Tag
                Case "CheckBox"
                    Return DirectCast(CtlALg, CheckBox).Checked
                Case "MyCheckBox"
                    Return DirectCast(CtlALg, MyCheckBox).Checked
                Case Else
                    Return CtlALg
            End Select
        Catch ex As Exception
            MsgBox("Error al devolver Valor", MsgBoxStyle.Critical, "Opps cat 2")
            Return Nothing
        End Try
    End Function

    Friend Function Validar(ByVal absID As Integer) As Boolean
        If String.IsNullOrEmpty(queryValid) Then Return True 'No hay validacion
        'Se hace busqueda tanto de el resultado y el texto
        'la idea es que cuando ya tengamos que todas las filas en el resultado del query 
        'vienen con res='True'. Importante el orden en los parámetros indirectos de la consulta
        '1.- el valor a grabarse (GetValor)
        '2.- el id Absoluto de lo que se quiere modificar (lo que se envia como parámetro)
        Dim validation As New SqlBatch()
        validation.AddFormat(queryValid, GetValor(), absID)
        Dim tablaValid As DataTable = validation.Query(CStr(Cn_x_Defecto))
        If IsNothing(tablaValid) Then Return False
        If tablaValid.Rows.Count = 0 Then Return False
        For Each dR As DataRow In tablaValid.Rows
            Dim var As Object = dR.Item("Res")
            Dim var2 As Object = dR.Item("texto")
            If var.GetType = GetType(Boolean) Then
                If Not var Then
                    Me.TableLayoutPanel1.ColumnStyles(1).Width = 29
                    Me.ErrorProvider1.SetError(Me.Panel1, var2)
                    Return False
                Else
                    cleanErrProv()
                End If
            End If
        Next
        'Si llega acá es porque ninguna dió error
        Return True
    End Function

    Friend Sub cleanErrProv()
        Me.TableLayoutPanel1.ColumnStyles(1).Width = 1
        Me.ErrorProvider1.SetError(Me.Panel1, "")
        Me.ErrorProvider1.Clear()
    End Sub

    Private Sub PanelControlData_Paint(sender As Object, e As PaintEventArgs) Handles PanelControlData.Paint

    End Sub
End Class

