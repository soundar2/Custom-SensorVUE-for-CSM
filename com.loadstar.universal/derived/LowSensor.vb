Public Class LowSensor
    Inherits Sensor
    Implements ISensor
    Implements IVirtualSensor


    Private WithEvents _baseSensor As ISensor
    Private _low As Double = Integer.MaxValue
    Public Sub New(ByVal container As ISensorContainer, ByVal sensorIndex As Integer, ByVal baseSensor As ISensor)
        MyBase.New(container, sensorIndex)
        _baseSensor = baseSensor
        Me.ID = String.Format("Low of ({0})", _baseSensor.ID)
    End Sub

    Public Overrides WriteOnly Property CurrentReadingInDeviceUnits As Double
        Set(value As Double)

        End Set
    End Property

    Private Sub _baseSensor_SensorDataReceived(sender As ISensor, reading As Double) Handles _baseSensor.SensorDataReceived
        _low = Math.Min(_low, _baseSensor.CurrentReading)
        If _low <> Integer.MaxValue Then
            CurrentReading = _low
        End If
    End Sub

    Public Property VirtualType As IVirtualSensor.Enum_VirtualType Implements IVirtualSensor.VirtualType
        Get
            Return IVirtualSensor.Enum_VirtualType.low
        End Get
        Set(value As IVirtualSensor.Enum_VirtualType)

        End Set
    End Property
    Public Sub ResetLow()
        _low = Integer.MaxValue
    End Sub
End Class
