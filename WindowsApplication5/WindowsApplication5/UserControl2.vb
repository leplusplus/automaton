Public Class UserControl2
    Dim inincircle As Boolean
    Private innertext As String

    Property textw As String

        Get
            Return innertext
        End Get
        Set(ByVal value As String)
            innertext = value
        End Set
    End Property
    Property incircle As Boolean
        Get
            Return inincircle
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property
    Private Sub UserControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub UserControl1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Dim a, b
        a = (e.X - Me.Width / 2) ^ 2 + (e.Y - Me.Height / 2) ^ 2
        b = (Me.Height / 2) ^ 2
        If a > b Then


            inincircle = False
        Else
            inincircle = True

        End If
    End Sub

    Private Sub UserControl1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.DrawEllipse(Pens.Black, 1, 1, Me.Width - 2, Me.Height - 2)

    End Sub
    Private Sub UserControl2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
