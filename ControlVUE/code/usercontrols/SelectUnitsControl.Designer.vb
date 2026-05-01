<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectUnitsControl
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
        Me.components = New System.ComponentModel.Container
        Me.lblUnits = New System.Windows.Forms.Label
        Me.mnuUnits = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SuspendLayout()
        '
        'lblUnits
        '
        Me.lblUnits.BackColor = System.Drawing.Color.Transparent
        Me.lblUnits.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblUnits.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnits.ForeColor = System.Drawing.Color.Blue
        Me.lblUnits.Location = New System.Drawing.Point(0, 0)
        Me.lblUnits.Name = "lblUnits"
        Me.lblUnits.Size = New System.Drawing.Size(67, 18)
        Me.lblUnits.TabIndex = 61
        Me.lblUnits.Text = "lb."
        Me.lblUnits.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'mnuUnits
        '
        Me.mnuUnits.Name = "mnuUnits"
        Me.mnuUnits.ShowImageMargin = False
        Me.mnuUnits.ShowItemToolTips = False
        Me.mnuUnits.Size = New System.Drawing.Size(36, 4)
        '
        'SelectUnitsControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblUnits)
        Me.Name = "SelectUnitsControl"
        Me.Size = New System.Drawing.Size(67, 26)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblUnits As System.Windows.Forms.Label
    Friend WithEvents mnuUnits As System.Windows.Forms.ContextMenuStrip

End Class
