<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMessageBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMessageBox))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.flpListPersonBox = New System.Windows.Forms.FlowLayoutPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.tlpInsideInbox = New System.Windows.Forms.TableLayoutPanel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.cmdCreate = New PowerNET8.My8Button
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.txtRecipient = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tlpUnderMessageBox = New System.Windows.Forms.TableLayoutPanel
        Me.cmdSend = New PowerNET8.My8Button
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.txtMessage = New System.Windows.Forms.TextBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.lblMaxAllowedCharacter = New System.Windows.Forms.Label
        Me.lblImageStatus = New System.Windows.Forms.Label
        Me.pcInsertImage = New System.Windows.Forms.PictureBox
        Me.flpCenterBox = New System.Windows.Forms.FlowLayoutPanel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ForwardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.My7GlassButton1 = New PowerNET8.My7GlassButton
        Me.TableLayoutPanel1.SuspendLayout()
        Me.flpListPersonBox.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpInsideInbox.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.tlpUnderMessageBox.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.pcInsertImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpCenterBox.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.flpListPersonBox, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tlpInsideInbox, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(865, 568)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'flpListPersonBox
        '
        Me.flpListPersonBox.AutoScroll = True
        Me.flpListPersonBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.flpListPersonBox.Controls.Add(Me.Panel1)
        Me.flpListPersonBox.Controls.Add(Me.Panel2)
        Me.flpListPersonBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpListPersonBox.Location = New System.Drawing.Point(5, 5)
        Me.flpListPersonBox.Margin = New System.Windows.Forms.Padding(5)
        Me.flpListPersonBox.Name = "flpListPersonBox"
        Me.flpListPersonBox.Size = New System.Drawing.Size(206, 558)
        Me.flpListPersonBox.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.PictureBox8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(200, 66)
        Me.Panel1.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(93, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(105, 16)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "2011-1-1 !2:22:22 AM"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(177, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(19, 18)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "12"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(60, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 28)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Label9"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(60, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(139, 16)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Label8"
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox8.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(5, 5)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(54, 56)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox8.TabIndex = 3
        Me.PictureBox8.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Lavender
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.PictureBox9)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 75)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel2.Size = New System.Drawing.Size(200, 66)
        Me.Panel2.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(177, 4)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(19, 18)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "12"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(59, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(137, 37)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Label12"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(58, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(139, 20)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Label13"
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox9.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(5, 5)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(54, 56)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox9.TabIndex = 3
        Me.PictureBox9.TabStop = False
        '
        'tlpInsideInbox
        '
        Me.tlpInsideInbox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tlpInsideInbox.ColumnCount = 1
        Me.tlpInsideInbox.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpInsideInbox.Controls.Add(Me.Panel3, 0, 0)
        Me.tlpInsideInbox.Controls.Add(Me.Panel4, 0, 1)
        Me.tlpInsideInbox.Controls.Add(Me.tlpUnderMessageBox, 0, 3)
        Me.tlpInsideInbox.Controls.Add(Me.flpCenterBox, 0, 2)
        Me.tlpInsideInbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpInsideInbox.Location = New System.Drawing.Point(219, 3)
        Me.tlpInsideInbox.Name = "tlpInsideInbox"
        Me.tlpInsideInbox.RowCount = 4
        Me.tlpInsideInbox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlpInsideInbox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.tlpInsideInbox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpInsideInbox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 139.0!))
        Me.tlpInsideInbox.Size = New System.Drawing.Size(643, 562)
        Me.tlpInsideInbox.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.PictureBox7)
        Me.Panel3.Controls.Add(Me.cmdCreate)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(637, 54)
        Me.Panel3.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(71, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Label4"
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(65, 54)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 2
        Me.PictureBox7.TabStop = False
        '
        'cmdCreate
        '
        Me.cmdCreate.BorderColors = System.Drawing.Color.White
        Me.cmdCreate.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.cmdCreate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdCreate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cmdCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCreate.IconTypes = PowerNET8.myIcons.Share.General.IconLibraryTypes.Jquery
        Me.cmdCreate.ImageSize = New System.Drawing.Size(24, 24)
        Me.cmdCreate.JqueryIconColorHover = PowerNET8.myIcons.Share.Jquery.JqueryIconTypes.carrat_1_ne
        Me.cmdCreate.JqueryIconTypes = PowerNET8.myIcons.Share.Jquery.JqueryIconTypes.NotSet
        Me.cmdCreate.JqueryMobileIconColor = PowerNET8.myIcons.Share.JqueryMobile.JqueryMobileIconColor.NotSet
        Me.cmdCreate.JqueryMobileIconTypes = PowerNET8.myIcons.Share.JqueryMobile.JqueryMobileIconTypes.NotSet
        Me.cmdCreate.Location = New System.Drawing.Point(506, 4)
        Me.cmdCreate.MouseOverBackcolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.cmdCreate.MouseOverForecolor = System.Drawing.Color.White
        Me.cmdCreate.MousePressedBackColor = System.Drawing.Color.White
        Me.cmdCreate.MousePressedForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(127, 47)
        Me.cmdCreate.Standard_ThemeColor = PowerNET8.myColor.Share.SystemColor.BackgroundColor.StandardColor.DColors.Blue
        Me.cmdCreate.TabIndex = 0
        Me.cmdCreate.Text = "Create Message"
        Me.cmdCreate.UseVisualStyleBackColor = True
        Me.cmdCreate.Windows8IconTypes = PowerNET8.myIcons.Share.Windows8.Windows8IconTypes.NotSet
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Silver
        Me.Panel4.Controls.Add(Me.txtRecipient)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 63)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(637, 39)
        Me.Panel4.TabIndex = 1
        '
        'txtRecipient
        '
        Me.txtRecipient.Location = New System.Drawing.Point(50, 8)
        Me.txtRecipient.Name = "txtRecipient"
        Me.txtRecipient.Size = New System.Drawing.Size(246, 20)
        Me.txtRecipient.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "To:"
        '
        'tlpUnderMessageBox
        '
        Me.tlpUnderMessageBox.ColumnCount = 2
        Me.tlpUnderMessageBox.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.0518!))
        Me.tlpUnderMessageBox.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.948195!))
        Me.tlpUnderMessageBox.Controls.Add(Me.cmdSend, 1, 0)
        Me.tlpUnderMessageBox.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.tlpUnderMessageBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpUnderMessageBox.Location = New System.Drawing.Point(3, 426)
        Me.tlpUnderMessageBox.Name = "tlpUnderMessageBox"
        Me.tlpUnderMessageBox.RowCount = 1
        Me.tlpUnderMessageBox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpUnderMessageBox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.tlpUnderMessageBox.Size = New System.Drawing.Size(637, 133)
        Me.tlpUnderMessageBox.TabIndex = 3
        '
        'cmdSend
        '
        Me.cmdSend.BorderColors = System.Drawing.Color.White
        Me.cmdSend.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmdSend.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.cmdSend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cmdSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSend.IconTypes = PowerNET8.myIcons.Share.General.IconLibraryTypes.Jquery
        Me.cmdSend.ImageSize = New System.Drawing.Size(24, 24)
        Me.cmdSend.JqueryIconColorHover = PowerNET8.myIcons.Share.Jquery.JqueryIconTypes.carrat_1_ne
        Me.cmdSend.JqueryIconTypes = PowerNET8.myIcons.Share.Jquery.JqueryIconTypes.NotSet
        Me.cmdSend.JqueryMobileIconColor = PowerNET8.myIcons.Share.JqueryMobile.JqueryMobileIconColor.NotSet
        Me.cmdSend.JqueryMobileIconTypes = PowerNET8.myIcons.Share.JqueryMobile.JqueryMobileIconTypes.NotSet
        Me.cmdSend.Location = New System.Drawing.Point(582, 3)
        Me.cmdSend.MouseOverBackcolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.cmdSend.MouseOverForecolor = System.Drawing.Color.White
        Me.cmdSend.MousePressedBackColor = System.Drawing.Color.White
        Me.cmdSend.MousePressedForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(52, 45)
        Me.cmdSend.Standard_ThemeColor = PowerNET8.myColor.Share.SystemColor.BackgroundColor.StandardColor.DColors.Blue
        Me.cmdSend.TabIndex = 2
        Me.cmdSend.Text = "Send"
        Me.cmdSend.UseVisualStyleBackColor = True
        Me.cmdSend.Windows8IconTypes = PowerNET8.myIcons.Share.Windows8.Windows8IconTypes.NotSet
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.txtMessage, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel5, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.16535!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.83465!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(573, 127)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'txtMessage
        '
        Me.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMessage.Location = New System.Drawing.Point(3, 3)
        Me.txtMessage.MaxLength = 300
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessage.Size = New System.Drawing.Size(567, 91)
        Me.txtMessage.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblMaxAllowedCharacter)
        Me.Panel5.Controls.Add(Me.lblImageStatus)
        Me.Panel5.Controls.Add(Me.pcInsertImage)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(11, 100)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(559, 24)
        Me.Panel5.TabIndex = 1
        '
        'lblMaxAllowedCharacter
        '
        Me.lblMaxAllowedCharacter.AutoSize = True
        Me.lblMaxAllowedCharacter.Location = New System.Drawing.Point(3, 6)
        Me.lblMaxAllowedCharacter.Name = "lblMaxAllowedCharacter"
        Me.lblMaxAllowedCharacter.Size = New System.Drawing.Size(151, 13)
        Me.lblMaxAllowedCharacter.TabIndex = 2
        Me.lblMaxAllowedCharacter.Text = "Max Allowed Character: 0/300"
        '
        'lblImageStatus
        '
        Me.lblImageStatus.AutoSize = True
        Me.lblImageStatus.Location = New System.Drawing.Point(265, 6)
        Me.lblImageStatus.Name = "lblImageStatus"
        Me.lblImageStatus.Size = New System.Drawing.Size(86, 13)
        Me.lblImageStatus.TabIndex = 1
        Me.lblImageStatus.Text = "Image Inserted..."
        '
        'pcInsertImage
        '
        Me.pcInsertImage.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcInsertImage.Image = Global.Game_List_Browser.My.Resources.Resources._1
        Me.pcInsertImage.Location = New System.Drawing.Point(535, 0)
        Me.pcInsertImage.Name = "pcInsertImage"
        Me.pcInsertImage.Size = New System.Drawing.Size(24, 24)
        Me.pcInsertImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcInsertImage.TabIndex = 0
        Me.pcInsertImage.TabStop = False
        '
        'flpCenterBox
        '
        Me.flpCenterBox.AutoScroll = True
        Me.flpCenterBox.BackColor = System.Drawing.Color.White
        Me.flpCenterBox.Controls.Add(Me.Panel6)
        Me.flpCenterBox.Controls.Add(Me.Panel7)
        Me.flpCenterBox.Controls.Add(Me.Panel8)
        Me.flpCenterBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpCenterBox.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp
        Me.flpCenterBox.Location = New System.Drawing.Point(3, 108)
        Me.flpCenterBox.Name = "flpCenterBox"
        Me.flpCenterBox.Size = New System.Drawing.Size(637, 312)
        Me.flpCenterBox.TabIndex = 4
        Me.flpCenterBox.WrapContents = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.PictureBox3)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.PictureBox2)
        Me.Panel6.Controls.Add(Me.PictureBox1)
        Me.Panel6.Location = New System.Drawing.Point(3, 182)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(613, 127)
        Me.Panel6.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(320, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 25)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Seen"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label5.Image = Global.Game_List_Browser.My.Resources.Resources._1437561088_User_Info
        Me.Label5.Location = New System.Drawing.Point(17, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(550, 73)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Label5"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(580, 34)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(29, 27)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 4
        Me.PictureBox3.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteMessageToolStripMenuItem, Me.ForwardToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(152, 48)
        '
        'DeleteMessageToolStripMenuItem
        '
        Me.DeleteMessageToolStripMenuItem.Name = "DeleteMessageToolStripMenuItem"
        Me.DeleteMessageToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.DeleteMessageToolStripMenuItem.Text = "Delete Message"
        '
        'ForwardToolStripMenuItem
        '
        Me.ForwardToolStripMenuItem.Name = "ForwardToolStripMenuItem"
        Me.ForwardToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ForwardToolStripMenuItem.Text = "Forward"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(292, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(247, 27)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Message Sent: 2011-1-1 2:2:2 PM"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(538, 101)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(29, 27)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(578, 100)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.Label6)
        Me.Panel7.Controls.Add(Me.PictureBox4)
        Me.Panel7.Controls.Add(Me.Label3)
        Me.Panel7.Controls.Add(Me.PictureBox5)
        Me.Panel7.Controls.Add(Me.PictureBox6)
        Me.Panel7.Location = New System.Drawing.Point(3, 51)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(613, 125)
        Me.Panel7.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Label6.Image = Global.Game_List_Browser.My.Resources.Resources._0b970b3241d1d1a
        Me.Label6.Location = New System.Drawing.Point(35, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(183, 73)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Label6"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(0, 40)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(29, 27)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 4
        Me.PictureBox4.TabStop = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(82, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(260, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Message Sent: 2011-1-1 2:2:2 PM"
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(46, 101)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(29, 27)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 1
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(29, 2)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(200, 100)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 0
        Me.PictureBox6.TabStop = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
        Me.Panel8.Controls.Add(Me.My7GlassButton1)
        Me.Panel8.Location = New System.Drawing.Point(3, 12)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(613, 33)
        Me.Panel8.TabIndex = 2
        '
        'My7GlassButton1
        '
        Me.My7GlassButton1.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.My7GlassButton1.BackColor = System.Drawing.Color.Transparent
        Me.My7GlassButton1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.My7GlassButton1.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.My7GlassButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.My7GlassButton1.FlatAppearance.BorderSize = 0
        Me.My7GlassButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.My7GlassButton1.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.My7GlassButton1.ImageSize = New System.Drawing.Size(24, 24)
        Me.My7GlassButton1.Location = New System.Drawing.Point(0, 0)
        Me.My7GlassButton1.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.My7GlassButton1.Name = "My7GlassButton1"
        Me.My7GlassButton1.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.My7GlassButton1.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.My7GlassButton1.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.My7GlassButton1.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.My7GlassButton1.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.My7GlassButton1.Size = New System.Drawing.Size(613, 33)
        Me.My7GlassButton1.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.My7GlassButton1.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.My7GlassButton1.TabIndex = 0
        Me.My7GlassButton1.Text = "Load More . . ."
        Me.My7GlassButton1.UseVisualStyleBackColor = True
        '
        'frmMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ClientSize = New System.Drawing.Size(865, 568)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMessageBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Message Box"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.flpListPersonBox.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpInsideInbox.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.tlpUnderMessageBox.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.pcInsertImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpCenterBox.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flpListPersonBox As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tlpInsideInbox As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmdCreate As PowerNET8.My8Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtRecipient As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tlpUnderMessageBox As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdSend As PowerNET8.My8Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents pcInsertImage As System.Windows.Forms.PictureBox
    Friend WithEvents lblImageStatus As System.Windows.Forms.Label
    Friend WithEvents flpCenterBox As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblMaxAllowedCharacter As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ForwardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents My7GlassButton1 As PowerNET8.My7GlassButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
