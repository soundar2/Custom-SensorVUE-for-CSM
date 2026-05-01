Imports System.IO
Imports System.ComponentModel
Imports com.loadstar.utility
Imports LoadVUE

Public Class frmRelay
    Implements ISensorForm

    Private _relayChannels As List(Of RelayChannel)
    Private _lstCtlRelay As New List(Of ctlRelayControl)
    Public Sub New(ByVal relays As List(Of RelayChannel))

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _relayChannels = relays
    End Sub
    Private Sub frmRelay_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing And _programClose = False Then
            e.Cancel = True
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub
    Private Sub frmRelay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Hourglass.Show()
        'AddHandler _gFrmMain.mnuRelaySettings.Click, AddressOf cmdRelaySettings_Click
        'AddHandler _gFrmMain.mnuRelaySettings2.Click, AddressOf cmdRelaySettings_Click
        '
        Me.MdiParent = _gFrmMain
        '
        'mouse handling
        '
        AddMouseHandlerRecursive(Me)
        SetupRelays()
        Hourglass.Release()
    End Sub
    Private Sub SetupRelays()
        _relayChannels.Clear()
        _lstCtlRelay.Clear()
        _relayChannels = (From s In _gAttachedSensors Where s.UnitType = Units.Enum_UNIT_TYPE.relay Select CType(s, RelayChannel)).ToList
        For Each channel In _relayChannels
            RemoveHandler channel.ShowRelayCommandToExecute, AddressOf RelayChannel_ShowRelayCommandToExecute ' remove earlier handlers if any
            AddHandler channel.ShowRelayCommandToExecute, AddressOf RelayChannel_ShowRelayCommandToExecute
        Next

        Dim ctl As ctlRelayControl
        For i = 0 To _relayChannels.Count - 1
            If (i = 0) Then
                ctl = CtlRelayControl0
            Else
                ctl = New ctlRelayControl
                relayLayoutPanel.Controls.Add(ctl)
            End If
            ctl.Height = CtlRelayControl0.Height
            ctl.Width = CtlRelayControl0.Width
            ctl.Visible = True
            ctl.RelayIndex = i
            ctl.RelayBox = _relayChannels(0).Parent
            ctl.IsProgramControlled = Not (_relayChannels(i).setting.controlType = RelaySetting.Enum_Relay_Control_Type.manual)
            ctl.RelayName = _relayChannels(i).setting.relayName
            ctl.UpdateRelayStatus()
            _lstCtlRelay.Add(ctl)

        Next

        SetControlStates()
    End Sub
    Public ReadOnly Property WindowTagToSave As String Implements ISensorForm.WindowTagToSave
        Get
            Return "relay"
        End Get
    End Property

    Private _programClose As Boolean = False
    Public WriteOnly Property ProgramClose As Boolean Implements ISensorForm.ProgramClose
        Set(value As Boolean)
            _programClose = value
        End Set
    End Property

    Public Sub StartReadingSensors() Implements ISensorForm.StartReadingSensors
        dgvAction.Rows.Clear()
        For Each item In _relayChannels
            item.StartReading()
        Next
    End Sub

    Public Sub ResumeReadingSensors() Implements ISensorForm.ResumeReadingSensors
        For Each item In _relayChannels
            item.StartReading()
        Next
    End Sub
    Public Sub StopReadingSensors() Implements ISensorForm.StopReadingSensors
        For Each item In _relayChannels
            item.StopReading()
        Next
    End Sub

    Public Sub TareSensors(unitType As Units.Enum_UNIT_TYPE) Implements ISensorForm.TareSensors
        'nothing to tare
    End Sub

    Public Sub SetControlStates() Implements ISensorForm.SetControlStates
        cmdRelaySettings.Enabled = Not _gIsOperating
    End Sub

    Public Sub ResetPeakLow() Implements ISensorForm.ResetPeakLow

    End Sub

    Private Sub cmdRelaySettings_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRelaySettings.Click
        Dim frm As New frmRelaySettings
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            SetupRelays()
        End If
    End Sub

    Private Delegate Sub ShowRelayCommandToExecuteDelegate(ByVal cmd As RelayCommand)

    Private Sub RelayChannel_ShowRelayCommandToExecute(ByVal cmd As RelayCommand)
        If Me.InvokeRequired Then
            Me.Invoke(New ShowRelayCommandToExecuteDelegate(AddressOf RelayChannel_ShowRelayCommandToExecute), cmd)
        Else
            Dim n As UShort
            With dgvAction
                .Rows.Add()
                n = .RowCount - 1
                Dim col1 As String = String.Empty, col2 As String = String.Empty
                Select Case cmd.action
                    Case RelaySetting.Enum_Relay_Action.trip
                        col1 = "ON"
                    Case RelaySetting.Enum_Relay_Action.reset
                        col1 = "OFF"
                    Case RelaySetting.Enum_Relay_Action.delay
                        col1 = "Delay"
                        col2 = (cmd.delayTimeMSec / 1000).ToString("0.0")
                    Case RelaySetting.Enum_Relay_Action.waitfor
                        col1 = "Wait until"
                        Select Case cmd.condition
                            Case RelaySetting.Enum_GtLtCondition.GT
                                col1 += " >="
                            Case RelaySetting.Enum_GtLtCondition.LT
                                col1 += " <="
                        End Select
                        col2 = cmd.targetValue.ToString("0.00")
                End Select
                .Rows(n).Cells("colChannel").Value = (cmd.targetChannelIndex + 1).ToString("0")
                .Rows(n).Cells("colAction").Value = col1
                .Rows(n).Cells("colValue").Value = col2
                'we need to make sure that the new row is visible
                Static f As UInteger
                If .RowCount = 1 Then
                    f = 0
                Else
                    f += 1
                End If
                Try
                    .Rows(n).Selected = True
                    'how many rows are visible
                    .FirstDisplayedScrollingRowIndex = f
                Catch ex As Exception

                End Try
            End With
        End If
    End Sub


    Private Sub cmdClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLog.Click
        dgvAction.Rows.Clear()
    End Sub


    Public Sub ResetAllRelays()
        For Each item In _relayChannels
            item.QueueResetRelay(item.ChannelIndex)
        Next
    End Sub

    Public Sub TripAllRelays()
        For Each item In _relayChannels
            item.QueueTripRelay(item.ChannelIndex)
        Next
    End Sub

    Public Sub SaveWindowLocation() Implements ISensorForm.SaveWindowLocation
        WindowLayout.Instance.SaveWindowLocation(Me, Me.WindowTagToSave)
    End Sub

    Public Sub RestoreWindowLocation() Implements ISensorForm.RestoreWindowLocation
        WindowLayout.Instance.RestoreWindowLocation(Me, Me.WindowTagToSave)
    End Sub

    Public Function GetWindowType() As String Implements ISensorForm.GetWindowType
        Return "relay"
    End Function
    Private Sub AddMouseHandlerRecursive(ByVal parent As Control)
        AddHandler parent.MouseDown, AddressOf MouseHandler
        For Each ctl As Control In parent.Controls
            AddMouseHandlerRecursive(ctl)
        Next
    End Sub
    Private Sub MouseHandler(sender As Object, e As MouseEventArgs)
        Me.BringToFront()
    End Sub
End Class