Module XbeeGlobals
    Public DongleLock As New Object
    Public Enum Enum_LogLevel
        all = 1
        errorOnly = 2
    End Enum
    Public logLevel As Enum_LogLevel = Enum_LogLevel.errorOnly
End Module
