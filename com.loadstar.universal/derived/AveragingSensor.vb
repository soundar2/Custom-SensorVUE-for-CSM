Public Class AveragingSensor
    Inherits Sensor
    Implements ISensor
    Implements IVirtualSensor


    Private WithEvents _baseSensor As ISensor
    Private _average As Double = 0
    Private _expWma As ExpWMA
    Private _pointsToAverage As UInteger = 10
    Private _jumpThreshold As Double = 0
    Public Sub New(ByVal container As ISensorContainer, ByVal sensorIndex As Integer, ByVal baseSensor As ISensor)
        MyBase.New(container, sensorIndex)
        _baseSensor = baseSensor
        _expWma = New ExpWMA(_pointsToAverage, _jumpThreshold)
        Me.ID = String.Format("Average of ({0})", _baseSensor.ID)
    End Sub
    Public Property PointsToAverage() As UInteger
        Get
            Return _pointsToAverage
        End Get
        Set(ByVal value As UInteger)
            _pointsToAverage = Math.Max(1, value)
            _expWma = New ExpWMA(_pointsToAverage, _jumpThreshold)
        End Set
    End Property

    Public Property JumpThreshold() As Double
        Get
            Return _jumpThreshold
        End Get
        Set(ByVal value As Double)
            _jumpThreshold = value
            _expWma = New ExpWMA(_pointsToAverage, _jumpThreshold)
        End Set
    End Property
    Public Overrides WriteOnly Property CurrentReadingInDeviceUnits As Double
        Set(value As Double)

        End Set
    End Property

    Private Sub _baseSensor_SensorDataReceived(sender As ISensor, reading As Double) Handles _baseSensor.SensorDataReceived
        _expWma.NewValue(_baseSensor.CurrentReading)
        CurrentReading = _expWma.Average
    End Sub

    Public Property VirtualType As IVirtualSensor.Enum_VirtualType Implements IVirtualSensor.VirtualType
        Get
            Return IVirtualSensor.Enum_VirtualType.average
        End Get
        Set(value As IVirtualSensor.Enum_VirtualType)

        End Set
    End Property
    Public Sub Reset()
        _expWma.Reset()
    End Sub
End Class
