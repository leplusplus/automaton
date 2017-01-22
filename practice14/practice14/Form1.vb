Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Timer1.Enabled = True Then
            Button1.Text = "START"
            Timer1.Enabled = False
            result_display()
        Else
            Button1.Text = "STOP"
            Timer1.Enabled = True
            Label4.Text = ""
        End If
            End Sub
    Private Sub result_display()
        Dim a, b, c As Integer
        a = CInt(Label1.Text)
        b = CInt(Label2.Text)
        c = CInt(Label3.Text)
        '整列
        Dim d(6)
        For i = 1 To 6
            d(i) = 0
        Next
        d(a) = d(a) + 1
        d(b) = d(b) + 1
        d(c) = d(c) + 1
        If d(1) = 1 And d(2) = 1 And d(3) = 1 Then
            Label4.Text = "ヒフミ"
        End If
        If d(4) = 1 And d(5) = 1 And d(6) = 1 Then
            Label4.Text = "シゴロ"
        End If
        If d(1) = 3 Then
            Label4.Text = "ピン・アラシ"
        End If
        For i = 2 To 6
            If d(i) = 3 Then
                Label4.Text = "アラシ"
            End If
        Next
        For i = 1 To 6
            If d(i) = 2 Then
                For j = 1 To 6
                    If d(j) = 1 Then
                        Label4.Text = CStr(j) & "の目"
                    End If
                Next

            End If
        Next
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = CInt(Math.Floor(Rnd() * 6)) + 1
        Label2.Text = CInt(Math.Floor(Rnd() * 6)) + 1
        Label3.Text = CInt(Math.Floor(Rnd() * 6)) + 1


    End Sub
End Class
