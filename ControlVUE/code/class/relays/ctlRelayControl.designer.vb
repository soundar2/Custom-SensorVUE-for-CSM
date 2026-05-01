<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctlRelayControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlRelayControl))
        Me.cmdTrip = New System.Windows.Forms.Button()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.picRelayStatus = New System.Windows.Forms.PictureBox()
        Me.lblRelayName = New System.Windows.Forms.Label()
        Me.lblRelayNo = New System.Windows.Forms.Label()
        Me.lblAuto = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.picRelayStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdTrip
        '
        Me.cmdTrip.Location = New System.Drawing.Point(6, 76)
        Me.cmdTrip.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdTrip.Name = "cmdTrip"
        Me.cmdTrip.Size = New System.Drawing.Size(130, 36)
        Me.cmdTrip.TabIndex = 53
        Me.cmdTrip.Text = "ON"
        Me.cmdTrip.UseVisualStyleBackColor = True
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(4, 35)
        Me.cmdReset.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(132, 36)
        Me.cmdReset.TabIndex = 54
        Me.cmdReset.Text = "OFF"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lblRelayName)
        Me.Panel1.Controls.Add(Me.lblRelayNo)
        Me.Panel1.Controls.Add(Me.lblAuto)
        Me.Panel1.Controls.Add(Me.cmdTrip)
        Me.Panel1.Controls.Add(Me.cmdReset)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(142, 205)
        Me.Panel1.TabIndex = 56
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.picRelayStatus)
        Me.Panel2.Location = New System.Drawing.Point(0, 119)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(136, 47)
        Me.Panel2.TabIndex = 61
        '
        'picRelayStatus
        '
        Me.picRelayStatus.Image = CType(resources.GetObject("picRelayStatus.Image"), System.Drawing.Image)
        Me.picRelayStatus.Location = New System.Drawing.Point(6, -22)
        Me.picRelayStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.picRelayStatus.Name = "picRelayStatus"
        Me.picRelayStatus.Size = New System.Drawing.Size(120, 83)
        Me.picRelayStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picRelayStatus.TabIndex = 60
        Me.picRelayStatus.TabStop = False
        '
        'lblRelayName
        '
        Me.lblRelayName.BackColor = System.Drawing.Color.Gold
        Me.lblRelayName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblRelayName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRelayName.Location = New System.Drawing.Point(0, 0)
        Me.lblRelayName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRelayName.Name = "lblRelayName"
        Me.lblRelayName.Size = New System.Drawing.Size(140, 31)
        Me.lblRelayName.TabIndex = 59
        Me.lblRelayName.Text = "..."
        Me.lblRelayName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRelayNo
        '
        Me.lblRelayNo.BackColor = System.Drawing.Color.Transparent
        Me.lblRelayNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRelayNo.Location = New System.Drawing.Point(0, 167)
        Me.lblRelayNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRelayNo.Name = "lblRelayNo"
        Me.lblRelayNo.Size = New System.Drawing.Size(33, 28)
        Me.lblRelayNo.TabIndex = 57
        Me.lblRelayNo.Text = "16"
        Me.lblRelayNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAuto
        '
        Me.lblAuto.AutoSize = True
        Me.lblAuto.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAuto.ForeColor = System.Drawing.Color.Black
        Me.lblAuto.Location = New System.Drawing.Point(34, 174)
        Me.lblAuto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAuto.Name = "lblAuto"
        Me.lblAuto.Size = New System.Drawing.Size(95, 18)
        Me.lblAuto.TabIndex = 58
        Me.lblAuto.Text = "Programmed"
        '
        'ctlRelayControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctlRelayControl"
        Me.Size = New System.Drawing.Size(142, 205)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.picRelayStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdTrip As System.Windows.Forms.Button
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblRelayNo As System.Windows.Forms.Label
    Friend WithEvents lblAuto As System.Windows.Forms.Label
    Friend WithEvents lblRelayName As System.Windows.Forms.Label
    Friend WithEvents picRelayStatus As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel

End Class
