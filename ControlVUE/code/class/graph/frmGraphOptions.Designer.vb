<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGraphOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGraphOptions))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.udLabelFontSize = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.udTitleFontSize = New System.Windows.Forms.NumericUpDown()
        Me.chkShowTitle = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkEnableGraph = New System.Windows.Forms.CheckBox()
        Me.chkBlackBackground = New System.Windows.Forms.CheckBox()
        Me.chkShowMinorGrid = New System.Windows.Forms.CheckBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.chkShowGrid = New System.Windows.Forms.CheckBox()
        Me.chkShowLegend = New System.Windows.Forms.CheckBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtXTitle = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlXsensor = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.optAutoX = New System.Windows.Forms.RadioButton()
        Me.grpXManual = New System.Windows.Forms.GroupBox()
        Me.txtXMax = New LvNumericTextBox.LvNumericTextBox()
        Me.txtXMin = New LvNumericTextBox.LvNumericTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.optXManual = New System.Windows.Forms.RadioButton()
        Me.lstXAxisSensors = New System.Windows.Forms.ListBox()
        Me.pnlTime = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAutoTruncateCountScrolling = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtAutoTruncateCountCumulative = New System.Windows.Forms.TextBox()
        Me.txtTimeRange = New System.Windows.Forms.TextBox()
        Me.optCumulative = New System.Windows.Forms.RadioButton()
        Me.optScrolling = New System.Windows.Forms.RadioButton()
        Me.optXUseSensor = New System.Windows.Forms.RadioButton()
        Me.optTimeAxis = New System.Windows.Forms.RadioButton()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.chkSelectAllY1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.optAutoY1 = New System.Windows.Forms.RadioButton()
        Me.optY1Manual = New System.Windows.Forms.RadioButton()
        Me.grpY1Manual = New System.Windows.Forms.GroupBox()
        Me.txtY1Max = New LvNumericTextBox.LvNumericTextBox()
        Me.txtY1Min = New LvNumericTextBox.LvNumericTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtY1Title = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dgvY1AxisSensors = New System.Windows.Forms.DataGridView()
        Me.y1Check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.y1Ss1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.y1Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.y1Color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.y1cmdColor = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.y1LineStyle = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.y1LineWidth = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.y1MarkerStyle = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.y1MarkerSize = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optAutoY2 = New System.Windows.Forms.RadioButton()
        Me.optY2Manual = New System.Windows.Forms.RadioButton()
        Me.grpY2Manual = New System.Windows.Forms.GroupBox()
        Me.txtY2Max = New LvNumericTextBox.LvNumericTextBox()
        Me.txtY2Min = New LvNumericTextBox.LvNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtY2Title = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dgvY2AxisSensors = New System.Windows.Forms.DataGridView()
        Me.Y2Check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Y2Ss1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Y2Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Y2Color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Y2cmdColor = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Y2LineStyle = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Y2LineWidth = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Y2MarkerStyle = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Y2MarkerSize = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.chkSelectAllY2 = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.udLabelFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udTitleFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.pnlXsensor.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.grpXManual.SuspendLayout()
        Me.pnlTime.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.grpY1Manual.SuspendLayout()
        CType(Me.dgvY1AxisSensors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpY2Manual.SuspendLayout()
        CType(Me.dgvY2AxisSensors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(298, 4)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(6)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(961, 502)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.udLabelFontSize)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.udTitleFontSize)
        Me.TabPage1.Controls.Add(Me.chkShowTitle)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.chkEnableGraph)
        Me.TabPage1.Controls.Add(Me.chkBlackBackground)
        Me.TabPage1.Controls.Add(Me.chkShowMinorGrid)
        Me.TabPage1.Controls.Add(Me.PictureBox3)
        Me.TabPage1.Controls.Add(Me.chkShowGrid)
        Me.TabPage1.Controls.Add(Me.chkShowLegend)
        Me.TabPage1.Controls.Add(Me.txtTitle)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 33)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(6)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(6)
        Me.TabPage1.Size = New System.Drawing.Size(953, 465)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(66, 300)
        Me.Label13.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(374, 24)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Background color is common for all graphs."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(332, 72)
        Me.Label16.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(145, 24)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Label Font Size:"
        '
        'udLabelFontSize
        '
        Me.udLabelFontSize.Location = New System.Drawing.Point(495, 69)
        Me.udLabelFontSize.Margin = New System.Windows.Forms.Padding(6)
        Me.udLabelFontSize.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.udLabelFontSize.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.udLabelFontSize.Name = "udLabelFontSize"
        Me.udLabelFontSize.Size = New System.Drawing.Size(73, 29)
        Me.udLabelFontSize.TabIndex = 25
        Me.udLabelFontSize.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(35, 72)
        Me.Label15.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(134, 24)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Title Font Size:"
        '
        'udTitleFontSize
        '
        Me.udTitleFontSize.Location = New System.Drawing.Point(187, 69)
        Me.udTitleFontSize.Margin = New System.Windows.Forms.Padding(6)
        Me.udTitleFontSize.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.udTitleFontSize.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.udTitleFontSize.Name = "udTitleFontSize"
        Me.udTitleFontSize.Size = New System.Drawing.Size(81, 29)
        Me.udTitleFontSize.TabIndex = 23
        Me.udTitleFontSize.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'chkShowTitle
        '
        Me.chkShowTitle.AutoSize = True
        Me.chkShowTitle.Location = New System.Drawing.Point(37, 111)
        Me.chkShowTitle.Margin = New System.Windows.Forms.Padding(6)
        Me.chkShowTitle.Name = "chkShowTitle"
        Me.chkShowTitle.Size = New System.Drawing.Size(117, 28)
        Me.chkShowTitle.TabIndex = 22
        Me.chkShowTitle.Text = "Show Title"
        Me.chkShowTitle.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(66, 378)
        Me.Label14.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(337, 24)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "If disabled, this graph will not be drawn."
        '
        'chkEnableGraph
        '
        Me.chkEnableGraph.AutoSize = True
        Me.chkEnableGraph.Location = New System.Drawing.Point(37, 341)
        Me.chkEnableGraph.Margin = New System.Windows.Forms.Padding(6)
        Me.chkEnableGraph.Name = "chkEnableGraph"
        Me.chkEnableGraph.Size = New System.Drawing.Size(176, 28)
        Me.chkEnableGraph.TabIndex = 20
        Me.chkEnableGraph.Text = "Enable this graph"
        Me.chkEnableGraph.UseVisualStyleBackColor = True
        '
        'chkBlackBackground
        '
        Me.chkBlackBackground.AutoSize = True
        Me.chkBlackBackground.Location = New System.Drawing.Point(37, 266)
        Me.chkBlackBackground.Margin = New System.Windows.Forms.Padding(6)
        Me.chkBlackBackground.Name = "chkBlackBackground"
        Me.chkBlackBackground.Size = New System.Drawing.Size(289, 28)
        Me.chkBlackBackground.TabIndex = 3
        Me.chkBlackBackground.Text = "Use Black as background color"
        Me.chkBlackBackground.UseVisualStyleBackColor = True
        '
        'chkShowMinorGrid
        '
        Me.chkShowMinorGrid.AutoSize = True
        Me.chkShowMinorGrid.Location = New System.Drawing.Point(72, 225)
        Me.chkShowMinorGrid.Margin = New System.Windows.Forms.Padding(6)
        Me.chkShowMinorGrid.Name = "chkShowMinorGrid"
        Me.chkShowMinorGrid.Size = New System.Drawing.Size(220, 28)
        Me.chkShowMinorGrid.TabIndex = 19
        Me.chkShowMinorGrid.Text = "Show Minor Grid Lines"
        Me.chkShowMinorGrid.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(595, 28)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(6)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(295, 336)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 18
        Me.PictureBox3.TabStop = False
        '
        'chkShowGrid
        '
        Me.chkShowGrid.AutoSize = True
        Me.chkShowGrid.Location = New System.Drawing.Point(37, 192)
        Me.chkShowGrid.Margin = New System.Windows.Forms.Padding(6)
        Me.chkShowGrid.Name = "chkShowGrid"
        Me.chkShowGrid.Size = New System.Drawing.Size(167, 28)
        Me.chkShowGrid.TabIndex = 3
        Me.chkShowGrid.Text = "Show Grid Lines"
        Me.chkShowGrid.UseVisualStyleBackColor = True
        '
        'chkShowLegend
        '
        Me.chkShowLegend.AutoSize = True
        Me.chkShowLegend.Location = New System.Drawing.Point(37, 151)
        Me.chkShowLegend.Margin = New System.Windows.Forms.Padding(6)
        Me.chkShowLegend.Name = "chkShowLegend"
        Me.chkShowLegend.Size = New System.Drawing.Size(147, 28)
        Me.chkShowLegend.TabIndex = 2
        Me.chkShowLegend.Text = "Show Legend"
        Me.chkShowLegend.UseVisualStyleBackColor = True
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(156, 22)
        Me.txtTitle.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTitle.MaxLength = 50
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(409, 29)
        Me.txtTitle.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Graph Title:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtXTitle)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.pnlXsensor)
        Me.TabPage2.Controls.Add(Me.pnlTime)
        Me.TabPage2.Controls.Add(Me.optXUseSensor)
        Me.TabPage2.Controls.Add(Me.optTimeAxis)
        Me.TabPage2.Location = New System.Drawing.Point(4, 33)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(6)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(6)
        Me.TabPage2.Size = New System.Drawing.Size(953, 465)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "X Axis"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtXTitle
        '
        Me.txtXTitle.Location = New System.Drawing.Point(137, 360)
        Me.txtXTitle.Margin = New System.Windows.Forms.Padding(6)
        Me.txtXTitle.Name = "txtXTitle"
        Me.txtXTitle.Size = New System.Drawing.Size(360, 29)
        Me.txtXTitle.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 363)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 24)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "X-Axis Title:"
        '
        'pnlXsensor
        '
        Me.pnlXsensor.Controls.Add(Me.GroupBox6)
        Me.pnlXsensor.Controls.Add(Me.lstXAxisSensors)
        Me.pnlXsensor.Location = New System.Drawing.Point(55, 178)
        Me.pnlXsensor.Margin = New System.Windows.Forms.Padding(6)
        Me.pnlXsensor.Name = "pnlXsensor"
        Me.pnlXsensor.Size = New System.Drawing.Size(838, 149)
        Me.pnlXsensor.TabIndex = 5
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.optAutoX)
        Me.GroupBox6.Controls.Add(Me.grpXManual)
        Me.GroupBox6.Controls.Add(Me.optXManual)
        Me.GroupBox6.Location = New System.Drawing.Point(282, 4)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox6.Size = New System.Drawing.Size(542, 131)
        Me.GroupBox6.TabIndex = 18
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Scale"
        '
        'optAutoX
        '
        Me.optAutoX.AutoSize = True
        Me.optAutoX.Location = New System.Drawing.Point(12, 50)
        Me.optAutoX.Margin = New System.Windows.Forms.Padding(6)
        Me.optAutoX.Name = "optAutoX"
        Me.optAutoX.Size = New System.Drawing.Size(111, 28)
        Me.optAutoX.TabIndex = 4
        Me.optAutoX.TabStop = True
        Me.optAutoX.Text = "Automatic"
        Me.optAutoX.UseVisualStyleBackColor = True
        '
        'grpXManual
        '
        Me.grpXManual.Controls.Add(Me.txtXMax)
        Me.grpXManual.Controls.Add(Me.txtXMin)
        Me.grpXManual.Controls.Add(Me.Label4)
        Me.grpXManual.Controls.Add(Me.Label5)
        Me.grpXManual.Location = New System.Drawing.Point(238, 7)
        Me.grpXManual.Margin = New System.Windows.Forms.Padding(6)
        Me.grpXManual.Name = "grpXManual"
        Me.grpXManual.Padding = New System.Windows.Forms.Padding(6)
        Me.grpXManual.Size = New System.Drawing.Size(292, 114)
        Me.grpXManual.TabIndex = 9
        Me.grpXManual.TabStop = False
        '
        'txtXMax
        '
        Me.txtXMax.Location = New System.Drawing.Point(169, 64)
        Me.txtXMax.Margin = New System.Windows.Forms.Padding(6)
        Me.txtXMax.Name = "txtXMax"
        Me.txtXMax.Size = New System.Drawing.Size(103, 29)
        Me.txtXMax.TabIndex = 1
        '
        'txtXMin
        '
        Me.txtXMin.Location = New System.Drawing.Point(169, 22)
        Me.txtXMin.Margin = New System.Windows.Forms.Padding(6)
        Me.txtXMin.Name = "txtXMin"
        Me.txtXMin.Size = New System.Drawing.Size(103, 29)
        Me.txtXMin.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 28)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 24)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "M&inimum:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 69)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 24)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "&Maximum:"
        '
        'optXManual
        '
        Me.optXManual.AutoSize = True
        Me.optXManual.Location = New System.Drawing.Point(136, 50)
        Me.optXManual.Margin = New System.Windows.Forms.Padding(6)
        Me.optXManual.Name = "optXManual"
        Me.optXManual.Size = New System.Drawing.Size(90, 28)
        Me.optXManual.TabIndex = 5
        Me.optXManual.TabStop = True
        Me.optXManual.Text = "Manual"
        Me.optXManual.UseVisualStyleBackColor = True
        '
        'lstXAxisSensors
        '
        Me.lstXAxisSensors.FormattingEnabled = True
        Me.lstXAxisSensors.ItemHeight = 24
        Me.lstXAxisSensors.Location = New System.Drawing.Point(22, 16)
        Me.lstXAxisSensors.Margin = New System.Windows.Forms.Padding(6)
        Me.lstXAxisSensors.Name = "lstXAxisSensors"
        Me.lstXAxisSensors.Size = New System.Drawing.Size(233, 124)
        Me.lstXAxisSensors.TabIndex = 10
        '
        'pnlTime
        '
        Me.pnlTime.Controls.Add(Me.Label18)
        Me.pnlTime.Controls.Add(Me.Label17)
        Me.pnlTime.Controls.Add(Me.txtAutoTruncateCountScrolling)
        Me.pnlTime.Controls.Add(Me.Label12)
        Me.pnlTime.Controls.Add(Me.txtAutoTruncateCountCumulative)
        Me.pnlTime.Controls.Add(Me.txtTimeRange)
        Me.pnlTime.Controls.Add(Me.optCumulative)
        Me.pnlTime.Controls.Add(Me.optScrolling)
        Me.pnlTime.Location = New System.Drawing.Point(55, 42)
        Me.pnlTime.Margin = New System.Windows.Forms.Padding(6)
        Me.pnlTime.Name = "pnlTime"
        Me.pnlTime.Size = New System.Drawing.Size(838, 92)
        Me.pnlTime.TabIndex = 4
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(393, 14)
        Me.Label18.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(125, 24)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "Truncate after"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(634, 14)
        Me.Label17.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(165, 24)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "Points (per graph)."
        '
        'txtAutoTruncateCountScrolling
        '
        Me.txtAutoTruncateCountScrolling.Location = New System.Drawing.Point(525, 11)
        Me.txtAutoTruncateCountScrolling.Margin = New System.Windows.Forms.Padding(6)
        Me.txtAutoTruncateCountScrolling.Name = "txtAutoTruncateCountScrolling"
        Me.txtAutoTruncateCountScrolling.Size = New System.Drawing.Size(99, 29)
        Me.txtAutoTruncateCountScrolling.TabIndex = 6
        Me.txtAutoTruncateCountScrolling.Text = "9999999"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(344, 55)
        Me.Label12.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(165, 24)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Points (per graph)."
        '
        'txtAutoTruncateCountCumulative
        '
        Me.txtAutoTruncateCountCumulative.Location = New System.Drawing.Point(233, 52)
        Me.txtAutoTruncateCountCumulative.Margin = New System.Windows.Forms.Padding(6)
        Me.txtAutoTruncateCountCumulative.Name = "txtAutoTruncateCountCumulative"
        Me.txtAutoTruncateCountCumulative.Size = New System.Drawing.Size(99, 29)
        Me.txtAutoTruncateCountCumulative.TabIndex = 4
        Me.txtAutoTruncateCountCumulative.Text = "9999999"
        '
        'txtTimeRange
        '
        Me.txtTimeRange.Location = New System.Drawing.Point(293, 11)
        Me.txtTimeRange.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTimeRange.Name = "txtTimeRange"
        Me.txtTimeRange.Size = New System.Drawing.Size(88, 29)
        Me.txtTimeRange.TabIndex = 3
        '
        'optCumulative
        '
        Me.optCumulative.AutoSize = True
        Me.optCumulative.Location = New System.Drawing.Point(22, 51)
        Me.optCumulative.Margin = New System.Windows.Forms.Padding(6)
        Me.optCumulative.Name = "optCumulative"
        Me.optCumulative.Size = New System.Drawing.Size(209, 28)
        Me.optCumulative.TabIndex = 1
        Me.optCumulative.TabStop = True
        Me.optCumulative.Text = "Cumulative, Stop after"
        Me.optCumulative.UseVisualStyleBackColor = True
        '
        'optScrolling
        '
        Me.optScrolling.AutoSize = True
        Me.optScrolling.Location = New System.Drawing.Point(22, 12)
        Me.optScrolling.Margin = New System.Windows.Forms.Padding(6)
        Me.optScrolling.Name = "optScrolling"
        Me.optScrolling.Size = New System.Drawing.Size(267, 28)
        Me.optScrolling.TabIndex = 0
        Me.optScrolling.TabStop = True
        Me.optScrolling.Text = "Scrolling, Time Range (sec):"
        Me.optScrolling.UseVisualStyleBackColor = True
        '
        'optXUseSensor
        '
        Me.optXUseSensor.AutoSize = True
        Me.optXUseSensor.Location = New System.Drawing.Point(15, 146)
        Me.optXUseSensor.Margin = New System.Windows.Forms.Padding(6)
        Me.optXUseSensor.Name = "optXUseSensor"
        Me.optXUseSensor.Size = New System.Drawing.Size(434, 28)
        Me.optXUseSensor.TabIndex = 1
        Me.optXUseSensor.Text = "Show one of the following sensors on the X-Axis"
        Me.optXUseSensor.UseVisualStyleBackColor = True
        '
        'optTimeAxis
        '
        Me.optTimeAxis.AutoSize = True
        Me.optTimeAxis.Checked = True
        Me.optTimeAxis.Location = New System.Drawing.Point(15, 11)
        Me.optTimeAxis.Margin = New System.Windows.Forms.Padding(6)
        Me.optTimeAxis.Name = "optTimeAxis"
        Me.optTimeAxis.Size = New System.Drawing.Size(212, 28)
        Me.optTimeAxis.TabIndex = 0
        Me.optTimeAxis.TabStop = True
        Me.optTimeAxis.Text = "Show Time on X-Axis"
        Me.optTimeAxis.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.chkSelectAllY1)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.txtY1Title)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.dgvY1AxisSensors)
        Me.TabPage3.Location = New System.Drawing.Point(4, 33)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(6)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(953, 465)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Y1 Axis"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'chkSelectAllY1
        '
        Me.chkSelectAllY1.AutoSize = True
        Me.chkSelectAllY1.Location = New System.Drawing.Point(20, 233)
        Me.chkSelectAllY1.Margin = New System.Windows.Forms.Padding(6)
        Me.chkSelectAllY1.Name = "chkSelectAllY1"
        Me.chkSelectAllY1.Size = New System.Drawing.Size(107, 28)
        Me.chkSelectAllY1.TabIndex = 23
        Me.chkSelectAllY1.Text = "Select All"
        Me.chkSelectAllY1.ThreeState = True
        Me.chkSelectAllY1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.optAutoY1)
        Me.GroupBox4.Controls.Add(Me.optY1Manual)
        Me.GroupBox4.Controls.Add(Me.grpY1Manual)
        Me.GroupBox4.Location = New System.Drawing.Point(22, 270)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox4.Size = New System.Drawing.Size(533, 135)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Scale"
        '
        'optAutoY1
        '
        Me.optAutoY1.AutoSize = True
        Me.optAutoY1.Location = New System.Drawing.Point(24, 57)
        Me.optAutoY1.Margin = New System.Windows.Forms.Padding(6)
        Me.optAutoY1.Name = "optAutoY1"
        Me.optAutoY1.Size = New System.Drawing.Size(111, 28)
        Me.optAutoY1.TabIndex = 10
        Me.optAutoY1.TabStop = True
        Me.optAutoY1.Text = "Automatic"
        Me.optAutoY1.UseVisualStyleBackColor = True
        '
        'optY1Manual
        '
        Me.optY1Manual.AutoSize = True
        Me.optY1Manual.Location = New System.Drawing.Point(158, 57)
        Me.optY1Manual.Margin = New System.Windows.Forms.Padding(6)
        Me.optY1Manual.Name = "optY1Manual"
        Me.optY1Manual.Size = New System.Drawing.Size(90, 28)
        Me.optY1Manual.TabIndex = 11
        Me.optY1Manual.TabStop = True
        Me.optY1Manual.Text = "Manual"
        Me.optY1Manual.UseVisualStyleBackColor = True
        '
        'grpY1Manual
        '
        Me.grpY1Manual.Controls.Add(Me.txtY1Max)
        Me.grpY1Manual.Controls.Add(Me.txtY1Min)
        Me.grpY1Manual.Controls.Add(Me.Label6)
        Me.grpY1Manual.Controls.Add(Me.Label7)
        Me.grpY1Manual.Location = New System.Drawing.Point(260, 15)
        Me.grpY1Manual.Margin = New System.Windows.Forms.Padding(6)
        Me.grpY1Manual.Name = "grpY1Manual"
        Me.grpY1Manual.Padding = New System.Windows.Forms.Padding(6)
        Me.grpY1Manual.Size = New System.Drawing.Size(251, 107)
        Me.grpY1Manual.TabIndex = 12
        Me.grpY1Manual.TabStop = False
        '
        'txtY1Max
        '
        Me.txtY1Max.Location = New System.Drawing.Point(127, 22)
        Me.txtY1Max.Margin = New System.Windows.Forms.Padding(6)
        Me.txtY1Max.Name = "txtY1Max"
        Me.txtY1Max.Size = New System.Drawing.Size(103, 29)
        Me.txtY1Max.TabIndex = 1
        '
        'txtY1Min
        '
        Me.txtY1Min.Location = New System.Drawing.Point(127, 63)
        Me.txtY1Min.Margin = New System.Windows.Forms.Padding(6)
        Me.txtY1Min.Name = "txtY1Min"
        Me.txtY1Min.Size = New System.Drawing.Size(103, 29)
        Me.txtY1Min.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 69)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 24)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "M&inimum:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 28)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 24)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "&Maximum:"
        '
        'txtY1Title
        '
        Me.txtY1Title.Location = New System.Drawing.Point(149, 425)
        Me.txtY1Title.Margin = New System.Windows.Forms.Padding(6)
        Me.txtY1Title.MaxLength = 50
        Me.txtY1Title.Name = "txtY1Title"
        Me.txtY1Title.Size = New System.Drawing.Size(330, 29)
        Me.txtY1Title.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 428)
        Me.Label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 24)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Y1-Axis Title:"
        '
        'dgvY1AxisSensors
        '
        Me.dgvY1AxisSensors.AllowUserToAddRows = False
        Me.dgvY1AxisSensors.AllowUserToDeleteRows = False
        Me.dgvY1AxisSensors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvY1AxisSensors.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvY1AxisSensors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvY1AxisSensors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.y1Check, Me.y1Ss1, Me.y1Type, Me.y1Color, Me.y1cmdColor, Me.y1LineStyle, Me.y1LineWidth, Me.y1MarkerStyle, Me.y1MarkerSize})
        Me.dgvY1AxisSensors.Location = New System.Drawing.Point(22, 22)
        Me.dgvY1AxisSensors.Margin = New System.Windows.Forms.Padding(6)
        Me.dgvY1AxisSensors.Name = "dgvY1AxisSensors"
        Me.dgvY1AxisSensors.RowHeadersVisible = False
        Me.dgvY1AxisSensors.Size = New System.Drawing.Size(920, 199)
        Me.dgvY1AxisSensors.TabIndex = 0
        '
        'y1Check
        '
        Me.y1Check.HeaderText = "Select"
        Me.y1Check.Name = "y1Check"
        Me.y1Check.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.y1Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.y1Check.Width = 87
        '
        'y1Ss1
        '
        Me.y1Ss1.HeaderText = "Name"
        Me.y1Ss1.Name = "y1Ss1"
        Me.y1Ss1.ReadOnly = True
        Me.y1Ss1.Width = 86
        '
        'y1Type
        '
        Me.y1Type.HeaderText = "Type"
        Me.y1Type.Name = "y1Type"
        Me.y1Type.ReadOnly = True
        Me.y1Type.Width = 78
        '
        'y1Color
        '
        Me.y1Color.HeaderText = "Color"
        Me.y1Color.Name = "y1Color"
        Me.y1Color.ReadOnly = True
        Me.y1Color.Width = 80
        '
        'y1cmdColor
        '
        Me.y1cmdColor.HeaderText = "Select Color"
        Me.y1cmdColor.Name = "y1cmdColor"
        Me.y1cmdColor.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.y1cmdColor.Width = 118
        '
        'y1LineStyle
        '
        Me.y1LineStyle.HeaderText = "Line Style"
        Me.y1LineStyle.Name = "y1LineStyle"
        Me.y1LineStyle.Width = 97
        '
        'y1LineWidth
        '
        Me.y1LineWidth.HeaderText = "Line Width"
        Me.y1LineWidth.Name = "y1LineWidth"
        Me.y1LineWidth.Width = 105
        '
        'y1MarkerStyle
        '
        Me.y1MarkerStyle.HeaderText = "Marker Type"
        Me.y1MarkerStyle.Name = "y1MarkerStyle"
        Me.y1MarkerStyle.Width = 122
        '
        'y1MarkerSize
        '
        Me.y1MarkerSize.HeaderText = "Marker Size"
        Me.y1MarkerSize.Name = "y1MarkerSize"
        Me.y1MarkerSize.Width = 115
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.chkSelectAllY2)
        Me.TabPage4.Controls.Add(Me.GroupBox1)
        Me.TabPage4.Controls.Add(Me.txtY2Title)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.dgvY2AxisSensors)
        Me.TabPage4.Location = New System.Drawing.Point(4, 33)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(6)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(953, 465)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Y2 Axis"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optAutoY2)
        Me.GroupBox1.Controls.Add(Me.optY2Manual)
        Me.GroupBox1.Controls.Add(Me.grpY2Manual)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 270)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox1.Size = New System.Drawing.Size(533, 135)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Scale"
        '
        'optAutoY2
        '
        Me.optAutoY2.AutoSize = True
        Me.optAutoY2.Location = New System.Drawing.Point(24, 57)
        Me.optAutoY2.Margin = New System.Windows.Forms.Padding(6)
        Me.optAutoY2.Name = "optAutoY2"
        Me.optAutoY2.Size = New System.Drawing.Size(111, 28)
        Me.optAutoY2.TabIndex = 10
        Me.optAutoY2.TabStop = True
        Me.optAutoY2.Text = "Automatic"
        Me.optAutoY2.UseVisualStyleBackColor = True
        '
        'optY2Manual
        '
        Me.optY2Manual.AutoSize = True
        Me.optY2Manual.Location = New System.Drawing.Point(158, 57)
        Me.optY2Manual.Margin = New System.Windows.Forms.Padding(6)
        Me.optY2Manual.Name = "optY2Manual"
        Me.optY2Manual.Size = New System.Drawing.Size(90, 28)
        Me.optY2Manual.TabIndex = 11
        Me.optY2Manual.TabStop = True
        Me.optY2Manual.Text = "Manual"
        Me.optY2Manual.UseVisualStyleBackColor = True
        '
        'grpY2Manual
        '
        Me.grpY2Manual.Controls.Add(Me.txtY2Max)
        Me.grpY2Manual.Controls.Add(Me.txtY2Min)
        Me.grpY2Manual.Controls.Add(Me.Label2)
        Me.grpY2Manual.Controls.Add(Me.Label8)
        Me.grpY2Manual.Location = New System.Drawing.Point(260, 15)
        Me.grpY2Manual.Margin = New System.Windows.Forms.Padding(6)
        Me.grpY2Manual.Name = "grpY2Manual"
        Me.grpY2Manual.Padding = New System.Windows.Forms.Padding(6)
        Me.grpY2Manual.Size = New System.Drawing.Size(251, 107)
        Me.grpY2Manual.TabIndex = 12
        Me.grpY2Manual.TabStop = False
        '
        'txtY2Max
        '
        Me.txtY2Max.Location = New System.Drawing.Point(127, 22)
        Me.txtY2Max.Margin = New System.Windows.Forms.Padding(6)
        Me.txtY2Max.Name = "txtY2Max"
        Me.txtY2Max.Size = New System.Drawing.Size(103, 29)
        Me.txtY2Max.TabIndex = 1
        '
        'txtY2Min
        '
        Me.txtY2Min.Location = New System.Drawing.Point(127, 64)
        Me.txtY2Min.Margin = New System.Windows.Forms.Padding(6)
        Me.txtY2Min.Name = "txtY2Min"
        Me.txtY2Min.Size = New System.Drawing.Size(103, 29)
        Me.txtY2Min.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 70)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "M&inimum:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 28)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 24)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "&Maximum:"
        '
        'txtY2Title
        '
        Me.txtY2Title.Location = New System.Drawing.Point(144, 425)
        Me.txtY2Title.Margin = New System.Windows.Forms.Padding(6)
        Me.txtY2Title.MaxLength = 50
        Me.txtY2Title.Name = "txtY2Title"
        Me.txtY2Title.Size = New System.Drawing.Size(330, 29)
        Me.txtY2Title.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 428)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 24)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Y2-Axis Title:"
        '
        'dgvY2AxisSensors
        '
        Me.dgvY2AxisSensors.AllowUserToAddRows = False
        Me.dgvY2AxisSensors.AllowUserToDeleteRows = False
        Me.dgvY2AxisSensors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvY2AxisSensors.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvY2AxisSensors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvY2AxisSensors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Y2Check, Me.Y2Ss1, Me.Y2Type, Me.Y2Color, Me.Y2cmdColor, Me.Y2LineStyle, Me.Y2LineWidth, Me.Y2MarkerStyle, Me.Y2MarkerSize})
        Me.dgvY2AxisSensors.Location = New System.Drawing.Point(17, 17)
        Me.dgvY2AxisSensors.Margin = New System.Windows.Forms.Padding(6)
        Me.dgvY2AxisSensors.Name = "dgvY2AxisSensors"
        Me.dgvY2AxisSensors.RowHeadersVisible = False
        Me.dgvY2AxisSensors.Size = New System.Drawing.Size(920, 199)
        Me.dgvY2AxisSensors.TabIndex = 16
        '
        'Y2Check
        '
        Me.Y2Check.HeaderText = "Select"
        Me.Y2Check.Name = "Y2Check"
        Me.Y2Check.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Y2Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Y2Check.Width = 87
        '
        'Y2Ss1
        '
        Me.Y2Ss1.HeaderText = "Name"
        Me.Y2Ss1.Name = "Y2Ss1"
        Me.Y2Ss1.ReadOnly = True
        Me.Y2Ss1.Width = 86
        '
        'Y2Type
        '
        Me.Y2Type.HeaderText = "Type"
        Me.Y2Type.Name = "Y2Type"
        Me.Y2Type.ReadOnly = True
        Me.Y2Type.Width = 78
        '
        'Y2Color
        '
        Me.Y2Color.HeaderText = "Color"
        Me.Y2Color.Name = "Y2Color"
        Me.Y2Color.ReadOnly = True
        Me.Y2Color.Width = 80
        '
        'Y2cmdColor
        '
        Me.Y2cmdColor.HeaderText = "Select Color"
        Me.Y2cmdColor.Name = "Y2cmdColor"
        Me.Y2cmdColor.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Y2cmdColor.Width = 118
        '
        'Y2LineStyle
        '
        Me.Y2LineStyle.HeaderText = "Line Style"
        Me.Y2LineStyle.Name = "Y2LineStyle"
        Me.Y2LineStyle.Width = 97
        '
        'Y2LineWidth
        '
        Me.Y2LineWidth.HeaderText = "Line Width"
        Me.Y2LineWidth.Name = "Y2LineWidth"
        Me.Y2LineWidth.Width = 105
        '
        'Y2MarkerStyle
        '
        Me.Y2MarkerStyle.HeaderText = "Marker Type"
        Me.Y2MarkerStyle.Name = "Y2MarkerStyle"
        Me.Y2MarkerStyle.Width = 122
        '
        'Y2MarkerSize
        '
        Me.Y2MarkerSize.HeaderText = "Marker Size"
        Me.Y2MarkerSize.Name = "Y2MarkerSize"
        Me.Y2MarkerSize.Width = 115
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(26, 36)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(77, 17)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Cumulative"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(26, 13)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(65, 17)
        Me.RadioButton2.TabIndex = 0
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Scrolling"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CheckedListBox1)
        Me.Panel1.Location = New System.Drawing.Point(49, 144)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(416, 209)
        Me.Panel1.TabIndex = 5
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(3, 3)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(186, 109)
        Me.CheckedListBox1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.RadioButton1)
        Me.Panel2.Controls.Add(Me.RadioButton2)
        Me.Panel2.Location = New System.Drawing.Point(49, 44)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(279, 62)
        Me.Panel2.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(211, 13)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(50, 20)
        Me.TextBox1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(107, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Time Range (sec.):"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(27, 121)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(251, 17)
        Me.RadioButton3.TabIndex = 1
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Show one of the following sensors on the X-Axis"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(27, 21)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(125, 17)
        Me.RadioButton4.TabIndex = 0
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Show Time on X-Axis"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Image = Global.LoadVUE.My.Resources.Resources.cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(1110, 522)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(145, 43)
        Me.cmdCancel.TabIndex = 15
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Image = Global.LoadVUE.My.Resources.Resources.ok
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(955, 522)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(145, 43)
        Me.cmdOK.TabIndex = 14
        Me.cmdOK.Text = "OK"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Image = Global.LoadVUE.My.Resources.Resources.new_plus
        Me.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdNew.Location = New System.Drawing.Point(25, 522)
        Me.cmdNew.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(122, 43)
        Me.cmdNew.TabIndex = 16
        Me.cmdNew.Text = "New"
        Me.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Image = Global.LoadVUE.My.Resources.Resources.delete_minus
        Me.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDelete.Location = New System.Drawing.Point(159, 522)
        Me.cmdDelete.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(122, 43)
        Me.cmdDelete.TabIndex = 17
        Me.cmdDelete.Text = "Delete..."
        Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.HideSelection = False
        Me.TreeView1.Location = New System.Drawing.Point(22, 11)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(6)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.ShowLines = False
        Me.TreeView1.ShowPlusMinus = False
        Me.TreeView1.ShowRootLines = False
        Me.TreeView1.Size = New System.Drawing.Size(265, 495)
        Me.TreeView1.TabIndex = 18
        '
        'chkSelectAllY2
        '
        Me.chkSelectAllY2.AutoSize = True
        Me.chkSelectAllY2.Location = New System.Drawing.Point(20, 233)
        Me.chkSelectAllY2.Margin = New System.Windows.Forms.Padding(6)
        Me.chkSelectAllY2.Name = "chkSelectAllY2"
        Me.chkSelectAllY2.Size = New System.Drawing.Size(107, 28)
        Me.chkSelectAllY2.TabIndex = 24
        Me.chkSelectAllY2.Text = "Select All"
        Me.chkSelectAllY2.ThreeState = True
        Me.chkSelectAllY2.UseVisualStyleBackColor = True
        '
        'frmGraphOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1268, 578)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdNew)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGraphOptions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Graph Options"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.udLabelFontSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udTitleFontSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.pnlXsensor.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.grpXManual.ResumeLayout(False)
        Me.grpXManual.PerformLayout()
        Me.pnlTime.ResumeLayout(False)
        Me.pnlTime.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.grpY1Manual.ResumeLayout(False)
        Me.grpY1Manual.PerformLayout()
        CType(Me.dgvY1AxisSensors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpY2Manual.ResumeLayout(False)
        Me.grpY2Manual.PerformLayout()
        CType(Me.dgvY2AxisSensors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkShowLegend As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowGrid As System.Windows.Forms.CheckBox
    Friend WithEvents optXUseSensor As System.Windows.Forms.RadioButton
    Friend WithEvents optTimeAxis As System.Windows.Forms.RadioButton
    Friend WithEvents dgvY1AxisSensors As System.Windows.Forms.DataGridView
    Friend WithEvents pnlTime As System.Windows.Forms.Panel
    Friend WithEvents optCumulative As System.Windows.Forms.RadioButton
    Friend WithEvents optScrolling As System.Windows.Forms.RadioButton
    Friend WithEvents txtTimeRange As System.Windows.Forms.TextBox
    Friend WithEvents pnlXsensor As System.Windows.Forms.Panel
    Friend WithEvents optXManual As System.Windows.Forms.RadioButton
    Friend WithEvents optAutoX As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents grpXManual As System.Windows.Forms.GroupBox
    Friend WithEvents txtXMax As LvNumericTextBox.LvNumericTextBox
    Friend WithEvents txtXMin As LvNumericTextBox.LvNumericTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lstXAxisSensors As System.Windows.Forms.ListBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents grpY1Manual As System.Windows.Forms.GroupBox
    Friend WithEvents txtY1Max As LvNumericTextBox.LvNumericTextBox
    Friend WithEvents txtY1Min As LvNumericTextBox.LvNumericTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents optY1Manual As System.Windows.Forms.RadioButton
    Friend WithEvents optAutoY1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtXTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtY1Title As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents chkShowMinorGrid As System.Windows.Forms.CheckBox
    Friend WithEvents chkBlackBackground As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkEnableGraph As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowTitle As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents udTitleFontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents udLabelFontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents y1Check As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents y1Ss1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents y1Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents y1Color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents y1cmdColor As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents y1LineStyle As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents y1LineWidth As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents y1MarkerStyle As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents y1MarkerSize As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optAutoY2 As System.Windows.Forms.RadioButton
    Friend WithEvents optY2Manual As System.Windows.Forms.RadioButton
    Friend WithEvents grpY2Manual As System.Windows.Forms.GroupBox
    Friend WithEvents txtY2Max As LvNumericTextBox.LvNumericTextBox
    Friend WithEvents txtY2Min As LvNumericTextBox.LvNumericTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtY2Title As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvY2AxisSensors As System.Windows.Forms.DataGridView
    Friend WithEvents Y2Check As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Y2Ss1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Y2Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Y2Color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Y2cmdColor As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Y2LineStyle As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Y2LineWidth As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Y2MarkerStyle As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Y2MarkerSize As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtAutoTruncateCountCumulative As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtAutoTruncateCountScrolling As System.Windows.Forms.TextBox
    Friend WithEvents chkSelectAllY1 As CheckBox
    Friend WithEvents chkSelectAllY2 As CheckBox
End Class
