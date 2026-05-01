Option Compare Text
Option Explicit On
Imports System.Threading
Imports System.IO.Ports
Imports System.Text.RegularExpressions
Imports System.ComponentModel
Public Class MitutoyoSPC
    Inherits LsComSensor
    Implements IConnectionInfo
    Implements IFilterable
    Implements IAlarmable

    Private Const _o0w1 As String = "R" & vbCrLf 'we need line feed not just CR here
    Private Const _o0w0 As String = "B" & vbCrLf 'we need line feed not just CR here
    Private _inchRegex As Regex = New Regex("[\+\-]\d{3}\.\d{5}")
    Private _mmRegex As Regex = New Regex("[\+\-]\d{4}\.\d{4}")
    Private _currentRegex As Regex
    Private WithEvents _bg As New BackgroundWorker
    Private Shared MitutoyoCount As Integer = 0
    Public Sub New(ByVal model As String, ByVal portName As String, ByVal baud As UInteger)
        MyBase.New(portName, baud)
        Dim buffer As String = String.Empty
        TryOpen()

        DeviceUnitType = Enum_Device_Unit_Type.Length
        Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.length)
        Me.Units.CalibratedUnits = "in"
        'if already streaming stop it
        SerialPortSlowWrite("S" & vbCrLf)
        '
        TryClose()
        MitutoyoCount += 1
        SS1 = "Mitutoyo-" & MitutoyoCount

        _bg.WorkerSupportsCancellation = True
    End Sub

    Protected Overrides Sub PortDataReceived(ByVal buffer As String)

    End Sub
    Public Overrides Sub StartReading()
        TryOpen()
        DisableDataReceivedEvent()
        _thisPort.Write(_o0w0)
        If Not _bg.IsBusy Then
            _bg.RunWorkerAsync()
        End If
    End Sub
    Public Overrides Sub StopReading()
        _bg.CancelAsync()
        Thread.Sleep(500)
        DisableDataReceivedEvent()
        _thisPort.Write("S" & vbCrLf) 'stop streaming
        TryClose()
    End Sub
    Public Overrides Sub Tare()
        'nothing here
    End Sub
    Private Sub _bg_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles _bg.DoWork
        Do
            Try
                Dim buffer = _thisPort.ReadTo(vbCr)
                'If buffer.Length <> 13 Then Continue Do
                'CurrentReading = ConvertToOutputUnits(1)
                CurrentReading = ConvertToOutputUnits(Val(buffer.Trim))
            Catch ex As Exception
                If _bg.CancellationPending Then
                    Return
                End If
            End Try
        Loop Until _bg.CancellationPending
    End Sub

    Public ReadOnly Property ConnectionInfo As String Implements IConnectionInfo.ConnectionInfo
        Get
            Return String.Format("{0}, {1}, {2}", PortName, Baud, "Mitutoyo")
        End Get
    End Property
End Class
