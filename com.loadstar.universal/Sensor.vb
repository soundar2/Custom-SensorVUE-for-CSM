Imports System.Threading
Imports com.loadstar
Public MustInherit Class Sensor
    Implements ISensor

    Private _units As New Units(Units.Enum_MeasurementType.force)
    Private _myIndex As Integer
    Private _isSensorPolled As Boolean = False
    Public Shared sensorsToBeTared As New Concurrent.BlockingCollection(Of System.Guid)
    Public Sub New(ByVal container As ISensorContainer, ByVal sensorIndex As Integer)
        _container = container
        _myIndex = sensorIndex
        _tareState = ISensor.Enum_TareState.NoTareNeeded
    End Sub
    Public Shared Operator =(ByVal x As Sensor, ByVal y As Sensor)
        Return x._guid.ToString = y._guid.ToString
    End Operator
    Public Shared Operator <>(ByVal x As Sensor, ByVal y As Sensor)
        Return x._guid.ToString <> y._guid.ToString
    End Operator
    Public Property Units As Units Implements ISensor.units
        Get
            Return _units
        End Get
        Set(ByVal value As Units)
            _units = value
        End Set
    End Property
    Public Overridable Property ID As String Implements ISensor.ID
    Private _capacityInCalUnits As Double
    Public Overridable Property CapacityInCalUnits As Double Implements ISensor.CapacityInCalUnits
        Get
            Return _capacityInCalUnits
        End Get
        Set(ByVal value As Double)
            _capacityInCalUnits = value
        End Set
    End Property

    Private _capacityInOutputUnits As Double
    Public Property CapacityInOutputUnits As Double Implements ISensor.CapacityInOutputUnits
        Get
            Return _capacityInOutputUnits
        End Get
        Set(ByVal value As Double)
            _capacityInOutputUnits = value
        End Set
    End Property

    Public Function ConvertToOutputUnits(ByVal readingInCalUnits As Double) As Double Implements ISensor.ConvertToOutputUnits
        Return Me.Units.ConvertToOutputUnits(readingInCalUnits)
    End Function
    Private _lock As New ReaderWriterLockSlim
    Private _currentReading As Double
    Public Property CurrentReading As Double Implements ISensor.CurrentReading
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
            _lock.ExitWriteLock()
            _isSensorPolled = True
            RaiseEvent SensorDataReceived(Me, _currentReading)
        End Set
    End Property

    Private _displayFormat As String
    Public Property DisplayFormat As String Implements ISensor.DisplayFormat
        Get
            Return _displayFormat
        End Get
        Set(ByVal value As String)
            _displayFormat = value
        End Set
    End Property

    Private _sensorType As String
    Public Property SensorType As String Implements ISensor.SensorType
        Get
            Return _sensorType
        End Get
        Set(ByVal value As String)
            _sensorType = value
        End Set
    End Property

    Private _sequenceNo As UShort
    Public Property SequenceNo As UShort Implements ISensor.SequenceNo
        Get
            Return _sequenceNo
        End Get
        Set(ByVal value As UShort)
            _sequenceNo = value
        End Set
    End Property

    Private _container As ISensorContainer
    Public ReadOnly Property container As ISensorContainer Implements ISensor.container
        Get
            Return _container
        End Get
    End Property
    Public Event SensorDataReceived(sender As ISensor, reading As Double) Implements ISensor.SensorDataReceived

    Public MustOverride WriteOnly Property CurrentReadingInDeviceUnits As Double Implements ISensor.CurrentReadingInDeviceUnits
    Private _guid As System.Guid = System.Guid.NewGuid
    Public ReadOnly Property Guid As Guid Implements ISensor.Guid
        Get
            Return _guid
        End Get
    End Property

    Public ReadOnly Property ChildIndex As UShort Implements ISensor.ChildIndex
        Get
            Return _myIndex
        End Get
    End Property

    Public ReadOnly Property IsSensorPolled As Boolean Implements ISensor.IsSensorPolled
        Get
            Return _isSensorPolled
        End Get
    End Property
    Public Sub SetUnpolled()
        _isSensorPolled = False
    End Sub
    Private _tareState As ISensor.Enum_TareState = ISensor.Enum_TareState.NoTareNeeded


    Public Property TareState As ISensor.Enum_TareState Implements ISensor.TareState
        Get
            Return _tareState
        End Get
        Set(value As ISensor.Enum_TareState)
            _tareState = value
        End Set
    End Property
End Class
