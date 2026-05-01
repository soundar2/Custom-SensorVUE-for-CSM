Public Class TotalSensor
    Inherits Sensor
    Implements ISensor
    Implements IVirtualSensor


    Private _baseSensors As List(Of ISensor)
    Public Sub New(ByVal container As ISensorContainer, ByVal sensorIndex As Integer, ByVal baseSensors As List(Of ISensor))
        MyBase.New(container, sensorIndex)
        _baseSensors = baseSensors
        '
        'it is enough if only one sensor's datareceived is handled
        'we will use all other sensors' CurrentReading property
        AddHandler _baseSensors(0).SensorDataReceived, AddressOf BaseSensorDataReceived
        Me.ID = "Total"
    End Sub

    Public Overrides WriteOnly Property CurrentReadingInDeviceUnits As Double
        Set(value As Double)

        End Set
    End Property

    Private Sub BaseSensorDataReceived(sender As ISensor, reading As Double)
        Static lock As New Object
        SyncLock lock
            Dim sum As Double = 0
            For Each s In _baseSensors
                sum += s.CurrentReading
            Next
            If sender.SequenceNo = _baseSensors.Last.SequenceNo Then
                CurrentReading = sum
            End If
        End SyncLock
    End Sub

    Public Property VirtualType As IVirtualSensor.Enum_VirtualType Implements IVirtualSensor.VirtualType
        Get
            Return IVirtualSensor.Enum_VirtualType.total
        End Get
        Set(value As IVirtualSensor.Enum_VirtualType)

        End Set
    End Property

End Class
