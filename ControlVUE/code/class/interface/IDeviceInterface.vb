Public Interface IDeviceInterface
    Sub StartReading()
    Sub StopReading()
    Sub Tare()
    Function GetCommandResponse(ByVal cmdStr As String) As String
End Interface
