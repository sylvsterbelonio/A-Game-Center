Public Class frmGiftBox
    Private mysql As New PowerNET8.mySQL.Init.SQL
    Private hr As Integer = 0
    Private min As Integer = 0
    Private sec As Long = 0

    Private chestLevel As Integer = 0
    Private chestLevelDesc() As String = {"", "I", "II", "III", "IV", "V", "VI", "VII"}
    Private chestStatus As String = ""
    Private nextChestAvailable As DateTime = Nothing
    Private overrideServerTime As Boolean = False

    Private data_rewards_EXP As Integer = 0
    Private data_rewards_TP As Integer = 0
    Private data_rewards_Ticket As Integer = 0


    Private rewards_EXP As Integer = 0
    Private rewards_TP As Integer = 0
    Private rewards_Ticket As Integer = 0

    Private Function chestMenu(ByRef panelBody As Panel, ByRef panelFooter As Label, ByVal chest As String, Optional ByVal action As String = "", Optional ByVal stat As String = "") As Image
        Select Case chest
            Case "chest 1"
                If action = "open" Then
                    panelBody.BackgroundImage = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\finished.jpg")
                    panelBody.Parent.BackColor = Color.Green
                    panelFooter.ForeColor = Color.Green
                    panelFooter.Parent.Parent.BackColor = Color.Green

                   

                    Return Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\gift 1 open.png")
                Else
                    panelBody.BackgroundImage = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\240_F_136255856_XGPHT6zyNJay48Dprr0bTVYb4XlUuSaI.jpg")
                    If stat = "ready" Then
                        panelBody.Parent.BackColor = Color.Cyan
                        panelFooter.ForeColor = Color.Cyan
                        panelFooter.Parent.Parent.BackColor = Color.Cyan
                    Else
                        panelBody.Parent.BackColor = Color.Red
                        panelFooter.ForeColor = Color.Red
                        panelFooter.Parent.Parent.BackColor = Color.Red
                    End If
                    Return Image.FromFile(Application.StartupPath + "\\Images\System\Gift Rewards\gift 1 close.png")
                End If
            Case "chest 2"
                If action = "open" Then
                    panelBody.BackgroundImage = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\finished.jpg")
                    panelBody.Parent.BackColor = Color.Green
                    panelFooter.ForeColor = Color.Green
                    panelFooter.Parent.Parent.BackColor = Color.Green
                    Return Image.FromFile(Application.StartupPath + "\\Images\System\Gift Rewards\gift 2 open.png")
                Else
                    panelBody.BackgroundImage = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\240_F_136255856_XGPHT6zyNJay48Dprr0bTVYb4XlUuSaI.jpg")
                    If stat = "ready" Then
                        panelBody.Parent.BackColor = Color.Cyan
                        panelFooter.ForeColor = Color.Cyan
                        panelFooter.Parent.Parent.BackColor = Color.Cyan
                    Else
                        panelBody.Parent.BackColor = Color.Red
                        panelFooter.ForeColor = Color.Red
                        panelFooter.Parent.Parent.BackColor = Color.Red
                    End If
                    Return Image.FromFile(Application.StartupPath + "\\Images\System\Gift Rewards\gift 2 close.png")
                End If
            Case "chest 3"
                If action = "open" Then
                    panelBody.BackgroundImage = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\finished.jpg")
                    panelBody.Parent.BackColor = Color.Green
                    panelFooter.ForeColor = Color.Green
                    panelFooter.Parent.Parent.BackColor = Color.Green
                    Return Image.FromFile(Application.StartupPath + "\\Images\System\Gift Rewards\gift 3 open.png")
                Else
                    panelBody.BackgroundImage = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\240_F_136255856_XGPHT6zyNJay48Dprr0bTVYb4XlUuSaI.jpg")
                    If stat = "ready" Then
                        panelBody.Parent.BackColor = Color.Cyan
                        panelFooter.ForeColor = Color.Cyan
                        panelFooter.Parent.Parent.BackColor = Color.Cyan
                    Else
                        panelBody.Parent.BackColor = Color.Red
                        panelFooter.ForeColor = Color.Red
                        panelFooter.Parent.Parent.BackColor = Color.Red
                    End If
                    Return Image.FromFile(Application.StartupPath + "\\Images\System\Gift Rewards\gift 3 close.png")
                End If
        End Select
    End Function

    Private Sub setChest()
        Select Case chestLevelDesc(chestLevel)
            Case "I"
                pcDay1.Image = chestMenu(pnlDay1, lblDay1, "chest 1", "", chestStatus.ToLower)
                pcDay2.Image = chestMenu(pnlDay2, lblDay2, "chest 1", "")
                pcDay3.Image = chestMenu(pnlDay3, lblDay3, "chest 1", "")
                pcDay4.Image = chestMenu(pnlDay4, lblDay4, "chest 2", "")
                pcDay5.Image = chestMenu(pnlDay5, lblDay5, "chest 1", "")
                pcDay6.Image = chestMenu(pnlDay6, lblDay6, "chest 2", "")
                pcDay7.Image = chestMenu(pnlDay7, lblDay7, "chest 3", "")
            Case "II"
                pcDay1.Image = chestMenu(pnlDay1, lblDay1, "chest 1", "open")
                pcDay2.Image = chestMenu(pnlDay2, lblDay2, "chest 1", "", chestStatus.ToLower)
                pcDay3.Image = chestMenu(pnlDay3, lblDay3, "chest 1", "")
                pcDay4.Image = chestMenu(pnlDay4, lblDay4, "chest 2", "")
                pcDay5.Image = chestMenu(pnlDay5, lblDay5, "chest 1", "")
                pcDay6.Image = chestMenu(pnlDay6, lblDay6, "chest 2", "")
                pcDay7.Image = chestMenu(pnlDay7, lblDay7, "chest 3", "")
            Case "III"
                pcDay1.Image = chestMenu(pnlDay1, lblDay1, "chest 1", "open")
                pcDay2.Image = chestMenu(pnlDay2, lblDay2, "chest 1", "open")
                pcDay3.Image = chestMenu(pnlDay3, lblDay3, "chest 1", "", chestStatus.ToLower)
                pcDay4.Image = chestMenu(pnlDay4, lblDay4, "chest 2", "")
                pcDay5.Image = chestMenu(pnlDay5, lblDay5, "chest 1", "")
                pcDay6.Image = chestMenu(pnlDay6, lblDay6, "chest 2", "")
                pcDay7.Image = chestMenu(pnlDay7, lblDay7, "chest 3", "")
            Case "IV"
                pcDay1.Image = chestMenu(pnlDay1, lblDay1, "chest 1", "open")
                pcDay2.Image = chestMenu(pnlDay2, lblDay2, "chest 1", "open")
                pcDay3.Image = chestMenu(pnlDay3, lblDay3, "chest 1", "open")
                pcDay4.Image = chestMenu(pnlDay4, lblDay4, "chest 2", "", chestStatus.ToLower)
                pcDay5.Image = chestMenu(pnlDay5, lblDay5, "chest 1", "")
                pcDay6.Image = chestMenu(pnlDay6, lblDay6, "chest 2", "")
                pcDay7.Image = chestMenu(pnlDay7, lblDay7, "chest 3", "")
            Case "V"
                pcDay1.Image = chestMenu(pnlDay1, lblDay1, "chest 1", "open")
                pcDay2.Image = chestMenu(pnlDay2, lblDay2, "chest 1", "open")
                pcDay3.Image = chestMenu(pnlDay3, lblDay3, "chest 1", "open")
                pcDay4.Image = chestMenu(pnlDay4, lblDay4, "chest 2", "open")
                pcDay5.Image = chestMenu(pnlDay5, lblDay5, "chest 1", "", chestStatus.ToLower)
                pcDay6.Image = chestMenu(pnlDay6, lblDay6, "chest 2", "")
                pcDay7.Image = chestMenu(pnlDay7, lblDay7, "chest 3", "")
            Case "VI"
                pcDay1.Image = chestMenu(pnlDay1, lblDay1, "chest 1", "open")
                pcDay2.Image = chestMenu(pnlDay2, lblDay2, "chest 1", "open")
                pcDay3.Image = chestMenu(pnlDay3, lblDay3, "chest 1", "open")
                pcDay4.Image = chestMenu(pnlDay4, lblDay4, "chest 2", "open")
                pcDay5.Image = chestMenu(pnlDay5, lblDay5, "chest 1", "open")
                pcDay6.Image = chestMenu(pnlDay6, lblDay6, "chest 2", "", chestStatus.ToLower)
                pcDay7.Image = chestMenu(pnlDay7, lblDay7, "chest 3", "")
            Case "VII"
                pcDay1.Image = chestMenu(pnlDay1, lblDay1, "chest 1", "open")
                pcDay2.Image = chestMenu(pnlDay2, lblDay2, "chest 1", "open")
                pcDay3.Image = chestMenu(pnlDay3, lblDay3, "chest 1", "open")
                pcDay4.Image = chestMenu(pnlDay4, lblDay4, "chest 2", "open")
                pcDay5.Image = chestMenu(pnlDay5, lblDay5, "chest 1", "open")
                pcDay6.Image = chestMenu(pnlDay6, lblDay6, "chest 2", "open")
                pcDay7.Image = chestMenu(pnlDay7, lblDay7, "chest 3", "", chestStatus.ToLower)
        End Select

        If chestStatus = "Ready" Then
            cmdOpenChest.Enabled = True
        Else
            cmdOpenChest.Enabled = False
        End If
    End Sub

    Private Sub frmGiftBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        checkChestItem()
        setChest()
        setTimer()
    End Sub

    Private Sub setTimer()
        Dim mydata As DataTable = mysql.Query("call spServerDateGet()")
        Dim serverDate As Date = mydata.Rows(0).Item(0)
        Dim localDate As Date = Now()
        Dim remainingTime As Long
        serverDate = serverDate.AddDays(2)

        Dim sDate As New DateTime(serverDate.Year, serverDate.Month, serverDate.Day, 1, 0, 0)

        If overrideServerTime Then
            sDate = nextChestAvailable
        End If

        'Label2.Text = sDate.Month.ToString + "/" + sDate.Day.ToString + "/" + sDate.Year.ToString + "  " + sDate.Hour.ToString + ":" + sDate.Minute.ToString + ":" + sDate.Second.ToString
        'serverDate = serverDate.AddHours(8)

        'MsgBox(sDate.ToString)
        'MsgBox(localDate.ToString)

        remainingTime = DateDiff(DateInterval.Second, localDate, sDate)

        'MsgBox(remainingTime.ToString)

        hr = 0
        min = 0
        sec = remainingTime

        Do While sec > 59
            sec -= 60
            min += 1
        Loop

        Do While min > 59
            min -= 60
            hr += 1
        Loop

        lblTimeLeft.Text = "TIME LEFT " + hr.ToString + ":" + min.ToString + ":" + sec.ToString
        tLocalTime.Start()
    End Sub

    Private Sub checkIfRewardsIsAvailable()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblrewards_my_status where accountID=" + userID.ToString)
        If mydata.Rows.Count > 0 Then
            Dim dt As DateTime = mydata.Rows(0).Item("nextUpdate")
            Dim localDate As Date = Now()
            Dim hourTime As Long
            hourTime = DateDiff(DateInterval.Hour, localDate, dt)
            'MsgBox(hourTime.ToString)
            If hourTime <= 0 And hourTime >= -23 Then
                With mysql
                    .setTable("tblrewards_my_status")
                    .addValue("Ready", "status")
                    .Update("accountID", userID.ToString)
                End With
                chestStatus = "Ready"
                lblTimeLeft.Visible = False
                overrideServerTime = False
                setChest()


                setTimer()
                tLocalTime.Start()
            Else
                MsgBox("You Failed To Claim your Gift Rewards Regularly, Please try again next time. Your gift rewards have been reset from the start.", MsgBoxStyle.Information, "Failed To Claim Gift Rewards")
                With mysql
                    .setTable("tblrewards_my_status")
                    .addValue(1, "chestLevel")
                    .addValue("Ready", "status")
                    .Update("accountID", userID.ToString)
                End With
                lblTimeLeft.Visible = False
                chestLevel = 1
                chestStatus = "Ready"
                lblTimeLeft.Visible = False
                overrideServerTime = False
                setChest()

                checkChestItem()

                setTimer()
                'tLocalTime.Start()
            End If
        End If
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tLocalTime.Tick
        If sec > 0 Then
            sec -= 1
        Else
            If min > 0 Then
                sec = 59
                min -= 1
            Else
                If hr > 0 Then
                    min = 59
                    hr -= 1
                End If
            End If
        End If
        lblTimeLeft.Text = "TIME LEFT " + hr.ToString + ":" + min.ToString + ":" + sec.ToString

        If sec <= 0 And min <= 0 And hr <= 0 Then
            tLocalTime.Stop()
            'MsgBox("ayay!")
            checkIfRewardsIsAvailable()
            tLocalTime.Enabled = False
        ElseIf sec < 0 Then
            tLocalTime.Stop()
            'MsgBox("ayay!")
            checkIfRewardsIsAvailable()
            tLocalTime.Enabled = False
        End If

    End Sub

    Private Function getRewards(ByVal chestType As String) As Integer
        Dim Generator As System.Random = New System.Random()
        Dim randomNumber As Integer = Generator.Next(1, 100)
        Dim items() As Integer = {-1, _
      2, 1, 2, 1, 2, 1, 2, 1, 4, 2, _
      2, 1, 2, 1, 2, 2, 2, 3, 1, 2, _
      3, 2, 1, 2, 2, 1, 3, 1, 2, 2, _
      1, 1, 1, 4, 3, 1, 2, 2, 3, 2, _
      2, 2, 1, 1, 3, 1, 4, 1, 1, 2, _
      1, 2, 3, 1, 2, 2, 1, 1, 3, 1, _
      1, 3, 1, 3, 1, 2, 3, 2, 1, 3, _
      1, 1, 2, 1, 4, 1, 2, 1, 2, 2, _
      3, 1, 1, 2, 2, 2, 2, 1, 2, 2, _
      3, 2, 3, 1, 2, 1, 2, 1, 4, 1}

        Select Case chestType
            Case "chest 1"
                '1= 40% chance of 5  EXP / 0 TP
                '2= 40% chance of 10 EXP / 0 TP
                '3= 15% chance of 15 EXP / 5 TP
                '4= 5% chance of  20 EXP / 10 TP / 1 ticket
                Select Case items(randomNumber)
                    Case 1
                        rewards_EXP = 5
                        rewards_TP = 0
                        rewards_Ticket = 0
                    Case 2
                        rewards_EXP = 10
                        rewards_TP = 0
                        rewards_Ticket = 0
                    Case 3
                        rewards_EXP = 15
                        rewards_TP = 5
                        rewards_Ticket = 0
                    Case 4
                        rewards_EXP = 20
                        rewards_TP = 10
                        rewards_Ticket = 1
                End Select
            Case "chest 2"
                '40% chance of 15 EXP / 3  TP
                '40% chance of 30 EXP / 8  TP / 1 ticket
                '15% chance of 40 EXP / 15 TP / 1 ticket
                '5% chance of  60 EXP / 30 TP / 1 ticket
                Select Case items(randomNumber)
                    Case 1
                        rewards_EXP = 15
                        rewards_TP = 3
                        rewards_Ticket = 0
                    Case 2
                        rewards_EXP = 30
                        rewards_TP = 8
                        rewards_Ticket = 1
                    Case 3
                        rewards_EXP = 40
                        rewards_TP = 15
                        rewards_Ticket = 1
                    Case 4
                        rewards_EXP = 60
                        rewards_TP = 15
                        rewards_Ticket = 1
                End Select
            Case "chest 3"
                '40% chance of 30 EXP / 15 TP / 1 ticket
                '40% chance of 40 EXP / 30 TP / 1 ticket
                '15% chance of 50 EXP / 30 TP / 1 ticket
                '5% chance of  80 EXP / 60 TP / 2 tickets
                Select Case items(randomNumber)
                    Case 1
                        rewards_EXP = 30
                        rewards_TP = 15
                        rewards_Ticket = 1
                    Case 2
                        rewards_EXP = 40
                        rewards_TP = 30
                        rewards_Ticket = 1
                    Case 3
                        rewards_EXP = 50
                        rewards_TP = 30
                        rewards_Ticket = 1
                    Case 4
                        rewards_EXP = 80
                        rewards_TP = 60
                        rewards_Ticket = 2
                End Select
        End Select

        If rewards_EXP > 0 And rewards_TP > 0 And rewards_Ticket > 0 Then
            MsgBox("CONGRATULATIONS! You got " + rewards_EXP.ToString + " EXP, " + rewards_TP.ToString + " TP and " + rewards_Ticket.ToString + " Ticket", MsgBoxStyle.Information, "GIft Obtained")
        ElseIf rewards_EXP > 0 And rewards_TP > 0 Then
            MsgBox("CONGRATULATIONS! You got " + rewards_EXP.ToString + " EXP and " + rewards_TP.ToString + " TP", MsgBoxStyle.Information, "GIft Obtained")
        Else
            MsgBox("CONGRATULATIONS! You got " + rewards_EXP.ToString + " EXP", MsgBoxStyle.Information, "GIft Obtained")
        End If


        'POST THE UPDATE
        With mysql
            .setTable("tblrewards_giftbox")
            .addValue(userID.ToString, "accountID")
            .addValue(chestLevel, "chestLevel")
            .addValue(rewards_EXP, "exp")
            .addValue(rewards_TP, "tp")
            .addValue(rewards_Ticket, "ticket")
            .addValue(0, "isAvailable")
            .addValue(Now.ToString("yyyy-MM-dd H:m:s"), "lastOpenedChest")
            .Insert()
        End With

        'POST TO NEWSFEED
        With mysql
            .setTable("tblaccount_newsfeed")
            .addValue(.nextID("newsFeedID"), "newsFeedID")
            .addValue(userID.ToString, "accountID")
            .addValue("Gift Rewards", "type")
            .addValue("Gift Reward Received", "name")
            .addValue("~ just received a gift rewards on Day " + chestLevel.ToString + ".", "description")
            .addValue(chestLevel, "giftChest")
            .addValue("exp~" + rewards_EXP.ToString + ",tp~" + rewards_TP.ToString + ",ticket~" + rewards_Ticket.ToString + "", "giftItemReceived")
            .addValue(Now.ToString("yyyy-MM-dd H:m:s"), "dateUpdate")
            .Insert()
        End With

        cmdOpenChest.Enabled = False

        'update the status
        chestLevel += 1
        chestStatus = "Waiting"
        With mysql
            .setTable("tblrewards_my_status")
            .addValue(chestLevel, "chestLevel")
            .addValue(chestStatus, "status")

            .addValue(data_rewards_EXP + rewards_EXP, "exp")
            .addValue(data_rewards_TP + rewards_TP, "tp")
            .addValue(data_rewards_Ticket + rewards_Ticket, "ticket")


            Dim fDay As DateTime = Now
            fDay = fDay.AddDays(1)
            Dim nextUpate As DateTime = New DateTime(fDay.Year, fDay.Month, fDay.Day, 1, 0, 0)
            .addValue(nextUpate, "nextUpdate")
            .Update("accountID", userID.ToString)
        End With

        If chestStatus = "Waiting" Then
            lblTimeLeft.Visible = True
        End If

        setChest()

    End Function

    Private Sub checkChestItem()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblrewards_my_status where accountID=" + userID.ToString)
        If mydata.Rows.Count > 0 Then
            chestLevel = mydata.Rows(0).Item("chestLevel")
            chestStatus = mydata.Rows(0).Item("status")

            data_rewards_EXP = mydata.Rows(0).Item("exp")
            data_rewards_TP = mydata.Rows(0).Item("tp")
            data_rewards_Ticket = mydata.Rows(0).Item("ticket")

            If chestStatus = "Waiting" Then
                lblTimeLeft.Visible = True
                overrideServerTime = True
                nextChestAvailable = mydata.Rows(0).Item("nextUpdate")
            Else
                lblTimeLeft.Visible = False
            End If
        Else
            'if not exist, it automatically created new status record
            With mysql
                .setTable("tblrewards_my_status")
                .addValue(userID, "accountID")
                .addValue(1, "chestLevel")
                .addValue("Ready", "status")
                .addValue(Now.ToString("yyyy-MM-dd H:m:s"), "nextupdate")
                .Insert()
            End With

            chestLevel = 1
            chestStatus = "Ready"
            lblTimeLeft.Visible = False
            overrideServerTime = False
        End If
    End Sub

    Private Sub cmdOpenChest_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdOpenChest.ClickButtonArea
        Select Case chestLevelDesc(chestLevel)
            Case "I", "II", "III", "V"
                getRewards("chest 1")
            Case "IV", "VI"
                getRewards("chest 2")
            Case "VII"
                getRewards("chest 3")
        End Select
        tLocalTime.Start()
    End Sub


    Private Sub CButton1_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CButton1.ClickButtonArea
        Me.Close()
    End Sub
End Class