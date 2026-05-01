Imports System.Threading
Imports System.ComponentModel
Public Class RelayChannel
    Inherits LsSensor
    Implements RelayInterface.IRelayHost
    Implements IConnectionInfo
    ' represents a single relay in a relay box
    '
    'all delay values in milliseconds
    '
    Private _myIndex As UShort
    Private WithEvents _bgworker As New BackgroundWorker
    Public Enum Enum_RelayState
        none
        reset
        tripped
    End Enum
    Private _relayCommandQ As New Queue(Of RelayCommand) 'for this channel only
    Private _parent As NcdRelayBox
    Public WithEvents setting As RelaySetting
    Private _myState As Enum_RelayState
    Private _lock As Object
    Event ShowRelayCommandToExecute(ByVal cmd As RelayCommand)
    Public Sub New(ByVal parent As NcdRelayBox, ByVal index As UShort)
        _parent = parent
        Me.Units = New Units(Units.Enum_UNIT_TYPE.relay)
        DeviceUnitType = Enum_Device_Unit_Type.Relay
        TypeDescription = "Relay"
        _myIndex = index
        setting = New RelaySetting(index)
        _myState = IIf(parent.IsRelayTripped(index), Enum_RelayState.tripped, Enum_RelayState.reset)
        AddHandler parent.RelayIsTripped, AddressOf RelayIsTripped
        AddHandler parent.RelayIsReset, AddressOf RelayIsReset
        _bgworker.WorkerReportsProgress = True
        _bgworker.WorkerSupportsCancellation = True
        'we need to run the background task right away as 
        'the ALL RELAYS OFF emergency button should work even if 
        'start button is not clicked
        If Not _bgworker.IsBusy Then
            _bgworker.RunWorkerAsync()
        End If
    End Sub
    Public Sub New()
        'used for serialization
        Me.Units = New Units(Units.Enum_UNIT_TYPE.relay)
        DeviceUnitType = Enum_Device_Unit_Type.Relay
    End Sub
    Public Property Parent() As NcdRelayBox
        Get
            Return _parent
        End Get
        Set(ByVal value As NcdRelayBox)
            _parent = value
        End Set
    End Property

    Public ReadOnly Property ChannelIndex() As UShort
        Get
            Return _myIndex
        End Get
    End Property
    Public Property RelayState() As Enum_RelayState
        Get
            Return _myState
        End Get
        Set(ByVal value As Enum_RelayState)
            _myState = value
        End Set
    End Property
    Public Overrides Sub StartReading()
        _relayCommandQ.Clear()
        If Not _bgworker.IsBusy Then
            _bgworker.RunWorkerAsync()
        End If
        If setting.controlType <> RelaySetting.Enum_Relay_Control_Type.manual AndAlso setting.controllingSs1.Length <> 0 Then
            _controllingSensor = (From s In _gAttachedSensors Where s.SS1 = setting.controllingSs1 Select s).Single
            If setting.controlType = RelaySetting.Enum_Relay_Control_Type.script Then
                setting.compiledScript.Initialize(Me)
                setting.compiledScript.StartMonitoring()
            End If
            setting.StartMonitoring() 'initializes the command zone to 0 if commands are set
        Else
            _controllingSensor = Nothing
        End If
    End Sub

    Public Overrides Sub StopReading()
        If _controllingSensor IsNot Nothing Then
            If setting.controlType = RelaySetting.Enum_Relay_Control_Type.script Then
                setting.compiledScript.StopMonitoring()
            End If
        End If
        _bgworker.CancelAsync()
    End Sub

    Public Overrides Sub Tare()

    End Sub

    Private WithEvents _controllingSensor As LsSensor

    Private Sub _controllingSensor_SensorDataReceived(ByVal seqNo As UShort) Handles _controllingSensor.SensorDataReceived
        If setting.controlType = RelaySetting.Enum_Relay_Control_Type.script Then
            setting.MonitorRelayWithScript(_controllingSensor.CurrentReading) 'this calls scripttriprelay and scriptresetrelay
        ElseIf setting.controlType <> RelaySetting.Enum_Relay_Control_Type.manual Then
            'for both simple and command based
            Dim cmd As RelayCommand = setting.MonitorRelay(_controllingSensor.CurrentReading)
            If cmd IsNot Nothing Then
                Select Case cmd.action
                    Case RelaySetting.Enum_Relay_Action.trip
                        If _myState <> Enum_RelayState.tripped Then
                            QueueTripRelay(_myIndex)
                        End If
                    Case RelaySetting.Enum_Relay_Action.reset
                        If _myState <> Enum_RelayState.reset Then
                            QueueResetRelay(_myIndex)
                        End If
                    Case RelaySetting.Enum_Relay_Action.delay
                        QueueDelay(_myIndex, cmd.delayTimeMSec)
                End Select
            End If
        End If
    End Sub
    Private Sub RelayIsTripped(ByVal relayIndex As UShort)
        If relayIndex = _myIndex Then
            _myState = Enum_RelayState.tripped
            CurrentReading = 1
        End If
    End Sub
    Private Sub RelayIsReset(ByVal relayIndex As UShort)
        If relayIndex = _myIndex Then
            _myState = Enum_RelayState.reset
            CurrentReading = 0
        End If
    End Sub

    Private Sub _bgworker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _bgworker.DoWork
        Static cmd As RelayCommand
        Do
            SyncLock _relayCommandQ
                If _relayCommandQ.Count <> 0 Then
                    cmd = _relayCommandQ.Dequeue
                Else
                    Thread.Sleep(500)
                    Continue Do
                End If
            End SyncLock
            Select Case cmd.action
                Case RelaySetting.Enum_Relay_Action.trip
                    If _myIndex = cmd.targetChannelIndex Then
                        If _myState <> Enum_RelayState.tripped Then
                            _parent.TripRelay(_myIndex)
                            _myState = Enum_RelayState.tripped
                        End If
                    Else
                        'will only happen when called from script
                        _parent.TripRelay(cmd.targetChannelIndex)
                    End If
                Case RelaySetting.Enum_Relay_Action.reset
                    If _myIndex = cmd.targetChannelIndex Then
                        If _myState <> Enum_RelayState.reset Then
                            _parent.ResetRelay(_myIndex)
                            _myState = Enum_RelayState.reset
                        End If
                    Else
                        'will only happen when called from script
                        _parent.ResetRelay(cmd.targetChannelIndex)
                    End If
                Case RelaySetting.Enum_Relay_Action.delay
                    System.Threading.Thread.Sleep(cmd.delayTimeMSec)
                    setting.delayExecuting = False
            End Select
        Loop
    End Sub
