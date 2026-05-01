Imports System.IO.Ports
Imports System.Threading
Imports System.ComponentModel
Public Class SerialConnection
    Implements IConnection

    Private _portName As String = String.Empty
    Private _baud As UInteger = 9600
    Private WithEvents _thisPort As SerialPort
    Private WithEvents _bg As BackgroundWorker
    Private _streamingByteCount As UShort = 0
    Private _anyBytesToRead As New ManualResetEventSlim(True)


    Public Sub New(ByVal portName As String, ByVal baud As UInteger)
        _portName = portName
        _baud = baud
    End Sub
    Public ReadOnly Property PortName() As String
        Get
            Return _portName
        End Get
    End Property
    Public ReadOnly Property Baud() As UInteger
        Get
            Return _baud
        End Get
    End Property
    Public Function GetCommandResponse(ByVal cmd As SensorCommand) As String Implements IConnection.GetCommandResponse
        Trace.Assert(_thisPort.IsOpen, "Port not open")
        If _thisPort.IsOpen Then
            Try
                Dim buffer As String = String.Empty
                buffer = _thisPort.ReadExisting
                _thisPort.DiscardInBuffer()
                _thisPort.ReceivedBytesThreshold = 1
                _anyBytesToRead.Reset()
                SerialPortSlowWrite(cmd.commandText, 10)
                _anyBytesToRead.Wait(2000)
                If _thisPort.BytesToRead <> 0 Then
                    buffer = _thisPort.ReadTo(vbCr).Trim
                    If buffer.Length = 0 Then
                        buffer = _thisPort.ReadTo(vbCr).Trim
                    End If
                    _thisPort.DiscardInBuffer()
                    Return buffer
                End If
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End If
        Return String.Empty
    End Function

    Public Function TryClose() As Boolean Implements IConnection.TryClose
        If _thisPort Is Nothing OrElse _thisPort.IsOpen = False Then Return True
        Try
            _thisPort.Close()
            Do
            Loop Until _thisPort.IsOpen() = False
            Return True
        Catch ex As Exception
            MsgBox(String.Format("Unable to close port {0}{1}{2}", _portName, vbCrLf, ex.Message))
            Return False
        End Try
    End Function

    Public Function TryOpen() As Boolean Implements IConnection.TryOpen
        Dim ret As Int16
        Dim msg As String = String.Empty

        If _thisPort Is Nothing Then
            Try
                _thisPort = New SerialPort(_portName, _baud, Parity.None, 8, StopBits.One)
                _thisPort.Handshake = Handshake.None
                _thisPort.ReadBufferSize = 128000
                _thisPort.ReadTimeout = 2000
                _thisPort.WriteTimeout = 1000
                _thisPort.DiscardNull = True
                _thisPort.ReceivedBytesThreshold = 10000
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
    End Function
    Private Sub SerialPortSlowWrite(ByVal str As String, Optional ByVal delay As UShort = 1)
        If _thisPort.IsOpen Then
            For Each ch As Char In str
                _thisPort.Write(ch)
                Thread.Sleep(delay)
            Next
        End If
    End Sub

    Public ReadOnly Property IsConnected As Boolean Implements IConnection.IsConnected
        Get
            Return _thisPort IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property ConnectionInfoString As String Implements IConnection.ConnectionInfoString
        Get
            Return String.Format("{0},{1}", PortName, Baud.ToString("0"))
        End Get
    End Property

    Public Function Flush() As Boolean Implements IConnection.Flush

        Try
            If Not _thisPort.IsOpen() Then Return True
            SerialPortSlowWrite(vbCr & vbCr)
            Do
                Dim buffer = _thisPort.ReadExisting
                Thread.Sleep(250)
            Loop Until _thisPort.BytesToRead() = 0
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function XmitCommand(ByVal cmd As SensorCommand) As Boolean Implements IConnection.XmitCommand
        'Debug.Assert(_thisPort.IsOpen, "XmitCommand:Port is closed")
        If _thisPort.IsOpen() Then
            SerialPortSlowWrite(cmd.commandText)
        End If
        Return True
    End Function

    Public Function XmitStreamingCommand(commandText As String) As Boolean Implements IConnection.XmitStreamingCommand
        'Debug.Assert(_thisPort.IsOpen, "XmitCommand:Port is closed")
        If _thisPort.IsOpen() Then
            SerialPortSlowWrite(commandText)
        End If
        Return StartReading()
    End Function

    Private Function StartReading() As Boolean
        _bg = New BackgroundWorker
        _bg.WorkerSupportsCancellation = True
        _bg.RunWorkerAsync()
        Return True
    End Function

    Public Function StopReading() As Boolean Implements IConnection.StopReading
        If _bg IsNot Nothing Then
            _bg.CancelAsync()
        End If
        Thread.Sleep(250)
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

    Private Sub _bg_DoWork(sender As Object, e As DoWorkEventArgs) Handles _bg.DoWork
        'only for streaming outputs
        Dim buffer As String = String.Empty
        Do
            Try
                If Not _thisPort.IsOpen Then Continue Do
                buffer = _thisPort.ReadTo(LineTerminator)
                If buffer.Length = _streamingByteCount Then
                    RaiseEvent SensorStringDataReceived(Me, buffer)
                End If
            Catch ex As Exception
                If _bg.CancellationPending Then Exit Do
            End Try
        Loop Until _bg.CancellationPending
        e.Cancel = True
    End Sub

    Public Event SensorStringDataReceived(ByVal sender As IConnection, ByVal data As String) Implements IConnection.SensorStringDataReceived

    Public Property LineTerminator As Char Implements IConnection.LineTerminator

    Public Function GetMultiLineResponse(ByVal command As SensorCommand) As List(Of String) Implements IConnection.GetMultiLineResponse
        Trace.Assert(_thisPort.IsOpen, "Port not open")
        Dim lstResponse As New List(Of String)
        If _thisPort.IsOpen Then
            Try
                Dim buffer As String = String.Empty
                buffer = _thisPort.ReadExisting
                _thisPort.DiscardInBuffer()
                _thisPort.ReceivedBytesThreshold = 1
                _anyBytesToRead.Reset()
                SerialPortSlowWrite(command.commandText, 10)
                _anyBytesToRead.Wait(2000)
                If command.responseType = SensorCommand.Enum_ResponseType.count Then
                    For i = 0 To command.nOutputLine - 1
                        buffer = _thisPort.ReadTo(vbCr).Trim
                        If buffer.Length = 0 Then
                            buffer = _thisPort.ReadTo(vbCr).Trim
                        End If
                        lstResponse.Add(buffer)
                    Next
                    lstResponse.Sort()
                ElseIf command.responseType = SensorCommand.Enum_ResponseType.stringmatch Then
                    Do
                        buffer = _thisPort.ReadTo(vbCr).Trim
                        If buffer.Length = 0 Then
                            buffer = _thisPort.ReadTo(vbCr).Trim
                        End If
                        lstResponse.Add(buffer)
                    Loop Until buffer.ToLower.Contains(command.terminatingString.ToLower)
                End If
                _thisPort.DiscardInBuffer()
                Return lstResponse
            Catch ex As Exception
                Debug.Print("Multi-line Response:" & ex.Message)
                Return lstResponse
            End Try
        Else
            Return lstResponse
        End If
    End Function
    Private Sub CheckIfAnythingToRead()
        Do
            Thread.Sleep(250)
        Loop Until _thisPort.BytesToRead <> 0
        'if no bytes to read this function will timeout
        If _thisPort.BytesToRead <> 0 Then
            _anyBytesToRead.Set()
        End If
    End Sub

    Private Sub _thisPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles _thisPort.DataReceived
        _anyBytesToRead.Set()

        'If _thisPort.BytesToRead <> 0 Then
        '    _anyBytesToRead.Set()
        '    _thisPort.ReceivedBytesThreshold = 10000
        'End If
    End Sub
End Class

