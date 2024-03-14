Imports System.IO
Imports System.Xml
Imports System.Threading
Imports PowerNET8.myString.Share
Public Class frmMain

    Private mysql As New PowerNET8.mySQL.Init.SQL
    Private selectedGameID As String = "0"

    Private Sub reloadPlatforms()
        Dim mydata As DataTable = mysql.Query("select distinct platforms from tblgamedata order by platforms")
        cboPlatforms.Items.Clear()
        If mydata.Rows.Count - 1 Then
            For i As Integer = 0 To mydata.Rows.Count - 1
                With cboPlatforms
                    .Items.Add(mydata.Rows(i).Item(0))
                End With
            Next
        End If
        cboPlatforms.Items.Add("-View All-")
        cboPlatforms.Text = "-View All-"
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.ControlBox = False Then
            e.Cancel = True
            MsgBox("Unble to exit form during battle between two players.", MsgBoxStyle.Exclamation, "Error in Exit")
        End If
    End Sub

    Private Function getSumWLBet(ByVal accountID As String, ByVal type As String) As Decimal
        Select Case type
            Case "win"
                Dim mydata As DataTable = mysql.Query("select (select sum(bet_win_A) as 'total' from tblaccount_battle where accountID_A=" + accountID + " and status_A='win') as 'A', (select sum(bet_win_B) as 'total' from tblaccount_battle where accountID_B=" + accountID + " and status_B='win') as 'B'")
                If mydata.Rows.Count > 0 Then
                    Dim tot As Decimal = 0
                    If Not IsDBNull(mydata.Rows(0).Item(0)) Then tot += mydata.Rows(0).Item(0)
                    If Not IsDBNull(mydata.Rows(0).Item(1)) Then tot += mydata.Rows(0).Item(1)
                    Return tot
                End If
            Case "lose"
                Dim mydata As DataTable = mysql.Query("select (select sum(bet_lose_A) as 'total' from tblaccount_battle where accountID_A=" + accountID + " and status_A='lose') as 'A', (select sum(bet_lose_B) as 'total' from tblaccount_battle where accountID_B=" + accountID + " and status_B='lose') as 'B'")
                If mydata.Rows.Count > 0 Then
                    Dim tot As Decimal = 0
                    If Not IsDBNull(mydata.Rows(0).Item(0)) Then tot += mydata.Rows(0).Item(0)
                    If Not IsDBNull(mydata.Rows(0).Item(1)) Then tot += mydata.Rows(0).Item(1)
                    Return tot
                End If
            Case "draw"
                Dim mydata As DataTable = mysql.Query("select (select sum(bet_win_A) as 'total' from tblaccount_battle where accountID_A=" + accountID + " and status_A='draw') as 'A', (select sum(bet_win_B) as 'total' from tblaccount_battle where accountID_B=" + accountID + " and status_B='draw') as 'B'")
                If mydata.Rows.Count > 0 Then
                    Dim tot As Decimal = 0
                    If Not IsDBNull(mydata.Rows(0).Item(0)) Then tot += mydata.Rows(0).Item(0)
                    If Not IsDBNull(mydata.Rows(0).Item(1)) Then tot += mydata.Rows(0).Item(1)
                    Return tot
                End If
        End Select
        Return 0
    End Function

    Private Function getWinLoseStatus(ByVal accountID As String, ByVal type As String)
        Select Case Type
            Case "win"
                Dim mydata As DataTable = mysql.Query("select (select count(status_A) as 'total' from tblaccount_battle where accountID_A=" + accountID + " and status_A='win') as 'A', (select count(status_B) as 'total' from tblaccount_battle where accountID_B=" + accountID + " and status_B='win') as 'B'")
                If mydata.Rows.Count > 0 Then
                    Return mydata.Rows(0).Item(0) + mydata.Rows(0).Item(1)
                End If
            Case "lose"
                Dim mydata As DataTable = mysql.Query("select (select count(status_A) as 'total' from tblaccount_battle where accountID_A=" + accountID + " and status_A='lose') as 'A', (select count(status_B) as 'total' from tblaccount_battle where accountID_B=" + accountID + " and status_B='lose') as 'B'")
                If mydata.Rows.Count > 0 Then
                    Return mydata.Rows(0).Item(0) + mydata.Rows(0).Item(1)
                End If
            Case "draw"
                Dim mydata As DataTable = mysql.Query("select (select count(status_A) as 'total' from tblaccount_battle where accountID_A=" + accountID + " and status_A='draw') as 'A', (select count(status_B) as 'total' from tblaccount_battle where accountID_B=" + accountID + " and status_B='draw') as 'B'")
                If mydata.Rows.Count > 0 Then
                    Return mydata.Rows(0).Item(0) + mydata.Rows(0).Item(1)
                End If
        End Select
        Return 0
    End Function


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim con As New PowerNET8.myConnector
        If con.check_No_Multi_System_Running("Battle") Then
            If con.connection_MYSQL_Settings(Application.StartupPath, "connection.ini") Then
                With con
                    dblocalhost = ._Localhost
                    dbport = ._Port
                    dbuser = ._UserRoot
                    dbpassword = ._Password
                    db = ._Database
                End With
            End If
        End If

        connect(mysql)
        defaults()

    End Sub

    Private Sub defaults()
        pcPicA.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\profile_icon1.jpg")
        pcRankA.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\no image.png")
        pcPicB.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\profile_icon1.jpg")
        pcRankB.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\no image.png")
        lblReadyBetA.Text = "0"
        lblReadyBetB.Text = "0"
    End Sub

    Private Sub reloadGames()
        Me.Cursor = Cursors.WaitCursor

        Dim wh As String = ""
        If cboPlatforms.Text <> "-View All-" Then Concat.Append(wh, " platforms like '" + cboPlatforms.Text + "' ", " and ")
        If txtSearchGames.Text <> "" Then Concat.Append(wh, " gameName like '" + txtSearchGames.Text + "%' ", " and ")
        If wh <> "" Then wh = " and " + wh
        Dim mydata As DataTable = mysql.Query("SELECT tblgamedata.gameID, coverPhoto, gameName, platforms FROM  tblgamedata_imageloc  INNER JOIN  tblgamedata    ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) where isVisible=1 and versusMode='Y' " + wh + " order by gameName ")
        flpGames.Controls.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            createBox(flpGames, mydata.Rows(i).Item("gameID"), mydata.Rows(i).Item("coverPhoto"), mydata.Rows(i).Item("gameName"), mydata.Rows(i).Item("platforms"))
        Next
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Box_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf sender Is Panel Then
            sender.backcolor = Color.FromArgb(21, 21, 21)
        Else
            sender.parent.backcolor = Color.FromArgb(21, 21, 21)
        End If
    End Sub

    Private Sub Box_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        sender.Cursor = Cursors.Hand
        If TypeOf sender Is Panel Then
            sender.backcolor = Color.FromArgb(255, 128, 0)
            sender.parent.focus()
        Else
            sender.parent.backcolor = Color.FromArgb(255, 128, 0)
            sender.parent.parent.focus()
        End If
    End Sub

    Private Sub Box_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gameID As String
        If TypeOf sender Is Panel Then
            gameID = sender.tag
        Else
            gameID = sender.parent.tag
        End If
        Dim mydata As DataTable = mysql.Query("SELECT tblgamedata.gameID, coverPhoto, gameName,gameType, platforms FROM  tblgamedata_imageloc  INNER JOIN  tblgamedata    ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) where tblgamedata.gameID=" + gameID)
        If mydata.Rows.Count > 0 Then
            pnlLoadGame.Visible = False
            selectedGameID = mydata.Rows(0).Item("gameID")
            pcGamesPic.Image = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(0).Item("coverPhoto").ToString.Replace("~", "\"))
            lblSGameName.Text = "Game Name: " + mydata.Rows(0).Item("gameName")
            lblSGenre.Text = "Genre: " + mydata.Rows(0).Item("gameType")
            lblSPlatforms.Text = "Platforms: " + mydata.Rows(0).Item("platforms")
            cmdLoadGame.Text = "Load Game"
            cmdBetA.Visible = True
            cmdBetB.Visible = True
            lblBetPointsA.Visible = True
            lblBetPointsB.Visible = True
            txtBetPointsA.Visible = True
            txtBetPointsB.Visible = True
            txtBetPointsA.Value = 0
            txtBetPointsB.Value = 0
            cmdReset.Visible = True
            cmdBattleHistory.Visible = True
        End If
    End Sub

    Private Sub createBox(ByRef flpBox As FlowLayoutPanel, ByVal gameID As String, ByVal imageLoc As String, ByVal gameName As String, ByVal platforms As String)
        Dim pnlBOdy As New Panel
        With pnlBOdy
            .BackColor = Color.FromArgb(21, 21, 21)
            .Width = 140
            .Height = 152
            flpBox.Controls.Add(pnlBOdy)
            .Tag = gameID
            AddHandler .Click, AddressOf Box_Click
            AddHandler .MouseMove, AddressOf Box_MouseMove
            AddHandler .MouseLeave, AddressOf Box_MouseLeave
        End With

        Dim pcPicture As New PictureBox
        With pcPicture
            .Image = Image.FromFile(Application.StartupPath + "\" + imageLoc.Replace("~", "\"))
            .Left = 3
            .Top = 3
            .Width = 133
            .Height = 92
            .SizeMode = PictureBoxSizeMode.Zoom
            pnlBOdy.Controls.Add(pcPicture)
            AddHandler .Click, AddressOf Box_Click
            AddHandler .MouseMove, AddressOf Box_MouseMove
            AddHandler .MouseLeave, AddressOf Box_MouseLeave
        End With

        Dim lblName As New Label
        With lblName
            .AutoSize = False
            .Width = 123
            .Height = 23
            .Left = 3
            .Top = 98
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = gameName
            pnlBOdy.Controls.Add(lblName)
            AddHandler .Click, AddressOf Box_Click
            AddHandler .MouseMove, AddressOf Box_MouseMove
            AddHandler .MouseLeave, AddressOf Box_MouseLeave
        End With

        Dim lblPlatforms As New Label
        With lblPlatforms
            .AutoSize = False
            .Left = 3
            .Top = 121
            Dim oldFont As Font = New Font(.Font.FontFamily, 7.25, FontStyle.Italic, .Font.Unit)
            .Font = oldFont
            .Width = 134
            .Text = platforms
            .TextAlign = ContentAlignment.MiddleCenter
            .Height = 23
            pnlBOdy.Controls.Add(lblPlatforms)
            AddHandler .Click, AddressOf Box_Click
            AddHandler .MouseMove, AddressOf Box_MouseMove
            AddHandler .MouseLeave, AddressOf Box_MouseLeave
        End With
    End Sub

#Region "OTHER CODES"
#Region "WinAPI declarations"
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long
    Private Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (ByVal hWnd1 As Long, ByVal hWnd2 As Long, ByVal lpsz1 As String, ByVal lpsz2 As String) As Long
    Private Declare Function SetParentWindow Lib "user32" Alias "SetParent" (ByVal hWndChild As Long, ByVal hWndNewParent As Long) As Long
#End Region

    Public Shared Sub AttachFormToDesktop(ByRef targetForm As Form)
        Dim hWinShell, hDesktopClass, hDesktopFileListView As Long

        'In the below: Retrieving neccessary handles, one by one.

        '"ProgMan" is the Windows shell.
        hWinShell = FindWindow("progman", vbNullString)

        'The windows desktop is a "shelldll_defview" class, and also a child to the ProgMan window.
        hDesktopClass = FindWindowEx(hWinShell, 0, "shelldll_defview", vbNullString)

        '"syslistview32" is a windows listview. This particular listview is the desktops listview, and that's where we'll append our targetForm. 
        hDesktopFileListView = FindWindowEx(hDesktopClass, 0, "syslistview32", vbNullString)

        SetParentWindow(targetForm.Handle, hDesktopFileListView) 'Set targetform's parent window to the desktops' file listview

    End Sub 'Makes the form permanently positioned on top of the desktop, above the desktop icons but below any other running applications.

    Private counter As Integer = 0
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Me.Activate()
        If counter >= 30 Then
            cmdPlusA.Enabled = True
            cmdMinusA.Enabled = True
            cmdPlusB.Enabled = True
            cmdMinusB.Enabled = True
            counter = 0
            Timer1.Stop()
        ElseIf counter = 0 Then
            cmdPlusA.Enabled = False
            cmdMinusA.Enabled = False
            cmdPlusB.Enabled = False
            cmdMinusB.Enabled = False
            counter += 1
        Else
            counter += 1
        End If
    End Sub
#End Region

    Private Function validateAccountID() As Boolean
        If userID1 <> "" And userID2 <> "" Then
            If userID1 = userID2 Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
        Return True
    End Function

    Private Sub cmdLogInA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogInA.Click
        Dim frm As New frmLogIn
        Select Case cmdLogInA.Text
            Case "Log In"
                cmdLogInA.Visible = False
                pnlLogInA.Visible = True
                txtUsernameA.Text = ""
                txtPasswordA.Text = ""
                txtUsernameA.Focus()
            Case "Log Out"
                userID1 = "0"
                cmdLogInA.Text = "Log In"
                lblBetPointsA.Visible = False
                txtBetPointsA.Visible = False
                pcPicA.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\profile_icon1.jpg")
                pcRankA.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\no image.png")
                lblNameA.Text = "Name:"
                lblAvailablePointsA.Text = "Available Points: "
                cmdBetA.Visible = False
                cmdBetA.Enabled = True
                cmdBetB.Enabled = True
                lblWwinA.Text = "0"
                lblLoseA.Text = "0"
                lblDrawA.Text = "0"
        End Select
    End Sub

    Private Sub loadPlayerA(ByVal userID As String)
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=" + userID)
        If mydata.Rows.Count > 0 Then
            Try
                pcPicA.Image = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(0).Item("picture").ToString.Replace("~", "\"))
            Catch ex As Exception
                pcPicA.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\profile_icon1.jpg")
            End Try
            Dim points As Integer = getRankPoints(userID)
            pcRankA.Image = getRankLogo_Selected(userID, points)
            betPointsA = points
            txtBetPointsA.Maximum = points
            txtBetPointsA.Value = 0

            lblWwinA.Text = getWinLoseStatus(userID, "win")
            lblLosea.Text = getWinLoseStatus(userID, "lose")
            lblDrawa.Text = getWinLoseStatus(userID, "draw")


            lblNameA.Text = "Name: " + mydata.Rows(0).Item("firstname") + " " + mydata.Rows(0).Item("middlename") + " " + mydata.Rows(0).Item("lastname")
            lblAvailablePointsA.Text = "Available Points: " + FormatNumber(points, 2) + " pts"
            lblRankPosition.Text = getRankPosition(userID, points)
            'lblBetPointsA.Visible = True
            'txtBetPointsA.Visible = True
        End If
    End Sub

    Private betPointsB As Decimal = 0
    Private Sub loadPlayerB(ByVal userID As String)
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=" + userID)
        If mydata.Rows.Count > 0 Then
            Try
                pcPicB.Image = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(0).Item("picture").ToString.Replace("~", "\"))
            Catch ex As Exception
                pcPicB.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\profile_icon1.jpg")
            End Try
            Dim points As Integer = getRankPoints(userID)
            pcRankB.Image = getRankLogo_Selected(userID, points)
            betPointsB = points
            txtBetPointsB.Maximum = points
            txtBetPointsB.Value = 0

            lblWinB.Text = getWinLoseStatus(userID, "win")
            lblLoseB.Text = getWinLoseStatus(userID, "lose")
            lblDrawB.Text = getWinLoseStatus(userID, "draw")

            lblNameB.Text = "Name: " + mydata.Rows(0).Item("firstname") + " " + mydata.Rows(0).Item("middlename") + " " + mydata.Rows(0).Item("lastname")
            lblAvailablePointsB.Text = "Available Points: " + FormatNumber(points, 2) + " pts"
            lblRankPositionb.Text = getRankPosition(userID, points)
            'lblBetPointsB.Visible = True
            'txtBetPointsB.Visible = True
        End If
    End Sub

    Private Function getRankLogo_Selected(ByVal accountID As String, ByVal points As String) As Image
        'GET THE RANK BASED FROM POINTS
        Dim mydata As DataTable = mysql.Query("select * from tblaccount_activity_rank where " + IIf(points = "", "0", points) + " <= tPoints and " + IIf(points = "", "0", points) + " >= fPoints")
        If mydata.Rows.Count > 0 Then
            If Not IsDBNull(mydata.Rows(0).Item("rankLogo")) Then
                Dim pbImage() As Byte = mydata.Rows(0).Item("rankLogo")
                Dim frmImageView As New System.IO.MemoryStream(pbImage)
                Return Image.FromStream(frmImageView)
            Else
                Return Nothing
            End If
            Return Nothing
        End If
    End Function

    Public Function getTotalPoints(ByRef mysql As PowerNET8.mySQL.Init.SQL, ByVal gameID As String, ByVal accountID As String) As String
        Dim mydata As DataTable = mysql.Query("SELECT sum(points)    FROM  tblaccount_activity_points_ref INNER JOIN  tblaccount_activity   ON (tblaccount_activity_points_ref.name = tblaccount_activity.typeVal) where accountID=" + accountID.ToString + " and gameID=" + gameID + " and typeVal = 'start_play'")
        Dim totalStartPlay = mydata.Rows(0).Item(0)
        mydata = mysql.Query("SELECT sum(pts_timePlayed) FROM  tblaccount_activity where accountID=" + accountID.ToString + " and gameID=" + gameID + " and typeVal = 'playing'")
        Dim totalPlaying = mydata.Rows(0).Item(0)
        If Not IsDBNull(totalStartPlay) And Not IsDBNull(totalPlaying) Then
            Return FormatNumber(totalStartPlay + totalPlaying, 2)
        ElseIf Not IsDBNull(totalStartPlay) Then
            Return FormatNumber(totalStartPlay, 2)
        Else
            Return "0"
        End If

    End Function

    Private Function getRankPoints(ByVal accountID As String, Optional ByVal wh As String = "") As Decimal
        'GET THE TOTAL NUMBER OF OVERALL POINTS
        Dim totalPoints As Double = 0
        Dim s As String
        If wh = "" Then
            s = "SELECT sum(points) as 'total' FROM  tblaccount_activity  INNER JOIN tblaccount_activity_points_ref    ON (tblaccount_activity.typeVal = tblaccount_activity_points_ref.name)  where tblaccount_activity.accountID = " + accountID + "  and (typeVal = 'login' or typeVal = 'logout') " + wh
        Else
            s = "SELECT sum(points) as 'total' FROM  tblaccount_activity  INNER JOIN tblaccount_activity_points_ref    ON (tblaccount_activity.typeVal = tblaccount_activity_points_ref.name)  LEFT JOIN tblgamedata   ON (tblgamedata.gameID = tblaccount_activity.gameID)  where tblaccount_activity.accountID = " + accountID + "   " + wh
        End If
        '

        'game points
        Dim mydata As DataTable = mysql.Query("SELECT tblaccount_activity.accountID, tblgamedata.gameID,tblgamedata_imageloc.coverPhoto, tblgamedata.gameName, gameType as 'genre',platforms, sum(points) as 'total' FROM   tblaccount_activity inner JOIN tblaccount_activity_points_ref       ON (tblaccount_activity.typeVal = tblaccount_activity_points_ref.name) INNER JOIN tblgamedata     ON (tblgamedata.gameID = tblaccount_activity.gameID)   INNER JOIN tblgamedata_imageloc   ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) where tblaccount_activity.accountID = " + accountID + " " + wh + " group by tblgamedata.gameID order by total desc")
        If mydata.Rows.Count > 0 Then
            'dgvProfInfoGameStatus.Rows.Clear()
            For i As Integer = 0 To mydata.Rows.Count - 1
                totalPoints += getTotalPoints(mysql, mydata.Rows(i).Item("gameID"), accountID.ToString)
            Next
        End If

        If wh = "" Then
            mydata = mysql.Query(s)
            If mydata.Rows.Count > 0 Then
                If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                    totalPoints += mydata.Rows(0).Item(0)
                End If
            End If

            'GET THE TOTAL POINTS OF GIFT REWARDS
            mydata = mysql.Query("SELECT sum(exp) from tblrewards_giftbox where accountID=" + accountID.ToString)
            If mydata.Rows.Count > 0 Then
                If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                    totalPoints += mydata.Rows(0).Item(0)
                End If
            End If

            'GET THE TOTAL POINTS OF SLOT MACHINE
            mydata = mysql.Query("SELECT sum(exp) from tblrewards_slotmachine where accountID=" + accountID.ToString)
            If mydata.Rows.Count > 0 Then
                If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                    totalPoints += mydata.Rows(0).Item(0)
                End If
            End If
        End If


        'BET POINTS ADDITION
        Dim win As Decimal = getSumWLBet(accountID, "win")
        Dim lose As Decimal = getSumWLBet(accountID, "lose")

        Return totalPoints + (win - lose)


    End Function

    Private Function getRankPosition(ByVal accountID As String, ByVal points As Decimal) As String
        'GET THE RANK BASED FROM POINTS
        Dim mydata As DataTable = mysql.Query("select * from tblaccount_activity_rank where " + IIf(points.ToString = "", "0", points.ToString) + " <= tPoints and " + IIf(points.ToString = "", "0", points.ToString) + " >= fPoints")
        If mydata.Rows.Count > 0 Then
            If Not IsDBNull(mydata.Rows(0).Item("rankName")) Then
                Return mydata.Rows(0).Item("rankName")
            Else
                Return Nothing
            End If
            Return Nothing
        End If
    End Function

    Private Sub txtBetPointsA_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBetPointsA.MouseClick
        txtBetPointsA.Select()
    End Sub

    Private Sub txtBetPointsA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBetPointsA.ValueChanged
        If txtBetPointsA.Value > 0 Then
            'cmdBetA.Enabled = True
        Else
            'cmdBetA.Enabled = False
        End If

        If txtBetPointsA.Value > 0 And cmdReadyA.Enabled = False And txtBetPointsB.Value > 0 And cmdReadyB.Enabled = False Then
            cmdSetup.Enabled = True
        Else
            cmdSetup.Enabled = False
        End If


    End Sub

    Private Sub cmdLogInB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogInB.Click
        Dim frm As New frmLogIn
        Select Case cmdLogInB.Text
            Case "Log In"
                cmdLogInB.Visible = False
                pnlLoginB.Visible = True
                txtUsernameB.Text = ""
                txtPasswordB.Text = ""
                txtUsernameB.Focus()
            Case "Log Out"
                userID2 = "0"
                cmdLogInB.Text = "Log In"
                lblBetPointsB.Visible = False
                txtBetPointsB.Visible = False
                pcPicB.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\profile_icon1.jpg")
                pcRankB.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\no image.png")
                lblNameB.Text = "Name:"
                lblAvailablePointsB.Text = "Available Points: "
                cmdBetB.Visible = False
                lblWinB.Text = "0"
                lblLoseB.Text = "0"
                lblDrawB.Text = "0"
        End Select
    End Sub

    Private Sub lblNameA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblNameA.TextChanged
        If lblNameA.Text <> "Name:" And lblNameB.Text <> "Name:" Then
            cmdLoadGame.Enabled = True
        Else
            cmdLoadGame.Enabled = False
        End If
    End Sub

    Private Sub lblNameB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblNameB.TextChanged
        If lblNameA.Text <> "Name:" And lblNameB.Text <> "Name:" Then
            cmdLoadGame.Enabled = True
        Else
            cmdLoadGame.Enabled = False
        End If
    End Sub


    Private betPointsA As Decimal = 0
    Private Sub cmdLogInAA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogInAA.Click
        If txtUsernameA.Text <> "" And txtPasswordA.Text <> "" Then
            Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount where username = '" + txtUsernameA.Text + "'")
            If mydata.Rows.Count > 0 Then
                mydata = mysql.Query("SELECT * FROM tblaccount where username = '" + txtUsernameA.Text + "' and password ='" + mysql.crypt(txtPassworda.Text) + "'")
                If mydata.Rows.Count > 0 Then
                    userID1 = mydata.Rows(0).Item("accountID")

                    If validateAccountID() Then
                        pnlLogInA.Visible = False
                        loadPlayerA(userID1)
                        cmdLogInA.Text = "Log Out"
                        'cmdBetA.Visible = True
                        cmdLogInA.Visible = True


                        If Val(selectedGameID) > 0 Then
                            cmdBetB.Visible = True
                            lblBetPointsB.Visible = True
                            txtBetPointsB.Visible = True
                        End If

                    Else
                        MsgBox("Duplication of User Account, please try another account name", MsgBoxStyle.Exclamation, "Unable To Log In")
                    End If

                Else
                    txtPasswordA.Focus()
                    txtPasswordA.Text = ""
                    MsgBox("Password does not match!", MsgBoxStyle.Exclamation, "Password Incorrect")
                End If
            Else
                txtUsernameA.Text = ""
                txtUsernameA.Focus()
                MsgBox("Username does not exist, please try again", MsgBoxStyle.Exclamation, "Username Failure")
            End If
        Else
            MsgBox("Please fill up the required field", MsgBoxStyle.Information, "Required Field")
        End If
    End Sub

    Private Sub cmdCancelAA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelAA.Click
        pnlLogInA.Visible = False
        cmdLogInA.Visible = True
    End Sub

    Private Sub cmdLogInBB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogInBB.Click
        If txtUsernameB.Text <> "" And txtPasswordB.Text <> "" Then
            Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount where username = '" + txtUsernameB.Text + "'")
            If mydata.Rows.Count > 0 Then
                mydata = mysql.Query("SELECT * FROM tblaccount where username = '" + txtUsernameB.Text + "' and password ='" + mysql.crypt(txtPasswordB.Text) + "'")
                If mydata.Rows.Count > 0 Then
                    userID2 = mydata.Rows(0).Item("accountID")
                    If validateAccountID() Then
                        pnlLoginB.Visible = False
                        loadPlayerB(userID2)
                        cmdLogInB.Text = "Log Out"
                        'cmdBetB.Visible = True
                        cmdLogInB.Visible = True

                        If Val(selectedGameID) > 0 Then
                            cmdBetB.Visible = True
                            lblBetPointsB.Visible = True
                            txtBetPointsB.Visible = True
                        End If
                    Else
                        MsgBox("Duplication of User Account, please try another account name", MsgBoxStyle.Exclamation, "Unable To Log In")
                    End If
                Else
                    txtPasswordB.Focus()
                    txtPasswordB.Text = ""
                    MsgBox("Password does not match!", MsgBoxStyle.Exclamation, "Password Incorrect")
                End If
            Else
                txtUsernameB.Text = ""
                txtUsernameB.Focus()
                MsgBox("Username does not exist, please try again", MsgBoxStyle.Exclamation, "Username Failure")
            End If
        Else
            MsgBox("Please fill up the required field", MsgBoxStyle.Information, "Required Field")
        End If
    End Sub

    Private Sub cmdCancelBB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelBB.Click
        pnlLoginB.Visible = False
        cmdLogInB.Visible = True
    End Sub

    Private Sub txtUsernameB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsernameB.KeyDown, txtPasswordB.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdLogInBB_Click(cmdLogInBB, Nothing)
        End If
    End Sub

    Private Sub txtUsernameA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsernameA.KeyDown, txtPasswordA.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdLogInAA_Click(cmdLogInAA, Nothing)
        End If
    End Sub

    Private Sub cmdLoadGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadGame.Click
        pnlLoadGame.Width = 671
        utcMain.Tabs(0).Visible = True
        utcMain.Tabs(0).Selected = True
        utcMain.Tabs(1).Visible = False

        Select Case cmdLoadGame.Text
            Case "Load Game"
                pnlLoadGame.Visible = True
                cmdLoadGame.Text = "Cancel"
                txtSearchGames.Text = ""
                reloadPlatforms()
                reloadGames()

            Case "Cancel"
                pnlLoadGame.Visible = False
                cmdLoadGame.Text = "Load Game"

        End Select
    End Sub

    Private Sub cboPlatforms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPlatforms.SelectedIndexChanged
        reloadGames()
    End Sub

    Private Sub txtSearchGames_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchGames.GotFocus
        sender.backcolor = Color.FromArgb(84, 84, 84)
    End Sub

    Private Sub txtSearchGames_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchGames.LostFocus
        sender.backcolor = Color.FromArgb(42, 42, 42)
    End Sub

    Private Sub txtSearchGames_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchGames.TextChanged
        reloadGames()
    End Sub

    Private Sub txtUsernameA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsernameA.GotFocus, txtPasswordA.GotFocus
        sender.backcolor = Color.FromArgb(0, 0, 104)
    End Sub

    Private Sub txtUsernameA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsernameA.LostFocus, txtPasswordA.LostFocus
        sender.backcolor = Color.FromArgb(0, 0, 64)
    End Sub

    Private Sub txtUsernameB_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsernameB.LostFocus, txtPasswordB.LostFocus
        sender.backcolor = Color.FromArgb(64, 0, 0)
    End Sub

    Private Sub txtUsernameB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsernameB.GotFocus, txtPasswordB.GotFocus
        sender.backcolor = Color.FromArgb(104, 0, 0)
    End Sub

    Private Sub My8Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        cmdBattleHistory.Visible = False
        lblSGameName.Text = "Game Name:"
        lblSGenre.Text = "Genre:"
        lblSPlatforms.Text = "Platforms:"
        pcGamesPic.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\no image.jpg")
        selectedGameID = "0"
        lblRankPosition.Text = "Rank"
        lblNameA.Text = "Name:"
        userID1 = ""
        lblAvailablePointsA.Text = "Available Points"
        lblBetPointsA.Visible = False
        txtBetPointsA.Visible = False
        cmdBetA.Visible = False
        pcPicA.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\profile_icon1.jpg")
        pcRankA.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\no image.png")

        lblRankPositionB.Text = "Rank"
        lblNameB.Text = "Name:"
        userID2 = ""
        lblAvailablePointsB.Text = "Available Points"
        lblBetPointsB.Visible = False
        txtBetPointsB.Visible = False
        cmdBetB.Visible = False
        pcPicB.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\profile_icon1.jpg")
        pcRankB.Image = Image.FromFile(Application.StartupPath + "\Images\System\Default\no image.png")
        cmdReset.Visible = False
        cmdSetup.Enabled = False
        cmdLoadGame.Enabled = False

        cmdLogInA.Text = "Log In"
        cmdLogInB.Text = "Log In"

        lblWinB.Text = "0"
        lblLoseB.Text = "0"
        lblDrawB.Text = "0"
        lblWwinA.Text = "0"
        lblLoseA.Text = "0"
        lblDrawA.Text = "0"
    End Sub

    Private Sub cmdBattleHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBattleHistory.Click
        utcMain.Tabs(0).Visible = False
        utcMain.Tabs(1).Visible = True
        cmdLoadGame.Text = "Cancel"
        utcMain.Tabs(1).Selected = True
        pnlLoadGame.Visible = True
        cmdLoadGame.Enabled = True
    End Sub

    Private readyBetA As Decimal = 0

    Private Sub cmd1A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1A.Click, cmd5A.Click, cmd10A.Click, cmd25A.Click, cmd50A.Click, cmd100A.Click, cmdAllA.Click, cmdResetA.Click, cmdReadyA.Click, cmdCancelA.Click
        Select Case CType(sender, Button).Text
            Case "1", "5", "10", "50", "25", "100"
                readyBetA += Val(CType(sender, Button).Text)
                If readyBetA > betPointsA Then
                    readyBetA = betPointsA
                End If
            Case "All"
                readyBetA = betPointsA
            Case "Reset"
                readyBetA = 0
                cmdReadyA.Enabled = True
            Case "Ready"
                If readyBetA > 0 Then
                    txtBetPointsA.Value = readyBetA
                    pnlBetPanelA.Visible = False
                    cmdReadyA.Enabled = False
                End If
            Case "Cancel"
                pnlBetPanelA.Visible = False
        End Select

        lblReadyBetA.Text = FormatNumber(readyBetA, 0)

        If txtBetPointsA.Value > 0 And cmdReadyA.Enabled = False And txtBetPointsB.Value > 0 And cmdReadyB.Enabled = False Then
            cmdSetup.Enabled = True
        Else
            cmdSetup.Enabled = False
        End If

    End Sub

    Private Sub cmdBetA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBetA.Click
        pnlBetPanelA.Visible = True
    End Sub


    Private readyBetB As Decimal = 0

    Private Sub cmdBetB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBetB.Click
        pnlBetPanelB.Visible = True
    End Sub

    Private Sub cmd1B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1B.Click, cmd5B.Click, cmd10B.Click, cmd25B.Click, cmd50B.Click, cmd100B.Click, cmdAllB.Click, cmdResetB.Click, cmdReadyB.Click, cmdCancelB.Click


        Select Case CType(sender, Button).Text
            Case "1", "5", "10", "50", "25", "100"
                readyBetB += Val(CType(sender, Button).Text)
                If readyBetB > betPointsB Then
                    readyBetB = betPointsB
                End If
            Case "All"
                readyBetB = betPointsB
            Case "Reset"
                readyBetB = 0
                cmdReadyB.Enabled = True
            Case "Ready"
                If readyBetB > 0 Then
                    txtBetPointsB.Value = readyBetB
                    pnlBetPanelB.Visible = False
                    cmdReadyB.Enabled = False
                End If
            Case "Cancel"
                pnlBetPanelB.Visible = False
        End Select

        lblReadyBetB.Text = FormatNumber(readyBetB, 0)

        If txtBetPointsA.Value > 0 And cmdReadyA.Enabled = False And txtBetPointsB.Value > 0 And cmdReadyB.Enabled = False Then
            cmdSetup.Enabled = True
        Else
            cmdSetup.Enabled = False
        End If

    End Sub

    Private Sub txtBetPointsB_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBetPointsB.ValueChanged
        If txtBetPointsA.Value > 0 And cmdReadyA.Enabled = False And txtBetPointsB.Value > 0 And cmdReadyB.Enabled = False Then
            cmdSetup.Enabled = True
        Else
            cmdSetup.Enabled = False
        End If
    End Sub

    Private Function loadBin(ByVal gameID As String) As String
        Dim mydata2 As DataTable = mysql.Query("SELECT * FROM tblgamedata where gameID=" + gameid.ToString)
        Return mydata2.Rows(0).Item("gamefile").ToString.Replace("~", "\")
    End Function

    Dim myProcess As Process

    Private Sub disableAllSettings()
        'cmd()
    End Sub

    Private Sub cmdBattleNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBattleNow.Click
        disableAllSettings()
        With mysql
            'If userID = 0 Then
            '    .setTable("tblaccount_activity")
            '    .addValue("start_play", "typeVal")
            '    .addValue(0, "accountID")
            '    .addValue(gameid, "gameID")
            '    .addValue(Now.ToString("yyyy-MM-dd HH:mm:ss"), "dtActivity")
            '    .Insert()
            'Else
            '    Dim mydata As DataTable = mysql.Query("SELECT count(*) from tblaccount_activity where accountID=" + userID.ToString + " and gameID=" + gameid.ToString + " and typeVal='start_play' and dtActivity between '" + Now.ToString("yyyy-MM-dd") + " 00:00:00' and '" + Now.ToString("yyyy-MM-dd") + " 23:59:59'")
            '    If mydata.Rows.Count > 0 Then
            '        If mydata.Rows(0).Item(0) <= 5 Then
            '            Dim mydata2 As DataTable = mysql.Query("SELECT count(*) from tblaccount_activity where accountID=" + userID.ToString + " and typeVal='start_play' and dtActivity between '" + Now.ToString("yyyy-MM-dd") + " 00:00:00' and '" + Now.ToString("yyyy-MM-dd") + " 23:59:59'")
            '            If mydata2.Rows.Count > 0 Then
            '                If mydata2.Rows(0).Item(0) <= 15 Then
            '                    .setTable("tblaccount_activity")
            '                    .addValue("start_play", "typeVal")
            '                    .addValue(userID, "accountID")
            '                    .addValue(gameid, "gameID")
            '                    .addValue(Now.ToString("yyyy-MM-dd HH:mm:ss"), "dtActivity")
            '                    .Insert()
            '                End If
            '            End If
            '        End If
            '    End If
            'End If


        End With

        Dim mydatax As DataTable = mysql.Query("SELECT * from tblgamedata where gameID=" + selectedGameID.ToString)
        Dim cboEmulator As String
        If mydatax.Rows.Count > 0 Then
            Dim data() As String = mydatax.Rows(0).Item("emulator").ToString.Split(";")
            cboEmulator = data(0)
        End If


        Select Case cboEmulator
            Case "PSX", "EPSXE"

                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = 'PSX'")
                If mydata.Rows.Count > 0 Then
                    Try
                        Dim SW As New System.IO.StreamWriter("loadGame.bat")
                        With SW
                            Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """  """ + loadBin(selectedGameID) + """"
                            .WriteLine(str)
                            .Flush()
                            .Close()
                            .Dispose()
                            SW = Nothing
                        End With
                        'System.Diagnostics.Process.Start("loadGame.bat")


                        myProcess = New Process                         '~~~ Creating the object
                        myProcess.StartInfo.FileName = "loadGame.bat"    '~~~ We are going to start notepad.
                        myProcess.StartInfo.CreateNoWindow = True
                        myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        myProcess.Start()
                        '~~~ Start it

                        myProcess.EnableRaisingEvents = True            '~~~ Need to be TRUE, inorder to notify us when the process is closed by the user in some other means (like Alt + F4)
                        'AddHandler myProcess.Exited, AddressOf ProcessExited

                        'timeBegin = Now


                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If

            Case "PCSX2"


                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator + "'")
                If mydata.Rows.Count > 0 Then
                    Try

                        Dim SW As New System.IO.StreamWriter("loadGame.bat")
                        With SW
                            Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """  """ + loadBin(selectedGameID) + """  --fullboot"
                            .WriteLine(str)
                            .Flush()
                            .Close()
                            .Dispose()
                            SW = Nothing
                        End With
                        'System.Diagnostics.Process.Start("loadGame.bat")


                        myProcess = New Process                         '~~~ Creating the object
                        myProcess.StartInfo.FileName = "loadGame.bat"    '~~~ We are going to start notepad.
                        myProcess.StartInfo.CreateNoWindow = True
                        myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        myProcess.Start()
                        '~~~ Start it

                        myProcess.EnableRaisingEvents = True            '~~~ Need to be TRUE, inorder to notify us when the process is closed by the user in some other means (like Alt + F4)
                        'AddHandler myProcess.Exited, AddressOf ProcessExited

                        'timeBegin = Now


                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "ZSNES"


                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator + "'")
                If mydata.Rows.Count > 0 Then
                    Try


                        Dim SW As New System.IO.StreamWriter("loadGame.bat")
                        With SW
                            Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """  """ + loadBin(selectedGameID) + """ -m "
                            .WriteLine(str)
                            .Flush()
                            .Close()
                            .Dispose()
                            SW = Nothing
                        End With
                        'System.Diagnostics.Process.Start("loadGame.bat")


                        myProcess = New Process                         '~~~ Creating the object
                        myProcess.StartInfo.FileName = "loadGame.bat"    '~~~ We are going to start notepad.
                        myProcess.StartInfo.CreateNoWindow = True
                        myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        myProcess.Start()
                        '~~~ Start it

                        myProcess.EnableRaisingEvents = True            '~~~ Need to be TRUE, inorder to notify us when the process is closed by the user in some other means (like Alt + F4)
                        'AddHandler myProcess.Exited, AddressOf ProcessExited

                        'timeBegin = Now


                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "Project64"


                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator + "'")
                If mydata.Rows.Count > 0 Then
                    Try
                        Dim SW As New System.IO.StreamWriter("loadGame.bat")
                        With SW
                            Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """ """ + loadBin(selectedGameID) + """"
                            .WriteLine(str)
                            .Flush()
                            .Close()
                            .Dispose()
                            SW = Nothing
                        End With

                        myProcess = New Process                         '~~~ Creating the object
                        myProcess.StartInfo.FileName = "loadGame.bat"    '~~~ We are going to start notepad.
                        myProcess.StartInfo.CreateNoWindow = True
                        myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        myProcess.Start()
                        '~~~ Start it

                        myProcess.EnableRaisingEvents = True            '~~~ Need to be TRUE, inorder to notify us when the process is closed by the user in some other means (like Alt + F4)
                        'timeBegin = Now

                        'AddHandler myProcess.Exited, AddressOf ProcessExited
                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "SEGA"


                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator + "'")
                If mydata.Rows.Count > 0 Then
                    Try
                        Dim SW As New System.IO.StreamWriter("loadGame.bat")
                        With SW
                            Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """ """ + loadBin(selectedGameID) + """"
                            .WriteLine(str)
                            .Flush()
                            .Close()
                            .Dispose()
                            SW = Nothing
                        End With

                        myProcess = New Process                         '~~~ Creating the object
                        myProcess.StartInfo.FileName = "loadGame.bat"    '~~~ We are going to start notepad.
                        myProcess.StartInfo.CreateNoWindow = True
                        myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        myProcess.Start()
                        '~~~ Start it

                        Dim localByName As Process() = Process.GetProcessesByName("loadGame.bat")
                        For Each p As Process In localByName
                            'ShowWindow(p.MainWindowHandle, 3) ' SW_MAXIMIZE
                        Next

                        myProcess.EnableRaisingEvents = True            '~~~ Need to be TRUE, inorder to notify us when the process is closed by the user in some other means (like Alt + F4)
                        '[timeBegin = Now

                        'AddHandler myProcess.Exited, AddressOf ProcessExited
                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "PC"
                Try
                    Dim SW As New System.IO.StreamWriter("loadGame.bat")
                    With SW
                        Dim str As String = loadBin(selectedGameID)
                        .WriteLine(str)
                        .Flush()
                        .Close()
                        .Dispose()
                        SW = Nothing
                    End With

                    myProcess = New Process                         '~~~ Creating the object
                    myProcess.StartInfo.FileName = "loadGame.bat"    '~~~ We are going to start notepad.
                    myProcess.StartInfo.CreateNoWindow = True
                    myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    'myProcess.Start(loadBin())
                    '~~~ Start it

                    Dim localByName As Process() = Process.GetProcessesByName("loadGame.bat")
                    For Each p As Process In localByName
                        'ShowWindow(p.MainWindowHandle, 3) ' SW_MAXIMIZE
                    Next

                    myProcess.EnableRaisingEvents = True            '~~~ Need to be TRUE, inorder to notify us when the process is closed by the user in some other means (like Alt + F4)
                    'timeBegin = Now

                    'AddHandler myProcess.Exited, AddressOf ProcessExited
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                End Try

        End Select


    End Sub

    Private Sub cmdSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetup.Click
        pnlSetup.Visible = True
        pnlSetup.Height = 454

        lblWinA.Text = "0"
        lblWB.Text = "0"

        cmdSetupCancel.Enabled = True
        'player a

        pcA.Image = pcPicA.Image
        pcB.Image = pcPicB.Image

        lblNameAA.Text = lblNameA.Text
        lblNameBB.Text = lblNameB.Text

        pcRA.Image = pcRankA.Image
        pcRB.Image = pcRankB.Image

        lblBetAA.Text = txtBetPointsA.Value
        lblBetBB.Text = txtBetPointsB.Value

        cmdSetupCancel.Text = "Cancel"
        lblNoticeA.Visible = False
        lblNoticeB.Visible = False
    End Sub


    Private Sub updateTheWinner(ByVal theWinner As String)
       

        If theWinner = "A" Then
            With mysql
                .setTable("tblaccount_battle")
                .addValue(.nextID("battleID"), "battleID")
                .addValue(selectedGameID, "gameID")
                .addValue(userID1.ToString, "accountID_A")
                .addValue(lblWinA.Text, "points_A")
                .addValue("win", "status_A")
                .addValue(lblBetAA.Text, "bet_entry_A")
                .addValue(lblBetBB.Text, "bet_win_A")

                .addValue(userID2.ToString, "accountID_B")
                .addValue(lblWB.Text, "points_B")
                .addValue("lose", "status_B")
                .addValue(lblBetBB.Text, "bet_entry_B")
                .addValue(lblBetBB.Text, "bet_lose_B")
                .addValue(Now.ToString("yyyy-MM-dd HH:mm:ss"), "dtBattle")
                .Insert()
            End With
            Dim col() As String = lblNameBB.Text.ToString.Split(":")
            Dim gm() As String = lblSGameName.Text.ToString.Split(":")
            Dim gn() As String = lblSGenre.Text.ToString.Split(":")
            newsFeedCreator(userID1, col(1), gm(1), gn(1), lblBetBB.Text, "win")
            Dim col2() = lblNameAA.Text.ToString.Split(":")
            newsFeedCreator(userID2, col2(1), gm(1), gn(1), lblBetBB.Text, "lose")
        ElseIf theWinner = "B" Then
            With mysql
                .setTable("tblaccount_battle")
                .addValue(.nextID("battleID"), "battleID")
                .addValue(userID1.ToString, "accountID_A")
                .addValue(lblWinA.Text, "points_A")
                .addValue("lose", "status_A")
                .addValue(lblBetAA.Text, "bet_entry_A")
                .addValue(lblBetAA.Text, "bet_lose_A")


                .addValue(userID2.ToString, "accountID_B")
                .addValue(lblWB.Text, "points_B")
                .addValue("win", "status_B")
                .addValue(lblBetBB.Text, "bet_entry_B")
                .addValue(lblBetAA.Text, "bet_win_B")
                .addValue(Now.ToString("yyyy-MM-dd HH:mm:ss"), "dtBattle")
                .Insert()
            End With
            Dim col() As String = lblNameBB.Text.ToString.Split(":")
            Dim gm() As String = lblSGameName.Text.ToString.Split(":")
            Dim gn() As String = lblSGenre.Text.ToString.Split(":")

            newsFeedCreator(userID1, col(1), gm(1), gn(1), lblBetAA.Text, "lose")
            Dim col2() = lblNameAA.Text.ToString.Split(":")
            newsFeedCreator(userID2, col2(1), gm(1), gn(1), lblBetAA.Text, "win")
        Else
            With mysql
                .setTable("tblaccount_battle")
                .addValue(.nextID("battleID"), "battleID")
                .addValue(userID1.ToString, "accountID_A")
                .addValue(lblWinA.Text, "points_A")
                .addValue("draw", "status_A")
                .addValue(lblBetAA.Text, "bet_entry_A")

                .addValue(userID2.ToString, "accountID_B")
                .addValue(lblWB.Text, "points_B")
                .addValue("draw", "status_B")
                .addValue(lblWB.Text, "bet_entry_B")
            End With
        End If

    End Sub

    Private Sub newsFeedCreator(ByVal accountID As String, ByVal opponent As String, ByVal gamename As String, ByVal genre As String, ByVal bet As String, ByVal sector As String)
        'newsfeed
        With mysql
            .setTable("tblaccount_newsfeed")
            .addValue(.nextID("newsFeedID"), "newsFeedID")
            .addValue(accountID, "accountID")
            .addValue("battle", "type")
            If sector = "win" Then
                .addValue("Victory", "name")
                .addValue("~ has won in " + genre + " against with the player name of " + opponent + " from the game of " + gamename + ". And he/she won the bet of " + bet + " points.", "description")
            ElseIf sector = "lose" Then
                .addValue("Lose", "name")
                .addValue("~ has defeated in " + genre + " against with the player name of " + opponent + " from the game of " + gamename + ". And he/she lose the bet of " + bet + " points.", "description")
            End If
            .addValue(Now.ToString("yyyy-MM-dd H:m:s"), "dateUpdate")
            .Insert()
        End With
    End Sub

    Private Sub cmdSetupCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetupCancel.Click
        Select Case CType(sender, Button).Text
            Case "Done"


                lblWwinA.Text = getWinLoseStatus(userID1, "win")
                lblLoseA.Text = getWinLoseStatus(userID1, "lose")
                lblDrawA.Text = getWinLoseStatus(userID1, "draw")

                lblWinB.Text = getWinLoseStatus(userID2, "win")
                lblLoseB.Text = getWinLoseStatus(userID2, "lose")
                lblDrawB.Text = getWinLoseStatus(userID2, "draw")


                Me.ControlBox = True
                cboWinningEntry.SelectedIndex = -1
                pnlSetup.Visible = False
                cmdPlusA.Enabled = False
                cmdMinusA.Enabled = False
                cmdPlusB.Enabled = False
                cboWinningEntry.Enabled = True
                cmdMinusB.Enabled = False
                cmdBattleNow.Enabled = False
                cmdFinalize.Enabled = False
                Timer1.Stop()
                counter = 0
                txtBetPointsA.Value = 0
                txtBetPointsB.Value = 0
                cmdReadyA.Enabled = True
                cmdReadyB.Enabled = True
                lblReadyBetA.Text = "0"
                lblReadyBetB.Text = "0"
                readyBetA = 0
                readyBetB = 0
                Me.Cursor = Cursors.WaitCursor
                loadPlayerA(userID1)
                loadPlayerB(userID2)
                Me.Cursor = Cursors.Default

            Case "Cancel"
                pnlSetup.Visible = False
                cboWinningEntry.SelectedIndex = -1
        End Select
   
    End Sub

    Private Sub whoIsTheWinner()


        If Val(lblWinA.Text) > Val(lblWB.Text) Then
            lblNoticeA.Text = "WINNER"
            lblNoticeA.BackColor = Color.Green
            lblNoticeB.Text = "LOSER"
            lblNoticeB.BackColor = Color.Red
            updateTheWinner("A")
        ElseIf Val(lblWB.Text) > Val(lblWinA.Text) Then
            lblNoticeB.Text = "WINNER"
            lblNoticeB.BackColor = Color.Green
            lblNoticeA.Text = "LOSER"
            lblNoticeA.BackColor = Color.Red
            updateTheWinner("B")
        Else
            lblNoticeB.Text = "DRAW"
            lblNoticeB.BackColor = Color.Blue
            lblNoticeA.Text = "DRAW"
            lblNoticeA.BackColor = Color.Blue
            updateTheWinner("both")
        End If

        lblNoticeA.Visible = True
        lblNoticeB.Visible = True

        MsgBox("Battle Over!", MsgBoxStyle.Information, "Battle Mode")

        cmdSetupCancel.Text = "Done"
        cmdSetupCancel.Enabled = True



    End Sub


    Private Sub cmdPlusA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlusA.Click, cmdMinusA.Click
        Timer1.Start()
        counter = 0
        Select Case CType(sender, Button).Name
            Case "cmdPlusA"
                lblWinA.Text = Val(lblWinA.Text) + 1
            Case "cmdMinusA"
                lblWinA.Text = Val(lblWinA.Text) - 1
        End Select

        If Val(lblWinA.Text) >= Val(cboWinningEntry.Text) Then
            whoIsTheWinner()
        End If
    End Sub

    Private Sub cmdPlusB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlusB.Click, cmdMinusB.Click
        Timer1.Start()
        counter = 0
        Select Case CType(sender, Button).Name
            Case "cmdPlusB"
                lblWB.Text = Val(lblWB.Text) + 1
            Case "cmdMinusB"
                lblWB.Text = Val(lblWB.Text) - 1
        End Select

        If Val(lblWB.Text) >= Val(cboWinningEntry.Text) Then
            whoIsTheWinner()
        End If
    End Sub

    Private Sub cmdFinalize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinalize.Click
        cboWinningEntry.Enabled = False
        cmdSetupCancel.Enabled = False
        cmdPlusA.Enabled = True
        cmdMinusA.Enabled = True
        cmdPlusB.Enabled = True
        cmdMinusB.Enabled = True
        cmdBattleNow.Enabled = True
        cmdFinalize.Enabled = False
        Me.ControlBox = False
        counter = 1
        Timer1.Start()
    End Sub

    Private Sub cboWinningEntry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWinningEntry.SelectedIndexChanged
        If cboWinningEntry.SelectedIndex <> -1 Then
            cmdFinalize.Enabled = True
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("This application provides the battle mode between two players, they can bet to win or lose.", MsgBoxStyle.Information, "Programmed and Developed by: Sylvster R. Belonio")
    End Sub
End Class
