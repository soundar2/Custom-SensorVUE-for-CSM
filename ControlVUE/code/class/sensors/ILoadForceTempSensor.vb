Imports System.IO.Ports
Imports System.Threading
Imports System.ComponentModel

Public Class ILoadForceTempSensor
    Inherits LsComSensor
    Implements IConnectionInfo
    Implements IFilterable
    Implements IAlarmable

    Protected Const _o0s1 As String = "o0s1" & vbCr
    Protected Const _o0s0 As String = "o0s0" & vbCr
    Private _forceSensor As ILoadForceSensor
    Private _tempSensor As ILoadTempSensor
    Private _sensor(0 To 1) As LsSensor
    Private delimiters() As Char = ("A" & vbCr & vbLf & vbTab & Space$(1)).ToCharArray
    Private _firstSs1 As String = String.Empty
    Private WithEvents _bg As New BackgroundWorker
    Private _bgwCompleted As Boolean = False
    Public Sub New(ByVal ss1 As String, ByVal portName As String, ByVal baud As UInteger)
        MyBase.New(portName, baud)
        Dim capacity As Double = 0
        Try
            Thread.Sleep(1000)
            TryOpen()
            '
            'read sensor names from all 4 channels
            '
            _forceSensor = New ILoadForceSensor(Me)
            _tempSensor = New ILoadTempSensor(Me)
            _forceSensor.SS1 = ss1 & "/F"
            _tempSensor.SS1 = ss1 & "/T"
            _sensor(0) = _forceSensor
            _sensor(1) = _tempSensor
            _forceSensor.CapacityInCalibratedUnits = Val(GetCommandResponse("SLC" & vbCr))
            _tempSensor.CapacityInCalibratedUnits = 100
        Catch ex As Exception
            _thisPort = Nothing
            Throw ex
        Finally
            TryClose()
        End Try
        _bg.WorkerSupportsCancellation = True
    End Sub
    Public ReadOnly Property ForceSensor() As IDerivedSensor
        Get
            Return _forceSensor
        End Get
    End Property
    Public ReadOnly Property TempSensor() As IDerivedSensor
        Get
            Return _tempSensor
        End Get
    End Property
    Public Overrides Sub StartReading()
    End Sub
    Public Overrides Sub StopReading()
    End Sub

    Public Overrides Sub Tare()
    End Sub
    Protected Overrides Sub PortDataReceived(ByVal buffer As String)
#If 0 Then
        Dim str() As String
        Dim total As Double = 0

        Try
            buffer = buffer.Trim
            str = buffer.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            If str.Length >= 6 Then
                _forceSensor.Reading = Val(str(5)) / 1000
                _tempSensor.Reading = Val(str(3)) / 100
            End If
        Catch ex As Exception
        Finally
            _thisPort.Write(_o0s1)
        End Try
#End If
    End Sub
    Private Sub IdentifyFirstChild()
        Dim childSensorNames = (From s In _sensor Select s.SS1).ToList
        Dim allSensorNames = (From s In _gAttachedSensors Select s.SS1).ToList
        _firstSs1 = childSensorNames.Intersect(allSensorNames).First
    End Sub
    Public Overloads Sub StartReading(ByVal child As LsSensor)
        'this command is issued by the child sensor not by the main form
        'the main form issues the command to all child sensors
        'which pass up the command to the parent (this object)
        If _firstSs1.Length = 0 Then
            IdentifyFirstChild()
        End If
        If child.SS1 = _firstSs1 Then
            TryOpen()
            EnableDataReceivedEvent()
            _thisPort.Write(_o0s0)
            If Not _bg.IsBusy Then
                _bgwCompleted = False
                _bg.RunWorkerAsync()
            End If
        End If
    End Sub
    Public Overloads Sub StopReading(ByVal child As LsSensor)
        'this command is issued by the child sensor not by the main form
        'the main form issues the command to all child sensors
        'which pass up the command to the parent (this object)
        'all the children will be sending the read requests
        'but we need to start reading only once
        If _firstSs1.Length = 0 Then
            IdentifyFirstChild()
        End If
        If child.SS1 = _firstSs1 Then
            _bg.CancelAsync()
            Thread.Sleep(100)
            DisableDataReceivedEvent()
            TryClose()
        End If
    End Sub
    Public Overloads Sub Tare(ByVal child As IDerivedSensor)
        'this command is issued by the child sensor not by the main form
        'the main form issues the command to all child sensors
        'which pass up the command to the parent (this object)
        'all the children will be sending the tare request
        'but we need to tare only once
        If TryCast(child, ILoadForceSensor) IsNot Nothing Then
            DisableDataReceivedEvent()
            If _thisPort.IsOpen Then
                For i = 1 To 2
                    'send command 2 times
                    SerialPortSlowWrite("CT0" & vbCr)
                    Thread.Sleep(250)
                Next
            Else
                TryOpen()
                For i = 1 To 2
                    'send command 2 times
                    SerialPortSlowWrite("CT0" & vbCr)
                    Thread.Sleep(250)
                Next
                TryClose()
            End If
            FlushThisport()
        End If
    End Sub
    Private Sub _bg_DoWork(sender As Object, e As DoWorkEventArgs) Handles _bg.DoWork
        Dim str() As String
        Do
            Try
                Dim buffer = _thisPort.ReadTo(vbLf)
                buffer = buffer.Trim
                str = buffer.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                If str.Length >= 6 Then
                    _forceSensor.Reading = Val(str(5)) / 1000
                    _tempSensor.Reading = Val(str(3)) / 100
                End If
            Catch ex As Exception
            End Try
        Loop Until _bg.CancellationPending
        _bgwCompleted = True
    End Sub

    Public ReadOnly Property ConnectionInfo As String Implements IConnectionInfo.ConnectionInfo
        Get
            Return String.Format("{0}, {1}, iLoad Temperature", PortName, Baud)
        End Get
    End Property
End Class
