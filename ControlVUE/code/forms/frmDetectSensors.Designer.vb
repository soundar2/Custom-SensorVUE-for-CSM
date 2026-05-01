<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetectSensors
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetectSensors))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdRetry = New System.Windows.Forms.Button()
        Me.dgvSensors = New System.Windows.Forms.DataGridView()
        Me.check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ss1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sensorType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.connection = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.cmdPutty = New System.Windows.Forms.Button()
        Me.cmdDeviceManager = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmdTeamviewer = New System.Windows.Forms.Button()
        Me.latencyDocLink = New System.Windows.Forms.LinkLabel()
        Me.lblSelectedCount = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvSensors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Enabled = False
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Image = Global.LoadVUE.My.Resources.Resources.cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(794, 385)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(145, 50)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Enabled = False
        Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Image = Global.LoadVUE.My.Resources.Resources.ok
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(639, 385)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(145, 50)
        Me.cmdOK.TabIndex = 12
        Me.cmdOK.Text = "&Continue"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar1.Location = New System.Drawing.Point(557, 7)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1918, 33)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 13
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblProgress.Location = New System.Drawing.Point(9, 16)
        Me.lblProgress.Margin = New System.Windows.Forms.Padding(9, 0, 9, 0)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(516, 31)
        Me.lblProgress.TabIndex = 20
        Me.lblProgress.Text = "Scanning COM99, Baud 230400..."
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 534.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.ProgressBar1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProgress, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 439)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(954, 47)
        Me.TableLayoutPanel1.TabIndex = 21
        '
        'cmdRetry
        '
        Me.cmdRetry.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRetry.Image = CType(resources.GetObject("cmdRetry.Image"), System.Drawing.Image)
        Me.cmdRetry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRetry.Location = New System.Drawing.Point(485, 385)
        Me.cmdRetry.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdRetry.Name = "cmdRetry"
        Me.cmdRetry.Size = New System.Drawing.Size(145, 50)
        Me.cmdRetry.TabIndex = 29
        Me.cmdRetry.Text = "&Retry"
        Me.cmdRetry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdRetry.UseVisualStyleBackColor = True
        '
        'dgvSensors
        '
        Me.dgvSensors.AllowUserToAddRows = False
        Me.dgvSensors.AllowUserToDeleteRows = False
        Me.dgvSensors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvSensors.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvSensors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSensors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.check, Me.ss1, Me.sensorType, Me.connection})
        Me.dgvSensors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvSensors.Location = New System.Drawing.Point(22, 17)
        Me.dgvSensors.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.dgvSensors.MultiSelect = False
        Me.dgvSensors.Name = "dgvSensors"
        Me.dgvSensors.RowHeadersVisible = False
        Me.dgvSensors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSensors.Size = New System.Drawing.Size(658, 320)
        Me.dgvSensors.TabIndex = 30
        '
        'check
        '
        Me.check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.NullValue = False
        Me.check.DefaultCellStyle = DataGridViewCellStyle2
        Me.check.HeaderText = "Select"
        Me.check.Name = "check"
        Me.check.ReadOnly = True
        Me.check.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.check.Width = 96
        '
        'ss1
        '
        Me.ss1.HeaderText = "Name"
        Me.ss1.Name = "ss1"
        Me.ss1.ReadOnly = True
        Me.ss1.Width = 111
        '
        'sensorType
        '
        Me.sensorType.HeaderText = "Type"
        Me.sensorType.Name = "sensorType"
        Me.sensorType.ReadOnly = True
        '
        'connection
        '
        Me.connection.HeaderText = "Connection"
        Me.connection.Name = "connection"
        Me.connection.ReadOnly = True
        Me.connection.Width = 177
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(22, 345)
        Me.chkAll.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(697, 35)
        Me.chkAll.TabIndex = 31
        Me.chkAll.Text = "Select/Clear All, uncheck items you do not want to read"
        Me.chkAll.ThreeState = True
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'cmdPutty
        '
        Me.cmdPutty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPutty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPutty.Location = New System.Drawing.Point(692, 174)
        Me.cmdPutty.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdPutty.Name = "cmdPutty"
        Me.cmdPutty.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.cmdPutty.Size = New System.Drawing.Size(247, 50)
        Me.cmdPutty.TabIndex = 32
        Me.cmdPutty.Text = "Terminal Program"
        Me.cmdPutty.UseVisualStyleBackColor = True
        '
        'cmdDeviceManager
        '
        Me.cmdDeviceManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeviceManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDeviceManager.Location = New System.Drawing.Point(692, 110)
        Me.cmdDeviceManager.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdDeviceManager.Name = "cmdDeviceManager"
        Me.cmdDeviceManager.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.cmdDeviceManager.Size = New System.Drawing.Size(247, 50)
        Me.cmdDeviceManager.TabIndex = 33
        Me.cmdDeviceManager.Text = "&Device Manager"
        Me.cmdDeviceManager.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(692, -9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(253, 115)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'cmdTeamviewer
        '
        Me.cmdTeamviewer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTeamviewer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdTeamviewer.Location = New System.Drawing.Point(692, 238)
        Me.cmdTeamviewer.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdTeamviewer.Name = "cmdTeamviewer"
        Me.cmdTeamviewer.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.cmdTeamviewer.Size = New System.Drawing.Size(247, 50)
        Me.cmdTeamviewer.TabIndex = 35
        Me.cmdTeamviewer.Text = "&Remote Support"
        Me.cmdTeamviewer.UseVisualStyleBackColor = True
        '
        'latencyDocLink
        '
        Me.latencyDocLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.latencyDocLink.Location = New System.Drawing.Point(692, 306)
        Me.latencyDocLink.Name = "latencyDocLink"
        Me.latencyDocLink.Size = New System.Drawing.Size(247, 32)
        Me.latencyDocLink.TabIndex = 36
        Me.latencyDocLink.TabStop = True
        Me.latencyDocLink.Text = "How to set latency timer"
        Me.latencyDocLink.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSelectedCount
        '
        Me.lblSelectedCount.AutoSize = True
        Me.lblSelectedCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedCount.Location = New System.Drawing.Point(16, 385)
        Me.lblSelectedCount.Name = "lblSelectedCount"
        Me.lblSelectedCount.Size = New System.Drawing.Size(29, 31)
        Me.lblSelectedCount.TabIndex = 37
        Me.lblSelectedCount.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(60, 385)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 31)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Selected"
        '
        'frmDetectSensors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(954, 486)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSelectedCount)
        Me.Controls.Add(Me.latencyDocLink)
        Me.Controls.Add(Me.cmdTeamviewer)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmdDeviceManager)
        Me.Controls.Add(Me.cmdPutty)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.dgvSensors)
        Me.Controls.Add(Me.cmdRetry)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDetectSensors"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "..."
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvSensors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdRetry As System.Windows.Forms.Button
    Friend WithEvents dgvSensors As System.Windows.Forms.DataGridView
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents cmdPutty As System.Windows.Forms.Button
    Friend WithEvents cmdDeviceManager As System.Windows.Forms.Button
    Friend WithEvents check As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ss1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sensorType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents connection As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdTeamviewer As System.Windows.Forms.Button
    Friend WithEvents latencyDocLink As System.Windows.Forms.LinkLabel
    Friend WithEvents lblSelectedCount As Label
    Friend WithEvents Label1 As Label
End Class
