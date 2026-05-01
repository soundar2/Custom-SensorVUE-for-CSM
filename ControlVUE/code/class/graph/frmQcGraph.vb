Imports com.loadstar.utility
Public Class frmQcGraph
    Implements ISensorForm

    Private _graphIndex As UShort
    Private _qcGraph As IQcGraph
    Private _zoomEnabled As Boolean = False
    Public Sub New(ByVal graphIndex As UShort)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.MdiParent = _gFrmMain
        ' Add any initialization after the InitializeComponent() call.
        _graphIndex = graphIndex
        AddHandler _gFrmMain.cmdZoom.CheckedChanged, AddressOf cmdZoom_Click
        Me.Text = _gGraphOptionsCollection(_graphIndex).Title
    End Sub

    Public ReadOnly Property GraphIndex() As UShort
        Get
            Return _graphIndex
        End Get
    End Property

    Private Sub frmQcGraph_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        _gFrmMain.cmdZoom.Enabled = Not _gIsOperating
    End Sub

    Private Sub frmQcGraph_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        _gFrmMain.cmdZoom.Enabled = False
    End Sub

    Private Sub frmQcGraph_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing And _programClose = False Then
            e.Cancel = True
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub frmQcGraph_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Hourglass.Show()
        Dim go = _gGraphOptionsCollection(_graphIndex)
        If go.xAxisOptions.UseTimeScale Then
            _qcGraph = timeGraph
            pnlTimeGraph.Visible = True
            AddHandler timeGraph.GraphDataLimitReached, AddressOf GraphDataLimitReached
            _qcGraph.Initialize(_graphIndex)
        Else
            pnlLinearXGraph.Visible = True
            _qcGraph = linearGraph
            _qcGraph.Initialize(_graphIndex)
            _qcGraph.LoadTargetCurveForPart("Part001")
        End If
        _qcGraph.SetZoomEnabled(_zoomEnabled)

        SetControlStates()
        '
        'mouse handling
        '
        AddMouseHandlerRecursive(Me)
        Hourglass.Release()
    End Sub

    Public Sub StartReadingSensors() Implements ISensorForm.StartReadingSensors
        If _qcGraph IsNot Nothing Then
            _qcGraph.Initialize(_graphIndex)
            _qcGraph.StartReadingSensors()
        End If
    End Sub
    Public Sub ResumeReadingSensors() Implements ISensorForm.ResumeReadingSensors
        If _qcGraph IsNot Nothing Then
            _qcGraph.ResumeReadingSensors()
        End If
    End Sub
    Public Sub StopReadingSensors() Implements ISensorForm.StopReadingSensors
        If _qcGraph IsNot Nothing Then
            _qcGraph.StopReadingSensors()
        End If
    End Sub
    Public Sub TareSensors(ByVal unitType As Units.Enum_UNIT_TYPE) Implements ISensorForm.TareSensors
        'not valid
        'only valid for real sensors
    End Sub
    Public Function GetWindowType() As String Implements ISensorForm.GetWindowType
        Return "graph"
    End Function

    Private Sub CopyToClipboardToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CopyToClipboardToolStripMenuItem.Click, mnuCopyGraph2.Click
        Dim oldState = Me.WindowState
        Me.WindowState = FormWindowState.Maximized
        _qcGraph.CopyToClipboard()
        Me.WindowState = oldState
    End Sub

    Private Sub PrintGraphToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrintGraphToolStripMenuItem.Click, mnuPrintGraph2.Click
        _qcGraph.PrintChart()
    End Sub

    Private Sub mnuGraphOptions2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuGraphOptions2.Click, mnuGraphOptions.Click
        _gFrmMain.mnuGraphOptions.PerformClick()
    End Sub
    Public Sub SetControlStates() Implements ISensorForm.SetControlStates

        If _gIsOperating OrElse _zoomEnabled Then
            linearGraph.ContextMenuStrip = Nothing
            timeGraph.ContextMenuStrip = Nothing
        Else
            linearGraph.ContextMenuStrip = mnuContextGraphHdr
            timeGraph.ContextMenuStrip = mnuContextGraphHdr
        End If
    End Sub

    Private Sub cmdZoom_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        _zoomEnabled = CType(sender, ToolStripButton).Checked
        _qcGraph.SetZoomEnabled(_zoomEnabled)
        SetControlStates()
    End Sub
    Private Sub GraphDataLimitReached(ByVal sensor As LsSensor, ByVal nPoints As UInteger)
        If ConfigXml.Instance.graphLimitNoOfPointsReachedShowWarning Then
            CheckForIllegalCrossThreadCalls = False
            _gFrmMain.cmdStop.PerformClick()
            CheckForIllegalCrossThreadCalls = True
            Utility.ShowWarningMessage(String.Format("Limit of {0} points reached for graphing {1}. Use Graph Logged Readings Only option if you want to graph for a longer period.", nPoints, sensor.SS1))
        End If
    End Sub
    Public Sub ResetPeakLow1() Implements ISensorForm.ResetPeakLow
    End Sub

    Public Sub SaveWindowLocation() Implements ISensorForm.SaveWindowLocation
        WindowLayout.Instance.SaveWindowLocation(Me, Me.WindowTagToSave)
    End Sub
    Private _programClose As Boolean = False
    Public WriteOnly Property ProgramClose As Boolean Implements ISensorForm.ProgramClose
        Set(value As Boolean)
            _programClose = value
        End Set
    End Property

    Public Sub RestoreWindowLocation() Implements ISensorForm.RestoreWindowLocation
        WindowLayout.Instance.RestoreWindowLocation(Me, Me.WindowTagToSave)
    End Sub
    Private Sub AddMouseHandlerRecursive(ByVal parent As Control)
        AddHandler parent.MouseDown, AddressOf MouseHandler
        For Each ctl As Control In parent.Controls
            AddMouseHandlerRecursive(ctl)
        Next
    End Sub
    Private Sub MouseHandler(sender As Object, e As MouseEventArgs)
        Me.BringToFront()
    End Sub

    Public ReadOnly Property WindowTagToSave As String Implements ISensorForm.WindowTagToSave
        Get
            Return "graph" & _graphIndex
        End Get
    End Property


End Class