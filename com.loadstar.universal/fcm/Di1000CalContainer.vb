Imports System.Text.RegularExpressions
Public Class Di1000CalContainer
    Inherits Container
    Implements ISensorContainer

    Private _device As Sensor
    Private _isTaring As Boolean = False
    Private _xmitFailureCount As Integer = 0
    Public firmwareSettings As String = String.Empty
    Public Sub New(con As IConnection)
        _connection = con
        _connection.LineTerminator = vbLf
        If TypeOf _connection Is XbeeApiConnection Then
            AddHandler CType(_connection, XbeeApiConnection).RelayDongleMessage, AddressOf DongleErrorMessage
            SyncLock XbeeGlobals.DongleLock
                ReadSettings()
            End SyncLock
        Else
            ReadSettings()
        End If
    End Sub
    Private Sub ReadSettings()
        If _connection.TryOpen() Then
            Dim cmd = New SensorCommand
            cmd.responseType = SensorCommand.Enum_ResponseType.oneline
            cmd.commandText = "MODEL" & vbCr
            Dim buffer = _connection.GetCommandResponse(cmd).Trim
            If buffer Like "*FCM*1000*" Then
                _device = New di1000(Me, 0)
            Else
                _device = New di100(Me, 0)
            End If
            cmd.commandText = "ID" & vbCr
            _device.ID = _connection.GetCommandResponse(cmd).Trim
            cmd.commandText = "UNITS" & vbCr
            _device.Units.CalibratedUnits = _connection.GetCommandResponse(cmd).Trim
            cmd.commandText = "LC" & vbCr
            _device.CapacityInCalUnits = Math.Max(0.000001, Val(_connection.GetCommandResponse(cmd).Trim))
            cmd.commandText = "SETT" & vbCr
            cmd.responseType = SensorCommand.Enum_ResponseType.stringmatch
            cmd.terminatingString = "LastTare"
            For Each item In _connection.GetMultiLineResponse(cmd)
                firmwareSettings += item & vbCrLf
            Next
            _connection.TryClose()
        End If
    End Sub
    Public ReadOnly Property NoOfChannels As UShort Implements ISensorContainer.NoOfChannels
        Get
            Return 1
        End Get
    End Property

    Public Function StartReading() As Boolean Implements ISensorContainer.StartReading
        _connection.StreamingByteCount = 13
        _connection.TryOpen()
        If TypeOf _connection Is XbeeApiConnection Then
            _timerPoll.Enabled = True
            PollAll()
        Else
            _connection.XmitStreamingCommand("WC" & vbCr)
        End If
        Return True
    End Function

    Public Function StopReading() As Boolean Implements ISensorContainer.StopReading
        Dim cmd As New SensorCommand()
        cmd.commandText = vbCr
        cmd.responseType = SensorCommand.Enum_ResponseType.oneline
        _connection.XmitCommand(cmd)
        _connection.XmitCommand(cmd)
        _connection.StopReading()
        Return True
    End Function

    Public Function Tare(sensorIndex As UShort) As Boolean Implements ISensorContainer.Tare
        If TypeOf _connection Is XbeeApiConnection Then
            SyncLock XbeeGlobals.DongleLock
                _isTaring = True
                ReallyTare()
                _isTaring = False
            End SyncLock
        Else
            ReallyTare()
        End If
        Return True
    End Function
    Private Function ReallyTare() As Boolean
        _connection.TryOpen()
        Dim cmd = New SensorCommand
        cmd.responseType = SensorCommand.Enum_ResponseType.oneline
        cmd.commandText = "CT0" & vbCr
        For i = 1 To 2
            Dim buffer = _connection.GetCommandResponse(cmd)
            RaiseEvent DebugMessage(Me, buffer)
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
        _device.CurrentReadingInDeviceUnits = Val(data.Trim)
    End Sub
    Public ReadOnly Property Guid As Guid Implements ISensorContainer.Guid
        Get
            Return _guid
        End Get
    End Property
    Public Function PollAll() As Boolean Implements ISensorContainer.PollAll
        If TypeOf _connection Is XbeeApiConnection Then
            SyncLock XbeeGlobals.DongleLock
                If Not _timerPoll.Enabled Then Return True
                ReallyPoll()
            End SyncLock
        Else
            ReallyPoll()
        End If
        Return True
    End Function
    Private Sub ReallyPoll()
        Dim cmd As New SensorCommand
        cmd.commandText = "W" & vbCr
        cmd.responseType = SensorCommand.Enum_ResponseType.oneline
        RaiseEvent DebugMessage(Me, "==> W " & _device.ID)
        Dim buffer As String = _connection.GetCommandResponse(cmd)
        If buffer IsNot Nothing AndAlso buffer.Length = 12 Then
            RaiseEvent DebugMessage(Me, buffer)
            Dim reading As Double = Val(buffer.Trim)
            _device.CurrentReadingInDeviceUnits = reading
            _xmitFailureCount = 0
        Else
            _xmitFailureCount += 1
            '_pollAttempts += 1
            'If _pollAttempts = 150 Then
            '    RaiseEvent ContainerDisconnected(Me)
            '    Return False
            'End If
        End If
        Threading.Thread.Sleep(5000)
    End Sub
    Public Function Children() As List(Of ISensor) Implements ISensorContainer.Children
        Dim lst As New List(Of ISensor)
        lst.Add(_device)
        Return lst
    End Function
    Public ReadOnly Property ConnectionInfoString1 As String Implements ISensorContainer.ConnectionInfoString
        'container connection info string
        Get
            Return String.Format("{0} ({1})", _device.ID, _connection.ConnectionInfoString)
        End Get
    End Property

    Public Function Type() As ISensorContainer.Enum_ContainerType Implements ISensorContainer.Type
        Return ISensorContainer.Enum_ContainerType.di100x
    End Function
    Private Sub _timer_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles _timerPoll.Elapsed
        If Not _isTaring Then
            PollAll()
        End If
    End Sub
    Public Sub PollingInterval(intervalMSec As Integer) Implements ISensorContainer.SetPollingIntervalMSec
        _timerPoll.Interval = intervalMSec
    End Sub
    Public Event DebugMessage(c As ISensorContainer, msg As String) Implements ISensorContainer.DebugMessage

    Public Event ContainerDisconnected(ByVal sender As ISensorContainer) Implements ISensorContainer.ContainerDisconnected
    Private Sub DongleErrorMessage(ByVal msg As String)
        If msg.ToLower.Contains("transmission failed") AndAlso _xmitFailureCount = 10 Then
            RaiseEvent DebugMessage(Me, msg)
        End If
    End Sub
    Public Function ReadCounts() As Double
        Dim cmd = New SensorCommand
        cmd.commandText = "R" & vbCr
        cmd.responseType = SensorCommand.Enum_ResponseType.oneline
        Dim lst As New List(Of Double)
        If _connection.TryOpen Then
            For i = 1 To 50
                Dim buffer = _connection.GetCommandResponse(cmd)
                If IsNumeric(buffer) Then
                    lst.Add(Val(buffer))
                End If
            Next
            cmd.commandText = vbCr
            _connection.XmitCommand(cmd)
            _connection.XmitCommand(cmd)
            _connection.TryClose()
            Return lst.Average
        End If
        Return 0
    End Function
    Public Function ReadWeight() As Double
        Dim cmd = New SensorCommand
        cmd.commandText = "W" & vbCr
        cmd.responseType = SensorCommand.Enum_ResponseType.oneline
        Dim lst As New List(Of Double)
        If _connection.TryOpen Then
            For i = 1 To 50
                Dim buffer = _connection.GetCommandResponse(cmd)
                If IsNumeric(buffer) Then
                    lst.Add(Val(buffer))
                End If
            Next
            cmd.commandText = vbCr
            _connection.XmitCommand(cmd)
            _connection.XmitCommand(cmd)
            _connection.TryClose()
            Return lst.Average
        End If
        Return 0
    End Function
    Public Function CalculateMVolt(ByVal load() As Double, ByVal counts() As Double) As Double
        Dim Ve As Double
        Dim Gain As Double
        Dim Resolution As Long
        Dim voltsPerBit As Double
        Dim mVoltPerVolt As Double = 0
        If TypeOf _device Is di100 Then
            Ve = 3.51
            Gain = 67.67
            Resolution = 1048575
            voltsPerBit = Ve / 2 / Gain / Resolution
            mVoltPerVolt = voltsPerBit * 1000 * (counts(1) - counts(0)) * _device.CapacityInCalUnits / (load(1) - load(0)) / Ve
        Else
            Ve = 5.05
            Gain = 64
            Resolution = 16777216
            voltsPerBit = Ve / 2 / Gain / Resolution
            mVoltPerVolt = voltsPerBit * 1000 * (counts(1) - counts(0)) * _device.CapacityInCalUnits * 2 / (load(1) - load(0)) / Ve
        End If
        Return mVoltPerVolt
    End Function
    Public Function CalibrateAndBurnMVolt(ByVal load() As Double, ByVal counts() As Double) As Double
        Dim mVoltPerVolt As Double = 0
        mVoltPerVolt = CalculateMVolt(load, counts)
        If _connection.TryOpen Then
            Dim buffer As String
            Dim cmd As New SensorCommand
            cmd.responseType = SensorCommand.Enum_ResponseType.oneline
            cmd.commandText = "nCal 1" & vbCr
            buffer = _connection.GetCommandResponse(cmd)
            cmd.commandText = "CAL m" & vbCr
            buffer = _connection.GetCommandResponse(cmd)
            cmd.commandText = String.Format("mVolt {0:f6}", mVoltPerVolt) & vbCr
            buffer = _connection.GetCommandResponse(cmd)
            _connection.TryClose()
        End If

        Return mVoltPerVolt
    End Function

    Public Function CalibrateAndBurnCubic(ByVal coeff() As Double) As Boolean
        If coeff.Length <> 4 Then
            utility.Utility.ShowErrorMessage("Need 4 coeffcients for cubic calibration.")
            Return False
        End If
        Const sBurnFormat As String = "0.000000E0"
        If _connection.TryOpen Then
            Try
                Dim buffer As String
                Dim cmd As New SensorCommand
                cmd.responseType = SensorCommand.Enum_ResponseType.oneline
                cmd.commandText = "CAL c" & vbCr
                buffer = _connection.GetCommandResponse(cmd)

                Dim cmdText = New String() {"CCA", "CCB", "CCC", "CCD", "TCA", "TCB", "TCC", "TCD"}
                Dim params = New Double() {coeff(3), coeff(2), coeff(1), coeff(0), coeff(3), coeff(2), coeff(1), coeff(0)}

                For i = 0 To cmdText.Length - 1
                    cmd.commandText = cmdText(i) & " " & String.Format(params(i), sBurnFormat)
                    buffer = _connection.GetCommandResponse(cmd)
                    _connection.Flush()
                Next
                Return True
            Catch ex As Exception
                utility.Utility.ShowErrorMessage(ex.Message)
            Finally
                _connection.TryClose()
            End Try
        End If
        Return False
    End Function
    Public Function GetFirmwareSettings() As String
        If _connection.TryOpen() Then
            Dim cmd = New SensorCommand
            cmd.commandText = "SETT" & vbCr
            cmd.responseType = SensorCommand.Enum_ResponseType.stringmatch
            cmd.terminatingString = "LastTare"
            firmwareSettings = String.Empty
            For Each item In _connection.GetMultiLineResponse(cmd)
                firmwareSettings += item & vbCrLf
            Next
            _connection.TryClose()
        End If
        Return firmwareSettings
    End Function
    Public Function GetFirmwareVersion1() As String Implements ISensorContainer.GetFirmwareVersion
        If _connection.TryOpen() Then
            _connection.Flush()
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
    Public Function Connection() As IConnection
        Return _connection
    End Function
End Class
