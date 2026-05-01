Public Class ExpWMA
    Private _average As Double = 0
    Private _weighting As Double
    Private _eventCounter As Short = 0
    Private _jumpThreshold As Double
    Private _windowSize As UShort = 1
    Private _pointIndex As UInteger = 0
    Public Sub New(ByVal windowSize As UShort, ByVal jumpThreshold As Double)
        _windowSize = Math.Max(1, windowSize)
        _weighting = 2 / (1 + _windowSize)
        _average = 0
        _eventCounter = 0
        _jumpThreshold = jumpThreshold
    End Sub
    Public Sub Reset()
        _average = 0
        _eventCounter = 0
        _pointIndex = 0
    End Sub
    Public ReadOnly Property Average() As Double
        Get
            Return _average
        End Get
    End Property
    Public Sub NewValue(ByVal v As Double)
        If _windowSize = 1 Then
            _average = v
            Return
        Else
            Dim delta As Double = v - _average
            Dim prevEc As UShort = Math.Abs(_eventCounter)

            If Math.Abs(delta) >= _jumpThreshold Then
                'change is > jumpThreshold
                'is this a noise or a possible real load?
                _eventCounter += Math.Sign(delta)
                If prevEc > 0 AndAlso Math.Abs(_eventCounter) < prevEc Then
                    'just noise
                    'don't change the average
                    _eventCounter = 0
                Else
                    'possible load
                    Select Case Math.Abs(_eventCounter)
                        Case 1, 2
                            'dont change the average
                        Case 3
                            '3 successive points are above threshold, real load
                            'jump to the new value
                            _eventCounter = 0
                            _average = v
                    End Select
                End If
            Else
                'neither noise or load
                _eventCounter = 0
                prevEc = 0
                _average += _weighting * (v - _average) ' _average = _weighting * (v - _average) + _average
            End If
        End If
        If _pointIndex = 0 Then
            _average = v 'just return the value
            'don't return the computed average
            'otherwise the average climbs slowly to the steady state value and gives
            'a misleading impression
            _pointIndex += 1 'once we reach the windowsize
            'we do not care about the pointIndex
        End If
    End Sub

End Class
