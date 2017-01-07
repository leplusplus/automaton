Public Class Form1
    Dim NPHASE As Integer = 100
    Dim NSYMBOL As Integer = 10

    Dim PhaseName(NPHASE) As String
    Dim isFinalPhase(NPHASE) As Boolean
    Dim Inputsymbol(NSYMBOL) As String
    Dim Delta(NPHASE, NSYMBOL, 10) As Integer
    Dim NumberOfDelta(NPHASE, NSYMBOL) As Integer
    Dim NumberOfPhase As Integer
    Dim NumberOfInputSymbol As Integer

    Dim PhaseToPhase(NPHASE, NPHASE) As String
    Dim PhasePointX(NPHASE) As Integer
    Dim PhasePointY(NPHASE) As Integer
    Dim PreviousPhasePointX(NPHASE) As Integer
    Dim PreviousPhasePointY(NPHASE) As Integer

    Dim PhaseColor(NPHASE) As Integer
    Dim NewPhaseColor(NPHASE) As Integer
    Dim CurrentPhase As Integer
    Dim movingphase As Integer
    Dim panel2dragged As Boolean
    '--------for DFA --------------------------------------------
    Dim dPhasename(NPHASE) As String
    Dim dnumberofdelta(NPHASE, NSYMBOL) As Integer
    Dim dDelta(NPHASE, NSYMBOL, 10) As Integer
    Dim dNumberOfPhase As Integer
    Dim dPhasePointX(NPHASE) As Integer
    Dim dPhasePointY(NPHASE) As Integer
    Dim dPreviousPhasePointX(NPHASE) As Integer
    Dim dPreviousPhasePointY(NPHASE) As Integer
    Dim dPhaseToPhase(NPHASE, NPHASE) As String
    Dim dIsFinalPhase(NPHASE) As Boolean
    Dim dPhaseColor(NPHASE) As Integer
    Dim dNewPhaseColor(NPHASE) As Integer
    Dim dCurrentPhase As Integer
    Dim dmovingphase As Integer
    Dim dpanel3dragged As Boolean
    '---------------------------------floating buttons------
    Dim inputbutton(10) As Button

    '---------------------------------for floating labels --------------------
    Dim fLabel(NPHASE,NPHASE) As Label
    Dim NumberOfLabel As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim phaselist As String
        Button2.Enabled = True
        TextBox2.Enabled = True
        TextBox1.Enabled = False
        TextBox5.Enabled = False
        Button1.Enabled = False
        Dim l As New Random(998)
        Dim phasename1(NPHASE), phasename2(NPHASE) As String
        phaselist = TextBox1.Text
        phasename1 = phaselist.Split(",")
        phaselist = TextBox5.Text
        phasename2 = phaselist.Split(",")
        For Each j As String In phasename1
            ComboBox1.Items.Add(j)
            ComboBox3.Items.Add(j)
            PhaseName(NumberOfPhase) = j
            PhaseColor(NumberOfPhase) = 0
            isFinalPhase(NumberOfPhase) = False
            NumberOfPhase += 1

        Next
        For Each j As String In phasename2
            ComboBox1.Items.Add(j)
            ComboBox3.Items.Add(j)
            PhaseName(NumberOfPhase) = j
            PhaseColor(NumberOfPhase) = 0
            isFinalPhase(NumberOfPhase) = True
            NumberOfPhase += 1

        Next

        ComboBox1.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0

        While (initial_phase_setting() = False)


            For i As Integer = 0 To NumberOfPhase - 1



                PhasePointX(i) = l.Next(Panel2.Width)
                PhasePointY(i) = l.Next(Panel2.Height)

            Next
        End While
        Panel2.Invalidate()

        Panel2.Update()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim inputsymbollist As String
        inputsymbollist = TextBox2.Text
        inputsymbol = inputsymbollist.Split(",")
        Dim tmpSymbol As String
        For Each tmpSymbol In inputsymbol
            ComboBox2.Items.Add(tmpSymbol)
            NumberOfInputSymbol += 1


        Next
        ComboBox2.SelectedIndex = 0
        Dim i, j As Integer
        
        For i = 0 To NumberOfPhase - 1
            For j = 0 To NumberOfPhase - 1
                PhaseToPhase(i, j) = ""
            Next
        Next
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        Button3.Enabled = True
        Button2.Enabled = False
        TextBox2.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        delta(ComboBox1.SelectedIndex, ComboBox2.SelectedIndex, NumberOfDelta(ComboBox1.SelectedIndex, ComboBox2.SelectedIndex)) = ComboBox3.SelectedIndex
        NumberOfDelta(ComboBox1.SelectedIndex, ComboBox2.SelectedIndex) += 1

        If PhaseToPhase(ComboBox1.SelectedIndex, ComboBox3.SelectedIndex) = "" Then
            PhaseToPhase(ComboBox1.SelectedIndex, ComboBox3.SelectedIndex) = ComboBox2.SelectedItem

        Else
            PhaseToPhase(ComboBox1.SelectedIndex, ComboBox3.SelectedIndex) = PhaseToPhase(ComboBox1.SelectedIndex, ComboBox3.SelectedIndex) & "," & ComboBox2.SelectedItem
        End If

        TextBox3.Text = TextBox3.Text & "δ（" & phasename(ComboBox1.SelectedIndex) & "," & inputsymbol(ComboBox2.SelectedIndex) & "）→" & phasename(ComboBox3.SelectedIndex) & vbCrLf
        Panel2.Invalidate()
        Panel2.Update()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
       
        Dim l As New System.Random(92)
        Dim distance, previousdistance As Long
        While (initial_phase_setting() = False)


            For i As Integer = 0 To NumberOfPhase - 1



                PhasePointX(i) = l.Next(Panel2.Width)
                PhasePointY(i) = l.Next(Panel2.Height)

            Next
        End While
        '     MsgBox("initial")

        Panel2.Invalidate()
        Panel2.Update()

        For i = 0 To NumberOfPhase - 1
            PreviousPhasePointX(i) = PhasePointX(i)
            PreviousPhasePointY(i) = PhasePointY(i)
        Next

        distance = calculate_distance()
        previousdistance = distance

        Dim loop_flag As Integer = 0


        While (distance > 10)
            Dim target As Integer = l.Next(NumberOfPhase)
            Dim xdiff As Integer = 5 - l.Next(10)
            Dim ydiff As Integer = 5 - l.Next(10)
            PhasePointX(target) = PhasePointX(target) + xdiff
            PhasePointY(target) = PhasePointY(target) + ydiff
            distance = calculate_distance()



            If (distance < previousdistance) Then
                loop_flag = 0

                For i = 0 To NumberOfPhase - 1
                    PreviousPhasePointX(i) = PhasePointX(i)
                    PreviousPhasePointY(i) = PhasePointY(i)
                Next
                Label1.Text = distance

                Panel2.Invalidate()
                Panel2.Update()
                'MsgBox(distance.ToString)


                previousdistance = distance
            Else
                loop_flag += 1
                If (loop_flag = 100) Then Exit Sub
                For i = 0 To NumberOfPhase - 1
                    PhasePointX(i) = PreviousPhasePointX(i)
                    PhasePointY(i) = PreviousPhasePointY(i)
                Next

            End If


        End While

    End Sub
    Private Function initial_phase_setting() As Boolean
        Dim distancesub As Integer
        For i = 0 To NumberOfPhase - 1
            If (PhasePointX(i) < 25) Then Return False
            If (PhasePointY(i) < 25) Then Return False
            If (PhasePointX(i) > Panel2.Width - 25) Then Return False
            If (PhasePointY(i) > Panel2.Height - 25) Then Return False
        Next

        For i As Integer = 0 To NumberOfPhase - 1
            For j As Integer = 0 To NumberOfPhase - 1
                If (i = j) Then Exit For

                distancesub = (PhasePointX(i) - PhasePointX(j)) ^ 2 + (PhasePointY(i) - PhasePointY(j)) ^ 2
                If (distancesub < 10000) Then Return False

            Next
        Next
        Return True
        
    End Function
    Private Function calculate_distance() As Long
        Dim distance, distancesub As Integer
        Dim i, j, k As Integer
        distance = 0
        For i = 0 To NumberOfPhase - 1
            For j = 0 To NumberOfInputSymbol - 1
                For k = 0 To NumberOfDelta(i, j) - 1


                    If (delta(i, j, k) = -1) Then Exit For
                    If (i = delta(i, j, k)) Then Exit For

                    Dim FromPhase As Integer
                    Dim ToPhase As Integer

                    FromPhase = i
                    ToPhase = delta(i, j, k)
                    distancesub = (PhasePointX(FromPhase) - PhasePointX(ToPhase)) ^ 2 + (PhasePointY(FromPhase) - PhasePointY(ToPhase)) ^ 2
                    If (distancesub < 10000) Then
                        distancesub = 1000000
                    End If

                    distance = distance + distancesub
                Next
            Next

            For j = 0 To NumberOfPhase - 1
                distancesub = (PhasePointX(i) - PhasePointX(j)) ^ 2 + (PhasePointY(i) - PhasePointY(j)) ^ 2
                If (distancesub < 10000) Then
                    distancesub = 1000000
                End If

                distance = distance + distancesub
            Next
        Next
        calculate_distance = distance
    End Function

    Private Sub Panel2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseDown
        Dim i As Integer
        If panel2dragged = False Then
            For i = 0 To NumberOfPhase - 1
                If ((e.X - PhasePointX(i)) ^ 2 + (e.Y - PhasePointY(i)) ^ 2 < 25 * 25) Then
                    movingphase = i
                End If

            Next
            Panel2.Invalidate()
            Panel2.Update()
            panel2dragged = True
        End If


    End Sub

    Private Sub Panel2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseMove
        If panel2dragged = True Then

            PhasePointX(movingphase) = e.X
            PhasePointY(movingphase) = e.Y
            Panel2.Invalidate()
            Panel2.Update()
        End If

    End Sub



    Private Sub Panel2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseUp
        If panel2dragged = True Then

            PhasePointX(movingphase) = e.X
            PhasePointY(movingphase) = e.Y
            Panel2.Invalidate()
            Panel2.Update()
            panel2dragged = False
        End If

    End Sub
    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        Dim g As Graphics

        g = e.Graphics
        Dim fontname As Font
        fontname = New System.Drawing.Font("arial", 12)
        Dim i, j As Integer

        For i = 0 To NumberOfPhase - 1

            If (PhaseColor(i) = 0) Then
                g.FillEllipse(Brushes.White, PhasePointX(i) - 25, PhasePointY(i) - 25, 50, 50)
            Else
                g.FillEllipse(Brushes.Red, PhasePointX(i) - 25, PhasePointY(i) - 25, 50, 50)

            End If
            g.DrawEllipse(Pens.Black, PhasePointX(i) - 25, PhasePointY(i) - 25, 50, 50)
            If (isFinalPhase(i) = True) Then
                g.DrawEllipse(Pens.Black, PhasePointX(i) - 20, PhasePointY(i) - 20, 40, 40)

            End If
            g.DrawString(phasename(i), fontname, System.Drawing.Brushes.Black, PhasePointX(i) - 10, PhasePointY(i) - 10)
            
        Next
        For i = 0 To NumberOfPhase - 1
            For j = 0 To NumberOfPhase - 1
                If (PhaseToPhase(i, j) = "") Then
                Else


                    If (i = j) Then

                        g.DrawArc(System.Drawing.Pens.Blue, PhasePointX(i), PhasePointY(i), 50, 50, -90, 270)
                        g.DrawLine(Pens.Black, PhasePointX(i) + 25, PhasePointY(i), PhasePointX(i) + 30, PhasePointY(i) + 5)
                        g.DrawLine(Pens.Black, PhasePointX(i) + 25, PhasePointY(i), PhasePointX(i) + 30, PhasePointY(i) - 5)

                        g.DrawString(PhaseToPhase(i, i), fontname, System.Drawing.Brushes.Black, PhasePointX(i) + 15, PhasePointY(i) + 15)

                    Else
                        drawflesh(g, i, j)
                    End If

                End If
            Next
        Next
    End Sub

    Private Sub drawflesh(ByVal g As Graphics, ByVal i As Integer, ByVal j As Integer)
        Dim vectx, vecty, newvectx, newvecty As Integer
        Dim circlex, circley As Integer
        Dim radius As Integer
        Dim angleStart, angleEnd, angleSweep, angleSpace As Double
        Dim xArrowTop, yArrowTop, xArrowBase1, yArrowBase1, xArrowBase2, yArrowBase2 As Integer
        Dim fontname As Font
        fontname = New System.Drawing.Font("arial", 12)
        vectx = PhasePointX(j) - PhasePointX(i)
        vecty = PhasePointY(j) - PhasePointY(i)
        newvectx = vecty
        newvecty = -vectx
        circlex = (PhasePointX(i) + PhasePointX(j)) / 2 + newvectx
        circley = (PhasePointY(i) + PhasePointY(j)) / 2 + newvecty
        radius = CInt(Math.Sqrt((PhasePointX(i) - circlex) ^ 2 + (PhasePointY(i) - circley) ^ 2))
        angleStart = Math.Atan2((PhasePointY(j) - circley), (PhasePointX(j) - circlex))
        angleEnd = Math.Atan2((PhasePointY(i) - circley), (PhasePointX(i) - circlex))
        If radius < 25 Then
            radius = 25
        End If
        angleSpace = Math.Asin(25.0 / CSng(radius))


      
        angleSweep = angleEnd - angleStart
        If Math.Abs(angleSweep) > Math.PI Then
            If angleStart < angleEnd Then
                angleStart += 2 * Math.PI
            End If
            If angleEnd < 0 Then
                '       MsgBox("swap2" & angleEnd)
                angleEnd += 2 * Math.PI
            End If
            angleSweep = angleEnd - angleStart
            g.DrawArc(Pens.Blue, circlex - radius, circley - radius, radius * 2, radius * 2, CInt((angleStart + angleSpace) / 2.0 / Math.PI * 360.0), CInt((angleSweep - angleSpace * 2) / 2.0 / Math.PI * 360.0))
        Else
            g.DrawArc(Pens.Blue, circlex - radius, circley - radius, radius * 2, radius * 2, CInt((angleStart + angleSpace) / 2.0 / Math.PI * 360.0), CInt((angleSweep - angleSpace * 2) / 2.0 / Math.PI * 360.0))

        End If

        
        xArrowTop = circlex + radius * Math.Cos(angleStart + angleSpace)
        yArrowTop = circley + radius * Math.Sin(angleStart + angleSpace)
        xArrowBase1 = circlex + radius * Math.Cos(angleStart + angleSpace * 1.2) * 1.01
        yArrowBase1 = circley + radius * Math.Sin(angleStart + angleSpace * 1.2) * 1.01
        xArrowBase2 = circlex + radius * Math.Cos(angleStart + angleSpace * 1.2) * 0.99
        yArrowBase2 = circley + radius * Math.Sin(angleStart + angleSpace * 1.2) * 0.99
        Label1.Text = CInt(angleStart / 2.0 / Math.PI * 360)
        Label2.Text = CInt(angleEnd / 2.0 / Math.PI * 360)
        Label3.Text = CInt(angleSweep / 2.0 / Math.PI * 360)
        ' g.DrawLine(Pens.Black, circlex, circley, xArrowTop, yArrowTop)
        g.DrawLine(Pens.Black, xArrowTop, yArrowTop, xArrowBase1, yArrowBase1)
        g.DrawLine(Pens.Black, xArrowTop, yArrowTop, xArrowBase2, yArrowBase2)

        'Try
        '    fLabel(i, j) = New Label
        '    Panel2.Controls.Add(fLabel(i, j))

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'fLabel(i, j).Location = New Point(circlex + radius * Math.Cos((angleStart + angleEnd) / 2.0), circley + radius * Math.Sin((angleStart + angleEnd) / 2.0))
        'fLabel(i, j).Text = PhaseToPhase(i, j)
        'fLabel(i, j).Font = fontname
        g.DrawString(PhaseToPhase(i, j), fontname, Brushes.Black, circlex + radius * Math.Cos((angleStart + angleEnd) / 2.0), circley + radius * Math.Sin((angleStart + angleEnd) / 2.0))



    End Sub

 

   
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PhasePointX(0) = PhasePointX(0) + 200

    End Sub

  
    Private Sub ＤＦＡNFAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ＤＦＡNFAToolStripMenuItem.Click
        Dim l As New Random(998)
        TextBox4.Text = ""
        'MsgBox("NFA")
        Dim i, j As Integer
        For i = 0 To NPHASE - 1
            dPhasename(i) = ""
            For j = 0 To NSYMBOL - 1
                dnumberofdelta(i, j) = 0
                dPhaseToPhase(i, j) = ""

            Next
        Next
        dPhasename(0) = PhaseName(0)
        dNumberOfPhase = 1

        createdfa_recurse(0)
        While (dinitial_phase_setting() = False)


            For i = 0 To dNumberOfPhase - 1



                dPhasePointX(i) = l.Next(Panel2.Width)
                dPhasePointY(i) = l.Next(Panel2.Height)

            Next
        End While
        Panel3.Invalidate()

        Panel3.Update()
    End Sub
    Private Function PhaseNameToNumber(ByVal IIi As String) As Integer
        Dim i, result As Integer
        For i = 0 To NumberOfPhase - 1
            If PhaseName(i) = IIi Then
                result = i
            End If
        Next
        Return result
    End Function

    Private Function createdfa_recurse(ByVal fromPhase As Integer) As Boolean
        Dim innerPhase(NPHASE) As String
        Dim i As String
        Dim toString As String
        Dim HaveCreatedPhase As Boolean
        Dim ExistingPhase As Integer
        Dim fromphasenumber As Integer

        HaveCreatedPhase = False

        innerPhase = Split(dPhasename(fromPhase), ",")
        For j = 0 To NumberOfInputSymbol - 1
            toString = ""
            For Each i In innerPhase
                fromphasenumber = PhaseNameToNumber(i)

                For k = 0 To NumberOfDelta(fromphasenumber, j) - 1
                    If toString = "" Then
                        toString = PhaseName(Delta(fromphasenumber, j, k))
                    Else
                        toString = toString & "," & PhaseName(Delta(fromphasenumber, j, k))

                    End If
                Next
            Next
            If toString = "" Then
            Else

                toString = ConvertPhaseNameToStandardFormat(toString)
                ExistingPhase = CheckForExistingdPhase(toString)
                If ExistingPhase = -1 Then
                    If disFinalState(toString) Then
                        dIsFinalPhase(dNumberOfPhase) = True
                    Else
                        dIsFinalPhase(dNumberOfPhase) = False
                    End If
                    dPhasename(dNumberOfPhase) = toString
                    dPhaseColor(dNumberOfPhase) = 0
                    dDelta(fromPhase, j, 0) = dNumberOfPhase
                    dnumberofdelta(fromPhase, j) += 1

                    TextBox4.Text = TextBox4.Text & "δ（[" & dPhasename(fromPhase) & "]," & Inputsymbol(j) & ")→ [" & dPhasename(dNumberOfPhase) & "]" & vbCrLf
                    dPhaseToPhase(fromPhase, dNumberOfPhase) = Inputsymbol(j)
                    dNumberOfPhase += 1

                    HaveCreatedPhase = createdfa_recurse(dNumberOfPhase - 1)
                Else
                    dDelta(fromPhase, j, 0) = ExistingPhase
                    dnumberofdelta(fromPhase, j) += 1

                    TextBox4.Text = TextBox4.Text & "δ（[" & dPhasename(fromPhase) & "]," & Inputsymbol(j) & ")→ [" & dPhasename(ExistingPhase) & "]" & vbCrLf
                    dPhaseToPhase(fromPhase, ExistingPhase) = Inputsymbol(j)
                End If
            End If

        Next
        Return HaveCreatedPhase


    End Function
    Private Function disFinalState(ByVal tostring) As Boolean
        Dim tmpstr() As String
        Dim ff As Boolean
        ff = False
        tmpstr = Split(tostring, ",")
        For i = 0 To tmpstr.Length - 1
            If (isFinalPhase(PhaseNameToNumber(tmpstr(i)))) Then
                ff = True
            End If
        Next
        Return ff
    End Function
    Private Function ConvertPhaseNameToStandardFormat(ByVal InputString As String) As String
        Dim tmpstr(), OutputStr As String
        tmpstr = Split(InputString, ",")
        OutputStr = ""
        For i = 0 To NumberOfPhase - 1
            For j = 0 To tmpstr.Length - 1
                If PhaseName(i) = tmpstr(j) Then
                    If OutputStr = "" Then
                        OutputStr = PhaseName(i)
                        Exit For
                    Else
                        OutputStr = OutputStr & "," & PhaseName(i)
                        Exit For
                    End If
                End If
            Next
        Next
        Return OutputStr
    End Function
    Private Function CheckForExistingdPhase(ByVal inputstr As String) As Integer
        For i = 0 To dNumberOfPhase - 1
            If dPhasename(i) = inputstr Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel3.MouseDown
        Dim i As Integer
        If dpanel3dragged = False Then

            For i = 0 To dNumberOfPhase - 1
                If ((e.X - dPhasePointX(i)) ^ 2 + (e.Y - dPhasePointY(i)) ^ 2 < 25 * 25) Then
                    dmovingphase = i
                End If

            Next
            Panel3.Invalidate()
            Panel3.Update()
            dpanel3dragged = True
        End If

    End Sub

    Private Sub Panel3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel3.MouseMove
        If dpanel3dragged = True Then
            dPhasePointX(dmovingphase) = e.X
            dPhasePointY(dmovingphase) = e.Y
            Panel3.Invalidate()
            Panel3.Update()
        End If
    End Sub

    Private Sub Panel3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel3.MouseUp
        If (dpanel3dragged = True) Then
            dPhasePointX(dmovingphase) = e.X
            dPhasePointY(dmovingphase) = e.Y
            Panel3.Invalidate()
            Panel3.Update()
            dpanel3dragged = False
        End If
    End Sub

    Private Sub Panel3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint
        Dim g As Graphics

        g = e.Graphics
        Dim fontname As Font
        fontname = New System.Drawing.Font("arial", 12)
        Dim i, j As Integer

        For i = 0 To dNumberOfPhase - 1

            If dPhaseColor(i) = 1 Then
                g.FillEllipse(Brushes.Red, dPhasePointX(i) - 25, dPhasePointY(i) - 25, 50, 50)
            Else
                g.FillEllipse(Brushes.White, dPhasePointX(i) - 25, dPhasePointY(i) - 25, 50, 50)

            End If

            g.DrawEllipse(Pens.Black, dPhasePointX(i) - 25, dPhasePointY(i) - 25, 50, 50)
            If dIsFinalPhase(i) = True Then
                g.DrawEllipse(Pens.Black, dPhasePointX(i) - 20, dPhasePointY(i) - 20, 40, 40)

            End If

            g.DrawString(dPhasename(i), fontname, System.Drawing.Brushes.Black, dPhasePointX(i) - 10, dPhasePointY(i) - 10)

        Next
        For i = 0 To dNumberOfPhase - 1
            For j = 0 To dNumberOfPhase - 1
                If (dPhaseToPhase(i, j) = "") Then
                Else


                    If (i = j) Then

                        g.DrawArc(System.Drawing.Pens.Blue, dPhasePointX(i), dPhasePointY(i), 50, 50, -90, 270)
                        g.DrawLine(Pens.Black, dPhasePointX(i) + 25, dPhasePointY(i), dPhasePointX(i) + 30, dPhasePointY(i) + 5)
                        g.DrawLine(Pens.Black, dPhasePointX(i) + 25, dPhasePointY(i), dPhasePointX(i) + 30, dPhasePointY(i) - 5)

                        g.DrawString(dPhaseToPhase(i, i), fontname, System.Drawing.Brushes.Black, dPhasePointX(i) + 15, dPhasePointY(i) + 15)

                    Else
                        dDrawflesh(g, i, j)
                    End If

                End If
            Next
        Next
    End Sub
    Private Sub dDrawflesh(ByVal g, ByVal i, ByVal j)
        Dim vectx, vecty, newvectx, newvecty As Integer
        Dim circlex, circley As Integer
        Dim radius As Integer
        Dim angleStart, angleEnd, angleSweep, angleSpace As Double
        Dim xArrowTop, yArrowTop, xArrowBase1, yArrowBase1, xArrowBase2, yArrowBase2 As Integer
        Dim fontname As Font
        fontname = New System.Drawing.Font("arial", 12)
        vectx = dPhasePointX(j) - dPhasePointX(i)
        vecty = dPhasePointY(j) - dPhasePointY(i)
        newvectx = vecty
        newvecty = -vectx
        circlex = (dPhasePointX(i) + dPhasePointX(j)) / 2 + newvectx
        circley = (dPhasePointY(i) + dPhasePointY(j)) / 2 + newvecty
        radius = CInt(Math.Sqrt((dPhasePointX(i) - circlex) ^ 2 + (dPhasePointY(i) - circley) ^ 2))
        angleStart = Math.Atan2((dPhasePointY(j) - circley), (dPhasePointX(j) - circlex))
        angleEnd = Math.Atan2((dPhasePointY(i) - circley), (dPhasePointX(i) - circlex))
        angleSpace = Math.Asin(25.0 / CSng(radius))



        angleSweep = angleEnd - angleStart
        If Math.Abs(angleSweep) > Math.PI Then
            If angleStart < angleEnd Then
                angleStart += 2 * Math.PI
            End If
            If angleEnd < 0 Then
                '       MsgBox("swap2" & angleEnd)
                angleEnd += 2 * Math.PI
            End If
            angleSweep = angleEnd - angleStart
            g.DrawArc(Pens.Blue, circlex - radius, circley - radius, radius * 2, radius * 2, CInt((angleStart + angleSpace) / 2.0 / Math.PI * 360.0), CInt((angleSweep - angleSpace * 2) / 2.0 / Math.PI * 360.0))
        Else
            g.DrawArc(Pens.Blue, circlex - radius, circley - radius, radius * 2, radius * 2, CInt((angleStart + angleSpace) / 2.0 / Math.PI * 360.0), CInt((angleSweep - angleSpace * 2) / 2.0 / Math.PI * 360.0))

        End If


        xArrowTop = circlex + radius * Math.Cos(angleStart + angleSpace)
        yArrowTop = circley + radius * Math.Sin(angleStart + angleSpace)
        xArrowBase1 = circlex + radius * Math.Cos(angleStart + angleSpace * 1.2) * 1.01
        yArrowBase1 = circley + radius * Math.Sin(angleStart + angleSpace * 1.2) * 1.01
        xArrowBase2 = circlex + radius * Math.Cos(angleStart + angleSpace * 1.2) * 0.99
        yArrowBase2 = circley + radius * Math.Sin(angleStart + angleSpace * 1.2) * 0.99
        Label1.Text = CInt(angleStart / 2.0 / Math.PI * 360)
        Label2.Text = CInt(angleEnd / 2.0 / Math.PI * 360)
        Label3.Text = CInt(angleSweep / 2.0 / Math.PI * 360)
        ' g.DrawLine(Pens.Black, circlex, circley, xArrowTop, yArrowTop)
        g.DrawLine(Pens.Black, xArrowTop, yArrowTop, xArrowBase1, yArrowBase1)
        g.DrawLine(Pens.Black, xArrowTop, yArrowTop, xArrowBase2, yArrowBase2)

        g.DrawString(dPhaseToPhase(i, j), fontname, Brushes.Black, circlex + radius * Math.Cos((angleStart + angleEnd) / 2.0), circley + radius * Math.Sin((angleStart + angleEnd) / 2.0))


    End Sub
    Private Function dinitial_phase_setting() As Boolean
        Dim distancesub As Integer
        For i = 0 To dNumberOfPhase - 1
            If (dPhasePointX(i) < 25) Then Return False
            If (dPhasePointY(i) < 25) Then Return False
            If (dPhasePointX(i) > Panel3.Width - 25) Then Return False
            If (dPhasePointY(i) > Panel3.Height - 25) Then Return False
        Next

        For i As Integer = 0 To dNumberOfPhase - 1
            For j As Integer = 0 To dNumberOfPhase - 1
                If (i = j) Then Exit For

                distancesub = (dPhasePointX(i) - dPhasePointX(j)) ^ 2 + (dPhasePointY(i) - dPhasePointY(j)) ^ 2
                If (distancesub < 10000) Then Return False

            Next
        Next
        Return True
    End Function





    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Label8.Text = ""
        For i = 0 To NumberOfInputSymbol - 1
            inputbutton(i) = New Button
            Panel1.Controls.Add(inputbutton(i))
            inputbutton(i).Top = 300
            inputbutton(i).Left = i * 100
            inputbutton(i).Text = Inputsymbol(i)
            AddHandler inputbutton(i).Click, AddressOf inputbuttonclick


        Next
        For i = 0 To NumberOfPhase - 1
            PhaseColor(i) = 0
        Next
        For i = 0 To dNumberOfPhase - 1
            dPhaseColor(i) = 0
        Next

        PhaseColor(0) = 1
        dPhaseColor(0) = 1
        Panel2.Invalidate()
        Panel2.Update()
        Panel3.Invalidate()
        Panel3.Update()

    End Sub
    Private Sub inputbuttonclick(ByVal e As Object, ByVal f As EventArgs)
        Dim clickedbutton As Integer
        Dim i As Integer

        For i = 0 To NumberOfInputSymbol - 1
            If e.Text = Inputsymbol(i) Then
                clickedbutton = i
            End If
        Next
        Label8.Text = Label8.Text & CStr(clickedbutton)
        For i = 0 To NumberOfPhase - 1
            NewPhaseColor(i) = 0
        Next
        For i = 0 To NumberOfPhase - 1
            If PhaseColor(i) = 1 Then

                For j = 0 To NumberOfDelta(i, clickedbutton) - 1

                    NewPhaseColor(Delta(i, clickedbutton, j)) = 1
                Next

            End If
        Next
        For i = 0 To NumberOfPhase - 1
            PhaseColor(i) = NewPhaseColor(i)
        Next
        For i = 0 To dNumberOfPhase - 1
            dNewPhaseColor(i) = 0
        Next
        For i = 0 To dNumberOfPhase - 1
            If dPhaseColor(i) = 1 Then
                For j = 0 To dnumberofdelta(i, clickedbutton) - 1
                    dNewPhaseColor(dDelta(i, clickedbutton, j)) = 1
                Next
            End If
        Next
        For i = 0 To dNumberOfPhase - 1
            dPhaseColor(i) = dNewPhaseColor(i)
        Next

        Panel2.Invalidate()
        Panel2.Update()
        Panel3.Invalidate()
        Panel3.Update()

    End Sub
    Private Sub リセットRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles リセットRToolStripMenuItem.Click
        Dim i, j, k As Integer
        For i = 0 To NumberOfPhase - 1
            For j = 0 To NumberOfPhase - 1
                PhaseToPhase(i, j) = ""
            Next
        Next
        TextBox1.Enabled = True
        Button1.Enabled = True
        TextBox5.Enabled = True
        TextBox2.Enabled = False
        Button2.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        Button3.Enabled = False

        NumberOfPhase = 0
        NumberOfInputSymbol = 0
        ComboBox1.Text = ""
        ComboBox1.Items.Clear()
        ComboBox2.Text = ""
        ComboBox2.Items.Clear()
        ComboBox3.Text = ""
        ComboBox3.Items.Clear()
        For i = 0 To NPHASE - 1
            For j = 0 To NSYMBOL - 1
                For k = 0 To 9
                    Delta(i, j, k) = -1

                Next
            Next
        Next
        For i = 0 To NPHASE - 1
            For j = 0 To NSYMBOL - 1
                NumberOfDelta(i, j) = 0
            Next
        Next
        TextBox1.Text = "0,1,2"
        TextBox2.Text = "0,1"
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = "3"
        Panel2.Invalidate()
        Panel2.Update()
        dNumberOfPhase = 0
        Panel3.Invalidate()
        Panel3.Update()
    End Sub

    Private Sub 開くOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 開くOToolStripMenuItem.Click
        Dim fs As System.IO.StreamReader()
        Dim shfd As FileDialog
        shfd = New FileDialog()

        fs = shfd.FileName

        prouquoi?





    End Sub
End Class



