<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIgnorePorts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIgnorePorts))
        Me.cb1 = New System.Windows.Forms.CheckedListBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cb1
        '
        Me.cb1.FormattingEnabled = True
        Me.cb1.Location = New System.Drawing.Point(12, 27)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(434, 142)
        Me.cb1.TabIndex = 0
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(136, 323)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(146, 55)
        Me.cmdOk.TabIndex = 1
        Me.cmdOk.Text = "Continue"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(434, 104)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 271)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(385, 51)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "If there are no relevant serial ports, click Continue without making any selectio" &
    "n."
        '
        'frmIgnorePorts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 389)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cb1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmIgnorePorts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ignore Ports"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cb1 As CheckedListBox
    Friend WithEvents cmdOk As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
