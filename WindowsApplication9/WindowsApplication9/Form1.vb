Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim filein As String
        OpenFileDialog1.ShowDialog()
        filein = OpenFileDialog1.FileName

        Dim fs As IO.StreamReader
        fs = New IO.StreamReader(filein)

        Dim oneline As String
        oneline = fs.ReadLine
        Dim fields() As String
        While (oneline <> "")
            fields = Split(oneline, ",")
            If (Mid(fields(4), 2, 8) = TextBox1.Text) Then
                TextBox2.Text = fields(7) & fields(9) & fields(13)
            End If

            oneline = fs.ReadLine


        End While
    End Sub


End Class
