Public Class MessageLog
    Private Shared _instance As MessageLog
    Private _logs As New Concurrent.ConcurrentQueue(Of String)
    Private Sub New()
    End Sub
    Public Shared Function Instance() As MessageLog
        If _instance Is Nothing Then
            _instance = New MessageLog
        End If
        Return _instance
    End Function
    Public Sub Append(ByVal log As String)
        _logs.Enqueue(log)
    End Sub
    Public Function LogCount() As Integer
        Return _logs.Count
    End Function
    Public Function LogItem() As String
        Dim msg As String = String.Empty
        If _logs.TryDequeue(msg) Then
            Return msg
        Else
            Return String.Empty
        End If
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
