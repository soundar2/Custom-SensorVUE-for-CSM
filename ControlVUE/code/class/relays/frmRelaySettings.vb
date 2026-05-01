Imports System.CodeDom.Compiler
Imports System.Threading
Imports System.IO
Imports System.Text
Imports com.loadstar.utility.Utility
Imports com.loadstar.utility
Public Class frmRelaySettings
    Private _relayList As List(Of RelayChannel)
    Private _isScriptVerified As Boolean = False
    Private Sub SetControlStates()
        cmdEditScript.Enabled = txtScriptFile.Text.Length <> 0
        cmdVerifyScript.Enabled = cmdEditScript.Enabled
    End Sub
    Private _tpage(0 To 5) As TabPage
    Private Sub frmRelaySettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Hourglass.Show()
        For i = 0 To TabControl1.TabPages.Count - 1
            _tpage(i) = TabControl1.TabPages(i)
        Next
        'load sensor list
        Dim sensorList = (From s In _gAttachedSensors Where Not (s.DeviceUnitType = LsDevice.Enum_Device_Unit_Type.Relay) Select s.SS1).ToList
        cmbSensors.DataSource = sensorList
        cmbSensors.SelectedIndex = 0
        'load relay list
        _relayList = (From r In _gAttachedSensors Where r.UnitType = Units.Enum_UNIT_TYPE.relay Select CType(r, RelayChannel)).ToList
        For i = 0 To ConfigXml.Instance.MAX_RELAY_CHANNELS - 1
            cmbRelays.Items.Add(i + 1)
        Next
        cmbRelays.SelectedIndex = 0
        SetControlStates()
        Hourglass.Release()
    End Sub



    Private Sub cmbSensors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSensors.SelectedIndexChanged
        ChangeUnits()
    End Sub


    Private Function IsOkToSave() As Boolean

    End Function

    Private Sub LoadThisChannel()
        Dim chIndex = cmbRelays.SelectedIndex
        optManual.Checked = False
        optScript.Checked = False
        optSimple.Checked = False
        optCommands.Checked = False
        With _relayList(chIndex).setting
            optManual.Checked = (.controlType = RelaySetting.Enum_Relay_Control_Type.manual)
            optScript.Checked = (.controlType = RelaySetting.Enum_Relay_Control_Type.script)
            optSimple.Checked = (.controlType = RelaySetting.Enum_Relay_Control_Type.simple)
            optCommands.Checked = (.controlType = RelaySetting.Enum_Relay_Control_Type.commands)
            txtRelayName.Text = .relayName
            If .controllingSs1.Length <> 0 Then
                cmbSensors.Text = .controllingSs1
            Else
                cmbSensors.SelectedIndex = 0
            End If
            txtV1.Text = .L1.ToString("0.00")
            txtV2.Text = .L2.ToString("0.00")
            For Each ctl As Control In pnlRelaySetting.Controls
                If TryCast(ctl, RadioButton) IsNot Nothing Then
                    CType(ctl, RadioButton).Checked = False
                End If
            Next
            Trip1.Checked = (.action1 = RelaySetting.Enum_Relay_Action.trip)
            Trip12.Checked = (.action12 = RelaySetting.Enum_Relay_Action.trip)
            Trip2.Checked = (.action2 = RelaySetting.Enum_Relay_Action.trip)
            Reset1.Checked = (.action1 = RelaySetting.Enum_Relay_Action.reset)
            Reset12.Checked = (.action12 = RelaySetting.Enum_Relay_Action.reset)
            Reset2.Checked = (.action2 = RelaySetting.Enum_Relay_Action.reset)
            Hold1.Checked = (.action1 = RelaySetting.Enum_Relay_Action.hold)
            Hold12.Checked = (.action12 = RelaySetting.Enum_Relay_Action.hold)
            Hold2.Checked = (.action2 = RelaySetting.Enum_Relay_Action.hold)
            chkAutoReset.Checked = .autoReset
            If optScript.Checked Then
                txtScriptFile.Text = .scriptFileName
            ElseIf optCommands.Checked Then
                CtRelayCommands1.Clear()
                If .lstCommands IsNot Nothing Then
                    Me.CtRelayCommands1.CommandList = .lstCommands
                End If
            End If
        End With
    End Sub
    Private Sub SaveThisChannel()
        Dim chIndex = cmbRelays.SelectedIndex
        With _relayList(chIndex).setting
            If optManual.Checked Then
                .controlType = RelaySetting.Enum_Relay_Control_Type.manual
            ElseIf optScript.Checked Then
                .controlType = RelaySetting.Enum_Relay_Control_Type.script
            ElseIf optSimple.Checked Then
                .controlType = RelaySetting.Enum_Relay_Control_Type.simple
            ElseIf optCommands.Checked Then
                .controlType = RelaySetting.Enum_Relay_Control_Type.commands
            End If
            If Not optManual.Checked Then
                .relayName = txtRelayName.Text.Trim
                .controllingSs1 = cmbSensors.Text
            End If
            If optSimple.Checked Then
                .autoReset = chkAutoReset.Checked
                .L1 = Val(txtV1.Text.Trim)
                .L2 = Val(txtV2.Text.Trim)
                .action1 = SelectedRelayAction(Trip1, Reset1, Hold1)
                .action12 = SelectedRelayAction(Trip12, Reset12, Hold12)
                .action2 = SelectedRelayAction(Trip2, Reset2, Hold2)
            ElseIf optScript.Checked Then
                .scriptFileName = txtScriptFile.Text
            ElseIf optCommands.Checked Then
                .lstCommands = Me.CtRelayCommands1.CommandList
            End If
        End With
    End Sub
    Private Sub ChangeUnits()
        If cmbSensors.SelectedIndex <> -1 Then
            Dim sensor As LsSensor = (From item In _gAttachedSensors Where item.SS1 = cmbSensors.Text).Single
            lblUnits.Text = sensor.Units.OutputUnits
            CtRelayCommands1.Units = sensor.Units.OutputUnits
        Else
            cmbSensors.SelectedIndex = -1
            lblUnits.Text = String.Empty
            CtRelayCommands1.Units = String.Empty
        End If
    End Sub

    Private Sub chkAutoReset_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoReset.CheckedChanged
        SetControlStates()
    End Sub

    Private Function SelectedRelayAction(ByVal tripButton As RadioButton, ByVal resetButton As RadioButton, ByVal holdButton As RadioButton) As RelaySetting.Enum_Relay_Action
        If tripButton.Checked Then
            Return RelaySetting.Enum_Relay_Action.trip
        ElseIf resetButton.Checked Then
            Return RelaySetting.Enum_Relay_Action.reset
        Else
            Return RelaySetting.Enum_Relay_Action.hold
        End If
    End Function


    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Dim dlgOpen As New OpenFileDialog
        dlgOpen.Filter = "Relay Script Files (*.TXT;*.VB)|*.TXT;*.VB"
        Dim chIndex = cmbRelays.SelectedIndex
        Dim scriptFile As String = _relayList(chIndex).setting.scriptFileName
        If scriptFile.Length <> 0 Then
            dlgOpen.FileName = scriptFile
        End If
        'dlgOpen.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        If dlgOpen.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtScriptFile.Text = dlgOpen.FileName
            SetToolTip(txtScriptFile, dlgOpen.FileName)
        End If
        SetControlStates()
    End Sub

    Private Sub cmdEditScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditScript.Click
        Dim scriptFile As String = txtScriptFile.Text
        If scriptFile.Length <> 0 Then
            System.Diagnostics.Process.Start("notepad", scriptFile)
        End If
    End Sub

    Private Sub cmdVerifyScript_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVerifyScript.Click
        _isScriptVerified = False
        If txtScriptFile.Text.Length <> 0 Then
            'compile the script file
            Dim results As CompilerResults = RelayScripting.VerifyScriptFile(txtScriptFile.Text)
            If results.Errors.Count = 0 Then
                MsgBox("Script compiled successfully. Restart the program for the for script execution.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
                _isScriptVerified = True
            Else
                ShowErrorMessage("Script error")
                Dim sb As New StringBuilder
                For Each err As CompilerError In results.Errors
                    sb.AppendLine(String.Format("Line {0}: {1}", err.Line, err.ErrorText))
                Next
                Dim frm As New frmScriptErrors(sb)
                frm.Show()
            End If
        End If
    End Sub

    Private Sub cmbRelays_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRelays.SelectedIndexChanged
        LoadThisChannel()
    End Sub

    Private Sub cmdApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        'error checks
        If txtRelayName.Text.Trim.Length = 0 Then
            Utility.FlashControl(txtRelayName) : Return
        End If
        If optScript.Checked AndAlso txtScriptFile.Text.Length <> 0 Then
            'verify script
            cmdVerifyScript.PerformClick()
            If Not _isScriptVerified Then Return
        End If
        If optCommands.Checked Then
            If Not CtRelayCommands1.CommandEnabled(0) Then
                ShowErrorMessage("No commands enabled")
                Return
            End If
        End If
        '
        'if reached here then ok to save
        Hourglass.Show()
        SaveThisChannel()
        _relayList(0).Parent.WriteRelaySettingsToFile()
        Hourglass.Release(True)
        ShowInfoMessage("Relay settings have been saved.")
    End Sub

    Private Sub optManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optManual.CheckedChanged, optScript.CheckedChanged, optSimple.CheckedChanged, optCommands.CheckedChanged
        'the tag of the radio button must match the tag of 
        'the tab page
        'remove all tabpages
        For i = TabControl1.TabPages.Count - 1 To 0 Step -1
            TabControl1.TabPages.RemoveAt(i)
        Next
        Dim tag As String = CType(sender, RadioButton).Tag
        TabControl1.TabPages.Add((From item In _tpage Where item.Tag = tag Select item).First)
        SetControlStates()
    End Sub
End Class