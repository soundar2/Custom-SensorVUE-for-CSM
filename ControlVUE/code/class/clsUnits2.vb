Option Compare Text
Option Explicit On
Option Strict Off
Imports System.Xml
Imports System.Xml.XPath
Public Class clsUnits2
    Public Enum ENUM_Unit_Type
        Force = 0
        Length = 1
        Torque = 2
    End Enum
    Private _unitType As ENUM_Unit_Type = ENUM_Unit_Type.Force
    Private _defaultUnits As String
    Private _loadvueUnits As String
    Private _docNav As XPathDocument
    Private _unitTypeString As String
    Private _unitList As New List(Of String)
    Private _sensorUnits As String
    Private _cvfToLoadVueUnits As Double = 1
    Public Sub New(ByVal unitType As ENUM_Unit_Type)
        _unitType = unitType
        Select Case unitType
            Case ENUM_Unit_Type.Torque
                _unitTypeString = "torque"
            Case ENUM_Unit_Type.Length
                _unitTypeString = "length"
            Case Else
                _unitTypeString = "force"
        End Select
        '
        Dim xpathString As String
        Dim unitFile As String = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "units.xml")
        _docNav = New XPathDocument(unitFile)
        Dim nav As XPathNavigator = _docNav.CreateNavigator()
        xpathString = "//" & _unitTypeString & "/unit" 'eg: //force/unit
        Dim nodeIter As XPathNodeIterator = nav.Select(xpathString)
        While (nodeIter.MoveNext)
            _unitList.Add(nodeIter.Current.Value)
        End While
        '
        xpathString = "//" & _unitTypeString & "/unit[@default='yes']" 'eg: //force/unit[...
        nodeIter = nav.Select(xpathString)
        nodeIter.MoveNext() 'move to the first node of the result set - only one default anyway
        _defaultUnits = nodeIter.Current.Value
        '
        _sensorUnits = _defaultUnits
        _loadvueUnits = _defaultUnits
    End Sub
    Public ReadOnly Property UnitTypeString() As String
        Get
            Return _unitTypeString
        End Get
    End Property
    Public ReadOnly Property DefaultUnits() As String
        Get
            Return _defaultUnits
        End Get
    End Property
    Public ReadOnly Property UnitList() As List(Of String)
        Get
            Return _unitList
        End Get
    End Property
    Public Property LoadVueUnits() As String
        Get
            Return _loadvueUnits
        End Get
        Set(ByVal value As String)
            _loadvueUnits = _defaultUnits
            'overwrite below
            For Each x As String In _unitList
                If x = value Then
                    _loadvueUnits = value
                End If
            Next
            'set the conversion factor
            Dim strXpath As String = String.Format("//{0}/cvfactor/from[@unit='{1}']/to[@unit='{2}']", _unitTypeString, _sensorUnits, _loadvueUnits)
            Dim nav As XPathNavigator = _docNav.CreateNavigator()
            Dim nodeIter As XPathNodeIterator = nav.Select(strXpath)
            nodeIter = nav.Select(strXpath)
            nodeIter.MoveNext()
            _cvfToLoadVueUnits = Convert.ToDouble(nodeIter.Current.Value)
        End Set
    End Property
    Public WriteOnly Property SensorUnits() As String
        Set(ByVal value As String)
            _sensorUnits = _defaultUnits
            'overwrite below
            For Each x As String In _unitList
                If x = value Then
                    _sensorUnits = value
                    Return
                End If
            Next
        End Set
    End Property
    Public Function ConvertToLoadVueUnits(ByVal value As Double) As Double
        Return _cvfToLoadVueUnits * value
    End Function
    Public Function ConvertToUnits(ByVal fromUnits As String, ByVal tounits As String, ByVal value As Double) As Double
        Dim strXpath As String = String.Format("//{0}/cvfactor/from[@unit='{1}']/to[@unit='{2}']", _unitTypeString, fromUnits, tounits)
        Dim nav As XPathNavigator = _docNav.CreateNavigator()
        Dim nodeIter As XPathNodeIterator = nav.Select(strXpath)
        nodeIter = nav.Select(strXpath)
        nodeIter.MoveNext()
        Dim cvFactor As Double = Convert.ToDouble(nodeIter.Current.Value)
        Return cvFactor * value
    End Function
End Class
