Imports System.Text
Imports System.Threading
Imports System.IO
Imports System.ComponentModel
Imports Multimedia 'need high frequency, high resolution timer
Imports com.loadstar.utility
Imports com.loadstar.utility.Utility
Imports System.Threading.Tasks.Dataflow
Public Class frmPunchForce
    Implements ISensorForm
    Private _sDisplayFormat As String
    Private WithEvents _pfsensor As PunchForceSensor
    Private _bInPunch As Boolean = False
    Private _punchCount As UShort = 0
    Private _fAverage As Double = 0
    Private _fLocalPeak As Double = 0
    Private _fSumOfPeaks As Double = 0
    Private _prevPunchStartMSec As ULong 'the time stamp for a punch
    Private _punchIntervalMSec As UShort
    Private _context As WindowsFormsSynchronizationContext = WindowsFormsSynchronizationContext.Current
    Private _countDownMSec As Long = 0

    Private Sub frmPunchForce_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing And _programClose = False Then
            e.Cancel = True
            Me.WindowState = FormWindowState.Minimized
        Else
        End If

    End Sub
    Private Sub frmPunchForce_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MdiParent = _gFrmMain
        '
        'mouse handling
        '
        AddMouseHandlerRecursive(Me)
    End Sub


    Public Function GetWindowType() As String Implements ISensorForm.GetWindowType
        Return "punch"
    End Function

    Public Sub SetControlStates() Implements ISensorForm.SetControlStates
        TimerDisplay.Enabled = _gIsOperating
    End Sub

    Public Sub StartReadingSensors() Implements ISensorForm.StartReadingSensors
        SetControlStates()
        _punchCount = 0
        txtNPunch.Text = "0"
        txtPeakLoad.Text = "0"
        txtAverageF.Text = "0"
        txtPunchRateMin.Text = "0"
        _fAverage = 0
        _fLocalPeak = 0
        _fSumOfPeaks = 0
        _prevPunchStartMSec = 0
        _punchIntervalMSec = ConfigXml.Instance.punchIntervalMSec
        _bInPunch = False
        dgvPunches.Rows.Clear()
        lblUnits0.Text = _pfsensor.BaseSensor.Units.OutputUnits
        lblUnits1.Text = lblUnits0.Text
        lblUnits2.Text = lblUnits0.Text

        If ConfigXml.Instance.punchTimerEnableAutoStop Then
            TimerAutoStop.Interval = ConfigXml.Instance.punchTimerAutostopMin * 60000 + ConfigXml.Instance.punchTimerAutostopSec * 1000
            If ConfigXml.Instance.startTimerAfterFirstPunch = False Then
                StartAutostopTimer()
            End If
        Else
            TimerAutoStop.Enabled = False
            lblElapsedTime.Visible = False
        End If
        _pfsensor.StartReading()
    End Sub
    Public Sub ResumeReadingSensors() Implements ISensorForm.ResumeReadingSensors
        StartReadingSensors()
    End Sub
    Public Sub StopReadingSensors() Implements ISensorForm.StopReadingSensors
        TimerAutoStop.Enabled = False
        _countDownMSec = 0
        lblElapsedTime.Visible = False
        _pfsensor.StopReading()
    End Sub
    Public Sub TareSensors(ByVal unitType As Units.Enum_UNIT_TYPE) Implements ISensorForm.TareSensors
        'not valid
        'only valid for real sensors
    End Sub

    Public Sub New(ByVal pfSensor As PunchForceSensor)


        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Hourglass.Show()
        _pfsensor = pfSensor

        ' _pfsensor.Units.OutputU TBD
        AddHandler _pfsensor.SensorDataReceived, AddressOf OnSensorDataReceived
        Hourglass.Release()
    End Sub
    Private Sub TimerDisplay_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerDisplay.Tick
        txtNPunch.Text = _pfsensor.PunchCount
        txtPunchRateMin.Text = _pfsensor.PunchRatePerMin.ToString("0")
        txtAverageF.Text = _pfsensor.AverageForce.ToString("0")
        txtPeakLoad.Text = _pfsensor.MaxForce.ToString("0")

        If TimerAutoStop.Enabled Then
            _countDownMSec = TimerAutoStop.Interval - clsGlobals._gTimeStampStopwatch.ElapsedMilliseconds
            If _countDownMSec > 0 Then
                Dim quotient As Long, remainder As Long
                quotient = Math.DivRem(CLng(_countDownMSec), 60000, remainder)
                lblElapsedTime.Text = String.Format("{0:00}:{1:00}", quotient, remainder \ 1000)
            End If
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
            Return "punch"
        End Get
    End Property

    Private Sub _pfsensor_PunchThrown(punch As PunchForceSensor.TIMESTAMPED_FORCE) Handles _pfsensor.PunchThrown
        _context.Post(AddressOf AddPunchForceToLog, punch)
    End Sub
    Private Sub AddPunchForceToLog(ByVal punch As PunchForceSensor.TIMESTAMPED_FORCE)
        With dgvPunches
            .Rows.Add()
            Dim n = .RowCount - 1
            .Rows(n).Cells(0).Value = n + 1
            .Rows(n).Cells(1).Value = (punch.elapsedMSec / 1000.0).ToString("0.000")
            .Rows(n).Cells(2).Value = punch.force.ToString("0")
            txtLastPunch.Text = punch.force.ToString("0")
            With ConfigXml.Instance
                If punch.punchIndex = 1 AndAlso .startTimerAfterFirstPunch AndAlso .punchTimerEnableAutoStop Then
                    My.Computer.Audio.Play(My.Resources.start_round, AudioPlayMode.Background)
                    StartAutostopTimer()
                End If
            End With
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
    End Sub

    Private Sub TimerAutoStop_Tick(sender As Object, e As EventArgs) Handles TimerAutoStop.Tick
        If _gFrmMain.cmdStop.Enabled Then
            My.Computer.Audio.Play(My.Resources.boxing_bell, AudioPlayMode.Background)
            _gFrmMain.cmdStop.PerformClick()
        End If
    End Sub
    Private Sub StartAutostopTimer()
        _countDownMSec = TimerAutoStop.Interval / 1000
        lblElapsedTime.Visible = True
        lblElapsedTime.Text = "0:00"
        TimerAutoStop.Enabled = True
    End Sub
    Private Sub OnSensorDataReceived(ByVal seqNo As UShort)
    End Sub

End Class
