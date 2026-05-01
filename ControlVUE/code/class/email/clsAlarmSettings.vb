Imports System.IO
Public Class clsAlarmSettings
    Private _sendEmail As Boolean = False
    Private _sendSMS As Boolean = False
    Private _phone As String = String.Empty
    Private _email As String = String.Empty
    Private _smsCarrier As String = String.Empty
    Private _sendIntervalHrs As UInteger = 24
    Private _startTime As Date = Now()
    Private _iniFile As LvIniFile
    Public Property SendEmail() As Boolean
        Get
            Return _iniFile.GetBoolean("SendEmail", False)
        End Get
        Set(ByVal value As Boolean)
            _iniFile.WriteBoolean("SendEmail", value)
        End Set
    End Property
    Public Property SendSMS() As Boolean
        Get
            Return _iniFile.GetBoolean("SendSMS", False)
        End Get
        Set(ByVal value As Boolean)
            _iniFile.WriteBoolean("SendSMS", value)
        End Set
    End Property
    Public Property Phone() As String
        Get
            Return _iniFile.GetString("Phone", String.Empty)
        End Get
        Set(ByVal value As String)
            _iniFile.WriteString("Phone", value)
        End Set
    End Property
    Public Property Email() As String
        Get
            Return _iniFile.GetString("EMail", String.Empty)
        End Get
        Set(ByVal value As String)
            _iniFile.WriteString("EMail", value)
        End Set
    End Property
    Public Property SMSCarrier() As String
        Get
            Return _iniFile.GetString("SMSCarrier", String.Empty)
        End Get
        Set(ByVal value As String)
            _iniFile.WriteString("SMSCarrier", value)
        End Set
    End Property
    Public Property SendIntervalHrs() As UShort
        Get
            Return _iniFile.GetString("SendIntervalHrs", 24)
        End Get
        Set(ByVal value As UShort)
            _iniFile.WriteString("SendIntervalHrs", value)
        End Set
    End Property
    Public Property StartTime() As Date
        Get
            Dim buffer As String = _iniFile.GetString("StartTime", String.Empty)
            If IsDate(buffer) Then
                Return CDate(buffer)
            Else
                Return Now()
            End If
        End Get
        Set(ByVal value As Date)
            _iniFile.WriteString("StartTime", value)
        End Set
    End Property
    Public Property LastSentTime() As Date
        Get
            Dim buffer As String = _iniFile.GetString("LastSentTime", String.Empty)
            If IsDate(buffer) Then
                Return CDate(buffer)
            Else
                Return DateTime.MinValue
            End If
        End Get
        Private Set(ByVal value As Date)
            _iniFile.WriteString("LastSentTime", value)
        End Set
    End Property
    Public Shared ReadOnly Property GetSMSCarriers() As List(Of String)
        Get
            Dim lstCarr As New List(Of String)
            Dim inifile As New LvIniFile(My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "data\sms-carriers.ini"))
            inifile.Section = "SMSCarriers"
            For Each carrier As String In inifile.GetAllKeys("")
                lstCarr.Add(carrier)
            Next
            Return lstCarr
        End Get
    End Property
    Public Sub New()
        _iniFile = New LvIniFile()
        _iniFile.Section = "EmailOptions"
    End Sub
    Public Function SendPendingEmails(ByVal subject As String, ByVal body As String) As Boolean
        Dim emailSent As Boolean = False, smsSent As Boolean = False
        Dim msg As String = String.Empty
        If IsEmailPending() Then
            Debug.Print("Sending email now" + Now().ToString)
            Try
                ShowHourglass()
                If Not My.Computer.Network.IsAvailable Then
                    msg = "Internet Connection not available"
                    AppendToEmailLog(msg)
                    Throw New Exception(msg)
                ElseIf My.Computer.Network.Ping("loadstarsensors.com") = False Then
                    AppendToEmailLog(msg)
                    Throw New Exception(msg)
                End If
                If Me.SendEmail = True Then
                    Try
                        If clsSendMail.SendMail(Me.Email, String.Empty, subject, body, False) = True Then
                            Me.LastSentTime = Now()
                            emailSent = True
                            AppendToEmailLog("Email sent at")
                        End If
                    Catch ex As Exception
                        AppendToEmailLog(ex.Message)
                    End Try
                End If
                If Me.SendSMS = True Then
                    Dim inifile As New LvIniFile(My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "data\sms-carriers.ini"))
                    inifile.Section = "SMSCarriers"
                    Dim carr As String = Me.SMSCarrier
                    Dim smsEmail As String = inifile.GetString(carr, String.Empty)
                    If smsEmail.Length <> 0 Then
                        Try
                            If clsSendMail.SendMail(Me.Phone + "@" + smsEmail, String.Empty, subject, body, False) = True Then
                                Me.LastSentTime = Now()
                                smsSent = True
                                AppendToEmailLog("SMS sent at")
                            End If
                        Catch ex As Exception
                            AppendToEmailLog(ex.Message)
                        End Try
                    End If
                End If
                Return (emailSent OrElse smsSent)
            Catch ex As Exception
                AppendToEmailLog(ex.Message)
                Return False
            Finally
                ReleaseHourglass()
            End Try
        End If
    End Function
    Private Function IsEmailPending() As Boolean

        Dim intervalHrs As UShort = Me.SendIntervalHrs

        Dim tn As Date = Now()
        Dim n As UInteger = 0
        Dim stTime As Date = Me.StartTime
        Dim tmpTime As Date
        Debug.Print("Start time " & Me.StartTime.ToString())
        Do

            tmpTime = stTime + New TimeSpan(intervalHrs * n, 0, 0)
            Debug.Print(String.Format("Band start: {0} Now: {1}", tmpTime, tn))
            If tn >= tmpTime AndAlso tn < tmpTime + New TimeSpan(0, 1, 0) Then
                'we are in a one minute band of interval to send the email
                Return True
            ElseIf tmpTime > tn Then
                'we are in the middle of a time interval
                Return False
            End If
            n += 1
        Loop
        Return False
    End Function
    Public Shared ReadOnly Property EmailLogFile() As String
        Get
            Return My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData, "loadvue-alerts-log.txt")
        End Get
    End Property
    Private Sub AppendToEmailLog(ByVal msg As String)
        Using sw As New StreamWriter(clsAlarmSettings.EmailLogFile, True)
            sw.WriteLine(DateTime.Now.ToString(clsGlobals.emailTimeFormat) & " ==> " & msg)
        End Using
    End Sub
End Class
