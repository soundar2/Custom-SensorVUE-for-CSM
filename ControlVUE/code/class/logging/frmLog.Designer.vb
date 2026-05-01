<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLog
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLog))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlLogOuter = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.pnlLog = New System.Windows.Forms.Panel()
        Me.pnlLogMessage = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvLog = New System.Windows.Forms.DataGridView()
        Me.time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colElapsedTimeSec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlUploadToCloud = New System.Windows.Forms.Panel()
        Me.txtUploadLog = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.chkUploadToCloud = New System.Windows.Forms.CheckBox()
        Me.cmdLogNow = New System.Windows.Forms.Button()
        Me.txtUdf = New System.Windows.Forms.TextBox()
        Me.lblUdf = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdLogOptions = New System.Windows.Forms.Button()
        Me.cmbLogInterval = New System.Windows.Forms.ComboBox()
        Me.pnlLogSettings = New System.Windows.Forms.Panel()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.chkLogToFile = New System.Windows.Forms.CheckBox()
        Me.txtLogFile = New System.Windows.Forms.TextBox()
        Me.TimerLogFileSize = New System.Windows.Forms.Timer(Me.components)
        Me.TimerLogToScreen = New System.Windows.Forms.Timer(Me.components)
        Me.pnlLogOuter.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlLog.SuspendLayout()
        Me.pnlLogMessage.SuspendLayout()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlUploadToCloud.SuspendLayout()
        Me.pnlLogSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLogOuter
        '
        Me.pnlLogOuter.Controls.Add(Me.SplitContainer1)
        Me.pnlLogOuter.Controls.Add(Me.pnlLogSettings)
        Me.pnlLogOuter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLogOuter.Location = New System.Drawing.Point(0, 0)
        Me.pnlLogOuter.Margin = New System.Windows.Forms.Padding(6)
        Me.pnlLogOuter.Name = "pnlLogOuter"
        Me.pnlLogOuter.Size = New System.Drawing.Size(955, 702)
        Me.pnlLogOuter.TabIndex = 8
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 58)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlLog)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(955, 644)
        Me.SplitContainer1.SplitterDistance = 701
        Me.SplitContainer1.TabIndex = 4
        '
        'pnlLog
        '
        Me.pnlLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlLog.Controls.Add(Me.pnlLogMessage)
        Me.pnlLog.Controls.Add(Me.dgvLog)
        Me.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLog.Location = New System.Drawing.Point(0, 0)
        Me.pnlLog.Margin = New System.Windows.Forms.Padding(6)
        Me.pnlLog.Name = "pnlLog"
        Me.pnlLog.Size = New System.Drawing.Size(701, 644)
        Me.pnlLog.TabIndex = 2
        '
        'pnlLogMessage
        '
        Me.pnlLogMessage.BackgroundImage = CType(resources.GetObject("pnlLogMessage.BackgroundImage"), System.Drawing.Image)
        Me.pnlLogMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlLogMessage.Controls.Add(Me.Label2)
        Me.pnlLogMessage.Controls.Add(Me.Label6)
        Me.pnlLogMessage.Location = New System.Drawing.Point(132, 100)
        Me.pnlLogMessage.Margin = New System.Windows.Forms.Padding(6)
        Me.pnlLogMessage.Name = "pnlLogMessage"
        Me.pnlLogMessage.Size = New System.Drawing.Size(410, 183)
        Me.pnlLogMessage.TabIndex = 34
        Me.pnlLogMessage.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(11, 41)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(310, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Logging to screen is not available/disabled."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(11, 113)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(338, 20)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "However, logging to file will proceed if selected."
        '
        'dgvLog
        '
        Me.dgvLog.AllowUserToAddRows = False
        Me.dgvLog.AllowUserToDeleteRows = False
        Me.dgvLog.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvLog.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.time, Me.colElapsedTimeSec})
        Me.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvLog.Location = New System.Drawing.Point(0, 0)
        Me.dgvLog.Margin = New System.Windows.Forms.Padding(6)
        Me.dgvLog.MultiSelect = False
        Me.dgvLog.Name = "dgvLog"
        Me.dgvLog.ReadOnly = True
        Me.dgvLog.RowHeadersVisible = False
        Me.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLog.Size = New System.Drawing.Size(697, 640)
        Me.dgvLog.TabIndex = 36
        '
        'time
        '
        Me.time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.time.Frozen = True
        Me.time.HeaderText = "Time"
        Me.time.Name = "time"
        Me.time.ReadOnly = True
        Me.time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.time.Width = 59
        '
        'colElapsedTimeSec
        '
        Me.colElapsedTimeSec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colElapsedTimeSec.Frozen = True
        Me.colElapsedTimeSec.HeaderText = "Elapsed Time (sec)"
        Me.colElapsedTimeSec.Name = "colElapsedTimeSec"
        Me.colElapsedTimeSec.ReadOnly = True
        Me.colElapsedTimeSec.Width = 143
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.Controls.Add(Me.txtUploadLog)
        Me.Panel1.Controls.Add(Me.pnlUploadToCloud)
        Me.Panel1.Controls.Add(Me.cmdLogNow)
        Me.Panel1.Controls.Add(Me.txtUdf)
        Me.Panel1.Controls.Add(Me.lblUdf)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmdLogOptions)
        Me.Panel1.Controls.Add(Me.cmbLogInterval)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(250, 644)
        Me.Panel1.TabIndex = 3
        '
        'pnlUploadToCloud
        '
        Me.pnlUploadToCloud.Controls.Add(Me.LinkLabel1)
        Me.pnlUploadToCloud.Controls.Add(Me.chkUploadToCloud)
        Me.pnlUploadToCloud.Location = New System.Drawing.Point(18, 270)
        Me.pnlUploadToCloud.Name = "pnlUploadToCloud"
        Me.pnlUploadToCloud.Size = New System.Drawing.Size(216, 70)
        Me.pnlUploadToCloud.TabIndex = 65
        '
        'txtUploadLog
        '
        Me.txtUploadLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtUploadLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUploadLog.Location = New System.Drawing.Point(20, 346)
        Me.txtUploadLog.Multiline = True
        Me.txtUploadLog.Name = "txtUploadLog"
        Me.txtUploadLog.ReadOnly = True
        Me.txtUploadLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtUploadLog.Size = New System.Drawing.Size(215, 275)
        Me.txtUploadLog.TabIndex = 65
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(28, 35)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(164, 24)
        Me.LinkLabel1.TabIndex = 64
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "SensorVUE Cloud"
        '
        'chkUploadToCloud
        '
        Me.chkUploadToCloud.AutoSize = True
        Me.chkUploadToCloud.Location = New System.Drawing.Point(10, 6)
        Me.chkUploadToCloud.Name = "chkUploadToCloud"
        Me.chkUploadToCloud.Size = New System.Drawing.Size(109, 28)
        Me.chkUploadToCloud.TabIndex = 63
        Me.chkUploadToCloud.Text = "Upload to"
        Me.chkUploadToCloud.UseVisualStyleBackColor = True
        '
        'cmdLogNow
        '
        Me.cmdLogNow.Enabled = False
        Me.cmdLogNow.Image = CType(resources.GetObject("cmdLogNow.Image"), System.Drawing.Image)
        Me.cmdLogNow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLogNow.Location = New System.Drawing.Point(18, 222)
        Me.cmdLogNow.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdLogNow.Name = "cmdLogNow"
        Me.cmdLogNow.Size = New System.Drawing.Size(217, 39)
        Me.cmdLogNow.TabIndex = 36
        Me.cmdLogNow.Text = "Take one Reading"
        Me.cmdLogNow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdLogNow.UseVisualStyleBackColor = True
        '
        'txtUdf
        '
        Me.txtUdf.BackColor = System.Drawing.Color.White
        Me.txtUdf.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUdf.Location = New System.Drawing.Point(18, 169)
        Me.txtUdf.Margin = New System.Windows.Forms.Padding(6)
        Me.txtUdf.Name = "txtUdf"
        Me.txtUdf.Size = New System.Drawing.Size(216, 29)
        Me.txtUdf.TabIndex = 38
        Me.txtUdf.TabStop = False
        '
        'lblUdf
        '
        Me.lblUdf.BackColor = System.Drawing.Color.Transparent
        Me.lblUdf.Location = New System.Drawing.Point(16, 139)
        Me.lblUdf.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblUdf.Name = "lblUdf"
        Me.lblUdf.Size = New System.Drawing.Size(178, 24)
        Me.lblUdf.TabIndex = 37
        Me.lblUdf.Text = "User defined field:"
        Me.lblUdf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 24)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Log Interval:"
        '
        'cmdLogOptions
        '
        Me.cmdLogOptions.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLogOptions.Image = CType(resources.GetObject("cmdLogOptions.Image"), System.Drawing.Image)
        Me.cmdLogOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLogOptions.Location = New System.Drawing.Point(18, 79)
        Me.cmdLogOptions.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdLogOptions.Name = "cmdLogOptions"
        Me.cmdLogOptions.Size = New System.Drawing.Size(217, 44)
        Me.cmdLogOptions.TabIndex = 61
        Me.cmdLogOptions.Text = "Log Options..."
        Me.cmdLogOptions.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdLogOptions.UseVisualStyleBackColor = False
        '
        'cmbLogInterval
        '
        Me.cmbLogInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLogInterval.FormattingEnabled = True
        Me.cmbLogInterval.Location = New System.Drawing.Point(18, 36)
        Me.cmbLogInterval.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbLogInterval.Name = "cmbLogInterval"
        Me.cmbLogInterval.Size = New System.Drawing.Size(216, 32)
        Me.cmbLogInterval.TabIndex = 30
        '
        'pnlLogSettings
        '
        Me.pnlLogSettings.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pnlLogSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlLogSettings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlLogSettings.Controls.Add(Me.cmdBrowse)
        Me.pnlLogSettings.Controls.Add(Me.chkLogToFile)
        Me.pnlLogSettings.Controls.Add(Me.txtLogFile)
        Me.pnlLogSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLogSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnlLogSettings.Margin = New System.Windows.Forms.Padding(6)
        Me.pnlLogSettings.Name = "pnlLogSettings"
        Me.pnlLogSettings.Size = New System.Drawing.Size(955, 58)
        Me.pnlLogSettings.TabIndex = 1
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Enabled = False
        Me.cmdBrowse.Image = CType(resources.GetObject("cmdBrowse.Image"), System.Drawing.Image)
        Me.cmdBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBrowse.Location = New System.Drawing.Point(551, 5)
        Me.cmdBrowse.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(148, 39)
        Me.cmdBrowse.TabIndex = 27
        Me.cmdBrowse.Text = "Select File..."
        Me.cmdBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'chkLogToFile
        '
        Me.chkLogToFile.AutoSize = True
        Me.chkLogToFile.Location = New System.Drawing.Point(13, 13)
        Me.chkLogToFile.Margin = New System.Windows.Forms.Padding(6)
        Me.chkLogToFile.Name = "chkLogToFile"
        Me.chkLogToFile.Size = New System.Drawing.Size(122, 28)
        Me.chkLogToFile.TabIndex = 26
        Me.chkLogToFile.Text = "Log to File:"
        Me.chkLogToFile.UseVisualStyleBackColor = True
        '
        'txtLogFile
        '
        Me.txtLogFile.Enabled = False
        Me.txtLogFile.Location = New System.Drawing.Point(147, 11)
        Me.txtLogFile.Margin = New System.Windows.Forms.Padding(6)
        Me.txtLogFile.Name = "txtLogFile"
        Me.txtLogFile.ReadOnly = True
        Me.txtLogFile.Size = New System.Drawing.Size(392, 29)
        Me.txtLogFile.TabIndex = 28
        '
        'TimerLogFileSize
        '
        Me.TimerLogFileSize.Interval = 5000
        '
        'TimerLogToScreen
        '
        Me.TimerLogToScreen.Interval = 1000
        '
        'frmLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 702)
        Me.Controls.Add(Me.pnlLogOuter)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "frmLog"
        Me.Text = "Log"
        Me.pnlLogOuter.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlLog.ResumeLayout(False)
        Me.pnlLogMessage.ResumeLayout(False)
        Me.pnlLogMessage.PerformLayout()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlUploadToCloud.ResumeLayout(False)
        Me.pnlUploadToCloud.PerformLayout()
        Me.pnlLogSettings.ResumeLayout(False)
        Me.pnlLogSettings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLogOuter As System.Windows.Forms.Panel
    Friend WithEvents pnlLog As System.Windows.Forms.Panel
    Friend WithEvents pnlLogMessage As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvLog As System.Windows.Forms.DataGridView
    Friend WithEvents pnlLogSettings As System.Windows.Forms.Panel
    Friend WithEvents txtUdf As System.Windows.Forms.TextBox
    Friend WithEvents lblUdf As System.Windows.Forms.Label
    Friend WithEvents cmdLogNow As System.Windows.Forms.Button
    Friend WithEvents cmbLogInterval As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkLogToFile As System.Windows.Forms.CheckBox
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents txtLogFile As System.Windows.Forms.TextBox
    Friend WithEvents TimerLogFileSize As System.Windows.Forms.Timer
    Friend WithEvents cmdLogOptions As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents chkUploadToCloud As System.Windows.Forms.CheckBox
    Friend WithEvents time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colElapsedTimeSec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents pnlUploadToCloud As System.Windows.Forms.Panel
    Friend WithEvents TimerLogToScreen As System.Windows.Forms.Timer
    Friend WithEvents txtUploadLog As System.Windows.Forms.TextBox
End Class
