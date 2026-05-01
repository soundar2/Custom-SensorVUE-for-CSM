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
Public Class ctlQcTimeXGraph
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
    Private _xTimeAxis As ElapsedTimeAxis
    Private _xLinearAxis As LinearAxis
    Private _y1Frame As RTScrollFrame, _y2Frame As RTScrollFrame
    Private _y1Transform As ElapsedTimeCoordinates, _y2Transform As ElapsedTimeCoordinates
    Private _ptIndex As ULong
    Private _isCumulativeMode As Boolean = False
    Private _cp As ChartPrint
    Private _isY2GraphEnabled As Boolean = False
    Private _legend As StandardLegend
    Private _isOperating As Boolean = False
    '
    Private Class YAxisParameter
        Public rtProcess As RTProcessVar
        Public attrib As ChartAttribute
        Public symAttrib As ChartAttribute
        Public linePlot As SimplePlot
        Public sensor As LsSensor
    End Class
    Private _y1 As List(Of YAxisParameter)
    Private _y2 As List(Of YAxisParameter)
    Private _alwaysGraph As Boolean = True
    Private _theme As GraphTheme
    Private _zoomObj As ChartZoom
    '
    Private _handlerAttached As Boolean = False
    '
    'event for autotruncate
    '
    Event GraphDataLimitReached(ByVal sensor As LsSensor, ByVal nPoints As UInteger)
    Public Sub Initialize(ByVal graphIndex As UShort) Implements IQcGraph.Initialize
        Dim chartVu As ChartView = Me
        _handlerAttached = False
        TimerRepaint.Interval = 250
        'delete all objects in chart
        ResetChartObjectList()
        'For i = Me.GetChartObjectsArrayList.Count - 1 To 0 Step -1
        '    Me.DeleteChartObject(Me.GetChartObjectsArrayList(i))
        'Next
        _y1 = New List(Of YAxisParameter)
        _y2 = New List(Of YAxisParameter)
        _legend = New StandardLegend
        _graphIndex = graphIndex
        _options = _gGraphOptionsCollection(_graphIndex)
        _graphFont = New Font("Arial Narrow", _options.labelFontSize, FontStyle.Regular)
        _graphTitleFont = New Font("Arial Narrow", _options.titleFontSize, FontStyle.Bold)
        _isCumulativeMode = _options.xAxisOptions.cumulative
        _theme = New GraphTheme(IIf(ConfigXml.Instance.graphBlackBackground, True, False))
        _isY2GraphEnabled = (From s In _options.y2AxisOptions.SeriesCollection Select s.ss1).Any()

        SetupY1Frame()
        If _isY2GraphEnabled Then
            SetupY2Frame()
        End If

        '
        'x axis
        '

        _xTimeAxis = New ElapsedTimeAxis(_y1Transform, ChartObj.X_AXIS)
        _xTimeAxis.SetColor(_theme.majorGridColor)
        chartVu.AddChartObject(_xTimeAxis)
        Dim xAxisLab As New ElapsedTimeAxisLabels(_xTimeAxis)
        xAxisLab.TextFont = _graphFont
        xAxisLab.SetColor(_theme.textColor)
        xAxisLab.SetAxisLabelsFormat(ChartObj.TIMEDATEFORMAT_24HMS)
        chartVu.AddChartObject(xAxisLab)
        '

        'x-axis title
        Dim xTitle As AxisTitle

        If _options.xAxisOptions.UseTimeScale Then
            xTitle = New AxisTitle(_xTimeAxis, _graphFont, "Time (h:m:s)")
        Else
            xTitle = New AxisTitle(_xTimeAxis, _graphFont, _options.xAxisOptions.title)
        End If
        xTitle.SetColor(_theme.textColor)
        chartVu.AddChartObject(xTitle)
        'setup title
        _title = New ChartTitle(_titleTransform, _graphTitleFont, _options.Title)
        _title.SetTitleType(ChartObj.CHART_HEADER)
        _title.SetTextNudge(0, 5)
        _title.SetColor(_theme.textColor)
        If _options.showTitle Then
            chartVu.AddChartObject(_title)
        End If


        'grid
        If _options.showGrid Then
            Dim xMajorGrid As New Grid(_xTimeAxis, _y1axis, ChartObj.X_AXIS, ChartObj.GRID_MAJOR)
            xMajorGrid.SetColor(_theme.majorGridColor)
            xMajorGrid.SetLineWidth(1)
            xMajorGrid.SetLineStyle(DashStyle.Dot)
            chartVu.AddChartObject(xMajorGrid)
            If _options.showMinorGrid Then
                Dim xMinorGrid As New Grid(_xTimeAxis, _y1axis, ChartObj.X_AXIS, ChartObj.GRID_MINOR)
                xMinorGrid.SetColor(_theme.minorGridColor)
                xMinorGrid.SetLineWidth(1)
                xMinorGrid.SetLineStyle(DashStyle.Dot)
                chartVu.AddChartObject(xMinorGrid)
            End If

            '--------------------------------
            Dim yMajorGrid As New Grid(_xTimeAxis, _y1axis, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR)
            yMajorGrid.SetColor(_theme.majorGridColor)
            yMajorGrid.SetLineWidth(1)
            yMajorGrid.SetLineStyle(DashStyle.Dot)
            chartVu.AddChartObject(yMajorGrid)
            If _options.showMinorGrid Then
                Dim yMinorGrid As New Grid(_xTimeAxis, _y1axis, ChartObj.Y_AXIS, ChartObj.GRID_MINOR)
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
        Dim graphbackground As New Background
        graphbackground.SetColor(_theme.backgroundColor)
        chartVu.AddChartObject(graphbackground)

        Dim plotbackground As New Background
        plotbackground.SetColor(_theme.backgroundColor)
        chartVu.AddChartObject(plotbackground)

        _ptIndex = 0
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
        _zoomObj.SetZoomStackEnable(True)
        _zoomObj.SetZoomRangeLimits(New Dimension(1, 0.001))
        _zoomObj.InternalZoomStackProcesssing = True
        SetZoomEnabled(False)
        Reset()
        UpdateDraw()
    End Sub
    Public Sub Reset()
        _ptIndex = 0
        _y1Frame.ScrollScaleModeX = ChartObj.RT_FIXEDEXTENT_MOVINGSTART_AUTOSCROLL
        For i = 0 To _y1.Count - 1
            _y1(i).rtProcess.TruncateProcessVarDataset(0)
        Next
        If _isY2GraphEnabled Then
            _y2Frame.ScrollScaleModeX = ChartObj.RT_FIXEDEXTENT_MOVINGSTART_AUTOSCROLL
            For i = 0 To _y2.Count - 1
                _y2(i).rtProcess.TruncateProcessVarDataset(0)
            Next
        End If
    End Sub
    Public Sub SetGraphTitle(ByVal title As String)
        Dim chartVu As ChartView = Me
        chartVu.DeleteChartObject(_title)

    End Sub
    Private Sub OnSensorDataReceived(ByVal seqNo As UShort)
        If _isOperating AndAlso (_alwaysGraph OrElse _gOkToGraph(_graphIndex) = True) Then
            _gOkToGraph(_graphIndex) = False

            Dim t = clsGlobals._gTimeStampStopwatch.ElapsedMilliseconds
            For i = 0 To _y1.Count - 1
                _y1(i).rtProcess.SetCurrentValue(t, _y1(i).sensor.CurrentReading)
            Next
            If _ptIndex = 1 AndAlso _isCumulativeMode Then
                _y1Frame.ScrollScaleModeX = ChartObj.RT_MAXEXTENT_FIXEDSTART_AUTOSCROLL
            End If
            If _isY2GraphEnabled Then
                For i = 0 To _y2.Count - 1
                    _y2(i).rtProcess.SetCurrentValue(t, _y2(i).sensor.CurrentReading)
                Next
                If _ptIndex = 1 AndAlso _isCumulativeMode Then
                    _y2Frame.ScrollScaleModeX = ChartObj.RT_MAXEXTENT_FIXEDSTART_AUTOSCROLL
                End If
            End If
            _ptIndex += 1
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
        Me.UpdateDraw()
    End Sub

    Private Sub SetupY1Frame()
        Dim chartVu As ChartView = Me
        '
        _y1Transform = New ElapsedTimeCoordinates(-10, -1, _options.xAxisOptions.TimeRangeSec * 1000, 10)
        _y1Transform.SetGraphBorderDiagonal(0.08, 0.05, 0.92, 0.88)
        _titleTransform = _y1Transform
        If _options.y1AxisOptions.autoScale Then
            _y1Frame = New RTScrollFrame(Me, _y1Transform,
  ChartObj.RT_FIXEDEXTENT_MOVINGSTART_AUTOSCROLL, ChartObj.RT_AUTOSCALE_Y_MINMAX)
        Else
            _y1Frame = New RTScrollFrame(Me, _y1Transform,
  ChartObj.RT_FIXEDEXTENT_MOVINGSTART_AUTOSCROLL, ChartObj.RT_NO_AUTOSCALE_Y)
            _y1Frame.ChartObjScale.SetScaleStartY(_options.y1AxisOptions.YMin)
            _y1Frame.ChartObjScale.SetScaleStopY(_options.y1AxisOptions.YMax)
        End If

        _y1Frame.MinSamplesForAutoScale = ConfigXml.Instance.minSamplesForAutoScale
        _y1Frame.ScrollRescaleMargin = 0.01
        '
        For i = 0 To _options.y1AxisOptions.SeriesCollection.Count - 1
            _y1.Add(New YAxisParameter())
            _y1(i).rtProcess = New RTProcessVar()
            '_y1(i).rtProcess.SetCurrentValue(0)
            _y1(i).rtProcess.DatasetEnableUpdate = True
            _y1(i).rtProcess.AutoTruncateDataset = True
            _y1(i).rtProcess.AutoTruncateMaxCount = IIf(_isCumulativeMode, ConfigXml.Instance.graphCumulativeTruncateNPoint, ConfigXml.Instance.graphScrollingTruncateNPoint)
            _y1(i).rtProcess.AutoTruncateMinCount = _y1(i).rtProcess.AutoTruncateMaxCount * 0.98
            AddHandler _y1(i).rtProcess.RTDatasetTruncateEventHandler, AddressOf AutoTruncateEventHandler
            _y1Frame.AddProcessVar(_y1(i).rtProcess) 'add variables to frame
        Next
        chartVu.AddChartObject(_y1Frame)

        '
        'y axis
        '
        _y1axis = New LinearAxis(_y1Transform, ChartObj.Y_AXIS)
        Try
            _y1axis.SetColor(_theme.FixColor(Color.FromArgb(_options.y1AxisOptions.SeriesCollection(0).lineColor)))
        Catch ex As Exception

        End Try

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
        _y2Transform = New ElapsedTimeCoordinates(-10, -1, _options.xAxisOptions.TimeRangeSec * 1000, 10)
        _y2Transform.SetGraphBorderDiagonal(0.08, 0.05, 0.92, 0.88)
        If _options.y2AxisOptions.autoScale Then
            _y2Frame = New RTScrollFrame(Me, _y2Transform,
  ChartObj.RT_FIXEDEXTENT_MOVINGSTART_AUTOSCROLL, ChartObj.RT_AUTOSCALE_Y_MINMAX)
        Else
            _y2Frame = New RTScrollFrame(Me, _y2Transform,
  ChartObj.RT_FIXEDEXTENT_MOVINGSTART_AUTOSCROLL, ChartObj.RT_NO_AUTOSCALE_Y)
            _y2Frame.ChartObjScale.SetScaleStartY(_options.y2AxisOptions.YMin)
            _y2Frame.ChartObjScale.SetScaleStopY(_options.y2AxisOptions.YMax)
        End If

        _y2Frame.MinSamplesForAutoScale = ConfigXml.Instance.minSamplesForAutoScale
        _y2Frame.ScrollRescaleMargin = 0.01
        '
        For i = 0 To _options.y2AxisOptions.SeriesCollection.Count - 1
            _y2.Add(New YAxisParameter())
            _y2(i).rtProcess = New RTProcessVar()
            '_y2(i).rtProcess.SetCurrentValue(0)
            _y2(i).rtProcess.DatasetEnableUpdate = True
            _y2(i).rtProcess.AutoTruncateDataset = True
            _y2(i).rtProcess.AutoTruncateMaxCount = IIf(_isCumulativeMode, ConfigXml.Instance.graphCumulativeTruncateNPoint, ConfigXml.Instance.graphScrollingTruncateNPoint)
            _y2(i).rtProcess.AutoTruncateMinCount = _y2(i).rtProcess.AutoTruncateMaxCount * 0.98
            AddHandler _y2(i).rtProcess.RTDatasetTruncateEventHandler, AddressOf AutoTruncateEventHandler
            _y2Frame.AddProcessVar(_y2(i).rtProcess) 'add variables to frame
        Next
        chartVu.AddChartObject(_y2Frame)

        '
        'y axis
        '
        _y2axis = New LinearAxis(_y2Transform, ChartObj.Y_AXIS)
        _y2axis.SetAxisIntercept(_y2Transform.GetScaleStopX)
        _y2axis.AxisTickDir = ChartObj.AXIS_MAX
        Try

            _y2axis.SetColor(_theme.FixColor(Color.FromArgb(_options.y2AxisOptions.SeriesCollection(0).lineColor)))
        Catch ex As Exception

        End Try
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
            Else
                Dim disabledImage As System.Drawing.Image = My.Resources.graph_disabled
                Dim left1 As Double = (1 - disabledImage.Width / Me.Width) / 2
                Dim top1 As Double = (1 - disabledImage.Height / Me.Height) / 2
                Dim img As New ChartImage(_y1Transform, disabledImage, left1, top1, ChartObj.NORM_GRAPH_POS, 0)
                img.SetSizeMode(ChartObj.ACTUAL_SIZE)
                Me.AddChartObject(img)
                Exit For 'no need to process others because graph is not enabled
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
                _y1(i).linePlot = New SimpleScatterPlot(_y1Transform, Nothing, symbol, _y1(i).attrib)
            Else
                _y1(i).linePlot = New SimpleLineMarkerPlot(_y1Transform, Nothing, symbol, _y1(i).attrib, _y1(i).symAttrib, 0, 0)
            End If
            _y1(i).linePlot.SetFastClipMode(ChartObj.FASTCLIP_X)
            chartVu.AddChartObject(New RTSimpleSingleValuePlot(_y1Transform, _y1(i).linePlot, _y1(i).rtProcess))
            _legend.AddLegendItem(series.ss1, _y1(i).linePlot, _graphFont)
        Next

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
            Else
                Exit For 'no need to process others because graph is not enabled
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
                _y2(i).linePlot = New SimpleScatterPlot(_y2Transform, Nothing, symbol, _y2(i).attrib)
            Else
                _y2(i).linePlot = New SimpleLineMarkerPlot(_y2Transform, Nothing, symbol, _y2(i).attrib, _y2(i).symAttrib, 0, 0)
            End If
            _y2(i).linePlot.SetFastClipMode(ChartObj.FASTCLIP_X)
            chartVu.AddChartObject(New RTSimpleSingleValuePlot(_y2Transform, _y2(i).linePlot, _y2(i).rtProcess))
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
        clsClipboardMetafileHelper.CopyChartToClipboardEMF(Me.Handle, Me)
        Hourglass.Release()
    End Sub
    Public Sub PrintChart() Implements IQcGraph.PrintChart
        If _cp.DoPrintDialog() = True Then
            _cp.DocPrintPage(Nothing, Nothing)
        End If
    End Sub
    Public Sub SetZoomEnabled(ByVal enabled As Boolean) Implements IQcGraph.SetZoomEnabled
        If enabled Then
            _y1Frame.ScrollScaleModeX = ChartObj.RT_AUTOSCALE_X_MINMAX
            If _isY2GraphEnabled Then
                _y2Frame.ScrollScaleModeX = ChartObj.RT_AUTOSCALE_X_MINMAX
            End If
            Me.UpdateDraw()
            _y1Frame.ChartObjEnable = ChartObj.OBJECT_DISABLE
            If _isY2GraphEnabled Then
                _y2Frame.ChartObjEnable = ChartObj.OBJECT_DISABLE
            End If
            _zoomObj.SetEnable(True)
            Me.SetCurrentMouseListener(_zoomObj)
            Me.Cursor = Cursors.Cross
        Else
            _zoomObj.SetEnable(False)
            Me.MouseListeners.ResetArrayList()
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub AutoTruncateEventHandler(sender As Object, e As RTDatasetTruncateArgs)
        If _isCumulativeMode Then
            For Each axisParameter In _y1
                If axisParameter.rtProcess.Equals(e.ProcessVar) Then
                    RemoveHandler axisParameter.sensor.SensorDataReceived, AddressOf OnSensorDataReceived 'remove earlier handlers, if any
                    RaiseEvent GraphDataLimitReached(axisParameter.sensor, e.ProcessVar.AutoTruncateMaxCount)
                End If
            Next
        End If
    End Sub

    Public Sub LoadTargetCurveForPart(partNumber As String) Implements IQcGraph.LoadTargetCurveForPart
        Throw New NotImplementedException()
    End Sub

    Private Sub IQcGraph_SaveChart(fileName As String) Implements IQcGraph.SaveChart
        Dim savegraph As New BufferedImage(Me, ImageFormat.Jpeg)
        savegraph.Render()
        savegraph.SaveImage(fileName)
    End Sub
End Class
