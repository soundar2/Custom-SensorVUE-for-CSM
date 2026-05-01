Option Compare Text
Imports System.Text
Imports System.ComponentModel
Imports System.Threading
Public Class XbeeApiSensor
    Inherits LsSensor

    Private _myAddress As UShort
    Private _inputCharQ As Concurrent.ConcurrentQueue(Of Char)
    Private WithEvents _bgw As BackgroundWorker
    Private _sb As New StringBuilder
    Protected _linesQ As Concurrent.ConcurrentQueue(Of String)
    Private _readDone As New ManualResetEventSlim(False)
    Private _isOperating As Boolean = True
    Private WithEvents _dongle As XbeeApiDongle
    Event LineReceived(ByVal line As String)
    Private _lock As New Object
    Private _currentCmd As SensorCommand
    Public Sub New(ByVal myAddress As UShort, ByVal dongle As XbeeApiDongle)
        _myAddress = myAddress
        _dongle = dongle
        AddHandler _dongle.DataReceived, AddressOf Dongle_DataReceived
        _inputCharQ = New Concurrent.ConcurrentQueue(Of Char)
        _bgw = New BackgroundWorker
        _linesQ = New Concurrent.ConcurrentQueue(Of String)()
        _sb.Length = 0
        _bgw.WorkerSupportsCancellation = True
        _bgw.WorkerReportsProgress = True
        _bgw.RunWorkerAsync()
    End Sub
    ReadOnly Property MyAddress() As UShort
        Get
            Return _myAddress
        End Get
    End Property
    Public Sub IssueStreamingCommand(ByVal cmdText As String)
        _isOperating = False
        Flush()
        Thread.Sleep(1000)
        _linesQ = New Concurrent.ConcurrentQueue(Of String)
        Dim cmd As New SensorCommand(cmdText, SensorCommand.Enum_ResponseType.continuous)
        cmd.nOutputLine = 0
        _currentCmd = cmd
        _dongle.XmitCommand(cmd.commandText, _myAddress)
        _isOperating = True
    End Sub
    Protected Sub Flush()
        Dim cmd As New SensorCommand
        cmd.commandText = vbCr
        cmd.responseType = SensorCommand.Enum_ResponseType.oneline
        cmd.nOutputLine = 1
        _currentCmd = cmd
        _dongle.XmitCommand(cmd.commandText, _myAddress)
        Thread.Sleep(250)
        _dongle.XmitCommand(cmd.commandText, _myAddress)
    End Sub
    Private Sub Dongle_DataReceived(sourceAddr As Integer, ByVal str As String)
        If sourceAddr = _myAddress AndAlso _isOperating Then
            'else this is meant for someone else
            For Each c In str.ToCharArray
                _inputCharQ.Enqueue(c)
            Next
        End If
    End Sub

    Private Sub _bgw_DoWork(sender As Object, e As DoWorkEventArgs) Handles _bgw.DoWork
        Dim ch As Char
        Do
            If _inputCharQ.TryDequeue(ch) Then
                If _isOperating Then
                    If ch = vbCr Then
                        Dim buffer As String = _sb.ToString
                        If buffer <> "A" Then
                            _linesQ.Enqueue(buffer)
                            Select Case _currentCmd.responseType
                                Case SensorCommand.Enum_ResponseType.oneline
                                    _readDone.Set()
                                Case SensorCommand.Enum_ResponseType.continuous
                                    'do nothing, handled in derived class
                                Case SensorCommand.Enum_ResponseType.count

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
        Loop Until _bgw.CancellationPending
    End Sub
    Public Function GetCommandResponse(ByVal cmd As SensorCommand) As String
        _inputCharQ = New Concurrent.ConcurrentQueue(Of Char)
        _linesQ = New Concurrent.ConcurrentQueue(Of String)
        _readDone.Reset()
        _currentCmd = cmd
        _dongle.XmitCommand(cmd.commandText, _myAddress)
        _isOperating = True
        If _readDone.Wait(5000) Then
            Dim buffer As String = String.Empty
            If cmd.responseType = SensorCommand.Enum_ResponseType.oneline Then
                _linesQ.TryDequeue(buffer)
                Return buffer
            ElseIf cmd.responseType = SensorCommand.Enum_ResponseType.count Then

            End If
        End If

        Return String.Empty 'timedout
    End Function

    Public Overrides Sub StartReading()
        _isOperating = True
    End Sub

    Public Overrides Sub StopReading()
        Flush()
        _isOperating = False
    End Sub

    Public Overrides Sub Tare()

    End Sub
    Protected Sub XmitCommand(ByVal cmd As SensorCommand)
        _currentCmd = cmd
        _dongle.XmitCommand(cmd.commandText, _myAddress)
    End Sub
    Protected ReadOnly Property PortName As String
        Get
            Return _dongle.PortName
        End Get
    End Property
    Protected ReadOnly Property BaudRate As String
        Get
            Return _dongle.BaudRate
        End Get
    End Property
End Class
