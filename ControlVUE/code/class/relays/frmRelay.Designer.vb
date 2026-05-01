<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRelay))
        Me.cmdClearLog = New System.Windows.Forms.Button()
        Me.colValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colChannel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvAction = New System.Windows.Forms.DataGridView()
        Me.tabRelayLog = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdRelaySettings = New System.Windows.Forms.Button()
        Me.relayLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.tabRelayStatus = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.CtlRelayControl0 = New LoadVUE.ctlRelayControl()
        CType(Me.dgvAction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabRelayLog.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.relayLayoutPanel.SuspendLayout()
        Me.tabRelayStatus.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdClearLog
        '
        Me.cmdClearLog.Image = CType(resources.GetObject("cmdClearLog.Image"), System.Drawing.Image)
        Me.cmdClearLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdClearLog.Location = New System.Drawing.Point(2, 2)
        Me.cmdClearLog.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdClearLog.Name = "cmdClearLog"
        Me.cmdClearLog.Size = New System.Drawing.Size(77, 22)
        Me.cmdClearLog.TabIndex = 3
        Me.cmdClearLog.Text = "Clear Relay Log"
        Me.cmdClearLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdClearLog.UseVisualStyleBackColor = True
        '
        'colValue
        '
        Me.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colValue.HeaderText = "Value"
        Me.colValue.Name = "colValue"
        Me.colValue.ReadOnly = True
        Me.colValue.Width = 84
        '
        'colAction
        '
        Me.colAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colAction.HeaderText = "Action"
        Me.colAction.Name = "colAction"
        Me.colAction.ReadOnly = True
        Me.colAction.Width = 88
        '
        'colChannel
        '
        Me.colChannel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colChannel.HeaderText = "Channel"
        Me.colChannel.Name = "colChannel"
        Me.colChannel.ReadOnly = True
        Me.colChannel.Width = 106
        '
        'dgvAction
        '
        Me.dgvAction.AllowUserToAddRows = False
        Me.dgvAction.AllowUserToDeleteRows = False
        Me.dgvAction.AllowUserToOrderColumns = True
        Me.dgvAction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvAction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAction.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colChannel, Me.colAction, Me.colValue})
        Me.dgvAction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAction.Location = New System.Drawing.Point(2, 29)
        Me.dgvAction.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvAction.MultiSelect = False
        Me.dgvAction.Name = "dgvAction"
        Me.dgvAction.ReadOnly = True
        Me.dgvAction.RowHeadersVisible = False
        Me.dgvAction.Size = New System.Drawing.Size(812, 407)
        Me.dgvAction.TabIndex = 1
        '
        'tabRelayLog
        '
        Me.tabRelayLog.Controls.Add(Me.dgvAction)
        Me.tabRelayLog.Controls.Add(Me.Panel2)
        Me.tabRelayLog.Location = New System.Drawing.Point(4, 22)
        Me.tabRelayLog.Margin = New System.Windows.Forms.Padding(2)
        Me.tabRelayLog.Name = "tabRelayLog"
        Me.tabRelayLog.Padding = New System.Windows.Forms.Padding(2)
        Me.tabRelayLog.Size = New System.Drawing.Size(816, 438)
        Me.tabRelayLog.TabIndex = 1
        Me.tabRelayLog.Text = "Relay Log"
        Me.tabRelayLog.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmdClearLog)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(2, 2)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(812, 27)
        Me.Panel2.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdRelaySettings)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(812, 57)
        Me.Panel1.TabIndex = 4
        '
        'cmdRelaySettings
        '
        Me.cmdRelaySettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRelaySettings.Image = CType(resources.GetObject("cmdRelaySettings.Image"), System.Drawing.Image)
        Me.cmdRelaySettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRelaySettings.Location = New System.Drawing.Point(2, 2)
        Me.cmdRelaySettings.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdRelaySettings.Name = "cmdRelaySettings"
        Me.cmdRelaySettings.Size = New System.Drawing.Size(142, 48)
        Me.cmdRelaySettings.TabIndex = 1
        Me.cmdRelaySettings.Text = "Settings..."
        Me.cmdRelaySettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdRelaySettings.UseVisualStyleBackColor = True
        '
        'relayLayoutPanel
        '
        Me.relayLayoutPanel.AutoScroll = True
        Me.relayLayoutPanel.Controls.Add(Me.CtlRelayControl0)
        Me.relayLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.relayLayoutPanel.Location = New System.Drawing.Point(2, 59)
        Me.relayLayoutPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.relayLayoutPanel.Name = "relayLayoutPanel"
        Me.relayLayoutPanel.Size = New System.Drawing.Size(812, 366)
        Me.relayLayoutPanel.TabIndex = 5
        '
        'tabRelayStatus
        '
        Me.tabRelayStatus.Controls.Add(Me.relayLayoutPanel)
        Me.tabRelayStatus.Controls.Add(Me.Panel1)
        Me.tabRelayStatus.Location = New System.Drawing.Point(4, 33)
        Me.tabRelayStatus.Margin = New System.Windows.Forms.Padding(2)
        Me.tabRelayStatus.Name = "tabRelayStatus"
        Me.tabRelayStatus.Padding = New System.Windows.Forms.Padding(2)
        Me.tabRelayStatus.Size = New System.Drawing.Size(816, 427)
        Me.tabRelayStatus.TabIndex = 0
        Me.tabRelayStatus.Text = "Relay Status"
        Me.tabRelayStatus.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabRelayStatus)
        Me.TabControl1.Controls.Add(Me.tabRelayLog)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(824, 464)
        Me.TabControl1.TabIndex = 5
        '
        'CtlRelayControl0
        '
        Me.CtlRelayControl0.BackColor = System.Drawing.SystemColors.Control
        Me.CtlRelayControl0.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtlRelayControl0.IsProgramControlled = False
        Me.CtlRelayControl0.Location = New System.Drawing.Point(4, 4)
        Me.CtlRelayControl0.Margin = New System.Windows.Forms.Padding(4)
        Me.CtlRelayControl0.Name = "CtlRelayControl0"
        Me.CtlRelayControl0.RelayIndex = CType(0, Byte)
        Me.CtlRelayControl0.RelayName = "..."
        Me.CtlRelayControl0.Size = New System.Drawing.Size(140, 200)
        Me.CtlRelayControl0.TabIndex = 0
        '
        'frmRelay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 464)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmRelay"
        Me.Text = "frmRelay"
        CType(Me.dgvAction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabRelayLog.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.relayLayoutPanel.ResumeLayout(False)
        Me.tabRelayStatus.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdClearLog As Button
    Friend WithEvents colValue As DataGridViewTextBoxColumn
    Friend WithEvents colAction As DataGridViewTextBoxColumn
    Friend WithEvents CtlRelayControl0 As ctlRelayControl
    Friend WithEvents colChannel As DataGridViewTextBoxColumn
    Friend WithEvents dgvAction As DataGridView
    Friend WithEvents tabRelayLog As TabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmdRelaySettings As Button
    Friend WithEvents relayLayoutPanel As FlowLayoutPanel
    Friend WithEvents tabRelayStatus As TabPage
    Friend WithEvents TabControl1 As TabControl
End Class
