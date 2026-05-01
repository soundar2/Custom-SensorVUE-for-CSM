<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlAlarm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlAlarm))
        Me.cmdAddress = New System.Windows.Forms.Button()
        Me.pnlAlarm = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpAlarmType = New System.Windows.Forms.GroupBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.chkSound = New System.Windows.Forms.CheckBox()
        Me.chkEmail = New System.Windows.Forms.CheckBox()
        Me.chkSms = New System.Windows.Forms.CheckBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cmbSensor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkHighAlarm = New System.Windows.Forms.CheckBox()
        Me.chkLowAlarm = New System.Windows.Forms.CheckBox()
        Me.txtHighAlarm = New System.Windows.Forms.TextBox()
        Me.txtLowAlarm = New System.Windows.Forms.TextBox()
        Me.cmbAlarmSound = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlAlarm.SuspendLayout()
        Me.grpAlarmType.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAddress
        '
        Me.cmdAddress.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddress.Location = New System.Drawing.Point(289, 158)
        Me.cmdAddress.Name = "cmdAddress"
        Me.cmdAddress.Size = New System.Drawing.Size(88, 76)
        Me.cmdAddress.TabIndex = 8
        Me.cmdAddress.Text = "Email, SMS Addresses..."
        Me.cmdAddress.UseVisualStyleBackColor = True
        '
        'pnlAlarm
        '
        Me.pnlAlarm.Controls.Add(Me.Label1)
        Me.pnlAlarm.Controls.Add(Me.cmdAddress)
        Me.pnlAlarm.Controls.Add(Me.grpAlarmType)
        Me.pnlAlarm.Controls.Add(Me.txtName)
        Me.pnlAlarm.Controls.Add(Me.cmbSensor)
        Me.pnlAlarm.Controls.Add(Me.Label2)
        Me.pnlAlarm.Controls.Add(Me.chkHighAlarm)
        Me.pnlAlarm.Controls.Add(Me.chkLowAlarm)
        Me.pnlAlarm.Controls.Add(Me.txtHighAlarm)
        Me.pnlAlarm.Controls.Add(Me.txtLowAlarm)
        Me.pnlAlarm.Location = New System.Drawing.Point(0, 0)
        Me.pnlAlarm.Name = "pnlAlarm"
        Me.pnlAlarm.Size = New System.Drawing.Size(390, 247)
        Me.pnlAlarm.TabIndex = 7
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
        'grpAlarmType
        '
        Me.grpAlarmType.Controls.Add(Me.PictureBox5)
        Me.grpAlarmType.Controls.Add(Me.PictureBox4)
        Me.grpAlarmType.Controls.Add(Me.PictureBox3)
        Me.grpAlarmType.Controls.Add(Me.chkSound)
        Me.grpAlarmType.Controls.Add(Me.chkEmail)
        Me.grpAlarmType.Controls.Add(Me.chkSms)
        Me.grpAlarmType.Location = New System.Drawing.Point(10, 138)
        Me.grpAlarmType.Name = "grpAlarmType"
        Me.grpAlarmType.Size = New System.Drawing.Size(267, 105)
        Me.grpAlarmType.TabIndex = 6
        Me.grpAlarmType.TabStop = False
        Me.grpAlarmType.Text = "Alarm Type"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(92, 71)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 35
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(167, 42)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(26, 28)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 34
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(104, 15)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(26, 28)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 33
        Me.PictureBox3.TabStop = False
        '
        'chkSound
        '
        Me.chkSound.AutoSize = True
        Me.chkSound.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSound.Location = New System.Drawing.Point(13, 20)
        Me.chkSound.Name = "chkSound"
        Me.chkSound.Size = New System.Drawing.Size(85, 17)
        Me.chkSound.TabIndex = 0
        Me.chkSound.Text = "Sound alarm"
        Me.chkSound.UseVisualStyleBackColor = True
        '
        'chkEmail
        '
        Me.chkEmail.AutoSize = True
        Me.chkEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEmail.Location = New System.Drawing.Point(13, 79)
        Me.chkEmail.Name = "chkEmail"
        Me.chkEmail.Size = New System.Drawing.Size(78, 17)
        Me.chkEmail.TabIndex = 2
        Me.chkEmail.Text = "Send email"
        Me.chkEmail.UseVisualStyleBackColor = True
        '
        'chkSms
        '
        Me.chkSms.AutoSize = True
        Me.chkSms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSms.Location = New System.Drawing.Point(13, 49)
        Me.chkSms.Name = "chkSms"
        Me.chkSms.Size = New System.Drawing.Size(153, 17)
        Me.chkSms.TabIndex = 1
        Me.chkSms.Text = "Send Text Message (SMS)"
        Me.chkSms.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(54, 11)
        Me.txtName.MaxLength = 20
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(107, 20)
        Me.txtName.TabIndex = 10
        '
        'cmbSensor
        '
        Me.cmbSensor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSensor.FormattingEnabled = True
        Me.cmbSensor.Location = New System.Drawing.Point(54, 43)
        Me.cmbSensor.Name = "cmbSensor"
        Me.cmbSensor.Size = New System.Drawing.Size(178, 21)
        Me.cmbSensor.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "&Sensor:"
        '
        'chkHighAlarm
        '
        Me.chkHighAlarm.AutoSize = True
        Me.chkHighAlarm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHighAlarm.Location = New System.Drawing.Point(10, 79)
        Me.chkHighAlarm.Name = "chkHighAlarm"
        Me.chkHighAlarm.Size = New System.Drawing.Size(201, 17)
        Me.chkHighAlarm.TabIndex = 2
        Me.chkHighAlarm.Text = "Enable alarm if reading goes ABOVE:"
        Me.chkHighAlarm.UseVisualStyleBackColor = True
        '
        'chkLowAlarm
        '
        Me.chkLowAlarm.AutoSize = True
        Me.chkLowAlarm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLowAlarm.Location = New System.Drawing.Point(10, 110)
        Me.chkLowAlarm.Name = "chkLowAlarm"
        Me.chkLowAlarm.Size = New System.Drawing.Size(204, 17)
        Me.chkLowAlarm.TabIndex = 4
        Me.chkLowAlarm.Text = "Enable alarm if reading goes BELOW:"
        Me.chkLowAlarm.UseVisualStyleBackColor = True
        '
        'txtHighAlarm
        '
        Me.txtHighAlarm.Enabled = False
        Me.txtHighAlarm.Location = New System.Drawing.Point(226, 76)
        Me.txtHighAlarm.Name = "txtHighAlarm"
        Me.txtHighAlarm.Size = New System.Drawing.Size(61, 20)
        Me.txtHighAlarm.TabIndex = 3
        '
        'txtLowAlarm
        '
        Me.txtLowAlarm.Enabled = False
        Me.txtLowAlarm.Location = New System.Drawing.Point(226, 108)
        Me.txtLowAlarm.Name = "txtLowAlarm"
        Me.txtLowAlarm.Size = New System.Drawing.Size(61, 20)
        Me.txtLowAlarm.TabIndex = 5
        '
        'cmbAlarmSound
        '
        Me.cmbAlarmSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlarmSound.FormattingEnabled = True
        Me.cmbAlarmSound.Location = New System.Drawing.Point(207, 256)
        Me.cmbAlarmSound.Name = "cmbAlarmSound"
        Me.cmbAlarmSound.Size = New System.Drawing.Size(170, 21)
        Me.cmbAlarmSound.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 259)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(181, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Alarm Sound - Common for all alarms:"
        '
        'ctlAlarm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbAlarmSound)
        Me.Controls.Add(Me.pnlAlarm)
        Me.Name = "ctlAlarm"
        Me.Size = New System.Drawing.Size(398, 286)
        Me.pnlAlarm.ResumeLayout(False)
        Me.pnlAlarm.PerformLayout()
        Me.grpAlarmType.ResumeLayout(False)
        Me.grpAlarmType.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAddress As System.Windows.Forms.Button
    Friend WithEvents pnlAlarm As System.Windows.Forms.Panel
    Friend WithEvents grpAlarmType As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents chkSound As System.Windows.Forms.CheckBox
    Friend WithEvents chkEmail As System.Windows.Forms.CheckBox
    Friend WithEvents chkSms As System.Windows.Forms.CheckBox
    Friend WithEvents cmbSensor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkHighAlarm As System.Windows.Forms.CheckBox
    Friend WithEvents chkLowAlarm As System.Windows.Forms.CheckBox
    Friend WithEvents txtHighAlarm As System.Windows.Forms.TextBox
    Friend WithEvents txtLowAlarm As System.Windows.Forms.TextBox
    Friend WithEvents cmbAlarmSound As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
