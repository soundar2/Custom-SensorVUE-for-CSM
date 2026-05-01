Public Interface IVirtualSensor
    Enum Enum_VirtualType
        peak
        low
        total
        formula
        average
        std
        median
    End Enum
    Property VirtualType() As Enum_VirtualType
End Interface
