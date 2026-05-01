Imports com.loadstar.universal
Imports com.loadstar.utility
Public Class frmSensorList

    Private Sub frmSensorList_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sensorList As List(Of String) = (From s In _gAttachedSensors Where Not (s.DeviceUnitType = LsDevice.Enum_Device_Unit_Type.Relay Or TypeOf s Is DerivedSensor) Select s.SS1).ToList

        For Each s In _gAttachedSensors
            If s.IsVirtualDevice = True Then
            ElseIf s.DeviceUnitType = LsDevice.Enum_Device_Unit_Type.Relay Then
            Else
                'this is a standard sensor or interface
                With dgvSensors
                    .Rows.Add()
                    Dim i = .Rows.Count - 1
                    .Rows(i).Cells("colSs1").Value = s.SS1
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
                    .Rows(i).Cells("colType").Value = sensorType
                    .Rows(i).Cells("colConnection").Value = CType(s, IConnectionInfo).ConnectionInfo
                    .Rows(i).Cells("colFirmware").Value = "Read"
                    .Rows(i).Tag = s
                End With
            End If
        Next
    End Sub

    Private Sub dgvSensors_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSensors.CellContentClick
        Hourglass.Show()
        With dgvSensors
            If (e.RowIndex >= 0 AndAlso .Columns(e.ColumnIndex).Name = "colFirmware") Then
                txtFirmware.Clear()
                If TryCast(.Rows(e.RowIndex).Tag, FcmSensor) IsNot Nothing Then
                    Dim cap = CType(.Rows(e.RowIndex).Tag, FcmSensor)
                    Dim con = New SerialConnection(cap.PortName, cap.Baud)
                    Dim container = New Di1000CalContainer(con)
                    Dim buffer As String = "Version: " & container.GetFirmwareVersion1() & vbCrLf
                    buffer &= container.GetFirmwareSettings()
                    txtFirmware.Text = buffer

                ElseIf TryCast(.Rows(e.RowIndex).Tag, CapSensor) IsNot Nothing Then
                    Dim cap = CType(.Rows(e.RowIndex).Tag, CapSensor)
                    Dim con = New SerialConnection(cap.PortName, cap.Baud)
                    Dim container = New iLoadContainer(con)
                    txtFirmware.Text = container.GetFirmwareSettings()
                End If
            End If

        End With
        Hourglass.Release()
    End Sub
End Class