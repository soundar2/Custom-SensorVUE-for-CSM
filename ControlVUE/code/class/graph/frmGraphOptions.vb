Option Compare Text
Imports System.IO
Imports System.Xml.Serialization
Imports com.loadstar.utility.Utility
Public Class frmGraphOptions
    Private _currentGraphIndex As Integer = 0
    Private _prevGraphIndex As Integer = 0
    Private _isFormLoading As Boolean = True
    Private Shared _xmlFile As String = _gConfigFolder & "\graph.xml"
    Private Sub frmGraphOptions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            If IsOkToSave() Then
                SaveGraphOptions(_currentGraphIndex)
                WriteGraphOptionsToFile()
                ConfigXml.Instance.WriteConfiguration()
            Else
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub frmGraphOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _isFormLoading = True
        TreeView1.Nodes.Clear()
        ReadGraphOptionsFromFile()
        If _gGraphOptionsCollection.Count = 0 Then
            Dim go As New GraphOptions
            go.showGrid = True
            go.showTitle = False
            go.xAxisOptions.UseTimeScale = True
            _gGraphOptionsCollection.Add(go)
        End If
        RePopulateGraphs()
        If My.Application.Info.ProductName.Contains("LV-1000") OrElse My.Application.Info.ProductName.Contains("LV-4000") Then
            cmdNew.Visible = False
            cmdDelete.Visible = False
            optXUseSensor.Visible = False
            pnlXsensor.Visible = False
        End If
        UpdateSelectAllCheckbox(chkSelectAllY1, dgvY1AxisSensors)
        UpdateSelectAllCheckbox(chkSelectAllY2, dgvY2AxisSensors)
        _isFormLoading = False
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub dgvYAxisSensors_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvY1AxisSensors.CellContentClick, dgvY2AxisSensors.CellContentClick
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If TypeOf dgv.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then
            ' Commit the edit to update the value immediately
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        Dim sacb As CheckBox
        If dgv.Name.Contains("Y1") Then
            sacb = chkSelectAllY1
        Else
            sacb = chkSelectAllY2
        End If
        If (e.RowIndex < 0 OrElse e.ColumnIndex < 0) Then Return
        If dgv.Columns(e.ColumnIndex).Name.Contains("cmdColor") Then
            Dim currentColor As Color = dgv.Rows(e.RowIndex).Cells(e.ColumnIndex - 1).Style.BackColor
            Dim colorDlg As New ColorDialog
            With colorDlg
                .Color = currentColor
                .FullOpen = True
                .AnyColor = True
                .AllowFullOpen = True
                .SolidColorOnly = False
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgv.Rows(e.RowIndex).Cells(e.ColumnIndex - 1).Style.BackColor = .Color
                End If
            End With
        ElseIf e.ColumnIndex = 0 Then
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
            UpdateSelectAllCheckbox(sacb, dgv)
        End If
    End Sub
    Private Sub UpdateSelectAllCheckbox(ByVal cb As CheckBox, ByVal dgv As DataGridView)
        Dim dgvRows = dgv.Rows.Cast(Of DataGridViewRow).ToList()
        cb.ThreeState = True
        Dim allSelected = dgvRows.Count = (From r In dgvRows Where r.Cells(0).Value = True).Count
        Dim noneSelected = dgvRows.Count = (From r In dgvRows Where r.Cells(0).Value = False).Count
        If allSelected Then
            cb.CheckState = CheckState.Checked
        ElseIf noneSelected Then
            cb.CheckState = CheckState.Unchecked
        Else
            cb.CheckState = CheckState.Indeterminate
        End If
    End Sub
    'Private Function AddDefaultGraph() As GraphOptions
    '    Dim go As New GraphOptions
    '    go.xAxisOptions.UseTimeScale = True
    '    go.xAxisOptions.title = "Time (sec)"
    '    go.xAxisOptions.cumulative = False
    '    Dim series As New YAxisSeries
    '    series.ss1 = _gAttachedSensors(0).SS1
    '    series.lineColor = Color.Black.ToArgb
    '    go.y1AxisOptions.SeriesCollection.Add(series)
    '    go.y1AxisOptions.title = _gAttachedSensors(0).DeviceUnitType.ToString
    '    go.Title = series.ss1 & " vs " & "Time"
    '    go.showGrid = True
    '    go.showLegend = True
    '    Return go
    'End Function
    Private Sub SetControlStates()
        pnlTime.Enabled = optTimeAxis.Checked
        txtTimeRange.Enabled = pnlTime.Enabled AndAlso optScrolling.Checked
        txtAutoTruncateCountScrolling.Enabled = txtTimeRange.Enabled
        pnlXsensor.Enabled = optXUseSensor.Checked
        grpXManual.Enabled = optXManual.Checked
        grpY1Manual.Enabled = optY1Manual.Checked
        grpY2Manual.Enabled = optY2Manual.Checked
    End Sub

    Private Sub optCumulative_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCumulative.Click, optScrolling.Click, optXUseSensor.Click, optTimeAxis.Click, optXManual.Click, optAutoX.Click, optAutoY1.Click, optY1Manual.Click, optAutoY2.Click, optY2Manual.Click
        SetControlStates()
    End Sub
    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        If IsOkToSave() Then
            Dim go = GraphOptionsCollection.GetDefaultGraph()
            _gGraphOptionsCollection.Add(go)
            TreeView1.Nodes.Add(go.Title)
            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Tag = TreeView1.Nodes.Count - 1
            TreeView1.SelectedNode = TreeView1.Nodes(TreeView1.Nodes.Count - 1)
        End If
    End Sub

    Private Sub LoadGraphOptions(ByVal graphIndex As Integer)
        ClearControls(Me.TabControl1)
        Dim go = _gGraphOptionsCollection(graphIndex)
        'general
        txtTitle.Text = go.Title
        udTitleFontSize.Value = go.titleFontSize
        udLabelFontSize.Value = go.labelFontSize
        chkShowLegend.Checked = go.showLegend
        chkShowGrid.Checked = go.showGrid
        chkShowTitle.Checked = go.showTitle
        chkShowMinorGrid.Checked = go.showMinorGrid
        chkBlackBackground.Checked = ConfigXml.Instance.graphBlackBackground
        txtAutoTruncateCountCumulative.Text = Math.Max(1000, ConfigXml.Instance.graphCumulativeTruncateNPoint)
        txtAutoTruncateCountScrolling.Text = Math.Max(1000, ConfigXml.Instance.graphScrollingTruncateNPoint)
        chkEnableGraph.Checked = go.graphEnabled
        'x axis options
        optTimeAxis.Checked = go.xAxisOptions.UseTimeScale
        optXUseSensor.Checked = Not go.xAxisOptions.UseTimeScale
        optScrolling.Checked = Not go.xAxisOptions.cumulative
        optCumulative.Checked = go.xAxisOptions.cumulative
        txtTimeRange.Text = go.xAxisOptions.TimeRangeSec.ToString("0")
        optAutoX.Checked = go.xAxisOptions.autoScale
        optXManual.Checked = Not go.xAxisOptions.autoScale
        txtXMin.Text = go.xAxisOptions.XMin
        txtXMax.Text = go.xAxisOptions.XMax
        txtXTitle.Text = go.xAxisOptions.title
        For Each s In (From sen In _gAttachedSensors Where TryCast(sen, DerivedSensor) Is Nothing AndAlso TryCast(sen, PunchCompletedSensor) Is Nothing Select sen).ToList
            If s.Units.UnitType = Units.Enum_UNIT_TYPE.relay Then Continue For
            lstXAxisSensors.Items.Add(s.SS1)
            If s.SS1 = go.xAxisOptions.SS1 Then
                lstXAxisSensors.SelectedIndex = lstXAxisSensors.Items.Count - 1
            End If
            If lstXAxisSensors.SelectedIndex < 0 Then lstXAxisSensors.SelectedIndex = 0
        Next
        'y axis
        optAutoY1.Checked = go.y1AxisOptions.autoScale
        optY1Manual.Checked = Not go.y1AxisOptions.autoScale
        txtY1Max.Text = go.y1AxisOptions.YMax
        txtY1Min.Text = go.y1AxisOptions.YMin
        txtY1Title.Text = go.y1AxisOptions.title
        optAutoY2.Checked = go.y2AxisOptions.autoScale
        optY2Manual.Checked = Not go.y2AxisOptions.autoScale
        txtY2Max.Text = go.y2AxisOptions.YMax
        txtY2Min.Text = go.y2AxisOptions.YMin
        txtY2Title.Text = go.y2AxisOptions.title

        ' Dim graphSensors = (From item In _gAttachedSensors Where item.UnitType <> Units.Enum_UNIT_TYPE.relay AndAlso TryCast(item, PunchCompletedSensor) Is Nothing Select item).ToList
        Dim graphSensors = (From item In _gAttachedSensors Where TryCast(item, PunchCompletedSensor) Is Nothing Select item).ToList

        For Each s In graphSensors
            Dim ss1 As String = s.SS1
            With dgvY1AxisSensors
                .Rows.Add()
                Dim index = .Rows.Count - 1
                .Rows(index).Cells("y1Check").Value = False
                .Rows(index).Cells("y1ss1").Value = s.SS1
                .Rows(index).Cells("y1Type").Value = s.UnitType.ToString
                .Rows(index).Cells("y1Color").Style.BackColor = Color.Black
                .Rows(index).Cells("y1cmdColor").Value = "Select Color"
                '
                PopulateLineStyles(.Rows(index).Cells("y1LineStyle"))
                PopulateMarkerStyles(.Rows(index).Cells("y1MarkerStyle"))
                PopulateLineWidths(.Rows(index).Cells("y1LineWidth"))
                PopulateSymbolSizes(.Rows(index).Cells("y1MarkerSize"))

                'is this sensor to be used for this graph
                Dim series = (From item In go.y1AxisOptions.SeriesCollection Where item.ss1 = ss1 Select item).SingleOrDefault
                If series IsNot Nothing Then
                    Try
                        .Rows(index).Cells("y1Check").Value = True
                        .Rows(index).Cells("y1Color").Style.BackColor = Color.FromArgb(series.lineColor)
                        .Rows(index).Cells("y1LineStyle").Value = series.lineStyle
                        .Rows(index).Cells("y1LineWidth").Value = series.lineWidth.ToString("0")
                        .Rows(index).Cells("y1MarkerStyle").Value = series.markerStyle
                        .Rows(index).Cells("y1MarkerSize").Value = series.markerSize.ToString("0")
                    Catch
                    End Try
                Else
                    .Rows(index).Cells("y1Color").Style.BackColor = GraphTheme.GetDefaultColor(index)
                End If
            End With
            With dgvY2AxisSensors
                .Rows.Add()
                Dim index = .Rows.Count - 1
                .Rows(index).Cells("y2Check").Value = False
                .Rows(index).Cells("y2ss1").Value = s.SS1
                .Rows(index).Cells("y2Type").Value = s.UnitType.ToString
                .Rows(index).Cells("y2Color").Style.BackColor = Color.Black
                .Rows(index).Cells("y2cmdColor").Value = "Select Color"
                '
                PopulateLineStyles(.Rows(index).Cells("y2LineStyle"))
                PopulateMarkerStyles(.Rows(index).Cells("y2MarkerStyle"))
                PopulateLineWidths(.Rows(index).Cells("y2LineWidth"))
                PopulateSymbolSizes(.Rows(index).Cells("y2MarkerSize"))

                'is this sensor to be used for this graph
                Dim series = (From item In go.y2AxisOptions.SeriesCollection Where item.ss1 = ss1 Select item).SingleOrDefault
                If series IsNot Nothing Then
                    Try
                        .Rows(index).Cells("y2Check").Value = True
                        .Rows(index).Cells("y2Color").Style.BackColor = Color.FromArgb(series.lineColor)
                        .Rows(index).Cells("y2LineStyle").Value = series.lineStyle
                        .Rows(index).Cells("y2LineWidth").Value = series.lineWidth.ToString("0")
                        .Rows(index).Cells("y2MarkerStyle").Value = series.markerStyle
                        .Rows(index).Cells("y2MarkerSize").Value = series.markerSize.ToString("0")
                    Catch
                    End Try
                Else
                    .Rows(index).Cells("y2Color").Style.BackColor = GraphTheme.GetDefaultColor(index)
                End If
            End With
        Next
        SetControlStates()
    End Sub
    Private Sub SaveGraphOptions(ByVal index As Integer)
        Dim go = _gGraphOptionsCollection(index)
        'general
        go.Title = txtTitle.Text.Trim
        go.showTitle = chkShowTitle.Checked
        go.titleFontSize = udTitleFontSize.Value
        go.labelFontSize = udLabelFontSize.Value
        go.showLegend = chkShowLegend.Checked
        go.showGrid = chkShowGrid.Checked
        go.showMinorGrid = chkShowMinorGrid.Checked
        ConfigXml.Instance.graphBlackBackground = chkBlackBackground.Checked
        ConfigXml.Instance.graphCumulativeTruncateNPoint = Math.Max(1000, Val(txtAutoTruncateCountCumulative.Text))
        ConfigXml.Instance.graphScrollingTruncateNPoint = Math.Max(1000, Val(txtAutoTruncateCountScrolling.Text))
        go.graphEnabled = chkEnableGraph.Checked
        'x axis options
        go.xAxisOptions.UseTimeScale = optTimeAxis.Checked
        go.xAxisOptions.cumulative = optCumulative.Checked
        go.xAxisOptions.TimeRangeSec = Math.Max(1, Val(txtTimeRange.Text))
        go.xAxisOptions.autoScale = optAutoX.Checked
        go.xAxisOptions.XMin = txtXMin.Text
        go.xAxisOptions.XMax = txtXMax.Text
        go.xAxisOptions.title = txtXTitle.Text.Trim
        If lstXAxisSensors.SelectedIndex <> -1 Then
            go.xAxisOptions.SS1 = lstXAxisSensors.Text
        End If

        'y axis
        go.y1AxisOptions.SeriesCollection.Clear()
        go.y1AxisOptions.autoScale = optAutoY1.Checked
        go.y1AxisOptions.YMax = Val(txtY1Max.Text)
        go.y1AxisOptions.YMin = Val(txtY1Min.Text)
        go.y1AxisOptions.title = txtY1Title.Text.Trim
        go.y2AxisOptions.SeriesCollection.Clear()
        go.y2AxisOptions.autoScale = optAutoY2.Checked
        go.y2AxisOptions.YMax = Val(txtY2Max.Text)
        go.y2AxisOptions.YMin = Val(txtY2Min.Text)
        go.y2AxisOptions.title = txtY2Title.Text.Trim
        With dgvY1AxisSensors
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Cells(0).Value = True Then
                    Dim series As New YAxisSeries
                    series.ss1 = .Rows(i).Cells("y1Ss1").Value
                    series.lineColor = .Rows(i).Cells("y1Color").Style.BackColor.ToArgb
                    series.lineStyle = .Rows(i).Cells("y1LineStyle").Value
                    series.lineWidth = Val(.Rows(i).Cells("y1LineWidth").Value)
                    series.markerStyle = .Rows(i).Cells("y1MarkerStyle").Value
                    series.markerSize = Val(.Rows(i).Cells("y1MarkerSize").Value)
                    go.y1AxisOptions.SeriesCollection.Add(series)
                End If
            Next
        End With
        With dgvY2AxisSensors
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Cells(0).Value = True Then
                    Dim series As New YAxisSeries
                    series.ss1 = .Rows(i).Cells("y2Ss1").Value
                    series.lineColor = .Rows(i).Cells("y2Color").Style.BackColor.ToArgb
                    series.lineStyle = .Rows(i).Cells("y2LineStyle").Value
                    series.lineWidth = Val(.Rows(i).Cells("y2LineWidth").Value)
                    series.markerStyle = .Rows(i).Cells("y2MarkerStyle").Value
                    series.markerSize = Val(.Rows(i).Cells("y2MarkerSize").Value)
                    go.y2AxisOptions.SeriesCollection.Add(series)
                End If
            Next
        End With
    End Sub
    Private Sub ClearControls(ByVal c As Control)
        If TryCast(c, RadioButton) IsNot Nothing Then
            CType(c, RadioButton).Checked = False
        ElseIf TryCast(c, ListBox) IsNot Nothing Then
            CType(c, ListBox).Items.Clear()
        ElseIf TryCast(c, DataGridView) IsNot Nothing Then
            CType(c, DataGridView).Rows.Clear()
        ElseIf TryCast(c, CheckBox) IsNot Nothing Then
            CType(c, CheckBox).Checked = False
        ElseIf TryCast(c, TextBox) IsNot Nothing Then
            CType(c, TextBox).Clear()
        ElseIf c.Controls.Count <> 0 Then
            For i = 0 To c.Controls.Count - 1
                ClearControls(c.Controls(i))
            Next
        End If
    End Sub

    Private Function IsOkToSave() As Boolean
        Dim ret As Boolean = False
        If Me.txtTitle.Text.Trim.Length = 0 Then
            ShowErrorMessage("Enter a graph title")
            Return False
        End If
        Dim y1CheckedRows = dgvY1AxisSensors.Rows.Cast(Of DataGridViewRow)().Where(Function(row) row.Cells(0).Value = True)
        Dim y2CheckedRows = dgvY2AxisSensors.Rows.Cast(Of DataGridViewRow)().Where(Function(row) row.Cells(0).Value = True)
        Dim y1SensorNames = (From row In y1CheckedRows Select row.Cells("y1SS1").Value).ToList
        Dim y2SensorNames = (From row In y2CheckedRows Select row.Cells("y2SS1").Value).ToList


        If y1CheckedRows.Count = 0 Then
            ShowErrorMessage("Must select at least one sensor for Y1 axis")
            Return False
        ElseIf txtY1Title.Text.Length = 0 Then
            ShowErrorMessage("Enter a title for the Y2 axis")
            Return False
        ElseIf y2CheckedRows.Count <> 0 Then
            'is the same sensor checked in y1 and y2
            If y1SensorNames.Intersect(y2SensorNames).Any Then
                'If (From s1 In y1SensorNames Where (From s2 In y2SensorNames Select s2).Contains(s1) Select s1).Any() Then
                ShowErrorMessage("Same sensor cannot be chosen for Y1 and Y2 axes.")
                Return False
            ElseIf txtY2Title.Text.Length = 0 Then
                ShowErrorMessage("Enter a title for the Y2 axis")
                Return False
            End If
        End If
        '
        'if x axis is time and scrolling range is checked, the time cannot be zero
        '
        If optTimeAxis.Checked AndAlso optScrolling.Checked AndAlso Val(txtTimeRange.Text) = 0 Then
            ShowErrorMessage("Enter a valid x Axis time range")
            Return False
        End If

        'if x axis is not time, then the sensor selected must not be in y1 or y2
        If optXUseSensor.Checked Then
            If txtXTitle.Text.Trim.Length = 0 Then
                ShowErrorMessage("Enter a title for the X-Axis.") : Return False
            End If
            Dim xSensorName = lstXAxisSensors.SelectedItem
            If y1SensorNames.Contains(xSensorName) OrElse y2SensorNames.Contains(xSensorName) Then
                ShowErrorMessage("Selected sensor for X Axis cannot be in Y1 or Y2 Axes.")
                Return False
            End If
        End If

        'is max > min
        If (optXManual.Checked AndAlso Val(txtXMax.Text) <= Val(txtXMin.Text)) OrElse
            (optY1Manual.Checked AndAlso Val(txtY1Max.Text) <= Val(txtY1Min.Text)) OrElse
            (y2SensorNames.Count > 0 AndAlso optY2Manual.Checked AndAlso Val(txtY2Max.Text) <= Val(txtY2Min.Text)) _
            Then
            MsgBox("Maximum should be > Minimum", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation) : Return False
        End If

        'both line style and marker should not be "None"
        If (From r1 In y1CheckedRows Where (r1.Cells("y1LineStyle").Value = "None" AndAlso r1.Cells("y1MarkerStyle").Value = "None")).Union(From r2 In y2CheckedRows Where (r2.Cells("y2LineStyle").Value = "None" AndAlso r2.Cells("y2MarkerStyle").Value = "None")).Any Then
            ShowErrorMessage("Graph should have either a Line Style or a Marker Style set") : Return False
        End If
        Return True
    End Function
    Public Shared Sub ReadGraphOptionsFromFile()


        If My.Computer.FileSystem.FileExists(_xmlFile) Then
            _gGraphOptionsCollection.Clear()
            Try
                Using sr As New StreamReader(_xmlFile)
                    Dim x As New XmlSerializer(_gGraphOptionsCollection.GetType)
                    _gGraphOptionsCollection = x.Deserialize(sr)
                End Using
            Catch ex As Exception
            Finally
            End Try
        End If
        RemoveInvalidGraphs()
        If Not _gGraphOptionsCollection.Any Then
            'no graph has been defined, add a default graph
            _gGraphOptionsCollection.Add(GraphOptionsCollection.GetDefaultGraph())
            frmGraphOptions.WriteGraphOptionsToFile()
        End If
    End Sub
    Private Shared Sub WriteGraphOptionsToFile()
        Try
            Using sw = New StreamWriter(_xmlFile)
                Dim st As New XmlSerializer(_gGraphOptionsCollection.GetType)
                st.Serialize(sw, _gGraphOptionsCollection)
            End Using
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

    End Sub
    Private Shared Sub RemoveInvalidGraphs()
        Dim existingSensorsList = (From s In _gAttachedSensors Select s.SS1).ToList
        For i = _gGraphOptionsCollection.Count - 1 To 0 Step -1
            Dim g = _gGraphOptionsCollection(i)
            If g.Ss1List.Except(existingSensorsList).Any() Then
                ' g's sensors are NOT a subset of existingSensorList
                'see http://stackoverflow.com/questions/332973/check-whether-an-array-is-a-subset-of-another
                _gGraphOptionsCollection.RemoveAt(i)
            End If
        Next
    End Sub
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        With TreeView1
            If .Nodes.Count = 1 Then
                ShowErrorMessage("Please edit this graph. There must be at least be one graph.")
            ElseIf .Nodes.Count > 1 Then
                If MsgBox("Ok to delete?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) = MsgBoxResult.Ok Then
                    Dim nodeIndexToDelete = Convert.ToInt16(.SelectedNode.Tag)
                    _gGraphOptionsCollection.RemoveAt(nodeIndexToDelete)
                    WriteGraphOptionsToFile()
                    _isFormLoading = True
                    TreeView1.Nodes.Clear()
                    ReadGraphOptionsFromFile()
                    RePopulateGraphs()
                    _isFormLoading = False
                Else
                    Return
                End If
            End If
        End With
    End Sub
    Private Sub RePopulateGraphs()
        TreeView1.Nodes.Clear()
        For i = 0 To _gGraphOptionsCollection.Count - 1
            TreeView1.Nodes.Add(_gGraphOptionsCollection(i).Title)
            TreeView1.Nodes(i).Tag = i
        Next
        TreeView1.SelectedNode = TreeView1.Nodes(0)
    End Sub
    Private Sub PopulateLineStyles(ByVal dgcc As DataGridViewComboBoxCell)
        dgcc.Items.Add("Solid")
        dgcc.Items.Add("Dashed")
        dgcc.Items.Add("None")
        dgcc.Value = dgcc.Items(0).ToString
    End Sub
    Private Sub PopulateMarkerStyles(ByVal dgcc As DataGridViewComboBoxCell)
        dgcc.Items.Add("None")
        dgcc.Items.Add("Square")
        dgcc.Items.Add("Circle")
        dgcc.Items.Add("Diamond")
        dgcc.Items.Add("Cross")
        dgcc.Items.Add("Plus")
        dgcc.Value = dgcc.Items(0).ToString
    End Sub
    Private Sub PopulateLineWidths(ByVal dgcc As DataGridViewComboBoxCell)
        dgcc.Items.Add("1")
        dgcc.Items.Add("2")
        dgcc.Items.Add("3")
        dgcc.Items.Add("4")
        dgcc.Value = dgcc.Items(1).ToString
    End Sub
    Private Sub PopulateSymbolSizes(ByVal dgcc As DataGridViewComboBoxCell)
        dgcc.Items.Add("5")
        dgcc.Items.Add("7")
        dgcc.Items.Add("10")
        dgcc.Items.Add("15")
        dgcc.Value = dgcc.Items(0).ToString
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        _currentGraphIndex = Val(TreeView1.SelectedNode.Tag)
        LoadGraphOptions(_currentGraphIndex)
    End Sub

    Private Sub TreeView1_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeSelect
        If Not _isFormLoading Then
            If Not IsOkToSave() Then
                e.Cancel = True
            Else
                SaveGraphOptions(_currentGraphIndex)
            End If
        End If
    End Sub

    Private Sub dgvY1AxisSensors_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvY1AxisSensors.DataError, dgvY2AxisSensors.DataError
        'MsgBox(CType(sender, DataGridView).Name)
        'MsgBox(e.RowIndex)
        'MsgBox(e.ColumnIndex)
    End Sub

    Private Sub txtTitle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTitle.TextChanged
        If Not _isFormLoading Then
            TreeView1.SelectedNode.Text = txtTitle.Text.Trim
        End If
    End Sub

    Private Sub chkSelectAllY1_click(sender As Object, e As EventArgs) Handles chkSelectAllY1.Click, chkSelectAllY2.Click
        Dim cb = CType(sender, CheckBox)
        Dim dgv As DataGridView
        If cb.Name.Contains("Y1") Then
            dgv = dgvY1AxisSensors
        Else
            dgv = dgvY2AxisSensors
        End If
        Select Case cb.CheckState
            Case CheckState.Checked
                For i = 0 To dgv.Rows.Count - 1
                    dgv.Rows(i).Cells(0).Value = True
                Next
            Case CheckState.Unchecked
                For i = 0 To dgv.Rows.Count - 1
                    dgv.Rows(i).Cells(0).Value = False
                Next
        End Select
    End Sub
End Class