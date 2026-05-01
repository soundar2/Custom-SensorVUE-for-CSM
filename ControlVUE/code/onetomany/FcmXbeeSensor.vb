Imports System.Threading
Imports System.ComponentModel
Public Class FcmXbeeSensor
    Inherits XbeeApiSensor
    Implements IConnectionInfo

    Private Enum Enum_FCM_TYPE
        di1000 = 1
        di100 = 2
    End Enum
    Private _model As Enum_FCM_TYPE
    Private WithEvents _bg As New BackgroundWorker
    Public Sub New(ByVal myAddress As UShort, ByVal dongle As XbeeApiDongle)
        MyBase.New(myAddress, dongle)
        _model = Enum_FCM_TYPE.di1000
        Dim cmd As New SensorCommand("ID" & vbCr, SensorCommand.Enum_ResponseType.oneline)
        SS1 = GetCommandResponse(cmd).Trim
        If SS1.StartsWith("DISP") Then
            Me.Units = New Units(Units.Enum_UNIT_TYPE.length)
            DeviceUnitType = Enum_Device_Unit_Type.Length
        ElseIf SS1.StartsWith("TQ") Or SS1.StartsWith("TORQ") Then
            Me.Units = New Units(Units.Enum_UNIT_TYPE.torque)
            DeviceUnitType = Enum_Device_Unit_Type.Torque
        ElseIf SS1.StartsWith("VM") Then
            Me.Units = New Units(Units.Enum_UNIT_TYPE.voltage)
            DeviceUnitType = Enum_Device_Unit_Type.Voltage
        ElseIf SS1.StartsWith("PR") Then
            Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.pressure)
            DeviceUnitType = Enum_Device_Unit_Type.Pressure
            TypeDescription = "Pressure"
        Else
            Me.Units = New Units(Units.Enum_UNIT_TYPE.force)
            DeviceUnitType = Enum_Device_Unit_Type.Force
        End If
        cmd.commandText = "UNITS" & vbCr
        Me.Units.CalibratedUnits = GetCommandResponse(cmd) 'validated by base class
        cmd.commandText = "LC" & vbCr
        CapacityInCalibratedUnits = Val(GetCommandResponse(cmd))
        _bg.WorkerSupportsCancellation = True
    End Sub
    Public Overrides Sub StartReading()
        MyBase.StartReading()
        IssueStreamingCommand("WC" & vbCr)
        _bg = New BackgroundWorker
        _bg.WorkerSupportsCancellation = True
        _bg.RunWorkerAsync()
    End Sub
    Public Overrides Sub StopReading()
        MyBase.StopReading()
        Thread.Sleep(500)
        _bg.CancelAsync()
    End Sub
    Public Overrides Sub Tare()
        Dim cmd As New SensorCommand("CT0" & vbCr, SensorCommand.Enum_ResponseType.oneline)
        For i = 1 To 2
            XmitCommand(cmd)
            Thread.Sleep(250)
        Next
        Flush()
    End Sub

    Private Sub _bg_DoWork(sender As Object, e As DoWorkEventArgs) Handles _bg.DoWork
        Dim buffer As String = String.Empty
        Do
            Try
                If _linesQ.TryDequeue(buffer) Then
                    If buffer.Length = 12 Then
                        CurrentReading = ConvertToOutputUnits(Val(buffer.Trim))
                    End If
                End If
            Catch ex As Exception
                If _bg.CancellationPending Then
                    Return
                End If
            End Try
        Loop Until _bg.CancellationPending
    End Sub


    Public ReadOnly Property ConnectionInfo As String Implements IConnectionInfo.ConnectionInfo
        Get
            Return String.Format("{0}, {1}, DI-1000", PortName, BaudRate)
        End Get
    End Property

End Class
