<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOverlayGraphs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOverlayGraphs))
        Me.pnlButtons = New System.Windows.Forms.Panel
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.CtlQcOverlayTimeGraphs1 = New ctlQcOverlayTimeGraphs
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.cmdBrowse)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 515)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(907, 53)
        Me.pnlButtons.TabIndex = 2
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Image = CType(resources.GetObject("cmdBrowse.Image"), System.Drawing.Image)
        Me.cmdBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBrowse.Location = New System.Drawing.Point(12, 9)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(96, 32)
        Me.cmdBrowse.TabIndex = 28
        Me.cmdBrowse.Text = "Select File..."
        Me.cmdBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'CtlQcOverlayTimeGraphs1
        '
        Me.CtlQcOverlayTimeGraphs1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtlQcOverlayTimeGraphs1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.CtlQcOverlayTimeGraphs1.Location = New System.Drawing.Point(0, 0)
        Me.CtlQcOverlayTimeGraphs1.Name = "CtlQcOverlayTimeGraphs1"
        Me.CtlQcOverlayTimeGraphs1.Size = New System.Drawing.Size(907, 511)
        Me.CtlQcOverlayTimeGraphs1.TabIndex = 1
        '
        'frmOverlayGraphs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 568)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.CtlQcOverlayTimeGraphs1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOverlayGraphs"
        Me.Text = "Overlay Graphs"
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtlQcOverlayTimeGraphs1 As ctlQcOverlayTimeGraphs
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button

End Class
