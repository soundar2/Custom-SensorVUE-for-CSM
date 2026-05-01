Public Class SC1200Sensor
    Inherits Sensor
    Private _id As String
    Private _lastPollTime As Date
    Public Sub New(ByVal container As ISensorContainer, ByVal sensorIndex As Integer)
        MyBase.New(container, sensorIndex)
        'set the initial last poll time to 48 hours ago
        'will be overwritten on the first read
        _lastPollTime = Now() - New TimeSpan(48, 0, 0)
    End Sub
    Public Overrides Property ID As String
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value
            If value.Length = 0 Then
                _id = "<Unknown>"
            End If
            Units = New Units(Units.Enum_MeasurementType.force)
        End Set
    End Property
    Public Overrides WriteOnly Property CurrentReadingInDeviceUnits As Double
        Set(value As Double)
            CurrentReading = Units.ConvertToOutputUnits(value)
            _lastPollTime = Now
        End Set
    End Property
    Public ReadOnly Property LastPollTime() As Date
        Get
            Return _lastPollTime
        End Get
    End Property
End Class