#Region "relaybox"
    Public Sub QueueTripRelay(ByVal channelNo As UShort)
        SyncLock _relayCommandQ
            _relayCommandQ.Enqueue(New RelayCommand(channelNo, RelaySetting.Enum_Relay_Action.trip, RelaySetting.Enum_GtLtCondition.invalid, 0, 0))
        End SyncLock
    End Sub
    Public Sub QueueResetRelay(ByVal channelNo As UShort)
        SyncLock _relayCommandQ
            _relayCommandQ.Enqueue(New RelayCommand(channelNo, RelaySetting.Enum_Relay_Action.reset, RelaySetting.Enum_GtLtCondition.invalid, 0, 0))
        End SyncLock
    End Sub
    Public Sub QueueDelay(ByVal channelNo As UShort, ByVal msec As UInteger)
        SyncLock _relayCommandQ
            _relayCommandQ.Enqueue(New RelayCommand(channelNo, RelaySetting.Enum_Relay_Action.delay, RelaySetting.Enum_GtLtCondition.invalid, 0, msec))
        End SyncLock
    End Sub
#End Region
#Region "script"
    Public Sub ScriptResetRelay(ByVal channelNo As UShort) Implements RelayInterface.IRelayHost.ResetRelay
        'channel No issued by script is one based
        'whereas in controlvue it is zero based
        'so subtract one
        QueueResetRelay(channelNo - 1)
    End Sub

    Public Sub ScriptTripRelay(ByVal channelNo As UShort) Implements RelayInterface.IRelayHost.TripRelay
        'channel No issued by script is one based
        'whereas in controlvue it is zero based
        'so subtract one
        QueueTripRelay(channelNo - 1)
    End Sub
    Public Sub ScriptDelay(ByVal milliseconds As UInteger) Implements RelayInterface.IRelayHost.Delay
        QueueDelay(0, milliseconds)
    End Sub
#End Region

    Private Sub setting_ShowRelayCommandToExecute(ByVal cmd As RelayCommand) Handles setting.ShowRelayCommandToExecute
        RaiseEvent ShowRelayCommandToExecute(cmd)
    End Sub

    Public ReadOnly Property ConnectionInfo As String Implements IConnectionInfo.ConnectionInfo
        Get
            Return String.Format("{0}, {1}, Relay", _parent.PortName, _parent.Baud)
        End Get
    End Property
End Class
