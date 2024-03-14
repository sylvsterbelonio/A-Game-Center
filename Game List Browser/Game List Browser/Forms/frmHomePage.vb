Imports PowerNET8.myNumber.Share
Imports PowerNET8.myString.Share
Imports System.Threading

Public Class frmHomePage

    Private mysql As New PowerNET8.mySQL.Init.SQL
    Dim Title As String = ""
    Private onLoad As Boolean = False

    Private Boxheight As Integer = 224

    Private Enum BoxType
        Standard
        Portrait
    End Enum

    Private Function getBoxHeight(ByVal type As BoxType)
        Select Case type
            Case BoxType.Standard
                Return 224
            Case BoxType.Portrait

        End Select
    End Function

    Public Sub UnlockFavoriteMenu()
        tsFLimiter.Text = "25"
        utcMain.Tabs(2).Visible = True
        reloadFavoriteGames()
    End Sub

    Private Sub frmPrimaryBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)

        tsLimiter.Text = "25"
        tsFLimiter.Text = "25"


        'RANK RELOAD
        reloadAllGenre()
        GameRankingTop3()
        recentGames()
        'PROFILE INFO
        'reloadProfileInformation(1)

        reloadNewsFeed()
        tReloadHomeUpdates.Start()
    End Sub

    Private Sub reloadGameType()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblgametype order by product")
        flpHome.Controls.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            createObjectBox(mydata.Rows(i).Item("product"), mydata.Rows(i).Item("introduced"), getNoOfGames(mydata.Rows(i).Item("product")), mydata.Rows(i).Item("logo"))
        Next
    End Sub

    Private Sub txtSearchHome_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblgametype where product like '" + txtSearchHome.Text + "%'order by product ")
        flpHome.Controls.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            createObjectBox(mydata.Rows(i).Item("product"), mydata.Rows(i).Item("introduced"), getNoOfGames(mydata.Rows(i).Item("product")), mydata.Rows(i).Item("logo"))
        Next
    End Sub

    Private Function getNoOfGames(ByVal title As String) As Integer
        Dim mydata As DataTable = mysql.Query("SELECT COUNT(*) from tblgamedata where platforms LIKE '" + title + "'")
        Return mydata.Rows(0).Item(0)
    End Function

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        createObjectBox()
    End Sub

    Private Sub setPlayer(ByVal type As String)
        cboPlayer.Items.Clear()
        Dim count As Integer = 1
        Select Case type
            Case "PSX"
                count = 2
            Case "EPXE"
                count = 4
            Case "Nintendo 64"
                count = 4
            Case "Sega"
                count = 2
            Case "Popcap Games"
                count = 1
            Case Else
                count = 2
        End Select
        For i As Integer = 1 To count
            If i = 1 Then
                cboPlayer.Items.Add(i.ToString)
            Else
                cboPlayer.Items.Add("1-" + i.ToString)
            End If

        Next
        cboPlayer.Items.Add("-View All-")
        cboPlayer.Text = "-View All-"
    End Sub

    Private Sub Box_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel3.Click
        If TypeOf sender Is Panel Then
            Title = sender.tag

        Else
            Title = sender.parent.tag
        End If

        With utcMain
            .Tabs(3).Visible = True
            .Tabs(3).Text = Title.ToUpper
            .Tabs(3).Selected = True

            Select Case Title
                Case "Play Station"
                    .Tabs(3).Appearance.Image = Image.FromFile(Application.StartupPath + "\Images\Play Station\ps1.png")
                    setPlayer("EPXE")
                Case "Play Station 2"
                    .Tabs(3).Appearance.Image = Image.FromFile(Application.StartupPath + "\Images\Play Station 2\ps2.png")
                    setPlayer("Play Station 2")
                Case "Nintendo 64"
                    .Tabs(3).Appearance.Image = Image.FromFile(Application.StartupPath + "\Images\Nintendo 64\nintendo 64.png")
                    setPlayer("Nintendo 64")
                Case "Sega"
                    .Tabs(3).Appearance.Image = Image.FromFile(Application.StartupPath + "\Images\SEGA\sega.png")
                    setPlayer("Sega")
                Case "Popcap Games"
                    .Tabs(3).Appearance.Image = Image.FromFile(Application.StartupPath + "\Images\Popcap Games\Popcaplogo.png")
                    setPlayer("Popcap Games")
            End Select
        End With
        reloadSubGames(Title)
    End Sub

    Private Sub Box_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel3.MouseEnter
        If TypeOf sender Is Panel Then
            sender.BackColor = Color.FromArgb(42, 42, 42)
        Else
            sender.parent.BackColor = Color.FromArgb(42, 42, 42)
        End If
    End Sub

    Private Sub Box_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel3.MouseLeave
        If TypeOf sender Is Panel Then
            If sender.AccessibleDescription = "favorite" Then
                sender.backcolor = Color.FromArgb(128, 64, 0)
            Else
                sender.BackColor = Color.Transparent
            End If
        Else
            If sender.parent.AccessibleDescription = "favorite" Then
                sender.parent.backcolor = Color.FromArgb(128, 64, 0)
            Else
                sender.parent.BackColor = Color.Transparent
            End If
        End If
    End Sub

    Private Sub createObjectBox(Optional ByVal NameOf As String = "", Optional ByVal Title As Date = Nothing, Optional ByVal Games As String = "", Optional ByVal imageLoc As String = "")
        Dim pnlObject As New Panel
        With pnlObject
            .Width = 232
            .Height = 150

            .Cursor = Cursors.Hand

            AddHandler .MouseEnter, AddressOf Box_MouseEnter
            AddHandler .MouseLeave, AddressOf Box_MouseLeave
            AddHandler .MouseClick, AddressOf Box_Click
            .Tag = NameOf
        End With

        Dim picLogo As New PictureBox
        With picLogo
            .Width = 216
            .Height = 92

            If imageLoc <> "" Then
                .ImageLocation = Application.StartupPath + "\" + imageLoc.Replace("~", "\")
            Else
                .Image = My.Resources.Play_Now_Button_PNG_Transparent_Image
            End If

            .SizeMode = PictureBoxSizeMode.Zoom
            .Left = 8
            .Top = 7

            AddHandler .MouseEnter, AddressOf Box_MouseEnter
            AddHandler .MouseLeave, AddressOf Box_MouseLeave
            AddHandler .MouseClick, AddressOf Box_Click
        End With
        pnlObject.Controls.Add(picLogo)

        Dim lblCaption As New Label
        With lblCaption
            .Width = 214
            .Height = 23
            .AutoSize = False
            .ForeColor = Color.White
            .TextAlign = ContentAlignment.MiddleCenter
            Dim dt As Date = Title
            .Text = "Since " + Title.Year.ToString
            .Left = 9
            .Top = 105
            AddHandler .MouseEnter, AddressOf Box_MouseEnter
            AddHandler .MouseLeave, AddressOf Box_MouseLeave
            AddHandler .MouseClick, AddressOf Box_Click
        End With
        pnlObject.Controls.Add(lblCaption)

        Dim lblCaption2 As New Label
        With lblCaption2
            .Width = 214
            .Height = 23
            .AutoSize = False
            .ForeColor = Color.White
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = FormatNumber(Games, 0) + " Games"
            .Left = 9
            .Top = 123
            AddHandler .MouseEnter, AddressOf Box_MouseEnter
            AddHandler .MouseLeave, AddressOf Box_MouseLeave
            AddHandler .MouseClick, AddressOf Box_Click
        End With
        pnlObject.Controls.Add(lblCaption2)
        flpHome.Controls.Add(pnlObject)
    End Sub

    Private Sub utcMain_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles utcMain.SelectedTabChanged
        If utcMain.Tabs(1).Selected Then
            reloadGameType()
        ElseIf utcMain.Tabs(1).Selected Then
            If utcMain.Tabs(3).Visible = True Then utcMain.Tabs(3).Visible = False
            If utcMain.Tabs(4).Visible = True Then utcMain.Tabs(4).Visible = False
        ElseIf utcMain.Tabs(2).Selected Then

            reloadFavoriteGames()

            reloadFavoritePlatforms()
            reloadFavoriteGenre()
        ElseIf utcMain.Tabs(3).Selected Then
            If utcMain.Tabs(4).Visible = True Then utcMain.Tabs(4).Visible = False
        End If
        txtSearch.Text = ""
        txtSearchHome.Text = ""
    End Sub

    Private Sub cmdReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReturn.Click
        utcMain.Tabs(1).Selected = True
    End Sub

#Region "Navigation Bar"

    Private nPage As Integer = 0
    Private sPage As Integer = 0
    Private MaxPage As Integer = 0
    Private MaxRecord As Integer = 0
    Private Limiter As Integer = 25

    Private Sub Navigation_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFirst.Click, tsPrev.Click, tsNext.Click, tsLast.Click
        Select Case CType(sender, ToolStripButton).Name
            Case "tsFirst"
                sPage = 0
                tsFirst.Enabled = False
                tsPrev.Enabled = False
                tsLast.Enabled = True
                tsNext.Enabled = True
            Case "tsPrev"
                sPage -= 1
                If sPage <= 0 Then
                    tsFirst.Enabled = False
                    tsPrev.Enabled = False
                    If sPage = nPage Then
                        tsNext.Enabled = False
                        tsLast.Enabled = False
                    Else
                        tsNext.Enabled = True
                        tsLast.Enabled = True
                    End If
                Else
                    If sPage = nPage Then
                        tsNext.Enabled = False
                        tsLast.Enabled = False
                    Else
                        tsNext.Enabled = True
                        tsLast.Enabled = True
                    End If
                End If
            Case "tsNext"
                sPage += 1
                If sPage = nPage - 1 Then
                    tsNext.Enabled = False
                    tsLast.Enabled = False
                    tsFirst.Enabled = True
                    tsPrev.Enabled = True
                Else
                    tsNext.Enabled = True
                    tsLast.Enabled = True
                    tsPrev.Enabled = True
                    tsFirst.Enabled = True
                End If
            Case "tsLast"
                sPage = nPage - 1
                tsFirst.Enabled = True
                tsPrev.Enabled = True
                tsPrev.Enabled = False
                tsLast.Enabled = False
        End Select
        reloadSubGames(Title)
    End Sub

    Private Sub updateNavigationGrid()
        tsTotalPage.Text = "/" + FormatNumber(nPage, 0)
        tsPage.Text = sPage + 1

        Dim getPagePoint = IIf(sPage = 0, 1, sPage)

        'CHECK AND VALIDATE TOOLS
        If sPage = nPage - 1 And sPage > 0 Then
            tsFirst.Enabled = True
            tsPrev.Enabled = True
            tsNext.Enabled = False
            tsLast.Enabled = False
        ElseIf sPage = nPage - 1 Then
            tsFirst.Enabled = False
            tsPrev.Enabled = False
            tsNext.Enabled = False
            tsLast.Enabled = False
        ElseIf sPage = 0 Then
            tsFirst.Enabled = False
            tsPrev.Enabled = False
            tsNext.Enabled = True
            tsLast.Enabled = True
        Else
            tsFirst.Enabled = True
            tsPrev.Enabled = True
            tsNext.Enabled = True
            tsLast.Enabled = True
        End If


        If Val(tsPage.Text) < nPage Then
            tsCaption.Text = "- View " + FormatNumber(Val(tsPage.Text) * Val(tsLimiter.Text), 0) + " of " + FormatNumber(MaxRecord, 0) + " - "
        Else
            tsCaption.Text = "- View " + FormatNumber(MaxRecord, 0) + " of " + FormatNumber(MaxRecord, 0) + " - "
        End If

    End Sub

    Private Sub tsPage_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tsPage.KeyDown
        If e.KeyCode = Keys.Enter Then
            reloadSubGames(Title)
        End If
    End Sub

    Private Sub tsPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPage.Click
        tsPage.SelectAll()
    End Sub

    Private Sub tsPage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsPage.TextChanged
        If IsNumeric(tsPage.Text) Then
            If Val(tsPage.Text) = 0 Then
                tsPage.Text = "1"
            ElseIf Val(tsPage.Text) = nPage Then
                tsPage.Text = nPage.ToString
            Else
                sPage = Val(tsPage.Text) - 1
            End If
        End If
    End Sub

    Private Sub tsLimiter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsLimiter.SelectedIndexChanged
        sPage = 0
        reloadSubGames(Title)
    End Sub

#End Region

