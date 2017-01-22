
Public Class Form1
    Dim x(10000), y(10000), numberofPoint As Integer
    Dim inside, outside As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        inside = 0
        outside = 0
        numberofPoint = 0

        For i = 0 To 9999
            x(i) = Rnd() * Panel1.Width
            y(i) = Rnd() * Panel1.Height

            If (x(i) - Panel1.Width / 2) * (x(i) - Panel1.Width / 2) + (y(i) - Panel1.Height / 2) * (y(i) - Panel1.Height / 2) < (Panel1.Width * Panel1.Width / 4) Then
                inside = inside + 1
            Else
                outside = outside + 1
            End If

            numberofPoint = numberofPoint + 1
            Label1.Text = CStr(inside / (inside + outside) * 4)
        Next

        Panel1.Refresh()

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Dim i As Integer
        Dim g As Graphics

        g = e.Graphics



        For i = 0 To numberofPoint
            g.DrawEllipse(Pens.Black, x(i) - 1, y(i) - 1, 2, 2)
        Next

        g.DrawEllipse(Pens.Red, 0, 0, Panel1.Width, Panel1.Height)

    End Sub
End Class
