Imports System.Xml.Serialization
Imports System.IO
Public Class ConfigXml
    Public Enum Enum_LogRate
        ondemand = 0
        slowTimed = 1
        fastTimed = 2
        continuous = 3
    End Enum
    Private Shared _instance As ConfigXml
    '
    'cool muscle
    Public motorSpeed As Integer = 10
    Public motorAccel As Integer = 10

    'general options
    Public confirmTare As Boolean = False
    Public readingsToAverage As UShort = 1

    'logging
    Public logRate As Enum_LogRate = Enum_LogRate.slowTimed
    Public doNotLogToScreen As Boolean = False
    Public runningTareEnabled As Boolean = False
    Public logIntervalMSec As ULong = 1000
    Public graphLoggedReadingsOnly As Boolean = False
    Public logUdf As Boolean
    Public udfFieldName As String = "<User defined field>"
    Public loggingControlSs1 As String = String.Empty
    Public uploadToCloud As Boolean = False
    '
    'motor looping
    '
    Public enableLooping As Boolean = False
    Public loopUntilStopped As Boolean = True
    Public loopTimes As UInteger = 10
    Public loopFrom As Integer = -60
    Public loopTo As Integer = 60
    'alarms
    '
    'email/sms
    '
    Public emailAddress As String = String.Empty
    Public smsPhone As String = String.Empty
    Public smsCarrier As String = String.Empty
    '
    Public graphBlackBackground As Boolean = False
    '
    'selected sensors on the opening screen
    '
    '
    Public selectedSensors As New List(Of String)
    '
    'wordpad toolbars
    '
    Public showStandardToolbar As Boolean = False
    Public showFormattingToolbar As Boolean = False
    Public showStatusbar As Boolean = False
    Public isPreviewMode As Boolean = False
    Public textZoomFactor As Integer = 100
    '
    'sizing text for LV-100 popout window
    '
    Public totalSizingText As String = "-99999"
    Public peakLowSizingText As String = "-99999"
    '
    'LV-100 options
    '
    Public lv100sDisplayFormat As String = "0.00"
    Public forceOutputUnits As String = "lbf"
    Public lengthOutputUnits As String = "in"
    Public torqueOutputUnits As String = "lbf-ft"
    Public voltageOutputUnits As String = "V"
    Public pressureOutputUnits As String = "psi"
    Public temperatureOutputUnits As String = "C"
    Public motorOutputUnits As String = "deg"

    '
    Public selectedConnectionType As String = "wired"
    '
    Public myPriorityClass As System.Diagnostics.ProcessPriorityClass = ProcessPriorityClass.Normal
    '
    'wifi related
    '
    Public wifiOutputIntervalMSec As UInt16 = 1000
    '
    '
    Public baudRateOrderArray() As UInteger = {9600, 230400, 115200}
    Public gateWayIpAddress As String = "192.168.1.1"
    '
    'range ipaddresses to ping and detect
    '
    Public startSuffix As Integer = 2
    Public stopSuffix As Integer = 253
    '
    'punchForce sensor
    '
    Public punchForceSensorSs1 As String = String.Empty
    Public punchThresholdLb As Integer = 2
    Public punchIntervalMSec As UShort = 100
    Public punchTimerEnableAutoStop As Boolean = True
    Public punchTimerAutostopMin As UShort = 1
    Public punchTimerAutostopSec As UShort = 0
    Public startTimerAfterFirstPunch As Boolean = False
    '
    'see email track from Div, he wants 250000 points
    'on 2018/3/1 Div wanted 1,000,000 points
    'changed it back to 250000 as it became too slow even for 250000 points
    '
    '
    Public graphCumulativeTruncateNPoint As UInteger = 250000
    Public graphScrollingTruncateNPoint As UInteger = 20000
    Public graphLimitNoOfPointsReachedShowWarning As Boolean = True
    Public minSamplesForAutoScale As UInteger = 4
    '
    'filter sensors
    '
    <XmlIgnore> Public maxFilterWindowSize As Integer = 50000
    '
    'wait timeout for taring for DQ-4000
    '
    Public dq4000TareWaitSec As Integer = 1
    '

    '
    'cloud upload credentials
    '
    Public cloudValidateUrl As String = "http://www.loadstarsensors.com/sensorvue-cloud/api/login"
    Public cloudUploadUrl As String = "http://www.loadstarsensors.com/sensorvue-cloud/api/upload"
    Public cloudBrowserUrl As String = "http://www.loadstarsensors.com/sensorvue-cloud"
    '

    '
    Public sensorDisconnectionCheckIntervalSec As Integer = 10

    Private Shared _xmlFile As String = _gConfigFolder & "\config.xml"
    <XmlIgnore()> Public Shared ResetWindowLocations As Boolean = False
    <XmlIgnore()> Public Shared RestartApplication As Boolean = False
    <XmlIgnore> Public MAX_RELAY_CHANNELS As Integer = 2

    Private Sub New()
    End Sub
    Public Shared Function Instance() As ConfigXml
        If _instance Is Nothing Then
            _instance = New ConfigXml
        End If
        Return _instance
    End Function
    Public Sub ReadConfiguration()
        If My.Computer.FileSystem.FileExists(_xmlFile) Then
            Try
                Using sr As New StreamReader(_xmlFile)
                    Dim x As New XmlSerializer(_instance.GetType)
                    _instance = x.Deserialize(sr)
                End Using
            Catch ex As Exception
            Finally
            End Try
        End If
    End Sub
    Public Sub WriteConfiguration()
        Using sw = New StreamWriter(_xmlFile)
            Dim st As New XmlSerializer(_instance.GetType)
            st.Serialize(sw, _instance)
        End Using
    End Sub

    Private _lstSensorsToLog As New List(Of String)
    Public Property SensorsToLog() As List(Of String)
        Get
            Return _lstSensorsToLog
        End Get
        Set(ByVal value As List(Of String))
            _lstSensorsToLog = value
        End Set
    End Property
    Private _lstSensorsToPopup As New List(Of String)
    Public Property SensorsToPopup() As List(Of String)
        Get
            Return _lstSensorsToPopup
        End Get
        Set(ByVal value As List(Of String))
            _lstSensorsToPopup = value
        End Set
    End Property
    Private _alarmFile As String = String.Empty
    Public Property AlarmFile() As String
        Get
            Return _alarmFile
        End Get
        Set(ByVal value As String)
            _alarmFile = value
        End Set
    End Property
    Private _useScientificFormatInLogFiles As Boolean = False
    Public Property UseScientificFormatInLogFiles() As Boolean
        Get
            Return _useScientificFormatInLogFiles
        End Get
        Set(ByVal value As Boolean)
            _useScientificFormatInLogFiles = value
        End Set
    End Property
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private _lstWifiSensorIpAddress As New List(Of String)
    Public Property WifiSensorIpAddressList() As List(Of String)
        Get
            Return _lstWifiSensorIpAddress
        End Get
        Set(ByVal value As List(Of String))
            _lstWifiSensorIpAddress = value
        End Set
    End Property
    Private _lstStartupParam As New List(Of String)
    Public ReadOnly Property StartupParamList() As List(Of String)
        'each item could have 2 or more words/phrases delimited by '|' character
        'for example ID DI-1234|LC 2000|GAIN 64...'
        Get
            Return _lstStartupParam
        End Get
    End Property
    Private _dockPanelRenderMode As Integer = 3
    Public Property DockPanelRenderMode() As UShort
        Get
            Return _dockPanelRenderMode
        End Get
        Set(ByVal value As UShort)
            If value < 0 Or value > 6 Then
                value = 3
            End If
            _dockPanelRenderMode = value
        End Set
    End Property
    Public uploadEmail As String
    Public encUploadPassword As String 'sshould be private but then we can't save it
    <XmlIgnore()> Public Property uploadPassword() As String
        'encrypt and save, decrypt and retrieve
        Get
            If (encUploadPassword & "").Length = 0 OrElse (uploadEmail & "").Length = 0 Then Return String.Empty
            Dim crypt As New Simple3Des(Me.uploadEmail.Reverse.ToString)
            Return crypt.DecryptData(encUploadPassword)
        End Get
        Set(ByVal value As String)
            If value.Length = 0 OrElse (uploadEmail & "").Length = 0 Then Return
            Dim crypt As New Simple3Des(Me.uploadEmail.Reverse.ToString)
            encUploadPassword = crypt.EncryptData(value)
        End Set
    End Property


End Class
