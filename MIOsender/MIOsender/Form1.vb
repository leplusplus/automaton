Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (Timer1.Enabled = True) Then
            Timer1.Enabled = False
            TextBox1.Text = "STOP"
        Else
            Timer1.Enabled = True
            TextBox1.Text = Timer1.Interval



        End If



    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        UdpSender.Main()


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged


    End Sub
End Class
Public Class UdpSender
    Public Shared Sub Main()
        'データを送信するリモートホストとポート番号
        Dim remoteHost As String = "192.168.1.100"
        Dim remotePort As Integer = 9751

        'UdpClientオブジェクトを作成する
        Dim udp As New System.Net.Sockets.UdpClient()


        '送信するデータを作成する
        '     Console.WriteLine("送信する文字列を入力してください。")
        Dim sendMsg As String = "4"
        Dim sendBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(sendMsg)

        'リモートホストを指定してデータを送信する
        udp.Send(sendBytes, sendBytes.Length, remoteHost, remotePort)

        'または、
        'udp = New UdpClient(remoteHost, remotePort)
        'として、
        'udp.Send(sendBytes, sendBytes.Length)


        'UdpClientを閉じる
        udp.Close()

        '   Console.WriteLine("終了しました。")
        '  Console.ReadLine()
    End Sub
End Class