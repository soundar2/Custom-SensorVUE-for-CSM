<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQcGraph
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQcGraph))
        Me.mnuGraphHdr = New System.Windows.Forms.MenuStrip()
        Me.mnuGraphSubdr = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGraphOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintGraphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextGraphHdr = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuGraphOptions2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCopyGraph2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintGraph2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlTimeGraph = New System.Windows.Forms.Panel()
        Me.timeGraph = New LoadVUE.ctlQcTimeXGraph()
        Me.pnlLinearXGraph = New System.Windows.Forms.Panel()
        Me.linearGraph = New LoadVUE.ctlQcLinearXGraph()
        Me.mnuGraphHdr.SuspendLayout()
        Me.mnuContextGraphHdr.SuspendLayout()
        Me.pnlTimeGraph.SuspendLayout()
        Me.pnlLinearXGraph.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuGraphHdr
        '
        Me.mnuGraphHdr.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuGraphHdr.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGraphSubdr})
        Me.mnuGraphHdr.Location = New System.Drawing.Point(0, 0)
        Me.mnuGraphHdr.Name = "mnuGraphHdr"
        Me.mnuGraphHdr.Size = New System.Drawing.Size(636, 29)
        Me.mnuGraphHdr.TabIndex = 2
        Me.mnuGraphHdr.Text = "&Graph"
        Me.mnuGraphHdr.Visible = False
        '
        'mnuGraphSubdr
        '
        Me.mnuGraphSubdr.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGraphOptions, Me.CopyToClipboardToolStripMenuItem, Me.PrintGraphToolStripMenuItem})
        Me.mnuGraphSubdr.MergeAction = System.Windows.Forms.MergeAction.Replace
        Me.mnuGraphSubdr.MergeIndex = 2
        Me.mnuGraphSubdr.Name = "mnuGraphSubdr"
        Me.mnuGraphSubdr.Size = New System.Drawing.Size(65, 25)
        Me.mnuGraphSubdr.Text = "&Graph"
        '
        'mnuGraphOptions
        '
        Me.mnuGraphOptions.Name = "mnuGraphOptions"
        Me.mnuGraphOptions.Size = New System.Drawing.Size(216, 26)
        Me.mnuGraphOptions.Text = "&Graph Options..."
        '
        'CopyToClipboardToolStripMenuItem
        '
        Me.CopyToClipboardToolStripMenuItem.Name = "CopyToClipboardToolStripMenuItem"
        Me.CopyToClipboardToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.CopyToClipboardToolStripMenuItem.Text = "&Copy to clipboard ..."
        '
        'PrintGraphToolStripMenuItem
        '
        Me.PrintGraphToolStripMenuItem.Name = "PrintGraphToolStripMenuItem"
        Me.PrintGraphToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.PrintGraphToolStripMenuItem.Text = "&Print Graph..."
        '
        'mnuContextGraphHdr
        '
        Me.mnuContextGraphHdr.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGraphOptions2, Me.ToolStripSeparator6, Me.mnuCopyGraph2, Me.mnuPrintGraph2})
        Me.mnuContextGraphHdr.Name = "mnuCopyGraphHdr"
        Me.mnuContextGraphHdr.Size = New System.Drawing.Size(170, 76)
        '
        'mnuGraphOptions2
        '
        Me.mnuGraphOptions2.Image = Global.LoadVUE.My.Resources.Resources.wrench_settings2
        Me.mnuGraphOptions2.Name = "mnuGraphOptions2"
        Me.mnuGraphOptions2.Size = New System.Drawing.Size(169, 22)
        Me.mnuGraphOptions2.Text = "&Graph Options..."
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(166, 6)
        '
        'mnuCopyGraph2
        '
        Me.mnuCopyGraph2.Image = Global.LoadVUE.My.Resources.Resources.copy_to_clipboard
        Me.mnuCopyGraph2.Name = "mnuCopyGraph2"
        Me.mnuCopyGraph2.Size = New System.Drawing.Size(169, 22)
        Me.mnuCopyGraph2.Text = "&Copy to clipboard"
        '
        'mnuPrintGraph2
        '
        Me.mnuPrintGraph2.Image = Global.LoadVUE.My.Resources.Resources.print
        Me.mnuPrintGraph2.Name = "mnuPrintGraph2"
        Me.mnuPrintGraph2.Size = New System.Drawing.Size(169, 22)
        Me.mnuPrintGraph2.Text = "&Print Graph..."
        '
        'pnlTimeGraph
        '
        Me.pnlTimeGraph.Controls.Add(Me.timeGraph)
        Me.pnlTimeGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTimeGraph.Location = New System.Drawing.Point(0, 29)
        Me.pnlTimeGraph.Name = "pnlTimeGraph"
        Me.pnlTimeGraph.Size = New System.Drawing.Size(636, 485)
        Me.pnlTimeGraph.TabIndex = 3
        Me.pnlTimeGraph.Visible = False
        '
        'timeGraph
        '
        Me.timeGraph.BackColor = System.Drawing.Color.Peru
        Me.timeGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.timeGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.timeGraph.Location = New System.Drawing.Point(0, 0)
        Me.timeGraph.Name = "timeGraph"
        Me.timeGraph.Size = New System.Drawing.Size(636, 485)
        Me.timeGraph.TabIndex = 0
        '
        'pnlLinearXGraph
        '
        Me.pnlLinearXGraph.Controls.Add(Me.linearGraph)
        Me.pnlLinearXGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLinearXGraph.Location = New System.Drawing.Point(0, 29)
        Me.pnlLinearXGraph.Name = "pnlLinearXGraph"
        Me.pnlLinearXGraph.Size = New System.Drawing.Size(636, 485)
        Me.pnlLinearXGraph.TabIndex = 4
        Me.pnlLinearXGraph.Visible = False
        '
        'linearGraph
        '
        Me.linearGraph.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.linearGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.linearGraph.Location = New System.Drawing.Point(0, 0)
        Me.linearGraph.Name = "linearGraph"
        Me.linearGraph.Size = New System.Drawing.Size(636, 485)
        Me.linearGraph.TabIndex = 1
        '
        'frmQcGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 514)
        Me.Controls.Add(Me.pnlTimeGraph)
        Me.Controls.Add(Me.pnlLinearXGraph)
        Me.Controls.Add(Me.mnuGraphHdr)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuGraphHdr
        Me.Name = "frmQcGraph"
        Me.Text = "frmQcGraph"
        Me.mnuGraphHdr.ResumeLayout(False)
        Me.mnuGraphHdr.PerformLayout()
        Me.mnuContextGraphHdr.ResumeLayout(False)
        Me.pnlTimeGraph.ResumeLayout(False)
        Me.pnlLinearXGraph.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents timeGraph As LoadVUE.ctlQcTimeXGraph
    Friend WithEvents linearGraph As LoadVUE.ctlQcLinearXGraph
    Friend WithEvents mnuGraphHdr As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuGraphSubdr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToClipboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintGraphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextGraphHdr As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCopyGraph2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintGraph2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuGraphOptions2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlTimeGraph As System.Windows.Forms.Panel
    Friend WithEvents pnlLinearXGraph As System.Windows.Forms.Panel
    Friend WithEvents mnuGraphOptions As System.Windows.Forms.ToolStripMenuItem
End Class
