Imports System.Threading
Imports System.Text.RegularExpressions
Public Class SC1200Container
    Inherits Container
    Implements ISensorContainer

    Private MAX_SENSORS As UShort = 12
    Private _device(0 To MAX_SENSORS - 1) As SC1200Sensor
    Private _midIndex As UShort 'NOTE: _midIndex starts with 1
    Private _isTaring As Boolean = False
    Private _xmitFailureCount As Integer = 0
    Public Sub New(con As IConnection, expectedMidIndex As UShort)
        _connection = con
        _connection.LineTerminator = vbLf
        _timerPoll.Interval = 20000
        _timerTare.Interval = 1000
        If TypeOf _connection Is XbeeApiConnection Then
            AddHandler CType(_connection, XbeeApiConnection).RelayDongleMessage, AddressOf DongleErrorMessage
            ReadSettings(expectedMidIndex)
        Else
            'serial connection etc
            ReadSettings(expectedMidIndex)
        End If
    End Sub
    Private Sub ReadSettings(ByVal expectedMidIndex As UShort)
        Dim buffer As String
        Dim sExpected = String.Format("M{0:00}", expectedMidIndex)
        Dim ret As Boolean = False

        Dim cmd = New SensorCommand
        cmd.responseType = SensorCommand.Enum_ResponseType.oneline
        cmd.commandText = "MID " & sExpected & vbCr
        If _connection.TryOpen() Then
            buffer = _connection.GetCommandResponse(cmd)
            Do While buffer <> "MID " & sExpected
                buffer = _connection.GetCommandResponse(cmd)
            Loop
            _midIndex = expectedMidIndex
            cmd.commandText = "SNM" & vbCr
            cmd.responseType = SensorCommand.Enum_ResponseType.count
            cmd.nOutputLine = 12

            Dim lstReponse = _connection.GetMultiLineResponse(cmd)
            Dim namePattern As String = "^SNM M\d\d\.R00\.C00.S[01]\d .+$"
            For Each s In lstReponse
                If Regex.IsMatch(s, namePattern) Then
                    RaiseEvent DebugMessage(Me, s)
                    If Not s.Contains("Invalid") Then
                        Dim sensorIndex As Integer = Val(s.Substring(17, 2)) - 1
                        Dim sensorName As String = s.Substring(20)
                        _device(sensorIndex) = New SC1200Sensor(Me, sensorIndex)
                        _device(sensorIndex).ID = sensorName
                        _device(sensorIndex).Units.CalibratedUnits = "lb"
                    End If
                Else
                    RaiseEvent DebugMessage(Me, "???" & s)
                End If
            Next

            cmd.commandText = "SLC" & vbCr
            Dim slcPattern As String = "^SLC M\d\d\.R00\.C00.S[01]\d \d+$"
            lstReponse = _connection.GetMultiLineResponse(cmd)
            For Each s In lstReponse
                If Regex.IsMatch(s, slcPattern) Then
                    RaiseEvent DebugMessage(Me, s)
                    Dim sensorIndex As Integer = Val(s.Substring(17, 2)) - 1
                    Dim capacity As Double = Math.Min(1, Val(s.Substring(20)))
                    If _device(sensorIndex) IsNot Nothing Then
                        _device(sensorIndex).CapacityInCalUnits = capacity
                    End If
                End If
            Next
            _connection.TryClose()
        End If
    End Sub

    Public ReadOnly Property NoOfChannels As UShort Implements ISensorContainer.NoOfChannels
        Get
            Return 12
        End Get
    End Property

    Public Function StartReading() As Boolean Implements ISensorContainer.StartReading
        _connection.StreamingByteCount = 65
        _connection.TryOpen()
        _timerPoll.Enabled = True
        _timerTare.Enabled = True
        PollAll()
        Return True
    End Function

    Public Function StopReading() As Boolean Implements ISensorContainer.StopReading
        _timerPoll.Enabled = False
        _timerTare.Enabled = False
        _connection.Flush()
        _connection.TryClose()
        Return True
    End Function

    Public Function Tare(sensorIndex As UShort) As Boolean Implements ISensorContainer.Tare

        If _device(sensorIndex) IsNot Nothing Then
            com.loadstar.universal.Sensor.sensorsToBeTared.TryAdd(_device(sensorIndex).Guid)
            If TypeOf _connection Is XbeeApiConnection Then
                _device(sensorIndex).TareState = ISensor.Enum_TareState.NeedsTaring
                _device(sensorIndex).SetUnpolled()
            Else
                _isTaring = True
                ReallyTare(sensorIndex)
                _isTaring = False
            End If
        End If

        Return True
    End Function
    Private Function ReallyTare(sensorIndex As UShort) As Boolean

        If _device(sensorIndex).ID.Contains("Invalid") Then
            _device(sensorIndex).TareState = ISensor.Enum_TareState.NoTareNeeded
            Return False 'no sensor connected this port
        End If

        If _connection.TryOpen() Then
            Dim cmd = New SensorCommand
            cmd.responseType = SensorCommand.Enum_ResponseType.oneline
            cmd.commandText = String.Format("T M{0:00}.R00.C00.S{1:00}" & vbCr, _midIndex, sensorIndex + 1)
            RaiseEvent DebugMessage(Me, "==> " & cmd.commandText)
            Dim response = _connection.GetCommandResponse(cmd)
            RaiseEvent DebugMessage(Me, response)
            cmd.commandText = String.Empty
            RaiseEvent DebugMessage(Me, _connection.GetCommandResponse(cmd))
            RaiseEvent DebugMessage(Me, String.Format("{0} tared.", _device(sensorIndex).ID))
            Thread.Sleep(2000)
            _device(sensorIndex).TareState = ISensor.Enum_TareState.Tared
            com.loadstar.universal.Sensor.sensorsToBeTared.TryTake(_device(sensorIndex).Guid)
            _connection.Flush()
            _connection.TryClose()
        End If
        Return True
    End Function

    Public Function TareAll() As Boolean Implements ISensorContainer.TareAll
        For i = 0 To MAX_SENSORS - 1
            Tare(i)
        Next
        Return True
    End Function

    Public ReadOnly Property sensor(sensorIndex As Integer) As Sensor Implements ISensorContainer.sensor
        Get
            Return _device(sensorIndex)
        End Get
    End Property

    Public ReadOnly Property ConnectionInfoString(ByVal sensorIndex As Integer) As String Implements ISensorContainer.ConnectionInfoString
        Get
            ' Return String.Format("SC-1200, Ch:{0:00} ({1})", sensorIndex + 1, _connection.ConnectionInfoString)
            Return String.Format("M{0:00}, Ch:{1:00}, {2}", _midIndex, sensorIndex + 1, _connection.ConnectionInfoString)
        End Get
    End Property


    Private Sub _connection_SensorStringDataReceived(sender As IConnection, data As String) Handles _connection.SensorStringDataReceived

    End Sub

    Private Sub _timerPoll_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles _timerPoll.Elapsed
        'if any sensor anywhere needs taring do not poll
        If com.loadstar.universal.Sensor.sensorsToBeTared.Any Then Return
        If Not _isTaring Then
            PollAll()
        End If
    End Sub
    Private Sub _timerTare_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles _timerTare.Elapsed
        For i = 0 To MAX_SENSORS - 1
            If _device(i) IsNot Nothing Then
                If _device(i).TareState = ISensor.Enum_TareState.NeedsTaring Then
                    _timerTare.Enabled = False
                    RaiseEvent DebugMessage(Me, String.Format("{0} needs taring.", _device(i).ID))
                    If TypeOf _connection Is XbeeApiConnection Then
                        ReallyTare(i)
                        'if no sensor needs taring poll
                        If Not (From item In _device Where item IsNot Nothing AndAlso item.TareState = ISensor.Enum_TareState.NeedsTaring Select item).Any Then
                            ReallyPoll()
                        End If

                    Else
                        ReallyTare(i)
                    End If
                    _timerTare.Enabled = True
                    Return
                End If
            End If
        Next
    End Sub
    Public ReadOnly Property Guid As Guid Implements ISensorContainer.Guid
        Get
            Return _guid
        End Get
    End Property

    Public Function PollAll() As Boolean Implements ISensorContainer.PollAll
        If (From item In _device Where item IsNot Nothing).Any Then
            'poll only if there are attached sensors
            If TypeOf _connection Is XbeeApiConnection Then
                If Not _timerPoll.Enabled Then Return True
                _timerPoll.Enabled = False
                ReallyPoll()
                _timerPoll.Enabled = True
            Else
                ReallyPoll()
            End If
        End If
        Return True
    End Function
    Private Function ReallyPoll() As Boolean
        'if any sensor needs taring don't poll
        For i = 0 To MAX_SENSORS - 1
            If _device(i) IsNot Nothing AndAlso _device(i).TareState = ISensor.Enum_TareState.NeedsTaring Then
                Return True
            End If
        Next
        Dim cmd As New SensorCommand

        Static wtPattern As String = "^W M\d\d\.R00\.C00.S[01]\d (-){0,1}\d+$"
        cmd.commandText = "W" & vbCr
        cmd.responseType = SensorCommand.Enum_ResponseType.count
        cmd.nOutputLine = 12
        'RaiseEvent DebugMessage(Me, "==> " & cmd.commandText & _midIndex.ToString("00"))
        RaiseEvent DebugMessage(Me, String.Format("==> {0}{1} ({2}, UTC:{3})", cmd.commandText, _midIndex.ToString("00"), Now.ToShortTimeString, Now.ToUniversalTime.ToShortTimeString))

        Dim lst As List(Of String)
        lst = _connection.GetMultiLineResponse(cmd)
        If lst.Count = 0 Then
            '_connection.Flush()
            _xmitFailureCount += 1
            cmd.responseType = SensorCommand.Enum_ResponseType.ack
            cmd.commandText = vbCr
            Dim s = _connection.GetCommandResponse(cmd)
            RaiseEvent DebugMessage(Me, s)
            Threading.Thread.Sleep(1000)
            Return False
        Else
            _xmitFailureCount = 0 'reset, because we got SOME data
            For Each s In lst
                RaiseEvent DebugMessage(Me, s)
                If Regex.IsMatch(s, wtPattern) Then
                    If Not s Like "*-999999*" Then
                        Dim sensorIndex As Integer = Val(s.Substring(15, 2)) - 1
                        Dim w As Double = Val(s.Substring(18) / 1000)
                        If _device(sensorIndex) IsNot Nothing Then
                            _device(sensorIndex).CurrentReadingInDeviceUnits = w
                            _device(sensorIndex).TareState = ISensor.Enum_TareState.NoTareNeeded
                        End If
                    End If
                End If
            Next
        End If
        ' Threading.Thread.Sleep(5000)
        Return True
    End Function
    Public Function Children() As List(Of ISensor) Implements ISensorContainer.Children
        Dim lst As New List(Of ISensor)
        For Each dev In _device
            If dev IsNot Nothing Then
                lst.Add(dev)
            End If
        Next
        Return lst
    End Function
    Public ReadOnly Property ConnectionInfoString1 As String Implements ISensorContainer.ConnectionInfoString
        Get
            Return String.Format("M{0:00}/{1}", _midIndex, _connection.ConnectionInfoString)
        End Get
    End Property
    Public Function Type() As ISensorContainer.Enum_ContainerType Implements ISensorContainer.Type
        Return ISensorContainer.Enum_ContainerType.sc1200
    End Function

    Public Event DebugMessage(c As ISensorContainer, msg As String) Implements ISensorContainer.DebugMessage

    Public Event ContainerDisconnected(ByVal sender As ISensorContainer) Implements ISensorContainer.ContainerDisconnected
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
    Protected Overrides Sub Finalize()
        _connection = Nothing
        MyBase.Finalize()
    End Sub

    Public Sub PollingInterval(intervalMSec As Integer) Implements ISensorContainer.SetPollingIntervalMSec
        _timerPoll.Interval = intervalMSec
    End Sub
    Private Sub DongleErrorMessage(ByVal msg As String)
        If msg.ToLower.Contains("transmission failed") AndAlso _xmitFailureCount = 10 Then
            RaiseEvent DebugMessage(Me, msg)
        End If
    End Sub
End Class
