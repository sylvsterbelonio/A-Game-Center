Public Class frmShadow
    Public action As String
    Public return_value As String
    Public rankID As String
    Public rankAction As String

    Private Sub frmShadow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case action
            Case "gift box"
                Dim frm As New frmGiftBox
                With frm
                    .ShowDialog()
                End With
            Case "log in"
                Dim frm As New frmLogIn
                With frm
                    .ShowDialog()
                    return_value = .return_value
                End With
            Case "slot machine"
                Dim frm As New frmSlotMachines
                With frm
                    .ShowDialog()
                End With
            Case "level update"
                Dim frm As New frmRankUpdate
                With frm
                    .rankID = rankID
                    .rankAction = rankAction
                    .ShowDialog()
                End With
        End Select
        Me.Dispose()
        Me.Close()
    End Sub
End Class