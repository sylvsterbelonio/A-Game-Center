Public Class frmDashBoard
    Private mysql As New PowerNET8.mySQL.Init.SQL
    Private myform As New PowerNET8.myForm
    Dim frmDashboard As New frmHomePage


    Private data_ticket As Long = 0
    Private data_tp As Long = 0

    Private Sub frmDashBoard_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Are you sure you want to exit application?", MsgBoxStyle.YesNo, "Exit Application Confirm") = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub frmDashBoard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        'loadRecord()

        statFooter.My_Database = db

        myform.Load_Form(Me, frmDashboard, "frmPrimaryBrowser")
        frmDashboard.WindowState = FormWindowState.Maximized

        Timer1.Start()
        setIcon()
    End Sub

    Private Sub setIcon()
        ClaimTimePointsRewardsToolStripMenuItem.Image = Image.FromFile(Application.StartupPath + "\Images\System\TP\time reward.png")
        SpinATicketToolStripMenuItem.Image = Image.FromFile(Application.StartupPath + "\Images\System\Lottery\slot machine reward.png")
        GidToolStripMenuItem.Image = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\gift reward.png")
        tsTPlogo.BackgroundImage = Image.FromFile(Application.StartupPath + "\Images\System\TP\tp.png")
        tsTicketLogo.BackgroundImage = Image.FromFile(Application.StartupPath + "\Images\System\Lottery\ticket.png")
        tsTicketReady.Image = Image.FromFile(Application.StartupPath + "\Images\System\Lottery\slot machine reward.png")
        tsGiftStatus.Image = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\gift reward.png")

        tsMessage.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\message-read.png")
        tsNotification.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\notification.png")

    End Sub

    Private Sub SaveToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        saveRecord()
    End Sub

    Private Sub MenuStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case CType(sender, ToolStripMenuItem).Name
            'PLAY STATION
            Case "tsPlayStationConfig"

        End Select
    End Sub

    Private Sub EToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EToolStripMenuItem.Click
        Dim frm As New frmEmulatorsFinder
        myform.Load_Form(Me, frm, "frmEmulatorsFinder")
        frm.WindowState = FormWindowState.Normal
    End Sub

    Private Sub GameDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GameDataToolStripMenuItem.Click
        Dim frm As New frmGameDataInfoFinder
        myform.Load_Form(Me, frm, "frmGameDataInfoFinder")
        frm.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ExToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExToolStripMenuItem.Click
        End
    End Sub


    Private Sub tsSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSignIn.Click

        Select Case tsSignIn.Text
            Case "Log In"
                Dim frm As New frmShadow
                With frm
                    .action = "log in"
                    .ShowDialog()
                    If .return_value <> "" Then
                        setAccountInfo(mysql)
                        tsHeading.Text = "WELCOME " + pbName

                        tsPoints.Text = FormatNumber(IIf(IsNumeric(pbPoints), pbPoints, 0), 2)
                        tsRank.Text = pbRank

                        tsSignIn.Text = "Log Out"
                        tsSignIn.Image = My.Resources.dialog_cancel

                        statFooter.My_User = pbUsername
                        statFooter.My_RoleName = pbRole

                        setLogUpdate(mysql, "login")

                        frmDashboard.UnlockFavoriteMenu()



                        'REWARDS
                        tsRewards.Visible = True
                        tsTPlogo.Visible = True
                        tsTP.Visible = True
                        tsTicket.Visible = True
                        tsTicketLogo.Visible = True
                        tsGiftStatus.Visible = True
                        'tsTicketReady.Visible = True

                        checkGiftBox()
                        tsTP.Text = "x " + FormatNumber(data_tp, 0)
                        tsTicket.Text = "x " + FormatNumber(data_ticket, 0)

                        'NOTIFICATION
                        sp6.Visible = True
                        tsMessage.Visible = True
                        tsNotification.Visible = True

                        'RANK
                        tsRankPics.Visible = True
                        tsRank.Visible = True
                        tsPoints.Visible = True
                        sp1.Visible = True
                        sp2.Visible = True
                        sp3.Visible = True


                        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=" + userID.ToString)
                        If mydata.Rows.Count > 0 Then
                            Try '
                                tsProfile.BackgroundImage = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(0).Item("picture").ToString.Replace("~", "\"))
                            Catch ex As Exception
                                tsProfile.BackgroundImage = My.Resources.profile_icon1
                            End Try

                        End If

                    End If
                End With
            Case "Log Out"
                If MsgBox("Do you want to log out your account?", MsgBoxStyle.YesNo, "Log Out Confirm") = MsgBoxResult.Yes Then
                    setLogUpdate(mysql, "logout")

                    'REWARDS
                    tsRewards.Visible = False
                    tsTPlogo.Visible = False
                    tsTP.Visible = False
                    tsTicket.Visible = False
                    tsTicketLogo.Visible = False
                    tsGiftStatus.Visible = False
                    tsTicketReady.Visible = False

                    'RANK
                    tsRank.Visible = False
                    tsPoints.Visible = False
                    tsRankPics.Visible = False


                    sp1.Visible = False
                    sp2.Visible = False
                    sp3.Visible = False
                    sp4.Visible = False
                    sp5.Visible = False

                    'NOTIFICATION
                    sp6.Visible = False
                    tsMessage.Visible = False
                    tsNotification.Visible = False


                    tsHeading.Text = "WELCOME GUEST!"
                    tsPoints.Text = "0.00"
                    tsRank.Text = "RANK ?"

                    tsSignIn.Text = "Log In"
                    tsSignIn.Image = My.Resources._1437561088_User_Info

                    statFooter.My_RoleName = "Standard"
                    statFooter.My_User = "?"
                    userID = 0
                    pbUsername = ""
                    pbPoints = 0
                    pbRank = ""
                    tsProfile.BackgroundImage = My.Resources.profile_icon1
                    setAccountInfo(mysql)
                End If
        End Select
    End Sub

    Private Sub tsProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsProfile.Click
        If tsSignIn.Text = "Log Out" Then
            Dim frm As New frmProfileInformation
            With frm
                .ShowDialog()
                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=" + userID.ToString)
                If mydata.Rows.Count > 0 Then
                    Try
                        tsProfile.BackgroundImage = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(0).Item("picture").ToString.Replace("~", "\"))
                    Catch ex As Exception
                        tsProfile.BackgroundImage = My.Resources.profile_icon1
                    End Try

                End If
            End With
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If userID > 0 Then
            tsPoints.Text = "Points: " + FormatNumber(IIf(IsNumeric(pbPoints), pbPoints, 0), 2)
            tsRank.Text = "" + pbRank

            If pbImageRank Is Nothing Then
                tsRankPics.BackgroundImage = Nothing
            Else
                'Dim byteImage() As Byte = reader("Foto")
                Dim frmImageView As New System.IO.MemoryStream(pbImageRank)
                tsRankPics.BackgroundImage = Image.FromStream(frmImageView)
            End If
        End If

        Dim frm As New frmShadow
        With frm
            .action = "level update"
            If rankID > dataRank Then
                .rankID = rankID
                .rankAction = "Up"
                With mysql
                    .setTable("tblaccount")
                    .addValue(rankID, "rankID")
                    .Update("accountID", userID.ToString)
                End With


                dataRank = rankID
                Timer1.Stop()
                .ShowDialog()

                'ADD NEWSFEED
                With mysql
                    .setTable("tblaccount_newsfeed")
                    .addValue(userID.ToString, "accountID")
                    .addValue("Rank", "Type")
                    .addValue("Rank Promoted", "name")
                    .addValue("~ has been promoted from " + getRankName(rankID - 1) + " into " + getRankName(rankID) + ".", "description")
                    .addValue(rankID - 1, "rank_from")
                    .addValue(rankID, "rank_to")
                    .addValue(Now.ToString("yyyy-MM-dd H:m:s"), "dateUpdate")
                    .Insert()
                End With

            ElseIf rankID < dataRank Then
                .action = "level update"
                .rankID = rankID
                .rankAction = "Down"
                dataRank = rankID
                .ShowDialog()
                With mysql
                    .setTable("tblaccount")
                    .addValue(rankID, "rankID")
                    .Update("accountID", userID.ToString)
                End With
                'ADD NEWSFEED
                With mysql
                    .setTable("tblaccount_newsfeed")
                    .addValue(userID.ToString, "accountID")
                    .addValue("Rank", "Type")
                    .addValue("Rank Demoted", "name")
                    .addValue("~ has been demoted from " + getRankName(rankID - 1) + " into " + getRankName(rankID) + ".", "description")
                    .addValue(rankID - 1, "rank_from")
                    .addValue(rankID, "rank_to")
                    .addValue(Now.ToString("yyyy-MM-dd H:m:s"), "dateUpdate")
                    .Insert()
                End With
            End If
            Timer1.Start()
        End With


    End Sub

    Private Function getRankName(ByVal rankID As Integer)
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount_activity_rank where rankID=" + rankID.ToString)
        If mydata.Rows.Count > 0 Then
            Return mydata.Rows(0).Item("rankName")
        Else
            Return "None"
        End If
    End Function


    Private Sub GameTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GameTypeToolStripMenuItem.Click
        Dim frm As New frmGameTypeFinder
        myform.Load_Form(Me, frm, "frmGameTypeFinder")
        frm.WindowState = FormWindowState.Normal
    End Sub

    Private Sub GidToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GidToolStripMenuItem.Click
        'myform.Load_Form(Me, frmDashboard, "frmGiftBox")
        Dim frm As New frmShadow
        With frm
            .action = "gift box"
            .ShowDialog()
        End With

        checkGiftBox()
        setAccountInfo(mysql)
    End Sub

    Private Sub SpinATicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpinATicketToolStripMenuItem.Click
        If data_ticket > 0 Then
            data_ticket -= 1
            tsTicket.Text = "x " + FormatNumber(data_ticket, 0)
            With mysql
                .setTable("tblrewards_my_status")
                .addValue(data_ticket, "ticket")
                .Update("accountID", userID.ToString)
            End With

            Dim frm As New frmShadow
            frm.action = "slot machine"
            frm.ShowDialog()
            checkGiftBox()
            setAccountInfo(mysql)
        Else
            MsgBox("You don't have enough ticket. Please try again next time.", MsgBoxStyle.Exclamation, "Not Enough Ticket")
        End If
    End Sub

#Region "GIFT BOX UPDATE"

    Private giftStatus As String = ""
    Private nextUpdate As DateTime
    Private hr, min, sec As Integer

    Private Sub checkGiftBox()

        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblrewards_my_status where accountID=" + userID.ToString)
        If mydata.Rows.Count > 0 Then
            nextUpdate = mydata.Rows(0).Item("nextUpdate")
            giftStatus = mydata.Rows(0).Item("status")
            data_ticket = mydata.Rows(0).Item("ticket")
            data_tp = mydata.Rows(0).Item("tp")

            If data_ticket > 0 Then
                tsTicketReady.Visible = True
                sp4.Visible = False
            Else
                tsTicketReady.Visible = False
                sp5.Visible = False
            End If

            If giftStatus = "Waiting" Then
                setTimer()
                tGiftRewards.Start()
                tsGiftStatus.Visible = True
                sp4.Visible = True
            Else
                tsGiftStatus.Text = "Claim Your Gift"
                tsGiftStatus.ForeColor = Color.Green
                tsGiftStatus.Visible = True
                sp4.Visible = True
            End If

            tsTP.Text = "x " + FormatNumber(data_tp, 0)
        Else
            tsGiftStatus.Text = "Claim Your Gift"
            tsGiftStatus.Visible = True
            sp4.Visible = True
        End If

    End Sub

    Private Sub tGiftRewards_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tGiftRewards.Tick
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
        tsGiftStatus.Text = "Time Left " + hr.ToString + ":" + min.ToString + ":" + sec.ToString

        If sec <= 0 And min <= 0 And hr <= 0 Then
            tGiftRewards.Stop()
            tsGiftStatus.Text = "Get Your Gift"
            'MsgBox("ayay!")
            'checkIfRewardsIsAvailable()
            'tLocalTime.Enabled = False
        ElseIf sec < 0 Then
            'checkIfRewardsIsAvailable()
        End If
    End Sub

    Private Sub setTimer()
        Dim mydata As DataTable = mysql.Query("call spServerDateGet()")
        Dim serverDate As Date = mydata.Rows(0).Item(0)
        Dim localDate As Date = Now()
        Dim remainingTime As Long
        serverDate = serverDate.AddDays(2)

        Dim sDate As New DateTime(serverDate.Year, serverDate.Month, serverDate.Day, 1, 0, 0)

        sDate = nextUpdate

        remainingTime = DateDiff(DateInterval.Second, localDate, sDate)

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

        tsGiftStatus.ForeColor = Color.Red
        tsGiftStatus.Text = "Time Left " + hr.ToString + ":" + min.ToString + ":" + sec.ToString
        tGiftRewards.Start()

    End Sub

    Private Sub tsGiftStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsGiftStatus.Click
        GidToolStripMenuItem_Click(GidToolStripMenuItem, Nothing)
    End Sub

    Private Sub tsTicketReady_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsTicketReady.Click
        SpinATicketToolStripMenuItem_Click(SpinATicketToolStripMenuItem, Nothing)
    End Sub

    Private Sub ClaimTimePointsRewardsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClaimTimePointsRewardsToolStripMenuItem.Click
        Dim frm As New frmTPConversion
        With frm
            .ShowDialog()
        End With
    End Sub

#End Region

 

    Private Sub UnlockSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private unlockSettings As Boolean = False
    Private Sub UnlockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnlockToolStripMenuItem.Click
        If unlockSettings = False Then
            Dim frm As New frmLock
            With frm
                .ShowDialog()
                If .return_value = "yes" Then
                    unlockSettings = True
                    ModulesToolStripMenuItem.Visible = True
                End If
            End With
        Else
            unlockSettings = False
            ModulesToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub FeedbackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FeedbackToolStripMenuItem.Click
        MsgBox("This application help to browse all kinds of game and very easy to locate. A combination of accounts, newsfeed, points and other features that craves the player.", MsgBoxStyle.Information, "Programmed and Developed by: Sylvster R. Belonio")
    End Sub
End Class
