<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSensorStartupParam
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
        Me.cmdApply = New System.Windows.Forms.Button
        Me.txtParam = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbSensors = New System.Windows.Forms.ComboBox
        Me.lblSensor = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdApply
        '
        Me.cmdApply.Image = Global.LoadVUE.My.Resources.Resources.ok
        Me.cmdApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdApply.Location = New System.Drawing.Point(170, 274)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(79, 36)
        Me.cmdApply.TabIndex = 10
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'txtParam
        '
        Me.txtParam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtParam.Location = New System.Drawing.Point(12, 93)
        Me.txtParam.Multiline = True
        Me.txtParam.Name = "txtParam"
        Me.txtParam.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtParam.Size = New System.Drawing.Size(237, 162)
        Me.txtParam.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Burn these parameters on startup."
        '
        'cmbSensors
        '
        Me.cmbSensors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSensors.FormattingEnabled = True
        Me.cmbSensors.Items.AddRange(New Object() {"Greater than", "Less than"})
        Me.cmbSensors.Location = New System.Drawing.Point(61, 54)
        Me.cmbSensors.Name = "cmbSensors"
        Me.cmbSensors.Size = New System.Drawing.Size(157, 21)
        Me.cmbSensors.TabIndex = 59
        '
        'lblSensor
        '
        Me.lblSensor.AutoSize = True
        Me.lblSensor.Location = New System.Drawing.Point(12, 57)
        Me.lblSensor.Name = "lblSensor"
        Me.lblSensor.Size = New System.Drawing.Size(43, 13)
        Me.lblSensor.TabIndex = 60
        Me.lblSensor.Text = "Sensor:"
        Me.lblSensor.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmSensorStartupParam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(261, 322)
        Me.Controls.Add(Me.cmbSensors)
        Me.Controls.Add(Me.lblSensor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtParam)
        Me.Controls.Add(Me.cmdApply)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSensorStartupParam"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sensor Parameters"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents txtParam As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbSensors As System.Windows.Forms.ComboBox
    Friend WithEvents lblSensor As System.Windows.Forms.Label
End Class
