Class Program
    'エントリポイント
    Public Shared Sub Main(ByVal args As String())
        'Processオブジェクトを作成
        Dim p As New System.Diagnostics.Process()

        '出力とエラーをストリームに書き込むようにする
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.RedirectStandardError = True
        'OutputDataReceivedとErrorDataReceivedイベントハンドラを追加
        AddHandler p.OutputDataReceived, AddressOf p_OutputDataReceived
        AddHandler p.ErrorDataReceived, AddressOf p_ErrorDataReceived

        p.StartInfo.FileName = _
            System.Environment.GetEnvironmentVariable("ComSpec")
        p.StartInfo.RedirectStandardInput = False
        p.StartInfo.CreateNoWindow = True
        p.StartInfo.Arguments = "/c dir c:\ /w"

        '起動
        p.Start()

        '非同期で出力とエラーの読み取りを開始
        p.BeginOutputReadLine()
        p.BeginErrorReadLine()

        p.WaitForExit()
        p.Close()

        Console.ReadLine()
    End Sub

    'OutputDataReceivedイベントハンドラ
    '行が出力されるたびに呼び出される
    Private Shared Sub p_OutputDataReceived(ByVal sender As Object, _
            ByVal e As System.Diagnostics.DataReceivedEventArgs)
        '出力された文字列を表示する
        Console.WriteLine(e.Data)
    End Sub

    'ErrorDataReceivedイベントハンドラ
    Private Shared Sub p_ErrorDataReceived(ByVal sender As Object, _
            ByVal e As System.Diagnostics.DataReceivedEventArgs)
        'エラー出力された文字列を表示する
        Console.WriteLine("ERR>{0}", e.Data)
    End Sub

    'エントリポイント


    Private Sub commit()
        Dim p As New System.Diagnostics.Process()

        'ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
        p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec")
        '出力を読み取れるようにする
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.RedirectStandardInput = False
        'ウィンドウを表示しないようにする
        p.StartInfo.CreateNoWindow = True
        'コマンドラインを指定（"/c"は実行後閉じるために必要）
        p.StartInfo.Arguments = "/c C:\Users\Le\Documents\gitcommit.bat abc"

        '起動
        p.Start()

        '出力を読み取る
        Dim results As String = p.StandardOutput.ReadToEnd()

        'プロセス終了まで待機する
        'WaitForExitはReadToEndの後である必要がある
        '(親プロセス、子プロセスでブロック防止のため)
        p.WaitForExit()
        p.Close()

        '出力された結果を表示
        Console.WriteLine(results)
    End Sub
    Private Sub push()
        Dim p As New System.Diagnostics.Process()

        'ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
        p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec")
        '出力を読み取れるようにする
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.RedirectStandardInput = False
        'ウィンドウを表示しないようにする
        p.StartInfo.CreateNoWindow = True
        'コマンドラインを指定（"/c"は実行後閉じるために必要）
        p.StartInfo.Arguments = "/c C:\Users\Le\Documents\gitpush.bat abc"

        '起動
        p.Start()

        '出力を読み取る
        Dim results As String = p.StandardOutput.ReadToEnd()

        'プロセス終了まで待機する
        'WaitForExitはReadToEndの後である必要がある
        '(親プロセス、子プロセスでブロック防止のため)
        p.WaitForExit()
        p.Close()

        '出力された結果を表示
        Console.WriteLine(results)
    End Sub

    Private Sub Program_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Call commit()

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Call push()
    End Sub
End Class
