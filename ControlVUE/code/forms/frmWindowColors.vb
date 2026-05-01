Option Compare Text
Imports System.IO
Imports System.Xml.Serialization
Imports com.loadstar.utility.Utility
Public Class frmWindowColors
    Private Sub frmGraphOptions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            If IsOkToSave() Then
                SaveOptions()
            Else
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub frmGraphOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadOptions()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub dgvColors_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvColors.CellContentClick
        If (e.RowIndex < 0 OrElse e.ColumnIndex < 0) Then Return
        If dgvColors.Columns(e.ColumnIndex).Name.ToLower.Contains("cmd") Then
            SetRowColor(e.RowIndex, e.ColumnIndex, dgvColors.Columns(e.ColumnIndex).Name.ToLower.Contains("back"))
        End If
    End Sub
    Private Sub SetRowColor(ByVal rowIndex As Integer, ByVal colIndex As Integer, isBackgroundColor As Boolean)
        Dim currentColor As Color
        If isBackgroundColor Then
            currentColor = dgvColors.Rows(rowIndex).Cells("y1Color").Style.BackColor
        Else
            currentColor = dgvColors.Rows(rowIndex).Cells("y1Color").Style.ForeColor
        End If


        Dim colorDlg As New ColorDialog
        With colorDlg
            .Color = currentColor
            .FullOpen = True
            .AnyColor = True
            .AllowFullOpen = True
            .SolidColorOnly = False
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                If isBackgroundColor Then
                    dgvColors.Rows(rowIndex).Cells("y1Color").Style.BackColor = .Color
                Else
                    dgvColors.Rows(rowIndex).Cells("y1Color").Style.ForeColor = .Color
                End If
            End If
        End With
    End Sub
    Private Sub SetControlStates()
    End Sub

    Private Sub LoadOptions()
        Dim ini As New LvIniFile()

        For Each s In _gAttachedSensors
            Dim ss1 As String = s.SS1
            With dgvColors
                .Rows.Add()
                Dim index = .Rows.Count - 1
                PopulateTextAlignments(.Rows(index).Cells("y1TextAlignment"))
                .Rows(index).Cells("y1ss1").Value = s.SS1
                '
                '
                '
                ini.Section = "WindowTextColors"
                Dim fColor As System.Drawing.Color = System.Drawing.Color.FromArgb(ini.GetInteger(s.SS1, Color.Black.ToArgb))
                .Rows(index).Cells("y1Color").Style.ForeColor = fColor
                .Rows(index).Cells("y1Color").Value = "123.45"
                .Rows(index).Cells("y1cmdColor").Value = "Select Color"
                '
                '
                '
                ini.Section = "WindowBackgroundColors"
                Dim bColor As System.Drawing.Color = System.Drawing.Color.FromArgb(ini.GetInteger(s.SS1, Color.White.ToArgb))
                .Rows(index).Cells("y1Color").Style.BackColor = bColor
                .Rows(index).Cells("y1CmdBackColor").Value = "Select Color"

                ini.Section = "WindowTextAlignment"
                Dim alignment As String = ini.GetString(s.SS1, "Center") 'default alignment is center
                .Rows(index).Cells("y1TextAlignment").Value = alignment
                'Select Case alignment
                '    Case "Center"
                '        .Rows(index).Cells("y1Color").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                '    Case "Right"
                '        .Rows(index).Cells("y1Color").Style.Alignment = DataGridViewContentAlignment.MiddleRight
                '    Case Else
                '        .Rows(index).Cells("y1Color").Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                'End Select
            End With
        Next
        SetControlStates()
    End Sub
    Private Sub SaveOptions()
        Dim ini As New LvIniFile()
        '
        '
        '
        ini.Section = "WindowTextColors"
        With dgvColors
            For i = 0 To .Rows.Count - 1
                Dim intColor As Integer = .Rows(i).Cells("y1Color").Style.ForeColor.ToArgb
                ini.WriteInteger(.Rows(i).Cells("y1ss1").Value, intColor)
            Next
        End With
        '
        '
        '
        ini.Section = "WindowBackgroundColors"
        With dgvColors
            For i = 0 To .Rows.Count - 1
                Dim intColor As Integer = .Rows(i).Cells("y1Color").Style.BackColor.ToArgb
                ini.WriteInteger(.Rows(i).Cells("y1ss1").Value, intColor)
            Next
        End With

        ini.Section = "WindowTextAlignment"
        With dgvColors
            For i = 0 To .Rows.Count - 1
                Dim alignment As String = .Rows(i).Cells("y1TextAlignment").Value
                ini.WriteString(.Rows(i).Cells("y1ss1").Value, alignment)
            Next
        End With
    End Sub
    Private Function IsOkToSave() As Boolean
        Return True
    End Function
    Private Sub PopulateTextAlignments(ByVal dgcc As DataGridViewComboBoxCell)
        dgcc.Items.Add("Left")
        dgcc.Items.Add("Center")
        dgcc.Items.Add("Right")
        dgcc.Value = dgcc.Items(1).ToString
    End Sub
End Class