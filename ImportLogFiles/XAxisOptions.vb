Friend Class XAxisOptions

    Public cumulative As Boolean = False
    Public autoScale As Boolean = True 'if not using timescale
    Private _xMax As Double = 100
    Private _xMin As Double = 0
    Public title As String = String.Empty
    Private _useTimeScale As Boolean = True

    Public Property UseTimeScale() As Boolean
        Get
            Return _useTimeScale
        End Get
        Set(ByVal value As Boolean)
            _useTimeScale = value
            If value = True Then
                title = "Time (sec)"
            End If
        End Set
    End Property

    Public Property XMax() As Double
        Get
            Return _xMax
        End Get
        Set(ByVal value As Double)
            _xMax = value
        End Set
    End Property

    Public Property XMin() As Double
        Get
            Return _xMin
        End Get
        Set(ByVal value As Double)
            _xMin = value
        End Set
    End Property
    Private _timeRange As UInteger = 10
    Public Property TimeRangeSec() As UInteger
        Get
            Return _timeRange
        End Get
        Set(ByVal value As UInteger)
            If _timeRange > 0 Then
                _timeRange = value
            End If
        End Set
    End Property
    Private _ss1 As String = String.Empty

    Public Property SS1() As String
        Get
            Return _ss1
        End Get
        Set(ByVal value As String)
            If value.Trim.Length <> 0 Then
                _ss1 = value
            End If
        End Set
    End Property
End Class
