Imports com.loadstar.utility
Public Class frmAlarmSettings
    Private _currentAlarmIndex As Integer = -1
    Private _prevAlarmIndex As Integer = -1
    Private _isCurrentNew As Boolean = False

    Private Sub frmAlarmSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            If _currentAlarmIndex <> -1 Then
                'save the current alarm
                If CtlAlarm1.IsOkToSave() Then
                    CtlAlarm1.SaveAlarmSettings(_gAlarms(_currentAlarmIndex))
                Else
                    'bad alarm
                    e.Cancel = True
                    Return
                End If
            Else
                'no current alarm
            End If
            'if reached here save everything to disk
            AlarmsCollection.WriteAlarmSettingsXml(_gAlarms)
            _gAlarms = AlarmsCollection.ReadAlarmSettingsXml
            ConfigXml.Instance.AlarmFile = CtlAlarm1.AlarmFile
            ConfigXml.Instance.WriteConfiguration()
        Else
            'discard changes
            'read from disk again
            _gAlarms = AlarmsCollection.ReadAlarmSettingsXml
        End If
    End Sub
    Private Sub frmAlarmSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Hourglass.Show()
        CtlAlarm1.InitControls()
        'read alarms from file
        _gAlarms = AlarmsCollection.ReadAlarmSettingsXml()
        RePopulateAlarms()
        Hourglass.Release()
    End Sub
    Private Sub tvAlarm_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvAlarm.AfterSelect
        _currentAlarmIndex = e.Node.Index
        _prevAlarmIndex = e.Node.Index
        CtlAlarm1.LoadAlarmSettings(_gAlarms(e.Node.Index))
        CtlAlarm1.Enabled = True
    End Sub
#Region "nonevents"
    Private Sub RePopulateAlarms()
        _currentAlarmIndex = -1
        _prevAlarmIndex = -1
        tvAlarm.Nodes.Clear()
        CtlAlarm1.ClearAlarmSettings()
        If _gAlarms.Count <> 0 Then
            For i = 0 To _gAlarms.Count - 1
                tvAlarm.Nodes.Add(_gAlarms(i).Setting.name)
            Next
            tvAlarm.SelectedNode = tvAlarm.Nodes(0)
        End If
    End Sub
#End Region

    Private Sub tvAlarm_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles tvAlarm.BeforeSelect
        If _prevAlarmIndex <> -1 Then
            If CtlAlarm1.IsOkToSave() Then
                CtlAlarm1.SaveAlarmSettings(_gAlarms(_prevAlarmIndex))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        If _prevAlarmIndex <> -1 Then
            If CtlAlarm1.IsOkToSave() Then
                CtlAlarm1.SaveAlarmSettings(_gAlarms(_prevAlarmIndex))
            Else
                Return
            End If
        End If
        'create
        _gAlarms.Add(New Alarm)
        Dim node As New TreeNode("Alarm " & _gAlarms.Count)
        With tvAlarm.Nodes
            .Add(node)
            _isCurrentNew = True
            tvAlarm.SelectedNode = node
        End With
    End Sub

    Private Sub CtlAlarm1_NameChanged(name As String) Handles CtlAlarm1.NameChanged
        If _currentAlarmIndex <> -1 Then
            tvAlarm.Nodes(_currentAlarmIndex).Text = name
        End If
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        With tvAlarm
            If MsgBox("Ok to delete?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) = MsgBoxResult.Ok Then
                _gAlarms.RemoveAt(.SelectedNode.Index)
                RePopulateAlarms()
            End If
        End With
    End Sub
End Class