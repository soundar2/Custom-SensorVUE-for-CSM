Public Class GraphOptionsCollection
    Implements IList(Of GraphOptions)

    Public Shared graphLoggedReadingsOnly As Boolean = False
    Private _lstOptions As New List(Of GraphOptions)
    Private Shared _iniFile As New LvIniFile
    Private Shared _instance As GraphOptionsCollection
    Private Sub New()
    End Sub
    Public Shared Function Instance() As GraphOptionsCollection
        If _instance Is Nothing Then
            _instance = New GraphOptionsCollection
        End If
        Return _instance
    End Function
    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of GraphOptions) Implements System.Collections.Generic.IEnumerable(Of GraphOptions).GetEnumerator
        Return _lstOptions.GetEnumerator
    End Function

    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return _lstOptions.GetEnumerator
    End Function

    Public Sub Add(ByVal item As GraphOptions) Implements System.Collections.Generic.ICollection(Of GraphOptions).Add
        _lstOptions.Add(item)
    End Sub

    Public Sub Clear() Implements System.Collections.Generic.ICollection(Of GraphOptions).Clear
        _lstOptions.Clear()
    End Sub

    Public Function Contains(ByVal item As GraphOptions) As Boolean Implements System.Collections.Generic.ICollection(Of GraphOptions).Contains
        Return _lstOptions.Contains(item)
    End Function

    Public Sub CopyTo(ByVal array() As GraphOptions, ByVal arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of GraphOptions).CopyTo
        _lstOptions.CopyTo(array, arrayIndex)
    End Sub

    Public ReadOnly Property Count() As Integer Implements System.Collections.Generic.ICollection(Of GraphOptions).Count
        Get
            Return _lstOptions.Count
        End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.Generic.ICollection(Of GraphOptions).IsReadOnly
        Get
            Return False
        End Get
    End Property

    Public Function Remove(ByVal item As GraphOptions) As Boolean Implements System.Collections.Generic.ICollection(Of GraphOptions).Remove
        Return _lstOptions.Remove(item)
    End Function

    Public Function IndexOf(ByVal item As GraphOptions) As Integer Implements System.Collections.Generic.IList(Of GraphOptions).IndexOf
        Return _lstOptions.IndexOf(item)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal item As GraphOptions) Implements System.Collections.Generic.IList(Of GraphOptions).Insert
        _lstOptions.Insert(index, item)
    End Sub

    Default Public Property Item(ByVal index As Integer) As GraphOptions Implements System.Collections.Generic.IList(Of GraphOptions).Item
        Get
            Return _lstOptions(index)
        End Get
        Set(ByVal value As GraphOptions)
            _lstOptions(index) = value
        End Set
    End Property

    Public Sub RemoveAt(ByVal index As Integer) Implements System.Collections.Generic.IList(Of GraphOptions).RemoveAt
        _lstOptions.RemoveAt(index)
    End Sub
    Public Shared Function GetDefaultGraph() As GraphOptions
        Dim go As New GraphOptions
        go.xAxisOptions.UseTimeScale = True
        go.xAxisOptions.title = "Time (sec)"
        go.showGrid = True
        go.showLegend = True
        go.Title = _gAttachedSensors(0).DeviceUnitType.ToString & " vs Time"
        go.y1AxisOptions.title = _gAttachedSensors(0).DeviceUnitType.ToString
        go.xAxisOptions.cumulative = True
        go.xAxisOptions.TimeRangeSec = 25
        '
        'set y axis to auto scale and +/- 10% of capacity
        '
        go.y1AxisOptions.autoScale = True
        go.y1AxisOptions.YMax = _gAttachedSensors(0).CapacityInOutputUnits
        go.y1AxisOptions.YMin = -1 * go.y1AxisOptions.YMax


        Dim index As Integer = 0
        For Each sen In _gAttachedSensors
            Dim series As New YAxisSeries
            If sen.Units.UnitType = Units.Enum_UNIT_TYPE.relay Then Continue For
            If TryCast(sen, DerivedSensor) Is Nothing Then
                'regular sensors
                series.ss1 = sen.SS1
                series.lineColor = GraphTheme.GetDefaultColor(index).ToArgb
                index += 1
                'series.lineColor = Color.Black.ToArgb
                go.y1AxisOptions.SeriesCollection.Add(series)
            ElseIf CType(sen, DerivedSensor).DerivedType = DerivedSensor.Enum_Derived_Type.total Then
                series.ss1 = sen.SS1
                series.lineColor = GraphTheme.GetDefaultColor(index).ToArgb
                index += 1
                'series.lineColor = Color.Black.ToArgb
                go.y1AxisOptions.SeriesCollection.Add(series)
            End If
        Next



        Return go
    End Function
End Class
