Imports System.Threading

Module modPublic
    Public ptblGameType As DataTable = createGameTypeRecord()
    Public ptblPlayStation As DataTable = createPlayStation()
    Public userID As Integer = 0
    Public pbUsername As String
    Public pbPoints As Decimal
    Public pbImageRank() As Byte
    Public pbRank As String
    Public pbRole As String
    Public pbName As String
    Public dataRank As Integer = 0
    Public rankID As Integer = 0
    Public pTP As Integer = 0
    Public pTicket As Integer = 0

    Public RemindersSega As Boolean = False
    Public RemindersProject64 As Boolean = False
    Public RemindersEPSXE As Boolean = False
    Public RemindersPSX As Boolean = False
    Public dblocalhost As String = "localhost"
    Public dbport As String = "3306"
    Public dbuser As String = "root"
    Public dbpassword As String = ""
    Public db As String = "gamelist"

    'Play Station
    Public pPSX As String = ""
    Public pEPSXE As String = ""

    Public Sub connect(ByRef mysql As PowerNET8.mySQL.Init.SQL)
        mysql.connectDatabase(dblocalhost, dbport, dbuser, dbpassword, db)
    End Sub

    Public Function getTotalPoints(ByRef mysql As PowerNET8.mySQL.Init.SQL, ByVal gameID As String, ByVal accountID As String) As Decimal
        Dim mydata As DataTable = mysql.Query("SELECT sum(points)    FROM  tblaccount_activity_points_ref INNER JOIN  tblaccount_activity   ON (tblaccount_activity_points_ref.name = tblaccount_activity.typeVal) where accountID=" + accountID.ToString + " and gameID=" + gameID + " and typeVal = 'start_play'")
        Dim totalStartPlay = mydata.Rows(0).Item(0)
        mydata = mysql.Query("SELECT sum(pts_timePlayed) FROM  tblaccount_activity where accountID=" + accountID.ToString + " and gameID=" + gameID + " and typeVal = 'playing'")
        Dim totalPlaying = mydata.Rows(0).Item(0)
        If Not IsDBNull(totalStartPlay) And Not IsDBNull(totalPlaying) Then
            Return (totalStartPlay + totalPlaying)
        ElseIf Not IsDBNull(totalStartPlay) Then
            Return totalStartPlay
        Else
            Return 0
        End If
    End Function

    Public Sub setAccountInfo(ByRef mysql As PowerNET8.mySQL.Init.SQL)
        'GET THE USERNAME
        Dim mydata As DataTable = mysql.Query("SELECT * from tblaccount where accountID = " + userID.ToString)
        If mydata.Rows.Count > 0 Then
            pbName = mydata.Rows(0).Item("firstname").ToString.ToUpper + " " + mydata.Rows(0).Item("middlename").ToString.ToUpper + " " + mydata.Rows(0).Item("lastname").ToString.ToUpper
            pbUsername = mydata.Rows(0).Item("username")
            pbRole = mydata.Rows(0).Item("role")
            dataRank = mydata.Rows(0).Item("rankID")
            'GET THE TOTAL NUMBER OF OVERALL POINTS
            pbPoints = 0
            mydata = mysql.Query("SELECT sum(points) as 'total' FROM  tblaccount_activity_points_ref  INNER JOIN tblaccount_activity     ON (tblaccount_activity_points_ref.name = tblaccount_activity.typeVal) where tblaccount_activity.accountID = " + userID.ToString + " and (typeVal='login' or typeVal='logout') ")
            If mydata.Rows.Count > 0 Then
                If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                    pbPoints += mydata.Rows(0).Item(0)
                End If
            End If



            'game points

            mydata = mysql.Query("SELECT tblaccount_activity.accountID, tblgamedata.gameID,tblgamedata_imageloc.coverPhoto, tblgamedata.gameName, gameType as 'genre',platforms, sum(points) as 'total' FROM   tblaccount_activity inner JOIN tblaccount_activity_points_ref       ON (tblaccount_activity.typeVal = tblaccount_activity_points_ref.name) INNER JOIN tblgamedata     ON (tblgamedata.gameID = tblaccount_activity.gameID)   INNER JOIN tblgamedata_imageloc   ON (tblgamedata_imageloc.gameID = tblgamedata.gameID) where tblaccount_activity.accountID = " + userID.ToString + " group by tblgamedata.gameID order by total desc")
            If mydata.Rows.Count > 0 Then
                'dgvProfInfoGameStatus.Rows.Clear()
                For i As Integer = 0 To mydata.Rows.Count - 1
                    pbPoints += getTotalPoints(mysql, mydata.Rows(i).Item("gameID"), userID.ToString)
                Next
            End If


            'GET THE TOTAL POINTS FROM GIFT REWARDS
            Dim mydata2 As DataTable = mysql.Query("SELECT sum(exp) as 'total' from tblrewards_giftbox where accountID=" + userID.ToString)
            If mydata2.Rows.Count > 0 Then
                If Not IsDBNull(mydata2.Rows(0).Item(0)) Then
                    pbPoints += CDbl(mydata2.Rows(0).Item(0))
                End If
            End If


            'GET THE TOTAL POINTS FROM SLOT MACHINES
            mydata = mysql.Query("SELECT sum(exp) as 'total' from tblrewards_slotmachine where accountID=" + userID.ToString)
            If mydata.Rows.Count > 0 Then
                If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                    pbPoints += mydata.Rows(0).Item(0)
                End If
            End If


            'GET TOTAL TP POINTS FROM GIFT REWARDS
            pTP = 0
            mydata = mysql.Query("SELECT sum(tp) as 'total' from tblrewards_giftbox where accountID=" + userID.ToString)
            If mydata.Rows.Count > 0 Then
                If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                    pTP += mydata.Rows(0).Item(0)
                End If
            End If

            'GET TOTAL TP POINTS FROM SLOT MACHINE REWARDS
            mydata = mysql.Query("SELECT sum(tp) as 'total' from tblrewards_slotmachine where accountID=" + userID.ToString)
            If mydata.Rows.Count > 0 Then
                If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                    pTP += mydata.Rows(0).Item(0)
                End If
            End If

            'BET POINTS ADDITION
            pbPoints += getSumWLBet(userID, "win")
            pbPoints -= getSumWLBet(userID, "lose")



            'GET THE RANK BASED FROM POINTS
            mydata = mysql.Query("select * from tblaccount_activity_rank where " + IIf(pbPoints.ToString = "", "0", pbPoints.ToString) + " <= tPoints and " + IIf(pbPoints.ToString = "", "0", pbPoints.ToString) + " >= fPoints")
            If mydata.Rows.Count > 0 Then
                If Not IsDBNull(mydata.Rows(0).Item("rankLogo")) Then
                    pbImageRank = mydata.Rows(0).Item("rankLogo")
                    rankID = mydata.Rows(0).Item("rankID")
                Else
                    pbImageRank = Nothing
                End If
                pbRank = mydata.Rows(0).Item("rankName")
            End If



        Else
            pbName = "GUEST"
            pbUsername = "guest"
            pbRole = "Standard"
            pbPoints = 0
            pbRank = "RANK: ?"
        End If

    End Sub

    Private Function getSumWLBet(ByVal accountID As String, ByVal type As String) As Decimal
        Dim mysql As New PowerNET8.mySQL.Init.SQL
        connect(mysql)
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

    Public Sub setLogUpdate(ByRef mysql As PowerNET8.mySQL.Init.SQL, ByVal value As String)
        Dim dtNow As Date = Now
        Dim mydata As DataTable = mysql.Query("SELECT count(*) as 'total' from tblaccount_activity where typeVal='" + value + "' and accountID=" + userID.ToString + " and dtActivity between '" + dtNow.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtNow.ToString("yyyy-MM-dd") + " 23:59:59'")
        If mydata.Rows(0).Item(0) <= 9 Then
            With mysql
                .setTable("tblaccount_activity")
                .addValue(userID.ToString, "accountID")
                .addValue(value, "typeVal")
                .addValue(Now.ToString("yyyy-MM-dd ") + (Now.Hour).ToString + ":" + Now.ToString("mm:ss"), "dtActivity")
                .Insert()
            End With
        End If
    End Sub


    Private Function createGameTypeRecord() As DataTable
        Dim tableRow As New PowerNET8.myDataTableCreator
        With tableRow
            .new_table("tblGameType")
            .add_columnField("id", PowerNET8.myDataTableCreator.FieldType.Integer_)
            .add_columnField("gameType")
            .add_columnField("yearPublished", PowerNET8.myDataTableCreator.FieldType.Integer_)
            .add_columnField("coverLocation")
            Return .get_table()
        End With
    End Function

    Private Function createPlayStation() As DataTable
        Dim tableRow As New PowerNET8.myDataTableCreator
        With tableRow
            .new_table("tblPlayStation")
            .add_columnField("codeID")
            .add_columnField("gameName")
            .add_columnField("gameType")
            .add_columnField("noOfPlayed", PowerNET8.myDataTableCreator.FieldType.Integer_)
            .add_columnField("emulator")
            .add_columnField("country")
            .add_columnField("gameDescription")
            .add_columnField("composers")
            .add_columnField("developers")
            .add_columnField("designer")
            .add_columnField("platforms")
            .add_columnField("publishers")
            .add_columnField("initialReleaseDate")
            .add_columnField("gamefile")
            .add_columnField("coverPhoto")
            .add_columnField("sc1")
            .add_columnField("sc2")
            .add_columnField("sc3")
            .add_columnField("sc4")
            .add_columnField("sc5")
            Return .get_table
        End With
    End Function

    Public Sub loadRecord()
        LibraryCode.Data.loadGameType(ptblGameType)
    End Sub

    Public Sub saveRecord()
        LibraryCode.Data.saveGameType(ptblGameType)
        MsgBox("Save Successfully", MsgBoxStyle.Information, "Save")
    End Sub

End Module
