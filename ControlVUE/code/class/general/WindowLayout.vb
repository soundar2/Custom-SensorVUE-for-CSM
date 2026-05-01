Public Class WindowLayout
    Private Shared _instance As WindowLayout
    Private _iniFile As String = String.Empty
    Private _screenLayout As String = String.Empty
    Public Enum ENUM_ViewMode
        screen = 0
        mix = 1
        text = 2
        graph = 3
        log = 4
        relay = 5
    End Enum
    Private Sub New()

        'get the default no of sensors
        '
        Dim nSensor = (From s In _gAttachedSensors Where TryCast(s, DerivedSensor) Is Nothing _
                           AndAlso TryCast(s, FilterSensor) Is Nothing _
                           AndAlso TryCast(s, FormulaSensor) Is Nothing
                           Select s).ToList.Count

        _screenLayout = String.Format("n{0}", nSensor)
    End Sub
    Public Shared Function Instance() As WindowLayout
        If _instance Is Nothing Then
            _instance = New WindowLayout
            _instance.currentViewMode = ENUM_ViewMode.mix
            Dim ini As New LvIniFile(_instance._iniFile)
            ini.Section = "default"
            ini.WriteString("view", _instance._screenLayout)
        End If
        Return _instance
    End Function
    Private Shared Function GetSectionPrefix(Optional ByVal idString As String = "")
        Dim prefix As String = String.Empty
        With _instance
            If .currentViewMode = ENUM_ViewMode.screen Then
                prefix = String.Format("View_{0}_{1}", ._screenLayout, .currentViewMode.ToString)
            Else
                prefix = String.Format("View_{0}", .currentViewMode.ToString)
            End If
        End With
        If idString.Length = 0 Then
            Return prefix
        Else
            Return prefix & "_" & idString
        End If
    End Function
    Friend Sub SaveWindowLocation(ByVal frm As Form, ByVal idString As String)
        Dim ini As New LvIniFile(_iniFile)
        '
        'first flag the view as saved
        '
        ini.Section = GetSectionPrefix()
        ini.WriteInteger("Saved", 1)
        ini.Section = GetSectionPrefix(idString)
        ini.DeleteSection()
        'save window state first, then save location
        If frm.WindowState = FormWindowState.Maximized Then
            frm.WindowState = FormWindowState.Normal
        End If
        ini.WriteInteger("windowstate", frm.WindowState)
        Dim mainForm = CType(frm.MdiParent, frmMainV2).ClientWindow
        If frm.WindowState = FormWindowState.Normal Then
            ini.WriteString("x", (frm.Left * 100 / mainForm.ClientSize.Width).ToString("0.00"))
            ini.WriteString("y", (frm.Top * 100 / mainForm.ClientSize.Height).ToString("0.00"))
            ini.WriteString("w", (frm.Width * 100 / mainForm.ClientSize.Width).ToString("0.00"))
            ini.WriteString("h", (frm.Height * 100 / mainForm.ClientSize.Height).ToString("0.00"))
        End If
    End Sub
    Friend Function IsCurrentViewSaved() As Boolean
        Dim ini As New LvIniFile(_iniFile)
        ini.Section = GetSectionPrefix()
        Return ini.GetInteger("Saved", 0) = 1
    End Function
    Friend Sub RestoreWindowLocation(ByVal frm As Form, ByVal idString As String)

        Dim ini As New LvIniFile(_iniFile)
        ini.Section = GetSectionPrefix(idString)
        'restore location first
        Dim ws As FormWindowState = ini.GetInteger("windowstate", 0)
        Select Case ws
            Case FormWindowState.Minimized
                frm.WindowState = FormWindowState.Minimized
            Case Else
                frm.WindowState = FormWindowState.Normal
                If Val(ini.GetString("w", "0")) > 0 Then
                    'this window exists in the ini file
                    Dim mainForm = CType(frm.MdiParent, frmMainV2).ClientWindow
                    frm.Left = Val(ini.GetDouble("x", 0)) / 100 * mainForm.ClientSize.Width
                    frm.Top = Val(ini.GetDouble("y", 0)) / 100 * mainForm.ClientSize.Height
                    frm.Width = Val(ini.GetDouble("w", 100)) / 100 * mainForm.ClientSize.Width
                    frm.Height = Val(ini.GetDouble("h", 100)) / 100 * mainForm.ClientSize.Height
                End If
        End Select


    End Sub

    Friend Sub SaveAllWindowNames(ByVal names As List(Of String))
        Dim ini As New LvIniFile(_iniFile)
        ini.Section = "default"
        ini.WriteBoolean("default", True)
        ini.Section = "AllWindows"
        ini.DeleteSection()
        For i = 0 To names.Count - 1
            ini.WriteString("Name" & i, names(i))
        Next
    End Sub
    Friend Sub DeleteLayoutFile()
        Dim ini As New LvIniFile(_iniFile)
        If My.Computer.FileSystem.FileExists(_iniFile) Then
            My.Computer.FileSystem.DeleteFile(_iniFile)
        End If
        ini.Section = "default"
        ini.WriteBoolean("default", True)
    End Sub
    Private _currentViewMode As ENUM_ViewMode = ENUM_ViewMode.mix
    Public Property currentViewMode() As ENUM_ViewMode
        Get
            Return _currentViewMode
        End Get
        Set(ByVal value As ENUM_ViewMode)
            _currentViewMode = value
            If _currentViewMode = ENUM_ViewMode.screen Then
                _iniFile = My.Application.Info.DirectoryPath & "\data\defaultwindowlayout.ini"
                '_iniFile = _gConfigFolder & "\defaultwindowlayout.ini"
            Else
                _iniFile = _gConfigFolder & "\windowlayout.ini"
            End If
        End Set
    End Property

End Class
