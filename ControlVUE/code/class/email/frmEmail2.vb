Imports System.Reflection
Imports System.Text
Public Class frmEmail2
    Private _sendInterval As UInteger
    Private _sendStartTime As Date = Now()
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'units
        Dim iniFile As New LvIniFile("", "AlarmOptions")
        With cmbUnits
            .Items.Clear()
            For Each x As clsUnits.ENUM_UNITS In [Enum].GetValues(GetType(clsUnits.ENUM_UNITS))
                .Items.Add(clsUnits.GetUnitString(x))
            Next
        End With
        cmbUnits.Text = iniFile.GetString("units", "lb.")
        '
        cmbAlarm1.SelectedIndex = 0
        '
        cmbCarriers.Items.Clear()
        For Each carrier As String In clsEmailAlerts.GetSMSCarriers()
            Me.cmbCarriers.Items.Add(carrier)
        Next
        cmbCarriers.Sorted = True
        'load values
        Dim options As New clsEmailAlerts
        chkSMS.Checked = options.SendSMS
        chkEmail.Checked = options.SendEmail
        txtPhone.Text = options.Phone
        txtEmail.Text = options.Email
        cmbCarriers.Text = options.SMSCarrier
        Me.cmbInterval.Text = options.SendIntervalHrs '
        Me.lblLastSentTime.Text = IIf(options.LastSentTime = DateTime.MinValue.ToString(clsGlobals.emailTimeFormat), String.Empty, options.LastSentTime.ToString(clsGlobals.emailTimeFormat))
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub chkSMS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSMS.CheckedChanged
        SetControlStates()
    End Sub

    Private Sub chkEmail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEmail.CheckedChanged
        SetControlStates()
    End Sub
    Private Sub SetControlStates()
        pnlSMS.Enabled = (chkSMS.Checked = True)
        pnlEmail.Enabled = (chkEmail.Checked = True)
        Me.grpTimings.Enabled = (chkSMS.Checked = True OrElse chkEmail.Checked = True)
    End Sub

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'we need to validate
        If Me.txtAlarmValue.Text.Trim.Length = 0 Then
            FlashControl(txtAlarmValue) : Return
        End If
        Dim buffer As String
        If chkSMS.Checked = True Then
            buffer = txtPhone.Text.Trim
            If buffer.Length = 0 Then
                FlashControl(txtPhone) : Return
            Else
                Dim re As New System.Text.RegularExpressions.Regex("^\d{10,}$")
                If Not re.IsMatch(buffer) Then
                    FlashControl(txtPhone) : Return
                End If
            End If
            If Me.cmbCarriers.SelectedIndex = -1 Then
                FlashControl(cmbCarriers)
                Return
            End If
        End If
        If chkEmail.Checked = True Then
            buffer = txtEmail.Text.Trim
            If buffer.Length = 0 Then
                FlashControl(txtEmail) : Return
            Else
                Dim re As New System.Text.RegularExpressions.Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
                If Not re.IsMatch(buffer) Then
                    FlashControl(txtEmail)
                    Return
                End If
            End If
        End If
        'save values
        Dim options As New clsEmailAlerts
        options.SendEmail = chkEmail.Checked
        options.SendSMS = chkSMS.Checked
        options.Phone = txtPhone.Text.Trim
        options.Email = txtEmail.Text.Trim
        options.SMSCarrier = cmbCarriers.Text
        options.SendIntervalHrs = Val(cmbInterval.Text.Trim)
        Me.Close()
    End Sub

    Private Sub cmdViewLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewLog.Click
        Try
            System.Diagnostics.Process.Start(clsEmailAlerts.EmailLogFile)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub optOnce_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optOnce.CheckedChanged, optEvery.CheckedChanged
        Me.pnlAlarmInterval.Enabled = (Me.optEvery.Checked = True)
    End Sub
End Class
