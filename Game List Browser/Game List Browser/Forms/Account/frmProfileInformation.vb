Imports System.IO

Public Class frmProfileInformation
    Private mysql As New PowerNET8.mySQL.Init.SQL

    Private Sub frmProfileInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        setSkin()
        reloadRecord()
    End Sub

    Private Sub setSkin()
        Dim colObject As New Collection
        Dim clsSKin As New LibraryCode.Skin
        With colObject
            .Clear()
            .Add(txtFirstname)
            .Add(txtMiddlename)
            .Add(txtLastname)
            .Add(txtAddress)
            .Add(txtMunicipality)
            .Add(txtProvince)
            .Add(txtContact)
            .Add(txtMessageBoard)
            .Add(txtOldpassword)
            .Add(txtNewpassword)
            .Add(txtConfirmPassword)
        End With
        clsSKin.setSkin(colObject)
    End Sub

    Private Sub reloadRecord()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount where accountID=" + userID.ToString)
        If mydata.Rows.Count > 0 Then

            pcProfilePhoto.ImageLocation = Application.StartupPath + "\" + mydata.Rows(0).Item("picture").ToString.Replace("~", "\")
            pcCoverPhoto.ImageLocation = Application.StartupPath + "\" + mydata.Rows(0).Item("coverPhoto").ToString.Replace("~", "\")

            If pcProfilePhoto.ImageLocation <> "" Then lnkProfilePhotoRemove.Visible = True
            If pcCoverPhoto.ImageLocation <> "" Then lnkCoverPhotoRemove.Visible = True

            lblFullName.Text = mydata.Rows(0).Item("firstname").ToString.ToUpper + " " + mydata.Rows(0).Item("middlename").ToString.ToUpper + " " + mydata.Rows(0).Item("lastname").ToString.ToUpper
            txtFirstname.Text = mydata.Rows(0).Item("firstname")
            txtMiddlename.Text = mydata.Rows(0).Item("middlename")
            txtLastname.Text = mydata.Rows(0).Item("lastname")
            If mydata.Rows(0).Item("gender") = "M" Then
                optM.Checked = True
            ElseIf mydata.Rows(0).Item("gender") = "F" Then
                optF.Checked = True
            End If
            Dim dt As Date = mydata.Rows(0).Item("birthdate")
            udtDateBirth.Value = dt
            If Not IsDBNull(mydata.Rows(0).Item("address")) Then txtAddress.Text = mydata.Rows(0).Item("address")
            txtMunicipality.Text = mydata.Rows(0).Item("city")
            txtProvince.Text = mydata.Rows(0).Item("province")
            txtContact.Text = mydata.Rows(0).Item("contactNo")
            If Not IsDBNull(mydata.Rows(0).Item("messageBoard")) Then txtMessageBoard.Text = mydata.Rows(0).Item("messageBoard")
            lblUsername.Text = mydata.Rows(0).Item("username")
            lblDtCreated.Text = mydata.Rows(0).Item("dtCreated")
        End If

    



    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If txtFirstname.Text <> "" And txtLastname.Text <> "" Then
            With mysql
                .setTable("tblaccount")
                .addValue(txtFirstname, "firstname")
                .addValue(txtMiddlename, "middlename")
                .addValue(txtLastname, "lastname")
                If optM.Checked Then
                    .addValue("M", "gender")
                ElseIf optF.Checked Then
                    .addValue("F", "gender")
                End If
                .addValue(udtDateBirth.Value, "birthdate")
                .addValue(txtAddress, "address")
                .addValue(txtMunicipality, "city")
                .addValue(txtProvince, "province")
                .addValue(txtContact, "contactNo")
                .addValue(txtMessageBoard, "messageBoard")
                .Update("accountID", userID.ToString)
                MsgBox("Successfully updated your profile record", MsgBoxStyle.Information, "Update Completed")
                lblFullName.Text = txtFirstname.Text.ToUpper + " " + txtMiddlename.Text.ToUpper + " " + txtLastname.Text.ToUpper
            End With
        End If
    End Sub

    Private Sub cmdChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangePassword.Click
        If lblUsername.Text <> "" And txtOldpassword.Text <> "" Then
            Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount where username = '" + lblUsername.Text + "'")
            If mydata.Rows.Count > 0 Then
                mydata = mysql.Query("SELECT * FROM tblaccount where username = '" + lblUsername.Text + "' and password ='" + mysql.crypt(txtOldpassword.Text) + "'")
                If mydata.Rows.Count > 0 Then
                    If txtOldpassword.Text <> "" And txtNewpassword.Text <> "" Then
                        If txtConfirmPassword.Text = txtNewpassword.Text Then
                            With mysql
                                .setTable("tblaccount")
                                .addValue(.crypt(txtNewpassword.Text), "password")
                                .Update("accountID", userID.ToString)
                                MsgBox("Password successfully changed!", MsgBoxStyle.Information, "Change Password")
                                txtOldpassword.Text = ""
                                txtNewpassword.Text = ""
                            End With
                        Else
                            MsgBox("Old and New Password does not match! ", MsgBoxStyle.Exclamation, "Mismatch Password")
                        End If
                    Else
                        MsgBox("Please fill up the old password and new password", MsgBoxStyle.Exclamation, "Unable to Proceed")
                    End If

                Else
                    txtOldpassword.Focus()
                    txtOldpassword.Text = ""
                    MsgBox("Password does not match!", MsgBoxStyle.Exclamation, "Password Incorrect")
                End If
            Else
                MsgBox("Username does not exist, please try again", MsgBoxStyle.Exclamation, "Username Failure")
            End If
        Else
            MsgBox("Please fill up the required field", MsgBoxStyle.Information, "Required Field")
        End If
    End Sub

    Private Sub pcProfilePhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pcProfilePhoto.Click
        Dim loc As String = PowerNET8.myBrowseDialog.browseImage("")

        If Not Directory.Exists(Application.StartupPath + "\Images\Accounts") Then
            PowerNET8.myFile.Share.Folders.createFolder("Images\Accounts")
        End If

        If lblUsername.Text <> "" Then
            'create the folder for the game
            If Not Directory.Exists(Application.StartupPath + "\Images\Accounts\" + lblUsername.Text) Then
                PowerNET8.myFile.Share.Folders.createFolder("Images\Accounts\" + lblUsername.Text)
            End If

            Dim col() As String = loc.Split(".")


            If loc <> "" Then
                'get the location
                Dim nLoc As String = Application.StartupPath + "\Images\Accounts\" + lblUsername.Text + userID.ToString + Now.ToString("MMddyyyyhhmmss") + "." + col(col.Length - 1)
                PowerNET8.myFile.Share.Files.copyFile(loc, nLoc)
                pcProfilePhoto.ImageLocation = nLoc
            Else
                pcProfilePhoto.ImageLocation = ""
            End If
            pcProfilePhoto.Refresh()

            With mysql
                .setTable("tblaccount")
                .addValue("Images~Accounts~" + getPictureName(pcProfilePhoto.ImageLocation.ToString), "picture")
                .Update("accountID", userID.ToString)
            End With
            lnkProfilePhotoRemove.Visible = True
        Else
            MsgBox("Game name is required", MsgBoxStyle.Exclamation, "Unable to browse")
        End If

    End Sub

    Private Sub pcCoverPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pcCoverPhoto.Click
        Dim loc As String = PowerNET8.myBrowseDialog.browseImage("")

        If Not Directory.Exists(Application.StartupPath + "\Images\Accounts") Then
            PowerNET8.myFile.Share.Folders.createFolder("Images\Accounts")
        End If

        If lblUsername.Text <> "" Then
            'create the folder for the game
            If Not Directory.Exists(Application.StartupPath + "\Images\Accounts\" + lblUsername.Text) Then
                PowerNET8.myFile.Share.Folders.createFolder("Images\Accounts\" + lblUsername.Text)
            End If

            Dim col() As String = loc.Split(".")


            If loc <> "" Then
                'get the location
                Dim nLoc As String = Application.StartupPath + "\Images\Accounts\" + lblUsername.Text + userID.ToString + Now.ToString("MMddyyyyhhmmss") + "." + col(col.Length - 1)
                PowerNET8.myFile.Share.Files.copyFile(loc, nLoc)
                pcCoverPhoto.ImageLocation = nLoc
            Else
                pcCoverPhoto.ImageLocation = ""
            End If
            pcCoverPhoto.Refresh()

            With mysql
                .setTable("tblaccount")
                .addValue("Images~Accounts~" + getPictureName(pcCoverPhoto.ImageLocation.ToString), "coverPhoto")
                .Update("accountID", userID.ToString)
            End With
            lnkCoverPhotoRemove.Visible = True
        Else
            MsgBox("Game name is required", MsgBoxStyle.Exclamation, "Unable to browse")
        End If
    End Sub

    Private Function getPictureName(ByVal value As String) As String
        Dim col() As String = value.Split("\")
        Return col(col.Length - 1)
    End Function

    Private Sub lnkProfilePhotoRemove_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkProfilePhotoRemove.LinkClicked
        pcProfilePhoto.ImageLocation = Nothing
        With mysql
            .setTable("tblaccount")
            .addValue("", "picture")
            .Update("accountID", userID.ToString)
        End With
        lnkProfilePhotoRemove.Visible = False
    End Sub

    Private Sub lnkCoverPhotoRemove_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCoverPhotoRemove.LinkClicked
        pcCoverPhoto.ImageLocation = Nothing
        With mysql
            .setTable("tblaccount")
            .addValue("", "coverPhoto")
            .Update("accountID", userID.ToString)
        End With
        lnkCoverPhotoRemove.Visible = False
    End Sub
End Class