Imports System.IO.Ports
Imports System.Threading
#If Mock = True Then
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

    End Sub
    Public Shared Sub SerialPortSlowWrite(ByVal port As SerialPort, ByVal str As String, Optional ByVal delay As UShort = 1)

    End Sub
    Protected Function TryOpen() As Boolean
        Return True
    End Function

    Protected Function TryClose() As Boolean

        Return True
    End Function
    Protected Sub FlushThisport()

    End Sub
    Protected Sub EnableDataReceivedEvent()
    End Sub
    Protected Sub DisableDataReceivedEvent()
    End Sub
    Protected MustOverride Sub PortDataReceived(ByVal buffer As String)

    Protected Function GetCommandResponse(ByVal cmd As String) As String
        Return "xxxx"
    End Function
    Public Shared Function GetCommandResponse(ByVal port As SerialPort, ByVal cmd As String) As String
        Return "xxxx"

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

