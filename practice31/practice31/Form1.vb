Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim num_begin, num_end As Integer
        Dim is_prime As Boolean
        Dim n_ofprime As Integer


        Try
            num_begin = CInt(TextBox1.Text)
        Catch ex As Exception
            MsgBox("「整数を入力してください")
            TextBox1.Text = ""
            TextBox1.Focus()
            Exit Sub

        End Try
        Try
            num_end = CInt(TextBox2.Text)
        Catch ex As Exception
            MsgBox("「整数を入力してください")
            TextBox2.Text = ""
            TextBox2.Focus()
            Exit Sub
        End Try

        If num_begin >= num_end Then
            MsgBox("開始数は終了数より小さくなくてはなりません。")
            Exit Sub
        End If
        TextBox3.Text = ""

        n_ofprime = 0
        For i = num_begin To num_end
            is_prime = True
            For j = 2 To CInt(Math.Sqrt(i)) + 1
                If i Mod j = 0 Then
                    is_prime = False

                End If
            Next
            If is_prime = True Then
                TextBox3.Text = TextBox3.Text & vbCrLf & CStr(i)
                n_ofprime = n_ofprime + 1
                Label4.Text = CStr(n_ofprime)
            End If
        Next



    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class
