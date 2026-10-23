Public Class About
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        System.Diagnostics.Process.Start("http://syscompsa.com/")
    End Sub

    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox4.MouseHover
        PictureBox4.Cursor = Cursors.Hand
    End Sub

    Private Sub About_Load(sender As Object, e As EventArgs) Handles Me.Load
        Version.Text = "Version: " & My.Application.Info.Version.ToString
    End Sub

    Private Sub Ventana_Paint(sender As Object, e As PaintEventArgs) Handles Ventana.Paint

    End Sub
End Class