
Public Class Form1
    Dim y(1000)

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

        For i = 1 To Panel1.Width

            e.Graphics.DrawLine(Pens.Black, i - 1, Panel1.Height * (1 - y(i - 1)), i, (1 - y(i)) * Panel1.Height)
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        Dim k, x0 As Single

        x0 = 0.5
        k = HScrollBar1.Value / 100 * 4.0


        y(0) = x0
        For i = 1 To Panel1.Width
            y(i) = k * y(i - 1) * (1 - y(i - 1))
        Next
        Panel1.Refresh()
    End Sub
End Class

