Public MustInherit Class LsDevice
    Public Enum Enum_Device_Unit_Type
        Force
        Torque
        Length
        Angle
        Pressure
        Acceleration
        Temperature
        Relay
        Formula
        Voltage
    End Enum
    Protected _ss1 As String = String.Empty
    Private _deviceUnitType As Enum_Device_Unit_Type
    Private _typeDescription As String = "Force or Weight"

    Public Property DeviceUnitType() As Enum_Device_Unit_Type
        Get
            Return _deviceUnitType
        End Get
        Protected Set(ByVal value As Enum_Device_Unit_Type)
            _deviceUnitType = value
        End Set
    End Property
    Public Property SS1() As String
        Get
            Return _ss1
        End Get
        Set(ByVal value As String)
            If value.Length = 0 Then
                _ss1 = "<Unknown>"
            Else
                _ss1 = value
            End If
        End Set
    End Property
    Public Property TypeDescription() As String
        Get
            Return _typeDescription
        End Get
        Protected Set(ByVal value As String)
            If value.Length = 0 Then
                _typeDescription = "<Unknown>"
            Else
                _typeDescription = value
            End If
        End Set
    End Property
    Private _isVirtualDevice As Boolean = False
    Public Property IsVirtualDevice() As Boolean
        Get
            Return _isVirtualDevice
        End Get
        Protected Set(ByVal value As Boolean)
            _isVirtualDevice = value
        End Set
    End Property

End Class
