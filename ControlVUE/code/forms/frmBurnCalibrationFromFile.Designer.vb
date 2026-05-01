<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBurnCalibrationFromFile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBurnCalibrationFromFile))
        Me.cmdOpenFile = New System.Windows.Forms.Button()
        Me.cmdBurn = New System.Windows.Forms.Button()
        Me.txtLeft = New System.Windows.Forms.TextBox()
        Me.cmbPorts = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRight = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmdReadSettings = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbBaud = New System.Windows.Forms.ComboBox()
        Me.bgw = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOpenFile
        '
        Me.cmdOpenFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOpenFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOpenFile.Location = New System.Drawing.Point(935, 225)
        Me.cmdOpenFile.Margin = New System.Windows.Forms.Padding(17, 13, 17, 13)
        Me.cmdOpenFile.Name = "cmdOpenFile"
        Me.cmdOpenFile.Size = New System.Drawing.Size(209, 50)
        Me.cmdOpenFile.TabIndex = 13
        Me.cmdOpenFile.Text = "Read File..."
        Me.cmdOpenFile.UseVisualStyleBackColor = True
        '
        'cmdBurn
        '
        Me.cmdBurn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdBurn.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBurn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBurn.Location = New System.Drawing.Point(935, 291)
        Me.cmdBurn.Margin = New System.Windows.Forms.Padding(17, 13, 17, 13)
        Me.cmdBurn.Name = "cmdBurn"
        Me.cmdBurn.Size = New System.Drawing.Size(209, 50)
        Me.cmdBurn.TabIndex = 14
        Me.cmdBurn.Text = "Burn Settings..."
        Me.cmdBurn.UseVisualStyleBackColor = True
        '
        'txtLeft
        '
        Me.txtLeft.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtLeft.Location = New System.Drawing.Point(12, 77)
        Me.txtLeft.Multiline = True
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLeft.Size = New System.Drawing.Size(389, 261)
        Me.txtLeft.TabIndex = 15
        '
        'cmbPorts
        '
        Me.cmbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPorts.FormattingEnabled = True
        Me.cmbPorts.Location = New System.Drawing.Point(119, 22)
        Me.cmbPorts.Name = "cmbPorts"
        Me.cmbPorts.Size = New System.Drawing.Size(282, 32)
        Me.cmbPorts.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 24)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Select Port:"
        '
        'txtRight
        '
        Me.txtRight.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRight.Location = New System.Drawing.Point(416, 77)
        Me.txtRight.Multiline = True
        Me.txtRight.Name = "txtRight"
        Me.txtRight.ReadOnly = True
        Me.txtRight.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRight.Size = New System.Drawing.Size(499, 261)
        Me.txtRight.TabIndex = 19
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 348)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1161, 26)
        Me.StatusStrip1.TabIndex = 20
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(22, 21)
        Me.lblMessage.Text = "..."
        '
        'cmdReadSettings
        '
        Me.cmdReadSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReadSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdReadSettings.Location = New System.Drawing.Point(935, 77)
        Me.cmdReadSettings.Margin = New System.Windows.Forms.Padding(17, 13, 17, 13)
        Me.cmdReadSettings.Name = "cmdReadSettings"
        Me.cmdReadSettings.Size = New System.Drawing.Size(209, 77)
        Me.cmdReadSettings.TabIndex = 21
        Me.cmdReadSettings.Text = "Read Current Settings"
        Me.cmdReadSettings.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(419, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 24)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Baud Rate:"
        '
        'cmbBaud
        '
        Me.cmbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBaud.FormattingEnabled = True
        Me.cmbBaud.Items.AddRange(New Object() {"9600", "230400"})
        Me.cmbBaud.Location = New System.Drawing.Point(530, 22)
        Me.cmbBaud.Name = "cmbBaud"
        Me.cmbBaud.Size = New System.Drawing.Size(230, 32)
        Me.cmbBaud.TabIndex = 22
        '
        'bgw
        '
        Me.bgw.WorkerReportsProgress = True
        Me.bgw.WorkerSupportsCancellation = True
        '
        'frmBurnCalibrationFromFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1161, 374)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbBaud)
        Me.Controls.Add(Me.cmdReadSettings)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtRight)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbPorts)
        Me.Controls.Add(Me.txtLeft)
        Me.Controls.Add(Me.cmdBurn)
        Me.Controls.Add(Me.cmdOpenFile)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "frmBurnCalibrationFromFile"
        Me.Text = "Burn Calibration from File"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdOpenFile As Button
    Friend WithEvents cmdBurn As Button
    Friend WithEvents txtLeft As TextBox
    Friend WithEvents cmbPorts As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtRight As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblMessage As ToolStripStatusLabel
    Friend WithEvents cmdReadSettings As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbBaud As ComboBox
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
End Class
