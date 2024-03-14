Public Class frmEmulatorsFinder
    Dim mysql As New PowerNET8.mySQL.Init.SQL

    Private Sub reloadData()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblemulator order by emulator")

        dgvList.Rows.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            With dgvList
                .Rows.Add()
                .Rows(i).Cells(0).Value = mydata.Rows(i).Item("emulatorID")
                Dim path As String = mydata.Rows(i).Item("logo").ToString.Replace("~", "\")
                .Rows(i).Cells(1).Value = Image.FromFile(path)
                .Rows(i).Cells(2).Value = mydata.Rows(i).Item("emulator")
                .Rows(i).Cells(3).Value = mydata.Rows(i).Item("version")
                .Rows(i).Cells(4).Value = mydata.Rows(i).Item("platforms")

                Dim dt As Date = mydata.Rows(i).Item("dateReleased")
                .Rows(i).Cells(5).Value = dt.ToString("M/d/yyyy")
            End With
        Next
    End Sub

    Private Function getImage(ByVal id As String) As Image
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblgamedata_imageloc where gameID=" + id)
        If mydata.Rows.Count > 0 Then
            Dim path As String = mydata.Rows(0).Item("coverPhoto").ToString.Replace("~", "\")
            Return Image.FromFile(Application.StartupPath + "\" + path)
        End If
    End Function

    Private Sub frmEmulatorsFinder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        reloadData()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click, cmdEdit.Click, cmdView.Click
        Dim frm As New frmEmulators
        With frm
            Select Case CType(sender, Button).Name
                Case "cmdAdd"
                    .emulatorID = 0
                    .action = "add"
                    .ShowDialog()
                Case "cmdEdit"
                    If dgvList.RowCount > 0 Then
                        .emulatorID = dgvList.CurrentRow.Cells(0).Value
                        .action = "edit"
                        .ShowDialog()
                    End If
                Case "cmdView"
                    If dgvList.RowCount > 0 Then
                        .emulatorID = dgvList.CurrentRow.Cells(0).Value
                        .action = "view"
                        .ShowDialog()
                    End If
            End Select
        End With
    End Sub

    Private Sub dgvList_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellContentDoubleClick
        cmdAdd_Click(cmdView, Nothing)
    End Sub
End Class