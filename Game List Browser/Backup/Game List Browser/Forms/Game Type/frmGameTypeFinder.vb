Public Class frmGameTypeFinder
    Dim mysql As New PowerNET8.mySQL.Init.SQL

    Private Sub reloadData()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblgametype order by product")

        dgvList.Rows.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            With dgvList
                .Rows.Add()
                .Rows(i).Cells(0).Value = mydata.Rows(i).Item("gameTypeID")
                Dim path As String = mydata.Rows(i).Item("logo").ToString.Replace("~", "\")
                .Rows(i).Cells(1).Value = Image.FromFile(path)
                .Rows(i).Cells(2).Value = mydata.Rows(i).Item("product")
                .Rows(i).Cells(3).Value = mydata.Rows(i).Item("owner")
                Dim dt As Date = mydata.Rows(i).Item("introduced")
                .Rows(i).Cells(4).Value = dt.ToString("M/d/yyyy")
            End With
        Next
    End Sub

    Private Sub frmGameTypeFinder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        reloadData()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click, cmdEdit.Click, cmdView.Click
        Dim frm As New frmGameType
        With frm
            Select Case CType(sender, Button).Name
                Case "cmdAdd"
                    .gameTypeID = 0
                    .action = "add"
                    .ShowDialog()
                Case "cmdEdit"
                    If dgvList.RowCount > 0 Then
                        .gameTypeID = dgvList.CurrentRow.Cells(0).Value
                        .action = "edit"
                        .ShowDialog()
                    End If
                Case "cmdView"
                    If dgvList.RowCount > 0 Then
                        .gameTypeID = dgvList.CurrentRow.Cells(0).Value
                        .action = "view"
                        .ShowDialog()
                    End If
            End Select
        End With
    End Sub



    Private Sub dgvList_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellContentDoubleClick
        If dgvList.RowCount > 0 Then
            cmdAdd_Click(cmdView, Nothing)
        End If
    End Sub

    Private Sub dgvList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellContentClick

    End Sub
End Class