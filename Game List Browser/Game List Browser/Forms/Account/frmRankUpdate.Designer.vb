<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRankUpdate
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
        Dim DesignerRectTracker1 As PowerNET8.DesignerRectTracker = New PowerNET8.DesignerRectTracker
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRankUpdate))
        Dim CBlendItems1 As PowerNET8.cBlendItems = New PowerNET8.cBlendItems
        Dim DesignerRectTracker2 As PowerNET8.DesignerRectTracker = New PowerNET8.DesignerRectTracker
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblUPdate = New System.Windows.Forms.Label
        Me.lblPrevRank = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblPrevName = New System.Windows.Forms.Label
        Me.lblNextRankName = New System.Windows.Forms.Label
        Me.lblPrevPointsNeeded = New System.Windows.Forms.Label
        Me.lblNextRankPointsNeeded = New System.Windows.Forms.Label
        Me.pcNextRankLogo = New System.Windows.Forms.PictureBox
        Me.pcPrevRankLogo = New System.Windows.Forms.PictureBox
        Me.pcCurrentRank = New System.Windows.Forms.PictureBox
        Me.cmdOK = New PowerNET8.CButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCurrentRankName = New System.Windows.Forms.Label
        CType(Me.pcNextRankLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcPrevRankLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcCurrentRank, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(257, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 42)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "RANK"
        '
        'lblUPdate
        '
        Me.lblUPdate.AutoSize = True
        Me.lblUPdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUPdate.ForeColor = System.Drawing.Color.White
        Me.lblUPdate.Location = New System.Drawing.Point(254, 85)
        Me.lblUPdate.Name = "lblUPdate"
        Me.lblUPdate.Size = New System.Drawing.Size(304, 55)
        Me.lblUPdate.TabIndex = 2
        Me.lblUPdate.Text = "LEVEL UP!!!"
        '
        'lblPrevRank
        '
        Me.lblPrevRank.AutoSize = True
        Me.lblPrevRank.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrevRank.ForeColor = System.Drawing.Color.White
        Me.lblPrevRank.Location = New System.Drawing.Point(259, 159)
        Me.lblPrevRank.Name = "lblPrevRank"
        Me.lblPrevRank.Size = New System.Drawing.Size(204, 25)
        Me.lblPrevRank.TabIndex = 3
        Me.lblPrevRank.Text = "Your Previous Rank"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(508, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 25)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Next Rank"
        '
        'lblPrevName
        '
        Me.lblPrevName.AutoSize = True
        Me.lblPrevName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrevName.ForeColor = System.Drawing.Color.White
        Me.lblPrevName.Location = New System.Drawing.Point(324, 196)
        Me.lblPrevName.Name = "lblPrevName"
        Me.lblPrevName.Size = New System.Drawing.Size(127, 16)
        Me.lblPrevName.TabIndex = 7
        Me.lblPrevName.Text = "Your Previous Rank"
        '
        'lblNextRankName
        '
        Me.lblNextRankName.AutoSize = True
        Me.lblNextRankName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNextRankName.ForeColor = System.Drawing.Color.White
        Me.lblNextRankName.Location = New System.Drawing.Point(573, 196)
        Me.lblNextRankName.Name = "lblNextRankName"
        Me.lblNextRankName.Size = New System.Drawing.Size(127, 16)
        Me.lblNextRankName.TabIndex = 8
        Me.lblNextRankName.Text = "Your Previous Rank"
        '
        'lblPrevPointsNeeded
        '
        Me.lblPrevPointsNeeded.AutoSize = True
        Me.lblPrevPointsNeeded.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrevPointsNeeded.ForeColor = System.Drawing.Color.White
        Me.lblPrevPointsNeeded.Location = New System.Drawing.Point(324, 216)
        Me.lblPrevPointsNeeded.Name = "lblPrevPointsNeeded"
        Me.lblPrevPointsNeeded.Size = New System.Drawing.Size(127, 16)
        Me.lblPrevPointsNeeded.TabIndex = 9
        Me.lblPrevPointsNeeded.Text = "Your Previous Rank"
        '
        'lblNextRankPointsNeeded
        '
        Me.lblNextRankPointsNeeded.AutoSize = True
        Me.lblNextRankPointsNeeded.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNextRankPointsNeeded.ForeColor = System.Drawing.Color.White
        Me.lblNextRankPointsNeeded.Location = New System.Drawing.Point(573, 216)
        Me.lblNextRankPointsNeeded.Name = "lblNextRankPointsNeeded"
        Me.lblNextRankPointsNeeded.Size = New System.Drawing.Size(127, 16)
        Me.lblNextRankPointsNeeded.TabIndex = 10
        Me.lblNextRankPointsNeeded.Text = "Your Previous Rank"
        '
        'pcNextRankLogo
        '
        Me.pcNextRankLogo.Location = New System.Drawing.Point(513, 196)
        Me.pcNextRankLogo.Name = "pcNextRankLogo"
        Me.pcNextRankLogo.Size = New System.Drawing.Size(54, 58)
        Me.pcNextRankLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pcNextRankLogo.TabIndex = 6
        Me.pcNextRankLogo.TabStop = False
        '
        'pcPrevRankLogo
        '
        Me.pcPrevRankLogo.Location = New System.Drawing.Point(264, 194)
        Me.pcPrevRankLogo.Name = "pcPrevRankLogo"
        Me.pcPrevRankLogo.Size = New System.Drawing.Size(54, 58)
        Me.pcPrevRankLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pcPrevRankLogo.TabIndex = 5
        Me.pcPrevRankLogo.TabStop = False
        '
        'pcCurrentRank
        '
        Me.pcCurrentRank.Location = New System.Drawing.Point(16, 10)
        Me.pcCurrentRank.Name = "pcCurrentRank"
        Me.pcCurrentRank.Size = New System.Drawing.Size(225, 242)
        Me.pcCurrentRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pcCurrentRank.TabIndex = 0
        Me.pcCurrentRank.TabStop = False
        '
        'cmdOK
        '
        Me.cmdOK.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DesignerRectTracker1.IsActive = False
        DesignerRectTracker1.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker1.TrackerRectangle"), System.Drawing.RectangleF)
        Me.cmdOK.CenterPtTracker = DesignerRectTracker1
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.AliceBlue, System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))}
        CBlendItems1.iPoint = New Single() {0.0!, 0.5!, 1.0!}
        Me.cmdOK.ColorFillBlend = CBlendItems1
        Me.cmdOK.Corners.All = CType(24, Short)
        Me.cmdOK.Corners.LowerLeft = CType(24, Short)
        Me.cmdOK.Corners.LowerRight = CType(24, Short)
        Me.cmdOK.Corners.UpperLeft = CType(24, Short)
        Me.cmdOK.Corners.UpperRight = CType(24, Short)
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdOK.FocalPoints.CenterPtX = 0.4837398!
        Me.cmdOK.FocalPoints.CenterPtY = 0.58!
        Me.cmdOK.FocalPoints.FocusPtX = 0.0!
        Me.cmdOK.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker2.IsActive = False
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.cmdOK.FocusPtTracker = DesignerRectTracker2
        Me.cmdOK.ImageIndex = 0
        Me.cmdOK.Location = New System.Drawing.Point(49, 19)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(613, 62)
        Me.cmdOK.TabIndex = 11
        Me.cmdOK.Text = "OK"
        Me.cmdOK.TextShadow = System.Drawing.Color.Gray
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Maroon
        Me.Panel1.Controls.Add(Me.cmdOK)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 263)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(719, 100)
        Me.Panel1.TabIndex = 12
        '
        'lblCurrentRankName
        '
        Me.lblCurrentRankName.AutoSize = True
        Me.lblCurrentRankName.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentRankName.ForeColor = System.Drawing.Color.White
        Me.lblCurrentRankName.Location = New System.Drawing.Point(389, 29)
        Me.lblCurrentRankName.Name = "lblCurrentRankName"
        Me.lblCurrentRankName.Size = New System.Drawing.Size(122, 42)
        Me.lblCurrentRankName.TabIndex = 13
        Me.lblCurrentRankName.Text = "RANK"
        '
        'frmRankUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.IndianRed
        Me.ClientSize = New System.Drawing.Size(719, 363)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblCurrentRankName)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblNextRankPointsNeeded)
        Me.Controls.Add(Me.lblPrevPointsNeeded)
        Me.Controls.Add(Me.lblNextRankName)
        Me.Controls.Add(Me.lblPrevName)
        Me.Controls.Add(Me.pcNextRankLogo)
        Me.Controls.Add(Me.pcPrevRankLogo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblPrevRank)
        Me.Controls.Add(Me.lblUPdate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pcCurrentRank)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "frmRankUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pcNextRankLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcPrevRankLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcCurrentRank, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pcCurrentRank As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUPdate As System.Windows.Forms.Label
    Friend WithEvents lblPrevRank As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pcPrevRankLogo As System.Windows.Forms.PictureBox
    Friend WithEvents pcNextRankLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblPrevName As System.Windows.Forms.Label
    Friend WithEvents lblNextRankName As System.Windows.Forms.Label
    Friend WithEvents lblPrevPointsNeeded As System.Windows.Forms.Label
    Friend WithEvents lblNextRankPointsNeeded As System.Windows.Forms.Label
    Friend WithEvents cmdOK As PowerNET8.CButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCurrentRankName As System.Windows.Forms.Label
End Class
