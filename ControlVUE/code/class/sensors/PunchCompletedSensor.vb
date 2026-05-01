Imports System.Threading
Imports System.Threading.Tasks.Dataflow
Imports System.ComponentModel
Public Class PunchCompletedSensor
    Inherits LsSensor

    Private _baseSensor As PunchForceSensor
    Public Sub New(ByVal baseSensor As PunchForceSensor)
        _baseSensor = baseSensor
        AddHandler _baseSensor.PunchThrown, AddressOf PunchThrown
        TypeDescription = "Punch Completed"
        Me.SS1 = String.Format("Punch Completed ({0})", _baseSensor.BaseSensor.SS1)
        IsVirtualDevice = True
    End Sub

    Public Overrides Sub StartReading()
    End Sub
    Protected Sub PunchThrown(ByVal pf As PunchForceSensor.TIMESTAMPED_FORCE)
        CurrentReading = pf.force
    End Sub

    Public Overrides Sub StopReading()
    End Sub

    Public Overrides Sub Tare()
    End Sub
End Class