#Region "List of Games"

    Private Sub reloadGenre()
        cboGenre.Items.Clear()
        Dim mydata As DataTable = mysql.Query("select distinct gametype from tblgamedata order by gametype")
        If mydata.Rows.Count > 0 Then
            For i As Integer = 0 To mydata.Rows.Count - 1
                Dim col() As String = mydata.Rows(i).Item(0).ToString.Split(",")
                For a As Integer = 0 To col.Length - 1

                    Dim blnFound As Boolean = False
                    For b As Integer = 0 To cboGenre.Items.Count - 1
                        If col(a) = cboGenre.Items(b) Then
                            blnFound = True
                            Exit For
                        End If
                    Next

                    If blnFound = False Then
                        cboGenre.Items.Add(Trim(col(a)))
                    End If

                Next
            Next
        End If
        cboGenre.Items.Add("-View All-")
        cboGenre.SelectedIndex = cboGenre.Items.Count - 1
    End Sub

    Private Sub reloadSubGames(ByVal gamename As String)
        reloadGenre()
        flpGameList.Controls.Clear()

        Dim boxTT As BoxType = BoxType.Standard

        Dim wh As String = ""

        If cboGenre.Text <> "-View All-" Then
            Concat.Append(wh, " gameType like '%" + cboGenre.Text + "%' ", " and ")
        End If
        If txtSearch.Text <> "" Then
            Concat.Append(wh, " gameName like '" + txtSearch.Text + "%' ", " and ")
        End If
        If cboPlayer.Text <> "-View All-" And cboPlayer.Text <> "" Then
            Dim col() = cboPlayer.Text.Split("-")
            If col.Length = 1 Then
                Concat.Append(wh, " Player = " + IIf(IsNumeric(col(0)), col(0), 1) + "", " and ")
            Else
                Concat.Append(wh, " Player = " + col(1) + "", " and ")
            End If
        End If

        If wh <> "" Then
            wh = " and " + wh
        End If

        Select Case gamename
            Case "Play Station"
            Case "Sega", "Play Station 2", "Popcap Games"
                boxTT = BoxType.Portrait
        End Select

        'QUERY OF DATA
        Dim q As String = "SELECT tblgamedata.gameID, gameName, gametype, coverPhoto, platforms FROM   tblgamedata_imageloc   INNER JOIN tblgamedata     ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) where platforms like '" + gamename + "' and isVisible=1 " + wh + " order by gameName limit " + (sPage * Val(tsLimiter.Text)).ToString + "," + tsLimiter.Text.ToString
        Dim mydata As DataTable = mysql.Query(q)
        Dim s As String = "SELECT count(*) as 'total' FROM   tblgamedata_imageloc   INNER JOIN tblgamedata     ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) where platforms like '" + gamename + "'  and isVisible=1 " + wh + " order by gameName "
        Dim mydataCount As DataTable = mysql.Query(s)

        'GET THE NUMBER OF PAGES
        nPage = 0
        Dim record As Integer = 0
        MaxRecord = mydataCount.Rows(0).Item(0)
        record = MaxRecord
        Do
            nPage += 1
            record -= Val(tsLimiter.Text)
        Loop Until record < Val(tsLimiter.Text)
        If record > 0 Then nPage += 1

        'CAPTION THE RECORD
        updateNavigationGrid()

        If mydata.Rows.Count > 0 Then
            For i As Integer = 0 To mydata.Rows.Count - 1
                createSubObjectBox(mydata.Rows(i).Item("gameID"), mydata.Rows(i).Item("coverPhoto"), mydata.Rows(i).Item("gameName"), boxTT)
            Next
        Else
            'MsgBox("No Game Record Found!", MsgBoxStyle.Information, "Unable to Load Game List")
        End If
    End Sub

    Private Function getFavoriteGame(ByVal gameID As Integer)
        If userID > 0 Then
            Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount_favorite_games where gameID=" + gameID.ToString + " and accountID=" + userID.ToString)
            If mydata.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
            Return False
        End If
    End Function

    Private Sub createSubObjectBox(ByVal gameID As Integer, ByVal imageloc As String, ByVal title As String, Optional ByVal boxType As BoxType = BoxType.Standard)
        Dim pnlObject As New Panel
        With pnlObject

            If boxType = frmHomePage.BoxType.Standard Then
                .Height = 224
            Else
                .Height = 309
            End If

            .Width = 229

            .Cursor = Cursors.Hand
            .BackColor = IIf(getFavoriteGame(gameID), Color.FromArgb(128, 64, 0), Color.Transparent)

            If .BackColor = Color.FromArgb(128, 64, 0) Then .AccessibleDescription = "favorite"

            AddHandler .MouseEnter, AddressOf Box_MouseEnter
            AddHandler .MouseLeave, AddressOf Box_MouseLeave
            AddHandler .MouseClick, AddressOf SubBox_Click
            .Tag = gameID

        End With

        Dim picLogo As New PictureBox
        With picLogo
            .Width = 220

            If boxType = frmHomePage.BoxType.Standard Then
                .Height = 187
            Else
                .Height = 268
            End If



            If imageloc <> "" Then
                .ImageLocation = imageloc.Replace("~", "\")
            Else
                .Image = My.Resources.Play_Now_Button_PNG_Transparent_Image
            End If

            .SizeMode = PictureBoxSizeMode.Zoom
            .Left = 4
            .Top = 5

            If pnlObject.BackColor = Color.FromArgb(255, 128, 0) Then .AccessibleDescription = "favorite"

            AddHandler .MouseEnter, AddressOf Box_MouseEnter
            AddHandler .MouseLeave, AddressOf Box_MouseLeave
            AddHandler .MouseClick, AddressOf SubBox_Click
        End With
        pnlObject.Controls.Add(picLogo)

        Dim lblCaption As New Label
        With lblCaption
            .Width = 221
            .Height = 23
            .AutoSize = False
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = title
            .Left = 3
            .ForeColor = Color.White
            If boxType = frmHomePage.BoxType.Standard Then
                .Top = 195
            Else
                .Top = 280
            End If


            If pnlObject.BackColor = Color.PeachPuff Then .AccessibleDescription = "favorite"

            AddHandler .MouseEnter, AddressOf Box_MouseEnter
            AddHandler .MouseLeave, AddressOf Box_MouseLeave
            AddHandler .MouseClick, AddressOf SubBox_Click
        End With
        pnlObject.Controls.Add(lblCaption)

        flpGameList.Controls.Add(pnlObject)
    End Sub

    Private Sub SubBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel3.Click
        Dim gameID As Integer = 0
        If TypeOf sender Is Panel Then
            gameID = sender.tag
        Else
            gameID = sender.parent.tag
        End If
        Dim frm As New lblDesigners
        With frm
            .gameid = gameID
            .Text = "Profile Game"
            .ShowDialog()
        End With
    End Sub

    Private Sub search_SubGames()

        Dim wh As String = ""

        If cboGenre.Text <> "-View All-" Then
            Concat.Append(wh, " gameType like '%" + cboGenre.Text + "%' ", " and ")
        End If
        If txtSearch.Text <> "" Then
            Concat.Append(wh, " gameName like '" + txtSearch.Text + "%' ", " and ")
        End If
        If cboPlayer.Text <> "-View All-" And cboPlayer.Text <> "" Then
            Dim col() = cboPlayer.Text.Split("-")
            If col.Length = 1 Then
                Concat.Append(wh, " Player = " + IIf(IsNumeric(col(0)), col(0), 1) + "", " and ")
            Else
                Concat.Append(wh, " Player = " + col(1) + "", " and ")
            End If
        End If

        If wh <> "" Then
            wh = " and " + wh
        End If

        'QUERY OF DATA
        Dim q As String = "SELECT tblgamedata.gameID, gameName, gametype, coverPhoto, platforms FROM   tblgamedata_imageloc   INNER JOIN tblgamedata     ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) where platforms like '" + Title + "' " + wh + " order by gameName limit " + (sPage * Val(tsLimiter.Text)).ToString + "," + tsLimiter.Text.ToString
        Dim mydata As DataTable = mysql.Query(q)
        Dim s As String = "SELECT count(*) as 'total' FROM   tblgamedata_imageloc   INNER JOIN tblgamedata     ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) where platforms like '" + Title + "' " + wh + " order by gameName "
        Dim mydataCount As DataTable = mysql.Query(s)

        'GET THE NUMBER OF PAGES
        nPage = 0
        Dim record As Integer = 0
        MaxRecord = mydataCount.Rows(0).Item(0)
        record = MaxRecord
        Do
            nPage += 1
            record -= Val(tsLimiter.Text)
        Loop Until record < Val(tsLimiter.Text)
        If record > 0 Then nPage += 1

        'CAPTION THE RECORD
        updateNavigationGrid()


        flpGameList.Controls.Clear()
        'Dim mydata As DataTable = mysql.Query("SELECT tblgamedata.gameID, gameName, gametype, coverPhoto, platforms FROM   tblgamedata_imageloc   INNER JOIN tblgamedata     ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) where platforms like '" + utcMain.Tabs(1).Text + "' " + wh)
        If mydata.Rows.Count > 0 Then
            For i As Integer = 0 To mydata.Rows.Count - 1
                createSubObjectBox(mydata.Rows(i).Item("gameID"), mydata.Rows(i).Item("coverPhoto"), mydata.Rows(i).Item("gameName"))
            Next
        Else

        End If
    End Sub

    Private Sub flpGameList_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles flpGameList.MouseEnter
        flpGameList.Focus()
    End Sub

    Private Sub txtSearchHome_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchHome.GotFocus
        txtSearchHome.BackColor = Color.Black
    End Sub

    Private Sub txtSearchHome_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchHome.KeyUp
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblgametype where product like '" + txtSearchHome.Text + "%'order by product ")
        flpHome.Controls.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            createObjectBox(mydata.Rows(i).Item("product"), mydata.Rows(i).Item("introduced"), getNoOfGames(mydata.Rows(i).Item("product")), mydata.Rows(i).Item("logo"))
        Next
    End Sub

    Private Sub cboGenre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGenre.SelectedIndexChanged
        txtSearch.Text = ""
        tsPage.Text = "1"
        search_SubGames()
    End Sub

    Private Sub cmdSearchGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        search_SubGames()
    End Sub

    Private Sub txtSearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.GotFocus
        txtSearch.BackColor = Color.Black
    End Sub

    Private Sub txtSearch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.LostFocus
        txtSearch.BackColor = Color.FromArgb(84, 84, 84)
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        tsPage.Text = "1"
        search_SubGames()
    End Sub

#End Region

#Region "FAVORITE GAMES"

    Private Sub reloadFavoriteGames()
        Dim wh As String = ""

        If cboFGenre.Text <> "-View All-" Then
            Concat.Append(wh, " gameType like '%" + cboFGenre.Text + "%' ", " and ")
        End If

        If cboFGameType.Text <> "-View All-" Then
            Concat.Append(wh, " platforms like '%" + cboFGameType.Text + "%' ", " and ")
        End If

        If txtFSearch.Text <> "" Then
            Concat.Append(wh, " gameName like '" + txtFSearch.Text + "%' ", " and ")
        End If
        If wh <> "" Then
            wh = " and " + wh
        End If


        'QUERY OF DATA
        Dim q As String = "SELECT * FROM  tblgamedata_imageloc INNER JOIN tblgamedata    ON (tblgamedata_imageloc.gameID = tblgamedata.gameID)  INNER JOIN tblaccount_favorite_games    ON (tblaccount_favorite_games.gameID = tblgamedata.gameID) where accountID=" + userID.ToString + " " + wh + " order by gameName limit " + (FsPage * Val(tsFLimiter.Text)).ToString + "," + tsFLimiter.Text.ToString
        Dim mydata As DataTable = mysql.Query(q)
        Dim s As String = "SELECT count(*) as 'total' FROM  tblgamedata_imageloc INNER JOIN tblgamedata    ON (tblgamedata_imageloc.gameID = tblgamedata.gameID)  INNER JOIN tblaccount_favorite_games    ON (tblaccount_favorite_games.gameID = tblgamedata.gameID) where accountID=" + userID.ToString + " " + wh
        Dim mydataCount As DataTable = mysql.Query(s)

        'GET THE NUMBER OF PAGES
        FnPage = 0
        Dim record As Integer = 0
        FMaxRecord = mydataCount.Rows(0).Item(0)
        record = FMaxRecord
        Do
            FnPage += 1
            record -= Val(tsFLimiter.Text)
        Loop Until record < Val(tsFLimiter.Text)
        If record > 0 Then FnPage += 1

        'CAPTION THE RECORD
        FupdateNavigationGrid()

        'Dim mydata As DataTable = mysql.Query("SELECT * FROM  tblgamedata_imageloc INNER JOIN tblgamedata    ON (tblgamedata_imageloc.gameID = tblgamedata.gameID)  INNER JOIN tblaccount_favorite_games    ON (tblaccount_favorite_games.gameID = tblgamedata.gameID) where accountID=" + userID.ToString + " " + wh)
        flpFavoriteList.Controls.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            createFavoriteObjectBox(mydata.Rows(i).Item("gameID"), mydata.Rows(i).Item("gameName"), mydata.Rows(i).Item("coverPhoto"), mydata.Rows(i).Item("gameType"), mydata.Rows(i).Item("platforms"))
        Next

        onLoad = True
    End Sub

    Private Sub reloadFavoritePlatforms()
        Dim mydata As DataTable = mysql.Query("SELECT distinct platforms FROM  tblgamedata_imageloc INNER JOIN tblgamedata    ON (tblgamedata_imageloc.gameID = tblgamedata.gameID)  INNER JOIN tblaccount_favorite_games    ON (tblaccount_favorite_games.gameID = tblgamedata.gameID) where accountID=" + userID.ToString + " order by platforms")
        cboFGameType.Items.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            cboFGameType.Items.Add(mydata.Rows(i).Item(0))
        Next
        cboFGameType.Items.Add("-View All-")
        cboFGameType.Text = "-View All-"
    End Sub

    Private Sub reloadFavoriteGenre()
        Dim mydata As DataTable = mysql.Query("SELECT distinct gameType FROM  tblgamedata_imageloc INNER JOIN tblgamedata    ON (tblgamedata_imageloc.gameID = tblgamedata.gameID)  INNER JOIN tblaccount_favorite_games    ON (tblaccount_favorite_games.gameID = tblgamedata.gameID) where accountID=" + userID.ToString + " order by gameType")
        cboFGenre.Items.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            cboFGenre.Items.Add(mydata.Rows(i).Item(0))
        Next
        cboFGenre.Items.Add("-View All-")
        cboFGenre.Text = "-View All-"
    End Sub

    Private Sub FBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel3.MouseEnter
        If TypeOf sender Is Panel Then
            sender.BackColor = Color.FromArgb(255, 128, 0)
        Else
            sender.parent.BackColor = Color.FromArgb(255, 128, 0)
        End If
    End Sub

    Private Sub FBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel3.MouseLeave
        If TypeOf sender Is Panel Then
            sender.BackColor = Color.Transparent
        Else
            sender.parent.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub createCustomObject(ByRef obj As Object, ByVal type As String, ByVal value As String, ByVal size As String, ByVal position As String, Optional ByVal ext As String = "")
        Select Case type
            Case "label"
                Dim lblCaption As New Label
                With lblCaption
                    .ForeColor = Color.White
                    If ext = "headings" Then
                        Dim oldFont As Font = New Font(.Font.FontFamily, 8.25, FontStyle.Bold, .Font.Unit)
                        .Font = oldFont
                        .TextAlign = ContentAlignment.MiddleLeft
                    Else
                        .TextAlign = ContentAlignment.MiddleLeft
                    End If

                    Dim sz() As String = size.Split(",")
                    .Width = Val(sz(0))
                    .Height = Val(sz(1))
                    .AutoSize = False


                    .Text = value
                    Dim ps() As String = position.Split(",")
                    .Left = Val(ps(0))
                    .Top = Val(ps(1))
                    AddHandler .MouseEnter, AddressOf FBox_MouseEnter
                    AddHandler .MouseLeave, AddressOf FBox_MouseLeave
                    AddHandler .MouseClick, AddressOf SubBox_Click
                End With
                obj.Controls.Add(lblCaption)
            Case "picture"
                Dim picLogo As New PictureBox
                With picLogo
                    Dim sz() As String = size.Split(",")
                    .Width = Val(sz(0))
                    .Height = Val(sz(1))

                    If value <> "" Then
                        .ImageLocation = value.Replace("~", "\")
                    Else
                        .Image = My.Resources.Play_Now_Button_PNG_Transparent_Image
                    End If

                    .SizeMode = PictureBoxSizeMode.Zoom

                    Dim ps() As String = position.Split(",")
                    .Left = Val(ps(0))
                    .Top = Val(ps(1))

                    AddHandler .MouseEnter, AddressOf FBox_MouseEnter
                    AddHandler .MouseLeave, AddressOf FBox_MouseLeave
                    AddHandler .MouseClick, AddressOf SubBox_Click
                End With
                obj.Controls.Add(picLogo)
        End Select
    End Sub

    Private Function getTotalPlayed(ByVal gameid As String) As String
        Dim timex As TimeSpan = New TimeSpan(0, 0, 0)
        Dim mydata As DataTable = mysql.Query("SELECT timePlayed FROM tblaccount_activity where accountID=" + userID.ToString + " and gameID=" + gameid + " and typeVal = 'playing'")
        If mydata.Rows.Count > 0 Then

            For i As Integer = 0 To mydata.Rows.Count - 1
                Dim time2 As TimeSpan = mydata.Rows(i).Item(0)
                timex = timex + time2
            Next
        End If
        Return timex.ToString
    End Function

    Private Function getPlayedTimes(ByVal gameID As String) As String
        Dim mydata As DataTable = mysql.Query("SELECT count(*) FROM tblaccount_activity where accountID=" + userID.ToString + " and gameID=" + gameID + " and typeVal = 'start_play'")
        Return mydata.Rows(0).Item(0)
    End Function

    Private Sub createFavoriteObjectBox(ByVal gameID As String, ByVal nameOf As String, ByVal imageLoc As String, ByVal genre As String, ByVal platforms As String)
        Dim pnlObject As New Panel

        With pnlObject
            .Width = 318
            .Height = 117

            .Cursor = Cursors.Hand

            AddHandler .MouseEnter, AddressOf FBox_MouseEnter
            AddHandler .MouseLeave, AddressOf FBox_MouseLeave
            AddHandler .MouseClick, AddressOf SubBox_Click
            .Tag = gameID
        End With

        createCustomObject(pnlObject, "label", nameOf, "200, 23", "115, 5", "headings")
        createCustomObject(pnlObject, "picture", imageLoc, "105, 105", "4, 5")

        createCustomObject(pnlObject, "label", "Play/Points", "88, 23", "115, 27")
        createCustomObject(pnlObject, "label", getPlayedTimes(gameID) + "/" + getTotalPoints(mysql, gameID, userID.ToString).ToString, "98, 23", "202, 27")
        createCustomObject(pnlObject, "label", "Played Time", "81, 23", "115, 47")
        createCustomObject(pnlObject, "label", getTotalPlayed(gameID), "98, 23", "202, 47")
        createCustomObject(pnlObject, "label", "Genre", "80, 23", "116, 66")
        createCustomObject(pnlObject, "label", genre, "98, 23", "202, 66")
        createCustomObject(pnlObject, "label", "Platform", "73, 23", "115, 85")
        createCustomObject(pnlObject, "label", platforms, "98, 23", "202, 84")

        flpFavoriteList.Controls.Add(pnlObject)
    End Sub

    Private Sub cboFGameType_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFGameType.LostFocus
        reloadFavoriteGames()
    End Sub

    Private Sub cboFGameType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFGameType.SelectedIndexChanged
        If onLoad Then
            txtFSearch.Text = ""
            reloadFavoriteGames()
        End If

    End Sub

    Private Sub cboFGenre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFGenre.SelectedIndexChanged
        If onLoad Then
            txtFSearch.Text = ""
            reloadFavoriteGames()
        End If
    End Sub

    Private Sub txtFSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFSearch.KeyPress
        reloadFavoriteGames()
    End Sub

#Region "NAVIGATION BAR"

    Private FnPage As Integer = 0
    Private FsPage As Integer = 0
    Private FMaxPage As Integer = 0
    Private FMaxRecord As Integer = 0
    Private FLimiter As Integer = 25

    Private Sub FNavigation_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFFirst.Click, tsFPrev.Click, tsFNext.Click, tsFLast.Click
        Select Case CType(sender, ToolStripButton).Name
            Case "tsFFirst"
                FsPage = 0
                tsFFirst.Enabled = False
                tsFPrev.Enabled = False
                tsFLast.Enabled = True
                tsFNext.Enabled = True
            Case "tsFPrev"
                FsPage -= 1
                If FsPage <= 0 Then
                    tsFFirst.Enabled = False
                    tsFPrev.Enabled = False
                    If FsPage = nPage Then
                        tsFNext.Enabled = False
                        tsFLast.Enabled = False
                    Else
                        tsFNext.Enabled = True
                        tsFLast.Enabled = True
                    End If
                Else
                    If FsPage = nPage Then
                        tsFNext.Enabled = False
                        tsFLast.Enabled = False
                    Else
                        tsFNext.Enabled = True
                        tsFLast.Enabled = True
                    End If
                End If
            Case "tsFNext"
                FsPage += 1
                If FsPage = nPage - 1 Then
                    tsFNext.Enabled = False
                    tsFLast.Enabled = False
                    tsFFirst.Enabled = True
                    tsFPrev.Enabled = True
                Else
                    tsFNext.Enabled = True
                    tsFLast.Enabled = True
                    tsFPrev.Enabled = True
                    tsFFirst.Enabled = True
                End If
            Case "tsFLast"
                FsPage = nPage - 1
                tsFFirst.Enabled = True
                tsFPrev.Enabled = True
                tsFPrev.Enabled = False
                tsFLast.Enabled = False
        End Select
        reloadFavoriteGames()
    End Sub

    Private Sub FupdateNavigationGrid()
        tsFTotalPage.Text = "/" + FormatNumber(FnPage, 0)
        tsFPage.Text = FsPage + 1

        Dim getPagePoint = IIf(FsPage = 0, 1, FsPage)

        'CHECK AND VALIDATE TOOLS
        If FsPage = FnPage - 1 And FsPage > 0 Then
            tsFFirst.Enabled = True
            tsFPrev.Enabled = True
            tsFNext.Enabled = False
            tsFLast.Enabled = False
        ElseIf FsPage = FnPage - 1 Then
            tsFFirst.Enabled = False
            tsFPrev.Enabled = False
            tsFNext.Enabled = False
            tsFLast.Enabled = False
        ElseIf FsPage = 0 Then
            tsFFirst.Enabled = False
            tsFPrev.Enabled = False
            tsFNext.Enabled = True
            tsFLast.Enabled = True
        Else
            tsFFirst.Enabled = True
            tsFPrev.Enabled = True
            tsFNext.Enabled = True
            tsFLast.Enabled = True
        End If


        If Val(tsFPage.Text) < FnPage Then
            tsFCaption.Text = "- View " + FormatNumber(Val(tsFPage.Text) * Val(tsFLimiter.Text), 0) + " of " + FormatNumber(FMaxRecord, 0) + " - "
        Else
            tsFCaption.Text = "- View " + FormatNumber(FMaxRecord, 0) + " of " + FormatNumber(FMaxRecord, 0) + " - "
        End If

    End Sub

    Private Sub tsFPage_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tsFPage.KeyDown
        If e.KeyCode = Keys.Enter Then
            reloadFavoriteGames()
        End If
    End Sub

    Private Sub tsfPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFPage.Click
        tsFPage.SelectAll()
    End Sub

    Private Sub tsfPage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsFPage.TextChanged
        If IsNumeric(tsFPage.Text) Then
            If Val(tsFPage.Text) = 0 Then
                tsFPage.Text = "1"
            ElseIf Val(tsFPage.Text) = FnPage Then
                tsFPage.Text = FnPage.ToString
            Else
                FsPage = Val(tsFPage.Text) - 1
            End If
        End If
    End Sub

    Private Sub tsfLimiter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsFLimiter.SelectedIndexChanged
        FsPage = 0
        reloadFavoriteGames()
    End Sub

#End Region

#End Region


    Private Sub cboPlayer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPlayer.SelectedIndexChanged
        tsPage.Text = "1"
        search_SubGames()
    End Sub

#Region "OTHER GAMES"

    Private Sub cmdOtherGamesShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOtherGamesShow.Click
        With utcMain
            .Tabs(4).Visible = True
            .Tabs(4).Selected = True
            Select Case Title
                Case "Play Station"
                    pbOtherLogo.Image = My.Resources.ps1
                Case "Sega"
                    pbOtherLogo.Image = My.Resources.segass
                Case "Play Station 2"
                    pbOtherLogo.Image = My.Resources.ps2
            End Select
        End With
        reloadOtherGames()
        reloadEMulator()
    End Sub

    Private Function createOtherGamesTable() As DataTable
        Dim mytable As New PowerNET8.myDataTableCreator
        With mytable
            .new_table("tblOtherGames")
            .add_columnField("filename")
            .add_columnField("fileExt")
            .add_columnField("location")
            .add_columnField("filesize")

        End With
        Return mytable.get_table
    End Function

    Private dvOtherGames As DataView

    Private Sub reloadOtherGames()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator_other_game_location where gameType='" + Title + "'")
        If mydata.Rows.Count > 0 Then


            Dim di As New IO.DirectoryInfo(mydata.Rows(0).Item("location").ToString.Replace("~", "\"))
            Dim aryFi As IO.FileInfo() = di.GetFiles("*")
            Dim fi As IO.FileInfo

            Dim tblOtherGames As DataTable = createOtherGamesTable()


            tblOtherGames.Rows.Clear()
            For Each fi In aryFi
                ' Do work, example

                With tblOtherGames
                    Select Case Title
                        Case "Play Station"
                            If fi.Extension.ToLower = ".bin" Or fi.Extension.ToLower = ".img" Then
                                .Rows.Add()
                                .Rows(.Rows.Count - 1).Item("filename") = fi.Name
                                .Rows(.Rows.Count - 1).Item("fileExt") = fi.Extension
                                .Rows(.Rows.Count - 1).Item("location") = fi.FullName
                                .Rows(.Rows.Count - 1).Item("filesize") = GetFileSize(fi.Length, True)
                            End If
                        Case "Sega"
                            If fi.Extension.ToLower = ".bin" Then
                                .Rows.Add()
                                .Rows(.Rows.Count - 1).Item("filename") = fi.Name
                                .Rows(.Rows.Count - 1).Item("fileExt") = fi.Extension
                                .Rows(.Rows.Count - 1).Item("location") = fi.FullName
                                .Rows(.Rows.Count - 1).Item("filesize") = GetFileSize(fi.Length, True)
                            End If
                        Case "Super Nintendo"
                            If fi.Extension.ToLower = ".zip" Or fi.Extension.ToLower = ".rar" Then
                                .Rows.Add()
                                .Rows(.Rows.Count - 1).Item("filename") = fi.Name
                                .Rows(.Rows.Count - 1).Item("fileExt") = fi.Extension
                                .Rows(.Rows.Count - 1).Item("location") = fi.FullName
                                .Rows(.Rows.Count - 1).Item("filesize") = GetFileSize(fi.Length, True)
                            End If
                        Case "Play Station 2"
                            If fi.Extension.ToLower = ".iso" Or fi.Extension.ToLower = ".daa" Or fi.Extension.ToLower = ".bin" Or fi.Extension.ToLower = ".nrg" Then
                                .Rows.Add()
                                .Rows(.Rows.Count - 1).Item("filename") = fi.Name
                                .Rows(.Rows.Count - 1).Item("fileExt") = fi.Extension
                                .Rows(.Rows.Count - 1).Item("location") = fi.FullName
                                .Rows(.Rows.Count - 1).Item("filesize") = GetFileSize(fi.Length, True)
                            End If
                        Case "Nintendo 64"
                            If fi.Extension.ToLower = ".n64" Or fi.Extension.ToLower = ".z64" Then
                                .Rows.Add()
                                .Rows(.Rows.Count - 1).Item("filename") = fi.Name
                                .Rows(.Rows.Count - 1).Item("fileExt") = fi.Extension
                                .Rows(.Rows.Count - 1).Item("location") = fi.FullName
                                .Rows(.Rows.Count - 1).Item("filesize") = GetFileSize(fi.Length, True)
                            End If
                    End Select

                End With

            Next

            dvOtherGames = New DataView(tblOtherGames)
            dvOtherGames.Sort = "filename"

            Dim td As DataTable = dvOtherGames.ToTable

            dgvOtherGames.Rows.Clear()
            For i As Integer = 0 To td.Rows.Count - 1
                With dgvOtherGames
                    .Rows.Add()
                    .Rows(i).Cells(1).Value = td.Rows(i).Item("filename")
                    .Rows(i).Cells(2).Value = td.Rows(i).Item("fileExt")
                    .Rows(i).Cells(3).Value = td.Rows(i).Item("filesize")
                    .Rows(i).Cells(4).Value = td.Rows(i).Item("location")
                End With
            Next


        End If
    End Sub

    Public Function GetFileSize(ByVal TheSize As Long, Optional ByVal ShowSizeType As Boolean = False) As String

        Dim SizeType As String = ""
        '---
        If TheSize < 1000 Then
            SizeType = "B"
        Else
            If TheSize < 1000000000 Then
                If TheSize < 1000000 Then
                    SizeType = "KB"
                    TheSize = TheSize / 1000
                Else
                    SizeType = "MB"
                    TheSize = TheSize / 1000000
                End If
            Else
                TheSize = TheSize / 1000
                SizeType = "KB"
            End If
        End If
        '---
        If ShowSizeType = True Then
            Return FormatNumber(TheSize, 2) & SizeType
        Else
            Return TheSize
        End If
    End Function

    Private Sub txtOtherGamesSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtherGamesSearch.TextChanged

        dvOtherGames.RowFilter = " filename like '" + txtOtherGamesSearch.Text + "%'"
        dvOtherGames.Sort = "filename"
        Dim td As DataTable = dvOtherGames.ToTable

        dgvOtherGames.Rows.Clear()
        For i As Integer = 0 To td.Rows.Count - 1
            With dgvOtherGames
                .Rows.Add()
                .Rows(i).Cells(1).Value = td.Rows(i).Item("filename")
                .Rows(i).Cells(2).Value = td.Rows(i).Item("fileExt")
                .Rows(i).Cells(3).Value = td.Rows(i).Item("filesize")
                .Rows(i).Cells(4).Value = td.Rows(i).Item("location")
            End With
        Next
    End Sub

    Private Sub cmdOtherGamesHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOtherGamesHide.Click
        With utcMain
            .Tabs(4).Visible = False
        End With
    End Sub

    Private Sub reloadEMulator()
        With cboEmulator.Items
            .Clear()
            Select Case Title
                Case "Play Station"
                    .Add("PSX")
                    .Add("EPSXE")
                Case "Sega"
                    .Add("SEGA")
                Case "Super Nintendo"
                    .Add("ZSNES")
                Case "Play Station 2"
                    .Add("PCSX2")
                Case "Nintendo 64"
                    .Add("Project64")
                Case Else
                    .Add("PC")
            End Select
        End With
        cboEmulator.SelectedIndex = 0
    End Sub

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
        End Select
    End Sub


    Dim selectedGameID As String
    Dim myProcess As Process


    Private Sub selectOtherGames(ByVal emulator As String)

        Select Case emulator.ToLower
            Case "play station"
                If RemindersPSX = False Then
                    MsgBox("Press [ESC] to quit the Video Game. ", MsgBoxStyle.Information, "Importatn Reminders")
                    RemindersPSX = True
                End If
                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator.Text + "'")
                If mydata.Rows.Count > 0 Then
                    Try
                        Dim SW As New System.IO.StreamWriter("loadGame.bat")
                        With SW
                            Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """ -f """ + dgvOtherGames.CurrentRow.Cells(4).Value.ToString + """"
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


                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "play station 2"
                If RemindersPSX = False Then
                    MsgBox("Press [ESC] to quit the Video Game. ", MsgBoxStyle.Information, "Importatn Reminders")
                    RemindersPSX = True
                End If

                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator.Text + "'")
                If mydata.Rows.Count > 0 Then
                    Try


                        Dim SW As New System.IO.StreamWriter("loadGame.bat")
                        With SW
                            Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """  """ + dgvOtherGames.CurrentRow.Cells(4).Value.ToString + """ --fullscreen --fullboot"
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


                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "sega"
                If RemindersSega = False Then
                    MsgBox("Press [ALT + ENTER] to fullscreen/minimize the Video Game. ", MsgBoxStyle.Information, "FullScreen/Minimize")
                    RemindersSega = True
                End If

                Try
                    Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = 'Fusion'")
                    If mydata.Rows.Count > 0 Then
                        Dim SW As New System.IO.StreamWriter("loadGame.bat")
                        With SW
                            Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """ """ + dgvOtherGames.CurrentRow.Cells(4).Value.ToString + """ -fullscreen"
                            .WriteLine(str)
                            .Flush()
                            .Close()
                            .Dispose()
                            SW = Nothing
                        End With
                    End If

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
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                End Try
            Case "super nintendo"
                If RemindersPSX = False Then
                    MsgBox("Press [ESC] to quit the Video Game. ", MsgBoxStyle.Information, "Importatn Reminders")
                    RemindersPSX = True
                End If

                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator.Text + "'")
                If mydata.Rows.Count > 0 Then
                    Try


                        Dim SW As New System.IO.StreamWriter("loadGame.bat")
                        With SW
                            Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """  """ + dgvOtherGames.CurrentRow.Cells(4).Value.ToString + """ -m "
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


                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "nintendo 64"
                If RemindersProject64 = False Then
                    MsgBox("Press [ALT + ENTER] to fullscreen/minimize the Video Game. ", MsgBoxStyle.Information, "FullScreen/Minimize")
                    RemindersProject64 = True
                End If

                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulator = '" + cboEmulator.Text + "'")
                If mydata.Rows.Count > 0 Then
                    Try
                        Dim SW As New System.IO.StreamWriter("loadGame.bat")
                        With SW
                            Dim str As String = """" + mydata.Rows(0).Item("location").ToString.Replace("~", "\") + """ """ + dgvOtherGames.CurrentRow.Cells(4).Value.ToString + """"
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
                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                    End Try
                End If
            Case "pc"
                Try
                    Dim SW As New System.IO.StreamWriter("loadGame.bat")
                    With SW
                        Dim str As String = dgvOtherGames.CurrentRow.Cells(4).Value.ToString
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
                    myProcess.Start(dgvOtherGames.CurrentRow.Cells(4).Value.ToString)
                    '~~~ Start it

                    Dim localByName As Process() = Process.GetProcessesByName("loadGame.bat")
                    For Each p As Process In localByName
                        ShowWindow(p.MainWindowHandle, 3) ' SW_MAXIMIZE
                    Next

                    myProcess.EnableRaisingEvents = True            '~~~ Need to be TRUE, inorder to notify us when the process is closed by the user in some other means (like Alt + F4)
                    timeBegin = Now

                    AddHandler myProcess.Exited, AddressOf ProcessExited
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Unable to Load the Game")
                End Try
        End Select

        With mysql
            If userID = 0 Then

                .setTable("tblaccount_activity")
                .addValue(.nextID("accountActivityID"), "accountActivityID")
                .addValue("start_play", "typeVal")
                .addValue(0, "accountID")
                .addValue(selectedGameID, "gameID")
                .addValue(Now.ToString("yyyy-MM-dd HH:mm:ss"), "dtActivity")
                .Insert()
            Else
                Dim mydata As DataTable = mysql.Query("SELECT count(*) from tblaccount_activity where accountID=" + userID.ToString + " and gameID=" + selectedGameID.ToString + " and typeVal='start_play' and dtActivity between '" + Now.ToString("yyyy-MM-dd") + " 00:00:00' and '" + Now.ToString("yyyy-MM-dd") + " 23:59:59'")
                If mydata.Rows.Count > 0 Then
                    If mydata.Rows(0).Item(0) <= 5 Then
                        Dim mydata2 As DataTable = mysql.Query("SELECT count(*) from tblaccount_activity where accountID=" + userID.ToString + " and typeVal='start_play' and dtActivity between '" + Now.ToString("yyyy-MM-dd") + " 00:00:00' and '" + Now.ToString("yyyy-MM-dd") + " 23:59:59'")
                        If mydata2.Rows.Count > 0 Then
                            If mydata2.Rows(0).Item(0) <= 15 Then
                                .setTable("tblaccount_activity")
                                .addValue(.nextID("accountActivityID"), "accountActivityID")
                                .addValue("start_play", "typeVal")
                                .addValue(userID, "accountID")
                                .addValue(selectedGameID, "gameID")
                                .addValue(Now.ToString("yyyy-MM-dd H:m:s"), "dtActivity")
                                .Insert()
                            End If
                        End If
                    End If
                End If
            End If

            setAccountInfo(mysql)
        End With

    End Sub

    Private Sub dgvOtherGames_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOtherGames.CellClick

        Select Case dgvOtherGames.CurrentCell.ColumnIndex
            Case 5
                Dim emulator As String = Title
                Dim gameFile As String = ""

                Dim gameID As Integer = validateName(dgvOtherGames.CurrentRow.Cells(1).Value, dgvOtherGames.CurrentRow.Cells(4).Value)
                selectedGameID = gameID

                selectOtherGames(emulator)
        End Select

    End Sub

    Private Declare Function ShowWindow Lib "user32" (ByVal handle As IntPtr, ByVal nCmdShow As Integer) As Integer
    Private Declare Function SetForegroundWindow Lib "user32" (ByVal handle As IntPtr) As Integer
    Private timeBegin As DateTime

    Private Sub dgvOtherGames_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOtherGames.CellDoubleClick
        If dgvOtherGames.RowCount > 0 Then
            Dim emulator As String = Title
            Dim gameFile As String = ""

            Dim gameID As Integer = validateName(dgvOtherGames.CurrentRow.Cells(1).Value, dgvOtherGames.CurrentRow.Cells(4).Value)
            selectedGameID = gameID

            selectOtherGames(emulator)
        End If

    End Sub

    '~~~ This is the sub which will be called when the Process is closed. Whatever we want to do (when the process is closed), has to be included in this sub
    Private Sub ProcessExited(ByVal sender As Object, ByVal e As System.EventArgs, Optional ByVal GameID As String = "")
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
                .addValue(.nextID("accountActivityID"), "accountActivityID")
                .addValue(userID, "accountID")
                .addValue(GameID, "gameID")
                .addValue("playing", "typeVal")
                .addValue(difftime, "timePlayed")
                .addValue(totalPoints, "pts_timePlayed")
                .addValue(Now.ToString("yyyy-MM-dd HH:mm:ss"), "dtActivity")
                .Insert()
            End With
        End If
        myProcess.Close()   '~~~ Freeup the object
    End Sub

    Private Function validateName(ByVal name As String, ByVal location As String) As Integer
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblgamedata where gameName = '" + name + "'")
        If mydata.Rows.Count > 0 Then
            Return mydata.Rows(0).Item("gameID")
        Else
            Dim gameID As Integer
            With mysql
                .setTable("tblgamedata")
                gameID = .nextID("gameID")
                .addValue(gameID, "gameID")
                .addValue(name, "gameName")
                .addValue(Title, "platforms")
                .addValue(location, "gamefile")
                .addValue(0, "isVisible")
                .Insert()
            End With
            Return gameID
        End If
    End Function


#End Region

#Region "RANK"

#Region "Get list of Genre"

    Private Function getGenreTable()
        Dim table As New PowerNET8.myDataTableCreator
        With table
            .new_table("tblRank")
            .add_columnField("rank")
            Return .get_table
        End With
    End Function

    Private Function checkIfExistRank(ByVal name As String, ByRef table As DataTable)
        Dim blnFound As Boolean = False
        If table.Rows.Count > 0 Then
            For i As Integer = 0 To table.Rows.Count - 1
                If Trim(name) = Trim(table.Rows(i).Item(0)) Then
                    blnFound = True
                    Exit For
                End If
            Next
        End If
        Return blnFound
    End Function

    Private Sub reloadAllGenre()
        Dim mydata As DataTable = mysql.Query("select distinct gameType from tblgamedata")
        Dim tblRank As DataTable = getGenreTable()
        If mydata.Rows.Count > 0 Then
            For i As Integer = 0 To mydata.Rows.Count - 1
                'MsgBox(mydata.Rows(i).Item(0).ToString)
                Dim col() As String = mydata.Rows(i).Item(0).ToString.Split(",")
                If col.Length > 1 Then
                    For a As Integer = 0 To col.Length - 1
                        If Not checkIfExistRank(col(a), tblRank) And Trim(col(a)) <> "" Then
                            tblRank.Rows.Add()
                            tblRank.Rows(tblRank.Rows.Count - 1).Item(0) = Trim(col(a))
                        End If
                    Next
                Else
                    If Not checkIfExistRank(col(0), tblRank) And Trim(col(0)) <> "" Then
                        tblRank.Rows.Add()
                        tblRank.Rows(tblRank.Rows.Count - 1).Item(0) = Trim(col(0))
                    End If
                End If
            Next
        End If

        Dim dv As DataView = New DataView(tblRank)
        dv.Sort = "rank"
        tblRank = dv.ToTable
        cboRank.Items.Clear()
        cboRank.Items.Add("- OVERALL RANK -")
        cboRank.SelectedIndex = 0
        For i As Integer = 0 To tblRank.Rows.Count - 1
            cboRank.Items.Add(tblRank.Rows(i).Item(0))
        Next
    End Sub

#End Region

    Private Function getTableRankPlayer()
        Dim tbl As New PowerNET8.myDataTableCreator
        With tbl
            .new_table("tblRankPlayer")
            .add_columnField("accountID")
            .add_columnField("RankLogo")
            .add_columnField("Player")
            .add_columnField("Points", PowerNET8.myDataTableCreator.FieldType.Decimal_)
            Return .get_table
        End With
    End Function

    Private Function getRankPointsByMonth(ByVal accountID As String, Optional ByVal wh As String = "", Optional ByVal dtMonth As Date = Nothing) As Decimal
        'GET THE TOTAL NUMBER OF OVERALL POINTS
        Dim totalPoints As Double = 0
        Dim s As String
        If wh = "" Then
            s = "SELECT sum(points) as 'total' FROM  tblaccount_activity  INNER JOIN tblaccount_activity_points_ref    ON (tblaccount_activity.typeVal = tblaccount_activity_points_ref.name)  where tblaccount_activity.accountID = " + accountID + "  and (typeVal = 'login' or typeVal = 'logout') and tblaccount_activity.dtActivity between '" + Now.Year.ToString + "-" + Now.Month.ToString + "-1 00:00:00' and '" + Now.Year.ToString + "-" + Now.Month.ToString + "-31 23:59:59' " + wh
        Else
            s = "SELECT sum(points) as 'total' FROM  tblaccount_activity  INNER JOIN tblaccount_activity_points_ref    ON (tblaccount_activity.typeVal = tblaccount_activity_points_ref.name)  LEFT JOIN tblgamedata   ON (tblgamedata.gameID = tblaccount_activity.gameID)  where tblaccount_activity.accountID = " + accountID + " and tblaccount_activity.dtActivity between '" + Now.Year.ToString + "-" + Now.Month.ToString + "-1 00:00:00' and '" + Now.Year.ToString + "-" + Now.Month.ToString + "-31 23:59:59' " + wh
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
            mydata = mysql.Query("SELECT sum(exp) from tblrewards_giftbox where accountID=" + accountID.ToString + " and lastOpenedChest between '" + Now.Year.ToString + "-" + Now.Month.ToString + "-1 00:00:00' and '" + Now.Year.ToString + "-" + Now.Month.ToString + "-31 23:59:59'")
            If mydata.Rows.Count > 0 Then
                If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                    totalPoints += mydata.Rows(0).Item(0)
                End If
            End If
            'GET THE TOTAL POINTS OF SLOT MACHINE
            mydata = mysql.Query("SELECT sum(exp) from tblrewards_slotmachine where accountID=" + accountID.ToString + " and dateSpin between '" + Now.Year.ToString + "-" + Now.Month.ToString + "-1 00:00:00' and '" + Now.Year.ToString + "-" + Now.Month.ToString + "-31 23:59:59'")
            If mydata.Rows.Count > 0 Then
                If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                    totalPoints += mydata.Rows(0).Item(0)
                End If
            End If
        End If


        'BET POINTS ADDITION
        Dim win As Decimal = getSumWLBet(accountID, "win", "this month")
        Dim lose As Decimal = getSumWLBet(accountID, "lose", "this month")

        Return totalPoints + (win - lose)


    End Function

    Private Function getSumWLBet(ByVal accountID As String, ByVal type As String, Optional ByVal dtx As String = "") As Decimal
        Dim wh As String = ""
        If dtx <> "" Then
            wh = " and dtBattle between '" + Now.Year.ToString + "-" + Now.Month.ToString + "-1 0:0:0' and '" + Now.Year.ToString + "-" + Now.Month.ToString + "-31 23:59:59' "
        End If
        Select Case type
            Case "win"
                Dim mydata As DataTable = mysql.Query("select (select sum(bet_win_A) as 'total' from tblaccount_battle where accountID_A=" + accountID + " and status_A='win' " + wh + ") as 'A', (select sum(bet_win_B) as 'total' from tblaccount_battle where accountID_B=" + accountID + " and status_B='win' " + wh + ") as 'B'")
                If mydata.Rows.Count > 0 Then
                    Dim tot As Decimal = 0
                    If Not IsDBNull(mydata.Rows(0).Item(0)) Then tot += mydata.Rows(0).Item(0)
                    If Not IsDBNull(mydata.Rows(0).Item(1)) Then tot += mydata.Rows(0).Item(1)
                    Return tot
                End If
            Case "lose"
                Dim mydata As DataTable = mysql.Query("select (select sum(bet_lose_A) as 'total' from tblaccount_battle where accountID_A=" + accountID + " and status_A='lose' " + wh + ") as 'A', (select sum(bet_lose_B) as 'total' from tblaccount_battle where accountID_B=" + accountID + " and status_B='lose' " + wh + ") as 'B'")
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
        If accountID = "8" Then
            totalPoints = 0
        End If
        'game points
        Dim mydata As DataTable = mysql.Query("SELECT tblaccount_activity.accountID, tblgamedata.gameID,tblgamedata_imageloc.coverPhoto, tblgamedata.gameName, gameType as 'genre',platforms, sum(points) as 'total' FROM   tblaccount_activity inner JOIN tblaccount_activity_points_ref       ON (tblaccount_activity.typeVal = tblaccount_activity_points_ref.name) INNER JOIN tblgamedata     ON (tblgamedata.gameID = tblaccount_activity.gameID)   INNER JOIN tblgamedata_imageloc   ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) where tblaccount_activity.accountID = " + accountID + " " + wh + " group by tblgamedata.gameID order by total desc")
        If mydata.Rows.Count > 0 Then
            'dgvProfInfoGameStatus.Rows.Clear()
            For i As Integer = 0 To mydata.Rows.Count - 1
                totalPoints += CDbl(getTotalPoints(mysql, mydata.Rows(i).Item("gameID"), accountID.ToString))
            Next
        End If

        If wh = "" Then
            mydata = mysql.Query(s)
            If mydata.Rows.Count > 0 Then
                If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                    totalPoints += CDbl(mydata.Rows(0).Item(0))
                End If
            End If

            'GET THE TOTAL POINTS OF GIFT REWARDS
            mydata = mysql.Query("SELECT sum(exp) from tblrewards_giftbox where accountID=" + accountID.ToString)
            If mydata.Rows.Count > 0 Then
                If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                    totalPoints += CDbl(mydata.Rows(0).Item(0))
                End If
            End If
            'GET THE TOTAL POINTS OF SLOT MACHINE
            mydata = mysql.Query("SELECT sum(exp) from tblrewards_slotmachine where accountID=" + accountID.ToString)
            If mydata.Rows.Count > 0 Then
                If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                    totalPoints += CDbl(mydata.Rows(0).Item(0))
                End If
            End If
        End If


        'BET POINTS ADDITION
        Dim win As Decimal = getSumWLBet(accountID, "win")
        Dim lose As Decimal = getSumWLBet(accountID, "lose")

        Return CDbl(totalPoints + (win - lose))

    End Function

    Private Function getRankLogo(ByVal accountID As String) As Image
        'GET THE RANK BASED FROM POINTSget
            Dim mydata As DataTable = mysql.Query("select * from tblaccount_activity_rank where " + IIf(pbPoints = "", "0", pbPoints) + " <= tPoints and " + IIf(pbPoints = "", "0", pbPoints) + " >= fPoints")
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

    Private Function getProfilePlayer(ByVal accountID As String, Optional ByVal type As String = "")
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=" + accountID.ToString)
        If mydata.Rows.Count > 0 Then
            Try '
                If type = "" Then
                    Return Image.FromFile(Application.StartupPath + "\" + mydata.Rows(0).Item("picture").ToString.Replace("~", "\"))
                Else
                    Return mydata.Rows(0).Item("firstname") + " " + mydata.Rows(0).Item("lastname")
                End If

            Catch ex As Exception
                If type = "" Then
                    Return My.Resources.profile_icon1
                Else
                    Return ""
                End If

            End Try

        End If
    End Function

#Region "HOME PAGE"

#Region "NEWSFEED"

    Public Declare Function GetScrollRange Lib "user32" (ByVal hwnd As Long, ByVal nBar As Long, ByVal lpMinPos As Long, ByVal lpMaxPos As Long) As Long
    Public Declare Function GetScrollPos Lib "user32" (ByVal hwnd As Long, ByVal nBar As Long) As Long

    Private Sub flpNewsFeed_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles flpNewsFeed.Scroll
        sender.focus()
    End Sub

    Private Sub FlowLayoutPanel1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles flpNewsFeed.SizeChanged
        'Panel28.Width = flpNewsFeed.Width
    End Sub

    Private Function createTopWinnerTable()
        Dim mytable As New PowerNET8.myDataTableCreator
        With mytable
            .new_table("tblWinner")
            .add_columnField("accountID")
            .add_columnField("totalWInner", PowerNET8.myDataTableCreator.FieldType.Integer_)
            Return .get_table
        End With
    End Function

    Private Sub validateIfAccountExist(ByVal tbl As DataTable, ByVal passValue As String, ByVal total As Integer)
        Dim blnFound As Boolean = False
        For i As Integer = 0 To tbl.Rows.Count - 1
            If tbl.Rows(i).Item("accountID") = passValue Then
                tbl.Rows(i).Item("totalWinner") = tbl.Rows(i).Item("totalWinner") + total
                blnFound = True
                Exit For
            End If
        Next
        If Not blnFound Then
            tbl.Rows.Add()
            tbl.Rows(tbl.Rows.Count - 1).Item("accountID") = passValue
            tbl.Rows(tbl.Rows.Count - 1).Item("totalWinner") = total
        End If
    End Sub

    Private Sub reloadTop3Winner()
        Dim mydata As DataTable = mysql.Query("select accountID_A,count(accountID_A) from tblaccount_battle where status_A='win' and dtBattle between '" + Now.Year.ToString + "-" + Now.Month.ToString + "-1 0:0:0' and '" + Now.Year.ToString + "-" + Now.Month.ToString + "-31 23:59:59' group By accountID_A ")
        Dim tblWinner As DataTable = createTopWinnerTable()
        For i As Integer = 0 To mydata.Rows.Count - 1
            validateIfAccountExist(tblWinner, mydata.Rows(i).Item(0), mydata.Rows(i).Item(1))
        Next

        'SECOND COLUMN
        mydata = mysql.Query("select accountID_B,count(accountID_B) from tblaccount_battle where status_B='win' and dtBattle between '" + Now.Year.ToString + "-" + Now.Month.ToString + "-1 0:0:0' and '" + Now.Year.ToString + "-" + Now.Month.ToString + "-31 23:59:59' group By accountID_B ")
        For i As Integer = 0 To mydata.Rows.Count - 1
            validateIfAccountExist(tblWinner, mydata.Rows(i).Item(0), mydata.Rows(i).Item(1))
        Next

        Dim dv As New DataView(tblWinner)
        dv.Sort = "totalWinner desc"

        tblWinner = dv.ToTable

        For i As Integer = 0 To tblWinner.Rows.Count - 1
            Select Case i
                Case 0
                    pc1Winner.Image = getProfilePlayer(tblWinner.Rows(i).Item("accountID"))
                    lbl1WinnerName.Text = getProfilePlayer(tblWinner.Rows(i).Item("accountID"), "name")

                    If tblWinner.Rows(i).Item("totalWInner") > 1 Then
                        lbl1Winner.Text = FormatNumber(tblWinner.Rows(i).Item("totalWInner"), 0) + " Wins"
                    Else
                        lbl1Winner.Text = FormatNumber(tblWinner.Rows(i).Item("totalWInner"), 0) + " Win"
                    End If

                Case 1
                    pc2Winner.Image = getProfilePlayer(tblWinner.Rows(i).Item("accountID"))
                    lbl2WinnerName.Text = getProfilePlayer(tblWinner.Rows(i).Item("accountID"), "name")

                    If tblWinner.Rows(i).Item("totalWInner") > 1 Then
                        lbl2Winner.Text = FormatNumber(tblWinner.Rows(i).Item("totalWInner"), 0) + " Wins"
                    Else
                        lbl2Winner.Text = FormatNumber(tblWinner.Rows(i).Item("totalWInner"), 0) + " Win"
                    End If

                Case 2
                    pc3Winner.Image = getProfilePlayer(tblWinner.Rows(i).Item("accountID"))
                    lbl3WinnerName.Text = getProfilePlayer(tblWinner.Rows(i).Item("accountID"), "name")

                    If tblWinner.Rows(i).Item("totalWInner") > 1 Then
                        lbl3Winner.Text = FormatNumber(tblWinner.Rows(i).Item("totalWInner"), 0) + " Wins"
                    Else
                        lbl3Winner.Text = FormatNumber(tblWinner.Rows(i).Item("totalWInner"), 0) + " Win"
                    End If

                Case Else
                    Exit For
            End Select
        Next

    End Sub

    Private Sub reloadNewsFeed()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount_newsfeed  order by dateUpdate desc limit 0,10")
        flpNewsFeed.Controls.Clear()

        If mydata.Rows.Count > 0 Then
            For i As Integer = 0 To mydata.Rows.Count - 1
                Select Case mydata.Rows(i).Item("type").ToString.ToLower
                    Case "slot machine"
                        Dim getName As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=" + mydata.Rows(i).Item("accountID").ToString)
                        Dim fullname As String = getName.Rows(0).Item("firstname") + " " + getName.Rows(0).Item("middlename") + " " + getName.Rows(0).Item("lastname")
                        Dim rep As String = getName.Rows(0).Item("firstname") + " " + mydata.Rows(i).Item("description").ToString.Replace("~", "")

                        Dim pcActivityPicture As Image = Image.FromFile(Application.StartupPath + "\Images\System\Lottery\newsfeed_slot.png")

                        Dim points() As String = mydata.Rows(i).Item("slotItemReceived").ToString.Split(",")
                        Dim exp() As String = points(0).Split("~")
                        Dim tp() As String = points(1).Split("~")
                        Dim ticket() As String = points(2).Split("~")
                        Dim MessageDialog As String = rep + " And selected an item of (" + mydata.Rows(i).Item("slotMachine") + ") with the points of EXP/s x " + exp(1) + ", TP/s x " + tp(1) + " and Ticket/s x " + ticket(1) + "."
                        Dim picture As String = "Images\System\Default\profile_icon1.jpg"
                        If Not IsDBNull(getName.Rows(0).Item("picture")) Then
                            picture = getName.Rows(0).Item("picture")
                        End If

                        create_NewsFeed(flpNewsFeed, mydata.Rows(i).Item("accountID"), picture, fullname, pcActivityPicture, MessageDialog, mydata.Rows(i).Item("dateUpdate"))
                    Case "rank"
                        Dim getName As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=" + mydata.Rows(i).Item("accountID").ToString)
                        Dim fullname As String = getName.Rows(0).Item("firstname") + " " + getName.Rows(0).Item("middlename") + " " + getName.Rows(0).Item("lastname")
                        Dim rep As String = getName.Rows(0).Item("firstname") + " " + mydata.Rows(i).Item("description").ToString.Replace("~", "")


                        Dim MessageDialog As String = getName.Rows(0).Item("firstname") + " " + mydata.Rows(i).Item("description").ToString.Replace("~", "")

                        Dim picture As String = "Images\System\Default\profile_icon1.jpg"
                        If Not IsDBNull(getName.Rows(0).Item("picture")) Then
                            picture = getName.Rows(0).Item("picture")
                        End If

                        If mydata.Rows(i).Item("name") = "Rank Promoted" Then
                            create_NewsFeed(flpNewsFeed, mydata.Rows(i).Item("accountID"), picture, fullname, GetRankFromNewsfeed(mydata.Rows(i).Item("rank_to"), "up"), MessageDialog, mydata.Rows(i).Item("dateUpdate"))
                        Else
                            create_NewsFeed(flpNewsFeed, mydata.Rows(i).Item("accountID"), picture, fullname, GetRankFromNewsfeed(mydata.Rows(i).Item("rank_to"), "down"), MessageDialog, mydata.Rows(i).Item("dateUpdate"))
                        End If
                    Case "gift rewards"
                        Dim getName As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=" + mydata.Rows(i).Item("accountID").ToString)
                        Dim fullname As String = getName.Rows(0).Item("firstname") + " " + getName.Rows(0).Item("middlename") + " " + getName.Rows(0).Item("lastname")
                        Dim rep As String = getName.Rows(0).Item("firstname") + " " + mydata.Rows(i).Item("description").ToString.Replace("~", "")

                        Dim MessageDialog As String = getName.Rows(0).Item("firstname") + " " + mydata.Rows(i).Item("description").ToString.Replace("~", "")
                        Dim imageChest As Image
                        Select Case mydata.Rows(i).Item("giftChest")
                            Case 1
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\Day 1.png")
                            Case 2
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\Day 2.png")
                            Case 3
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\Day 3.png")
                            Case 4
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\Day 4.png")
                            Case 5
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\Day 5.png")
                            Case 6
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\Day 6.png")
                            Case 7
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\Day 7.png")
                            Case Else
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\gift reward.png")
                        End Select

                        Dim picture As String = "Images\System\Default\profile_icon1.jpg"
                        If Not IsDBNull(getName.Rows(0).Item("picture")) Then
                            picture = getName.Rows(0).Item("picture")
                        End If

                        create_NewsFeed(flpNewsFeed, mydata.Rows(i).Item("accountID"), picture, fullname, imageChest, MessageDialog, mydata.Rows(i).Item("dateUpdate"))
                    Case "battle"
                        Dim getName As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=" + mydata.Rows(i).Item("accountID").ToString)
                        Dim fullname As String = getName.Rows(0).Item("firstname") + " " + getName.Rows(0).Item("middlename") + " " + getName.Rows(0).Item("lastname")
                        Dim rep As String = getName.Rows(0).Item("firstname") + " " + mydata.Rows(i).Item("description").ToString.Replace("~", "")

                        Dim MessageDialog As String = getName.Rows(0).Item("firstname") + " " + mydata.Rows(i).Item("description").ToString.Replace("~", "")
                        Dim imageChest As Image
                        Select Case mydata.Rows(i).Item("name")
                            Case "Victory"
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Default\win.png")
                            Case "Lose"
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Default\lose.png")
                        End Select

                        Dim picture As String = "Images\System\Default\profile_icon1.jpg"
                        If Not IsDBNull(getName.Rows(0).Item("picture")) Then
                            picture = getName.Rows(0).Item("picture")
                        End If

                        create_NewsFeed(flpNewsFeed, mydata.Rows(i).Item("accountID"), picture, fullname, imageChest, MessageDialog, mydata.Rows(i).Item("dateUpdate"))
                End Select
                'Exit For
            Next
            createLoadFooterNewsFeed(flpNewsFeed)
        End If
    End Sub

    Private Function GetRankFromNewsfeed(ByVal rankID As String, Optional ByVal stat As String = "up") As Image
        ' rankID = 1
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount_activity_rank where rankID=" + rankID)
        If mydata.Rows.Count > 0 Then
            If stat = "up" Then
                Dim pbImage() As Byte = mydata.Rows(0).Item("rankLogoUp")
                Dim frmImageView As New System.IO.MemoryStream(pbImage)
                Return Image.FromStream(frmImageView)
            Else
                Dim pbImage() As Byte = mydata.Rows(0).Item("rankLogoDown")
                Dim frmImageView As New System.IO.MemoryStream(pbImage)
                Return Image.FromStream(frmImageView)
            End If
        Else
            Return Nothing
        End If
    End Function

    Private BackColor As Color = Color.Black
    Private BackColor_Inner As Color = Color.FromArgb(26, 26, 26)
    Private BackCOlor_Inner_Inner As Color = Color.FromArgb(40, 40, 40)
    Private ForeColor As Color = Color.White
    Private ForeColor_Selected As Color = Color.Red
    Private ForeColor_Highlight As Color = Color.Orange
    Private ForeColor_Link As Color = Color.Orange
    Private TextBox_BackColor As Color = Color.FromArgb(40, 40, 40)
    Private TextBox_BackColor_Focus As Color = Color.Black

    Private Sub loadNewsFeedMore(ByRef sender As Object)

        Dim page As Integer = flpNewsFeed.Tag
        page += 1

        page = page * 10
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount_newsfeed where accountID=1 order by dateUpdate desc limit " + page.ToString + ",10")
        If mydata.Rows.Count > 0 Then
            flpNewsFeed.Tag = Val(flpNewsFeed.Tag) + 1
            For i As Integer = 0 To mydata.Rows.Count - 1
                Select Case mydata.Rows(i).Item("type").ToString.ToLower
                    Case "slot machine"
                        Dim getName As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=1")
                        Dim fullname As String = getName.Rows(0).Item("firstname") + " " + getName.Rows(0).Item("middlename") + " " + getName.Rows(0).Item("lastname")
                        Dim rep As String = getName.Rows(0).Item("firstname") + " " + mydata.Rows(i).Item("description").ToString.Replace("~", "")

                        Dim pcActivityPicture As Image = Image.FromFile(Application.StartupPath + "\Images\System\Lottery\newsfeed_slot.png")

                        Dim points() As String = mydata.Rows(i).Item("slotItemReceived").ToString.Split(",")
                        Dim exp() As String = points(0).Split("~")
                        Dim tp() As String = points(1).Split("~")
                        Dim ticket() As String = points(2).Split("~")
                        Dim MessageDialog As String = rep + " And selected an item of (" + mydata.Rows(i).Item("slotMachine") + ") with the points of EXP/s x " + exp(1) + ", TP/s x " + tp(1) + " and Ticket/s x " + ticket(1) + "."

                        Dim picture As String = "Images\System\Default\profile_icon1.jpg"
                        If Not IsDBNull(getName.Rows(0).Item("picture")) Then
                            picture = getName.Rows(0).Item("picture")
                        End If
                        create_NewsFeed(flpNewsFeed, mydata.Rows(i).Item("accountID"), picture, fullname, pcActivityPicture, MessageDialog, mydata.Rows(i).Item("dateUpdate"))
                    Case "rank"
                        Dim getName As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=1")
                        Dim fullname As String = getName.Rows(0).Item("firstname") + " " + getName.Rows(0).Item("middlename") + " " + getName.Rows(0).Item("lastname")
                        Dim rep As String = getName.Rows(0).Item("firstname") + " " + mydata.Rows(i).Item("description").ToString.Replace("~", "")


                        Dim MessageDialog As String = getName.Rows(0).Item("firstname") + " " + mydata.Rows(i).Item("description").ToString.Replace("~", "")

                        Dim picture As String = "Images\System\Default\profile_icon1.jpg"
                        If Not IsDBNull(getName.Rows(0).Item("picture")) Then
                            picture = getName.Rows(0).Item("picture")
                        End If

                        If mydata.Rows(i).Item("name") = "Rank Promoted" Then
                            create_NewsFeed(flpNewsFeed, mydata.Rows(i).Item("accountID"), picture, fullname, GetRankFromNewsfeed(mydata.Rows(i).Item("rank_to"), "up"), MessageDialog, mydata.Rows(i).Item("dateUpdate"))
                        Else
                            create_NewsFeed(flpNewsFeed, mydata.Rows(i).Item("accountID"), picture, fullname, GetRankFromNewsfeed(mydata.Rows(i).Item("rank_to"), "down"), MessageDialog, mydata.Rows(i).Item("dateUpdate"))
                        End If
                    Case "gift rewards"
                        Dim getName As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=1")
                        Dim fullname As String = getName.Rows(0).Item("firstname") + " " + getName.Rows(0).Item("middlename") + " " + getName.Rows(0).Item("lastname")
                        Dim rep As String = getName.Rows(0).Item("firstname") + " " + mydata.Rows(i).Item("description").ToString.Replace("~", "")

                        Dim MessageDialog As String = getName.Rows(0).Item("firstname") + " " + mydata.Rows(i).Item("description").ToString.Replace("~", "")
                        Dim imageChest As Image
                        Select Case mydata.Rows(i).Item("giftChest")
                            Case 1
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\Day 1.png")
                            Case 2
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\Day 2.png")
                            Case 3
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\Day 3.png")
                            Case 4
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\Day 4.png")
                            Case 5
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\Day 5.png")
                            Case 6
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\Day 6.png")
                            Case 7
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\Day 7.png")
                            Case Else
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Gift Rewards\gift reward.png")
                        End Select

                        Dim picture As String = "Images\System\Default\profile_icon1.jpg"
                        If Not IsDBNull(getName.Rows(0).Item("picture")) Then
                            picture = getName.Rows(0).Item("picture")
                        End If
                        create_NewsFeed(flpNewsFeed, mydata.Rows(i).Item("accountID"), picture, fullname, imageChest, MessageDialog, mydata.Rows(i).Item("dateUpdate"))

                    Case "battle"
                        Dim getName As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=" + mydata.Rows(i).Item("accountID").ToString)
                        Dim fullname As String = getName.Rows(0).Item("firstname") + " " + getName.Rows(0).Item("middlename") + " " + getName.Rows(0).Item("lastname")
                        Dim rep As String = getName.Rows(0).Item("firstname") + " " + mydata.Rows(i).Item("description").ToString.Replace("~", "")

                        Dim MessageDialog As String = getName.Rows(0).Item("firstname") + " " + mydata.Rows(i).Item("description").ToString.Replace("~", "")
                        Dim imageChest As Image
                        Select Case mydata.Rows(i).Item("name")
                            Case "Victory"
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Default\win.png")
                            Case "Lose"
                                imageChest = Image.FromFile(Application.StartupPath + "\Images\System\Default\lose.png")
                        End Select

                        Dim picture As String = "Images\System\Default\profile_icon1.jpg"
                        If Not IsDBNull(getName.Rows(0).Item("picture")) Then
                            picture = getName.Rows(0).Item("picture")
                        End If

                        create_NewsFeed(flpNewsFeed, mydata.Rows(i).Item("accountID"), picture, fullname, imageChest, MessageDialog, mydata.Rows(i).Item("dateUpdate"))

                End Select
                'Exit For
            Next
            createLoadFooterNewsFeed(flpNewsFeed)
        Else

        End If

    End Sub

    Private Sub create_NewsFeed(ByRef control As FlowLayoutPanel, ByVal id As String, ByVal ProfilePictureLoc As String, ByVal Name As String, ByVal PictureUpdate As Image, ByVal message As String, ByVal time As DateTime)
        Dim MainPanel As New Panel
        With MainPanel
            .BackColor = BackColor_Inner
            .Dock = DockStyle.None
            .Width = 490
            .Height = 350
            .Padding = New Padding(5)
        End With

        'Create A TableLeftMost
        Dim BelowProfilePicture As New TableLayoutPanel
        With BelowProfilePicture
            .BackColor = Color.Transparent
            .RowCount = 2
            .RowStyles.Add(New RowStyle(SizeType.Percent, 100%))
            .RowStyles.Add(New RowStyle(SizeType.Absolute, 23))
        End With

        'Create TableLayout
        Dim MainTableLayout As New TableLayoutPanel
        With MainTableLayout
            .ColumnCount = 2
            .RowCount = 4
            .Dock = DockStyle.Fill
            .BackColor = BackColor_Inner
            .ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 75))
            .RowStyles.Add(New RowStyle(SizeType.Absolute, 100))
            .RowStyles.Add(New RowStyle(SizeType.Absolute, 42))
            .RowStyles.Add(New RowStyle(SizeType.Absolute, 150))
            .RowStyles.Add(New RowStyle(SizeType.Absolute, 33))
            .Controls.Add(BelowProfilePicture, 0, 0)
        End With

        'add Panel under profile Picture
        Dim underProfile As New Panel
        With underProfile
            .Dock = DockStyle.Fill
            .BackColor = Color.Transparent
            BelowProfilePicture.Controls.Add(underProfile, 0, 1)
        End With

        'add rank from Profile Picture

        Dim rnPoints As Decimal = getRankPoints(id)

        Dim rankProfilePicture As New PictureBox
        With rankProfilePicture
            .Dock = DockStyle.Left
            .Width = 18
            .BackColor = Color.Transparent
            .Image = getRankLogo_Selected(id, rnPoints)
            .SizeMode = PictureBoxSizeMode.Zoom
            underProfile.Controls.Add(rankProfilePicture)
        End With
        'add rank label
        Dim lblRanklabelProfile As New Label
        With lblRanklabelProfile
            .BackColor = Color.Transparent
            .Left = 19
            .Top = 4
            Dim oldFont2 As Font = New Font(.Font.FontFamily, 6.25, FontStyle.Regular, .Font.Unit)
            .Font = oldFont2
            .ForeColor = ForeColor
            .Text = getRankPosition_Selected(id, rnPoints)
            underProfile.Controls.Add(lblRanklabelProfile)
        End With

        'Add Picture From Left
        Dim profilePicture As New PictureBox
        With profilePicture
            .Width = 70
            .Height = 66
            .SizeMode = PictureBoxSizeMode.Zoom
            .BackColor = BackColor
            .ImageLocation = Application.StartupPath + "\" + ProfilePictureLoc.ToString.Replace("~", "\")
            BelowProfilePicture.Controls.Add(profilePicture, 0, 0)
        End With

        'Create A Table (0,1)
        Dim RightTopTableLayout As New TableLayoutPanel
        With RightTopTableLayout
            .Dock = DockStyle.Fill
            .BackColor = BackColor_Inner
            .RowStyles.Add(New RowStyle(SizeType.Absolute, 20))

            MainPanel.Controls.Add(MainTableLayout)
            MainTableLayout.Controls.Add(RightTopTableLayout, 1, 0)
        End With

        'Add Full Name
        Dim lblName As New Label
        With lblName
            Dim oldFont As Font = New Font(.Font.FontFamily, 8.25, FontStyle.Bold, .Font.Unit)
            .Font = oldFont
            .ForeColor = ForeColor_Link
            .Cursor = Cursors.Hand
            .Text = "FULL NAME"
            .Text = Name
            .AutoSize = False
            .Width = MainPanel.Width - 75
            .Dock = DockStyle.None
            .TextAlign = ContentAlignment.MiddleLeft
            .Tag = id
            AddHandler .Click, AddressOf NewsFeed_ProfileName_Click
            AddHandler .MouseUp, AddressOf NewsFeed_ProfileName_MouseUp
            AddHandler .MouseMove, AddressOf NewsFeed_ProfileName_MouseMove
            AddHandler .MouseDown, AddressOf NewsFeed_ProfileName_MouseDown
            AddHandler .MouseLeave, AddressOf NewsFeed_ProfileName_MouseLeave
        End With
        RightTopTableLayout.Controls.Add(lblName, 0, 0)

        'Create TableLayout below the NAME
        Dim BelowTheNameTableLayOut As New TableLayoutPanel
        With BelowTheNameTableLayOut
            .BackColor = BackColor_Inner
            .Dock = DockStyle.Fill
            .ColumnCount = 2
            .ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 65))
            RightTopTableLayout.Controls.Add(BelowTheNameTableLayOut, 0, 1)
        End With

        'Create Picture Update Box
        Dim PictureUpdateBox As New PictureBox
        With PictureUpdateBox
            .BackColor = Color.Transparent
            .SizeMode = PictureBoxSizeMode.Zoom
            .Image = PictureUpdate
            .Width = 59
            .Height = 55
            BelowTheNameTableLayOut.Controls.Add(PictureUpdateBox, 0, 0)
        End With

        'create a message LAbel
        Dim lblMessage As New Label
        With lblMessage
            .ForeColor = ForeColor
            .BackColor = Color.Transparent
            .AutoSize = False
            .Width = 343
            .Height = 61
            .Text = message
            BelowTheNameTableLayOut.Controls.Add(lblMessage, 1, 0)
        End With

        'Create a New PanEL FOR like, share, comment
        Dim LikeShareCommentPanel As New Panel
        With LikeShareCommentPanel
            .Dock = DockStyle.Right
            .BackColor = BackColor_Inner
            .Width = 337

            MainTableLayout.Controls.Add(LikeShareCommentPanel, 1, 1)
        End With
        'create a time post
        Dim lblTime As New Label
        With lblTime
            Dim oldFont As Font = New Font(.Font.FontFamily, 8.25, FontStyle.Italic, .Font.Unit)
            .Font = oldFont
            .AutoSize = False
            .SendToBack()
            .Height = 15
            .ForeColor = ForeColor
            .Width = 200
            .Left = 137
            .Text = getPostDate(time)
            .TextAlign = ContentAlignment.TopRight
            LikeShareCommentPanel.Controls.Add(lblTime)
        End With
        'create SHARE button
        Dim lblShare As New LinkLabel
        With lblShare
            Dim oldFont As Font = New Font(.Font.FontFamily, 8.25, FontStyle.Bold, .Font.Unit)
            .Font = oldFont
            .LinkColor = ForeColor_Link
            .Text = "Share"
            .Left = 296
            .Top = 20
            AddHandler .Click, AddressOf NewsFeed_Share_Click
            AddHandler .MouseMove, AddressOf NewsFeed_ProfileName_MouseMove
            AddHandler .MouseLeave, AddressOf NewsFeed_ProfileName_MouseLeave
            LikeShareCommentPanel.Controls.Add(lblShare)
        End With
        'create Comment button
        Dim lblComment As New LinkLabel
        With lblComment
            Dim oldFont As Font = New Font(.Font.FontFamily, 8.25, FontStyle.Bold, .Font.Unit)
            .Font = oldFont
            .LinkColor = ForeColor_Link
            .Text = "Comment"
            .Left = 230
            .Top = 20
            .Tag = "open"
            AddHandler .Click, AddressOf NewsFeed_Comment_Click
            AddHandler .MouseMove, AddressOf NewsFeed_ProfileName_MouseMove
            AddHandler .MouseLeave, AddressOf NewsFeed_ProfileName_MouseLeave
            LikeShareCommentPanel.Controls.Add(lblComment)
        End With

        NewsFeed_Comment_Click(lblComment, Nothing)
        NewsFeed_Comment_Click(lblComment, Nothing)

        'create like button
        Dim lblLike As New LinkLabel
        With lblLike
            Dim oldFont As Font = New Font(.Font.FontFamily, 8.25, FontStyle.Bold, .Font.Unit)
            .Font = oldFont
            .LinkColor = ForeColor_Link
            .AutoSize = False

            .TextAlign = ContentAlignment.MiddleRight
            .Text = "Like"
            .Width = 50
            .Left = 171
            .Top = 15
            AddHandler .Click, AddressOf NewsFeed_Like_Click
            AddHandler .MouseMove, AddressOf NewsFeed_ProfileName_MouseMove
            AddHandler .MouseLeave, AddressOf NewsFeed_ProfileName_MouseLeave
            LikeShareCommentPanel.Controls.Add(lblLike)
        End With
        'create playnow button
        Dim lblPlayNow As New Label
        With lblPlayNow
            .AutoSize = False
            Dim oldFont As Font = New Font(.Font.FontFamily, 8.25, FontStyle.Bold, .Font.Unit)
            .Font = oldFont
            .ForeColor = ForeColor_Link
            .Cursor = Cursors.Hand
            .TextAlign = ContentAlignment.MiddleLeft
            .Text = "GET NOW"
            .Width = 80
            .Left = -2
            .Top = 0
            .BringToFront()
            AddHandler .Click, AddressOf NewsFeed_PlayNow_Click
            AddHandler .MouseMove, AddressOf NewsFeed_ProfileName_MouseMove
            AddHandler .MouseLeave, AddressOf NewsFeed_ProfileName_MouseLeave
            LikeShareCommentPanel.Controls.Add(lblPlayNow)
        End With

        'Create Flow Layout Panel For Comments
        Dim flpComments As New FlowLayoutPanel
        With flpComments
            .Dock = DockStyle.Fill
            .AutoScroll = True
            .BackColor = BackCOlor_Inner_Inner
            MainTableLayout.Controls.Add(flpComments, 1, 2)
        End With


        createListOfComments(flpComments)


        'Footer of List of Comments
        Dim tlpfooterListComments As New TableLayoutPanel
        With tlpfooterListComments
            .ColumnCount = 3
            .Dock = DockStyle.Fill
            .BackColor = BackColor_Inner
            .ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50%))
            .ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 25))
            .ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 25))
            MainTableLayout.Controls.Add(tlpfooterListComments, 1, 3)
        End With
        'create reply textbox
        Dim txtReplyComments As New TextBox
        With txtReplyComments
            .Dock = DockStyle.Fill
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = BackCOlor_Inner_Inner
            .ForeColor = Color.White
            tlpfooterListComments.Controls.Add(txtReplyComments, 0, 0)
            AddHandler .GotFocus, AddressOf NewsFeed_GotFocus
            AddHandler .LostFocus, AddressOf NewsFeed_LostFocus
        End With

        'create Player Comment Picture
        Dim pcPlayerPictureComment As New PictureBox
        With pcPlayerPictureComment
            .Top = 0
            .Height = 20
            .Width = 20
            .BackColor = Color.Red
            .SizeMode = PictureBoxSizeMode.Zoom
            .Image = My.Resources.profile_icon1
            tlpfooterListComments.Controls.Add(pcPlayerPictureComment, 1, 0)
        End With
        'create send button
        'create small profilepicture
        Dim pcCommentSend As New PictureBox
        With pcCommentSend
            .Top = 0
            .Height = 20
            .Width = 20
            .BackColor = Color.Red
            .SizeMode = PictureBoxSizeMode.Zoom
            .Image = My.Resources.profile_icon1
            tlpfooterListComments.Controls.Add(pcCommentSend, 2, 0)
        End With

        flpNewsFeed.Controls.Add(MainPanel)


    End Sub

    Private Function getPostDate(ByVal time As DateTime) As String

        Dim lc As DateTime = Now
        Dim timeDiff As TimeSpan = lc - time
        Dim a As Integer = timeDiff.TotalSeconds
        'MsgBox(a.ToString)

        If timeDiff.TotalSeconds <= 180 Then
            Return "Few Seconds Ago"
        ElseIf Val(timeDiff.TotalSeconds) > 180 And Val(timeDiff.TotalSeconds) <= 300 Then
            Return "Few Minutes Ago"
        ElseIf Val(timeDiff.TotalMinutes) <= 59 Then
            If Val(timeDiff.TotalMinutes) = 1 Then
                Return FormatNumber(timeDiff.TotalMinutes, 0) + " minute ago"
            Else
                Return FormatNumber(timeDiff.TotalMinutes, 0) + " minutes ago"
            End If
        ElseIf Val(timeDiff.TotalHours) <= 24 Then
            If Val(timeDiff.TotalHours) = 1 Then
                Return FormatNumber(timeDiff.TotalHours, 0) + " hour ago"
            Else
                Return FormatNumber(timeDiff.TotalHours, 0) + " hours ago"
            End If
        ElseIf Val(timeDiff.TotalHours) > 24 And Val(timeDiff.TotalHours) <= 48 Then
            Return "Yesterday"
        Else
            Return time.ToString("MM/dd/yyyy hh:mm:ss tt")
        End If
    End Function

    Private Sub createListOfComments(ByRef flpComments As FlowLayoutPanel)
        'Create Panel at the 3rd ROW
        Dim PnlCommentPlayer As New Panel
        With PnlCommentPlayer
            .BackColor = BackCOlor_Inner_Inner
            .Dock = DockStyle.None
            .Width = 385
            flpComments.Controls.Add(PnlCommentPlayer)
        End With
        'create small profilepicture
        Dim pcSmallProfilePicture As New PictureBox
        With pcSmallProfilePicture
            .BackColor = Color.Transparent
            .Width = 31
            .Height = 30
            .Left = 4
            .Top = 4
            .SizeMode = PictureBoxSizeMode.Zoom
            .Image = My.Resources.profile_icon1
            PnlCommentPlayer.Controls.Add(pcSmallProfilePicture)
        End With

        'create edit icon
        Dim pcEdit As New PictureBox
        With pcEdit
            .BackColor = Color.Transparent
            .Width = 16
            .Height = 16
            .Left = 345
            .Top = 4
            .SizeMode = PictureBoxSizeMode.Zoom
            .Image = My.Resources.profile_icon1
            PnlCommentPlayer.Controls.Add(pcEdit)
        End With

        Dim pcDelete As New PictureBox
        With pcDelete
            .BackColor = Color.Transparent
            .Width = 16
            .Height = 16
            .Left = 365
            .Top = 4
            .SizeMode = PictureBoxSizeMode.Zoom
            .Image = My.Resources.profile_icon1
            PnlCommentPlayer.Controls.Add(pcDelete)
        End With


        'create small name
        Dim lblName As New Label
        With lblName
            Dim oldFont As Font = New Font(.Font.FontFamily, 8.25, FontStyle.Bold, .Font.Unit)
            .Font = oldFont
            .ForeColor = ForeColor_Link
            .Left = 36
            .Height = 13
            .Top = 4
            .Text = "Full Name Here"
            PnlCommentPlayer.Controls.Add(lblName)
        End With

        'create small rank description
        Dim lblRankDescription As New Label
        With lblRankDescription
            Dim oldFont As Font = New Font(.Font.FontFamily, 8.25, FontStyle.Italic, .Font.Unit)
            .Font = oldFont
            .ForeColor = ForeColor
            .Left = 54
            .Top = 21
            .Height = 16
            .Text = "Rank Description"
            PnlCommentPlayer.Controls.Add(lblRankDescription)
        End With

        'create small rank picture
        Dim pcSmallRankProfilePicture As New PictureBox
        With pcSmallRankProfilePicture
            .BackColor = Color.Transparent
            .Width = 16
            .Height = 16
            .Left = 39
            .Top = 18
            .SizeMode = PictureBoxSizeMode.Zoom
            .Image = My.Resources.profile_icon1
            PnlCommentPlayer.Controls.Add(pcSmallRankProfilePicture)
        End With

        'create message
        Dim lblMessage As New Label
        With lblMessage
            .ForeColor = ForeColor
            .AutoSize = False
            .TextAlign = ContentAlignment.TopLeft
            .Width = 343
            .BackColor = Color.Transparent
            .Height = 41
            .Left = 37
            .Top = 39
            .Text = "Full Name Here"
            PnlCommentPlayer.Controls.Add(lblMessage)
        End With

        'create date post
        Dim lblDate As New Label
        With lblDate
            Dim oldFont As Font = New Font(.Font.FontFamily, 8.25, FontStyle.Italic, .Font.Unit)
            .Font = oldFont
            .ForeColor = ForeColor
            .AutoSize = False
            .TextAlign = ContentAlignment.MiddleRight
            .Width = 147
            .Height = 18
            .Left = 237
            .Top = 80
            .Text = "12/12/2019"
            PnlCommentPlayer.Controls.Add(lblDate)
        End With

    End Sub

    Private Sub createLoadFooterNewsFeed(ByRef flpPanel As FlowLayoutPanel)
        'Create Panel at the 3rd ROW
        Dim PnlCommentPlayer As New Panel
        With PnlCommentPlayer
            .BackColor = BackCOlor_Inner_Inner
            .Dock = DockStyle.None
            .Width = 490
            .Height = 25
            flpPanel.Controls.Add(PnlCommentPlayer)
        End With

        Dim lblLoader As New Label
        With lblLoader
            .Text = "LOAD MORE..."
            .TextAlign = ContentAlignment.MiddleCenter
            .AutoSize = False
            .ForeColor = Color.White
            .Dock = DockStyle.Fill
            PnlCommentPlayer.Controls.Add(lblLoader)

            If flpNewsFeed.Tag Is Nothing Then
                flpNewsFeed.Tag = "0"
            End If

            AddHandler .MouseMove, AddressOf NewsFeed_LoadMore_MouseMove
        End With
    End Sub

