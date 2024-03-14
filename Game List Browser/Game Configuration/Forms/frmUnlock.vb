Public Class frmUnlock
    Public return_value As Boolean = False
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPassword.Text = "Masterkey2011" Then
                return_value = True
                Me.Close()
            Else
                MsgBox("Invalid Password", MsgBoxStyle.Exclamation, "Error")
                txtPassword.Text = ""
            End If
        End If
    End Sub
End Class