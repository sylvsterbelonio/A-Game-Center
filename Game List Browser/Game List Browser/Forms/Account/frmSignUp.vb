Imports System.IO
Imports System.Diagnostics

Public Class frmSignUp
    Private mysql As New PowerNET8.mySQL.Init.SQL
    Public accountID As Integer = 0
    Public action As String = ""

    Private Sub frmSignUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        setObject()
        selectRecord()
    End Sub

    Private Sub setObject()
        Dim colObject As New Collection
        With colObject
            .Clear()
            .Add(txtConfirmPassword)
            .Add(udtBDate)
            .Add(txtFirstname)
            .Add(txtLastname)
            .Add(txtmiddleName)
            .Add(txtPassword)
            .Add(txtUsername)
        End With
        Dim clsSkin As New LibraryCode.Skin
        clsSkin.setSkin(colObject)
    End Sub

    Private Sub selectRecord()
        If action = "view" Or action = "edit" Then
            Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=" + accountID.ToString)
            If mydata.Rows.Count > 0 Then
                txtFirstname.Text = mydata.Rows(0).Item("firstname")
                txtmiddleName.Text = mydata.Rows(0).Item("middlename")
                txtLastname.Text = mydata.Rows(0).Item("lastname")
                optM.Checked = IIf(mydata.Rows(0).Item("gender") = "M", True, False)
                optF.Checked = IIf(mydata.Rows(0).Item("gender") = "F", True, False)
                udtBDate.Value = mydata.Rows(0).Item("birthdate")
                txtUsername.Text = mydata.Rows(0).Item("username")
                txtPassword.Text = mydata.Rows(0).Item("password")
                txtConfirmPassword.Text = mydata.Rows(0).Item("password")
                pcPic.ImageLocation = mydata.Rows(0).Item("picture").ToString.Replace("~", "\")
            End If
            If action = "view" Then
                controllerField(True)
                cmdCreate.Text = "Edit"
                cmdCreate.Text = "Add"
            Else
                txtFirstname.Focus()
                controllerField(False)
                cmdCreate.Text = "Save"
                cmdCancel.Text = "Add"
            End If
        End If
    End Sub

    Private Sub controllerField(Optional ByVal lock As Boolean = False)
        txtFirstname.ReadOnly = lock
        txtmiddleName.ReadOnly = lock
        txtLastname.ReadOnly = lock
        txtPassword.ReadOnly = lock
        txtUsername.ReadOnly = lock

        optF.Enabled = IIf(lock, False, True)
        optM.Enabled = IIf(lock, False, True)
        udtBDate.Enabled = IIf(lock, False, True)
        pcPic.Enabled = IIf(lock, False, True)
    End Sub

    Private Sub clearField()
        txtFirstname.Text = ""
        txtmiddleName.Text = ""
        txtLastname.Text = ""
        txtPassword.Text = ""
        txtUsername.Text = ""

        pcPic.ImageLocation = Nothing
        optF.Checked = False
        optM.Checked = False
        udtBDate.Value = Nothing
    End Sub

    Private Sub pcPic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pcPic.Click
        Dim loc As String = PowerNET8.myBrowseDialog.browseImage("")

        If Not Directory.Exists(Application.StartupPath + "\Images\Accounts") Then
            PowerNET8.myFile.Share.Folders.createFolder(Application.StartupPath + "\Images\Accounts")
        End If

        If Not Directory.Exists(Application.StartupPath + "\Images\Accounts\" + txtUsername.Text) Then
            PowerNET8.myFile.Share.Folders.createFolder(Application.StartupPath + "\Images\Accounts\" + txtUsername.Text)
        End If

        If loc <> "" Then
            'get the location
            Dim nLoc As String = Application.StartupPath + "\Images\Accounts\" + txtUsername.Text + "\" + accountID.ToString + Now.ToString("MMddyyyyhhmmss") + ".jpg"
            PowerNET8.myFile.Share.Files.copyFile(loc, nLoc)
            pcPic.ImageLocation = nLoc
        Else
            pcPic.ImageLocation = ""
        End If
        pcPic.Refresh()
    End Sub

    Private Function getPictureName(ByVal value As String) As String
        Dim col() As String = value.Split("\")
        Return col(col.Length - 1)
    End Function

    Private Function validateUsername(ByVal username As String) As Boolean
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount where username like '" + username + "'")
        If mydata.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function


    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub udtBDate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles udtBDate.GotFocus
        udtBDate.Appearance.BackColor = Color.AliceBlue
    End Sub

    Private Sub udtBDate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles udtBDate.LostFocus
        udtBDate.Appearance.BackColor = Color.White
    End Sub

    Private Sub My8Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreate.Click
        Select Case CType(sender, Button).Text
            Case "Add", "New"
                controllerField(False)
                clearField()
                accountID = 0
                txtFirstname.Focus()
                cmdCancel.Text = "Save"
                cmdCreate.Visible = False
            Case "Create"
                If txtUsername.Text <> "" Then
                    If validateUsername(txtUsername.Text) Then
                        If txtPassword.Text = txtConfirmPassword.Text Then
                            If Len(txtPassword.Text) > 5 Then


                                'ADD GAME FILE
                                With mysql
                                    .clear()
                                    .setTable("tblaccount")
                                    If pcPic.ImageLocation <> "" Then
                                        .addValue("Images~Accounts~" + txtUsername.Text + "~" + getPictureName(pcPic.ImageLocation.ToString), "picture")
                                    End If
                                    .addValue(txtFirstname.Text, "firstname")
                                    .addValue(txtmiddleName.Text, "middlename")
                                    .addValue(txtLastname.Text, "lastname")
                                    .addValue(IIf(optM.Checked, "M", IIf(optF.Checked, "F", "")), "gender")
                                    .addValue(udtBDate.Value, "birthdate")
                                    .addValue(txtUsername.Text, "username")
                                    .addValue(.crypt(txtPassword.Text), "password")
                                    If accountID = 0 Then
                                        accountID = .nextID("accountID")
                                        .addValue(accountID, "accountID")
                                        .addValue(Now, "dtCreated")
                                        .addValue(userID, "createdBy")
                                        .addValue(Now, "dtUpdated")
                                        .addValue(userID, "updatedBy")
                                        .Insert()
                                        MsgBox("You have successfully created an account", MsgBoxStyle.Information, "Create Account Completed")
                                        Me.Close()
                                    Else
                                        .addValue(Now, "dtUpdated")
                                        .addValue(userID, "updatedBy")
                                        .Update("accountID", accountID)
                                        MsgBox("You have successfully updated your account", MsgBoxStyle.Information, "Update Completed")
                                        GoTo cancel
                                    End If
                                End With
                            Else
                                txtPassword.Focus()
                                MsgBox("Password must have at least 6 character long!", MsgBoxStyle.Exclamation, "Password Short")
                            End If
                        Else
                            txtPassword.Focus()
                            txtPassword.Text = ""
                            txtConfirmPassword.Text = ""
                            MsgBox("Password does not match!", MsgBoxStyle.Exclamation, "Password Mismatch")
                        End If
                    Else
                        txtUsername.Focus()
                        txtUsername.Text = ""
                        MsgBox("Username already exist, please try another.", MsgBoxStyle.Exclamation, "Username Exist")
                    End If
                Else
                    txtUsername.Focus()
                    MsgBox("Username is required", MsgBoxStyle.Information, "Username is missing")
                End If
            Case "Edit"
                cmdCancel.Text = "Cancel"
                cmdCancel.Visible = True
                cmdCreate.Text = "Save"
                controllerField(False)
            Case "Cancel"
cancel:
                Me.Close()
                'controllerField(True)
                'cmdNew.Visible = True
                'cmdNew.Text = "Add"
                'cmdSave.Text = "Edit"
        End Select
    End Sub

    Private Sub My8Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class