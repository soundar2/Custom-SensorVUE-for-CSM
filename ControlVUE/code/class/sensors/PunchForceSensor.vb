Imports System.Threading
Imports System.Threading.Tasks.Dataflow
Imports System.ComponentModel
Public Class PunchForceSensor
    Inherits LsSensor

    Public Structure TIMESTAMPED_FORCE
        Public punchIndex As UShort
        Public elapsedMSec As Long
        Public force As Double
    End Structure
    Private _bufBlock As New BufferBlock(Of TIMESTAMPED_FORCE)
    Private _baseSensor As LsSensor
    Private WithEvents _bgw As New BackgroundWorker
    Private _punchCount As UInteger = 0
    Private _bInPunch As Boolean = False
    Private _fAverage As Double = 0
    Private _fLocalPeak As Double = 0
    Private _fSumOfPeaks As Double = 0
    Private _prevPunchStartMSec As ULong 'the time stamp for a punch
    Private _fMaxPunchForce As Double = 0
    Private _punchRatePerMin As Integer = 0
    Private _lstPunches As New Concurrent.ConcurrentBag(Of TIMESTAMPED_FORCE)
    Public Event PunchThrown(ByVal punch As TIMESTAMPED_FORCE)
    Public Sub New(ByVal baseSensor As LsSensor)
        _baseSensor = baseSensor
        AddHandler _baseSensor.SensorDataReceived, AddressOf BaseSensorDataReceived
        Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.force)
        _bgw.WorkerSupportsCancellation = True
        TypeDescription = "Punch Force Counter"
        Me.SS1 = String.Format("Punch Force({0})", baseSensor.SS1)
        IsVirtualDevice = True
    End Sub

    Public Overrides Sub StartReading()
        _bufBlock = New BufferBlock(Of TIMESTAMPED_FORCE)
        _punchCount = 0
         _fAverage = 0
        _fLocalPeak = 0
        _fSumOfPeaks = 0
        _fMaxPunchForce = 0
        _prevPunchStartMSec = 0
        _lstPunches = New Concurrent.ConcurrentBag(Of TIMESTAMPED_FORCE)
        Me.Units.OutputUnits = _baseSensor.Units.OutputUnits
        If Not _bgw.IsBusy Then
            _bgw.RunWorkerAsync()
        End If
    End Sub
    Protected Sub BaseSensorDataReceived(ByVal seqNo As UShort)
        Static data As TIMESTAMPED_FORCE
        data.elapsedMSec = clsGlobals._gTimeStampStopwatch.ElapsedMilliseconds
        data.force = _baseSensor.CurrentReading
        _bufBlock.Post(data)
    End Sub

    Public Overrides Sub StopReading()
        If _bgw.IsBusy Then
            _bgw.CancelAsync()
        End If
    End Sub

    Public Overrides Sub Tare()
        If TryCast(_baseSensor, FcmHs1KSensor) IsNot Nothing Then
            CType(_baseSensor, FcmHs1KSensor).SoftTare()
        Else
            _baseSensor.Tare()
        End If
    End Sub

    Private Sub _bgw_DoWork(sender As Object, e As DoWorkEventArgs) Handles _bgw.DoWork
        Static data As TIMESTAMPED_FORCE
        Dim punchThresholdOutputUnits = Units.ConvertToOutputUnits(ConfigXml.Instance.punchThresholdLb)
        Dim punchIntervalMSec = ConfigXml.Instance.punchIntervalMSec
        Do
            If _bufBlock.TryReceive(data) Then
                Dim elapsedMSec = data.elapsedMSec
                Dim force = data.force
                If force <= 0 Then
                    CurrentReading = 0 'do not process negatives
                    Continue Do
                End If
                If force > punchThresholdOutputUnits Then ' ConfigXml.Instance.punchThresholdLb Then
                    If Not _bInPunch Then
                        'you are NOT in a punch
                        'should we begin a new punch? may be it is due to 'shaking'
                        'this is a new punch if
                        ' 1. Punch interval is not enabled
                        '2. It is enabled AND the time to the older punch is > than the set threshold
                        If (elapsedMSec - _prevPunchStartMSec > punchIntervalMSec) OrElse _punchCount = 0 Then
                            'begin a new punch
                            _bInPunch = True
                            _prevPunchStartMSec = elapsedMSec 'store start time for this punch
                            _punchCount += 1 '
                            _fLocalPeak = force
                            CurrentReading = force
                        End If
                    Else
                        'you are already in a punch 
                        'keep calculating the local peak
                        _fLocalPeak = Math.Max(_fLocalPeak, force)
                        CurrentReading = force
                    End If
                Else 'force > punchThresholdOutputUnits
                    '
                    'have we just come out of a punch?
                    '
                    If _bInPunch Then
                        'yes
                        'come out of this punch
                        'compute the statistics after this punch
                        '
                        _fSumOfPeaks += _fLocalPeak
                        _fAverage = _fSumOfPeaks / _punchCount
                        _fMaxPunchForce = Math.Max(_fMaxPunchForce, _fLocalPeak)
                        Dim punch As TIMESTAMPED_FORCE
                        punch.punchIndex = _punchCount
                        punch.elapsedMSec = _prevPunchStartMSec
                        punch.force = _fLocalPeak
                        _lstPunches.Add(punch)
                        CurrentReading = _fLocalPeak
                        RaiseEvent PunchThrown(punch)
                    Else
                        CurrentReading = 0
                    End If
                    _bInPunch = False
                    _fLocalPeak = 0
                End If
            End If
            'If Math.Abs(_load(0)) < 1 Then _load(0) = 0
        Loop Until _bgw.CancellationPending
    End Sub
    Public ReadOnly Property PunchCount() As Integer
        Get
            Return _punchCount
        End Get
    End Property
    Public ReadOnly Property PunchRatePerMin() As Integer
        Get
            Return (_punchCount * 60000 / clsGlobals._gTimeStampStopwatch.ElapsedMilliseconds)
        End Get
    End Property
    Public ReadOnly Property AverageForce() As Double
        Get
            Return _fAverage
        End Get
    End Property
    Public ReadOnly Property MaxForce() As Double
        Get
            Return _fMaxPunchForce
        End Get
    End Property
    Public ReadOnly Property BaseSensor() As LsSensor
        Get
            Return _baseSensor
        End Get
    End Property

End Class
