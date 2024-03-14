Public Class frmTPConversion
    Private mysql As New PowerNET8.mySQL.Init.SQL
    Private maxTP As Integer
    Private Sub frmTPConversion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        getCurrentTP()
        reloadRequest()
    End Sub

    Private Sub getCurrentTP()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblrewards_my_status where accountID=" + userID.ToString)
        If mydata.Rows.Count Then
            maxTP = mydata.Rows(0).Item("TP")
            lblMaxTP.Text = "/" + FormatNumber(maxTP.ToString, 2)
            txtTP.Value = 0
            txtTP.Maximum = maxTP
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTP.ValueChanged
        lblConverted.Text = txtTP.Value.ToString + "/Min"
    End Sub

    Private Sub CButton1_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdConvert.ClickButtonArea
        If txtTP.Value Mod 30 = 0 Then
            If txtTP.Value >= 30 Then
                If MsgBox("Are you sure you want to convert this TP into Minutes?", MsgBoxStyle.YesNo, "TP Conversion Confirm") = MsgBoxResult.Yes Then
                    With mysql
                        .setTable("tblrewards_tp_conversion")
                        .addValue(userID.ToString, "accountID")
                        .addValue(txtTP.Value, "tp")
                        .addValue(txtTP.Value, "minutes")
                        .addValue((txtTP.Value / 30) * 5, "pesos")
                        .addValue("Pending", "status")
                        .addValue(Now.ToString("yyyy-MM-dd H:m:s"), "dtRequested")
                        .Insert()
                    End With
                    MsgBox("See the administrator to grant your request.", MsgBoxStyle.Information, "Administrator")
                    With mysql
                        .setTable("tblrewards_my_status")
                        .addValue(maxTP - txtTP.Value, "TP")
                        .Update("accountID", userID.ToString)
                    End With

                    'POST NEWSFEED
                    With mysql
                        .setTable("tblaccount_newsfeed")
                        .addValue(userID.ToString, "accountID")
                        .addValue("TP Conversion", "type")
                        .addValue("Request to convert TP into Time", "name")
                        .addValue("~ is requesting to the administrator to convert his/her TP with the total number of " + txtTP.Value.ToString + " into " + txtTP.Value.ToString + " mins. for the amount of P" + FormatNumber((txtTP.Value / 30) * 5, 2), "description")
                        .addValue(Now.ToString("yyyy-MM-dd H:m:s"), "dateUpdate")
                        .Insert()
                    End With

                    reloadRequest()
                    getCurrentTP()
                End If
            Else
                MsgBox("Minimum of TP conversion must at least 30 TP and above.", MsgBoxStyle.Exclamation, "Minimum of 30TP")
            End If
        Else
            MsgBox("The Conversion of your TP must be divisible by 30.", MsgBoxStyle.Exclamation, "Must Divisible by 30")
        End If

    End Sub

    Private Sub reloadRequest()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblrewards_tp_conversion where accountID=" + userID.ToString)
        With MyNavigationGrid1
            .set_class(mysql)
            .Set_Data(dgvConversionRequest)
            .Set_SELECT(" tp as 'TP', minutes as 'MINUTES', pesos as '(P)ESOS', status as 'STATUS', dtRequested as 'DATE REQUESTED', dtGranted as 'DATE GRANTED'")
            .Set_FROM(" tblrewards_tp_conversion")
            .Set_WHERE(" accountID=" + userID.ToString)
            .Set_ORDER(" dtGranted desc")
            .Execute()
        End With
    End Sub


    Private Sub cmdConvertAll_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdConvertAll.ClickButtonArea
        Dim availableLoop As Integer = maxTP
        Dim counter As Integer = 0
        Do While availableLoop >= 30
            counter += 1
            availableLoop -= 30
        Loop
        txtTP.Value = counter * 30
    End Sub
End Class