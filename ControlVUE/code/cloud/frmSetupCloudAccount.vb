Option Infer On
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports com.loadstar.utility
Public Class frmSetupCloudAccount
    Function isEmail(ByVal email As String) As Boolean
        Static emailRegex As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")

        Return emailRegex.IsMatch(email)
    End Function
    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim ret = RTCloudUpload.Instance.VerifyUploadCredentials(txtEmail.Text.Trim, txtPassword.Text.Trim)
        If ret.Item1 = False Then
            Utility.ShowErrorMessage(ret.Item2)
        Else
            Utility.ShowInfoMessage("Credentials check succeeded.")
            Dim crypt As New Simple3Des(txtEmail.Text.Trim.Reverse.ToString)
            ConfigXml.Instance.uploadEmail = txtEmail.Text.Trim
            ConfigXml.Instance.uploadPassword = txtPassword.Text.Trim
            ConfigXml.Instance.WriteConfiguration()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged, txtPassword.TextChanged, txtConfirm.TextChanged
        cmdOK.Enabled = isEmail(txtEmail.Text) AndAlso txtPassword.Text.Trim.Length <> 0 AndAlso txtPassword.Text = txtConfirm.Text
    End Sub

    Private Sub frmSetupCloudAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEmail.Text = ConfigXml.Instance.uploadEmail
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(ConfigXml.Instance.cloudBrowserUrl)
    End Sub

End Class