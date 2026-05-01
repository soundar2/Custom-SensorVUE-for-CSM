<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlScalingSensor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuTare = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtLoad = New LoadVUE.FontScalingTextBox()
        Me.lblSensorName = New LoadVUE.FontScalingLabel()
        Me.lblUnits = New LoadVUE.FontScalingLabel()
        Me.lblNoHidden = New LoadVUE.FontScalingLabel()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTare})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(99, 26)
        '
        'mnuTare
        '
        Me.mnuTare.Name = "mnuTare"
        Me.mnuTare.Size = New System.Drawing.Size(98, 22)
        Me.mnuTare.Text = "&Zero"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.txtLoad, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSensorName, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblUnits, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 413.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(790, 413)
        Me.TableLayoutPanel2.TabIndex = 52
        '
        'txtLoad
        '
        Me.txtLoad.BackColor = System.Drawing.Color.White
        Me.txtLoad.BackColorTextBox = System.Drawing.SystemColors.Window
        Me.txtLoad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLoad.ForeColorTextBox = System.Drawing.SystemColors.WindowText
        Me.txtLoad.Location = New System.Drawing.Point(200, 3)
        Me.txtLoad.Name = "txtLoad"
        Me.txtLoad.Size = New System.Drawing.Size(483, 407)
        Me.txtLoad.SizingText = "-99999.99"
        Me.txtLoad.TabIndex = 46
        Me.txtLoad.TabStop = False
        Me.txtLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSensorName
        '
        Me.lblSensorName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSensorName.LabelText = "lblId"
        Me.lblSensorName.Location = New System.Drawing.Point(3, 3)
        Me.lblSensorName.Name = "lblSensorName"
        Me.lblSensorName.Size = New System.Drawing.Size(191, 407)
        Me.lblSensorName.SizingText = "F999999999"
        Me.lblSensorName.TabIndex = 47
        Me.lblSensorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnits
        '
        Me.lblUnits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUnits.LabelText = "lblUnits"
        Me.lblUnits.Location = New System.Drawing.Point(689, 3)
        Me.lblUnits.Name = "lblUnits"
        Me.lblUnits.Size = New System.Drawing.Size(98, 407)
        Me.lblUnits.SizingText = "Newtons"
        Me.lblUnits.TabIndex = 52
        Me.lblUnits.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNoHidden
        '
        Me.lblNoHidden.LabelText = "lblNoHidden"
        Me.lblNoHidden.Location = New System.Drawing.Point(557, 46)
        Me.lblNoHidden.Name = "lblNoHidden"
        Me.lblNoHidden.Size = New System.Drawing.Size(129, 18)
        Me.lblNoHidden.SizingText = "F160112345(COM32)X"
        Me.lblNoHidden.TabIndex = 50
        Me.lblNoHidden.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNoHidden.Visible = False
        '
        'ctlScalingSensor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.lblNoHidden)
        Me.Name = "ctlScalingSensor"
        Me.Size = New System.Drawing.Size(790, 413)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuTare As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtLoad As FontScalingTextBox
    Friend WithEvents lblSensorName As FontScalingLabel
    Friend WithEvents lblNoHidden As FontScalingLabel
    Friend WithEvents lblUnits As LoadVUE.FontScalingLabel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel

End Class
