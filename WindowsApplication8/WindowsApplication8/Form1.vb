Public Class Form1
    Dim a, b As Single
    Private Sub pnldraw_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnldraw.Paint
        Dim g As Graphics
        g = e.Graphics
        Dim pen1, pen2, pen3 As Pen
        pen1 = Pens.Black
        pen2 = Pens.Blue
        pen3 = Pens.LightCyan
        Dim font1 As Font
        font1 = New Font("MS UI Gothic", 10, FontStyle.Bold)
        Dim brush1 As Brush
        brush1 = Brushes.Black

        Dim y, yold As Single
        yold = a * Math.Sin(0) + b * Math.Cos(0)
        For I = 0 To Math.PI * 2 Step 0.01
            y = a * Math.Sin(I) + b * Math.Cos(I)
            g.DrawLine(pen1, CInt(I / Math.PI / 2.0 * pnldraw.Width), CInt(pnldraw.Height * 0.9 - (y + a + b) / ((a + b) * 2.0) * pnldraw.Height * 0.8), CInt((I - 0.01) / Math.PI / 2.0 * pnldraw.Width), CInt(pnldraw.Height * 0.9 - (yold + a + b) / ((a + b) * 2.0) * pnldraw.Height * 0.8))
            yold = y

        Next
        g.DrawLine(pen2, 0, CInt(pnldraw.Height / 2), pnldraw.Width, CInt(pnldraw.Height / 2))

        g.DrawLine(pen3, 0, CInt(pnldraw.Height * 0.1), pnldraw.Width, CInt(pnldraw.Height * 0.1))
        g.DrawLine(pen3, 0, CInt(pnldraw.Height * 0.9), pnldraw.Width, CInt(pnldraw.Height * 0.9))

        g.DrawLine(pen2, CInt(pnldraw.Width / 2), CInt(pnldraw.Height * 0.1), CInt(pnldraw.Width / 2), CInt(pnldraw.Height * 0.9))

        g.DrawLine(pen3, CInt(0), CInt(pnldraw.Height * 0.1), CInt(0), CInt(pnldraw.Height * 0.9))
        g.DrawLine(pen3, CInt(pnldraw.Width / 4), CInt(pnldraw.Height * 0.1), CInt(pnldraw.Width / 4), CInt(pnldraw.Height * 0.9))
        g.DrawLine(pen3, CInt(pnldraw.Width * 3 / 4), CInt(pnldraw.Height * 0.1), CInt(pnldraw.Width * 3 / 4), CInt(pnldraw.Height * 0.9))
        g.DrawLine(pen3, CInt(pnldraw.Width - 1), CInt(pnldraw.Height * 0.1), CInt(pnldraw.Width - 1), CInt(pnldraw.Height * 0.9))

        g.DrawString("0", font1, brush1, 5, CInt(pnldraw.Height / 2 + 5))
        g.DrawString("1/2Π", font1, brush1, CInt(pnldraw.Width / 4 - 10), CInt(pnldraw.Height / 2 + 5))
        g.DrawString("Π", font1, brush1, CInt(pnldraw.Width / 2 - 10), CInt(pnldraw.Height / 2 + 5))
        g.DrawString("3/2Π", font1, brush1, CInt(pnldraw.Width * 3 / 4 - 10), CInt(pnldraw.Height / 2 + 5))
        g.DrawString("2Π", font1, brush1, CInt(pnldraw.Width - 20), CInt(pnldraw.Height / 2 + 5))


        g.DrawString(CStr(a + b), font1, brush1, CInt(pnldraw.Width / 2), CInt(pnldraw.Height * 0.1 + 5))
        g.DrawString("0", font1, brush1, CInt(pnldraw.Width / 2), CInt(pnldraw.Height * 0.5 + 5))
        g.DrawString(CStr(-a - b), font1, brush1, CInt(pnldraw.Width / 2), CInt(pnldraw.Height * 0.9 + 5))

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        a = CSng(TextBox1.Text)
        b = CSng(TextBox2.Text)
        pnldraw.Refresh()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        a = 1
        b = 1


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        OpenFileDialog1.ShowDialog()

    End Sub
End Class
