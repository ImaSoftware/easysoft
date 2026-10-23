Imports System.Data

Module FUGSD
    Public Cn_x_Defecto As String = My.Settings.ConexionReportes

    Function cargarConsulta(ByVal sql As String) As DataTable
        Return Database.Query(sql, Cn_x_Defecto)
    End Function

    Function DataC(ByVal value As Object) As String
        Return If(value Is Nothing OrElse Convert.IsDBNull(value), "", Convert.ToString(value))
    End Function

    Sub imprimeComanda(ByVal id As Integer)
        SAAB.vReport.PrintComanda(id)
    End Sub

    Sub imprimePrefactura(ByVal id As Integer)
        SAAB.vReport.PrintPrefactura(id)
    End Sub
End Module
