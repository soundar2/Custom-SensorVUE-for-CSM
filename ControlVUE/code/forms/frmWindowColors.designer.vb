<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWindowColors
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
        Me.dgvColors = New System.Windows.Forms.DataGridView()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.y1Ss1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.y1Color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.y1cmdColor = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.y1CmdBackColor = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.y1TextAlignment = New System.Windows.Forms.DataGridViewComboBoxColumn()
        CType(Me.dgvColors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvColors
        '
        Me.dgvColors.AllowUserToAddRows = False
        Me.dgvColors.AllowUserToDeleteRows = False
        Me.dgvColors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvColors.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvColors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.y1Ss1, Me.y1Color, Me.y1cmdColor, Me.y1CmdBackColor, Me.y1TextAlignment})
        Me.dgvColors.Location = New System.Drawing.Point(9, 4)
        Me.dgvColors.Margin = New System.Windows.Forms.Padding(6)
        Me.dgvColors.Name = "dgvColors"
        Me.dgvColors.RowHeadersVisible = False
        Me.dgvColors.Size = New System.Drawing.Size(784, 419)
        Me.dgvColors.TabIndex = 0
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(26, 36)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(77, 17)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Cumulative"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(26, 13)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(65, 17)
        Me.RadioButton2.TabIndex = 0
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Scrolling"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CheckedListBox1)
        Me.Panel1.Location = New System.Drawing.Point(49, 144)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(416, 209)
        Me.Panel1.TabIndex = 5
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(3, 3)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(186, 109)
        Me.CheckedListBox1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.RadioButton1)
        Me.Panel2.Controls.Add(Me.RadioButton2)
        Me.Panel2.Location = New System.Drawing.Point(49, 44)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(279, 62)
        Me.Panel2.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(211, 13)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(50, 20)
        Me.TextBox1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(107, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Time Range (sec.):"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(27, 121)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(251, 17)
        Me.RadioButton3.TabIndex = 1
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Show one of the following sensors on the X-Axis"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(27, 21)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(125, 17)
        Me.RadioButton4.TabIndex = 0
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Show Time on X-Axis"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Image = Global.LoadVUE.My.Resources.Resources.cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(684, 435)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(109, 36)
        Me.cmdCancel.TabIndex = 15
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Image = Global.LoadVUE.My.Resources.Resources.ok
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(563, 435)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(109, 36)
        Me.cmdOK.TabIndex = 14
        Me.cmdOK.Text = "OK"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'y1Ss1
        '
        Me.y1Ss1.HeaderText = "Name"
        Me.y1Ss1.Name = "y1Ss1"
        Me.y1Ss1.ReadOnly = True
        Me.y1Ss1.Width = 86
        '
        'y1Color
        '
        Me.y1Color.HeaderText = "Colors"
        Me.y1Color.Name = "y1Color"
        Me.y1Color.ReadOnly = True
        Me.y1Color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.y1Color.Width = 70
        '
        'y1cmdColor
        '
        Me.y1cmdColor.HeaderText = "Foreground Color"
        Me.y1cmdColor.Name = "y1cmdColor"
        Me.y1cmdColor.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.y1cmdColor.Width = 150
        '
        'y1CmdBackColor
        '
        Me.y1CmdBackColor.HeaderText = "Background Color"
        Me.y1CmdBackColor.Name = "y1CmdBackColor"
        Me.y1CmdBackColor.ReadOnly = True
        Me.y1CmdBackColor.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.y1CmdBackColor.Width = 151
        '
        'y1TextAlignment
        '
        Me.y1TextAlignment.HeaderText = "Text Alignment"
        Me.y1TextAlignment.Name = "y1TextAlignment"
        Me.y1TextAlignment.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.y1TextAlignment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.y1TextAlignment.Width = 148
        '
        'frmWindowColors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.dgvColors)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWindowColors"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Text Options"
        CType(Me.dgvColors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvColors As System.Windows.Forms.DataGridView
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents y1Ss1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents y1Color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents y1cmdColor As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents y1CmdBackColor As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents y1TextAlignment As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
