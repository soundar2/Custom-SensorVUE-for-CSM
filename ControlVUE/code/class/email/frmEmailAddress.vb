Imports System.Reflection
Imports System.Text
Public Class frmEmailAddress

    Private Sub frmEmailAddress_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            'save values
            ConfigXml.Instance.smsPhone = txtPhone.Text.Trim
            ConfigXml.Instance.emailAddress = txtEmail.Text.Trim
            ConfigXml.Instance.smsCarrier = cmbCarriers.Text
            ConfigXml.Instance.WriteConfiguration()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbCarriers.Items.Clear()
        For Each carrier As String In LsUtility.GetSMSCarriers
            Me.cmbCarriers.Items.Add(carrier)
        Next
        cmbCarriers.Sorted = True
        'load values
        txtPhone.Text = ConfigXml.Instance.smsPhone
        txtEmail.Text = ConfigXml.Instance.emailAddress
        If txtPhone.Text.Length <> 0 Then
            cmbCarriers.Text = ConfigXml.Instance.smsCarrier
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub chkSMS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetControlStates()
    End Sub

    Private Sub chkEmail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        SetControlStates()
    End Sub
    Private Sub SetControlStates()
    End Sub

    Private Sub txtEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmail.TextChanged, txtPhone.TextChanged, cmbCarriers.SelectionChangeCommitted
        'email address be entered
        'or phone and carrier must be entered
        cmdOK.Enabled = (txtEmail.Text.Trim.Length <> 0) OrElse (txtPhone.Text.Trim.Length <> 0 AndAlso cmbCarriers.SelectedIndex <> -1)
    End Sub
End Class
