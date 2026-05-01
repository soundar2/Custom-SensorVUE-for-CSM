<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FontScalingButton
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
        Me.lblHidden = New System.Windows.Forms.Label()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblHidden
        '
        Me.lblHidden.AutoSize = True
        Me.lblHidden.Location = New System.Drawing.Point(0, 0)
        Me.lblHidden.Name = "lblHidden"
        Me.lblHidden.Size = New System.Drawing.Size(39, 13)
        Me.lblHidden.TabIndex = 0
        Me.lblHidden.Text = "Label1"
        Me.lblHidden.Visible = False
        '
        'btnDisplay
        '
        Me.btnDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDisplay.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnDisplay.FlatAppearance.BorderSize = 4
        Me.btnDisplay.Location = New System.Drawing.Point(0, 0)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(347, 185)
        Me.btnDisplay.TabIndex = 1
        Me.btnDisplay.Text = "Button1"
        Me.btnDisplay.UseVisualStyleBackColor = True
        '
        'FontScalingButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnDisplay)
        Me.Controls.Add(Me.lblHidden)
        Me.Name = "FontScalingButton"
        Me.Size = New System.Drawing.Size(347, 185)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblHidden As System.Windows.Forms.Label
    Friend WithEvents btnDisplay As System.Windows.Forms.Button

End Class
