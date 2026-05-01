Imports System.Threading
Imports System.ComponentModel
Imports System.Globalization

Public Class FcmHs1KSensor
    Inherits LsComSensor
    Implements IConnectionInfo
    Implements IPunchable
    Implements IFilterable
    Implements IAlarmable

    Protected delimiters() As Char = (vbCr & vbLf).ToCharArray
    Private WithEvents _bg As New BackgroundWorker
    Private _o0h0 As String = "H" & vbCr
    Private _wtPerBit As Double
    Private _tareA2D As Integer
    Private _isTaring As Boolean = False
    Public Sub New(ByVal model As String, ByVal portName As String, ByVal baud As UInteger)
        MyBase.New(portName, baud)
        Dim buffer As String = String.Empty
        TryOpen()
        SS1 = GetCommandResponse("ID")
        If SS1.StartsWith("DISP") Then
            Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.length)
            DeviceUnitType = Enum_Device_Unit_Type.Length
            TypeDescription = "Displacement"
        ElseIf SS1.StartsWith("TQ") Or SS1.StartsWith("TORQ") Then
            Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.torque)
            DeviceUnitType = Enum_Device_Unit_Type.Torque
            TypeDescription = "Torque"
        ElseIf SS1.StartsWith("PR") Then
            Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.pressure)
            DeviceUnitType = Enum_Device_Unit_Type.Pressure
            TypeDescription = "Pressure"
        ElseIf SS1.StartsWith("VM") Then
            Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.voltage)
            DeviceUnitType = Enum_Device_Unit_Type.Voltage
            TypeDescription = "Voltage"
        Else
            Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.force)
            DeviceUnitType = Enum_Device_Unit_Type.Force
            TypeDescription = "Force or Weight"
        End If
        '
        'get calibrated units
        Me.Units.CalibratedUnits = GetCommandResponse("UNITS") 'validated by base class
        '
        CapacityInCalibratedUnits = Convert.ToDouble(GetCommandResponse("LC"), CultureInfo.CreateSpecificCulture("us-EN"))

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
        'weight per count
        '
        SerialPortSlowWrite("SWC" & vbCr)
        buffer = _thisPort.ReadTo(vbCr).Trim
        _wtPerBit = Val(buffer)
        If _wtPerBit = 0 Then
            MsgBox("Invalid weight per count", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
        End If
        '
        'tareA2D
        '
        ReadTareCounts()
        '
        TryClose()
        _bg.WorkerSupportsCancellation = True
        ReadingsToAverage = 1
    End Sub
    Public Overrides Sub StartReading()
        TryOpen()
        DisableDataReceivedEvent()
        StartDisconnectionTimer()
        SerialPortSlowWrite(_o0h0)
        If Not _bg.IsBusy Then
            _bg.RunWorkerAsync()
        End If
    End Sub
    Public Overrides Sub StopReading()
        StopDisconnectionTimer()
        _bg.CancelAsync()
        Do
        Loop While _bg.IsBusy
        DisableDataReceivedEvent()
        TryClose()
    End Sub
    Public Overrides Sub Tare()
        SoftTare()
    End Sub
    Private Sub _bg_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles _bg.DoWork
        Dim buffer As String = String.Empty
        Static rawA2D As Integer = 0
        Do
            While _thisPort.BytesToRead
                Try
                    buffer = _thisPort.ReadTo(vbCr).Trim
                    If buffer(0) = "-"c Then
                        rawA2D = -1 * Convert.ToInt32(buffer.Substring(1), 16)
                    Else
                        rawA2D = Convert.ToInt32(buffer, 16)
                    End If
                    If Math.Abs(rawA2D) < 2 Then Continue While
                    If _isTaring Then
                        _tareA2D = rawA2D
                        _isTaring = False
                    End If
                    CurrentReading = ConvertToOutputUnits((rawA2D - _tareA2D) * _wtPerBit)
                Catch ex As Exception
                End Try
                If _bg.CancellationPending Then Return
            End While
        Loop Until _bg.CancellationPending
    End Sub

    Protected Overrides Sub PortDataReceived(ByVal buffer As String)

    End Sub

    Public Sub SoftTare()
        _isTaring = True
    End Sub
    Private Sub ReadTareCounts()
        Dim buffer As String
        FlushThisport()
        SerialPortSlowWrite("ST0" & vbCr)
        buffer = _thisPort.ReadTo(vbCr).Trim
        _tareA2D = Val(buffer)
    End Sub

    Public ReadOnly Property ConnectionInfo As String Implements IConnectionInfo.ConnectionInfo
        Get
            Return String.Format("{0}, {1}, DI-1000HS-1K", PortName, 230400)
        End Get
    End Property
End Class
