Public Class frmMessageLog
    Private Delegate Sub ShowFormDelegate()
    Public okToClose As Boolean = False
    Private Sub TimerLog_Tick(sender As Object, e As EventArgs) Handles TimerLog.Tick
        While MessageLog.Instance.LogCount > 0
            Dim buf As String
            With Now()
                buf = String.Format("{0:0000}-{1:00}-{2:00} {3:00}:{4:00}:{5:00}", .Year, .Month, .Day, .Hour, .Minute, .Second)
            End With
            Debug.Print(buf)
            TextBox1.AppendText(String.Format("{0}: {1}{2}", buf, MessageLog.Instance.LogItem, vbCrLf))
            Threading.Thread.Sleep(1000) 'without this sleep, this window
            'does not refresh at all in slow computers
        End While
        TextBox1.Refresh()
        If okToClose Then Me.Close()
    End Sub

    Private Sub frmMessageLog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If Not okToClose Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmMessageLog_Load(sender As Object, e As EventArgs) Handles Me.Load
        TimerLog.Enabled = True
    End Sub

    Private Sub mnuClearLog_Click(sender As Object, e As EventArgs) Handles mnuClearLog.Click
        If MsgBox("OK to clear log entries?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Me.TextBox1.Clear()
        End If
    End Sub

    Private Sub mnuHideWindow_Click(sender As Object, e As EventArgs) Handles mnuHideWindow.Click
        Me.Hide()
    End Sub
End Class