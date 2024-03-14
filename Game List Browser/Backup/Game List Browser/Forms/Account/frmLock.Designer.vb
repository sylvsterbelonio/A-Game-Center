<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLock
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
        Me.txtLockPassword = New System.Windows.Forms.TextBox
        Me.My8Button1 = New PowerNET8.My8Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Password"
        '
        'txtLockPassword
        '
        Me.txtLockPassword.Location = New System.Drawing.Point(71, 6)
        Me.txtLockPassword.Name = "txtLockPassword"
        Me.txtLockPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtLockPassword.Size = New System.Drawing.Size(201, 20)
        Me.txtLockPassword.TabIndex = 1
        '
        'My8Button1
        '
        Me.My8Button1.BorderColors = System.Drawing.Color.White
        Me.My8Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.My8Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.My8Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.My8Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.My8Button1.IconTypes = PowerNET8.myIcons.Share.General.IconLibraryTypes.NotSet
        Me.My8Button1.ImageSize = New System.Drawing.Size(24, 24)
        Me.My8Button1.JqueryIconColorHover = PowerNET8.myIcons.Share.Jquery.JqueryIconTypes.carrat_1_ne
        Me.My8Button1.JqueryIconTypes = PowerNET8.myIcons.Share.Jquery.JqueryIconTypes.NotSet
        Me.My8Button1.JqueryMobileIconColor = PowerNET8.myIcons.Share.JqueryMobile.JqueryMobileIconColor.NotSet
        Me.My8Button1.JqueryMobileIconTypes = PowerNET8.myIcons.Share.JqueryMobile.JqueryMobileIconTypes.NotSet
        Me.My8Button1.Location = New System.Drawing.Point(197, 32)
        Me.My8Button1.MouseOverBackcolor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.My8Button1.MouseOverForecolor = System.Drawing.Color.White
        Me.My8Button1.MousePressedBackColor = System.Drawing.Color.White
        Me.My8Button1.MousePressedForeColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.My8Button1.Name = "My8Button1"
        Me.My8Button1.Size = New System.Drawing.Size(75, 30)
        Me.My8Button1.Standard_ThemeColor = PowerNET8.myColor.Share.SystemColor.BackgroundColor.StandardColor.DColors.Orange
        Me.My8Button1.TabIndex = 2
        Me.My8Button1.Text = "Unlock"
        Me.My8Button1.UseVisualStyleBackColor = True
        Me.My8Button1.Windows8IconTypes = PowerNET8.myIcons.Share.Windows8.Windows8IconTypes.NotSet
        '
        'frmLock
        '
        Me.AcceptButton = Me.My8Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(278, 71)
        Me.Controls.Add(Me.My8Button1)
        Me.Controls.Add(Me.txtLockPassword)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLock"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unlock Parental Control"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLockPassword As System.Windows.Forms.TextBox
    Friend WithEvents My8Button1 As PowerNET8.My8Button
End Class
