Imports System.Threading
Imports System.Text.RegularExpressions
Public Class Dq4000Container
    Inherits Container
    Implements ISensorContainer

    Private _device(0 To 3) As Dq4000Sensor
    Private _isDq4000HS As Boolean = False
    Public firmwareSettings As String = String.Empty
    Public Sub New(con As IConnection)
        Dim buffer As String
        _connection = con
        _connection.LineTerminator = vbLf
        If _connection.TryOpen() Then
            Dim cmd As New SensorCommand
            cmd.commandText = "MODEL" & vbCr
            cmd.responseType = SensorCommand.Enum_ResponseType.oneline
            buffer = _connection.GetCommandResponse(cmd)
            _isDq4000HS = buffer.Contains("HS")
            For i = 0 To 3
                cmd.commandText = "S" & (i + 1) & vbCr
                buffer = _connection.GetCommandResponse(cmd)
                Thread.Sleep(250)
                cmd.commandText = "SS1" & vbCr
                buffer = _connection.GetCommandResponse(cmd)
                _device(i) = New Dq4000Sensor(Me, i)
                If buffer.Length > 0 Then
                    _device(i).ID = buffer
                Else
                    _device(i).ID = "<Unknown>"
                End If
                _device(i).Units.CalibratedUnits = "lbf."
                cmd.commandText = "SLC" & vbCr
                _device(i).CapacityInCalUnits = Val(_connection.GetCommandResponse(cmd).Trim)
            Next
            cmd.commandText = "S0" & vbCr
            buffer = _connection.GetCommandResponse(cmd)
            _connection.TryClose()
        End If
    End Sub

    Public ReadOnly Property NoOfChannels As UShort Implements ISensorContainer.NoOfChannels
        Get
            Return 4
        End Get
    End Property

    Public Function StartReading() As Boolean Implements ISensorContainer.StartReading
        _connection.StreamingByteCount = 65
        _connection.TryOpen()
        _connection.XmitStreamingCommand("o0x0" & vbCr)
        Return True
    End Function

    Public Function StopReading() As Boolean Implements ISensorContainer.StopReading
        Dim cmd As New SensorCommand
        cmd.commandText = vbCr
        _connection.XmitCommand(cmd)
        _connection.XmitCommand(cmd)
        _connection.StopReading()
        _connection.TryClose()
        Return True
    End Function

    Public Function Tare(sensorIndex As UShort) As Boolean Implements ISensorContainer.Tare
        _connection.TryOpen()
        Dim cmd As New SensorCommand
        cmd.commandText = "CT0" & vbCr
        cmd.responseType = SensorCommand.Enum_ResponseType.oneline
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
            Return _device(sensorIndex)
        End Get
    End Property

    Public ReadOnly Property ConnectionInfoString(sensorIndex As Integer) As String Implements ISensorContainer.ConnectionInfoString
        Get
            Return String.Format("DQ-4000: {0} ({1})", _device(sensorIndex).ID, _connection.ConnectionInfoString)
        End Get
    End Property


    Private Sub _connection_SensorStringDataReceived(sender As IConnection, data As String) Handles _connection.SensorStringDataReceived
        Dim str() As String
        Dim total As Double = 0
        Static sep As Char() = " ".ToCharArray
        ' Static hexStr As String
        Static multiplier As Integer = 1
        Dim delimiters() As Char = (vbCr & vbLf & vbTab & Space$(1)).ToCharArray

        If _isDq4000HS Then
        Else
            Dim buffer As String = data.Trim
            str = buffer.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            If str.Length = 5 Then
                Dim values(0 To 3) As Integer, chkSum As Integer = 0
                For i As UShort = 0 To 3
                    values(i) = Val(str(i))
                    chkSum += values(i)
                Next
                If chkSum = Val(str(4)) Then
                    'valid response, last number is the total
                    For i As UShort = 0 To 3
                        _device(i).CurrentReadingInDeviceUnits = values(i) / 1000
                    Next
                Else
                    'bad checkSum, wait for 100ms
                    Thread.Sleep(100)
                End If
            ElseIf buffer Like "*timeout*" Then
                'SPI timeout 
                'wait for 2 sec and return
                Thread.Sleep(2000)
            End If
        End If
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
        For Each dev In _device
            lst.Add(dev)
        Next
        Return lst
    End Function
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
    Public Function GetFirmwareSettings() As String
        firmwareSettings = String.Empty
        Dim dummy As String = String.Empty
        If _connection.TryOpen() Then
            For i = 1 To 4
                Dim cmd = New SensorCommand
                cmd.commandText = "S" & i & vbCr
                cmd.responseType = SensorCommand.Enum_ResponseType.oneline
                dummy = _connection.GetCommandResponse(cmd)
                cmd.commandText = "SETTINGS" & vbCr
                cmd.responseType = SensorCommand.Enum_ResponseType.stringmatch
                cmd.terminatingString = "CCD"
                For Each item In _connection.GetMultiLineResponse(cmd)
                    firmwareSettings += item & vbCrLf
                Next
            Next
            _connection.TryClose()
        End If
        Return firmwareSettings
    End Function
    Public ReadOnly Property ConnectionInfoString1 As String Implements ISensorContainer.ConnectionInfoString
        Get
            Return _connection.ConnectionInfoString
        End Get
    End Property
    Public Function Type() As ISensorContainer.Enum_ContainerType Implements ISensorContainer.Type
        Return ISensorContainer.Enum_ContainerType.di100x
    End Function
    Public Sub PollingInterval(intervalMSec As Integer) Implements ISensorContainer.SetPollingIntervalMSec
    End Sub
    Public Event DebugMessage(c As ISensorContainer, msg As String) Implements ISensorContainer.DebugMessage

    Public Event ContainerDisconnected(ByVal sender As ISensorContainer) Implements ISensorContainer.ContainerDisconnected
End Class
