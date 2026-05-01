<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelaySettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRelaySettings))
        Me.cmdApply = New System.Windows.Forms.Button
        Me.lblSensor = New System.Windows.Forms.Label
        Me.cmbSensors = New System.Windows.Forms.ComboBox
        Me.txtRelayName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.optScript = New System.Windows.Forms.RadioButton
        Me.optSimple = New System.Windows.Forms.RadioButton
        Me.optManual = New System.Windows.Forms.RadioButton
        Me.cmbRelays = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.pnlRelaySetting = New System.Windows.Forms.Panel
        Me.lblUnits = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtV1 = New LvNumericTextBox.LvNumericTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtV2 = New LvNumericTextBox.LvNumericTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Hold2 = New System.Windows.Forms.RadioButton
        Me.Reset2 = New System.Windows.Forms.RadioButton
        Me.Trip2 = New System.Windows.Forms.RadioButton
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Hold1 = New System.Windows.Forms.RadioButton
        Me.Reset1 = New System.Windows.Forms.RadioButton
        Me.Trip1 = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Hold12 = New System.Windows.Forms.RadioButton
        Me.Reset12 = New System.Windows.Forms.RadioButton
        Me.Trip12 = New System.Windows.Forms.RadioButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.chkAutoReset = New System.Windows.Forms.CheckBox
        Me.cmdEditScript = New System.Windows.Forms.Button
        Me.cmdVerifyScript = New System.Windows.Forms.Button
        Me.txtScriptFile = New System.Windows.Forms.TextBox
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabDisable = New System.Windows.Forms.TabPage
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.tabSimple = New System.Windows.Forms.TabPage
        Me.tabCommands = New System.Windows.Forms.TabPage
        Me.Label10 = New System.Windows.Forms.Label
        Me.tabScript = New System.Windows.Forms.TabPage
        Me.Label9 = New System.Windows.Forms.Label
        Me.optCommands = New System.Windows.Forms.RadioButton
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.CtRelayCommands1 = New LoadVUE.ctRelayCommands
        Me.pnlRelaySetting.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tabDisable.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSimple.SuspendLayout()
        Me.tabCommands.SuspendLayout()
        Me.tabScript.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        Me.cmdApply.Image = Global.LoadVUE.My.Resources.Resources.ok
        Me.cmdApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdApply.Location = New System.Drawing.Point(582, 475)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(79, 36)
        Me.cmdApply.TabIndex = 6
        Me.cmdApply.Text = "&Apply"
        Me.cmdApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'lblSensor
        '
        Me.lblSensor.AutoSize = True
        Me.lblSensor.Location = New System.Drawing.Point(17, 74)
        Me.lblSensor.Name = "lblSensor"
        Me.lblSensor.Size = New System.Drawing.Size(150, 13)
        Me.lblSensor.TabIndex = 58
        Me.lblSensor.Text = "This relay will be controlled by:"
        Me.lblSensor.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbSensors
        '
        Me.cmbSensors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSensors.FormattingEnabled = True
        Me.cmbSensors.Items.AddRange(New Object() {"Greater than", "Less than"})
        Me.cmbSensors.Location = New System.Drawing.Point(173, 71)
        Me.cmbSensors.Name = "cmbSensors"
        Me.cmbSensors.Size = New System.Drawing.Size(157, 21)
        Me.cmbSensors.TabIndex = 5
        '
        'txtRelayName
        '
        Me.txtRelayName.Location = New System.Drawing.Point(173, 43)
        Me.txtRelayName.MaxLength = 30
        Me.txtRelayName.Name = "txtRelayName"
        Me.txtRelayName.Size = New System.Drawing.Size(157, 20)
        Me.txtRelayName.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 13)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Enter a name for this relay:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'optScript
        '
        Me.optScript.AutoSize = True
        Me.optScript.Location = New System.Drawing.Point(306, 103)
        Me.optScript.Name = "optScript"
        Me.optScript.Size = New System.Drawing.Size(97, 17)
        Me.optScript.TabIndex = 3
        Me.optScript.TabStop = True
        Me.optScript.Tag = "Script"
        Me.optScript.Text = "Use a script file"
        Me.optScript.UseVisualStyleBackColor = True
        '
        'optSimple
        '
        Me.optSimple.AutoSize = True
        Me.optSimple.Location = New System.Drawing.Point(80, 103)
        Me.optSimple.Name = "optSimple"
        Me.optSimple.Size = New System.Drawing.Size(115, 17)
        Me.optSimple.TabIndex = 2
        Me.optSimple.TabStop = True
        Me.optSimple.Tag = "Simple"
        Me.optSimple.Text = "Use simple settings"
        Me.optSimple.UseVisualStyleBackColor = True
        '
        'optManual
        '
        Me.optManual.AutoSize = True
        Me.optManual.Location = New System.Drawing.Point(17, 103)
        Me.optManual.Name = "optManual"
        Me.optManual.Size = New System.Drawing.Size(60, 17)
        Me.optManual.TabIndex = 1
        Me.optManual.TabStop = True
        Me.optManual.Tag = "Disable"
        Me.optManual.Text = "Manual"
        Me.optManual.UseVisualStyleBackColor = True
        '
        'cmbRelays
        '
        Me.cmbRelays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRelays.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRelays.FormattingEnabled = True
        Me.cmbRelays.Location = New System.Drawing.Point(173, 14)
        Me.cmbRelays.Name = "cmbRelays"
        Me.cmbRelays.Size = New System.Drawing.Size(51, 21)
        Me.cmbRelays.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(98, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Channel No.:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(143, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(348, 13)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "(If not checked, once the relay is tripped it will not be reset automatically)"
        '
        'pnlRelaySetting
        '
        Me.pnlRelaySetting.Controls.Add(Me.lblUnits)
        Me.pnlRelaySetting.Controls.Add(Me.Label1)
        Me.pnlRelaySetting.Controls.Add(Me.Label6)
        Me.pnlRelaySetting.Controls.Add(Me.txtV1)
        Me.pnlRelaySetting.Controls.Add(Me.Label3)
        Me.pnlRelaySetting.Controls.Add(Me.txtV2)
        Me.pnlRelaySetting.Controls.Add(Me.Label5)
        Me.pnlRelaySetting.Controls.Add(Me.Panel1)
        Me.pnlRelaySetting.Controls.Add(Me.Panel3)
        Me.pnlRelaySetting.Controls.Add(Me.Panel2)
        Me.pnlRelaySetting.Controls.Add(Me.PictureBox1)
        Me.pnlRelaySetting.Location = New System.Drawing.Point(12, 38)
        Me.pnlRelaySetting.Name = "pnlRelaySetting"
        Me.pnlRelaySetting.Size = New System.Drawing.Size(445, 316)
        Me.pnlRelaySetting.TabIndex = 66
        '
        'lblUnits
        '
        Me.lblUnits.AutoSize = True
        Me.lblUnits.Location = New System.Drawing.Point(381, 47)
        Me.lblUnits.Name = "lblUnits"
        Me.lblUnits.Size = New System.Drawing.Size(16, 13)
        Me.lblUnits.TabIndex = 63
        Me.lblUnits.Text = "..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(173, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "(V2 must be >= V1)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(341, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Units:"
        '
        'txtV1
        '
        Me.txtV1.Location = New System.Drawing.Point(337, 181)
        Me.txtV1.MaxLength = 10
        Me.txtV1.Name = "txtV1"
        Me.txtV1.Size = New System.Drawing.Size(63, 20)
        Me.txtV1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(309, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "V1:"
        '
        'txtV2
        '
        Me.txtV2.Location = New System.Drawing.Point(337, 119)
        Me.txtV2.MaxLength = 10
        Me.txtV2.Name = "txtV2"
        Me.txtV2.Size = New System.Drawing.Size(63, 20)
        Me.txtV2.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(309, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "V2:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Hold2)
        Me.Panel1.Controls.Add(Me.Reset2)
        Me.Panel1.Controls.Add(Me.Trip2)
        Me.Panel1.Location = New System.Drawing.Point(172, 84)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(204, 23)
        Me.Panel1.TabIndex = 35
        '
        'Hold2
        '
        Me.Hold2.AutoSize = True
        Me.Hold2.Location = New System.Drawing.Point(118, 3)
        Me.Hold2.Name = "Hold2"
        Me.Hold2.Size = New System.Drawing.Size(47, 17)
        Me.Hold2.TabIndex = 2
        Me.Hold2.Tag = "2"
        Me.Hold2.Text = "Hold"
        Me.Hold2.UseVisualStyleBackColor = True
        '
        'Reset2
        '
        Me.Reset2.AutoSize = True
        Me.Reset2.Checked = True
        Me.Reset2.Location = New System.Drawing.Point(61, 3)
        Me.Reset2.Name = "Reset2"
        Me.Reset2.Size = New System.Drawing.Size(53, 17)
        Me.Reset2.TabIndex = 1
        Me.Reset2.TabStop = True
        Me.Reset2.Tag = "2"
        Me.Reset2.Text = "OFF"
        Me.Reset2.UseVisualStyleBackColor = True
        '
        'Trip2
        '
        Me.Trip2.AutoSize = True
        Me.Trip2.Location = New System.Drawing.Point(4, 3)
        Me.Trip2.Name = "Trip2"
        Me.Trip2.Size = New System.Drawing.Size(43, 17)
        Me.Trip2.TabIndex = 0
        Me.Trip2.Tag = "2"
        Me.Trip2.Text = "ON"
        Me.Trip2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Hold1)
        Me.Panel3.Controls.Add(Me.Reset1)
        Me.Panel3.Controls.Add(Me.Trip1)
        Me.Panel3.Location = New System.Drawing.Point(172, 219)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(204, 23)
        Me.Panel3.TabIndex = 36
        '
        'Hold1
        '
        Me.Hold1.AutoSize = True
        Me.Hold1.Location = New System.Drawing.Point(119, 3)
        Me.Hold1.Name = "Hold1"
        Me.Hold1.Size = New System.Drawing.Size(47, 17)
        Me.Hold1.TabIndex = 2
        Me.Hold1.Tag = "1"
        Me.Hold1.Text = "Hold"
        Me.Hold1.UseVisualStyleBackColor = True
        '
        'Reset1
        '
        Me.Reset1.AutoSize = True
        Me.Reset1.Checked = True
        Me.Reset1.Location = New System.Drawing.Point(61, 3)
        Me.Reset1.Name = "Reset1"
        Me.Reset1.Size = New System.Drawing.Size(53, 17)
        Me.Reset1.TabIndex = 1
        Me.Reset1.TabStop = True
        Me.Reset1.Tag = "1"
        Me.Reset1.Text = "OFF"
        Me.Reset1.UseVisualStyleBackColor = True
        '
        'Trip1
        '
        Me.Trip1.AutoSize = True
        Me.Trip1.Location = New System.Drawing.Point(4, 3)
        Me.Trip1.Name = "Trip1"
        Me.Trip1.Size = New System.Drawing.Size(43, 17)
        Me.Trip1.TabIndex = 0
        Me.Trip1.Tag = "1"
        Me.Trip1.Text = "ON"
        Me.Trip1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Hold12)
        Me.Panel2.Controls.Add(Me.Reset12)
        Me.Panel2.Controls.Add(Me.Trip12)
        Me.Panel2.Location = New System.Drawing.Point(172, 148)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(204, 23)
        Me.Panel2.TabIndex = 37
        '
        'Hold12
        '
        Me.Hold12.AutoSize = True
        Me.Hold12.Location = New System.Drawing.Point(119, 3)
        Me.Hold12.Name = "Hold12"
        Me.Hold12.Size = New System.Drawing.Size(47, 17)
        Me.Hold12.TabIndex = 2
        Me.Hold12.Tag = "12"
        Me.Hold12.Text = "Hold"
        Me.Hold12.UseVisualStyleBackColor = True
        '
        'Reset12
        '
        Me.Reset12.AutoSize = True
        Me.Reset12.Checked = True
        Me.Reset12.Location = New System.Drawing.Point(61, 3)
        Me.Reset12.Name = "Reset12"
        Me.Reset12.Size = New System.Drawing.Size(53, 17)
        Me.Reset12.TabIndex = 1
        Me.Reset12.TabStop = True
        Me.Reset12.Tag = "12"
        Me.Reset12.Text = "OFF"
        Me.Reset12.UseVisualStyleBackColor = True
        '
        'Trip12
        '
        Me.Trip12.AutoSize = True
        Me.Trip12.Location = New System.Drawing.Point(4, 3)
        Me.Trip12.Name = "Trip12"
        Me.Trip12.Size = New System.Drawing.Size(43, 17)
        Me.Trip12.TabIndex = 0
        Me.Trip12.Tag = "12"
        Me.Trip12.Text = "ON"
        Me.Trip12.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-129, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(542, 272)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'chkAutoReset
        '
        Me.chkAutoReset.AutoSize = True
        Me.chkAutoReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoReset.Location = New System.Drawing.Point(12, 15)
        Me.chkAutoReset.Name = "chkAutoReset"
        Me.chkAutoReset.Size = New System.Drawing.Size(134, 17)
        Me.chkAutoReset.TabIndex = 65
        Me.chkAutoReset.Text = "Enable automatic reset"
        Me.chkAutoReset.UseVisualStyleBackColor = True
        '
        'cmdEditScript
        '
        Me.cmdEditScript.Enabled = False
        Me.cmdEditScript.Image = CType(resources.GetObject("cmdEditScript.Image"), System.Drawing.Image)
        Me.cmdEditScript.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEditScript.Location = New System.Drawing.Point(17, 148)
        Me.cmdEditScript.Name = "cmdEditScript"
        Me.cmdEditScript.Size = New System.Drawing.Size(101, 32)
        Me.cmdEditScript.TabIndex = 1
        Me.cmdEditScript.Text = "View/Edit"
        Me.cmdEditScript.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEditScript.UseVisualStyleBackColor = True
        '
        'cmdVerifyScript
        '
        Me.cmdVerifyScript.Enabled = False
        Me.cmdVerifyScript.Image = CType(resources.GetObject("cmdVerifyScript.Image"), System.Drawing.Image)
        Me.cmdVerifyScript.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdVerifyScript.Location = New System.Drawing.Point(124, 148)
        Me.cmdVerifyScript.Name = "cmdVerifyScript"
        Me.cmdVerifyScript.Size = New System.Drawing.Size(102, 32)
        Me.cmdVerifyScript.TabIndex = 2
        Me.cmdVerifyScript.Text = "Verify"
        Me.cmdVerifyScript.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdVerifyScript.UseVisualStyleBackColor = True
        '
        'txtScriptFile
        '
        Me.txtScriptFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtScriptFile.Location = New System.Drawing.Point(17, 122)
        Me.txtScriptFile.Name = "txtScriptFile"
        Me.txtScriptFile.ReadOnly = True
        Me.txtScriptFile.Size = New System.Drawing.Size(377, 20)
        Me.txtScriptFile.TabIndex = 61
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBrowse.Image = CType(resources.GetObject("cmdBrowse.Image"), System.Drawing.Image)
        Me.cmdBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBrowse.Location = New System.Drawing.Point(400, 115)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(86, 32)
        Me.cmdBrowse.TabIndex = 0
        Me.cmdBrowse.Text = "Select..."
        Me.cmdBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabDisable)
        Me.TabControl1.Controls.Add(Me.tabSimple)
        Me.TabControl1.Controls.Add(Me.tabCommands)
        Me.TabControl1.Controls.Add(Me.tabScript)
        Me.TabControl1.Location = New System.Drawing.Point(17, 133)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(559, 423)
        Me.TabControl1.TabIndex = 71
        '
        'tabDisable
        '
        Me.tabDisable.Controls.Add(Me.PictureBox2)
        Me.tabDisable.Controls.Add(Me.Label11)
        Me.tabDisable.Controls.Add(Me.Label8)
        Me.tabDisable.Location = New System.Drawing.Point(4, 22)
        Me.tabDisable.Name = "tabDisable"
        Me.tabDisable.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDisable.Size = New System.Drawing.Size(551, 381)
        Me.tabDisable.TabIndex = 0
        Me.tabDisable.Tag = "Disable"
        Me.tabDisable.Text = "Disable"
        Me.tabDisable.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(17, 40)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(39, 45)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 65
        Me.PictureBox2.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(77, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(318, 16)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "This channel can still be controlled manually."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(77, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(341, 16)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "The software control is disabled for this channel."
        '
        'tabSimple
        '
        Me.tabSimple.Controls.Add(Me.Label7)
        Me.tabSimple.Controls.Add(Me.chkAutoReset)
        Me.tabSimple.Controls.Add(Me.pnlRelaySetting)
        Me.tabSimple.Location = New System.Drawing.Point(4, 22)
        Me.tabSimple.Name = "tabSimple"
        Me.tabSimple.Size = New System.Drawing.Size(551, 381)
        Me.tabSimple.TabIndex = 3
        Me.tabSimple.Tag = "Simple"
        Me.tabSimple.Text = "Simple Settings"
        Me.tabSimple.UseVisualStyleBackColor = True
        '
        'tabCommands
        '
        Me.tabCommands.Controls.Add(Me.Label10)
        Me.tabCommands.Controls.Add(Me.CtRelayCommands1)
        Me.tabCommands.Location = New System.Drawing.Point(4, 22)
        Me.tabCommands.Name = "tabCommands"
        Me.tabCommands.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCommands.Size = New System.Drawing.Size(551, 397)
        Me.tabCommands.TabIndex = 1
        Me.tabCommands.Tag = "Commands"
        Me.tabCommands.Text = "Command Sequence"
        Me.tabCommands.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(309, 16)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "Use a set of commands to control this relay."
        '
        'tabScript
        '
        Me.tabScript.Controls.Add(Me.Label9)
        Me.tabScript.Controls.Add(Me.cmdEditScript)
        Me.tabScript.Controls.Add(Me.cmdVerifyScript)
        Me.tabScript.Controls.Add(Me.txtScriptFile)
        Me.tabScript.Controls.Add(Me.cmdBrowse)
        Me.tabScript.Location = New System.Drawing.Point(4, 22)
        Me.tabScript.Name = "tabScript"
        Me.tabScript.Size = New System.Drawing.Size(551, 381)
        Me.tabScript.TabIndex = 2
        Me.tabScript.Tag = "Script"
        Me.tabScript.Text = "Script Settings"
        Me.tabScript.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(503, 42)
        Me.Label9.TabIndex = 64
        Me.Label9.Text = "Use a VB.NET script file to control this relay. A single script can control more " & _
            "than one relay."
        '
        'optCommands
        '
        Me.optCommands.AutoSize = True
        Me.optCommands.Location = New System.Drawing.Point(201, 103)
        Me.optCommands.Name = "optCommands"
        Me.optCommands.Size = New System.Drawing.Size(99, 17)
        Me.optCommands.TabIndex = 72
        Me.optCommands.TabStop = True
        Me.optCommands.Tag = "Commands"
        Me.optCommands.Text = "Use Commands"
        Me.optCommands.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(582, 517)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(79, 36)
        Me.cmdCancel.TabIndex = 73
        Me.cmdCancel.Text = "Close"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'CtRelayCommands1
        '
        Me.CtRelayCommands1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CtRelayCommands1.AutoScroll = True
        Me.CtRelayCommands1.CommandList = Nothing
        Me.CtRelayCommands1.Location = New System.Drawing.Point(6, 44)
        Me.CtRelayCommands1.Name = "CtRelayCommands1"
        Me.CtRelayCommands1.Size = New System.Drawing.Size(525, 347)
        Me.CtRelayCommands1.TabIndex = 0
        '
        'frmRelaySettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 568)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.optCommands)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.optScript)
        Me.Controls.Add(Me.optSimple)
        Me.Controls.Add(Me.optManual)
        Me.Controls.Add(Me.cmbRelays)
        Me.Controls.Add(Me.txtRelayName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbSensors)
        Me.Controls.Add(Me.lblSensor)
        Me.Controls.Add(Me.cmdApply)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRelaySettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relay Settings"
        Me.pnlRelaySetting.ResumeLayout(False)
        Me.pnlRelaySetting.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tabDisable.ResumeLayout(False)
        Me.tabDisable.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSimple.ResumeLayout(False)
        Me.tabSimple.PerformLayout()
        Me.tabCommands.ResumeLayout(False)
        Me.tabCommands.PerformLayout()
        Me.tabScript.ResumeLayout(False)
        Me.tabScript.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents lblSensor As System.Windows.Forms.Label
    Friend WithEvents cmbSensors As System.Windows.Forms.ComboBox
    Friend WithEvents txtRelayName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents optScript As System.Windows.Forms.RadioButton
    Friend WithEvents optSimple As System.Windows.Forms.RadioButton
    Friend WithEvents optManual As System.Windows.Forms.RadioButton
    Friend WithEvents cmbRelays As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlRelaySetting As System.Windows.Forms.Panel
    Friend WithEvents lblUnits As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtV1 As LvNumericTextBox.LvNumericTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtV2 As LvNumericTextBox.LvNumericTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Hold2 As System.Windows.Forms.RadioButton
    Friend WithEvents Reset2 As System.Windows.Forms.RadioButton
    Friend WithEvents Trip2 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Hold1 As System.Windows.Forms.RadioButton
    Friend WithEvents Reset1 As System.Windows.Forms.RadioButton
    Friend WithEvents Trip1 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Hold12 As System.Windows.Forms.RadioButton
    Friend WithEvents Reset12 As System.Windows.Forms.RadioButton
    Friend WithEvents Trip12 As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents chkAutoReset As System.Windows.Forms.CheckBox
    Friend WithEvents cmdEditScript As System.Windows.Forms.Button
    Friend WithEvents cmdVerifyScript As System.Windows.Forms.Button
    Friend WithEvents txtScriptFile As System.Windows.Forms.TextBox
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabDisable As System.Windows.Forms.TabPage
    Friend WithEvents tabCommands As System.Windows.Forms.TabPage
    Friend WithEvents tabScript As System.Windows.Forms.TabPage
    Friend WithEvents CtRelayCommands1 As LoadVUE.ctRelayCommands
    Friend WithEvents tabSimple As System.Windows.Forms.TabPage
    Friend WithEvents optCommands As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
