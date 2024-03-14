Imports System.IO
Imports System.Diagnostics

Public Class frmEmulators
    Dim mysql As New PowerNET8.mySQL.Init.SQL
    Public emulatorID As Integer = 0
    Public action As String = ""
    Private Sub frmEmulators_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        selectRecord()
    End Sub

    Private Sub selectRecord()
        If action = "view" Or action = "edit" Then
            Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator where emulatorID=" + emulatorID.ToString)
            If mydata.Rows.Count > 0 Then
                pbLogo.ImageLocation = mydata.Rows(0).Item("logo").ToString.Replace("~", "\")
                cboPlatforms.Text = mydata.Rows(0).Item("platforms")
                txtEmulator.Text = mydata.Rows(0).Item("emulator")
                txtVersion.Text = mydata.Rows(0).Item("version")
                txtDeveloper.Text = mydata.Rows(0).Item("developer")
                txtContactSite.Text = mydata.Rows(0).Item("contactSite")
                dtDR.Value = mydata.Rows(0).Item("dateReleased")
                txtLocation.Text = mydata.Rows(0).Item("location").ToString.Replace("~", "\")

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

    Private Sub controllerField(Optional ByVal lock As Boolean = False)
        txtEmulator.ReadOnly = lock
        txtVersion.ReadOnly = lock
        txtDeveloper.ReadOnly = lock
        txtContactSite.ReadOnly = lock
        txtLocation.ReadOnly = lock

        pbLogo.Enabled = IIf(lock, False, True)
        cboPlatforms.Enabled = IIf(lock, False, True)
        dtDR.Enabled = IIf(lock, False, True)
    End Sub

    Private Sub clearField()
        txtEmulator.Text = ""
        txtVersion.Text = ""
        txtDeveloper.Text = ""
        txtContactSite.Text = ""
        txtLocation.Text = ""

        pbLogo.ImageLocation = Nothing
        cboPlatforms.Text = ""
        dtDR.Value = Nothing
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click, cmdNew.Click
        Select Case CType(sender, Button).Text
            Case "Save"
                With mysql
                    .setTable("tblemulator")
                    .addValue(cboPlatforms.Text, "platforms")
                    .addValue(txtEmulator.Text, "emulator")
                    .addValue(txtVersion.Text, "version")
                    .addValue(txtDeveloper.Text, "developer")
                    .addValue(txtContactSite.Text, "contactSite")
                    .addValue(pbLogo.ImageLocation.ToString.Replace("\", "~"), "logo")
                    Dim dt As Date = dtDR.Value
                    .addValue(dt.ToString("yyyy-MM-dd"), "dateReleased")
                    .addValue(txtLocation.Text.ToString.Replace("\", "~"), "location")

                    If emulatorID = 0 Then
                        emulatorID = .nextID("emulatorID")
                        .addValue(emulatorID, "emulatorID")
                        .addValue(Now, "dtCreated")
                        .addValue(userID, "createdBy")
                        .addValue(Now, "dtUpdated")
                        .addValue(userID, "updatedBy")
                        .Insert()
                        MsgBox("You have successfully added new record", MsgBoxStyle.Information, "Add Completed")
                    Else
                        .addValue(Now, "dtUpdated")
                        .addValue(userID, "updatedBy")
                        .Update("emulatorID", emulatorID.ToString)
                        MsgBox("You have successful updated the record", MsgBoxStyle.Information, "Update Completed")
                        GoTo cancel
                    End If
                End With
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
        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open Game File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            txtLocation.Text = fd.FileName
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbLogo.Click
        Dim loc As String = PowerNET8.myBrowseDialog.browseImage("")

        If Not Directory.Exists(Application.StartupPath + "\Images\Emulators") Then
            PowerNET8.myFile.Share.Folders.createFolder(Application.StartupPath + "\Images\Emulators")
        End If

        If Not Directory.Exists(Application.StartupPath + "\Images\Emulators\" + txtEmulator.Text) Then
            PowerNET8.myFile.Share.Folders.createFolder(Application.StartupPath + "\Images\Emulators\" + txtEmulator.Text)
        End If

        If loc <> "" Then
            'get the location
            Dim nLoc As String = Application.StartupPath + "\Images\Emulators\" + txtEmulator.Text + "\" + emulatorID.ToString + Now.ToString("MMddyyyyhhmmss") + ".jpg"
            PowerNET8.myFile.Share.Files.copyFile(loc, nLoc)
            pbLogo.ImageLocation = nLoc
        Else
            pbLogo.ImageLocation = ""
        End If
        pbLogo.Refresh()

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub txtLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocation.TextChanged
        If txtLocation.Text <> "" Then
            cmdSettings.Enabled = True
        Else
            cmdSettings.Enabled = False
        End If
    End Sub

    Private Sub cmdSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSettings.Click
        Try

            Process.Start(txtLocation.Text)
          
        Catch ex As Exception
            MsgBox("unable to locate the exe file, please relocate the data.", MsgBoxStyle.Exclamation, "Unable to Locate")
        End Try
    End Sub
End Class