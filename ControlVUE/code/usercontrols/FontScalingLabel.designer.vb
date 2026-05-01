<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FontScalingLabel
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
        Me.lblHidden = New System.Windows.Forms.Label
        Me.lblDisplay = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblHidden
        '
        Me.lblHidden.AutoSize = True
        Me.lblHidden.BackColor = System.Drawing.Color.Transparent
        Me.lblHidden.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHidden.Location = New System.Drawing.Point(3, 0)
        Me.lblHidden.Name = "lblHidden"
        Me.lblHidden.Size = New System.Drawing.Size(442, 108)
        Me.lblHidden.TabIndex = 1
        Me.lblHidden.Text = "lblHidden"
        Me.lblHidden.Visible = False
        '
        'lblDisplay
        '
        Me.lblDisplay.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDisplay.Location = New System.Drawing.Point(0, 0)
        Me.lblDisplay.Name = "lblDisplay"
        Me.lblDisplay.Size = New System.Drawing.Size(834, 429)
        Me.lblDisplay.TabIndex = 2
        Me.lblDisplay.Text = "Label1"
        Me.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FontScalingLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblHidden)
        Me.Controls.Add(Me.lblDisplay)
        Me.Name = "FontScalingLabel"
        Me.Size = New System.Drawing.Size(834, 429)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblHidden As System.Windows.Forms.Label
    Friend WithEvents lblDisplay As System.Windows.Forms.Label

End Class
