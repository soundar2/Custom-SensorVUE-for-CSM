Imports System.Threading
Imports System.Reflection
Imports com.loadstar.utility.Utility
Imports com.loadstar.utility
Public Class frmDetectSensors

    Private Sub frmDetectSensors_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Static firstTime As Boolean = True
        If firstTime = True Then
            firstTime = False
            Application.DoEvents()
            ScanPorts()
            UpdateSensorListDisplay()
            If _gAttachedSensors.Count = 0 Then
                Me.Close()
            Else
                cmdOK.Enabled = True
                cmdCancel.Enabled = True
            End If
        End If
    End Sub

    Private Sub frmDetectSensors_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            'are any sensors checked
            Dim allCheckedRows = GetCheckedRows(dgvSensors)
            Dim allUncheckedRows = GetUnCheckedRows(dgvSensors)

            If allCheckedRows.Count = 0 Then
                ShowErrorMessage("No items selected.")
                e.Cancel = True
                Return
            End If
            If IsAnyUnauthorizedSensor() Then e.Cancel = True : Return
            If allUncheckedRows.Count <> 0 Then
                '
                'some sensors have been unchecked, we have to delete them from the attached sensor list
                '
                For Each r In allUncheckedRows
                    If r.Cells(0).Value = False Then
                        Dim sName As String = r.Cells("ss1").Value
                        If sName.StartsWith("Relay") Then
                            _gAttachedSensors.RemoveAll(Function(s) IIf(s.SS1.StartsWith("Relay"), True, False))
                        Else
                            _gAttachedSensors.RemoveAll(Function(s) IIf(s.SS1 = sName, True, False))
                        End If
                    End If
                Next
            End If
            'now check for authorizations
            'for example if SensorVUE no motors or relays will be allowed
            '
            'now check if the relay is added
            'if yes then remove the relay box and add individual relays
            'is a relay checked
            '
            'also remember all the selected sensors so next time we can 
            'preselect these sensors only
            '
            ConfigXml.Instance.selectedSensors.Clear()
            For Each r In allCheckedRows
                If r.Cells("ss1").Value.ToString.StartsWith("Relay") Then
                    'relay checked
                    'add the rest of relays upto MAX
                    Dim relay As RelayChannel = _gAttachedSensors.First(Function(s) s.SS1.StartsWith("Relay"))
                    Dim relayBox As NcdRelayBox = relay.Parent
                    For i = 1 To ConfigXml.Instance.MAX_RELAY_CHANNELS - 1
                        _gAttachedSensors.Add(relayBox.Relay(i))
                    Next
                End If
                ConfigXml.Instance.selectedSensors.Add(r.Cells("ss1").Value)
            Next
            If ConfigXml.Instance.selectedSensors.Count <> 0 Then
                ConfigXml.Instance.WriteConfiguration()
            End If

        End If
    End Sub

    Private Sub frmDetectSensors_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = clsGlobals.GetProductNameAndVersion()
        lblProgress.Text = String.Empty

        AddHandler AttachedSensors.PortScanning, AddressOf AttachedSensors_PortScanning
        AddHandler AttachedSensors.SensorDetected, AddressOf SensorDetected
        AddHandler AttachedSensors.ProgressMessage, AddressOf DetectProgress
    End Sub
    Private Sub ScanPorts()
        TableLayoutPanel1.Visible = True
        Application.DoEvents()
        Try
            cmdRetry.Enabled = False
            AttachedSensors.RefreshPortList()
            Do
                If _gAttachedSensors.Count = 0 Then
                    Dim frm As New frmNoSensors

                    Dim ret As MsgBoxResult = frm.ShowDialog ' MsgBox("No loadcells or interfaces detected. Please check your device setup.", MsgBoxStyle.Critical + MsgBoxStyle.RetryCancel)
                    If ret = MsgBoxResult.Retry Then
                        AttachedSensors.RefreshPortList()
                    Else
                        Exit Do
                    End If
                End If
            Loop Until _gAttachedSensors.Count <> 0
        Catch ex As Exception
            MsgBox("Fatal error encountered. Program aborting..." & vbCrLf & ex.Message)
        Finally
            TableLayoutPanel1.Visible = False
            cmdRetry.Enabled = True
        End Try
    End Sub
    Private Delegate Sub AttachedSensors_PortScanning_Delegate(ByVal portName As String, ByVal baudrate As UInteger)
    Private Sub AttachedSensors_PortScanning(ByVal portName As String, ByVal baudrate As UInteger)
        Static lock As New Object
        SyncLock lock
            CheckForIllegalCrossThreadCalls = False
            If _gUseWifi Then
                lblProgress.Text = String.Format("Scanning {0}:{1} ...", portName, baudrate.ToString)
            Else
                lblProgress.Text = String.Format("Scanning {0}, Baud: {1}...", portName, baudrate.ToString)
            End If

            lblProgress.Refresh()
            Thread.Sleep(100)
            CheckForIllegalCrossThreadCalls = True
        End SyncLock
    End Sub
    Private Sub SensorDetected(ByVal sensor As LsSensor)
    End Sub
    Private Sub DetectProgress(ByVal msg As String)
        CheckForIllegalCrossThreadCalls = False
        lblProgress.Text = msg
        CheckForIllegalCrossThreadCalls = True
    End Sub
    Private Function GetPortName(ByVal item As LsSensor) As String
        If TryCast(item, RelayChannel) IsNot Nothing Then
            Return CType(item, RelayChannel).Parent.PortName
        ElseIf TryCast(item, LsComSensor) IsNot Nothing Then
            Return CType(item, LsComSensor).PortName
        Else
            Return String.Empty
        End If
    End Function
    Private Function GetCheckedRows(ByVal dgv As DataGridView) As IEnumerable(Of DataGridViewRow)
        Return dgv.Rows.Cast(Of DataGridViewRow)().Where(Function(row) row.Cells(0).Value = True).ToList
    End Function
    Private Function GetUnCheckedRows(ByVal dgv As DataGridView) As IEnumerable(Of DataGridViewRow)
        Return dgv.Rows.Cast(Of DataGridViewRow)().Where(Function(row) row.Cells(0).Value = False).ToList
    End Function

    Private Sub cmdRetry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRetry.Click
        dgvSensors.Rows.Clear()
        UpdateSelectedCount()
        _gAttachedSensors.Clear()
        ScanPorts()
        UpdateSensorListDisplay()
    End Sub

    Private Sub dgvSensors_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSensors.CellClick
        If e.ColumnIndex = 0 Then
            With dgvSensors
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Not .Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            End With
        End If
    End Sub
    Private Function IsAnyUnauthorizedSensor() As Boolean
        'if not controlvue we cannot have relays
        Dim prodName As String = My.Application.Info.ProductName
        Dim prodDescr As String = My.Application.Info.Description
        Dim msg As String = String.Empty
        Dim selectedSensors As New List(Of LsSensor)

        Dim allCheckedRows = GetCheckedRows(dgvSensors)
        For Each r In allCheckedRows
            Dim sName As String = r.Cells("ss1").Value
            selectedSensors.Add((From s In _gAttachedSensors Where s.SS1 = sName Select s).First)
        Next

        If Not clsGlobals.IsRunningControlVue Then
            If (From s In selectedSensors Where s.DeviceUnitType = LsDevice.Enum_Device_Unit_Type.Relay Select s).Any Then
                msg = "Relays are not supported Please use ControlVUE"
            ElseIf (From s In selectedSensors Where s.DeviceUnitType = LsDevice.Enum_Device_Unit_Type.Angle Select s).Any Then
                msg = "Motors are not supported. Please use ControlVUE"
            End If
            Dim nForceSensors = (From s In selectedSensors Where s.DeviceUnitType = LsDevice.Enum_Device_Unit_Type.Force Select s).Count
            Dim nonForceSensors = (From s In selectedSensors Where s.DeviceUnitType <> LsDevice.Enum_Device_Unit_Type.Force Select s).Count
            If clsGlobals.IsRunningLV1000 AndAlso (nForceSensors > 1 OrElse nonForceSensors > 0) Then
                msg = "Select only one force sensor"
            ElseIf clsGlobals.IsRunningLV4000 AndAlso (nForceSensors > 4 OrElse nonForceSensors > 0) Then
                msg = "Select only four force sensors"
            End If
        End If
        If msg.Length <> 0 Then
            ShowErrorMessage(msg)
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub UpdateSensorListDisplay()
        Dim i As Integer
        With dgvSensors
            .Rows.Clear()

            For Each s In _gAttachedSensors
                .Rows.Add()
                i = .Rows.Count - 1
                .Rows(i).Cells("check").Value = True
                If TryCast(s, RelayChannel) IsNot Nothing Then
                    'we add the relay only once
                    .Rows(i).Cells("ss1").Value = s.SS1
                    .Rows(i).Cells("connection").Value = CType(s, IConnectionInfo).ConnectionInfo
                Else
                    .Rows(i).Cells("ss1").Value = s.SS1
                    Dim sensorType As String = String.Empty
                    Select Case s.Units.UnitType
                        Case Units.Enum_UNIT_TYPE.force
                            sensorType = "Force"
                        Case Units.Enum_UNIT_TYPE.angle
                            sensorType = "Motor"
                        Case Units.Enum_UNIT_TYPE.length
                            sensorType = "Displacement/Level"
                        Case Units.Enum_UNIT_TYPE.torque
                            sensorType = "Torque"
                        Case Units.Enum_UNIT_TYPE.temperature
                            sensorType = "Temperature"
                        Case Units.Enum_UNIT_TYPE.pressure
                            sensorType = "Pressure"
                        Case Units.Enum_UNIT_TYPE.voltage
                            sensorType = "Voltage"
                    End Select
                    .Rows(i).Cells("sensorType").Value = sensorType
                    .Rows(i).Cells("connection").Value = CType(s, IConnectionInfo).ConnectionInfo
                End If
                UpdateSelectAllCheckbox()
                UpdateSelectedCount()
            Next
        End With
    End Sub



    Private Sub cmdPutty_Click(sender As Object, e As EventArgs) Handles cmdPutty.Click
        clsGlobals.RunPutty()
    End Sub

    Private Sub cmdDeviceManager_Click(sender As Object, e As EventArgs) Handles cmdDeviceManager.Click
        clsGlobals.RunDeviceManager()
    End Sub

    Private Sub cmdTeamviewer_Click(sender As Object, e As EventArgs) Handles cmdTeamviewer.Click
        clsGlobals.RunTeamviewer()
    End Sub

    Private Sub latencyDocLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles latencyDocLink.LinkClicked
        System.Diagnostics.Process.Start("http://www.loadstarsensors.com/assets/manuals/html/how-to-set-latency-timer/latency-timer.html")
    End Sub
    Private Sub chkAll_click(sender As Object, e As EventArgs) Handles chkAll.Click
        Select Case chkAll.CheckState
            Case CheckState.Checked
                For i = 0 To dgvSensors.Rows.Count - 1
                    dgvSensors.Rows(i).Cells(0).Value = True
                Next
            Case CheckState.Unchecked
                For i = 0 To dgvSensors.Rows.Count - 1
                    dgvSensors.Rows(i).Cells(0).Value = False
                Next
        End Select
        UpdateSelectedCount()
    End Sub
    Private Sub UpdateSelectAllCheckbox()
        chkAll.ThreeState = True
        Dim dgvRows = dgvSensors.Rows.Cast(Of DataGridViewRow).ToList()
        Dim allSelected = dgvRows.Count = (From r In dgvRows Where r.Cells(0).Value = True).Count
        Dim noneSelected = dgvRows.Count = (From r In dgvRows Where r.Cells(0).Value = False).Count
        If allSelected Then
            chkAll.CheckState = CheckState.Checked
        ElseIf noneSelected Then
            chkAll.CheckState = CheckState.Unchecked
        Else
            chkAll.CheckState = CheckState.Indeterminate
        End If
    End Sub

    Private Sub dgvSensors_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSensors.CellContentClick
        If (e.RowIndex < 0 OrElse e.ColumnIndex < 0) Then Return
        If TypeOf dgvSensors.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then
            ' Commit the edit to update the value immediately
            dgvSensors.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        If e.ColumnIndex = 0 Then
            'checking or unchecking
            dgvSensors.CommitEdit(DataGridViewDataErrorContexts.Commit)
            UpdateSelectAllCheckbox()
            UpdateSelectedCount()
        End If
    End Sub
    Private Sub UpdateSelectedCount()
        lblSelectedCount.Text = GetCheckedRows(dgvSensors).Count
    End Sub
End Class