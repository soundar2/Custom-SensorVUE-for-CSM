<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlSensor
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
        Me.components = New System.ComponentModel.Container()
        Me.txtLoad = New System.Windows.Forms.TextBox()
        Me.lblSensorName = New System.Windows.Forms.Label()
        Me.lblNo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuTare = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtLoad
        '
        Me.txtLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLoad.BackColor = System.Drawing.SystemColors.Window
        Me.txtLoad.ContextMenuStrip = Me.ContextMenuStrip1
        Me.txtLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoad.Location = New System.Drawing.Point(155, 14)
        Me.txtLoad.MaxLength = 10
        Me.txtLoad.Name = "txtLoad"
        Me.txtLoad.ReadOnly = True
        Me.txtLoad.Size = New System.Drawing.Size(87, 22)
        Me.txtLoad.TabIndex = 43
        Me.txtLoad.TabStop = False
        Me.txtLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSensorName
        '
        Me.lblSensorName.BackColor = System.Drawing.Color.Transparent
        Me.lblSensorName.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lblSensorName.Location = New System.Drawing.Point(36, 17)
        Me.lblSensorName.Name = "lblSensorName"
        Me.lblSensorName.Size = New System.Drawing.Size(113, 17)
        Me.lblSensorName.TabIndex = 44
        Me.lblSensorName.Text = "..."
        Me.lblSensorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNo
        '
        Me.lblNo.BackColor = System.Drawing.Color.Transparent
        Me.lblNo.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lblNo.Location = New System.Drawing.Point(9, 17)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Size = New System.Drawing.Size(23, 17)
        Me.lblNo.TabIndex = 42
        Me.lblNo.Text = "99."
        Me.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GroupBox1.Controls.Add(Me.txtLoad)
        Me.GroupBox1.Controls.Add(Me.lblNo)
        Me.GroupBox1.Controls.Add(Me.lblSensorName)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 43)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTare})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(99, 26)
        '
        'mnuTare
        '
        Me.mnuTare.Name = "mnuTare"
        Me.mnuTare.Size = New System.Drawing.Size(98, 22)
        Me.mnuTare.Text = "&Zero"
        '
        'ctlSensor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctlSensor"
        Me.Size = New System.Drawing.Size(259, 52)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtLoad As System.Windows.Forms.TextBox
    Friend WithEvents lblSensorName As System.Windows.Forms.Label
    Friend WithEvents lblNo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuTare As System.Windows.Forms.ToolStripMenuItem

End Class
