Public Interface ISensor
    'only sensor properties
    'not behavior
    Property CapacityInCalibratedUnits() As Double
    Property CurrentReading() As Double
    Property ReadingsToAverage() As Integer
    Property SS1() As String
    Property SequenceNo() As UShort
    Property Units() As Units
    ReadOnly Property CapacityInOutputUnits() As Double
    ReadOnly Property UnitType() As Units.Enum_UNIT_TYPE
    Property TypeDescription() As String

End Interface
