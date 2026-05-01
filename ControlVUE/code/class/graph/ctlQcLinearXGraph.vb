Option Compare Text
Option Explicit On
Option Strict Off
Imports com.quinncurtis.chart2dnet
Imports com.quinncurtis.rtgraphnet
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports com.loadstar.utility
Imports System.Drawing.Imaging
Public Class ctlQcLinearXGraph
    Inherits com.quinncurtis.chart2dnet.ChartView
    Implements IQcGraph
    '
    Private _graphIndex As UShort = 0
    Private Const GRAPH_LINE_WIDTH = 2
    Private _options As GraphOptions
    Protected _graphFont As Font
    Protected _graphTitleFont As Font
    Protected _graphTitle As String
    Protected _title As ChartTitle
    Protected _titleTransform As PhysicalCoordinates
    Private _y1axis, _y2axis As LinearAxis
    Private _xAxis As LinearAxis
    Private _y1Transform As CartesianCoordinates, _y2Transform As CartesianCoordinates
    Private _cp As ChartPrint
    Private _isY2GraphEnabled As Boolean = False
    Private _legend As StandardLegend
    Private _isOperating As Boolean = False
    Private _handlerAttached As Boolean = False
    '
    Private Class YAxisParameter
        Public attrib As ChartAttribute
        Public symAttrib As ChartAttribute
        Public linePlot As SimplePlot
        Public sensor As LsSensor
    End Class
    Private _y1 As List(Of YAxisParameter)
    Private _y2 As List(Of YAxisParameter)
    Private _y1Dataset() As SimpleDataset, _y2Dataset() As SimpleDataset
    Private _targetYp As YAxisParameter

    Private _targetDataset As SimpleDataset
    Private _preloadedDataset As List(Of Point2D)
    Private _alwaysGraph As Boolean = True
    Private _autoscaleX, _autoscaleY1, _autoscaleY2 As Boolean
    Private _xSensor As LsSensor
    Private _theme As GraphTheme
    Private _zoomObj As ChartZoom
    '
    Public Sub Initialize(ByVal graphIndex As UShort) Implements IQcGraph.Initialize
        Dim chartVu As ChartView = Me
        _handlerAttached = False
        'delete all objects in chart
        ResetChartObjectList()
        'For i = Me.GetChartObjectsArrayList.Count - 1 To 0 Step -1
        '    Me.DeleteChartObject(Me.GetChartObjectsArrayList(i))
        'Next
        _y1 = New List(Of YAxisParameter)
        _y2 = New List(Of YAxisParameter)
        _legend = New StandardLegend
        _theme = New GraphTheme(IIf(ConfigXml.Instance.graphBlackBackground, True, False))
        _graphIndex = graphIndex
        _options = _gGraphOptionsCollection(_graphIndex)
        _graphFont = New Font("Arial Narrow", _options.labelFontSize, FontStyle.Regular)
        _graphTitleFont = New Font("Arial Narrow", _options.titleFontSize, FontStyle.Bold)
        _autoscaleX = _options.xAxisOptions.autoScale
        _autoscaleY1 = _options.y1AxisOptions.autoScale
        _autoscaleY2 = _options.y2AxisOptions.autoScale

        Dim firstSs1Tograph = _options.y1AxisOptions.SeriesCollection(0).ss1

        _xSensor = (From item In _gAttachedSensors Where item.SS1 = _options.xAxisOptions.SS1 Select item).Single
        ReDim _y1Dataset(0 To _options.y1AxisOptions.SeriesCollection.Count - 1)
        ReDim _y2Dataset(0 To _options.y2AxisOptions.SeriesCollection.Count - 1)
        For i = 0 To _y1Dataset.Length - 1
            _y1Dataset(i) = New SimpleDataset
        Next
        For i = 0 To _y2Dataset.Length - 1
            _y2Dataset(i) = New SimpleDataset
        Next
        If _targetDataset Is Nothing Then
            _targetDataset = New SimpleDataset
        End If
        Dim graphbackground As New Background
        graphbackground.SetColor(_theme.backgroundColor)
        chartVu.AddChartObject(graphbackground)

        Dim plotbackground As New Background
        plotbackground.SetColor(_theme.backgroundColor)
        chartVu.AddChartObject(plotbackground)

        _isY2GraphEnabled = (From s In _options.y2AxisOptions.SeriesCollection Select s.ss1).Any()


        SetupY1Frame()
        If _isY2GraphEnabled Then
            SetupY2Frame()
        End If

        '
        'x axis
        '
        _xAxis = New LinearAxis(_y1Transform, ChartObj.X_AXIS)
        _xAxis.SetColor(_theme.majorGridColor)
        chartVu.AddChartObject(_xAxis)
        Dim xAxisLab As New NumericAxisLabels(_xAxis)
        xAxisLab.SetColor(_theme.textColor)
        xAxisLab.TextFont = _graphFont
        chartVu.AddChartObject(xAxisLab)
        '

        'x-axis title
        Dim xTitle As AxisTitle
        xTitle = New AxisTitle(_xAxis, _graphFont, IIf(_options.xAxisOptions.title.Length = 0, _options.xAxisOptions.SS1, _options.xAxisOptions.title))
        xTitle.SetColor(_theme.textColor)
        chartVu.AddChartObject(xTitle)
        'setup title
        _title = New ChartTitle(_titleTransform, _graphTitleFont, _options.Title)
        _title.SetTitleType(ChartObj.CHART_HEADER)
        _title.SetColor(_theme.textColor)
        _title.SetTextNudge(0, 5)
        If _options.showTitle Then
            chartVu.AddChartObject(_title)
        End If

        ''grid
        If _options.showGrid Then
            Dim xMajorGrid As New Grid(_xAxis, _y1axis, ChartObj.X_AXIS, ChartObj.GRID_MAJOR)
            xMajorGrid.SetColor(_theme.majorGridColor)
            xMajorGrid.SetLineWidth(1)
            xMajorGrid.SetLineStyle(DashStyle.Dot)
            chartVu.AddChartObject(xMajorGrid)
            If _options.showMinorGrid Then
                Dim xMinorGrid As New Grid(_xAxis, _y1axis, ChartObj.X_AXIS, ChartObj.GRID_MINOR)
                xMinorGrid.SetColor(_theme.minorGridColor)
                xMinorGrid.SetLineWidth(1)
                xMinorGrid.SetLineStyle(DashStyle.Dot)
                chartVu.AddChartObject(xMinorGrid)
            End If

            '--------------------------------
            Dim yMajorGrid As New Grid(_xAxis, _y1axis, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR)
            yMajorGrid.SetColor(_theme.majorGridColor)
            yMajorGrid.SetLineWidth(1)
            yMajorGrid.SetLineStyle(DashStyle.Dot)
            chartVu.AddChartObject(yMajorGrid)
            If _options.showMinorGrid Then
                Dim yMinorGrid As New Grid(_xAxis, _y1axis, ChartObj.Y_AXIS, ChartObj.GRID_MINOR)
                yMinorGrid.SetColor(_theme.minorGridColor)
                yMinorGrid.SetLineWidth(1)
                yMinorGrid.SetLineStyle(DashStyle.Dot)
                chartVu.AddChartObject(yMinorGrid)
            End If
        End If
        'initialize printer obj
        _cp = New ChartPrint(Me, ChartObj.PRT_MAX)

        SetupY1Plots()
        If _isY2GraphEnabled Then
            SetupY2Plots()
        End If

        'add legend, items have been added to the legend earlier
        If _options.showLegend Then
            _legend.SetColor(Color.Transparent)
            _legend.SetLegendWidth(1)
            _legend.SetLegendHeight(0.05)
            chartVu.AddChartObject(_legend)
        End If
        AddX2Y2Lines()
        TimerRepaint.Interval = 100
        '
        'set up zoom parameters
        '
        Dim tArray() As CartesianCoordinates
        If _isY2GraphEnabled Then
            tArray = New CartesianCoordinates() {_y1Transform, _y2Transform}
        Else
            tArray = New CartesianCoordinates() {_y1Transform}
        End If

        _zoomObj = Nothing
        _zoomObj = New ChartZoom(chartVu, tArray, True)
        _zoomObj.SetButtonMask(System.Windows.Forms.MouseButtons.Left)
        _zoomObj.SetZoomYEnable(True)
        _zoomObj.SetZoomXEnable(True)
        _zoomObj.SetZoomXRoundMode(ChartObj.AUTOAXES_FAR)
        _zoomObj.SetZoomYRoundMode(ChartObj.AUTOAXES_FAR)
        _zoomObj.SetEnable(True)
        _zoomObj.SetZoomStackEnable(True)
        _zoomObj.SetZoomRangeLimitsRatio(New Dimension(0.000001, 0.0001))
        _zoomObj.InternalZoomStackProcesssing = True
        ' chartVu.SetCurrentMouseListener(_zoomObj)
        SetZoomEnabled(False)
        '
        Reset()
    End Sub
    Public Sub Reset()
        For i = 0 To _y1Dataset.Length - 1
            _y1Dataset(i).Resize(0)
        Next
        If _isY2GraphEnabled Then
            For i = 0 To _y2Dataset.Length - 1
                _y2Dataset(i).Resize(0)
            Next
        End If
    End Sub
    Private Sub OnSensorDataReceived(ByVal seqNo As UShort)
        If _isOperating AndAlso (_alwaysGraph OrElse _gOkToGraph(_graphIndex) = True) Then
            _gOkToGraph(_graphIndex) = False
            If _targetDataset.XData.Length = 0 Then
                For k = 0 To _preloadedDataset.Count - 1
                    Dim x = _preloadedDataset.ElementAt(k).X
                    Dim y = _preloadedDataset.ElementAt(k).Y
                    _targetDataset.AddDataPoint(x, y)
                Next
            End If

            For i = 0 To _y1.Count - 1
                _y1Dataset(i).AddDataPoint(_xSensor.CurrentReading, _y1(i).sensor.CurrentReading)
            Next
            If _isY2GraphEnabled Then
                For i = 0 To _y2.Count - 1
                    _y2Dataset(i).AddDataPoint(_xSensor.CurrentReading, _y2(i).sensor.CurrentReading)
                Next
            End If
        End If
    End Sub
    Public Sub StartReadingSensors() Implements IQcGraph.StartReadingSensors
        Reset()
        _alwaysGraph = (ConfigXml.Instance.logRate = ConfigXml.Enum_LogRate.continuous OrElse Not ConfigXml.Instance.graphLoggedReadingsOnly)
        TimerRepaint.Enabled = True
        _isOperating = True
    End Sub

    Public Sub ResumeReadingSensors() Implements IQcGraph.ResumeReadingSensors
        TimerRepaint.Enabled = True
        _isOperating = True
    End Sub
    Public Sub StopReadingSensors() Implements IQcGraph.StopReadingSensors
        _isOperating = False
        TimerRepaint.Enabled = False
    End Sub

    Private Sub TimerRepaint_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerRepaint.Tick
        'this is where most of the autoscaling work is done
        _y1Transform.AutoScale(_y1Dataset.Append(_targetDataset).ToArray())
        '_y1Transform.AutoScale(_y1Dataset)
        If _isY2GraphEnabled Then
            _y2Transform.AutoScale(_y2Dataset)
        End If
        If _autoscaleX Then
            _xAxis.CalcAutoAxis()
        Else
            _y1Transform.SetScaleStartX(_options.xAxisOptions.XMin)
            _y1Transform.SetScaleStopX(_options.xAxisOptions.XMax)
        End If
        If _autoscaleY1 Then
            _y1axis.CalcAutoAxis()
        Else
            _y1Transform.SetScaleStartY(_options.y1AxisOptions.YMin)
            _y1Transform.SetScaleStopY(_options.y1AxisOptions.YMax)
        End If
        If _isY2GraphEnabled Then
            If _autoscaleY2 Then
                _y2axis.CalcAutoAxis()
            Else
                _y2Transform.SetScaleStartY(_options.y2AxisOptions.YMin)
                _y2Transform.SetScaleStopY(_options.y2AxisOptions.YMax)
            End If
            If Not _autoscaleX Then
                _y2Transform.SetScaleStartX(_options.xAxisOptions.XMin)
                _y2Transform.SetScaleStopX(_options.xAxisOptions.XMax)
            End If
        End If
        _xAxis.SetAxisIntercept(_y1Transform.GetScaleStartY)
        _y1axis.SetAxisIntercept(_y1Transform.GetScaleStartX)
        If _isY2GraphEnabled Then
            _y2axis.SetAxisIntercept(_y2Transform.GetScaleStopX)
        End If
        Me.UpdateDraw()
    End Sub

    Private Sub SetupY1Frame()
        Dim chartVu As ChartView = Me
        '
        _y1Transform = New CartesianCoordinates(-100, -100, 100, 100)
        _y1Transform.SetGraphBorderDiagonal(0.08, 0.05, 0.92, 0.88)
        _titleTransform = _y1Transform
        If Not _autoscaleX Then
            _y1Transform.SetScaleStartX(_options.xAxisOptions.XMin)
            _y1Transform.SetScaleStopX(_options.xAxisOptions.XMax)
        End If
        If Not _autoscaleY1 Then
            _y1Transform.SetScaleStartY(_options.y1AxisOptions.YMin)
            _y1Transform.SetScaleStopY(_options.y1AxisOptions.YMax)
        End If

        '
        For i = 0 To _options.y1AxisOptions.SeriesCollection.Count - 1
            _y1.Add(New YAxisParameter())
        Next


        '
        'y axis
        '
        _y1axis = New LinearAxis(_y1Transform, ChartObj.Y_AXIS)
        _y1axis.SetColor(_theme.FixColor(Color.FromArgb(_options.y1AxisOptions.SeriesCollection(0).lineColor)))
        chartVu.AddChartObject(_y1axis)
        Dim yTitle = New AxisTitle(_y1axis, _graphFont, _options.y1AxisOptions.title)
        yTitle.SetColor(_theme.FixColor(_y1axis.GetColor()))
        chartVu.AddChartObject(yTitle)
        Dim yAxisLab = New NumericAxisLabels(_y1axis)
        yAxisLab.SetColor(_theme.FixColor(_y1axis.GetColor()))
        yAxisLab.SetTextFont(_graphFont)
        chartVu.AddChartObject(yAxisLab)
    End Sub
    Private Sub SetupY2Frame()
        Dim chartVu As ChartView = Me
        '
        _y2Transform = New CartesianCoordinates(-100, -100, 100, 100)
        _y2Transform.SetGraphBorderDiagonal(0.08, 0.05, 0.92, 0.88)
        If Not _autoscaleY2 Then
            _y2Transform.SetScaleStartY(_options.y2AxisOptions.YMin)
            _y2Transform.SetScaleStopY(_options.y2AxisOptions.YMax)
        End If

        '
        For i = 0 To _options.y2AxisOptions.SeriesCollection.Count - 1
            _y2.Add(New YAxisParameter())
        Next


        '
        'y axis
        '
        _y2axis = New LinearAxis(_y2Transform, ChartObj.Y_AXIS)
        _y2axis.SetColor(_theme.FixColor(Color.FromArgb(_options.y2AxisOptions.SeriesCollection(0).lineColor)))
        _y2axis.SetAxisIntercept(_y2Transform.GetScaleStopX)
        _y2axis.AxisTickDir = ChartObj.AXIS_MAX
        chartVu.AddChartObject(_y2axis)
        Dim yTitle = New AxisTitle(_y2axis, _graphFont, _options.y2AxisOptions.title)
        yTitle.SetColor(_theme.FixColor(_y2axis.GetColor()))
        chartVu.AddChartObject(yTitle)
        Dim yAxisLab = New NumericAxisLabels(_y2axis)
        yAxisLab.SetColor(_theme.FixColor(_y2axis.GetColor()))
        yAxisLab.SetTextFont(_graphFont)
        chartVu.AddChartObject(yAxisLab)
    End Sub
    Private Sub SetupY1Plots()
        Dim chartVu As ChartView = Me
        'create and add plots
        For i = 0 To _options.y1AxisOptions.SeriesCollection.Count - 1
            Dim series = _options.y1AxisOptions.SeriesCollection(i)
            Dim seriesSs1 = series.ss1
            _y1(i).sensor = (From s In _gAttachedSensors Where s.SS1 = seriesSs1 Select s).SingleOrDefault
            RemoveHandler _y1(i).sensor.SensorDataReceived, AddressOf OnSensorDataReceived 'remove earlier handlers, if any
            If _options.graphEnabled Then
                If Not _handlerAttached Then
                    AddHandler _y1(i).sensor.SensorDataReceived, AddressOf OnSensorDataReceived
                    _handlerAttached = True
                End If
            End If
            _y1(i).attrib = New ChartAttribute()
            _y1(i).attrib.SetLineWidth(series.lineWidth)
            _y1(i).attrib.SetColor(_theme.FixColor(Color.FromArgb(series.lineColor)))
            Select Case series.lineStyle
                Case "None"
                    'process below
                Case "Dashed"
                    _y1(i).attrib.SetLineStyle(DashStyle.Dash)
                Case Else
                    _y1(i).attrib.SetLineStyle(DashStyle.Solid)
            End Select
            _y1(i).symAttrib = New ChartAttribute(_theme.FixColor(Color.FromArgb(series.lineColor)), 1, DashStyle.Solid, _theme.FixColor(Color.FromArgb(series.lineColor)))

            _y1(i).symAttrib.SetSymbolSize(series.markerSize)
            Dim symbol As Integer = ChartObj.NOSYMBOL
            Select Case series.markerStyle
                Case "Square"
                    symbol = ChartObj.SQUARE
                Case "Circle"
                    symbol = ChartObj.CIRCLE
                Case "Diamond"
                    symbol = ChartObj.DIAMOND
                Case "Cross"
                    symbol = ChartObj.CROSS
                Case "Plus"
                    symbol = ChartObj.PLUS
                Case Else
                    symbol = ChartObj.NOSYMBOL
            End Select
            If series.lineStyle = "None" Then
                _y1(i).linePlot = New SimpleScatterPlot(_y1Transform, _y1Dataset(i), symbol, _y1(i).attrib)
            Else
                _y1(i).linePlot = New SimpleLineMarkerPlot(_y1Transform, _y1Dataset(i), symbol, _y1(i).attrib, _y1(i).symAttrib, 0, 0)
            End If
            _y1(i).linePlot.SetFastClipMode(ChartObj.FASTCLIP_X)
            chartVu.AddChartObject(_y1(i).linePlot)
            _legend.AddLegendItem(series.ss1, _y1(i).linePlot, _graphFont)
        Next
        '
        'add target curve
        '
        _targetYp = New YAxisParameter
        _targetYp.attrib = New ChartAttribute()
        _targetYp.attrib.SetLineWidth(2)
        _targetYp.attrib.SetColor(Color.Red)
        _targetYp.attrib.SetLineStyle(DashStyle.Dash)
        _targetYp.linePlot = New SimpleLinePlot(_y1Transform, _targetDataset, _targetYp.attrib)
        _targetYp.linePlot.SetFastClipMode(ChartObj.FASTCLIP_X)
        chartVu.AddChartObject(_targetYp.linePlot)
        _legend.AddLegendItem("Target", _targetYp.linePlot, _graphFont)
    End Sub
    Private Sub SetupY2Plots()
        Dim chartVu As ChartView = Me
        'create and add plots
        For i = 0 To _options.y2AxisOptions.SeriesCollection.Count - 1
            Dim series = _options.y2AxisOptions.SeriesCollection(i)
            Dim seriesSs1 = series.ss1
            _y2(i).sensor = (From s In _gAttachedSensors Where s.SS1 = seriesSs1 Select s).SingleOrDefault
            RemoveHandler _y2(i).sensor.SensorDataReceived, AddressOf OnSensorDataReceived 'remove earlier handlers, if any
            If _options.graphEnabled Then
                If Not _handlerAttached Then
                    AddHandler _y2(i).sensor.SensorDataReceived, AddressOf OnSensorDataReceived
                    _handlerAttached = True
                End If
            End If
            _y2(i).attrib = New ChartAttribute()
            _y2(i).attrib.SetLineWidth(series.lineWidth)
            _y2(i).attrib.SetColor(_theme.FixColor(Color.FromArgb(series.lineColor)))
            Select Case series.lineStyle
                Case "None"
                    'process below
                Case "Dashed"
                    _y2(i).attrib.SetLineStyle(DashStyle.Dash)
                Case Else
                    _y2(i).attrib.SetLineStyle(DashStyle.Solid)
            End Select
            _y2(i).symAttrib = New ChartAttribute(_theme.FixColor(Color.FromArgb(series.lineColor)), 1, DashStyle.Solid, _theme.FixColor(Color.FromArgb(series.lineColor)))
            _y2(i).symAttrib.SetSymbolSize(series.markerSize)
            Dim symbol As Integer = ChartObj.NOSYMBOL
            Select Case series.markerStyle
                Case "Square"
                    symbol = ChartObj.SQUARE
                Case "Circle"
                    symbol = ChartObj.CIRCLE
                Case "Diamond"
                    symbol = ChartObj.DIAMOND
                Case "Cross"
                    symbol = ChartObj.CROSS
                Case "Plus"
                    symbol = ChartObj.PLUS
                Case Else
                    symbol = ChartObj.NOSYMBOL
            End Select
            If series.lineStyle = "None" Then
                _y2(i).linePlot = New SimpleScatterPlot(_y2Transform, _y2Dataset(i), symbol, _y2(i).attrib)
            Else
                _y2(i).linePlot = New SimpleLineMarkerPlot(_y2Transform, _y2Dataset(i), symbol, _y2(i).attrib, _y2(i).symAttrib, 0, 0)
            End If
            _y2(i).linePlot.SetFastClipMode(ChartObj.FASTCLIP_X)
            chartVu.AddChartObject(_y2(i).linePlot)
            _legend.AddLegendItem(series.ss1, _y2(i).linePlot, _graphFont)
        Next

    End Sub
    Private Sub AddX2Y2Lines()
        Dim attrib2 As ChartAttribute = New ChartAttribute(_theme.majorGridColor, 1, DashStyle.Solid)
        Dim borderRect As Rectangle2D = New Rectangle2D(0, 0, 1, 1)
        Dim rectpath As GraphicsPath = New GraphicsPath()
        rectpath.AddRectangle(borderRect.GetRectangleF())
        Dim borderShape As ChartShape = New ChartShape(_y1Transform, rectpath, ChartObj.NORM_PLOT_POS, 0, 0, ChartObj.NORM_PLOT_POS, 0)
        borderShape.ChartObjClipping = ChartObj.GRAPH_AREA_CLIPPING
        borderShape.SetChartObjAttributes(attrib2)
        Me.AddChartObject(borderShape)
    End Sub
    Public Sub CopyToClipboard() Implements IQcGraph.CopyToClipboard
        Hourglass.Show()
        clsClipboardMetafileHelper.CopyChartToClipboardEMF(Me.Handle, Me, 4, 4)
        Hourglass.Release()

    End Sub
    Public Sub PrintChart() Implements IQcGraph.PrintChart
        If _cp.DoPrintDialog() = True Then
            _cp.DocPrintPage(Nothing, Nothing)
        End If
    End Sub

    Public Sub SetZoomEnabled(ByVal enabled As Boolean) Implements IQcGraph.SetZoomEnabled
        If enabled Then
            Me.SetCurrentMouseListener(_zoomObj)
            Me.Cursor = Cursors.Cross
        Else
            Me.MouseListeners.ResetArrayList()
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Public Sub LoadTargetCurveForPart(partNumber As String) Implements IQcGraph.LoadTargetCurveForPart
        _preloadedDataset = New List(Of Point2D)
        Dim targetCurve = csm.ModCsmTest.LoadTargetCurveForPart(partNumber)
        For i = 0 To targetCurve.Readings.Count - 1
            _preloadedDataset.Add(New Point2D(targetCurve.Readings(i).Displacement, targetCurve.Readings(i).Load))
        Next
    End Sub
    Private Sub SaveChart(fileName As String) Implements IQcGraph.SaveChart
        Hourglass.Show()
        clsClipboardMetafileHelper.CopyChartToClipboardEMF(Me.Handle, Me, 3, 3)
        clsClipboardMetafileHelper.SaveClipboardEmfAsImage("d:\temp\loadstar\junk.JPG", 3200, 3200, ImageFormat.Jpeg)
        Hourglass.Release()
    End Sub
End Class
