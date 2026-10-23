Namespace My
    Partial Friend Class MyApplication
        Private Sub HandleFailure(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            MsgBox(Database.UserError(e.Exception), MsgBoxStyle.Exclamation, "SAAB")
            e.ExitApplication = True
        End Sub
    End Class
End Namespace
