Option Compare Text
Option Explicit On
Option Strict Off
Imports System.Text
Imports System.Threading
Imports System.IO
Imports System.ComponentModel
Imports com.loadstar.utility
Public Class frmSensorCtl
    Implements ISensorForm

    Private _thisSensor As LsSensor
    Private _isPeakSensor As Boolean = False
    Private _isLowSensor As Boolean = False
    Private _isTotalSensor As Boolean = False
    Private _isDerivedSensor As Boolean = False
    Private _isRegularSensor As Boolean = False
    Private Shared _windowCount As Integer = 0
    Private _windowTagToSave As String = ""
    Public Sub New(ByVal sensor As LsSensor)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _thisSensor = sensor
        AddHandler sensor.Units.OutputUnitsChanged, AddressOf SensorUnitsChanged
        If TryCast(_thisSensor, DerivedSensor) Is Nothing Then
            _isRegularSensor = True
        Else
            _isRegularSensor = False
            _isDerivedSensor = True
            Select Case (CType(_thisSensor, DerivedSensor).DerivedType)
                Case DerivedSensor.Enum_Derived_Type.peak
                    _isPeakSensor = True
                Case DerivedSensor.Enum_Derived_Type.low
                    _isLowSensor = True
                Case DerivedSensor.Enum_Derived_Type.total
                    _isTotalSensor = True
            End Select
        End If
        SetWindowOptions()
    End Sub
    Public ReadOnly Property Sensor() As LsSensor
        Get
            Return _thisSensor
        End Get
    End Property

    Public Sub SetWindowOptions()
        Dim ini As New LvIniFile
        ini.Section = "WindowTextColors"
        CtlScalingSensor1.TextColor = System.Drawing.Color.FromArgb(ini.GetInteger(_thisSensor.SS1, Color.Black.ToArgb))
        ini.Section = "WindowBackgroundColors"
        CtlScalingSensor1.BackgroundColor = System.Drawing.Color.FromArgb(ini.GetInteger(_thisSensor.SS1, Color.White.ToArgb))
        ini.Section = "WindowTextAlignment"
        Dim alignment = ini.GetString(_thisSensor.SS1, "Center")
        Select Case alignment
            Case "Center"
                CtlScalingSensor1.TextAlign = HorizontalAlignment.Center
            Case "Right"
                CtlScalingSensor1.TextAlign = HorizontalAlignment.Right
            Case Else
                CtlScalingSensor1.TextAlign = HorizontalAlignment.Left
        End Select
    End Sub
    Private Sub frmSensorCtl_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '
        'user closing event is fired BOTH when user clicks on X to close
        'or programmatically closing
        'we have to distinguish between the two by using the _programClose flag
        If e.CloseReason = CloseReason.UserClosing And _programClose = False Then
            e.Cancel = True
            Me.WindowState = FormWindowState.Minimized
        End If


    End Sub

    Private Sub frmSensorCtl_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = _gFrmMain
        If _isRegularSensor Then
            Me.CtlScalingSensor1.SS1 = _thisSensor.SS1
            If _thisSensor.IsVirtualDevice Then
                Me.Text = _thisSensor.SS1
            Else
                Me.Text = String.Format("{0} ({1})", _thisSensor.SS1, CType(_thisSensor, LsComSensor).PortName)
            End If

        Else
            Me.CtlScalingSensor1.SS1 = _thisSensor.SS1
            Me.Text = _thisSensor.SS1
        End If
        If TypeOf _thisSensor Is FormulaSensor Then
            Me.CtlScalingSensor1.Units = CType(_thisSensor, FormulaSensor).FormulaUnits
        Else
            Me.CtlScalingSensor1.Units = _thisSensor.Units.OutputUnits
        End If
        '
        'alignment
        '
        Dim ini As New LvIniFile()
        ini.Section = "WindowTextAlignment"
        Dim alignment = ini.GetString(_thisSensor.SS1, "Center")
        Select Case alignment
            Case "Center"
                CtlScalingSensor1.TextAlign = HorizontalAlignment.Center
            Case "Right"
                CtlScalingSensor1.TextAlign = HorizontalAlignment.Right
            Case Else
                CtlScalingSensor1.TextAlign = HorizontalAlignment.Left
        End Select
        '
        'mouse handling
        '
        AddMouseHandlerRecursive(Me)
        '
        'parameters for saving
        '
        ' _windowTagToSave = "SensorWin" & windowCount
        _windowTagToSave = "SensorWin" & _thisSensor.SequenceNo
        _windowCount += 1 'this is a shared variable
    End Sub

    Public Function GetWindowType() As String Implements ISensorForm.GetWindowType
        Return "text"
    End Function
    Public Sub ResetPeakLow() Implements ISensorForm.ResetPeakLow
        If _isDerivedSensor Then
            CType(_thisSensor, DerivedSensor).ResetPeakLow()
        End If
    End Sub

    Public Sub SetControlStates() Implements ISensorForm.SetControlStates
        TimerDisplay.Enabled = _gIsOperating
    End Sub

    Public Sub StartReadingSensors() Implements ISensorForm.StartReadingSensors
        ResetPeakLow()
        Dim th As New Thread(AddressOf _thisSensor.StartReading)
        th.IsBackground = True
        th.Start()
    End Sub

    Public Sub ResumeReadingSensors() Implements ISensorForm.ResumeReadingSensors
        StartReadingSensors()
    End Sub
    Public Sub StopReadingSensors() Implements ISensorForm.StopReadingSensors
        Dim th As New Thread(AddressOf _thisSensor.StopReading)
        th.IsBackground = True
        th.Start()
    End Sub

    Public Sub TareSensors(ByVal unitType As Units.Enum_UNIT_TYPE) Implements ISensorForm.TareSensors
        If _thisSensor.Units.UnitType = unitType OrElse unitType = Units.Enum_UNIT_TYPE.none Then
            Hourglass.Show()
            Dim th As New Thread(AddressOf _thisSensor.Tare)
            th.IsBackground = True
            th.Start()
            Me.CtlScalingSensor1.Reading = 0.ToString(ConfigXml.Instance.lv100sDisplayFormat)
            ResetPeakLow()
            Hourglass.Release()
        End If
    End Sub
    Private Sub TimerDisplay_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerDisplay.Tick
        Me.CtlScalingSensor1.Reading = _thisSensor.CurrentReading.ToString(ConfigXml.Instance.lv100sDisplayFormat)
    End Sub
    Private Sub SensorUnitsChanged(ByVal newUnits As String)
        Me.CtlScalingSensor1.Units = newUnits
        ResetPeakLow()
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
        WindowLayout.Instance.RestoreWindowLocation(Me, _windowTagToSave)
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
            Return _windowTagToSave
        End Get
    End Property

End Class