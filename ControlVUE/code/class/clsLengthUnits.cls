Option Compare Text
Option Explicit On
Option Strict Off
Public Class clsLengthUnits
    Public Enum ENUM_UNITS
        INCHES = 0
        MM = 1
    End Enum
    Private Shared cfactor(,) As Double = _
        {{1, 25.4}, _
        {0.03937, 1}}

    Public Shared Function GetUnitString(ByVal value As ENUM_UNITS) As String
        Select Case value
            Case ENUM_UNITS.MM
                Return "mm"
            Case Else
                Return "in."
        End Select
    End Function
    Public Shared Function GetUnitNumber(ByVal value As String) As ENUM_UNITS
        Select Case value
            Case "mm"
                Return ENUM_UNITS.MM
            Case Else
                Return ENUM_UNITS.INCHES
        End Select
    End Function

    Public Shared Function ConvertToUnits(ByVal fromUnits As clsLengthUnits.ENUM_UNITS, ByVal toUnits As clsLengthUnits.ENUM_UNITS, ByVal value As Double) As Double
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
