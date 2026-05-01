Public Interface IRelayHost
    Sub TripRelay(ByVal channelNo As UInt16)
    Sub ResetRelay(ByVal channelNo As UInt16)
    Sub Delay(ByVal milliseconds As UInt32)
End Interface
