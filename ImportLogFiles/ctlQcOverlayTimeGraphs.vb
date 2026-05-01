Option Compare Text
Option Explicit On
Option Strict Off
Imports com.quinncurtis.chart2dnet
Imports com.quinncurtis.rtgraphnet
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports com.loadstar.utility

Friend Class ctlQcOverlayTimeGraphs
    Inherits com.quinncurtis.chart2dnet.ChartView
    '
    Private _graphIndex As Short = -1
    Private Const GRAPH_LINE_WIDTH = 1
    Private _options As New OverlayGraphOptions
    Protected _graphFont As New Font("Arial Narrow", 10, FontStyle.Regular)
    Protected _graphTitleFont As New Font("Arial Narrow", 12, FontStyle.Bold)
    Protected _graphTitle As String
    Protected _title As ChartTitle
    Protected _titleTransform As PhysicalCoordinates
    Private _y1axis, _y2axis As LinearAxis
    Private _xAxis As LinearAxis
    Private _y1Transform As CartesianCoordinates, _y2Transform As CartesianCoordinates
    Private _cp As ChartPrint
    Private _isY2GraphEnabled As Boolean = False
    Private _legend As StandardLegend
    '
    Private Class YAxisParameter
        Public attrib As ChartAttribute
        Public symAttrib As ChartAttribute
        Public linePlot As SimplePlot
    End Class
    Private _y1AxisParams As List(Of YAxisParameter)
    Private _y2AxisParams As List(Of YAxisParameter)
    Private _y1Dataset() As SimpleDataset, _y2Dataset() As SimpleDataset
    Private _firstSequenceNoToGraph As Integer
    Private _autoscaleX, _autoscaleY1, _autoscaleY2 As Boolean
    Private _theme As GraphTheme
    '
    Public Sub Initialize(ByVal blackBackground As Boolean)
        Dim chartVu As ChartView = Me
        _theme = New GraphTheme(blackBackground)
        'delete all objects in chart
        'For i = Me.GetChartObjectsArrayList.Count - 1 To 0 Step -1
        '    Me.DeleteChartObject(Me.GetChartObjectsArrayList(i))
        'Next
        Me.ResetChartObjectList()
        _y1AxisParams = New List(Of YAxisParameter)
        _y2AxisParams = New List(Of YAxisParameter)

        _autoscaleX = _options.xAxisOptions.autoScale
        _autoscaleY1 = _options.y1AxisOptions.autoScale
        _autoscaleY2 = _options.y2AxisOptions.autoScale
        Dim graphbackground As New Background
        graphbackground.SetColor(_theme.backgroundColor)
        chartVu.AddChartObject(graphbackground)

        Dim plotbackground As New Background
        plotbackground.SetColor(_theme.backgroundColor)
        chartVu.AddChartObject(plotbackground)

        SetupY1Frame()
        AddX2Y2Lines()

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
        xTitle = New AxisTitle(_xAxis, _graphFont, "Time (sec)")
        xTitle.SetColor(_theme.textColor)
        chartVu.AddChartObject(xTitle)

        ''grid
        Dim xMajorGrid As New Grid(_xAxis, _y1axis, ChartObj.X_AXIS, ChartObj.GRID_MAJOR)
        xMajorGrid.SetColor(_theme.majorGridColor)
        xMajorGrid.SetLineWidth(1)
        xMajorGrid.SetLineStyle(DashStyle.Dot)
        chartVu.AddChartObject(xMajorGrid)
        Dim xMinorGrid As New Grid(_xAxis, _y1axis, ChartObj.X_AXIS, ChartObj.GRID_MINOR)
        xMinorGrid.SetColor(_theme.minorGridColor)
        xMinorGrid.SetLineWidth(1)
        xMinorGrid.SetLineStyle(DashStyle.Dot)
        chartVu.AddChartObject(xMinorGrid)

        '--------------------------------
        Dim yMajorGrid As New Grid(_xAxis, _y1axis, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR)
        yMajorGrid.SetColor(_theme.majorGridColor)
        yMajorGrid.SetLineWidth(1)
        yMajorGrid.SetLineStyle(DashStyle.Dot)
        chartVu.AddChartObject(yMajorGrid)
        Dim yMinorGrid As New Grid(_xAxis, _y1axis, ChartObj.Y_AXIS, ChartObj.GRID_MINOR)
        yMinorGrid.SetColor(_theme.minorGridColor)
        yMinorGrid.SetLineWidth(1)
        yMinorGrid.SetLineStyle(DashStyle.Dot)
        chartVu.AddChartObject(yMinorGrid)
        'initialize printer obj
        _cp = New ChartPrint(Me, ChartObj.PRT_MAX)

        'add legend, items have been added to the legend earlier
        _legend = New StandardLegend
        _legend.SetColor(Color.Transparent)
        _legend.SetLegendWidth(1)
        _legend.SetLegendHeight(0.05)
        chartVu.AddChartObject(_legend)
    End Sub
    Private Sub SetupY1Frame()
        Dim chartVu As ChartView = Me
        '
        _y1Transform = New CartesianCoordinates(-100, -100, 100, 100)
        _y1Transform.SetGraphBorderDiagonal(0.08, 0.05, 0.92, 0.9)
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
        'y axis
        '
        _y1axis = New LinearAxis(_y1Transform, ChartObj.Y_AXIS)
        _y1axis.SetColor(_theme.majorGridColor)
        chartVu.AddChartObject(_y1axis)
        Dim yTitle = New AxisTitle(_y1axis, _graphFont, "Force")
        yTitle.SetColor(_theme.textColor)
        chartVu.AddChartObject(yTitle)
        Dim yAxisLab = New NumericAxisLabels(_y1axis)
        yAxisLab.SetColor(_theme.textColor)
        yAxisLab.SetTextFont(_graphFont)
        chartVu.AddChartObject(yAxisLab)
        '
        'zoom
        '
        Dim zoomObj As New ChartZoom(chartVu, _y1Transform, True)
        zoomObj.SetButtonMask(System.Windows.Forms.MouseButtons.Left)
        zoomObj.SetZoomYEnable(True)
        zoomObj.SetZoomXEnable(True)
        zoomObj.SetZoomXRoundMode(ChartObj.AUTOAXES_FAR)
        zoomObj.SetZoomYRoundMode(ChartObj.AUTOAXES_FAR)
        zoomObj.SetEnable(True)
        zoomObj.SetZoomStackEnable(True)
        zoomObj.SetZoomRangeLimitsRatio(New Dimension(0.000001, 0.0001))
        zoomObj.InternalZoomStackProcesssing = True
        chartVu.SetCurrentMouseListener(zoomObj)
        _graphIndex = -1
    End Sub
    Public Sub AddSeries(ByVal ss1 As String, ByVal x() As Double, ByVal y() As Double)

        Hourglass.Show()
        _graphIndex = _graphIndex + 1
        Try

            ReDim Preserve _y1Dataset(0 To _graphIndex)
            _y1Dataset(_graphIndex) = New SimpleDataset
            Dim series = New YAxisSeries
            series.ss1 = ss1
            Dim yp As New YAxisParameter
            yp.attrib = New ChartAttribute()
            yp.attrib.SetLineWidth(series.lineWidth)
            yp.attrib.SetColor(_theme.FixColor(GraphTheme.ColorNumber(_graphIndex)))
            yp.attrib.SetLineStyle(DashStyle.Solid)
            yp.symAttrib = New ChartAttribute(_theme.FixColor(Color.FromArgb(series.lineColor)), 1, DashStyle.Solid, _theme.FixColor(Color.FromArgb(series.lineColor)))
            yp.linePlot = New SimpleLineMarkerPlot(_y1Transform, _y1Dataset(_graphIndex), ChartObj.NOSYMBOL, yp.attrib, yp.symAttrib, 0, 0)
            yp.linePlot.SetFastClipMode(ChartObj.FASTCLIP_X)
            _y1AxisParams.Add(yp)
            Me.AddChartObject(yp.linePlot)

            Dim n = _legend.AddLegendItem(series.ss1, yp.linePlot, _graphFont)
            _legend.GetLegendItem(n - 1).LegendItemText.SetColor(_theme.FixColor(yp.attrib.GetColor))
            'For i = 0 To x.Length - 1
            '    _y1Dataset(graphIndex).AddDataPoint(x(i), y(i))
            'Next
            _y1Dataset(_graphIndex).SetYData(y)
            _y1Dataset(_graphIndex).SetXData(x)
            _y1Transform.AutoScale(_y1Dataset)
            _xAxis.CalcAutoAxis()
            _y1axis.CalcAutoAxis()
            _xAxis.SetAxisIntercept(_y1Transform.GetScaleStartY)
            _y1axis.SetAxisIntercept(_y1Transform.GetScaleStartX)
            Me.UpdateDraw()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
        Hourglass.Release()
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
    Public Sub CopyToClipboard()
        Hourglass.Show()
        clsClipboardMetafileHelper.CopyChartToClipboardEMF(Me.Handle, Me)
        Hourglass.Release()
    End Sub
    Public Sub PrintChart()
        If _cp.DoPrintDialog() = True Then
            _cp.DocPrintPage(Nothing, Nothing)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
