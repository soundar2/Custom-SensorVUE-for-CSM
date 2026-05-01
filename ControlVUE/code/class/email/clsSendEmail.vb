Imports System.Net.Mail
Imports Microsoft.VisualBasic
Imports System.Diagnostics
Public Class clsSendMail
    Public Shared Function SendMail(ByVal sTo As String, ByVal sCC As String, ByVal subject As String, ByVal body As String, Optional ByVal isBodyHtml As Boolean = False) As Boolean
        Dim mailMsg As New MailMessage()
        Dim client As New SmtpClient
        With mailMsg
            .From = New MailAddress("sms@loadstarsensors.com")
            .To.Add(New MailAddress(sTo))
            If sCC.Length <> 0 Then
                .CC.Add(New MailAddress(sCC))
            End If
            .Subject = subject
            .Body = body
            .Priority = MailPriority.Normal
            .IsBodyHtml = isBodyHtml
            client.Host = "smtp.ionos.com"
            client.Port = 587
            client.UseDefaultCredentials = False
            client.Credentials = New System.Net.NetworkCredential("sms@loadstarsensors.com", "pavaq69rEstespAf")
            Try
                client.Send(mailMsg)
                My.Computer.Audio.Play(My.Resources.email_success, AudioPlayMode.Background)
                Return True
            Catch ex As Exception
                My.Computer.Audio.Play(My.Resources.email_error, AudioPlayMode.Background)
                Return False
            End Try

        End With

    End Function
End Class
