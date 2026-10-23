Public Class dolfinBox

    Inherits TextBox

    Protected Overrides Sub OnReadOnlyChanged(ByVal e As System.EventArgs)
        MyBase.OnEnabledChanged(e)
        ' If Enabled Then
        'BackColor = Color.White
        'Else
        BackColor = Color.White
        ' End If
    End Sub

End Class
