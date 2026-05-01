<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUploadToCloud
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUploadToCloud))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFileSize = New System.Windows.Forms.Label()
        Me.cmdCredentials = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 35)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "File Name:"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(182, 116)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(6)
        Me.txtDescription.MaxLength = 80
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(581, 29)
        Me.txtDescription.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 119)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File Description:"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Image = Global.LoadVUE.My.Resources.Resources.cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(652, 173)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(115, 52)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Enabled = False
        Me.cmdOK.Image = Global.LoadVUE.My.Resources.Resources.ok
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(525, 173)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(115, 52)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "Upload"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(182, 28)
        Me.txtFileName.Margin = New System.Windows.Forms.Padding(6)
        Me.txtFileName.MaxLength = 80
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(581, 29)
        Me.txtFileName.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 76)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "File Size (KB):"
        '
        'lblFileSize
        '
        Me.lblFileSize.AutoSize = True
        Me.lblFileSize.Location = New System.Drawing.Point(182, 76)
        Me.lblFileSize.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblFileSize.Name = "lblFileSize"
        Me.lblFileSize.Size = New System.Drawing.Size(25, 24)
        Me.lblFileSize.TabIndex = 3
        Me.lblFileSize.Text = "..."
        '
        'cmdCredentials
        '
        Me.cmdCredentials.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdCredentials.Image = CType(resources.GetObject("cmdCredentials.Image"), System.Drawing.Image)
        Me.cmdCredentials.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCredentials.Location = New System.Drawing.Point(33, 173)
        Me.cmdCredentials.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdCredentials.Name = "cmdCredentials"
        Me.cmdCredentials.Size = New System.Drawing.Size(261, 52)
        Me.cmdCredentials.TabIndex = 2
        Me.cmdCredentials.Text = "Upload Credentials..."
        Me.cmdCredentials.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCredentials.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(29, 252)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(425, 24)
        Me.LinkLabel1.TabIndex = 28
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "http://www.loadstarsensors.com/sensorvue_cloud"
        Me.LinkLabel1.Text = "http://www.loadstarsensors.com/sensorvue_cloud"
        '
        'frmUploadToCloud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 306)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.cmdCredentials)
        Me.Controls.Add(Me.lblFileSize)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUploadToCloud"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Upload to Cloud"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFileSize As System.Windows.Forms.Label
    Friend WithEvents cmdCredentials As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
End Class
