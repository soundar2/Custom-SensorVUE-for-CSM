Imports System.Text.RegularExpressions
Public Class iLoadContainer
    Inherits Container
    Implements ISensorContainer

    Private _device As iLoad
    Public Sub New(con As IConnection)
        _connection = con
        _connection.LineTerminator = vbLf
        If _connection.TryOpen() Then
            _device = New iLoad(Me, 0)
            Dim cmd = New SensorCommand
            cmd.responseType = SensorCommand.Enum_ResponseType.oneline
            cmd.commandText = "SS1" & vbCr
            _device.ID = _connection.GetCommandResponse(cmd).Trim
            'we will assume iLoad load cells are always calibrated in lbs
            'because the firmware does not support units
            _device.Units.CalibratedUnits = "lb"
            cmd.commandText = "SLC" & vbCr
            _device.CapacityInCalUnits = _connection.GetCommandResponse(cmd).Trim
            _connection.TryClose()
        End If
    End Sub

    Public ReadOnly Property NoOfChannels As UShort Implements ISensorContainer.NoOfChannels
        Get
            Return 1
        End Get
    End Property

    Public Function StartReading() As Boolean Implements ISensorContainer.StartReading
        _connection.StreamingByteCount = 10
        _connection.TryOpen()
        _connection.XmitStreamingCommand("O0W0" & vbCr)
        Return True
    End Function

    Public Function StopReading() As Boolean Implements ISensorContainer.StopReading
        Dim cmd = New SensorCommand
        cmd.responseType = SensorCommand.Enum_ResponseType.oneline
        cmd.commandText = vbCr
        _connection.XmitCommand(cmd)
        _connection.XmitCommand(cmd)
        _connection.StopReading()
        _connection.TryClose()
        Return True
    End Function

    Public Function Tare(sensorIndex As UShort) As Boolean Implements ISensorContainer.Tare
        _connection.TryOpen()
        Dim cmd = New SensorCommand
        cmd.responseType = SensorCommand.Enum_ResponseType.oneline
        cmd.commandText = "CT0" & vbCr
        For i = 1 To 2
            _connection.XmitCommand(cmd)
            Threading.Thread.Sleep(1000)
        Next
        _connection.Flush()
        _connection.TryClose()
        Return True
    End Function

    Public Function TareAll() As Boolean Implements ISensorContainer.TareAll
        Return Tare(0)
    End Function

    Public ReadOnly Property sensor(sensorIndex As Integer) As Sensor Implements ISensorContainer.sensor
        Get
            Return _device
        End Get
    End Property

    Public ReadOnly Property ConnectionInfoString(sensorIndex As Integer) As String Implements ISensorContainer.ConnectionInfoString
        Get
            Return String.Format("{0} ({1})", _device.ID, _connection.ConnectionInfoString)
        End Get
    End Property


    Private Sub _connection_SensorStringDataReceived(sender As IConnection, data As String) Handles _connection.SensorStringDataReceived
        _device.CurrentReadingInDeviceUnits = Val(data.Trim) / 1000  'o0w0 iload outputs in mLb
    End Sub

    Public ReadOnly Property Guid As Guid Implements ISensorContainer.Guid
        Get
            Return _guid
        End Get
    End Property
    Public Function PollAll() As Boolean Implements ISensorContainer.PollAll
        Return True
    End Function
    Public Function Children() As List(Of ISensor) Implements ISensorContainer.Children
        Dim lst As New List(Of ISensor)
        lst.Add(_device)
        Return lst
    End Function
    Public ReadOnly Property ConnectionInfoString1 As String Implements ISensorContainer.ConnectionInfoString
        Get
            Return Me.ConnectionInfoString(0)
        End Get
    End Property
    Public Function GetFirmwareVersion1() As String Implements ISensorContainer.GetFirmwareVersion
        If _connection.TryOpen() Then
            Dim cmd As New SensorCommand("?" & vbCr, SensorCommand.Enum_ResponseType.stringmatch)
            cmd.terminatingString = "Ver "
            Dim lst = _connection.GetMultiLineResponse(cmd)
            _connection.TryClose()
            Dim versionRegex = New Regex("Ver\s+(\d+\w\.\d+)")
            For Each item In lst
                If versionRegex.IsMatch(item) Then
                    Dim version = versionRegex.Matches(item)(0).Groups(1).ToString
                    Return version
                End If
            Next
        End If
        Return String.Empty
    End Function
    Public Function GetFirmwareSettings() As String
        Dim buffer As String = ""
        If _connection.TryOpen() Then
            Dim cmd = New SensorCommand
            cmd.commandText = "SETTINGS" & vbCr
            cmd.responseType = SensorCommand.Enum_ResponseType.stringmatch
            cmd.terminatingString = "UNITS"
            buffer = String.Empty
            For Each item In _connection.GetMultiLineResponse(cmd)
                buffer += item & vbCrLf
            Next
            _connection.TryClose()
        End If
        Return buffer
    End Function
    Public Function Type() As ISensorContainer.Enum_ContainerType Implements ISensorContainer.Type
        Return ISensorContainer.Enum_ContainerType.iload
    End Function
    Public Sub SetPollingIntervalMilliSeconds(intervalMSec As Integer) Implements ISensorContainer.SetPollingIntervalMSec

    End Sub
    Public Event DebugMessage(c As ISensorContainer, msg As String) Implements ISensorContainer.DebugMessage

    Public Event ContainerDisconnected(ByVal sender As ISensorContainer) Implements ISensorContainer.ContainerDisconnected
End Class
