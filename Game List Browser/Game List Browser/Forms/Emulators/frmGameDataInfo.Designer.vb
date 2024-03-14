<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGameDataInfo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtGameType = New System.Windows.Forms.TextBox
        Me.txtGameName = New System.Windows.Forms.TextBox
        Me.txtNoOfPlayed = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboEmulator = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboCountry = New System.Windows.Forms.ComboBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtGameDescription = New System.Windows.Forms.TextBox
        Me.dtReleasedDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtComposers = New System.Windows.Forms.TextBox
        Me.txtDeveloper = New System.Windows.Forms.TextBox
        Me.txtDesigner = New System.Windows.Forms.TextBox
        Me.txtPlatforms = New System.Windows.Forms.TextBox
        Me.txtPublishers = New System.Windows.Forms.TextBox
        Me.cmdNew = New System.Windows.Forms.Button
        Me.cmdPreview = New System.Windows.Forms.Button
        Me.cmdCD1 = New System.Windows.Forms.Button
        Me.txtCD1 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboPlayers = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtCD2 = New System.Windows.Forms.TextBox
        Me.cmdCD2 = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtCD3 = New System.Windows.Forms.TextBox
        Me.cmdCD3 = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtCD4 = New System.Windows.Forms.TextBox
        Me.cmdCD4 = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtMemoryCard = New System.Windows.Forms.TextBox
        Me.cmdMemoryCard = New System.Windows.Forms.Button
        Me.pbSC5 = New System.Windows.Forms.PictureBox
        Me.pbSC2 = New System.Windows.Forms.PictureBox
        Me.pbSC4 = New System.Windows.Forms.PictureBox
        Me.pbSC3 = New System.Windows.Forms.PictureBox
        Me.pbCS1 = New System.Windows.Forms.PictureBox
        Me.picCover = New System.Windows.Forms.PictureBox
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dtReleasedDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSC5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSC2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSC4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSC3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(118, 26)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(287, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Game Name *"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(287, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Genre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(368, 290)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Initial Released Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(470, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "No. of Played"
        '
        'txtGameType
        '
        Me.txtGameType.Location = New System.Drawing.Point(371, 47)
        Me.txtGameType.Name = "txtGameType"
        Me.txtGameType.Size = New System.Drawing.Size(246, 20)
        Me.txtGameType.TabIndex = 4
        '
        'txtGameName
        '
        Me.txtGameName.Location = New System.Drawing.Point(371, 20)
        Me.txtGameName.Name = "txtGameName"
        Me.txtGameName.Size = New System.Drawing.Size(246, 20)
        Me.txtGameName.TabIndex = 2
        '
        'txtNoOfPlayed
        '
        Me.txtNoOfPlayed.Location = New System.Drawing.Point(547, 125)
        Me.txtNoOfPlayed.Name = "txtNoOfPlayed"
        Me.txtNoOfPlayed.Size = New System.Drawing.Size(69, 20)
        Me.txtNoOfPlayed.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(286, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Emulator"
        '
        'cboEmulator
        '
        Me.cboEmulator.FormattingEnabled = True
        Me.cboEmulator.Items.AddRange(New Object() {"PSX", "EPSXE", "PSX;EPSXE", "PCSX2", "Project64", "SEGA", "Fusion", "SEGA;Fusion", "ZSNES"})
        Me.cboEmulator.Location = New System.Drawing.Point(371, 99)
        Me.cboEmulator.Name = "cboEmulator"
        Me.cboEmulator.Size = New System.Drawing.Size(245, 21)
        Me.cboEmulator.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(628, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Country"
        '
        'cboCountry
        '
        Me.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCountry.FormattingEnabled = True
        Me.cboCountry.Items.AddRange(New Object() {"USA", "Japan", "Europe", "Asia"})
        Me.cboCountry.Location = New System.Drawing.Point(698, 122)
        Me.cboCountry.Name = "cboCountry"
        Me.cboCountry.Size = New System.Drawing.Size(236, 21)
        Me.cboCountry.TabIndex = 26
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(778, 338)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 26)
        Me.cmdSave.TabIndex = 43
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.Location = New System.Drawing.Point(859, 338)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 26)
        Me.cmdExit.TabIndex = 44
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(288, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 37)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Game Description"
        '
        'txtGameDescription
        '
        Me.txtGameDescription.Location = New System.Drawing.Point(371, 152)
        Me.txtGameDescription.Multiline = True
        Me.txtGameDescription.Name = "txtGameDescription"
        Me.txtGameDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGameDescription.Size = New System.Drawing.Size(246, 127)
        Me.txtGameDescription.TabIndex = 14
        '
        'dtReleasedDate
        '
        Me.dtReleasedDate.DateTime = New Date(2018, 10, 28, 0, 0, 0, 0)
        Me.dtReleasedDate.Location = New System.Drawing.Point(518, 286)
        Me.dtReleasedDate.Name = "dtReleasedDate"
        Me.dtReleasedDate.Size = New System.Drawing.Size(98, 21)
        Me.dtReleasedDate.TabIndex = 16
        Me.dtReleasedDate.Value = New Date(2018, 10, 28, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(628, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Composers"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(628, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Developer"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(628, 75)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Designer"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(288, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Platforms"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(627, 100)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Publishers"
        '
        'txtComposers
        '
        Me.txtComposers.Location = New System.Drawing.Point(697, 19)
        Me.txtComposers.Name = "txtComposers"
        Me.txtComposers.Size = New System.Drawing.Size(237, 20)
        Me.txtComposers.TabIndex = 18
        '
        'txtDeveloper
        '
        Me.txtDeveloper.Location = New System.Drawing.Point(697, 45)
        Me.txtDeveloper.Name = "txtDeveloper"
        Me.txtDeveloper.Size = New System.Drawing.Size(237, 20)
        Me.txtDeveloper.TabIndex = 20
        '
        'txtDesigner
        '
        Me.txtDesigner.Location = New System.Drawing.Point(697, 70)
        Me.txtDesigner.Name = "txtDesigner"
        Me.txtDesigner.Size = New System.Drawing.Size(237, 20)
        Me.txtDesigner.TabIndex = 22
        '
        'txtPlatforms
        '
        Me.txtPlatforms.Location = New System.Drawing.Point(371, 73)
        Me.txtPlatforms.Name = "txtPlatforms"
        Me.txtPlatforms.Size = New System.Drawing.Size(245, 20)
        Me.txtPlatforms.TabIndex = 6
        '
        'txtPublishers
        '
        Me.txtPublishers.Location = New System.Drawing.Point(697, 96)
        Me.txtPublishers.Name = "txtPublishers"
        Me.txtPublishers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPublishers.Size = New System.Drawing.Size(237, 20)
        Me.txtPublishers.TabIndex = 24
        '
        'cmdNew
        '
        Me.cmdNew.Location = New System.Drawing.Point(697, 338)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(75, 26)
        Me.cmdNew.TabIndex = 42
        Me.cmdNew.Text = "New"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'cmdPreview
        '
        Me.cmdPreview.Location = New System.Drawing.Point(12, 338)
        Me.cmdPreview.Name = "cmdPreview"
        Me.cmdPreview.Size = New System.Drawing.Size(264, 26)
        Me.cmdPreview.TabIndex = 0
        Me.cmdPreview.Text = "Preview"
        Me.cmdPreview.UseVisualStyleBackColor = True
        Me.cmdPreview.Visible = False
        '
        'cmdCD1
        '
        Me.cmdCD1.Location = New System.Drawing.Point(883, 170)
        Me.cmdCD1.Name = "cmdCD1"
        Me.cmdCD1.Size = New System.Drawing.Size(52, 23)
        Me.cmdCD1.TabIndex = 29
        Me.cmdCD1.Text = "Browse"
        Me.cmdCD1.UseVisualStyleBackColor = True
        '
        'txtCD1
        '
        Me.txtCD1.Location = New System.Drawing.Point(698, 172)
        Me.txtCD1.Name = "txtCD1"
        Me.txtCD1.Size = New System.Drawing.Size(179, 20)
        Me.txtCD1.TabIndex = 28
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(625, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Game File #1"
        '
        'cboPlayers
        '
        Me.cboPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlayers.FormattingEnabled = True
        Me.cboPlayers.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cboPlayers.Location = New System.Drawing.Point(371, 125)
        Me.cboPlayers.Name = "cboPlayers"
        Me.cboPlayers.Size = New System.Drawing.Size(86, 21)
        Me.cboPlayers.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(286, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "No. of Players"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(624, 204)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Game File #2"
        '
        'txtCD2
        '
        Me.txtCD2.Location = New System.Drawing.Point(697, 201)
        Me.txtCD2.Name = "txtCD2"
        Me.txtCD2.Size = New System.Drawing.Size(179, 20)
        Me.txtCD2.TabIndex = 31
        '
        'cmdCD2
        '
        Me.cmdCD2.Location = New System.Drawing.Point(883, 199)
        Me.cmdCD2.Name = "cmdCD2"
        Me.cmdCD2.Size = New System.Drawing.Size(52, 23)
        Me.cmdCD2.TabIndex = 32
        Me.cmdCD2.Text = "Browse"
        Me.cmdCD2.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(624, 233)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 13)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Game File #3"
        '
        'txtCD3
        '
        Me.txtCD3.Location = New System.Drawing.Point(697, 230)
        Me.txtCD3.Name = "txtCD3"
        Me.txtCD3.Size = New System.Drawing.Size(179, 20)
        Me.txtCD3.TabIndex = 34
        '
        'cmdCD3
        '
        Me.cmdCD3.Location = New System.Drawing.Point(883, 228)
        Me.cmdCD3.Name = "cmdCD3"
        Me.cmdCD3.Size = New System.Drawing.Size(52, 23)
        Me.cmdCD3.TabIndex = 35
        Me.cmdCD3.Text = "Browse"
        Me.cmdCD3.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(624, 262)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "Game File #4"
        '
        'txtCD4
        '
        Me.txtCD4.Location = New System.Drawing.Point(697, 259)
        Me.txtCD4.Name = "txtCD4"
        Me.txtCD4.Size = New System.Drawing.Size(179, 20)
        Me.txtCD4.TabIndex = 37
        '
        'cmdCD4
        '
        Me.cmdCD4.Location = New System.Drawing.Point(883, 257)
        Me.cmdCD4.Name = "cmdCD4"
        Me.cmdCD4.Size = New System.Drawing.Size(52, 23)
        Me.cmdCD4.TabIndex = 38
        Me.cmdCD4.Text = "Browse"
        Me.cmdCD4.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(624, 292)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(69, 13)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "Memory Card"
        '
        'txtMemoryCard
        '
        Me.txtMemoryCard.Location = New System.Drawing.Point(697, 289)
        Me.txtMemoryCard.Name = "txtMemoryCard"
        Me.txtMemoryCard.Size = New System.Drawing.Size(179, 20)
        Me.txtMemoryCard.TabIndex = 40
        '
        'cmdMemoryCard
        '
        Me.cmdMemoryCard.Location = New System.Drawing.Point(883, 287)
        Me.cmdMemoryCard.Name = "cmdMemoryCard"
        Me.cmdMemoryCard.Size = New System.Drawing.Size(52, 23)
        Me.cmdMemoryCard.TabIndex = 41
        Me.cmdMemoryCard.Text = "Browse"
        Me.cmdMemoryCard.UseVisualStyleBackColor = True
        '
        'pbSC5
        '
        Me.pbSC5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pbSC5.ContextMenuStrip = Me.ContextMenuStrip1
        Me.pbSC5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbSC5.Location = New System.Drawing.Point(228, 277)
        Me.pbSC5.Name = "pbSC5"
        Me.pbSC5.Size = New System.Drawing.Size(48, 47)
        Me.pbSC5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbSC5.TabIndex = 24
        Me.pbSC5.TabStop = False
        '
        'pbSC2
        '
        Me.pbSC2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pbSC2.ContextMenuStrip = Me.ContextMenuStrip1
        Me.pbSC2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbSC2.Location = New System.Drawing.Point(66, 277)
        Me.pbSC2.Name = "pbSC2"
        Me.pbSC2.Size = New System.Drawing.Size(48, 47)
        Me.pbSC2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbSC2.TabIndex = 21
        Me.pbSC2.TabStop = False
        '
        'pbSC4
        '
        Me.pbSC4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pbSC4.ContextMenuStrip = Me.ContextMenuStrip1
        Me.pbSC4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbSC4.Location = New System.Drawing.Point(174, 277)
        Me.pbSC4.Name = "pbSC4"
        Me.pbSC4.Size = New System.Drawing.Size(48, 47)
        Me.pbSC4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbSC4.TabIndex = 23
        Me.pbSC4.TabStop = False
        '
        'pbSC3
        '
        Me.pbSC3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pbSC3.ContextMenuStrip = Me.ContextMenuStrip1
        Me.pbSC3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbSC3.Location = New System.Drawing.Point(120, 277)
        Me.pbSC3.Name = "pbSC3"
        Me.pbSC3.Size = New System.Drawing.Size(48, 47)
        Me.pbSC3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbSC3.TabIndex = 22
        Me.pbSC3.TabStop = False
        '
        'pbCS1
        '
        Me.pbCS1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pbCS1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.pbCS1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbCS1.Location = New System.Drawing.Point(12, 277)
        Me.pbCS1.Name = "pbCS1"
        Me.pbCS1.Size = New System.Drawing.Size(48, 47)
        Me.pbCS1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbCS1.TabIndex = 17
        Me.pbCS1.TabStop = False
        '
        'picCover
        '
        Me.picCover.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.picCover.ContextMenuStrip = Me.ContextMenuStrip1
        Me.picCover.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCover.Location = New System.Drawing.Point(12, 12)
        Me.picCover.Name = "picCover"
        Me.picCover.Size = New System.Drawing.Size(264, 249)
        Me.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCover.TabIndex = 0
        Me.picCover.TabStop = False
        '
        'frmGameDataInfo
        '
        Me.AcceptButton = Me.cmdSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdExit
        Me.ClientSize = New System.Drawing.Size(947, 372)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtMemoryCard)
        Me.Controls.Add(Me.cmdMemoryCard)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtCD4)
        Me.Controls.Add(Me.cmdCD4)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtCD3)
        Me.Controls.Add(Me.cmdCD3)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtCD2)
        Me.Controls.Add(Me.cmdCD2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCD1)
        Me.Controls.Add(Me.cmdCD1)
        Me.Controls.Add(Me.cboPlayers)
        Me.Controls.Add(Me.pbSC5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPublishers)
        Me.Controls.Add(Me.cmdNew)
        Me.Controls.Add(Me.cmdPreview)
        Me.Controls.Add(Me.txtDesigner)
        Me.Controls.Add(Me.txtDeveloper)
        Me.Controls.Add(Me.txtPlatforms)
        Me.Controls.Add(Me.txtComposers)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.pbSC2)
        Me.Controls.Add(Me.dtReleasedDate)
        Me.Controls.Add(Me.pbSC4)
        Me.Controls.Add(Me.pbSC3)
        Me.Controls.Add(Me.txtGameDescription)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.pbCS1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cboCountry)
        Me.Controls.Add(Me.cboEmulator)
        Me.Controls.Add(Me.picCover)
        Me.Controls.Add(Me.txtGameName)
        Me.Controls.Add(Me.txtGameType)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNoOfPlayed)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGameDataInfo"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game File"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dtReleasedDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSC5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSC2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSC4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSC3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picCover As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtGameType As System.Windows.Forms.TextBox
    Friend WithEvents txtGameName As System.Windows.Forms.TextBox
    Friend WithEvents txtNoOfPlayed As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboEmulator As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboCountry As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents pbCS1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtGameDescription As System.Windows.Forms.TextBox
    Friend WithEvents pbSC2 As System.Windows.Forms.PictureBox
    Friend WithEvents pbSC3 As System.Windows.Forms.PictureBox
    Friend WithEvents pbSC4 As System.Windows.Forms.PictureBox
    Friend WithEvents pbSC5 As System.Windows.Forms.PictureBox
    Friend WithEvents dtReleasedDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtComposers As System.Windows.Forms.TextBox
    Friend WithEvents txtDeveloper As System.Windows.Forms.TextBox
    Friend WithEvents txtDesigner As System.Windows.Forms.TextBox
    Friend WithEvents txtPlatforms As System.Windows.Forms.TextBox
    Friend WithEvents txtPublishers As System.Windows.Forms.TextBox
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents cmdPreview As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdCD1 As System.Windows.Forms.Button
    Friend WithEvents txtCD1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboPlayers As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCD2 As System.Windows.Forms.TextBox
    Friend WithEvents cmdCD2 As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCD3 As System.Windows.Forms.TextBox
    Friend WithEvents cmdCD3 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCD4 As System.Windows.Forms.TextBox
    Friend WithEvents cmdCD4 As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtMemoryCard As System.Windows.Forms.TextBox
    Friend WithEvents cmdMemoryCard As System.Windows.Forms.Button
End Class
