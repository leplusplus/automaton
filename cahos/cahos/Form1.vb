Public Class Form1


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
       

      
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Dim g As Graphics
        Dim y As Single
        Dim alpha As Single

        g = e.Graphics
        Dim n As Integer
        For x = 0 To Panel1.Width
            alpha = (CSng(x) / Panel1.Width * 4.0) / 2 + 2
            y = 0.1
            For n = 1 To 10
                y = alpha * y * (1 - y)
            Next
            For n = 1 To HScrollBar1.Value
                y = alpha * y * (1 - y)
                g.DrawLine(Pens.Black, x, y * Panel1.Height, x, (y * Panel1.Height) - 1)
            Next
        Next



    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



    End Sub

    Private Sub HScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HScrollBar1.ValueChanged
        Panel1.Refresh()
    End Sub
End Class
