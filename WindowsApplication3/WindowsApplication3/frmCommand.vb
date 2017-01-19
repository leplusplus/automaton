Public Class form1

    Dim x As Integer = 0
    Dim xold As Integer = 0

    Dim y1 As Long
    Dim y2 As Long
    Dim y3 As Long
    Dim y1old As Long
    Dim y2old As Long
    Dim y3old As Long
    Dim no1 As Long
    Dim no1min As Long
    Dim no1max As Long
    Dim no2 As Long
    Dim no2min As Long
    Dim no2max As Long
    Dim no3 As Long
    Dim no3min As Long
    Dim no3max As Long
    Dim no1minsum As Long
    Dim no1maxsum As Long
    Dim no2minsum As Long
    Dim no2maxsum As Long
    Dim no3minsum As Long
    Dim no3maxsum As Long
    Private udpClient As System.Net.Sockets.UdpClient = Nothing
    Dim flag As Integer = 0

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

        Dim grr As Graphics
        grr = Frmgraph.Panel1.CreateGraphics


        If str.Length < 31 Then
            RichTextBox1.Text = str

            Return
        End If
        TextBox6.Text = str.Length.ToString








    

        ' create graph


        x = x + 1
        If (x > My.Forms.Frmgraph.Panel1.Width) Then
            My.Forms.Frmgraph.Panel1.Refresh()
            x = 1
            xold = 0
        End If

        no1 = 0
        no2 = 0
        no3 = 0
        For i = 3 To 6
            no1 = Asc(Mid(str, i, 1)) - 48 + no1 * 16

        Next i
        For i = 7 To 10
            no2 = Asc(Mid(str, i, 1)) - 48 + no2 * 16

        Next i
        For i = 11 To 14
            no3 = Asc(Mid(str, i, 1)) - 48 + no3 * 16

        Next i
        My.Forms.Frmgraph.Label1.Text = no1.ToString


        My.Forms.Frmgraph.Label2.Text = no2.ToString
        My.Forms.Frmgraph.Label3.Text = no3.ToString



        If (flag = 0) Then
            MsgBox("reset" & flag.ToString)

            no1min = no1
            no1max = no1 + 1
            no2min = no2
            no2max = no2 + 1
            no3min = no3
            no3max = no3 + 1
            no1maxsum = 0
            no1minsum = 0
            no2minsum = 0
            no2maxsum = 0
            no3maxsum = 0
            no3minsum = 0
        End If
        If (no1 > no1max) Then
            no1max = no1
            My.Forms.Frmgraph.Label4.Text = no1max.ToString
        End If
        If (no1 < no1min) Then
            no1min = no1
            My.Forms.Frmgraph.Label5.Text = no1min.ToString

        End If
        If (no2 > no2max) Then
            no2max = no2
            My.Forms.Frmgraph.Label6.Text = no2max.ToString
        End If
        If (no2 < no2min) Then
            no2min = no2
            My.Forms.Frmgraph.Label7.Text = no2min.ToString
        End If
        If (no3 > no3max) Then
            no3max = no3
            My.Forms.Frmgraph.Label8.Text = no3max.ToString
        End If
        If (no3 < no3min) Then
            no3min = no3
            My.Forms.Frmgraph.Label9.Text = no3min.ToString
        End If
        flag = flag + 1
        My.Forms.Frmgraph.Label10.Text = flag.ToString

        no1minsum = no1minsum + no1min
        no1maxsum = no1maxsum + no1max
        no2minsum = no2minsum + no2min
        no2maxsum = no2maxsum + no2max
        no3minsum = no3minsum + no3min
        no3maxsum = no3maxsum + no3max
        If (flag = 101) Then
            flag = flag - 100
            no1max = CLng(CDbl(no1maxsum) / 100.0)
            no1min = CLng(CDbl(no1minsum) / 100.0)
            no2max = CLng(CDbl(no2maxsum) / 100.0)
            no2min = CLng(CDbl(no2minsum) / 100.0)
            no3max = CLng(CDbl(no3maxsum) / 100.0)
            no3min = CLng(CDbl(no3minsum) / 100.0)

            no1maxsum = 0
            no1minsum = 0
            no2minsum = 0
            no2maxsum = 0
            no3minsum = 0
            no3maxsum = 0

        End If
        y1 = no1 - no1min
        y1 = CLng(CDbl(y1) / CDbl(no1max - no1min) * CDbl(Panel1.Height))
        y2 = no2 - no2min
        y2 = CLng(CDbl(y2) / CDbl(no2max - no2min) * CDbl(Panel1.Height))
        y3 = no3 - no3min
        y3 = CLng(CDbl(y3) / CDbl(no3max - no3min) * CDbl(Panel1.Height))
        grr.DrawLine(System.Drawing.Pens.Blue, x, y1, xold, y1old)
        grr.DrawLine(System.Drawing.Pens.Red, x, y2, xold, y2old)
        grr.DrawLine(System.Drawing.Pens.Black, x, y3, xold, y3old)
        y1old = y1
        y2old = y2
        y3old = y3
        xold = x

    End Sub

    'Button2のClickイベントハンドラ
    'データを送信する
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)

        '送信するデータを作成する
        Dim sendbytes As Byte()

        If (TextBox4.Text = "") Then

            sendbytes = System.Text.Encoding.UTF8.GetBytes("4")
        Else
            sendbytes = System.Text.Encoding.UTF8.GetBytes(TextBox4.Text)

        End If

        'UdpClientを作成する
        If udpClient Is Nothing Then
            udpClient = New System.Net.Sockets.UdpClient()
        End If

        '非同期的にデータを送信する
        udpClient.BeginSend(sendbytes, sendbytes.Length, TextBox2.Text, _
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
            TextBox4.Enabled = False
        Timer1.Enabled = True
        Else
            TextBox4.Enabled = True
            Timer1.Enabled = False
        End If

    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '送信するデータを作成する
        Dim sendbytes As Byte()

        If (TextBox4.Text = "") Then

            sendbytes = System.Text.Encoding.UTF8.GetBytes("4")
        Else
            sendbytes = System.Text.Encoding.UTF8.GetBytes(TextBox4.Text)

        End If

        'UdpClientを作成する
        If udpClient Is Nothing Then
            udpClient = New System.Net.Sockets.UdpClient()
        End If

        '非同期的にデータを送信する
        udpClient.BeginSend(sendbytes, sendbytes.Length, TextBox2.Text, _
            Integer.Parse(TextBox3.Text), AddressOf SendCallback, udpClient)
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Timer1.Enabled = False
        TextBox4.Visible = True
    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged

    End Sub
End Class