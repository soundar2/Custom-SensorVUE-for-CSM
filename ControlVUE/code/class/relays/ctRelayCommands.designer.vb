<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctRelayCommands
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
        Dim RelayCommand1 As RelayCommand = New RelayCommand
        Me.CtlRelayCommand0 = New ctlRelayCommand
        Me.SuspendLayout()
        '
        'CtlRelayCommand0
        '
        Me.CtlRelayCommand0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CtlRelayCommand0.CommandEnabled = True
        Me.CtlRelayCommand0.Location = New System.Drawing.Point(0, 0)
        Me.CtlRelayCommand0.Name = "CtlRelayCommand0"
        Me.CtlRelayCommand0.Size = New System.Drawing.Size(495, 44)
        Me.CtlRelayCommand0.TabIndex = 0
        Me.CtlRelayCommand0.Units = Nothing
        '
        'ctRelayCommands
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.CtlRelayCommand0)
        Me.Name = "ctRelayCommands"
        Me.Size = New System.Drawing.Size(574, 293)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtlRelayCommand0 As ctlRelayCommand

End Class
