Imports System.Text
Imports System.Threading
Imports System.Net.Sockets
Imports System.IO
Imports System.Net
Imports com.loadstar.utility
Imports System.ComponentModel
Public Class WiFiConnection
    Implements IConnection

    Public Enum ENUM_WIFI_ERROR
        Connected = 0
        CannotPing = 1
        CannotConnect = 2
        Disconnected = 3
    End Enum

    Public Enum ENUM_CmdType
        None
        CheckConnection
        SingleRead
        ContinuousRead
        Flush
    End Enum
    Private _streamingByteCount As UShort = 0
    Private _hostIp As String
    Private _portNo As UInteger
    Private _tcpClient As TcpClient = Nothing
    Private _reading As Double
    Private _sr As StreamReader
    Private _connectDone As New ManualResetEvent(False)
    Private _writeDone As New ManualResetEvent(False)
    Private _readDone As New ManualResetEvent(False)
    Private _response As String = String.Empty
    Private _cmdState As ENUM_CmdType = ENUM_CmdType.None
    Private _isConnected As Boolean = False
    Event WiFiDisconnected()
    Private _sensorIsAlive As Boolean = False
    Private WithEvents _heartbeatTimer As New System.Timers.Timer
    Private _deadEventCounter As Integer = 0
    Private _streamingCommand As String = String.Empty
    Private _lock As New ReaderWriterLockSlim
    Public Sub New(ByVal hostIp As String, ByVal portNo As UInteger)
        _hostIp = hostIp
        _portNo = portNo
        _heartbeatTimer.Interval = 30000
        Select Case TryOpen()
            Case False
                Throw New Exception("Cannot Ping or connect" & _hostIp)
        End Select
    End Sub

    Public Function GetCommandResponse(ByVal cmd As SensorCommand) As String Implements IConnection.GetCommandResponse
        If _tcpClient IsNot Nothing Then
            _readDone.Reset()
            _cmdState = ENUM_CmdType.SingleRead
            _response = String.Empty
            Write(cmd.commandText)
            If _readDone.WaitOne(10000) Then
                Return _response
            End If
            _cmdState = ENUM_CmdType.None
        End If
        Return String.Empty
    End Function

    Public Function TryClose() As Boolean Implements IConnection.TryClose
        If _isConnected Then
            SyncLock _lock
                Thread.Sleep(1000)
                _tcpClient.Close()
                _tcpClient = Nothing
                _isConnected = False
                MessageLog.Instance.Append("Closed:" & _hostIp)
                _deadEventCounter = 0
            End SyncLock
            Return True
        End If
        Return True
    End Function

    Public Function TryOpen() As Boolean Implements IConnection.TryOpen
        If My.Computer.Network.Ping(_hostIp) Then
            Try
                Hourglass.Show()
                Dim remoteEp As New IPEndPoint(IPAddress.Parse(_hostIp), _portNo)
                _connectDone.Reset()
                _tcpClient = New TcpClient
                _tcpClient.ExclusiveAddressUse = True
                _tcpClient.BeginConnect(_hostIp, _portNo, AddressOf OnConnected, Nothing)
                _cmdState = ENUM_CmdType.CheckConnection
                Dim ret As Boolean = _connectDone.WaitOne(5000)
                _cmdState = ENUM_CmdType.None
                Return ret
            Catch ex As Exception
                Debug.Print(ex.Message)
                Return False
            Finally
                Hourglass.Release()
            End Try
        Else
            MessageLog.Instance.Append("Cannot Ping:" & _hostIp)
            Return False
        End If
    End Function


    Public ReadOnly Property IsConnected As Boolean Implements IConnection.IsConnected
        Get
            Return _isConnected
        End Get
    End Property

    Public ReadOnly Property ConnectionInfoString As String Implements IConnection.ConnectionInfoString
        Get
            Return String.Format("{0},{1}", _hostIp, _portNo)
        End Get
    End Property

    Public Function Flush() As Boolean Implements IConnection.Flush
        _cmdState = ENUM_CmdType.Flush
        Return True
    End Function

    Public Function XmitCommand(ByVal cmd As SensorCommand) As Boolean Implements IConnection.XmitCommand
        If _tcpClient IsNot Nothing Then
            SyncLock _lock
                If _isConnected AndAlso _tcpClient.Connected Then
                    Dim bytes() As Byte = Encoding.ASCII.GetBytes(cmd.commandText)
                    Hourglass.Show()
                    _writeDone.Reset()
                    _tcpClient.GetStream.BeginWrite(bytes, 0, bytes.Length, AddressOf OnDataWrite, Nothing)
                    Return _writeDone.WaitOne(1000)
                    Hourglass.Release()
                End If
            End SyncLock
        End If
        Return True
    End Function

    Public Function XmitStreamingCommand(commandText As String) As Boolean Implements IConnection.XmitStreamingCommand
        If _tcpClient IsNot Nothing Then
            ' _cmdState = ENUM_CmdType.Flush
            _cmdState = ENUM_CmdType.ContinuousRead
            _heartbeatTimer.Enabled = True
            Write(commandText)
            Return StartReading()
        End If
        Return False
    End Function

    Private Function StartReading() As Boolean
        Return True
    End Function

    Public Function StopReading() As Boolean Implements IConnection.StopReading
        Flush()
        Return True
    End Function

    Public Property StreamingBytesPerReading As UShort Implements IConnection.StreamingByteCount
        Get
            Return _streamingByteCount
        End Get
        Set(value As UShort)
            _streamingByteCount = Math.Max(3, value)
        End Set
    End Property

    Public Event SensorStringDataReceived(ByVal sender As IConnection, ByVal data As String) Implements IConnection.SensorStringDataReceived
    Private Sub OnConnected(ByVal result As IAsyncResult)
        Try
            'connected but not conclusive
            'we have to write something
            'ony if we can get something back then it is connected
            _tcpClient.EndConnect(result)
            MessageLog.Instance.Append("Opened:" & _hostIp)
            Dim buffer(_tcpClient.ReceiveBufferSize) As Byte
            _tcpClient.GetStream.BeginRead(buffer, 0, buffer.Length, AddressOf OnDataRead, buffer)
            'write a VBCR to check connection
            'Dim bytes() As Byte = Encoding.ASCII.GetBytes(vbCr)
            Dim bytes() As Byte = Encoding.ASCII.GetBytes("MODEL" & vbCr)

            _tcpClient.GetStream.BeginWrite(bytes, 0, bytes.Length, AddressOf OnDataWrite, Nothing)
            Thread.Sleep(500)
        Catch ex As Exception
            MessageLog.Instance.Append(ex.Message)
        End Try
    End Sub
    Private Sub OnDataWrite(ByVal result As IAsyncResult)
        Try
            If _isConnected AndAlso _tcpClient.Connected Then
                SyncLock _lock
                    _tcpClient.GetStream.EndWrite(result)
                    MessageLog.Instance.Append("Write Success:" & _hostIp)
                    _writeDone.Set()
                End SyncLock
            End If
        Catch ex As Exception
            MessageLog.Instance.Append("Write Error:" & _hostIp)
        End Try
    End Sub
    Private Sub OnDataRead(ByVal result As IAsyncResult)
        Dim read As Integer
        Try
            SyncLock _lock
                If _tcpClient Is Nothing Then Return 'client closed
            End SyncLock

            read = _tcpClient.GetStream.EndRead(result) 'no of characters read
            If read = 0 Then
                Return
            End If
            Dim byteArray() As Byte = CType(result.AsyncState, Byte())
            'Array.Resize(byteArray, read)
            Dim strData As String = Encoding.ASCII.GetString(byteArray, 0, read)
            Dim sr As New StringReader(strData)

            _response = String.Empty
            Do While sr.Peek > 0
                Select Case _cmdState
                    Case ENUM_CmdType.CheckConnection
                        sr.ReadToEnd() 'ignore response
                        _isConnected = True
                        _connectDone.Set()
                    Case ENUM_CmdType.ContinuousRead
                        Dim buf As String
                        buf = sr.ReadLine
                        RaiseEvent SensorStringDataReceived(Me, buf)
                        _sensorIsAlive = True
                        Thread.Sleep(1)
                    Case ENUM_CmdType.SingleRead
                        _response = sr.ReadToEnd
                        _readDone.Set()
                    Case ENUM_CmdType.Flush
                        sr.ReadToEnd()
                End Select
            Loop
            SyncLock _lock
                If _tcpClient IsNot Nothing AndAlso _tcpClient.Connected Then
                    _tcpClient.GetStream.BeginRead(byteArray, 0, byteArray.Length, AddressOf OnDataRead, byteArray)
                Else
                    Return
                End If
            End SyncLock
        Catch ex As Exception
            Debug.Print(ex.Message)
            Return
        End Try
        If read = 0 Then
            Return
        End If

    End Sub
    Private Sub _heartbeatTimer_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles _heartbeatTimer.Elapsed
        ' If Not _gIsOperating Then Return
        Debug.Print("heartbeat")
        If _sensorIsAlive = True Then
            _sensorIsAlive = False
            _deadEventCounter = 0
        Else
            'already dead
            MessageLog.Instance.Append("No data?:" & _hostIp)
            If Not My.Computer.Network.Ping(_hostIp) Then
                MessageLog.Instance.Append("Cannot ping:" & _hostIp)
            Else
                MessageLog.Instance.Append("Retrying:" & _hostIp)
                TryClose()
                If TryOpen() Then
                    XmitStreamingCommand(_streamingCommand)
                End If
            End If
        End If
    End Sub
    Protected Overrides Sub Finalize()
        If _isConnected Then TryClose()
        MyBase.Finalize()
    End Sub
    Public Function Readline() As String
        Dim buffer As String
        buffer = _response
        Return buffer
    End Function

    Public Property LineTerminator As Char Implements IConnection.LineTerminator

    Public Function GetMultiLineResponse(ByVal command As SensorCommand) As List(Of String) Implements IConnection.GetMultiLineResponse
        Return Nothing
    End Function
End Class

