Public Class Tema
    Property ID As Integer
    Property colorPrimario As Color
    Property colorSecundario As Color
    Property FontName As String = "Arial"
    Property fontsize As Integer = 11
    Public Sub cargarTema(ByVal istC As Integer)
        Dim sqlTema As String = String.Format("Select * from SD_SysParam_Temas where id = {0}", Globales.Parametros.CombinacionColores)
        Dim dtttema As DataTable = cargarConsulta(sqlTema)
        If Not IsNothing(dtttema) Then
            If dtttema.Rows.Count = 0 Then
                MsgBox("Tema Invalido, consulte a su proveedor.", MsgBoxStyle.Exclamation, "Opps!!!")
                Exit Sub
            ElseIf dtttema.Rows.Count > 1 Then
                MsgBox("Id de tema duplicado. No se puede cargar", MsgBoxStyle.Exclamation, "Opps!!!")
                Exit Sub
            End If
        Else
            MsgBox("La consulta ha fallado. No se puede cargar el tema")
            Exit Sub
        End If
        colorPrimario = Color.FromArgb(Numero(DataC(dtttema(0)("DolphinColor1"))))
        colorSecundario = Color.FromArgb(Numero(DataC(dtttema(0)("DolphinColor2"))))
        FontName = DataC(dtttema(0)("f_name"))
        fontsize = DataC(dtttema(0)("f_size"))
        'si llega ak es porque no hubo errores
    End Sub

End Class
