Public Class Form1
    ' ソケット生成
    Private objSck As New System.Net.Sockets.UdpClient(9752)
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load
        ' ソケット接続
        objSck.Connect("192.168.1.100", 9751)

        ' ソケット非同期受信(System.AsyncCallback)
        objSck.BeginReceive(AddressOf ReceiveCallback, objSck)
    End Sub

    Private Sub Form1_FormClosed( _
        ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) _
        Handles MyBase.FormClosed
        ' ソケットクローズ
        objSck.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (Timer1.Enabled = False) Then
            Timer1.Enabled = True
        Else


            Timer1.Enabled = False

        End If
    End Sub

    Private Sub ReceiveCallback(ByVal AR As IAsyncResult)
        ' ソケット受信
        Dim udp As System.Net.Sockets.UdpClient = _
       DirectCast(AR.AsyncState, System.Net.Sockets.UdpClient)
        Dim ipAny As System.Net.IPEndPoint = New System.Net.IPEndPoint(System.Net.IPAddress.Any, 0)
        Dim dat As Byte() = o

        bjSck.EndReceive(AR, ipAny)
        Dim rcvmg As String = System.Text.Encoding.UTF8.GetString(dat)

        TextBox1.BeginInvoke(New Action(Of String)(AddressOf showstringtextbox), rcvmg)

        MsgBox(dat.ToString)
        ' ソケット非同期受信(System.AsyncCallback)
        objSck.BeginReceive(AddressOf ReceiveCallback, objSck)
    End Sub
   
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        ' ソケット送信
        Dim dat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes("4")
        objSck.Send(dat, dat.GetLength(0))
    End Sub
    Private Sub showstringtextbox(ByVal star As String)
        TextBox1.Text = star
    End Sub

End Class
  