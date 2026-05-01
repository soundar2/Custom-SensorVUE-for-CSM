<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNoSensors
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNoSensors))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdDeviceManager = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmdTeamviewer = New System.Windows.Forms.Button()
        Me.cmdPutty = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Image = Global.LoadVUE.My.Resources.Resources.cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(356, 208)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(111, 36)
        Me.cmdCancel.TabIndex = 17
        Me.cmdCancel.Text = "Abort"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Retry
        Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Image = Global.LoadVUE.My.Resources.Resources.retry_2
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(239, 208)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(111, 36)
        Me.cmdOK.TabIndex = 16
        Me.cmdOK.Text = "Retry"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(126, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(296, 24)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "No sensors or interfaces detected."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(127, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 18)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Troubleshooting Guide"
        '
        'cmdDeviceManager
        '
        Me.cmdDeviceManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeviceManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDeviceManager.Location = New System.Drawing.Point(12, 112)
        Me.cmdDeviceManager.Name = "cmdDeviceManager"
        Me.cmdDeviceManager.Size = New System.Drawing.Size(187, 36)
        Me.cmdDeviceManager.TabIndex = 20
        Me.cmdDeviceManager.Text = "Device Manager"
        Me.cmdDeviceManager.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDeviceManager.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(99, 94)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'cmdTeamviewer
        '
        Me.cmdTeamviewer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTeamviewer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdTeamviewer.Location = New System.Drawing.Point(12, 208)
        Me.cmdTeamviewer.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdTeamviewer.Name = "cmdTeamviewer"
        Me.cmdTeamviewer.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.cmdTeamviewer.Size = New System.Drawing.Size(187, 36)
        Me.cmdTeamviewer.TabIndex = 37
        Me.cmdTeamviewer.Text = "&Remote Support"
        Me.cmdTeamviewer.UseVisualStyleBackColor = True
        '
        'cmdPutty
        '
        Me.cmdPutty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPutty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPutty.Location = New System.Drawing.Point(12, 160)
        Me.cmdPutty.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.cmdPutty.Name = "cmdPutty"
        Me.cmdPutty.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.cmdPutty.Size = New System.Drawing.Size(187, 36)
        Me.cmdPutty.TabIndex = 36
        Me.cmdPutty.Text = "Terminal Program"
        Me.cmdPutty.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(126, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(282, 24)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Please check your device setup."
        '
        'frmNoSensors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 254)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdTeamviewer)
        Me.Controls.Add(Me.cmdPutty)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmdDeviceManager)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "frmNoSensors"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sensor/Interface not Found"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdDeviceManager As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdTeamviewer As System.Windows.Forms.Button
    Friend WithEvents cmdPutty As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
