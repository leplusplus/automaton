Public Class Form1
    Dim x(10000), y(10000), numberofPoint As Integer


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        numberofPoint = 0
        For i = 0 To 10000
            x(i) = Rnd() * Panel1.Width
            y(i) = Rnd() * Panel1.Height

            numberofPoint = numberofPoint + 1


        Next
      
        Panel1.Refresh()

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Dim i As Integer
        Dim g As Graphics
        g = e.Graphics

        For i = 0 To numberofPoint - 1
            g.DrawEllipse(Pens.Black, x(i) - 1, y(i) - 1, 2, 2)
        Next
    End Sub
End Class
