Public Class Form1
    Dim numberofdata As Integer
    Dim data(100) As String
    Dim selected(100) As Boolean
    Dim answer(100) As Integer
    Dim ndata As String
    Dim nanswer As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            numberofdata = CInt(TextBox1.Text)

            ndata = 1
            TextBox2.Visible = True
            Button2.Visible = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        data(ndata) = TextBox2.Text
        ndata = ndata + 1
        TextBox2.Text = ""
        If ndata > numberofdata Then
            Button2.Visible = False
            TextBox2.Visible = False
            Button3.visible = True
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        docomposite(numberofdata)

    End Sub

    Private Sub docomposite(ByVal iii As Integer)
     
        If iii = 1 Then
            answer(numberofdata - iii + 1) = 1
            printresult()
            Return
        End If

        For i = 1 To iii
            answer(numberofdata - iii + 1) = i
            docomposite(iii - 1)
        Next




    End Sub
    Private Sub printresult()
        Dim i, j, s As Integer
        For i = 1 To numberofdata
            selected(i) = False
        Next
        For i = 1 To numberofdata
            s = 1
            For j = 1 To numberofdata
                If selected(j) = False Then


                    If s = answer(i) Then
                        TextBox3.Text = TextBox3.Text & data(j)
                        selected(j) = True

                    End If
                    s = s + 1
                End If

            Next
        Next
        TextBox3.Text = TextBox3.Text & vbCrLf
    End Sub
End Class
