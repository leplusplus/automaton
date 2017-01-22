Public Class Form1

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Dim g As Graphics
        Dim i As Integer
        Dim x, y As Integer
        g = e.Graphics
        For i = 1 To 100
            x = CInt(Rnd() * Panel1.Width)
            y = CInt(Rnd() * Panel1.Height)
            g.DrawEllipse(Pens.Black, x - 1, y - 1, 2, 2)

        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
       
        Panel1.Refresh()


    End Sub
End Class
