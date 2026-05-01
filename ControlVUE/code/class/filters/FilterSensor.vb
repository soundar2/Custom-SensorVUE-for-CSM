Imports System.Threading
Imports System.Threading.Tasks.Dataflow
Imports System.ComponentModel
Public Class FilterSensor
    Inherits LsSensor
    Implements IFilterable
    Implements IAlarmable

    Private _baseSensor As LsSensor
    Private _expWma As ExpWMA
    Public Enum Enum_Filter_Type
        none
        average
        median
        std
        variance
    End Enum
    Public Class FilterSensorSetting
        Public name As String = String.Empty
        Public baseSensorSs1 As String = String.Empty
        Public filterType As Enum_Filter_Type = Enum_Filter_Type.average
        Public windowSize As Integer = 3
        Public jumpThreshold As Double = 100000
    End Class
    Public setting As New FilterSensorSetting
    Private _bufferBlock As New BufferBlock(Of Double)

    Private WithEvents _bgw As New BackgroundWorker
    Public Overrides Sub StartReading()

        Me.Units.OutputUnits = _baseSensor.Units.OutputUnits
        If Me.setting.filterType = Enum_Filter_Type.median Then
            _bufferBlock = New BufferBlock(Of Double)
            If Not _bgw.IsBusy Then
                _bgw.RunWorkerAsync()
            End If
        ElseIf Me.setting.filterType = Enum_Filter_Type.average Then
            _expWma = New ExpWMA(Me.setting.windowSize, Me.setting.jumpThreshold)
            _expWma.Reset()
        End If

    End Sub

    Public Overrides Sub StopReading()
        If _bgw.IsBusy Then
            _bgw.CancelAsync()
        End If
    End Sub

    Public Overrides Sub Tare()
    End Sub

    Public Sub New(ByVal setting As FilterSensorSetting)
        IsVirtualDevice = True
        _baseSensor = (From item In _gAttachedSensors Where item.SS1 = setting.baseSensorSs1 Select item).FirstOrDefault
        If _baseSensor Is Nothing Then
            Throw New Exception("Base sensor not found/not yet added")
        End If
        AddHandler _baseSensor.SensorDataReceived, AddressOf BaseSensorDataReceived
        Me.Units = _baseSensor.Units
        Me.setting.filterType = setting.filterType
        If setting.filterType = Enum_Filter_Type.average Then
            Me.setting.windowSize = setting.windowSize
            _expWma = New ExpWMA(setting.windowSize, setting.jumpThreshold)
        ElseIf setting.filterType = Enum_Filter_Type.median Then
            Me.setting.windowSize = Math.Max(3, setting.windowSize) 'we need min 3 points to find the median
            'no of points must be odd
            If Me.setting.windowSize Mod 2 = 0 Then
                'if even number of points increase by 1
                Me.setting.windowSize += 1
            End If
        End If
        Me.setting.jumpThreshold = setting.jumpThreshold
        SS1 = setting.name
        _bgw.WorkerSupportsCancellation = True
    End Sub
    Private Sub BaseSensorDataReceived(ByVal seqNo As UShort)
        ComputeReading()
    End Sub
    Public Sub ComputeReading()
        If setting.filterType = Enum_Filter_Type.average Then
            _expWma.NewValue(_baseSensor.CurrentReading)
            CurrentReading = _expWma.Average
        ElseIf setting.filterType = Enum_Filter_Type.median Then
            _bufferBlock.Post(_baseSensor.CurrentReading)
        Else
            CurrentReading = -99
        End If
    End Sub

    Private Sub _bgw_DoWork(sender As Object, e As DoWorkEventArgs) Handles _bgw.DoWork
        Dim midIndex As Integer = (Me.setting.windowSize - 1) / 2
        Dim al As ArrayList = New ArrayList
        Dim alSorted As ArrayList = New ArrayList
        Dim force As Double
        Do
            If _bufferBlock.TryReceive(force) Then
                If al.Count = Me.setting.windowSize Then
                    al.RemoveAt(0)
                    al.Add(force)
                    alSorted.Clear()
                    alSorted = al.Clone
                    alSorted.Sort()
                    CurrentReading = alSorted(midIndex)
                Else
                    al.Add(force)
                    CurrentReading = force
                End If
            End If
        Loop Until _bgw.CancellationPending
    End Sub
End Class
