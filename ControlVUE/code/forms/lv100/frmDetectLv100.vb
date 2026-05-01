Imports System.Threading
Imports System.Reflection
Imports com.loadstar.utility.Utility
Public Class frmDetectLv100

    Private Sub frmDetectLv100_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Static firstTime As Boolean = True
        If firstTime = True Then
            firstTime = False
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub frmDetectLv100_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            'are any sensors checked
            Dim allCheckedRows = GetCheckedRows(dgvSensors)
            If ProductName.Contains("LV-400") AndAlso allCheckedRows.Count > 4 Then
                ShowErrorMessage("Select only 4 sensors.")
                e.Cancel = True
                Return
            ElseIf ProductName.Contains("LV-100") AndAlso allCheckedRows.Count > 1 Then
                ShowErrorMessage("Select only one sensor.")
                e.Cancel = True
                Return
            End If

            Dim allUncheckedRows = GetUnCheckedRows(dgvSensors)

            If allCheckedRows.Count = 0 Then
                ShowErrorMessage("No items selected.")
                e.Cancel = True
                Return
            End If
            'If IsAnyUnauthorizedSensor() Then e.Cancel = True : Return
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

    Private Sub frmDetectLv100_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = String.Format("{0} ({1})", My.Application.Info.ProductName, Assembly.GetExecutingAssembly().GetName().Version.ToString)
        lblProgress.Text = String.Empty
        Me.WindowState = FormWindowState.Normal
        Dim sw As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim sh As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Left = (sw - Me.Width) / 2
        Me.Top = (sh - Me.Height) / 2
        Me.Refresh()
        AddHandler AttachedSensors.PortScanning, AddressOf AttachedSensors_PortScanning
        AddHandler AttachedSensors.SensorDetected, AddressOf SensorDetected
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

        If Not prodName.StartsWith("ControlVUE") Then
            If (From s In selectedSensors Where s.DeviceUnitType = LsDevice.Enum_Device_Unit_Type.Relay Select s).Any Then
                msg = "Relays are not supported Please use ControlVUE"
            ElseIf (From s In selectedSensors Where s.DeviceUnitType = LsDevice.Enum_Device_Unit_Type.Angle Select s).Any Then
                msg = "Motors are not supported. Please use ControlVUE"
            End If
        End If
        If prodName.StartsWith("LoadVUE") Then
            'only force sensors are supported
            If (From s In selectedSensors Where s.DeviceUnitType <> LsDevice.Enum_Device_Unit_Type.Force Select s).Any Then
                msg = "Only force sensors are supported."
            End If
            If prodDescr.Contains("LV-100") AndAlso (From s In selectedSensors Where s.DeviceUnitType = LsDevice.Enum_Device_Unit_Type.Force Select s).Count > 1 Then
                msg = "Select only one force sensor"
            End If
            If prodDescr.Contains("LV-400") AndAlso (From s In selectedSensors Where s.DeviceUnitType = LsDevice.Enum_Device_Unit_Type.Force Select s).Count > 4 Then
                msg = "Only 4 force sensors can be selected."
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
                If s.Units.UnitType = Units.Enum_UNIT_TYPE.force Then
                    .Rows(i).Cells("port").Value = GetPortName(s)
                    .Rows(i).Cells("ss1").Value = s.SS1
                    ' .Rows(i).Cells("check").Value = True
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
                        Case Units.Enum_UNIT_TYPE.voltage
                            sensorType = "Voltage"
                        Case Units.Enum_UNIT_TYPE.temperature
                            sensorType = "Temperature"
                        Case Units.Enum_UNIT_TYPE.pressure
                            sensorType = "Pressure"
                    End Select
                    .Rows(i).Cells("sensorType").Value = sensorType
                End If
                '
                'if this sensor was selected before or if running for the first time
                'in which case the preselected list will be empty
                'then preselect this sensor
                '
                If ConfigXml.Instance.selectedSensors.Contains(s.SS1) OrElse ConfigXml.Instance.selectedSensors.Count = 0 Then
                    .Rows(i).Cells("check").Value = True
                End If
            Next
        End With
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        ScanPorts()
        UpdateSensorListDisplay()
        If _gAttachedSensors.Count = 0 Then
            Me.Close()
        Else
            cmdOK.Enabled = True
            cmdCancel.Enabled = True
        End If
    End Sub

    Private Sub cmdPutty_Click(sender As Object, e As EventArgs) Handles cmdPutty.Click
        Dim fileName = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "putty\putty.exe")
        If My.Computer.FileSystem.FileExists(fileName) Then
            System.Diagnostics.Process.Start(fileName)
        Else
            ShowErrorMessage("File not found: " & fileName)
        End If
    End Sub

    Private Sub cmdDeviceManager_Click(sender As Object, e As EventArgs) Handles cmdDeviceManager.Click
        clsGlobals.RunDeviceManager()
    End Sub
End Class