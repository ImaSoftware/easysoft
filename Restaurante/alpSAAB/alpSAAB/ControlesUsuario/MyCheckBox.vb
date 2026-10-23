Imports System.Drawing
Imports System.Windows.Forms

Class MyCheckBox
    Inherits CheckBox
    Public Sub New()
        Me.TextAlign = ContentAlignment.MiddleCenter
        Me.CheckAlign = ContentAlignment.MiddleCenter
    End Sub
    Public Overrides Property AutoSize() As Boolean
        Get
            Return MyBase.AutoSize
        End Get
        Set
            MyBase.AutoSize = False
        End Set
    End Property
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        If Me.ClientSize.Height <= 5 Then Exit Sub
        Dim h As Integer = Me.ClientSize.Height * 0.5
        Dim w As Integer = Me.ClientSize.Width * 0.5
        Dim rc As New Rectangle(New Point(w / 2, h / 2), New Size(w, h))
        Try
            ControlPaint.DrawCheckBox(e.Graphics, rc, If(Me.Checked, ButtonState.Checked, ButtonState.Pushed))
        Catch ex As Exception
            MsgBox("opps")
        End Try

    End Sub
End Class

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