#Region "EVENTS"

    Private Function getTime(ByVal time As DateTime) As String
        Return "Few Minutes Ago"
    End Function

    Private Sub NewsFeed_LoadMore_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.Cursor = Cursors.WaitCursor
        flpNewsFeed.Controls.RemoveAt(flpNewsFeed.Controls.Count - 1)
        loadNewsFeedMore(sender)
    End Sub

    Private Sub NewsFeed_ProfileName_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor

        If Val(sender.tag) > 0 Then
            reloadProfileInformation(sender.tag)
            reloadProfileInformation(sender.tag)
            utcHome.Tabs(1).Visible = True
            utcHome.Tabs(1).Selected = True
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub NewsFeed_ProfileName_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        sender.forecolor = ForeColor_Selected
    End Sub

    Private Sub NewsFeed_ProfileName_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.forecolor = ForeColor_Link
    End Sub

    Private Sub NewsFeed_ProfileName_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        sender.forecolor = ForeColor_Highlight
    End Sub

    Private Sub NewsFeed_ProfileName_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        sender.forecolor = ForeColor_Highlight
    End Sub

    Private Sub NewsFeed_Comment_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim control As Object = sender.parent.parent
        Dim a = CType(control, TableLayoutPanel).RowCount
        Select Case sender.tag
            Case "open"
                CType(control, TableLayoutPanel).RowStyles(2).Height = 125
                CType(control, TableLayoutPanel).RowStyles(3).Height = 33
                control.parent.height = 310
                sender.tag = "close"
            Case "close"
                control.RowStyles(2).Height = 0
                control.RowStyles(3).Height = 0
                control.parent.height = 150
                sender.tag = "open"
        End Select
    End Sub

    Private Sub NewsFeed_Share_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        '  MsgBox("comment:" + sender.tag)
    End Sub

    Private Sub NewsFeed_Like_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MsgBox("Like:" + sender.tag)
    End Sub

    Private Sub NewsFeed_PlayNow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MsgBox("Play Now:" + sender.tag)
    End Sub

    Private Sub NewsFeed_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.readonly = False Then
            sender.backcolor = TextBox_BackColor_Focus
        End If
    End Sub

    Private Sub NewsFeed_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.readonly = False Then
            sender.backcolor = TextBox_BackColor
        End If
    End Sub

