<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPunchCounterOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.udPunchInterval = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlAutostop = New System.Windows.Forms.Panel()
        Me.udSeconds = New System.Windows.Forms.NumericUpDown()
        Me.udMinutes = New System.Windows.Forms.NumericUpDown()
        Me.chkAutostop = New System.Windows.Forms.CheckBox()
        Me.txtPunchThreshold = New System.Windows.Forms.TextBox()
        Me.chkTimerFirstPunch = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbSensor = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grpSettings = New System.Windows.Forms.GroupBox()
        CType(Me.udPunchInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAutostop.SuspendLayout()
        CType(Me.udSeconds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udMinutes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Enabled = False
        Me.cmdOK.Image = Global.LoadVUE.My.Resources.Resources.ok
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(444, 325)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(149, 42)
        Me.cmdOK.TabIndex = 6
        Me.cmdOK.Text = "OK"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Image = Global.LoadVUE.My.Resources.Resources.cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(604, 325)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(149, 42)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(572, 81)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 25)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "milliseconds"
        '
        'udPunchInterval
        '
        Me.udPunchInterval.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udPunchInterval.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.udPunchInterval.Location = New System.Drawing.Point(466, 79)
        Me.udPunchInterval.Margin = New System.Windows.Forms.Padding(6)
        Me.udPunchInterval.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.udPunchInterval.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.udPunchInterval.Name = "udPunchInterval"
        Me.udPunchInterval.Size = New System.Drawing.Size(94, 33)
        Me.udPunchInterval.TabIndex = 4
        Me.udPunchInterval.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(22, 81)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(401, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ignore if interval between punches is less than"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(22, 31)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(387, 25)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Minimum force to be considered as a punch:"
        '
        'pnlAutostop
        '
        Me.pnlAutostop.BackColor = System.Drawing.SystemColors.Control
        Me.pnlAutostop.Controls.Add(Me.udSeconds)
        Me.pnlAutostop.Controls.Add(Me.udMinutes)
        Me.pnlAutostop.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlAutostop.Location = New System.Drawing.Point(396, 132)
        Me.pnlAutostop.Margin = New System.Windows.Forms.Padding(6)
        Me.pnlAutostop.Name = "pnlAutostop"
        Me.pnlAutostop.Size = New System.Drawing.Size(233, 40)
        Me.pnlAutostop.TabIndex = 82
        '
        'udSeconds
        '
        Me.udSeconds.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udSeconds.Location = New System.Drawing.Point(114, 0)
        Me.udSeconds.Margin = New System.Windows.Forms.Padding(6)
        Me.udSeconds.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.udSeconds.Name = "udSeconds"
        Me.udSeconds.Size = New System.Drawing.Size(103, 29)
        Me.udSeconds.TabIndex = 1
        Me.udSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'udMinutes
        '
        Me.udMinutes.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udMinutes.Location = New System.Drawing.Point(0, 0)
        Me.udMinutes.Margin = New System.Windows.Forms.Padding(6)
        Me.udMinutes.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.udMinutes.Name = "udMinutes"
        Me.udMinutes.Size = New System.Drawing.Size(103, 29)
        Me.udMinutes.TabIndex = 0
        Me.udMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkAutostop
        '
        Me.chkAutostop.AutoSize = True
        Me.chkAutostop.BackColor = System.Drawing.Color.Transparent
        Me.chkAutostop.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutostop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAutostop.Location = New System.Drawing.Point(28, 132)
        Me.chkAutostop.Margin = New System.Windows.Forms.Padding(6)
        Me.chkAutostop.Name = "chkAutostop"
        Me.chkAutostop.Size = New System.Drawing.Size(305, 29)
        Me.chkAutostop.TabIndex = 83
        Me.chkAutostop.Text = "Automatically stop reading after:"
        Me.chkAutostop.UseVisualStyleBackColor = False
        '
        'txtPunchThreshold
        '
        Me.txtPunchThreshold.BackColor = System.Drawing.Color.White
        Me.txtPunchThreshold.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPunchThreshold.Location = New System.Drawing.Point(466, 25)
        Me.txtPunchThreshold.Margin = New System.Windows.Forms.Padding(6)
        Me.txtPunchThreshold.Name = "txtPunchThreshold"
        Me.txtPunchThreshold.Size = New System.Drawing.Size(147, 33)
        Me.txtPunchThreshold.TabIndex = 85
        Me.txtPunchThreshold.TabStop = False
        '
        'chkTimerFirstPunch
        '
        Me.chkTimerFirstPunch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTimerFirstPunch.BackColor = System.Drawing.Color.Transparent
        Me.chkTimerFirstPunch.Enabled = False
        Me.chkTimerFirstPunch.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTimerFirstPunch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkTimerFirstPunch.Location = New System.Drawing.Point(28, 181)
        Me.chkTimerFirstPunch.Margin = New System.Windows.Forms.Padding(6)
        Me.chkTimerFirstPunch.Name = "chkTimerFirstPunch"
        Me.chkTimerFirstPunch.Size = New System.Drawing.Size(434, 29)
        Me.chkTimerFirstPunch.TabIndex = 86
        Me.chkTimerFirstPunch.Text = "Start the timer only after the first punch"
        Me.chkTimerFirstPunch.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(627, 31)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 25)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "lbf"
        '
        'cmbSensor
        '
        Me.cmbSensor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSensor.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSensor.FormattingEnabled = True
        Me.cmbSensor.Location = New System.Drawing.Point(379, 33)
        Me.cmbSensor.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbSensor.Name = "cmbSensor"
        Me.cmbSensor.Size = New System.Drawing.Size(323, 33)
        Me.cmbSensor.TabIndex = 89
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(38, 39)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(283, 25)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Count punches from this sensor:"
        '
        'grpSettings
        '
        Me.grpSettings.Controls.Add(Me.Label4)
        Me.grpSettings.Controls.Add(Me.chkTimerFirstPunch)
        Me.grpSettings.Controls.Add(Me.txtPunchThreshold)
        Me.grpSettings.Controls.Add(Me.chkAutostop)
        Me.grpSettings.Controls.Add(Me.pnlAutostop)
        Me.grpSettings.Controls.Add(Me.Label2)
        Me.grpSettings.Controls.Add(Me.Label3)
        Me.grpSettings.Controls.Add(Me.udPunchInterval)
        Me.grpSettings.Controls.Add(Me.Label1)
        Me.grpSettings.Location = New System.Drawing.Point(16, 83)
        Me.grpSettings.Margin = New System.Windows.Forms.Padding(6)
        Me.grpSettings.Name = "grpSettings"
        Me.grpSettings.Padding = New System.Windows.Forms.Padding(6)
        Me.grpSettings.Size = New System.Drawing.Size(737, 230)
        Me.grpSettings.TabIndex = 90
        Me.grpSettings.TabStop = False
        '
        'frmPunchCounterOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 380)
        Me.Controls.Add(Me.grpSettings)
        Me.Controls.Add(Me.cmbSensor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPunchCounterOptions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Punch Counter Settings"
        CType(Me.udPunchInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAutostop.ResumeLayout(False)
        CType(Me.udSeconds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udMinutes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSettings.ResumeLayout(False)
        Me.grpSettings.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents udPunchInterval As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlAutostop As System.Windows.Forms.Panel
    Friend WithEvents udSeconds As System.Windows.Forms.NumericUpDown
    Friend WithEvents udMinutes As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkAutostop As System.Windows.Forms.CheckBox
    Friend WithEvents txtPunchThreshold As System.Windows.Forms.TextBox
    Friend WithEvents chkTimerFirstPunch As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbSensor As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grpSettings As System.Windows.Forms.GroupBox

End Class
