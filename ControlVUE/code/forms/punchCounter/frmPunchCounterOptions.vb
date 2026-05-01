Option Compare Text
Option Explicit On
Option Strict Off
Imports System.IO.Ports
Imports com.loadstar.utility.Utility
Imports com.loadstar.utility
Public Class frmPunchCounterOptions
    Private _prevPunchForceSensorSs1 As String = String.Empty
    Private Sub frmPunchCounterOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Hourglass.Show()
            ConfigXml.Instance.punchForceSensorSs1 = cmbSensor.Text
            ConfigXml.Instance.punchThresholdLb = txtPunchThreshold.Text
            ConfigXml.Instance.punchIntervalMSec = udPunchInterval.Value
            ConfigXml.Instance.punchTimerEnableAutoStop = chkAutostop.Checked
            ConfigXml.Instance.punchTimerAutostopMin = udMinutes.Value
            ConfigXml.Instance.punchTimerAutostopSec = udSeconds.Value
            ConfigXml.Instance.startTimerAfterFirstPunch = chkTimerFirstPunch.Checked
            ConfigXml.Instance.WriteConfiguration()
            Hourglass.Release()
            If _prevPunchForceSensorSs1 <> cmbSensor.Text Then
                ShowInfoMessage("Program will be restarted for the settings to take effect.")
                ConfigXml.RestartApplication = True
            End If
        End If
    End Sub

    Private Sub frmPunchCounterOptions_Load(sender As Object, e As EventArgs) Handles Me.Load
        Hourglass.Show()
        'populate sensors
        For Each s In _gAttachedSensors
            If TryCast(s, IPunchable) IsNot Nothing Then
                cmbSensor.Items.Add(s.SS1)
                If s.SS1 = ConfigXml.Instance.punchForceSensorSs1 Then
                    cmbSensor.SelectedIndex = cmbSensor.Items.Count - 1
                    _prevPunchForceSensorSs1 = s.SS1
                End If
            End If
        Next
        If cmbSensor.SelectedIndex = -1 Then
            cmbSensor.SelectedIndex = 0
        End If

        txtPunchThreshold.Text = ConfigXml.Instance.punchThresholdLb.ToString("0")
        udPunchInterval.Value = ConfigXml.Instance.punchIntervalMSec
        chkAutostop.Checked = ConfigXml.Instance.punchTimerEnableAutoStop
        udMinutes.Value = ConfigXml.Instance.punchTimerAutostopMin
        udSeconds.Value = ConfigXml.Instance.punchTimerAutostopSec
        chkTimerFirstPunch.Checked = ConfigXml.Instance.startTimerAfterFirstPunch
        cmbSensor_Click(Nothing, Nothing)
        Hourglass.Release()
    End Sub

    Private Sub chkAutostop_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutostop.CheckedChanged, chkAutostop.Click
        chkTimerFirstPunch.Enabled = chkAutostop.Checked
    End Sub

    Private Sub cmbSensor_Click(sender As Object, e As EventArgs) Handles cmbSensor.Click, cmbSensor.SelectionChangeCommitted
        grpSettings.Enabled = cmbSensor.SelectedIndex <> -1
        cmdOK.Enabled = cmbSensor.SelectedIndex <> -1
    End Sub

    Private Sub chkTimerFirstPunch_CheckedChanged(sender As Object, e As EventArgs) Handles chkTimerFirstPunch.CheckedChanged

    End Sub
End Class
