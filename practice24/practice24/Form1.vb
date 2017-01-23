Public Class Form1
    Dim n As Integer
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Dim x, k As Single
        Dim i, j As Integer
    
        For i = 0 To Panel1.Width
            k = CSng(i) / CSng(Panel1.Width) * 2 + 2
            x = 0.5
            For j = 1 To n
                x = k * x * (1 - x)
                e.Graphics.DrawLine(Pens.Black, i, (1 - x) * Panel1.Height, i, (1 - x) * Panel1.Height - 1)

            Next
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        n = CStr(TextBox1.Text)
        Panel1.Refresh()

    End Sub
End Class
