Option Compare Text
Imports System.IO
Imports System.Xml.Serialization

Public Class AlarmsCollection
    Implements IList(Of Alarm)

    Private _lstAlarm As New List(Of Alarm)
    Private Shared _xmlFile As String = _gConfigFolder & "\alarm.xml"
#Region "interface"


    Public Sub Add(ByVal item As Alarm) Implements System.Collections.Generic.ICollection(Of Alarm).Add
        _lstAlarm.Add(item)
    End Sub

    Public Sub Clear() Implements System.Collections.Generic.ICollection(Of Alarm).Clear
        _lstAlarm.Clear()
    End Sub

    Public Function Contains(ByVal item As Alarm) As Boolean Implements System.Collections.Generic.ICollection(Of Alarm).Contains
        Return _lstAlarm.Contains(item)
    End Function

    Public Sub CopyTo(ByVal array() As Alarm, ByVal arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of Alarm).CopyTo

    End Sub

    Public ReadOnly Property Count() As Integer Implements System.Collections.Generic.ICollection(Of Alarm).Count
        Get
            Return _lstAlarm.Count
        End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.Generic.ICollection(Of Alarm).IsReadOnly
        Get
            Return False
        End Get
    End Property

    Public Function Remove(ByVal item As Alarm) As Boolean Implements System.Collections.Generic.ICollection(Of Alarm).Remove
        Return _lstAlarm.Remove(item)
    End Function

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of Alarm) Implements System.Collections.Generic.IEnumerable(Of Alarm).GetEnumerator
        Return _lstAlarm.GetEnumerator()
    End Function

    Public Function IndexOf(ByVal item As Alarm) As Integer Implements System.Collections.Generic.IList(Of Alarm).IndexOf
        Return _lstAlarm.IndexOf(item)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal item As Alarm) Implements System.Collections.Generic.IList(Of Alarm).Insert
        _lstAlarm.Insert(index, item)
    End Sub

    Default Public Property Item(ByVal index As Integer) As Alarm Implements System.Collections.Generic.IList(Of Alarm).Item
        Get
            Return _lstAlarm(index)
        End Get
        Set(ByVal value As Alarm)
            _lstAlarm(index) = value
        End Set
    End Property

    Public Sub RemoveAt(ByVal index As Integer) Implements System.Collections.Generic.IList(Of Alarm).RemoveAt
        _lstAlarm.RemoveAt(index)
    End Sub

    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return _lstAlarm.GetEnumerator()
    End Function
#End Region
    Public Shared Function ReadAlarmSettingsXml() As List(Of Alarm)


        Dim alarms As New List(Of Alarm)
        Try
            If My.Computer.FileSystem.FileExists(_xmlFile) Then
                Using sr As New StreamReader(_xmlFile)
                    Dim settings As New List(Of Alarm.AlarmSetting)
                    Dim x As New XmlSerializer(settings.GetType)
                    settings = x.Deserialize(sr)
                    If settings.Count > 0 Then
                        For Each setting In settings
                            'does this alarmed sensor exist now
                            Dim sensorName = setting.ss1
                            If AttachedSensors.Contains(sensorName) Then
                                Dim alarm As New Alarm
                                alarm.Setting = setting
                                alarms.Add(alarm)
                            End If
                        Next
                    End If
                End Using
            End If
        Catch ex As Exception
        Finally
        End Try
        Return alarms
    End Function
    Public Shared Sub WriteAlarmSettingsXml(ByVal lstAlarm As List(Of Alarm))
        Dim alarms As New List(Of Alarm)
        Try
            If lstAlarm.Count = 0 Then
                If My.Computer.FileSystem.FileExists(_xmlFile) Then
                    My.Computer.FileSystem.DeleteFile(_xmlFile)
                End If
            Else
                Dim settings As New List(Of Alarm.AlarmSetting)
                For Each al In lstAlarm
                    settings.Add(al.setting)
                Next
                Using sw = New StreamWriter(_xmlFile)
                    Dim st As New XmlSerializer(settings.GetType)
                    st.Serialize(sw, settings)
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
