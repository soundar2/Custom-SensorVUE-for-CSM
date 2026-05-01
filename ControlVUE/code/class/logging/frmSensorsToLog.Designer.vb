<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSensorsToLog
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
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.dgvLog = New System.Windows.Forms.DataGridView()
        Me.check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ss1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkLogUdf = New System.Windows.Forms.CheckBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Image = Global.LoadVUE.My.Resources.Resources.cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(464, 320)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(145, 48)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Image = Global.LoadVUE.My.Resources.Resources.ok
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(308, 320)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(145, 48)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "OK"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'dgvLog
        '
        Me.dgvLog.AllowUserToAddRows = False
        Me.dgvLog.AllowUserToDeleteRows = False
        Me.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.check, Me.ss1, Me.sType})
        Me.dgvLog.Location = New System.Drawing.Point(28, 46)
        Me.dgvLog.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.dgvLog.MultiSelect = False
        Me.dgvLog.Name = "dgvLog"
        Me.dgvLog.RowHeadersVisible = False
        Me.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLog.Size = New System.Drawing.Size(581, 251)
        Me.dgvLog.TabIndex = 1
        '
        'check
        '
        Me.check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.check.DataPropertyName = "check"
        Me.check.HeaderText = "Select"
        Me.check.Name = "check"
        Me.check.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.check.Width = 87
        '
        'ss1
        '
        Me.ss1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ss1.DataPropertyName = "SS1"
        Me.ss1.HeaderText = "Name"
        Me.ss1.Name = "ss1"
        Me.ss1.ReadOnly = True
        '
        'sType
        '
        Me.sType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.sType.DataPropertyName = "sType"
        Me.sType.HeaderText = "Type"
        Me.sType.Name = "sType"
        Me.sType.ReadOnly = True
        Me.sType.Width = 78
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(387, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select sensors and/or peak/low values to log."
        '
        'chkLogUdf
        '
        Me.chkLogUdf.AutoSize = True
        Me.chkLogUdf.Location = New System.Drawing.Point(27, 320)
        Me.chkLogUdf.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.chkLogUdf.Name = "chkLogUdf"
        Me.chkLogUdf.Size = New System.Drawing.Size(258, 28)
        Me.chkLogUdf.TabIndex = 2
        Me.chkLogUdf.Text = "Also log User Defined Field"
        Me.chkLogUdf.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(27, 360)
        Me.chkAll.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(156, 28)
        Me.chkAll.TabIndex = 3
        Me.chkAll.Text = "Select/Clear All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'frmSensorsToLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 398)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.chkLogUdf)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvLog)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSensorsToLog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Sensors to Log"
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents dgvLog As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkLogUdf As System.Windows.Forms.CheckBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents check As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ss1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sType As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
