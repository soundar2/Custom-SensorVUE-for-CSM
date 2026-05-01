Public Class di1000
    Inherits Sensor

    Private _id As String
    Public Sub New(ByVal container As ISensorContainer, ByVal sensorIndex As Integer)
        MyBase.New(container, sensorIndex)
    End Sub
    Public Overrides Property ID As String
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value
            If value.Length = 0 Then
                _id = "<Unknown>"
            End If
            If value.StartsWith("DISP") Then
                Units = New Units(Units.Enum_MeasurementType.length)
            ElseIf value.StartsWith("TQ") Or value.StartsWith("TORQ") Then
                Units = New Units(Units.Enum_MeasurementType.torque)
            ElseIf value.StartsWith("PR") Then
                Units = New Units(Units.Enum_MeasurementType.pressure)
            ElseIf value.StartsWith("VM") Then
                Units = New Units(Units.Enum_MeasurementType.voltage)
            Else
                Units = New Units(Units.Enum_MeasurementType.force)
            End If
        End Set
    End Property

    Public Overrides WriteOnly Property CurrentReadingInDeviceUnits As Double
        Set(value As Double)
            CurrentReading = Units.ConvertToOutputUnits(value)
        End Set
    End Property
End Class
