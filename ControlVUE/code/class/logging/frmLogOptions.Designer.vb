<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogOptions))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkGraphLoggedOnly = New System.Windows.Forms.CheckBox()
        Me.cmdSelectSensors = New System.Windows.Forms.Button()
        Me.chkDontLog = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUdf = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(52, 104)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(406, 24)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "(Select this option if logging for a long duration.)"
        '
        'chkGraphLoggedOnly
        '
        Me.chkGraphLoggedOnly.AutoSize = True
        Me.chkGraphLoggedOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGraphLoggedOnly.Location = New System.Drawing.Point(15, 156)
        Me.chkGraphLoggedOnly.Margin = New System.Windows.Forms.Padding(6)
        Me.chkGraphLoggedOnly.Name = "chkGraphLoggedOnly"
        Me.chkGraphLoggedOnly.Size = New System.Drawing.Size(263, 28)
        Me.chkGraphLoggedOnly.TabIndex = 68
        Me.chkGraphLoggedOnly.Text = "Graph logged readings only"
        Me.chkGraphLoggedOnly.UseVisualStyleBackColor = True
        '
        'cmdSelectSensors
        '
        Me.cmdSelectSensors.Image = CType(resources.GetObject("cmdSelectSensors.Image"), System.Drawing.Image)
        Me.cmdSelectSensors.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSelectSensors.Location = New System.Drawing.Point(15, 15)
        Me.cmdSelectSensors.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdSelectSensors.Name = "cmdSelectSensors"
        Me.cmdSelectSensors.Size = New System.Drawing.Size(253, 39)
        Me.cmdSelectSensors.TabIndex = 66
        Me.cmdSelectSensors.Text = "Select Sensors to Log..."
        Me.cmdSelectSensors.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSelectSensors.UseVisualStyleBackColor = True
        '
        'chkDontLog
        '
        Me.chkDontLog.AutoSize = True
        Me.chkDontLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDontLog.Location = New System.Drawing.Point(15, 79)
        Me.chkDontLog.Margin = New System.Windows.Forms.Padding(6)
        Me.chkDontLog.Name = "chkDontLog"
        Me.chkDontLog.Size = New System.Drawing.Size(381, 28)
        Me.chkDontLog.TabIndex = 67
        Me.chkDontLog.Text = "Turn off logging to screen (Log to file only)"
        Me.chkDontLog.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 224)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(271, 24)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "User Defined Parameter Name:"
        '
        'txtUdf
        '
        Me.txtUdf.BackColor = System.Drawing.Color.White
        Me.txtUdf.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUdf.Location = New System.Drawing.Point(291, 224)
        Me.txtUdf.Margin = New System.Windows.Forms.Padding(6)
        Me.txtUdf.Name = "txtUdf"
        Me.txtUdf.Size = New System.Drawing.Size(266, 29)
        Me.txtUdf.TabIndex = 72
        Me.txtUdf.TabStop = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Image = Global.LoadVUE.My.Resources.Resources.ok
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(349, 264)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(100, 44)
        Me.cmdOK.TabIndex = 73
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
        Me.cmdCancel.Location = New System.Drawing.Point(457, 264)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 44)
        Me.cmdCancel.TabIndex = 74
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'frmLogOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 319)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtUdf)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkGraphLoggedOnly)
        Me.Controls.Add(Me.cmdSelectSensors)
        Me.Controls.Add(Me.chkDontLog)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogOptions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Log Options"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkGraphLoggedOnly As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSelectSensors As System.Windows.Forms.Button
    Friend WithEvents chkDontLog As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUdf As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
