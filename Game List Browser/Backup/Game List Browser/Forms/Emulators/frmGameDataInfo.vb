Imports System.IO

Public Class frmGameDataInfo
    Dim mysql As New PowerNET8.mySQL.Init.SQL
    Public gameid As Integer = 0


    Public action As String = ""

    Private Sub selectRecord()
        If action = "view" Or action = "edit" Then
            Dim mydata As DataTable = mysql.Query("SELECT * FROM tblgamedata where gameID=" + gameid.ToString)
            If mydata.Rows.Count > 0 Then
                txtGameName.Text = mydata.Rows(0).Item("gameName")
                txtGameType.Text = mydata.Rows(0).Item("gameType")
                cboPlayers.Text = mydata.Rows(0).Item("Player")
                txtNoOfPlayed.Text = mydata.Rows(0).Item("noOfPlayed")
                cboEmulator.Text = mydata.Rows(0).Item("emulator")
                cboCountry.Text = mydata.Rows(0).Item("country")
                txtGameDescription.Text = mydata.Rows(0).Item("gameDesc")
                txtComposers.Text = mydata.Rows(0).Item("composers")
                txtDeveloper.Text = mydata.Rows(0).Item("developer")
                txtDesigner.Text = mydata.Rows(0).Item("designer")
                txtPlatforms.Text = mydata.Rows(0).Item("platforms")
                txtPublishers.Text = mydata.Rows(0).Item("publishers")
                txtCD1.Text = mydata.Rows(0).Item("gamefile").ToString.ToString.Replace("~", "\")
                txtCD2.Text = mydata.Rows(0).Item("cd2").ToString.ToString.Replace("~", "\")
                txtCD3.Text = mydata.Rows(0).Item("cd3").ToString.ToString.Replace("~", "\")
                txtCD4.Text = mydata.Rows(0).Item("cd4").ToString.ToString.Replace("~", "\")
                txtMemoryCard.Text = mydata.Rows(0).Item("memoryCard").ToString.Replace("~", "\")
                dtReleasedDate.Value = mydata.Rows(0).Item("initialReleasedDate")
            End If

            mydata = mysql.Query("SELECT * FROM tblgamedata_imageloc where gameID=" + gameid.ToString)
            If mydata.Rows.Count > 0 Then
                picCover.ImageLocation = Application.StartupPath + "\" + mydata.Rows(0).Item("coverPhoto").ToString.Replace("~", "\")
                pbCS1.ImageLocation = Application.StartupPath + "\" + mydata.Rows(0).Item("backcoverPhoto").ToString.Replace("~", "\")
                pbSC2.ImageLocation = Application.StartupPath + "\" + mydata.Rows(0).Item("sc2").ToString.Replace("~", "\")
                pbSC3.ImageLocation = Application.StartupPath + "\" + mydata.Rows(0).Item("sc3").ToString.Replace("~", "\")
                pbSC4.ImageLocation = Application.StartupPath + "\" + mydata.Rows(0).Item("sc4").ToString.Replace("~", "\")
                pbSC5.ImageLocation = Application.StartupPath + "\" + mydata.Rows(0).Item("sc5").ToString.Replace("~", "\")
            End If

            If action = "view" Then
                controllerField(True)
                cmdSave.Text = "Edit"
                cmdNew.Text = "Add"
                cmdPreview.Visible = True
            Else
                controllerField(False)
                cmdSave.Text = "Save"
                cmdNew.Text = "Add"
            End If


        End If
        setTextAuto()
    End Sub

    Private Sub controllerField(Optional ByVal lock As Boolean = False)

        txtGameName.ReadOnly = lock
        txtGameType.ReadOnly = lock
        txtNoOfPlayed.ReadOnly = lock
        cboEmulator.Enabled = IIf(lock, False, True)
        cboCountry.Enabled = IIf(lock, False, True)
        cboPlayers.Enabled = IIf(lock, False, True)
        txtGameDescription.ReadOnly = lock
        txtMemoryCard.ReadOnly = lock
        txtComposers.ReadOnly = lock
        txtDeveloper.ReadOnly = lock
        txtDesigner.ReadOnly = lock
        txtPlatforms.ReadOnly = lock
        txtPublishers.ReadOnly = lock
        txtMemoryCard.ReadOnly = lock
        Dim dt As New Date()
        dtReleasedDate.Enabled = IIf(lock, False, True)

        picCover.Enabled = IIf(lock, False, True)
        pbCS1.Enabled = IIf(lock, False, True)
        pbSC2.Enabled = IIf(lock, False, True)
        pbSC3.Enabled = IIf(lock, False, True)
        pbSC4.Enabled = IIf(lock, False, True)
        pbSC5.Enabled = IIf(lock, False, True)

        txtCD1.ReadOnly = lock
        txtCD2.ReadOnly = lock
        txtCD3.ReadOnly = lock
        txtCD4.ReadOnly = lock

        cmdCD1.Enabled = IIf(lock, False, True)
        cmdCD2.Enabled = IIf(lock, False, True)
        cmdCD3.Enabled = IIf(lock, False, True)
        cmdCD4.Enabled = IIf(lock, False, True)
        cmdMemoryCard.Enabled = IIf(lock, False, True)
    End Sub

    Private Sub clearField()
        txtGameName.Text = ""
        txtGameType.Text = ""
        txtNoOfPlayed.Text = ""
        cboEmulator.SelectedIndex = -1
        cboCountry.SelectedIndex = -1
        cboPlayers.SelectedIndex = -1
        txtGameDescription.Text = ""
        txtComposers.Text = ""
        txtDeveloper.Text = ""
        txtDesigner.Text = ""
        txtPlatforms.Text = ""
        txtPublishers.Text = ""
        txtMemoryCard.Text = ""
        dtReleasedDate.Value = Nothing

        picCover.ImageLocation = Nothing
        pbCS1.ImageLocation = Nothing
        pbSC2.ImageLocation = Nothing
        pbSC3.ImageLocation = Nothing
        pbSC4.ImageLocation = Nothing
        pbSC5.ImageLocation = Nothing

        txtCD1.Text = ""
        txtCD2.Text = ""
        txtCD3.Text = ""
        txtMemoryCard.Text = ""
        txtCD4.Text = ""
    End Sub

    Private Sub setAutoSuggest(ByRef textboxes As TextBox, ByVal column As String)
        Dim mydata As DataTable = mysql.Query("SELECT distinct " + column + " FROM tblgamedata order by " + column)
        If mydata.Rows.Count > 0 Then
            With textboxes
                .AutoCompleteCustomSource.Clear()
                For i As Integer = 0 To mydata.Rows.Count - 1
                    .AutoCompleteCustomSource.Add(mydata.Rows(i).Item(0))
                Next
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.CustomSource
            End With
        End If
    End Sub

    Private Sub addAutoSuggest(ByRef textboxes As TextBox)
        With textboxes
            .AutoCompleteCustomSource.Add(textboxes.Text)
        End With
    End Sub

    Private Sub setTextAuto()
        setAutoSuggest(txtGameType, "gameType")
        setAutoSuggest(txtComposers, "composers")
        setAutoSuggest(txtDeveloper, "developer")
        setAutoSuggest(txtDesigner, "designer")
        setAutoSuggest(txtPlatforms, "platforms")
        setAutoSuggest(txtPublishers, "publishers")
    End Sub

    Private Sub addTextAuto()
        addAutoSuggest(txtGameType)
        addAutoSuggest(txtComposers)
        addAutoSuggest(txtDeveloper)
        addAutoSuggest(txtDesigner)
        addAutoSuggest(txtPlatforms)
        addAutoSuggest(txtPublishers)
    End Sub


    Private Sub frmPlayStation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        selectRecord()
    End Sub

    Private Sub picCover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCover.Click
        Dim loc As String = PowerNET8.myBrowseDialog.browseImage("")

        If Not Directory.Exists(Application.StartupPath + "\Images\Play Station") Then
            PowerNET8.myFile.Share.Folders.createFolder("Images\Play Station")
        End If

        If txtGameName.Text <> "" And txtPlatforms.Text <> "" Then
            'create the folder for the game
            If Not Directory.Exists(Application.StartupPath + "\Images\" + txtPlatforms.Text + "\" + txtGameName.Text) Then
                PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text)
            End If

            Dim col() As String = loc.Split(".")


            If loc <> "" Then
                'get the location
                Dim nLoc As String = Application.StartupPath + "\Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\coverPhoto" + gameid.ToString + Now.ToString("MMddyyyyhhmmss") + "." + col(col.Length - 1)
                PowerNET8.myFile.Share.Files.copyFile(loc, nLoc)
                picCover.ImageLocation = nLoc
            Else
                picCover.ImageLocation = ""
            End If
            picCover.Refresh()

        Else
            MsgBox("Game name and Platform are required", MsgBoxStyle.Exclamation, "Unable to browse")
        End If

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click, cmdNew.Click
        Select Case CType(sender, Button).Text
            Case "Add", "New"
                addTextAuto()
                controllerField(False)
                clearField()
                gameid = 0
                txtGameName.Focus()
                cmdSave.Text = "Save"
                cmdPreview.Visible = False
                cmdNew.Visible = False
            Case "Save"

                If txtGameName.Text <> "" Then

                    'ADD GAME FILE
                    With mysql
                        .clear()
                        .setTable("tblgamedata")
                        .addValue(txtGameName.Text, "gameName")
                        .addValue(txtGameType.Text, "gameType")
                        .addValue(txtNoOfPlayed.Text, "noOfPlayed")
                        .addValue(cboEmulator.Text, "emulator")
                        .addValue(cboPlayers.Text, "Player")
                        .addValue(cboCountry.Text, "country")
                        .addValue(txtGameDescription.Text, "gameDesc")
                        .addValue(txtComposers.Text, "composers")
                        .addValue(txtDeveloper.Text, "developer")
                        .addValue(txtDesigner.Text, "designer")
                        .addValue(txtPlatforms.Text, "platforms")
                        .addValue(txtPublishers.Text, "publishers")
                        .addValue(txtCD1.Text.Replace("\", "~"), "gamefile")
                        .addValue(txtCD2.Text.Replace("\", "~"), "cd2")
                        .addValue(txtCD3.Text.Replace("\", "~"), "cd3")
                        .addValue(txtCD4.Text.Replace("\", "~"), "cd4")
                        .addValue(txtMemoryCard.Text.Replace("\", "~"), "memoryCard")
                        .addValue(1, "isVisible")

                        Dim dt As Date = dtReleasedDate.Value
                        .addValue(dt.ToString("yyyy-MM-dd hh:mm:ss"), "initialReleasedDate")


                        If gameid = 0 Then
                            gameid = .nextID("gameid")
                            .addValue(gameid, "gameid")
                            .addValue(Now.ToString("yyyy-MM-dd HH:mm:ss"), "dtCreated")
                            .addValue(userID, "createdBy")
                            .addValue(Now.ToString("yyyy-MM-dd HH:mm:ss"), "dtUpdated")
                            .addValue(userID, "updatedBy")
                            .Insert()
                            MsgBox("You have successfully added new record", MsgBoxStyle.Information, "Add Completed")
                        Else
                            .addValue(Now.ToString("yyyy-MM-dd HH:mm:ss"), "dtUpdated")
                            .addValue(userID, "updatedBy")
                            .Update("gameId", gameid.ToString)
                            MsgBox("You have successful updated the record", MsgBoxStyle.Information, "Update Completed")
                            GoTo cancel
                        End If
                    End With

                    'ADD IMAGE LOCATION
                    With mysql
                        .clear()
                        Dim mydata As DataTable = mysql.Query("SELECT * from tblgamedata_imageloc where gameID=" + gameid.ToString)
                        If mydata.Rows.Count > 0 Then
                            mysql.Query("DELETE FROM tblgamedata_imageloc where gameID=" + gameid.ToString)
                        End If
                        .setTable("tblgamedata_imageloc")
                        .addValue(gameid.ToString, "gameID")
                        .addValue("Images~" + txtPlatforms.Text + "~" + txtGameName.Text + "~" + getPictureName(picCover.ImageLocation.ToString), "coverPhoto")
                        .addValue("Images~" + txtPlatforms.Text + "~" + txtGameName.Text + "~Screenshot~" + getPictureName(pbCS1.ImageLocation.ToString), "backcoverPhoto")
                        .addValue("Images~" + txtPlatforms.Text + "~" + txtGameName.Text + "~Screenshot~" + getPictureName(pbSC2.ImageLocation.ToString), "sc2")
                        .addValue("Images~" + txtPlatforms.Text + "~" + txtGameName.Text + "~Screenshot~" + getPictureName(pbSC3.ImageLocation.ToString), "sc3")
                        .addValue("Images~" + txtPlatforms.Text + "~" + txtGameName.Text + "~Screenshot~" + getPictureName(pbSC4.ImageLocation.ToString), "sc4")
                        .addValue("Images~" + txtPlatforms.Text + "~" + txtGameName.Text + "~Screenshot~" + getPictureName(pbSC5.ImageLocation.ToString), "sc5")
                        .Insert()
                    End With

                    cmdNew.Visible = True
                    cmdPreview.Visible = True
                Else
                    MsgBox("Please enter required field", MsgBoxStyle.Exclamation, "Unable to Save")
                End If
            Case "Edit"
                cmdNew.Text = "Cancel"
                cmdNew.Visible = True
                cmdSave.Text = "Save"

                controllerField(False)
            Case "Cancel"
cancel:
                controllerField(True)
                cmdNew.Visible = True
                cmdNew.Text = "Add"
                cmdSave.Text = "Edit"
                cmdPreview.Visible = True

        End Select
    End Sub

    Private Function getPictureName(ByVal value As String) As String
        Dim col() As String = value.Split("\")
        Return col(col.Length - 1)
    End Function

    Private Sub pbCS1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbCS1.Click
        Dim loc As String = PowerNET8.myBrowseDialog.browseImage("")
        If txtGameName.Text <> "" And txtPlatforms.Text <> "" Then
            Dim col() As String = loc.Split(".")

            If txtGameName.Text <> "" Then
                If Not Directory.Exists(Application.StartupPath + "\Images\" + txtPlatforms.Text + "\" + txtGameName.Text) Then
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text)
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot")
                Else
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot")
                End If
            End If


            If loc <> "" Then
                'get the location

                Dim nLoc As String = Application.StartupPath + "\Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot\Screenshot" + gameid.ToString + Now.ToString("MMddyyyyhhmmss") + "." + col(col.Length - 1)
                PowerNET8.myFile.Share.Files.copyFile(loc, nLoc)
                pbCS1.ImageLocation = nLoc
            Else
                pbCS1.ImageLocation = ""
            End If
            pbCS1.Refresh()
        Else
            MsgBox("Game name and platform are required.", MsgBoxStyle.Exclamation, "Unable to browse")
        End If
    End Sub

    Private Sub pbSC2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSC2.Click
        Dim loc As String = PowerNET8.myBrowseDialog.browseImage("")
        If txtGameName.Text <> "" And txtPlatforms.Text <> "" Then
            Dim col() As String = loc.Split(".")

            If txtGameName.Text <> "" Then
                If Not Directory.Exists(Application.StartupPath + "\Images\" + txtPlatforms.Text + "\" + txtGameName.Text) Then
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text)
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot")
                Else
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot")
                End If
            End If


            If loc <> "" Then
                'get the location
                Dim nLoc As String = Application.StartupPath + "\Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot\Screenshot" + gameid.ToString + Now.ToString("MMddyyyyhhmmss") + "." + col(col.Length - 1)
                PowerNET8.myFile.Share.Files.copyFile(loc, nLoc)
                pbSC2.ImageLocation = nLoc
            Else
                pbSC2.ImageLocation = ""
            End If
            pbSC2.Refresh()
        Else
            MsgBox("Game name and platform are required.", MsgBoxStyle.Exclamation, "Unable to browse")
        End If
    End Sub

    Private Sub pbSC3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSC3.Click
        Dim loc As String = PowerNET8.myBrowseDialog.browseImage("")
        If txtGameName.Text <> "" And txtPlatforms.Text <> "" Then
            Dim col() As String = loc.Split(".")
            If txtGameName.Text <> "" Then
                If Not Directory.Exists(Application.StartupPath + "\Images\" + txtPlatforms.Text + "\" + txtGameName.Text) Then
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text)
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot")
                Else
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot")
                End If
            End If


            If loc <> "" Then
                'get the location
                Dim nLoc As String = Application.StartupPath + "\Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot\Screenshot" + gameid.ToString + Now.ToString("MMddyyyyhhmmss") + "." + col(col.Length - 1)
                PowerNET8.myFile.Share.Files.copyFile(loc, nLoc)
                pbSC3.ImageLocation = nLoc
            Else
                pbSC3.ImageLocation = ""
            End If
            pbSC3.Refresh()
        Else
            MsgBox("Game name and platform are required.", MsgBoxStyle.Exclamation, "Unable to browse")
        End If
    End Sub

    Private Sub pbSC4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSC4.Click
        Dim loc As String = PowerNET8.myBrowseDialog.browseImage("")
        If txtGameName.Text <> "" Then
            Dim col() As String = loc.Split(".")
            If txtGameName.Text <> "" Then
                If Not Directory.Exists(Application.StartupPath + "\Images\" + txtPlatforms.Text + "\" + txtGameName.Text) Then
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text)
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot")
                Else
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot")
                End If
            End If

            If loc <> "" Then
                'get the location
                Dim nLoc As String = Application.StartupPath + "\Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot\Screenshot" + gameid.ToString + Now.ToString("MMddyyyyhhmmss") + "." + col(col.Length - 1)
                PowerNET8.myFile.Share.Files.copyFile(loc, nLoc)
                pbSC4.ImageLocation = nLoc
            Else
                pbSC4.ImageLocation = ""
            End If
            pbSC4.Refresh()
        Else
            MsgBox("Game name and platform are required.", MsgBoxStyle.Exclamation, "Unable to browse")
        End If
    End Sub

    Private Sub pbSC5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSC5.Click
        Dim loc As String = PowerNET8.myBrowseDialog.browseImage("")
        If txtGameName.Text <> "" And txtPlatforms.Text <> "" Then
            Dim col() As String = loc.Split(".")

            If txtGameName.Text <> "" Then
                If Not Directory.Exists(Application.StartupPath + "\Images\" + txtPlatforms.Text + "\" + txtGameName.Text) Then
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text)
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot")
                Else
                    PowerNET8.myFile.Share.Folders.createFolder("Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot")
                End If
            End If

            If loc <> "" Then
                'get the location
                Dim nLoc As String = Application.StartupPath + "\Images\" + txtPlatforms.Text + "\" + txtGameName.Text + "\Screenshot\Screenshot" + gameid.ToString + Now.ToString("MMddyyyyhhmmss") + "." + col(col.Length - 1)
                PowerNET8.myFile.Share.Files.copyFile(loc, nLoc)
                pbSC5.ImageLocation = nLoc
            Else
                pbSC5.ImageLocation = ""
            End If
            pbSC5.Refresh()
        Else
            MsgBox("Game name and platform are required.", MsgBoxStyle.Exclamation, "Unable to browse")
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        With CType(MenuSourceControl, PictureBox)
            If .ImageLocation <> "" Then If File.Exists(.ImageLocation) Then PowerNET8.myFile.Share.Files.deleteFile(.ImageLocation)
            .ImageLocation = ""
            .Refresh()
        End With
    End Sub

    Private MenuSourceControl As Control
    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        MenuSourceControl = CType(sender, ContextMenuStrip).SourceControl
    End Sub

    Private Sub cmdBrowseGameFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCD1.Click, cmdCD2.Click, cmdCD3.Click, cmdCD4.Click, cmdMemoryCard.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        fd.Title = "Open Game File Dialog"
        fd.InitialDirectory = ""
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            Select Case CType(sender, Button).Name
                Case "cmdCD1"
                    txtCD1.Text = fd.FileName
                Case "cmdCD2"
                    txtCD2.Text = fd.FileName
                Case "cmdCD3"
                    txtCD3.Text = fd.FileName
                Case "cmdCD4"
                    txtCD4.Text = fd.FileName
                Case "cmdMemoryCard"
                    txtMemoryCard.Text = fd.FileName
            End Select
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        Dim frm As New lblDesigners
        With frm
            .gameid = gameid
            .Text = txtGameName.Text + " - Profile Game Preview"
            .ShowDialog()
        End With
    End Sub


End Class