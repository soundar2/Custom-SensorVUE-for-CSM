Public Class frmIgnorePorts
    Friend RestartApp As Boolean = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each item In System.IO.Ports.SerialPort.GetPortNames()
            cb1.Items.Add(item)
        Next
        LoadSettings()
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Dim ini As New LvIniFile()
        For i = 0 To cb1.Items.Count - 1
            Dim portName = cb1.GetItemText(cb1.Items(i))
            Dim key = "Ignore-" & portName
            If cb1.GetItemChecked(i) Then
                ini.WriteInteger(key, 1)
            Else
                ini.WriteInteger(key, 0)
            End If
        Next
        Me.Close()
        If RestartApp Then
            Application.Restart()
        End If

    End Sub

    Private Sub LoadSettings()
        Dim ini As New LvIniFile()
        For i = 0 To cb1.Items.Count - 1
            Dim portName = cb1.GetItemText(cb1.Items(i))
            Dim key = "Ignore-" & portName
            If ini.GetInteger(key) = 1 Then
                cb1.SetItemChecked(i, True)
            End If
        Next
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Public Shared Function GetComPortsToIgnore() As List(Of String)
        Dim ini As New LvIniFile()
        Dim portNamesToIgnore As New List(Of String)
        For Each item In System.IO.Ports.SerialPort.GetPortNames()
            Dim key = "Ignore-" & item
            If ini.GetInteger(key) = 1 Then
                portNamesToIgnore.Add(item)
            End If
        Next
        Return portNamesToIgnore
    End Function

End Class
