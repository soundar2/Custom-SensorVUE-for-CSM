<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmail2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmail2))
        Me.chkSMS = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbInterval = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.pnlEmail = New System.Windows.Forms.Panel
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.pnlSMS = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPhone = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbCarriers = New System.Windows.Forms.ComboBox
        Me.chkEmail = New System.Windows.Forms.CheckBox
        Me.grpTimings = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblLastSentTime = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdViewLog = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbAlarm1 = New System.Windows.Forms.ComboBox
        Me.cmbUnits = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.optOnce = New System.Windows.Forms.RadioButton
        Me.optEvery = New System.Windows.Forms.RadioButton
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.pnlAlarmInterval = New System.Windows.Forms.Panel
        Me.txtAlarmValue = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEmail.SuspendLayout()
        Me.pnlSMS.SuspendLayout()
        Me.grpTimings.SuspendLayout()
        Me.pnlAlarmInterval.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkSMS
        '
        Me.chkSMS.AutoSize = True
        Me.chkSMS.Location = New System.Drawing.Point(14, 126)
        Me.chkSMS.Name = "chkSMS"
        Me.chkSMS.Size = New System.Drawing.Size(186, 17)
        Me.chkSMS.TabIndex = 1
        Me.chkSMS.Text = "Send a text message to my phone"
        Me.chkSMS.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(158, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(292, 44)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "An active internet connection is needed. LoadVUE must be actively polling the sen" & _
            "sors."
        '
        'cmbInterval
        '
        Me.cmbInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInterval.FormattingEnabled = True
        Me.cmbInterval.Items.AddRange(New Object() {"1", "2", "4", "6", "12", "24"})
        Me.cmbInterval.Location = New System.Drawing.Point(106, 30)
        Me.cmbInterval.Name = "cmbInterval"
        Me.cmbInterval.Size = New System.Drawing.Size(64, 21)
        Me.cmbInterval.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Send every"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.pnlEmail)
        Me.GroupBox1.Controls.Add(Me.pnlSMS)
        Me.GroupBox1.Controls.Add(Me.chkEmail)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.chkSMS)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 163)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(466, 244)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Send To"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(14, 155)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(64, 69)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 18
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(11, 49)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(95, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'pnlEmail
        '
        Me.pnlEmail.Controls.Add(Me.txtEmail)
        Me.pnlEmail.Controls.Add(Me.Label4)
        Me.pnlEmail.Enabled = False
        Me.pnlEmail.Location = New System.Drawing.Point(112, 61)
        Me.pnlEmail.Name = "pnlEmail"
        Me.pnlEmail.Size = New System.Drawing.Size(347, 38)
        Me.pnlEmail.TabIndex = 0
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(58, 8)
        Me.txtEmail.MaxLength = 192
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(280, 20)
        Me.txtEmail.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Email:"
        '
        'pnlSMS
        '
        Me.pnlSMS.Controls.Add(Me.Label2)
        Me.pnlSMS.Controls.Add(Me.txtPhone)
        Me.pnlSMS.Controls.Add(Me.Label3)
        Me.pnlSMS.Controls.Add(Me.cmbCarriers)
        Me.pnlSMS.Enabled = False
        Me.pnlSMS.Location = New System.Drawing.Point(112, 149)
        Me.pnlSMS.Name = "pnlSMS"
        Me.pnlSMS.Size = New System.Drawing.Size(254, 70)
        Me.pnlSMS.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Phone Number:"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(92, 8)
        Me.txtPhone.MaxLength = 20
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(156, 20)
        Me.txtPhone.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Carrier:"
        '
        'cmbCarriers
        '
        Me.cmbCarriers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCarriers.FormattingEnabled = True
        Me.cmbCarriers.Location = New System.Drawing.Point(92, 40)
        Me.cmbCarriers.Name = "cmbCarriers"
        Me.cmbCarriers.Size = New System.Drawing.Size(156, 21)
        Me.cmbCarriers.TabIndex = 1
        '
        'chkEmail
        '
        Me.chkEmail.AutoSize = True
        Me.chkEmail.Location = New System.Drawing.Point(14, 26)
        Me.chkEmail.Name = "chkEmail"
        Me.chkEmail.Size = New System.Drawing.Size(138, 17)
        Me.chkEmail.TabIndex = 0
        Me.chkEmail.Text = "Send an email message"
        Me.chkEmail.UseVisualStyleBackColor = True
        '
        'grpTimings
        '
        Me.grpTimings.Controls.Add(Me.Label9)
        Me.grpTimings.Controls.Add(Me.lblLastSentTime)
        Me.grpTimings.Controls.Add(Me.Label8)
        Me.grpTimings.Controls.Add(Me.Label6)
        Me.grpTimings.Controls.Add(Me.cmbInterval)
        Me.grpTimings.Enabled = False
        Me.grpTimings.Location = New System.Drawing.Point(12, 412)
        Me.grpTimings.Name = "grpTimings"
        Me.grpTimings.Size = New System.Drawing.Size(466, 96)
        Me.grpTimings.TabIndex = 1
        Me.grpTimings.TabStop = False
        Me.grpTimings.Text = "E-mail/SMS Timings"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(183, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Hour(s)"
        '
        'lblLastSentTime
        '
        Me.lblLastSentTime.AutoSize = True
        Me.lblLastSentTime.Location = New System.Drawing.Point(106, 66)
        Me.lblLastSentTime.Name = "lblLastSentTime"
        Me.lblLastSentTime.Size = New System.Drawing.Size(16, 13)
        Me.lblLastSentTime.TabIndex = 0
        Me.lblLastSentTime.Text = "..."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Last Sent Time:"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(223, 519)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(122, 32)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.CausesValidation = False
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(356, 519)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(122, 32)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdViewLog
        '
        Me.cmdViewLog.Image = CType(resources.GetObject("cmdViewLog.Image"), System.Drawing.Image)
        Me.cmdViewLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdViewLog.Location = New System.Drawing.Point(12, 519)
        Me.cmdViewLog.Name = "cmdViewLog"
        Me.cmdViewLog.Size = New System.Drawing.Size(178, 32)
        Me.cmdViewLog.TabIndex = 2
        Me.cmdViewLog.Text = "View Log of Sent Messages"
        Me.cmdViewLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdViewLog.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "When total load is"
        '
        'cmbAlarm1
        '
        Me.cmbAlarm1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlarm1.FormattingEnabled = True
        Me.cmbAlarm1.Items.AddRange(New Object() {"greater than", "less than"})
        Me.cmbAlarm1.Location = New System.Drawing.Point(120, 21)
        Me.cmbAlarm1.Name = "cmbAlarm1"
        Me.cmbAlarm1.Size = New System.Drawing.Size(111, 21)
        Me.cmbAlarm1.TabIndex = 6
        '
        'cmbUnits
        '
        Me.cmbUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnits.FormattingEnabled = True
        Me.cmbUnits.Location = New System.Drawing.Point(296, 20)
        Me.cmbUnits.Name = "cmbUnits"
        Me.cmbUnits.Size = New System.Drawing.Size(48, 21)
        Me.cmbUnits.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Sound an alarm"
        '
        'optOnce
        '
        Me.optOnce.AutoSize = True
        Me.optOnce.Checked = True
        Me.optOnce.Location = New System.Drawing.Point(26, 88)
        Me.optOnce.Name = "optOnce"
        Me.optOnce.Size = New System.Drawing.Size(51, 17)
        Me.optOnce.TabIndex = 10
        Me.optOnce.TabStop = True
        Me.optOnce.Text = "Once"
        Me.optOnce.UseVisualStyleBackColor = True
        '
        'optEvery
        '
        Me.optEvery.AutoSize = True
        Me.optEvery.Location = New System.Drawing.Point(95, 88)
        Me.optEvery.Name = "optEvery"
        Me.optEvery.Size = New System.Drawing.Size(52, 17)
        Me.optEvery.TabIndex = 11
        Me.optEvery.Text = "Every"
        Me.optEvery.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(9, 7)
        Me.TextBox1.MaxLength = 20
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(45, 20)
        Me.TextBox1.TabIndex = 12
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Seconds (Minimum: 10)", "Minutes"})
        Me.ComboBox1.Location = New System.Drawing.Point(71, 6)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(157, 21)
        Me.ComboBox1.TabIndex = 13
        '
        'pnlAlarmInterval
        '
        Me.pnlAlarmInterval.Controls.Add(Me.ComboBox1)
        Me.pnlAlarmInterval.Controls.Add(Me.TextBox1)
        Me.pnlAlarmInterval.Enabled = False
        Me.pnlAlarmInterval.Location = New System.Drawing.Point(145, 80)
        Me.pnlAlarmInterval.Name = "pnlAlarmInterval"
        Me.pnlAlarmInterval.Size = New System.Drawing.Size(239, 35)
        Me.pnlAlarmInterval.TabIndex = 14
        '
        'txtAlarmValue
        '
        Me.txtAlarmValue.Location = New System.Drawing.Point(241, 21)
        Me.txtAlarmValue.MaxLength = 20
        Me.txtAlarmValue.Name = "txtAlarmValue"
        Me.txtAlarmValue.Size = New System.Drawing.Size(45, 20)
        Me.txtAlarmValue.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(142, 118)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(153, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "as long as the condition is true."
        '
        'frmEmail2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 566)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.pnlAlarmInterval)
        Me.Controls.Add(Me.optEvery)
        Me.Controls.Add(Me.optOnce)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbUnits)
        Me.Controls.Add(Me.txtAlarmValue)
        Me.Controls.Add(Me.cmbAlarm1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdViewLog)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.grpTimings)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEmail2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alarm Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEmail.ResumeLayout(False)
        Me.pnlEmail.PerformLayout()
        Me.pnlSMS.ResumeLayout(False)
        Me.pnlSMS.PerformLayout()
        Me.grpTimings.ResumeLayout(False)
        Me.grpTimings.PerformLayout()
        Me.pnlAlarmInterval.ResumeLayout(False)
        Me.pnlAlarmInterval.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkSMS As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbInterval As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlEmail As System.Windows.Forms.Panel
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlSMS As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCarriers As System.Windows.Forms.ComboBox
    Friend WithEvents chkEmail As System.Windows.Forms.CheckBox
    Friend WithEvents grpTimings As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblLastSentTime As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdViewLog As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbAlarm1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUnits As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents optOnce As System.Windows.Forms.RadioButton
    Friend WithEvents optEvery As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents pnlAlarmInterval As System.Windows.Forms.Panel
    Friend WithEvents txtAlarmValue As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label

End Class
