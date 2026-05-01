Public Interface IConnection
    Enum Enum_ConnectionType
        serial
        wifi
        xbeeApiDongle
    End Enum
    'Function StartReading() As Boolean - not required, taken care of by xmit streaming command
    Event SensorStringDataReceived(ByVal sender As IConnection, ByVal data As String)
    Function Flush() As Boolean
    Function GetCommandResponse(ByVal cmd As SensorCommand) As String
    Function GetMultiLineResponse(ByVal cmd As SensorCommand) As List(Of String)
    Function StopReading() As Boolean
    Function TryClose() As Boolean
    Function TryOpen() As Boolean
    Function XmitCommand(ByVal cmd As SensorCommand) As Boolean
    Function XmitStreamingCommand(ByVal commandText As String) As Boolean
    Property LineTerminator() As Char
    Property StreamingByteCount() As UShort 'byte count per reading while streaming data
    ReadOnly Property ConnectionInfoString() As String
    ReadOnly Property IsConnected() As Boolean
End Interface

