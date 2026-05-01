Public MustInherit Class Container
    Protected _guid As System.Guid = System.Guid.NewGuid
    Protected WithEvents _connection As IConnection
    Protected WithEvents _timerPoll As New System.Timers.Timer
    Protected WithEvents _timerTare As New System.Timers.Timer
    Public Shared Operator =(ByVal x As Container, ByVal y As Container)
        Return x._guid.ToString = y._guid.ToString
    End Operator
    Public Shared Operator <>(ByVal x As Container, ByVal y As Container)
        Return x._guid.ToString <> y._guid.ToString
    End Operator
    Protected Sub SetPollingIntervalMSec(ByVal intervalMSec As Integer)
        _timerPoll.Interval = intervalMSec
    End Sub
    Protected Sub SetTaringIntervalMSec(ByVal intervalMSec As Integer)
        _timerTare.Interval = intervalMSec
    End Sub
    Public Sub New()

    End Sub
End Class
