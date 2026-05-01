Imports System.ComponentModel
Imports System.IO
Imports System.IO.Ports
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports com.loadstar.utility
Public Class frmBurnCalibrationFromFile
    Private _calFile As String = ""
    Private _lines As New List(Of String)
    Private _baud As UInteger
    Private WithEvents _thisPort As SerialPort
    Private _context As WindowsFormsSynchronizationContext = WindowsFormsSynchronizationContext.Current
    Private _settingsBurnt As Boolean = False
    Private Sub frmBurnCalibrationFromFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each item As String In (From p As String In SerialPort.GetPortNames().Except(frmIgnorePorts.GetComPortsToIgnore()) Order By p).ToList()
            cmbPorts.Items.Add(item)
        Next
        If cmbPorts.Items.Count > 0 Then
            cmbPorts.SelectedIndex = 0
        End If
        cmbBaud.SelectedIndex = 0
        Me.WindowState = FormWindowState.Maximized
        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub

    Private Sub SetControlStates()

    End Sub

    Private Sub cmdOpenFile_Click(sender As Object, e As EventArgs) Handles cmdOpenFile.Click
        Dim separator As String() = {vbCr, vbLf, vbCrLf}

        Dim dlgOpen As New OpenFileDialog
        dlgOpen.Filter = "Text Files|*.TXT"
        'dlgOpen.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        If dlgOpen.ShowDialog = Windows.Forms.DialogResult.OK Then
            _calFile = dlgOpen.FileName
            Using sr = New StreamReader(_calFile)
                Dim buffer = sr.ReadToEnd
                txtLeft.Text = buffer
                _lines = buffer.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList()
                _lines.RemoveAll(Function(s) s.Trim.Length = 0)
                txtRight.Clear()
            End Using
        End If
        SetControlStates()
    End Sub

    Protected Function TryOpen() As Boolean
        If _thisPort IsNot Nothing AndAlso _thisPort.IsOpen Then
            TryClose()
        End If
        Dim ret As Int16
        Dim msg As String = String.Empty
        Try
            _thisPort = New SerialPort(cmbPorts.Text, Convert.ToInt32(cmbBaud.Text), Parity.None, 8, StopBits.One)
            _thisPort.Handshake = Handshake.None
            _thisPort.ReadBufferSize = 128000
            _thisPort.ReadTimeout = 2000
            _thisPort.WriteTimeout = 1000
            _thisPort.DiscardNull = True
            _thisPort.ReceivedBytesThreshold = 1
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Do
            Try
                _thisPort.Open()
                Return True
            Catch ex As Exception
                'cannot open port
                ret = MsgBox("Error opening " & cmbPorts.Text & vbCrLf & msg, MsgBoxStyle.RetryCancel + MsgBoxStyle.Question)
                If ret = MsgBoxResult.Retry Then
                    Continue Do
                Else
                    Return False
                End If
            End Try
        Loop
    End Function

    Private Function TryClose() As Boolean

        If _thisPort Is Nothing OrElse _thisPort.IsOpen = False Then Return True
        Try
            'port is open
            _thisPort.Close()
            Do
            Loop Until _thisPort.IsOpen() = False
            Return True
        Catch ex As Exception
            MsgBox(String.Format("Unable to close port {0}{1}{2}", cmbPorts.Text, vbCrLf, ex.Message))
            Return False
        End Try
    End Function

    Private Sub cmdReadSettings_Click(sender As Object, e As EventArgs) Handles cmdReadSettings.Click
        txtRight.Clear()
        Hourglass.Show()

        If TryOpen() Then
            _thisPort.Write("SETTINGS" & vbCr)
        End If
        Hourglass.Release()
    End Sub



    Private Sub cmdBurn_Click(sender As Object, e As EventArgs) Handles cmdBurn.Click
        txtRight.Clear()
        Me.Refresh()

        If TryOpen() Then
            Dim lines = txtLeft.Lines
            For Each item As String In lines
                _thisPort.Write(item.Trim + vbCr)
                Thread.Sleep(250)
            Next
            _settingsBurnt = True
        End If
    End Sub

    Private Sub _thisPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles _thisPort.DataReceived
        Try
            Do While _thisPort.BytesToRead > 0
                Dim data As String = _thisPort.ReadTo(vbCr).Trim
                _context.Post(AddressOf UpdateDisplay, data)
                Thread.Sleep(250)
            Loop

        Catch ex As Exception
        End Try
    End Sub
    Private Sub UpdateDisplay(ByVal data As String)
        txtRight.Text += data + vbCrLf
    End Sub

    Private Sub frmBurnCalibrationFromFile_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        TryClose()
    End Sub

    Public ReadOnly Property SettingsBurnt() As Boolean
        Get
            Return _settingsBurnt
        End Get
    End Property
End Class