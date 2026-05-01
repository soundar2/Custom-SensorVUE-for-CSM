Option Compare Text
Option Explicit On
Option Strict Off

Imports com.quinncurtis.chart2dnet
Imports com.quinncurtis.rtgraphnet
Imports com.loadstar.utility

Module ModuleLvMain
    Public _gConfigFolder As String = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & My.Application.Info.ProductName
    Public _gAttachedSensors As New List(Of LsSensor)
    Public _gAlarms As New List(Of Alarm)
    Public _gIsOperating As Boolean = False
    Public _gGraphOptionsCollection As GraphOptionsCollection
    Public _gOkToGraph() As Boolean 'each graph needs its own flag on when to graph
    Public _gFrmMain As IMainForm 'we need this flag for every window to access the MDI parent
    Public _gMultiPoint As Boolean = False

    Public Sub Main()
        If Not Utility.IsDotNet4Installed() Then
            Utility.ShowErrorMessage("Microsoft .NET 4 is required to run this program.")
            Return
        End If

        With My.Computer.FileSystem
            If Not .DirectoryExists(_gConfigFolder) Then
                .CreateDirectory(_gConfigFolder)
            End If
        End With
        Application.EnableVisualStyles()
        ChartView.SetLicensePath(My.Computer.FileSystem.GetParentPath(Application.ExecutablePath))
        ReDim _gOkToGraph(0 To 20) ''maximum of 20 graphs

        ConfigXml.Instance.ReadConfiguration()
        Dim inst = ConfigXml.Instance
        System.Diagnostics.Process.GetCurrentProcess().PriorityClass = ConfigXml.Instance.myPriorityClass
        _gGraphOptionsCollection = GraphOptionsCollection.Instance


        'Dim frmp As New frmPartDetails
        'frmp.ShowDialog()
        'Return

        Dim agr = New com.loadstar.disclaimer.LicenseAgreement(My.Application.Info.ProductName, True)
        If Not agr.AgreeToLicense() Then
            Return
        End If


        '
        'show splash screen, it will automatically close after 5 sec
        '
        Dim frms As New frmSplashImage
        frms.ShowDialog()

        ' If My.Application.CommandLineArgs.Contains("/ignore-ports") Then
        Dim frm As New frmIgnorePorts
        frm.ShowDialog()
        ' End If

        '
        'show appropriate forms
        '
        'first check if wifi should be used
        'Dim frmW As New frmSelectProtocol

        'If My.Application.CommandLineArgs.Contains("/serial") Then
        '    _gUseWifi = False
        'ElseIf My.Application.CommandLineArgs.Contains("/wifi") Then
        '    _gUseWifi = True
        'Else
        '    If frmSelectProtocol.ShowDialog <> DialogResult.OK Then Return
        '    _gUseWifi = ConfigXml.Instance.selectedConnectionType.ToLower.Contains("wifi")
        '    _gMultiPoint = False
        'End If

        _gMultiPoint = False

        '
        '
        RunApplicationWithRestart()

    End Sub

    Private Sub AddForceSensors(ByRef seqNo As Integer)
        'force sensors
        Dim forceSensors = (From s In _gAttachedSensors Where s.UnitType = Units.Enum_UNIT_TYPE.force Order By s.SS1 Select s).ToList
        If forceSensors.Count = 1 Then
            Dim s As LsSensor = forceSensors(0)
            seqNo += 1 : s.SequenceNo = seqNo
            Dim peakSensor = New DerivedSensor(s, Units.Enum_UNIT_TYPE.force, DerivedSensor.Enum_Derived_Type.peak)
            seqNo += 1 : peakSensor.SequenceNo = seqNo
            peakSensor.SS1 = "Peak (" & s.SS1 & ")"
            _gAttachedSensors.Add(peakSensor)
            '
            Dim lowSensor = New DerivedSensor(s, Units.Enum_UNIT_TYPE.force, DerivedSensor.Enum_Derived_Type.low)
            seqNo += 1 : lowSensor.SequenceNo = seqNo
            lowSensor.SS1 = "Low (" & s.SS1 & ")"
            _gAttachedSensors.Add(lowSensor)
        ElseIf forceSensors.Count > 1 Then
            For Each s In forceSensors
                seqNo += 1
                s.SequenceNo = seqNo
            Next
            Dim totalSensor = New DerivedSensor(forceSensors, Units.Enum_UNIT_TYPE.force, DerivedSensor.Enum_Derived_Type.total)
            seqNo += 1 : totalSensor.SequenceNo = seqNo
            totalSensor.SS1 = "Total (Force)"
            _gAttachedSensors.Add(totalSensor)
            Dim peakSensor = New DerivedSensor(totalSensor, Units.Enum_UNIT_TYPE.force, DerivedSensor.Enum_Derived_Type.peak)
            seqNo += 1 : peakSensor.SequenceNo = seqNo
            peakSensor.SS1 = "Peak (Total Force)"
            _gAttachedSensors.Add(peakSensor)
            Dim lowSensor = New DerivedSensor(totalSensor, Units.Enum_UNIT_TYPE.force, DerivedSensor.Enum_Derived_Type.low)
            seqNo += 1 : lowSensor.SequenceNo = seqNo
            lowSensor.SS1 = "Low (Total Force)"
            _gAttachedSensors.Add(lowSensor)
        End If
    End Sub

    Private Sub AddPressureSensors(ByRef seqNo As Integer)
        'pressure sensors
        Dim pressureSensors = (From s In _gAttachedSensors Where s.UnitType = Units.Enum_UNIT_TYPE.pressure AndAlso TryCast(s, FilterSensor) Is Nothing Order By s.SS1 Select s).ToList
        If pressureSensors.Count = 1 Then
            Dim s As LsSensor = pressureSensors(0)
            seqNo += 1 : s.SequenceNo = seqNo
            Dim peakSensor = New DerivedSensor(s, Units.Enum_UNIT_TYPE.pressure, DerivedSensor.Enum_Derived_Type.peak)
            seqNo += 1 : peakSensor.SequenceNo = seqNo
            peakSensor.SS1 = "Peak (" & s.SS1 & ")"
            _gAttachedSensors.Add(peakSensor)
            '
            Dim lowSensor = New DerivedSensor(s, Units.Enum_UNIT_TYPE.pressure, DerivedSensor.Enum_Derived_Type.low)
            seqNo += 1 : lowSensor.SequenceNo = seqNo
            lowSensor.SS1 = "Low (" & s.SS1 & ")"
            _gAttachedSensors.Add(lowSensor)
        ElseIf pressureSensors.Count > 1 Then
            For Each s In pressureSensors
                seqNo += 1
                s.SequenceNo = seqNo
            Next
            Dim totalSensor = New DerivedSensor(pressureSensors, Units.Enum_UNIT_TYPE.pressure, DerivedSensor.Enum_Derived_Type.total)
            seqNo += 1 : totalSensor.SequenceNo = seqNo
            totalSensor.SS1 = "Total (Pressure)"
            _gAttachedSensors.Add(totalSensor)
            Dim peakSensor = New DerivedSensor(totalSensor, Units.Enum_UNIT_TYPE.pressure, DerivedSensor.Enum_Derived_Type.peak)
            seqNo += 1 : peakSensor.SequenceNo = seqNo
            peakSensor.SS1 = "Peak (Total Pressure)"
            _gAttachedSensors.Add(peakSensor)
            Dim lowSensor = New DerivedSensor(totalSensor, Units.Enum_UNIT_TYPE.pressure, DerivedSensor.Enum_Derived_Type.low)
            seqNo += 1 : lowSensor.SequenceNo = seqNo
            lowSensor.SS1 = "Low (Total Pressure)"
            _gAttachedSensors.Add(lowSensor)
        End If
    End Sub

    Private Sub AddTorqueSensors(ByRef seqNo As Integer)
        'torque sensors
        Dim torqueSensors = (From s In _gAttachedSensors Where s.UnitType = Units.Enum_UNIT_TYPE.torque Order By s.SS1 Select s).ToList
        If torqueSensors.Count = 1 Then
            Dim s As LsSensor = torqueSensors(0)
            seqNo += 1 : s.SequenceNo = seqNo
            Dim peakSensor = New DerivedSensor(s, Units.Enum_UNIT_TYPE.torque, DerivedSensor.Enum_Derived_Type.peak)
            seqNo += 1 : peakSensor.SequenceNo = seqNo
            peakSensor.SS1 = "Peak (" & s.SS1 & ")"
            _gAttachedSensors.Add(peakSensor)
            '
            Dim lowSensor = New DerivedSensor(s, Units.Enum_UNIT_TYPE.torque, DerivedSensor.Enum_Derived_Type.low)
            seqNo += 1 : lowSensor.SequenceNo = seqNo
            lowSensor.SS1 = "Low (" & s.SS1 & ")"
            _gAttachedSensors.Add(lowSensor)
        ElseIf torqueSensors.Count > 1 Then
            For Each s In torqueSensors
                seqNo += 1
                s.SequenceNo = seqNo
            Next
            Dim totalSensor = New DerivedSensor(torqueSensors, Units.Enum_UNIT_TYPE.torque, DerivedSensor.Enum_Derived_Type.total)
            seqNo += 1 : totalSensor.SequenceNo = seqNo
            totalSensor.SS1 = "Total (torque)"
            _gAttachedSensors.Add(totalSensor)
            Dim peakSensor = New DerivedSensor(totalSensor, Units.Enum_UNIT_TYPE.torque, DerivedSensor.Enum_Derived_Type.peak)
            seqNo += 1 : peakSensor.SequenceNo = seqNo
            peakSensor.SS1 = "Peak (Total torque)"
            _gAttachedSensors.Add(peakSensor)
            Dim lowSensor = New DerivedSensor(totalSensor, Units.Enum_UNIT_TYPE.torque, DerivedSensor.Enum_Derived_Type.low)
            seqNo += 1 : lowSensor.SequenceNo = seqNo
            lowSensor.SS1 = "Low (Total torque)"
            _gAttachedSensors.Add(lowSensor)
        End If
    End Sub

    Private Sub AddVoltageSensors(ByRef seqNo As Integer)
        'voltage sensors
        Dim voltageSensors = (From s In _gAttachedSensors Where s.UnitType = Units.Enum_UNIT_TYPE.voltage Order By s.SS1 Select s).ToList
        If voltageSensors.Count = 1 Then
            Dim s As LsSensor = voltageSensors(0)
            seqNo += 1 : s.SequenceNo = seqNo
            Dim peakSensor = New DerivedSensor(s, Units.Enum_UNIT_TYPE.voltage, DerivedSensor.Enum_Derived_Type.peak)
            seqNo += 1 : peakSensor.SequenceNo = seqNo
            peakSensor.SS1 = "Peak (" & s.SS1 & ")"
            _gAttachedSensors.Add(peakSensor)
            '
            Dim lowSensor = New DerivedSensor(s, Units.Enum_UNIT_TYPE.voltage, DerivedSensor.Enum_Derived_Type.low)
            seqNo += 1 : lowSensor.SequenceNo = seqNo
            lowSensor.SS1 = "Low (" & s.SS1 & ")"
            _gAttachedSensors.Add(lowSensor)
        ElseIf voltageSensors.Count > 1 Then
            For Each s In voltageSensors
                seqNo += 1
                s.SequenceNo = seqNo
            Next
            Dim totalSensor = New DerivedSensor(voltageSensors, Units.Enum_UNIT_TYPE.voltage, DerivedSensor.Enum_Derived_Type.total)
            seqNo += 1 : totalSensor.SequenceNo = seqNo
            totalSensor.SS1 = "Total (voltage)"
            _gAttachedSensors.Add(totalSensor)
            Dim peakSensor = New DerivedSensor(totalSensor, Units.Enum_UNIT_TYPE.voltage, DerivedSensor.Enum_Derived_Type.peak)
            seqNo += 1 : peakSensor.SequenceNo = seqNo
            peakSensor.SS1 = "Peak (Total voltage)"
            _gAttachedSensors.Add(peakSensor)
            Dim lowSensor = New DerivedSensor(totalSensor, Units.Enum_UNIT_TYPE.voltage, DerivedSensor.Enum_Derived_Type.low)
            seqNo += 1 : lowSensor.SequenceNo = seqNo
            lowSensor.SS1 = "Low (Total voltage)"
            _gAttachedSensors.Add(lowSensor)
        End If
    End Sub

    Private Sub AddLengthSensors(ByRef seqNo As Integer)
        'length sensors
        Dim lengthSensors = (From s In _gAttachedSensors Where s.UnitType = Units.Enum_UNIT_TYPE.length Order By s.SS1 Select s).ToList
        If lengthSensors.Count = 1 Then
            Dim s As LsSensor = lengthSensors(0)
            seqNo += 1 : s.SequenceNo = seqNo
            Dim peakSensor = New DerivedSensor(s, Units.Enum_UNIT_TYPE.length, DerivedSensor.Enum_Derived_Type.peak)
            seqNo += 1 : peakSensor.SequenceNo = seqNo
            peakSensor.SS1 = "Peak (" & s.SS1 & ")"
            _gAttachedSensors.Add(peakSensor)
            '
            Dim lowSensor = New DerivedSensor(s, Units.Enum_UNIT_TYPE.length, DerivedSensor.Enum_Derived_Type.low)
            seqNo += 1 : lowSensor.SequenceNo = seqNo
            lowSensor.SS1 = "Low (" & s.SS1 & ")"
            _gAttachedSensors.Add(lowSensor)
        ElseIf lengthSensors.Count > 1 Then
            For Each s In lengthSensors
                seqNo += 1
                s.SequenceNo = seqNo
            Next
            Dim totalSensor = New DerivedSensor(lengthSensors, Units.Enum_UNIT_TYPE.length, DerivedSensor.Enum_Derived_Type.total)
            seqNo += 1 : totalSensor.SequenceNo = seqNo
            totalSensor.SS1 = "Total (displacement)"
            _gAttachedSensors.Add(totalSensor)
            Dim peakSensor = New DerivedSensor(totalSensor, Units.Enum_UNIT_TYPE.length, DerivedSensor.Enum_Derived_Type.peak)
            seqNo += 1 : peakSensor.SequenceNo = seqNo
            peakSensor.SS1 = "Peak (Total displacement)"
            _gAttachedSensors.Add(peakSensor)
            Dim lowSensor = New DerivedSensor(totalSensor, Units.Enum_UNIT_TYPE.length, DerivedSensor.Enum_Derived_Type.low)
            seqNo += 1 : lowSensor.SequenceNo = seqNo
            lowSensor.SS1 = "Low (Total displacement)"
            _gAttachedSensors.Add(lowSensor)
        End If
    End Sub

    Private Sub AddTemperatureSensors(ByRef seqNo As Integer)
        'temperature sensors
        Dim temperatureSensors = (From s In _gAttachedSensors Where s.UnitType = Units.Enum_UNIT_TYPE.temperature Order By s.SS1 Select s).ToList
        For Each s In temperatureSensors
            seqNo += 1
            s.SequenceNo = seqNo
        Next
    End Sub

    Private Sub AddActuators(ByRef seqNo As Integer)
        'angle sensors
        'simply assign sequence numbers
        Dim angleSensors = (From s In _gAttachedSensors Where s.UnitType = Units.Enum_UNIT_TYPE.angle Order By s.SS1 Select s).ToList
        If angleSensors.Count = 1 Then
            Dim s As LsSensor = angleSensors(0)
            seqNo += 1 : s.SequenceNo = seqNo
        ElseIf angleSensors.Count > 1 Then
            For Each s In angleSensors
                seqNo += 1
                s.SequenceNo = seqNo
            Next
        End If
    End Sub

    Private Sub AddRelays(ByRef seqNo As Integer)
        'length sensors
        Dim relayChannels = (From s In _gAttachedSensors Where s.UnitType = Units.Enum_UNIT_TYPE.relay Order By s.SS1 Select s).ToList
        If relayChannels.Any Then
            For Each s In relayChannels
                seqNo += 1
                s.SequenceNo = seqNo
            Next
            CType(relayChannels(0), RelayChannel).Parent.Cleanup()
        End If
    End Sub

    Private Sub AddFormulaSensors(ByRef seqNo As Integer)
        Dim formulas As Dictionary(Of String, Formula) = frmFormulaSensors.ReadFormulasFromXmlFile()
        If formulas.Any Then
            For Each item In formulas
                If FormulaSensor.VerifyFormula(item.Value.rhs) Then 'some sensors may be missing
                    Dim fs = New FormulaSensor(item.Key, item.Value.rhs, item.Value.units)
                    seqNo += 1
                    fs.SequenceNo = seqNo
                    _gAttachedSensors.Add(fs)
                End If
            Next
        End If
    End Sub

    Private Sub AddPunchForceSensors(ByRef seqNo As Integer)
        Dim baseSensor = (From item In _gAttachedSensors Where item.SS1 = ConfigXml.Instance.punchForceSensorSs1 Select item).FirstOrDefault
        If baseSensor IsNot Nothing Then
            Dim pfs = New PunchForceSensor(baseSensor)
            _gAttachedSensors.Add(pfs)
            seqNo += 1
            pfs.SequenceNo = seqNo
            Dim pfc = New PunchCompletedSensor(pfs)
            _gAttachedSensors.Add(pfc)
            seqNo += 1
            pfc.SequenceNo = seqNo
        End If

    End Sub

    Private Sub AddFilterSensors(ByRef seqNo As Integer)
        Dim settings = frmFilterSensorSettings.ReadFiltersFromXmlFile()
        If settings.Any Then
            For Each setting In settings
                If (From s In _gAttachedSensors Where s.SS1 = setting.baseSensorSs1 Select s).Any Then
                    Dim fs = New FilterSensor(setting)
                    seqNo += 1
                    fs.SequenceNo = seqNo
                    _gAttachedSensors.Add(fs)
                End If
            Next
        End If
    End Sub

    Private Sub AddAlarms()
        _gAlarms = AlarmsCollection.ReadAlarmSettingsXml()
    End Sub

    Private Sub RunApplicationWithRestart()
        Do
            ConfigXml.RestartApplication = False
            _gAttachedSensors.Clear()
            '  AttachedSensors.RefreshPortList()
            RunApplication()
        Loop Until ConfigXml.RestartApplication = False
    End Sub

    Private Sub RunApplication()

        Dim result As DialogResult = DialogResult.Cancel
        Dim frmDetect As New frmDetectSensors
        'serial, multi-point ect
        If My.Application.CommandLineArgs.Contains("/auto") Then
                _gAttachedSensors.Clear()
                AttachedSensors.RefreshPortList()
                'are there any previously loaded sensors
                If ConfigXml.Instance.selectedSensors.Count <> 0 Then
                    Dim lstMissing As New List(Of String)
                    For Each s In ConfigXml.Instance.selectedSensors
                        If (From item In _gAttachedSensors Where item.SS1 = s).Any = False Then
                            'previous sensor not found
                            lstMissing.Add(s)
                        End If
                    Next
                    If lstMissing.Count <> 0 Then
                        Dim buffer As String = String.Empty
                        For Each s In lstMissing
                            buffer &= s & vbCrLf
                        Next
                        If MsgBox(My.Resources.strMissingSensors.Replace("%x%", buffer), MsgBoxStyle.Question + MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                            Return
                        Else
                            result = frmDetect.ShowDialog()
                        End If
                    Else
                        'all previous sensors have been detected
                        'add other sensors and go to main screen
                        clsGlobals._gAutoStart = True
                        result = DialogResult.OK
                    End If
                Else
                    'no previously loaded sesors
                    Utility.ShowInfoMessage("No previous sensors configured")
                    result = frmDetect.ShowDialog()
                End If
            Else
                result = frmDetect.ShowDialog()
            End If

        If result = DialogResult.OK Then
            If _gAttachedSensors.Count <> 0 Then
                'assign unique sequence numbers to all sensors
                Dim seqNo = -1
                AddForceSensors(seqNo)
                AddTorqueSensors(seqNo)
                AddVoltageSensors(seqNo)
                AddLengthSensors(seqNo)
                AddTemperatureSensors(seqNo)
                AddPressureSensors(seqNo)
                AddFormulaSensors(seqNo)
                AddPunchForceSensors(seqNo)
                AddFilterSensors(seqNo)
                AddAlarms()
                AddRelays(seqNo)

                'now reorder the attached sensors by seqNo
                _gAttachedSensors = (From s In _gAttachedSensors Order By s.SequenceNo, s.SS1 Select s).ToList
#If 0 Then

                Dim frm As New frmSetupCloudAccount
                If frm.ShowDialog() = DialogResult.OK Then
                    MsgBox("success")
                End If
                Return
                TestRTCloudUpload.Upload()
                Return
#End If
                Do
                    ConfigXml.ResetWindowLocations = False
                    _gFrmMain = New frmMainV2()
                    Application.Run(CType(_gFrmMain, frmMainV2))
                Loop Until ConfigXml.ResetWindowLocations = False
            End If '_gAttachedSensors.Count <> 0 Then
        End If

    End Sub

End Module