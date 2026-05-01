Public Class LogWriter
    Inherits System.Diagnostics.TextWriterTraceListener
    Private _traceFile As String
    Public Sub New(ByVal fileName As String)
        MyBase.New(fileName)
        _traceFile = fileName
    End Sub
    Public Overrides Sub WriteLine(message As String)
        MyBase.WriteLine(String.Format("{0},{1},{2}", Now.ToString(), Now.ToUniversalTime.ToString(), message))
    End Sub
    Public Function TraceFile() As String
        Return _traceFile
    End Function
End Class
