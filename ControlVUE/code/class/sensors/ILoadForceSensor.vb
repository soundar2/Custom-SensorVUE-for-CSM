Public Class ILoadForceSensor
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
        _parent.Tare(Me)
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
        DeviceUnitType = Enum_Device_Unit_Type.Force
        Me.Units = New Units(Units.Enum_UNIT_TYPE.force)
        Me.Units.CalibratedUnits = "lbf"
    End Sub

    Public ReadOnly Property ConnectionInfo As String Implements IConnectionInfo.ConnectionInfo
        Get
            Return String.Format("{0}, {1}, iLoad Force", _parent.PortName, _parent.Baud)
        End Get
    End Property
End Class
