Option Infer On
Imports RestSharp
Imports com.loadstar.utility
Imports Newtonsoft
Imports Newtonsoft.Json.Linq
Imports System.Threading.Tasks.Dataflow
Imports System.Net
Imports System.IO
Public Class RTCloudUpload
    'real time cloud upload
    Private Shared _instance As RTCloudUpload
    Private _email As String
    Private _password As String
    Private _key = "2509ncta709s2qo6p54zhewrfev467ha"
    Private _sessionUid As String = String.Empty
    Private _sessionPid As String = String.Empty
    Public IsUploading As Boolean = False
    Private _isUploadCompleted As Boolean = False
    Private _isSessionActive As Boolean = False
    Private _gotUid As Boolean = False
    Event LogMessage(ByVal message As String)
    Public Class SensorNameUnits
        Public name As String
        Public units As String
        Public Sub New(name As String, units As String)
            Me.name = name
            Me.units = units
        End Sub
    End Class
    Public Class SessionMetaData
        Public key As String
        Public uid As String
        Public session_desc As String
        Public no_sensor As String
        Public sensor_details As SensorNameUnits()
    End Class
    Public Class RawDataPacket
        Public elaps_time As Double 'don't change this variable name
        Public readings() As Double
    End Class
    Public Class UploadPacket
        Public key, uid, pid As String
        Public data() As RawDataPacket
    End Class
    Private _uploadBufferBlock As BufferBlock(Of RawDataPacket)
    Private WithEvents _bg As New System.ComponentModel.BackgroundWorker
    Private Sub New()
    End Sub
    Public Shared Function Instance() As RTCloudUpload
        If _instance Is Nothing Then
            _instance = New RTCloudUpload
        End If
        Return _instance
    End Function
    Public Function VerifyUploadCredentials(ByVal email As String, ByVal password As String) As Tuple(Of Boolean, String)
        _gotUid = False
        If Not My.Computer.Network.IsAvailable Then
            Return New Tuple(Of Boolean, String)(False, "Network/Internet Connection not available. ")
        End If
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
                    _sessionUid = CType(respObj(0)("uid"), String)
                    _gotUid = True
                    Return New Tuple(Of Boolean, String)(True, _sessionUid)
                Else
                    Dim respObj = SimpleJson.DeserializeObject(response.Content)
                    errMsg = CType(respObj("msg"), String)
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
    Public Function UploadSensorMetaData(ByVal sensors As List(Of LsSensor), ByVal sessionDescr As String) As Tuple(Of Boolean, String)
        Dim client = New RestClient("http://www.loadstarsensors.com/sensorvue-cloud/api/initrequest")
        Dim errMsg As String
        Dim pkt As New SessionMetaData
        pkt.key = _key
        pkt.uid = _sessionUid
        pkt.session_desc = sessionDescr
        pkt.no_sensor = sensors.Count
        Dim sensor_details As New List(Of SensorNameUnits)
        For Each s In sensors
            sensor_details.Add(New SensorNameUnits(s.SS1, s.Units.OutputUnits))
        Next
        pkt.sensor_details = sensor_details.ToArray

        Dim request = New RestRequest(RestSharp.Method.POST)
        request.RequestFormat = DataFormat.Json
        request.AddBody(pkt)

        Try
            _isSessionActive = False
            '
            'whenever there is a new session set no of readings uploaded to 0
            '
            Hourglass.Show()
            Dim response = client.Execute(request)
            Hourglass.Release()
            If response.StatusCode = Net.HttpStatusCode.OK Then
                'Debug.Print(response.Content)
                Dim respObj = SimpleJson.DeserializeObject(response.Content)
                _sessionPid = CType(respObj("pid"), String)
                _isSessionActive = True
                _uploadBufferBlock = New BufferBlock(Of RawDataPacket)
                _bg = New System.ComponentModel.BackgroundWorker
                _bg.WorkerSupportsCancellation = True
                _bg.RunWorkerAsync()
                _isUploadCompleted = False
                ' Utility.ShowInfoMessage(String.Format("Uploading new session data...PID: {0}", _sessionPid))
                Return New Tuple(Of Boolean, String)(True, _sessionPid.ToString)
            Else
                errMsg = response.StatusDescription
            End If
        Catch ex As Exception
            errMsg = ex.Message
        Finally
            Hourglass.Release()
        End Try
        Return New Tuple(Of Boolean, String)(False, errMsg)
    End Function
    Public Function QueueSensorReadingForUpload(ByVal elapsedSec As Double, ByVal lstReadings As List(Of Double)) As Boolean
        Dim packet As New RawDataPacket
        packet.elaps_time = elapsedSec
        packet.readings = lstReadings.ToArray
        _uploadBufferBlock.Post(packet)
        Return True
    End Function
    Private Function PostSensorReading(ByVal lstPacket As List(Of RawDataPacket)) As Boolean
        '
        'run by a background process which picks up the data from the 
        'upload buffer
        'and uploads it
        '
        Dim client = New RestClient("http://www.loadstarsensors.com/sensorvue-cloud/api/processrequest")
        Dim request = New RestRequest(RestSharp.Method.POST)
        request.RequestFormat = DataFormat.Json
        Dim upPacket As New UploadPacket
        With upPacket
            .uid = _sessionUid
            .pid = _sessionPid
            .key = _key
            .data = lstPacket.ToArray
        End With
        request.AddBody(upPacket)
        'Debug.Print(request.JsonSerializer.Serialize(uploadPacket))
        'Return True
        Dim errMsg As String
        '
        Try
            Hourglass.Show()
            Dim response = client.Execute(request)
            Hourglass.Release()
            If response.StatusCode = Net.HttpStatusCode.OK Then
                '  Debug.Print(response.Content)
                Return True
            Else
                errMsg = response.StatusDescription
            End If
        Catch ex As Exception
            errMsg = ex.Message
            RaiseEvent LogMessage(errMsg)
        Finally
            Hourglass.Release()
        End Try
        Return False
    End Function
    Public Function QueueUploadCompleted() As Boolean
        _isUploadCompleted = True
    End Function
    Private Function PostUploadCompleted() As Boolean
        Dim client = New RestClient("http://www.loadstarsensors.com/sensorvue-cloud/api/processdoneack")
        Dim errMsg As String
        Dim request = New RestRequest(RestSharp.Method.POST)
        request.AddParameter("key", _key)
        request.AddParameter("uid", _sessionUid)
        request.AddParameter("pid", _sessionPid)
        Try
            Hourglass.Show()
            Dim response = client.Execute(request)
            Hourglass.Release()
            If response.StatusCode = Net.HttpStatusCode.OK Then
                ' Debug.Print("posted upload completed")
                RaiseEvent LogMessage("Upload completed.")
                Return True
            Else
                errMsg = response.StatusDescription
            End If
        Catch ex As Exception
            errMsg = ex.Message
            RaiseEvent LogMessage(errMsg)
        Finally
            Hourglass.Release()
        End Try
        Return False
    End Function
    Public Sub Test()


    End Sub


    Public ReadOnly Property GotUid() As Boolean
        Get
            Return _gotUid
        End Get
    End Property
    Public ReadOnly Property IsSessionActive() As Boolean
        Get
            Return _isSessionActive
        End Get
    End Property

    Private Function IsInternetAvailable() As Boolean
        Try
            If My.Computer.Network.IsAvailable() Then
                My.Computer.Network.Ping("loadstarsensors.com")
                Return True
            End If
        Catch ex As Exception

        End Try
        Utility.ShowInfoMessage("No internet?")
        Return False
    End Function

    Private Sub _bg_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles _bg.DoWork
        Do
            Dim lstPacket As New List(Of RawDataPacket)
            If _uploadBufferBlock.Count > 0 Then
                _uploadBufferBlock.TryReceiveAll(lstPacket)
                PostSensorReading(lstPacket)
                'Debug.Print("uploaded " & lstPacket.Count)
                RaiseEvent LogMessage("Uploaded " & lstPacket.Count)
            ElseIf _isUploadCompleted Then
                PostUploadCompleted()
                Return
            End If
            System.Threading.Thread.Sleep(_uploadIntervalMSec)
        Loop
    End Sub
    Private Shared _uploadIntervalMSec As UInt16
    Public Shared Property UploadIntervalMSec() As UInt16
        Get
            Return _uploadIntervalMSec
        End Get
        Set(ByVal value As UInt16)
            _uploadIntervalMSec = Math.Min(5000, value)
        End Set
    End Property

End Class