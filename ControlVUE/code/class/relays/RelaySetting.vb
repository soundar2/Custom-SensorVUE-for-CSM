Imports System.Xml.Serialization
Imports System.CodeDom.Compiler
Public Class RelaySetting
    Public Enum Enum_Relay_Action
        invalid = 0
        waitfor = 1
        trip = 2
        reset = 3
        delay = 4
        hold = 5
    End Enum
    Public Enum Enum_Relay_Control_Type
        invalid = 0
        manual = 1
        simple = 2
        script = 3
        commands = 4
    End Enum
    Public Enum Enum_GtLtCondition
        invalid = 0
        GT = 1
        LT = 2
    End Enum
    '<XmlIgnore()> Private _trippedOnce As Boolean = False
    Public relayIndex As Short = 0
    Public relayName As String = String.Empty
    '
    'simple settings
    '
    Public L1 As Double = 0
    Public L2 As Double = 0
    Public action1 As Enum_Relay_Action = Enum_Relay_Action.hold
    Public action12 As Enum_Relay_Action = Enum_Relay_Action.hold
    Public action2 As Enum_Relay_Action = Enum_Relay_Action.hold
    Public action1Delay As UInt32 = 0
    Public action12Delay As UInt32 = 0
    Public action2Delay As UInt32 = 0
    Public autoReset As Boolean = False
    Public controllingSs1 As String = String.Empty
    '
    'using script file
    '
    Public controlType As Enum_Relay_Control_Type = Enum_Relay_Control_Type.manual
    Public scriptFileName As String = String.Empty
    <XmlIgnore()> Public compiledScript As RelayInterface.IRelayScript = Nothing
    '
    '
    'using command sequences
    '
    Public lstCommands As List(Of RelayCommand) = Nothing
    <XmlIgnore()> Public _currentCommandIndex As Short = -1
    <XmlIgnore()> Private _currentCommandActionTaken As Boolean = False
    Event ShowRelayCommandToExecute(ByVal cmd As RelayCommand)
    <XmlIgnore()> Public delayExecuting As Boolean = False
    <XmlIgnore()> Private _holdCurrentCommand As Boolean = False
    Public Function MonitorRelay(ByVal reading As Double) As RelayCommand
        If delayExecuting Then
            'do not monitor
            _holdCurrentCommand = True
            Return Nothing
        Else
            If _holdCurrentCommand Then
                _holdCurrentCommand = False
                Dim cmd As RelayCommand = lstCommands(_currentCommandIndex).ShallowCopy
                cmd.targetChannelIndex = relayIndex
                ShowCommandToExecute(_currentCommandIndex)
            End If
        End If
        Select Case Me.controlType
            Case Enum_Relay_Control_Type.simple
                If reading <= L1 Then
                    Return New RelayCommand(relayIndex, action1, Enum_GtLtCondition.invalid, 0, 0)
                ElseIf reading <= L2 AndAlso L1 <> L2 Then
                    Return New RelayCommand(relayIndex, action12, Enum_GtLtCondition.invalid, 0, 0)
                Else
                    'reading > l2
                    Return New RelayCommand(relayIndex, action2, Enum_GtLtCondition.invalid, 0, 0)
                End If
            Case Enum_Relay_Control_Type.commands
                Dim cmd As RelayCommand = lstCommands(_currentCommandIndex).ShallowCopy
                Select Case cmd.action
                    Case Enum_Relay_Action.waitfor
                        If (cmd.condition = Enum_GtLtCondition.GT _
                            AndAlso reading > cmd.targetValue) _
                            OrElse (cmd.condition = Enum_GtLtCondition.LT _
                                    AndAlso reading < cmd.targetValue) Then
                            'condition satisfied
                            'jump to next zone
                            'no action need to be taken
                            'Debug.Print(relayIndex & " *** " & _currentCommandIndex)
                            _currentCommandIndex += 1
                            If _currentCommandIndex = lstCommands.Count Then
                                _currentCommandIndex = 0
                            End If
                            ShowCommandToExecute(_currentCommandIndex)
                            Return Nothing 'no relay action to do for waitfor
                        End If
                    Case Enum_Relay_Action.trip, Enum_Relay_Action.reset
                        'either trip or reset and jump to next zone
                        Debug.Print(relayIndex & " *** " & _currentCommandIndex)
                        _currentCommandIndex += 1
                        If _currentCommandIndex = lstCommands.Count Then
                            _currentCommandIndex = 0
                        End If
                        ShowCommandToExecute(_currentCommandIndex)
                        cmd.targetChannelIndex = relayIndex
                        Return cmd
                    Case Enum_Relay_Action.delay
                        Debug.Print(relayIndex & " *** " & _currentCommandIndex)
                        _currentCommandIndex += 1
                        If _currentCommandIndex = lstCommands.Count Then
                            _currentCommandIndex = 0
                        End If
                        'do not show the next command to execute here
                        'till the delay has expired
                        cmd.targetChannelIndex = relayIndex
                        delayExecuting = True
                        Return cmd 'this will execute a delay
                End Select 'action type
        End Select 'command type
        Return Nothing
    End Function
    Public Sub MonitorRelayWithScript(ByVal reading As Double)
        'does not return anything
        'because script calls the trip/relay functions
        compiledScript.SensorDataReceived(reading)
    End Sub

    Public Sub New(ByVal myIndex As Short)
        If myIndex >= 0 AndAlso myIndex < ConfigXml.Instance.MAX_RELAY_CHANNELS Then
            relayIndex = myIndex
        End If
    End Sub
    Public Sub New()
        relayIndex = -1  'will be called by xmlsave
    End Sub
    Public Sub StartMonitoring()
        _currentCommandIndex = 0
        If Me.controlType = Enum_Relay_Control_Type.commands Then
            ShowCommandToExecute(_currentCommandIndex)
        End If
    End Sub
    Private Sub ShowCommandToExecute(ByVal cmdIndex As Integer)
        Dim cmd As RelayCommand = lstCommands(cmdIndex).ShallowCopy
        cmd.targetChannelIndex = relayIndex
        RaiseEvent ShowRelayCommandToExecute(cmd)
    End Sub
End Class
