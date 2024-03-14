<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmulators
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboPlatforms = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtEmulator = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtVersion = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdNew = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.txtDeveloper = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtContactSite = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtDR = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.MyLineSeparator1 = New PowerNET8.myLineSeparator
        Me.cmdSettings = New System.Windows.Forms.Button
        Me.pbLogo = New System.Windows.Forms.PictureBox
        CType(Me.dtDR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(92, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Platforms"
        '
        'cboPlatforms
        '
        Me.cboPlatforms.FormattingEnabled = True
        Me.cboPlatforms.Items.AddRange(New Object() {"Play Station", "Play Station 2", "Sega"})
        Me.cboPlatforms.Location = New System.Drawing.Point(176, 13)
        Me.cboPlatforms.Name = "cboPlatforms"
        Me.cboPlatforms.Size = New System.Drawing.Size(134, 21)
        Me.cboPlatforms.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(92, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Emulator Name"
        '
        'txtEmulator
        '
        Me.txtEmulator.Location = New System.Drawing.Point(177, 44)
        Me.txtEmulator.Name = "txtEmulator"
        Me.txtEmulator.Size = New System.Drawing.Size(133, 20)
        Me.txtEmulator.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(92, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Emulator Version"
        '
        'txtVersion
        '
        Me.txtVersion.Location = New System.Drawing.Point(177, 71)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(133, 20)
        Me.txtVersion.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Location"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(93, 180)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(150, 20)
        Me.txtLocation.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(249, 177)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Location = New System.Drawing.Point(136, 225)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(75, 26)
        Me.cmdNew.TabIndex = 16
        Me.cmdNew.Text = "New"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.Location = New System.Drawing.Point(298, 225)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 26)
        Me.cmdExit.TabIndex = 18
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(217, 225)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 26)
        Me.cmdSave.TabIndex = 17
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'txtDeveloper
        '
        Me.txtDeveloper.Location = New System.Drawing.Point(93, 100)
        Me.txtDeveloper.Name = "txtDeveloper"
        Me.txtDeveloper.Size = New System.Drawing.Size(217, 20)
        Me.txtDeveloper.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Developer"
        '
        'txtContactSite
        '
        Me.txtContactSite.Location = New System.Drawing.Point(93, 126)
        Me.txtContactSite.Name = "txtContactSite"
        Me.txtContactSite.Size = New System.Drawing.Size(217, 20)
        Me.txtContactSite.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Contact Site"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Date Released"
        '
        'dtDR
        '
        Me.dtDR.Location = New System.Drawing.Point(95, 152)
        Me.dtDR.Name = "dtDR"
        Me.dtDR.Size = New System.Drawing.Size(215, 21)
        Me.dtDR.TabIndex = 11
        '
        'MyLineSeparator1
        '
        Me.MyLineSeparator1.BackColor = System.Drawing.Color.Transparent
        Me.MyLineSeparator1.Location = New System.Drawing.Point(7, 213)
        Me.MyLineSeparator1.My_Line_Border = 1
        Me.MyLineSeparator1.My_Line_Color = System.Drawing.Color.Black
        Me.MyLineSeparator1.My_Line_Style = PowerNET8.myLineSeparator.LineMode.Horizontal
        Me.MyLineSeparator1.Name = "MyLineSeparator1"
        Me.MyLineSeparator1.Size = New System.Drawing.Size(364, 10)
        Me.MyLineSeparator1.TabIndex = 19
        '
        'cmdSettings
        '
        Me.cmdSettings.BackgroundImage = Global.Game_List_Browser.My.Resources.Resources.Settings_L_icon
        Me.cmdSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSettings.Location = New System.Drawing.Point(318, 12)
        Me.cmdSettings.Name = "cmdSettings"
        Me.cmdSettings.Size = New System.Drawing.Size(57, 52)
        Me.cmdSettings.TabIndex = 15
        Me.cmdSettings.UseVisualStyleBackColor = True
        '
        'pbLogo
        '
        Me.pbLogo.BackColor = System.Drawing.Color.White
        Me.pbLogo.Location = New System.Drawing.Point(7, 11)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(79, 77)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLogo.TabIndex = 20
        Me.pbLogo.TabStop = False
        '
        'frmEmulators
        '
        Me.AcceptButton = Me.cmdSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 263)
        Me.Controls.Add(Me.pbLogo)
        Me.Controls.Add(Me.MyLineSeparator1)
        Me.Controls.Add(Me.dtDR)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtContactSite)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDeveloper)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdSettings)
        Me.Controls.Add(Me.cmdNew)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtVersion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEmulator)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboPlatforms)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEmulators"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Emulators"
        CType(Me.dtDR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPlatforms As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEmulator As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdSettings As System.Windows.Forms.Button
    Friend WithEvents txtDeveloper As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtContactSite As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtDR As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents MyLineSeparator1 As PowerNET8.myLineSeparator
    Friend WithEvents pbLogo As System.Windows.Forms.PictureBox
End Class
