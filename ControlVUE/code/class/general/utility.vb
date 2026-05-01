Imports Microsoft.Win32
Imports com.loadstar.utility
Public Class LsUtility
    Public Shared Function IsOkToTareAll()
        'confirm if ok to tare before actually taring
        If ConfigXml.Instance.confirmTare Then
            If MsgBox("Ok to zero the sensor(s)?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then
                Return False
            End If
        End If
        Return True
    End Function
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
End Class
