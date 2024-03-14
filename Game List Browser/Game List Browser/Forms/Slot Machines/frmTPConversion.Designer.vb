<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTPConversion
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
        Dim DesignerRectTracker5 As PowerNET8.DesignerRectTracker = New PowerNET8.DesignerRectTracker
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTPConversion))
        Dim DesignerRectTracker6 As PowerNET8.DesignerRectTracker = New PowerNET8.DesignerRectTracker
        Dim DesignerRectTracker1 As PowerNET8.DesignerRectTracker = New PowerNET8.DesignerRectTracker
        Dim DesignerRectTracker2 As PowerNET8.DesignerRectTracker = New PowerNET8.DesignerRectTracker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTP = New System.Windows.Forms.NumericUpDown
        Me.lblMaxTP = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblConverted = New System.Windows.Forms.Label
        Me.cmdConvert = New PowerNET8.CButton
        Me.cmdConvertAll = New PowerNET8.CButton
        Me.dgvConversionRequest = New System.Windows.Forms.DataGridView
        Me.MyNavigationGrid1 = New PowerNET8.myNavigationGrid
        CType(Me.txtTP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvConversionRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Your Current TP"
        '
        'txtTP
        '
        Me.txtTP.Increment = New Decimal(New Integer() {30, 0, 0, 0})
        Me.txtTP.Location = New System.Drawing.Point(131, 16)
        Me.txtTP.Name = "txtTP"
        Me.txtTP.Size = New System.Drawing.Size(66, 20)
        Me.txtTP.TabIndex = 1
        '
        'lblMaxTP
        '
        Me.lblMaxTP.Location = New System.Drawing.Point(204, 19)
        Me.lblMaxTP.Name = "lblMaxTP"
        Me.lblMaxTP.Size = New System.Drawing.Size(41, 16)
        Me.lblMaxTP.TabIndex = 2
        Me.lblMaxTP.Text = "/Max"
        Me.lblMaxTP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(327, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Convert Into Time"
        '
        'lblConverted
        '
        Me.lblConverted.Location = New System.Drawing.Point(449, 17)
        Me.lblConverted.Name = "lblConverted"
        Me.lblConverted.Size = New System.Drawing.Size(100, 23)
        Me.lblConverted.TabIndex = 4
        Me.lblConverted.Text = "/Min"
        Me.lblConverted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdConvert
        '
        DesignerRectTracker5.IsActive = False
        DesignerRectTracker5.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker5.TrackerRectangle"), System.Drawing.RectangleF)
        Me.cmdConvert.CenterPtTracker = DesignerRectTracker5
        Me.cmdConvert.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdConvert.FocalPoints.CenterPtX = 0.04444445!
        Me.cmdConvert.FocalPoints.CenterPtY = 0.32!
        Me.cmdConvert.FocalPoints.FocusPtX = 0.0!
        Me.cmdConvert.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker6.IsActive = False
        DesignerRectTracker6.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker6.TrackerRectangle"), System.Drawing.RectangleF)
        Me.cmdConvert.FocusPtTracker = DesignerRectTracker6
        Me.cmdConvert.ImageIndex = 0
        Me.cmdConvert.Location = New System.Drawing.Point(362, 48)
        Me.cmdConvert.Name = "cmdConvert"
        Me.cmdConvert.Size = New System.Drawing.Size(90, 25)
        Me.cmdConvert.TabIndex = 5
        Me.cmdConvert.Text = "Convert"
        '
        'cmdConvertAll
        '
        DesignerRectTracker1.IsActive = True
        DesignerRectTracker1.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker1.TrackerRectangle"), System.Drawing.RectangleF)
        Me.cmdConvertAll.CenterPtTracker = DesignerRectTracker1
        Me.cmdConvertAll.Cursor = System.Windows.Forms.Cursors.Hand
        DesignerRectTracker2.IsActive = True
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.cmdConvertAll.FocusPtTracker = DesignerRectTracker2
        Me.cmdConvertAll.ImageIndex = 0
        Me.cmdConvertAll.Location = New System.Drawing.Point(458, 48)
        Me.cmdConvertAll.Name = "cmdConvertAll"
        Me.cmdConvertAll.Size = New System.Drawing.Size(90, 25)
        Me.cmdConvertAll.TabIndex = 6
        Me.cmdConvertAll.Text = "Convert All"
        '
        'dgvConversionRequest
        '
        Me.dgvConversionRequest.AllowUserToAddRows = False
        Me.dgvConversionRequest.AllowUserToDeleteRows = False
        Me.dgvConversionRequest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvConversionRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConversionRequest.Location = New System.Drawing.Point(15, 80)
        Me.dgvConversionRequest.MultiSelect = False
        Me.dgvConversionRequest.Name = "dgvConversionRequest"
        Me.dgvConversionRequest.ReadOnly = True
        Me.dgvConversionRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConversionRequest.Size = New System.Drawing.Size(533, 291)
        Me.dgvConversionRequest.TabIndex = 7
        '
        'MyNavigationGrid1
        '
        Me.MyNavigationGrid1.Location = New System.Drawing.Point(12, 377)
        Me.MyNavigationGrid1.My_Skin_BackGround_BorderColor = System.Drawing.Color.White
        Me.MyNavigationGrid1.My_Skin_BackGround_BottomColor1 = System.Drawing.Color.LightGray
        Me.MyNavigationGrid1.My_Skin_BackGround_BottomColor2 = System.Drawing.Color.White
        Me.MyNavigationGrid1.My_Skin_BackGround_Has_Border = False
        Me.MyNavigationGrid1.My_Skin_BackGround_TopColor1 = System.Drawing.Color.White
        Me.MyNavigationGrid1.My_Skin_BackGround_TopColor2 = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.MyNavigationGrid1.My_Skin_Selection_Style_Custom_Select_BorderColor = System.Drawing.Color.Black
        Me.MyNavigationGrid1.My_Skin_Selection_Style_Custom_Select_BottomColor1 = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MyNavigationGrid1.My_Skin_Selection_Style_Custom_Select_BottomColor2 = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.MyNavigationGrid1.My_Skin_Selection_Style_Custom_Select_Has_Border = False
        Me.MyNavigationGrid1.My_Skin_Selection_Style_Custom_Select_TopColor1 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MyNavigationGrid1.My_Skin_Selection_Style_Custom_Select_TopColor2 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.MyNavigationGrid1.My_Skin_Selection_Style_Custom_UnSelect_BorderColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.MyNavigationGrid1.My_Skin_Selection_Style_Custom_UnSelect_BottomColor1 = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.MyNavigationGrid1.My_Skin_Selection_Style_Custom_UnSelect_BottomColor2 = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.MyNavigationGrid1.My_Skin_Selection_Style_Custom_UnSelect_Has_Border = False
        Me.MyNavigationGrid1.My_Skin_Selection_Style_Custom_UnSelect_TopColor1 = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.MyNavigationGrid1.My_Skin_Selection_Style_Custom_UnSelect_TopColor2 = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.MyNavigationGrid1.My_Skin_Standard_Select_FontColor = System.Drawing.Color.DarkBlue
        Me.MyNavigationGrid1.My_Skin_Standard_UnSelect_FontColor = System.Drawing.Color.Black
        Me.MyNavigationGrid1.My_TxtCbo_Backcolor_GotFocus = System.Drawing.Color.Azure
        Me.MyNavigationGrid1.My_TxtCbo_Backcolor_LostFocus = System.Drawing.Color.White
        Me.MyNavigationGrid1.My_TxtCbo_Fontcolor_GotFocus = System.Drawing.Color.SteelBlue
        Me.MyNavigationGrid1.My_TxtCbo_Fontcolor_LostFocus = System.Drawing.Color.Black
        Me.MyNavigationGrid1.My_UI_ICON_HOVER_JQUERY = CType(resources.GetObject("MyNavigationGrid1.My_UI_ICON_HOVER_JQUERY"), System.Drawing.Image)
        Me.MyNavigationGrid1.My_UI_ICON_NORMAL_JQUERY = CType(resources.GetObject("MyNavigationGrid1.My_UI_ICON_NORMAL_JQUERY"), System.Drawing.Image)
        Me.MyNavigationGrid1.Name = "MyNavigationGrid1"
        Me.MyNavigationGrid1.Padding = New System.Windows.Forms.Padding(1)
        Me.MyNavigationGrid1.Size = New System.Drawing.Size(536, 32)
        Me.MyNavigationGrid1.TabIndex = 8
        '
        'frmTPConversion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 419)
        Me.Controls.Add(Me.MyNavigationGrid1)
        Me.Controls.Add(Me.dgvConversionRequest)
        Me.Controls.Add(Me.cmdConvertAll)
        Me.Controls.Add(Me.cmdConvert)
        Me.Controls.Add(Me.lblConverted)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblMaxTP)
        Me.Controls.Add(Me.txtTP)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTPConversion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TP Conversion"
        CType(Me.txtTP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvConversionRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTP As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMaxTP As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblConverted As System.Windows.Forms.Label
    Friend WithEvents cmdConvert As PowerNET8.CButton
    Friend WithEvents cmdConvertAll As PowerNET8.CButton
    Friend WithEvents dgvConversionRequest As System.Windows.Forms.DataGridView
    Friend WithEvents MyNavigationGrid1 As PowerNET8.myNavigationGrid
End Class
