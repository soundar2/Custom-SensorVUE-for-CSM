Imports System.Threading
Imports System.ComponentModel
Imports System.Globalization
Imports System.Threading.Tasks
#If Mock = True Then
Public Class FcmSensor
    Inherits LsComSensor
    Implements IConnectionInfo
    Implements IPunchable
    Implements IFilterable
    Implements IAlarmable

    Protected Const _o0w1 As String = "W" & vbCr
    Protected Const _o0w0 As String = "WC" & vbCr
    Private _model As Enum_FCM_TYPE
    Protected delimiters() As Char = (vbCr & vbLf).ToCharArray
    Private WithEvents _bg As New BackgroundWorker

    Private Enum Enum_FCM_TYPE
        di1000 = 1
        di100 = 2
    End Enum
    Public Sub New(ByVal model As String, ByVal portName As String, ByVal baud As UInteger)
        MyBase.New(portName, baud)
        If model.Contains("1000") Then
            _model = Enum_FCM_TYPE.di1000
        Else
            _model = Enum_FCM_TYPE.di100
        End If
        Dim buffer As String = String.Empty
        TryOpen()
        If portName = "COM100" Then
            SS1 = "FCM-001"
            Me.Units.CalibratedUnits = "lb"
            CapacityInCalibratedUnits = "100000"
        Else
            SS1 = "DISP-001"
            Me.Units.CalibratedUnits = "in"
            CapacityInCalibratedUnits = "1"
        End If
        If SS1.StartsWith("DISP") Then
            Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.length)
            DeviceUnitType = Enum_Device_Unit_Type.Length
            TypeDescription = "Displacement"
        ElseIf SS1.StartsWith("TQ") OrElse SS1.StartsWith("TORQ") Then
            Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.torque)
            DeviceUnitType = Enum_Device_Unit_Type.Torque
            TypeDescription = "Torque"
        ElseIf SS1.StartsWith("VM") Then
            Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.voltage)
            DeviceUnitType = Enum_Device_Unit_Type.Voltage
            TypeDescription = "Voltage"
        ElseIf SS1.StartsWith("PR") Then
            Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.pressure)
            DeviceUnitType = Enum_Device_Unit_Type.Pressure
            TypeDescription = "Pressure"
        Else
            Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.force)
            DeviceUnitType = Enum_Device_Unit_Type.Force
            TypeDescription = "Force or Weight"
        End If
        '
        'get calibrated units

        '

        'special settings
        '
        '
        'check if there are any startup parameters for this device
        'if yes burn them
        '
        For Each item As String In ConfigXml.Instance.StartupParamList
            If item.StartsWith(SS1) Then
                Dim str() As String = item.Split("|".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
                'in the format "sensorName|cmd1$cmd2$..."
                If str.Count = 2 Then
                    Dim lines() As String = str(1).Split("$".ToCharArray, StringSplitOptions.RemoveEmptyEntries) '
                    For Each s As String In lines
                        SerialPortSlowWrite(s.Trim & vbCr)
                        Thread.Sleep(1000)
                        _thisPort.DiscardInBuffer()
                    Next
                End If
            End If
        Next

        '
        TryClose()
        _bg.WorkerSupportsCancellation = True

    End Sub

    Public Overrides Sub StartReading()
        TryOpen()
        DisableDataReceivedEvent()
        StartDisconnectionTimer()
        SerialPortSlowWrite(_o0w0)
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

    End Sub
    Private Async Sub _bg_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles _bg.DoWork
        Dim fileName = "D:\temp\Loadstar\csm\sample-data-001.txt"
        Dim lines() As String = System.IO.File.ReadAllLines(fileName)
        For Each line As String In lines
            Dim buffer = line.Split(",")
            If Me.DeviceUnitType = Enum_Device_Unit_Type.Length Then
                CurrentReading = Val(buffer(0))
            Else
                CurrentReading = Val(buffer(1))
            End If
            Await Task.Delay(100)
            If _bg.CancellationPending Then Return
        Next
    End Sub

    Protected Overrides Sub PortDataReceived(ByVal buffer As String)

    End Sub

    Public ReadOnly Property ConnectionInfo As String Implements IConnectionInfo.ConnectionInfo
        Get
            Return String.Format("{0}, {1}, {2}", PortName, Baud, IIf(_model = Enum_FCM_TYPE.di1000, "DI-1000", "DI-100"))
        End Get
    End Property

End Class
#End If

