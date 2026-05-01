Imports System.IO.Ports
Imports System.Threading
Imports System.ComponentModel
Imports System.Text
Public Class XbeeApiConnection
    Implements IConnection

    Private WithEvents _bg As BackgroundWorker
    Private WithEvents _dongle As XbeeApiDongle
    Private _currentCmd As SensorCommand
    Private _inputCharQ As Concurrent.ConcurrentQueue(Of Char)
    Private _isOperating As Boolean = True
    Private _lock As New Object
    Private _myAddress As UShort
    Private _readDone As New ManualResetEventSlim(False)
    Private _sb As New StringBuilder
    Private _streamingByteCount As UShort = 0
    Protected _linesQ As Concurrent.ConcurrentQueue(Of String)
    Public Event SensorStringDataReceived(ByVal sender As IConnection, ByVal data As String) Implements IConnection.SensorStringDataReceived
    Public Event RelayDongleMessage(ByVal msg As String)
    Public Sub New(ByVal dongle As XbeeApiDongle, ByVal destAddr As UShort)
        _dongle = dongle
        _myAddress = destAddr
        AddHandler _dongle.DataReceived, AddressOf Dongle_DataReceived
        AddHandler _dongle.DongleErrorMessage, AddressOf DongleMessageHandler
        AddHandler _dongle.DongleInfoMessage, AddressOf DongleMessageHandler
        _inputCharQ = New Concurrent.ConcurrentQueue(Of Char)
        _sb.Length = 0
        _bg = New BackgroundWorker
        _bg.WorkerSupportsCancellation = True
        _bg.WorkerReportsProgress = True
        _bg.RunWorkerAsync()
    End Sub
    Private Sub Dongle_DataReceived(sourceAddr As Integer, ByVal str As String)
        If sourceAddr = _myAddress AndAlso _isOperating Then
            'else this is meant for someone else
            For Each c In str.ToCharArray
                _inputCharQ.Enqueue(c)
            Next
        End If
    End Sub
    Private Sub DongleMessageHandler(ByVal dongle As XbeeApiDongle, ByVal msg As String)
        RaiseEvent RelayDongleMessage(msg)
    End Sub
    ReadOnly Property MyAddress() As UShort
        Get
            Return _myAddress
        End Get
    End Property

    Public Function TryClose() As Boolean Implements IConnection.TryClose
        'dongle is always open
        Return True
    End Function

    Public Function TryOpen() As Boolean Implements IConnection.TryOpen
        'dongle is always open
        Return True
    End Function
    Public ReadOnly Property IsConnected As Boolean Implements IConnection.IsConnected
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property ConnectionInfoString As String Implements IConnection.ConnectionInfoString
        Get
            'Return String.Format("{0}/{1}[{2:0000}]", _dongle.PortName, _dongle.BaudRate.ToString("0"), _myAddress)
            Return String.Format("[{0:00000}]/{1}", _myAddress, _dongle.PortName)
        End Get
    End Property

    Public Function Flush() As Boolean Implements IConnection.Flush
        Return True
    End Function
    Private Function StartReading() As Boolean
        _isOperating = True
        Return True
    End Function

    Public Function StopReading() As Boolean Implements IConnection.StopReading
        _isOperating = False
        _linesQ = New Concurrent.ConcurrentQueue(Of String)
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
        Dim ch As Char
        Do
            If _inputCharQ.TryDequeue(ch) Then
                If _isOperating Then
                    If ch = vbCr Then
                        Dim buffer As String = _sb.ToString
                        If buffer <> "A" Then
                            _linesQ.Enqueue(buffer)
                            RaiseEvent SensorStringDataReceived(Me, buffer)
                            Select Case _currentCmd.responseType
                                Case SensorCommand.Enum_ResponseType.oneline
                                    _readDone.Set()
                                Case SensorCommand.Enum_ResponseType.continuous
                                    'do nothing, handled in derived class
                                Case SensorCommand.Enum_ResponseType.count
                                    If _linesQ.Count = _currentCmd.nOutputLine Then
                                        _readDone.Set()
                                    End If
                                Case SensorCommand.Enum_ResponseType.stringmatch
                                    'If buffer Like "*" & _currentCmd.terminatingString & "*" Then
                                    '    _readDone.Set()
                                    'End If
                            End Select
                        End If
                        _sb.Length = 0
                    ElseIf ch = vbLf OrElse Char.IsControl(ch) Then
                        'don't do anything
                    Else
                        _sb.Append(ch)
                    End If
                End If
            Else
                System.Threading.Thread.Sleep(1)
            End If
        Loop Until _bg.CancellationPending
        e.Cancel = True
    End Sub

    Public Property LineTerminator As Char Implements IConnection.LineTerminator

    Public Function GetMultiLineResponse(ByVal cmd As SensorCommand) As List(Of String) Implements IConnection.GetMultiLineResponse
        _inputCharQ = New Concurrent.ConcurrentQueue(Of Char)
        _linesQ = New Concurrent.ConcurrentQueue(Of String)
        _currentCmd = cmd
        _isOperating = True
        Dim lst = GetMultiLineResponse(cmd, 1)
        If lst.Count = _currentCmd.nOutputLine Then
            Return lst
        ElseIf lst.Count <> 0 Then
            Return GetMultiLineResponse(cmd, 2)
        End If
        Return New List(Of String)
    End Function
    Private Function GetMultilineResponse(ByVal cmd As SensorCommand, ByVal attemptNo As Integer) As List(Of String)
        '
        'no one else should be using this dongle
        '
        SyncLock XbeeGlobals.DongleLock
            Try
                _dongle.TryOpen()
                _readDone.Reset()
                _dongle.XmitCommand(cmd.commandText, _myAddress)
                _readDone.Wait(20000)
                Dim buffer As String = String.Empty
                If cmd.responseType = SensorCommand.Enum_ResponseType.count Then
                    Dim lst As List(Of String) = _linesQ.ToList
                    lst.Sort()
                    Return lst
                End If
                Return New List(Of String)
            Catch ex As Exception
            Finally
                '_dongle.Flush()
                _dongle.TryClose()
            End Try
        End SyncLock
        Return New List(Of String)
    End Function
    Public Function XmitCommand(ByVal cmd As SensorCommand) As Boolean Implements IConnection.XmitCommand
        Throw New NotImplementedException
        'SyncLock XbeeGlobals.DongleLock
        '    _currentCmd = cmd
        '    Return _dongle.XmitCommand(cmd.commandText, _myAddress)
        'End SyncLock
    End Function

    Public Function XmitStreamingCommand(commandText As String) As Boolean Implements IConnection.XmitStreamingCommand
        Throw New NotImplementedException
        'SyncLock XbeeGlobals.DongleLock
        '    _currentCmd = cmd
        '    Return _dongle.XmitCommand(cmd.commandText, _myAddress)
        'End SyncLock
    End Function

    Public Function GetCommandResponse(ByVal cmd As SensorCommand) As String Implements IConnection.GetCommandResponse
        _inputCharQ = New Concurrent.ConcurrentQueue(Of Char)
        _linesQ = New Concurrent.ConcurrentQueue(Of String)
        _currentCmd = cmd
        SyncLock XbeeGlobals.DongleLock
            Try
                _dongle.TryOpen()
                _readDone.Reset()
                If cmd.commandText.Length <> 0 Then
                    _dongle.XmitCommand(cmd.commandText, _myAddress)
                End If
                _isOperating = True
                If _readDone.Wait(5000) Then
                    Dim buffer As String = String.Empty
                    If cmd.responseType = SensorCommand.Enum_ResponseType.oneline Then
                        _linesQ.TryDequeue(buffer)
                        Return buffer
                    End If
                End If
            Catch ex As Exception
            Finally
                '_dongle.Flush()
                _dongle.TryClose()
            End Try
        End SyncLock
        Return String.Empty 'timedout
    End Function

    Protected Overrides Sub Finalize()
        If _bg IsNot Nothing AndAlso _bg.IsBusy Then
            _bg.CancelAsync()
            While _bg.IsBusy
                Thread.Sleep(250)
            End While
        End If
        MyBase.Finalize()
    End Sub
End Class

