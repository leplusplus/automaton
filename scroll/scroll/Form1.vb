Public Class Form1
    Dim sp As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TextBox1.Text = TextBox1.Text & "A"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        sp = CInt(ComboBox1.SelectedItem)
        TextBox1.Text = ""
        Timer1.Interval = 1000 / sp * 8
        Timer1.Enabled = True

    End Sub
End Class
