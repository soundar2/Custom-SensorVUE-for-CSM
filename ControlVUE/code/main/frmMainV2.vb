Option Infer On
Imports System.Threading
Imports com.loadstar.utility.Utility
Imports com.loadstar.utility
Public Class frmMainV2
    Implements IMainForm

    Private _layoutFile As String = _gConfigFolder & "\layout.xml"
    Private _frmLog As frmLog
    Private _frmRelay As frmRelay
    Private _frmGraphs As New List(Of frmQcGraph)
    Private _frmPunchForce As frmPunchForce
    Private _isOkToResume As Boolean = False
    Private _context As WindowsFormsSynchronizationContext = WindowsFormsSynchronizationContext.Current
    Private Sub frmMainV2_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Static firstTime As Boolean = True
        If firstTime Then
            firstTime = False
            ShowUnits()
            If clsGlobals._gAutoStart = True Then
                cmdStart.PerformClick()
            End If
        End If

    End Sub
    Private Sub frmMainV2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _gIsOperating Then
            cmdStop.PerformClick()
        End If
        ConfigXml.Instance.WriteConfiguration()
    End Sub
    Private Sub frmMainV2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Hourglass.Show()
        Me.Text = clsGlobals.GetProductNameAndVersion
        lblWifiLogo.Visible = _gUseWifi
        mnuAboutLoadVUE.Text = "&About " & My.Application.Info.ProductName
        '
        ToolStripManager.VisualStylesEnabled = True
        '
        Dim forceSensors As List(Of LsSensor) = (From item In _gAttachedSensors Where item.Units.UnitType = Units.Enum_UNIT_TYPE.force AndAlso Not (TypeOf item Is PunchForceSensor) AndAlso Not (TypeOf item Is PunchCompletedSensor) AndAlso TryCast(item, FilterSensor) Is Nothing Select item).ToList
        If forceSensors.Any Then
            For Each s In forceSensors
                s.Units.OutputUnits = ConfigXml.Instance.forceOutputUnits
                Dim frm = New frmSensorCtl(s)
                frm.Show()
            Next
        End If
        '
        'Length
        '
        Dim lengthSensors As List(Of LsSensor) = (From item In _gAttachedSensors Where item.Units.UnitType = Units.Enum_UNIT_TYPE.length AndAlso TryCast(item, FilterSensor) Is Nothing Select item).ToList

        If lengthSensors.Any Then
            For Each s In lengthSensors
                s.Units.OutputUnits = ConfigXml.Instance.lengthOutputUnits
                Dim frm = New frmSensorCtl(s)
                frm.Show()
            Next
        End If
        '
        'Pressure
        '
        Dim pressureSensors As List(Of LsSensor) = (From item In _gAttachedSensors Where item.Units.UnitType = Units.Enum_UNIT_TYPE.pressure AndAlso TryCast(item, FilterSensor) Is Nothing Select item).ToList
        If pressureSensors.Any Then
            For Each s In pressureSensors
                s.Units.OutputUnits = ConfigXml.Instance.pressureOutputUnits
                Dim frm = New frmSensorCtl(s)
                frm.Show()
            Next
        End If
        '
        ' Torque
        '
        Dim torqueSensors As List(Of LsSensor) = (From item In _gAttachedSensors Where item.Units.UnitType = Units.Enum_UNIT_TYPE.torque AndAlso TryCast(item, FilterSensor) Is Nothing Select item).ToList
        If torqueSensors.Any Then
            For Each s In torqueSensors
                s.Units.OutputUnits = ConfigXml.Instance.torqueOutputUnits
                Dim frm = New frmSensorCtl(s)
                frm.Show()
            Next
        End If
        '
        'Voltage
        '
        Dim voltageSensors As List(Of LsSensor) = (From item In _gAttachedSensors Where item.Units.UnitType = Units.Enum_UNIT_TYPE.voltage AndAlso TryCast(item, FilterSensor) Is Nothing Select item).ToList
        If voltageSensors.Any Then
            For Each s In voltageSensors
                s.Units.OutputUnits = ConfigXml.Instance.voltageOutputUnits
                Dim frm = New frmSensorCtl(s)
                frm.Show()
            Next
        End If
        '
        'Temperature
        '
        Dim temperatureSensors As List(Of LsSensor) = (From item In _gAttachedSensors Where item.Units.UnitType = Units.Enum_UNIT_TYPE.temperature AndAlso TryCast(item, FilterSensor) Is Nothing Select item).ToList
        If temperatureSensors.Any Then
            For Each s In temperatureSensors
                s.Units.OutputUnits = ConfigXml.Instance.temperatureOutputUnits
                Dim frm = New frmSensorCtl(s)
                frm.Show()
            Next
        End If
        '
        '
        '
        Dim cmMotors As List(Of LsSensor) = (From item In _gAttachedSensors Where item.Units.UnitType = Units.Enum_UNIT_TYPE.angle Select item).ToList
        '
        Dim formulaSensors As List(Of LsSensor) = (From item In _gAttachedSensors Where item.DeviceUnitType = LsDevice.Enum_Device_Unit_Type.Formula Select item).ToList
        '
        If formulaSensors.Any Then
            For Each s In formulaSensors
                Dim frm = New frmSensorCtl(s)
                frm.Show()
            Next
        End If
        '
        '
        Dim filterSensors As List(Of FilterSensor) = (From item In _gAttachedSensors Where TryCast(item, FilterSensor) IsNot Nothing Select CType(item, FilterSensor)).ToList
        If filterSensors.Any Then
            For Each s In filterSensors
                Dim frm = New frmSensorCtl(s)
                frm.Show()
            Next
        End If
        '
        '
        ''
        'open log window
        '
        _frmLog = New frmLog
        _frmLog = New frmLog()
        _frmLog.Show()
        '
        '

        Dim punchForceSensors As List(Of LsSensor) = (From item In _gAttachedSensors Where TypeOf item Is PunchForceSensor Select item).ToList
        If punchForceSensors.Any Then
            _frmPunchForce = New frmPunchForce(punchForceSensors.First)
            _frmPunchForce.Show()
        End If

        Dim relays As List(Of RelayChannel) = (From item In _gAttachedSensors Where item.Units.UnitType = Units.Enum_UNIT_TYPE.relay Select CType(item, RelayChannel)).ToList
        If relays.Any Then
            _frmRelay = New frmRelay(relays)
            _frmRelay.Show()
        Else
            cmdRelay.Visible = False
        End If

        OpenGraphWindows(showByDefault:=True)
        '
        Me.WindowState = FormWindowState.Maximized

        SetControlStates()

        '
        'add disconnected event handler to sensors
        '
        For Each s In _gAttachedSensors
            RemoveHandler s.SensorStoppedResponding, AddressOf SensorIsDead
            AddHandler s.SensorStoppedResponding, AddressOf SensorIsDead
        Next

        'it is possible that some windows may not have been persisted
        'try to reopen all the windows

        AddHandler Microsoft.Win32.SystemEvents.DisplaySettingsChanged, AddressOf DetectScreenRotation
        WindowLayout.Instance.currentViewMode = WindowLayout.ENUM_ViewMode.mix
        ShowWindows()
        Hourglass.Release()
    End Sub

    Private Sub cmdStart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdStart.Click, mnuStart.Click
        Try
            If Not _frmLog.OkToUploadToCloud Then Return
            Hourglass.Show()
            If _frmLog.IsUploadingToCloud() Then
                If Not _frmLog.UploadSensorMetaData() Then Return
            End If

            clsGlobals._gStartTime = Now()
            clsGlobals._gTimeStampStopwatch = Stopwatch.StartNew
            _gIsOperating = True

            For Each frm In Me.MdiChildren
                CType(frm, ISensorForm).StartReadingSensors()
                CType(frm, ISensorForm).SetControlStates()
            Next

            For Each alarm In _gAlarms
                alarm.StartMonitoring()
            Next

            If _frmRelay IsNot Nothing Then
                _frmRelay.StartReadingSensors()
            End If
            SetControlStates()
        Catch ex As Exception
        Finally
            Hourglass.Release(True)
        End Try
      
    End Sub

    Private Sub cmdStop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdStop.Click, mnuStop.Click
        Hourglass.Show()
        _gIsOperating = False
        _isOkToResume = True
        For Each frm In Me.MdiChildren
            CType(frm, ISensorForm).StopReadingSensors()
            CType(frm, ISensorForm).SetControlStates()
        Next
        For Each alarm In _gAlarms
            alarm.StopMonitoring()
        Next
        SetControlStates()
        Hourglass.Release(True)
    End Sub

    Private Sub mnuGraphOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuGraphOptions.Click

        Dim frm As New frmGraphOptions
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim frms = (From item In Me.MdiChildren Where CType(item, ISensorForm).GetWindowType() = "graph" Select item).ToArray
            For i = frms.Count - 1 To 0 Step -1
                CType(frms(i), ISensorForm).ProgramClose = True
                frms(i).Close()
            Next
            OpenGraphWindows(True)
            ShowWindows()
        End If
    End Sub
    Private Sub OpenGraphWindows(ByVal showByDefault As Boolean)
        '
        'show graph windows'
        '
        'are there any graphs
        'read the graphcollections
        frmGraphOptions.ReadGraphOptionsFromFile()
        'if the sensors in the graphs collection are not connected
        'delete this graph

        _frmGraphs.Clear()
        For i = 0 To _gGraphOptionsCollection.Count - 1
            Dim options = _gGraphOptionsCollection(i)
            'collect all sensor names in y1axis and y2axis and, where it is not a time-graph, from x axis
            Dim sensorNamesInGraph = (From s1 In options.y1AxisOptions.SeriesCollection Select s1.ss1).Union(From s2 In options.y2AxisOptions.SeriesCollection Select s2.ss1).ToList
            If options.xAxisOptions.UseTimeScale = False AndAlso options.xAxisOptions.SS1.Length <> 0 Then
                sensorNamesInGraph.Add(options.xAxisOptions.SS1)
            End If
            'if any of these sensors is not present, the graph is not possible
            'dont open it
            Dim notPresent = (From s1 In sensorNamesInGraph Where Not (From s2 In _gAttachedSensors Select s2.SS1).Contains(s1) Select s1).ToList.Any
            If notPresent Then
                'we cannot open this graph
            Else
                Dim frm As New frmQcGraph(i)
                _frmGraphs.Add(frm)
                frm.Show()
            End If
        Next
    End Sub
    Private Sub CloseGraphWindows()
        For Each frm In _frmGraphs
            If frm IsNot Nothing Then
                frm.Close()
            End If
        Next
    End Sub
    Private Sub SetControlStates()
        mnuGraphHdr.Enabled = Not _gIsOperating
        mnuToolsHdr.Enabled = Not _gIsOperating
        cmdStart.Enabled = Not _gIsOperating
        cmdResume.Enabled = Not _gIsOperating AndAlso _isOkToResume
        mnuStart.Enabled = Not _gIsOperating
        cmdStop.Enabled = _gIsOperating
        mnuStop.Enabled = _gIsOperating
        cmdTare.Enabled = Not _gIsOperating
        cmdOptions.Enabled = Not _gIsOperating
        mnuAlarmSettings.Enabled = Not _gIsOperating

        mnuFilterSensors.Enabled = Not _gIsOperating
        mnuFormulaSensors.Enabled = Not _gIsOperating
        mnuSensorList.Enabled = Not _gIsOperating

        mnuPunchForceSensors.Enabled = Not _gIsOperating
        cmdZoom.Enabled = Not _gIsOperating
        If _gIsOperating Then
            cmdZoom.Checked = False
        End If


        If Not clsGlobals.IsRunningControlVue Then
            cmdResetAllRelays.Visible = False
            cmdTripAllRelays.Visible = False
        Else
            cmdResetAllRelays.Enabled = _frmRelay IsNot Nothing
            cmdTripAllRelays.Enabled = cmdResetAllRelays.Enabled
        End If
    End Sub




    Private Sub mnuAboutLoadVUE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAboutLoadVUE.Click
        Dim frm As New frmAbout
        frm.ShowDialog()
    End Sub

    Private Sub mnuGeneralOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOptions.Click
        cmdOptions.PerformClick()
    End Sub


    Private Sub mnuFormulaSensors_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormulaSensors.Click
        ConfigXml.RestartApplication = False
        Dim frm As New frmFormulaSensors
        frm.ShowDialog()
        If ConfigXml.RestartApplication = True Then
            Me.Close()
        End If
    End Sub
    Private Sub mnuAlarmSettings_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAlarmSettings.Click
        Dim frm As New frmAlarmSettings
        frm.ShowDialog()
    End Sub

    Private Sub mnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub mnuCalibrate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCalibrate.Click
        CalibrateLoadCell(Me)
    End Sub

    Private Sub mnuConfigfolder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuConfigfolder.Click
        System.Diagnostics.Process.Start(_gConfigFolder)
    End Sub
    Public Sub DetectScreenRotation(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim theScreenBounds As Rectangle
        theScreenBounds = Screen.GetBounds(Screen.PrimaryScreen.Bounds)

        If (theScreenBounds.Height > theScreenBounds.Width) Then
            'portrait mode
            Me.WindowState = FormWindowState.Normal
            Me.WindowState = FormWindowState.Maximized
        Else
            'landscape mode
            Me.WindowState = FormWindowState.Normal
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub


    Private Sub mnuWindowMessageLog_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblSensorList_Click(sender As Object, e As EventArgs) Handles lblSensorList.Click
        Dim frm As New frmSensorList
        frm.ShowDialog()
    End Sub

    Private Sub mnuPunchForceSensors_Click(sender As Object, e As EventArgs) Handles mnuPunchForceSensors.Click
        Dim frm As New frmPunchCounterOptions
        frm.ShowDialog()
        If ConfigXml.RestartApplication = True Then
            Me.Close()
        End If
    End Sub

    Private Sub mnuFilterSensors_Click(sender As Object, e As EventArgs) Handles mnuFilterSensors.Click
        ConfigXml.RestartApplication = False
        Dim frm As New frmFilterSensorSettings
        frm.ShowDialog()
        If ConfigXml.RestartApplication = True Then
            Me.Close()
        End If
    End Sub

    Private Sub mnuGraphLogFile_Click(sender As Object, e As EventArgs) Handles mnuGraphLogFile.Click
        Dim g As New ImportLogFiles.GraphLogFile
        g.ShowDialog()
    End Sub

    Private Sub mnuPuttyTerminal_Click(sender As Object, e As EventArgs) Handles mnuPuttyTerminal.Click
        clsGlobals.RunPutty()
    End Sub


#Region "implementsInterface"

    Public ReadOnly Property cmdStart1 As ToolStripButton Implements IMainForm.cmdStart
        Get
            Return Me.cmdStart
        End Get
    End Property

    Public ReadOnly Property cmdStop1 As ToolStripButton Implements IMainForm.cmdStop
        Get
            Return Me.cmdStop
        End Get
    End Property

    Public ReadOnly Property cmdZoom1 As ToolStripButton Implements IMainForm.cmdZoom
        Get
            Return Me.cmdZoom
        End Get
    End Property

    Public ReadOnly Property lblLogging1 As ToolStripLabel Implements IMainForm.lblLogging
        Get
            Return Me.lblLogging
        End Get
    End Property

    Public ReadOnly Property mnuGraphOptions1 As ToolStripMenuItem Implements IMainForm.mnuGraphOptions
        Get
            Return Me.mnuGraphOptions
        End Get
    End Property

    Public ReadOnly Property mnuRelaySettings1 As ToolStripMenuItem Implements IMainForm.mnuRelaySettings
        Get
            Return Me.mnuRelaySettings
        End Get
    End Property

    Public ReadOnly Property lblLogFileSize1 As ToolStripLabel Implements IMainForm.lblLogFileSize
        Get
            Return Me.lblLogFileSize
        End Get
    End Property

    Public ReadOnly Property mnuRelaySettings21 As ToolStripMenuItem Implements IMainForm.mnuRelaySettings2
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property cmdTare1 As ToolStripButton Implements IMainForm.cmdTare
        Get
            Throw New Exception("cmdTare.Get not valid here")
        End Get
    End Property
#End Region



    Private Sub cmdOptions_Click(sender As Object, e As EventArgs) Handles cmdOptions.Click
        Dim frm As New frmOptions
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each s In _gAttachedSensors
                If TryCast(s, DerivedSensor) Is Nothing Then
                    'this is a physical  sensor
                    s.sDisplayFormat = ConfigXml.Instance.lv100sDisplayFormat
                    Select Case s.Units.UnitType
                        Case Units.Enum_UNIT_TYPE.force
                            s.Units.OutputUnits = ConfigXml.Instance.forceOutputUnits
                        Case Units.Enum_UNIT_TYPE.length
                            s.Units.OutputUnits = ConfigXml.Instance.lengthOutputUnits
                        Case Units.Enum_UNIT_TYPE.pressure
                            s.Units.OutputUnits = ConfigXml.Instance.pressureOutputUnits
                        Case Units.Enum_UNIT_TYPE.temperature
                            s.Units.OutputUnits = ConfigXml.Instance.temperatureOutputUnits
                        Case Units.Enum_UNIT_TYPE.torque
                            s.Units.OutputUnits = ConfigXml.Instance.torqueOutputUnits
                        Case Units.Enum_UNIT_TYPE.voltage
                            s.Units.OutputUnits = ConfigXml.Instance.voltageOutputUnits
                    End Select
                End If

            Next
            ShowUnits()
        ElseIf frm.showGraphOptions Then
            mnuGraphOptions.PerformClick()
        ElseIf frm.showLogOptions Then
            Dim frmL As New frmLogOptions
            If frmL.ShowDialog() = Windows.Forms.DialogResult.OK Then

            End If
        ElseIf frm.showTextOptions Then
            Dim frmW As New frmWindowColors
            If frmW.ShowDialog() = Windows.Forms.DialogResult.OK Then
                For Each frmx In Me.MdiChildren
                    If TypeOf frmx Is frmSensorCtl Then
                        CType(frmx, frmSensorCtl).SetWindowOptions()
                    End If
                Next
            End If
        ElseIf frm.showRelayOptions Then
            Dim frmY As New frmRelaySettings
            frmY.ShowDialog()
        ElseIf frm.showPunchCounterOptions Then
            Dim frmPC As New frmPunchCounterOptions
            frmPC.ShowDialog()
        End If
    End Sub
    Private Sub ShowUnits()
    End Sub
    Private Sub cmdResetPeakLow_Click(sender As Object, e As EventArgs) Handles cmdResetPeakLow.Click
        For Each x In Me.MdiChildren
            If TryCast(x, ISensorForm) IsNot Nothing Then
                CType(x, ISensorForm).ResetPeakLow()
            End If
        Next
    End Sub


    Private Sub cmdTextView_Click(sender As Object, e As EventArgs) Handles cmdTextView.Click
        WindowLayout.Instance.currentViewMode = WindowLayout.ENUM_ViewMode.text
        ShowWindows()
    End Sub

    Private Sub cmdLog_Click(sender As Object, e As EventArgs) Handles cmdLogView.Click
        WindowLayout.Instance.currentViewMode = WindowLayout.ENUM_ViewMode.log
        ShowWindows()
    End Sub

    Private Sub cmdPlot_Click(sender As Object, e As EventArgs) Handles cmdPlotView.Click
        WindowLayout.Instance.currentViewMode = WindowLayout.ENUM_ViewMode.graph
        ShowWindows()
    End Sub

    Private Sub ShowWindows()
        Dim otherFrms As New List(Of Form)
        Dim viewFrms As New List(Of Form)
        '
        'collect the appropriate forms for each view
        '
        UncheckViewButtons()
        Select Case WindowLayout.Instance.currentViewMode
            Case WindowLayout.ENUM_ViewMode.log
                otherFrms = (From item In Me.MdiChildren Where CType(item, ISensorForm).GetWindowType <> "log" Select item).ToList
                viewFrms = (From item In Me.MdiChildren Where CType(item, ISensorForm).GetWindowType = "log" Select item).ToList
                cmdLogView.Checked = True
                cmdSaveView.Text = "Save Log View"
            Case WindowLayout.ENUM_ViewMode.text
                otherFrms = (From item In Me.MdiChildren Where CType(item, ISensorForm).GetWindowType <> "text" Select item).ToList
                viewFrms = (From item In Me.MdiChildren Where CType(item, ISensorForm).GetWindowType = "text" Select item).ToList
                cmdTextView.Checked = True
                cmdSaveView.Text = "Save Text View"
            Case WindowLayout.ENUM_ViewMode.graph
                otherFrms = (From item In Me.MdiChildren Where CType(item, ISensorForm).GetWindowType <> "graph" Select item).ToList
                viewFrms = (From item In Me.MdiChildren Where CType(item, ISensorForm).GetWindowType = "graph" Select item).ToList
                cmdPlotView.Checked = True
                cmdSaveView.Text = "Save Plot View"
            Case WindowLayout.ENUM_ViewMode.relay
                otherFrms = (From item In Me.MdiChildren Where CType(item, ISensorForm).GetWindowType <> "relay" Select item).ToList
                viewFrms = (From item In Me.MdiChildren Where CType(item, ISensorForm).GetWindowType = "relay" Select item).ToList
                cmdPlotView.Checked = True
                cmdSaveView.Text = "Save Relay View"
            Case WindowLayout.ENUM_ViewMode.mix, WindowLayout.ENUM_ViewMode.screen
                viewFrms = (From item In Me.MdiChildren Select item).ToList 'all forms
                cmdMixView.Checked = True
                cmdSaveView.Text = "Save Display View"
        End Select
        '
        'minimize other frms
        '
        For Each frm In otherFrms
            frm.WindowState = FormWindowState.Minimized
        Next
        '
        'restore view forms
        '
        Debug.Print(WindowLayout.Instance.currentViewMode.ToString)
        If WindowLayout.Instance.IsCurrentViewSaved() Then
            '
            'restore current view
            '
            For Each frm In viewFrms
                CType(frm, ISensorForm).RestoreWindowLocation()
            Next
        ElseIf WindowLayout.Instance.currentViewMode = WindowLayout.ENUM_ViewMode.mix Then
            'current mix is not saved
            'goto default view
            WindowLayout.Instance.currentViewMode = WindowLayout.ENUM_ViewMode.screen
            ShowWindows()
            WindowLayout.Instance.currentViewMode = WindowLayout.ENUM_ViewMode.mix
            Return
        Else
            For Each frm In viewFrms
                frm.WindowState = FormWindowState.Normal
            Next
            Me.LayoutMdi(MdiLayout.TileVertical)
            If WindowLayout.Instance.currentViewMode = WindowLayout.ENUM_ViewMode.mix Then
                Utility.ShowInfoMessage(My.Resources.strViewHelp.Replace("|", vbCrLf))
            End If
        End If

    End Sub

    Private Sub cmdCascade_Click(sender As Object, e As EventArgs) Handles cmdCascade.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub cmdTileWindows_Click(sender As Object, e As EventArgs) Handles cmdTileWindows.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub mnuRestoreWindows_Click(sender As Object, e As EventArgs)
        For Each frm In Me.MdiChildren
            frm.WindowState = FormWindowState.Minimized
        Next
        For Each frm In Me.MdiChildren
            CType(frm, ISensorForm).RestoreWindowLocation()
        Next
    End Sub



    Private Sub cmdSaveView_Click(sender As Object, e As EventArgs) Handles cmdSaveView.Click
        Hourglass.Show()
        Me.SaveAllWindowNames()
        Dim allFrms As List(Of ISensorForm) = (From frm In Me.MdiChildren Select CType(frm, ISensorForm)).ToList
        Select Case WindowLayout.Instance.currentViewMode
            Case WindowLayout.ENUM_ViewMode.mix
                For Each frm In allFrms
                    frm.SaveWindowLocation()
                Next
            Case WindowLayout.ENUM_ViewMode.text
                For Each frm In (From item In allFrms Where item.GetWindowType = "text" Select item).ToList
                    frm.SaveWindowLocation()
                Next
            Case WindowLayout.ENUM_ViewMode.graph
                For Each frm In (From item In allFrms Where item.GetWindowType = "graph" Select item).ToList
                    frm.SaveWindowLocation()
                Next
            Case WindowLayout.ENUM_ViewMode.log
                For Each frm In (From item In allFrms Where item.GetWindowType = "log" Select item).ToList
                    frm.SaveWindowLocation()
                Next
            Case WindowLayout.ENUM_ViewMode.relay
                For Each frm In (From item In allFrms Where item.GetWindowType = "relay" Select item).ToList
                    frm.SaveWindowLocation()
                Next
        End Select
        Thread.Sleep(1000) 'just as in indicator
        Hourglass.Release()
    End Sub

    Private Sub cmdResetWindows_Click(sender As Object, e As EventArgs) Handles cmdResetWindows.Click
        If MsgBox("Ok to reset all windows?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            WindowLayout.Instance.DeleteLayoutFile()
            cmdMixView.PerformClick()
        End If
    End Sub
    Private Sub DeleteLayoutFile()
        WindowLayout.Instance.DeleteLayoutFile()
    End Sub

    Friend Function ClientWindow() As Control
        For Each c As Control In Me.Controls
            If TypeOf c Is MdiClient Then
                Return c
            End If
        Next
        Return Nothing
    End Function

    Private Sub cmdResume_Click(sender As Object, e As EventArgs) Handles cmdResume.Click
        Hourglass.Show()
        _gIsOperating = True
        '   clsGlobals._gTimeStampStopwatch = Stopwatch.StartNew
        For Each frm In Me.MdiChildren
            CType(frm, ISensorForm).ResumeReadingSensors()
            CType(frm, ISensorForm).SetControlStates()
        Next

        For Each alarm In _gAlarms
            alarm.StartMonitoring()
        Next
        SetControlStates()
        Hourglass.Release(True)
    End Sub

    Private Sub SaveAllWindowNames()
        Dim names As New List(Of String)
        For Each frm In Me.MdiChildren
            names.Add(CType(frm, ISensorForm).WindowTagToSave)
        Next
        WindowLayout.Instance.SaveAllWindowNames(names)
    End Sub

    Private Sub cmdMixView_Click(sender As Object, e As EventArgs) Handles cmdMixView.Click
        WindowLayout.Instance.currentViewMode = WindowLayout.ENUM_ViewMode.mix
        ShowWindows()
    End Sub
    Private Sub UncheckViewButtons()
        For Each item In {cmdMixView, cmdLogView, cmdPlotView, cmdTextView}
            CType(item, ToolStripButton).Checked = False
        Next
    End Sub

    Private Sub cmdOverlay_Click(sender As Object, e As EventArgs) Handles cmdOverlay.Click
        Dim g As New ImportLogFiles.GraphLogFile
        g.ShowDialog()
    End Sub
#Region "Tare"
    Private Sub cmdTare_Click(sender As Object, e As EventArgs) Handles cmdTare.Click
        Dim frm As New frmTareSensors()
        AddHandler frm.TareRequested, AddressOf TareRequested
        frm.ShowDialog()
    End Sub
    Private Sub TareRequested(ByVal unitType As Units.Enum_UNIT_TYPE)
        _context.Post(AddressOf TareSensors, unitType)
    End Sub
    Private Sub TareSensors(ByVal unitType As Units.Enum_UNIT_TYPE)
        For Each frm In Me.MdiChildren
            If TryCast(frm, ISensorForm) IsNot Nothing Then
                CType(frm, ISensorForm).TareSensors(unitType)
            End If
        Next

    End Sub
#End Region

    Private Sub mnuSetupCloudAccount_Click(sender As Object, e As EventArgs) Handles mnuSetupCloudAccount.Click
        Dim frm As New frmSetupCloudAccount()
        frm.ShowDialog()
    End Sub

    Private Sub mnuTeamviewer_Click(sender As Object, e As EventArgs) Handles mnuHelpTeamViewer.Click
        clsGlobals.RunTeamviewer()
    End Sub

    Private Sub mnuGotoCloud_Click(sender As Object, e As EventArgs) Handles mnuGotoCloud.Click
        System.Diagnostics.Process.Start(ConfigXml.Instance.cloudBrowserUrl)
    End Sub

    Private Sub mnuDeviceManager_Click(sender As Object, e As EventArgs) Handles mnuDeviceManager.Click
        clsGlobals.RunDeviceManager()
    End Sub

    Private Sub mnuSensorList_Click(sender As Object, e As EventArgs) Handles mnuSensorList.Click
        Dim frm As New frmSensorList
        frm.ShowDialog()
    End Sub
    Private Sub SensorIsDead(ByVal ss1 As String)
        Dim s = (From x In _gAttachedSensors Where x.SS1 = ss1 Select x).Single
        s.StartReading()
        Return
        MsgBox(String.Format("{0}: Sensor is not responding. Please check the connections.", ss1), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
        CheckForIllegalCrossThreadCalls = False
        Me.cmdStop.PerformClick()
        CheckForIllegalCrossThreadCalls = True
    End Sub

    Private Sub cmdRelay_Click(sender As Object, e As EventArgs) Handles cmdRelay.Click
        WindowLayout.Instance.currentViewMode = WindowLayout.ENUM_ViewMode.relay
        ShowWindows()
    End Sub

    Private Sub cmdResetAllRelays_Click(sender As Object, e As EventArgs) Handles cmdResetAllRelays.Click
        cmdStop.PerformClick()
        Hourglass.Show()
        If _frmRelay IsNot Nothing Then
            _frmRelay.ResetAllRelays()
        End If
        Hourglass.Release()
    End Sub

    Private Sub cmdTripAllRelays_Click(sender As Object, e As EventArgs) Handles cmdTripAllRelays.Click
        cmdStop.PerformClick()
        Hourglass.Show()

        If _frmRelay IsNot Nothing Then
            _frmRelay.TripAllRelays()
        End If
        Hourglass.Release
    End Sub

    Private Sub mnuRestartApp_Click(sender As Object, e As EventArgs) Handles mnuRestartApp.Click
        If MsgBox("Ok to restart?", MsgBoxStyle.Question) = MsgBoxResult.Ok Then
            ConfigXml.RestartApplication = True
            Me.Close()
        End If
    End Sub

    Private Sub mnuBurnCalibrationFromFile_Click(sender As Object, e As EventArgs) Handles mnuBurnCalibrationFromFile.Click
        Dim msg = "You must restart the software for the new settings to take effect. Ok to restart?"
        Dim frm As New frmBurnCalibrationFromFile
        frm.ShowDialog()
        If (frm.SettingsBurnt) Then
            If MsgBox(msg, vbOKCancel) = vbOK Then
                ConfigXml.RestartApplication = True
                Me.Close()
            End If
        End If
    End Sub
End Class
