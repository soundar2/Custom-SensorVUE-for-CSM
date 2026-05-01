Imports System.IO.Ports
Imports System.Threading
#If Mock = False Then
Public MustInherit Class LsComSensor
    Inherits LsSensor
    '
    Private _portName As String
    Private _baud As UInteger
    Protected _thisPort As SerialPort


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
    Protected Sub SerialPortSlowWrite(ByVal str As String, Optional ByVal delay As UShort = 1)
        For Each ch As Char In str
            _thisPort.Write(ch)
            Thread.Sleep(delay)
        Next
    End Sub
    Public Shared Sub SerialPortSlowWrite(ByVal port As SerialPort, ByVal str As String, Optional ByVal delay As UShort = 1)
        If port.IsOpen Then
            For Each ch As Char In str
                port.Write(ch)
                Thread.Sleep(delay)
            Next
        End If
    End Sub
    Protected Function TryOpen() As Boolean
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
                DisableDataReceivedEvent()
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

    Protected Function TryClose() As Boolean

        If _thisPort Is Nothing OrElse _thisPort.IsOpen = False Then Return True
        Try
            'port is open
            DisableDataReceivedEvent()
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
    End Function
    Protected Sub FlushThisport()
        DisableDataReceivedEvent()
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
    End Sub
    Protected Sub EnableDataReceivedEvent()
        _thisPort.ReceivedBytesThreshold = 1
    End Sub
    Protected Sub DisableDataReceivedEvent()
        If _thisPort Is Nothing Then Return
        _thisPort.ReceivedBytesThreshold = 10000
    End Sub
    Protected MustOverride Sub PortDataReceived(ByVal buffer As String)
#If 0 Then
    Private Sub _thisPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles _thisPort.DataReceived

        Return
        Try
            Do While _thisPort.BytesToRead <> 0
                ' Dim buffer As String = _thisPort.ReadTo(vbCrLf)
                'PortDataReceived(_thisPort.ReadTo(vbLf))
            Loop
        Catch ex As Exception
        End Try
    End Sub
#End If
    Protected Function GetCommandResponse(ByVal cmd As String) As String
        If _thisPort.IsOpen Then
            Try
                Dim buffer As String = String.Empty
                buffer = _thisPort.ReadExisting
                _thisPort.DiscardInBuffer()
                SerialPortSlowWrite(cmd & vbCr, 20)
                Do
                    Thread.Sleep(250)
                Loop Until _thisPort.BytesToRead <> 0
                buffer = _thisPort.ReadTo(vbCr).Trim
                If buffer.Length = 0 Then
                    buffer = _thisPort.ReadTo(vbCr).Trim
                End If
                _thisPort.DiscardInBuffer()
                Return buffer
            Catch ex As Exception
                Return String.Empty
            End Try
        Else
            Return String.Empty
        End If
    End Function
    Public Shared Function GetCommandResponse(ByVal port As SerialPort, ByVal cmd As String) As String
        If port.IsOpen Then
            Try
                port.DiscardInBuffer()
                Dim buffer As String = String.Empty
                SerialPortSlowWrite(port, cmd & vbCr, 20)
                Do
                    Thread.Sleep(100)
                Loop Until port.BytesToRead <> 0
                If buffer.Length = 0 Then
                    buffer = port.ReadTo(vbCr).Trim
                End If
                buffer = port.ReadTo(vbCr).Trim
                port.DiscardInBuffer()
                Return buffer
            Catch ex As Exception
                Return String.Empty
            End Try
        Else
            Return String.Empty
        End If
    End Function
    Protected Overrides Sub Finalize()
        DisableDataReceivedEvent()
        TryClose()
        MyBase.Finalize()
    End Sub
    Public Overrides Sub StartReading()
    End Sub
    Public Overrides Sub StopReading()
    End Sub

    Public Overrides Sub Tare()
    End Sub
End Class
#End If

