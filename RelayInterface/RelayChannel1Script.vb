'The following class is required by ControlVUE to
'control the relays from a VB.NET script file
'Modify only the following procedure bodies
'As required by your relay control conditions
'
' StartMonitoring,
' StopMonitoring, and
' SensorDataReceived
'Comment lines are started with a single quote (')
'
'use the following calls to trip/reset relays
'
'
'       _host.Trip(channelNo)
'       _host.Reset(channelNo)
'Use
'       _host.Delay(1000)
'to suspend the execution for 1 sec. The parameter is in milliseconds
'


Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Threading
Imports RelayInterface
Imports Microsoft.VisualBasic

Public Class RelayChannel1Script
    Implements RelayInterface.IRelayScript


    Private _host As RelayInterface.IRelayHost
    Public zone As Integer = 0

	'
	'NOTE: The following procedure is required by the ControVUE
    'Do not modify the procedure
    '
    Public Sub Initialize(ByVal host As IRelayHost) Implements IRelayScript.Initialize
        _host = host
    End Sub


	'
	'NOTE: The following procedure is required by the ControVUE
    'Do not modify the procedure signature
    'Modify only the procedure body
    'The StartMonitoring procedure is called when the Start button is clicked
    '
    Public Sub StartMonitoring() Implements IRelayScript.StartMonitoring
    	zone=-1
    	_host.ResetRelay(1)
    	_host.ResetRelay(2)
    	zone=0
    End Sub

	'
	'NOTE: The following procedure is required by the ControVUE
    'Do not modify the procedure signature
    'Modify only the procedure body
    'The StopMonitoring procedure is called when the Stop button is clicked
    '
    Public Sub StopMonitoring() Implements IRelayScript.StopMonitoring

    End Sub
	'
	'NOTE: The following procedure is required by the ControVUE
    'Do not modify the procedure signature
    'Modify only the procedure body
    'This procedure is called periodically by ControlVUE and
    'the reading from the selected sensor is passed as 'data'
    '
    Public Sub SensorDataReceived(ByVal data As Double) Implements IRelayScript.SensorDataReceived

		'add your code below this line
        Select Case zone
            'you are in zone 0
            'hopper is empty. need to start loading
            'everything is reset
            Case 0
                If data > 0.9 Then
                    '
                    'trip relay-1 and start the feeder
                    'at high speed, go to zone 1
                    _host.TripRelay(1)
                    zone = 1
                End If
            Case 1
                'in zone 1
                'check if weight is above 25 lb
                'reset relay 1, and trip relay 2
                'feeder at dribble
                If (data > 1.9) Then
                zone = 2
                End If
            Case 2
                'in zone2
                'check if weight is above 30 lb
                'shut off feeder
                'reset relay-2, start emptying hopper
                'trip relay-3 after delay of 2 sec
                _host.Delay(2000)
                _host.ResetRelay(1)
                _host.Delay(2000)
                _host.TripRelay(2)
                zone = 3
            Case 3
                'in zone 3
                'when weight is back to 0 reset relay 3
                'since weight may not be exactly 0
                'for ex, it may be 0.05
                'check if weight is < 0.1 and then weight
                'some more
                If (data < 0.1) Then
                    _host.Delay(2000)
                    _host.ResetRelay(2)
                    _host.Delay(2000)
                    zone = 0
                End If
        End Select
    End Sub


End Class
