Imports System.Text.RegularExpressions
Public Class Di1000Hs1kContainer
    Inherits Container
    Implements ISensorContainer

    Private _device As di1000hs1k
    Private _isTaring As Boolean = False
    Private _tareA2D As Integer = 0
    Public Sub New(con As IConnection)
        _connection = con
        _connection.LineTerminator = vbCr
        If _connection.TryOpen() Then
            _device = New di1000hs1k(Me, 0)
            Dim cmd = New SensorCommand
            cmd.responseType = SensorCommand.Enum_ResponseType.oneline
            cmd.commandText = "ID" & vbCr
            _device.ID = _connection.GetCommandResponse(cmd).Trim
            cmd.commandText = "UNITS" & vbCr
            _device.Units.CalibratedUnits = _connection.GetCommandResponse(cmd).Trim
            cmd.commandText = "LC" & vbCr
            _device.CapacityInCalUnits = _connection.GetCommandResponse(cmd).Trim
            cmd.commandText = "SWC" & vbCr
            _device.WtPerBit = _connection.GetCommandResponse(cmd).Trim
            ReadTareCounts()
            _connection.TryClose()
        End If
    End Sub

    Public ReadOnly Property NoOfChannels As UShort Implements ISensorContainer.NoOfChannels
        Get
            Return 1
        End Get
    End Property

    Public Function StartReading() As Boolean Implements ISensorContainer.StartReading
        _connection.StreamingByteCount = 7
        _connection.TryOpen()
        _connection.XmitStreamingCommand("H" & vbCr)
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
            Return String.Format("DI-1000HS-1K: {0} ({1})", _device.ID, _connection.ConnectionInfoString)
        End Get
    End Property


    Private Sub _connection_SensorStringDataReceived(sender As IConnection, data As String) Handles _connection.SensorStringDataReceived
        Static rawA2D As Integer = 0
        data = data.Trim
        If data(0) = "-"c Then
            rawA2D = -1 * Convert.ToInt32(data.Substring(1), 16)
        Else
            rawA2D = Convert.ToInt32(data, 16)
        End If
        If Math.Abs(rawA2D) < 2 Then Return
        If _isTaring Then
            _tareA2D = rawA2D
            _isTaring = False
        End If
        _device.CurrentReadingInDeviceUnits = (rawA2D - _tareA2D) * _device.WtPerBit
    End Sub
    Public Sub SoftTare()
        _isTaring = True
    End Sub
    Private Sub ReadTareCounts()
        Dim data As String
        _connection.Flush()
        Dim cmd = New SensorCommand
        cmd.responseType = SensorCommand.Enum_ResponseType.oneline
        cmd.commandText = "ST0" & vbCr
        data = _connection.GetCommandResponse(cmd)
        _tareA2D = Val(data)
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
            Return _connection.ConnectionInfoString
        End Get
    End Property
    Public Function GetFirmwareVersion1() As String Implements ISensorContainer.GetFirmwareVersion
        If _connection.TryOpen() Then
            Dim cmd As New SensorCommand("?" & vbCr, SensorCommand.Enum_ResponseType.stringmatch)
            cmd.terminatingString = "Version"
            Dim lst = _connection.GetMultiLineResponse(cmd)
            _connection.TryClose()
            Dim versionRegex = New Regex("Version\s+(\d+\.\d+)")
            For Each item In lst
                If versionRegex.IsMatch(item) Then
                    Dim version = versionRegex.Matches(item)(0).Groups(1).ToString
                    Return version
                End If
            Next
        End If
        Return String.Empty
    End Function
    Public Function Type() As ISensorContainer.Enum_ContainerType Implements ISensorContainer.Type
        Return ISensorContainer.Enum_ContainerType.di1000hs1k
    End Function
    Public Sub PollingInterval(intervalMSec As Integer) Implements ISensorContainer.SetPollingIntervalMSec
    End Sub
    Public Event DebugMessage(c As ISensorContainer, msg As String) Implements ISensorContainer.DebugMessage

    Public Event ContainerDisconnected(ByVal sender As ISensorContainer) Implements ISensorContainer.ContainerDisconnected
End Class


