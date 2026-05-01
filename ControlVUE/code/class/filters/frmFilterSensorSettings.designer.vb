<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFilterSensorSettings
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tvFilter = New System.Windows.Forms.TreeView()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.CtlFilter1 = New LoadVUE.ctlFilter()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(9, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(407, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Median filters with large window sizes may affect data acquisition rate."
        '
        'tvFilter
        '
        Me.tvFilter.FullRowSelect = True
        Me.tvFilter.HideSelection = False
        Me.tvFilter.Indent = 6
        Me.tvFilter.Location = New System.Drawing.Point(12, 61)
        Me.tvFilter.Name = "tvFilter"
        Me.tvFilter.ShowLines = False
        Me.tvFilter.Size = New System.Drawing.Size(148, 243)
        Me.tvFilter.TabIndex = 0
        '
        'cmdDelete
        '
        Me.cmdDelete.Image = Global.LoadVUE.My.Resources.Resources.delete_minus
        Me.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDelete.Location = New System.Drawing.Point(77, 310)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(83, 36)
        Me.cmdDelete.TabIndex = 5
        Me.cmdDelete.Text = "&Delete..."
        Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Image = Global.LoadVUE.My.Resources.Resources.new_plus
        Me.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdNew.Location = New System.Drawing.Point(9, 310)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(62, 36)
        Me.cmdNew.TabIndex = 4
        Me.cmdNew.Text = "&New"
        Me.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Image = Global.LoadVUE.My.Resources.Resources.ok
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(420, 364)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(79, 36)
        Me.cmdOK.TabIndex = 7
        Me.cmdOK.Text = "OK"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Image = Global.LoadVUE.My.Resources.Resources.cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(505, 364)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(79, 36)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'CtlFilter1
        '
        Me.CtlFilter1.Enabled = False
        Me.CtlFilter1.Location = New System.Drawing.Point(180, 59)
        Me.CtlFilter1.Name = "CtlFilter1"
        Me.CtlFilter1.Size = New System.Drawing.Size(418, 286)
        Me.CtlFilter1.TabIndex = 36
        '
        'frmFilterSensorSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 412)
        Me.Controls.Add(Me.CtlFilter1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdNew)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.tvFilter)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFilterSensorSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filters"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tvFilter As System.Windows.Forms.TreeView
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents CtlFilter1 As LoadVUE.ctlFilter
End Class
