Option Compare Text

Imports com.loadstar.utility.Utility
Imports com.loadstar.utility
Public Class ctlAlarm
    Event NameChanged(ByVal name As String)
    Public Function IsOkToSave() As Boolean
        If (chkHighAlarm.Checked AndAlso txtHighAlarm.Text.Trim.Length = 0) Then
            FlashControl(txtHighAlarm)
            Return False
        ElseIf (chkLowAlarm.Checked AndAlso txtLowAlarm.Text.Trim.Length = 0) Then
            FlashControl(txtLowAlarm)
            Return False
        ElseIf Not (chkHighAlarm.Checked OrElse chkLowAlarm.Checked) Then
            ShowErrorMessage("Invalid high and/or low alarm setting.")
            Return False
        ElseIf txtName.Text.Trim.Length = 0 Then
            FlashControl(txtName)
            Return False
        Else
            Return True
        End If
    End Function
    Public ReadOnly Property AlarmFile() As String
        Get
            If cmbAlarmSound.Text.Contains("Default") Then
                Return "default.wav"
            Else
                Return cmbAlarmSound.Text
            End If

        End Get
    End Property

    Public Sub ClearAlarmSettings()
        txtName.Text = String.Empty
        txtHighAlarm.Text = String.Empty
        txtLowAlarm.Text = String.Empty
        chkHighAlarm.Checked = False
        chkLowAlarm.Checked = False
        cmbSensor.SelectedIndex = 0
        chkSms.Checked = False
        chkEmail.Checked = False
        chkSound.Checked = False
    End Sub
    Public Sub LoadAlarmSettings(ByVal al As Alarm)
        ClearAlarmSettings()
        With al.Setting
            .enabled = True
            txtName.Text = .name
            txtHighAlarm.Text = .highLimit.ToString()
            txtLowAlarm.Text = .lowLimit.ToString()
            chkHighAlarm.Checked = .monitorHigh
            chkLowAlarm.Checked = .monitorLow
            cmbSensor.Text = .ss1
            chkSms.Checked = .enabled AndAlso .sendSms
            chkEmail.Checked = .enabled AndAlso .sendEmail
            chkSound.Checked = .enabled AndAlso .enableSound
        End With
    End Sub
    Public Sub SaveAlarmSettings(ByVal al As Alarm)
        Hourglass.Show()
        With al.Setting
            .name = txtName.Text.Trim
            .highLimit = Val(txtHighAlarm.Text)
            .lowLimit = Val(txtLowAlarm.Text)
            .monitorHigh = chkHighAlarm.Checked
            .monitorLow = chkLowAlarm.Checked
            .ss1 = cmbSensor.Text
            .sendSms = .enabled AndAlso chkSms.Checked
            .sendEmail = .enabled AndAlso chkEmail.Checked
            .enableSound = .enabled AndAlso chkSound.Checked
        End With
        Hourglass.Release()
    End Sub
    Private Sub Alarm_CheckedChanged(sender As Object, e As EventArgs) Handles chkHighAlarm.CheckedChanged, chkLowAlarm.CheckedChanged
        txtHighAlarm.Enabled = chkHighAlarm.Checked
        txtLowAlarm.Enabled = chkLowAlarm.Checked
    End Sub
    Private Sub cmdAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddress.Click
        Dim frm As New frmEmailAddress
        frm.ShowDialog()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub InitControls()
        'populate sensors
        For Each s In _gAttachedSensors
            If TryCast(s, IAlarmable) IsNot Nothing Then
                cmbSensor.Items.Add(s.SS1)
            End If
        Next
        cmbSensor.SelectedIndex = 0

        'populate alarm sounds
        cmbAlarmSound.Items.Clear()
        cmbAlarmSound.Items.Add("<Default>")
        Dim alarmDir = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "data\alarms")
        For Each f In My.Computer.FileSystem.GetFiles(alarmDir)
            cmbAlarmSound.Items.Add(My.Computer.FileSystem.GetName(f))
        Next
        cmbAlarmSound.SelectedIndex = 0
        '
        'load saved alarm sound
        '
        If ConfigXml.Instance.AlarmFile.Length <> 0 Then
            Try
                cmbAlarmSound.Text = ConfigXml.Instance.AlarmFile
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        RaiseEvent NameChanged(txtName.Text)
    End Sub
End Class
