Imports System.IO.Ports
Imports System.Threading
Imports System.IO
Imports System.Xml.Serialization
Imports System.CodeDom.Compiler
Imports com.loadstar.utility.Utility
Imports com.loadstar.utility
Imports System.Text.RegularExpressions
Imports NCD
Public Class NcdRelayBox
    Inherits LsComSensor
    'Trip means ON, reset means OFF
    Protected _portName As String
    Protected _baudRate As UInteger
    Private _relayChannels As New List(Of RelayChannel)
    Public Event RelayFailure()
    Public Event RelayIsTripped(ByVal relayIndex As UShort)
    Public Event RelayIsReset(ByVal relayIndex As UShort)
    Private Shared _xmlFile As String = _gConfigFolder & "\relay.xml"
    Private _relayLock As New Object
    Private _ncd As New NCDComponent
    Public Sub New(ByVal comPort As String, ByVal baudrate As UInteger)
        MyBase.New(comPort, baudrate)
        _ncd.UsingComPort = True
        _ncd.BaudRate = 115200
        Try
            _ncd.OpenPort()
            _ncd.ProXR.RelayBanks.SelectBank(1)
            Dim status = _ncd.ProXR.RelayBanks.GetStatus(0).ToString()
            If (status = "OFF" OrElse status = "ON") Then
                'this is an ncd relay
            Else
                Throw New Exception()
            End If
            _ncd.ClosePort()
        Catch ex As Exception
            MsgBox("Unable to detect/open relay port:" + comPort)
            _ncd = Nothing
        End Try
        Dim n = ConfigXml.Instance.MAX_RELAY_CHANNELS
        For i = 0 To ConfigXml.Instance.MAX_RELAY_CHANNELS - 1
            _relayChannels.Add(New RelayChannel(Me, i))
            _relayChannels.Last.SS1 = "Relay Channel " & (i + 1)
        Next
        'load previous relay settings if any
        Try
            ReadRelaySettingsFromXmlFile()
        Catch ex As Exception
            MsgBox("Error reading relay settings. Please reconfigure relays.")
        End Try
    End Sub


    Public Function IsRelayTripped(ByVal relayIndex As UShort) As Boolean
        'relayIndex starts from 0

        Try
            _ncd.OpenPort()
            _ncd.ProXR.RelayBanks.SelectBank(1)
            Dim status = _ncd.ProXR.RelayBanks.GetStatus(relayIndex).ToString()
            IsRelayTripped = status = "ON"
            _ncd.ClosePort()
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Sub ResetAllRelays()
        'relayIndex starts from 0
        Debug.Print("reset all:")
        Try
            SyncLock _relayLock
                _ncd.OpenPort()
                If _ncd.IsOpen() Then
                    _ncd.ProXR.RelayBanks.TurnOffAllRelays()
                    _ncd.ClosePort()
                    For i = 0 To _relayChannels.Count - 1
                        RaiseEvent RelayIsReset(i)
                    Next
                End If
            End SyncLock
        Catch ex As Exception
            RaiseEvent RelayFailure()
        Finally
        End Try
    End Sub
    Public Sub TripRelay(ByVal relayIndex As UShort)
        'relayIndex starts from 0
        Debug.Print("trip:" & relayIndex)
        Try
            SyncLock _relayLock
                _ncd.OpenPort()
                If _ncd.IsOpen() Then
                    _ncd.ProXR.RelayBanks.TurnOnRelay(relayIndex)
                    _ncd.ClosePort()
                    RaiseEvent RelayIsTripped(relayIndex)
                End If
            End SyncLock
        Catch ex As Exception
            RaiseEvent RelayFailure()
        Finally
        End Try
    End Sub
    Public Sub ResetRelay(ByVal relayIndex As UShort)
        'relayIndex starts from 0
        Debug.Print("reset:" & relayIndex)
        Try
            SyncLock _relayLock
                _ncd.OpenPort()
                If _ncd.IsOpen() Then
                    _ncd.ProXR.RelayBanks.TurnOffRelay(relayIndex)
                    _ncd.ClosePort()
                    RaiseEvent RelayIsReset(relayIndex)
                End If
            End SyncLock
        Catch ex As Exception
            RaiseEvent RelayFailure()
        Finally
        End Try
    End Sub


    Public ReadOnly Property Relay(ByVal index As Integer) As RelayChannel
        Get
            Return _relayChannels(index)
        End Get
    End Property
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Public Function ReadRelaySettingsFromXmlFile() As Boolean

        If My.Computer.FileSystem.FileExists(_xmlFile) Then
            Try
                Using sr As New StreamReader(_xmlFile)
                    Dim settingsCollection As New List(Of RelaySetting)

                    Dim x As New XmlSerializer(settingsCollection.GetType)
                    settingsCollection = x.Deserialize(sr)
                    For i = 0 To ConfigXml.Instance.MAX_RELAY_CHANNELS - 1
                        Dim setting As RelaySetting = settingsCollection(i)
                        _relayChannels(i).setting = setting
                        _relayChannels(i).Parent = Me
                        If setting.controlType = RelaySetting.Enum_Relay_Control_Type.script Then
                            Dim errScript As Boolean = True
                            If My.Computer.FileSystem.FileExists(setting.scriptFileName) Then
                                Dim results = RelayScripting.VerifyScriptFile(setting.scriptFileName)
                                If results.Errors.Count = 0 Then
                                    errScript = False
                                    setting.compiledScript = DirectCast(RelayScripting.FindInterface(results.CompiledAssembly, "IRelayScript"), RelayInterface.IRelayScript)
                                End If
                            End If
                            If errScript Then
                                setting.controlType = RelaySetting.Enum_Relay_Control_Type.manual
                                ShowErrorMessage("Error in script file: " & setting.scriptFileName)
                            End If
                        End If
                    Next
                    Return True

                End Using
            Catch ex As Exception
            Finally
            End Try
        End If
        Return False
    End Function
    Public Sub WriteRelaySettingsToFile()
        Dim settingsCollection As New List(Of RelaySetting)
        For i = 0 To ConfigXml.Instance.MAX_RELAY_CHANNELS - 1
            settingsCollection.Add(_relayChannels(i).setting)
        Next

        Using sw = New StreamWriter(_xmlFile)
            Dim st As New XmlSerializer(settingsCollection.GetType)
            st.Serialize(sw, settingsCollection)
        End Using
    End Sub
    Public Sub Cleanup()
        'if a sensor does not exist, then we disable this relay
        For i = 0 To ConfigXml.Instance.MAX_RELAY_CHANNELS - 1
            Dim oldSS1 As String = _relayChannels(i).setting.controllingSs1
            If oldSS1.Length <> 0 Then
                Dim sensorExists = (From s In _gAttachedSensors Where s.SS1 = oldSS1 Select s.SS1).Any
                If Not sensorExists Then
                    _relayChannels(i).setting.controlType = RelaySetting.Enum_Relay_Control_Type.manual
                    _relayChannels(i).setting.controllingSs1 = String.Empty
                End If
            End If
        Next
    End Sub

    Private Function GetStatus() As Tuple(Of Boolean, Boolean)
        _ncd.OpenPort()
        If _ncd.IsOpen() Then
            Dim status0 = _ncd.ProXR.RelayBanks.GetStatus(0).ToString()
            Dim status1 = _ncd.ProXR.RelayBanks.GetStatus(1).ToString()
            Return New Tuple(Of Boolean, Boolean)(status0 = "ON", status1 = "ON")
            _ncd.ClosePort()
        End If
        Return New Tuple(Of Boolean, Boolean)(Nothing, Nothing)
    End Function
    Public Overrides Sub StartReading()
    End Sub
    Public Overrides Sub StopReading()
    End Sub

    Public Overrides Sub Tare()
    End Sub
    Protected Overrides Sub PortDataReceived(ByVal buffer As String)
    End Sub
End Class
