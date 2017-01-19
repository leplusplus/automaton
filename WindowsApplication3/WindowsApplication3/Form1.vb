Public Class form1

    Dim x As Integer = 0
    Dim xold As Integer = 0

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
    Dim no1minsum As Long
    Dim no1maxsum As Long
    Dim no2minsum As Long
    Dim no2maxsum As Long
    Private udpClient As System.Net.Sockets.UdpClient = Nothing
    Dim flag = 0

    Public fromgraph As Windows.Forms.Form
    'フォームのLoadイベントハンドラ

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
            Handles MyBase.Load
        Button1.Text = "受信"
        Button2.Text = "送信"
    End Sub

    'Button1のClickイベントハンドラ
    'データ受信の待機を開始する
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles Button1.Click
        If udpClient IsNot Nothing Then
            Return
        End If
        DirectCast(sender, Button).Enabled = False
        Frmgraph.Show()


        'UdpClientを作成し、指定したポート番号にバインドする
        Dim localEP As New System.Net.IPEndPoint( _
            System.Net.IPAddress.Any, Integer.Parse(TextBox1.Text))
        udpClient = New System.Net.Sockets.UdpClient(localEP)
        '非同期的なデータ受信を開始する
        udpClient.BeginReceive(AddressOf ReceiveCallback, udpClient)
    End Sub

    'データを受信した時
    Private Sub ReceiveCallback(ByVal ar As IAsyncResult)
        Dim udp As System.Net.Sockets.UdpClient = _
            DirectCast(ar.AsyncState, System.Net.Sockets.UdpClient)

        '非同期受信を終了する
        Dim remoteEP As System.Net.IPEndPoint = Nothing
        Dim rcvBytes As Byte()
        Try
            rcvBytes = udp.EndReceive(ar, remoteEP)
        Catch ex As System.Net.Sockets.SocketException
            Console.WriteLine("受信エラー({0}/{1})", ex.Message, ex.ErrorCode)
            Return
        Catch ex As ObjectDisposedException
            'すでに閉じている時は終了
            Console.WriteLine("Socketは閉じられています。")
            Return
        End Try


        'データを文字列に変換する
        Dim rcvMsg As String = System.Text.Encoding.UTF8.GetString(rcvBytes)

        '受信したデータと送信者の情報をRichTextBoxに表示する




        RichTextBox1.BeginInvoke(New Action(Of String)(AddressOf ShowReceivedString), rcvMsg)



        '再びデータ受信を開始する
        udp.BeginReceive(AddressOf ReceiveCallback, udp)
    End Sub

    'RichTextBox1にメッセージを表示する
    Public Sub ShowReceivedString(ByVal str As String)
        RichTextBox1.Text = str & vbCrLf & RichTextBox1.Text
        My.Forms.Frmgraph.TextBox2.Text = str

        Dim grr As Graphics
        grr = Frmgraph.Panel1.CreateGraphics


        TextBox6.Text = str.Length


    

        ' create graph


        x = x + 1
        If (x > My.Forms.Frmgraph.Panel1.Width) Then
            My.Forms.Frmgraph.Panel1.Refresh()
            x = 1
            xold = 0
        End If

        no1 = 0
        no2 = 0

        For i = 1 To 4
            no1 = Asc(Mid(str, i, 1)) - 48 + no1 * 16

        Next i
        For i = 5 To 8
            no2 = Asc(Mid(str, i, 1)) - 48 + no2 * 16

        Next i

        My.Forms.Frmgraph.TextBox1.Text = no1

        My.Forms.Frmgraph.TextBox2.Text = no2

        If flag < 0 Then flag = -1

        If (flag = 0) Then
            no1min = no1
            no1max = no1 + 1
            no2min = no2
            no2max = no2 + 1
            no1maxsum = 0
            no1minsum = 0
            no2minsum = 0
            no2maxsum = 0
        End If
        If (no1 > no1max) Then
            no1max = no1
            My.Forms.Frmgraph.TextBox3.Text = no1max
        End If
        If (no1 < no1min) Then
            no1min = no1
            My.Forms.Frmgraph.TextBox4.Text = no1min
        End If
        If (no2 > no2max) Then
            no2max = no2
            My.Forms.Frmgraph.TextBox5.Text = no2max
        End If
        If (no2 < no2min) Then
            no2min = no2
            My.Forms.Frmgraph.TextBox6.Text = no2min
        End If
        flag = flag + 1
        My.Forms.Frmgraph.TextBox7.Text = flag
       
        no1minsum = no1minsum + no1min
        no1maxsum = no1maxsum + no1max
        no2minsum = no2minsum + no2min
        no2maxsum = no2maxsum + no2max
        If (flag = 1001) Then
            flag = flag - 1000
            no1max = no1maxsum / 1000
            no1min = no1minsum / 1000
            no2max = no2maxsum / 1000
            no2min = no2minsum / 1000
          
            no1maxsum = 0
            no1minsum = 0
            no2minsum = 0
            no2maxsum = 0
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

    End Sub

    'Button2のClickイベントハンドラ
    'データを送信する
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles Button2.Click
        '送信するデータを作成する
        Dim sendBytes As Byte() = _
            System.Text.Encoding.UTF8.GetBytes("4")

        'UdpClientを作成する
        If udpClient Is Nothing Then
            udpClient = New System.Net.Sockets.UdpClient()
        End If

        '非同期的にデータを送信する
        udpClient.BeginSend(sendBytes, sendBytes.Length, TextBox2.Text, _
            Integer.Parse(TextBox3.Text), AddressOf SendCallback, udpClient)
    End Sub




    'データを送信した時
    Private Sub SendCallback(ByVal ar As IAsyncResult)
        Dim udp As System.Net.Sockets.UdpClient = _
            DirectCast(ar.AsyncState, System.Net.Sockets.UdpClient)

        '非同期送信を終了する
        Try
            udp.EndSend(ar)
        Catch ex As System.Net.Sockets.SocketException
            Console.WriteLine("送信エラー({0}/{1})", ex.Message, ex.ErrorCode)
        Catch ex As ObjectDisposedException
            'すでに閉じている時は終了
            Console.WriteLine("Socketは閉じられています。")
        End Try
    End Sub

    'フォームのFormClosedイベントハンドラ
    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
            Handles MyBase.FormClosed
        'UdpClientを閉じる
        If udpClient IsNot Nothing Then
            udpClient.Close()
        End If
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Call Button2_Click(sender, e)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Timer1.Enabled = False Then

        Timer1.Enabled = True
        Else
            Timer1.Enabled = False

        End If

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class