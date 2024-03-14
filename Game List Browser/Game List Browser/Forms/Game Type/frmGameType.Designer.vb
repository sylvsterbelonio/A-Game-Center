<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGameType
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
        Me.txtGameType = New System.Windows.Forms.TextBox
        Me.txtowner = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtReleasedDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtcountry = New System.Windows.Forms.TextBox
        Me.txtMarkets = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtWebsite = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdNew = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.pbCover = New System.Windows.Forms.PictureBox
        CType(Me.dtReleasedDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product"
        '
        'txtGameType
        '
        Me.txtGameType.Location = New System.Drawing.Point(55, 111)
        Me.txtGameType.Name = "txtGameType"
        Me.txtGameType.Size = New System.Drawing.Size(192, 20)
        Me.txtGameType.TabIndex = 1
        '
        'txtowner
        '
        Me.txtowner.Location = New System.Drawing.Point(55, 137)
        Me.txtowner.Name = "txtowner"
        Me.txtowner.Size = New System.Drawing.Size(192, 20)
        Me.txtowner.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Owner"
        '
        'dtReleasedDate
        '
        Me.dtReleasedDate.DateTime = New Date(2018, 10, 28, 0, 0, 0, 0)
        Me.dtReleasedDate.Location = New System.Drawing.Point(149, 189)
        Me.dtReleasedDate.Name = "dtReleasedDate"
        Me.dtReleasedDate.Size = New System.Drawing.Size(98, 21)
        Me.dtReleasedDate.TabIndex = 7
        Me.dtReleasedDate.Value = New Date(2018, 10, 28, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(52, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Date Introduced"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Country"
        '
        'txtcountry
        '
        Me.txtcountry.Location = New System.Drawing.Point(55, 163)
        Me.txtcountry.Name = "txtcountry"
        Me.txtcountry.Size = New System.Drawing.Size(192, 20)
        Me.txtcountry.TabIndex = 5
        '
        'txtMarkets
        '
        Me.txtMarkets.Location = New System.Drawing.Point(55, 216)
        Me.txtMarkets.Name = "txtMarkets"
        Me.txtMarkets.Size = New System.Drawing.Size(192, 20)
        Me.txtMarkets.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 219)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Markets"
        '
        'txtWebsite
        '
        Me.txtWebsite.Location = New System.Drawing.Point(55, 242)
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.Size = New System.Drawing.Size(192, 20)
        Me.txtWebsite.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 245)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Website"
        '
        'cmdNew
        '
        Me.cmdNew.Location = New System.Drawing.Point(91, 270)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(75, 26)
        Me.cmdNew.TabIndex = 12
        Me.cmdNew.Text = "New"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(172, 270)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 26)
        Me.cmdSave.TabIndex = 13
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'pbCover
        '
        Me.pbCover.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pbCover.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbCover.Location = New System.Drawing.Point(8, 8)
        Me.pbCover.Name = "pbCover"
        Me.pbCover.Size = New System.Drawing.Size(239, 92)
        Me.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbCover.TabIndex = 9
        Me.pbCover.TabStop = False
        '
        'frmGameType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(256, 304)
        Me.Controls.Add(Me.cmdNew)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.txtWebsite)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtMarkets)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtReleasedDate)
        Me.Controls.Add(Me.txtcountry)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtowner)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pbCover)
        Me.Controls.Add(Me.txtGameType)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGameType"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game Type"
        CType(Me.dtReleasedDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGameType As System.Windows.Forms.TextBox
    Friend WithEvents pbCover As System.Windows.Forms.PictureBox
    Friend WithEvents txtowner As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtReleasedDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcountry As System.Windows.Forms.TextBox
    Friend WithEvents txtMarkets As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtWebsite As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
End Class
