Public Class Form1
    Dim x As Single

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim k, x0 As Single
        TextBox3.Text = ""

        Try
            k = CSng(TextBox1.Text)
        Catch ex As Exception
            MsgBox("kは数値で、0≦k≦4）でなくてはなりません。")
            Exit Sub
        End Try
        Try
            x0 = CSng(TextBox2.Text)
        Catch ex As Exception
            MsgBox("x0は数値で、0≦k≦1）でなくてはなりません。")
            Exit Sub
        End Try
        If k < 0 Or k > 4 Or x0 < 0 Or x0 > 1 Then
            MsgBox("0≦k≦4、かつ　0≦k≦1　でなくてはなりません")
            Exit Sub
        End If

        x = x0
        For i = 1 To 100
            x = k * x * (1 - x)
        Next
        For i = 1 To 10
            x = k * x * (1 - x)
            TextBox3.Text = TextBox3.Text & vbCrLf & CStr(x)

        Next

    End Sub
End Class
