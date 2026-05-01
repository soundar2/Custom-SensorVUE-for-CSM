Public Class ctlRelayCommand
    Private _sUnits As String
    Private _cmdEnabled As Boolean = False
    Private _cmdIndex As UShort
    Private INVALID_VALUE = 999
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    Public Sub Initialize(ByVal cmdIndex As UShort)
        lblIndex.Text = (cmdIndex + 1) & "."
        cmbAction.SelectedIndex = 0
        cmbCondition.SelectedIndex = 0
        txtValue.Text = 0
        lblUnits.Text = "lbf"
        chkEnabled.Checked = False
    End Sub
    Private Sub SetControlStates()
        pnlCondition.Visible = (cmbAction.SelectedIndex = 0) 'No 'condition' for delay
        pnlValue.Visible = (cmbAction.SelectedIndex = 0 OrElse cmbAction.SelectedIndex = 3)
        lblUnits.Visible = (cmbAction.SelectedIndex <> 3)
        lblSeconds.Visible = Not lblUnits.Visible
        pnlCommand.Enabled = chkEnabled.Checked
    End Sub

    Public Property CommandEnabled() As Boolean
        Get
            Return _cmdEnabled
        End Get
        Set(ByVal value As Boolean)
            _cmdEnabled = value
            chkEnabled.Checked = value
        End Set
    End Property
    Public Property Units() As String
        Get
            Return _sUnits
        End Get
        Set(ByVal value As String)
            If Not Me.DesignMode Then
                _sUnits = value
                lblUnits.Text = _sUnits
                SetControlStates()
            End If
        End Set
    End Property
    Private Sub cmbCondition_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCondition.SelectionChangeCommitted
        SetControlStates()
    End Sub

    Private Sub chkEnabled_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEnabled.CheckStateChanged
        _cmdEnabled = chkEnabled.Checked
        SetControlStates()
    End Sub

    Private Sub cmbAction_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAction.SelectionChangeCommitted
        SetControlStates()
    End Sub
    Public Sub Clear()
        cmbAction.SelectedIndex = 0
        cmbCondition.SelectedIndex = 0
        txtValue.Text = "0"
        chkEnabled.Checked = False
    End Sub
    Friend Function ReadSetting() As RelayCommand
        Dim cmd As New RelayCommand
        cmd.zone = _cmdIndex
        cmd.action = RelaySetting.Enum_Relay_Action.invalid
        Select Case cmbAction.SelectedIndex
            Case 0
                cmd.action = RelaySetting.Enum_Relay_Action.waitfor
                cmd.targetValue = Val(txtValue.Text.Trim)
            Case 1
                cmd.action = RelaySetting.Enum_Relay_Action.trip
                cmd.targetValue = INVALID_VALUE
            Case 2
                cmd.action = RelaySetting.Enum_Relay_Action.reset
                cmd.targetValue = INVALID_VALUE
            Case Else
                cmd.action = RelaySetting.Enum_Relay_Action.delay
                cmd.delayTimeMSec = Val(txtValue.Text.Trim) * 1000
        End Select
        Select Case cmbCondition.SelectedIndex
            Case 0
                cmd.condition = RelaySetting.Enum_GtLtCondition.GT
            Case Else
                cmd.condition = RelaySetting.Enum_GtLtCondition.LT
        End Select
        Return cmd
    End Function
    Friend Sub WriteSetting(ByVal cmd As RelayCommand)
        Select Case cmd.action
            Case RelaySetting.Enum_Relay_Action.waitfor
                cmbAction.SelectedIndex = 0
                txtValue.Text = cmd.targetValue
            Case RelaySetting.Enum_Relay_Action.trip
                cmbAction.SelectedIndex = 1
            Case RelaySetting.Enum_Relay_Action.delay
                cmbAction.SelectedIndex = 3 'delay
                txtValue.Text = (cmd.delayTimeMSec / 1000).ToString("0.0")
            Case Else 'reset
                cmbAction.SelectedIndex = 2
        End Select
        Select Case cmd.condition
            Case 1
                cmbCondition.SelectedIndex = 0
            Case Else
                cmbCondition.SelectedIndex = 1
        End Select
        chkEnabled.Checked = True
    End Sub
End Class
