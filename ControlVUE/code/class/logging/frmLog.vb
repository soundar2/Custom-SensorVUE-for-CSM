Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks.Dataflow
Imports com.loadstar.utility
Imports com.loadstar.utility.Utility
Imports CsvHelper
Imports Multimedia 'need high frequency, high resolution timer
Public Class frmLog
    Implements ISensorForm

    Private _isLoggingInProgress As Boolean = False
    Private _intervals As New Dictionary(Of Long, String)
    Private Const LOG_ONCE_INTERVAL = 9999
    Private _udfValue As String
    Private _sensorsToLog As New List(Of LsSensor)

    Friend Class LOG_DATA
        Public elapsedTimeMSec As Long
        Public reading() As Double
        Public udf As String
        Public formattedTime As String
    End Class

    Private WithEvents _timerLogToFile As New Multimedia.Timer
    Private _logRate As ConfigXml.Enum_LogRate = ConfigXml.Enum_LogRate.slowTimed
    Private _thLog As Thread

    Private _fileLogBuffer As BufferBlock(Of LOG_DATA)
    Private _screenLogBuffer As BufferBlock(Of LOG_DATA)
    Private _logTimerFired As Boolean = False
    Private _hasDataCaptureStarted As Boolean = False
    Private Sub chkLogToFile_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLogToFile.CheckedChanged
        If chkLogToFile.Checked = False Then
            chkUploadToCloud.Checked = False
            Return
        End If
        If Not _sensorsToLog.Any Then
            'no sensors to log have been chosen
            'show dialog
            Dim frm As New frmSensorsToLog
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'add these columns to the log file
                AddColumnsToLogWindow()
            Else
                chkLogToFile.Checked = False
                Return
            End If
        End If
        cmdBrowse.Enabled = (chkLogToFile.Checked = True)
        txtLogFile.Enabled = cmdBrowse.Enabled
        If chkLogToFile.Checked = True AndAlso txtLogFile.Text = String.Empty Then
            cmdBrowse.PerformClick()
            'if user selected cancel , clear the checkbox
            If txtLogFile.Text = String.Empty Then
                chkLogToFile.Checked = False
            End If
        End If
        SetControlStates()
    End Sub

    Private Sub frmLog_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing And _programClose = False Then
            e.Cancel = True
            Me.WindowState = FormWindowState.Minimized
        Else
            ConfigXml.Instance.uploadToCloud = chkUploadToCloud.Checked
            ConfigXml.Instance.WriteConfiguration()
        End If

    End Sub

    Private Sub frmLog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MdiParent = _gFrmMain
        _timerLogToFile.Resolution = 0
        _timerLogToFile.SynchronizingObject = Me
        chkUploadToCloud.Checked = ConfigXml.Instance.uploadToCloud
        '
        'mouse handling
        '
        AddMouseHandlerRecursive(Me)
        RemoveHandler RTCloudUpload.Instance.LogMessage, AddressOf CloudUploadMessageHandler
        AddHandler RTCloudUpload.Instance.LogMessage, AddressOf CloudUploadMessageHandler
    End Sub

    Private Sub GetAttachedSensorsInConfigFile()
        Dim t As New List(Of LsSensor)
        If ConfigXml.Instance.SensorsToLog.Any Then
            t = (From item In _gAttachedSensors Where
                       (From cName In ConfigXml.Instance.SensorsToLog Where cName = item.SS1 Order By item.SequenceNo Select cName).Any() Select item).ToList
        End If
        _sensorsToLog = t
    End Sub

    Private Sub AddColumnsToLogWindow()
        GetAttachedSensorsInConfigFile()
        Dim col As New DataGridViewTextBoxColumn
        dgvLog.Rows.Clear()
        'delete any previous sensor columns
        For i = dgvLog.Columns.Count - 1 To 2 Step -1
            dgvLog.Columns.RemoveAt(i)
        Next
        'add a column for each force channel
        Dim handlerAdded As Boolean = False
        For Each sen In _sensorsToLog
            col = New DataGridViewTextBoxColumn
            col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            col.HeaderText = sen.SS1
            col.Name = "sensor" & sen.SequenceNo
            col.ReadOnly = True
            col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            dgvLog.Columns.Add(col)
            RemoveHandler sen.SensorDataReceived, AddressOf LogSensorDataReceived
            If sen.SS1 = ConfigXml.Instance.loggingControlSs1 Then
                AddHandler sen.SensorDataReceived, AddressOf LogSensorDataReceived
                handlerAdded = True
            End If
        Next
        If Not handlerAdded Then
            AddHandler _sensorsToLog(0).SensorDataReceived, AddressOf LogSensorDataReceived
        End If
        If ConfigXml.Instance.logUdf Then
            col = New DataGridViewTextBoxColumn
            col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            col.HeaderText = ConfigXml.Instance.udfFieldName
            col.Name = "udf"
            col.ReadOnly = True
            col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            dgvLog.Columns.Add(col)
        End If
        dgvLog.Columns(dgvLog.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub LogSensorDataReceived(ByVal seqNo As UShort)
        '
        'we add data to a logq if logging continuously
        'if logging on a timer log only when log timer is fired
        '
        If _isLoggingInProgress AndAlso (_logRate = ConfigXml.Enum_LogRate.continuous OrElse _logTimerFired = True) Then
            Dim logData As New LOG_DATA
            ReDim logData.reading(0 To _sensorsToLog.Count - 1)
            With logData
                For i = 0 To _sensorsToLog.Count - 1
                    .reading(i) = _sensorsToLog(i).CurrentReading
                Next
                .elapsedTimeMSec = clsGlobals._gTimeStampStopwatch.ElapsedMilliseconds
                .udf = _udfValue
            End With
            _fileLogBuffer.Post(logData)
            If _logTimerFired Then
                For i = 0 To _gOkToGraph.Length - 1
                    _gOkToGraph(i) = True
                Next
            End If
            _logTimerFired = False
        End If
    End Sub

    Private Sub cmdLogOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogOptions.Click
        Dim frm As New frmLogOptions
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'add these columns to the log file
            AddColumnsToLogWindow()
        End If

    End Sub

    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Dim dlgSave As New SaveFileDialog
        dlgSave.Filter = "Excel Files (*.CSV)|*.CSV"
        'dlgSave.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        If dlgSave.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtLogFile.Text = dlgSave.FileName
            SetToolTip(txtLogFile, dlgSave.FileName)

            dgvLog.Rows.Clear()
            Try
                If My.Computer.FileSystem.FileExists(txtLogFile.Text) Then
                    My.Computer.FileSystem.DeleteFile(txtLogFile.Text)
                End If
                Using swriter As New StreamWriter(txtLogFile.Text, False)

                    Using cw As New CsvWriter(swriter)
                        cw.Configuration.Delimiter = CultureInfo.CurrentCulture.TextInfo.ListSeparator
                        cw.WriteField(Of String)("Loadstar Sensors SensorVUE - Log File")
                        cw.NextRecord()
                    End Using
                    _hasDataCaptureStarted = False
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Function GetWindowType() As String Implements ISensorForm.GetWindowType
        Return "log"
    End Function

    Public Sub SetControlStates() Implements ISensorForm.SetControlStates
        _isLoggingInProgress = (_gIsOperating AndAlso chkLogToFile.Checked = True AndAlso txtLogFile.Text <> String.Empty)
        If _isLoggingInProgress Then
            If _timerLogToFile.Period = LOG_ONCE_INTERVAL Then
                ConfigXml.Instance.logRate = ConfigXml.Enum_LogRate.ondemand
            ElseIf _timerLogToFile.Period >= 1000 Then
                ConfigXml.Instance.logRate = ConfigXml.Enum_LogRate.slowTimed
            ElseIf _timerLogToFile.Period >= 10 Then
                ConfigXml.Instance.logRate = ConfigXml.Enum_LogRate.fastTimed
            Else
                ConfigXml.Instance.logRate = ConfigXml.Enum_LogRate.continuous
            End If
        End If
        If _timerLogToFile.Period >= 1000 Then
            RTCloudUpload.UploadIntervalMSec = 1000
        Else
            RTCloudUpload.UploadIntervalMSec = 5000
        End If
        _logRate = ConfigXml.Instance.logRate
        pnlLogMessage.Visible = (_logRate > ConfigXml.Enum_LogRate.slowTimed OrElse (ConfigXml.Instance.doNotLogToScreen = True))
        dgvLog.Visible = Not pnlLogMessage.Visible
        cmdLogNow.Enabled = (_logRate = ConfigXml.Enum_LogRate.ondemand) AndAlso _isLoggingInProgress
        cmbLogInterval.Enabled = Not _gIsOperating
        _gFrmMain.lblLogging.Visible = _isLoggingInProgress
        pnlLogSettings.Enabled = Not _gIsOperating
        cmdLogOptions.Enabled = Not _gIsOperating
        pnlUploadToCloud.Enabled = Not _gIsOperating
    End Sub

    Public Sub StartReadingSensors() Implements ISensorForm.StartReadingSensors
        If chkLogToFile.Checked Then
            If Not CanWriteToLogFile() Then
                chkLogToFile.Checked = False
                Return
            End If
        End If
        SetControlStates()
        If _isLoggingInProgress Then
            _fileLogBuffer = New BufferBlock(Of LOG_DATA)
            _screenLogBuffer = New BufferBlock(Of LOG_DATA)

            If (ConfigXml.Instance.logRate = ConfigXml.Enum_LogRate.fastTimed OrElse ConfigXml.Instance.logRate = ConfigXml.Enum_LogRate.slowTimed) Then
                _timerLogToFile.Start()
            End If
            For i = 0 To _gOkToGraph.Length - 1
                _gOkToGraph(i) = False
            Next
            _thLog = New Thread(AddressOf LogInBackground)
            _thLog.IsBackground = True
            _thLog.Priority = ThreadPriority.Lowest
            _thLog.Start()
            TimerLogFileSize.Enabled = True
            TimerLogToScreen.Enabled = True
        Else
            If ConfigXml.Instance.graphLoggedReadingsOnly Then
                MsgBox("'Graph logged readings only' is checked but a log file has not been selected. Readings will not be plotted.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Public Sub ResumeReadingSensors() Implements ISensorForm.ResumeReadingSensors
        StartReadingSensors()
    End Sub

    Public Sub StopReadingSensors() Implements ISensorForm.StopReadingSensors

        _timerLogToFile.Stop()
        TimerLogToScreen.Enabled = False
        TimerLogFileSize.Enabled = False

        If _thLog IsNot Nothing AndAlso _thLog.IsAlive Then
            ''this means logging is in progress
            'there may be data in filebuffer not yet written to disk
            'let us wait for 2 seconds and then terminate the thread
            'create EOF object and post it
            Dim data As New LOG_DATA
            data.elapsedTimeMSec = -1 'invalid
            _fileLogBuffer.Post(data) 'post an empty record to indicate finishing operation
            _thLog.Join(5000)
            _thLog = Nothing

            If IsUploadingToCloud() Then
                Utility.ShowInfoMessage("It may take a few minutes for the uploaded data to show up in SensorVUE Cloud.")
            End If
        End If
    End Sub

    Public Sub TareSensors(ByVal unitType As Units.Enum_UNIT_TYPE) Implements ISensorForm.TareSensors
        'not valid
        'only valid for real sensors
    End Sub

    Private Function CanWriteToLogFile() As Boolean
        If txtLogFile.Text.Length = 0 Then Return True
        Try
            Using sw As New StreamWriter(txtLogFile.Text, True)
                sw.Write(vbNullString)
            End Using
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Return False
        End Try
    End Function

    Private Sub TimerLogging_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _timerLogToFile.Tick
        _logTimerFired = True
    End Sub

    Private Sub cmdLogNow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLogNow.Click
        _logTimerFired = True
    End Sub

    Private Sub cmbLogInterval_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLogInterval.SelectionChangeCommitted
        For Each x As Long In _intervals.Keys
            If _intervals.Item(x) = cmbLogInterval.Text Then
                _timerLogToFile.Period = x
                SetControlStates()
                ConfigXml.Instance.logIntervalMSec = x
                Return
            End If
        Next
        SetControlStates()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Hourglass.Show()
        GetAttachedSensorsInConfigFile()
        If _sensorsToLog.Any Then
            AddColumnsToLogWindow()
        End If
        'logging
        '
        With _intervals
            .Add(1, "Maximum") 'continuous
            .Add(10, "0.01 sec") '100 readings a second crashes, not able to handle this
            .Add(20, "0.02 sec  (50 Hz)")
            .Add(33, "0.03 sec  (30 Hz)")
            .Add(50, "0.05 sec  (20 Hz)")
            .Add(100, "0.1 sec  (10 Hz)") '10 readings a second
            .Add(250, "0.25 sec  (4 Hz)")
            .Add(500, "0.5 sec  (2 Hz)")
            .Add(1000, "1 sec  (1 Hz)")
            .Add(2000, "2 sec")
            .Add(5000, "5 sec")
            .Add(10000, "10 sec")
            .Add(30000, "30 sec")
            .Add(60000, "1 min")
            .Add(600000, "10 min")
            .Add(1800000, "30 min")
            .Add(LOG_ONCE_INTERVAL, "On demand")
        End With

        With cmbLogInterval
            For Each x As String In _intervals.Keys
                .Items.Add(_intervals.Item(x))
            Next
            .Text = _intervals.Item(ConfigXml.Instance.logIntervalMSec) 'default is 1 sec
            _timerLogToFile.Period = ConfigXml.Instance.logIntervalMSec
        End With
        'udf
        lblUdf.Text = ConfigXml.Instance.udfFieldName & ":"
        Hourglass.Release()
    End Sub

    Private Sub LogInBackground()
        Dim absoluteTime As Date
        Dim logdata As LOG_DATA = Nothing
        Dim shouldLogUdf = ConfigXml.Instance.logUdf
        Try

            Using sw = New System.IO.StreamWriter(txtLogFile.Text, True) 'append
                Using cw = New CsvHelper.CsvWriter(sw)
                    cw.Configuration.Delimiter = CultureInfo.CurrentCulture.TextInfo.ListSeparator
                    If _hasDataCaptureStarted = False Then
                        WriteLogFileHeader(cw)
                        _hasDataCaptureStarted = True
                    End If
                    Do
                        Thread.Sleep(100)
                        Dim n = _fileLogBuffer.Count
                        If n <> 0 Then
                            For k = 1 To n
                                logdata = _fileLogBuffer.Receive()
                                If logdata.elapsedTimeMSec = -1 Then
                                    'this is a marker object to indicate log completion
                                    'if we are uploading to cloud
                                    'indicate no more data to upload
                                    RTCloudUpload.Instance.QueueUploadCompleted()
                                    Return
                                End If
                                absoluteTime = clsGlobals._gStartTime.AddMilliseconds(logdata.elapsedTimeMSec)
                                With absoluteTime
                                    'format time to string
                                    logdata.formattedTime = FormatTimeForLog(absoluteTime)
                                    cw.WriteField(Of String)(logdata.formattedTime)
                                    cw.WriteField(Of String)((logdata.elapsedTimeMSec / 1000).ToString("0.000"))
                                End With
                                With logdata
                                    For i As Byte = 0 To .reading.Length - 1
                                        If ConfigXml.Instance.UseScientificFormatInLogFiles Then
                                            cw.WriteField(.reading(i).ToString("0.######E00"))
                                        Else
                                            cw.WriteField(.reading(i).ToString(ConfigXml.Instance.lv100sDisplayFormat))
                                        End If
                                    Next
                                    If shouldLogUdf Then
                                        cw.WriteField(.udf)
                                    End If
                                End With
                                cw.NextRecord()

                                If _logRate <= ConfigXml.Enum_LogRate.slowTimed AndAlso ConfigXml.Instance.doNotLogToScreen = False Then
                                    _screenLogBuffer.Post(logdata)
                                End If
                                If IsUploadingToCloud() Then
                                    RTCloudUpload.Instance.QueueSensorReadingForUpload(logdata.elapsedTimeMSec / 1000, logdata.reading.ToList)
                                End If
                                sw.Flush()
                            Next
                        End If
                    Loop
                End Using
            End Using
        Catch ex As Exception
            Return
        End Try
    End Sub

    Private Sub TimerLogFileSize_Tick(sender As Object, e As EventArgs) Handles TimerLogFileSize.Tick
        Dim fileSize As Double = (My.Computer.FileSystem.GetFileInfo(txtLogFile.Text).Length / 1000)
        If fileSize > 1000 Then
            fileSize /= 1000
            _gFrmMain.lblLogFileSize.Text = fileSize.ToString("0.000") & " MB"
        Else
            _gFrmMain.lblLogFileSize.Text = fileSize.ToString("0") & " KB"
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
            Return "log"
        End Get
    End Property

    'Private Sub cmdUploadToCloud_Click(sender As Object, e As EventArgs) Handles cmdUploadToCloud.Click
    '    Dim fileName = txtLogFile.Text
    '    If fileName.Length <> 0 Then
    '        Dim frm As New frmUploadToCloud(fileName)
    '        frm.ShowDialog()
    '    End If

    'End Sub

    Private Sub txtUdf_TextChanged(sender As Object, e As EventArgs) Handles txtUdf.TextChanged
        _udfValue = txtUdf.Text.Trim
    End Sub

    Public Function OkToUploadToCloud() As Boolean
        If chkLogToFile.Checked Then
            If chkUploadToCloud.Checked Then
                If RTCloudUpload.Instance.GotUid() Then Return True 'no need to get again
                Dim ret As Tuple(Of Boolean, String)
                Hourglass.Show()
                ret = RTCloudUpload.Instance.VerifyUploadCredentials(ConfigXml.Instance.uploadEmail, ConfigXml.Instance.uploadPassword)
                Hourglass.Release()
                If ret.Item1 = True Then
                    Return True
                Else
                    Utility.ShowErrorMessage(ret.Item2)
                    Return False
                End If
            Else
                Return True
            End If
        Else
            Return True
        End If

        Return False
    End Function

    Public Function IsUploadingToCloud()
        Return chkLogToFile.Checked AndAlso chkUploadToCloud.Checked
    End Function

    Public Function UploadSensorMetaData() As Boolean
        If IsUploadingToCloud() Then
            Dim frmI As New frmInputBox("Uploading to SensorVUE Cloud...Enter a description for this session:")
            If Not frmI.ShowDialog = Windows.Forms.DialogResult.OK Then Return False
            Dim sessonDesc = String.Format("{0} ({1})", frmI.answer, DateTime.Now)
            txtUploadLog.Clear()
            txtUploadLog.AppendText(sessonDesc & vbCrLf)
            Dim ret = RTCloudUpload.Instance.UploadSensorMetaData(_sensorsToLog, sessonDesc)
            If ret.Item1 = True Then
                txtUploadLog.AppendText("Session ID: " & ret.Item2 & vbCrLf)
                Return True
            Else
                Utility.ShowErrorMessage(ret.Item2)
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(ConfigXml.Instance.cloudBrowserUrl)
    End Sub

    Private Sub chkUploadToCloud_CheckedChanged(sender As Object, e As EventArgs) Handles chkUploadToCloud.CheckedChanged
        ConfigXml.Instance.uploadToCloud = chkUploadToCloud.Checked
        ConfigXml.Instance.WriteConfiguration()
    End Sub

    Private Function FormatTimeForLog(ByVal d As Date) As String
        With d
            Return String.Format("{0:0000}-{1:00}-{2:00} {3:00}:{4:00}:{5}", .Year, .Month, .Day, .Hour, .Minute,
                                 ((d.Second * 1000 + d.Millisecond) / 1000).ToString("0.000"))
        End With
    End Function

    Private Sub TimerLogToScreen_Tick(sender As Object, e As EventArgs) Handles TimerLogToScreen.Tick
        If _screenLogBuffer.Count <> 0 Then
            Dim n = _screenLogBuffer.Count
            For k = 1 To n
                Dim logData = _screenLogBuffer.Receive()
                With dgvLog
                    .Rows.Add()
                    n = .RowCount - 1
                    .Rows(n).Cells(0).Value = logData.formattedTime
                    .Rows(n).Cells(1).Value = (logData.elapsedTimeMSec / 1000).ToString("0.000")
                    For i = 0 To logData.reading.Count - 1
                        If ConfigXml.Instance.UseScientificFormatInLogFiles Then
                            .Rows(n).Cells(i + 2).Value = logData.reading(i).ToString("0.######E00")
                        Else
                            .Rows(n).Cells(i + 2).Value = logData.reading(i).ToString(ConfigXml.Instance.lv100sDisplayFormat)
                        End If
                    Next
                    'udf
                    Try
                        If ConfigXml.Instance.logUdf Then
                            .Rows(n).Cells("udf").Value = logData.udf
                        End If
                    Catch ex As Exception
                    End Try

                    'we need to make sure that the new row is visible
                    Static f As UInteger
                    If .RowCount = 1 Then
                        f = 0
                    Else
                        f += 1
                    End If
                    Try
                        .Rows(n).Selected = True
                        'how many rows are visible
                        .FirstDisplayedScrollingRowIndex = f
                    Catch ex As Exception

                    End Try
                End With
            Next
        End If
    End Sub

    Private Sub CloudUploadMessageHandler(ByVal msg As String)
        CheckForIllegalCrossThreadCalls = False
        txtUploadLog.AppendText(msg & vbCrLf)
        txtUploadLog.SelectionStart = txtUploadLog.Text.Length - 1
        If txtUploadLog.Lines.Count > 1000 Then
            txtUploadLog.Clear()
        End If
        CheckForIllegalCrossThreadCalls = True
    End Sub
    Private Sub WriteLogFileHeader(ByVal cw As CsvWriter)
        For Each s In _sensorsToLog
            cw.WriteField(Of String)("Units for " & s.SS1)
            If TryCast(s, FormulaSensor) IsNot Nothing Then
                cw.WriteField(Of String)(CType(s, FormulaSensor).FormulaUnits)
            Else
                cw.WriteField(Of String)(s.Units.OutputUnits.ToString)
            End If
            cw.NextRecord()
        Next
        cw.WriteField(Of String)("Logging Interval:")
        CheckForIllegalCrossThreadCalls = False
        cw.WriteField(Of String)(Me.cmbLogInterval.Text)
        CheckForIllegalCrossThreadCalls = True
        cw.NextRecord()
        cw.WriteField(Of String)(New String("-", 80))
        cw.NextRecord()
        cw.WriteField(Of String)("*** Use custom format 'hh:mm:ss.000' in Microsoft Excel to correctly display the time stamp in milliseconds. ***")
        cw.NextRecord()
        cw.WriteField(Of String)(New String("-", 120))
        cw.NextRecord()
        cw.WriteField("Time")
        cw.WriteField("Elapsed Time(sec)")
        For Each sen In _sensorsToLog
            cw.WriteField(sen.SS1)
        Next
        If ConfigXml.Instance.logUdf Then
            cw.WriteField("UDF:" & ConfigXml.Instance.udfFieldName)
        End If
        cw.NextRecord()
    End Sub
End Class