<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlFilter
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtJumpThreshold = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.udWindowSize = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbFilterType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cmbSensor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlFilter.SuspendLayout()
        CType(Me.udWindowSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlFilter
        '
        Me.pnlFilter.Controls.Add(Me.Label8)
        Me.pnlFilter.Controls.Add(Me.Label7)
        Me.pnlFilter.Controls.Add(Me.Label6)
        Me.pnlFilter.Controls.Add(Me.txtJumpThreshold)
        Me.pnlFilter.Controls.Add(Me.Label5)
        Me.pnlFilter.Controls.Add(Me.udWindowSize)
        Me.pnlFilter.Controls.Add(Me.Label4)
        Me.pnlFilter.Controls.Add(Me.cmbFilterType)
        Me.pnlFilter.Controls.Add(Me.Label3)
        Me.pnlFilter.Controls.Add(Me.Label1)
        Me.pnlFilter.Controls.Add(Me.txtName)
        Me.pnlFilter.Controls.Add(Me.cmbSensor)
        Me.pnlFilter.Controls.Add(Me.Label2)
        Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(443, 266)
        Me.pnlFilter.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(245, 166)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(153, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "(Applies only to averaging filter)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(208, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(225, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "(For median filter, must be an odd number >=3)"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(129, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(258, 61)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Specify in same units as the sensor to apply filter on, ex. lb, mm etc. Readings " &
    "will be averaged as long as a change in value remains below this threshold."
        '
        'txtJumpThreshold
        '
        Me.txtJumpThreshold.Location = New System.Drawing.Point(132, 163)
        Me.txtJumpThreshold.MaxLength = 20
        Me.txtJumpThreshold.Name = "txtJumpThreshold"
        Me.txtJumpThreshold.Size = New System.Drawing.Size(107, 20)
        Me.txtJumpThreshold.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "&Filter Threshold:"
        '
        'udWindowSize
        '
        Me.udWindowSize.Location = New System.Drawing.Point(132, 127)
        Me.udWindowSize.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.udWindowSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udWindowSize.Name = "udWindowSize"
        Me.udWindowSize.Size = New System.Drawing.Size(74, 20)
        Me.udWindowSize.TabIndex = 15
        Me.udWindowSize.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "&Window Size:"
        '
        'cmbFilterType
        '
        Me.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterType.FormattingEnabled = True
        Me.cmbFilterType.Items.AddRange(New Object() {"Average", "Median"})
        Me.cmbFilterType.Location = New System.Drawing.Point(132, 88)
        Me.cmbFilterType.Name = "cmbFilterType"
        Me.cmbFilterType.Size = New System.Drawing.Size(178, 21)
        Me.cmbFilterType.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "&Filter Type:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "&Name:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(132, 11)
        Me.txtName.MaxLength = 20
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(107, 20)
        Me.txtName.TabIndex = 10
        '
        'cmbSensor
        '
        Me.cmbSensor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSensor.FormattingEnabled = True
        Me.cmbSensor.Location = New System.Drawing.Point(132, 49)
        Me.cmbSensor.Name = "cmbSensor"
        Me.cmbSensor.Size = New System.Drawing.Size(178, 21)
        Me.cmbSensor.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "&Sensor to apply filter on:"
        '
        'ctlFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlFilter)
        Me.Name = "ctlFilter"
        Me.Size = New System.Drawing.Size(458, 274)
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        CType(Me.udWindowSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents cmbSensor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents udWindowSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbFilterType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtJumpThreshold As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
