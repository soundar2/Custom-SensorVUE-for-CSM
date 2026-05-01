Public Class PeakSensor
    Inherits Sensor
    Implements ISensor
    Implements IVirtualSensor


    Private WithEvents _baseSensor As ISensor
    Private _peak As Double = Integer.MinValue
    Public Sub New(ByVal container As ISensorContainer, ByVal sensorIndex As Integer, ByVal baseSensor As ISensor)
        MyBase.New(container, sensorIndex)
        _baseSensor = baseSensor
        Me.ID = String.Format("Peak of ({0})", _baseSensor.ID)
    End Sub

    Public Overrides WriteOnly Property CurrentReadingInDeviceUnits As Double
        Set(value As Double)

        End Set
    End Property

    Private Sub _baseSensor_SensorDataReceived(sender As ISensor, reading As Double) Handles _baseSensor.SensorDataReceived
        _peak = Math.Max(_peak, _baseSensor.CurrentReading)
        If _peak <> Integer.MinValue Then
            CurrentReading = _peak
        End If
    End Sub

    Public Property VirtualType As IVirtualSensor.Enum_VirtualType Implements IVirtualSensor.VirtualType
        Get
            Return IVirtualSensor.Enum_VirtualType.peak
        End Get
        Set(value As IVirtualSensor.Enum_VirtualType)

        End Set
    End Property
    Public Sub ResetPeak()
        _peak = Integer.MinValue
    End Sub
End Class
