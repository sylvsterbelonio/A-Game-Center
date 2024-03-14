Public Class frmLogIn
    Private mysql As New PowerNET8.mySQL.Init.SQL
    Private clsSkin As New LibraryCode.Skin
    Private colObject As New Collection
    Public return_value As String = ""

    Private Sub frmLogIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        return_value = ""
        setObject()
    End Sub

    Private Sub setObject()
        With colObject
            .Clear()
            .Add(txtUsername)
            .Add(txtPassword)
        End With
        ' clsSkin.setSkin(colObject)
        txtUsername.Focus()
    End Sub

    Private Sub My8Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogIn.Click
        If txtUsername.Text <> "" And txtPassword.Text <> "" Then
            Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount where username = '" + txtUsername.Text + "'")
            If mydata.Rows.Count > 0 Then
                mydata = mysql.Query("SELECT * FROM tblaccount where username = '" + txtUsername.Text + "' and password ='" + mysql.crypt(txtPassword.Text) + "'")
                If mydata.Rows.Count > 0 Then
                    ' userID1 = mydata.Rows(0).Item("accountID")
                    return_value = mydata.Rows(0).Item("accountID")
                    'setAccountInfo(mysql)
                    Me.Close()
                Else
                    txtPassword.Focus()
                    txtPassword.Text = ""
                    MsgBox("Password does not match!", MsgBoxStyle.Exclamation, "Password Incorrect")
                End If
            Else
                txtUsername.Text = ""
                txtUsername.Focus()
                MsgBox("Username does not exist, please try again", MsgBoxStyle.Exclamation, "Username Failure")
            End If
        Else
            MsgBox("Please fill up the required field", MsgBoxStyle.Information, "Required Field")
        End If
    End Sub

    Private Sub My8Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub txtUsername_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.GotFocus, txtPassword.GotFocus
        sender.backcolor = Color.FromArgb(64, 64, 64)
    End Sub

    Private Sub txtUsername_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.LostFocus, txtPassword.LostFocus
        sender.backcolor = Color.FromArgb(21, 21, 21)
    End Sub

End Class