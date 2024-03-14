Public Class frmSlotMachines
    Private mysql As New PowerNET8.mySQL.Init.SQL

    Private itemAcounter As Integer = 0
    Private itemBcounter As Integer = 0
    Private itemCcounter As Integer = 0

    Private triggerManualA As Boolean = False
    Private triggerManualB As Boolean = False
    Private triggerManualC As Boolean = False

    Private manualStoperA As Integer = 0
    Private manualStoperB As Integer = 0
    Private manualStoperC As Integer = 0

    Public TP As Integer = 0
    Public Points As Integer = 0
    Public Ticket As Integer = 0

    Private data_rewards_EXP As Long = 0
    Private data_rewards_TP As Long = 0
    Private data_rewards_Ticket As Long = 0

    Private Sub frmSlotMachines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        loadAccount()
        My.Computer.Audio.Play(Application.StartupPath + "\Audio\Lottery\background.wav", AudioPlayMode.BackgroundLoop)
        reloadPrizeGuide()
    End Sub

    Private Sub loadAccount()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblrewards_my_status where accountID=" + userID.ToString)
        If mydata.Rows.Count > 0 Then
            data_rewards_EXP = mydata.Rows(0).Item("exp")
            data_rewards_TP = mydata.Rows(0).Item("tp")
            data_rewards_Ticket = mydata.Rows(0).Item("ticket")
        End If
    End Sub



    Private Sub reloadPrizeGuide()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblrewards_slotmachine_ref order by LID")
        If mydata.Rows.Count > 0 Then
            For i As Integer = 0 To mydata.Rows.Count - 1
                Select Case i
                    Case 0
                        'SEVEN
                        lblSevenA.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                        pbSeven.Image = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(i).Item("icon").ToString.Replace("~", "\"))
                    Case 1
                        'SEVEN B
                        lblSevenB.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                    Case 2
                        'DIAMOND
                        lblDiamondA.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                        pbDiamond.Image = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(i).Item("icon").ToString.Replace("~", "\"))
                    Case 3
                        'DIAMOND
                        lblDiamondB.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                    Case 4
                        'BAR
                        lblBarA.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                        pbBar.Image = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(i).Item("icon").ToString.Replace("~", "\"))
                    Case 5
                        'BAR
                        lblBarB.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                    Case 6
                        'HORSESHOE
                        lblHorseshoeA.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                        pbHorseshoe.Image = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(i).Item("icon").ToString.Replace("~", "\"))
                    Case 7
                        'HORSESHOE
                        lblHorseShoeB.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                    Case 8
                        'BELL
                        lblBellA.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                        pbBell.Image = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(i).Item("icon").ToString.Replace("~", "\"))
                    Case 9
                        'BELL
                        lblBellB.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                    Case 10
                        'CHERRY
                        lblCherryA.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                        pbCherry.Image = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(i).Item("icon").ToString.Replace("~", "\"))
                    Case 11
                        'CHERRY
                        lblCherryB.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                    Case 12
                        'LEMON
                        lblLemonA.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                        pbLemon.Image = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(i).Item("icon").ToString.Replace("~", "\"))
                    Case 13
                        'LEMON
                        lblLemonB.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                    Case 14
                        'wATERMELON
                        lblWatermelonA.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                        pbWatermelon.Image = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(i).Item("icon").ToString.Replace("~", "\"))
                    Case 15
                        'WATERMELOON
                        lblWatermelonB.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                    Case 16
                        'HEART
                        lblHeartA.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                        pbHeart.Image = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(i).Item("icon").ToString.Replace("~", "\"))
                    Case 17
                        'HEART
                        lblHearB.Text = "= " + mydata.Rows(i).Item("Points").ToString + "pts and " + mydata.Rows(i).Item("TP").ToString + "TP"
                    Case 18
                        lblOther.Text = "*** IF Any Kind " + mydata.Rows(i).Item("Points").ToString + "pts/" + mydata.Rows(i).Item("TP").ToString + "TP"
                End Select
            Next
        End If
    End Sub

    Private Function getSpeed(ByVal level As Integer)
        Select Case level
            Case 1
                Return 70
        End Select
    End Function

    Private Function getItem(ByVal index As Integer, Optional ByVal pattern As String = "A") As Image
        Select Case index
            Case 0
                Select Case pattern
                    Case "A"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\1 heart.png")
                    Case "B"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\2 watermellon.png")
                    Case "C"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\9 diamond.png")
                End Select
            Case 1
                Select Case pattern
                    Case "A"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\2 watermellon.png")
                    Case "B"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\4 cherry.png")
                    Case "C"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\8 horseshoe.png")
                End Select
            Case 2
                Select Case pattern
                    Case "A"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\3 lemon.png")
                    Case "B"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\6 bar.png")
                    Case "C"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\7 bell.png")
                End Select
            Case 3
                Select Case pattern
                    Case "A"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\4 cherry.png")
                    Case "B"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\8 horseshoe.png")
                    Case "C"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\6 bar.png")
                End Select
            Case 4
                Select Case pattern
                    Case "A"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\5 seven.png")
                    Case "B"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\3 lemon.png")
                    Case "C"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\5 seven.png")
                End Select
            Case 5
                Select Case pattern
                    Case "A"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\6 bar.png")
                    Case "B"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\5 seven.png")
                    Case "C"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\4 cherry.png")
                End Select
            Case 6
                Select Case pattern
                    Case "A"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\7 bell.png")
                    Case "B"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\7 bell.png")
                    Case "C"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\3 lemon.png")
                End Select
            Case 7
                Select Case pattern
                    Case "A"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\8 horseshoe.png")
                    Case "B"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\9 diamond.png")
                    Case "C"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\2 watermellon.png")
                End Select
            Case 8
                Select Case pattern
                    Case "A"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\9 diamond.png")
                    Case "B"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\1 heart.png")
                    Case "C"
                        Return Image.FromFile(Application.StartupPath + "\Images\System\Lottery\1 heart.png")
                End Select
        End Select
    End Function

    Private actionCommand As String = ""

    Private Sub cmdSpin_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSpin.ClickButtonArea

        Select Case cmdSpin.Text
            Case "SPIN"
                Timer4.Start()
                Timer1.Interval = getSpeed(1)
                Timer1.Start()
                Timer2.Interval = getSpeed(1)
                Timer2.Start()
                Timer3.Interval = getSpeed(1)
                Timer3.Start()

                cmdSpin.Text = "STOP"
                actionCommand = chkRandom.Checked.ToString


                If chkRandom.Checked = False Then
                    cmdStopA.Visible = True
                    cmdStopB.Visible = True
                    cmdStopC.Visible = True
                    cmdSpin.Visible = False
                End If
                chkRandom.Enabled = False
            Case "STOP"
                ' Create a random number generator
                Dim Generator As System.Random = New System.Random()
                Dim A As Integer = Generator.Next(0, 9)
                Dim B As Integer = Generator.Next(0, 9)
                Dim C As Integer = Generator.Next(0, 9)

                itemAcounter = A
                itemBcounter = B
                itemCcounter = C

                Timer1.Stop()
                Timer2.Stop()
                Timer3.Stop()

                pcItemA.Image = getItem(A)
                pcitemB.Image = getItem(B)
                pcItemC.Image = getItem(C)
                cmdSpin.Visible = False
        End Select

    End Sub

    Dim MytoneItemA As New System.Media.SoundPlayer
    Dim MytoneItemB As New System.Media.SoundPlayer
    Dim MytoneItemC As New System.Media.SoundPlayer

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'trigger to stop the spin
        If triggerManualA Then
            manualStoperA += 1
            If manualStoperA = 18 Then
                Timer1.Interval = 100
            ElseIf manualStoperA = 15 Then
                Timer1.Interval = 200
            ElseIf manualStoperA = 20 Then
                Timer1.Interval = 400
            ElseIf manualStoperA = 23 Then
                Timer1.Interval = 800
            ElseIf manualStoperA = 25 Then
                Timer1.Interval = 1200

                pcItemA.Image = getItem(itemAcounter, "A")
                pcItemA.Refresh()
                'My.Computer.Audio.Play(Application.StartupPath + "\Audio\Lottery\selecting.wav", AudioPlayMode.Background)
                Timer1.Stop()
                Exit Sub
                'MsgBox(itemAcounter.ToString)
            End If
        End If

        If itemAcounter <= 8 Then
            pcItemA.Image = getItem(itemAcounter, "A")
            itemAcounter += 1
            pcItemA.Refresh()
            'My.Computer.Audio.Play(Application.StartupPath + "\Audio\Lottery\selecting.wav", AudioPlayMode.Background)
        Else
            itemAcounter = 0
            pcItemA.Image = getItem(itemAcounter, "A")
            pcItemA.Refresh()
            'My.Computer.Audio.Play(Application.StartupPath + "\Audio\Lottery\selecting.wav", AudioPlayMode.Background)
        End If


    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        'trigger to stop the spin
        If triggerManualB Then
            manualStoperB += 1
            If manualStoperB = 18 Then
                Timer2.Interval = 100
            ElseIf manualStoperB = 15 Then
                Timer2.Interval = 200
            ElseIf manualStoperB = 20 Then
                Timer2.Interval = 400
            ElseIf manualStoperB = 23 Then
                Timer2.Interval = 800
            ElseIf manualStoperB = 25 Then
                Timer2.Interval = 1200

                pcitemB.Image = getItem(itemBcounter, "A")
                pcitemB.Refresh()
                'My.Computer.Audio.Play(Application.StartupPath + "\Audio\Lottery\selecting.wav", AudioPlayMode.Background)
                Timer2.Stop()
                Exit Sub
                'MsgBox(itemBcounter.ToString)

            End If
        End If

        If itemBcounter <= 8 Then
            pcitemB.Image = getItem(itemBcounter, "A")
            pcitemB.Refresh()
            'My.Computer.Audio.Play(Application.StartupPath + "\Audio\Lottery\selecting.wav", AudioPlayMode.Background)
            itemBcounter += 1
        Else
            itemBcounter = 0
            pcitemB.Image = getItem(itemBcounter, "A")
            pcitemB.Refresh()
            'My.Computer.Audio.Play(Application.StartupPath + "\Audio\Lottery\selecting.wav", AudioPlayMode.Background)
        End If
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick

        'trigger to stop the spin
        If triggerManualC Then
            manualStoperC += 1
            If manualStoperC = 18 Then
                Timer3.Interval = 100
            ElseIf manualStoperC = 15 Then
                Timer3.Interval = 200
            ElseIf manualStoperC = 20 Then
                Timer3.Interval = 400
            ElseIf manualStoperC = 23 Then
                Timer3.Interval = 800
            ElseIf manualStoperC = 25 Then
                Timer3.Interval = 1200

                pcItemC.Image = getItem(itemCcounter, "A")
                pcItemC.Refresh()
                'My.Computer.Audio.Play(Application.StartupPath + "\Audio\Lottery\selecting.wav", AudioPlayMode.Background)
                Timer3.Stop()
                Exit Sub
                'MsgBox(itemCcounter.ToString)

            End If
        End If

        If itemCcounter <= 8 Then
            pcItemC.Image = getItem(itemCcounter, "A")
            pcItemC.Refresh()
            'My.Computer.Audio.Play(Application.StartupPath + "\Audio\Lottery\selecting.wav", AudioPlayMode.Background)
            itemCcounter += 1
        Else
            itemCcounter = 0
            pcItemC.Image = getItem(itemCcounter, "A")
            'My.Computer.Audio.Play(Application.StartupPath + "\Audio\Lottery\selecting.wav", AudioPlayMode.Background)
            pcItemC.Refresh()

        End If

    End Sub

    Private Sub cmdStopA_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdStopA.ClickButtonArea
        triggerManualA = True
        cmdStopA.Visible = False
    End Sub

    Private Sub cmdStopB_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdStopB.ClickButtonArea
        triggerManualB = True
        cmdStopB.Visible = False
    End Sub

    Private Sub cmdStopC_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdStopC.ClickButtonArea
        triggerManualC = True
        cmdStopC.Visible = False
    End Sub

    Private Sub chkRandom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRandom.CheckedChanged
        If chkRandom.Checked Then
            cmdSpin.Visible = True
            cmdStopA.Visible = False
            cmdStopB.Visible = False
            cmdStopC.Visible = False
        Else
            If cmdSpin.Text = "STOP" Then
                cmdSpin.Visible = False
            End If
        End If
    End Sub

    Public Enum itemsKey
        Heart
        Watermellon
        Lemon
        Cherry
        Seven
        Bar
        Bell
        Horseshoe
        Diamond
    End Enum

    Private Function getItemPrizes(ByVal index As Integer, Optional ByVal pattern As String = "A") As itemsKey
        Select Case index
            Case 0
                Select Case pattern
                    Case "A"
                        Return itemsKey.Heart
                    Case "B"
                        Return itemsKey.Watermellon
                    Case "C"
                        Return itemsKey.Diamond
                End Select
            Case 1
                Select Case pattern
                    Case "A"
                        Return itemsKey.Watermellon
                    Case "B"
                        Return itemsKey.Cherry
                    Case "C"
                        Return itemsKey.Horseshoe
                End Select
            Case 2
                Select Case pattern
                    Case "A"
                        Return itemsKey.Lemon
                    Case "B"
                        Return itemsKey.Bar
                    Case "C"
                        Return itemsKey.Bell
                End Select
            Case 3
                Select Case pattern
                    Case "A"
                        Return itemsKey.Cherry
                    Case "B"
                        Return itemsKey.Horseshoe
                    Case "C"
                        Return itemsKey.Bar
                End Select
            Case 4
                Select Case pattern
                    Case "A"
                        Return itemsKey.Seven
                    Case "B"
                        Return itemsKey.Lemon
                    Case "C"
                        Return itemsKey.Seven
                End Select
            Case 5
                Select Case pattern
                    Case "A"
                        Return itemsKey.Bar
                    Case "B"
                        Return itemsKey.Seven
                    Case "C"
                        Return itemsKey.Cherry
                End Select
            Case 6
                Select Case pattern
                    Case "A"
                        Return itemsKey.Bell
                    Case "B"
                        Return itemsKey.Bell
                    Case "C"
                        Return itemsKey.Lemon
                End Select
            Case 7
                Select Case pattern
                    Case "A"
                        Return itemsKey.Horseshoe
                    Case "B"
                        Return itemsKey.Diamond
                    Case "C"
                        Return itemsKey.Watermellon
                End Select
            Case 8
                Select Case pattern
                    Case "A"
                        Return itemsKey.Diamond
                    Case "B"
                        Return itemsKey.Heart
                    Case "C"
                        Return itemsKey.Heart
                End Select
        End Select
    End Function

    Private Function getPrizesLibrary(ByVal keycode As String) As DataTable
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblrewards_slotmachine_ref where name='" + keycode + "'")
        If mydata.Rows.Count > 0 Then
            Return mydata
        End If
    End Function

    Private Function getPrizes()
        Dim myPrizeLib As DataTable

        Dim itemA As itemsKey = getItemPrizes(itemAcounter)
        Dim itemB As itemsKey = getItemPrizes(itemBcounter)
        Dim itemC As itemsKey = getItemPrizes(itemCcounter)
        Dim strMsg As String = "CONGRATULATIONS!!!"
        'MsgBox(itemA.ToString + " + " + itemB.ToString + " +  " + itemC.ToString)

        'itemA = itemsKey.Bar
        'itemB = itemsKey.Bell
        'itemC = itemsKey.Bar

        If itemA = itemsKey.Seven And itemB = itemsKey.Seven And itemC = itemsKey.Seven Then
            'SEVEN ***
            myPrizeLib = getPrizesLibrary("jockpot")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf (itemA = itemsKey.Seven And itemC = itemsKey.Seven) Or (itemA = itemsKey.Seven And itemB = itemsKey.Seven) Or (itemB = itemsKey.Seven And itemC = itemsKey.Seven) Then
            'SEVEN **
            myPrizeLib = getPrizesLibrary("semi-jockpot")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf itemA = itemsKey.Diamond And itemB = itemsKey.Diamond And itemC = itemsKey.Diamond Then
            'DIAMOND ***
            myPrizeLib = getPrizesLibrary("diamond")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf (itemA = itemsKey.Diamond And itemC = itemsKey.Diamond) Or (itemA = itemsKey.Diamond And itemB = itemsKey.Diamond) Or (itemB = itemsKey.Diamond And itemC = itemsKey.Diamond) Then
            'DIAMOND **
            myPrizeLib = getPrizesLibrary("semi-diamond")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf itemA = itemsKey.Bar And itemB = itemsKey.Bar And itemC = itemsKey.Bar Then
            'BAR ***
            myPrizeLib = getPrizesLibrary("bar")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf (itemA = itemsKey.Bar And itemC = itemsKey.Bar) Or (itemA = itemsKey.Bar And itemB = itemsKey.Bar) Or (itemB = itemsKey.Bar And itemC = itemsKey.Bar) Then
            'BAR **
            myPrizeLib = getPrizesLibrary("semi-bar")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf itemA = itemsKey.Horseshoe And itemB = itemsKey.Horseshoe And itemC = itemsKey.Horseshoe Then
            'HORSESHOE ***
            myPrizeLib = getPrizesLibrary("horseshoe")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf (itemA = itemsKey.Horseshoe And itemC = itemsKey.Horseshoe) Or (itemA = itemsKey.Horseshoe And itemB = itemsKey.Horseshoe) Or (itemB = itemsKey.Horseshoe And itemC = itemsKey.Horseshoe) Then
            'HORSESHOE **
            myPrizeLib = getPrizesLibrary("semi-horseshoe")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf itemA = itemsKey.Bell And itemB = itemsKey.Bell And itemC = itemsKey.Bell Then
            'BELL ***
            myPrizeLib = getPrizesLibrary("bell")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf (itemA = itemsKey.Bell And itemC = itemsKey.Bell) Or (itemA = itemsKey.Bell And itemB = itemsKey.Bell) Or (itemB = itemsKey.Bell And itemC = itemsKey.Bell) Then
            'BELL **
            myPrizeLib = getPrizesLibrary("semi-bell")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf itemA = itemsKey.Cherry And itemB = itemsKey.Cherry And itemC = itemsKey.Cherry Then
            'CHERRY ***
            myPrizeLib = getPrizesLibrary("cherry")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf (itemA = itemsKey.Cherry And itemC = itemsKey.Cherry) Or (itemA = itemsKey.Cherry And itemB = itemsKey.Cherry) Or (itemB = itemsKey.Cherry And itemC = itemsKey.Cherry) Then
            'CHERRY **
            myPrizeLib = getPrizesLibrary("semi-cherry")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf itemA = itemsKey.Lemon And itemB = itemsKey.Lemon And itemC = itemsKey.Lemon Then
            'LEMON ***
            myPrizeLib = getPrizesLibrary("lemon")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf (itemA = itemsKey.Lemon And itemC = itemsKey.Lemon) Or (itemA = itemsKey.Lemon And itemB = itemsKey.Lemon) Or (itemB = itemsKey.Lemon And itemC = itemsKey.Lemon) Then
            'LEMON **
            myPrizeLib = getPrizesLibrary("semi-lemon")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf itemA = itemsKey.Watermellon And itemB = itemsKey.Watermellon And itemC = itemsKey.Watermellon Then
            'WATERMELON ***
            myPrizeLib = getPrizesLibrary("watermelon")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf (itemA = itemsKey.Watermellon And itemC = itemsKey.Watermellon) Or (itemA = itemsKey.Watermellon And itemB = itemsKey.Watermellon) Or (itemB = itemsKey.Watermellon And itemC = itemsKey.Watermellon) Then
            'WATERMELON **
            myPrizeLib = getPrizesLibrary("semi-watermelon")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf itemA = itemsKey.Heart And itemB = itemsKey.Heart And itemC = itemsKey.Heart Then
            'HEART ***
            myPrizeLib = getPrizesLibrary("heart")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        ElseIf (itemA = itemsKey.Heart And itemC = itemsKey.Heart) Or (itemA = itemsKey.Heart And itemB = itemsKey.Heart) Or (itemB = itemsKey.Heart And itemC = itemsKey.Heart) Then
            'HEART **
            myPrizeLib = getPrizesLibrary("semi-heart")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
        Else
            'NOTHING TO SEEK
            myPrizeLib = getPrizesLibrary("other")
            Points = myPrizeLib.Rows(0).Item("Points")
            TP = myPrizeLib.Rows(0).Item("TP")
            strMsg = "BETTER LUCK NEXT TIME."
        End If

        Dim Mytone As New System.Media.SoundPlayer

        If strMsg = "BETTER LUCK NEXT TIME." Then
            Mytone.SoundLocation = Application.StartupPath + "\Audio\Lottery\fail.wav"
        Else
            Mytone.SoundLocation = Application.StartupPath + "\Audio\Lottery\congrats.wav"
        End If

        Mytone.Load()
        Mytone.Play()

        MsgBox(strMsg + " YOU GOT " + Points.ToString + "pts and " + TP.ToString + "TP!!!!!", , "REWARDS OBTAINED")

        'POST UPDATE
        With mysql
            .setTable("tblrewards_slotmachine")
            .addValue(userID.ToString, "accountID")
            .addValue(Points, "exp")
            .addValue(TP, "tp")
            .addValue(Ticket, "ticket")
            .addValue(getItemName(itemA), "itemA")
            .addValue(getItemName(itemB), "itemB")
            .addValue(getItemName(itemC), "itemC")
            .addValue(Now.ToString("yyyy-MM-dd H:m:s"), "dateSpin")
            .Insert()
        End With

        'POST TO NEWSFEED
        With mysql
            .setTable("tblaccount_newsfeed")
            .addValue(.nextID("newsFeedID"), "newsFeedID")
            .addValue(userID.ToString, "accountID")
            .addValue("Slot Machine", "type")
            .addValue("Slot Raffle Draw Prizes Award", "name")
            .addValue("~ jusr received a prize reward from the slop raffle draw.", "description")
            .addValue(getItemName(itemA) + "," + getItemName(itemB) + "," + getItemName(itemC), "slotMachine")
            .addValue("exp~" + Points.ToString + ",tp~" + TP.ToString + ",ticket~" + Ticket.ToString, "slotItemReceived")
            .addValue(Now.ToString("yyyy-MM-dd H:m:s"), "dateUpdate")
            .Insert()
        End With

        'UPDATE MY ACCOUNT STATUS
        With mysql
            .setTable("tblrewards_my_status")
            .addValue(data_rewards_EXP + Points, "exp")
            .addValue(data_rewards_TP + TP, "TP")
            .Update("accountID", userID.ToString)
        End With

    End Function

    Private Function getItemName(ByVal type As itemsKey)
        Select Case type
            Case itemsKey.Bar
                Return "Bar"
            Case itemsKey.Bell
                Return "Bell"
            Case itemsKey.Cherry
                Return "Cherry"
            Case itemsKey.Diamond
                Return "Diamond"
            Case itemsKey.Heart
                Return "Heart"
            Case itemsKey.Horseshoe
                Return "Horseshoe"
            Case itemsKey.Lemon
                Return "Lemon"
            Case itemsKey.Seven
                Return "Seven"
            Case itemsKey.Watermellon
                Return "Watermelon"
        End Select
    End Function


    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        If Timer1.Enabled = False And Timer2.Enabled = False And Timer3.Enabled = False Then
            Timer4.Stop()
            getPrizes()
            Me.Close()
        End If
    End Sub

    Private Sub cmdExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExpand.Click
        Select Case cmdExpand.Text
            Case "?"
                cmdExpand.Text = "<"
                Me.Width = 907
            Case "<"
                cmdExpand.Text = "?"
                Me.Width = 558
        End Select
    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click

    End Sub

    Private Sub pcItemA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pcItemA.Click

    End Sub
End Class