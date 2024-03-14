Public Class frmLock
    Public return_value As String = ""
    Private Sub My8Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles My8Button1.Click
        If txtLockPassword.Text = "Masterkey2019" Then
            return_value = "yes"
            Me.Close()
        Else
            MsgBox("Invalid Password", MsgBoxStyle.Exclamation, "Error Password")
            txtLockPassword.Text = ""
            txtLockPassword.Focus()
        End If
    End Sub
End Class