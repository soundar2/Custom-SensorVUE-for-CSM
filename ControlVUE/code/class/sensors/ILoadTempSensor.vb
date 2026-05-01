Public Class ILoadTempSensor
    Inherits LsSensor
    Implements IDerivedSensor
    Implements IConnectionInfo
    Implements IFilterable
    Implements IAlarmable

    Private _parent As ILoadForceTempSensor

    Public Sub ResetPeakLow() Implements IDerivedSensor.ResetPeakLow

    End Sub
    Public Overrides Sub StartReading()
        ResetPeakLow()
        _parent.StartReading(Me)
    End Sub

    Public Overrides Sub StopReading()
        _parent.StopReading(Me)
    End Sub

    Public Overrides Sub Tare()
    End Sub
    Public WriteOnly Property Reading() As Double
        Set(ByVal value As Double)
            CurrentReading = ConvertToOutputUnits(value)
        End Set
    End Property

    Private _parentPortName As String
    Public Property ParentPortName() As String
        Get
            Return _parentPortName
        End Get
        Set(ByVal value As String)
            _parentPortName = value
        End Set
    End Property

    Public Sub New(ByVal parent As ILoadForceTempSensor)
        _parent = parent
        DeviceUnitType = Enum_Device_Unit_Type.Temperature
        Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.temperature)
        Me.Units.CalibratedUnits = "C"
        TypeDescription = "Temperature"
    End Sub

    Public ReadOnly Property ConnectionInfo As String Implements IConnectionInfo.ConnectionInfo
        Get
            Return String.Format("{0}, {1}", ParentPortName, "iLoad Temperature")
        End Get
    End Property
End Class
