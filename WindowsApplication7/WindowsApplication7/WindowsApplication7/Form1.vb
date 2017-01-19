Public Class Form1
    Dim dayofmonth(12) As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim year, month, day As Integer
        Dim result As Integer
        dayofmonth(1) = 31
        dayofmonth(2) = 28
        dayofmonth(3) = 31
        dayofmonth(4) = 30
        dayofmonth(5) = 31
        dayofmonth(6) = 30
        dayofmonth(7) = 31
        dayofmonth(8) = 31
        dayofmonth(9) = 30
        dayofmonth(10) = 31
        dayofmonth(11) = 30
        dayofmonth(12) = 31


        year = CInt(TextBox1.Text)
        month = CInt(TextBox2.Text)
        day = CInt(TextBox3.Text)
        If ((year Mod 4 = 0) And ((year Mod 100 <> 0)) Or (year Mod 400 = 0)) Then
            dayofmonth(2) = 29
        End If
        For i = 1 To month - 1
            result = result + dayofmonth(i)
        Next
        result = result + day
        Label1.Text = CStr(result) & "日目です。"
    End Sub
End Class
