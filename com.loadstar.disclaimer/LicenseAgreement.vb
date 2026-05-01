Imports System.IO

Public Class LicenseAgreement
    Private _productName As String
    Private _configFile As String
    Private _alwaysShowAgreement As Boolean

    Public Sub New(ByVal productName As String, ByVal alwaysShowAgreement As Boolean)
        _productName = productName
        'read show license flag
        _alwaysShowAgreement = alwaysShowAgreement
        Dim configFileFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & productName
        _configFile = Path.Combine(configFileFolder, "license.show")
        With My.Computer.FileSystem
            If Not .DirectoryExists(configFileFolder) Then
                .CreateDirectory(configFileFolder)
                WriteShowFlag(True)
            End If
        End With
    End Sub

    Private Function ShowLicenseAgreement() As Boolean
        Try
            Using sr = New StreamReader(_configFile)
                Dim buffer = sr.ReadLine()
                Return (buffer Is Nothing OrElse buffer = "Show=1")
            End Using
        Catch ex As Exception
            'if there is
            Return True
        End Try
    End Function

    Private Sub WriteShowFlag(ByVal show As Boolean)
        Using sw As New StreamWriter(_configFile)
            sw.Write(IIf(show, "Show=1", "Show=0"))
        End Using
    End Sub

    Public Function AgreeToLicense() As Boolean

        If _alwaysShowAgreement Then
            Dim frmL As New frmLicAgreement()
            frmL.CheckBox1.Visible = False
            Return (frmL.ShowDialog = DialogResult.OK)
        End If

        If ShowLicenseAgreement() = False Then
            Return True
        End If
        Dim frm As New frmLicAgreement
        Dim ret = frm.ShowDialog
        If ret = DialogResult.OK Then
            WriteShowFlag(frm.showLicense)
            Return True
        Else
            WriteShowFlag(True)
            Return False
        End If
    End Function

End Class