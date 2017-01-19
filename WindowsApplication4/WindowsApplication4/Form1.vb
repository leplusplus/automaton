Public Class Form1
    Dim label(100) As UserControl1
    Dim noflabel As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        noflabel += 1
        label(noflabel) = New UserControl1

        label(noflabel).Name = CStr(noflabel)
        label(noflabel).Left = 100 * noflabel
        label(noflabel).Top = 100
        label(noflabel).Text = CStr(noflabel)
        label(noflabel).Visible = True
        label(noflabel).BackColor = Color.Transparent

        Me.Controls.Add(label(noflabel))


        MsgBox("lable created")
    End Sub

    Private Sub Form1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click

    End Sub
End Class
