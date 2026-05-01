Public Interface IQcGraph
    Sub Initialize(ByVal graphIndex As UShort)
    Sub StartReadingSensors()
    Sub ResumeReadingSensors()
    Sub StopReadingSensors()
    Sub CopyToClipboard()
    Sub PrintChart()
    Sub SetZoomEnabled(ByVal enabled As Boolean)
    Sub LoadTargetCurveForPart(ByVal partNumber As String)
    Sub SaveChart(ByVal fileName As String)
End Interface