#End Region

#End Region

    Private Sub recentGames()
        Dim mydata As DataTable = mysql.Query("SELECT tblgamedata.gameID, coverPhoto, gameName, platforms, gameType, dtCreated  FROM  tblgamedata_imageloc  INNER JOIN  tblgamedata   ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) order by dtCreated desc limit 0,10")
        flpRecentGames.Controls.Clear()
        If mydata.Rows.Count - 1 Then
            For i As Integer = 0 To mydata.Rows.Count - 1
                Dim dt As DateTime = mydata.Rows(i).Item("dtCreated")
                createRecentGames(flpRecentGames, _
                                  mydata.Rows(i).Item("gameID"), _
                                  mydata.Rows(i).Item("coverPhoto"), _
                                  mydata.Rows(i).Item("gameName"), _
                                  mydata.Rows(i).Item("gameType"), _
                                  mydata.Rows(i).Item("platforms"), _
                                   "Date Released: " + dt.ToString("MM/dd/yyyy"))
            Next
        End If

    End Sub

    Private Sub MostPopularGames()
        Me.Cursor = Cursors.WaitCursor
        Dim mydata As DataTable = mysql.Query("SELECT tblgamedata.gameID,coverPhoto, gamename,gameType,platforms, count(typeval) as 'playedTimes' FROM  tblgamedata_imageloc  INNER JOIN  tblgamedata      ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) INNER JOIN  tblaccount_activity    ON (tblaccount_activity.gameID = tblgamedata.gameID) where typeval='start_play' group by gamename order by playedTimes desc limit 0,15")
        flpMostPopularGames.Controls.Clear()
        If mydata.Rows.Count - 1 Then
            For i As Integer = 0 To mydata.Rows.Count - 1
                createRecentGames(flpMostPopularGames, _
                                  mydata.Rows(i).Item("gameID"), _
                                  mydata.Rows(i).Item("coverPhoto"), _
                                  mydata.Rows(i).Item("gameName"), _
                                  mydata.Rows(i).Item("gameType"), _
                                  mydata.Rows(i).Item("platforms"), _
                                  "Played Times: " + FormatNumber(mydata.Rows(i).Item("playedTimes"), 0))
            Next
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MostRequestedGames()
        Me.Cursor = Cursors.WaitCursor
        Dim mydata As DataTable = mysql.Query("SELECT tblgamedata.gameID, coverPhoto, gamename, gametype, platforms, count(tblaccount_favorite_games.dtCreated) as 'totalFavorite'  FROM   tblgamedata_imageloc  INNER JOIN  tblgamedata     ON (tblgamedata_imageloc.gameID = tblgamedata.gameID)  INNER JOIN  tblaccount_favorite_games     ON (tblaccount_favorite_games.gameID = tblgamedata.gameID) group by gamename order by totalFavorite desc limit 0,15")
        flpMostRequested.Controls.Clear()
        If mydata.Rows.Count - 1 Then
            For i As Integer = 0 To mydata.Rows.Count - 1
                createRecentGames(flpMostRequested, _
                                  mydata.Rows(i).Item("gameID"), _
                                  mydata.Rows(i).Item("coverPhoto"), _
                                  mydata.Rows(i).Item("gameName"), _
                                  mydata.Rows(i).Item("gameType"), _
                                  mydata.Rows(i).Item("platforms"), _
                                  "Favorites: " + FormatNumber(mydata.Rows(i).Item("totalFavorite"), 0))
            Next
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub recentGames_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim gameID As Integer = 0

        If TypeOf sender Is Panel Then
            gameID = sender.tag
        Else
            gameID = sender.parent.tag
        End If

        Dim frm As New lblDesigners
        With frm
            .gameid = gameID
            .Text = "Profile Game"
            .ShowDialog()
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub recentGames_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf sender Is Label Then

            sender.parent.backcolor = Color.FromArgb(64, 64, 64)
        ElseIf TypeOf sender Is PictureBox Then

            sender.parent.backcolor = Color.FromArgb(64, 64, 64)
        Else

            sender.backcolor = Color.FromArgb(64, 64, 64)
        End If
    End Sub

    Private Sub recentGames_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If TypeOf sender Is Label Then
            CType(sender.parent, Panel).Cursor = Cursors.Hand
            sender.parent.backcolor = Color.FromArgb(21, 21, 21)
        ElseIf TypeOf sender Is PictureBox Then
            CType(sender.parent, Panel).Cursor = Cursors.Hand
            sender.parent.backcolor = Color.FromArgb(21, 21, 21)
        Else
            CType(sender, Panel).Cursor = Cursors.Hand
            sender.backcolor = Color.FromArgb(21, 21, 21)
        End If
    End Sub

    Private Sub createRecentGames(ByRef flpRecentGames As FlowLayoutPanel, ByVal gameID As String, ByVal imageLoc As String, ByVal gameName As String, ByVal genre As String, ByVal platform As String, ByVal dtCreated As String)
        Dim pnlBody As New Panel
        With pnlBody
            .BackColor = Color.FromArgb(64, 64, 64)
            .Width = 153
            .Height = 194
            .Tag = gameID
            flpRecentGames.Controls.Add(pnlBody)
            AddHandler .Click, AddressOf recentGames_Click
            AddHandler .MouseMove, AddressOf recentGames_MouseMove
            AddHandler .MouseLeave, AddressOf recentGames_MouseLeave
        End With

        Dim pcPicture As New PictureBox
        With pcPicture
            .Image = Image.FromFile(Application.StartupPath + "\" + imageLoc.Replace("~", "\"))
            .Width = 105
            .Height = 100
            .Left = 24
            .Top = 7
            .SizeMode = PictureBoxSizeMode.Zoom
            pnlBody.Controls.Add(pcPicture)
            AddHandler .Click, AddressOf recentGames_Click
            AddHandler .MouseMove, AddressOf recentGames_MouseMove
            AddHandler .MouseLeave, AddressOf recentGames_MouseLeave
        End With

        Dim lblGameName As New Label
        With lblGameName
            .ForeColor = Color.White
            .AutoSize = False
            .Left = 4
            .TextAlign = ContentAlignment.MiddleCenter
            .Top = 108
            .Width = 143
            .Height = 23
            Dim oldFont2 As Font = New Font(.Font.FontFamily, 8.25, FontStyle.Bold, .Font.Unit)
            .Font = oldFont2
            .Text = gameName
            pnlBody.Controls.Add(lblGameName)
            AddHandler .Click, AddressOf recentGames_Click
            AddHandler .MouseMove, AddressOf recentGames_MouseMove
            AddHandler .MouseLeave, AddressOf recentGames_MouseLeave
        End With

        Dim lblGenre As New Label
        With lblGenre
            .ForeColor = Color.White
            .Left = 5
            .Top = 132
            .Width = 140
            .AutoSize = False
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "Genre: " + genre
            pnlBody.Controls.Add(lblGenre)
            AddHandler .Click, AddressOf recentGames_Click
            AddHandler .MouseMove, AddressOf recentGames_MouseMove
            AddHandler .MouseLeave, AddressOf recentGames_MouseLeave
        End With

        Dim lblPlatform As New Label
        With lblPlatform
            .ForeColor = Color.White
            .Left = 5
            .Top = 148
            .Width = 140
            .AutoSize = False
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "Platforms: " + platform
            pnlBody.Controls.Add(lblPlatform)
            AddHandler .Click, AddressOf recentGames_Click
            AddHandler .MouseMove, AddressOf recentGames_MouseMove
            AddHandler .MouseLeave, AddressOf recentGames_MouseLeave
        End With

        Dim lblDt As New Label
        With lblDt
            .ForeColor = Color.White
            .Left = 5
            .Top = 175
            .AutoSize = False
            .Width = 140
            .Height = 50
            .TextAlign = ContentAlignment.TopCenter
            Dim oldFont3 As Font = New Font(.Font.FontFamily, 7.25, FontStyle.Italic, .Font.Unit)
            .Font = oldFont3
            .Text = dtCreated
            pnlBody.Controls.Add(lblDt)
            AddHandler .Click, AddressOf recentGames_Click
            AddHandler .MouseMove, AddressOf recentGames_MouseMove
            AddHandler .MouseLeave, AddressOf recentGames_MouseLeave
        End With
    End Sub

    Private Sub GameRankingTop3()
        Dim wh As String = ""
        If cboRank.SelectedIndex > 0 Then
            PowerNET8.myString.Share.Concat.Append(wh, " gameType like '%" + cboRank.Text + "%'", " and ")
        End If
        If wh <> "" Then wh = " and " + wh

        Dim mydata As DataTable = mysql.Query("SELECT accountID, username, firstname FROM tblaccount order by username")
        Dim tblRankPlayer As DataTable = getTableRankPlayer()
        If mydata.Rows.Count > 0 Then
            For i As Integer = 0 To mydata.Rows.Count - 1
                With tblRankPlayer
                    .Rows.Add()
                    .Rows(i).Item("accountID") = mydata.Rows(i).Item(0)
                    .Rows(i).Item("RankLogo") = mydata.Rows(i).Item(0)
                    .Rows(i).Item("Player") = mydata.Rows(i).Item(2)
                    .Rows(i).Item("Points") = getRankPointsByMonth(mydata.Rows(i).Item(0), wh)
                End With
            Next
        End If
        Dim dv As DataView
        dv = New DataView(tblRankPlayer)
        dv.Sort = "Points desc"
        tblRankPlayer = dv.ToTable

        For i As Integer = 0 To tblRankPlayer.Rows.Count - 1
            Select Case i
                Case 0
                    pc1Player.Image = getProfilePlayer(tblRankPlayer.Rows(i).Item("RankLogo"))
                    lbl1Name.Text = tblRankPlayer.Rows(i).Item("Player")
                    lbl1Points.Text = FormatNumber(tblRankPlayer.Rows(i).Item("Points"), 2) + " pts."
                Case 1
                    pc2Player.Image = getProfilePlayer(tblRankPlayer.Rows(i).Item("RankLogo"))
                    lbl2Name.Text = tblRankPlayer.Rows(i).Item("Player")
                    lbl2Points.Text = FormatNumber(tblRankPlayer.Rows(i).Item("Points"), 2) + " pts."
                Case 2
                    pc3Player.Image = getProfilePlayer(tblRankPlayer.Rows(i).Item("RankLogo"))
                    lbl3Name.Text = tblRankPlayer.Rows(i).Item("Player")
                    lbl3Points.Text = FormatNumber(tblRankPlayer.Rows(i).Item("Points"), 2) + " pts."
                Case Else
                    Exit For
            End Select
        Next
    End Sub

    Private Sub utcRecentGames_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles utcRecentGames.SelectedTabChanged
        If utcRecentGames.Tabs(1).Selected Then
            MostPopularGames()
        ElseIf utcRecentGames.Tabs(2).Selected Then
            MostRequestedGames()
        End If
    End Sub

#End Region



    Private Sub GameRanking()
        Dim wh As String = ""
        If cboRank.SelectedIndex > 0 Then
            PowerNET8.myString.Share.Concat.Append(wh, " gameType like '%" + cboRank.Text + "%'", " and ")
        End If
        If wh <> "" Then wh = " and " + wh

        Dim mydata As DataTable = mysql.Query("SELECT accountID, username,concat(firstname,' ',lastname) FROM tblaccount order by username")
        Dim tblRankPlayer As DataTable = getTableRankPlayer()
        If mydata.Rows.Count > 0 Then
            For i As Integer = 0 To mydata.Rows.Count - 1
                With tblRankPlayer
                    .Rows.Add()
                    .Rows(i).Item("accountID") = mydata.Rows(i).Item(0)
                    .Rows(i).Item("RankLogo") = mydata.Rows(i).Item(0)
                    .Rows(i).Item("Player") = mydata.Rows(i).Item(2)
                    .Rows(i).Item("Points") = getRankPoints(mydata.Rows(i).Item(0), wh)
                End With
            Next
        End If
        Dim dv As DataView
        dv = New DataView(tblRankPlayer)
        dv.Sort = "Points desc"
        tblRankPlayer = dv.ToTable

        dgvRank.Rows.Clear()
        For i As Integer = 0 To tblRankPlayer.Rows.Count - 1
            With dgvRank
                .Rows.Add()
                .Rows(i).Cells(0).Value = tblRankPlayer.Rows(i).Item("accountID")
                .Rows(i).Cells(1).Value = i + 1
                .Rows(i).Cells(2).Value = getProfilePlayer(tblRankPlayer.Rows(i).Item("RankLogo"))
                .Rows(i).Cells(3).Value = tblRankPlayer.Rows(i).Item("Player")
                .Rows(i).Cells(4).Value = getRankLogo_Selected(tblRankPlayer.Rows(i).Item("RankLogo"), tblRankPlayer.Rows(i).Item("Points").ToString)
                .Rows(i).Cells(5).Value = FormatNumber(tblRankPlayer.Rows(i).Item("Points"), 2)
            End With
        Next
    End Sub

    Private Sub cboRank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRank.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        GameRanking()
        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region "PROFILE INFORMATION"

    Private Function getRankPosition(ByVal accountID As String) As String
        'GET THE RANK BASED FROM POINTS
        Dim mydata As DataTable = mysql.Query("select * from tblaccount_activity_rank where " + IIf(pbPoints.ToString = "", "0", pbPoints.ToString) + " <= tPoints and " + IIf(pbPoints.ToString = "", "0", pbPoints.ToString) + " >= fPoints")
        If mydata.Rows.Count > 0 Then
            If Not IsDBNull(mydata.Rows(0).Item("rankName")) Then
                Return mydata.Rows(0).Item("rankName")
            Else
                Return Nothing
            End If
            Return Nothing
        End If
    End Function

    Private Function getRankPosition_Selected(ByVal accountID As String, ByVal pbPoints As String) As String
        'GET THE RANK BASED FROM POINTS
        Dim mydata As DataTable = mysql.Query("select * from tblaccount_activity_rank where " + IIf(pbPoints.ToString = "", "0", pbPoints.ToString) + " <= tPoints and " + IIf(pbPoints.ToString = "", "0", pbPoints.ToString) + " >= fPoints")
        If mydata.Rows.Count > 0 Then
            If Not IsDBNull(mydata.Rows(0).Item("rankName")) Then
                Return mydata.Rows(0).Item("rankName")
            Else
                Return Nothing
            End If
            Return Nothing
        End If
    End Function

    Private Sub dgvRank_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRank.CellClick
        Select Case dgvRank.CurrentCell.ColumnIndex
            Case 7
                Me.Cursor = Cursors.WaitCursor
                reloadProfileInformation(dgvRank.CurrentRow.Cells(0).Value)
                reloadProfileInformation(dgvRank.CurrentRow.Cells(0).Value)
                utcHome.Tabs(1).Visible = True
                utcHome.Tabs(1).Selected = True
                Me.Cursor = Cursors.Default
        End Select
    End Sub

    Private Sub reloadProfileInformation(ByVal accountID As String)
        Dim totalGamePoints As Decimal = 0
        lblProfileStatusAccountID.Text = accountID
        dgvListRanking.Cursor = Cursors.WaitCursor

        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=" + accountID.ToString)
        If mydata.Rows.Count > 0 Then

            dgvProfInfoGameStatus.Rows.Clear()

            pcProfInfoPicture.ImageLocation = Application.StartupPath + "\" + mydata.Rows(0).Item("picture").ToString.Replace("~", "\")
            If pcProfInfoPicture.ImageLocation = "" Then pcProfInfoPicture.Image = My.Resources.profile_icon1


            lblProfInfoName.Text = mydata.Rows(0).Item("firstname").ToString.ToUpper + " " + mydata.Rows(0).Item("middlename").ToString.ToUpper + " " + mydata.Rows(0).Item("lastname").ToString.ToUpper
            If mydata.Rows(0).Item("gender") = "M" Then
                lblProfInfoGender.Text = "Male"
            ElseIf mydata.Rows(0).Item("gender") = "F" Then
                lblProfInfoGender.Text = "Female"
            End If
            Dim dt As Date = mydata.Rows(0).Item("birthdate")
            lblProfInfoBirthdate.Text = dt.ToString("MM/dd/yyyy")
            If Not IsDBNull(mydata.Rows(0).Item("address")) Then lblProfInfoAddress.Text = mydata.Rows(0).Item("address")
            lblProfInfoCity.Text = mydata.Rows(0).Item("city")
            lblProfInfoProvince.Text = mydata.Rows(0).Item("province")
            lblProfInfoContactNo.Text = mydata.Rows(0).Item("contactNo")

            If Not IsDBNull(mydata.Rows(0).Item("messageBoard")) Then lblProfInfoMessageBoard.Text = mydata.Rows(0).Item("messageBoard")
        End If


        lblProfInfoPoints.Text = FormatNumber(getRankPoints(accountID), 2)
        lblProfInfoPosition.Text = getRankPosition_Selected(accountID, lblProfInfoPoints.Text)

        mydata = mysql.Query("SELECT tblaccount_activity.accountID, tblgamedata.gameID,tblgamedata_imageloc.coverPhoto, tblgamedata.gameName, gameType as 'genre',platforms, sum(points) as 'total' FROM   tblaccount_activity inner JOIN tblaccount_activity_points_ref       ON (tblaccount_activity.typeVal = tblaccount_activity_points_ref.name) INNER JOIN tblgamedata     ON (tblgamedata.gameID = tblaccount_activity.gameID)   INNER JOIN tblgamedata_imageloc   ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) where tblaccount_activity.accountID = " + accountID.ToString + " group by tblgamedata.gameID order by total desc")
        dgvProfInfoGameStatus.Rows.Clear()
        dgvProfInfoGameStatus.Refresh()
        If mydata.Rows.Count > 0 Then
            'dgvProfInfoGameStatus.Rows.Clear()
            For i As Integer = 0 To mydata.Rows.Count - 1
                With dgvProfInfoGameStatus
                    .Rows.Add()
                    .Rows(i).Cells(0).Value = mydata.Rows(i).Item("gameID")
                    .Rows(i).Cells(1).Value = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(i).Item("coverPhoto").ToString.Replace("~", "\"))
                    .Rows(i).Cells(2).Value = mydata.Rows(i).Item("gameName")
                    .Rows(i).Cells(3).Value = mydata.Rows(i).Item("genre")
                    .Rows(i).Cells(4).Value = mydata.Rows(i).Item("platforms")
                    Dim tot As Decimal = getTotalPoints(mysql, mydata.Rows(i).Item("gameID"), accountID)
                    .Rows(i).Cells(5).Value = FormatNumber(tot, 2) + " pts."
                    totalGamePoints += tot
                End With
            Next
        End If
        lblGamePoints.Text = "TOTAL GAME POINTS : " + FormatNumber(totalGamePoints, 2)
        pcProfInfoRankLogo.Image = getRankLogo_Selected(accountID, lblProfInfoPoints.Text)
        'GET THE PLATFORMS
        mydata = mysql.Query("SELECT  distinct platforms FROM   tblaccount_activity inner JOIN tblaccount_activity_points_ref       ON (tblaccount_activity.typeVal = tblaccount_activity_points_ref.name) INNER JOIN tblgamedata     ON (tblgamedata.gameID = tblaccount_activity.gameID)   INNER JOIN tblgamedata_imageloc   ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) where tblaccount_activity.accountID = " + accountID + "  order by tblgamedata.platforms")
        cboProfInfoPlatforms.Items.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            With cboProfInfoPlatforms
                .Items.Add(mydata.Rows(i).Item(0))
            End With
        Next
        cboProfInfoPlatforms.Items.Add("-View All-")
        cboProfInfoPlatforms.Text = "-View All-"
        lblProfInfoAccountID.Text = accountID
        utcProfileStatus.Tabs(0).Selected = True

        lblWinner.Text = getWinLoseStatus(accountID, "win")
        lblLoser.Text = getWinLoseStatus(accountID, "lose")
        lblDraw.Text = getWinLoseStatus(accountID, "draw")



        dgvListRanking.Cursor = Cursors.Default
    End Sub

    Private Function getWinLoseStatus(ByVal accountID As String, ByVal type As String, Optional ByVal dt As String = "")
        Dim wh As String = ""
        If dt <> "" Then
            wh = " and dtBattle between '" + Now.Year.ToString + "-" + Now.Month.ToString + "-1 0:0:0' and '" + Now.Year.ToString + "-" + Now.Month.ToString + "-31 23:59:59' "
        End If
        Select Case type
            Case "win"
                Dim mydata As DataTable = mysql.Query("select (select count(status_A) as 'total' from tblaccount_battle where accountID_A=" + accountID + " and status_A='win' " + wh + ") as 'A', (select count(status_B) as 'total' from tblaccount_battle where accountID_B=" + accountID + " and status_B='win' " + wh + ") as 'B'")
                If mydata.Rows.Count > 0 Then
                    Return mydata.Rows(0).Item(0) + mydata.Rows(0).Item(1)
                End If
            Case "lose"
                Dim mydata As DataTable = mysql.Query("select (select count(status_A) as 'total' from tblaccount_battle where accountID_A=" + accountID + " and status_A='lose' " + wh + ") as 'A', (select count(status_B) as 'total' from tblaccount_battle where accountID_B=" + accountID + " and status_B='lose' " + wh + ") as 'B'")
                If mydata.Rows.Count > 0 Then
                    Return mydata.Rows(0).Item(0) + mydata.Rows(0).Item(1)
                End If
            Case "draw"
                Dim mydata As DataTable = mysql.Query("select (select count(status_A) as 'total' from tblaccount_battle where accountID_A=" + accountID + " and status_A='draw' " + wh + ") as 'A', (select count(status_B) as 'total' from tblaccount_battle where accountID_B=" + accountID + " and status_B='draw' " + wh + ") as 'B'")
                If mydata.Rows.Count > 0 Then
                    Return mydata.Rows(0).Item(0) + mydata.Rows(0).Item(1)
                End If
        End Select
        Return 0
    End Function

    Private Sub cboProfInfoPlatforms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProfInfoPlatforms.SelectedIndexChanged
        Dim wh As String = ""
        If cboProfInfoPlatforms.Text <> "-View All-" Then wh = " and tblgamedata.platforms =  '" + cboProfInfoPlatforms.Text + "'"

        Dim mydata As DataTable = mysql.Query("SELECT tblaccount_activity.accountID, tblgamedata.gameID,tblgamedata_imageloc.coverPhoto, tblgamedata.gameName, gameType as 'genre',platforms, sum(points) as 'total' FROM   tblaccount_activity inner JOIN tblaccount_activity_points_ref       ON (tblaccount_activity.typeVal = tblaccount_activity_points_ref.name) INNER JOIN tblgamedata     ON (tblgamedata.gameID = tblaccount_activity.gameID)   INNER JOIN tblgamedata_imageloc   ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) where tblaccount_activity.accountID = " + lblProfInfoAccountID.Text.ToString + "  " + wh + " group by tblgamedata.gameID order by total desc")
        If mydata.Rows.Count > 0 Then
            dgvProfInfoGameStatus.Rows.Clear()
            For i As Integer = 0 To mydata.Rows.Count - 1
                With dgvProfInfoGameStatus
                    .Rows.Add()
                    .Rows(i).Cells(0).Value = mydata.Rows(i).Item("gameID")
                    .Rows(i).Cells(1).Value = Image.FromFile(Application.StartupPath + "\" + mydata.Rows(i).Item("coverPhoto").ToString.Replace("~", "\"))
                    .Rows(i).Cells(2).Value = mydata.Rows(i).Item("gameName")
                    .Rows(i).Cells(3).Value = mydata.Rows(i).Item("genre")
                    .Rows(i).Cells(4).Value = mydata.Rows(i).Item("platforms")
                    .Rows(i).Cells(5).Value = getTotalPoints(mysql, mydata.Rows(i).Item("gameID"), lblProfInfoAccountID.Text)
                End With
            Next
        End If
    End Sub

    'SELECTION DURING TAB SELECTION EVENT
    Private Sub utcProfileStatus_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles utcProfileStatus.SelectedTabChanged
        If utcProfileStatus.Tabs(3).Selected Then
            'STATUS
            status()
        ElseIf utcProfileStatus.Tabs(1).Selected Then
            cboRewardsType.Text = "-View All-"
            reloadRewardsStatus()
        ElseIf utcProfileStatus.Tabs(2).Selected Then
            cboLogType.Text = "-View All-"
            reloadAccountStatus()
        End If
    End Sub

#Region "STATUS"

    Private Sub status()
        'reload account status
        Dim mydata As DataTable = mysql.Query("SELECT sum(points) FROM  tblaccount_activity_points_ref  INNER JOIN tblaccount_activity    ON (tblaccount_activity_points_ref.name = tblaccount_activity.typeVal) where accountID=" + lblProfileStatusAccountID.Text + " and (typeVal='login' or typeVal='logout') ")
        If mydata.Rows.Count > 0 Then
            If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                lblGAccountPoints.Text = FormatNumber(mydata.Rows(0).Item(0), 2)
            End If
        End If
        'reload rewards status
        Dim totalRewardsPoints As Decimal = 0
        Dim totalRewardsTP As Decimal = 0
        Dim totalTicket As Decimal = 0
        'gift rewards
        mydata = mysql.Query("SELECT sum(exp), sum(tp), sum(ticket), lastOpenedChest from tblrewards_giftbox where accountID=" + lblProfileStatusAccountID.Text)
        If mydata.Rows.Count > 0 Then
            If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                totalRewardsPoints += mydata.Rows(0).Item(0)
                totalRewardsTP += mydata.Rows(0).Item(1)
                totalTicket += mydata.Rows(0).Item(2)
            End If
        End If
        'slot machine
        mydata = mysql.Query("SELECT  sum(exp), sum(tp), sum(ticket) from tblrewards_slotmachine where accountID=" + lblProfileStatusAccountID.Text)
        If mydata.Rows.Count > 0 Then
            If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                totalRewardsPoints += mydata.Rows(0).Item(0)
                totalRewardsTP += mydata.Rows(0).Item(1)
                totalTicket += mydata.Rows(0).Item(2)
            End If
        End If
        lblGRewardsPoints.Text = FormatNumber(totalRewardsPoints, 2)
        lblGTimesPoints.Text = FormatNumber(totalRewardsTP, 0)
        lblGTickets.Text = FormatNumber(totalTicket, 0)
        'game points

        mydata = mysql.Query("SELECT tblaccount_activity.accountID, tblgamedata.gameID,tblgamedata_imageloc.coverPhoto, tblgamedata.gameName, gameType as 'genre',platforms, sum(points) as 'total' FROM   tblaccount_activity inner JOIN tblaccount_activity_points_ref       ON (tblaccount_activity.typeVal = tblaccount_activity_points_ref.name) INNER JOIN tblgamedata     ON (tblgamedata.gameID = tblaccount_activity.gameID)   INNER JOIN tblgamedata_imageloc   ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) where tblaccount_activity.accountID = " + lblProfileStatusAccountID.Text + " group by tblgamedata.gameID order by total desc")
        Dim gamePoints As Decimal = 0
        If mydata.Rows.Count > 0 Then
            'dgvProfInfoGameStatus.Rows.Clear()
            For i As Integer = 0 To mydata.Rows.Count - 1
                gamePoints += getTotalPoints(mysql, mydata.Rows(i).Item("gameID"), lblProfileStatusAccountID.Text)
            Next
        End If
        lblGPoints.Text = FormatNumber(gamePoints, 2)
        lblOverallPoints.Text = FormatNumber(CDbl(lblGPoints.Text) + CDbl(lblGRewardsPoints.Text) + CDbl(lblGAccountPoints.Text), 2)
    End Sub

#End Region

#Region "ACCOUNT STATUS"

    Private Sub reloadAccountStatus()
        'ACCOUNT STATUS
        Dim wh As String = ""
        If cboLogType.Text <> "-View All-" Then
            wh = " and typeVal='" + cboLogType.Text + "' "
        Else
            wh = " and (typeVal='login' or typeVal='logout') "
        End If

        'reload account activity
        Dim mydata As DataTable = mysql.Query("SELECT accountActivityID, typeVal, points, dtActivity FROM  tblaccount_activity_points_ref  INNER JOIN tblaccount_activity    ON (tblaccount_activity_points_ref.name = tblaccount_activity.typeVal) where accountID=" + lblProfileStatusAccountID.Text + " " + wh + " order by dtActivity desc")
        dgvLogType.Rows.Clear()
        Dim totalPoints As Decimal = 0
        For i As Integer = 0 To mydata.Rows.Count - 1
            With dgvLogType
                .Rows.Add()
                .Rows(i).Cells(0).Value = mydata.Rows(i).Item(0)
                .Rows(i).Cells(1).Value = mydata.Rows(i).Item(1)
                .Rows(i).Cells(2).Value = FormatNumber(mydata.Rows(i).Item(2), 2)
                totalPoints += mydata.Rows(i).Item(2)
                .Rows(i).Cells(3).Value = mydata.Rows(i).Item(3)
            End With
        Next
        lblLogType.Text = "TOTAL ACCOUNT POINTS: " + FormatNumber(totalPoints, 2)
    End Sub

    Private Sub cboLogType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLogType.SelectedIndexChanged
        reloadAccountStatus()
    End Sub

#End Region

#Region "REWARD STATUS"

    Private Sub reloadRewardsStatus()
        Dim wh As String = ""
        Select Case cboRewardsType.Text
            Case "Daily Gift Box Award"
                wh = "SELECT giftBoxID, chestLevel, exp, tp, ticket, lastOpenedChest from tblrewards_giftbox where accountID=" + lblProfileStatusAccountID.Text

                Dim mydata As DataTable = mysql.Query(wh)
                dgvRewardsPoints.Rows.Clear()
                Dim totalRewardsPoints As Decimal = 0
                Dim totalRewardsTP As Decimal = 0
                Dim totalRewardsTicket As Decimal = 0
                For i As Integer = 0 To mydata.Rows.Count - 1
                    With dgvRewardsPoints
                        .Rows.Add()
                        .Rows(i).Cells(0).Value = mydata.Rows(i).Item(0)
                        .Rows(i).Cells(1).Value = "Daily Gift Rewards"
                        .Rows(i).Cells(2).Value = "Opened Chest lvl " + mydata.Rows(i).Item(1) + " "
                        .Rows(i).Cells(3).Value = FormatNumber(mydata.Rows(i).Item(2), 2)
                        totalRewardsPoints += mydata.Rows(i).Item(2)
                        .Rows(i).Cells(4).Value = mydata.Rows(i).Item(3)
                        totalRewardsTP += mydata.Rows(i).Item(3)
                        .Rows(i).Cells(5).Value = mydata.Rows(i).Item(4)
                        totalRewardsTicket += mydata.Rows(i).Item(4)
                        .Rows(i).Cells(6).Value = mydata.Rows(i).Item(5)
                    End With
                Next
                lblRewardsPoints.Text = "TOTAL REWARDS POINTS: " + FormatNumber(totalRewardsPoints, 2)
                lblTPTicket.Text = "TP: " + totalRewardsTP.ToString + " / TICKET: " + totalRewardsTicket.ToString
            Case "Slot Machine Raffle Draw"
                wh = "SELECT slotMachineID, exp, tp, ticket, itemA, itemB, itemC, dateSpin from tblrewards_slotmachine where accountID=" + lblProfileStatusAccountID.Text
                Dim mydata As DataTable = mysql.Query(wh)
                dgvRewardsPoints.Rows.Clear()
                Dim totalRewardsPoints As Decimal = 0
                Dim totalRewardsTP As Decimal = 0
                Dim totalRewardsTicket As Decimal = 0
                For i As Integer = 0 To mydata.Rows.Count - 1
                    With dgvRewardsPoints
                        .Rows.Add()
                        .Rows(i).Cells(0).Value = mydata.Rows(i).Item(0)
                        .Rows(i).Cells(1).Value = "Slot Machine Awards"
                        .Rows(i).Cells(2).Value = "Items ( " + mydata.Rows(i).Item("itemA") + ", " + mydata.Rows(i).Item("itemB") + ", " + mydata.Rows(i).Item("itemC") + ")"
                        .Rows(i).Cells(3).Value = FormatNumber(mydata.Rows(i).Item(2), 2)
                        totalRewardsPoints += mydata.Rows(i).Item(1)
                        .Rows(i).Cells(4).Value = mydata.Rows(i).Item(1)
                        totalRewardsTP += mydata.Rows(i).Item(2)
                        .Rows(i).Cells(5).Value = mydata.Rows(i).Item(3)
                        totalRewardsTicket += mydata.Rows(i).Item(3)
                        .Rows(i).Cells(6).Value = mydata.Rows(i).Item("dateSpin")
                    End With
                Next
                lblRewardsPoints.Text = "TOTAL REWARDS POINTS: " + FormatNumber(totalRewardsPoints, 2)
                lblTPTicket.Text = "TP: " + totalRewardsTP.ToString + " / TICKET: " + totalRewardsTicket.ToString
            Case "-View All-"
                wh = "SELECT giftBoxID, chestLevel, exp, tp, ticket, lastOpenedChest from tblrewards_giftbox where accountID=" + lblProfileStatusAccountID.Text

                Dim mydata As DataTable = mysql.Query(wh)
                dgvRewardsPoints.Rows.Clear()
                Dim totalRewardsPoints As Decimal = 0
                Dim totalRewardsTP As Decimal = 0
                Dim totalRewardsTicket As Decimal = 0
                For i As Integer = 0 To mydata.Rows.Count - 1
                    With dgvRewardsPoints
                        .Rows.Add()
                        .Rows(i).Cells(0).Value = mydata.Rows(i).Item(0)
                        .Rows(i).Cells(1).Value = "Daily Gift Rewards"
                        .Rows(i).Cells(2).Value = "Opened Chest lvl " + mydata.Rows(i).Item(1) + " "
                        .Rows(i).Cells(3).Value = FormatNumber(mydata.Rows(i).Item(2), 2)
                        totalRewardsPoints += mydata.Rows(i).Item(2)
                        .Rows(i).Cells(4).Value = mydata.Rows(i).Item(3)
                        totalRewardsTP += mydata.Rows(i).Item(3)
                        .Rows(i).Cells(5).Value = mydata.Rows(i).Item(4)
                        totalRewardsTicket += mydata.Rows(i).Item(4)
                        .Rows(i).Cells(6).Value = mydata.Rows(i).Item(5)
                    End With
                Next

                wh = "SELECT slotMachineID, exp, tp, ticket, itemA, itemB, itemC, dateSpin from tblrewards_slotmachine where accountID=" + lblProfileStatusAccountID.Text
                mydata = mysql.Query(wh)
                Dim count As Integer = dgvRewardsPoints.Rows.Count - 1
                For i As Integer = 0 To mydata.Rows.Count - 1
                    With dgvRewardsPoints
                        .Rows.Add()
                        count += 1
                        .Rows(count).Cells(0).Value = mydata.Rows(i).Item(0)
                        .Rows(count).Cells(1).Value = "Slot Machine Awards"
                        .Rows(count).Cells(2).Value = "Items ( " + mydata.Rows(i).Item("itemA") + ", " + mydata.Rows(i).Item("itemB") + ", " + mydata.Rows(i).Item("itemC") + ")"
                        .Rows(count).Cells(3).Value = FormatNumber(mydata.Rows(i).Item(2), 2)
                        totalRewardsPoints += mydata.Rows(i).Item(1)
                        .Rows(count).Cells(4).Value = mydata.Rows(i).Item(1)
                        totalRewardsTP += mydata.Rows(i).Item(2)
                        .Rows(count).Cells(5).Value = mydata.Rows(i).Item(3)
                        totalRewardsTicket += mydata.Rows(i).Item(3)
                        .Rows(count).Cells(6).Value = mydata.Rows(i).Item("dateSpin")
                    End With
                Next
                lblRewardsPoints.Text = "TOTAL REWARDS POINTS: " + FormatNumber(totalRewardsPoints, 2)
                lblTPTicket.Text = "TP: " + totalRewardsTP.ToString + " / TICKET: " + totalRewardsTicket.ToString
        End Select

        If wh <> "" Then




        End If

    End Sub

    Private Sub cboRewardsType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRewardsType.SelectedIndexChanged
        reloadRewardsStatus()
    End Sub

#End Region

#Region "GAME STATUS"


#End Region

#End Region







    Private Sub flpNewsFeed_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles flpNewsFeed.Paint

    End Sub

    Private Sub dgvRank_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListRanking.CellContentClick

    End Sub

    Private Sub utcHome_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles utcHome.SelectedTabChanged
        If utcHome.Tabs(2).Selected Then
            Me.Cursor = Cursors.WaitCursor
            GameRanking()
            getRankPromotionsGuide()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub getRankPromotionsGuide()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount_activity_rank order by rankID desc")
        If mydata.Rows.Count > 0 Then
            dgvListRanking.Rows.Clear()
            For i As Integer = 0 To mydata.Rows.Count - 1
                With dgvListRanking
                    .Rows.Add()
                    .Rows(i).Cells(0).Value = mydata.Rows(i).Item("rankID")
                    Dim raw() As Byte = mydata.Rows(i).Item("rankLogo")
                    Dim frm As New System.IO.MemoryStream(raw)
                    .Rows(i).Cells(1).Value = Image.FromStream(frm)
                    .Rows(i).Cells(2).Value = mydata.Rows(i).Item("grade")
                    .Rows(i).Cells(3).Value = mydata.Rows(i).Item("rankName")
                    .Rows(i).Cells(4).Value = FormatNumber(mydata.Rows(i).Item("fPoints"), 0) + "-" + FormatNumber(mydata.Rows(i).Item("tPoints"), 0)
                End With
            Next
        End If
    End Sub

    Private Sub tReloadHomeUpdates_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tReloadHomeUpdates.Tick
        Me.Cursor = Cursors.WaitCursor
        'RANK RELOAD
        reloadAllGenre()
        GameRankingTop3()
        'PROFILE INFO
        reloadNewsFeed()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub UltraTabControl3_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles utcTopPlayer.SelectedTabChanged
        If utcTopPlayer.Tabs(1).Selected Then
            reloadTop3Winner()
        End If
    End Sub

    Private Sub txtSearchHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchHome.Click

    End Sub

    Private Sub txtSearchHome_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchHome.LostFocus
        txtSearchHome.BackColor = Color.FromArgb(64, 64, 64)
    End Sub

    Private Sub dgvRank_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRank.CellContentClick

    End Sub

    Private Sub dgvOtherGames_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOtherGames.CellContentClick

    End Sub
End Class