Option Compare Text
Option Explicit On
Option Strict Off
Imports System.IO.Ports
Imports com.loadstar.utility
Public Class frmOptions
    Public showGraphOptions As Boolean = False
    Public showLogOptions As Boolean = False
    Public showTextOptions As Boolean = False
    Public showRelayOptions As Boolean = False
    Public showPunchCounterOptions As Boolean = False
    Private Sub frmOptions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            With ConfigXml.Instance
                For Each grp In {grpForce, grpLength, grpPressure, grpTorque, grpTemperature, grpDecimals}
                    For Each ctl As Control In grp.Controls
                        If TryCast(ctl, RadioButton) IsNot Nothing Then
                            Dim rd As RadioButton = CType(ctl, RadioButton)
                            If rd.Checked Then
                                Select Case grp.Name
                                    Case grpForce.Name
                                        .forceOutputUnits = rd.Tag
                                    Case grpLength.Name
                                        .lengthOutputUnits = rd.Tag
                                    Case grpPressure.Name
                                        .pressureOutputUnits = rd.Tag
                                    Case grpTorque.Name
                                        .torqueOutputUnits = rd.Tag
                                    Case grpTemperature.Name
                                        .temperatureOutputUnits = rd.Tag
                                    Case grpDecimals.Name
                                        .lv100sDisplayFormat = rd.Tag
                                End Select
                                Exit For
                            End If
                        End If
                    Next
                Next
                ConfigXml.Instance.sensorDisconnectionCheckIntervalSec = Math.Max(1, Val(txtDisconnectionCheckInterval.Text.Trim))
                If clsGlobals.IsRunningControlVue() Then
                    ConfigXml.Instance.MAX_RELAY_CHANNELS = Math.Max(Val(cmbNRelay.Text), 1)
                End If
                .WriteConfiguration()
                .UseScientificFormatInLogFiles = chkScientific.Checked
            End With
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Hourglass.Show()
        showGraphOptions = False
        If Not clsGlobals.IsRunningControlVue() Then
            Dim relayTab = (From item In TabControl1.TabPages Where item.name.ToString.ToLower().Contains("relay") Select item).Single
            If relayTab IsNot Nothing Then
                TabControl1.TabPages.Remove(relayTab) ' remove relay tab
            End If
        End If
        With ConfigXml.Instance
            For Each grp In {grpForce, grpLength, grpPressure, grpTorque, grpTemperature, grpDecimals}
                Dim configUnits As String = ""
                Select Case grp.Name
                    Case grpForce.Name
                        configUnits = .forceOutputUnits
                    Case grpLength.Name
                        configUnits = .lengthOutputUnits
                    Case grpPressure.Name
                        configUnits = .pressureOutputUnits
                    Case grpTorque.Name
                        configUnits = .torqueOutputUnits
                    Case grpTemperature.Name
                        configUnits = .temperatureOutputUnits
                    Case grpDecimals.Name
                        configUnits = .lv100sDisplayFormat
                End Select

                For Each ctl As Control In grp.Controls
                    If TryCast(ctl, RadioButton) IsNot Nothing Then
                        Dim rd As RadioButton = CType(ctl, RadioButton)
                        If rd.Tag = configUnits Then
                            rd.Checked = True
                            Exit For
                        Else
                            rd.Checked = False
                        End If
                    End If
                Next
            Next
            chkScientific.Checked = .UseScientificFormatInLogFiles
        End With
        txtDisconnectionCheckInterval.Text = Math.Max(1, ConfigXml.Instance.sensorDisconnectionCheckIntervalSec)
        Dim nRelay = Math.Max(ConfigXml.Instance.MAX_RELAY_CHANNELS, 0)
        For Each item As String In cmbNRelay.Items
            If Val(item) = nRelay Then
                cmbNRelay.Text = item
                Exit For
            End If
        Next
        cmdRelayOptions.Enabled = (clsGlobals.IsRunningControlVue = True)
        Hourglass.Release()
    End Sub

    Private Sub cmdGraphOptions_Click(sender As Object, e As EventArgs) Handles cmdGraphOptions.Click
        showGraphOptions = True
        Me.Close()
    End Sub

    Private Sub cmdLogOptions_Click(sender As Object, e As EventArgs) Handles cmdLogOptions.Click
        showLogOptions = True
        Me.Close()
    End Sub

    Private Sub cmdTextOptions_Click(sender As Object, e As EventArgs) Handles cmdTextOptions.Click
        showTextOptions = True
        Me.Close()
    End Sub

    Private Sub cmdRelayOptions_Click(sender As Object, e As EventArgs) Handles cmdRelayOptions.Click
        showRelayOptions = True
        Me.Close()
    End Sub

    Private Sub cmdPunchCounterOptions_Click(sender As Object, e As EventArgs) Handles cmdPunchCounterOptions.Click
        showPunchCounterOptions = True
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
