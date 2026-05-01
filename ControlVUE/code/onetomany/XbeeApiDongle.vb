Imports System.IO.Ports
Imports System.Threading
Imports System.ComponentModel
Imports System.Text
Public Class XbeeApiDongle
    Private _portName As String
    Private _baud As UInteger
    Private WithEvents _thisPort As SerialPort
    Private _xmitEvent As New ManualResetEventSlim(False)
    Private _currentDestAddr As UShort
    Private _lock As New Object
    Private _lstChildAddress As New List(Of UInt16)
    '
    Event XmitStatus(ByVal destAddr As UShort)
    Event DataReceived(ByVal sourceAddr As UShort, ByVal str As String)
    Public Sub New(ByVal portName As String, ByVal baud As Integer)
        _portName = portName
        _baud = baud
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
                Return True
            End If
            Do
                Try
                    _thisPort.Open()
                    Return True
                Catch ex As Exception
                    'cannot open port
                    ret = MsgBox("Error opening " & _portName & vbCrLf & msg, MsgBoxStyle.RetryCancel + MsgBoxStyle.Question)
                    If ret = MsgBoxResult.Retry Then
                        Continue Do
                    Else
                        Return False
                    End If
                End Try
            Loop
        End SyncLock
    End Function
    Public Function TryClose() As Boolean
        SyncLock _lock
            If _thisPort Is Nothing OrElse _thisPort.IsOpen = False Then Return True
            Try
                'port is open
                _thisPort.Write(vbCr)
                _thisPort.Write(vbCr)
                FlushThisport()
                _thisPort.Close()
                Do
                Loop Until _thisPort.IsOpen() = False
                Return True
            Catch ex As Exception
                MsgBox(String.Format("Unable to close port {0}{1}{2}", _portName, vbCrLf, ex.Message))
                Return False
            End Try

        End SyncLock
    End Function
    Protected Sub FlushThisport()
        SyncLock _lock
            With _thisPort
                If .IsOpen() Then
                    Dim buffer As String
                    Do
                        Try
                            buffer = _thisPort.ReadExisting
                        Catch ex As Exception
                        End Try
                    Loop Until _thisPort.BytesToRead = 0
                End If
            End With
        End SyncLock
    End Sub

    Public Function XmitCommand(ByVal commandText As String, ByVal destAddr As UInt16)
        SyncLock _lock
            Dim bytes = EncodeTxPacket(commandText, destAddr)
            TryOpen()
            Debug.Assert(_thisPort.IsOpen)
            _thisPort.Write(bytes, 0, bytes.Length)
            _currentDestAddr = destAddr
        End SyncLock

        Return True
    End Function
    Public Function ScanForDevices() As Boolean
        _lstChildAddress.Clear()
        Dim bytes = EncodeGetRemoteAddresses()
        Debug.Assert(_thisPort.IsOpen)
        _thisPort.Write(bytes, 0, bytes.Length)
        Thread.Sleep(5000)
        Return True
    End Function
    Public Function BroadcastVbCrs() As Boolean
        For i = 1 To 2
            XmitCommand(vbCr, &HFFFF)
            Thread.Sleep(500)
        Next
        Return True
    End Function
    Public Function Flush(ByVal destAddr As UShort) As Boolean
        SyncLock _lock
            XmitCommand(vbCr, destAddr)
            Thread.Sleep(250)
            XmitCommand(vbCr, destAddr)
        End SyncLock
    End Function
    Private Shared Function EncodeTxPacket(ByVal cmd As String, ByVal destAddr As UInt16) As Byte()
        Dim startDelimiter As Byte = &H7E
        Dim apiIdentifier As Byte = &H1
        Dim sizeHighByte As Byte = 0
        Dim sizeLowByte As Byte = 0
        Dim frameId As Byte = &H1 ' 0 - disable response, 1-enable response
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
        Dim apiIdentifier As Byte = &H17
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
        Dim statusByte As Byte
        Dim inBytes(120) As Byte
        Dim checkByte As Byte
        Dim chksum As New XBeeChecksum
        Dim b As Byte
        Static sb As New StringBuilder
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
                    Case &H89 'xmit status
                        statusByte = inBytes(2)
                        If statusByte = 0 Then
                            'xmit success
                            RaiseEvent XmitStatus(_currentDestAddr)
                        Else
                            RaiseEvent XmitStatus(0)
                        End If
                    Case &H81 'RX 16 bit address packet
                        Dim sourceAddr As UShort = inBytes(1) * 256 + inBytes(2)
                        sb.Length = 0
                        For i = 5 To 2 + packetSize
                            Dim ch = Convert.ToChar(inBytes(i))
                            sb.Append(ch)
                        Next
                        '    SyncLock _lock
                        'because multiple receivers could be receiving this
                        'we need to make sure there is no conflict
                        RaiseEvent DataReceived(sourceAddr, sb.ToString)
                        '     End SyncLock
                    Case &H97
                        '
                        'remote AT command response for serial number low
                        '
                        'input bytes -->API identifier (0), Frame ID (1), 64 bit address (2-9), 16 bit address (10-11), 
                        Dim deviceAddress As UInt16
                        deviceAddress = inBytes(10) * 256 + inBytes(11)
                        If Not _lstChildAddress.Contains(deviceAddress) Then
                            _lstChildAddress.Add(deviceAddress)
                        End If
                End Select
            End If
        End If
    End Sub
    Public Function GetSlaveDeviceAddresses() As UInt16()
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
End Class
