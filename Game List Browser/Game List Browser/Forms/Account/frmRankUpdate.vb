Imports System.IO
Public Class frmRankUpdate
    Private mysql As New PowerNET8.mySQL.Init.SQL

    Public rankID As Integer = 2
    Public rankAction As String = "Down"

    Private Sub CButton1_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdOK.ClickButtonArea
        Me.Close()
    End Sub

    Private Sub frmRankUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect(mysql)
        reloadRank()
    End Sub

    Private Sub reloadRank()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblaccount_activity_rank where rankID=" + rankID.ToString)
        If mydata.Rows.Count > 0 Then
            If mydata.Rows(0).Item("rankName") = "None" Then
                lblPrevRank.Visible = False
                lblPrevPointsNeeded.Visible = False
                lblPrevRank.Visible = False
                lblPrevName.Visible = False

                'NEXT RANK
                Dim upRank = rankID + 2
                mydata = mysql.Query("SELECT * FROM tblaccount_activity_rank where rankID=" + upRank.ToString)
                If mydata.Rows.Count > 0 Then
                    lblNextRankName.Text = mydata.Rows(0).Item("rankName")
                    lblNextRankPointsNeeded.Text = FormatNumber(mydata.Rows(0).Item("fPoints"), 0) + " - " + FormatNumber(mydata.Rows(0).Item("tPoints"), 0)
                    Dim byteImage() As Byte = mydata.Rows(0).Item("rankLogo")
                    Dim Imager As New System.IO.MemoryStream(byteImage)
                    pcNextRankLogo.Image = Image.FromStream(Imager)
                End If

                My.Computer.Audio.Play(Application.StartupPath + "\Audio\Rank\level up.wav", AudioPlayMode.Background)
            Else
                'PREVIOUS RANK
                Dim upPrevRank As Integer = rankID - 1
                mydata = mysql.Query("SELECT * FROM tblaccount_activity_rank where rankID=" + upPrevRank.ToString)
                If mydata.Rows.Count > 0 Then
                    lblPrevName.Text = mydata.Rows(0).Item("rankName")
                    lblPrevPointsNeeded.Text = FormatNumber(mydata.Rows(0).Item("fPoints"), 0) + " - " + FormatNumber(mydata.Rows(0).Item("tPoints"), 0)
                    Dim byteImage() As Byte = mydata.Rows(0).Item("rankLogo")
                    Dim Imager As New System.IO.MemoryStream(byteImage)
                    pcPrevRankLogo.Image = Image.FromStream(Imager)

                    lblPrevRank.Visible = True
                    lblPrevPointsNeeded.Visible = True
                    lblPrevRank.Visible = True
                    lblPrevName.Visible = True
                End If
            End If

            If rankAction = "Up" Then
                Me.BackColor = Color.MediumSeaGreen
                Panel1.BackColor = Color.DarkGreen


                lblUPdate.Text = "LEVEL UP!!!!!"

                'CURRENT RANK

                mydata = mysql.Query("SELECT * FROM tblaccount_activity_rank where rankID=" + rankID.ToString)
                If mydata.Rows.Count > 0 Then
                    lblCurrentRankName.Text = mydata.Rows(0).Item("rankName")
                    'lblNextRankPointsNeeded.Text = FormatNumber(mydata.Rows(0).Item("fPoints"), 0) + " - " + FormatNumber(mydata.Rows(0).Item("tPoints"), 0)
                    Dim byteImage() As Byte = mydata.Rows(0).Item("rankLogo")
                    Dim Imager As New System.IO.MemoryStream(byteImage)
                    pcCurrentRank.Image = Image.FromStream(Imager)
                End If

                'NEXT RANK
                Dim upRank = rankID + 1
                mydata = mysql.Query("SELECT * FROM tblaccount_activity_rank where rankID=" + upRank.ToString)
                If mydata.Rows.Count > 0 Then
                    lblNextRankName.Text = mydata.Rows(0).Item("rankName")
                    lblNextRankPointsNeeded.Text = FormatNumber(mydata.Rows(0).Item("fPoints"), 0) + " - " + FormatNumber(mydata.Rows(0).Item("tPoints"), 0)
                    Dim byteImage() As Byte = mydata.Rows(0).Item("rankLogo")
                    Dim Imager As New System.IO.MemoryStream(byteImage)
                    pcNextRankLogo.Image = Image.FromStream(Imager)
                End If


                My.Computer.Audio.Play(Application.StartupPath + "\Audio\Rank\level up.wav", AudioPlayMode.Background)
            Else
                Me.BackColor = Color.IndianRed
                Panel1.BackColor = Color.Maroon

                'CURRENT RANK

                mydata = mysql.Query("SELECT * FROM tblaccount_activity_rank where rankID=" + rankID.ToString)
                If mydata.Rows.Count > 0 Then
                    lblCurrentRankName.Text = mydata.Rows(0).Item("rankName")
                    'lblNextRankPointsNeeded.Text = FormatNumber(mydata.Rows(0).Item("fPoints"), 0) + " - " + FormatNumber(mydata.Rows(0).Item("tPoints"), 0)
                    Dim byteImage() As Byte = mydata.Rows(0).Item("rankLogo")
                    Dim Imager As New System.IO.MemoryStream(byteImage)
                    pcCurrentRank.Image = Image.FromStream(Imager)
                End If

                'NEXT RANK
                Dim upRank = rankID + 1
                mydata = mysql.Query("SELECT * FROM tblaccount_activity_rank where rankID=" + upRank.ToString)
                If mydata.Rows.Count > 0 Then
                    lblNextRankName.Text = mydata.Rows(0).Item("rankName")
                    lblNextRankPointsNeeded.Text = FormatNumber(mydata.Rows(0).Item("fPoints"), 0) + " - " + FormatNumber(mydata.Rows(0).Item("tPoints"), 0)
                    Dim byteImage() As Byte = mydata.Rows(0).Item("rankLogo")
                    Dim Imager As New System.IO.MemoryStream(byteImage)
                    pcNextRankLogo.Image = Image.FromStream(Imager)
                End If

                lblUPdate.Text = "LEVEL DOWN!!!!!"
                My.Computer.Audio.Play(Application.StartupPath + "\Audio\Rank\level down.wav", AudioPlayMode.Background)
            End If
        End If

    End Sub

End Class