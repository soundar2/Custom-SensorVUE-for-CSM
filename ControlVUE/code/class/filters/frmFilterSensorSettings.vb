Option Compare Text
Imports com.loadstar.utility
Imports System.IO
Imports System.Xml.Serialization
Imports com.loadstar.utility.Utility
Public Class frmFilterSensorSettings
    Private _currentFilterIndex As Integer = -1
    Private _prevFilterIndex As Integer = -1
    Private _isCurrentNew As Boolean = False
    Private Shared _xmlFile As String = _gConfigFolder & "\filters.xml"
    Private _lstFilterSettings As New List(Of FilterSensor.FilterSensorSetting)

    Private Sub frmFilterSensors_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            If _currentFilterIndex <> -1 Then
                'save the current Filter
                If CtlFilter1.IsOkToSave() Then
                    CtlFilter1.SaveFilterSettings(_lstFilterSettings(_currentFilterIndex))
                Else
                    'bad Filter
                    e.Cancel = True
                    Return
                End If
            Else
                'no current Filter
            End If
            'if reached here save everything to disk
            SaveFiltersToXmlFile()
            ShowInfoMessage("Program will be restarted for the settings to take effect.")
            ConfigXml.RestartApplication = True
        Else
            'discard changes
            'read from disk again
            ReadFiltersFromXmlFile()
        End If
    End Sub
    Private Sub frmFilterSensors_Load(sender As Object, e As EventArgs) Handles Me.Load
        Hourglass.Show()
        CtlFilter1.InitControls()
        CtlFilter1.ClearFilterSettings()
        _lstFilterSettings = ReadFiltersFromXmlFile()
        RePopulateFilters()
        Hourglass.Release()
    End Sub
    Private Sub tvFilter_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvFilter.AfterSelect
        _currentFilterIndex = e.Node.Index
        _prevFilterIndex = e.Node.Index
        CtlFilter1.LoadFilterSettings(_lstFilterSettings(_currentFilterIndex))
        CtlFilter1.Enabled = True
    End Sub
#Region "nonevents"
    Private Sub RePopulateFilters()
        _currentFilterIndex = -1
        _prevFilterIndex = -1
        tvFilter.Nodes.Clear()
        CtlFilter1.ClearFilterSettings()
        If _lstFilterSettings.Count <> 0 Then
            For i = _lstFilterSettings.Count - 1 To 0 Step -1
                'if the base sensor does not exist remove from list
                Dim k = i
                If Not (From item In _gAttachedSensors Where item.SS1 = _lstFilterSettings(k).baseSensorSs1 Select item).Any Then
                    _lstFilterSettings.RemoveAt(k)
                End If
            Next
        End If
        If _lstFilterSettings.Count <> 0 Then
            For i = 0 To _lstFilterSettings.Count - 1
                tvFilter.Nodes.Add(_lstFilterSettings(i).name)
            Next
            tvFilter.SelectedNode = tvFilter.Nodes(0)
        End If
    End Sub
#End Region

    Private Sub tvFilter_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles tvFilter.BeforeSelect
        If _prevFilterIndex <> -1 Then
            If CtlFilter1.IsOkToSave() Then
                CtlFilter1.SaveFilterSettings(_lstFilterSettings(_prevFilterIndex))
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        If _prevFilterIndex <> -1 Then
            If CtlFilter1.IsOkToSave() Then
                CtlFilter1.SaveFilterSettings(_lstFilterSettings(_prevFilterIndex))
            Else
                Return
            End If
        End If
        'create
        _lstFilterSettings.Add(New FilterSensor.FilterSensorSetting)
        CtlFilter1.Enabled = True
        Dim node As New TreeNode("Filter " & _lstFilterSettings.Count)
        With tvFilter.Nodes
            .Add(node)
            _isCurrentNew = True
            tvFilter.SelectedNode = node
        End With
    End Sub

    Private Sub CtlFilter1_NameChanged(name As String)
        If _currentFilterIndex <> -1 Then
            tvFilter.Nodes(_currentFilterIndex).Text = name
        End If
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        With tvFilter
            If MsgBox("Ok to delete?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) = MsgBoxResult.Ok Then
                _lstFilterSettings.RemoveAt(.SelectedNode.Index)
                RePopulateFilters()
            End If
        End With
    End Sub
    Public Shared Function ReadFiltersFromXmlFile() As List(Of FilterSensor.FilterSensorSetting)
        Dim filterSettings As New List(Of FilterSensor.FilterSensorSetting)
        Try
            If My.Computer.FileSystem.FileExists(_xmlFile) Then
                Using sr As New StreamReader(_xmlFile)

                    Dim x As New XmlSerializer(filterSettings.GetType)
                    filterSettings = x.Deserialize(sr)
                End Using
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        Finally
        End Try
        Return filterSettings
    End Function
    Private Sub SaveFiltersToXmlFile()
        Using sw = New StreamWriter(_xmlFile)
            Dim st As New XmlSerializer(_lstFilterSettings.GetType)
            st.Serialize(sw, _lstFilterSettings)
        End Using
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click

    End Sub
End Class