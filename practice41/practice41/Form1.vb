Public Class Form1
    Dim h As Single
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Dim g As Graphics
        g = e.Graphics
        Dim y, yold As Single
        Dim i As Integer

        g.DrawLine(Pens.Red, 0, 0, 0, Panel1.Height)
        g.DrawLine(Pens.Red, CInt(Panel1.Width / 4.0), 0, CInt(Panel1.Width / 4.0), Panel1.Height)
        g.DrawLine(Pens.Red, CInt(Panel1.Width / 2.0), 0, CInt(Panel1.Width / 2.0), Panel1.Height)
        g.DrawLine(Pens.Red, CInt(Panel1.Width / 4.0 * 3.0), 0, CInt(Panel1.Width / 4.0 * 3.0), Panel1.Height)
        g.DrawLine(Pens.Red, Panel1.Width, 0, Panel1.Width, Panel1.Height)

        g.DrawLine(Pens.Blue, 0, 0, Panel1.Width, 0)
        g.DrawLine(Pens.Blue, 0, CInt(Panel1.Height / 4.0), CInt(Panel1.Width), CInt(Panel1.Height / 4.0))
        g.DrawLine(Pens.Blue, 0, CInt(Panel1.Height / 2.0), CInt(Panel1.Width), CInt(Panel1.Height / 2.0))
        g.DrawLine(Pens.Blue, 0, CInt(Panel1.Height / 4.0 * 3.0), CInt(Panel1.Width), CInt(Panel1.Height / 4.0 * 3.0))
        g.DrawLine(Pens.Blue, 0, CInt(Panel1.Height), CInt(Panel1.Width), CInt(Panel1.Height))

        yold = CSng(Panel1.Height) / 2.0
        For i = 1 To Panel1.Width
            y = Math.Sin(CSng(i) / CSng(Panel1.Width) * 2.0 * Math.PI) * h
            y = ((-y) / 2.0 + 0.5) * Panel1.Height
            g.DrawLine(Pens.Black, i - 1, CInt(yold), i, CInt(y))
            yold = y
        Next
    End Sub

    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        h = CSng(HScrollBar1.Value) / 100.0
        Label4.Text = "y=" & CStr(h) & " * sin(x) "
        Panel1.Refresh()

    End Sub
End Class
