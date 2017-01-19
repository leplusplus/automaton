Public Class Form1
    Dim nofphase = 0
    Dim mousemovei As Integer
    Dim a(100) As UserControl1
    Dim isdragging As Boolean
    Dim diff As Point

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        a(nofphase) = New UserControl1
        a(nofphase).textw = CStr(nofphase)
        a(nofphase).TabIndex = nofphase
        Me.Controls.Add(a(nofphase))
        AddHandler a(nofphase).MouseDown, AddressOf mixedmousedownhandler
        AddHandler a(nofphase).MouseMove, AddressOf mixedmousemovehandler
        AddHandler a(nofphase).MouseUp, AddressOf mixedmouseuphandler
        nofphase += 1
        
    End Sub
    Private Sub mixedmouseuphandler(ByVal myobject As Object, ByVal e As MouseEventArgs)
        isdragging = False

    End Sub
    Private Sub mixedmousemovehandler(ByVal myobject As Object, ByVal e As MouseEventArgs)
        If isdragging = True Then
            a(mousemovei).Top = a(mousemovei).Location.Y + e.Y - diff.X
            a(mousemovei).Left = a(mousemovei).Location.X + e.X - diff.X
        End If
    End Sub

    Private Sub mixedmousedownhandler(ByVal myobject As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        mousemovei = -1
        For i = 0 To nofphase
            If a(i) Is myobject Then
                If a(i).incircle = True Then
                    mousemovei = i

                End If
            End If
        Next
        If mousemovei >= 0 Then
            diff = e.Location
            isdragging = True
            Debug.Print(CStr(nofphase) & "selected")

        End If
    End Sub


    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
      


    End Sub
End Class
