<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainV2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainV2))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuSensorHdr = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFormulaSensors = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFilterSensors = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSensorList = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuRestartApp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsHdr = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPunchForceSensors = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuRelaySettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAlarmSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStartupParam = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCalibrate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBurnCalibrationFromFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuConfigfolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPuttyTerminal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeviceManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGraphHdr = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGraphOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGraphLogFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCloudHeader = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSetupCloudAccount = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGotoCloud = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpHdr = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpTeamViewer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAboutLoadVUE = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cmdStart = New System.Windows.Forms.ToolStripButton()
        Me.cmdStop = New System.Windows.Forms.ToolStripButton()
        Me.cmdTare = New System.Windows.Forms.ToolStripButton()
        Me.cmdResume = New System.Windows.Forms.ToolStripButton()
        Me.cmdResetPeakLow = New System.Windows.Forms.ToolStripButton()
        Me.cmdResetAllRelays = New System.Windows.Forms.ToolStripButton()
        Me.cmdTripAllRelays = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdMixView = New System.Windows.Forms.ToolStripButton()
        Me.cmdTextView = New System.Windows.Forms.ToolStripButton()
        Me.cmdLogView = New System.Windows.Forms.ToolStripButton()
        Me.cmdPlotView = New System.Windows.Forms.ToolStripButton()
        Me.cmdRelay = New System.Windows.Forms.ToolStripButton()
        Me.cmdVideo = New System.Windows.Forms.ToolStripButton()
        Me.cmdSaveView = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdOptions = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdZoom = New System.Windows.Forms.ToolStripButton()
        Me.cmdOverlay = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdCascade = New System.Windows.Forms.ToolStripButton()
        Me.cmdTileWindows = New System.Windows.Forms.ToolStripButton()
        Me.cmdResetWindows = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblSpacer = New System.Windows.Forms.ToolStripLabel()
        Me.lblLogo = New System.Windows.Forms.ToolStripLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblWifiLogo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblSensorList = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.filler2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblLogging = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblLogFileSize = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSensorHdr, Me.mnuToolsHdr, Me.mnuGraphHdr, Me.mnuCloudHeader, Me.mnuHelpHdr})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1284, 29)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuSensorHdr
        '
        Me.mnuSensorHdr.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuStart, Me.mnuStop, Me.ToolStripSeparator5, Me.mnuFormulaSensors, Me.mnuFilterSensors, Me.ToolStripSeparator14, Me.mnuSensorList, Me.ToolStripSeparator13, Me.mnuRestartApp, Me.ToolStripSeparator15, Me.mnuExit})
        Me.mnuSensorHdr.Name = "mnuSensorHdr"
        Me.mnuSensorHdr.Size = New System.Drawing.Size(77, 25)
        Me.mnuSensorHdr.Text = "&Sensors"
        '
        'mnuStart
        '
        Me.mnuStart.Image = Global.LoadVUE.My.Resources.Resources.start_16x16
        Me.mnuStart.Name = "mnuStart"
        Me.mnuStart.Size = New System.Drawing.Size(300, 26)
        Me.mnuStart.Text = "S&tart"
        '
        'mnuStop
        '
        Me.mnuStop.Image = Global.LoadVUE.My.Resources.Resources.stop_16x16
        Me.mnuStop.Name = "mnuStop"
        Me.mnuStop.Size = New System.Drawing.Size(300, 26)
        Me.mnuStop.Text = "Sto&p"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(297, 6)
        '
        'mnuFormulaSensors
        '
        Me.mnuFormulaSensors.Image = CType(resources.GetObject("mnuFormulaSensors.Image"), System.Drawing.Image)
        Me.mnuFormulaSensors.Name = "mnuFormulaSensors"
        Me.mnuFormulaSensors.Size = New System.Drawing.Size(300, 26)
        Me.mnuFormulaSensors.Text = "&Formula Sensors..."
        '
        'mnuFilterSensors
        '
        Me.mnuFilterSensors.Name = "mnuFilterSensors"
        Me.mnuFilterSensors.Size = New System.Drawing.Size(300, 26)
        Me.mnuFilterSensors.Text = "&Average/Median Filters..."
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(297, 6)
        '
        'mnuSensorList
        '
        Me.mnuSensorList.Name = "mnuSensorList"
        Me.mnuSensorList.Size = New System.Drawing.Size(300, 26)
        Me.mnuSensorList.Text = "Connected Sensors && Firmware"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(297, 6)
        '
        'mnuRestartApp
        '
        Me.mnuRestartApp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.mnuRestartApp.Name = "mnuRestartApp"
        Me.mnuRestartApp.Size = New System.Drawing.Size(300, 26)
        Me.mnuRestartApp.Text = "Restart Application"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(297, 6)
        '
        'mnuExit
        '
        Me.mnuExit.ForeColor = System.Drawing.Color.Red
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(300, 26)
        Me.mnuExit.Text = "E&xit"
        '
        'mnuToolsHdr
        '
        Me.mnuToolsHdr.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOptions, Me.mnuPunchForceSensors, Me.ToolStripSeparator12, Me.mnuRelaySettings, Me.mnuAlarmSettings, Me.mnuStartupParam, Me.ToolStripSeparator7, Me.mnuCalibrate, Me.mnuBurnCalibrationFromFile, Me.ToolStripSeparator9, Me.mnuConfigfolder, Me.ToolStripSeparator10, Me.mnuPuttyTerminal, Me.mnuDeviceManager})
        Me.mnuToolsHdr.Name = "mnuToolsHdr"
        Me.mnuToolsHdr.Size = New System.Drawing.Size(57, 25)
        Me.mnuToolsHdr.Text = "&Tools"
        '
        'mnuOptions
        '
        Me.mnuOptions.Image = Global.LoadVUE.My.Resources.Resources.wrench_settings2
        Me.mnuOptions.Name = "mnuOptions"
        Me.mnuOptions.Size = New System.Drawing.Size(320, 26)
        Me.mnuOptions.Text = "&Options..."
        '
        'mnuPunchForceSensors
        '
        Me.mnuPunchForceSensors.Name = "mnuPunchForceSensors"
        Me.mnuPunchForceSensors.Size = New System.Drawing.Size(320, 26)
        Me.mnuPunchForceSensors.Text = "Punch Counter Settings..."
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(317, 6)
        '
        'mnuRelaySettings
        '
        Me.mnuRelaySettings.Enabled = False
        Me.mnuRelaySettings.Name = "mnuRelaySettings"
        Me.mnuRelaySettings.Size = New System.Drawing.Size(320, 26)
        Me.mnuRelaySettings.Text = "&Relay Settings..."
        Me.mnuRelaySettings.Visible = False
        '
        'mnuAlarmSettings
        '
        Me.mnuAlarmSettings.Enabled = False
        Me.mnuAlarmSettings.Image = CType(resources.GetObject("mnuAlarmSettings.Image"), System.Drawing.Image)
        Me.mnuAlarmSettings.Name = "mnuAlarmSettings"
        Me.mnuAlarmSettings.Size = New System.Drawing.Size(320, 26)
        Me.mnuAlarmSettings.Text = "&Alarm Settings..."
        '
        'mnuStartupParam
        '
        Me.mnuStartupParam.Name = "mnuStartupParam"
        Me.mnuStartupParam.Size = New System.Drawing.Size(320, 26)
        Me.mnuStartupParam.Text = "Set Startup Parameters..."
        Me.mnuStartupParam.Visible = False
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(317, 6)
        '
        'mnuCalibrate
        '
        Me.mnuCalibrate.Name = "mnuCalibrate"
        Me.mnuCalibrate.Size = New System.Drawing.Size(320, 26)
        Me.mnuCalibrate.Text = "&Calibrate Sensor..."
        '
        'mnuBurnCalibrationFromFile
        '
        Me.mnuBurnCalibrationFromFile.Name = "mnuBurnCalibrationFromFile"
        Me.mnuBurnCalibrationFromFile.Size = New System.Drawing.Size(320, 26)
        Me.mnuBurnCalibrationFromFile.Text = "Burn Sensor Calibration from File..."
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(317, 6)
        '
        'mnuConfigfolder
        '
        Me.mnuConfigfolder.Name = "mnuConfigfolder"
        Me.mnuConfigfolder.Size = New System.Drawing.Size(320, 26)
        Me.mnuConfigfolder.Text = "Configuration folder"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(317, 6)
        '
        'mnuPuttyTerminal
        '
        Me.mnuPuttyTerminal.Name = "mnuPuttyTerminal"
        Me.mnuPuttyTerminal.Size = New System.Drawing.Size(320, 26)
        Me.mnuPuttyTerminal.Text = "PuTTY Terminal..."
        '
        'mnuDeviceManager
        '
        Me.mnuDeviceManager.Name = "mnuDeviceManager"
        Me.mnuDeviceManager.Size = New System.Drawing.Size(320, 26)
        Me.mnuDeviceManager.Text = "Device Manager"
        '
        'mnuGraphHdr
        '
        Me.mnuGraphHdr.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGraphOptions, Me.mnuGraphLogFile})
        Me.mnuGraphHdr.Name = "mnuGraphHdr"
        Me.mnuGraphHdr.Size = New System.Drawing.Size(65, 25)
        Me.mnuGraphHdr.Text = "&Graph"
        '
        'mnuGraphOptions
        '
        Me.mnuGraphOptions.Image = Global.LoadVUE.My.Resources.Resources.wrench_settings2
        Me.mnuGraphOptions.Name = "mnuGraphOptions"
        Me.mnuGraphOptions.Size = New System.Drawing.Size(249, 26)
        Me.mnuGraphOptions.Text = "&Graph Options..."
        '
        'mnuGraphLogFile
        '
        Me.mnuGraphLogFile.Name = "mnuGraphLogFile"
        Me.mnuGraphLogFile.Size = New System.Drawing.Size(249, 26)
        Me.mnuGraphLogFile.Text = "&Open && Graph Log File..."
        '
        'mnuCloudHeader
        '
        Me.mnuCloudHeader.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSetupCloudAccount, Me.mnuGotoCloud})
        Me.mnuCloudHeader.Name = "mnuCloudHeader"
        Me.mnuCloudHeader.Size = New System.Drawing.Size(63, 25)
        Me.mnuCloudHeader.Text = "&Cloud"
        '
        'mnuSetupCloudAccount
        '
        Me.mnuSetupCloudAccount.Name = "mnuSetupCloudAccount"
        Me.mnuSetupCloudAccount.Size = New System.Drawing.Size(296, 26)
        Me.mnuSetupCloudAccount.Text = "Credentials for Cloud Account..."
        '
        'mnuGotoCloud
        '
        Me.mnuGotoCloud.Name = "mnuGotoCloud"
        Me.mnuGotoCloud.Size = New System.Drawing.Size(296, 26)
        Me.mnuGotoCloud.Text = "Go to SensorVUE Cloud..."
        '
        'mnuHelpHdr
        '
        Me.mnuHelpHdr.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpTeamViewer, Me.ToolStripSeparator11, Me.mnuAboutLoadVUE})
        Me.mnuHelpHdr.Name = "mnuHelpHdr"
        Me.mnuHelpHdr.Size = New System.Drawing.Size(54, 25)
        Me.mnuHelpHdr.Text = "&Help"
        '
        'mnuHelpTeamViewer
        '
        Me.mnuHelpTeamViewer.Name = "mnuHelpTeamViewer"
        Me.mnuHelpTeamViewer.Size = New System.Drawing.Size(289, 26)
        Me.mnuHelpTeamViewer.Text = "Teamviewer Remote Support..."
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(286, 6)
        '
        'mnuAboutLoadVUE
        '
        Me.mnuAboutLoadVUE.Name = "mnuAboutLoadVUE"
        Me.mnuAboutLoadVUE.Size = New System.Drawing.Size(289, 26)
        Me.mnuAboutLoadVUE.Text = "&About"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(163, 6)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(50, 50)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdStart, Me.cmdStop, Me.cmdTare, Me.cmdResume, Me.cmdResetPeakLow, Me.cmdResetAllRelays, Me.cmdTripAllRelays, Me.ToolStripSeparator1, Me.cmdMixView, Me.cmdTextView, Me.cmdLogView, Me.cmdPlotView, Me.cmdRelay, Me.cmdVideo, Me.cmdSaveView, Me.ToolStripSeparator4, Me.cmdOptions, Me.ToolStripSeparator6, Me.cmdZoom, Me.cmdOverlay, Me.ToolStripSeparator3, Me.cmdCascade, Me.cmdTileWindows, Me.cmdResetWindows, Me.ToolStripSeparator8, Me.lblSpacer, Me.lblLogo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 29)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(1284, 78)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmdStart
        '
        Me.cmdStart.Image = CType(resources.GetObject("cmdStart.Image"), System.Drawing.Image)
        Me.cmdStart.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdStart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(64, 75)
        Me.cmdStart.Text = "Start"
        Me.cmdStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdStop
        '
        Me.cmdStop.Image = CType(resources.GetObject("cmdStop.Image"), System.Drawing.Image)
        Me.cmdStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(64, 75)
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdTare
        '
        Me.cmdTare.Image = CType(resources.GetObject("cmdTare.Image"), System.Drawing.Image)
        Me.cmdTare.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdTare.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdTare.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdTare.Name = "cmdTare"
        Me.cmdTare.Size = New System.Drawing.Size(64, 75)
        Me.cmdTare.Text = "Zero"
        Me.cmdTare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdResume
        '
        Me.cmdResume.Image = CType(resources.GetObject("cmdResume.Image"), System.Drawing.Image)
        Me.cmdResume.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdResume.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdResume.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdResume.Name = "cmdResume"
        Me.cmdResume.Size = New System.Drawing.Size(70, 75)
        Me.cmdResume.Text = "Resume"
        Me.cmdResume.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdResetPeakLow
        '
        Me.cmdResetPeakLow.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdResetPeakLow.Image = CType(resources.GetObject("cmdResetPeakLow.Image"), System.Drawing.Image)
        Me.cmdResetPeakLow.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdResetPeakLow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdResetPeakLow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdResetPeakLow.Name = "cmdResetPeakLow"
        Me.cmdResetPeakLow.Size = New System.Drawing.Size(123, 75)
        Me.cmdResetPeakLow.Text = "Reset Peak/Low"
        Me.cmdResetPeakLow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdResetAllRelays
        '
        Me.cmdResetAllRelays.Enabled = False
        Me.cmdResetAllRelays.Image = CType(resources.GetObject("cmdResetAllRelays.Image"), System.Drawing.Image)
        Me.cmdResetAllRelays.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdResetAllRelays.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdResetAllRelays.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdResetAllRelays.Name = "cmdResetAllRelays"
        Me.cmdResetAllRelays.Size = New System.Drawing.Size(113, 75)
        Me.cmdResetAllRelays.Text = "All Relays OFF"
        Me.cmdResetAllRelays.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdTripAllRelays
        '
        Me.cmdTripAllRelays.Enabled = False
        Me.cmdTripAllRelays.Image = CType(resources.GetObject("cmdTripAllRelays.Image"), System.Drawing.Image)
        Me.cmdTripAllRelays.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdTripAllRelays.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdTripAllRelays.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdTripAllRelays.Name = "cmdTripAllRelays"
        Me.cmdTripAllRelays.Size = New System.Drawing.Size(109, 75)
        Me.cmdTripAllRelays.Text = "All Relays ON"
        Me.cmdTripAllRelays.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 78)
        '
        'cmdMixView
        '
        Me.cmdMixView.Image = CType(resources.GetObject("cmdMixView.Image"), System.Drawing.Image)
        Me.cmdMixView.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdMixView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdMixView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdMixView.Name = "cmdMixView"
        Me.cmdMixView.Size = New System.Drawing.Size(65, 75)
        Me.cmdMixView.Tag = "M"
        Me.cmdMixView.Text = "Display"
        Me.cmdMixView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdTextView
        '
        Me.cmdTextView.Image = CType(resources.GetObject("cmdTextView.Image"), System.Drawing.Image)
        Me.cmdTextView.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdTextView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdTextView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdTextView.Name = "cmdTextView"
        Me.cmdTextView.Size = New System.Drawing.Size(64, 75)
        Me.cmdTextView.Tag = "T"
        Me.cmdTextView.Text = "Text"
        Me.cmdTextView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdLogView
        '
        Me.cmdLogView.Image = CType(resources.GetObject("cmdLogView.Image"), System.Drawing.Image)
        Me.cmdLogView.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdLogView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdLogView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdLogView.Name = "cmdLogView"
        Me.cmdLogView.Size = New System.Drawing.Size(64, 75)
        Me.cmdLogView.Tag = "L"
        Me.cmdLogView.Text = "Log"
        Me.cmdLogView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdPlotView
        '
        Me.cmdPlotView.Image = CType(resources.GetObject("cmdPlotView.Image"), System.Drawing.Image)
        Me.cmdPlotView.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdPlotView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdPlotView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdPlotView.Name = "cmdPlotView"
        Me.cmdPlotView.Size = New System.Drawing.Size(64, 75)
        Me.cmdPlotView.Tag = "G"
        Me.cmdPlotView.Text = "Plot"
        Me.cmdPlotView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdRelay
        '
        Me.cmdRelay.Image = CType(resources.GetObject("cmdRelay.Image"), System.Drawing.Image)
        Me.cmdRelay.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdRelay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdRelay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRelay.Name = "cmdRelay"
        Me.cmdRelay.Size = New System.Drawing.Size(64, 75)
        Me.cmdRelay.Tag = "G"
        Me.cmdRelay.Text = "Relay"
        Me.cmdRelay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdVideo
        '
        Me.cmdVideo.AutoToolTip = False
        Me.cmdVideo.Image = CType(resources.GetObject("cmdVideo.Image"), System.Drawing.Image)
        Me.cmdVideo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdVideo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdVideo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdVideo.Name = "cmdVideo"
        Me.cmdVideo.Size = New System.Drawing.Size(64, 75)
        Me.cmdVideo.Text = "Video"
        Me.cmdVideo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdVideo.ToolTipText = "Record Video"
        Me.cmdVideo.Visible = False
        '
        'cmdSaveView
        '
        Me.cmdSaveView.AutoToolTip = False
        Me.cmdSaveView.Image = CType(resources.GetObject("cmdSaveView.Image"), System.Drawing.Image)
        Me.cmdSaveView.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdSaveView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdSaveView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSaveView.Name = "cmdSaveView"
        Me.cmdSaveView.Size = New System.Drawing.Size(64, 75)
        Me.cmdSaveView.Text = "Save"
        Me.cmdSaveView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdSaveView.ToolTipText = "Save"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 78)
        '
        'cmdOptions
        '
        Me.cmdOptions.Image = CType(resources.GetObject("cmdOptions.Image"), System.Drawing.Image)
        Me.cmdOptions.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdOptions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdOptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdOptions.Name = "cmdOptions"
        Me.cmdOptions.ShowDropDownArrow = False
        Me.cmdOptions.Size = New System.Drawing.Size(78, 75)
        Me.cmdOptions.Text = "Options..."
        Me.cmdOptions.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 78)
        '
        'cmdZoom
        '
        Me.cmdZoom.AutoSize = False
        Me.cmdZoom.CheckOnClick = True
        Me.cmdZoom.Enabled = False
        Me.cmdZoom.Image = CType(resources.GetObject("cmdZoom.Image"), System.Drawing.Image)
        Me.cmdZoom.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdZoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdZoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdZoom.Name = "cmdZoom"
        Me.cmdZoom.Size = New System.Drawing.Size(64, 75)
        Me.cmdZoom.Text = "Zoom"
        Me.cmdZoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdZoom.ToolTipText = "Zoom to selected area (on/off)"
        '
        'cmdOverlay
        '
        Me.cmdOverlay.Image = CType(resources.GetObject("cmdOverlay.Image"), System.Drawing.Image)
        Me.cmdOverlay.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdOverlay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdOverlay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdOverlay.Name = "cmdOverlay"
        Me.cmdOverlay.Size = New System.Drawing.Size(103, 75)
        Me.cmdOverlay.Text = "Overlay Files"
        Me.cmdOverlay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 78)
        '
        'cmdCascade
        '
        Me.cmdCascade.AutoToolTip = False
        Me.cmdCascade.Image = CType(resources.GetObject("cmdCascade.Image"), System.Drawing.Image)
        Me.cmdCascade.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdCascade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdCascade.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdCascade.Name = "cmdCascade"
        Me.cmdCascade.Size = New System.Drawing.Size(71, 75)
        Me.cmdCascade.Text = "Cascade"
        Me.cmdCascade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdCascade.ToolTipText = "Cascade"
        '
        'cmdTileWindows
        '
        Me.cmdTileWindows.AutoToolTip = False
        Me.cmdTileWindows.Image = CType(resources.GetObject("cmdTileWindows.Image"), System.Drawing.Image)
        Me.cmdTileWindows.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdTileWindows.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdTileWindows.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdTileWindows.Name = "cmdTileWindows"
        Me.cmdTileWindows.Size = New System.Drawing.Size(64, 75)
        Me.cmdTileWindows.Text = "Tile"
        Me.cmdTileWindows.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdTileWindows.ToolTipText = "Tile"
        '
        'cmdResetWindows
        '
        Me.cmdResetWindows.AutoToolTip = False
        Me.cmdResetWindows.Image = CType(resources.GetObject("cmdResetWindows.Image"), System.Drawing.Image)
        Me.cmdResetWindows.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdResetWindows.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdResetWindows.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdResetWindows.Name = "cmdResetWindows"
        Me.cmdResetWindows.Size = New System.Drawing.Size(64, 75)
        Me.cmdResetWindows.Text = "OFF"
        Me.cmdResetWindows.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdResetWindows.ToolTipText = "OFF"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 78)
        '
        'lblSpacer
        '
        Me.lblSpacer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblSpacer.AutoSize = False
        Me.lblSpacer.BackColor = System.Drawing.Color.Transparent
        Me.lblSpacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.lblSpacer.Name = "lblSpacer"
        Me.lblSpacer.Size = New System.Drawing.Size(5, 69)
        Me.lblSpacer.Text = "ToolStripLabel2"
        '
        'lblLogo
        '
        Me.lblLogo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblLogo.AutoSize = False
        Me.lblLogo.BackColor = System.Drawing.Color.Transparent
        Me.lblLogo.BackgroundImage = CType(resources.GetObject("lblLogo.BackgroundImage"), System.Drawing.Image)
        Me.lblLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.lblLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.lblLogo.Name = "lblLogo"
        Me.lblLogo.Padding = New System.Windows.Forms.Padding(2, 2, 5, 2)
        Me.lblLogo.Size = New System.Drawing.Size(150, 69)
        Me.lblLogo.Text = "ToolStripLabel1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblWifiLogo, Me.lblSensorList, Me.lblStatus, Me.filler2, Me.lblLogging, Me.lblLogFileSize})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 464)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.ShowItemToolTips = True
        Me.StatusStrip1.Size = New System.Drawing.Size(1284, 25)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"

        '
        'lblSensorList
        '
        Me.lblSensorList.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSensorList.ForeColor = System.Drawing.Color.Blue
        Me.lblSensorList.Name = "lblSensorList"
        Me.lblSensorList.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblSensorList.Size = New System.Drawing.Size(73, 20)
        Me.lblSensorList.Text = "Sensor List"
        '
        'lblStatus
        '
        Me.lblStatus.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(20, 20)
        Me.lblStatus.Text = "..."
        Me.lblStatus.ToolTipText = "WiFi"
        '
        'filler2
        '
        Me.filler2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.filler2.Name = "filler2"
        Me.filler2.Size = New System.Drawing.Size(1026, 20)
        Me.filler2.Spring = True
        '
        'lblLogging
        '
        Me.lblLogging.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lblLogging.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblLogging.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogging.ForeColor = System.Drawing.Color.Red
        Me.lblLogging.Name = "lblLogging"
        Me.lblLogging.Size = New System.Drawing.Size(109, 20)
        Me.lblLogging.Text = "Logging, File Size:"
        '
        'lblLogFileSize
        '
        Me.lblLogFileSize.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogFileSize.ForeColor = System.Drawing.Color.Red
        Me.lblLogFileSize.Name = "lblLogFileSize"
        Me.lblLogFileSize.Size = New System.Drawing.Size(16, 20)
        Me.lblLogFileSize.Text = "..."
        '
        'frmMainV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 489)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMainV2"
        Me.Text = "..."
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuSensorHdr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuToolsHdr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCalibrate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGraphHdr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuGraphOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpHdr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAboutLoadVUE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdStart As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents filler2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblLogging As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRelaySettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdOptions As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuAlarmSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdZoom As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuConfigfolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblWifiLogo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuStartupParam As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblLogFileSize As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblSensorList As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuPunchForceSensors As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblLogo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblSpacer As System.Windows.Forms.ToolStripLabel
    Friend WithEvents mnuGraphLogFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPuttyTerminal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdTare As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdResetPeakLow As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdTextView As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLogView As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPlotView As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdCascade As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdTileWindows As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdSaveView As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdResetWindows As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdOverlay As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdResume As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdMixView As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCloudHeader As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSetupCloudAccount As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGotoCloud As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdVideo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDeviceManager As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSensorList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpTeamViewer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFormulaSensors As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFilterSensors As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdRelay As ToolStripButton
    Friend WithEvents cmdResetAllRelays As ToolStripButton
    Friend WithEvents cmdTripAllRelays As ToolStripButton
    Friend WithEvents mnuRestartApp As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As ToolStripSeparator
    Friend WithEvents mnuBurnCalibrationFromFile As ToolStripMenuItem
End Class
