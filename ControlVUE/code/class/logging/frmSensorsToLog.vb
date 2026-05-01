Imports com.loadstar.utility.Utility
Imports com.loadstar.utility
Public Class frmSensorsToLog

    Private Sub frmSensorsToLog_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            'at least one field must be selected
            Dim rowsChecked = dgvLog.Rows.Cast(Of DataGridViewRow)().Where(Function(row) row.Cells(0).Value = True).ToList
            If Not rowsChecked.Any Then
                ShowErrorMessage("At least one field must be selected.")
                e.Cancel = True
                Return
            Else
                'save the fields
                Dim t As New List(Of String)
                For Each row In rowsChecked
                    t.Add(row.Cells("ss1").Value.ToString)
                Next
                ConfigXml.Instance.SensorsToLog = t
                ConfigXml.Instance.logUdf = chkLogUdf.Checked
                ConfigXml.Instance.WriteConfiguration()
            End If
        End If
    End Sub

    Private Sub frmSensorsToLog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Hourglass.Show()
        chkLogUdf.Checked = ConfigXml.Instance.logUdf
        Dim configList = ConfigXml.Instance.SensorsToLog 'sensors picked for an earlier session
        Dim newList
        If configList IsNot Nothing Then
            newList = (From item In _gAttachedSensors Where item.UnitType <> Units.Enum_UNIT_TYPE.relay _
                       Where TryCast(item, PunchCompletedSensor) Is Nothing _
                       Order By item.SequenceNo Select New With {.check = (From s In configList Where s = item.SS1).Any, .SS1 = item.SS1, .sType = item.UnitType.ToString}).ToList 'sensors attached, if selected earlier, precheck it
        Else
            newList = (From item In _gAttachedSensors Where item.UnitType <> Units.Enum_UNIT_TYPE.relay _
                       Where TryCast(item, PunchCompletedSensor) Is Nothing _
                       Select New With {.check = True, .SS1 = item.SS1, .sType = item.UnitType.ToString}).ToList 'sensors attached, if selected earlier, precheck it
        End If
        dgvLog.DataSource = newList
        Hourglass.Release()
    End Sub

 

    Private Sub chkAll_Click(sender As Object, e As EventArgs) Handles chkAll.Click
        For Each row As DataGridViewRow In dgvLog.Rows
            row.Cells(0).Value = chkAll.Checked
        Next
    End Sub
End Class