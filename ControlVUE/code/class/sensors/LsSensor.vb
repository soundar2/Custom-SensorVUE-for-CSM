Imports System.Threading
#If Mock = False Then
Public MustInherit Class LsSensor
    Inherits LsDevice
    '
    Private _units As Units
    Private _readingsToAverage As Integer = 1
    Private _expWma As ExpWMA
    Private _capacityInCalibratedUnits As Double

    Public Event SensorDataReceived(ByVal seqNo As UShort)
    Public Event DisplayFormatChanged(ByVal sDisplayFormat As String)
    Public Event SensorStoppedResponding(ByVal ss1 As String)
    Private _seqNo As UShort = 0
    Private _computePeakLow As Boolean
    Private _currentReading As Double
    Private _sDisplayFormat As String = "0.00"
    Private _lock As New ReaderWriterLockSlim
    Private WithEvents _timerDisconnectCheck As New System.Timers.Timer(1000)
    Private _isSensorResponding As Boolean = True
    Public Property CurrentReading() As Double
        'multiple reads of the sensor value from
        'log file, graph file, alarm file etc
        'so we have a separate variable for this
        'not sure if this is needed or even if it works efficiently
        Get
            Static r As Double
            _lock.EnterReadLock()
            r = _currentReading
            _lock.ExitReadLock()
            Return r
        End Get
        Protected Set(ByVal value As Double)
            _lock.EnterWriteLock()
            _currentReading = value
            _isSensorResponding = True
            _lock.ExitWriteLock()
            RaiseEvent SensorDataReceived(_seqNo)
        End Set
    End Property
    Public Sub New()
        DeviceUnitType = Enum_Device_Unit_Type.Force
        Me.Units = New Units(Units.Enum_UNIT_TYPE.force)
        Me.ReadingsToAverage = ConfigXml.Instance.readingsToAverage
        _timerDisconnectCheck.Interval = ConfigXml.Instance.sensorDisconnectionCheckIntervalSec * 1000

    End Sub
    Public Property SequenceNo() As UShort
        Get
            Return _seqNo
        End Get
        Set(ByVal value As UShort)
            _seqNo = value
        End Set
    End Property
    Public Event UnitChanged(ByVal newUnits As Units)
    Public Property Units() As Units
        Get
            Return _units
        End Get
        Protected Set(ByVal value As Units)
            _units = value
            RaiseEvent UnitChanged(value)
        End Set
    End Property
    Public ReadOnly Property UnitType() As Units.Enum_UNIT_TYPE
        Get
            Return _units.UnitType
        End Get
    End Property

    Public Property CapacityInCalibratedUnits() As Double
        Get
            Return _capacityInCalibratedUnits
        End Get
        Set(ByVal value As Double)
            If value <= 0 Then value = 1
            _capacityInCalibratedUnits = value
            _expWma = New ExpWMA(_readingsToAverage, _capacityInCalibratedUnits * 0.1 / 100)
        End Set
    End Property
    Public ReadOnly Property CapacityInOutputUnits() As Double
        'we may need this property to set the max/min for graphs
        'and maybe to set alarms
        Get
            Return _units.ConvertToOutputUnits(_capacityInCalibratedUnits)
        End Get
    End Property

    Public Property ReadingsToAverage() As Integer
        Get
            Return _readingsToAverage
        End Get
        Set(ByVal value As Integer)
            _readingsToAverage = Math.Max(1, value)
            _expWma = New ExpWMA(_readingsToAverage, _capacityInCalibratedUnits * 0.1 / 100)
        End Set
    End Property
    Public Function ConvertToOutputUnits(ByVal newReadingInCalUnits As Double)
        _expWma.NewValue(newReadingInCalUnits)
        Return _units.ConvertToOutputUnits(_expWma.Average)
    End Function
    Private _tag As String 'for use by derived classes
    Public Property Tag() As String
        Get
            Return _tag
        End Get
        Set(ByVal value As String)
            _tag = value
        End Set
    End Property
    Public Property sDisplayFormat() As String
        Get
            Return _sDisplayFormat
        End Get
        Set(ByVal value As String)
            _sDisplayFormat = value
            RaiseEvent DisplayFormatChanged(value)
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return IIf(_ss1.Length = 0, "<Unknown>", _ss1)
    End Function
    Public MustOverride Sub StartReading()
    Public MustOverride Sub StopReading()
    Public MustOverride Sub Tare()
    Public Sub StartDisconnectionTimer()
        _timerDisconnectCheck.AutoReset = True
        _timerDisconnectCheck.Enabled = True
    End Sub
    Public Sub StopDisconnectionTimer()
        _timerDisconnectCheck.Enabled = False
    End Sub

    Private Sub _timerDisconnectCheck_Tick(sender As Object, e As EventArgs) Handles _timerDisconnectCheck.Elapsed
        If _isSensorResponding = False AndAlso (Me.IsVirtualDevice = False OrElse TypeOf Me Is Dq4000Sensor) Then
            RaiseEvent SensorStoppedResponding(Me.SS1)
            Me.CurrentReading = 0
            _timerDisconnectCheck.Enabled = False
        Else
            'sensor is responding, just set responding = false and wait for the flag
            'to be set to true when data is received
            _isSensorResponding = False
        End If
    End Sub


End Class

#End If
