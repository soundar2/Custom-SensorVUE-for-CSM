Imports System.ComponentModel
Imports System.Threading
Public Class Alarm
    Private WithEvents _sensor As LsSensor
    Public Class AlarmSetting
        Public enabled As Boolean = True
        Public name As String = "Alarm"
        Public ss1 As String = String.Empty
        Public highLimit As Double = 100
        Public lowLimit As Double = 0
        Public monitorHigh As Boolean = True
        Public monitorLow As Boolean = False
        Public enableSound As Boolean = True
        Public sendSms As Boolean = False
        Public sendEmail As Boolean = False
        Public sendIntervalMinutes As UInteger = 1
    End Class
    Private _myLockIndex As Integer
    Private Shared _alarmFile As String
    Private _alarmOn As Boolean = False
    Private WithEvents _bgworker As New BackgroundWorker
    Private _emailSent As Boolean = False
    Private _smsSent As Boolean = False
    Private Shared _audioLockedBy As Alarm
    Private _thisAlarmEnabled As Boolean = False
    Public alarmSaved As Boolean = False
    Private Sub _sensor_SensorDataReceived(ByVal seqNo As UShort) Handles _sensor.SensorDataReceived
        Dim d As Double = _sensor.CurrentReading
        With _setting
            If _thisAlarmEnabled AndAlso ((.monitorHigh And d > .highLimit) OrElse (.monitorLow And d < .lowLimit)) Then
                _alarmOn = True
            Else
                _alarmOn = False
            End If
        End With
    End Sub
    Public Sub StartMonitoring()
        With Setting
            _thisAlarmEnabled = .enabled AndAlso (.enableSound OrElse .sendEmail OrElse .sendSms)
        End With
        _emailSent = False
        _smsSent = False
        _alarmFile = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "data\alarms\" & ConfigXml.Instance.AlarmFile)
        If Not My.Computer.FileSystem.FileExists(_alarmFile) Then
            _alarmFile = String.Empty
        End If
        If _thisAlarmEnabled Then
            _bgworker.RunWorkerAsync()
        End If
    End Sub
    Public Sub StopMonitoring()
        _alarmOn = False
        _bgworker.CancelAsync()
        Thread.Sleep(100)
        If _audioLockedBy Is Me Then
            _audioLockedBy = Nothing
        End If
        My.Computer.Audio.Stop()
    End Sub


    Private _setting As AlarmSetting
    Public Property Setting() As AlarmSetting
        Get
            Return _setting
        End Get
        Set(ByVal value As AlarmSetting)
            _setting = value
            If value.enabled Then
                _sensor = (From item In _gAttachedSensors Where item.SS1 = value.ss1).Single
            End If
        End Set
    End Property
    Private Sub StartAudio()

    End Sub
    Private Sub StopAudio()

    End Sub

    Public Sub New()
        _setting = New AlarmSetting
        _bgworker = New BackgroundWorker
        _bgworker.WorkerSupportsCancellation = True
    End Sub

    Private Sub _bgworker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _bgworker.DoWork
        Do
            If _setting.enableSound Then
                If _alarmOn Then
                    'we have to start the audio
                    'unless some other alarm has started it first

                    If _audioLockedBy Is Nothing Then
                        'if audiolock *is not* nothing then
                        'either I am already playing it or
                        'or someone else is sounding the alarm
                        'grab the lock only if it is free
                        _audioLockedBy = Me
                        If _alarmFile.Length = 0 Then
                            My.Computer.Audio.Play(My.Resources.alarm, AudioPlayMode.BackgroundLoop)
                        Else
                            My.Computer.Audio.Play(_alarmFile, AudioPlayMode.BackgroundLoop)
                        End If
                    End If
                Else
                    If _audioLockedBy Is Me Then
                        'I am already playing, stop
                        My.Computer.Audio.Stop()
                        _audioLockedBy = Nothing
                    End If
                End If
            End If
            SendEmailSMS()
            System.Threading.Thread.Sleep(1000)
        Loop Until _bgworker.CancellationPending
    End Sub
    Private Sub SendEmailSMS()
        If Not _alarmOn Then Return
        If Not (_setting.sendEmail Or _setting.sendSms) Then Return
        If _setting.sendEmail AndAlso _emailSent Then Return
        If _setting.sendSms AndAlso _smsSent Then Return

        If Not My.Computer.Network.IsAvailable Then Return
        Try
            If My.Computer.Network.Ping("loadstarsensors.com") = False Then Return
        Catch ex As Exception
            'internet not available
            Return
        End Try

        Dim subject, body As String
        subject = "Alert from " & My.Application.Info.ProductName
        body = String.Format("Time: {0}{1}Reading from Sensor {2}: {3} {4} Exceeds alarm thresholds.", Now().ToString, vbCrLf, _sensor.SS1, _sensor.CurrentReading.ToString("0.00"), _sensor.Units.OutputUnits)
        If _setting.sendEmail AndAlso Not _emailSent Then
            clsSendMail.SendMail(ConfigXml.Instance.emailAddress, String.Empty, "Email " & subject, body)
            _emailSent = True
        End If
        If _setting.sendSms AndAlso Not _smsSent Then
            Dim inifile As New LvIniFile(My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "data\sms-carriers.ini"))
            inifile.Section = "SMSCarriers"
            Dim carr As String = ConfigXml.Instance.smsCarrier
            Dim smsEmail As String = inifile.GetString(carr, String.Empty)
            If smsEmail.Length <> 0 Then
                clsSendMail.SendMail(ConfigXml.Instance.smsPhone + "@" + smsEmail, String.Empty, "SMS " & subject, body, False)
            End If
            _smsSent = True
        End If
    End Sub
End Class
