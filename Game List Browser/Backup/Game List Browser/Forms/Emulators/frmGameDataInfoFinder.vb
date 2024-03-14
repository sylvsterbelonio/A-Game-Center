Imports PowerNET8.myString.Share
Public Class frmGameDataInfoFinder
    Dim mysql As New PowerNET8.mySQL.Init.SQL

    Private Sub reloadPlatforms()
        Dim mydata As DataTable = mysql.Query("SELECT distinct platforms from tblgamedata order by platforms")
        cboPlatforms.Items.Clear()
        If mydata.Rows.Count > 0 Then
            For i As Integer = 0 To mydata.Rows.Count - 1
                cboPlatforms.Items.Add(mydata.Rows(i).Item(0))
            Next
        End If
        cboPlatforms.Items.Add("-View All-")
        cboPlatforms.Text = "-View All-"
    End Sub

    Private Sub reloadData()
        Dim wh As String = ""
        If cboPlatforms.Text <> "-View All-" Then
            Concat.Append(wh, " platforms like '" + cboPlatforms.Text + "' ", " and ")
        End If
        If txtGameName.Text <> "" Then
            Concat.Append(wh, " gameName like '" + txtGameName.Text + "%' ", " and ")
        End If
        If wh <> "" Then
            wh = " where " + wh
        End If

        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblgamedata  " + wh + "  order by gameName limit " + (sPage * Val(tsLimiter.Text)).ToString + "," + tsLimiter.Text.ToString)

        Dim s As String = "SELECT count(*) as 'total' FROM   tblgamedata  " + wh + "  order by gameName "
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

        dgvList.Rows.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            With dgvList
                .Rows.Add()
                .Rows(i).Cells(0).Value = mydata.Rows(i).Item("gameID")
                .Rows(i).Cells(1).Value = getImage(mydata.Rows(i).Item("gameID"))
                .Rows(i).Cells(2).Value = mydata.Rows(i).Item("gameName")
                .Rows(i).Cells(3).Value = mydata.Rows(i).Item("gameType")
                .Rows(i).Cells(4).Value = mydata.Rows(i).Item("developer")
                .Rows(i).Cells(5).Value = mydata.Rows(i).Item("publishers")
                .Rows(i).Cells(6).Value = mydata.Rows(i).Item("country")
                .Rows(i).Cells(7).Value = mydata.Rows(i).Item("platforms")
                If Not IsDBNull(mydata.Rows(i).Item("initialReleasedDate")) Then
                    Dim dt As Date = mydata.Rows(i).Item("initialReleasedDate")
                    .Rows(i).Cells(8).Value = dt.ToString("M/d/yyyy")
                End If
            End With
        Next
    End Sub

    Private Function getImage(ByVal id As String) As Image
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblgamedata_imageloc where gameID=" + id)
        If mydata.Rows.Count > 0 Then
            Dim path As String = mydata.Rows(0).Item("coverPhoto").ToString.Replace("~", "\")
            Return Image.FromFile(Application.StartupPath + "\" + path)
        Else
            Return Image.FromFile(Application.StartupPath + "\Images\System\Default\no image.jpg")
        End If
    End Function

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click, cmdView.Click, cmdEdit.Click
        Dim frm As New frmGameDataInfo
        With frm
            Select Case CType(sender, Button).Name
                Case "cmdAdd"
                    .ShowDialog()
                    reloadData()
                Case "cmdEdit"
                    If dgvList.RowCount > 0 Then
                        .gameid = dgvList.CurrentRow.Cells(0).Value
                        .action = "edit"
                        .ShowDialog()
                    End If
                Case "cmdView"
                    If dgvList.RowCount > 0 Then
                        .gameid = dgvList.CurrentRow.Cells(0).Value
                        .action = "view"
                        .ShowDialog()
                    End If
            End Select

        End With
    End Sub

    Private Sub frmPlayStationFinder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        tsLimiter.Text = "10"
        reloadPlatforms()
        reloadData()
    End Sub

    Private Sub dgvList_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvList.CellMouseDoubleClick
        If dgvList.RowCount > 0 Then
            cmdAdd_Click(cmdView, Nothing)
        End If
    End Sub

    Private Sub cboPlatforms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPlatforms.SelectedIndexChanged
        reloadData()
    End Sub

    Private Sub txtGameName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGameName.TextChanged
        reloadData()
    End Sub

    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        txtGameName.Text = ""
        cboPlatforms.Text = "-View All-"
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        reloadData()
    End Sub

#Region "Navigation Bar"
    Private nPage As Integer = 0
    Private sPage As Integer = 0
    Private MaxPage As Integer = 0
    Private MaxRecord As Integer = 0
    Private Limiter As Integer = 10

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
        reloadData()
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
            reloadData()
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
        reloadData()
    End Sub

#End Region

End Class