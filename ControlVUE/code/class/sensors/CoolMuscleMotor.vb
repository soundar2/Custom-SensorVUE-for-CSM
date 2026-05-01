Imports System.Threading
Imports System.ComponentModel
Public Class CoolMuscleMotor
    Inherits LsComSensor
    Implements IConnectionInfo


    Protected Const _o0w1 As String = "?96" & vbCr
    Protected delimiters() As Char = (vbCr & vbLf).ToCharArray
    Private _pulsesPerDeg As Double
    Private _currentAngle As Double
    Private _loopCounter As UInt16 = 0
    Event LoopCounterStatus(ByVal loopCounter As Integer)
    Const CM_PulsesPerRev = 2500 'K37=5
    Private WithEvents _bg As New BackgroundWorker
    Public Enum Enum_Motor_Command
        none
        getAngleOnce
        getAngleContinous
        tare
        repeat
    End Enum
    Private _command As Enum_Motor_Command
    Private _loopStarted As Boolean = False
    Public Sub New(ByVal portName As String, ByVal baud As UInteger)
        MyBase.New(portName, baud)
        DeviceUnitType = Enum_Device_Unit_Type.Angle
        Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.angle)
        SS1 = "Motor"
        TypeDescription = "Motor"
        TryOpen()
        _pulsesPerDeg = CM_PulsesPerRev / 360
        GetAngle()
        TryClose()
        _bg.WorkerSupportsCancellation = True
    End Sub

    Public Overrides Sub StartReading()
        DisableDataReceivedEvent()
        _loopStarted = False
        _loopCounter = 0
        TryOpen()
        If ConfigXml.Instance.enableLooping Then
            _command = Enum_Motor_Command.repeat
        Else
            _command = Enum_Motor_Command.getAngleContinous
        End If
        SerialPortSlowWrite(_o0w1)
        Thread.Sleep(50)
        If Not _bg.IsBusy Then
            _bg.RunWorkerAsync()
        End If
    End Sub
    Public Overrides Sub StopReading()
        _command = Enum_Motor_Command.none
        _bg.CancelAsync()
        Thread.Sleep(500)
        DisableDataReceivedEvent()
        TryClose()
    End Sub
    Public Overrides Sub Tare()
        TryOpen()
        DisableDataReceivedEvent()
        'set the current position to 0
        SerialPortSlowWrite("|2" & vbCr)
        SerialPortSlowWrite("P=0" & vbCr)
        SerialPortSlowWrite("^" & vbCr)
        FlushThisport()
        _currentAngle = 0
        Me.CurrentReading = 0
    End Sub
    Public Sub SetSpeed(ByVal speed As UShort)
        If speed >= 1 And speed <= 100 Then
            TryOpen()
            SerialPortSlowWrite("S=" & speed & vbCr)
            TryClose()
        End If
    End Sub
    Public Sub SetAccel(ByVal accel As UShort)
        If accel >= 1 And accel <= 100 Then
            TryOpen()
            SerialPortSlowWrite("A=" & accel & vbCr)
            TryClose()
        End If
    End Sub
    Protected Overrides Sub PortDataReceived(ByVal buffer As String)

    End Sub
    Private Sub _bg_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles _bg.DoWork
        Do
            Try
                Dim buffer = _thisPort.ReadTo(vbLf)
                Select Case _command
                    Case Enum_Motor_Command.getAngleOnce, Enum_Motor_Command.getAngleContinous, Enum_Motor_Command.repeat
                        Try
                            If buffer Like "Px.1=*" Then
                                CurrentReading = Val(buffer.Substring(5)) / _pulsesPerDeg
                            End If
                        Catch ex As Exception
                        Finally
                            Select Case _command
                                Case Enum_Motor_Command.repeat
                                    With ConfigXml.Instance
                                        If .loopUntilStopped Then
                                            RepeatOnce()
                                        Else
                                            If _loopCounter <= .loopTimes Then
                                                RepeatOnce()
                                            End If
                                        End If
                                    End With
                                    Thread.Sleep(5)
                                    SerialPortSlowWrite(_o0w1) 'returns current position in pulses/rev
                                    Thread.Sleep(5)
                                Case Enum_Motor_Command.getAngleContinous
                                    SerialPortSlowWrite(_o0w1) 'returns current position in pulses/rev
                                    Thread.Sleep(5)
                            End Select
                        End Try

                End Select
            Catch ex As Exception
                If _bg.CancellationPending Then Return
            Finally

            End Try
        Loop Until _bg.CancellationPending
    End Sub
    Public Function GetAngle() As Double
        '
        'send the command for position P
        'response will be in the form P0.1=xxxx, where xxxx is the position in pulses
        'divide by pulses/deg to get current angle
        If _thisPort.IsOpen Then
            Dim buffer As String = String.Empty
            SerialPortSlowWrite("?96" & vbCr) 'returns current position in pulses/rev
            buffer = _thisPort.ReadTo(vbCr).Trim
            _thisPort.DiscardInBuffer()
            If buffer Like "Px.1=*" Then
                _currentAngle = Val(buffer.Substring(5)) / _pulsesPerDeg
                CurrentReading = _currentAngle
            End If
            Return _currentAngle
        Else
            Return 0
        End If
    End Function

    Public Sub SetAngle(ByVal deg As Double)
        _command = Enum_Motor_Command.none
        Thread.Sleep(250)
        _thisPort.DiscardInBuffer()
        Dim targetPulses As Integer = deg * _pulsesPerDeg
        Dim buffer As String = String.Format("P={0}{1}", targetPulses, vbCr)
        SerialPortSlowWrite(buffer)
        Thread.Sleep(250)
        SerialPortSlowWrite("^" & vbCr)
        If _gIsOperating Then
            EnableDataReceivedEvent()
            _command = Enum_Motor_Command.getAngleContinous
            SerialPortSlowWrite(_o0w1)
        End If
    End Sub
    Public Function GetSpeed() As Integer
        TryOpen()
        Dim buffer As String = GetCommandResponse("S" & vbCr)
        If buffer Like "S0.1=*" Then
            Return Val(buffer.Substring(5))
        Else
            Return 1
        End If
        TryClose()
    End Function
    Public Function GetAccel() As Integer
        TryOpen()
        Dim buffer As String = GetCommandResponse("A" & vbCr)
        If buffer Like "A0.1=*" Then
            Return Val(buffer.Substring(5))
        Else
            Return 1
        End If
        TryClose()
    End Function
    Protected Overrides Sub Finalize()
        TryClose()
        MyBase.Finalize()
    End Sub
    Private Sub SetAngle2(ByVal deg As Integer)
        Dim targetPulses As Integer = deg * _pulsesPerDeg
        Dim buffer As String = String.Format("P={0}{1}", targetPulses, vbCr)
        SerialPortSlowWrite(buffer)
        '  Thread.Sleep(250)
        SerialPortSlowWrite("^" & vbCr)
    End Sub
    Private Sub RepeatOnce()
        With ConfigXml.Instance
            If Convert.ToInt16(CurrentReading) = .loopFrom Then
                SetAngle2(.loopTo)
            ElseIf Convert.ToInt16(CurrentReading) = .loopTo Then
                SetAngle2(.loopFrom)
                _loopCounter += 1
                RaiseEvent LoopCounterStatus(_loopCounter)
            Else
                If Not _loopStarted Then
                    _loopStarted = True
                    SetAngle2(.loopFrom)
                End If
            End If
        End With
    End Sub
    Public Function CalculateRPS(ByVal speedUnit As Integer) As Double
        Dim pseudoPulsesPerSec = 100 'K37=5
        Dim pulsesPerSec = pseudoPulsesPerSec * speedUnit
        Return (pulsesPerSec / CM_PulsesPerRev)
    End Function

    Public ReadOnly Property ConnectionInfo As String Implements IConnectionInfo.ConnectionInfo
        Get
            Return String.Format("{0}, {1}", PortName, "Motor")
        End Get
    End Property
End Class
