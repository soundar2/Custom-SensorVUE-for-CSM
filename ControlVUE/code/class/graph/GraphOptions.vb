Imports System.Xml.Serialization
Public Class GraphOptions
    Private _title As String
    Public xAxisOptions As New XAxisOptions
    Public y1AxisOptions As New YAxisOptions
    Public y2AxisOptions As New YAxisOptions
    Public showLegend As Boolean = True
    Public showTitle As Boolean = False
    Public titleFontSize As Integer = 12
    Public labelFontSize As Integer = 10
    Public showGrid As Boolean = True
    Public showMinorGrid As Boolean = True
    Public cumulativeMode As Boolean = True
    Public graphLoggedReadingsOnly As Boolean = False
    Public graphEnabled As Boolean = True
    '<XmlIgnore()> Public Shared blackBackground As Boolean = False
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property

    Private Shared _graphRefreshMSec As UShort
    Public Shared Property GraphRefreshMSec() As UShort
        Get
            Return _graphRefreshMSec
        End Get
        Set(ByVal value As UShort)
            _graphRefreshMSec = value
        End Set
    End Property


    Private _defaultTitle As String
    Public Property DefaultTitle() As String
        Get
            Return _defaultTitle
        End Get
        Set(ByVal value As String)
            _defaultTitle = value
        End Set
    End Property
    Public Sub New()
    End Sub
    <XmlIgnore()> Public ReadOnly Property Ss1List() As List(Of String)
        Get
            Dim names = (From item In y1AxisOptions.SeriesCollection Select item.ss1).Union(From item In y2AxisOptions.SeriesCollection Select item.ss1).Distinct.ToList
            Return names
        End Get
    End Property
End Class
