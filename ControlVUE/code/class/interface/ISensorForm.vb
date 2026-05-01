Public Interface ISensorForm
    Sub StartReadingSensors()
    Sub ResumeReadingSensors()
    Sub StopReadingSensors()
    Sub TareSensors(ByVal unitType As Units.Enum_UNIT_TYPE)
    Function GetWindowType() As String
    Sub SetControlStates()
    Sub ResetPeakLow()
    ReadOnly Property WindowTagToSave() As String
    Sub SaveWindowLocation()
    Sub RestoreWindowLocation()
    WriteOnly Property ProgramClose() As Boolean

End Interface
