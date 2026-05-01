Public Class RelayCommand
    Public targetChannelIndex As UShort = 0
    Public action As RelaySetting.Enum_Relay_Action
    Public condition As RelaySetting.Enum_GtLtCondition
    Public targetValue As Double
    Public delayTimeMSec As UInteger
    Public zone As UShort 'this is the sequenceNo
    Public Function ShallowCopy() As RelayCommand
        Return DirectCast(Me.MemberwiseClone(), RelayCommand)
    End Function
    Public Sub New()
        Me.New(0, RelaySetting.Enum_Relay_Action.delay, RelaySetting.Enum_GtLtCondition.invalid, 0, 1000)
    End Sub
    Public Sub New(ByVal targetChannelIndex As UShort, ByVal action As RelaySetting.Enum_Relay_Action, ByVal condition As RelaySetting.Enum_GtLtCondition, ByVal targetValue As Double, ByVal delayTimeMSec As UInteger)
        Me.targetChannelIndex = targetChannelIndex
        Me.action = action
        Me.condition = condition
        Me.targetValue = targetValue
        Me.delayTimeMSec = delayTimeMSec
    End Sub
End Class