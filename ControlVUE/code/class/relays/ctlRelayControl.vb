Public Class ctlRelayControl
    Private _myRelayIndex As Byte = 0
    Private _isProgramControlled As Boolean = False
    Private WithEvents _relayBox As NcdRelayBox
    Public Property RelayIndex() As Byte
        Get
            Return _myRelayIndex
        End Get
        Set(ByVal value As Byte)
            _myRelayIndex = value
            SetRelayIndex()
        End Set
    End Property

    Public Property RelayName() As String
        Get
            Return lblRelayName.Text
        End Get
        Set(ByVal value As String)
            lblRelayName.Text = value
        End Set
    End Property

    Public WriteOnly Property RelayBox() As NcdRelayBox
        Set(ByVal value As NcdRelayBox)
            _relayBox = value
        End Set
    End Property
    Private Sub ctlRelayControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetRelayIndex()
    End Sub

    Private Sub cmdTrip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTrip.Click
        _relayBox.TripRelay(_myRelayIndex) 'we get a call back and update the status
        'If Not (_isProgramControlled And _gIsOperating) Then
        '    _relayBox.TripRelay(_myRelayIndex) 'we get a call back and update the status
        'End If
    End Sub

    Private Sub cmdReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        _relayBox.ResetRelay(_myRelayIndex) 'we get a call back and update the status
    End Sub
    Public Sub UpdateRelayStatus()
        Dim tripped As Boolean = _relayBox.IsRelayTripped(_myRelayIndex)
        'cmdReset.Enabled = tripped
        lblRelayName.BackColor = IIf(tripped, Color.Red, Color.FromKnownColor(KnownColor.Control))
        picRelayStatus.Image = IIf(tripped, My.Resources.relay_tripped2, My.Resources.relay_reset2)
        picRelayStatus.BringToFront()
        picRelayStatus.BackColor = Color.Transparent
        'If _gIsOperating Then
        '    cmdTrip.Enabled = Not tripped AndAlso (_isProgramControlled = False)
        'Else
        '    cmdTrip.Enabled = Not tripped
        'End If
        lblAuto.Visible = _isProgramControlled
    End Sub
    Private Sub SetRelayIndex()
        lblRelayNo.Text = _myRelayIndex + 1
        Me.BackColor = Color.FromKnownColor(KnownColor.Control)
        'If _myRelayIndex Mod 2 = 1 Then
        '    Me.BackColor = Color.LightCyan
        'Else
        '    Me.BackColor = Color.FromKnownColor(KnownColor.Control)
        'End If
    End Sub
    Public Property IsProgramControlled() As Boolean
        Get
            Return _isProgramControlled
        End Get
        Set(ByVal value As Boolean)
            _isProgramControlled = value
            lblAuto.Visible = value
        End Set
    End Property

    Private Sub _relayBox_RelayIsReset(ByVal relayIndex As UShort) Handles _relayBox.RelayIsReset
        If relayIndex = _myRelayIndex Then
            RelayStatusChanged()
        End If
    End Sub

    Private Sub _relayBox_RelayIsTripped(ByVal relayIndex As UShort) Handles _relayBox.RelayIsTripped
        If relayIndex = _myRelayIndex Then
            RelayStatusChanged()
        End If
    End Sub
    Private Delegate Sub RelayStatusChangedDelegate()
    Private Sub RelayStatusChanged()
        If Me.InvokeRequired Then
            Me.Invoke(New RelayStatusChangedDelegate(AddressOf RelayStatusChanged))
        Else
            UpdateRelayStatus()
        End If
    End Sub
End Class
