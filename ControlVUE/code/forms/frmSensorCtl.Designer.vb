<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSensorCtl
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSensorCtl))
        Me.TimerDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.CtlScalingSensor1 = New LoadVUE.ctlScalingSensor()
        Me.SuspendLayout()
        '
        'TimerDisplay
        '
        Me.TimerDisplay.Interval = 500
        '
        'CtlScalingSensor1
        '
        Me.CtlScalingSensor1.BackgroundColor = System.Drawing.Color.Empty
        Me.CtlScalingSensor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtlScalingSensor1.Location = New System.Drawing.Point(0, 0)
        Me.CtlScalingSensor1.Name = "CtlScalingSensor1"
        Me.CtlScalingSensor1.Sensor = Nothing
        Me.CtlScalingSensor1.Size = New System.Drawing.Size(415, 163)
        Me.CtlScalingSensor1.SS1 = ""
        Me.CtlScalingSensor1.TabIndex = 0
        Me.CtlScalingSensor1.TextColor = System.Drawing.Color.Empty
        Me.CtlScalingSensor1.Units = "lblUnits"
        '
        'frmSensorCtl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 163)
        Me.Controls.Add(Me.CtlScalingSensor1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSensorCtl"
        Me.Text = "frmSensorCtl"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtlScalingSensor1 As LoadVUE.ctlScalingSensor
    Friend WithEvents TimerDisplay As System.Windows.Forms.Timer
End Class
