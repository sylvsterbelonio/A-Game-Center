Imports System.IO
Imports System.Windows.Forms
Imports System.IO.Stream
Imports PowerNET8.myNumber
Imports System.Threading

Public Class lblDesigners
    Public gameid As String
    Private irgsMutex As Mutex
    Dim mysql As New PowerNET8.mySQL.Init.SQL
    Dim col(6) As String
    Dim frm As New frmShadow
    Dim discNum As Integer = 1

    Private Function getNoPlayed()
        Dim mydata As DataTable = mysql.Query("SELECT count(*) from tblaccount_activity where accountID=" + userID.ToString + " and gameID=" + gameid.ToString + " and typeVal='start_play'")
        If mydata.Rows.Count > 0 Then
            Return mydata.Rows(0).Item(0)
        End If
    End Function


    Private Sub reloadData()

        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblgamedata where gameID=" + gameid)
        If mydata.Rows.Count > 0 Then
            lblTitle.Text = mydata.Rows(0).Item("gameName")
            lblDescription.Text = mydata.Rows(0).Item("gameDesc")
            lblDesc.Text = mydata.Rows(0).Item("designer")
            lblDevelopers.Text = mydata.Rows(0).Item("developer")
            lblComposers.Text = mydata.Rows(0).Item("composers")
            lblPublishers.Text = mydata.Rows(0).Item("publishers")
            lblCountry.Text = mydata.Rows(0).Item("country")

            'Check if there is more than a disc to play

            If Trim(mydata.Rows(0).Item("cd2").ToString) <> "" Then discNum += 1
            If Trim(mydata.Rows(0).Item("cd3").ToString) <> "" Then discNum += 1
            If Trim(mydata.Rows(0).Item("cd4").ToString) <> "" Then discNum += 1
            If discNum > 1 Then
                lblDisk.Visible = True
                cboDisk.Visible = True
                cboDisk.Items.Clear()
                For i As Integer = 1 To discNum
                    cboDisk.Items.Add("Disk " + i.ToString)
                Next
                cboDisk.SelectedIndex = 0
            End If

            Dim col() As String = mydata.Rows(0).Item("emulator").ToString.Split(";")
            cboEmulator.Items.Clear()
            If col.Length > 1 Then
                For i As Integer = 0 To col.Length - 1
                    cboEmulator.Items.Add(col(i))
                Next
            Else
                cboEmulator.Items.Add(col(0))
            End If
            If cboEmulator.Items.Count > 0 Then cboEmulator.SelectedIndex = 0

            cboEmulator.Text = mydata.Rows(0).Item("lastSelectedEmu")

            'lblEmulator.Text = mydata.Rows(0).Item("emulator")
            lblPlatforms.Text = mydata.Rows(0).Item("platforms")
            lblNoOPlayer.Text = mydata.Rows(0).Item("Player")
            lblPlayedTimes.Text = FormatNumber(getNoPlayed, 0)
            lblGameType.Text = mydata.Rows(0).Item("gameType")
            lblYearEstablished.Text = mydata.Rows(0).Item("initialReleasedDate")

        End If

        mydata = mysql.Query("SELECT * FROM tblgamedata_imageloc where gameID=" + gameid)
        If mydata.Rows.Count > 0 Then
            col(0) = mydata.Rows(0).Item("coverPhoto").ToString.Replace("~", "\")
            col(1) = mydata.Rows(0).Item("backcoverPhoto").ToString.Replace("~", "\")
            col(2) = mydata.Rows(0).Item("sc2").ToString.Replace("~", "\")
            col(3) = mydata.Rows(0).Item("sc3").ToString.Replace("~", "\")
            col(4) = mydata.Rows(0).Item("sc4").ToString.Replace("~", "\")
            col(5) = mydata.Rows(0).Item("sc5").ToString.Replace("~", "\")

            pbMain.ImageLocation = col(0)
            pb1.Focus()
            pb1.BackgroundImage = Image.FromFile(col(0))
            pb2.BackgroundImage = Image.FromFile(col(1))
            pb3.BackgroundImage = Image.FromFile(col(2))
            pb4.BackgroundImage = Image.FromFile(col(3))
            pb5.BackgroundImage = Image.FromFile(col(4))
            pb6.BackgroundImage = Image.FromFile(col(5))
        End If
    End Sub


    Private Sub frmPlayStationViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        Timer1.Start()
        reloadData()
        FavoriteStat()
        topPlayer()
    End Sub


    Private Sub topPlayer()
        Dim mydata As DataTable = mysql.Query("SELECT gameID, picture, tblaccount_activity.accountID,tblaccount.firstname, typeVal, timePlayed, sum(pts_timePlayed + points) as 'TotalPoints' FROM  tblaccount INNER JOIN  tblaccount_activity    ON (tblaccount.accountID = tblaccount_activity.accountID)   INNER JOIN  tblaccount_activity_points_ref   ON (tblaccount_activity_points_ref.name = tblaccount_activity.typeVal) where gameID=" + gameid.ToString + " and tblaccount_activity.accountID>0 group by tblaccount_activity.accountID  order by TotalPoints desc")
        flpTopGamer.Controls.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            If Not IsDBNull(mydata.Rows(i).Item("picture")) Then
                createBox(flpTopGamer, mydata.Rows(i).Item("picture"), mydata.Rows(i).Item("firstname"), (mydata.Rows(i).Item("TotalPoints") - 0.01), i + 1)
            Else
                createBox(flpTopGamer, Nothing, mydata.Rows(i).Item("firstname"), CDbl(mydata.Rows(i).Item("TotalPoints") - 0.01), (i + 1).ToString)
            End If
       Next
    End Sub

    Private Sub createBox(ByRef flp As FlowLayoutPanel, ByVal imageLoc As String, ByVal name As String, ByVal points As Decimal, ByVal position As String)
        Dim pnlBody As New Panel
        With pnlBody
            .Width = 121
            .Height = 48
            .BackColor = Color.Transparent
            .ForeColor = Color.White
        End With
        flp.Controls.Add(pnlBody)

        Dim pcPicture As New PictureBox
        With pcPicture
            .Width = 42
            .Height = 42
            .Top = 3
            .Left = 3
            .SizeMode = PictureBoxSizeMode.Zoom
            Try
                .Image = Image.FromFile(Application.StartupPath + "\" + imageLoc.ToString.Replace("~", "\"))
            Catch ex As Exception
                .Image = My.Resources.profile_icon1
            End Try
            pnlBody.Controls.Add(pcPicture)
        End With

        Dim lblName As New Label
        With lblName
            .Top = 4
            .Left = 52
            .Height = 13
            .Text = name
            pnlBody.Controls.Add(lblName)
        End With

        Dim lblPoints As New Label
        With lblPoints
            .Top = 18
            Dim oldFont As Font = New Font(.Font.FontFamily, 7.25, FontStyle.Italic, .Font.Unit)
            .Font = oldFont
            .Left = 52
            pnlBody.Controls.Add(lblPoints)
            .Height = 13
            .Text = FormatNumber(points, 2) + " pts."
            pnlBody.Controls.Add(lblPoints)
        End With

        Dim lblPosition As New Label
        With lblPosition
            .Left = 52
            .Top = 33
            .Height = 13
            .Text = "#" + position
            pnlBody.Controls.Add(lblPosition)
        End With
    End Sub


    Private Sub FavoriteStat()
        'VIEW FAVORITE BUTTON when SIGN IN
        If userID > 0 Then
            cmdFavorite.Visible = True
            Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount_favorite_games where gameID=" + gameid.ToString + " and accountID=" + userID.ToString)
            If mydata.Rows.Count > 0 Then
                With cmdFavorite
                    Me.BackColor = Color.FromArgb(128, 64, 0)
                    flpTopGamer.BackColor = Color.FromArgb(108, 44, 0)
                    .Width = 120
                    .Standard_ThemeColor = PowerNET8.myColor.Share.SystemColor.BackgroundColor.StandardColor.DColors.Red
                    .JqueryIconTypes = PowerNET8.myIcons.Share.Jquery.JqueryIconTypes.close
                    .Text = "Remove Favorite"
                End With
            Else
                With cmdFavorite
                    .Width = 97
                    .JqueryIconTypes = PowerNET8.myIcons.Share.Jquery.JqueryIconTypes.star
                    .Standard_ThemeColor = PowerNET8.myColor.Share.SystemColor.BackgroundColor.StandardColor.DColors.Orange
                    Me.BackColor = Color.FromArgb(21, 21, 21)
                    flpTopGamer.BackColor = Color.FromArgb(42, 42, 42)
                    .Text = "Add Favorite"
                End With
            End If
        End If
    End Sub

    Dim start As Integer = 0
    Dim selectIndex As Integer = 1
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        start += 1
        If start = 3 Then
            pbMain.ImageLocation = col(selectIndex)
            setButton(selectIndex)
            selectIndex += 1
            If selectIndex >= 6 Then
                selectIndex = 0
            End If
            start = 0
        End If
    End Sub

    Private Sub setButton(ByVal index As Integer)
        Select Case index
            Case 0
                pb1.Focus()
            Case 1
                pb2.Focus()
            Case 2
                pb3.Focus()
            Case 3
                pb4.Focus()
            Case 4
                pb5.Focus()
            Case 5
                pb6.Focus()
        End Select
    End Sub

    Private Sub pb1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb1.Click, pb2.Click, pb3.Click, pb4.Click, pb5.Click, pb6.Click
        Select Case CType(sender, Button).Name
            Case "pb1"
                pbMain.ImageLocation = col(0)
            Case "pb2"
                pbMain.ImageLocation = col(1)
            Case "pb3"
                pbMain.ImageLocation = col(2)
            Case "pb4"
                pbMain.ImageLocation = col(3)
            Case "pb5"
                pbMain.ImageLocation = col(4)
            Case "pb6"
                pbMain.ImageLocation = col(5)
        End Select
        Timer1.Stop()
    End Sub

    Private Function loadBin() As String
        Dim mydata2 As DataTable = mysql.Query("SELECT * FROM tblgamedata where gameID=" + gameid.ToString)
        If discNum = 1 Then
            Return mydata2.Rows(0).Item("gamefile").ToString.Replace("~", "\")
        Else
            Select Case cboDisk.Text
                Case "Disk 1"
                    Return mydata2.Rows(0).Item("gamefile").ToString.Replace("~", "\")
                Case "Disk 2"
                    Return mydata2.Rows(0).Item("cd2").ToString.Replace("~", "\")
                Case "Disk 3"
                    Return mydata2.Rows(0).Item("cd3").ToString.Replace("~", "\")
                Case "Disk 4"
                    Return mydata2.Rows(0).Item("cd4").ToString.Replace("~", "\")
            End Select
        End If
        Return ""
    End Function

    Private Function loadMemoryCard() As String
        Dim mydata2 As DataTable = mysql.Query("SELECT * FROM tblgamedata where gameID=" + gameid.ToString)
        If Trim(mydata2.Rows(0).Item("memoryCard")) <> "" Then
            Return " -loadmemc0 """ + mydata2.Rows(0).Item("memoryCard").ToString.Replace("~", "\") + """"
        Else
            Return ""
        End If
    End Function

    Dim myProcess As Process
    '~~~ This is the sub which will be called when the Process is closed. Whatever we want to do (when the process is closed), has to be included in this sub
    Private Sub ProcessExited(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim difftime As TimeSpan = myProcess.ExitTime - timeBegin
        Dim totalSec As Decimal = difftime.TotalSeconds

        For Each prog As Process In Process.GetProcesses
            If prog.ProcessName = "pcsx2.exe" Then
                prog.Kill()
            End If
        Next

        Dim mydata As DataTable = mysql.Query("SELECT points FROM tblaccount_activity_points_ref where name='playing'")
        Dim refPoints As Decimal = CDbl(mydata.Rows(0).Item(0))

        Dim totalPoints As Decimal = totalSec * refPoints
        'MsgBox("Game close")
        'MessageBox.Show("Hey dude, you were using this program for XX minutes ! Oh man !!! You are so addicted to this program...! You closed the program at: " & myProcess.ExitTime)
        If userID > 0 Then
            With mysql
                .setTable("tblaccount_activity")
                .addValue(userID, "accountID")
                .addValue(gameid, "gameID")
                .addValue("playing", "typeVal")
                'MsgBox(difftime.ToString.Substring(0, 8))
                .addValue(difftime.ToString.Substring(0, 8), "timePlayed")
                .addValue(totalPoints, "pts_timePlayed")
                .addValue(Now.ToString("yyyy-MM-dd HH:mm:ss"), "dtActivity")
                .Insert()
            End With
        End If
        myProcess.Close()   '~~~ Freeup the object
    End Sub

    Private Declare Function ShowWindow Lib "user32" (ByVal handle As IntPtr, ByVal nCmdShow As Integer) As Integer
    Private Declare Function SetForegroundWindow Lib "user32" (ByVal handle As IntPtr) As Integer
    Private timeBegin As DateTime

    Private blnReminder As Boolean = False

    Private Sub pbPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbPlay.Click
        pbPlay.Enabled = False
        With mysql
            If userID = 0 Then
                .setTable("tblaccount_activity")
                .addValue("start_play", "typeVal")
                .addValue(0, "accountID")
                .addValue(gameid, "gameID")
                .addValue(Now.ToString("yyyy-MM-dd HH:mm:ss"), "dtActivity")
                .Insert()
            Else
                Dim mydata As DataTable = mysql.Query("SELECT count(*) from tblaccount_activity where accountID=" + userID.ToString + " and gameID=" + gameid.ToString + " and typeVal='start_play' and dtActivity between '" + Now.ToString("yyyy-MM-dd") + " 00:00:00' and '" + Now.ToString("yyyy-MM-dd") + " 23:59:59'")
                If mydata.Rows.Count > 0 Then
                    If mydata.Rows(0).Item(0) <= 5 Then
                        Dim mydata2 As DataTable = mysql.Query("SELECT count(*) from tblaccount_activity where accountID=" + userID.ToString + " and typeVal='start_play' and dtActivity between '" + Now.ToString("yyyy-MM-dd") + " 00:00:00' and '" + Now.ToString("yyyy-MM-dd") + " 23:59:59'")
                        If mydata2.Rows.Count > 0 Then
                            If CDbl(mydata2.Rows(0).Item(0)) <= 15 Then
                                .setTable("tblaccount_activity")
                                .addValue("start_play", "typeVal")
                                .addValue(userID, "accountID")
                                .addValue(gameid, "gameID")
                                .addValue(Now.ToString("yyyy-MM-dd HH:mm:ss"), "dtActivity")
                                .Insert()
                            End If
                        End If
                    End If
                End If
            End If


        End With


        Select Case cboEmulator.Text
            Case "PSX"

                If RemindersPSX = False Then
                    MsgBox("Press [ESC] to quit the Video Game. ", MsgBoxStyle.Information, "Importatn Reminders")
                    RemindersPSX = True
                End If

                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator.Text + "'")
                If mydata.Rows.Count > 0 Then
                    Try
                        Dim SW As New System.IO.StreamWriter("loadGame.bat")
                        Dim binChecker As String = loadBin()
                        If binChecker <> "" Then
                            With SW
                                Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """ -f """ + binChecker + """"
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
                            AddHandler myProcess.Exited, AddressOf ProcessExited

                            timeBegin = Now

                        Else
                            MsgBox("No Game File Found, please contact the administrator for assistance.", MsgBoxStyle.Information, "No Game File Found")
                        End If
                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "EPSXE"

                If RemindersEPSXE = False Then
                    MsgBox("Press [ESC] to quit the Video Game. ", MsgBoxStyle.Information, "Important Reminders")
                    RemindersEPSXE = True
                End If

                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator.Text + "'")
                If mydata.Rows.Count > 0 Then
                    Try
                        Dim SW As New System.IO.StreamWriter("loadGame.bat")
                        Dim binChecker As String = loadBin()
                        If binChecker <> "" Then


                            With SW
                                Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """ -nogui -slowboot -bios """ + getBIOS(lblCountry.Text) + """ " + loadMemoryCard() + " -loadbin """ + binChecker + """"
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
                            timeBegin = Now

                            AddHandler myProcess.Exited, AddressOf ProcessExited

                        Else
                            MsgBox("No Game File Found, please contact the administrator for assistance.", MsgBoxStyle.Information, "No Game File Found")
                        End If

                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "PCSX2"

                If RemindersPSX = False Then
                    MsgBox("Press [ESC] to quit the Video Game. ", MsgBoxStyle.Information, "Importatn Reminders")
                    RemindersPSX = True
                End If

                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator.Text + "'")
                If mydata.Rows.Count > 0 Then
                    Try


                        Dim SW As New System.IO.StreamWriter("loadGame.bat")
                        Dim binChecker As String = loadBin()
                        If binChecker <> "" Then


                            With SW
                                Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """  """ + binChecker + """ --fullscreen --fullboot"
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
                            AddHandler myProcess.Exited, AddressOf ProcessExited

                            timeBegin = Now


                        Else
                            MsgBox("No Game File Found, please contact the administrator for assistance.", MsgBoxStyle.Information, "No Game File Found")
                        End If

                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "ZSNES"
                If RemindersPSX = False Then
                    MsgBox("Press [ESC] to quit the Video Game. ", MsgBoxStyle.Information, "Important Reminders")
                    RemindersPSX = True
                End If

                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator.Text + "'")
                If mydata.Rows.Count > 0 Then
                    Try


                        Dim SW As New System.IO.StreamWriter("loadGame.bat")

                        Dim binChecker As String = loadBin()
                        If binChecker <> "" Then
                            With SW
                                Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """  """ + binChecker + """ -m "
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
                            AddHandler myProcess.Exited, AddressOf ProcessExited

                            timeBegin = Now

                        Else
                            MsgBox("No Game File Found, please contact the administrator for assistance.", MsgBoxStyle.Information, "No Game File Found")
                        End If
                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "Project64"

                If RemindersProject64 = False Then
                    MsgBox("Press [ALT + ENTER] to fullscreen/minimize the Video Game. ", MsgBoxStyle.Information, "FullScreen/Minimize")
                    RemindersProject64 = True
                End If

                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator.Text + "'")
                If mydata.Rows.Count > 0 Then
                    Try
                        Dim SW As New System.IO.StreamWriter("loadGame.bat")
                        Dim binChecker As String = loadBin()
                        If binChecker <> "" Then


                            With SW
                                Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """ """ + binChecker + """"
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
                            timeBegin = Now

                            AddHandler myProcess.Exited, AddressOf ProcessExited

                        Else
                            MsgBox("No Game File Found, please contact the administrator for assistance.", MsgBoxStyle.Information, "No Game File Found")
                        End If
                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "SEGA"

                If RemindersSega = False Then
                    MsgBox("Press [ALT + ENTER] to fullscreen/minimize the Video Game. ", MsgBoxStyle.Information, "FullScreen/Minimize")
                    RemindersSega = True
                End If

                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator.Text + "'")
                If mydata.Rows.Count > 0 Then
                    Try
                        Dim SW As New System.IO.StreamWriter("loadGame.bat")

                        Dim binChecker As String = loadBin()
                        If binChecker <> "" Then


                            With SW
                                Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """ """ + binChecker + """"
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
                                ShowWindow(p.MainWindowHandle, 3) ' SW_MAXIMIZE
                            Next

                            myProcess.EnableRaisingEvents = True            '~~~ Need to be TRUE, inorder to notify us when the process is closed by the user in some other means (like Alt + F4)
                            timeBegin = Now

                            AddHandler myProcess.Exited, AddressOf ProcessExited
                        Else
                            MsgBox("No Game File Found, please contact the administrator for assistance.", MsgBoxStyle.Information, "No Game File Found")
                        End If
                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "Fusion"
                If RemindersSega = False Then
                    MsgBox("Press [ALT + ENTER] to fullscreen/minimize the Video Game. ", MsgBoxStyle.Information, "FullScreen/Minimize")
                    RemindersSega = True
                End If

                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator.Text + "'")
                If mydata.Rows.Count > 0 Then
                    Try
                        Dim SW As New System.IO.StreamWriter("loadGame.bat")

                        Dim binChecker As String = loadBin()
                        If binChecker <> "" Then


                            With SW
                                Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """ """ + binChecker + """ -fullscreen"
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
                                ShowWindow(p.MainWindowHandle, 3) ' SW_MAXIMIZE
                            Next

                            myProcess.EnableRaisingEvents = True            '~~~ Need to be TRUE, inorder to notify us when the process is closed by the user in some other means (like Alt + F4)
                            timeBegin = Now

                            AddHandler myProcess.Exited, AddressOf ProcessExited
                        Else
                            MsgBox("No Game File Found, please contact the administrator for assistance.", MsgBoxStyle.Information, "No Game File Found")
                        End If
                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "PC"
                Try
                    Dim SW As New System.IO.StreamWriter("loadGame.bat")

                    Dim binChecker As String = loadBin()
                    If binChecker <> "" Then


                        With SW
                            Dim str As String = loadBin()
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
                        myProcess.Start(binChecker)
                        '~~~ Start it

                        Dim localByName As Process() = Process.GetProcessesByName("loadGame.bat")
                        For Each p As Process In localByName
                            ShowWindow(p.MainWindowHandle, 3) ' SW_MAXIMIZE
                        Next

                        myProcess.EnableRaisingEvents = True            '~~~ Need to be TRUE, inorder to notify us when the process is closed by the user in some other means (like Alt + F4)
                        timeBegin = Now

                        AddHandler myProcess.Exited, AddressOf ProcessExited

                    Else
                        MsgBox("No Game File Found, please contact the administrator for assistance.", MsgBoxStyle.Information, "No Game File Found")
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                End Try

        End Select


        setAccountInfo(mysql)
        Me.Close()
    End Sub

    Private Function getBIOS(ByVal region As String) As String
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator_bios where country='" + region + "'")
        If mydata.Rows.Count > 0 Then
            Return mydata.Rows(0).Item(3)
        Else
            Return "USA"
        End If
    End Function

    Private Sub cmdSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSettings.Click
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator='" + cboEmulator.Text.ToString + "'")
        Select Case cboEmulator.Text
            Case "PSX", "EPSXE", "PCSX2"
                Process.Start(mydata.Rows(0).Item("location").ToString.Replace("~", "\"))
            Case "ZSNES"
                Process.Start(mydata.Rows(0).Item("location").ToString.Replace("~", "\"))
            Case "Project64"
                Process.Start(mydata.Rows(0).Item("location").ToString.Replace("~", "\"))
            Case "SEGA"
                Process.Start(mydata.Rows(0).Item("location").ToString.Replace("~", "\"))
            Case "Fusion"
                Process.Start(mydata.Rows(0).Item("location").ToString.Replace("~", "\"))
        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frm.Close()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboEmulator_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmulator.SelectedIndexChanged
        With mysql
            .setTable("tblgamedata")
            .addValue(cboEmulator.Text, "lastSelectedEmu")
            .Update("gameID", gameid.ToString)
        End With
    End Sub

    Private Sub cmdFavorite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFavorite.Click
        Select Case cmdFavorite.Text
            Case "Add Favorite"
                With cmdFavorite
                    Me.BackColor = Color.FromArgb(128, 64, 0)
                    flpTopGamer.BackColor = Color.FromArgb(108, 44, 0)
                    .Width = 120
                    .Standard_ThemeColor = PowerNET8.myColor.Share.SystemColor.BackgroundColor.StandardColor.DColors.Red
                    .JqueryIconTypes = PowerNET8.myIcons.Share.Jquery.JqueryIconTypes.close
                    .Text = "Remove Favorite"

                    With mysql
                        .setTable("tblaccount_favorite_games")
                        .addValue(userID.ToString, "accountID")
                        .addValue(gameid.ToString, "gameID")
                        .addValue(Now.ToString("yyyy-MM-dd HH:mm:ss"), "dtCreated")
                        .Insert()
                    End With

                End With
            Case "Remove Favorite"
                With cmdFavorite
                    .Width = 97
                    .JqueryIconTypes = PowerNET8.myIcons.Share.Jquery.JqueryIconTypes.star
                    .Standard_ThemeColor = PowerNET8.myColor.Share.SystemColor.BackgroundColor.StandardColor.DColors.Orange
                    Me.BackColor = Color.FromArgb(21, 21, 21)
                    flpTopGamer.BackColor = Color.FromArgb(42, 42, 42)
                    .Text = "Add Favorite"

                    mysql.Query("DELETE FROM tblaccount_favorite_games where gameID=" + gameid.ToString)

                End With


        End Select
    End Sub

End Class