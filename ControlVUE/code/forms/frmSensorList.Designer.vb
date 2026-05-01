<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSensorList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSensorList))
        Me.dgvSensors = New System.Windows.Forms.DataGridView()
        Me.colSs1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConnection = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFirmware = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.txtFirmware = New System.Windows.Forms.TextBox()
        CType(Me.dgvSensors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSensors
        '
        Me.dgvSensors.AllowUserToAddRows = False
        Me.dgvSensors.AllowUserToDeleteRows = False
        Me.dgvSensors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvSensors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSensors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSs1, Me.colType, Me.colConnection, Me.colFirmware})
        Me.dgvSensors.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgvSensors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvSensors.Location = New System.Drawing.Point(0, 0)
        Me.dgvSensors.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvSensors.MultiSelect = False
        Me.dgvSensors.Name = "dgvSensors"
        Me.dgvSensors.RowHeadersVisible = False
        Me.dgvSensors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSensors.Size = New System.Drawing.Size(423, 373)
        Me.dgvSensors.TabIndex = 33
        '
        'colSs1
        '
        Me.colSs1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colSs1.HeaderText = "Name"
        Me.colSs1.Name = "colSs1"
        Me.colSs1.ReadOnly = True
        Me.colSs1.Width = 70
        '
        'colType
        '
        Me.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colType.HeaderText = "Type"
        Me.colType.Name = "colType"
        Me.colType.ReadOnly = True
        Me.colType.Width = 65
        '
        'colConnection
        '
        Me.colConnection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colConnection.HeaderText = "Connection"
        Me.colConnection.Name = "colConnection"
        Me.colConnection.ReadOnly = True
        '
        'colFirmware
        '
        Me.colFirmware.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colFirmware.HeaderText = "Firmware"
        Me.colFirmware.Name = "colFirmware"
        Me.colFirmware.Width = 69
        '
        'txtFirmware
        '
        Me.txtFirmware.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirmware.Location = New System.Drawing.Point(431, 0)
        Me.txtFirmware.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFirmware.Multiline = True
        Me.txtFirmware.Name = "txtFirmware"
        Me.txtFirmware.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFirmware.Size = New System.Drawing.Size(311, 373)
        Me.txtFirmware.TabIndex = 34
        '
        'frmSensorList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 373)
        Me.Controls.Add(Me.txtFirmware)
        Me.Controls.Add(Me.dgvSensors)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimizeBox = False
        Me.Name = "frmSensorList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sensors and/or Interfaces"
        CType(Me.dgvSensors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvSensors As System.Windows.Forms.DataGridView
    Friend WithEvents colSs1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConnection As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFirmware As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents txtFirmware As System.Windows.Forms.TextBox
End Class
