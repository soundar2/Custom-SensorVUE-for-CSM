Option Infer On
Imports RestSharp
Imports com.loadstar.utility
Public Class CloudUpload
    Private Shared _email As String
    Private Shared _password As String
    Private Shared _key = "2509ncta709s2qo6p54zhewrfev467ha"
    Public Class ValidateResponse
        Public uid As String
        Public name As String
        Public email As String
    End Class
    Public Shared Function ValidateUploadCredentials() As Tuple(Of Boolean, String)
        _email = ConfigXml.Instance.uploadEmail
        Dim errMsg As String = String.Empty
        If _email IsNot Nothing AndAlso _email.Length <> 0 Then
            Dim crypt As New Simple3Des(_email.Reverse.ToString)
            _password = crypt.DecryptData(ConfigXml.Instance.uploadPassword)
            Return ValidateUploadCredentials(_email, _password)
        Else
            errMsg = "Upload credentials not found."
        End If
        Return New Tuple(Of Boolean, String)(False, errMsg)
    End Function
    Public Shared Function ValidateUploadCredentials(ByVal email As String, ByVal password As String) As Tuple(Of Boolean, String)
        Dim errMsg As String = String.Empty
        If email IsNot Nothing AndAlso email.Length <> 0 Then
            Dim client = New RestClient(ConfigXml.Instance.cloudValidateUrl)
            Dim request = New RestRequest(RestSharp.Method.POST)
            request.AddParameter("key", _key)
            request.AddParameter("email", email)
            request.AddParameter("password", password)
            Try
                Hourglass.Show()
                Dim response = client.Execute(request)
                Hourglass.Release()
                If response.StatusCode = Net.HttpStatusCode.OK Then
                    Dim respObj = SimpleJson.DeserializeObject(response.Content)
                    Dim uid = CType(respObj(0)("uid"), String)
                    Return New Tuple(Of Boolean, String)(True, uid)
                Else
                    errMsg = "Unable to verify credentials. Please contact Loadstar Sensors"
                End If
            Catch ex As Exception
                errMsg = ex.Message
            Finally
                Hourglass.Release()
            End Try
        Else
            errMsg = "Upload credentials not found."
        End If
        Return New Tuple(Of Boolean, String)(False, errMsg)
    End Function
    Public Shared Function UploadFile(ByVal fileName As String, Optional ByVal fileDescription As String = "") As Boolean
        Dim ret = ValidateUploadCredentials()
        If ret.Item1 = False Then
            Utility.ShowErrorMessage("Invalid upload credentials")
            Return False
        End If
        Dim uid As String = ret.Item2
        Dim client = New RestClient(ConfigXml.Instance.cloudUploadUrl)
        Dim request = New RestRequest(RestSharp.Method.POST)
        request.AddParameter("key", _key)
        request.AddParameter("uid", uid)
        request.AddParameter("file_desc", fileDescription)
        request.AddParameter("key", _key)
        request.AddFile("file", fileName)
        Try
            Hourglass.Show()
            Dim response = client.Execute(request)
            Hourglass.Release()
            If response.StatusCode = Net.HttpStatusCode.OK Then
                Utility.ShowInfoMessage("File uploaded successfully")
            End If
        Catch ex As Exception
            Utility.ShowErrorMessage(ex.Message)
            Return False
        Finally
            Hourglass.Release()
        End Try
    End Function
End Class
