Public Class Form1
    Dim y(1000) As Single
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Dim g As Graphics = e.Graphics

        For i = 1 To Panel1.Width
            g.DrawLine(Pens.Black, i, y(i) * Panel1.Height, i - 1, y(i - 1) * Panel1.Height)
        Next
    End Sub

    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        Dim alpha As Single

        alpha = HScrollBar1.Value / 100.0 * 4
        y(0) = 0.5
        For i = 1 To Panel1.Width
            y(i) = alpha * y(i - 1) * (1 - y(i - 1))

        Next
        Panel1.Refresh()
        Panel1.Invalidate()

    End Sub
End Class
