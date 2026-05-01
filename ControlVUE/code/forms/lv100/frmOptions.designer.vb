<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdPunchCounterOptions = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabUnits = New System.Windows.Forms.TabPage()
        Me.grpTemperature = New System.Windows.Forms.GroupBox()
        Me.RadioButton16 = New System.Windows.Forms.RadioButton()
        Me.RadioButton17 = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpPressure = New System.Windows.Forms.GroupBox()
        Me.RadioButton15 = New System.Windows.Forms.RadioButton()
        Me.RadioButton11 = New System.Windows.Forms.RadioButton()
        Me.RadioButton12 = New System.Windows.Forms.RadioButton()
        Me.RadioButton13 = New System.Windows.Forms.RadioButton()
        Me.RadioButton14 = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grpTorque = New System.Windows.Forms.GroupBox()
        Me.RadioButton10 = New System.Windows.Forms.RadioButton()
        Me.RadioButton9 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grpLength = New System.Windows.Forms.GroupBox()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton8 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpForce = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabResolution = New System.Windows.Forms.TabPage()
        Me.grpDecimals = New System.Windows.Forms.GroupBox()
        Me.optDecimal1 = New System.Windows.Forms.RadioButton()
        Me.optDecimal2 = New System.Windows.Forms.RadioButton()
        Me.optDecimal3 = New System.Windows.Forms.RadioButton()
        Me.optDecimal0 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabRelay = New System.Windows.Forms.TabPage()
        Me.cmbNRelay = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tabSensorError = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDisconnectionCheckInterval = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdRelayOptions = New System.Windows.Forms.Button()
        Me.cmdTextOptions = New System.Windows.Forms.Button()
        Me.cmdLogOptions = New System.Windows.Forms.Button()
        Me.cmdGraphOptions = New System.Windows.Forms.Button()
        Me.chkScientific = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabUnits.SuspendLayout()
        Me.grpTemperature.SuspendLayout()
        Me.grpPressure.SuspendLayout()
        Me.grpTorque.SuspendLayout()
        Me.grpLength.SuspendLayout()
        Me.grpForce.SuspendLayout()
        Me.tabResolution.SuspendLayout()
        Me.grpDecimals.SuspendLayout()
        Me.tabRelay.SuspendLayout()
        Me.tabSensorError.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Image = Global.LoadVUE.My.Resources.Resources.ok
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(534, 359)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(100, 44)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "OK"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Image = Global.LoadVUE.My.Resources.Resources.cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(534, 413)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 44)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdPunchCounterOptions)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Controls.Add(Me.cmdRelayOptions)
        Me.Panel1.Controls.Add(Me.cmdTextOptions)
        Me.Panel1.Controls.Add(Me.cmdLogOptions)
        Me.Panel1.Controls.Add(Me.cmdGraphOptions)
        Me.Panel1.Controls.Add(Me.cmdOK)
        Me.Panel1.Controls.Add(Me.cmdCancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(697, 466)
        Me.Panel1.TabIndex = 13
        Me.Panel1.Tag = "lbf-ft"
        '
        'cmdPunchCounterOptions
        '
        Me.cmdPunchCounterOptions.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPunchCounterOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPunchCounterOptions.Location = New System.Drawing.Point(380, 359)
        Me.cmdPunchCounterOptions.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdPunchCounterOptions.Name = "cmdPunchCounterOptions"
        Me.cmdPunchCounterOptions.Size = New System.Drawing.Size(136, 98)
        Me.cmdPunchCounterOptions.TabIndex = 19
        Me.cmdPunchCounterOptions.Text = "Punch Counter Options..."
        Me.cmdPunchCounterOptions.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPunchCounterOptions.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabUnits)
        Me.TabControl1.Controls.Add(Me.tabResolution)
        Me.TabControl1.Controls.Add(Me.tabRelay)
        Me.TabControl1.Controls.Add(Me.tabSensorError)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(622, 339)
        Me.TabControl1.TabIndex = 18
        '
        'tabUnits
        '
        Me.tabUnits.Controls.Add(Me.grpTemperature)
        Me.tabUnits.Controls.Add(Me.grpPressure)
        Me.tabUnits.Controls.Add(Me.grpTorque)
        Me.tabUnits.Controls.Add(Me.grpLength)
        Me.tabUnits.Controls.Add(Me.grpForce)
        Me.tabUnits.Location = New System.Drawing.Point(4, 29)
        Me.tabUnits.Name = "tabUnits"
        Me.tabUnits.Padding = New System.Windows.Forms.Padding(3)
        Me.tabUnits.Size = New System.Drawing.Size(614, 306)
        Me.tabUnits.TabIndex = 0
        Me.tabUnits.Text = "Units"
        Me.tabUnits.UseVisualStyleBackColor = True
        '
        'grpTemperature
        '
        Me.grpTemperature.BackColor = System.Drawing.Color.Transparent
        Me.grpTemperature.Controls.Add(Me.RadioButton16)
        Me.grpTemperature.Controls.Add(Me.RadioButton17)
        Me.grpTemperature.Controls.Add(Me.Label6)
        Me.grpTemperature.Location = New System.Drawing.Point(7, 232)
        Me.grpTemperature.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpTemperature.Name = "grpTemperature"
        Me.grpTemperature.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpTemperature.Size = New System.Drawing.Size(555, 60)
        Me.grpTemperature.TabIndex = 18
        Me.grpTemperature.TabStop = False
        '
        'RadioButton16
        '
        Me.RadioButton16.AutoSize = True
        Me.RadioButton16.Location = New System.Drawing.Point(243, 23)
        Me.RadioButton16.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton16.Name = "RadioButton16"
        Me.RadioButton16.Size = New System.Drawing.Size(37, 24)
        Me.RadioButton16.TabIndex = 10
        Me.RadioButton16.TabStop = True
        Me.RadioButton16.Tag = "F"
        Me.RadioButton16.Text = "F"
        Me.RadioButton16.UseVisualStyleBackColor = True
        '
        'RadioButton17
        '
        Me.RadioButton17.AutoSize = True
        Me.RadioButton17.Location = New System.Drawing.Point(184, 23)
        Me.RadioButton17.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton17.Name = "RadioButton17"
        Me.RadioButton17.Size = New System.Drawing.Size(38, 24)
        Me.RadioButton17.TabIndex = 6
        Me.RadioButton17.TabStop = True
        Me.RadioButton17.Tag = "C"
        Me.RadioButton17.Text = "C"
        Me.RadioButton17.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 25)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Temperature:"
        '
        'grpPressure
        '
        Me.grpPressure.BackColor = System.Drawing.Color.Transparent
        Me.grpPressure.Controls.Add(Me.RadioButton15)
        Me.grpPressure.Controls.Add(Me.RadioButton11)
        Me.grpPressure.Controls.Add(Me.RadioButton12)
        Me.grpPressure.Controls.Add(Me.RadioButton13)
        Me.grpPressure.Controls.Add(Me.RadioButton14)
        Me.grpPressure.Controls.Add(Me.Label5)
        Me.grpPressure.Location = New System.Drawing.Point(7, 120)
        Me.grpPressure.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpPressure.Name = "grpPressure"
        Me.grpPressure.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpPressure.Size = New System.Drawing.Size(555, 60)
        Me.grpPressure.TabIndex = 20
        Me.grpPressure.TabStop = False
        '
        'RadioButton15
        '
        Me.RadioButton15.AutoSize = True
        Me.RadioButton15.Location = New System.Drawing.Point(463, 24)
        Me.RadioButton15.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton15.Name = "RadioButton15"
        Me.RadioButton15.Size = New System.Drawing.Size(59, 24)
        Me.RadioButton15.TabIndex = 13
        Me.RadioButton15.TabStop = True
        Me.RadioButton15.Tag = "MPa"
        Me.RadioButton15.Text = "MPa"
        Me.RadioButton15.UseVisualStyleBackColor = True
        '
        'RadioButton11
        '
        Me.RadioButton11.AutoSize = True
        Me.RadioButton11.Location = New System.Drawing.Point(386, 24)
        Me.RadioButton11.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton11.Name = "RadioButton11"
        Me.RadioButton11.Size = New System.Drawing.Size(56, 24)
        Me.RadioButton11.TabIndex = 12
        Me.RadioButton11.TabStop = True
        Me.RadioButton11.Tag = "KPa"
        Me.RadioButton11.Text = "KPa"
        Me.RadioButton11.UseVisualStyleBackColor = True
        '
        'RadioButton12
        '
        Me.RadioButton12.AutoSize = True
        Me.RadioButton12.Location = New System.Drawing.Point(319, 24)
        Me.RadioButton12.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton12.Name = "RadioButton12"
        Me.RadioButton12.Size = New System.Drawing.Size(46, 24)
        Me.RadioButton12.TabIndex = 11
        Me.RadioButton12.TabStop = True
        Me.RadioButton12.Tag = "Pa"
        Me.RadioButton12.Text = "Pa"
        Me.RadioButton12.UseVisualStyleBackColor = True
        '
        'RadioButton13
        '
        Me.RadioButton13.AutoSize = True
        Me.RadioButton13.Location = New System.Drawing.Point(252, 24)
        Me.RadioButton13.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton13.Name = "RadioButton13"
        Me.RadioButton13.Size = New System.Drawing.Size(46, 24)
        Me.RadioButton13.TabIndex = 10
        Me.RadioButton13.TabStop = True
        Me.RadioButton13.Tag = "ksi"
        Me.RadioButton13.Text = "ksi"
        Me.RadioButton13.UseVisualStyleBackColor = True
        '
        'RadioButton14
        '
        Me.RadioButton14.AutoSize = True
        Me.RadioButton14.Location = New System.Drawing.Point(184, 24)
        Me.RadioButton14.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton14.Name = "RadioButton14"
        Me.RadioButton14.Size = New System.Drawing.Size(47, 24)
        Me.RadioButton14.TabIndex = 6
        Me.RadioButton14.TabStop = True
        Me.RadioButton14.Tag = "psi"
        Me.RadioButton14.Text = "psi"
        Me.RadioButton14.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 26)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Pressure:"
        '
        'grpTorque
        '
        Me.grpTorque.BackColor = System.Drawing.Color.Transparent
        Me.grpTorque.Controls.Add(Me.RadioButton10)
        Me.grpTorque.Controls.Add(Me.RadioButton9)
        Me.grpTorque.Controls.Add(Me.RadioButton5)
        Me.grpTorque.Controls.Add(Me.RadioButton7)
        Me.grpTorque.Controls.Add(Me.Label4)
        Me.grpTorque.Location = New System.Drawing.Point(7, 64)
        Me.grpTorque.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpTorque.Name = "grpTorque"
        Me.grpTorque.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpTorque.Size = New System.Drawing.Size(555, 60)
        Me.grpTorque.TabIndex = 19
        Me.grpTorque.TabStop = False
        '
        'RadioButton10
        '
        Me.RadioButton10.AutoSize = True
        Me.RadioButton10.Location = New System.Drawing.Point(419, 23)
        Me.RadioButton10.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton10.Name = "RadioButton10"
        Me.RadioButton10.Size = New System.Drawing.Size(56, 24)
        Me.RadioButton10.TabIndex = 12
        Me.RadioButton10.TabStop = True
        Me.RadioButton10.Tag = "N-m"
        Me.RadioButton10.Text = "N-m"
        Me.RadioButton10.UseVisualStyleBackColor = True
        '
        'RadioButton9
        '
        Me.RadioButton9.AutoSize = True
        Me.RadioButton9.Location = New System.Drawing.Point(336, 23)
        Me.RadioButton9.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton9.Name = "RadioButton9"
        Me.RadioButton9.Size = New System.Drawing.Size(67, 24)
        Me.RadioButton9.TabIndex = 11
        Me.RadioButton9.TabStop = True
        Me.RadioButton9.Tag = "kgf-m"
        Me.RadioButton9.Text = "kgf-m"
        Me.RadioButton9.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(259, 23)
        Me.RadioButton5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(61, 24)
        Me.RadioButton5.TabIndex = 10
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Tag = "lbf-in"
        Me.RadioButton5.Text = "lbf-in"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.Location = New System.Drawing.Point(184, 23)
        Me.RadioButton7.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(59, 24)
        Me.RadioButton7.TabIndex = 6
        Me.RadioButton7.TabStop = True
        Me.RadioButton7.Tag = ""
        Me.RadioButton7.Text = "lbf-ft"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 25)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Torque:"
        '
        'grpLength
        '
        Me.grpLength.BackColor = System.Drawing.Color.Transparent
        Me.grpLength.Controls.Add(Me.RadioButton6)
        Me.grpLength.Controls.Add(Me.RadioButton8)
        Me.grpLength.Controls.Add(Me.Label3)
        Me.grpLength.Location = New System.Drawing.Point(7, 176)
        Me.grpLength.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpLength.Name = "grpLength"
        Me.grpLength.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpLength.Size = New System.Drawing.Size(555, 60)
        Me.grpLength.TabIndex = 17
        Me.grpLength.TabStop = False
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(274, 24)
        Me.RadioButton6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(53, 24)
        Me.RadioButton6.TabIndex = 10
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Tag = "mm"
        Me.RadioButton6.Text = "mm"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton8
        '
        Me.RadioButton8.AutoSize = True
        Me.RadioButton8.Location = New System.Drawing.Point(184, 24)
        Me.RadioButton8.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(73, 24)
        Me.RadioButton8.TabIndex = 6
        Me.RadioButton8.TabStop = True
        Me.RadioButton8.Tag = "in"
        Me.RadioButton8.Text = "inches"
        Me.RadioButton8.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Length:"
        '
        'grpForce
        '
        Me.grpForce.BackColor = System.Drawing.Color.Transparent
        Me.grpForce.Controls.Add(Me.RadioButton3)
        Me.grpForce.Controls.Add(Me.RadioButton1)
        Me.grpForce.Controls.Add(Me.RadioButton2)
        Me.grpForce.Controls.Add(Me.RadioButton4)
        Me.grpForce.Controls.Add(Me.Label2)
        Me.grpForce.Location = New System.Drawing.Point(7, 8)
        Me.grpForce.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpForce.Name = "grpForce"
        Me.grpForce.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpForce.Size = New System.Drawing.Size(555, 60)
        Me.grpForce.TabIndex = 16
        Me.grpForce.TabStop = False
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(337, 23)
        Me.RadioButton3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(36, 24)
        Me.RadioButton3.TabIndex = 11
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Tag = "g"
        Me.RadioButton3.Text = "g"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(258, 23)
        Me.RadioButton1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(49, 24)
        Me.RadioButton1.TabIndex = 10
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Tag = "kgf"
        Me.RadioButton1.Text = "kgf"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(403, 23)
        Me.RadioButton2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(38, 24)
        Me.RadioButton2.TabIndex = 9
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Tag = "N"
        Me.RadioButton2.Text = "N"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(184, 23)
        Me.RadioButton4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(44, 24)
        Me.RadioButton4.TabIndex = 6
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Tag = "lbf"
        Me.RadioButton4.Text = "lbf"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 23)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Force:"
        '
        'tabResolution
        '
        Me.tabResolution.Controls.Add(Me.chkScientific)
        Me.tabResolution.Controls.Add(Me.grpDecimals)
        Me.tabResolution.Location = New System.Drawing.Point(4, 29)
        Me.tabResolution.Name = "tabResolution"
        Me.tabResolution.Padding = New System.Windows.Forms.Padding(3)
        Me.tabResolution.Size = New System.Drawing.Size(614, 306)
        Me.tabResolution.TabIndex = 1
        Me.tabResolution.Text = "Resolution"
        Me.tabResolution.UseVisualStyleBackColor = True
        '
        'grpDecimals
        '
        Me.grpDecimals.BackColor = System.Drawing.Color.Transparent
        Me.grpDecimals.Controls.Add(Me.optDecimal1)
        Me.grpDecimals.Controls.Add(Me.optDecimal2)
        Me.grpDecimals.Controls.Add(Me.optDecimal3)
        Me.grpDecimals.Controls.Add(Me.optDecimal0)
        Me.grpDecimals.Controls.Add(Me.Label1)
        Me.grpDecimals.Location = New System.Drawing.Point(7, 8)
        Me.grpDecimals.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpDecimals.Name = "grpDecimals"
        Me.grpDecimals.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpDecimals.Size = New System.Drawing.Size(555, 60)
        Me.grpDecimals.TabIndex = 12
        Me.grpDecimals.TabStop = False
        '
        'optDecimal1
        '
        Me.optDecimal1.AutoSize = True
        Me.optDecimal1.Location = New System.Drawing.Point(243, 20)
        Me.optDecimal1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optDecimal1.Name = "optDecimal1"
        Me.optDecimal1.Size = New System.Drawing.Size(53, 24)
        Me.optDecimal1.TabIndex = 10
        Me.optDecimal1.TabStop = True
        Me.optDecimal1.Tag = "0.0"
        Me.optDecimal1.Text = "X.X"
        Me.optDecimal1.UseVisualStyleBackColor = True
        '
        'optDecimal2
        '
        Me.optDecimal2.AutoSize = True
        Me.optDecimal2.Location = New System.Drawing.Point(317, 20)
        Me.optDecimal2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optDecimal2.Name = "optDecimal2"
        Me.optDecimal2.Size = New System.Drawing.Size(64, 24)
        Me.optDecimal2.TabIndex = 9
        Me.optDecimal2.TabStop = True
        Me.optDecimal2.Tag = "0.00"
        Me.optDecimal2.Text = "X.XX"
        Me.optDecimal2.UseVisualStyleBackColor = True
        '
        'optDecimal3
        '
        Me.optDecimal3.AutoSize = True
        Me.optDecimal3.Location = New System.Drawing.Point(402, 20)
        Me.optDecimal3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optDecimal3.Name = "optDecimal3"
        Me.optDecimal3.Size = New System.Drawing.Size(75, 24)
        Me.optDecimal3.TabIndex = 8
        Me.optDecimal3.TabStop = True
        Me.optDecimal3.Tag = "0.000"
        Me.optDecimal3.Text = "X.XXX"
        Me.optDecimal3.UseVisualStyleBackColor = True
        '
        'optDecimal0
        '
        Me.optDecimal0.AutoSize = True
        Me.optDecimal0.Location = New System.Drawing.Point(184, 20)
        Me.optDecimal0.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optDecimal0.Name = "optDecimal0"
        Me.optDecimal0.Size = New System.Drawing.Size(38, 24)
        Me.optDecimal0.TabIndex = 6
        Me.optDecimal0.TabStop = True
        Me.optDecimal0.Tag = "0"
        Me.optDecimal0.Text = "X"
        Me.optDecimal0.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Resolution:"
        '
        'tabRelay
        '
        Me.tabRelay.Controls.Add(Me.cmbNRelay)
        Me.tabRelay.Controls.Add(Me.Label11)
        Me.tabRelay.Controls.Add(Me.Label12)
        Me.tabRelay.Location = New System.Drawing.Point(4, 29)
        Me.tabRelay.Name = "tabRelay"
        Me.tabRelay.Size = New System.Drawing.Size(614, 306)
        Me.tabRelay.TabIndex = 2
        Me.tabRelay.Text = "No. of Relays"
        Me.tabRelay.UseVisualStyleBackColor = True
        '
        'cmbNRelay
        '
        Me.cmbNRelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNRelay.FormattingEnabled = True
        Me.cmbNRelay.Items.AddRange(New Object() {"1 Channel", "2 Channels", "8 Channels", "16 Channels (2 x 8 Channels)"})
        Me.cmbNRelay.Location = New System.Drawing.Point(182, 35)
        Me.cmbNRelay.Name = "cmbNRelay"
        Me.cmbNRelay.Size = New System.Drawing.Size(207, 28)
        Me.cmbNRelay.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(18, 63)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "(Needs restart)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 38)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(158, 20)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "No of installed relays:"
        '
        'tabSensorError
        '
        Me.tabSensorError.Controls.Add(Me.GroupBox1)
        Me.tabSensorError.Location = New System.Drawing.Point(4, 29)
        Me.tabSensorError.Name = "tabSensorError"
        Me.tabSensorError.Size = New System.Drawing.Size(614, 306)
        Me.tabSensorError.TabIndex = 3
        Me.tabSensorError.Text = "Sensor Errors"
        Me.tabSensorError.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtDisconnectionCheckInterval)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(548, 96)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sensor Disconnection Check"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(17, 60)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 16)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "(Needs restart)"
        '
        'txtDisconnectionCheckInterval
        '
        Me.txtDisconnectionCheckInterval.Location = New System.Drawing.Point(314, 33)
        Me.txtDisconnectionCheckInterval.Name = "txtDisconnectionCheckInterval"
        Me.txtDisconnectionCheckInterval.Size = New System.Drawing.Size(67, 26)
        Me.txtDisconnectionCheckInterval.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(393, 35)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 20)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "sec. (Min: 1 sec)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 35)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(286, 20)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Check if a sensor is disconnected every"
        '
        'cmdRelayOptions
        '
        Me.cmdRelayOptions.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRelayOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRelayOptions.Location = New System.Drawing.Point(196, 413)
        Me.cmdRelayOptions.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdRelayOptions.Name = "cmdRelayOptions"
        Me.cmdRelayOptions.Size = New System.Drawing.Size(176, 44)
        Me.cmdRelayOptions.TabIndex = 17
        Me.cmdRelayOptions.Text = "Relay Options..."
        Me.cmdRelayOptions.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdRelayOptions.UseVisualStyleBackColor = False
        '
        'cmdTextOptions
        '
        Me.cmdTextOptions.BackColor = System.Drawing.SystemColors.Control
        Me.cmdTextOptions.Image = CType(resources.GetObject("cmdTextOptions.Image"), System.Drawing.Image)
        Me.cmdTextOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdTextOptions.Location = New System.Drawing.Point(196, 359)
        Me.cmdTextOptions.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdTextOptions.Name = "cmdTextOptions"
        Me.cmdTextOptions.Size = New System.Drawing.Size(176, 44)
        Me.cmdTextOptions.TabIndex = 15
        Me.cmdTextOptions.Text = "Text Options..."
        Me.cmdTextOptions.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdTextOptions.UseVisualStyleBackColor = False
        '
        'cmdLogOptions
        '
        Me.cmdLogOptions.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLogOptions.Image = CType(resources.GetObject("cmdLogOptions.Image"), System.Drawing.Image)
        Me.cmdLogOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLogOptions.Location = New System.Drawing.Point(12, 413)
        Me.cmdLogOptions.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdLogOptions.Name = "cmdLogOptions"
        Me.cmdLogOptions.Size = New System.Drawing.Size(176, 44)
        Me.cmdLogOptions.TabIndex = 14
        Me.cmdLogOptions.Text = "Log Options..."
        Me.cmdLogOptions.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdLogOptions.UseVisualStyleBackColor = False
        '
        'cmdGraphOptions
        '
        Me.cmdGraphOptions.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGraphOptions.Image = CType(resources.GetObject("cmdGraphOptions.Image"), System.Drawing.Image)
        Me.cmdGraphOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGraphOptions.Location = New System.Drawing.Point(12, 359)
        Me.cmdGraphOptions.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdGraphOptions.Name = "cmdGraphOptions"
        Me.cmdGraphOptions.Size = New System.Drawing.Size(176, 44)
        Me.cmdGraphOptions.TabIndex = 13
        Me.cmdGraphOptions.Text = "Graph Options..."
        Me.cmdGraphOptions.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGraphOptions.UseVisualStyleBackColor = False
        '
        'chkScientific
        '
        Me.chkScientific.AutoSize = True
        Me.chkScientific.Location = New System.Drawing.Point(32, 85)
        Me.chkScientific.Name = "chkScientific"
        Me.chkScientific.Size = New System.Drawing.Size(294, 24)
        Me.chkScientific.TabIndex = 14
        Me.chkScientific.Text = "Use scientific format for log files (only)"
        Me.chkScientific.UseVisualStyleBackColor = True
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(697, 466)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "General Options"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tabUnits.ResumeLayout(False)
        Me.grpTemperature.ResumeLayout(False)
        Me.grpTemperature.PerformLayout()
        Me.grpPressure.ResumeLayout(False)
        Me.grpPressure.PerformLayout()
        Me.grpTorque.ResumeLayout(False)
        Me.grpTorque.PerformLayout()
        Me.grpLength.ResumeLayout(False)
        Me.grpLength.PerformLayout()
        Me.grpForce.ResumeLayout(False)
        Me.grpForce.PerformLayout()
        Me.tabResolution.ResumeLayout(False)
        Me.tabResolution.PerformLayout()
        Me.grpDecimals.ResumeLayout(False)
        Me.grpDecimals.PerformLayout()
        Me.tabRelay.ResumeLayout(False)
        Me.tabRelay.PerformLayout()
        Me.tabSensorError.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdGraphOptions As System.Windows.Forms.Button
    Friend WithEvents cmdLogOptions As System.Windows.Forms.Button
    Friend WithEvents cmdTextOptions As System.Windows.Forms.Button
    Friend WithEvents cmdRelayOptions As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabUnits As TabPage
    Friend WithEvents grpTemperature As GroupBox
    Friend WithEvents RadioButton16 As RadioButton
    Friend WithEvents RadioButton17 As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents grpPressure As GroupBox
    Friend WithEvents RadioButton15 As RadioButton
    Friend WithEvents RadioButton11 As RadioButton
    Friend WithEvents RadioButton12 As RadioButton
    Friend WithEvents RadioButton13 As RadioButton
    Friend WithEvents RadioButton14 As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents grpTorque As GroupBox
    Friend WithEvents RadioButton10 As RadioButton
    Friend WithEvents RadioButton9 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents RadioButton7 As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents grpLength As GroupBox
    Friend WithEvents RadioButton6 As RadioButton
    Friend WithEvents RadioButton8 As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents grpForce As GroupBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents tabResolution As TabPage
    Friend WithEvents grpDecimals As GroupBox
    Friend WithEvents optDecimal1 As RadioButton
    Friend WithEvents optDecimal2 As RadioButton
    Friend WithEvents optDecimal3 As RadioButton
    Friend WithEvents optDecimal0 As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents tabRelay As TabPage
    Friend WithEvents tabSensorError As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtDisconnectionCheckInterval As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbNRelay As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cmdPunchCounterOptions As Button
    Friend WithEvents chkScientific As CheckBox
End Class
