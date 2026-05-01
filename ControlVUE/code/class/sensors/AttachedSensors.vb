Imports System.IO.Ports
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports com.loadstar.utility.Utility
#If Mock = False Then
Public Class AttachedSensors
    Implements IEnumerable(Of LsSensor)

    Public Shared RefreshDevices

    Public Shared Event PortScanning(ByVal portName As String, ByVal baudrate As UInteger)

    Public Shared Event SensorDetected(ByVal sensor As LsSensor)

    Public Shared Event PortError(ByVal errorMessage As String)

    Public Shared Event ProgressMessage(ByVal msg As String)

    Public Shared Sub RefreshPortList()
        _gAttachedSensors.Clear()

        Try
            DetectAllAttachedDevices()
        Catch ex As System.UnauthorizedAccessException
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Shared Function DetectCoolMuscleMotor(ByVal portName As String) As Boolean
        If Not My.Application.Info.ProductName.Contains("ControlVUE") Then
            'only controlvue supports motors
            Return False
        End If
        Dim portX As SerialPort
        Dim model As String = String.Empty
        Dim buffer As String = String.Empty
        Dim baudArray() As UInteger
        baudArray = New UInteger() {9600}
        For Each baudRate As UInteger In baudArray
            RaiseEvent PortScanning(portName, baudRate)
            portX = New SerialPort
            With portX
                .BaudRate = baudRate
                .Parity = Parity.None
                .StopBits = StopBits.One
                .DataBits = 8
                .DiscardNull = True
                .Handshake = Handshake.None
                .PortName = portName
                .ReadTimeout = 1000
                Try
                    .Open()
                    .Write("?85" & vbCr)
                    Thread.Sleep(250)
                    .Write("?85" & vbCr)
                    Do
                        buffer = buffer & .ReadExisting.Trim
                        Thread.Sleep(100)
                    Loop Until .BytesToRead = 0
                    If buffer Like "ID*:CM*" OrElse buffer Like "*ID*:CM*" Then
                        .DiscardInBuffer()
                        .Close()
                        _gAttachedSensors.Add(New CoolMuscleMotor(portName, baudRate))
                        RaiseEvent SensorDetected(_gAttachedSensors.Last)
                        Return True
                    End If
                Catch ex As Exception
                    buffer = String.Empty
                    RaiseEvent PortError(ex.Message)
                Finally
                    If .IsOpen() Then
                        .Close()
                        Do
                        Loop Until .IsOpen() = False
                    End If
                End Try
            End With
        Next
    End Function

    Private Shared Function DetectTypeOfAttachedDevice(ByVal portName As String) As Boolean
        Dim portX As SerialPort
        Dim model As String = String.Empty
        Dim buffer As String = String.Empty
        'baudArray = New UInteger() {9600, 230400, 115200}
        For Each baudRate As UInteger In ConfigXml.Instance.baudRateOrderArray
            RaiseEvent PortScanning(portName, baudRate)
            portX = New SerialPort
            With portX
                .BaudRate = baudRate
                .Parity = Parity.None
                .StopBits = StopBits.One
                .DataBits = 8
                .DiscardNull = True
                .Handshake = Handshake.None
                .PortName = portName
                .ReadTimeout = 1000
                Try
                    .Open()
                    .DiscardInBuffer()
                    .Write(vbCr)
                    Thread.Sleep(500)
                    .DiscardInBuffer()
                    .Write(vbCr)
                    Thread.Sleep(500)
                    buffer = .ReadExisting.Trim
                    If buffer = "A" Then
                        .DiscardInBuffer()
                        LsComSensor.SerialPortSlowWrite(portX, "MODEL" & vbCr)
                        Thread.Sleep(500)
                        buffer = .ReadTo(vbCr).Trim
                        .DiscardInBuffer()
                        If buffer = "E" Then
                            LsComSensor.SerialPortSlowWrite(portX, "MID" & vbCr)
                            buffer = .ReadTo(vbCr).Trim
                            .DiscardInBuffer()
                        End If
                    ElseIf buffer = "" Then
                        'is this a mitutoyo SPC-FTDI device
                        .Write("V" & vbCrLf)
                        Thread.Sleep(500)
                        buffer = .ReadExisting.Trim
                    End If
                Catch ex As Exception
                    buffer = String.Empty
                    Debug.Print(ex.Message)
                    RaiseEvent PortError(ex.Message)
                Finally
                    If .IsOpen() Then
                        .Close()
                        Do
                        Loop Until .IsOpen() = False
                    End If
                End Try
                If buffer Like "ATT M##" Then
                    Dim masterId = buffer.Substring(4, 3)
                    Dim dev = New Sc1200(buffer, portName, baudRate, masterId)
                    For i = 0 To 11
                        If dev.AttachedSensor(i).isValid Then
                            _gAttachedSensors.Add(dev.AttachedSensor(i))
                        End If
                    Next
                    RaiseEvent SensorDetected(_gAttachedSensors.Last)
                    Return True
                ElseIf buffer.Contains("DQ4000") Then
                    Dim dev As DQ4000
                    If buffer.Contains("DQ4000-HS") Then
                        dev = New DQ4000(buffer, portName, baudRate, True)
                    Else
                        dev = New DQ4000(buffer, portName, baudRate, False)
                    End If
                    For i = 0 To 3
                        _gAttachedSensors.Add(dev.AttachedSensor(i))
                    Next
                    RaiseEvent SensorDetected(_gAttachedSensors.Last)
                    SetLatencyTimer(portName)
                    Return True
                ElseIf buffer Like "FCM*HS*" Then
                    model = buffer
                    _gAttachedSensors.Add(New FcmHs1KSensor(model, portName, baudRate))
                    RaiseEvent SensorDetected(_gAttachedSensors.Last)
                    SetLatencyTimer(portName) 'always 230 baud!
                    Return True
                ElseIf buffer Like "FCM*" Then
                    model = buffer
                    _gAttachedSensors.Add(New FcmSensor(model, portName, baudRate))
                    RaiseEvent SensorDetected(_gAttachedSensors.Last)
                    SetLatencyTimer(portName)
                    Return True
                ElseIf buffer Like "*iLevel*" Then
                    model = buffer
                    _gAttachedSensors.Add(New iLevelSensor(model, portName, baudRate))
                    RaiseEvent SensorDetected(_gAttachedSensors.Last)
                    SetLatencyTimer(portName)
                    Return True
                ElseIf buffer Like "*iForce*" Then
                    model = buffer
                    _gAttachedSensors.Add(New iForceSensor(model, portName, baudRate))
                    RaiseEvent SensorDetected(_gAttachedSensors.Last)
                    SetLatencyTimer(portName)
                    Return True
                ElseIf buffer Like "iLoad*" Then
                    model = buffer
                    Dim ss1 As String = String.Empty
                    'do we want to read just the force or force and temperature
                    Try
                        .Open()
                        LsComSensor.SerialPortSlowWrite(portX, "SS1" & vbCr)
                        Thread.Sleep(500)
                        ss1 = .ReadTo(vbCr).Trim
                        .DiscardInBuffer()
                    Catch ex As Exception
                    Finally
                        .Close()
                        Do
                        Loop Until .IsOpen() = False
                    End Try
                    If ss1.StartsWith("FT") Then
                        Dim ftSensor As New ILoadForceTempSensor(ss1, portName, baudRate)
                        _gAttachedSensors.Add(ftSensor.ForceSensor)
                        RaiseEvent SensorDetected(_gAttachedSensors.Last)
                        _gAttachedSensors.Add(ftSensor.TempSensor)
                        RaiseEvent SensorDetected(_gAttachedSensors.Last)
                    Else
                        _gAttachedSensors.Add(New CapSensor(model, portName, baudRate))
                        RaiseEvent SensorDetected(_gAttachedSensors.Last)
                    End If

                    SetLatencyTimer(portName)
                    Return True
                ElseIf buffer.StartsWith("GW-SMU") Then
                    _gAttachedSensors.Add(New MitutoyoSPC(model, portName, baudRate))
                    RaiseEvent SensorDetected(_gAttachedSensors.Last)
                    Return True
                Else

                End If
            End With
        Next
        Return False 'this is not OUR ftdi sensor
    End Function

    Private Shared Sub DetectAllAttachedDevices()
        Dim allPortNames = System.IO.Ports.SerialPort.GetPortNames().Except(frmIgnorePorts.GetComPortsToIgnore()).ToList()
        Dim relayPortNames = New List(Of String)()
        If Application.ProductName.Contains("ControlVUE") Then
            Parallel.ForEach(allPortNames, Sub(portName)
                                               Dim ret = DetectNcdRelay(portName)
                                               If ret = True Then
                                                   relayPortNames.Add(portName)
                                                   Dim dev As New NcdRelayBox(portName, 115200)
                                                   _gAttachedSensors.Add(dev.Relay(0))
                                                   'raise only one relay event for each relay box
                                                   RaiseEvent SensorDetected(_gAttachedSensors.Last)
                                               End If
                                           End Sub)
        End If
        Dim thList As New List(Of Thread)

        '
        'detevt bluetooth porst and remove then
        '
        Dim bthPortNames = com.loadstar.utility.Utility.GetBlueToothPortNames()

        ' For Each portName In com.loadstar.utility.Utility.GetFtdiSerialPortNames()
        For Each portName In allPortNames.Except(bthPortNames).Except(relayPortNames).ToList()
            Dim t As New Thread(AddressOf DetectOneDevice)
            t.IsBackground = True
            t.Start(portName)
            thList.Add(t)
        Next
        For Each t In thList
            t.Join()
        Next

    End Sub

    Private Shared Sub DetectOneDevice(ByVal portName As String)
        Try

            Dim ret As Boolean = False
            Try
                If ret = False Then
                    ret = DetectTypeOfAttachedDevice(portName)
                End If
                If ret = False Then
                    ret = DetectCoolMuscleMotor(portName)
                End If
            Catch ex As Exception
                ret = DetectCoolMuscleMotor(portName)
            End Try
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Shared Function DetectNcdRelay(ByVal portName As String) As Boolean
        Dim buffer As String = String.Empty
        RaiseEvent PortScanning(portName, 115200)
        Dim ncd1 As New NCD.NCDComponent
        ncd1.UsingComPort = True
        ncd1.PortName = portName
        ncd1.BaudRate = 115200
        ncd1.ProXR.RelayBanks.SelectBank(1)
        Try
            ncd1.OpenPort()
            If ncd1.IsOpen() Then
                Dim status = ncd1.ProXR.RelayBanks.GetStatus(0).ToString()
                If status = "ON" OrElse status = "OFF" Then
                    RaiseEvent ProgressMessage("Relay detected:" + portName)
                End If
                ncd1.ClosePort()
                Return True
            End If
        Catch ex As Exception
            ncd1.ClosePort()
        End Try
        Return False
    End Function



    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of LsSensor) Implements System.Collections.Generic.IEnumerable(Of LsSensor).GetEnumerator
        Return _gAttachedSensors.GetEnumerator
    End Function

    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return _gAttachedSensors.GetEnumerator
    End Function

    Public Shared Function Contains(ByVal ss1 As String) As Boolean
        Return (From s In _gAttachedSensors Where s.SS1 = ss1 Select s).Any
    End Function

    Public Shared Function Find(ByVal ss1 As String) As LsSensor
        Return (From s In _gAttachedSensors Where s.SS1 = ss1 Select s).SingleOrDefault
    End Function

End Class
#End If

