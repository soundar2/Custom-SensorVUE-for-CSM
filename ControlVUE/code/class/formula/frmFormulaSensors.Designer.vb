<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFormulaSensors
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
        Me.tvFormula = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.dgvSensors = New System.Windows.Forms.DataGridView()
        Me.symbol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sensor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFormula = New System.Windows.Forms.TextBox()
        Me.picFormulaVerify = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUnits = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.dgvSensors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFormulaVerify, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tvFormula
        '
        Me.tvFormula.HideSelection = False
        Me.tvFormula.Location = New System.Drawing.Point(12, 256)
        Me.tvFormula.Name = "tvFormula"
        Me.tvFormula.Size = New System.Drawing.Size(178, 175)
        Me.tvFormula.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(205, 259)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Na&me:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(252, 279)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "(Example: Stress, Moment)"
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(255, 256)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(182, 20)
        Me.txtName.TabIndex = 2
        '
        'dgvSensors
        '
        Me.dgvSensors.AllowUserToAddRows = False
        Me.dgvSensors.AllowUserToDeleteRows = False
        Me.dgvSensors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvSensors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSensors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.symbol, Me.sensor})
        Me.dgvSensors.Location = New System.Drawing.Point(12, 30)
        Me.dgvSensors.Name = "dgvSensors"
        Me.dgvSensors.RowHeadersVisible = False
        Me.dgvSensors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSensors.Size = New System.Drawing.Size(476, 198)
        Me.dgvSensors.TabIndex = 9
        Me.dgvSensors.TabStop = False
        '
        'symbol
        '
        Me.symbol.HeaderText = "Symbol"
        Me.symbol.Name = "symbol"
        Me.symbol.ReadOnly = True
        Me.symbol.Width = 66
        '
        'sensor
        '
        Me.sensor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.sensor.HeaderText = "Sensor"
        Me.sensor.Name = "sensor"
        Me.sensor.ReadOnly = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Image = Global.LoadVUE.My.Resources.Resources.delete_minus
        Me.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDelete.Location = New System.Drawing.Point(106, 437)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(84, 36)
        Me.cmdDelete.TabIndex = 8
        Me.cmdDelete.Text = "&Delete..."
        Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Image = Global.LoadVUE.My.Resources.Resources.new_plus
        Me.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdNew.Location = New System.Drawing.Point(12, 437)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(84, 36)
        Me.cmdNew.TabIndex = 7
        Me.cmdNew.Text = "&New"
        Me.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Image = Global.LoadVUE.My.Resources.Resources.cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(409, 437)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(79, 36)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Image = Global.LoadVUE.My.Resources.Resources.ok
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(324, 437)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(79, 36)
        Me.cmdOK.TabIndex = 10
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(202, 303)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "&Formula:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(255, 335)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(196, 15)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Example: (S1+S2)-(S3/S4)*S1"
        '
        'txtFormula
        '
        Me.txtFormula.Enabled = False
        Me.txtFormula.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormula.Location = New System.Drawing.Point(255, 308)
        Me.txtFormula.MaxLength = 250
        Me.txtFormula.Name = "txtFormula"
        Me.txtFormula.Size = New System.Drawing.Size(212, 24)
        Me.txtFormula.TabIndex = 4
        '
        'picFormulaVerify
        '
        Me.picFormulaVerify.Image = Global.LoadVUE.My.Resources.Resources.formula_error
        Me.picFormulaVerify.Location = New System.Drawing.Point(473, 308)
        Me.picFormulaVerify.Name = "picFormulaVerify"
        Me.picFormulaVerify.Size = New System.Drawing.Size(20, 20)
        Me.picFormulaVerify.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picFormulaVerify.TabIndex = 25
        Me.picFormulaVerify.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Use the following symbols:"
        '
        'txtUnits
        '
        Me.txtUnits.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnits.Location = New System.Drawing.Point(255, 389)
        Me.txtUnits.MaxLength = 20
        Me.txtUnits.Name = "txtUnits"
        Me.txtUnits.Size = New System.Drawing.Size(78, 24)
        Me.txtUnits.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(202, 393)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "&Units:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(252, 416)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 15)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Example: psi, MPa, g/cc"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 238)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Formula List"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(255, 350)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(175, 15)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Only use +-*/ operations"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(255, 365)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 15)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "and parantheses."
        '
        'frmFormulaSensors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 483)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtUnits)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.picFormulaVerify)
        Me.Controls.Add(Me.txtFormula)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdNew)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.dgvSensors)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tvFormula)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFormulaSensors"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Formula Sensors"
        CType(Me.dgvSensors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFormulaVerify, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tvFormula As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents dgvSensors As System.Windows.Forms.DataGridView
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFormula As System.Windows.Forms.TextBox
    Friend WithEvents picFormulaVerify As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents symbol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sensor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
