Public Class Form1
    Dim numberofprime(10000) As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i, j As Integer
        Dim isprime As Boolean
        For i = 5000 To 50001 + Panel1.Width
            isprime = True
            For j = 2 To CInt(Math.Sqrt(i))
                If i Mod j = 0 Then
                    isprime = False
                    Exit For
                End If

            Next j
            If isprime = True Then
                numberofprime(i) = numberofprime(i - 1) + 1
            Else
                numberofprime(i) = numberofprime(i - 1)
            End If

        Next i
        Panel1.Refresh()

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        For i = 0 To Panel1.Width
            e.Graphics.DrawLine(Pens.Black, i, 0, i, numberofprime(5000 + i))

        Next
    End Sub
End Class
