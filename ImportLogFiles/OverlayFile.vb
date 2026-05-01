Imports System.Globalization
Imports System.IO
Imports System.Threading
Imports CsvHelper

Friend Class OverlayFile
    Private _fileName As String = String.Empty
    Private _seriesCount As UShort
    Private _ss1 As New List(Of String)

    Event PointsRead(ByVal count As Integer)

    Const MAX_POINTS_PER_SERIES = 100000
    Private _sensorReading()() As Double

    Private _lstY As New List(Of List(Of Double))
    Private _timeX As New List(Of Double)

    Private Sub ParseFile()
        Dim lineIndex As Integer = 0 'first line is 0
        Dim headerLineIndex As Integer = -1
        Dim buffer As String

        For Each buffer In File.ReadLines(_fileName)
            If buffer Like "*Elapsed Time*" Then
                'we have reached the header line
                headerLineIndex = lineIndex
                Exit For
            Else
                lineIndex += 1
            End If
        Next
        '
        If headerLineIndex = -1 Then 'still
            MsgBox("Invalid log file. No header line")
            Return
        End If
        '
        'read again from beginning and skip 0 to headerIndex-1
        '
        lineIndex = 0
        Using sr As New StreamReader(_fileName)
            Using cr = New CsvReader(sr)
                cr.Configuration.Delimiter = CultureInfo.CurrentCulture.TextInfo.ListSeparator
                cr.Configuration.HasHeaderRecord = False
                For i As Integer = 0 To headerLineIndex - 1
                    cr.Read()
                    Dim arr As String() = cr.CurrentRecord
                Next
                '
                'read the sensor label
                '
                '
                'timestamp and elapsed time
                '
                cr.Read()
                buffer = cr.GetField(Of String)(0) 'timestamp header
                buffer = cr.GetField(Of String)(1) 'elapsed time header
                '
                'get sensor labels
                '
                For i As Integer = 0 To 50
                    If cr.TryGetField(Of String)(i + 2, buffer) = True _
                        AndAlso buffer.Trim.Length > 0 _
                        AndAlso Not buffer.StartsWith("UDF:") Then
                        _seriesCount = i + 1
                        _ss1.Add(buffer.Trim)
                        _lstY.Add(New List(Of Double))
                    Else
                        Exit For
                    End If
                Next
                Dim pointNo As UInteger = 0 'from 0 to points read -1
                Do While cr.Read
                    _timeX.Add(cr.GetField(Of Double)(1))

                    For i = 0 To _seriesCount - 1
                        _lstY(i).Add(cr.GetField(Of Double)(i + 2))
                    Next
                    If pointNo Mod 1000 = 0 Then
                        RaiseEvent PointsRead(pointNo)
                    End If
                    If (pointNo > MAX_POINTS_PER_SERIES - 1) Then
                        Exit Do
                    End If
                    pointNo += 1
                Loop
            End Using

        End Using

    End Sub

    Public Sub New(ByVal fileName As String)
        _fileName = fileName
        Try
            ParseFile()
        Catch ex As Exception
            MsgBox("Invalid log file:" + ex.Message)
            Throw ex
        End Try
    End Sub

    Public ReadOnly Property SS1(ByVal index As UShort) As String
        Get
            Return _ss1(index)
        End Get
    End Property

    Public ReadOnly Property SeriesCount() As UShort
        Get
            Return _seriesCount
        End Get
    End Property

    Public ReadOnly Property Y(ByVal seriesIndex As Integer) As Double()
        Get
            Return _lstY(seriesIndex).ToArray()
        End Get
    End Property

    Public ReadOnly Property X() As Double()
        Get
            Return _timeX.ToArray()
        End Get
    End Property

End Class