
Public Class form1
    Dim x As Integer
    Dim y As Integer
    Dim y2 As Integer
    Dim xold As Integer
    Dim y2old As Integer
    Dim y3 As Integer
    Dim y3old As Integer

    Private Sub form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Console.Write("click")
        Call Mainloop()
    End Sub

   
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Public Sub Mainloop()
        'バインドするローカルIPとポート番号
        Dim localIpString As String = "192.168.1.6"
        Dim localAddress As System.Net.IPAddress = _
            System.Net.IPAddress.Parse(localIpString)
        Dim localPort As Integer = 9752
        Console.Write("MAIN LOOP")
        'UdpClientを作成し、ローカルエンドポイントにバインドする
        Dim localEP As New System.Net.IPEndPoint(localAddress, localPort)
        Dim udp As New System.Net.Sockets.UdpClient(localEP)
        Dim grr As Graphics
        Dim x As Integer
        Dim y1 As Long
        Dim y2 As Long
        Dim y1old As Long
        Dim y2old As Long
        Dim no1 As Long
        Dim no1min As Long
        Dim no1max As Long
        Dim no2 As Long
        Dim no2min As Long
        Dim no2max As Long


        '       Dim textstrm = New System.IO.StreamWriter("C:\Users\Le\Documents\YURIGAOKA\data.txt", True)
        grr = Panel1.CreateGraphics()

        x = 0
        Dim flag = True
        While True
            'データを受信する
            Dim remoteEP As System.Net.IPEndPoint = Nothing
            Dim rcvBytes As Byte() = udp.Receive(remoteEP)
            x = x + 1
            If (x > Panel1.Width) Then
                Panel1.Refresh()
                xold = 0

                x = 0
            End If


            'データを文字列に変換する
            Dim rcvMsg As String = System.Text.Encoding.UTF8.GetString(rcvBytes)

            Console.Write("Data:" & rcvMsg)
            Console.Write(Len(rcvMsg))


            '受信したデータと送信者の情報を表示する

            no1 = 0
            no2 = 0

            For i = 1 To 4
                no1 = Asc(Mid(rcvMsg, i, 1)) - 48 + no1 * 16

            Next i
            For i = 5 To 8
                no2 = Asc(Mid(rcvMsg, i, 1)) - 48 + no2 * 16

            Next i
            '   dt = DateTime.Now
            '  textstrm.WriteLine(dt.ToString & "," & no1.ToString & "," & no2.ToString)

            Console.Write("Data1:")
            Console.Write(no1)
            Console.Write("Data2:")
            Console.Write(no2)

            Console.WriteLine()
            If (x = 1) And (flag = True) Then
                no1min = no1
                no1max = no1 + 1
                no2max = no2 + 1
                no2min = no2
                flag = False
            End If
            If (no1 > no1max) Then
                no1max = no1
                TextBox1.Text = no1max
            End If
            If (no1 < no1min) Then
                no1min = no1
                TextBox2.Text = no1min

            End If
            If (no2 > no2max) Then
                no2max = no2
            End If
            If (no2 < no2min) Then
                no2min = no2
            End If
            y1 = no1 - no1min
            y1 = y1 / (no1max - no1min) * Panel1.Height * 1.0
            y2 = no2 - no2min
            y2 = y2 / (no2max - no2min) * Panel1.Height * 1.0
            grr.DrawLine(System.Drawing.Pens.Blue, x, y1, xold, y1old)
            grr.DrawLine(System.Drawing.Pens.Red, x, y2, xold, y2old)
            y1old = y1
            y2old = y2
            xold = x
            'Console.Write("X:")
            'Console.Write(x)
            'Console.Write("Y:")
            'Console.Write(y2)

            '          Panel1.Refresh()
            'Panel1.Invalidate()

            '    System.Threading.Thread.Sleep(10000)




            '"exit"を受信したら終了
            If rcvMsg.Equals("exit") Then
                Exit While
            End If


        End While

        'UdpClientを閉じる
        udp.Close()

        Console.WriteLine("終了しました。")
        Console.ReadLine()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Panel1_Paint_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
