<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlPeakLow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlPeakLow))
        Me.cmdResetPeakLow = New System.Windows.Forms.Button
        Me.txtLowLoad = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPeakLoad = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdResetPeakLow
        '
        Me.cmdResetPeakLow.Image = CType(resources.GetObject("cmdResetPeakLow.Image"), System.Drawing.Image)
        Me.cmdResetPeakLow.Location = New System.Drawing.Point(296, 5)
        Me.cmdResetPeakLow.Name = "cmdResetPeakLow"
        Me.cmdResetPeakLow.Size = New System.Drawing.Size(25, 24)
        Me.cmdResetPeakLow.TabIndex = 66
        Me.cmdResetPeakLow.UseVisualStyleBackColor = True
        '
        'txtLowLoad
        '
        Me.txtLowLoad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtLowLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLowLoad.Location = New System.Drawing.Point(199, 4)
        Me.txtLowLoad.Name = "txtLowLoad"
        Me.txtLowLoad.ReadOnly = True
        Me.txtLowLoad.Size = New System.Drawing.Size(87, 26)
        Me.txtLowLoad.TabIndex = 65
        Me.txtLowLoad.TabStop = False
        Me.txtLowLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(156, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 20)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Low:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPeakLoad
        '
        Me.txtPeakLoad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPeakLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeakLoad.Location = New System.Drawing.Point(61, 4)
        Me.txtPeakLoad.Name = "txtPeakLoad"
        Me.txtPeakLoad.ReadOnly = True
        Me.txtPeakLoad.Size = New System.Drawing.Size(87, 26)
        Me.txtPeakLoad.TabIndex = 63
        Me.txtPeakLoad.TabStop = False
        Me.txtPeakLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 20)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Peak:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ctlPeakLow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdResetPeakLow)
        Me.Controls.Add(Me.txtLowLoad)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPeakLoad)
        Me.Controls.Add(Me.Label7)
        Me.Name = "ctlPeakLow"
        Me.Size = New System.Drawing.Size(328, 36)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdResetPeakLow As System.Windows.Forms.Button
    Friend WithEvents txtLowLoad As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPeakLoad As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
