<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetectLv100
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetectLv100))
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
        Me.port = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmdPutty = New System.Windows.Forms.Button()
        Me.cmdDeviceManager = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvSensors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Enabled = False
        Me.cmdCancel.Image = Global.LoadVUE.My.Resources.Resources.cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(545, 166)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.cmdCancel.Size = New System.Drawing.Size(145, 66)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Enabled = False
        Me.cmdOK.Image = Global.LoadVUE.My.Resources.Resources.ok
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(545, 89)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.cmdOK.Size = New System.Drawing.Size(145, 66)
        Me.cmdOK.TabIndex = 12
        Me.cmdOK.Text = "&Continue"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar1.Location = New System.Drawing.Point(382, 6)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(6)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1157, 26)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 13
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblProgress.Location = New System.Drawing.Point(6, 14)
        Me.lblProgress.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(355, 24)
        Me.lblProgress.TabIndex = 20
        Me.lblProgress.Text = "Scanning COM99, Baud 230400..."
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 367.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.ProgressBar1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProgress, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 338)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(708, 38)
        Me.TableLayoutPanel1.TabIndex = 21
        '
        'cmdRetry
        '
        Me.cmdRetry.Image = CType(resources.GetObject("cmdRetry.Image"), System.Drawing.Image)
        Me.cmdRetry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRetry.Location = New System.Drawing.Point(545, 12)
        Me.cmdRetry.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdRetry.Name = "cmdRetry"
        Me.cmdRetry.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.cmdRetry.Size = New System.Drawing.Size(145, 66)
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
        Me.dgvSensors.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSensors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSensors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.check, Me.ss1, Me.sensorType, Me.port})
        Me.dgvSensors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvSensors.Location = New System.Drawing.Point(15, 12)
        Me.dgvSensors.Margin = New System.Windows.Forms.Padding(6)
        Me.dgvSensors.MultiSelect = False
        Me.dgvSensors.Name = "dgvSensors"
        Me.dgvSensors.RowHeadersVisible = False
        Me.dgvSensors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSensors.Size = New System.Drawing.Size(519, 220)
        Me.dgvSensors.TabIndex = 30
        '
        'check
        '
        Me.check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.check.HeaderText = "Select"
        Me.check.Name = "check"
        Me.check.ReadOnly = True
        Me.check.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.check.Width = 87
        '
        'ss1
        '
        Me.ss1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ss1.HeaderText = "Name"
        Me.ss1.Name = "ss1"
        Me.ss1.ReadOnly = True
        Me.ss1.Width = 86
        '
        'sensorType
        '
        Me.sensorType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.sensorType.HeaderText = "Type"
        Me.sensorType.Name = "sensorType"
        Me.sensorType.ReadOnly = True
        Me.sensorType.Width = 78
        '
        'port
        '
        Me.port.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.port.HeaderText = "Port"
        Me.port.Name = "port"
        Me.port.ReadOnly = True
        '
        'Timer1
        '
        '
        'cmdPutty
        '
        Me.cmdPutty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPutty.Image = CType(resources.GetObject("cmdPutty.Image"), System.Drawing.Image)
        Me.cmdPutty.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdPutty.Location = New System.Drawing.Point(15, 246)
        Me.cmdPutty.Name = "cmdPutty"
        Me.cmdPutty.Size = New System.Drawing.Size(145, 78)
        Me.cmdPutty.TabIndex = 33
        Me.cmdPutty.Text = "&PuTTY Terminal Program..."
        Me.cmdPutty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdPutty.UseVisualStyleBackColor = True
        '
        'cmdDeviceManager
        '
        Me.cmdDeviceManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeviceManager.Image = Global.LoadVUE.My.Resources.Resources.wrench_settings2
        Me.cmdDeviceManager.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdDeviceManager.Location = New System.Drawing.Point(166, 246)
        Me.cmdDeviceManager.Name = "cmdDeviceManager"
        Me.cmdDeviceManager.Size = New System.Drawing.Size(145, 78)
        Me.cmdDeviceManager.TabIndex = 34
        Me.cmdDeviceManager.Text = "&Device Manager"
        Me.cmdDeviceManager.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdDeviceManager.UseVisualStyleBackColor = True
        '
        'frmDetectLv100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(708, 376)
        Me.Controls.Add(Me.cmdDeviceManager)
        Me.Controls.Add(Me.cmdPutty)
        Me.Controls.Add(Me.dgvSensors)
        Me.Controls.Add(Me.cmdRetry)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDetectLv100"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "..."
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvSensors, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmdPutty As System.Windows.Forms.Button
    Friend WithEvents check As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ss1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sensorType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents port As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdDeviceManager As System.Windows.Forms.Button
End Class
