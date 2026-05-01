<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPunchForce
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPunchForce))
        Me.TimerAutoStop = New System.Windows.Forms.Timer(Me.components)
        Me.TimerDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.pnlTimer = New System.Windows.Forms.Panel()
        Me.lblElapsedTime = New System.Windows.Forms.Label()
        Me.lblUnits2 = New System.Windows.Forms.Label()
        Me.txtLastPunch = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.pnlSensors = New System.Windows.Forms.Panel()
        Me.dgvPunches = New System.Windows.Forms.DataGridView()
        Me.colIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colForce = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.lblUnits1 = New System.Windows.Forms.Label()
        Me.lblUnits0 = New System.Windows.Forms.Label()
        Me.cmdPunchForceOptions = New System.Windows.Forms.Button()
        Me.txtAverageF = New System.Windows.Forms.TextBox()
        Me.txtPunchRateMin = New System.Windows.Forms.TextBox()
        Me.txtPeakLoad = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNPunch = New System.Windows.Forms.TextBox()
        Me.cmdTare = New System.Windows.Forms.Button()
        Me.lblNPunch = New System.Windows.Forms.Label()
        Me.pnlTimer.SuspendLayout()
        Me.pnlLeft.SuspendLayout()
        Me.pnlSensors.SuspendLayout()
        CType(Me.dgvPunches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'TimerAutoStop
        '
        '
        'TimerDisplay
        '
        Me.TimerDisplay.Interval = 1000
        '
        'pnlTimer
        '
        Me.pnlTimer.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlTimer.Controls.Add(Me.lblElapsedTime)
        Me.pnlTimer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlTimer.Location = New System.Drawing.Point(0, 226)
        Me.pnlTimer.Name = "pnlTimer"
        Me.pnlTimer.Size = New System.Drawing.Size(366, 90)
        Me.pnlTimer.TabIndex = 71
        '
        'lblElapsedTime
        '
        Me.lblElapsedTime.BackColor = System.Drawing.Color.Transparent
        Me.lblElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblElapsedTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblElapsedTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblElapsedTime.ForeColor = System.Drawing.Color.Black
        Me.lblElapsedTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblElapsedTime.Location = New System.Drawing.Point(0, 0)
        Me.lblElapsedTime.Name = "lblElapsedTime"
        Me.lblElapsedTime.Size = New System.Drawing.Size(366, 90)
        Me.lblElapsedTime.TabIndex = 63
        Me.lblElapsedTime.Text = "0:00"
        Me.lblElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblElapsedTime.Visible = False
        '
        'lblUnits2
        '
        Me.lblUnits2.AutoSize = True
        Me.lblUnits2.BackColor = System.Drawing.Color.Transparent
        Me.lblUnits2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnits2.Location = New System.Drawing.Point(318, 18)
        Me.lblUnits2.Name = "lblUnits2"
        Me.lblUnits2.Size = New System.Drawing.Size(30, 25)
        Me.lblUnits2.TabIndex = 69
        Me.lblUnits2.Text = "..."
        '
        'txtLastPunch
        '
        Me.txtLastPunch.BackColor = System.Drawing.Color.White
        Me.txtLastPunch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastPunch.Location = New System.Drawing.Point(237, 15)
        Me.txtLastPunch.Name = "txtLastPunch"
        Me.txtLastPunch.ReadOnly = True
        Me.txtLastPunch.Size = New System.Drawing.Size(70, 31)
        Me.txtLastPunch.TabIndex = 1
        Me.txtLastPunch.TabStop = False
        Me.txtLastPunch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(187, 25)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Last Punch Force:"
        '
        'pnlLeft
        '
        Me.pnlLeft.Controls.Add(Me.pnlSensors)
        Me.pnlLeft.Controls.Add(Me.pnlButtons)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(366, 702)
        Me.pnlLeft.TabIndex = 2
        '
        'pnlSensors
        '
        Me.pnlSensors.AutoScroll = True
        Me.pnlSensors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSensors.Controls.Add(Me.dgvPunches)
        Me.pnlSensors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSensors.Location = New System.Drawing.Point(0, 316)
        Me.pnlSensors.Name = "pnlSensors"
        Me.pnlSensors.Size = New System.Drawing.Size(366, 386)
        Me.pnlSensors.TabIndex = 1
        '
        'dgvPunches
        '
        Me.dgvPunches.AllowUserToAddRows = False
        Me.dgvPunches.AllowUserToDeleteRows = False
        Me.dgvPunches.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPunches.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPunches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPunches.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvPunches.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPunches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPunches.ColumnHeadersVisible = False
        Me.dgvPunches.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIndex, Me.colTime, Me.colForce})
        Me.dgvPunches.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPunches.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvPunches.Location = New System.Drawing.Point(0, 0)
        Me.dgvPunches.MultiSelect = False
        Me.dgvPunches.Name = "dgvPunches"
        Me.dgvPunches.ReadOnly = True
        Me.dgvPunches.RowHeadersVisible = False
        Me.dgvPunches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPunches.Size = New System.Drawing.Size(362, 382)
        Me.dgvPunches.TabIndex = 0
        '
        'colIndex
        '
        Me.colIndex.HeaderText = "No."
        Me.colIndex.Name = "colIndex"
        Me.colIndex.ReadOnly = True
        Me.colIndex.Width = 5
        '
        'colTime
        '
        Me.colTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTime.HeaderText = "Elapsed Time (sec)"
        Me.colTime.Name = "colTime"
        Me.colTime.ReadOnly = True
        Me.colTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colTime.Width = 5
        '
        'colForce
        '
        Me.colForce.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colForce.HeaderText = "Punch Force"
        Me.colForce.Name = "colForce"
        Me.colForce.ReadOnly = True
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.pnlTimer)
        Me.pnlButtons.Controls.Add(Me.lblUnits2)
        Me.pnlButtons.Controls.Add(Me.txtLastPunch)
        Me.pnlButtons.Controls.Add(Me.Label4)
        Me.pnlButtons.Controls.Add(Me.lblUnits1)
        Me.pnlButtons.Controls.Add(Me.lblUnits0)
        Me.pnlButtons.Controls.Add(Me.cmdPunchForceOptions)
        Me.pnlButtons.Controls.Add(Me.txtAverageF)
        Me.pnlButtons.Controls.Add(Me.txtPunchRateMin)
        Me.pnlButtons.Controls.Add(Me.txtPeakLoad)
        Me.pnlButtons.Controls.Add(Me.Label3)
        Me.pnlButtons.Controls.Add(Me.Label2)
        Me.pnlButtons.Controls.Add(Me.Label1)
        Me.pnlButtons.Controls.Add(Me.txtNPunch)
        Me.pnlButtons.Controls.Add(Me.cmdTare)
        Me.pnlButtons.Controls.Add(Me.lblNPunch)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButtons.Location = New System.Drawing.Point(0, 0)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(366, 316)
        Me.pnlButtons.TabIndex = 0
        '
        'lblUnits1
        '
        Me.lblUnits1.AutoSize = True
        Me.lblUnits1.BackColor = System.Drawing.Color.Transparent
        Me.lblUnits1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnits1.Location = New System.Drawing.Point(318, 104)
        Me.lblUnits1.Name = "lblUnits1"
        Me.lblUnits1.Size = New System.Drawing.Size(30, 25)
        Me.lblUnits1.TabIndex = 62
        Me.lblUnits1.Text = "..."
        '
        'lblUnits0
        '
        Me.lblUnits0.AutoSize = True
        Me.lblUnits0.BackColor = System.Drawing.Color.Transparent
        Me.lblUnits0.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnits0.Location = New System.Drawing.Point(318, 61)
        Me.lblUnits0.Name = "lblUnits0"
        Me.lblUnits0.Size = New System.Drawing.Size(30, 25)
        Me.lblUnits0.TabIndex = 61
        Me.lblUnits0.Text = "..."
        '
        'cmdPunchForceOptions
        '
        Me.cmdPunchForceOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPunchForceOptions.Image = Global.LoadVUE.My.Resources.Resources.wrench_settings2
        Me.cmdPunchForceOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPunchForceOptions.Location = New System.Drawing.Point(629, 46)
        Me.cmdPunchForceOptions.Name = "cmdPunchForceOptions"
        Me.cmdPunchForceOptions.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdPunchForceOptions.Size = New System.Drawing.Size(132, 35)
        Me.cmdPunchForceOptions.TabIndex = 7
        Me.cmdPunchForceOptions.Text = "Options..."
        Me.cmdPunchForceOptions.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPunchForceOptions.UseVisualStyleBackColor = True
        Me.cmdPunchForceOptions.Visible = False
        '
        'txtAverageF
        '
        Me.txtAverageF.BackColor = System.Drawing.Color.White
        Me.txtAverageF.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAverageF.Location = New System.Drawing.Point(237, 101)
        Me.txtAverageF.Name = "txtAverageF"
        Me.txtAverageF.ReadOnly = True
        Me.txtAverageF.Size = New System.Drawing.Size(70, 31)
        Me.txtAverageF.TabIndex = 3
        Me.txtAverageF.TabStop = False
        Me.txtAverageF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPunchRateMin
        '
        Me.txtPunchRateMin.BackColor = System.Drawing.Color.White
        Me.txtPunchRateMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPunchRateMin.Location = New System.Drawing.Point(237, 187)
        Me.txtPunchRateMin.Name = "txtPunchRateMin"
        Me.txtPunchRateMin.ReadOnly = True
        Me.txtPunchRateMin.Size = New System.Drawing.Size(70, 31)
        Me.txtPunchRateMin.TabIndex = 5
        Me.txtPunchRateMin.TabStop = False
        Me.txtPunchRateMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPeakLoad
        '
        Me.txtPeakLoad.BackColor = System.Drawing.Color.White
        Me.txtPeakLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeakLoad.Location = New System.Drawing.Point(237, 58)
        Me.txtPeakLoad.Name = "txtPeakLoad"
        Me.txtPeakLoad.ReadOnly = True
        Me.txtPeakLoad.Size = New System.Drawing.Size(70, 31)
        Me.txtPeakLoad.TabIndex = 2
        Me.txtPeakLoad.TabStop = False
        Me.txtPeakLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(226, 25)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "Average Punch Force:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 25)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Peak Punch Force:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 190)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 25)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Punches / min:"
        '
        'txtNPunch
        '
        Me.txtNPunch.BackColor = System.Drawing.Color.White
        Me.txtNPunch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNPunch.Location = New System.Drawing.Point(237, 144)
        Me.txtNPunch.Name = "txtNPunch"
        Me.txtNPunch.ReadOnly = True
        Me.txtNPunch.Size = New System.Drawing.Size(70, 31)
        Me.txtNPunch.TabIndex = 4
        Me.txtNPunch.TabStop = False
        Me.txtNPunch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdTare
        '
        Me.cmdTare.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTare.Image = Global.LoadVUE.My.Resources.Resources.tare_20
        Me.cmdTare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdTare.Location = New System.Drawing.Point(530, 46)
        Me.cmdTare.Name = "cmdTare"
        Me.cmdTare.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdTare.Size = New System.Drawing.Size(91, 35)
        Me.cmdTare.TabIndex = 6
        Me.cmdTare.Text = "Zero"
        Me.cmdTare.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdTare.UseVisualStyleBackColor = True
        Me.cmdTare.Visible = False
        '
        'lblNPunch
        '
        Me.lblNPunch.AutoSize = True
        Me.lblNPunch.BackColor = System.Drawing.Color.Transparent
        Me.lblNPunch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNPunch.Location = New System.Drawing.Point(7, 147)
        Me.lblNPunch.Name = "lblNPunch"
        Me.lblNPunch.Size = New System.Drawing.Size(165, 25)
        Me.lblNPunch.TabIndex = 49
        Me.lblNPunch.Text = "No. of Punches:"
        '
        'frmPunchForce
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 702)
        Me.Controls.Add(Me.pnlLeft)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "frmPunchForce"
        Me.Text = "Punch Force Counter"
        Me.pnlTimer.ResumeLayout(False)
        Me.pnlLeft.ResumeLayout(False)
        Me.pnlSensors.ResumeLayout(False)
        CType(Me.dgvPunches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlButtons.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TimerAutoStop As Timer
    Friend WithEvents TimerDisplay As Timer
    Friend WithEvents pnlTimer As Panel
    Friend WithEvents lblElapsedTime As Label
    Friend WithEvents lblUnits2 As Label
    Friend WithEvents txtLastPunch As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents pnlSensors As Panel
    Friend WithEvents dgvPunches As DataGridView
    Friend WithEvents colIndex As DataGridViewTextBoxColumn
    Friend WithEvents colTime As DataGridViewTextBoxColumn
    Friend WithEvents colForce As DataGridViewTextBoxColumn
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents lblUnits1 As Label
    Friend WithEvents lblUnits0 As Label
    Friend WithEvents txtAverageF As TextBox
    Friend WithEvents txtPunchRateMin As TextBox
    Friend WithEvents txtPeakLoad As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNPunch As TextBox
    Friend WithEvents lblNPunch As Label
    Friend WithEvents cmdPunchForceOptions As Button
    Friend WithEvents cmdTare As Button
End Class
