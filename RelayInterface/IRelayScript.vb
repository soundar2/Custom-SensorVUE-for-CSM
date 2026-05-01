Public Interface IRelayScript
    Sub Initialize(ByVal host As IRelayHost)
    Sub SensorDataReceived(ByVal data As Double)
    Sub StartMonitoring()
    Sub StopMonitoring()
End Interface
