Public Class YAxisOptions
    Public autoScale As Boolean = True 'if not using timescale
    Private _seriesList As New List(Of YAxisSeries)
    Private _yMax As Double
    Public title As String = String.Empty
    Public Property YMax() As Double
        Get
            Return _yMax
        End Get
        Set(ByVal value As Double)
            If (value > _yMin) Then
                _yMax = value
            End If
        End Set
    End Property

    Private _yMin As Double
    Public Property YMin() As Double
        Get
            Return _yMin
        End Get
        Set(ByVal value As Double)
            If (value < _yMax) Then
                _yMin = value
            End If
        End Set
    End Property


    Public Property SeriesCollection() As List(Of YAxisSeries)
        Get
            Return _seriesList
        End Get
        Set(ByVal value As List(Of YAxisSeries))
            _seriesList = value
        End Set
    End Property

    Public Sub New()

    End Sub
End Class
