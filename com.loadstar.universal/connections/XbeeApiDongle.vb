Imports System.IO.Ports
Imports System.Threading
Imports System.ComponentModel
Imports System.Text
Imports com.loadstar.utility
Public Class XbeeApiDongle
    Private _portName As String
    Private _baud As UInteger
    Private WithEvents _thisPort As SerialPort
    Private _nodeDiscoverDone As New ManualResetEventSlim(False)
    Private _dongleDiscoverDone As New ManualResetEventSlim(False)
    Private _currentDestAddr As UShort
    Private _lock As New Object
    Private _lstChildAddress As New List(Of UInt16)
    '
    Event XmitStatus(ByVal destAddr As UShort)
    Event DataReceived(ByVal sourceAddr As UShort, ByVal str As String)
    Private _discardInput As Boolean = False
    Private _isOperating As Boolean = False
    Event DongleErrorMessage(ByVal sender As XbeeApiDongle, ByVal msg As String)
    Event DongleInfoMessage(ByVal sender As XbeeApiDongle, ByVal msg As String)
    Private _failedCount As Integer = 0
    Private _chksumErrorCount As Integer = 0
    Enum Enum_XBeeApiType
        ModemStatus = &H8A
        ATCommand = &H8
        ATCommandQueueParameterValue = &H9
        ATCommandResponse = &H88
        RemoteCommandRequest = &H17
        RemoteCommandResponse = &H97
        XBeeSensorReadIndicator = &H94
        NodeIdentificationIndicator = &H95
        RxReceivePacket16BitAddr = &H81
        TxTransmitRequest16bitAddr = &H1
        TxTransmitRequest64bitAddr = &H0
        TxTransmitStatus = &H89
    End Enum
    Enum Enum_FrameId
        DiscoverNodes = &H11
        DiscoverDongle = &H99
    End Enum
    Enum Enum_DongleError
        TransmissionFailed = 10
    End Enum

    Public Sub New(ByVal portName As String, ByVal baud As Integer)
        _portName = portName
        _baud = baud
        If Not TryOpen() Then
            Throw New Exception(String.Format("Cannot open API dongle:{0}/{1}", portName, baud))
        End If
        AddHandler DongleErrorMessage, AddressOf TransmissionFailed
    End Sub
    Public Function TryOpen() As Boolean
        SyncLock _lock


            Dim ret As Int16
            Dim msg As String = String.Empty

            If _thisPort Is Nothing Then
                Try
                    _thisPort = New SerialPort(_portName, _baud, Parity.None, 8, StopBits.One)
                    _thisPort.Handshake = Handshake.None
                    _thisPort.ReadBufferSize = 128000
                    _thisPort.ReadTimeout = 2000
                    _thisPort.WriteTimeout = 1000
                    _thisPort.DiscardNull = False 'DO NOT DISCARD NULLS in BINARY MODE!!!!
                Catch ex As Exception
                    Return False
                End Try
            ElseIf _thisPort.IsOpen() = True Then
                _isOperating = True
                Return True
            End If
            Do
                Try

                    _thisPort.Open()
                    _isOperating = True
                    Debug.Print("dongle opened")
                    ' MsgBox("Dongle opened")
                    Return True
                Catch ex As Exception
                    Debug.Print("unable to open dongle")
                    Return False
                    ''cannot open port
                    'ret = MsgBox("Error opening " & _portName & vbCrLf & msg, MsgBoxStyle.RetryCancel + MsgBoxStyle.Question)
                    'If ret = MsgBoxResult.Retry Then
                    '    Continue Do
                    'Else
                    '    Return False
                    'End If
                End Try
            Loop
        End SyncLock
    End Function
    Public Function TryClose() As Boolean
        SyncLock _lock
            If _thisPort Is Nothing OrElse _thisPort.IsOpen = False Then Return True
            Try
                'port is open
                _thisPort.Close()
                Do
                    Thread.Sleep(100)
                Loop Until _thisPort.IsOpen() = False
                Debug.Print("dongle closed")
                _isOperating = False
                Return True
            Catch ex As Exception
                Debug.Print("Unable to close dongle")
                'MsgBox(String.Format("Unable to close port {0}{1}{2}", _portName, vbCrLf, ex.Message))
                Return False
            End Try
        End SyncLock
    End Function
    Public Property DiscardInput() As Boolean
        Get
            Return _discardInput
        End Get
        Set(ByVal value As Boolean)
            _discardInput = value
        End Set
    End Property

    Public Function XmitCommand(ByVal commandText As String, ByVal destAddr As UInt16) As Boolean
        SyncLock _lock
            Dim bytes = EncodeTxPacket(commandText, destAddr)
            If _thisPort.IsOpen Then
                _thisPort.Write(bytes, 0, bytes.Length)
                _currentDestAddr = destAddr
            End If
        End SyncLock
        Return True
    End Function
    'Public Function ScanForDevices() As Boolean
    '    _lstChildAddress.Clear()
    '    Dim bytes = EncodeGetRemoteAddresses()
    '    Debug.Assert(_thisPort.IsOpen)
    '    _thisPort.Write(bytes, 0, bytes.Length)
    '    'Thread.Sleep(5000)
    '    Return True
    'End Function
    Public Function DiscoverNodes() As Boolean
        SyncLock _lock
            _lstChildAddress.Clear()
            Dim bytes = EncodeNodeDiscovery()
            Debug.Assert(_thisPort.IsOpen)
            _nodeDiscoverDone.Reset()
            _thisPort.Write(bytes, 0, bytes.Length)
            _nodeDiscoverDone.Wait(90000)
            BroadcastVbCrs()
            Flush()
            Return True
        End SyncLock
    End Function
    Public Function IsApiDongle() As Boolean
        SyncLock _lock
            Dim bytes = EncodeDongleDiscovery()
            Debug.Assert(_thisPort.IsOpen)
            _dongleDiscoverDone.Reset()
            _thisPort.Write(bytes, 0, bytes.Length)
            _dongleDiscoverDone.Wait(1000)
            Return _dongleDiscoverDone.IsSet
        End SyncLock
    End Function
    Public Function BroadcastVbCrs() As Boolean
        For i = 1 To 2
            XmitCommand(vbCr, &HFFFF)
            Thread.Sleep(1000)
        Next
        Return True
    End Function
    Private Function Flush() As Boolean
        SyncLock _lock
            _discardInput = True
            With _thisPort
                If .IsOpen() Then
                    Dim buffer As String
                    Do
                        Try
                            If _thisPort.BytesToRead <> 0 Then
                                buffer = _thisPort.ReadExisting
                            End If
                        Catch ex As Exception
                        End Try
                        Thread.Sleep(1000)
                    Loop Until _thisPort.BytesToRead = 0
                End If
            End With
            _discardInput = False
        End SyncLock
        Return True
    End Function
    Private Shared Function EncodeTxPacket(ByVal cmd As String, ByVal destAddr As UInt16) As Byte()
        Dim startDelimiter As Byte = &H7E
        Dim apiIdentifier As Byte = &H1
        Dim sizeHighByte As Byte = 0
        Dim sizeLowByte As Byte = 0
        Dim frameId As Byte = &H1 ' 0 - disable response, anything else - enable response 
        Dim destAddrHigh As Byte = CInt(destAddr \ 256)
        Dim destAddrLow As Byte = Convert.ToByte(destAddr Mod 256)
        Dim options As Byte = 0
        Dim size As Integer = 0
        '
        'packet size = cmd.length + 5 bytes(apiIdentifier,frameId,dest High and Low,options)
        '
        size = cmd.Length() + 5
        sizeHighByte = size / 256
        sizeLowByte = size Mod 256

        Dim bytes As New List(Of Byte)
        bytes.Add(apiIdentifier)
        bytes.Add(frameId)
        bytes.Add(destAddrHigh)
        bytes.Add(destAddrLow)
        bytes.Add(options)
        For Each c As Char In cmd
            bytes.Add(Convert.ToByte(c))
        Next
        Dim chk As New XBeeChecksum
        chk.AddBytes(bytes.ToArray)
        bytes.Add(chk.ComputeChecksum)
        bytes.Insert(0, sizeLowByte)
        bytes.Insert(0, sizeHighByte)
        bytes.Insert(0, startDelimiter)
        Return bytes.ToArray
    End Function
    Private Shared Function EncodeGetRemoteAddresses() As Byte()
        Dim startDelimiter As Byte = &H7E
        Dim apiIdentifier As Byte = Enum_XBeeApiType.RemoteCommandRequest ' &H17
        Dim sizeHighByte As Byte = 0
        Dim sizeLowByte As Byte = 0
        Dim frameId As Byte = &H1 ' 0 - disable response, 1-enable response

        'AT command is always 2 chars
        'Length [Bytes] = API Identifier + Frame ID + AT Command
        'so packet size is always 4

        sizeHighByte = 0
        sizeLowByte = &HF

        Dim bytes As New List(Of Byte)
        bytes.Add(apiIdentifier)
        bytes.Add(frameId)
        '
        '64 bit dest address field, ignored
        '
        For i = 0 To 7
            bytes.Add(0)
        Next
        bytes.Add(&HFF) 'broadcast address
        bytes.Add(&HFF)
        bytes.Add(0) 'options, none
        bytes.Add(Convert.ToByte("S"c)) 'ATSL command to get serial number low
        bytes.Add(Convert.ToByte("L"c))
        Dim chk As New XBeeChecksum
        chk.AddBytes(bytes.ToArray)
        bytes.Add(chk.ComputeChecksum)
        bytes.Insert(0, sizeLowByte)
        bytes.Insert(0, sizeHighByte)
        bytes.Insert(0, startDelimiter)
        Return bytes.ToArray
    End Function

    Private Shared Function EncodeNodeDiscovery() As Byte()
        Dim startDelimiter As Byte = &H7E
        Dim apiIdentifier As Byte = Enum_XBeeApiType.ATCommand
        Dim sizeHighByte As Byte = 0
        Dim sizeLowByte As Byte = 0
        Dim frameId As Byte = Enum_FrameId.DiscoverNodes

        'AT command is always 2 chars
        'Length [Bytes] = API Identifier + Frame ID + AT Command
        'so packet size is always 4

        sizeHighByte = 0
        sizeLowByte = &H4

        Dim bytes As New List(Of Byte)
        bytes.Add(apiIdentifier)
        bytes.Add(frameId)
        '
        'ND command
        '
        bytes.Add(Convert.ToByte("N"c)) 'ATSL command to get serial number low
        bytes.Add(Convert.ToByte("D"c))
        Dim chk As New XBeeChecksum
        chk.AddBytes(bytes.ToArray)
        bytes.Add(chk.ComputeChecksum)
        bytes.Insert(0, sizeLowByte)
        bytes.Insert(0, sizeHighByte)
        bytes.Insert(0, startDelimiter)
        Return bytes.ToArray
    End Function
    Private Shared Function EncodeDongleDiscovery() As Byte()
        'just encode an ATSL command
        Dim startDelimiter As Byte = &H7E
        Dim apiIdentifier As Byte = Enum_XBeeApiType.ATCommand
        Dim sizeHighByte As Byte = 0
        Dim sizeLowByte As Byte = 0
        Dim frameId As Byte = Enum_FrameId.DiscoverDongle

        'AT command is always 2 chars
        'Length [Bytes] = API Identifier + Frame ID + AT Command
        'so packet size is always 4

        sizeHighByte = 0
        sizeLowByte = &H4

        Dim bytes As New List(Of Byte)
        bytes.Add(apiIdentifier)
        bytes.Add(frameId)
        '
        'ND command
        '
        bytes.Add(Convert.ToByte("S"c)) 'ATSL command to get serial number low
        bytes.Add(Convert.ToByte("L"c))
        Dim chk As New XBeeChecksum
        chk.AddBytes(bytes.ToArray)
        bytes.Add(chk.ComputeChecksum)
        bytes.Insert(0, sizeLowByte)
        bytes.Insert(0, sizeHighByte)
        bytes.Insert(0, startDelimiter)
        Return bytes.ToArray
    End Function
    Private Sub WaitForNBytes(ByVal n As Integer)
        Do
        Loop Until _thisPort.BytesToRead >= n
    End Sub
    Private Function ReadPacketSize() As UShort
        Dim sizeHighbyte = _thisPort.ReadByte
        Dim sizeLowByte = _thisPort.ReadByte
        Return sizeHighbyte * 256 + sizeLowByte
    End Function

    Private Sub _thisPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles _thisPort.DataReceived
        If _discardInput Then Return
        Dim statusByte As Byte
        Dim inBytes(120) As Byte
        Dim checkByte As Byte
        Dim chksum As New XBeeChecksum
        Dim b As Byte
        Static sb As New StringBuilder

        If Not _isOperating Then Return
        Try
            If _thisPort.BytesToRead > 0 Then
                b = _thisPort.ReadByte()
                If b = &H7E Then
                    Dim packetSize = ReadPacketSize()
                    WaitForNBytes(packetSize)
                    _thisPort.Read(inBytes, 0, packetSize)
                    WaitForNBytes(1)
                    checkByte = _thisPort.ReadByte
                    If chksum.Verify(inBytes, packetSize, checkByte) Then
                        Dim apiIdentifer = inBytes(0)
                        Select Case apiIdentifer
                            Case Enum_XBeeApiType.TxTransmitStatus '&H89 'xmit status
                                statusByte = inBytes(2)
                                If statusByte = 0 Then
                                    'xmit success
                                    RaiseEvent XmitStatus(_currentDestAddr)
                                    _failedCount = 0
                                Else
                                    _failedCount += 1
                                    RaiseEvent DongleErrorMessage(Me, "transmission failed:" & _currentDestAddr)
                                    RaiseEvent XmitStatus(0)
                                End If
                            Case Enum_XBeeApiType.RxReceivePacket16BitAddr '&H81 'RX 16 bit address packet
                                Dim sourceAddr As UShort = inBytes(1) * 256 + inBytes(2)
                                sb.Length = 0
                                For i = 5 To 2 + packetSize
                                    Dim ch = Convert.ToChar(inBytes(i))
                                    sb.Append(ch)
                                Next
                                RaiseEvent DataReceived(sourceAddr, sb.ToString)
                            Case Enum_XBeeApiType.RemoteCommandResponse '&H97
                                '
                                'remote AT command response for serial number low
                                '
                                'input bytes -->API identifier (0), Frame ID (1), 64 bit address (2-9), 16 bit address (10-11), 
                                Dim deviceAddress As UInt16
                                deviceAddress = inBytes(10) * 256 + inBytes(11)
                                If Not _lstChildAddress.Contains(deviceAddress) Then
                                    _lstChildAddress.Add(deviceAddress)
                                    RaiseEvent DongleInfoMessage(Me, "Router discovered:  " & deviceAddress)
                                End If
                            Case Enum_XBeeApiType.ATCommandResponse '&H88
                                Select Case inBytes(1)
                                    Case Enum_FrameId.DiscoverNodes
                                        Dim deviceAddress As UInt16
                                        deviceAddress = inBytes(5) * 256 + inBytes(6)
                                        Debug.Print(deviceAddress)
                                        If deviceAddress = 0 Then
                                            'last device for now
                                            _nodeDiscoverDone.Set()
                                            RaiseEvent DongleInfoMessage(Me, "Discover complete received: Number of devices:" & _lstChildAddress.Count)
                                        ElseIf Not _lstChildAddress.Contains(deviceAddress) Then
                                            RaiseEvent DongleInfoMessage(Me, "Router discovered:" & deviceAddress)
                                            _lstChildAddress.Add(deviceAddress)
                                        Else
                                            RaiseEvent DongleInfoMessage(Me, "Router re-discovered?:" & deviceAddress)
                                            _lstChildAddress.Add(deviceAddress)
                                        End If
                                    Case Enum_FrameId.DiscoverDongle
                                        _dongleDiscoverDone.Set()
                                End Select
                        End Select
                    Else
                        RaiseEvent DongleErrorMessage(Me, "Chksum Error")
                    End If
                End If
            End If

        Catch ex As Exception
            RaiseEvent DongleErrorMessage(Me, ex.Message)
            Debug.Print(ex.Message)
            Return
        End Try

    End Sub
    Public Function GetSlaveDeviceAddresses() As UInt16()
        _lstChildAddress.Sort()
        Return _lstChildAddress.ToArray
    End Function
    Public ReadOnly Property PortName() As String
        Get
            Return _portName
        End Get
    End Property
    Public ReadOnly Property BaudRate As UInteger
        Get
            Return Me._baud
        End Get
    End Property

    Protected Overrides Sub Finalize()
        BroadcastVbCrs()
        Flush()
        TryClose()
        MyBase.Finalize()
    End Sub
    Public Sub Dispose()
        TryClose()
    End Sub
    Public Function IsOpen() As Boolean
        Return (_thisPort IsNot Nothing AndAlso _thisPort.IsOpen)
    End Function
    Private Sub TransmissionFailed(ByVal sender As XbeeApiDongle, ByVal msg As String)
        SyncLock _lock
            Debug.Print(_failedCount)
            If _failedCount > 10 Then
                _failedCount = 0
                TryClose()
                TryOpen()
                DiscoverNodes()
            End If
        End SyncLock
    End Sub
    Private Sub ChecksumError(ByVal sender As XbeeApiDongle, ByVal msg As String)
        SyncLock _lock
            _chksumErrorCount += 1
            If _chksumErrorCount = 5 Then

            End If
        End SyncLock
    End Sub
    Public Sub ForceClose()
        SyncLock _lock
            If _thisPort IsNot Nothing AndAlso _thisPort.IsOpen Then
                _isOperating = False
                Try
                    _thisPort.Close()
                Catch ex As Exception
                End Try
            End If
        End SyncLock
    End Sub
End Class
