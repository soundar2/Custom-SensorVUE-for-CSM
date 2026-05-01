Public Interface ISensorContainer
    Enum Enum_ContainerType
        di100x
        iload
        sc1200
        dq4000
        ilevel
        iforce
        di1000hs1k
        mitutoyo
        virtual
    End Enum
    ReadOnly Property NoOfChannels() As UShort
    Function StartReading() As Boolean
    Function StopReading() As Boolean
    Function Tare(ByVal sensorIndex As UShort) As Boolean
    Function TareAll() As Boolean
    ReadOnly Property sensor(ByVal sensorIndex As Integer) As Sensor
    ReadOnly Property ConnectionInfoString(ByVal sensorIndex As Integer) As String
    ReadOnly Property ConnectionInfoString() As String
    ReadOnly Property Guid() As System.Guid
    Function PollAll() As Boolean
    Function Children() As List(Of ISensor)
    Function Type() As Enum_ContainerType
    Event DebugMessage(ByVal c As ISensorContainer, ByVal msg As String)
    Event ContainerDisconnected(ByVal sender As ISensorContainer)
    Sub SetPollingIntervalMSec(ByVal intervalMSec As Integer)
    Function GetFirmwareVersion() As String
End Interface
