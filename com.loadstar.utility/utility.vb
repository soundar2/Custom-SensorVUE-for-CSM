Option Infer On
Option Compare Text
Imports Microsoft.Win32
Imports System.Management
Imports System.IO.Ports
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms
Imports System.Security.Principal

Public Class Utility
    Public Shared Sub ShowErrorMessage(ByVal message As String)
        Hourglass.Release(True)
        MsgBox(message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, My.Application.Info.ProductName)
    End Sub
    Public Shared Sub ShowWarningMessage(ByVal message As String)
        Hourglass.Release(True)
        MsgBox(message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, My.Application.Info.ProductName)
    End Sub
    Public Shared Sub ShowInfoMessage(ByVal message As String)
        Hourglass.Release(True)
        MsgBox(message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, My.Application.Info.ProductName)
    End Sub
    Public Shared Sub FlashControl(ByVal ctl As System.Windows.Forms.Control)
        Try
            Dim oldColor As System.Drawing.Color
            oldColor = ctl.BackColor
            Utility.Beep()

            ctl.BackColor = System.Drawing.Color.Red
            ctl.Refresh()
            System.Threading.Thread.Sleep(300)

            ctl.BackColor = oldColor
            ctl.Refresh()
            System.Threading.Thread.Sleep(300)

            ctl.BackColor = System.Drawing.Color.Red
            ctl.Refresh()
            System.Threading.Thread.Sleep(300)

            ctl.BackColor = oldColor
            ctl.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub SetToolTip(ByVal ctrl As Control, ByVal caption As String)
        Dim toolTip1 As New ToolTip()
        toolTip1.ShowAlways = True
        toolTip1.IsBalloon = True
        toolTip1.UseAnimation = True
        toolTip1.UseFading = True
        toolTip1.SetToolTip(ctrl, caption)
    End Sub
    Public Shared Function IsDotNet4Installed() As Boolean
        Const keyName As String = "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full"
        Return (Registry.GetValue(keyName, "Install", 0) = 1)
        'If Registry.GetValue(keyName, "Install", 0) <> 1 Then
        '    Return False
        'Else
        '    Return True
        'End If
    End Function
    Public Shared Sub SetLatencyTimer(ByVal portName As String)
        Dim regKey As Microsoft.Win32.RegistryKey
        Try
            regKey = My.Computer.Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Enum\FTDIBUS")
            Dim subKeys() As String
            subKeys = regKey.GetSubKeyNames()
            For Each subKey As String In subKeys
                If subKey.Contains("VID_0403+PID_6001") Then
                    Dim fragment As String = "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\FTDIBUS\" & subKey & "\0000\Device Parameters"
                    'get the COM port name for this subkey
                    Dim thisKeyPortName As String
                    thisKeyPortName = My.Computer.Registry.GetValue(fragment, "PortName", Nothing)
                    If thisKeyPortName IsNot Nothing AndAlso CStr(thisKeyPortName) = portName Then
                        'set the latency timer to high speed
                        'get the current latency timer settings
                        Dim lt As Object
                        lt = My.Computer.Registry.GetValue(fragment, "LatencyTimer", Nothing)
                        If lt IsNot Nothing Then
                            lt = Convert.ToUInt16(lt)
                            If lt > 1 Then
                                'need have admin privileges
                                My.Computer.Registry.SetValue(fragment, "LatencyTimer", 1, RegistryValueKind.DWord)
                                Exit Sub
                            End If
                        End If 'If lt IsNot Nothing Then
                    End If
                End If 'subKey.StartsWith("VID_0403+PID_6001") Then
            Next
        Catch ex As Exception
            Dim msg As String = String.Format(My.Resources.LatencyTimerWarning, portName).Replace("|", vbCrLf & vbCrLf)
            ShowWarningMessage(msg)
        Finally
        End Try
    End Sub
    Public Shared Function GetFtdiSerialPortNames() As List(Of String)
        Const FTDI_VID_PID As String = "FTDIBUS\VID_0403+PID_600"
        Dim comPortRegex As Regex = New Regex("COM\d+")
        Dim oq = New System.Management.ObjectQuery("SELECT * FROM Win32_PNPEntity")
        Dim ms = New System.Management.ManagementScope
        Dim query = New ManagementObjectSearcher(ms, oq)
        Dim queryCollection As ManagementObjectCollection = query.Get()
        Dim lstPortNames As New List(Of String)
        For Each mo In queryCollection
            If mo.Properties("pnpDeviceId").Value.ToString.Contains(FTDI_VID_PID) Then
                Dim caption As String = mo.Properties("caption").Value
                Dim m = comPortRegex.Match(caption)
                If m.Success Then
                    lstPortNames.Add(m.Value)
                End If
            End If
        Next
        Return lstPortNames
    End Function
    Public Shared Function GetPencomRelaySerialPortNames() As List(Of String)
        Dim comPortRegex As Regex = New Regex("COM\d+")
        Dim oq = New System.Management.ObjectQuery("SELECT * FROM Win32_PNPEntity")
        Dim ms = New System.Management.ManagementScope
        Dim query = New ManagementObjectSearcher(ms, oq)
        Dim queryCollection As ManagementObjectCollection = query.Get()
        Dim lstPortNames As New List(Of String)
        For Each mo In queryCollection
            If mo.Properties("pnpDeviceId").Value.ToString.Contains("PD") Then
                Dim caption As String = mo.Properties("caption").Value
                Dim m = comPortRegex.Match(caption)
                If m.Success Then
                    lstPortNames.Add(m.Value)
                End If
            End If
        Next
        Return lstPortNames
    End Function

    Public Shared Function GetBlueToothPortNames() As List(Of String)
        Dim bthPorts As New List(Of String)
        Dim serialSearcher =
           New ManagementObjectSearcher("SELECT * FROM Win32_SerialPort")
        Dim ports = (From s As ManagementObject In serialSearcher.Get()
                         Select New With {.Name = s("Name"), .DeviceID = s("DeviceID"), .PNPDeviceID = s("PNPDeviceID")}).ToList() ' DeviceID -- > PNPDeviceID
            For Each port In ports
                If port.PNPDeviceID.ToString().ToUpper().Contains("BTHENUM") Then
                    Dim expression = port.Name
                    Dim re = New Regex("COM\d+")
                    Dim m = re.Match(expression)
                    If m.Success Then
                        Dim portName = re.Match(expression).Value
                        bthPorts.Add(portName)
                    End If
                End If
            Next

        Return bthPorts
    End Function
    Public Shared Function ReverseString(ByVal str As String) As String
        Dim arr = str.ToCharArray
        Array.Reverse(arr)
        Return New String(arr)
    End Function
    Public Shared Sub Beep()
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
    End Sub

    Public Shared Function UserIsAdmin() As Boolean
        Return (New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
    End Function
End Class

