Imports com.loadstar.utility
Public Class frmTareSensors
    Private _regularSensors, _loadSensors, _torqueSensors, _pressureSensors, _lengthSensors, _voltageSensors, _iLevelSensors _
            As List(Of LsSensor)
    Public Event TareRequested(ByVal unitType As Units.Enum_UNIT_TYPE)
    Private Sub frmTareSensors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _regularSensors = (From s In _gAttachedSensors Where TryCast(s, DerivedSensor) Is Nothing _
                           AndAlso TryCast(s, FilterSensor) Is Nothing _
                           Select s).ToList
        _loadSensors = (From s In _regularSensors Where s.UnitType = Units.Enum_UNIT_TYPE.force Select s).ToList
        _torqueSensors = (From s In _regularSensors Where s.UnitType = Units.Enum_UNIT_TYPE.torque Select s).ToList
        _pressureSensors = (From s In _regularSensors Where s.UnitType = Units.Enum_UNIT_TYPE.pressure Select s).ToList
        _voltageSensors = (From s In _regularSensors Where s.UnitType = Units.Enum_UNIT_TYPE.voltage Select s).ToList
        cmdTareLoad.Enabled = (_loadSensors.Count <> 0)
        cmdTareTorque.Enabled = (_torqueSensors.Count <> 0)
        cmdTareDisp.Enabled = (_lengthSensors.Count <> 0)
        cmdTareILevel.Enabled = (_iLevelSensors.Count <> 0)
        cmdTarePressure.Enabled = (_pressureSensors.Count <> 0)
        cmdTareVoltage.Enabled = (_voltageSensors.Count <> 0)
    End Sub

    Private Sub cmdTareLoad_Click(sender As Object, e As EventArgs) Handles cmdTareLoad.Click
        RaiseEvent TareRequested(Units.Enum_UNIT_TYPE.force)
    End Sub

    Private Sub cmdTareTorque_Click(sender As Object, e As EventArgs) Handles cmdTareTorque.Click
        RaiseEvent TareRequested(Units.Enum_UNIT_TYPE.torque)
    End Sub

    Private Sub cmdTareVoltage_Click(sender As Object, e As EventArgs) Handles cmdTareVoltage.Click
        RaiseEvent TareRequested(Units.Enum_UNIT_TYPE.voltage)
    End Sub
    Private Sub cmdTareDisp_Click(sender As Object, e As EventArgs) Handles cmdTareDisp.Click, cmdTareILevel.Click
        RaiseEvent TareRequested(Units.Enum_UNIT_TYPE.length)
    End Sub

    Private Sub cmdTarePressure_Click(sender As Object, e As EventArgs) Handles cmdTarePressure.Click
        RaiseEvent TareRequested(Units.Enum_UNIT_TYPE.pressure)
    End Sub
    Private Sub cmdTareAll_Click(sender As Object, e As EventArgs) Handles cmdTareAll.Click
        RaiseEvent TareRequested(Units.Enum_UNIT_TYPE.none)
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

End Class