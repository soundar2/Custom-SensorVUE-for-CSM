Option Compare Text
Option Explicit On
Option Strict Off
Public Class clsUnits
    Public Enum ENUM_UNITS
        POUNDS = 0
        KG = 1
        N = 2
        KN = 3
        G = 4
        OZ = 5
    End Enum
    Private Shared calibratedUnits_ As ENUM_UNITS = ENUM_UNITS.POUNDS
    Private Shared outputUnits_ As ENUM_UNITS = ENUM_UNITS.POUNDS
    Private Shared cfactor(,) As Double = _
        {{1, 0.453592, 4.44822, 0.00444822, 453.592, 16}, _
        {2.20462442, 1, 9.80665, 0.00980665, 1000, 35.27399072}, _
        {0.224809025, 0.101971621, 1, 0.001, 101.9716213, 3.596944396}, _
        {224.8090247, 101.9716213, 1000.0, 1, 101971.6213, 3596.944396}, _
        {0.002204624, 0.001, 0.00980665, 0.00000980665, 1, 0.035273991}, _
        {0.0625, 0.0283495, 0.27801375, 0.000278014, 28.3495, 1}}

    Public Shared Function GetUnitString(ByVal value As ENUM_UNITS) As String
        Select Case value
            Case ENUM_UNITS.KG
                Return "kg"
            Case ENUM_UNITS.KN
                Return "kN"
            Case ENUM_UNITS.N
                Return "N"
            Case ENUM_UNITS.G
                Return "g"
            Case ENUM_UNITS.OZ
                Return "oz."
            Case Else
                Return "lb."
        End Select
    End Function
    Public Shared Function GetUnitNumber(ByVal value As String) As ENUM_UNITS
        Select Case value
            Case "kg"
                Return ENUM_UNITS.KG
            Case "N"
                Return ENUM_UNITS.N
            Case "kN"
                Return ENUM_UNITS.KN
            Case "g"
                Return ENUM_UNITS.G
            Case "oz."
                Return ENUM_UNITS.OZ
            Case Else
                Return ENUM_UNITS.POUNDS
        End Select
    End Function

    Public Shared Property CalibratedUnits() As ENUM_UNITS
        Get
            Return calibratedUnits_
        End Get
        Set(ByVal value As ENUM_UNITS)
            calibratedUnits_ = value
        End Set
    End Property
    Public Shared Property OutputUnits() As ENUM_UNITS
        Get
            Return outputUnits_
        End Get
        Set(ByVal value As ENUM_UNITS)
            outputUnits_ = value
        End Set
    End Property
    Public Shared Function ConvertToOutputUnits(ByVal value As Double) As Double
        Dim colNo As UInt16 = Convert.ToUInt16(calibratedUnits_)
        Dim rowNo As UInt16 = Convert.ToUInt16(outputUnits_)
        Return cfactor(colNo, rowNo) * value
    End Function
    Public Shared Function ConvertToOutputUnits(ByVal calUnits As clsUnits.ENUM_UNITS, ByVal value As Double) As Double
        Dim colNo As UInt16 = Convert.ToUInt16(calUnits)
        Dim rowNo As UInt16 = Convert.ToUInt16(outputUnits_)
        Return cfactor(colNo, rowNo) * value
    End Function
    Public Shared Function ConvertToUnits(ByVal fromUnits As clsUnits.ENUM_UNITS, ByVal toUnits As clsUnits.ENUM_UNITS, ByVal value As Double) As Double
        Dim colNo As UInt16 = Convert.ToUInt16(fromUnits)
        Dim rowNo As UInt16 = Convert.ToUInt16(toUnits)
        Return cfactor(colNo, rowNo) * value
    End Function
    Public Shared Function GetDefinedUnits() As List(Of String)
        Dim values As Array
        Dim strList As New List(Of String)
        values = [Enum].GetValues(GetType(ENUM_UNITS))
        For Each value As UInteger In values
            strList.Add(GetUnitString(value))
        Next
        Return strList
    End Function
End Class
