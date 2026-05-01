<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DecimalPlacesControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DecimalPlacesControl))
        Me.cmdDecreaseDecimals = New System.Windows.Forms.Button
        Me.cmdIncreaseDecimals = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdDecreaseDecimals
        '
        Me.cmdDecreaseDecimals.Image = CType(resources.GetObject("cmdDecreaseDecimals.Image"), System.Drawing.Image)
        Me.cmdDecreaseDecimals.Location = New System.Drawing.Point(0, 26)
        Me.cmdDecreaseDecimals.Name = "cmdDecreaseDecimals"
        Me.cmdDecreaseDecimals.Size = New System.Drawing.Size(25, 24)
        Me.cmdDecreaseDecimals.TabIndex = 57
        Me.cmdDecreaseDecimals.UseVisualStyleBackColor = True
        '
        'cmdIncreaseDecimals
        '
        Me.cmdIncreaseDecimals.Image = CType(resources.GetObject("cmdIncreaseDecimals.Image"), System.Drawing.Image)
        Me.cmdIncreaseDecimals.Location = New System.Drawing.Point(0, 0)
        Me.cmdIncreaseDecimals.Name = "cmdIncreaseDecimals"
        Me.cmdIncreaseDecimals.Size = New System.Drawing.Size(25, 24)
        Me.cmdIncreaseDecimals.TabIndex = 56
        Me.cmdIncreaseDecimals.UseVisualStyleBackColor = True
        '
        'DecimalPlacesControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdDecreaseDecimals)
        Me.Controls.Add(Me.cmdIncreaseDecimals)
        Me.Name = "DecimalPlacesControl"
        Me.Size = New System.Drawing.Size(64, 55)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdDecreaseDecimals As System.Windows.Forms.Button
    Friend WithEvents cmdIncreaseDecimals As System.Windows.Forms.Button

End Class
