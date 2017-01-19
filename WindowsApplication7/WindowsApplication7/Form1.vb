Public Class Form1
    Private NotifyIcon1 As System.Windows.Forms.NotifyIcon

    'フォームのLoadイベントハンドラ
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Load

        'NotifyIconオブジェクトを作成する
        'Me.componentsが存在しないならば、省略する
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
      
        'NotifyIconをタスクトレイに表示する
        Me.NotifyIcon1.Visible = True
        'アイコンの上にマウスポインタを移動した時に表示される文字列
        Me.NotifyIcon1.Text = "NotifyIcon1"
        'アイコンを右クリックしたときに表示するコンテキストメニュー
        'ContextMenuStrip1はすでに用意されているものとする
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        'Clickイベントハンドラを追加する
        AddHandler Me.NotifyIcon1.Click, _
            New EventHandler(AddressOf NotifyIcon1_Click)
    End Sub

    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As EventArgs)
        System.Windows.Forms.MessageBox.Show("アイコンがクリックされました。")
    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class
