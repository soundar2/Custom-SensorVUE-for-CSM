<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlRelayCommand
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblUnits = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbAction = New System.Windows.Forms.ComboBox
        Me.cmbCondition = New System.Windows.Forms.ComboBox
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.pnlCondition = New System.Windows.Forms.Panel
        Me.lblIndex = New System.Windows.Forms.Label
        Me.pnlCommand = New System.Windows.Forms.Panel
        Me.pnlValue = New System.Windows.Forms.Panel
        Me.lblSeconds = New System.Windows.Forms.Label
        Me.chkEnabled = New System.Windows.Forms.CheckBox
        Me.pnlCondition.SuspendLayout()
        Me.pnlCommand.SuspendLayout()
        Me.pnlValue.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Action:"
        '
        'lblUnits
        '
        Me.lblUnits.AutoSize = True
        Me.lblUnits.Location = New System.Drawing.Point(89, 13)
        Me.lblUnits.Name = "lblUnits"
        Me.lblUnits.Size = New System.Drawing.Size(29, 13)
        Me.lblUnits.TabIndex = 1
        Me.lblUnits.Text = "units"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "value"
        '
        'cmbAction
        '
        Me.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAction.FormattingEnabled = True
        Me.cmbAction.Items.AddRange(New Object() {"Wait until", "ON", "OFF", "Delay"})
        Me.cmbAction.Location = New System.Drawing.Point(77, 7)
        Me.cmbAction.Name = "cmbAction"
        Me.cmbAction.Size = New System.Drawing.Size(121, 21)
        Me.cmbAction.TabIndex = 5
        '
        'cmbCondition
        '
        Me.cmbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition.FormattingEnabled = True
        Me.cmbCondition.Items.AddRange(New Object() {">=", "<="})
        Me.cmbCondition.Location = New System.Drawing.Point(49, 8)
        Me.cmbCondition.Name = "cmbCondition"
        Me.cmbCondition.Size = New System.Drawing.Size(69, 21)
        Me.cmbCondition.TabIndex = 6
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(8, 8)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(75, 20)
        Me.txtValue.TabIndex = 7
        '
        'pnlCondition
        '
        Me.pnlCondition.Controls.Add(Me.cmbCondition)
        Me.pnlCondition.Controls.Add(Me.Label3)
        Me.pnlCondition.Location = New System.Drawing.Point(205, -1)
        Me.pnlCondition.Name = "pnlCondition"
        Me.pnlCondition.Size = New System.Drawing.Size(125, 38)
        Me.pnlCondition.TabIndex = 8
        '
        'lblIndex
        '
        Me.lblIndex.AutoSize = True
        Me.lblIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIndex.Location = New System.Drawing.Point(3, 10)
        Me.lblIndex.Name = "lblIndex"
        Me.lblIndex.Size = New System.Drawing.Size(25, 13)
        Me.lblIndex.TabIndex = 9
        Me.lblIndex.Text = "10."
        Me.lblIndex.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'pnlCommand
        '
        Me.pnlCommand.Controls.Add(Me.pnlValue)
        Me.pnlCommand.Controls.Add(Me.lblIndex)
        Me.pnlCommand.Controls.Add(Me.pnlCondition)
        Me.pnlCommand.Controls.Add(Me.cmbAction)
        Me.pnlCommand.Controls.Add(Me.Label1)
        Me.pnlCommand.Location = New System.Drawing.Point(23, -1)
        Me.pnlCommand.Name = "pnlCommand"
        Me.pnlCommand.Size = New System.Drawing.Size(483, 40)
        Me.pnlCommand.TabIndex = 10
        '
        'pnlValue
        '
        Me.pnlValue.Controls.Add(Me.lblSeconds)
        Me.pnlValue.Controls.Add(Me.txtValue)
        Me.pnlValue.Controls.Add(Me.lblUnits)
        Me.pnlValue.Location = New System.Drawing.Point(335, -1)
        Me.pnlValue.Name = "pnlValue"
        Me.pnlValue.Size = New System.Drawing.Size(149, 39)
        Me.pnlValue.TabIndex = 11
        '
        'lblSeconds
        '
        Me.lblSeconds.AutoSize = True
        Me.lblSeconds.Location = New System.Drawing.Point(89, 12)
        Me.lblSeconds.Name = "lblSeconds"
        Me.lblSeconds.Size = New System.Drawing.Size(47, 13)
        Me.lblSeconds.TabIndex = 10
        Me.lblSeconds.Text = "seconds"
        Me.lblSeconds.Visible = False
        '
        'chkEnabled
        '
        Me.chkEnabled.AutoSize = True
        Me.chkEnabled.Location = New System.Drawing.Point(3, 15)
        Me.chkEnabled.Name = "chkEnabled"
        Me.chkEnabled.Size = New System.Drawing.Size(15, 14)
        Me.chkEnabled.TabIndex = 11
        Me.chkEnabled.UseVisualStyleBackColor = True
        '
        'ctlRelayCommand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.chkEnabled)
        Me.Controls.Add(Me.pnlCommand)
        Me.Name = "ctlRelayCommand"
        Me.Size = New System.Drawing.Size(540, 34)
        Me.pnlCondition.ResumeLayout(False)
        Me.pnlCondition.PerformLayout()
        Me.pnlCommand.ResumeLayout(False)
        Me.pnlCommand.PerformLayout()
        Me.pnlValue.ResumeLayout(False)
        Me.pnlValue.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUnits As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbAction As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCondition As System.Windows.Forms.ComboBox
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents pnlCondition As System.Windows.Forms.Panel
    Friend WithEvents lblIndex As System.Windows.Forms.Label
    Friend WithEvents pnlCommand As System.Windows.Forms.Panel
    Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents lblSeconds As System.Windows.Forms.Label
    Friend WithEvents pnlValue As System.Windows.Forms.Panel

End Class
