Imports System.IO

Public Class frmGameType
    Dim mysql As New PowerNET8.mySQL.Init.SQL
    Public gameTypeID As Integer = 0
    Public action As String = ""

    Private Sub frmGameType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        selectRecord()
    End Sub

    Private Sub controllerField(Optional ByVal lock As Boolean = False)
        txtGameType.ReadOnly = lock
        txtcountry.ReadOnly = lock
        txtMarkets.ReadOnly = lock
        txtowner.ReadOnly = lock
        txtWebsite.ReadOnly = lock
        dtReleasedDate.Enabled = IIf(lock, False, True)
        pbCover.Enabled = IIf(lock, False, True)
    End Sub

    Private Sub clearField()
        txtGameType.Text = ""
        txtcountry.Text = ""
        txtMarkets.Text = ""
        txtowner.Text = ""
        txtWebsite.Text = ""
        dtReleasedDate.Value = Nothing
        pbCover.ImageLocation = Nothing
    End Sub

    Private Sub selectRecord()
        If action = "view" Or action = "edit" Then
            Dim mydata As DataTable = mysql.Query("SELECT * FROM tblgametype where gameTypeID=" + gameTypeID.ToString)
            If mydata.Rows.Count > 0 Then

                pbCover.ImageLocation = mydata.Rows(0).Item("logo").ToString.Replace("~", "\")
                txtGameType.Text = mydata.Rows(0).Item("product")
                txtowner.Text = mydata.Rows(0).Item("owner")
                txtcountry.Text = mydata.Rows(0).Item("country")
                dtReleasedDate.Value = mydata.Rows(0).Item("introduced")
                txtMarkets.Text = mydata.Rows(0).Item("markets")
                txtWebsite.Text = mydata.Rows(0).Item("website")

            End If

            If action = "view" Then
                controllerField(True)
                cmdSave.Text = "Edit"
                cmdNew.Text = "Add"
            Else
                controllerField(False)
                cmdSave.Text = "Save"
                cmdNew.Text = "Add"
            End If

        End If
    End Sub

    Private Sub imgCover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbCover.Click
        Dim loc As String = PowerNET8.myBrowseDialog.browseImage("")

        If Not Directory.Exists(Application.StartupPath + "\Images\Game Type") Then
            PowerNET8.myFile.Share.Folders.createFolder("Images\Game Type")
        End If

        If txtGameType.Text <> "" Then
            'create the folder for the game
            If Not Directory.Exists(Application.StartupPath + "\Images\Game Type\" + txtGameType.Text) Then
                PowerNET8.myFile.Share.Folders.createFolder("Images\Game Type\" + txtGameType.Text)
            End If


            If loc <> "" Then
                'get the location
                Dim nLoc As String = Application.StartupPath + "\Images\Game Type\" + txtGameType.Text + "\coverPhoto" + gameTypeID.ToString + Now.ToString("MMddyyyyhhmmss") + ".jpg"
                PowerNET8.myFile.Share.Files.copyFile(loc, nLoc)
                pbCover.ImageLocation = nLoc
            Else
                pbCover.ImageLocation = ""
            End If
            pbCover.Refresh()

        Else
            MsgBox("Game name is required", MsgBoxStyle.Exclamation, "Unable to browse")
        End If
    End Sub

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click, cmdSave.Click
        Select Case CType(sender, Button).Text
            Case "Add"
                controllerField(False)
                clearField()
                gameTypeID = 0
                txtGameType.Focus()
                cmdSave.Text = "Save"
                cmdNew.Visible = False
            Case "Save"
                If txtGameType.Text <> "" Then
                    'ADD GAME FILE
                    With mysql
                        .clear()
                        .setTable("tblgametype")
                        'Dim col() As String = pbCover.ImageLocation.ToString.Split("\")
                        '.Dim loc As String = "Images~Game Type~  col(col.Length-1) "
                        .addValue(pbCover.ImageLocation.ToString.Replace("\", "~"), "logo")
                        .addValue(txtGameType, "product")
                        .addValue(txtowner.Text, "owner")
                        .addValue(txtcountry.Text, "country")
                        Dim dt As Date = dtReleasedDate.Value
                        .addValue(dt.ToString("yyyy-MM-dd hh:mm:ss "), "introduced")
                        .addValue(txtMarkets.Text, "markets")
                        .addValue(txtWebsite.Text, "website")

                        If gameTypeID = 0 Then
                            gameTypeID = .nextID("gameTypeID")
                            .addValue(gameTypeID, "gameTypeID")
                            .addValue(Now, "dtCreated")
                            .addValue(userID, "createdBy")
                            .addValue(Now, "dtUpdated")
                            .addValue(userID, "updatedBy")
                            .Insert()
                            MsgBox("You have successfully added new record", MsgBoxStyle.Information, "Add Completed")
                        Else
                            .addValue(Now, "dtUpdated")
                            .addValue(userID, "updatedBy")
                            .Update("gameTypeID", gameTypeID.ToString)
                            MsgBox("You have successful updated the record", MsgBoxStyle.Information, "Update Completed")
                            GoTo cancel
                        End If
                    End With
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
        End Select
    End Sub


End Class