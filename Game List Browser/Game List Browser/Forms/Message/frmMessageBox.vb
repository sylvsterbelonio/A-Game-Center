Public Class frmMessageBox
    Private mysql As New PowerNET8.mySQL.Init.SQL
    Private imageLocs As String = ""


    Private Sub frmMessageBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tlpInsideInbox.RowStyles(1).Height = 0
        tlpInsideInbox.RowStyles(3).Height = 0
        connect(mysql)
        generateMessageFromGender()
    End Sub

    Private Sub My8Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreate.Click
        If cmdCreate.Text = "Create Message" Then
            tlpInsideInbox.RowStyles(1).Height = 45
            tlpInsideInbox.RowStyles(3).Height = 139
            cmdCreate.Text = "Cancel Message"
            txtMessage.Text = ""
            cmdCreate.Standard_ThemeColor = PowerNET8.myColor.Share.SystemColor.BackgroundColor.StandardColor.DColors.Red

            txtRecipient.Focus()
        Else
            tlpInsideInbox.RowStyles(3).Height = 0
            tlpInsideInbox.RowStyles(1).Height = 0
            cmdCreate.Text = "Create Message"
            txtRecipient.Text = ""

            cmdCreate.Standard_ThemeColor = PowerNET8.myColor.Share.SystemColor.BackgroundColor.StandardColor.DColors.Blue
        End If
    End Sub

    Private Sub txtMessage_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMessage.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtMessage.Text <> "" Then
                e.SuppressKeyPress = True

                Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount where username='" + txtRecipient.Text + "'")
                If mydata.Rows.Count > 0 Then
                    With mysql
                        .setTable("tblmessage")
                        .addValue(userID.ToString, "accountID")
                        .addValue(mydata.Rows(0).Item("accountID"), "recipientID")
                        .addValue(txtMessage.Text, "message")
                        .addValue(imageLocs, "image")
                        .addValue(0, "isReadByRecipient")
                        .addValue(Now.ToString("yyyy-MM-dd H:m:s"), "textDelivered")
                        .Insert()
                    End With
                    txtMessage.Text = Nothing
                    txtMessage.Text.Replace("\\n", "")

                    cmdSend.Focus()
                Else
                    cmdSend.Enabled = False
                End If
            Else
                MsgBox("Invalid recipient, please try again.", MsgBoxStyle.Exclamation, "Unable to send")
                txtRecipient.Focus()
            End If
        End If
    End Sub

    Private Sub txtMessage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMessage.TextChanged
        If txtMessage.Text <> "" Then
            cmdSend.Enabled = True
        Else
            cmdSend.Enabled = False
        End If
        lblMaxAllowedCharacter.Text = "Max Allowed Character: " + txtMessage.Text.Count.ToString + "/300"
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        ContextMenuStrip1.Show(sender.parent, sender.Location)
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        ContextMenuStrip1.Show(sender.parent, sender.Location)
    End Sub

    Private Sub generateMessageFromGender()
        Dim mydata As DataTable = mysql.Query("select messageID, accountID,recipientID,message, textDelivered from tblmessage where accountID=" + userID.ToString + " group by recipientID order by textDelivered desc")

        flpListPersonBox.Controls.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            createMessageMe(flpListPersonBox, mydata.Rows(i).Item("recipientID"), mydata.Rows(i).Item("message"), mydata.Rows(i).Item("textDelivered"))
        Next


    End Sub

    Private Function getPictureLogo(ByVal id As Integer) As Image
        Dim mydata As DataTable = mysql.Query("SELECT picture FROM tblaccount where accountID=" + id.ToString)
        If mydata.Rows.Count > 0 Then
            If Not IsDBNull(mydata.Rows(0).Item(0)) Then
                Return Image.FromFile(Application.StartupPath + "\" + mydata.Rows(0).Item(0).ToString.Replace("~", "\"))
            Else
                Return My.Resources.profile_icon1
            End If
        Else
            Return My.Resources.profile_icon1
        End If
    End Function

    Private Function getName(ByVal id As Integer) As String
        Dim mydata As DataTable = mysql.Query("SELECT firstname, middlename, lastname FROM tblaccount where accountID=" + id.ToString)
        If mydata.Rows.Count > 0 Then
            If mydata.Rows(0).Item(1).ToString.Count > 1 Then
                Return mydata.Rows(0).Item(0) + " " + mydata.Rows(0).Item(1).ToString.Substring(0, 1) + ". " + mydata.Rows(0).Item(2)
            Else
                Return mydata.Rows(0).Item(0) + " " + mydata.Rows(0).Item(1).ToString + " " + mydata.Rows(0).Item(2)
            End If
        End If
    End Function




    Private Sub createMessageMe(ByRef leftPane As FlowLayoutPanel, ByVal recipientID As Integer, ByVal msg As String, ByVal txtDelivered As DateTime)

        Dim panelInbox As New Panel
        With panelInbox
            .AccessibleDescription = "default"
            .Dock = DockStyle.Top
            .BackColor = Color.AliceBlue
            .Tag = "3"
            .Height = 66
        End With

        Dim pcLogo As New PictureBox
        With pcLogo
            .SizeMode = PictureBoxSizeMode.StretchImage
            .Height = 56
            .Width = 54
            .Left = 5
            .Top = 5
            .Image = getPictureLogo(recipientID)
            panelInbox.Controls.Add(pcLogo)
        End With

        Dim lblName As New Label
        With lblName
            Dim oldFont As Font = New Font(.Font.FontFamily, 8.25, FontStyle.Bold, .Font.Unit)
            .Font = oldFont
            .Height = 16
            .Left = 60
            .Top = 5
            .Text = getName(recipientID)
            panelInbox.Controls.Add(lblName)
        End With

        Dim lblMsg As New Label
        With lblMsg
            .AutoSize = False
            .ForeColor = Color.Gray
            .Left = 60
            .Top = 21
            .Width = 137
            .Height = 28
            .Text = msg
            panelInbox.Controls.Add(lblMsg)
        End With

        Dim lblTime As New Label
        With lblTime
            Dim oldFont As Font = New Font(.Font.FontFamily, 6.25, FontStyle.Regular, .Font.Unit)
            .Font = oldFont
            .AutoSize = False
            .Left = 93
            .Top = 48
            .Width = 105
            .Height = 16
            .TextAlign = ContentAlignment.TopRight
            .Text = txtDelivered.ToString("yyyy-MM-dd H:m:s")
            panelInbox.Controls.Add(lblTime)
        End With
        leftPane.Controls.Add(panelInbox)

    End Sub


    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click

    End Sub

    Private Sub Panel1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.MouseLeave

    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class