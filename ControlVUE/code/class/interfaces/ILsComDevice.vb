Public Interface ILsComDevice
    Inherits ILsDevice
    ReadOnly Property PortName() As String
    ReadOnly Property BaudRate() As UInteger
    ReadOnly Property SS1(ByVal chIndex As Byte) As String
    ReadOnly Property DeviceType() As clsGlobals.Enum_DEVICE_TYPE

    Sub StartQuery(ByVal qType As clsGlobals.Enum_QUERY_TYPE)
    Sub StopQuery()
End Interface
