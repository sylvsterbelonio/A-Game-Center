Imports System.Xml
Public Class frmMain

    Dim data As New DataTable
    Dim countValue As Integer = 0

    Private Sub utcMain_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles utcMain.SelectedTabChanged
        If utcMain.Tabs(0).Selected Then
            Me.Width = 247
            Me.Height = 153
            refreshRecord()
        Else
            Me.Width = 476
            Me.Height = 285
            refreshRecord()
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        set_Initialize()
        loadRecord()
    End Sub

    Private Sub set_Initialize()
        data.Columns.Add("title", GetType(String))
        data.Columns.Add("original", GetType(String))
        data.Columns.Add("destination", GetType(String))
    End Sub

    Private Sub EditItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditItemsToolStripMenuItem.Click
        Select Case CType(sender, ToolStripMenuItem).Text
            Case "Edit"
                Dim frm As New frmUnlock
                With frm
                    .ShowDialog()
                    If .return_value Then
                        SaveRecordToolStripMenuItem.Visible = True
                        EditItemsToolStripMenuItem.Visible = True
                        utcMain.Tabs(1).Visible = True
                        utcMain.Tabs(1).Selected = True
                        txtTitle.Focus()
                        txtTitle.Text = ""
                        txtDestinationPath.Text = ""
                        txtOriginalPath.Text = ""
                    End If
                End With
                CType(sender, ToolStripMenuItem).Text = "Cancel Edit"
            Case "Cancel Edit"
                CType(sender, ToolStripMenuItem).Text = "Edit"
                CType(sender, ToolStripMenuItem).Visible = False
                SaveRecordToolStripMenuItem.Visible = False
                utcMain.Tabs(1).Visible = False
                refreshRecord()
        End Select
    End Sub

    Private Sub lstListData_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstListData.MouseDoubleClick
        cmdAdd_Click(cmdEdit, Nothing)
    End Sub

    Private Sub lstListData_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstListData.SelectedIndexChanged
        If lstListData.Items.Count > 0 Then
            selectedRow = lstListData.SelectedIndex
            txtTitle.Text = ""
            txtDestinationPath.Text = ""
            txtOriginalPath.Text = ""
            cmdAdd.Text = "Add"
            cmdEdit.Text = "Edit"
            cmdDelete.Text = "Delete"
            cmdDelete.Enabled = True
            cmdEdit.Enabled = True
        Else
            cmdDelete.Enabled = False
            cmdEdit.Enabled = False
        End If
    End Sub
    Dim selectedRow As Integer = 0
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click, cmdEdit.Click, cmdDelete.Click
        Select Case CType(sender, Button).Text
            Case "New"
                txtTitle.Text = ""
                txtOriginalPath.Text = ""
                txtDestinationPath.Text = ""
                selectedRow = -1
                txtTitle.Focus()
                cmdAdd.Text = "Add"
                cmdEdit.Text = "Edit"
                cmdDelete.Text = "Delete"
                cmdEdit.Enabled = False
                cmdDelete.Enabled = False
            Case "Add"
                If txtTitle.Text <> "" Then
                    With data
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Item("title") = txtTitle.Text
                        .Rows(.Rows.Count - 1).Item("original") = txtOriginalPath.Text
                        .Rows(.Rows.Count - 1).Item("destination") = txtDestinationPath.Text
                        lstListData.Items.Add(txtTitle.Text)
                    End With
                    txtTitle.Text = ""
                    txtOriginalPath.Text = ""
                    txtDestinationPath.Text = ""
                    cmdEdit.Enabled = False
                    cmdDelete.Enabled = False
                Else
                    MsgBox("Please input title of the game")
                End If
            Case "Edit"
                If lstListData.SelectedIndex <> -1 Then
                    selectedRow = lstListData.SelectedIndex
                    txtTitle.Text = data.Rows(lstListData.SelectedIndex).Item("title")
                    txtOriginalPath.Text = data.Rows(lstListData.SelectedIndex).Item("original")
                    txtDestinationPath.Text = data.Rows(lstListData.SelectedIndex).Item("destination")
                    cmdAdd.Text = "New"
                    cmdEdit.Text = "Update"
                    cmdDelete.Text = "Cancel"
                End If
            Case "Update"
                With data
                    .Rows(lstListData.SelectedIndex).Item("title") = txtTitle.Text
                    .Rows(lstListData.SelectedIndex).Item("original") = txtOriginalPath.Text
                    .Rows(lstListData.SelectedIndex).Item("destination") = txtDestinationPath.Text
                End With

                lstListData.Items.Clear()
                For i As Integer = 0 To data.Rows.Count - 1
                    lstListData.Items.Add(data.Rows(i).Item("title"))
                Next

                MsgBox("Update Successfully", MsgBoxStyle.Information, "Update")
            Case "Cancel"
                selectedRow = -1
                cmdAdd.Text = "Add"
                cmdEdit.Text = "Edit"
                cmdDelete.Text = "Delete"
                txtDestinationPath.Text = ""
                txtOriginalPath.Text = ""
                txtTitle.Text = ""
                selectedRow = -1
            Case "Delete"
                If selectedRow <> -1 And lstListData.Items.Count > 0 Then
                    If MsgBox("Delete?", MsgBoxStyle.YesNo, "Delete Confirm") = MsgBoxResult.Yes Then
                        data.Rows(selectedRow).Delete()
                        txtTitle.Text = ""
                        txtDestinationPath.Text = ""
                        txtOriginalPath.Text = ""
                        cmdAdd.Text = "Add"
                        cmdEdit.Text = "Edit"
                        cmdDelete.Text = "Delete"
                    End If
                    selectedRow = -1
                    lstListData.Items.Clear()
                    For i As Integer = 0 To data.Rows.Count - 1
                        lstListData.Items.Add(data.Rows(i).Item("title"))
                    Next
                Else
                    MsgBox("No Record found.", MsgBoxStyle.Exclamation, "Unable To Delete")
                End If
        End Select

    End Sub
    Private Sub refreshRecord()
        cboSelection.Items.Clear()
        lstListData.Items.Clear()
        For i As Integer = 0 To data.Rows.Count - 1
            cboSelection.Items.Add(data.Rows(i).Item(0))
            lstListData.Items.Add(data.Rows(i).Item(0))
        Next
    End Sub

    Private Sub loadRecord()
        Dim xmlDoc As New XmlDocument()
        If IO.File.Exists("gamefile.xml") Then
            xmlDoc.Load("gamefile.xml")
            Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("Game_Data")
            Dim pID As String = "", pName As String = "", pPrice As String = ""
            For Each node As XmlNode In nodes
                With data
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Item("title") = node.SelectSingleNode("Title").InnerText
                    .Rows(.Rows.Count - 1).Item("original") = node.SelectSingleNode("Original_Path").InnerText
                    .Rows(.Rows.Count - 1).Item("destination") = node.SelectSingleNode("Destination_Path").InnerText
                End With
            Next
            Dim dv As New DataView(data)
            dv.Sort = "title"
            data = dv.ToTable

            cboSelection.Items.Clear()
            lstListData.Items.Clear()
            For i As Integer = 0 To data.Rows.Count - 1
                cboSelection.Items.Add(data.Rows(i).Item(0))
                lstListData.Items.Add(data.Rows(i).Item(0))
            Next
        End If
    End Sub


    Private Sub SaveRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveRecordToolStripMenuItem.Click
        'If IO.File.Exists("gamefile.xml") = False Then
        'declare our xmlwritersettings object
        Dim settings As New XmlWriterSettings()

        'lets tell to our xmlwritersettings that it must use indention for our xml
        settings.Indent = True

        'lets create the MyXML.xml document, the first parameter was the Path/filename of xml file
        ' the second parameter was our xml settings
        If IO.File.Exists("gamefile.xml") Then IO.File.Delete("gamefile.xml")
        Dim XmlWrt As XmlWriter = XmlWriter.Create("gamefile.xml", settings)

        With XmlWrt

            ' Write the Xml declaration.
            .WriteStartDocument()

            ' Write a comment.
            .WriteComment("Game File Configuration")

            ' Write the root element.
            .WriteStartElement("Data")

            For i As Integer = 0 To data.Rows.Count - 1
                ' The person nodes.
                ' Start our first person.
                .WriteStartElement("Game_Data")

                .WriteStartElement("Title")
                .WriteString(data.Rows(i).Item("title"))
                .WriteEndElement()

                .WriteStartElement("Original_Path")
                .WriteString(data.Rows(i).Item("original"))
                .WriteEndElement()


                .WriteStartElement("Destination_Path")
                .WriteString(data.Rows(i).Item("destination"))
                .WriteEndElement()

                ' The end of this person.
                .WriteEndElement()
            Next
            
            ' Close the XmlTextWriter.
            .WriteEndDocument()
            .Close()

        End With

        MessageBox.Show("Game file saved.")
        ' End If
    End Sub

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        If cboSelection.SelectedIndex <> -1 Then
            If MsgBox("Are you sure you want to load this game? [" + data.Rows(cboSelection.SelectedIndex).Item("title") + "]", MsgBoxStyle.YesNo, "Save Confirmation") = MsgBoxResult.Yes Then

                'from D:\ to C:\
                Dim orginalPath = data.Rows(cboSelection.SelectedIndex).Item("original")
                Dim destinationPath = data.Rows(cboSelection.SelectedIndex).Item("destination")
                Dim col() As String = orginalPath.ToString.Split("\")

                If IO.Directory.Exists(destinationPath + "\" + col(col.Length - 1)) Then
                    'System.IO.Directory.Delete(orginalPath, True)
                    My.Computer.FileSystem.CopyDirectory(destinationPath + "\" + col(col.Length - 1), orginalPath, True)
                    MsgBox(data.Rows(cboSelection.SelectedIndex).Item("title") + " game loaded!", MsgBoxStyle.Information, "Game Load Completed")
                Else
                    MsgBox("There is no saved file found to load the game.", MsgBoxStyle.Exclamation, "Unable to load")
                End If

               
            End If

        Else

            MsgBox("No game exist", MsgBoxStyle.Information, "Unable to load")
        End If

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboSelection.SelectedIndex <> -1 Then


            If MsgBox("Are you sure you want to save this game? [" + data.Rows(cboSelection.SelectedIndex).Item("title") + "]", MsgBoxStyle.YesNo, "Save Confirmation") = MsgBoxResult.Yes Then

                'from C:\ to D:\
                Dim orginalPath = data.Rows(cboSelection.SelectedIndex).Item("original")
                Dim destinationPath = data.Rows(cboSelection.SelectedIndex).Item("destination")
                Dim col() As String = orginalPath.ToString.Split("\")

                If IO.Directory.Exists(orginalPath) Then
                    If System.IO.Directory.Exists(destinationPath + "\" + col(col.Length - 1)) Then System.IO.Directory.Delete(destinationPath + "\" + col(col.Length - 1), True)

                    My.Computer.FileSystem.CopyDirectory(orginalPath, destinationPath + "\" + col(col.Length - 1), True)
                    MsgBox(data.Rows(cboSelection.SelectedIndex).Item("title") + " game saved!", MsgBoxStyle.Information, "Game Save Completed")

                Else
                    MsgBox("There is no game file found from the game.", MsgBoxStyle.Exclamation, "Unable to save")
                End If
             End If

        Else

            MsgBox("No game exist", MsgBoxStyle.Information, "Unable to save")
        End If


    End Sub

    Private Sub ExitApplicationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitApplicationToolStripMenuItem.Click
        End
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem1.Click
        MsgBox("This application helps to save and load game data of all games. If you want to save your game, please contact the administrator. Contact me: +09161319929.", MsgBoxStyle.Information, "Programmed and Developed by: Sylvster R. Belonio")
    End Sub
End Class
