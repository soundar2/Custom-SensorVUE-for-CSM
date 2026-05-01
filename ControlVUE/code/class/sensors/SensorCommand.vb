Public Class SensorCommand
    Public Enum Enum_ResponseType
        none
        oneline
        continuous
        count
        stringmatch
    End Enum

    Public commandText As String = vbCr
    Public responseType As Enum_ResponseType = Enum_ResponseType.none
    Public nOutputLine As Integer = 1 '0 means continuous
    Public terminatingString As String = "LastTare"

    Public Sub New()

    End Sub
    Public Sub New(ByVal commandText As String, ByVal responseType As Enum_ResponseType)
        Me.commandText = commandText
        Me.responseType = responseType
    End Sub
End Class
