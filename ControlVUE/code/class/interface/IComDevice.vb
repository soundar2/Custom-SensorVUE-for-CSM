Public Interface IComDevice
    Sub SerialPortSlowWrite(ByVal str As String)
    ReadOnly Property PortName() As String
    ReadOnly Property Baud() As UInteger
    Function TryOpen() As Boolean
    Function TryClose() As Boolean
    Sub EnableDataReceivedEvent()
    Sub DisableDataReceivedEvent()
End Interface
