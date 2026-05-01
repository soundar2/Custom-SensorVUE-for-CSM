Imports System.Threading
Imports System.ComponentModel
Imports System.Globalization

Public Class CapSensor
    Inherits LsComSensor
    Implements IConnectionInfo
    Implements IPunchable
    Implements IFilterable
    Implements IAlarmable

    Protected Const _o0w1 As String = "W" & vbCr
    Protected Const _o0w0 As String = "O0W0" & vbCr
    Protected delimiters() As Char = (vbCr & vbLf).ToCharArray
    Private WithEvents _bg As New BackgroundWorker
    Public Sub New(ByVal model As String, ByVal portName As String, ByVal baud As UInteger)
        MyBase.New(portName, baud)
        Dim buffer As String = String.Empty
        TryOpen()
        SS1 = GetCommandResponse("SS1")
        If SS1.StartsWith("DISP") OrElse SS1.StartsWith("IL") Then
            DeviceUnitType = Enum_Device_Unit_Type.Length
            Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.length)
            TypeDescription = "Level"
        Else
            DeviceUnitType = Enum_Device_Unit_Type.Force
            Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.force)
            TypeDescription = "Force or Weight"
        End If
        '
        'get calibrated units
        Me.Units.CalibratedUnits = GetCommandResponse("UNITS") 'validated by base class
        '
        CapacityInCalibratedUnits = Convert.ToDouble(GetCommandResponse("SLC"), CultureInfo.CreateSpecificCulture("us-EN"))

        'special settings
        '
        TryClose()
        _bg.WorkerSupportsCancellation = True
    End Sub
    Public Overrides Sub StartReading()
        TryOpen()
        DisableDataReceivedEvent()
        StartDisconnectionTimer()
        _thisPort.Write(_o0w0)
        If Not _bg.IsBusy Then
            _bg.RunWorkerAsync()
        End If
    End Sub
    Public Overrides Sub StopReading()
        StopDisconnectionTimer()
        _bg.CancelAsync()
        Thread.Sleep(500)
        DisableDataReceivedEvent()
        TryClose()
    End Sub
    Public Overrides Sub Tare()
        DisableDataReceivedEvent()
        Dim alreadyOpen As Boolean = _thisPort.IsOpen
        If Not alreadyOpen Then TryOpen()
        For i = 1 To 2
            'send command 2 times
            SerialPortSlowWrite("CT0" & vbCr)
            Thread.Sleep(250)
        Next
        If Not alreadyOpen Then TryClose()
        FlushThisport()
    End Sub
    Protected Overrides Sub PortDataReceived(ByVal buffer As String)
#If 0 Then
        Try

            If buffer.Length <> 10 Then Exit Try
            CurrentReading = ConvertToOutputUnits(Val(buffer.Trim) / 1000)
            OnSensorDataReceived(Me.SequenceNo)
        Catch ex As Exception
        Finally
        End Try
#End If
    End Sub
    Private Sub _bg_DoWork(sender As Object, e As DoWorkEventArgs) Handles _bg.DoWork
        Do
            Try
                Dim buffer = _thisPort.ReadTo(vbLf)
                If buffer.Length <> 10 Then Exit Try
                CurrentReading = ConvertToOutputUnits(Val(buffer.Trim) / 1000)
                If _bg.CancellationPending Then Return
            Catch ex As Exception
                If _bg.CancellationPending Then Return
            End Try
        Loop Until _bg.CancellationPending
    End Sub
    Public ReadOnly Property ConnectionInfo As String Implements IConnectionInfo.ConnectionInfo
        Get
            Return String.Format("{0}, {1}, iLoad Force", PortName, Baud)
        End Get
    End Property
End Class
