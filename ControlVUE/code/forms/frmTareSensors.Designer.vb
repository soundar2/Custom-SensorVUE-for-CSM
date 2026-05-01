<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTareSensors
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
        Me.cmdTareAll = New System.Windows.Forms.Button()
        Me.cmdTareLoad = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdTareDisp = New System.Windows.Forms.Button()
        Me.cmdTareTorque = New System.Windows.Forms.Button()
        Me.cmdTarePressure = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdTareILevel = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdTareVoltage = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdTareAll
        '
        Me.cmdTareAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTareAll.Image = Global.LoadVUE.My.Resources.Resources.tare_32x32
        Me.cmdTareAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdTareAll.Location = New System.Drawing.Point(32, 414)
        Me.cmdTareAll.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdTareAll.Name = "cmdTareAll"
        Me.cmdTareAll.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.cmdTareAll.Size = New System.Drawing.Size(155, 50)
        Me.cmdTareAll.TabIndex = 14
        Me.cmdTareAll.Text = "Zero &All"
        Me.cmdTareAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdTareAll.UseVisualStyleBackColor = True
        '
        'cmdTareLoad
        '
        Me.cmdTareLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTareLoad.Image = Global.LoadVUE.My.Resources.Resources.tare_32x32
        Me.cmdTareLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdTareLoad.Location = New System.Drawing.Point(248, 20)
        Me.cmdTareLoad.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdTareLoad.Name = "cmdTareLoad"
        Me.cmdTareLoad.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.cmdTareLoad.Size = New System.Drawing.Size(123, 48)
        Me.cmdTareLoad.TabIndex = 16
        Me.cmdTareLoad.Text = "Zero"
        Me.cmdTareLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdTareLoad.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 24)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Load Sensors"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 24)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Torque Sensors"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 231)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 24)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Pressure Sensors"
        '
        'cmdTareDisp
        '
        Me.cmdTareDisp.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTareDisp.Image = Global.LoadVUE.My.Resources.Resources.tare_32x32
        Me.cmdTareDisp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdTareDisp.Location = New System.Drawing.Point(248, 87)
        Me.cmdTareDisp.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdTareDisp.Name = "cmdTareDisp"
        Me.cmdTareDisp.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.cmdTareDisp.Size = New System.Drawing.Size(123, 48)
        Me.cmdTareDisp.TabIndex = 23
        Me.cmdTareDisp.Text = "Zero"
        Me.cmdTareDisp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdTareDisp.UseVisualStyleBackColor = True
        '
        'cmdTareTorque
        '
        Me.cmdTareTorque.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTareTorque.Image = Global.LoadVUE.My.Resources.Resources.tare_32x32
        Me.cmdTareTorque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdTareTorque.Location = New System.Drawing.Point(248, 152)
        Me.cmdTareTorque.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdTareTorque.Name = "cmdTareTorque"
        Me.cmdTareTorque.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.cmdTareTorque.Size = New System.Drawing.Size(123, 48)
        Me.cmdTareTorque.TabIndex = 24
        Me.cmdTareTorque.Text = "Zero"
        Me.cmdTareTorque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdTareTorque.UseVisualStyleBackColor = True
        '
        'cmdTarePressure
        '
        Me.cmdTarePressure.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTarePressure.Image = Global.LoadVUE.My.Resources.Resources.tare_32x32
        Me.cmdTarePressure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdTarePressure.Location = New System.Drawing.Point(248, 217)
        Me.cmdTarePressure.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdTarePressure.Name = "cmdTarePressure"
        Me.cmdTarePressure.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.cmdTarePressure.Size = New System.Drawing.Size(123, 48)
        Me.cmdTarePressure.TabIndex = 25
        Me.cmdTarePressure.Text = "Zero"
        Me.cmdTarePressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdTarePressure.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(198, 24)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Displacement Sensors"
        '
        'cmdTareILevel
        '
        Me.cmdTareILevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTareILevel.Image = Global.LoadVUE.My.Resources.Resources.tare_32x32
        Me.cmdTareILevel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdTareILevel.Location = New System.Drawing.Point(248, 282)
        Me.cmdTareILevel.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdTareILevel.Name = "cmdTareILevel"
        Me.cmdTareILevel.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.cmdTareILevel.Size = New System.Drawing.Size(123, 48)
        Me.cmdTareILevel.TabIndex = 26
        Me.cmdTareILevel.Text = "Zero"
        Me.cmdTareILevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdTareILevel.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 296)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 24)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "iLevel Sensors"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(205, 414)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Padding = New System.Windows.Forms.Padding(20, 0, 20, 0)
        Me.cmdCancel.Size = New System.Drawing.Size(155, 50)
        Me.cmdCancel.TabIndex = 27
        Me.cmdCancel.Text = "Close"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 359)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 24)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Voltage Sensors"
        '
        'cmdTareVoltage
        '
        Me.cmdTareVoltage.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTareVoltage.Image = Global.LoadVUE.My.Resources.Resources.tare_32x32
        Me.cmdTareVoltage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdTareVoltage.Location = New System.Drawing.Point(248, 345)
        Me.cmdTareVoltage.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdTareVoltage.Name = "cmdTareVoltage"
        Me.cmdTareVoltage.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.cmdTareVoltage.Size = New System.Drawing.Size(123, 48)
        Me.cmdTareVoltage.TabIndex = 29
        Me.cmdTareVoltage.Text = "Zero"
        Me.cmdTareVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdTareVoltage.UseVisualStyleBackColor = True
        '
        'frmTareSensors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 498)
        Me.Controls.Add(Me.cmdTareVoltage)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdTareILevel)
        Me.Controls.Add(Me.cmdTarePressure)
        Me.Controls.Add(Me.cmdTareTorque)
        Me.Controls.Add(Me.cmdTareDisp)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdTareLoad)
        Me.Controls.Add(Me.cmdTareAll)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTareSensors"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Zero Sensors"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdTareAll As System.Windows.Forms.Button
    Friend WithEvents cmdTareLoad As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdTareDisp As System.Windows.Forms.Button
    Friend WithEvents cmdTareTorque As System.Windows.Forms.Button
    Friend WithEvents cmdTarePressure As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdTareILevel As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label6 As Label
    Friend WithEvents cmdTareVoltage As Button
End Class
