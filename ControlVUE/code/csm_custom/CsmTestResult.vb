Namespace csm
    Public Class CsmTestResult
        Public Property Id As Guid = New Guid()
        Public Property TestDate As DateTime
        Public Property PartNumber As String
        Public Property HeatNumber As String
        Public Property OperatorName As String
        Public Property BlankLengthLower As Double
        Public Property BlankLengthHigher As Double
        Public Property PeakLoad As Double
        Public Property TargetPeakLoad As Double
        Public Property DisplacementAtEnd As Double
        Public Property DisplacementAtPeak As Double
        Public Property OutsideDiameterAtStart As Double
        Public Property OutsideDiameterAtEnd As Double
        Public Property HeightAtEnd As Double
        Public Property Springback As Double
        Public Property TargetSpringback As Double
        Public Property TestDurationSec As Double
        Public Property RawReadings As List(Of Reading) = New List(Of Reading)
    End Class

    Public Class Reading
        Public Property Timestamp As DateTime
        Public Property Load As Double
        Public Property Displacement As Double
    End Class
    Public Class TargetCurveReading
        Public Property Index As Integer
        Public Property Load As Double
        Public Property Displacement As Double
    End Class
    Public Class TargetCurve
        Public Property PartName As String
        Public Property Readings As List(Of TargetCurveReading) = New List(Of TargetCurveReading)
    End Class
End Namespace