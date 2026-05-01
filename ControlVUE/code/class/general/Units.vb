Public Class Units
    Public Enum Enum_UNIT_TYPE
        none
        force
        torque
        length
        angle
        pressure
        temperature
        relay
        voltage
    End Enum
    Public Event OutputUnitsChanged(ByVal newUnits As String)
    Private _unitType As Enum_UNIT_TYPE = Enum_UNIT_TYPE.force
    Private _unitList As String()
    Private _calibratedUnits As String
    Private _outputUnits As String
    Private _cvFactor As Double = 1
    '
    Private cvfactor(,) As Double
    '
    Public Function GetUnitList() As String()
        Return _unitList
    End Function
    Public Property CalibratedUnits() As String
        Get
            Return _calibratedUnits
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "kg", "kgf"
                    value = "kgf"
                Case "lb", "lbf"
                    value = "lbf"
                Case "g"
                    value = "g"
                Case "N"
                    value = "N"
                Case "kN"
                    value = "kN"
                Case "lb-ft", "lbf-ft"
                    value = "lbf-ft"
                Case "lb-in", "lbf-in"
                    value = "lbf-in"
                Case "kg-m", "kgf-m"
                    value = "kgf-m"
                Case "in.", "inches", "in"
                    value = "in"
                Case "mm", "MM"
                    value = "mm"
                Case "v", "volts", "V", "Volts"
                    value = "volts"
                Case Else
            End Select
            If (From item In _unitList Where item = value Select item).ToList.Count <> 0 Then
                _calibratedUnits = value
            Else
                _calibratedUnits = _unitList(0)
                _outputUnits = _calibratedUnits
                _cvFactor = 1
            End If
        End Set
    End Property
    Public Property OutputUnits() As String
        Get
            Return _outputUnits
        End Get
        Set(ByVal value As String)
            If (From item In _unitList Where item = value Select item).ToList.Count <> 0 Then
                _outputUnits = value
            Else
                _outputUnits = _unitList(0)
            End If
            ComputeCvFactor()
            RaiseEvent OutputUnitsChanged(_outputUnits)
        End Set
    End Property
    Public Function GetDefaultUnits() As String
        Return _unitList(0)
    End Function

    Private Sub ComputeCvFactor()
        If _unitType <> Enum_UNIT_TYPE.temperature Then
            Dim colIndex = 0
            Dim rowIndex = 0
            For i As Integer = 0 To _unitList.Count - 1
                If _calibratedUnits = _unitList(i) Then
                    colIndex = i
                    Exit For
                End If
            Next
            For i As Integer = 0 To _unitList.Count - 1
                If _outputUnits = _unitList(i) Then
                    rowIndex = i
                    Exit For
                End If
            Next
            _cvFactor = cvfactor(colIndex, rowIndex)
        Else
            _cvFactor = 0 'we cannot use a factor alone
            'since the offset is different
        End If
    End Sub
    Public Function ConvertToOutputUnits(ByVal value As Double)
        'convert from calibrated units to output units
        If _unitType <> Enum_UNIT_TYPE.temperature Then
            Return value * _cvFactor
        Else
            If _calibratedUnits = _outputUnits Then Return value
            Select Case _calibratedUnits
                Case "F"
                    'calibrated F, output C
                    Return (value - 32) * 5 / 9
                Case Else
                    'calibrated C, output F
                    Return value * 9 / 5 + 32
            End Select
        End If
    End Function

    Public Sub New(ByVal unitType As Enum_UNIT_TYPE)
        _unitType = unitType
        Select Case unitType
            Case Enum_UNIT_TYPE.length
                _unitList = New String() {"in", "mm", "mil"}
                cvfactor = New Double(,) _
                {{1, 25.4, 1000}, _
                {1 / 25.4, 1, 1000 / 25.4}, _
                {0.001, 0.001 * 25.4, 1}}
            Case Enum_UNIT_TYPE.torque
                _unitList = New String() {"lbf-ft", "lbf-in", "kgf-m", "N-m"}
                cvfactor = New Double(,) _
                  {{1, 12, 0.13825496, 1.355818}, _
                 {0.083333333, 1, 0.01152, 0.112984833}, _
                 {7.233, 86.8, 1, 9.807}, _
                 {0.7376, 8.851, 0.102, 1}}
            Case Enum_UNIT_TYPE.pressure
                _unitList = New String() {"psi", "ksi", "Pa", "KPa", "MPa"}
                cvfactor = New Double(,) _
                {{1, 0.001, 6894.757, 6.894757, 0.006894757}, _
                {1000, 1, 6894757, 6894.757, 6.894757}, _
                {0.000145038, 0.000000145038, 1, 0.001, 0.000001}, _
                {0.145037738, 0.000145038, 1000, 1, 0.001}, _
                {145.037738, 0.145037738, 1000000, 1000, 1}}

            Case Enum_UNIT_TYPE.angle
                _unitList = New String() {"deg"}
                cvfactor = New Double(,) _
                  {{1},
                 {1}}
            Case Enum_UNIT_TYPE.voltage
                _unitList = New String() {"V"}
                cvfactor = New Double(,) _
                  {{1},
                 {1}}
            Case Enum_UNIT_TYPE.temperature
                _unitList = New String() {"C", "F"}
                'cvfactor not used, just a placeholder
                cvfactor = New Double(,) _
                  {{0, 0}, _
                 {0, 0}}
            Case Else
                'force
                _unitList = New String() {"lbf", "kgf", "N", "kN", "g", "oz"}
                cvfactor = New Double(,) _
                {{1, 0.453592, 4.44822, 0.00444822, 453.592, 16}, _
                {2.20462442, 1, 9.80665, 0.00980665, 1000, 35.27399072}, _
                {0.224809025, 0.101971621, 1, 0.001, 101.9716213, 3.596944396}, _
                {224.8090247, 101.9716213, 1000.0, 1, 101971.6213, 3596.944396}, _
                {0.002204624, 0.001, 0.00980665, 0.00000980665, 1, 0.035273991}, _
                {0.0625, 0.0283495, 0.27801375, 0.000278014, 28.3495, 1}}
        End Select

        _calibratedUnits = _unitList(0)
        _outputUnits = _unitList(0)
    End Sub
    Public ReadOnly Property UnitType() As Enum_UNIT_TYPE
        Get
            Return _unitType
        End Get
    End Property
End Class
