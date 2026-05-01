Public Interface ISensor
    ReadOnly Property container As ISensorContainer
    Property ID() As String
    ReadOnly Property ChildIndex() As UShort
    Property SensorType() As String 'pressure, torque etc
    Property units As Units 'calibrated units
    Property CapacityInCalUnits As Double
    Property CapacityInOutputUnits As Double
    Property SequenceNo As UShort
    Property DisplayFormat As String
    Property CurrentReading() As Double
    WriteOnly Property CurrentReadingInDeviceUnits As Double
    Function ConvertToOutputUnits(ByVal readingInCalUnits As Double) As Double
    Event SensorDataReceived(ByVal sender As ISensor, ByVal reading As Double)
    ReadOnly Property Guid() As System.Guid
    ReadOnly Property IsSensorPolled() As Boolean
    Property TareState As Enum_TareState
    Enum Enum_TareState
        NoTareNeeded = 0
        NeedsTaring = 1
        Tared = 2
    End Enum
End Interface
