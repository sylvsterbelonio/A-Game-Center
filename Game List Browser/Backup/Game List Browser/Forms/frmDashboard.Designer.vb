<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashBoard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashBoard))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ExToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ModulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GameTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GameDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.UnlockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsRewards = New System.Windows.Forms.ToolStripMenuItem
        Me.GidToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SpinATicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClaimTimePointsRewardsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FeedbackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsSignIn = New System.Windows.Forms.ToolStripButton
        Me.sp6 = New System.Windows.Forms.ToolStripSeparator
        Me.tsNotification = New System.Windows.Forms.ToolStripSplitButton
        Me.tsProfile = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.tsHeading = New System.Windows.Forms.ToolStripLabel
        Me.tsMessage = New System.Windows.Forms.ToolStripSplitButton
        Me.sp3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsTicket = New System.Windows.Forms.ToolStripLabel
        Me.tsTicketLogo = New System.Windows.Forms.ToolStripLabel
        Me.tsTP = New System.Windows.Forms.ToolStripLabel
        Me.tsTPlogo = New System.Windows.Forms.ToolStripLabel
        Me.sp2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsPoints = New System.Windows.Forms.ToolStripLabel
        Me.sp1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsRank = New System.Windows.Forms.ToolStripLabel
        Me.tsRankPics = New System.Windows.Forms.ToolStripLabel
        Me.sp5 = New System.Windows.Forms.ToolStripSeparator
        Me.tsTicketReady = New System.Windows.Forms.ToolStripButton
        Me.sp4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsGiftStatus = New System.Windows.Forms.ToolStripButton
        Me.statFooter = New PowerNET8.MyStatusViewer
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tGiftRewards = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Silver
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ModulesToolStripMenuItem, Me.tsRewards, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(974, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ExToolStripMenuItem})
        Me.FileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(163, 6)
        '
        'ExToolStripMenuItem
        '
        Me.ExToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.ExToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ExToolStripMenuItem.Name = "ExToolStripMenuItem"
        Me.ExToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
                    Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.ExToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ExToolStripMenuItem.Text = "Exit"
        '
        'ModulesToolStripMenuItem
        '
        Me.ModulesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GameTypeToolStripMenuItem, Me.EToolStripMenuItem, Me.GameDataToolStripMenuItem, Me.ToolStripSeparator1, Me.UnlockToolStripMenuItem})
        Me.ModulesToolStripMenuItem.Name = "ModulesToolStripMenuItem"
        Me.ModulesToolStripMenuItem.Size = New System.Drawing.Size(96, 20)
        Me.ModulesToolStripMenuItem.Text = "&Parent Control"
        Me.ModulesToolStripMenuItem.Visible = False
        '
        'GameTypeToolStripMenuItem
        '
        Me.GameTypeToolStripMenuItem.Name = "GameTypeToolStripMenuItem"
        Me.GameTypeToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.GameTypeToolStripMenuItem.Text = "Game Type"
        '
        'EToolStripMenuItem
        '
        Me.EToolStripMenuItem.Name = "EToolStripMenuItem"
        Me.EToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.EToolStripMenuItem.Text = "&Emulator"
        '
        'GameDataToolStripMenuItem
        '
        Me.GameDataToolStripMenuItem.Name = "GameDataToolStripMenuItem"
        Me.GameDataToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.GameDataToolStripMenuItem.Text = "&Game Data Information"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(248, 6)
        '
        'UnlockToolStripMenuItem
        '
        Me.UnlockToolStripMenuItem.Name = "UnlockToolStripMenuItem"
        Me.UnlockToolStripMenuItem.ShortcutKeys = CType((((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
                    Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.F12), System.Windows.Forms.Keys)
        Me.UnlockToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.UnlockToolStripMenuItem.Text = "Lock Settings"
        '
        'tsRewards
        '
        Me.tsRewards.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GidToolStripMenuItem, Me.SpinATicketToolStripMenuItem, Me.ClaimTimePointsRewardsToolStripMenuItem})
        Me.tsRewards.Name = "tsRewards"
        Me.tsRewards.Size = New System.Drawing.Size(63, 20)
        Me.tsRewards.Text = "Rewards"
        Me.tsRewards.Visible = False
        '
        'GidToolStripMenuItem
        '
        Me.GidToolStripMenuItem.Name = "GidToolStripMenuItem"
        Me.GidToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.GidToolStripMenuItem.Text = "Daily Gift Rewards"
        '
        'SpinATicketToolStripMenuItem
        '
        Me.SpinATicketToolStripMenuItem.Name = "SpinATicketToolStripMenuItem"
        Me.SpinATicketToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.SpinATicketToolStripMenuItem.Text = "Slots Machine Rewards"
        '
        'ClaimTimePointsRewardsToolStripMenuItem
        '
        Me.ClaimTimePointsRewardsToolStripMenuItem.Name = "ClaimTimePointsRewardsToolStripMenuItem"
        Me.ClaimTimePointsRewardsToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ClaimTimePointsRewardsToolStripMenuItem.Text = "Claim Time Points Rewards"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FeedbackToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'FeedbackToolStripMenuItem
        '
        Me.FeedbackToolStripMenuItem.Name = "FeedbackToolStripMenuItem"
        Me.FeedbackToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FeedbackToolStripMenuItem.Text = "&About"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSignIn, Me.sp6, Me.tsNotification, Me.tsProfile, Me.ToolStripSeparator6, Me.tsHeading, Me.tsMessage, Me.sp3, Me.tsTicket, Me.tsTicketLogo, Me.tsTP, Me.tsTPlogo, Me.sp2, Me.tsPoints, Me.sp1, Me.tsRank, Me.tsRankPics, Me.sp5, Me.tsTicketReady, Me.sp4, Me.tsGiftStatus})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(974, 43)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsSignIn
        '
        Me.tsSignIn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsSignIn.BackColor = System.Drawing.Color.Transparent
        Me.tsSignIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tsSignIn.ForeColor = System.Drawing.Color.White
        Me.tsSignIn.Image = Global.Game_List_Browser.My.Resources.Resources._1437561088_User_Info
        Me.tsSignIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSignIn.Name = "tsSignIn"
        Me.tsSignIn.RightToLeftAutoMirrorImage = True
        Me.tsSignIn.Size = New System.Drawing.Size(60, 40)
        Me.tsSignIn.Text = "Log In"
        '
        'sp6
        '
        Me.sp6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.sp6.Name = "sp6"
        Me.sp6.Size = New System.Drawing.Size(6, 43)
        Me.sp6.Visible = False
        '
        'tsNotification
        '
        Me.tsNotification.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsNotification.AutoSize = False
        Me.tsNotification.ForeColor = System.Drawing.Color.White
        Me.tsNotification.Image = CType(resources.GetObject("tsNotification.Image"), System.Drawing.Image)
        Me.tsNotification.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNotification.Name = "tsNotification"
        Me.tsNotification.Size = New System.Drawing.Size(100, 40)
        Me.tsNotification.Text = "Notification"
        Me.tsNotification.Visible = False
        '
        'tsProfile
        '
        Me.tsProfile.AutoSize = False
        Me.tsProfile.BackgroundImage = Global.Game_List_Browser.My.Resources.Resources.profile_icon1
        Me.tsProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tsProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsProfile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsProfile.Name = "tsProfile"
        Me.tsProfile.Size = New System.Drawing.Size(40, 40)
        Me.tsProfile.Text = "ToolStripButton1"
        Me.tsProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.tsProfile.ToolTipText = "Profile Record"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 43)
        '
        'tsHeading
        '
        Me.tsHeading.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsHeading.ForeColor = System.Drawing.Color.White
        Me.tsHeading.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tsHeading.Name = "tsHeading"
        Me.tsHeading.Size = New System.Drawing.Size(109, 40)
        Me.tsHeading.Text = "WELCOME GUEST!"
        Me.tsHeading.ToolTipText = "Notification"
        '
        'tsMessage
        '
        Me.tsMessage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsMessage.AutoSize = False
        Me.tsMessage.ForeColor = System.Drawing.Color.White
        Me.tsMessage.Image = CType(resources.GetObject("tsMessage.Image"), System.Drawing.Image)
        Me.tsMessage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsMessage.Name = "tsMessage"
        Me.tsMessage.Size = New System.Drawing.Size(70, 40)
        Me.tsMessage.Text = "Inbox"
        Me.tsMessage.Visible = False
        '
        'sp3
        '
        Me.sp3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.sp3.Name = "sp3"
        Me.sp3.Size = New System.Drawing.Size(6, 43)
        Me.sp3.Visible = False
        '
        'tsTicket
        '
        Me.tsTicket.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsTicket.ForeColor = System.Drawing.Color.White
        Me.tsTicket.Name = "tsTicket"
        Me.tsTicket.Size = New System.Drawing.Size(21, 40)
        Me.tsTicket.Text = "x 0"
        Me.tsTicket.ToolTipText = "Your Total Ticket for Slot Machine Raffle Draw"
        Me.tsTicket.Visible = False
        '
        'tsTicketLogo
        '
        Me.tsTicketLogo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsTicketLogo.AutoSize = False
        Me.tsTicketLogo.BackColor = System.Drawing.Color.Transparent
        Me.tsTicketLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsTicketLogo.Name = "tsTicketLogo"
        Me.tsTicketLogo.Size = New System.Drawing.Size(25, 40)
        Me.tsTicketLogo.ToolTipText = "Ticket Logo"
        Me.tsTicketLogo.Visible = False
        '
        'tsTP
        '
        Me.tsTP.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsTP.ForeColor = System.Drawing.Color.White
        Me.tsTP.Name = "tsTP"
        Me.tsTP.Size = New System.Drawing.Size(24, 40)
        Me.tsTP.Text = " x 0"
        Me.tsTP.ToolTipText = "Your Total Timie Points (TP)"
        Me.tsTP.Visible = False
        '
        'tsTPlogo
        '
        Me.tsTPlogo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsTPlogo.AutoSize = False
        Me.tsTPlogo.BackColor = System.Drawing.Color.Transparent
        Me.tsTPlogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsTPlogo.Name = "tsTPlogo"
        Me.tsTPlogo.Padding = New System.Windows.Forms.Padding(10)
        Me.tsTPlogo.Size = New System.Drawing.Size(25, 40)
        Me.tsTPlogo.ToolTipText = "Your TP Logo"
        Me.tsTPlogo.Visible = False
        '
        'sp2
        '
        Me.sp2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.sp2.Name = "sp2"
        Me.sp2.Size = New System.Drawing.Size(6, 43)
        Me.sp2.Visible = False
        '
        'tsPoints
        '
        Me.tsPoints.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsPoints.ForeColor = System.Drawing.Color.White
        Me.tsPoints.Name = "tsPoints"
        Me.tsPoints.Size = New System.Drawing.Size(52, 40)
        Me.tsPoints.Text = "Points: 0"
        Me.tsPoints.ToolTipText = "Your Overall Game Points"
        Me.tsPoints.Visible = False
        '
        'sp1
        '
        Me.sp1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.sp1.Name = "sp1"
        Me.sp1.Size = New System.Drawing.Size(6, 43)
        Me.sp1.Visible = False
        '
        'tsRank
        '
        Me.tsRank.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRank.ForeColor = System.Drawing.Color.White
        Me.tsRank.Name = "tsRank"
        Me.tsRank.Size = New System.Drawing.Size(41, 40)
        Me.tsRank.Text = "Rank ?"
        Me.tsRank.ToolTipText = "You Current Rank"
        Me.tsRank.Visible = False
        '
        'tsRankPics
        '
        Me.tsRankPics.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRankPics.AutoSize = False
        Me.tsRankPics.BackColor = System.Drawing.Color.Transparent
        Me.tsRankPics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tsRankPics.ForeColor = System.Drawing.Color.White
        Me.tsRankPics.Name = "tsRankPics"
        Me.tsRankPics.Size = New System.Drawing.Size(40, 40)
        Me.tsRankPics.ToolTipText = "Your Rank Logo"
        '
        'sp5
        '
        Me.sp5.Name = "sp5"
        Me.sp5.Size = New System.Drawing.Size(6, 43)
        Me.sp5.Visible = False
        '
        'tsTicketReady
        '
        Me.tsTicketReady.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsTicketReady.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsTicketReady.Image = CType(resources.GetObject("tsTicketReady.Image"), System.Drawing.Image)
        Me.tsTicketReady.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsTicketReady.Name = "tsTicketReady"
        Me.tsTicketReady.Size = New System.Drawing.Size(23, 40)
        Me.tsTicketReady.Text = "ToolStripButton1"
        Me.tsTicketReady.ToolTipText = "Spend 1 Ticket for Slot Raffle Draw"
        Me.tsTicketReady.Visible = False
        '
        'sp4
        '
        Me.sp4.Name = "sp4"
        Me.sp4.Size = New System.Drawing.Size(6, 43)
        Me.sp4.Visible = False
        '
        'tsGiftStatus
        '
        Me.tsGiftStatus.ForeColor = System.Drawing.Color.White
        Me.tsGiftStatus.Image = CType(resources.GetObject("tsGiftStatus.Image"), System.Drawing.Image)
        Me.tsGiftStatus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsGiftStatus.Name = "tsGiftStatus"
        Me.tsGiftStatus.Size = New System.Drawing.Size(80, 40)
        Me.tsGiftStatus.Text = "Get Ready"
        Me.tsGiftStatus.ToolTipText = "Get Daily Gift Rewards"
        Me.tsGiftStatus.Visible = False
        '
        'statFooter
        '
        Me.statFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.statFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.statFooter.Location = New System.Drawing.Point(0, 571)
        Me.statFooter.My_Background_BorderColor = System.Drawing.Color.White
        Me.statFooter.My_Background_Has_Border = False
        Me.statFooter.My_BackgroundColor_Bottom1 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.statFooter.My_BackgroundColor_Bottom2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.statFooter.My_BackgroundColor_Top1 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.statFooter.My_BackgroundColor_Top2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.statFooter.My_Caption_Backcolor = System.Drawing.Color.White
        Me.statFooter.My_Caption_Forecolor = System.Drawing.Color.Black
        Me.statFooter.My_Connection_Quality_Good = System.Drawing.Color.Green
        Me.statFooter.My_Connection_Quality_Intermediate = System.Drawing.Color.Orange
        Me.statFooter.My_Connection_Quality_Poor = System.Drawing.Color.Red
        Me.statFooter.My_Database = "{database}"
        Me.statFooter.My_Fill_Forecolor = System.Drawing.Color.Black
        Me.statFooter.My_RoleName = "Standard"
        Me.statFooter.My_User = "?"
        Me.statFooter.Name = "statFooter"
        Me.statFooter.Size = New System.Drawing.Size(974, 23)
        Me.statFooter.TabIndex = 11
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'tGiftRewards
        '
        Me.tGiftRewards.Interval = 1000
        '
        'frmDashBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(974, 594)
        Me.Controls.Add(Me.statFooter)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmDashBoard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game Center v1.0"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GameDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsSignIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsHeading As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsProfile As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRank As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsPoints As System.Windows.Forms.ToolStripLabel
    Friend WithEvents statFooter As PowerNET8.MyStatusViewer
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GameTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsRankPics As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsTicket As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsTicketLogo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsTP As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsTPlogo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsRewards As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GidToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpinATicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClaimTimePointsRewardsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sp3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents sp2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents sp1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents sp5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents sp4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tGiftRewards As System.Windows.Forms.Timer
    Friend WithEvents tsGiftStatus As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsTicketReady As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsNotification As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tsMessage As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents sp6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UnlockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FeedbackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
