Imports com.loadstar.utility.Utility
Imports com.loadstar.utility
Public Class frmSensorStartupParam
    Dim _dictParam As New Dictionary(Of String, String)
    Private _changed As Boolean = False

    Private Sub frmSensorStartupParam_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _changed Then
            ShowInfoMessage("Program will be restarted for the settings to take effect.")
            ConfigXml.RestartApplication = True
        End If
    End Sub
    Private Sub frmSensorStartupParam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Hourglass.Show()
        For Each item As String In ConfigXml.Instance.StartupParamList
            Dim str() As String = item.Split("|")
            _dictParam(str(0)) = str(1)
        Next
        Dim sensorList As List(Of String) = (From s In _gAttachedSensors Where Not (s.DeviceUnitType = LsDevice.Enum_Device_Unit_Type.Relay Or TypeOf s Is DerivedSensor) Select s.SS1).ToList
        cmbSensors.DataSource = sensorList
        cmbSensors.SelectedIndex = 0
        Hourglass.Release()
    End Sub

    Private Sub txtParam_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtParam.TextChanged
        cmdApply.Enabled = (txtParam.Text.Trim.Length <> 0)
    End Sub

    Private Sub cmdApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        _dictParam(cmbSensors.Text) = txtParam.Text.Trim.Replace(vbCrLf, "$")
        ConfigXml.Instance.StartupParamList.Clear()
        For Each item In _dictParam
            Dim s As String = String.Format("{0}|{1}", item.Key, item.Value)
            ConfigXml.Instance.StartupParamList.Add(s)
        Next
        ConfigXml.Instance.WriteConfiguration()
        _changed = True
    End Sub

    Private Sub cmbSensors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSensors.SelectedIndexChanged
        txtParam.Clear()
        Try
            txtParam.Text = _dictParam(cmbSensors.Text).Replace("$", vbCrLf)
        Catch ex As Exception
        End Try
    End Sub
End Class