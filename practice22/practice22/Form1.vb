Public Class Form1
    Dim y(1000)

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim k, x0 As Single
       
        Try
            k = CSng(TextBox1.Text)
        Catch ex As Exception
            MsgBox("kは数値で、0≦k≦4）でなくてはなりません。")
            TextBox1.Text = ""
            TextBox1.Focus()

            Exit Sub
        End Try
        Try
            x0 = CSng(TextBox2.Text)
        Catch ex As Exception
            MsgBox("x0は数値で、0≦x0≦1）でなくてはなりません。")
            TextBox2.Text = ""
            TextBox2.Focus()
            Exit Sub
        End Try

        If k < 0 Or k > 4 Or x0 < 0 Or x0 > 1 Then
            MsgBox("0≦k≦4、かつ　0≦k≦1　でなくてはなりません")
            Exit Sub
        End If

        y(0) = x0
        For i = 1 To Panel1.Width
            y(i) = k * y(i - 1) * (1 - y(i - 1))
        Next
        Panel1.Refresh()

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

        For i = 1 To Panel1.Width

            e.Graphics.DrawLine(Pens.Black, i - 1, Panel1.Height * (1 - y(i - 1)), i, (1 - y(i)) * Panel1.Height)
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
